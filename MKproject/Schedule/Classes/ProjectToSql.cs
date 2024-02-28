using System;
using System.Data.SqlClient;
using System.Data;

namespace MKproject.Schedule
{
    public class ProjectToSql
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);

        //HistoryCoachavailibility
        public static void UpdateHistoryCoachavailibility(DateTime history_date, string rank_coaches, string availability_coaches)
        {
            SqlCommand command = new SqlCommand("UPDATE history_coach_availability SET rank_coaches=@rank_coaches, availability_coaches=@availability_coaches WHERE history_date =@history_date", con);

            command.Parameters.AddWithValue("@history_date", history_date);
            command.Parameters.AddWithValue("@rank_coaches", rank_coaches);
            command.Parameters.AddWithValue("@availability_coaches", availability_coaches);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void InsertHistoryCoachavailibility(DateTime history_date, string rank_coaches, string availability_coaches)
        {

           
            SqlCommand command = new SqlCommand(@"INSERT INTO history_coach_availability (history_date, rank_coaches, availability_coaches) 
                                                                  VALUES (@history_date,@rank_coaches,@availability_coaches) ", con);
         
            command.Parameters.AddWithValue("@history_date", history_date);
            command.Parameters.AddWithValue("@rank_coaches", rank_coaches);
            command.Parameters.AddWithValue("@availability_coaches", availability_coaches);
          

            con.Open();
            command.ExecuteNonQuery();//first command
            con.Close();
        }



        //CoachAvailability
        public static void UpdateCoachAvailabilitySQL(int Availability_id,string Availability)
        {
            SqlCommand command = new SqlCommand("UPDATE coach_availability SET availability=@availability  WHERE availability_id = @availability_id", con);
            command.Parameters.AddWithValue("@availability", Availability);
            command.Parameters.AddWithValue("@availability_id", Availability_id);

           
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateRankNIsCheckedCoachAvailabilitySQL(DataTable DataTableCoachavailability)
        {
            foreach (DataRow row in DataTableCoachavailability.Rows)
            {
                int availabilityId = Convert.ToInt32(row["availability_id"]); // Assuming column name is 'availablity_id'
                int newRank = Convert.ToInt32(row["rank"]); // Replace 'new_rank' with your new rank column name
                bool isChecked = Convert.ToBoolean(row["is_checked"]); // Replace 'is_checked' with your is checked column name

                // Construct the SQL query for updating
                string updateQuery = "UPDATE coach_availability SET rank = @rank, is_checked = @is_checked WHERE availability_id = @availability_id";

                // Create and configure the SqlCommand
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@availability_id", availabilityId);
                    cmd.Parameters.AddWithValue("@rank", newRank);
                    cmd.Parameters.AddWithValue("@is_checked", isChecked);

                    // Open the connection and execute the command
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

    }
}
