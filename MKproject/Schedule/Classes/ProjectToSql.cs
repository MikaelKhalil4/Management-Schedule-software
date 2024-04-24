using System;
using System.Data.SqlClient;
using System.Data;

namespace MKproject.Schedule
{
    public class ProjectToSql
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);

        //HistoryEmployeeavailibility
        public static void UpdateRank_HistoryEmployeeavailibility(DateTime history_date, int employee_id, int rank)
        { 
            SqlCommand command = new SqlCommand("UPDATE history_employee_availability SET rank= @rank WHERE CAST(history_date AS DATE) = @history_date and employee_id = @employee_id", con);

            command.Parameters.AddWithValue("@history_date", history_date.Date);
            command.Parameters.AddWithValue("@employee_id", employee_id);
            command.Parameters.AddWithValue("@rank", rank);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateAvailability_HistoryEmployeeavailibity(DateTime history_date, int employee_id, string availability)
        {
            SqlCommand command = new SqlCommand("UPDATE history_employee_availability SET availability=@availability WHERE CAST(history_date AS DATE) = @history_date and employee_id = @employee_id", con);

            command.Parameters.AddWithValue("@history_date", history_date.Date);
            command.Parameters.AddWithValue("@employee_id", employee_id);
            command.Parameters.AddWithValue("@availability", availability);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void InsertHistoryEmployeeavailibility(DateTime history_date, int employee_id, int rank, string availability)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO history_employee_availability (history_date,employee_id, rank, availability) 
                                                                  VALUES (@history_date,@employee_id,@rank,@availability) ", con);
         
            command.Parameters.AddWithValue("@history_date", history_date);
            command.Parameters.AddWithValue("@employee_id", employee_id);
            command.Parameters.AddWithValue("@rank", rank);
            command.Parameters.AddWithValue("@availability", availability);
          

            con.Open();
            command.ExecuteNonQuery();//first command
            con.Close();
        }



       

    }
}
