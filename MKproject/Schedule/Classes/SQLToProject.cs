using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace MKproject.Schedule
{
    public class SQLToProject
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);

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
