using System;
using System.Data;
using System.Data.SqlClient;

namespace MKproject.Management
{
    internal class SQLToProject
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);

      

        //client_balance



        //client_struct
        public static DataTable GetAttendance()
        {

            string query = "SELECT execute_date from client_services_attendance  ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static int GetLAstInsertedAttendance()
        {
            int Id;
            con.Open();
            string getLastIdQuery = "SELECT Max(attendance_id) FROM client_services_attendance";
            using (SqlCommand command = new SqlCommand(getLastIdQuery, con))
            {
                Id = Convert.ToInt32(command.ExecuteScalar());
            }
            con.Close();
            return Id;
        }
        public static DataTable GetAllClientAttendance(int? ClientId)
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT cs.client_id,cs.execute_date      
            FROM client_services_attendance cs,client c
            WHERE cs.client_id = c.client_id  AND execute_date IS NOT NULL ";
           if (ClientId != null)
            {
                query+= " And cs.client_id='" + ClientId + "'";
            }
           

            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            con.Close();          
            adapter.Fill(dt);
            return dt;
        }

        //required_visible_fields     
        public static DataTable GetAllVisibleFields()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM required_visible_fields ORDER BY design_index ASC";//la2n ma badna n3adil 3l full name w el phone number
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable GetChildParentVisibleFields()
        {

            DataTable dt = new DataTable();
            string query = "SELECT * FROM required_visible_fields WHERE Fields IN ('FullName','PhoneNumber','Adress')";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }

        //Albums
        public static DataTable GetAlbums()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Albums order by Album_id DESC";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }

        public static bool IsAlbumAlreadyExists(string albumName,string oldname)//oldname exist only in case of update mode
        {
            int count;
            string query;
            query= "SELECT COUNT(*) FROM Albums WHERE AlbumType = @AlbumName";
            if (oldname != null)
            {
                query+= " And AlbumType !='"+ oldname + "'";
            }
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@AlbumName", albumName);
            con.Open();
            count = (int)command.ExecuteScalar();
            con.Close();
            return count > 0;
        }



        //finance
        public static DataTable GetIncome()
        {
            string query = @"SELECT f.finance_id,f.client_balance_id,f.amount_paid,f.payment_date,cb.bundle_id,cb.bundle_id,cb.product_id
                                from finance f,client c,client_balance cb 
                               WHERE f.client_balance_id=cb.client_balance_id AND cb.client_id=c.client_id";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }




    }
}
