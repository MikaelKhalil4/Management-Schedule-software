using GlobalFunctions;
using Microsoft.VisualBasic;
using MKproject.Schedule;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Markup;
using static MKproject.Management.ClassBundles;
using System.Data.SQLite;
using System.Data.Common;
using Azure.Core;


namespace MKproject.Management
{
    public enum ActionsEnum
    {
        [StringValue("Purchases")]
        Purchases,

        [StringValue("Purchases")]
        SoloPurchases,

        [StringValue("Payments")]
        Payments,

        [StringValue("Offers")]
        Offers,

        [StringValue("Sessions Done")]
        SessionDone
        //later badna nzid el attendace yaane issession is false

    }

    public class ClassBackOffice
    {

        public int ClientID { get; set; }
        public string ActionDetails { get; set; }
        public ActionsEnum ActionType { get; set; }
        public int EmployeeID { get; set; }
        public int? ClientBalanceId { get; set; }//exist only when type is payments and purchase
        public double? AmountPaid { get; set; }//exist only when type is payments
        public int? AttendanceId { get; set; }//exist only when type is SessionDone
        public int? AppointmentId { get; set; }//exist only when type is sessionDone From schedule
        public bool? IsMoneyOrSessionOffre { get; set; }
        public string BalanceOrSessionOffre { get; set; }//fiya tkun session aw Balance has IsBundleOrSessionOffre: format: from/to  100/50   

        public DateTime Date { get; set; }

        public ClassBackOffice(int clientID, ActionsEnum actionType, int employeeID, int idClientBalance, double? amountPaid, int? attendanceId, int? appointmentId, bool? isMoneyOrSessionOffre, string Offre, DateTime date)
        {
            ClientID = clientID;
            ActionType = actionType;
            EmployeeID = employeeID;
            ClientBalanceId = idClientBalance;
            AmountPaid = amountPaid;
            AttendanceId = attendanceId;
            AppointmentId = appointmentId;
            IsMoneyOrSessionOffre = isMoneyOrSessionOffre;
            BalanceOrSessionOffre = Offre;
            Date = date;
        }


        public long InsertToArchiveSQL()
        {
            string query = @"INSERT INTO archive (client_id,action,action_type,employee_id,date,attendance_id,appointment_id,client_balance_id,amount_paid,is_moneyOrsession_offre,previousBalanceOrSession_Offre) 
                                                                VALUES
                                                (@client_id,@action,@action_type,@employee_id,@date,@attendance_id,@appointment_id,@client_balance_id,@amount_paid,@is_moneyOrsession_offre,@previousBalanceOrSession_Offre)";

           
            DbCommand cmd =  Program.CreateCommand(query);
            cmd.AddWithValue("@client_id", ClientID);
            cmd.AddWithValue("@action", ActionDetails);
            cmd.AddWithValue("@action_type", ActionType.ToString());
            cmd.AddWithValue("@employee_id", EmployeeID);

            if (ClientBalanceId != null)
            {
                cmd.AddWithValue("@client_balance_id", ClientBalanceId);
            }
            else
            {
                cmd.AddWithValue("@client_balance_id", DBNull.Value);
            }


            if (AmountPaid != null)
            {

                cmd.AddWithValue("@amount_paid", AmountPaid);
            }
            else
            {
                cmd.AddWithValue("@amount_paid", DBNull.Value);
            }


            if (AttendanceId != null)
                cmd.AddWithValue("@attendance_id", AttendanceId);
            else
                cmd.AddWithValue("@attendance_id", DBNull.Value);


            if (AppointmentId != null)
                cmd .AddWithValue("@appointment_id", AppointmentId);
            else
                cmd.AddWithValue("@appointment_id", DBNull.Value);


            if (IsMoneyOrSessionOffre != null)
            {
                cmd.AddWithValue("@is_moneyOrsession_offre", IsMoneyOrSessionOffre);
                cmd.AddWithValue("@previousBalanceOrSession_Offre", BalanceOrSessionOffre);
            }
            else
            {
                cmd.AddWithValue("@is_moneyOrsession_offre", DBNull.Value);
                cmd.AddWithValue("@previousBalanceOrSession_Offre", DBNull.Value);
            }

            cmd.AddWithValue("@date", Date);

            Program.conOpen();

            cmd.ExecuteNonQuery();
            // Retrieve the archive_id of the newly inserted row
            DbCommand cmdGetId = Program.CreateCommand("SELECT last_insert_rowid();");
            long archiveId = (long)cmdGetId.ExecuteScalar();

            Program.con.Close();

            return archiveId;
        }

