
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GlobalFunctions;

namespace MKproject.Management
{

    public partial class TransferData : Form
    {
        public static SqlConnection conOld = new SqlConnection("Data Source=MKpc;Initial Catalog=MK-ELKdata;Integrated Security=True;");
        public static SqlConnection conNew = new SqlConnection("Data Source=MKpc;Initial Catalog=MK-ELKdataNew;Integrated Security=True");
        public TransferData()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //TransferClientInfo();
            //TransferClientBalanceBundle();
            //TransferClientBalanceProduct();
            //TransferClientPaidBundle();
            //TransferClientPaidProduct();
            //TransferClientInfoTrialsInvitationBrochure();
            //UpdateClientInfoTrialsInvitationBrochure();
            //InsertIntoFinance();
            //UpdateTotalPayment();
            this.Close();
        }
        void InsertIntoFinance()
        {

            DataTable dtBundles = selectFinancepackges();
            foreach (DataRow dr in dtBundles.Rows)
            {
                int ClientId = GetClientIdFromPhoneNumberSQL((string)dr["phone_number"]);
                int IdClientBalance = GetBalanceId(ClientId, true);
                string AlbumType = GetAlbumType(ClientId);
                double amountPaid = (double)dr["amount_payed"];
                DateTime PaymentDate = (DateTime)dr["payment_date"];

                InsertToFinance(IdClientBalance, AlbumType, amountPaid, PaymentDate);
            }


            DataTable dtproduct = selectFinanceproducts();
            foreach (DataRow dr in dtproduct.Rows)
            {
                int ClientId = GetClientIdFromPhoneNumberSQL((string)dr["phone_number"]);
                int IdClientBalance = GetBalanceId(ClientId, false);
                string AlbumType = GetAlbumType(ClientId);
                double amountPaid = (double)dr["amount_paid"];
                DateTime PaymentDate = (DateTime)dr["payment_date"];

                InsertToFinance(IdClientBalance, AlbumType, amountPaid, PaymentDate);
            }


            //trials
            DataTable dttrials = selectFinanceTrials();
            foreach (DataRow dr in dttrials.Rows)
            {
                int ClientId = GetClientIdFromPhoneNumberSQL((string)dr["phone_number"]);
                if (ClientId != -1)
                {
                    int IdClientBalance = GetBalanceId(ClientId, true);
                    if (IdClientBalance != -1)
                    {
                        string AlbumType = GetAlbumType(ClientId);
                        double amountPaid = (double)dr["amount_payed"];
                        DateTime PaymentDate = (DateTime)dr["trial_date"];
                        InsertToFinance(IdClientBalance, AlbumType, amountPaid, PaymentDate);
                    }
                }
            }

        }

        void UpdateClientInfoTrialsInvitationBrochure()
        {
            DataTable dtTrials = selectTrialsClients(true);
            DataTable dtInv = selectInvitationClients(true);
            DataTable dtBroch = selectBrochureClients(true);
            int bundleid = SelectOldBundleId();

            foreach (DataRow dr in dtTrials.Rows)
            {
                int ClientId = GetClientIdFromPhoneNumberSQL((string)dr["phone_number"]);
                if (ClientId != -1)
                {
                    UpdateAlbum(ClientId, "Trials");

                    double AmountPaid = (double)dr["amount_payed"];
                    if (AmountPaid != 0)
                    {
                        UpdateClientBalancePaid(ClientId, bundleid, AmountPaid);
                        UpdateClientTotalPayemntsSQL(ClientId, AmountPaid);
                    }

                   
                }
            }

            foreach (DataRow dr in dtInv.Rows)
            {
                int ClientId = GetClientIdFromPhoneNumberSQL((string)dr["phone_number"]);

                if (ClientId != -1)
                {
                    UpdateAlbum(ClientId, "Invitations");
                }
            }

            foreach (DataRow dr in dtBroch.Rows)
            {
                int ClientId = GetClientIdFromPhoneNumberSQL((string)dr["phone_number"]);
                if (ClientId != -1)
                {
                    UpdateAlbum(ClientId, "Trials");
                    double AmountPaid = (double)dr["price"];
                    if (AmountPaid != 0)
                    {
                        UpdateClientBalancePaid(ClientId, bundleid, AmountPaid);
                        UpdateClientTotalPayemntsSQL(ClientId, AmountPaid);
                    }
                }

            }
        }

