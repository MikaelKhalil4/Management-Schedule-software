using GlobalFunctions;
using Microsoft.VisualBasic;
using MKproject.Schedule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKproject.Management
{
    public class ClassClientBalance//mainly used bel schedule , when we re selection a ervice
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);

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
        public DateTime? DueDate { get; set; }
        public bool? IsFreezed { get; set; }
        public bool? IsExpired { get; set; }



        //additional
        public bool ISPackageSessionsOrDays { get; set; }
        public bool IsPackageOrSolo { get; set; }
        public bool IsBundleOrProduct { get; set; }
        public int? SessionsLeft { get; set; }
        public int? DaysLeft { get; set; }

        //View 
        public string ClientBalanceSessionLeftDetails { get; set; }//additional,  it a string that describe the service,if package: adde baaed eendo session w masare,if solo: service name,
        public string ClientBalanceDetails { get; set; }//additional, null if not package, its a string: currency + Balance
        public string ClientBalanceFullDetails { get; set; }

        //Select
        public static DataTable GetClientBalanceSpecificOrLastInsert(int? ClientId)
        {

            String query = @"SELECT
                       cl.ID,  cl.bundle_id,b.bundle_name, cl.product_id, cl.purchase_date, cl.original_offre, cl.offre, cl.amount_paid, cl.balance, cl.session_left_days, cl.due_date,  cl.is_freezed,cl.is_expired,  cu.Currency_Name, cu.Symbol,            
                      CASE
                       WHEN cl.bundle_id IS NOT NULL THEN b.bundle_name
                          WHEN cl.product_id IS NOT NULL THEN p.product_name
                          ELSE 'Others' 
                         END AS Description  
                        FROM client_balance cl  
                        JOIN
                        Currencies cu ON cl.Currency_Name = cu.Currency_Name
                        LEFT JOIN
                        bundles b ON cl.bundle_id = b.bundle_id
                        LEFT JOIN
                        products p ON cl.product_id = p.product_id ";

            SqlCommand cmd = null;
            if (ClientId != null)
            {
                query += " Where cl.client_id = @client_id ORDER BY purchase_date ASC";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@client_id", ClientId);
            }
            else
            {
                query += " WHERE cl.ID = (SELECT MAX(ID) FROM client_balance)";
                cmd = new SqlCommand(query, con);
            }


            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtClientBalance = new DataTable();
            sda.Fill(dtClientBalance);
            return dtClientBalance;
        }
        public static (double, double) GetClientBalanceSpecificItem(int ClientBalanceId)
        {
            string query = "Select amount_paid,balance from client_balance WHERE ID=@ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", ClientBalanceId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return ((double)dt.Rows[0]["amount_paid"], Convert.ToDouble(dt.Rows[0]["balance"]));

        }
        public static DataTable GetClientBalanceNotExpiredPackage(int? clientID)
        {
            string query = @"Select	c.ID,c.client_id,c.bundle_id,b.bundle_name as Description,c.session_left_days,c.due_date,c.is_freezed,c.balance                           
                            from client_balance as c ,bundles  as b
                              where session_left_days is not null And is_expired='false' and c.bundle_id is not null and c.bundle_id=b.bundle_id ";

            if (clientID != null)
            {
                query += " And client_id='" + (int)clientID + "'";
            }
            query += " Order by is_expired ASC , purchase_date DESC ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtClientBalance = new DataTable();
            sda.Fill(dtClientBalance);
            return dtClientBalance;

        }
        public static DataTable GetClientBalanceAllInfoSql(int BalanceId)
        {
            SqlCommand cmd = new SqlCommand("select * from client_balance where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", BalanceId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
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
                  (client_id,bundle_id,product_id,purchase_date,original_offre,offre,amount_paid,balance,Currency_Name,session_left_days,isbundle_membership,due_date,is_freezed,is_expired) 
                                                              VALUES 
                  (@client_id,@bundle_id,@product_id,@purchase_date,@original_offre,@offre,@amount_paid,@balance,@Currency_Name,@session_left_days,@isbundle_membership,@due_date,@is_freezed,@is_expired)";

            SqlCommand cmd = new SqlCommand(query, con);


            if (bundleType != null)//bundles
            {
                bool IsMemberShip;
                (originalprice, NOSessionOrDays, IsMemberShip) = ClassBundles.FindBundleDetails(catgeoryid);

                if (bundleType == ClassBundles.enumBundle.Days.ToString())
                {
                    cmd.Parameters.AddWithValue("@session_left_days", NOSessionOrDays);
                    cmd.Parameters.AddWithValue("@is_freezed", false);

                    DateTime duedate = DateTime.Now.AddDays((int)NOSessionOrDays);
                    cmd.Parameters.AddWithValue("@due_date", duedate);

                    BundleType = ClassBundles.Days;
                    OriginalOffre = originalprice + "/" + Convert.ToInt16(NOSessionOrDays) + " " + BundleType;

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
                    OriginalOffre = originalprice + "/" + Convert.ToInt16(NOSessionOrDays) + " " + BundleType;

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


                cmd = new SqlCommand(query, con);
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
            cmd.Parameters.AddWithValue("@Currency_Name", Currency.CurrencyName);

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
        public static void UpdateClientBalanceAndInsertingFinanceOnPay(DataTable DesiredRowsDt, int AffectedRow, List<(double, int)> ListFinanceUpdates, DateTime Date, String AlbumType)
        {
            //client info retrieval IsMember & Album Type only meanwhile because later on they willl be already existes in the parent form


            for (int i = 0; i < AffectedRow; i++)
            {
                bool IsExpired = Convert.ToBoolean(DesiredRowsDt.Rows[i]["is_expired"]);
                string queryUpdate = "";
                //client_balance update
                if (IsExpired)
                {
                    queryUpdate = "UPDATE client_balance SET balance= @balance,amount_paid=@amount_paid,is_expired=@is_expired WHERE  ID=@id";
                }
                else
                {
                    queryUpdate = "UPDATE client_balance SET balance= @balance,amount_paid=@amount_paid WHERE  ID=@id";
                }

                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);
                cmdUpdate.Parameters.AddWithValue("@id", DesiredRowsDt.Rows[i]["ID"]);
                cmdUpdate.Parameters.AddWithValue("@balance", DesiredRowsDt.Rows[i]["balance"]);
                cmdUpdate.Parameters.AddWithValue("@amount_paid", DesiredRowsDt.Rows[i]["amount_paid"]);
                cmdUpdate.Parameters.AddWithValue("@is_expired", DesiredRowsDt.Rows[i]["is_expired"]);
                con.Open();
                cmdUpdate.ExecuteNonQuery();
                con.Close();
            }



            for (int i = 0; i < ListFinanceUpdates.Count; i++)
            {
                var Tuple = ListFinanceUpdates[i];
                ProjectToSQL.InsertToFinance(Tuple.Item2, Tuple.Item1, Date, AlbumType);
            }


        }


        public static void UpdateClientBalanceOnEditingOffre(int ID, string UpdatedOffre, double UpdatedBalance, bool isExpired)//isexpired mawjude cz ma3woul ykun gher bundle
        {
            string query = "";
            if (isExpired)
            {
                query = "UPDATE client_balance SET offre=@offre,balance=@balance,is_expired=@is_expired WHERE ID=@ID ";
            }
            else
            {
                query = "UPDATE client_balance SET offre=@offre,balance=@balance WHERE ID=@ID ";
            }
            SqlCommand cmdUpdate = new SqlCommand(query, con);
            cmdUpdate.Parameters.AddWithValue("@ID", ID);
            cmdUpdate.Parameters.AddWithValue("@balance", UpdatedBalance);
            cmdUpdate.Parameters.AddWithValue("@offre", UpdatedOffre);
            cmdUpdate.Parameters.AddWithValue("@is_expired", isExpired);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateClientBalanceOnEditingSessions(int ID, int UpdatedSessionOrDaysLeft, string newoffre, DateTime? Newduedate, bool isExpired)//isexpired mesh mawjude cz bas bundle hone
        {
            string query = "";
            SqlCommand cmdUpdate = null;
            if (newoffre != null)//Updating mode
            {
                if (Newduedate == null)
                {
                    query = "UPDATE client_balance SET session_left_days=@session_left_days,offre=@offre,is_expired=@is_expired WHERE ID=@ID ";
                    cmdUpdate = new SqlCommand(query, con);
                    cmdUpdate.Parameters.AddWithValue("@offre", newoffre);
                }
                else//days, w baddak now tkammil men hone, shuf el save points
                {
                    query = "UPDATE client_balance SET session_left_days=@session_left_days,offre=@offre,due_date=@due_date,is_expired=@is_expired WHERE ID=@ID ";
                    cmdUpdate = new SqlCommand(query, con);
                    cmdUpdate.Parameters.AddWithValue("@offre", newoffre);
                    //
                    DateTime DueDate = (DateTime)Newduedate;
                    cmdUpdate.Parameters.AddWithValue("@due_date", Newduedate);

                }

            }
            else//reducing a session mode
            {
                if (Newduedate == null)//mafi reduce session lal bundle days that s why ma hattayna else
                {
                    query = "UPDATE client_balance SET session_left_days=@session_left_days,is_expired=@is_expired  WHERE ID=@ID ";
                    cmdUpdate = new SqlCommand(query, con);
                }
            }

            cmdUpdate.Parameters.AddWithValue("@ID", ID);
            cmdUpdate.Parameters.AddWithValue("@session_left_days", UpdatedSessionOrDaysLeft);
            cmdUpdate.Parameters.AddWithValue("@is_expired", isExpired);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();


        }
        public static void UpdateClientBalanceOnFreezingDays(int ID, int UpdatedSessionOrDaysLeft, DateTime? Newduedate)
        {
            string query = "";
            SqlCommand cmdUpdate = null;
            bool IsFreezing;
            if (Newduedate == null)//freezing mode
            {
                query = "UPDATE client_balance SET session_left_days=@session_left_days,is_freezed=@is_freezed WHERE ID=@ID ";
                cmdUpdate = new SqlCommand(query, con);
                //
                IsFreezing = true;
            }
            else//reactivation mode
            {

                query = "UPDATE client_balance SET session_left_days=@session_left_days,due_date=@due_date,is_freezed=@is_freezed WHERE ID=@ID ";
                cmdUpdate = new SqlCommand(query, con);
                //
                DateTime DueDate = (DateTime)Newduedate;
                cmdUpdate.Parameters.AddWithValue("@due_date", Newduedate);
                //
                IsFreezing = false;


            }
            cmdUpdate.Parameters.AddWithValue("@session_left_days", UpdatedSessionOrDaysLeft);
            cmdUpdate.Parameters.AddWithValue("@is_freezed", IsFreezing);
            cmdUpdate.Parameters.AddWithValue("@ID", ID);

            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();

        }
        public static void UpdateIsexpiredClientBalanceRemoveUC(int ID, bool isExpired)
        {
            string query = "UPDATE client_balance SET is_expired=@is_expired WHERE ID=@ID ";
            SqlCommand cmdUpdate = new SqlCommand(query, con);
            cmdUpdate.Parameters.AddWithValue("@ID", ID);
            cmdUpdate.Parameters.AddWithValue("@is_expired", isExpired);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();

        }



        public static string SetPackageRemainingsFormat(DataRow dtrow)
        {
            string PackageRemainings = dtrow["Description"] + ": ";//Description = Bundle Name
            if (dtrow["due_date"] != DBNull.Value)
            {
                if ((bool)dtrow["is_freezed"] == false)//only packgae of days not freezed
                {
                    int daysLeft = RandomFunctions.GetDaysDifference(DateTime.Now, (DateTime)dtrow["due_date"]);
                    if (daysLeft < 0)
                    {
                        daysLeft = 0;
                    }
                    PackageRemainings += daysLeft + " Days Left";//tene wahde - awwal wahde
                }
                else//package days freezed
                {
                    PackageRemainings += (int)dtrow["session_left_days"] + " Days Left(Freezed)";
                }
            }
            else//package sesiosn
            {
                PackageRemainings += (int)dtrow["session_left_days"] + " Session Left";
            }
            return PackageRemainings;
        }
        public void SetStringDetailsIfBundle()
        {
            //Number Of Sessions or days
            if (BundleId != null)
            {
                string ServiceName;
                ServiceName = ClassBundles.FindBundleName((int)BundleId);
                //sessionleft
                if (ISPackageSessionsOrDays)//package of sessions
                {
                    ClientBalanceSessionLeftDetails = SessionLeftDays + " sess";
                }
                else if (!ISPackageSessionsOrDays)//package of days
                {
                    if (IsFreezed == false)//only packgae of days not freezed
                    {

                        ClientBalanceSessionLeftDetails = DaysLeft + " days";//tene wahde - awwal wahde
                    }
                    else//package days freezed
                    {
                        ServiceName += "(Freezed)";
                    }

                }
                ClientBalanceDetails = Program.SetBalanceFormat(Balance.ToString());
                ClientBalanceFullDetails = ServiceName + ": " + ClientBalanceSessionLeftDetails + " / " + ClientBalanceDetails;
            }
        }


        //new function with sql
        public static List<ClassClientBalance> GetClientBalanceListNotExpiredPackage(int? clientID)
        {
            List<ClassClientBalance> ClientBalanceList = new List<ClassClientBalance> { };

            string query = @"Select	*                           
                            from client_balance 
                              where session_left_days is not null And is_expired='false' and c.bundle_id is not null and c.bundle_id=b.bundle_id ";

            if (clientID != null)
            {
                query += " And client_id='" + (int)clientID + "'";
            }
            query += " Order by is_expired ASC , purchase_date DESC ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtClientBalance = new DataTable();
            sda.Fill(dtClientBalance);
            foreach (DataRow dr in dtClientBalance.Rows)
            {
                ClientBalanceList.Add(CreateClientBalanceObject((int)dr["ID"]));
            }
            return ClientBalanceList;
        }


        public static ClassClientBalance CreateClientBalanceObject(int ClientBalanceId)
        {
            DataTable dt;
            dt = GetClientBalanceAllInfoSql(ClientBalanceId);
            DataRow datarow = dt.Rows[0];//since we re expecting one row of return


            ClassClientBalance DesiredClientBalance = new ClassClientBalance();

            DesiredClientBalance.ClientBalanceID = (int)datarow["ID"];
            DesiredClientBalance.ClientId = (int)datarow["client_id"];
            DesiredClientBalance.BundleId = datarow["bundle_id"] is DBNull ? null : (int)datarow["bundle_id"];
            DesiredClientBalance.ProductId = datarow["product_id"] is DBNull ? null : (int)datarow["product_id"];
            DesiredClientBalance.PurchaseDate = datarow["purchase_date"] is DBNull ? null : (DateTime)datarow["purchase_date"];
            DesiredClientBalance.OriginalOffre = datarow["original_offre"] is DBNull ? null : (string)datarow["original_offre"];
            DesiredClientBalance.Offre = datarow["offre"] is DBNull ? null : (string)datarow["offre"];
            DesiredClientBalance.AmountPaid = datarow["amount_paid"] is DBNull ? null : (double)datarow["amount_paid"];
            DesiredClientBalance.Balance = datarow["balance"] is DBNull ? null : (double)datarow["balance"];
            DesiredClientBalance.CurrencyName = datarow["Currency_Name"] is DBNull ? null : (string)datarow["Currency_Name"];
            DesiredClientBalance.SessionLeftDays = datarow["session_left_days"] is DBNull ? null : (int)datarow["session_left_days"];
            DesiredClientBalance.IsBundleMembership = datarow["isbundle_membership"] is DBNull ? null : (bool)datarow["isbundle_membership"];
            DesiredClientBalance.DueDate = datarow["due_date"] is DBNull ? null : (DateTime)datarow["due_date"];
            DesiredClientBalance.IsFreezed = datarow["is_freezed"] is DBNull ? null : (bool)datarow["is_freezed"];
            DesiredClientBalance.IsExpired = datarow["is_expired"] is DBNull ? null : (bool)datarow["is_expired"];





            if (DesiredClientBalance.BundleId != null)//Bundle
            {
                DesiredClientBalance.IsBundleOrProduct = true;

                if (DesiredClientBalance.SessionLeftDays != null)//package
                {
                    DesiredClientBalance.IsPackageOrSolo = true;
                    if (DesiredClientBalance.DueDate == null)// package of sessions
                    {
                        DesiredClientBalance.ISPackageSessionsOrDays = true;
                        DesiredClientBalance.SessionsLeft = (int)DesiredClientBalance.SessionLeftDays;
                    }
                    else//package of days
                    {
                        DesiredClientBalance.ISPackageSessionsOrDays = false;
                        DesiredClientBalance.DaysLeft = RandomFunctions.GetDaysDifference(DateTime.Now, (DateTime)DesiredClientBalance.DueDate);
                        if (DesiredClientBalance.DaysLeft < 0)
                        {
                            DesiredClientBalance.DaysLeft = 0;
                        }
                    }
                }
                else//solo
                {
                    DesiredClientBalance.IsPackageOrSolo = false;
                }
            }
            else//product
            {
                DesiredClientBalance.IsBundleOrProduct = false;
            }

            return DesiredClientBalance;

        }

        public ClassClientBalance Copy()
        {
            return (ClassClientBalance)this.MemberwiseClone();
        }
    }
}

