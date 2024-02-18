using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace MKproject.Schedule
{
    public class SQLToProjectSchedule
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);

        //Appointment
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
      

        //Appointment
        public static DataTable DisplayAppointmentsWhereCoaches(UCDay ucday, List<int> listrankcoaches_id)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.AppendLine(@"SELECT t.appointment_id , t.coach_id, c.client_id, c.name,  c.family_name,
                                      t.start_time, t.end_time, t.Note, t.onpending, t.client_type
                                      FROM appointments t
                                      JOIN client c ON t.client_id = c.client_id
                                      WHERE CAST(t.start_time AS DATE) = @value1 AND  isappointment = @isappointment ");
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
        public static DataTable DisplayAppointmentsOneCoach(UCDay ucday, int coach_id)
        {
            SqlCommand command1 = new SqlCommand(@"SELECT t.appointment_id, c.client_id, c.name,  c.family_name,
                                                   t.start_time, t.end_time, t.Note, t.onpending, t.client_type
                                                   FROM appointments t JOIN client c ON t.client_id = c.client_id 
                                                   WHERE CAST(t.start_time AS DATE) = @value1 AND isappointment = @isappointment AND t.coach_id =@coach_id", con);
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
        public static DataTable DisplayMeetingsWhereCoaches(UCDay ucday, List<int> listrankcoaches_id)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.AppendLine(@"SELECT appointment_id , coach_id, title, start_time, end_time, Note, onpending
                                      FROM appointments
                                      WHERE CAST(start_time AS DATE) = @value1 AND  isappointment = @isappointment ");
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
            command1.Parameters.AddWithValue("@isappointment", false);
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
        public static DataTable DisplayMeetingsOneCoach(UCDay ucday, int coach_id)
        {
            SqlCommand command1 = new SqlCommand(@"SELECT appointment_id , coach_id, title, start_time, end_time, Note, onpending
                                                   FROM appointments
                                                   WHERE CAST(start_time AS DATE) = @value1 AND  isappointment = @isappointment AND coach_id =@coach_id", con);
            string datetime = ucday.DateUCDay.ToString();
            string[] date = datetime.Split(' ');
            command1.Parameters.AddWithValue("@value1", date[0]);
            command1.Parameters.AddWithValue("@coach_id", coach_id);
            command1.Parameters.AddWithValue("@isappointment", false);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;

        }


        //coach
        public static string DisplayCoachName(int coach_id)
        {
            string coachName = string.Empty;
            SqlCommand command1 = new SqlCommand(@"SELECT name , family_name 
                                                   FROM coach
                                                   WHERE coach_id = @coach_id;", con);
            command1.Parameters.AddWithValue("@coach_id", coach_id);
            con.Open();
            using (SqlDataReader reader = command1.ExecuteReader())
            {
                if (reader.Read())
                {
                    string firstName = reader["name"].ToString();
                    string lastName = reader["family_name"].ToString();

                    coachName = $"{firstName} {lastName}";
                }
            }
            con.Close();
            return coachName;

        }

        //CoachAvailability
        public static DataTable DisplayCoachAvailabilityASC()
        {
            string query = "SELECT a.availability_id, a.coach_id, c.name, c.family_name, a.availability, a.rank, a.is_checked " +
                           "FROM coach_availability a " +
                           "JOIN coach c ON a.coach_id = c.coach_id " +
                           "WHERE a.is_active = @is_active " +
                           "ORDER BY a.rank ASC";

            // Create and configure the SqlCommand
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@is_active", true);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                // Fill the DataTable with the results of the query
                adapter.Fill(dt);

                // If you want to execute the query without returning the DataTable, you can use cmd.ExecuteNonQuery()

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                return dt;
            }
        }

        //HistoryCoachavailibility
        public static DataTable DisplayRankCoachesNAvailability(DateTime history_date)
        {
            SqlCommand command = new SqlCommand("SELECT  rank_coaches, availability_coaches FROM history_coach_availability WHERE CAST(history_date AS DATE) = @history_date", con);
            command.Parameters.AddWithValue("@history_date", history_date.Date);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            return dt;
        }
        public static bool DataExistsForToday(DateTime dateToCheck)
        {
            int count;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM history_coach_availability WHERE CAST(history_date AS DATE) = @history_date", con);
            cmd.Parameters.AddWithValue("@history_date", dateToCheck.Date);
            con.Open();
            object result = cmd.ExecuteScalar();//return the first cell
            int.TryParse(result.ToString(), out count);//we got the idtime second command
            con.Close();

            return count > 0;
        }


        //Reminder
        public static DataTable DisplayReminder()
        {
            SqlCommand command1 = new SqlCommand(@"SELECT reminder.*, client.name, client.family_name
                                                   FROM reminder
                                                   LEFT JOIN client ON reminder.client_id = client.client_id", con);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["reminder_id"] };
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;
        }
        public static DataTable DisplayReminderByClientName(int? client_id)
        {
            SqlCommand command1 = new SqlCommand(@"SELECT reminder_id, reminder, repeat, starttime, labelquote, is_checked
                                                   FROM reminder
                                                   WHERE client_id = @client_id", con);
            command1.Parameters.AddWithValue("@client_id", client_id);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["reminder_id"] };
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;
        }


        //client
        public static DataTable DisplayDataGidViewSearchName()
        {
            SqlCommand cmd = new SqlCommand("SELECT client_id,name, family_name, phone_number,Registration_Date,check_in FROM client", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            adapter.Fill(dt);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return dt;
        }
    }
}
