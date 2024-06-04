using System;
using System.Data.SqlClient;
using System.Data;
using Azure.Core;
using System.Globalization;
using MKproject.Schedule;
using System.Data.SQLite;

namespace MKproject.Management
{
    public class ClassBundles
    {
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);
        public static string Session = "sess", Days = "days";//only strings kermel el transaction
        public enum Category
        {
            Package = 0,
            Product = 1,

        }
        public enum enumBundle
        {
            Days,
            Sessions,
            Solo
        }

        public int BundleID { get; set; }

        private string bundleName;

        public string BundleName
        {
            get { return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(bundleName.ToLower()); }
            set { bundleName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()); }
        }

        public string Description { get; set; }

        public int? SessionDaysNumber { get; set; }//null if solo

        public enumBundle EnumBundletype { get; set; }//2:solo 1:sessions 0: days

        public Double Price { get; set; }

        public bool IsMemberShip { get; set; }

        public bool Status { get; set; }
        public string CurrencyName { get; set; }


        public int Qty { get; set; }//only used lamma badde eshtere item 

        public ClassBundles()
        {

        }


        public static (double, int?, bool) FindBundleDetails(int BundleId)
        {

            string query = "Select price,sessions_numb,is_member_ship From bundles where bundle_id='" + BundleId + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int? SessionNumbre = dt.Rows[0]["sessions_numb"] is DBNull ? (int?)null : Convert.ToInt32(dt.Rows[0]["sessions_numb"]);
            // Return the results as a tuple
            return (Convert.ToDouble(dt.Rows[0]["price"]), SessionNumbre, Convert.ToBoolean(dt.Rows[0]["is_member_ship"]));
        }
        public static string FindBundleName(int categoryId)
        {

            string query = "Select bundle_name From bundles where bundle_id='" + categoryId + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // Return the results as a tuple
            return (dt.Rows[0]["bundle_name"].ToString());
        }

        public static DataTable GetLastInsertBundle()
        {
            string Query = "Select * from bundles where  bundle_id=(Select MAX(bundle_id) from bundles)";
            SQLiteCommand cmd = new SQLiteCommand(Query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable RetrieveAllBundleStatusOn(bool IsOnlySolo)
        {
            string query = "Select * From bundles where status=1 ";
            if (IsOnlySolo)
            {
                query += " AND bundle_type='"+ClassBundles.enumBundle.Solo+"' ";
            }
            query += " ORDER by bundle_id Desc ";

            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }    
        public static DataTable RetrieveAllBundle(int? bundleId)
        {
            string query = "Select * From bundles ";
            if (bundleId != null)
            {
                query += " Where bundle_id= '"+ bundleId + "' ";
            }
            query += " ORDER by status Desc, bundle_id Desc ";

            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }



        public void InsertBundle()
        {
            string query = "INSERT INTO bundles (bundle_name, description, sessions_numb,bundle_type ,price, status,is_member_ship,Currency_Name) " +
                           "VALUES (@bundle_name, @description, @SessionsNumb,@bundle_type, @Price, @Status,@is_member_ship,@Currency_Name)";

            SQLiteCommand command = new SQLiteCommand(query, con);
            command.Parameters.AddWithValue("@bundle_name", BundleName);
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
            command.Parameters.AddWithValue("@bundle_type", EnumBundletype.ToString());
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Status", Status);
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

            SQLiteCommand command = new SQLiteCommand(query, con);
            command.Parameters.AddWithValue("@bundle_name", BundleName);
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
            command.Parameters.AddWithValue("@bundle_type", EnumBundletype.ToString());
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@bundle_id", BundleID);
            command.Parameters.AddWithValue("@is_member_ship", IsMemberShip);
            con.Open();

            command.ExecuteNonQuery();

            con.Close();
        }
        public void DeleteBundle()
        {

            SQLiteCommand cmd = new SQLiteCommand("Delete FROM  bundles where bundle_id='" + BundleID + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }
        public bool CheckIBundletHasReferences()
        {
            string query = @"Select Count(*) from bundles as p
                         where bundle_id='" + BundleID + "' And  Exists ( Select * from client_balance as c where c.bundle_id=p.bundle_id)";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
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

        public static ClassBundles CreateBundleObject(int BundleId)
        {
            DataTable dt;
            dt = RetrieveAllBundle(BundleId);
            DataRow dataRow = dt.Rows[0];//since we re expecting one row of return


            ClassBundles bundle = new ClassBundles();

            bundle.BundleID = Convert.ToInt32(dataRow["bundle_id"]);
            bundle.BundleName =(string)dataRow["bundle_name"];
            bundle.Description = dataRow["description"] is DBNull ? null : (string)dataRow["description"];
            bundle.SessionDaysNumber = dataRow["sessions_numb"] is DBNull ? null : Convert.ToInt32(dataRow["sessions_numb"]);
            bundle.EnumBundletype = (ClassBundles.enumBundle)Enum.Parse(typeof(ClassBundles.enumBundle), (string)dataRow["bundle_type"]);
            bundle.Price = Convert.ToDouble(dataRow["price"]);
            bundle.IsMemberShip = Convert.ToBoolean(dataRow["is_member_ship"]);
            bundle.Status = Convert.ToBoolean(dataRow["status"]);
            bundle.CurrencyName = dataRow["Currency_Name"] is DBNull ? null : (string)dataRow["Currency_Name"];


            return bundle;
        }

        public ClassBundles Copy()//This Copy wont work fi Property eza fi  reference-type Properties (classes or list)/ eenda it s own methode, check ClassAppointment
        {
            return (ClassBundles)this.MemberwiseClone();
        }
    }
}
