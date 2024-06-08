using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.SQLite;

namespace MKproject.Schedule
{
    public class SQLToProject
    {
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);


        //HistoryEmployeeavailibility
        public static DataTable GetRankEmployeesNAvailabilityASC(DateTime history_date)
        {

            string query = @"SELECT emp.employee_id,emp.first_name,emp.last_name,h.rank,h.availability
                            FROM history_employee_availability as h
                            Join employee as emp on emp.employee_id=h.employee_id
                            WHERE history_date = @history_date ORDER BY h.rank ASC";


            SQLiteCommand command = new SQLiteCommand(query, con);
          
            
            command.Parameters.AddWithValue("@history_date", history_date.ToString("yyyy-MM-dd"));
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            return dt;
        }
        public static DataTable GetEmployeeAvailabilityBetweenTwoDates(DateTime StartDate,DateTime EndDate,int empId)
        {

            string query = "SELECT history_date,availability FROM history_employee_availability WHERE employee_id=@employee_id and Date(history_date) BETWEEN @startDate AND @endDate";

            SQLiteCommand command = new SQLiteCommand(query, con);

            command.Parameters.AddWithValue("@startDate", StartDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@endDate", EndDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@employee_id", empId);

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            return dt;
        }
        public static DataTable GetEmployeeAvailabilityofDesiredDate(DateTime Date, int empId)
        {

            string query = "SELECT history_date,availability FROM history_employee_availability WHERE employee_id=@employee_id and Date(history_date)=@history_date";

            SQLiteCommand command = new SQLiteCommand(query, con);

            command.Parameters.AddWithValue("@history_date", Date.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@employee_id", empId);

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            return dt;
        }
        public static bool CheckIfHistoryExistsToday(DateTime dateToCheck)
        {
           
            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM history_employee_availability WHERE Date(history_date) = @history_date", con);
            cmd.Parameters.AddWithValue("@history_date",dateToCheck.ToString("yyyy-MM-dd"));
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());//return the first cell
            con.Close();

            return count > 0;
        }

        //public static DataTable GetEmployeeAvailabiltyForThisWeekForPastDays()
        //{

        //}

        
     
    }
}