        public static DataTable GetBackOffice(bool IsOneYearORAll, int? ClientBalanceId, int? ClientID)
        {
            string query = @"SELECT ar.archive_id,ar.client_id ,ar.action as [Activity History], ar.action_type,ar.employee_id ,ar.date ,
                           ar.attendance_id,ar.client_balance_id, ar.appointment_id,ar.amount_paid,ar.is_moneyOrsession_offre,ar.previousBalanceOrSession_Offre , 
                           emp.first_name as EmployeeFN,emp.last_name as EmpoyeeLN,cl.name as ClientFN,family_name as ClientLN,cl.phone_number as ClientPhoneNumber
                          from archive ar JOIN employee emp  
                         ON ar.employee_id=emp.employee_id 
                        JOIN client cl ON ar.client_id=cl.client_id WHERE 1=1 ";


            if ((bool)IsOneYearORAll)
            {
                query += " And ar.date >= @StartDate ";

            }
            if (ClientBalanceId != null)
            {
                query += " And ar.client_balance_id=@client_balance_id ";
            }
            if (ClientID != null)
            {
                query += " And ar.client_id=@client_id ";
            }
            query += " ORDER by ar.date DESC , ar.archive_id DESC ";//ejbare both

           var cmd = Program.CreateCommand(query);

            if ((bool)IsOneYearORAll)
            {
                DateTime startDate = DateTime.Now.AddDays(-365);
                cmd.AddWithValue("@StartDate", startDate);
            }
            if (ClientBalanceId != null)
            {
                cmd.AddWithValue("@client_balance_id", ClientBalanceId);
            }
            if (ClientID != null)
            {
                cmd.AddWithValue("@client_id", ClientID);
            }

            var sda = Program.CreateDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
       
        public static bool CheckIfDesiredArchiveHasRefrencesInTableArchive(int ClientBalanceId,int archiveID)
        {
            string query = "Select Count(*) from archive where client_balance_id=@client_balance_id and archive_id!=@archive_id ";
            var cmd = Program.CreateCommand(query);
            cmd.AddWithValue("@client_balance_id", ClientBalanceId);
            cmd.AddWithValue("@archive_id", archiveID);
            Program.conOpen();
            int nb = Convert.ToInt32(cmd.ExecuteScalar());
            Program.con.Close();
            if (nb > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static (DateTime?, DateTime?,bool) UndoSoloPurchaseActionsSQL(int ClientId, int AttendanceID, int ArchiveId, int DesiredClientBalanceId, int? AppointmentIdReferringToBackoffice, int? BundleIdReferringToBackOffice)
        {


            //SQL UndoSession Part
            Program.conOpen();




            //Delete archive and update lastvisitsql

            DateTime? NewLastVistDate= DeleteTheArchiveAndUpdateLastVisitSql(ClientId, ArchiveId);


            //ejbare tkun tahet delete el archive kermel el fk 
            string queryDeleteStruct = "Delete FROM  client_services_attendance WHERE attendance_id=@attendance_id";
            var cmdDeleteStruct = Program.CreateCommand(queryDeleteStruct);
            cmdDeleteStruct.AddWithValue("@attendance_id", AttendanceID);
            cmdDeleteStruct.ExecuteNonQuery();
            Program.con.Close();




            //Sql Purchase Part
            string querySelect1 = "Select client_balance_id,client_id,bundle_id,purchase_date,session_left_days,isbundle_membership,due_date,balance,amount_paid from client_balance WHERE client_id=@client_id";
            var cmdSelect1 = Program.CreateCommand(querySelect1);
            cmdSelect1.AddWithValue("@client_id", ClientId);
            var sda1 = Program.CreateDataAdapter(cmdSelect1);
            DataTable dtClientBalanceOriginal = new DataTable();
            sda1.Fill(dtClientBalanceOriginal);

            //we re tracking el bundle li aam naamello undo now
            dtClientBalanceOriginal.PrimaryKey = new DataColumn[] { dtClientBalanceOriginal.Columns["client_balance_id"] };
            DataRow DesiredRow = dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);

            DateTime? MembershipDate;
            bool IsMembershipDateChanged;
            (MembershipDate,IsMembershipDateChanged) = UpdateRegistrationDateSQl(ClientId, DesiredClientBalanceId, dtClientBalanceOriginal, DesiredRow);


            //we re reseting balance, amountpaid, w session left tabaa el client
            double TotalBalanceAmount = 0;
            double TotalPayment = 0;
            foreach (DataRow row in dtClientBalanceOriginal.Rows)
            {
                if (Convert.ToInt32(row["client_balance_id"]) != DesiredClientBalanceId)
                {
                    TotalBalanceAmount += Convert.ToDouble(row["balance"]);
                    TotalPayment += Convert.ToDouble(row["amount_paid"]);
                }

            }
            ClassClientCustom.UpdateClientTotalPaymentSQL(ClientId, TotalPayment, true);
            ClassClientCustom.UpdateClientTotalBalanceSQL(ClientId, TotalBalanceAmount, true);



            ClassClientBalance.DeleteClientBalance(DesiredClientBalanceId);



            if (AppointmentIdReferringToBackoffice != null && BundleIdReferringToBackOffice != null)
            {
                UndoSoloPurchaseActionsSQLScheduleRelated((int)AppointmentIdReferringToBackoffice, (int)BundleIdReferringToBackOffice);
            }

            return (NewLastVistDate, MembershipDate, IsMembershipDateChanged);
        }

        public static void UndoSoloPurchaseActionsSQLScheduleRelated(int AppointmentId, int BundleId)
        {
            DataTable RelatedSoloBundles = ClassAppointment.GetRelatedSoloBundles(AppointmentId);
            if (RelatedSoloBundles.Rows.Count == 1)
            {
                ClassAppointment classAppointment = (new ClassAppointment());
                classAppointment.AppointmentID = AppointmentId;
                classAppointment.IsCompleted = false;
                classAppointment.UndoCompletionAppointmentSQL();//in this function UndoCompletionAppointment kell shi elo aalea bel archive juweta ma elo aaze since eemelna undo bel backoffice abel ma nfout aa hal function
            }
            else if (RelatedSoloBundles.Rows.Count > 1)
            {
                ClassAppointment.DeleteRelatedSoloBundle(AppointmentId, BundleId);
            }
            //it can be 0 eza ken package mesh Solo Service 
        }

        public static (bool, DateTime?,bool) UndoPurchaseActionsSQL(int ClientId, int DesiredClientBalanceId)
        {

            string querySelect1 = "Select client_balance_id,client_id,bundle_id,purchase_date,session_left_days,isbundle_membership,due_date,balance,amount_paid from client_balance WHERE client_id=@client_id";
            var cmdSelect1 = Program.CreateCommand(querySelect1);
            cmdSelect1.AddWithValue("@client_id", ClientId);
            var sda1 = Program.CreateDataAdapter(cmdSelect1);
            DataTable dtClientBalanceOriginal = new DataTable();
            sda1.Fill(dtClientBalanceOriginal);

            //we re tracking el bundle li aam naamello undo now
            dtClientBalanceOriginal.PrimaryKey = new DataColumn[] { dtClientBalanceOriginal.Columns["client_balance_id"] };
            DataRow DesiredRow = dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);
            bool IsBundleOrProduct;
            if (DesiredRow["bundle_id"] != DBNull.Value)
            {
                IsBundleOrProduct = true;
            }
            else
            {
                IsBundleOrProduct = false;
            }


            //update Registrationdate
            DateTime? MembershipDate = null;
            bool IsMembershipDateChanged=false;
            if (IsBundleOrProduct)//bundle
            {
                (MembershipDate, IsMembershipDateChanged)= UpdateRegistrationDateSQl(ClientId, DesiredClientBalanceId, dtClientBalanceOriginal, DesiredRow);
            }

            //we re reseting balance, amountpaid, w session left tabaa el client
            double TotalBalanceAmount = 0;
            double TotalPayment = 0;
            int totalsessionLeft = 0;
            foreach (DataRow row in dtClientBalanceOriginal.Rows)
            {
                if (Convert.ToInt32(row["client_balance_id"]) != DesiredClientBalanceId)
                {
                    TotalBalanceAmount += Convert.ToDouble(row["balance"]);
                    TotalPayment += Convert.ToDouble(row["amount_paid"]);

                    if (IsBundleOrProduct && row["session_left_days"] != DBNull.Value && row["due_date"] == DBNull.Value)//sessions only, w eza ken el el click row now huwwe bundle
                    {
                        totalsessionLeft += Convert.ToInt32(row["session_left_days"]);
                    }
                }

            }
            ClassClientCustom.UpdateClientTotalPaymentSQL(ClientId, TotalPayment, true);
            ClassClientCustom.UpdateClientTotalBalanceSQL(ClientId, TotalBalanceAmount, true);



            ClassClientBalance.DeleteClientBalance(DesiredClientBalanceId);



            return (IsBundleOrProduct, MembershipDate,IsMembershipDateChanged);
        }

        public static void UndoPaymentActionsSQL(int ClientID, int ClientBalanceId, int ArchiveId, DateTime ArchiveDate, double AmountPaid)
        {

            double NewAmountPaid, NewBalance;
            (NewAmountPaid, NewBalance) = ClassClientBalance.GetClientBalanceSpecificItem(ClientBalanceId);
            NewAmountPaid -= AmountPaid;
            NewBalance -= AmountPaid;

            Program.conOpen();

            string queryUpdateBalance = "UPDATE client_balance SET amount_paid=@amount_paid,balance=@balance,is_expired='0' WHERE  client_balance_id=@client_balance_id";
            var cmdUpdateBalance = Program.CreateCommand(queryUpdateBalance);
            cmdUpdateBalance.AddWithValue("@client_balance_id", ClientBalanceId);
            cmdUpdateBalance.AddWithValue("@amount_paid", NewAmountPaid);
            cmdUpdateBalance.AddWithValue("@balance", NewBalance);
            cmdUpdateBalance.ExecuteNonQuery();


            string queryDeleteIncome = "Delete FROM  finance WHERE archive_id=@archive_id";
            var cmdDeleteIncome = Program.CreateCommand(queryDeleteIncome);
            cmdDeleteIncome.AddWithValue("@archive_id", ArchiveId);
            cmdDeleteIncome.ExecuteNonQuery();

            string queryDeleteArchive = "Delete FROM  archive WHERE archive_id=@archive_id";
            var cmdDeleteArchive = Program.CreateCommand(queryDeleteArchive);
            cmdDeleteArchive.AddWithValue("@archive_id", ArchiveId);
            cmdDeleteArchive.ExecuteNonQuery();


            string queryUpdateClient = "UPDATE client SET total_payment=total_payment-@total_payment,total_balance=total_balance-@total_balance WHERE client_id=@client_id";
            var cmdUpdateClient = Program.CreateCommand(queryUpdateClient);
            cmdUpdateClient.AddWithValue("@client_id", ClientID);
            cmdUpdateClient.AddWithValue("@total_payment", AmountPaid);
            cmdUpdateClient.AddWithValue("@total_balance", AmountPaid);
            cmdUpdateClient.ExecuteNonQuery();

            Program.con.Close();

        }
        public static bool CheckIfClientBalanceHasArchiveId(int ArchiveId)//hayde eemelneha men baaed ma ktashafna enno fi meshekle bel data el adime w ma aam yenaamalun undo
        {
            bool exists = false;
            Program.conOpen();
            string query = "select * from finance where archive_id=@archive_id";
            var cmd = Program.CreateCommand(query);
            cmd.AddWithValue("@archive_id", ArchiveId);
            using (var reader = cmd.ExecuteReader())
            {
                exists = reader.HasRows;
            }
            Program.con.Close();

            return exists;
        }


        public static DateTime? UndoSessionDoneActionsSQL(int ClientId, int AttendanceID, int ArchiveId, int ClientBalanceId, bool IsDeletingTheBundle, int? AppointmentIdReferringToBackoffice)
        {

            Program.conOpen();
            //update lastvisit      
            DateTime? NewLastVistDate = DeleteTheArchiveAndUpdateLastVisitSql(ClientId, ArchiveId);


            if (!IsDeletingTheBundle)//cz ha aam naayetla marten yaa nehna w aam nmahe bundle ya aade, so to optimise
            {
                string queryUpdateSession = "UPDATE client_balance SET session_left_days=session_left_days+@session_left_days,is_expired='0' WHERE  client_balance_id=@client_balance_id";
                var cmdUpdateSession = Program.CreateCommand(queryUpdateSession);
                cmdUpdateSession.AddWithValue("@client_balance_id", ClientBalanceId);
                cmdUpdateSession.AddWithValue("session_left_days", 1);
                cmdUpdateSession.ExecuteNonQuery();//ejbare hone, cz badna el expiry date abel ma tenaamalla update
            }


            string queryDeleteStruct = "Delete FROM  client_services_attendance WHERE attendance_id=@attendance_id";
            var cmdDeleteStruct = Program.CreateCommand(queryDeleteStruct);
            cmdDeleteStruct.AddWithValue("@attendance_id", AttendanceID);
            cmdDeleteStruct.ExecuteNonQuery(); //ejbare tkun tahet delete el archive kermel el fk

            Program.con.Close();

            if (AppointmentIdReferringToBackoffice != null)
            {
                ClassAppointment classAppointment = new ClassAppointment();
                classAppointment.AppointmentID = (int)AppointmentIdReferringToBackoffice;
                classAppointment.IsCompleted = false;
                classAppointment.SetOrResetIsCompleted();
            }

            return (NewLastVistDate);


        }

        public static bool CanUndoOffresSQL(int ClientID, int ArchiveId, int ClientBalanceId)
        {

            string QuerySelect = "Select archive_id from archive Where client_id=@client_id and client_balance_id=@client_balance_id and date = (Select Max(date) from archive where client_balance_id=@client_balance_id)";
            var cmdSelect = Program.CreateCommand(QuerySelect);
            cmdSelect.AddWithValue("@client_id", ClientID);
            cmdSelect.AddWithValue("@client_balance_id", ClientBalanceId);
            var sda1 = Program.CreateDataAdapter(cmdSelect);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);

            bool IsTheLastAction = false;
            foreach (DataRow dr in dt1.Rows)//since ma3wol ykun eena two rows at the same time , eza eemele edit lal balance w session at the same time byenzalo bzeit el waet
            {
                if (Convert.ToInt32(dr["archive_id"]) == ArchiveId)
                {
                    IsTheLastAction = true;
                    break;
                }
                IsTheLastAction = false;
            }

            return IsTheLastAction;

        }
        public static void UndoOffresSQL(int ArchiveId)
        {

            string queryDeleteArchive = "Delete FROM  archive WHERE archive_id=@archive_id";
            var cmdDeleteArchive = Program.CreateCommand(queryDeleteArchive);
            cmdDeleteArchive.AddWithValue("@archive_id", ArchiveId);
            Program.conOpen();
            cmdDeleteArchive.ExecuteNonQuery();
            Program.con.Close();

        }


