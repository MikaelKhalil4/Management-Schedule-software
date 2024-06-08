using System;
using System.Data.SqlClient;
using System.Data;
using System.Data.SQLite;

namespace MKproject.Schedule
{
    public class ProjectToSql
    {
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);

        //HistoryEmployeeavailibility
        public static void UpdateRank_HistoryEmployeeavailibility(DateTime history_date, int employee_id, int rank,string availability)
        {
            SQLiteCommand command = new SQLiteCommand("UPDATE history_employee_availability SET rank= @rank,availability=@availability WHERE history_date = @history_date and employee_id = @employee_id", con);

            command.Parameters.AddWithValue("@history_date", history_date.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@employee_id", employee_id);
            command.Parameters.AddWithValue("@rank", rank);
            command.Parameters.AddWithValue("@availability", availability);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }    
        public static void InsertHistoryEmployeeavailibility(DateTime history_date, int employee_id, int rank, string availability)
        {
            SQLiteCommand command = new SQLiteCommand(@"INSERT INTO history_employee_availability (history_date,employee_id, rank, availability) 
                                                                  VALUES (@history_date,@employee_id,@rank,@availability) ", con);

            command.Parameters.AddWithValue("@history_date", history_date.Date.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@employee_id", employee_id);
            command.Parameters.AddWithValue("@rank", rank);
            if (!String.IsNullOrEmpty(availability))
            {
                command.Parameters.AddWithValue("@availability", availability);
            }
            else
            {
                command.Parameters.AddWithValue("@availability", DBNull.Value);
            }

            con.Open();
            command.ExecuteNonQuery();//first command
            con.Close();
        }
        public static void DeleteHistoryEmployee(DateTime history_date, int employee_id)
        {
            SQLiteCommand command = new SQLiteCommand("DELETE from history_employee_availability  WHERE history_date = @history_date and employee_id = @employee_id", con);
            command.Parameters.AddWithValue("@history_date", history_date.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@employee_id", employee_id);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }



    }
}
