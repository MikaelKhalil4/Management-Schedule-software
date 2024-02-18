using System;
using System.Data.SqlClient;
using System.Data;


namespace MKproject.Management
{
    public class ClassBundles
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);
        public static string Session = "sess", Days = "days";//only strings kermel el transaction
        public enum Category
        {
            Package = 0,
            Product = 1,

        }
        public enum bundle
        {
            Days,
            Sessions,
            Solo
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? SessionDaysNumber { get; set; }//null if solo

        public bundle EnumBundletype { get; set; }//2:solo 1:sessions 0: days

        public string Bundletype { get; set; }

        public Double Price { get; set; }

        public bool IsMemberShip { get; set; }

        public int Qty { get; set; }//only used lamma badde eshtere item 
        public bool Status { get; set; }

        public ClassBundles()
        {

        }


        public static (double, int?, bool) FindBundleDetails(int BundleId)
        {

            string query = "Select price,sessions_numb,is_member_ship From bundles where bundle_id='" + BundleId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int? SessionNumbre = dt.Rows[0]["sessions_numb"] is DBNull ? (int?)null : (int)dt.Rows[0]["sessions_numb"];
            // Return the results as a tuple
            return ((double)dt.Rows[0]["price"], SessionNumbre, (bool)dt.Rows[0]["is_member_ship"]);
        }
        public static string FindBundleName(int categoryId)
        {

            string query = "Select bundle_name From bundles where bundle_id='" + categoryId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // Return the results as a tuple
            return (dt.Rows[0]["bundle_name"].ToString());
        }
        public static bool FindBundleIfMembership(int categoryId)
        {

            string query = "Select is_member_ship From bundles where bundle_id='" + categoryId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // Return the results as a tuple

            return ((Boolean)dt.Rows[0]["is_member_ship"]);
        }

        public static DataTable GetLastInsertBundle()
        {
            string Query = "Select * from bundles where  bundle_id=(Select MAX(bundle_id) from bundles)";
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable RetrieveAllBundleStatusOn()
        {
            string query = "Select * From bundles where status=1 ORDER by bundle_id Desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public static DataTable RetrieveAllBundle()
        {
            string query = "Select * From bundles ORDER by status Desc, bundle_id Desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }



        public void InsertBundle()
        {
            string query = "INSERT INTO bundles (bundle_name, description, sessions_numb,bundle_type ,price, status,is_member_ship,Currency_Name) " +
                           "VALUES (@bundle_name, @description, @SessionsNumb,@bundle_type, @Price, @Status,@is_member_ship,@Currency_Name)";

            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@bundle_name", Name);
            if (Description == null)
            {
                command.Parameters.AddWithValue("@description", DBNull.Value);

            }
            else
            {
                command.Parameters.AddWithValue("@description", Description);
            }

            if (SessionDaysNumber == null)
            {
                command.Parameters.AddWithValue("@SessionsNumb", DBNull.Value);

            }
            else
            {
                command.Parameters.AddWithValue("@SessionsNumb", SessionDaysNumber);
            }
            command.Parameters.AddWithValue("@bundle_type", Bundletype);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Status", 1);
            command.Parameters.AddWithValue("@is_member_ship", IsMemberShip);
            command.Parameters.AddWithValue("@Currency_Name", Currency.CurrencyName);
            con.Open();

            command.ExecuteNonQuery();

            con.Close();
        }
        public void UpdateBundle()
        {
            string query = @"UPDATE bundles 
                           SET bundle_name = @bundle_name, 
                           description = @description,
                           sessions_numb = @SessionsNumb, 
                           bundle_type=@bundle_type,
                           price = @Price, 
                           status = @Status,
                           is_member_ship=@is_member_ship
                           WHERE bundle_id = @bundle_id";

            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@bundle_name", Name);
            if (Description == null)
            {
                command.Parameters.AddWithValue("@description", DBNull.Value);

            }
            else
            {
                command.Parameters.AddWithValue("@description", Description);
            }

            if (SessionDaysNumber == null)
            {
                command.Parameters.AddWithValue("@SessionsNumb", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@SessionsNumb", SessionDaysNumber);
            }
            command.Parameters.AddWithValue("@bundle_type", Bundletype);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@bundle_id", ID);
            command.Parameters.AddWithValue("@is_member_ship", IsMemberShip);
            con.Open();

            command.ExecuteNonQuery();

            con.Close();
        }
        public void DeleteBundle()
        {

            SqlCommand cmd = new SqlCommand("Delete bundles where bundle_id='" + ID + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }
        public bool CheckIBundletHasReferences()
        {
            string query = @"Select Count(*) from bundles as p
                         where bundle_id='" + ID + "' And  Exists ( Select * from client_balance as c where c.bundle_id=p.bundle_id)";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
