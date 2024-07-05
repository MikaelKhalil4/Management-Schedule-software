using CustomizedTools;
using GlobalFunctions;
using Microsoft.VisualBasic;
using MKproject.Schedule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace MKproject.Management
{
    public class ClassClientBalance//mainly used bel schedule , when we re selection a ervice
    {
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);

        public int ClientBalanceID { get; set; }
        public int ClientId { get; set; }
        public int? BundleId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string OriginalOffre { get; set; }
        public string Offre { get; set; }
        public double? AmountPaid { get; set; }
        public double? Balance { get; set; }
        public string CurrencyName { get; set; }
        public int? SessionLeftDays { get; set; }//null if not package of session
        public bool? IsBundleMembership { get; set; }

        private DateTime? dueDate;
        public DateTime? DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                if (value != null)
                {
                    DaysLeft = RandomFunctions.GetDaysDifference(DateTime.Now, (DateTime)DueDate);
                    if (DaysLeft < 0)
                    {
                        DaysLeft = 0;
                    }
                }

            }
        }

        public bool? IsFreezed { get; set; }
        public bool? IsExpired { get; set; }




        //additional
        public int? DaysLeft { get; set; }//btenjeb men wara Due Date w DateTime.Now bel Set tb3 El Due Dtae
        public string BundleName { get; set; }
        public TimeSpan BundleDuration { get; set; }
        //View 
        public string ClientBalanceSessionLeftDetails { get; set; }//additional,  it a string that describe the service,if package: adde baaed eendo session w masare,if solo: service name,
                                                                   //public string ClientBalanceBalanceDetails { get; set; }//additional, null if not package, its a string: currency + Balance
                                                                   //public string ClientBalanceFullDetails { get; set; }

        //Select


        public static DataTable GetClientBalanceSpecificOrLastInsert(int? ClientId)
        {

            String query = @"SELECT
                       cl.client_balance_id,  cl.bundle_id,b.bundle_name, cl.product_id, cl.purchase_date, cl.original_offre, cl.offre, cl.amount_paid, cl.balance, cl.session_left_days, cl.due_date,  cl.is_freezed,cl.is_expired,            
                      CASE
                       WHEN cl.bundle_id IS NOT NULL THEN b.bundle_name
                          WHEN cl.product_id IS NOT NULL THEN p.product_name
                          ELSE 'Others' 
                         END AS Description  
                        FROM client_balance cl                         
                        LEFT JOIN
                        bundles b ON cl.bundle_id = b.bundle_id
                        LEFT JOIN
                        products p ON cl.product_id = p.product_id WHERE 1=1 ";

            if (ClientId != null)
            {
                query += " And cl.client_id ='" + ClientId + "' ORDER BY purchase_date ASC ";
            }
            else
            {
                query += " And cl.client_balance_id = (SELECT MAX(client_balance_id) FROM client_balance) ";
            }


            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dtClientBalance = new DataTable();
            sda.Fill(dtClientBalance);
            ClassClientBalanceFront.FormatClientBalanceDt(dtClientBalance);
            return dtClientBalance;
        }
        public static (double, double) GetClientBalanceSpecificItem(int ClientBalanceId)
        {
            string query = "Select amount_paid,balance from client_balance WHERE client_balance_id=@client_balance_id";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@client_balance_id", ClientBalanceId);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return (Convert.ToDouble(dt.Rows[0]["amount_paid"]), Convert.ToDouble(dt.Rows[0]["balance"]));

        }
        public static DataTable GetClientBalanceNotExpiredPackage(int? clientID)
        {
            string query = @"Select	c.client_balance_id,c.client_id,c.bundle_id,b.bundle_name as Description,c.session_left_days,c.due_date,c.is_freezed,c.balance                           
                            from client_balance as c ,bundles  as b
                              where session_left_days is not null And is_expired='0' and c.bundle_id is not null and c.bundle_id=b.bundle_id ";

            if (clientID != null)
            {
                query += " And client_id='" + (int)clientID + "'";
            }
            query += " Order by is_expired ASC , purchase_date DESC ";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dtClientBalance = new DataTable();
            sda.Fill(dtClientBalance);
            return dtClientBalance;

        }
        public static DataRow GetClientBalanceAllInfoSql(int BalanceId)
        {
            SQLiteCommand cmd = new SQLiteCommand("select * from client_balance where client_balance_id=@client_balance_id", con);
            cmd.Parameters.AddWithValue("@client_balance_id", BalanceId);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt.Rows[0];
        }
        public static (int?, int?, DateTime?, int? SessionLeftDays) GetBundleIdProductIdueDateSessions(int ClientBalanceId)
        {
            SQLiteCommand cmd = new SQLiteCommand("select bundle_id,product_id,due_date,session_left_days from client_balance where client_balance_id=@client_balance_id", con);
            cmd.Parameters.AddWithValue("@client_balance_id", ClientBalanceId);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int? BundleId = dt.Rows[0]["bundle_id"] is DBNull ? null : Convert.ToInt32(dt.Rows[0]["bundle_id"]);
            int? productId = dt.Rows[0]["product_id"] is DBNull ? null : Convert.ToInt32(dt.Rows[0]["product_id"]);
            DateTime? DueDate = dt.Rows[0]["due_date"] is DBNull ? null : Convert.ToDateTime(dt.Rows[0]["due_date"]);
            int? SessionLeftDays = dt.Rows[0]["session_left_days"] is DBNull ? null : Convert.ToInt32(dt.Rows[0]["session_left_days"]);
            return (BundleId, productId, DueDate, SessionLeftDays);
        }

        //Insert and update
        public static void InsertToClientBalance(int clientid, int catgeoryid, string bundleType) //bundleType for packages , NULL FOR product
        {

            //try
            //{
            //if (RandomFunctions.IsInternetConnected())
            //{
            //    //we still need to do it for the product
            string BundleType;
            string OriginalOffre;
            int? NOSessionOrDays;//gonna be used in description
            double originalprice;
            bool IsExpired = false;
            string query = @"INSERT into  client_balance
                  (client_id,bundle_id,product_id,purchase_date,original_offre,offre,amount_paid,balance,session_left_days,isbundle_membership,due_date,is_freezed,is_expired) 
                                                              VALUES 
                  (@client_id,@bundle_id,@product_id,@purchase_date,@original_offre,@offre,@amount_paid,@balance,@session_left_days,@isbundle_membership,@due_date,@is_freezed,@is_expired)";

            SQLiteCommand cmd = new SQLiteCommand(query, con);


            if (bundleType != null)//bundles
            {
                bool IsMemberShip;
                (originalprice, NOSessionOrDays, IsMemberShip) = ClassBundles.FindBundleDetails(catgeoryid);

                if (bundleType == ClassBundles.enumBundle.Days.ToString())
                {
                    cmd.Parameters.AddWithValue("@session_left_days", NOSessionOrDays);
                    cmd.Parameters.AddWithValue("@is_freezed", false);

                    DateTime duedate = DateTime.Now.AddDays((int)NOSessionOrDays);
                    cmd.Parameters.AddWithValue("@due_date", duedate.ToString("yyyy-MM-dd"));

                    BundleType = ClassBundles.Days;
                    OriginalOffre = originalprice + "/" + Convert.ToInt32(NOSessionOrDays) + " " + BundleType;

                    if (originalprice == 0 && NOSessionOrDays == 0)//which is impossible , lieanno bel setup tb3 package mafi eendo hek option
                    {
                        IsExpired = true;
                    }
                }
                else if (bundleType == ClassBundles.enumBundle.Sessions.ToString())
                {

                    cmd.Parameters.AddWithValue("@session_left_days", NOSessionOrDays);
                    cmd.Parameters.AddWithValue("@due_date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@is_freezed", DBNull.Value);

                    BundleType = ClassBundles.Session;//hone fi "sess"
                    OriginalOffre = originalprice + "/" + Convert.ToInt32(NOSessionOrDays) + " " + BundleType;

                    if (originalprice == 0 && NOSessionOrDays == 0)//which is impossible , lieanno bel setup tb3 package mafi eendo hek option
                    {
                        IsExpired = true;
                    }
                }
                else//solo
                {
                    cmd.Parameters.AddWithValue("@session_left_days", DBNull.Value);
                    cmd.Parameters.AddWithValue("@due_date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@is_freezed", DBNull.Value);
                    OriginalOffre = originalprice.ToString();

                    if (originalprice == 0)//possible
                    {
                        IsExpired = true;
                    }
                }
                cmd.Parameters.AddWithValue("@bundle_id", catgeoryid);
                cmd.Parameters.AddWithValue("@isbundle_membership", IsMemberShip);
                cmd.Parameters.AddWithValue("@product_id", DBNull.Value);




            }
            else//product
            {
                (originalprice) = ClassProduct.FindProductDetails(catgeoryid);
                if (originalprice == 0)//possible
                {
                    IsExpired = true;
                }


                cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@product_id", catgeoryid);

                //
                OriginalOffre = originalprice.ToString();
                //


                cmd.Parameters.AddWithValue("@session_left_days", DBNull.Value);
                cmd.Parameters.AddWithValue("@isbundle_membership", DBNull.Value);
                cmd.Parameters.AddWithValue("@bundle_id", DBNull.Value);
                cmd.Parameters.AddWithValue("@due_date", DBNull.Value);
                cmd.Parameters.AddWithValue("@is_freezed", DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@client_id", clientid);
            cmd.Parameters.AddWithValue("@purchase_date", DateTime.Now);
            cmd.Parameters.AddWithValue("@amount_paid", 0);

            if (originalprice == 0)
                cmd.Parameters.AddWithValue("@balance", originalprice);
            else
                cmd.Parameters.AddWithValue("@balance", -originalprice);

            cmd.Parameters.AddWithValue("@original_offre", OriginalOffre);
            cmd.Parameters.AddWithValue("@offre", OriginalOffre);

            cmd.Parameters.AddWithValue("@is_expired", IsExpired);//since deyman shu ma neshtre , mnehstri bel initial price, later on mnaamil el updates     

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //}
            //}     
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //CustomMessageBox.Show(Program.ExecptionString + ex.Message, CustomMessageBox.Type.Ok);
            //}
        }
        public static void UpdateClientBalanceAndInsertingFinanceOnPay(DataRow DesiredClientBalanceRow, int ClientBalanceId, double AmountPaid, DateTime Date, String AlbumType)
        {
            //client info retrieval IsMember & Album Type only meanwhile because later on they willl be already existes in the parent form


            bool IsExpired = Convert.ToBoolean(DesiredClientBalanceRow["is_expired"]);
            string queryUpdate = "";
            //client_balance update
            if (IsExpired)
            {
                queryUpdate = "UPDATE client_balance SET balance= @balance,amount_paid=@amount_paid,is_expired=@is_expired WHERE  client_balance_id=@client_balance_id";
            }
            else
            {
                queryUpdate = "UPDATE client_balance SET balance= @balance,amount_paid=@amount_paid WHERE  client_balance_id=@client_balance_id";
            }

            SQLiteCommand cmdUpdate = new SQLiteCommand(queryUpdate, con);
            cmdUpdate.Parameters.AddWithValue("@client_balance_id", DesiredClientBalanceRow["client_balance_id"]);
            cmdUpdate.Parameters.AddWithValue("@balance", DesiredClientBalanceRow["balance"]);
            cmdUpdate.Parameters.AddWithValue("@amount_paid", DesiredClientBalanceRow["amount_paid"]);
            cmdUpdate.Parameters.AddWithValue("@is_expired", DesiredClientBalanceRow["is_expired"]);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();


            ProjectToSQL.InsertToFinance(ClientBalanceId, AmountPaid, Date, AlbumType);

        }


        public static (double, string, bool) UpdateClientBalanceOnEditingBalanceOffre(int ClientId, DataRow DesiredClientBlanaceRow, double ToBalance, double FromBalance, DateTime? Date, bool IsFromPaymentOrBackOffice)
        {

            int ClientBalanceID = Convert.ToInt32(DesiredClientBlanaceRow["client_balance_id"]);
            double BalanceAmount = Convert.ToDouble(DesiredClientBlanaceRow["balance"]);

            //////Calculations started
            Double DifferenceBetweenToFrom;
            DifferenceBetweenToFrom = (ToBalance - FromBalance);//since ToBalance is my target, so if frombalance=-100 & tobalance=-50, diff=+50, which means zedtello 50 aal balance,yaane eetito masare


            double UpdatedBalance = BalanceAmount + DifferenceBetweenToFrom;



            //updating theoffre in the datatgridview's PAyment Form
            string UpdatedOffre = DesiredClientBlanaceRow["offre"].ToString();
            double offrePrice;
            string OffreScdPart = null;
            if (UpdatedOffre.Contains('/'))//bundles and sessions
            {
                offrePrice = Convert.ToDouble(DesiredClientBlanaceRow["offre"].ToString().Split('/')[0]);
                OffreScdPart = DesiredClientBlanaceRow["offre"].ToString().Split('/')[1];
            }
            else//products
            {
                offrePrice = Convert.ToDouble(DesiredClientBlanaceRow["offre"]);
            }

            offrePrice -= DifferenceBetweenToFrom;//eza ken el offre offre 300 w el diff hiyye +50, yaane ana eemltello 50 discount,offre=250


            if (OffreScdPart != null)
            {
                UpdatedOffre = offrePrice + "/" + OffreScdPart;
            }
            else
            {
                UpdatedOffre = offrePrice.ToString();
            }

            bool OldIsExpired = Convert.ToBoolean(DesiredClientBlanaceRow["is_expired"]);
            bool NewIsExpired = OldIsExpired;//default value it s going to be used just in case eit was a bundle w feytin men el paymen aam naamil update, ma men ghayyir el expire tabaao , cz we click remove la nghayra haydik
            if (DesiredClientBlanaceRow["product_id"] != DBNull.Value || (DesiredClientBlanaceRow["bundle_id"] != DBNull.Value && DesiredClientBlanaceRow["session_left_days"] == DBNull.Value))//product or solo
            {
                if (UpdatedBalance == 0)
                {
                    NewIsExpired = true;// cz only el product could be expired by changing its balance
                }
                else
                {
                    NewIsExpired = false;
                }
            }
            else//package
            {
                if (!IsFromPaymentOrBackOffice && Date == null)//it means coming from backoffice ,ma mnelaab bel expiry eza ken aam naadil men el payment lieanno el bundle ha ykun already mawjud, we only change the expire by clicking remove
                {
                    if (OldIsExpired == true && (Convert.ToDouble(UpdatedBalance) != 0 || Convert.ToInt32(DesiredClientBlanaceRow["session_left_days"]) > 0))//only in this case men ghayyir el expiry date tabaa el bundle , eza aam naamil undo la shi w huwwe already ken expired
                    {
                        NewIsExpired = false;
                    }

                }
            }
            //Calculations ended



            string query = "";
            if (NewIsExpired)
            {
                query = "UPDATE client_balance SET offre=@offre,balance=@balance,is_expired=@is_expired WHERE client_balance_id=@client_balance_id ";
            }
            else
            {
                query = "UPDATE client_balance SET offre=@offre,balance=@balance WHERE client_balance_id=@client_balance_id ";
            }
            SQLiteCommand cmdUpdate = new SQLiteCommand(query, con);
            cmdUpdate.Parameters.AddWithValue("@client_balance_id", ClientBalanceID);
            cmdUpdate.Parameters.AddWithValue("@balance", UpdatedBalance);
            cmdUpdate.Parameters.AddWithValue("@offre", UpdatedOffre);
            cmdUpdate.Parameters.AddWithValue("@is_expired", NewIsExpired);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();



            //back office, ejbare  abel ma nghayyir el initialbalance
            if (IsFromPaymentOrBackOffice && Date != null)//yaane payment form
            {

                ClassBackOffice backOffice = new ClassBackOffice(ClientId, ActionsEnum.Offers, Program.Employee.EmployeeId, ClientBalanceID, null, null, null, true, FromBalance + "/" + ToBalance, (DateTime)Date);
                backOffice.CreateActionDetails(DesiredClientBlanaceRow);
                backOffice.InsertToArchiveSQL();

            }


            return (UpdatedBalance, UpdatedOffre, NewIsExpired);

        }
        public static (int, string, DateTime?, bool) UpdateClientBalanceOnEditingSessionOffre(int ClientId, DataRow DesiredClientBlanaceRow, int ToSessionOrDays, int FromSessionOrDays, DateTime? Date, bool IsFromPaymentOrBackOffice)
        {

            int ClientBalanceID = Convert.ToInt32(DesiredClientBlanaceRow["client_balance_id"]);

            //calculation has started
            DateTime? DueDate = DesiredClientBlanaceRow["due_date"] is DBNull ? null : Convert.ToDateTime(DesiredClientBlanaceRow["due_date"]);//null eza sessions not days
            DateTime? NewDueDate = null;
            int DifferenceInSessionOrDaysNumber;
            int UpdatedOffreScdPart = 0;//yaane session and days


            Match match1 = Regex.Match(DesiredClientBlanaceRow["offre"].ToString(), @"(\d+)\s*" + ClassBundles.Session);
            Match match2 = Regex.Match(DesiredClientBlanaceRow["offre"].ToString(), @"(\d+)\s*" + ClassBundles.Days);
            if (match1.Success)
            {
                UpdatedOffreScdPart = int.Parse(match1.Groups[1].Value);
            }
            else if (match2.Success)
            {
                UpdatedOffreScdPart = int.Parse(match2.Groups[1].Value);
            }
            else
            {
                CustomMessageBox.Show("Crash!!", CustomMessageBox.Type.Error);

            }


            DifferenceInSessionOrDaysNumber = (ToSessionOrDays - FromSessionOrDays);
            UpdatedOffreScdPart += DifferenceInSessionOrDaysNumber;



            string type;
            if (DueDate == null)
            {
                type = ClassBundles.Session;
            }
            else
            {
                type = ClassBundles.Days;
            }
            string newoffre = DesiredClientBlanaceRow["offre"].ToString().Split('/')[0] + "/" + UpdatedOffreScdPart + " " + type;//category name should take the name of the bundle
            int UpdatedSessionLeftORNoDays;

            if (DueDate == null)//updating session left
            {
                UpdatedSessionLeftORNoDays = Convert.ToInt32(DesiredClientBlanaceRow["session_left_days"])+ DifferenceInSessionOrDaysNumber;
            }
            else//update days left
            {
                UpdatedSessionLeftORNoDays = UpdatedOffreScdPart;//lieanno nehna bi hemna bel days mesh el days left as el total days li mawjud bi tene part men el offre
                NewDueDate = ((DateTime)DueDate).AddDays(DifferenceInSessionOrDaysNumber);
                NewDueDate = ((DateTime)DueDate).AddDays(DifferenceInSessionOrDaysNumber);
            }


            bool OldIsExpired = Convert.ToBoolean(DesiredClientBlanaceRow["is_expired"]);
            bool NewIsExpired = OldIsExpired;//default value it s going to be used just in case eit was a bundle w feytin men el paymen aam naamil update, ma men ghayyir el expire tabaao , cz we click remove la nghayra haydik

            if (DesiredClientBlanaceRow["bundle_id"] != DBNull.Value && DesiredClientBlanaceRow["session_left_days"] != DBNull.Value)//package
            {
                if (!IsFromPaymentOrBackOffice && Date == null)// it means coming from backoffice,ma mnelaab bel expiry eza ken aam naadil men el paymen lieanno el bundle ha ykun already mawjud, we only change the expire by clicking remove
                {
                    if (OldIsExpired == true && (Convert.ToDouble(DesiredClientBlanaceRow["balance"]) != 0 || UpdatedSessionLeftORNoDays > 0))//only in this case men ghayyir el expiry date tabaa el bundle , eza aam naamil undo la shi w huwwe already ken expired
                    {

                        NewIsExpired = false;
                    }

                }
            }

            //Calculation Finished



            string query = "";
            SQLiteCommand cmdUpdate = null;
            if (newoffre != null)//Updating mode
            {
                if (NewDueDate == null)
                {
                    query = "UPDATE client_balance SET session_left_days=@session_left_days,offre=@offre,is_expired=@is_expired WHERE client_balance_id=@client_balance_id ";
                    cmdUpdate = new SQLiteCommand(query, con);
                    cmdUpdate.Parameters.AddWithValue("@offre", newoffre);
                }
                else//days, w baddak now tkammil men hone, shuf el save points
                {
                    query = "UPDATE client_balance SET session_left_days=@session_left_days,offre=@offre,due_date=@due_date,is_expired=@is_expired WHERE client_balance_id=@client_balance_id ";
                    cmdUpdate = new SQLiteCommand(query, con);
                    cmdUpdate.Parameters.AddWithValue("@offre", newoffre);
                    //               
                    cmdUpdate.Parameters.AddWithValue("@due_date", ((DateTime)NewDueDate).ToString("yyyy-MM-dd"));

                }

            }
            else//reducing a session mode
            {
                if (NewDueDate == null)//mafi reduce session lal bundle days that s why ma hattayna else
                {
                    query = "UPDATE client_balance SET session_left_days=@session_left_days,is_expired=@is_expired  WHERE client_balance_id=@client_balance_id ";
                    cmdUpdate = new SQLiteCommand(query, con);
                }
            }

            cmdUpdate.Parameters.AddWithValue("@client_balance_id", ClientBalanceID);
            cmdUpdate.Parameters.AddWithValue("@session_left_days", UpdatedSessionLeftORNoDays);
            cmdUpdate.Parameters.AddWithValue("@is_expired", NewIsExpired);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();



            if (IsFromPaymentOrBackOffice && Date != null)//yaane payment form
            {
                //Backoffice
                ClassBackOffice backOffice = new ClassBackOffice(ClientId, ActionsEnum.Offers, Program.Employee.EmployeeId, ClientBalanceID, null, null, null, false, FromSessionOrDays + "/" + ToSessionOrDays, (DateTime)Date);
                backOffice.CreateActionDetails(DesiredClientBlanaceRow);
                backOffice.InsertToArchiveSQL();
            }

            return (UpdatedSessionLeftORNoDays, newoffre, NewDueDate, NewIsExpired);
        }





        public static void UpdateClientBalanceOnFreezingDays(int ID, int UpdatedSessionOrDaysLeft, DateTime? Newduedate)
        {
            string query = "";
            SQLiteCommand cmdUpdate = null;
            bool IsFreezing;
            if (Newduedate == null)//freezing mode
            {
                query = "UPDATE client_balance SET session_left_days=@session_left_days,is_freezed=@is_freezed WHERE client_balance_id=@client_balance_id ";
                cmdUpdate = new SQLiteCommand(query, con);
                //
                IsFreezing = true;
            }
            else//reactivation mode
            {

                query = "UPDATE client_balance SET session_left_days=@session_left_days,due_date=@due_date,is_freezed=@is_freezed WHERE client_balance_id=@client_balance_id ";
                cmdUpdate = new SQLiteCommand(query, con);
                //
                DateTime DueDate = (DateTime)Newduedate;
                cmdUpdate.Parameters.AddWithValue("@due_date", Newduedate);
                //
                IsFreezing = false;


            }
            cmdUpdate.Parameters.AddWithValue("@session_left_days", UpdatedSessionOrDaysLeft);
            cmdUpdate.Parameters.AddWithValue("@is_freezed", IsFreezing);
            cmdUpdate.Parameters.AddWithValue("@client_balance_id", ID);

            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();

        }
        public static void UpdateIsexpiredClientBalanceRemoveUC(int ID, bool isExpired)
        {
            string query = "UPDATE client_balance SET is_expired=@is_expired WHERE client_balance_id=@client_balance_id ";
            SQLiteCommand cmdUpdate = new SQLiteCommand(query, con);
            cmdUpdate.Parameters.AddWithValue("@client_balance_id", ID);
            cmdUpdate.Parameters.AddWithValue("@is_expired", isExpired);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();

        }

        public static bool ReduceSessionFromPackageOfSessions(int ClientId, int DesiredClientBalanceId, int UpdatedSessionLeft, int? AppointmentId, DateTime BackOfficeDate,DateTime AttendanceDate)
        {
            //Sql update
            UpdateNOSessions(DesiredClientBalanceId, UpdatedSessionLeft);//lieanno this function onlykermel el package sessiosns                   
            bool IfLastVisitDateChanged=ClassClientCustom.UpdateClientCheckInSQLIfShould(ClientId, AttendanceDate);
            ProjectToSQL.InsertToClientAttendance(ClientId, DesiredClientBalanceId, AppointmentId, AttendanceDate);

            ClassBackOffice backOffice = new ClassBackOffice(ClientId, ActionsEnum.SessionDone, Program.Employee.EmployeeId, DesiredClientBalanceId, null, SQLToProject.GetLAstInsertedAttendance(), AppointmentId, null, null, BackOfficeDate);
            DataRow DesiredClientBlanaceRow = GetClientBalanceAllInfoSql(DesiredClientBalanceId);//ma ela aaze bas mafina baleha, kermel CreateActionDetails, el clean code
            backOffice.CreateActionDetails(DesiredClientBlanaceRow);
            backOffice.InsertToArchiveSQL();

            return IfLastVisitDateChanged;
        }
        public static void UpdateNOSessions(int DesiredClientBalanceId, int UpdatedSessionLeft)
        {
            string query = "UPDATE client_balance SET session_left_days=@session_left_days WHERE client_balance_id=@client_balance_id ";
            SQLiteCommand cmdUpdate = new SQLiteCommand(query, con);
            cmdUpdate.Parameters.AddWithValue("@client_balance_id", DesiredClientBalanceId);
            cmdUpdate.Parameters.AddWithValue("@session_left_days", UpdatedSessionLeft);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();
        }

        public static void DeleteClientBalance(int DesiredClientBalanceId)
        {
            //Eza ghayaret shi hone make sure tghayir also bel ClassClientCustom on delete client
            con.Open();

            //hole el 4 ejbare bhal order kermel needir nemhe client balance
            string QueryDeleteArchive = "DELETE FROM archive WHERE client_balance_id = '" + DesiredClientBalanceId + "'";
            SQLiteCommand cmd1 = new SQLiteCommand(QueryDeleteArchive, con);
            cmd1.ExecuteNonQuery();

            string QueryDeleteFinance = "DELETE FROM finance WHERE client_balance_id = '" + DesiredClientBalanceId + "'";
            SQLiteCommand cmd2 = new SQLiteCommand(QueryDeleteFinance, con);
            cmd2.ExecuteNonQuery();

            string QueryDeleteRelatedServices = "DELETE FROM client_services_attendance WHERE client_balance_id = '" + DesiredClientBalanceId + "'";
            SQLiteCommand cmd4 = new SQLiteCommand(QueryDeleteRelatedServices, con);
            cmd4.ExecuteNonQuery();



            string QuerySetUpdatePastAppointment = @" UPDATE appointments 
                                            SET client_balance_id = NULL 
                                             WHERE client_balance_id = '" + DesiredClientBalanceId + "' And start_time < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";

            SQLiteCommand cmd5 = new SQLiteCommand(QuerySetUpdatePastAppointment, con);
            cmd5.ExecuteNonQuery();

            string QuerySetUpdatePresentFutureAppointment = @" UPDATE appointments 
                                                    SET client_balance_id = NULL 
                                                    WHERE client_balance_id = '" + DesiredClientBalanceId + "' AND start_time >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";

            SQLiteCommand cmd6 = new SQLiteCommand(QuerySetUpdatePresentFutureAppointment, con);
            cmd6.ExecuteNonQuery();





            string QueryDeleteClientBalance = "DELETE FROM client_balance WHERE client_balance_id ='" + DesiredClientBalanceId + "'";
            SQLiteCommand cmd3 = new SQLiteCommand(QueryDeleteClientBalance, con);
            cmd3.ExecuteNonQuery();


            con.Close();

        }



        public static string SetPackageRemainingsFormat(DataRow dtrow)
        {
            string PackageRemainings = dtrow["Description"] + ": ";//Description = Bundle Name
            if (dtrow["due_date"] != DBNull.Value)
            {
                if (Convert.ToBoolean(dtrow["is_freezed"]) == false)//only packgae of days not freezed
                {
                    int daysLeft = RandomFunctions.GetDaysDifference(DateTime.Now, Convert.ToDateTime(dtrow["due_date"]));
                    if (daysLeft < 0)
                    {
                        daysLeft = 0;
                    }
                    PackageRemainings += daysLeft + " Days Left";//tene wahde - awwal wahde
                }
                else//package days freezed
                {
                    PackageRemainings += Convert.ToInt32(dtrow["session_left_days"]) + " Days Left(Freezed)";
                }
            }
            else//package sesiosn
            {
                PackageRemainings += Convert.ToInt32(dtrow["session_left_days"]) + " Session Left";
            }
            return PackageRemainings;
        }
        public static (double, double, double, int, int) CalculatingClientPayment(DataTable DesiredClientBalanceDT)
        {
            double BundlePayments = 0;
            double ProductPayments = 0;
            int TokenBundles = 0;
            int TokenProducts = 0;
            double TotalPayment;
            foreach (DataRow row in DesiredClientBalanceDT.Rows)
            {
                if (row["bundle_id"] != DBNull.Value)
                {
                    TokenBundles++;
                    BundlePayments += Convert.ToDouble(row["amount_paid"]);
                }
                else if (row["product_id"] != DBNull.Value)
                {
                    TokenProducts++;
                    ProductPayments += Convert.ToDouble(row["amount_paid"]);
                }
            }
            TotalPayment = ProductPayments + BundlePayments;
            return (TotalPayment, BundlePayments, ProductPayments, TokenBundles, TokenProducts);
        }
        public static (double, double, double) CalculatingClientBalance(DataTable DesiredClientBalanceDT)
        {
            double bundleBalance = 0;
            double ProductBalance = 0;
            double TotalBalance;
            foreach (DataRow d in DesiredClientBalanceDT.Rows)
            {

                if (d["product_id"] != DBNull.Value)
                {
                    ProductBalance += Convert.ToDouble(d["balance"]);

                }
                else
                {
                    bundleBalance += Convert.ToDouble(d["balance"]);
                }
            }
            TotalBalance = bundleBalance + ProductBalance;
            return (TotalBalance, bundleBalance, ProductBalance);
        }



        public static ClassClientBalance CreateClientBalanceObject(int ClientBalanceId)
        {

            DataRow DesiredClientBlanaceRow = GetClientBalanceAllInfoSql(ClientBalanceId);



            ClassClientBalance DesiredClientBalance = new ClassClientBalance();

            DesiredClientBalance.ClientBalanceID = Convert.ToInt32(DesiredClientBlanaceRow["client_balance_id"]);
            DesiredClientBalance.ClientId = Convert.ToInt32(DesiredClientBlanaceRow["client_id"]);
            DesiredClientBalance.BundleId = DesiredClientBlanaceRow["bundle_id"] is DBNull ? null : Convert.ToInt32(DesiredClientBlanaceRow["bundle_id"]);
            DesiredClientBalance.ProductId = DesiredClientBlanaceRow["product_id"] is DBNull ? null : Convert.ToInt32(DesiredClientBlanaceRow["product_id"]);
            DesiredClientBalance.PurchaseDate = DesiredClientBlanaceRow["purchase_date"] is DBNull ? null : Convert.ToDateTime(DesiredClientBlanaceRow["purchase_date"]);
            DesiredClientBalance.OriginalOffre = DesiredClientBlanaceRow["original_offre"] is DBNull ? null : (string)DesiredClientBlanaceRow["original_offre"];
            DesiredClientBalance.Offre = DesiredClientBlanaceRow["offre"] is DBNull ? null : (string)DesiredClientBlanaceRow["offre"];
            DesiredClientBalance.AmountPaid = DesiredClientBlanaceRow["amount_paid"] is DBNull ? null : Convert.ToDouble(DesiredClientBlanaceRow["amount_paid"]);
            DesiredClientBalance.Balance = DesiredClientBlanaceRow["balance"] is DBNull ? null : Convert.ToDouble(DesiredClientBlanaceRow["balance"]);
            DesiredClientBalance.SessionLeftDays = DesiredClientBlanaceRow["session_left_days"] is DBNull ? null : Convert.ToInt32(DesiredClientBlanaceRow["session_left_days"]);
            DesiredClientBalance.IsBundleMembership = DesiredClientBlanaceRow["isbundle_membership"] is DBNull ? null : Convert.ToBoolean(DesiredClientBlanaceRow["isbundle_membership"]);
            DesiredClientBalance.DueDate = DesiredClientBlanaceRow["due_date"] is DBNull ? null : Convert.ToDateTime(DesiredClientBlanaceRow["due_date"]);
            DesiredClientBalance.IsFreezed = DesiredClientBlanaceRow["is_freezed"] is DBNull ? null : Convert.ToBoolean(DesiredClientBlanaceRow["is_freezed"]);
            DesiredClientBalance.IsExpired = DesiredClientBlanaceRow["is_expired"] is DBNull ? null : Convert.ToBoolean(DesiredClientBlanaceRow["is_expired"]);



            return DesiredClientBalance;

        }



        //View Model
        //new function with sql
        public static List<ClassClientBalance> GetClientBalanceListNotExpiredPackage(int? clientID)
        {
            List<ClassClientBalance> ClientBalanceList = new List<ClassClientBalance> { };

            string query = @"Select	*                           
                            from client_balance 
                              where session_left_days is not null And is_expired='0' and c.bundle_id is not null and c.bundle_id=b.bundle_id ";

            if (clientID != null)
            {
                query += " And client_id='" + (int)clientID + "'";
            }
            query += " Order by is_expired ASC , purchase_date DESC ";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dtClientBalance = new DataTable();
            sda.Fill(dtClientBalance);
            foreach (DataRow dr in dtClientBalance.Rows)
            {
                ClientBalanceList.Add(CreateClientBalanceObject(Convert.ToInt32(dr["client_balance_id"])));
            }
            return ClientBalanceList;
        }


        public void SetStringDetailsIfBundle()
        {
            //Number Of Sessions or days
            if (BundleId != null)
            {
                BundleName = ClassBundles.FindBundleName((int)BundleId);
                BundleDuration = TimeSpan.Parse(ClassBundles.FindBundleDuration((int)BundleId));

                string Details = "";
                //sessionleft
                if (DueDate == null)//package of sessions
                {
                    Details = SessionLeftDays + " sess";
                }
                else if (DueDate != null)//package of days
                {

                    Details = DaysLeft + " days";//tene wahde - awwal wahde

                    if (IsFreezed == true)

                    {
                        Details += " (Freezed)";
                    }

                }

                ClientBalanceSessionLeftDetails = BundleName + ": " + Details;

            }
        }
        public ClassClientBalance Copy()//This Copy wont work fi Property eza fi  reference-type Properties (classes or list)/ eenda it s own methode, check ClassAppointment
        {
            return (ClassClientBalance)this.MemberwiseClone();
        }





    }
}

