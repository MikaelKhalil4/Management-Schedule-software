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

        //employee
        public static string DisplayEmployeeName(int employee_id)
        {
            string employeeName = string.Empty;
            SQLiteCommand command1 = new SQLiteCommand(@"SELECT first_name , last_name 
                                                   FROM employee
                                                   WHERE employee_id = @employee_id;", con);
            command1.Parameters.AddWithValue("@employee_id", employee_id);
            con.Open();
            using (SQLiteDataReader reader = command1.ExecuteReader())
            {
                if (reader.Read())
                {
                    string firstName = reader["first_name"].ToString();
                    string lastName = reader["last_name"].ToString();

                    employeeName = $"{firstName} {lastName}";
                }
            }
            con.Close();
            return employeeName;

        }

        //HistoryEmployeeavailibility
        public static DataTable DisplayRankEmployeesNAvailabilityASC(DateTime history_date)
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
        public static bool CheckIfHistoryExistsToday(DateTime dateToCheck)
        {
           
            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM history_employee_availability WHERE history_date = @history_date", con);
            cmd.Parameters.AddWithValue("@history_date", dateToCheck.ToString("yyyy-MM-dd"));
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());//return the first cell
            con.Close();

            return count > 0;
        }


        //client
        public static DataTable DisplayDataGidViewSearchName()
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT client_id,first_name, last_name, phone_number,Registration_Date,check_in FROM client", con);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            adapter.Fill(dt);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return dt;
        }
    }
}