        void TransferClientInfoTrialsInvitationBrochure()
        {
            DateTime Date = DateTime.Now;

            DataTable dtTrials = selectTrialsClients(false);
            DataTable dtInv = selectInvitationClients(false);
            DataTable dtBroch = selectBrochureClients(false);

            int bundleid = SelectOldBundleId();

            foreach (DataRow dr in dtTrials.Rows)
            {
                int clientid = GetClientIdFromPhoneNumberSQL((string)dr["phone_number"]);
                if (clientid == -1)
                {
                    ClassClient NewClient = new ClassClient();
                    NewClient.AlbumType = "Trials";
                    NewClient.IsChild = false;
                    NewClient.IsParent = false;
                    NewClient.Fname = (string)dr["first_name"];
                    NewClient.Lname = (string)dr["last_name"];
                    NewClient.PhoneNumber = (string)dr["phone_number"];
                    if (((string)dr["username"]) != "none")//remove the first charchter @
                        NewClient.InstaUserName = ((string)dr["username"]).Substring(1);

                    NewClient.InsertClientToSQL();


                    double AmountPaid = (double)dr["amount_payed"];
                    if (AmountPaid != 0)
                    {
                        int lastinsetClientid = GetLastClientIDSQL();
                        InsertBundleToClientPayments(lastinsetClientid, bundleid, AmountPaid);
                        UpdateClientTotalPayemntsSQL(lastinsetClientid, AmountPaid);
                    }



                    //update
                    int ClientId = ClassClient.GetLastClientIDSQL();

                    if (dr["trial_date"] != DBNull.Value)
                    {
                        ClassClient.UpdateClientCheckInSQL(ClientId, (DateTime)dr["trial_date"]);
                    }
                    UpdateClientSaveDateSQL(ClientId, Date);

                }
            }
            foreach (DataRow dr in dtInv.Rows)
            {
                int clientid = GetClientIdFromPhoneNumberSQL((string)dr["phone_number"]);
                if (clientid == -1)
                {
                    ClassClient NewClient = new ClassClient();
                    NewClient.AlbumType = "Invitations";
                    NewClient.IsChild = false;
                    NewClient.IsParent = false;
                    NewClient.Fname = (string)dr["first_name"];
                    NewClient.Lname = (string)dr["last_name"];
                    NewClient.PhoneNumber = (string)dr["phone_number"];
                    if (((string)dr["username"]) != "none")//remove the first charchter @
                        NewClient.InstaUserName = ((string)dr["username"]).Substring(1);

                    NewClient.InsertClientToSQL();


                    //update
                    int ClientId = ClassClient.GetLastClientIDSQL();

                    if (dr["invitation_date"] != DBNull.Value)
                    {
                        ClassClient.UpdateClientCheckInSQL(ClientId, (DateTime)dr["invitation_date"]);
                    }
                    UpdateClientSaveDateSQL(ClientId, Date);

                }
            }
            foreach (DataRow dr in dtBroch.Rows)
            {
                int clientid = GetClientIdFromPhoneNumberSQL((string)dr["phone_number"]);
                if (clientid == -1)
                {
                    ClassClient NewClient = new ClassClient();
                    NewClient.AlbumType = "Trials";
                    NewClient.IsChild = false;
                    NewClient.IsParent = false;
                    NewClient.Fname = (string)dr["first_name"];
                    NewClient.Lname = (string)dr["last_name"];
                    NewClient.PhoneNumber = (string)dr["phone_number"];
                    if (((string)dr["username"]) != "none")//remove the first charchter @
                        NewClient.InstaUserName = ((string)dr["username"]).Substring(1);

                    NewClient.InsertClientToSQL();


                    double AmountPaid = (double)dr["price"];
                    if (AmountPaid != 0)
                    {
                        int lastinsetClientid = GetLastClientIDSQL();
                        InsertBundleToClientPayments(lastinsetClientid, bundleid, AmountPaid);
                        UpdateClientTotalPayemntsSQL(lastinsetClientid, AmountPaid);
                    }

                    //update
                    int ClientId = ClassClient.GetLastClientIDSQL();

                    if (dr["brochure_date"] != DBNull.Value)
                    {
                        ClassClient.UpdateClientCheckInSQL(ClientId, (DateTime)dr["brochure_date"]);
                    }
                   UpdateClientSaveDateSQL(ClientId, Date);

                }
            }
        }

