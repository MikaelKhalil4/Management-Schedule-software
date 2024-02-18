using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace MKproject.Management
{
    internal class ProjectToSQL
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);
        static Currency currency = new Currency();



        ///client balance
        //in here we can distinguish 4 categories
        // bundle not product: bundle_id!=null
        //proct not bundle: product_id!=null
        //package not solo: session_left_days!=null/ service not package: session_left_days==null
        //in package it could be sessions or days
        //session not days: due_date==null/days not sessionsdue_date!=nu;;
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
            bool IsExpired=false;
            string query = @"INSERT into  client_balance
                  (client_id,bundle_id,product_id,purchase_date,original_offre,offre,amount_paid,balance,Currency_Name,session_left_days,isbundle_membership,due_date,is_freezed,is_expired) 
                                                              VALUES 
                  (@client_id,@bundle_id,@product_id,@purchase_date,@original_offre,@offre,@amount_paid,@balance,@Currency_Name,@session_left_days,@isbundle_membership,@due_date,@is_freezed,@is_expired)";

            SqlCommand cmd = new SqlCommand(query, con);


            if (bundleType != null)//bundles
            {
                bool IsMemberShip;
                (originalprice, NOSessionOrDays, IsMemberShip) = ClassBundles.FindBundleDetails(catgeoryid);

                if (bundleType == ClassBundles.bundle.Days.ToString())
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
                else if (bundleType == ClassBundles.bundle.Sessions.ToString())
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
                InsertToFinance(Tuple.Item2, Tuple.Item1, Date, AlbumType);
            }


        }
        public static void InsertToFinance(int ClientBalanceId, Double AmountPaid, DateTime Date, String AlbumType)
        {

            string QueryInsert = @"INSERT INTO finance (id_client_balance,AlbumType,amount_paid,payment_date,Currency_Name) 
                        VALUES
                        (@id_client_balance,@AlbumType,@amount_paid,@payment_date,@Currency_Name) ";

            SqlCommand cmdInsert = new SqlCommand(QueryInsert, con); // Initialize the SqlCommand inside the loop

            cmdInsert.Parameters.AddWithValue("@id_client_balance", ClientBalanceId);

            if (AlbumType == null)
            {
                cmdInsert.Parameters.AddWithValue("@AlbumType", DBNull.Value);

            }
            else
            {
                cmdInsert.Parameters.AddWithValue("@AlbumType", AlbumType);
            }
            cmdInsert.Parameters.AddWithValue("@amount_paid", AmountPaid);
            cmdInsert.Parameters.AddWithValue("@payment_date", Date);
            cmdInsert.Parameters.AddWithValue("@Currency_Name", Currency.CurrencyName);
            con.Open();
            cmdInsert.ExecuteNonQuery();
            con.Close();
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




        //client_struct table
        public static void InsertToClientAttendance(int ClientID)
        {

            string QueryInsert = "insert into client_attendance (client_id,execute_date) values (@client_id,@execute_date)";
            SqlCommand cmdInsert = new SqlCommand(QueryInsert, con);
            cmdInsert.Parameters.AddWithValue("@client_id", ClientID);
            cmdInsert.Parameters.AddWithValue("@execute_date", DateTime.Today);
            con.Open();
            cmdInsert.ExecuteNonQuery();
            con.Close();


        }


        //album
        public static void InsertNewAlbum(string albumName)
        {
            string query = "INSERT INTO Albums (AlbumType) VALUES (@AlbumName)";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@AlbumName", albumName);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();

        }
        public static void UpdateAlbum(string NewAlbumName, string OldAlbumName)
        {
            string query = "UPDATE Albums SET AlbumType = @NewAlbumName WHERE AlbumType = @AlbumName";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@AlbumName", OldAlbumName);
            command.Parameters.AddWithValue("@NewAlbumName", NewAlbumName);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void DeleteAlbum(string AlbumName)
        {
            string query = "Delete Albums  WHERE AlbumType = @AlbumName";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@AlbumName", AlbumName);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }


        //registrationFidls
        public static void UpdateField(bool Isvisible, bool IsRequired, int id)
        {
            SqlCommand command = new SqlCommand("UPDATE required_visible_fields SET Visible = @Visible, Required = @Required WHERE id = @ID", con);
            command.Parameters.AddWithValue("@Visible", Isvisible);
            command.Parameters.AddWithValue("@Required", IsRequired);
            command.Parameters.AddWithValue("@ID", id);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }


    }
}
