using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace MKproject.Management
{
    internal class SQLToProject
    {



        //client_struct

        public static DateTime GetAttendanceDateOfSpecificAttendace(int AttendanceId)
        {
            string query = "SELECT execute_date from client_services_attendance WHERE  attendance_id='" + AttendanceId + "' ";
            var cmd = Program.CreateCommand(query);
            Program.conOpen();
            DateTime ExecutedDate = Convert.ToDateTime(cmd.ExecuteScalar());//couldnt be null
            Program.con.Close();
            return ExecutedDate;
        }
        public static DateTime GetMaxAttendanceDateOfClient(int ClientId)
        {

            string query = "SELECT MAX(execute_date) from client_services_attendance where client_id='" + ClientId + "'";


            var cmd = Program.CreateCommand(query);
            var sda = Program.CreateDataAdapter(cmd);
            Program.conOpen();
            DateTime ExecutedDate = Convert.ToDateTime(cmd.ExecuteScalar());//couldnt be null
            Program.con.Close();
            return ExecutedDate;
        }
        public static DataTable GetAttendanceDate()
        {

            string query = "SELECT execute_date from client_services_attendance  ";


            var cmd = Program.CreateCommand(query);
            var sda = Program.CreateDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static int GetLAstInsertedAttendance()
        {
            int Id;
            Program.conOpen();
            string getLastIdQuery = "SELECT Max(attendance_id) FROM client_services_attendance";
            using (var command = Program.CreateCommand(getLastIdQuery))
            {
                Id = Convert.ToInt32(command.ExecuteScalar());
            }
            Program.con.Close();
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
                query += " And cs.client_id='" + ClientId + "'";
            }


            Program.conOpen();
            var command = Program.CreateCommand(query );
            var adapter = Program.CreateDataAdapter(command);
            Program.con.Close();
            adapter.Fill(dt);
            return dt;
        }

        //required_visible_fields     
        public static DataTable GetAllVisibleFields()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM required_visible_fields";//la2n ma badna n3adil 3l full name w el phone number
            var cmd = Program.CreateCommand(query);
            var sda = Program.CreateDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable GetChildParentVisibleFields()
        {

            DataTable dt = new DataTable();
            string query = "SELECT * FROM required_visible_fields WHERE Fields IN ('FullName','PhoneNumber','Adress')";
            var cmd = Program.CreateCommand(query);
            var sda = Program.CreateDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }
        public static int GetFieldIdByEnumName(string enumName)
        {
            string query = "SELECT fields_id FROM required_visible_fields WHERE Fields = @enumName";
            var command = Program.CreateCommand(query);
            command.AddWithValue("@enumName", enumName);
            Program.conOpen();
            object result = command.ExecuteScalar();
            Program.con.Close();
            return Convert.ToInt32(result);
        }
        public static bool GetFieldContentOfSpecificCleint(int clientId, int fieldId)
        {
            string query = "SELECT COUNT(*) FROM client_fields WHERE client_id = @clientId AND fields_id = @fieldId";
            var command = Program.CreateCommand(query);
            command.AddWithValue("@clientId", clientId);
            command.AddWithValue("@fieldId", fieldId);
            Program.conOpen();
            int count = Convert.ToInt32(command.ExecuteScalar());
            Program.con.Close();
            return count > 0;

        }


        //Albums
        public static DataTable GetAlbums()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Albums order by Album_id DESC";
            var cmd = Program.CreateCommand(query);
            var sda = Program.CreateDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }

        public static bool IsAlbumAlreadyExists(string albumName, string oldname)//oldname exist only in case of update mode
        {
            int count;
            string query;
            query = "SELECT COUNT(*) FROM Albums WHERE AlbumType = @AlbumName";
            if (oldname != null)
            {
                query += " And AlbumType !='" + oldname + "'";
            }
            var command = Program.CreateCommand(query);
            command.AddWithValue("@AlbumName", albumName);
            Program.conOpen();
            count = Convert.ToInt32(command.ExecuteScalar());
            Program.con.Close();
            return count > 0;
        }



        //finance
        public static DataTable GetIncome()
        {
            string query = @"SELECT f.finance_id,f.client_balance_id,f.amount_paid,f.payment_date,cb.bundle_id,cb.product_id
                                from finance f,client c,client_balance cb 
                               WHERE f.client_balance_id=cb.client_balance_id AND cb.client_id=c.client_id";

            var cmd = Program.CreateCommand(query);
            var sda = Program.CreateDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }




    }
}
