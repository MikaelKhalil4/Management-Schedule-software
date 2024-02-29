using GlobalFunctions;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MKproject.Management
{
    public class Features
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);

        public static bool Management { get; set; }
        public static bool Schedule { get; set; }
        public static bool IsOnline { get; set; }

        public enum enumFeatures
        {
            [StringValue("Insert Or Edit Clients")]
            EditClients,
            [StringValue("Delete Clients")]
            DeleteClients,
            [StringValue("Edit Registration Fields")]
            RegistrationFields,
            [StringValue("Edit Offres")]
            EditOffres,
            [StringValue("Transactions")]//yaane el backoffice
            Transactions,
            [StringValue("Edit Services and Products and Employees")]
            ServicesProductsEmployees,
            [StringValue("Statistics")]
            Statistics,

            [StringValue("Schedule")]
            Schedule,
          

        }
    

        public static void GetFeatures()
        {
           
                DataTable dt = new DataTable();
            string query = "SELECT TOP 1 * FROM Features";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            Management = Convert.ToBoolean(dt.Rows[0]["management"]);
            Schedule = Convert.ToBoolean(dt.Rows[0]["schedule"]);
            IsOnline= Convert.ToBoolean(dt.Rows[0]["online"]);
          
        }

       
    }
}
