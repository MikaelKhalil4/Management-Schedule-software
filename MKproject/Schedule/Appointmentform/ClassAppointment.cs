using MKproject.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKproject.Schedule
{
    public class ClassAppointment
    {
        //Property
        public int IdAppointment { get; set; }
        public int IdCoach { get; set; }
        public ClassClient DesiredClient { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Notes { get; set; }
        public bool OnPending { get; set; }


        //SQL
        static SqlConnection con = new SqlConnection(Program.DataLocation);

        //zid title
        public static List<int> DisplayCoachesIdWhoTrained(UCDay ucday, List<int> listrankcoaches_id)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("SELECT DISTINCT coach_id FROM appointments WHERE CAST(start_time AS DATE) = @value1 ");
            if (listrankcoaches_id.Count > 0)
            {
                queryBuilder.AppendLine("AND coach_id IN (");

                for (int i = 0; i < listrankcoaches_id.Count; i++)
                {
                    queryBuilder.Append($"@coachId{i}");
                    if (i < listrankcoaches_id.Count - 1)
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
            for (int i = 0; i < listrankcoaches_id.Count; i++)
            {
                command1.Parameters.AddWithValue($"@coachId{i}", listrankcoaches_id[i]);
            }
            con.Open();

            // Execute the second query to get the list of coach IDs
            List<int> coachIdsWithAppointments = new List<int>();
            using (SqlDataReader reader = command1.ExecuteReader())
            {
                while (reader.Read())
                {
                    coachIdsWithAppointments.Add(reader.GetInt32(0));
                }
            }

            con.Close();
            return coachIdsWithAppointments;
        }

        //zid title
        public static DataTable DisplayAppointmentsWhereCoaches(UCDay ucday, List<int> listrankcoaches_id)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.AppendLine(@"SELECT t.appointment_id , t.coach_id, c.client_id, c.name,  c.family_name,
                                      t.start_time, t.end_time, t.Note, t.onpending, t.client_type
                                      FROM appointments t
                                      JOIN client c ON t.client_id = c.client_id
                                      WHERE CAST(t.start_time AS DATE) = @value1");
            if (listrankcoaches_id.Count > 0)
            {
                queryBuilder.AppendLine("AND t.coach_id IN (");

                for (int i = 0; i < listrankcoaches_id.Count; i++)
                {
                    queryBuilder.Append($"@coachId{i}");
                    if (i < listrankcoaches_id.Count - 1)
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
            command1.Parameters.AddWithValue("@isappointment", true);
            for (int i = 0; i < listrankcoaches_id.Count; i++)
            {
                command1.Parameters.AddWithValue($"@coachId{i}", listrankcoaches_id[i]);
            }
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;
        }

        //zid title
        public static DataTable DisplayAppointmentsOneCoach(UCDay ucday, int coach_id)
        {
            SqlCommand command1 = new SqlCommand(@"SELECT t.appointment_id, c.client_id, c.name,  c.family_name,
                                                   t.start_time, t.end_time, t.Note, t.onpending, t.client_type
                                                   FROM appointments t JOIN client c ON t.client_id = c.client_id 
                                                   WHERE CAST(t.start_time AS DATE) = @value1  AND t.coach_id =@coach_id", con);
            string datetime = ucday.DateUCDay.ToString();
            string[] date = datetime.Split(' ');
            command1.Parameters.AddWithValue("@value1", date[0]);
            command1.Parameters.AddWithValue("@coach_id", coach_id);
            command1.Parameters.AddWithValue("@isappointment", true);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;

        }

        //if
        public int AddFromAppoitementtoSQL()//na2is ClientType
        {
            int idappointment;
            SqlCommand command = new SqlCommand(@"INSERT INTO appointments (coach_id,client_id,start_time,end_time,Note,onpending,client_type) 
                                                                  VALUES (@coach_id,@client_id,@start_time, @end_time, @Note, @onpending, @client_type) ", con);
            SqlCommand cmd = new SqlCommand("SELECT Max(appointment_id) FROM appointments", con);
            //string[] parts = fullname.Split(' ');

            command.Parameters.AddWithValue("@coach_id", IdCoach);
            if (DesiredClient != null && Title == null)
            {
                command.Parameters.AddWithValue("@client_id", DesiredClient.ClientId);
            }
            else
            {
                command.Parameters.AddWithValue("@client_id", DBNull.Value);
            }
            command.Parameters.AddWithValue("@start_time", StartTime);
            command.Parameters.AddWithValue("@end_time", EndTime);
            command.Parameters.AddWithValue("@Note", Notes);
            command.Parameters.AddWithValue("@onpending", OnPending);
            command.Parameters.AddWithValue("@client_type", DBNull.Value);

            command.Parameters.AddWithValue("@isappointment", true);


            con.Open();
            command.ExecuteNonQuery();//first command
            object result = cmd.ExecuteScalar();//return the first cell
            int.TryParse(result.ToString(), out idappointment);//we got the idtime second command
            con.Close();

            return idappointment;

        }
        //if
        public void UpdateFromAppoitementtoSQL()
        {
            SqlCommand command = new SqlCommand(@"UPDATE appointments
                                                  SET client_id=@client_id, start_time=@start_time, end_time=@end_time, Note=@Note, onpending=@onpending,client_type=@client_type
                                                  WHERE appointment_id =@appointment_id", con);


            command.Parameters.AddWithValue("@client_id", DesiredClient.ClientId);
            command.Parameters.AddWithValue("@start_time", StartTime);
            command.Parameters.AddWithValue("@end_time", EndTime);
            command.Parameters.AddWithValue("@Note", Notes);
            command.Parameters.AddWithValue("@onpending", OnPending);
            command.Parameters.AddWithValue("@client_type", DBNull.Value);
            command.Parameters.AddWithValue("@appointment_id", IdAppointment);


            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteAppointment()
        {
            SqlCommand command = new SqlCommand("DELETE FROM appointments WHERE appointment_id = @value1 ", con);
            command.Parameters.AddWithValue("@value1", IdAppointment);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateAppointmentCheck()
        {
            SqlCommand command = new SqlCommand(@"UPDATE appointments
                                                  SET onpending=@onpending
                                                  WHERE appointment_id =@appointment_id", con);
            command.Parameters.AddWithValue("@onpending", OnPending);
            command.Parameters.AddWithValue("@appointment_id", IdAppointment);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }



    }
}
