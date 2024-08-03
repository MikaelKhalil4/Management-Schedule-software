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


        //HistoryEmployeeavailibility
        public static DataTable GetRankEmployeesNAvailabilityASC(DateTime history_date)
        {

            string query = @"SELECT emp.employee_id,emp.first_name,emp.last_name,h.rank,h.availability
                            FROM history_employee_availability as h
                            Join employee as emp on emp.employee_id=h.employee_id
                            WHERE Date(history_date) = @history_date  AND history_date IS NOT NULL 
                            ORDER BY h.rank ASC";


            var command = Program.CreateCommand(query);
          
            
            command.AddWithValue("@history_date", history_date.ToString("yyyy-MM-dd"));
            var adapter = Program.CreateDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();
            return dt;
        }
        public static DataTable GetEmployeeAvailabilityBetweenTwoDates(DateTime StartDate,DateTime EndDate,int empId)
        {

            string query = "SELECT history_date,availability FROM history_employee_availability WHERE employee_id=@employee_id and Date(history_date) BETWEEN @startDate AND @endDate";

            var command = Program.CreateCommand(query);

            command.AddWithValue("@startDate", StartDate.ToString("yyyy-MM-dd"));
            command.AddWithValue("@endDate", EndDate.ToString("yyyy-MM-dd"));
            command.AddWithValue("@employee_id", empId);

            var adapter = Program.CreateDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();
            return dt;
        }
        public static DataTable GetEmployeeAvailabilityofDesiredDate(DateTime Date, int empId)
        {

            string query = "SELECT history_date,availability FROM history_employee_availability WHERE employee_id=@employee_id and Date(history_date)=@history_date";

            var command = Program.CreateCommand(query);

            command.AddWithValue("@history_date", Date.ToString("yyyy-MM-dd"));
            command.AddWithValue("@employee_id", empId);

            var adapter = Program.CreateDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();
            return dt;
        }
        public static bool CheckIfHistoryExistsToday(DateTime dateToCheck)
        {
           
            var cmd = Program.CreateCommand("SELECT COUNT(*) FROM history_employee_availability WHERE Date(history_date) = @history_date");
            cmd.AddWithValue("@history_date",dateToCheck.ToString("yyyy-MM-dd"));
            Program.conOpen();
            int count = Convert.ToInt32(cmd.ExecuteScalar());//return the first cell
            Program.con.Close();

            return count > 0;
        }
        public static DateTime? GetLastHistoryDate()
        {
            var cmd = Program.CreateCommand("SELECT MAX(history_date) FROM history_employee_availability");

            Program.conOpen();
            object LastHistoryDate = cmd.ExecuteScalar();
            Program.con.Close();

            if (LastHistoryDate != DBNull.Value)
            {
                return Convert.ToDateTime(LastHistoryDate);
            }
            else
            {
                return null;
            }
        }

        //public static DataTable GetEmployeeAvailabiltyForThisWeekForPastDays()
        //{

        //}

        
     
    }
}
