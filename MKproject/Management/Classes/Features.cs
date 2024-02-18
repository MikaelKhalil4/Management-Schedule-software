using GlobalFunctions;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MKproject.Management
{
    public class Features
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);

        public static bool Workout { get; set; }
        public static bool Management { get; set; }
        public static bool Schedule { get; set; }
        public static bool Marketing { get; set; }
        public static bool IsOnline { get; set; }

        public enum enumFeatures
        {
            [StringValue("Edit Offres")]
            EditOffres,
            [StringValue("Transactions")]
            Transactions,
            [StringValue("BackOffice")]//yaane edit prices 
            BackOffice,
            [StringValue("Statistics")]
            Statistics,


            [StringValue("Schedule")]
            Schedule,
            [StringValue("Workout")]
            Workout,           
            [StringValue("Marketing")]
            Marketing,
            [StringValue("IsOnline")]
            IsOnline,

        }
    

        public static void GetFeatures()
        {
           
                DataTable dt = new DataTable();
            string query = "SELECT TOP 1 * FROM Features";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            Workout = Convert.ToBoolean(dt.Rows[0]["workout"]);
            Management = Convert.ToBoolean(dt.Rows[0]["management"]);
            Schedule = Convert.ToBoolean(dt.Rows[0]["schedule"]);
            Marketing = Convert.ToBoolean(dt.Rows[0]["marketing"]);
            IsOnline= Convert.ToBoolean(dt.Rows[0]["online"]);
          
        }

       
    }
}
