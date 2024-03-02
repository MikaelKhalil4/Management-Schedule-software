using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKproject.Schedule.Appointmentform
{
    public class ClassAppOthers: ClassAppointment
    {

        //SQL
        static SqlConnection con = new SqlConnection(Program.DataLocation);

        public static DataTable DisplayMeetingsWhereEmployees(UCDay ucday, List<int> listrankemployees_id)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.AppendLine(@"SELECT appointment_id , employee_id, title, start_time, end_time, Note, onpending
                                      FROM appointments
                                      WHERE CAST(start_time AS DATE) = @value1 AND  isappointment = @isappointment ");
            if (listrankemployees_id.Count > 0)
            {
                queryBuilder.AppendLine("AND employee_id IN (");

                for (int i = 0; i < listrankemployees_id.Count; i++)
                {
                    queryBuilder.Append($"@employee_id{i}");
                    if (i < listrankemployees_id.Count - 1)
                    {
                        queryBuilder.Append(", ");
                    }
                }

                queryBuilder.AppendLine(")");
            }
            SqlCommand command1 = new SqlCommand(queryBuilder.ToString(), con);
            string datetime = ucday.DateUCDay.ToString();
            string[] date = datetime.Split(' ');
            command1.Parameters.AddWithValue("@value1", date[0]);
            command1.Parameters.AddWithValue("@isappointment", false);
            for (int i = 0; i < listrankemployees_id.Count; i++)
            {
                command1.Parameters.AddWithValue($"@employee_id{i}", listrankemployees_id[i]);
            }
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;
        }
        public static DataTable DisplayMeetingsOneEmployee(UCDay ucday, int employee_id)
        {
            SqlCommand command1 = new SqlCommand(@"SELECT appointment_id , employee_id, title, start_time, end_time, Note, onpending
                                                   FROM appointments
                                                   WHERE CAST(start_time AS DATE) = @value1 AND  isappointment = @isappointment AND employee_id =@employee_id", con);
            string datetime = ucday.DateUCDay.ToString();
            string[] date = datetime.Split(' ');
            command1.Parameters.AddWithValue("@value1", date[0]);
            command1.Parameters.AddWithValue("@employee_id", employee_id);
            command1.Parameters.AddWithValue("@isappointment", false);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;

        }



        public static int AddFromMeetingtoSQL(int idemployee, string title, DateTime starttime, DateTime endtime, string Note, bool onpending)
        {
            int idmeeting;
            SqlCommand command = new SqlCommand(@"INSERT INTO appointments(employee_id,title,start_time,end_time,Note,onpending,isappointment) 
                                                                  VALUES (@employee_id,@title,@start_time, @end_time, @Note, @onpending, @isappointment) ", con);
            SqlCommand cmd = new SqlCommand("SELECT Max(appointment_id) FROM appointments", con);


            command.Parameters.AddWithValue("@employee_id", idemployee);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@start_time", starttime);
            command.Parameters.AddWithValue("@end_time", endtime);
            command.Parameters.AddWithValue("@Note", Note);
            command.Parameters.AddWithValue("@onpending", onpending);
            command.Parameters.AddWithValue("@isappointment", false);


            con.Open();
            command.ExecuteNonQuery();//first command
            object result = cmd.ExecuteScalar();//return the first cell
            int.TryParse(result.ToString(), out idmeeting);//we got the idtime second command
            con.Close();

            return idmeeting;

        }
        public static void UpdateFromMeetingtoSQL(int idmeeting, string title, DateTime starttime, DateTime endtime, string note, bool onpending)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Appointment
                                                  SET title=@title, start_time=@start_time, end_time=@end_time, Note=@Note, onpending=@onpending
                                                  WHERE appointment_id =@appointment_id", con);

            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@start_time", starttime);
            command.Parameters.AddWithValue("@end_time", endtime);
            command.Parameters.AddWithValue("@Note", note);
            command.Parameters.AddWithValue("@onpending", onpending);
            command.Parameters.AddWithValue("@appointment_id", idmeeting);


            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void DeleteMeeting(int idmeeting)
        {
            SqlCommand command = new SqlCommand("DELETE FROM appointments WHERE appointment_id = @value1 ", con);
            command.Parameters.AddWithValue("@value1", idmeeting);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateMeetingCheck(int idmeeting, bool onpending)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Appointment
                                                  SET onpending=@onpending
                                                  WHERE appointment_id =@appointment_id", con);
            command.Parameters.AddWithValue("@onpending", onpending);
            command.Parameters.AddWithValue("@appointment_id", idmeeting);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
