using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace MKproject.Management
{
    internal class SQLToProject
    {
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);



        //client_struct

        public static DateTime GetAttendanceDateOfSpecificAttendace(int AttendanceId)
        {
            string query = "SELECT execute_date from client_services_attendance WHERE  attendance_id='" + AttendanceId + "' ";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            DateTime ExecutedDate = Convert.ToDateTime(cmd.ExecuteScalar());//couldnt be null
            con.Close();
            return ExecutedDate;
        }
        public static DateTime GetMaxAttendanceDateOfClient(int ClientId)
        {

            string query = "SELECT MAX(execute_date) from client_services_attendance where client_id='" + ClientId + "'";


            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            con.Open();
            DateTime ExecutedDate = Convert.ToDateTime(cmd.ExecuteScalar());//couldnt be null
            con.Close();
            return ExecutedDate;
        }
        public static DataTable GetAttendanceDate()
        {

            string query = "SELECT execute_date from client_services_attendance  ";
       

            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static int GetLAstInsertedAttendance()
        {
            int Id;
            con.Open();
            string getLastIdQuery = "SELECT Max(attendance_id) FROM client_services_attendance";
            using (SQLiteCommand command = new SQLiteCommand(getLastIdQuery, con))
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
            SQLiteCommand command = new SQLiteCommand(query, con);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            con.Close();          
            adapter.Fill(dt);
            return dt;
        }

        //required_visible_fields     
        public static DataTable GetAllVisibleFields()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM required_visible_fields";//la2n ma badna n3adil 3l full name w el phone number
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable GetChildParentVisibleFields()
        {

            DataTable dt = new DataTable();
            string query = "SELECT * FROM required_visible_fields WHERE Fields IN ('FullName','PhoneNumber','Adress')";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }

        //Albums
        public static DataTable GetAlbums()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Albums order by Album_id DESC";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
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
            SQLiteCommand command = new SQLiteCommand(query, con);
            command.Parameters.AddWithValue("@AlbumName", albumName);
            con.Open();
            count = Convert.ToInt32(command.ExecuteScalar());
            con.Close();
            return count > 0;
        }



        //finance
        public static DataTable GetIncome()
        {
            string query = @"SELECT f.finance_id,f.client_balance_id,f.amount_paid,f.payment_date,cb.bundle_id,cb.bundle_id,cb.product_id
                                from finance f,client c,client_balance cb 
                               WHERE f.client_balance_id=cb.client_balance_id AND cb.client_id=c.client_id";

            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }




    }
}