        static DateTime? DeleteTheArchiveAndUpdateLastVisitSql(int ClientId, int ArchiveId)
        {
            
            string querySelect = @"
                             SELECT MAX(c.execute_date) 
                             FROM archive AS a
                             JOIN client_services_attendance AS c ON a.attendance_id = c.attendance_id
                             WHERE a.client_id = @client_id AND a.archive_id != @archive_id";


            var cmdSelect = Program.CreateCommand(querySelect);
            cmdSelect.AddWithValue("@client_id", ClientId);
            cmdSelect.AddWithValue("@archive_id", ArchiveId);
            var sda2 = Program.CreateDataAdapter(cmdSelect);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
     
            

            DateTime? NewLastVistDate= cmdSelect.ExecuteScalar() is DBNull ? null : Convert.ToDateTime(cmdSelect.ExecuteScalar()) ; 
          

            string queryUpdateClient = "UPDATE client SET check_in=@check_in WHERE client_id=@client_id";
            var cmdUpdateClient = Program.CreateCommand(queryUpdateClient);
            cmdUpdateClient.AddWithValue("@client_id", ClientId);
            if (NewLastVistDate != null)
            {
                cmdUpdateClient.AddWithValue("@check_in", NewLastVistDate);
            }
            else
            {
                cmdUpdateClient.AddWithValue("@check_in", DBNull.Value);
            }

            cmdUpdateClient.ExecuteNonQuery();


            //ejabre hone, cz foe aam nestamail hayda el archive id
            string queryDeleteArchive = "Delete FROM  archive WHERE archive_id=@archive_id";
            var cmdDeleteArchive = Program.CreateCommand(queryDeleteArchive);
            cmdDeleteArchive.AddWithValue("@archive_id", ArchiveId);
            cmdDeleteArchive.ExecuteNonQuery();
           
            
            return NewLastVistDate;
        }
        static (DateTime?,bool) UpdateRegistrationDateSQl(int ClientId, int DesiredClientBalanceId, DataTable dtClientBalanceOriginal, DataRow DesiredRow)
        {
            bool IsMembershipDateChanged=false;
            DateTime? MembershipDate=null;
            //updating client Membership
            if (Convert.ToBoolean(DesiredRow["isbundle_membership"]) == true)//lieanno eza ma kenit member ship, membershipdate makhasso fiya men el ases
            {
                IsMembershipDateChanged = true;

                DataRow[] filteredRows = dtClientBalanceOriginal.Select("client_id = " + ClientId + " AND bundle_id IS NOT NULL AND client_balance_id <>" + DesiredClientBalanceId + "");
                if (filteredRows.Length > 0)
                {
                    // There were results
                    DataTable dt2 = filteredRows.CopyToDataTable();
                    MembershipDate = DateTime.MaxValue;
                    foreach (DataRow row in dt2.Rows)
                    {
                        if (Convert.ToBoolean(row["isbundle_membership"]) == true)
                        {
                            if (row["purchase_date"] != DBNull.Value && Convert.ToDateTime(row["purchase_date"]) < MembershipDate)
                            {
                                MembershipDate = Convert.ToDateTime(row["purchase_date"]);
                            }
                        }

                    }
                    if (MembershipDate == DateTime.MaxValue)
                    {
                        MembershipDate = null;
                    }
                }

                string queryUpdate = "UPDATE client SET Registration_Date=@Registration_Date WHERE client_id=@client_id";
                var cmdUpdate = Program.CreateCommand(queryUpdate);
                cmdUpdate.AddWithValue("@client_id", ClientId);
                if (MembershipDate != null)
                {
                    cmdUpdate.AddWithValue("@Registration_Date", MembershipDate);
                }
                else
                {
                    cmdUpdate.AddWithValue("@Registration_Date", DBNull.Value);
                }
                Program.conOpen();
                cmdUpdate.ExecuteNonQuery();
                Program.con.Close();

            }
            return (MembershipDate,IsMembershipDateChanged);
        }



