using System;
using System.Data.SqlClient;
using System.Data;
using System.Data.SQLite;

namespace MKproject.Schedule
{
    public class ProjectToSql
    {

        //HistoryEmployeeavailibility
        public static void UpdateRank_HistoryEmployeeavailibility(DateTime history_date, int employee_id, int rank,string availability)
        {
            var command = Program.CreateCommand("UPDATE history_employee_availability SET rank= @rank,availability=@availability WHERE DATE(history_date) = @history_date and employee_id = @employee_id");

            command.AddWithValue("@history_date", history_date.ToString("yyyy-MM-dd"));
            command.AddWithValue("@employee_id", employee_id);
            command.AddWithValue("@rank", rank);
            if (!String.IsNullOrEmpty(availability))
            {
                command.AddWithValue("@availability", availability);
            }
            else
            {
                command.AddWithValue("@availability", DBNull.Value);
            }
            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();
        }    
        public static void InsertHistoryEmployeeavailibility(DateTime history_date, int employee_id, int rank, string availability)
        {
            var command = Program.CreateCommand(@"INSERT INTO history_employee_availability (history_date,employee_id, rank, availability) 
                                                                  VALUES (@history_date,@employee_id,@rank,@availability) ");

            command.AddWithValue("@history_date", history_date.Date.ToString("yyyy-MM-dd"));
            command.AddWithValue("@employee_id", employee_id);
            command.AddWithValue("@rank", rank);
           
            if (!String.IsNullOrEmpty(availability))
            {
                command.AddWithValue("@availability", availability);
            }
            else
            {
                command.AddWithValue("@availability", DBNull.Value);
            }

            Program.conOpen();
            command.ExecuteNonQuery();//first command
            Program.con.Close();
        }
        public static void DeleteHistoryEmployee(DateTime history_date, int employee_id)
        {
            var command = Program.CreateCommand("DELETE from history_employee_availability  WHERE DATE(history_date) = @history_date and employee_id = @employee_id");
            command.AddWithValue("@history_date", history_date.ToString("yyyy-MM-dd"));
            command.AddWithValue("@employee_id", employee_id);

            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();
        }



    }
}