        void TransferClientInfo()
        {

            DateTime Date = DateTime.Now;


            DataTable dt = selectClients();


            foreach (DataRow dr in dt.Rows)
            {
                ClassClient NewClient = new ClassClient();
                NewClient.IsChild = false;
                NewClient.IsParent = false;
                NewClient.AlbumType = null;
                NewClient.Fname = (string)dr["name"];
                NewClient.Lname = (string)dr["family_name"];
                NewClient.PhoneNumber = (string)dr["phone_number"];
                NewClient.Gender = (string)dr["gender"];
                NewClient.BirthDate = (DateTime)dr["date_of_birth"];


                if (((string)dr["special_note"]) != "none")
                    NewClient.Note = (string)dr["special_note"];

                if (((string)dr["insta_user"]) != "none")//remove the first charchter @
                    NewClient.InstaUserName = ((string)dr["insta_user"]).Substring(1);

                if (((string)dr["job"]) != "none")
                    NewClient.Job = (string)dr["job"];

                if (((string)dr["adress"]) != "none")
                    NewClient.Adress = (string)dr["adress"];


                //capital at the start and after each / + remove the last /        
                NewClient.BodyShapeTarget = CapitalizeSegmentsAndRemoveLastSlash((string)dr["body_shape_target"],false);
                NewClient.MuscleFocusOn = CapitalizeSegmentsAndRemoveLastSlash((string)dr["muscles_focus_on"],false);
                NewClient.Injuries = CapitalizeSegmentsAndRemoveLastSlash((string)dr["injuries"],true);



                NewClient.Weight = (int)dr["weight"] + "/kg";
                NewClient.Height = (int)dr["height"] + "/cm";


                NewClient.Hand = (string)dr["hand"];
                NewClient.SessionPerWeek = (int)dr["sessions_per_week"];


                NewClient.InsertClientToSQL();

                //update
                int ClientId = ClassClient.GetLastClientIDSQL();

                if (dr["check_in"] != DBNull.Value)
                {
                    ClassClient.UpdateClientCheckInSQL(ClientId, (DateTime)dr["check_in"]);
                }
                UpdateClientSaveDateSQL(ClientId, Date);
                UpdateClientRegistrationDateSQL(ClientId, Date);
            }

        }
        void TransferClientBalanceBundle()
        {
            DataTable dt = selectClients();

            int ClientId;
            int SessionLeft;
            string PackageName;
            int PackageId;
            double BalancePackage;
            double offrePrice;
            int offreSessions;
            string offre;
            foreach (DataRow dr in dt.Rows)
            {
                ClientId = GetClientIdFromPhoneNumberSQL((string)dr["phone_number"]);
                SessionLeft = (int)dr["sessions_left"];
                PackageName = (string)dr["package_type"];
                PackageId = FindBundleId(PackageName);
                (offrePrice, offreSessions) = FindBundleDetails(PackageId);
                offre = offrePrice + "/" + Convert.ToInt16(offreSessions) + " " + ClassBundles.Session;
                BalancePackage = (double)dr["balance_package"];
                if (BalancePackage > 0)
                {
                    BalancePackage = BalancePackage * -1;
                }
                if (BalancePackage != 0 || SessionLeft > 0)
                {
                    InsertBundleToClientBalance(ClientId, PackageId, offre, BalancePackage, SessionLeft);
                    UpdateClientTotalBalanceSQL(ClientId, BalancePackage);
                }
            }

        }
        void TransferClientBalanceProduct()
        {
            DataTable dt = selectClients();

            int ClientId;
            string ProductName;
            int ProductId;
            double BalancePRODUCT;
            double offre;
            foreach (DataRow dr in dt.Rows)
            {
                ClientId = GetClientIdFromPhoneNumberSQL((string)dr["phone_number"]);
                if (!String.IsNullOrEmpty((string)dr["product_name"]))
                {
                    ProductName = RetrieveBeforeLastSegment((string)dr["product_name"]);
                    ProductId = FindProductId(ProductName);
                    offre = FindProductDetails(ProductId);
                    BalancePRODUCT = (double)dr["balance_products"];
                    if (BalancePRODUCT > 0)
                    {
                        BalancePRODUCT = BalancePRODUCT * -1;
                    }
                    if (BalancePRODUCT != 0)
                    {
                        InsertProducetToClientBalance(ClientId, offre, ProductId, BalancePRODUCT);
                        UpdateClientTotalBalanceSQL(ClientId, BalancePRODUCT);
                    }
                }
            }

        }


