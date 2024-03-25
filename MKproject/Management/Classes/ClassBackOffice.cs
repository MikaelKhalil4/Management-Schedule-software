using GlobalFunctions;
using Microsoft.VisualBasic;
using MKproject.Schedule;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static MKproject.Management.ClassBundles;



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
        static SqlConnection con = new SqlConnection(Program.DataLocation);

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


        public void InsertToArchiveSQL()
        {
            string query = @"INSERT INTO archive (client_id,action,action_type,employee_id,date,attendance_id,appointment_id,client_balance_id,amount_paid,is_moneyOrsession_offre,previousBalanceOrSession_Offre,Currency_Name) 
                                                                VALUES
                                                (@client_id,@action,@action_type,@employee_id,@date,@attendance_id,@appointment_id,@client_balance_id,@amount_paid,@is_moneyOrsession_offre,@previousBalanceOrSession_Offre,@Currency_Name)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            cmd.Parameters.AddWithValue("@action", ActionDetails);
            cmd.Parameters.AddWithValue("@action_type", ActionType.ToString());
            cmd.Parameters.AddWithValue("@employee_id", EmployeeID);

            if (ClientBalanceId != null)
            {
                cmd.Parameters.AddWithValue("@client_balance_id", ClientBalanceId);
            }
            else
            {
                cmd.Parameters.AddWithValue("@client_balance_id", DBNull.Value);
            }


            if (AmountPaid != null)
            {

                cmd.Parameters.AddWithValue("@amount_paid", AmountPaid);
                cmd.Parameters.AddWithValue("@Currency_Name", Currency.CurrencyName);
            }
            else
            {
                cmd.Parameters.AddWithValue("@amount_paid", DBNull.Value);
                cmd.Parameters.AddWithValue("@Currency_Name", DBNull.Value);
            }


            if (AttendanceId != null)
                cmd.Parameters.AddWithValue("@attendance_id", AttendanceId);
            else
                cmd.Parameters.AddWithValue("@attendance_id", DBNull.Value);


            if (AppointmentId != null)
                cmd.Parameters.AddWithValue("@appointment_id", AppointmentId);
            else
                cmd.Parameters.AddWithValue("@appointment_id", DBNull.Value);


            if (IsMoneyOrSessionOffre != null)
            {
                cmd.Parameters.AddWithValue("@is_moneyOrsession_offre", IsMoneyOrSessionOffre);
                cmd.Parameters.AddWithValue("@previousBalanceOrSession_Offre", BalanceOrSessionOffre);
            }
            else
            {
                cmd.Parameters.AddWithValue("@is_moneyOrsession_offre", DBNull.Value);
                cmd.Parameters.AddWithValue("@previousBalanceOrSession_Offre", DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@date", Date);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static DataTable GetBackOffice(bool IsOneYearORAll, int? ClientBalanceId, int? ClientID)
        {
            SqlCommand cmd;
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
            query += " ORDER by archive_id DESC ";

            cmd = new SqlCommand(query, con);

            if ((bool)IsOneYearORAll)
            {
                DateTime startDate = DateTime.Now.AddDays(-365);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
            }
            if (ClientBalanceId != null)
            {
                cmd.Parameters.AddWithValue("@client_balance_id", ClientBalanceId);
            }
            if (ClientID != null)
            {
                cmd.Parameters.AddWithValue("@client_id", ClientID);
            }

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public void CreateActionDetails(DataRow DesiredClientBalanceRow)// aa ases view model tkun w nshil ActionDetails men sql w nwaffir a lot of storage,bas bad performance bel view model aa desptop app,But web lvl good eza server awe (men waffir ktir storage)
        {
            if (DesiredClientBalanceRow != null)//till now kell archive elun aalea bel client balance, ma32oul tetghayar in the future
            {
                //!!!el maaloumet li bi hemmun men el clientBalanceId aam nnjibun mannun latest update since after this opearion bel mother form aam yenaamal new update
                // bas nehna ma bi hemna gher maaloumet ma byetghayaro bhayetun aa wala update w ma aam notalaa aal values as null or not null ta naari type of package
                int? bundleId = DesiredClientBalanceRow["bundle_id"] is DBNull ? null : (int)DesiredClientBalanceRow["bundle_id"];
                int? productId = DesiredClientBalanceRow["product_id"] is DBNull ? null : (int)DesiredClientBalanceRow["product_id"];
                DateTime? DueDate = DesiredClientBalanceRow["due_date"] is DBNull ? null : (DateTime)DesiredClientBalanceRow["due_date"];
                int? SessionLeftDays = DesiredClientBalanceRow["session_left_days"] is DBNull ? null : (int)DesiredClientBalanceRow["session_left_days"];


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


                    ActionDetails = "Completed a session";


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


                if (ActionType != ActionsEnum.Payments && ActionType != ActionsEnum.Offers && productId == null)//only services, w it should be ya purchase ya sessionDone
                {
                    if (AppointmentId != null)
                    {
                        ActionDetails += " From the schedule.";
                    }
                    else
                    {
                        ActionDetails += " Manually.";
                    }
                }
                else
                {
                    ActionDetails += ".";
                }

            }


        }

        public static void UndoSoloPurchaseActionsSQL(int ClientId, int AttendanceID, int ArchiveId, int DesiredClientBalanceId, int? AppointmentIdReferringToBackoffice, int? BundleIdReferringToBackOffice, BackOffice backofficeform)
        {


            //SQL UndoSession Part
            con.Open();




            //Delete archive and update lastvisitsql
            DataTable dt1;
            DateTime? NewLastVistDate;
            (NewLastVistDate, dt1) = DeleteTheArchiveAndUpdateLastVisitSql(ClientId, ArchiveId);


            //ejbare tkun tahet delete el archive kermel el fk 
            string queryDeleteStruct = "DELETE client_services_attendance WHERE attendance_id=@attendance_id";
            SqlCommand cmdDeleteStruct = new SqlCommand(queryDeleteStruct, con);
            cmdDeleteStruct.Parameters.AddWithValue("@attendance_id", AttendanceID);
            cmdDeleteStruct.ExecuteNonQuery();
            con.Close();




            //Sql Purchase Part
            string querySelect1 = "Select client_balance_id,client_id,bundle_id,purchase_date,session_left_days,isbundle_membership,due_date,balance,amount_paid from client_balance WHERE client_id=@client_id";
            SqlCommand cmdSelect1 = new SqlCommand(querySelect1, con);
            cmdSelect1.Parameters.AddWithValue("@client_id", ClientId);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmdSelect1);
            DataTable dtClientBalanceOriginal = new DataTable();
            sda1.Fill(dtClientBalanceOriginal);

            //we re tracking el bundle li aam naamello undo now
            dtClientBalanceOriginal.PrimaryKey = new DataColumn[] { dtClientBalanceOriginal.Columns["client_balance_id"] };
            DataRow DesiredRow = dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);

            DateTime? MembershipDate;
            MembershipDate = UpdateRegistrationDateSQl(ClientId, DesiredClientBalanceId, dtClientBalanceOriginal, DesiredRow);


            //we re reseting balance, amountpaid, w session left tabaa el client
            double TotalBalanceAmount = 0;
            double TotalPayment = 0;
            foreach (DataRow row in dtClientBalanceOriginal.Rows)
            {
                if ((int)row["client_balance_id"] != DesiredClientBalanceId)
                {
                    TotalBalanceAmount += Convert.ToDouble(row["balance"]);
                    TotalPayment += (double)row["amount_paid"];
                }

            }
            ClassClient.UpdateClientTotalPaymentSQL(ClientId, TotalPayment);
            ClassClient.UpdateClientTotalBalanceSQL(ClientId, TotalBalanceAmount);



            ClassClientBalance.DeleteClientBalance(DesiredClientBalanceId);


            if (AppointmentIdReferringToBackoffice != null && BundleIdReferringToBackOffice!=null)
            {
                UndoSoloPurchaseActionsSQLScheduleRelated((int)AppointmentIdReferringToBackoffice,(int)BundleIdReferringToBackOffice);
            }


            //Design wise
            if (backofficeform != null)
            {
                //Datagridview 


                //datagridbalance bel profile 

                DataRow rowToEdit = backofficeform.ParentFormClientManagem.dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);
                rowToEdit.Delete();
                backofficeform.ParentFormClientManagem.dtClientBalanceOriginal.AcceptChanges();
                backofficeform.ParentFormClientManagem.FormatDatagridviewDesign();
                //datagridbalance bel backoffice el tahteniye
                backofficeform.DesiredBalanceRowsdt.Rows[0].Delete();
                backofficeform.DesiredBalanceRowsdt.AcceptChanges();
                //deleting the uc pakcgae


                backofficeform.ParentFormClientManagem.CalculatingTotalBalances(false);
                backofficeform.ParentFormClientManagem.CalculatingClientHistory(false);
                backofficeform.ParentFormClientManagem.datagridviewBalanceMode();
                //

                backofficeform.ParentFormClientManagem.Client.RegistrationDate = MembershipDate;
                if (MembershipDate != null)
                {
                    backofficeform.ParentFormClientManagem.UCMemberSince.Detail = RandomFunctions.SetDateFormat(((DateTime)MembershipDate).ToString());
                }
                else
                {
                    backofficeform.ParentFormClientManagem.UCMemberSince.Detail = "N/A";
                }


                if ((int)dt1.Rows[0]["archive_id"] == ArchiveId)//this block of design is only lamma nghayyir el last visit
                {
                    UpdateLastVisitDesign(NewLastVistDate, backofficeform);
                }

                backofficeform.ParentFormClientManagem.Client.TotalAttendance--;
                backofficeform.ParentFormClientManagem.UCTotalAttendance.Detail = Convert.ToString(backofficeform.ParentFormClientManagem.Client.TotalAttendance);

            }
        }
        public static void UndoSoloPurchaseActionsSQLScheduleRelated(int AppointmentId, int BundleId)
        {
            DataTable RelatedSoloBundles = ClassAppointment.GetRelatedSoloBundles(AppointmentId);
            if (RelatedSoloBundles.Rows.Count == 1)
            {
                ClassAppointment classAppointment = (new ClassAppointment());
                classAppointment.AppointmentID = AppointmentId;
                classAppointment.IsCompleted = false;
                classAppointment.UndoCompletionAppointment();//in this function UndoCompletionAppointment kell shi elo aalea bel archive ma elo aaze since eemelna undo bel backoffice abel ma nfout aa hal function
            }
            else if (RelatedSoloBundles.Rows.Count > 1)
            {
                ClassAppointment.DeleteRelatedSoloBundle(AppointmentId, BundleId);
            }
            //it can be 0 eza ken package mesh Solo Service 
        }

        public static void UndoPurchaseActionsSQL(int ClientId, int DesiredClientBalanceId, BackOffice backofficeform)
        {

            string querySelect1 = "Select client_balance_id,client_id,bundle_id,purchase_date,session_left_days,isbundle_membership,due_date,balance,amount_paid from client_balance WHERE client_id=@client_id";
            SqlCommand cmdSelect1 = new SqlCommand(querySelect1, con);
            cmdSelect1.Parameters.AddWithValue("@client_id", ClientId);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmdSelect1);
            DataTable dtClientBalanceOriginal = new DataTable();
            sda1.Fill(dtClientBalanceOriginal);

            //we re tracking el bundle li aam naamello undo now
            dtClientBalanceOriginal.PrimaryKey = new DataColumn[] { dtClientBalanceOriginal.Columns["client_balance_id"] };
            DataRow DesiredRow = dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);
            bool IsBundleOrProduct;
            int? BundleIDDesiredRow;
            if (DesiredRow["bundle_id"] != DBNull.Value)
            {
                IsBundleOrProduct = true;
                BundleIDDesiredRow = (int)DesiredRow["bundle_id"];
            }
            else
            {
                IsBundleOrProduct = false;
                BundleIDDesiredRow = null;
            }


            //update Registrationdate
            DateTime? MembershipDate = null;
            if (IsBundleOrProduct)//bundle
            {
                MembershipDate = UpdateRegistrationDateSQl(ClientId, DesiredClientBalanceId, dtClientBalanceOriginal, DesiredRow);
            }

            //we re reseting balance, amountpaid, w session left tabaa el client
            double TotalBalanceAmount = 0;
            double TotalPayment = 0;
            int totalsessionLeft = 0;
            foreach (DataRow row in dtClientBalanceOriginal.Rows)
            {
                if ((int)row["client_balance_id"] != DesiredClientBalanceId)
                {
                    TotalBalanceAmount += Convert.ToDouble(row["balance"]);
                    TotalPayment += (double)row["amount_paid"];

                    if (IsBundleOrProduct && row["session_left_days"] != DBNull.Value && row["due_date"] == DBNull.Value)//sessions only, w eza ken el el click row now huwwe bundle
                    {
                        totalsessionLeft += (int)row["session_left_days"];
                    }
                }

            }
            ClassClient.UpdateClientTotalPaymentSQL(ClientId, TotalPayment);
            ClassClient.UpdateClientTotalBalanceSQL(ClientId, TotalBalanceAmount);



            ClassClientBalance.DeleteClientBalance(DesiredClientBalanceId);




            //Design wise 
            if (backofficeform != null)
            {


                //datagridBalance bel profile 
                DataRow rowToEdit = backofficeform.ParentFormClientManagem.dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);
                rowToEdit.Delete();
                backofficeform.ParentFormClientManagem.dtClientBalanceOriginal.AcceptChanges();
                backofficeform.ParentFormClientManagem.FormatDatagridviewDesign();
                //datagridBalancebel backoffice el tahteniye
                backofficeform.DesiredBalanceRowsdt.Rows[0].Delete();//bel all transaction ma ha ysir shi lieannoo the desiredrow manno binded aa datagrid (which doesnt exists)
                backofficeform.DesiredBalanceRowsdt.AcceptChanges();
                //deleting the uc pakcgae
                if (IsBundleOrProduct)
                {
                    backofficeform.ParentFormClientManagem.DeleteUcPackage(DesiredClientBalanceId);
                }

                backofficeform.ParentFormClientManagem.CalculatingTotalBalances(false);
                backofficeform.ParentFormClientManagem.CalculatingClientHistory(false);
                backofficeform.ParentFormClientManagem.datagridviewBalanceMode();
                //
                if (IsBundleOrProduct)//bundle
                {
                    backofficeform.ParentFormClientManagem.Client.RegistrationDate = MembershipDate;
                    if (MembershipDate != null)
                    {
                        backofficeform.ParentFormClientManagem.UCMemberSince.Detail = RandomFunctions.SetDateFormat(((DateTime)MembershipDate).ToString());
                    }
                    else
                    {
                        backofficeform.ParentFormClientManagem.UCMemberSince.Detail = "N/A";
                    }
                }
            }
        }
        public static void UndoPaymentActionsSQL(int ClientID, int ClientBalanceId, int ArchiveId, DateTime ArchiveDate, double AmountPaid, BackOffice backofficeform)
        {

            double NewAmountPaid, NewBalance;
            (NewAmountPaid, NewBalance) = ClassClientBalance.GetClientBalanceSpecificItem(ClientBalanceId);
            NewAmountPaid -= AmountPaid;
            NewBalance -= AmountPaid;

            con.Open();

            string queryUpdateBalance = "UPDATE client_balance SET amount_paid=@amount_paid,balance=@balance,is_expired='false' WHERE  client_balance_id=@client_balance_id";
            SqlCommand cmdUpdateBalance = new SqlCommand(queryUpdateBalance, con);
            cmdUpdateBalance.Parameters.AddWithValue("@client_balance_id", ClientBalanceId);
            cmdUpdateBalance.Parameters.AddWithValue("@amount_paid", NewAmountPaid);
            cmdUpdateBalance.Parameters.AddWithValue("@balance", NewBalance);
            cmdUpdateBalance.ExecuteNonQuery();

            string queryDeleteIncome = "DELETE finance WHERE client_balance_id=@client_balance_id AND payment_date=@payment_date";
            SqlCommand cmdDeleteIncome = new SqlCommand(queryDeleteIncome, con);
            cmdDeleteIncome.Parameters.AddWithValue("@client_balance_id", ClientBalanceId);
            cmdDeleteIncome.Parameters.AddWithValue("@payment_date", ArchiveDate);//we can do this, lieanno ana bel code eemela enno both yekhdome same datetime
            cmdDeleteIncome.ExecuteNonQuery();

            string queryDeleteArchive = "DELETE archive WHERE archive_id=@archive_id";
            SqlCommand cmdDeleteArchive = new SqlCommand(queryDeleteArchive, con);
            cmdDeleteArchive.Parameters.AddWithValue("@archive_id", ArchiveId);
            cmdDeleteArchive.ExecuteNonQuery();


            string queryUpdateClient = "UPDATE client SET total_payment-=@total_payment,total_balance-=@total_balance WHERE client_id=@client_id";
            SqlCommand cmdUpdateClient = new SqlCommand(queryUpdateClient, con);
            cmdUpdateClient.Parameters.AddWithValue("@client_id", ClientID);
            cmdUpdateClient.Parameters.AddWithValue("@total_payment", AmountPaid);
            cmdUpdateClient.Parameters.AddWithValue("@total_balance", AmountPaid);
            cmdUpdateClient.ExecuteNonQuery();

            con.Close();


            if (backofficeform != null)
            {
                //design
                double OldBalance = (double)backofficeform.DesiredBalanceRowsdt.Rows[0]["balance"];
                string balance = Convert.ToString(OldBalance - AmountPaid);//eza kenit balance=-50 w paid 50 bet sir balance -100

                //updating backoffice datatgridbalancce
                backofficeform.DesiredBalanceRowsdt.Rows[0]["balance"] = balance;
                backofficeform.DesiredBalanceRowsdt.Rows[0]["amount_paid"] = (double)backofficeform.DesiredBalanceRowsdt.Rows[0]["amount_paid"] - AmountPaid;
                bool IsExpired = (bool)backofficeform.DesiredBalanceRowsdt.Rows[0]["is_expired"];
                if (IsExpired == true)
                {
                    backofficeform.DesiredBalanceRowsdt.Rows[0]["is_expired"] = false;
                }
                //updating original datatbalance
                DataRow rowToEdit = backofficeform.ParentFormClientManagem.dtClientBalanceOriginal.Rows.Find(backofficeform.DesiredBalanceRowsdt.Rows[0]["client_balance_id"]);
                rowToEdit["balance"] = backofficeform.DesiredBalanceRowsdt.Rows[0]["balance"];
                rowToEdit["amount_paid"] = backofficeform.DesiredBalanceRowsdt.Rows[0]["amount_paid"];
                if (IsExpired)
                {
                    rowToEdit["is_expired"] = backofficeform.DesiredBalanceRowsdt.Rows[0]["is_expired"];
                    backofficeform.ParentFormClientManagem.ResortOriginalDataTableAndSetDatasource();

                    if (rowToEdit["bundle_id"] != DBNull.Value && rowToEdit["session_left_days"] != DBNull.Value)//package
                    {
                        //creating back the uc
                        //Add UCbundle
                        backofficeform.ParentFormClientManagem.CheckAndSetNoBundleLabel();
                        backofficeform.ParentFormClientManagem.CreateUCPackage(rowToEdit);
                    }
                }

                if (rowToEdit["bundle_id"] != DBNull.Value && rowToEdit["session_left_days"] != DBNull.Value)//package
                {
                    if (OldBalance == 0)// since eza kenit 0 w eemelna undo la payment yaane for sur ha tzid negativily wich means ha yetghayar el state
                    {
                        backofficeform.ParentFormClientManagem.UpdateIsInDebteToUCBundle(ClientBalanceId, true);
                    }
                }


                backofficeform.ParentFormClientManagem.FormatDatagridviewDesign();
                //
                backofficeform.ParentFormClientManagem.CalculatingTotalBalances(false);
                backofficeform.ParentFormClientManagem.CalculatingClientHistory(false);
            }
        }
        public static void UndoSessionDoneActionsSQL(int ClientId, int AttendanceID, int ArchiveId, int ClientBalanceId, bool IsDeletingTheBundle, int? AppointmentIdReferringToBackoffice, BackOffice backofficeform)
        {
            //SQL
            con.Open();
            SqlCommand cmdUpdateSession = null;
            if (!IsDeletingTheBundle)//cz ha aam naayetla marten yaa nehna w aam nmahe bundle ya aade, so to optimise
            {
                string queryUpdateSession = "UPDATE client_balance SET session_left_days+=@session_left_days,is_expired='false' WHERE  client_balance_id=@client_balance_id";
                cmdUpdateSession = new SqlCommand(queryUpdateSession, con);
                cmdUpdateSession.Parameters.AddWithValue("@client_balance_id", ClientBalanceId);
                cmdUpdateSession.Parameters.AddWithValue("session_left_days", 1);


            }



            string queryDeleteStruct = "DELETE client_services_attendance WHERE attendance_id=@attendance_id";
            SqlCommand cmdDeleteStruct = new SqlCommand(queryDeleteStruct, con);
            cmdDeleteStruct.Parameters.AddWithValue("@attendance_id", AttendanceID);


            //update lastvisit
            DataTable dt1;
            DateTime? NewLastVistDate;
            (NewLastVistDate, dt1) = DeleteTheArchiveAndUpdateLastVisitSql(ClientId, ArchiveId);



            if (cmdUpdateSession != null)//ma32oul tkun null eza kenna aam naamil delete a bundle 
            {
                cmdUpdateSession.ExecuteNonQuery();//ejbare hone, cz badna el expiry date abel ma tenaamalla update
            }
            cmdDeleteStruct.ExecuteNonQuery(); //ejbare tkun tahet delete el archive kermel el fk       
            con.Close();

            if (AppointmentIdReferringToBackoffice != null)
            {
                ClassAppointment classAppointment = new ClassAppointment();
                classAppointment.AppointmentID = (int)AppointmentIdReferringToBackoffice;
                classAppointment.IsCompleted = false;
                classAppointment.SetOrResetIsCompleted();
            }


            //Design wise
            if (backofficeform != null)
            {


                if (!IsDeletingTheBundle)//lieannoo eza aam mahe bundle metel ma huwwe el uc bundle w el rows ha yenmeho kellun already
                {
                    //Datagridview 
                    int ClientBalanceID = Convert.ToInt16(backofficeform.DesiredBalanceRowsdt.Rows[0]["client_balance_id"]);
                    int NoOfSessions = Convert.ToInt16(backofficeform.DesiredBalanceRowsdt.Rows[0]["session_left_days"]) + 1;
                    bool IsExpired = (bool)backofficeform.DesiredBalanceRowsdt.Rows[0]["is_expired"];

                    backofficeform.DesiredBalanceRowsdt.Rows[0]["session_left_days"] = NoOfSessions;

                    if (IsExpired == true)
                    {
                        backofficeform.DesiredBalanceRowsdt.Rows[0]["is_expired"] = false;
                    }

                    //Updating the original datarow
                    DataRow rowToEdit = backofficeform.ParentFormClientManagem.dtClientBalanceOriginal.Rows.Find(ClientBalanceID);
                    rowToEdit["session_left_days"] = NoOfSessions;

                    //Update related UC in client profile    
                    if (IsExpired)
                    {
                        rowToEdit["is_expired"] = backofficeform.DesiredBalanceRowsdt.Rows[0]["is_expired"];
                        if (rowToEdit["bundle_id"] != DBNull.Value && rowToEdit["session_left_days"] != DBNull.Value)//packages
                        {
                            //creating back the uc
                            //Add UCbundle
                            backofficeform.ParentFormClientManagem.CheckAndSetNoBundleLabel();
                            backofficeform.ParentFormClientManagem.CreateUCPackage(rowToEdit);

                        }
                        //bas hone staamelneha,cz bas in this case ha nkun aam nghayyir bel datagridview
                        backofficeform.ParentFormClientManagem.ResortOriginalDataTableAndSetDatasource();
                        backofficeform.ParentFormClientManagem.FormatDatagridviewDesign();

                    }
                    else
                    {
                        backofficeform.ParentFormClientManagem.ResetUCMode(ClientBalanceID, NoOfSessions, null);
                    }
                }

                if ((int)dt1.Rows[0]["archive_id"] == ArchiveId)//this block of design is only lamma nghayyir el last visit
                {
                    UpdateLastVisitDesign(NewLastVistDate, backofficeform);
                }

                backofficeform.ParentFormClientManagem.Client.TotalAttendance--;
                backofficeform.ParentFormClientManagem.UCTotalAttendance.Detail = Convert.ToString(backofficeform.ParentFormClientManagem.Client.TotalAttendance);

            }


        }
        public static bool UndoOffresSQL(int ClientID, int ArchiveId, int ClientBalanceId, bool IsMoneyOrsession, string BalanceOrSession_Offre, BackOffice backofficeform)
        {

            string QuerySelect = "Select  MAX(archive_id) from archive Where client_id=@client_id and client_balance_id=@client_balance_id";
            SqlCommand cmdSelect = new SqlCommand(QuerySelect, con);
            cmdSelect.Parameters.AddWithValue("@client_id", ClientID);
            cmdSelect.Parameters.AddWithValue("@client_balance_id", ClientBalanceId);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmdSelect);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);

            //design
            if ((int)dt1.Rows[0][0] == ArchiveId)//yaane it s the last Action made bi this client list,w tdarayna naamil this restriction , lieanno some ways could lead us to positive balances!
            {

                string queryDeleteArchive = "DELETE archive WHERE archive_id=@archive_id";
                SqlCommand cmdDeleteArchive = new SqlCommand(queryDeleteArchive, con);
                cmdDeleteArchive.Parameters.AddWithValue("@archive_id", ArchiveId);
                con.Open();
                cmdDeleteArchive.ExecuteNonQuery();
                con.Close();

                if (backofficeform != null)
                {
                    //Design
                    if (IsMoneyOrsession == true)//undo money update
                    {
                        double ToBalance = Convert.ToDouble(BalanceOrSession_Offre.Split('/')[1]);//ma ela aaze el refe hone, bas lieanno bi payment eezneha , medtarrin nhatta hone, bas ma ha teaddim w teakkhir                 
                        double FromBalance = Convert.ToDouble(BalanceOrSession_Offre.Split('/')[0]);
                        backofficeform.ParentFormClientManagem.UpdateBalance(backofficeform.DesiredBalanceRowsdt, FromBalance, ref ToBalance, null);
                    }
                    else//undoing session or dates 
                    {
                        int ToSessionOrDays = Convert.ToInt16(BalanceOrSession_Offre.Split('/')[1]);//ma ela aaze el refe hone, bas lieanno bi payment eezneha , medtarrin nhatta hone, bas ma ha teaddim w teakkhir
                        int FromSessionOrDays = Convert.ToInt16(BalanceOrSession_Offre.Split('/')[0]);
                        backofficeform.ParentFormClientManagem.UpdateSessionNumber(backofficeform.DesiredBalanceRowsdt, FromSessionOrDays, ref ToSessionOrDays, null);//from bel awwal , lieanno hal value li badna nerjaa aalaya
                    }
                }
                return true;
            }

            else
            {

                return false;
            }



        }

        static void UpdateLastVisitDesign(DateTime? NewLastVistDate, BackOffice backofficeform)
        {
            //Client Prodile 
            string StringNewLastVisitDate;
            if (NewLastVistDate != null)
            {
                StringNewLastVisitDate = RandomFunctions.SetDateFormat(Convert.ToString(NewLastVistDate));
            }
            else
            {
                StringNewLastVisitDate = "N/A";
            }
            backofficeform.ParentFormClientManagem.UCLastVisit.Detail = StringNewLastVisitDate;
            backofficeform.ParentFormClientManagem.Client.LastVisit = NewLastVistDate;
        }
        static (DateTime?, DataTable) DeleteTheArchiveAndUpdateLastVisitSql(int ClientId, int ArchiveId)
        {
            string queryDeleteArchive = "DELETE archive WHERE archive_id=@archive_id";
            SqlCommand cmdDeleteArchive = new SqlCommand(queryDeleteArchive, con);
            cmdDeleteArchive.Parameters.AddWithValue("@archive_id", ArchiveId);

            //update lastvisit
            string querySelect = "SELECT date,archive_id FROM archive WHERE archive_id = (SELECT MAX(archive_id) FROM archive WHERE client_id = @client_id AND  attendance_id IS NOT NULL)";//baddak teteakad eno type tabaa session w fi menna
            SqlCommand cmdSelect = new SqlCommand(querySelect, con);
            cmdSelect.Parameters.AddWithValue("@client_id", ClientId);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmdSelect);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            DateTime? NewLastVistDate = null;
            if ((int)dt1.Rows[0]["archive_id"] == ArchiveId)//in order to check eza ha el last session 
            {

                cmdDeleteArchive.ExecuteNonQuery();//ejbare hone mahalla

                //after deleting the archive, i m fetching abel ekhir whade, kermel ekhud menna el date
                SqlDataAdapter sda2 = new SqlDataAdapter(cmdSelect);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    NewLastVistDate = (DateTime)dt2.Rows[0]["date"];
                }
                else
                {
                    NewLastVistDate = null;
                }

                string queryUpdateClient = "UPDATE client SET check_in=@check_in WHERE client_id=@client_id";
                SqlCommand cmdUpdateClient = new SqlCommand(queryUpdateClient, con);
                cmdUpdateClient.Parameters.AddWithValue("@client_id", ClientId);
                if (NewLastVistDate != null)
                {
                    cmdUpdateClient.Parameters.AddWithValue("@check_in", NewLastVistDate);
                }
                else
                {
                    cmdUpdateClient.Parameters.AddWithValue("@check_in", DBNull.Value);
                }

                cmdUpdateClient.ExecuteNonQuery();

            }
            else
            {
                cmdDeleteArchive.ExecuteNonQuery();//ejbare hone mahalla
            }

            return (NewLastVistDate, dt1);
        }

        static DateTime? UpdateRegistrationDateSQl(int ClientId, int DesiredClientBalanceId, DataTable dtClientBalanceOriginal, DataRow DesiredRow)
        {
            DateTime? MembershipDate = null;
            //updating client Membership
            if ((bool)DesiredRow["isbundle_membership"] == true)//lieanno eza ma kenit member ship, membershipdate makhasso fiya men el ases
            {


                DataRow[] filteredRows = dtClientBalanceOriginal.Select("client_id = " + ClientId + " AND bundle_id IS NOT NULL AND client_balance_id <>" + DesiredClientBalanceId + "");
                if (filteredRows.Length > 0)
                {
                    // There were results
                    DataTable dt2 = filteredRows.CopyToDataTable();
                    MembershipDate = DateTime.MaxValue;
                    foreach (DataRow row in dt2.Rows)
                    {
                        if ((bool)row["isbundle_membership"] == true)
                        {
                            if (row["purchase_date"] != DBNull.Value && (DateTime)row["purchase_date"] < MembershipDate)
                            {
                                MembershipDate = (DateTime)row["purchase_date"];
                            }
                        }

                    }
                    if (MembershipDate == DateTime.MaxValue)
                    {
                        MembershipDate = null;
                    }
                }

                string queryUpdate = "UPDATE client SET Registration_Date=@Registration_Date WHERE client_id=@client_id";
                SqlCommand cmdInsert = new SqlCommand(queryUpdate, con);
                cmdInsert.Parameters.AddWithValue("@client_id", ClientId);
                if (MembershipDate != null)
                {
                    cmdInsert.Parameters.AddWithValue("@Registration_Date", MembershipDate);
                }
                else
                {
                    cmdInsert.Parameters.AddWithValue("@Registration_Date", DBNull.Value);
                }
                con.Open();
                cmdInsert.ExecuteNonQuery();
                con.Close();

            }
            return MembershipDate;
        }


    }



}