        public void CreateActionDetails(DataRow DesiredClientBalanceRow)// aa ases view model tkun w nshil ActionDetails men sql w nwaffir a lot of storage,bas bad performance bel view model aa desptop app,But web lvl good eza server awe (men waffir ktir storage)
        {
            if (DesiredClientBalanceRow != null)//till now kell archive elun aalea bel client balance, ma32oul tetghayar in the future
            {
                //!!!el maaloumet li bi hemmun men el clientBalanceId aam nnjibun mannun latest update since after this opearion bel mother form aam yenaamal new update
                // bas nehna ma bi hemna gher maaloumet ma byetghayaro bhayetun aa wala update w ma aam notalaa aal values as null or not null ta naari type of package
                int? bundleId = DesiredClientBalanceRow["bundle_id"] is DBNull ? null : Convert.ToInt32(DesiredClientBalanceRow["bundle_id"]);
                int? productId = DesiredClientBalanceRow["product_id"] is DBNull ? null : Convert.ToInt32(DesiredClientBalanceRow["product_id"]);
                DateTime? DueDate = DesiredClientBalanceRow["due_date"] is DBNull ? null : Convert.ToDateTime(DesiredClientBalanceRow["due_date"]);
                int? SessionLeftDays = DesiredClientBalanceRow["session_left_days"] is DBNull ? null : Convert.ToInt32(DesiredClientBalanceRow["session_left_days"]);


                string BundleName = "";
                String ProductName = "";
                string BackOfficeCatName = "";
                string BackOfficeCatType = "";
                if (bundleId != null)
                {
                    BundleName = ClassBundles.FindBundleName((int)bundleId);

                    BackOfficeCatName = BundleName;
                    if (SessionLeftDays == null)//solo
                    {
                        BackOfficeCatType = "";
                    }
                    else
                    {
                        BackOfficeCatType = " Package";
                    }
                }
                else
                {
                    ProductName = ClassProduct.FindProductName((int)productId);
                    BackOfficeCatName = ProductName;
                    BackOfficeCatType = "";
                }



                if (ActionType == ActionsEnum.Purchases)
                {


                    if (bundleId != null)
                    {
                        ActionDetails = "Purchased the " + BundleName + BackOfficeCatType;

                    }
                    else
                    {
                        ActionDetails = "Purchased " + ProductName;
                    }



                }
                else if (ActionType == ActionsEnum.SoloPurchases)//only Bundles
                {
                    ActionDetails = "Purchased and Completed " + BundleName + BackOfficeCatType;


                }
                else if (ActionType == ActionsEnum.SessionDone)
                {

                    ActionDetails = "Completed a " + BundleName + " session";


                }
                else if (ActionType == ActionsEnum.Payments)
                {


                    ActionDetails = "Paid " + Currency.Symbol + AmountPaid + " for the " + BackOfficeCatName + BackOfficeCatType;


                }
                else if (ActionType == ActionsEnum.Offers)
                {


                    double FromOffre = Convert.ToDouble(BalanceOrSessionOffre.Split('/')[0]);
                    double ToOffre = Convert.ToDouble(BalanceOrSessionOffre.Split('/')[1]);


                    if ((bool)IsMoneyOrSessionOffre)
                    {
                        string Discount = Convert.ToString((ToOffre - FromOffre) * -1);//leh hone aam nehke bundle side, yaane eza zedtello 50 aal balance tabaao, means eemeltello bundle discount 50
                        if (Discount.Contains('-'))
                        {
                            Discount = Discount.Substring(1);
                            Discount = Currency.Symbol + Discount + " Discount";

                        }
                        else
                        {
                            Discount = Currency.Symbol + Discount + " Addition";
                        }


                        ActionDetails = "Received an offer on the " + BackOfficeCatName + BackOfficeCatType + ": " + Currency.Symbol + Math.Abs(FromOffre) + "->" + Currency.Symbol + Math.Abs(ToOffre) + " (" + Discount + ")";

                    }
                    else
                    {
                        string type;
                        if (DueDate == null)
                        {
                            type = ClassBundles.Session;
                        }
                        else
                        {
                            type = ClassBundles.Days;
                        }
                        ActionDetails = "Received an offer on the " + BackOfficeCatName + BackOfficeCatType + ": " + FromOffre + " " + type + "->" + ToOffre + " " + type;

                    }

                }


                if (ActionType == ActionsEnum.SessionDone || ActionType == ActionsEnum.SoloPurchases)
                {
                    DateTime ExecutedDate = SQLToProject.GetAttendanceDateOfSpecificAttendace((int)AttendanceId);

                    if (AppointmentId != null)
                    {
                        ActionDetails += " From the schedule.";
                    }
                    else
                    {
                        ActionDetails += " Manually.";
                    }
                    ActionDetails += "\n" + ExecutedDate.ToString("dddd, MMMM dd yyyy 'at' h:mm tt") + ".";
                }
                else
                {
                    ActionDetails += ".";
                }

            }


        }



    }



}