        void TransferClientPaidBundle()
        {
            DataTable dt = SelectClientBundlePayments();

            int bundleid = SelectOldBundleId();
            int clientid;
            double AmountPaid;
            foreach (DataRow dr in dt.Rows)
            {
                clientid = GetClientIdFromPhoneNumberSQL((string)dr["phone_number"]);//id in the new sql
                AmountPaid = (double)dr["AmountPaid"];
                InsertBundleToClientPayments(clientid, bundleid, AmountPaid);
                UpdateClientTotalPayemntsSQL(clientid, AmountPaid);
            }

        }
        void TransferClientPaidProduct()
        {
            DataTable dt = SelectClientProductPayments();
            int productid = SelectOldProductId();
            int clientid;
            double AmountPaid;
            foreach (DataRow dr in dt.Rows)
            {
                clientid = GetClientIdFromPhoneNumberSQL((string)dr["phone_number"]);
                AmountPaid = (double)dr["AmountPaid"];
                InsertProductToClientPayments(clientid, productid, AmountPaid);
                UpdateClientTotalPayemntsSQL(clientid, AmountPaid);
            }
        }

        private string CapitalizeSegmentsAndRemoveLastSlash(string input,bool IsInjuries)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Split the string by '/'
            string[] segments = input.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < segments.Length; i++)
            {
               

                if (segments[i].Length > 0)
                {
                    // Capitalize the first character of each segment
                    segments[i] = char.ToUpper(segments[i][0]) + segments[i].Substring(1);
                }

                if (IsInjuries)
                {
                    bool ValueExist = false;
                    foreach (ClassOptionsInsideFields.enumInjuries enumValue in Enum.GetValues(typeof(ClassOptionsInsideFields.enumInjuries)))
                    {
                        if (segments[i] == enumValue.GetStringValue())
                        {
                            ValueExist = true;
                            break;
                        }
                    }
                    if (!ValueExist)
                    {
                        segments[i] = "Others:" + segments[i];
                    }
                }


            }

            // Join the segments with a '/' and remove the last '/'
            string result = string.Join("/", segments);
            return result;
        }
        private string RetrieveBeforeLastSegment(string input)
        {

            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            string[] segments = input.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string result = segments[segments.Length - 1].Trim();
            return result;

        }



        //old

        DataTable selectFinancepackges()
        {
            string queryClient = "Select phone_number,amount_payed,payment_date from finance_packages as f,client as c where f.client_id=c.client_id"; /*ORDER BY check_in DESC*/
            SqlCommand cmd = new SqlCommand(queryClient, conOld);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        DataTable selectFinanceproducts()
        {
            string queryClient = "select phone_number,amount_paid,payment_date from finance_products as f,client as c where f.client_id=c.client_id"; /*ORDER BY check_in DESC*/
            SqlCommand cmd = new SqlCommand(queryClient, conOld);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        DataTable selectFinanceTrials()
        {
            string queryClient = "select phone_number,amount_payed,trial_date from trials";
            SqlCommand cmd = new SqlCommand(queryClient, conOld);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        DataTable selectInvitationClients(bool status)
        {
            string queryClient = "Select * from invitations where status_current='" + status + "'"; /*ORDER BY check_in DESC*/
            SqlCommand cmd = new SqlCommand(queryClient, conOld);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        DataTable selectTrialsClients(bool status)
        {
            string queryClient = "Select * from trials where status_current='" + status + "' And first_name!='test'"; /*ORDER BY check_in DESC*/
            SqlCommand cmd = new SqlCommand(queryClient, conOld);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        DataTable selectBrochureClients(bool status)
        {
            string queryClient = "Select * from brochures where  status_current='" + status + "' and  first_name is not null"; /*ORDER BY check_in DESC*/
            SqlCommand cmd = new SqlCommand(queryClient, conOld);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        DataTable selectClients()
        {
            string queryClient = "Select * from client "; /*ORDER BY check_in DESC*/
            SqlCommand cmd = new SqlCommand(queryClient, conOld);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        DataTable SelectClientBundlePayments()
        {
            string queryClient = "select phone_number,sum(amount_payed) as AmountPaid from finance_packages as f,client as c where f.client_id=c.client_id group by phone_number ";
            SqlCommand cmd = new SqlCommand(queryClient, conOld);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        DataTable SelectClientProductPayments()
        {
            string queryClient = "select phone_number,sum(amount_paid) as AmountPaid from finance_products as f,client as c where f.client_id=c.client_id group by phone_number ";
            SqlCommand cmd = new SqlCommand(queryClient, conOld);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }






        //new
        void UpdateTotalPayment()
        {
           

            string query1 = @"Select client_id,SUM(amount_paid) as total
                            from client_balance as c
                             Group By  client_id ";

            SqlCommand cmd1 = new SqlCommand(query1, conNew);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dtClientBalance = new DataTable();
            sda1.Fill(dtClientBalance);


            foreach (DataRow dr in dtClientBalance.Rows)
            {
                string query = "UPDATE client SET total_payment=@total_payment where client_id=@client_id";
                SqlCommand cmd = new SqlCommand(query, conNew);
                cmd.Parameters.AddWithValue("@client_id", dr["client_id"]);
                cmd.Parameters.AddWithValue("@total_payment", dr["total"]);
                conNew.Open();
                cmd.ExecuteNonQuery();
                conNew.Close();
            }
        }

        void InsertToFinance(int BalanceId, string AlbumType, double AmountPaid, DateTime Date)
        {
            string query = "Insert into finance (client_balance_id,AlbumType,amount_paid,payment_date,Currency_Name) Values (@client_balance_id,@AlbumType,@amount_paid,@payment_date,@Currency_Name)";
            SqlCommand cmd = new SqlCommand(query, conNew);

            cmd.Parameters.AddWithValue("@client_balance_id", BalanceId);
            if (String.IsNullOrEmpty(AlbumType))
            {
                cmd.Parameters.AddWithValue("@AlbumType", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@AlbumType", AlbumType);
            }
            cmd.Parameters.AddWithValue("@amount_paid", AmountPaid);
            cmd.Parameters.AddWithValue("@payment_date", Date);
            cmd.Parameters.AddWithValue("@Currency_Name", Currency.CurrencyName);
            conNew.Open();
            cmd.ExecuteNonQuery();
            conNew.Close();
        }


        void UpdateAlbum(int ClientID, string AlbumType)
        {
            string query = "UPDATE client SET AlbumType=@AlbumType where client_id=@client_id";
            SqlCommand cmd = new SqlCommand(query, conNew);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            cmd.Parameters.AddWithValue("@AlbumType", AlbumType);
            conNew.Open();
            cmd.ExecuteNonQuery();
            conNew.Close();
        }

        int SelectOldBundleId()
        {
            string queryClient = "select bundle_id from bundles where bundle_name='Old Services Data' ";
            SqlCommand cmd = new SqlCommand(queryClient, conNew);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return (int)dt.Rows[0][0];
        }
        int SelectOldProductId()
        {
            string queryClient = "select product_id from products where product_name='Old Products Data' ";
            SqlCommand cmd = new SqlCommand(queryClient, conNew);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return (int)dt.Rows[0][0];
        }



        public (double, int) FindBundleDetails(int BundleId)
        {

            string query = "Select price,sessions_numb From bundles where bundle_id='" + BundleId + "'";
            SqlCommand cmd = new SqlCommand(query, conNew);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return ((double)dt.Rows[0]["price"], (int)dt.Rows[0]["sessions_numb"]);
        }
        public double FindProductDetails(int categoryId)
        {

            string query = "Select product_price From products WHERE  product_id='" + categoryId + "'";
            SqlCommand cmd = new SqlCommand(query, conNew);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);


            // Return the results as a tuple
            return ((double)dt.Rows[0]["product_price"]);
        }
        public  void UpdateClientRegistrationDateSQL(int ClientID, DateTime Date)
        {
            string query = "UPDATE client SET Registration_Date=@Registration_Date WHERE client_id=@client_id ";
            SqlCommand cmdUpdate = new SqlCommand(query, conNew);
            cmdUpdate.Parameters.AddWithValue("@client_id", ClientID);
            cmdUpdate.Parameters.AddWithValue("@Registration_Date", Date.AddYears(-1).AddMonths(-6));
            conNew.Open();
            cmdUpdate.ExecuteNonQuery();
            conNew.Close();
        }
        public  void UpdateClientSaveDateSQL(int ClientID, DateTime Date)
        {
            string query = "UPDATE client SET save_date=@save_date WHERE client_id=@client_id ";
            SqlCommand cmdUpdate = new SqlCommand(query, conNew);
            cmdUpdate.Parameters.AddWithValue("@client_id", ClientID);
            cmdUpdate.Parameters.AddWithValue("@save_date", Date.AddYears(-1).AddMonths(-6));
            conNew.Open();
            cmdUpdate.ExecuteNonQuery();
            conNew.Close();
        }
        public void UpdateClientTotalBalanceSQL(int ClientID, double TotalBalance)
        {
            string query = "UPDATE client SET total_balance+=@total_balance where client_id=@client_id";
            SqlCommand cmd = new SqlCommand(query, conNew);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            cmd.Parameters.AddWithValue("@total_balance", TotalBalance);
            conNew.Open();
            cmd.ExecuteNonQuery();
            conNew.Close();
        }
        public void UpdateClientTotalPayemntsSQL(int ClientID, double totalPayemnt)
        {
            string query = "UPDATE client SET total_payment+=@total_payment where client_id=@client_id";
            SqlCommand cmd = new SqlCommand(query, conNew);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            cmd.Parameters.AddWithValue("@total_payment", totalPayemnt);
            conNew.Open();
            cmd.ExecuteNonQuery();
            conNew.Close();
        }
        public static int GetClientIdFromPhoneNumberSQL(string PhoneNumber)
        {
            string queryClient = "select client_id  from client WHERE phone_number='" + PhoneNumber + "'";

            SqlCommand cmd = new SqlCommand(queryClient, conNew);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return (int)dt.Rows[0]["client_id"];
            else
                return -1;
        }
        public static int GetLastClientIDSQL()
        {

            int lastClientId;
            conNew.Open();
            string getLastClientIdQuery = "SELECT Max(client_id) FROM client";

            using (SqlCommand command = new SqlCommand(getLastClientIdQuery, conNew))
            {
                lastClientId = Convert.ToInt32(command.ExecuteScalar());//we re sure enno ma tredd -1
            }
            conNew.Close();
            return lastClientId;
        }
        string GetAlbumType(int ClientID)
        {
            string query = "Select AlbumType from client where client_id=@client_id";
            SqlCommand cmd = new SqlCommand(query, conNew);
            cmd.Parameters.AddWithValue("@client_id", ClientID);
            conNew.Open();
            string albumType;
            using (SqlCommand command = new SqlCommand(query, conNew))
            {
                command.Parameters.AddWithValue("@client_id", ClientID);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    albumType = Convert.ToString(command.ExecuteScalar());
                }
                else
                {
                    albumType = null;
                }

            }
            conNew.Close();
            return albumType;

        }
        int GetBalanceId(int ClientID, bool IsBundleOrProduct)
        {
            string query;
            query = "Select client_balance_id from client_balance where client_id=@client_id And is_expired=1  ";
            if (IsBundleOrProduct)
            {
                query += " And bundle_id IS Not Null";
            }
            else
            {
                query += " And product_id IS Not Null";
            }

            int Id;
            conNew.Open();
            using (SqlCommand command = new SqlCommand(query, conNew))
            {
                command.Parameters.AddWithValue("@client_id", ClientID);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    Id = Convert.ToInt16(command.ExecuteScalar());
                }
                else
                {
                    Id = -1;
                }

            }
            conNew.Close();
            return Id;
        }


        public int FindBundleId(string packageName)
        {

            string query = "Select bundle_id From bundles where bundle_name='" + packageName + "'";
            SqlCommand cmd = new SqlCommand(query, conNew);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // Return the results as a tuple
            return (int)dt.Rows[0]["bundle_id"];
        }
        public int FindProductId(string productName)
        {
            string query = "Select product_id From products WHERE  product_name='" + productName + "'";
            SqlCommand cmd = new SqlCommand(query, conNew);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);


            return (int)dt.Rows[0]["product_id"];


        }


        public void InsertBundleToClientPayments(int clientid, int BundleId, double AmountPaid)
        {
            string query = @"INSERT into  client_balance
                  (client_id,bundle_id,amount_paid,Currency_Name,is_expired,session_left_days,isbundle_membership,balance) 
                                                              VALUES 
                  (@client_id,@bundle_id,@amount_paid,@Currency_Name,@is_expired,@session_left_days,@isbundle_membership,@balance)";

          
            SqlCommand cmd = new SqlCommand(query, conNew);
            cmd.Parameters.AddWithValue("@client_id", clientid);
            cmd.Parameters.AddWithValue("@bundle_id", BundleId);
            cmd.Parameters.AddWithValue("@amount_paid", AmountPaid);
            cmd.Parameters.AddWithValue("@Currency_Name", Currency.CurrencyName);
            cmd.Parameters.AddWithValue("@is_expired", true);
            cmd.Parameters.AddWithValue("@session_left_days", 0);
            cmd.Parameters.AddWithValue("@isbundle_membership", true);
            cmd.Parameters.AddWithValue("@balance", 0);
            conNew.Open();
            cmd.ExecuteNonQuery();
            conNew.Close();
        }
        public void InsertProductToClientPayments(int clientid, int ProductId, double AmountPaid)
        {
            string query = @"INSERT into  client_balance
                  (client_id,product_id,amount_paid,Currency_Name,is_expired,balance) 
                                                              VALUES 
                  (@client_id,@product_id,@amount_paid,@Currency_Name,@is_expired,@balance)";

            SqlCommand cmd = new SqlCommand(query, conNew);

            cmd.Parameters.AddWithValue("@client_id", clientid);
            cmd.Parameters.AddWithValue("@product_id", ProductId);
            cmd.Parameters.AddWithValue("@amount_paid", AmountPaid);
            cmd.Parameters.AddWithValue("@Currency_Name", Currency.CurrencyName);
            cmd.Parameters.AddWithValue("@is_expired", true);
            cmd.Parameters.AddWithValue("@balance", 0);

            conNew.Open();
            cmd.ExecuteNonQuery();
            conNew.Close();
        }
        void UpdateClientBalancePaid(int clientid, int BundleId, double AmountPaid)
        {
            string query = @"Update client_balance Set amount_paid+=@amount_paid where bundle_id=@bundle_id And client_id=@client_id";
            SqlCommand cmd = new SqlCommand(query, conNew);
            cmd.Parameters.AddWithValue("@client_id", clientid);
            cmd.Parameters.AddWithValue("@bundle_id", BundleId);
            cmd.Parameters.AddWithValue("@amount_paid", AmountPaid);
            conNew.Open();
            cmd.ExecuteNonQuery();
            conNew.Close();
        }



        public void InsertBundleToClientBalance(int clientid, int BundleId, string BundleOffre, double Balance, int SessionLeft)//Balance should be negative
        {
            string query = @"INSERT into  client_balance
                  (client_id,bundle_id,offre,original_offre,amount_paid,balance,Currency_Name,session_left_days,isbundle_membership,is_expired) 
                                                              VALUES 
                  (@client_id,@bundle_id,@offre,@original_offre,@amount_paid,@balance,@Currency_Name,@session_left_days,@isbundle_membership,@is_expired)";

            SqlCommand cmd = new SqlCommand(query, conNew);

            cmd.Parameters.AddWithValue("@client_id", clientid);
            cmd.Parameters.AddWithValue("@bundle_id", BundleId);
            cmd.Parameters.AddWithValue("@offre", BundleOffre);
            cmd.Parameters.AddWithValue("@original_offre", BundleOffre);
            cmd.Parameters.AddWithValue("@amount_paid", 0);
            cmd.Parameters.AddWithValue("@balance", Balance);
            cmd.Parameters.AddWithValue("@Currency_Name", Currency.CurrencyName);
            cmd.Parameters.AddWithValue("@session_left_days", SessionLeft);
            cmd.Parameters.AddWithValue("@isbundle_membership", true);
            cmd.Parameters.AddWithValue("@is_expired", false);

            conNew.Open();
            cmd.ExecuteNonQuery();
            conNew.Close();
        }
        public void InsertProducetToClientBalance(int clientid, double ProductOffre, int ProductId, double Balance)//Balance should be negative
        {
            string query = @"INSERT into  client_balance
                  (client_id,product_id,offre,original_offre,amount_paid,balance,Currency_Name,is_expired) 
                                                              VALUES 
                  (@client_id,@product_id,@offre,@original_offre,@amount_paid,@balance,@Currency_Name,@is_expired)";

            SqlCommand cmd = new SqlCommand(query, conNew);

            cmd.Parameters.AddWithValue("@client_id", clientid);
            cmd.Parameters.AddWithValue("@product_id", ProductId);
            cmd.Parameters.AddWithValue("@offre", ProductOffre);
            cmd.Parameters.AddWithValue("@original_offre", ProductOffre);
            cmd.Parameters.AddWithValue("@amount_paid", 0);
            cmd.Parameters.AddWithValue("@balance", Balance);
            cmd.Parameters.AddWithValue("@Currency_Name", Currency.CurrencyName);
            cmd.Parameters.AddWithValue("@is_expired", false);

            conNew.Open();
            cmd.ExecuteNonQuery();
            conNew.Close();
        }


    }
}
