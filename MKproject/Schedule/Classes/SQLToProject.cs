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

        //employee
        public static string DisplayEmployeeName(int employee_id)
        {
            string employeeName = string.Empty;
            SqlCommand command1 = new SqlCommand(@"SELECT first_name , last_name 
                                                   FROM employee
                                                   WHERE employee_id = @employee_id;", con);
            command1.Parameters.AddWithValue("@employee_id", employee_id);
            con.Open();
            using (SqlDataReader reader = command1.ExecuteReader())
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
                            WHERE history_date = @history_date ORDER BY rank ASC";


            SqlCommand command = new SqlCommand(query, con);
          
            
            command.Parameters.AddWithValue("@history_date", history_date.Date);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            return dt;
        }
        public static bool CheckIfHistoryExistsToday(DateTime dateToCheck)
        {
            int count;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM history_employee_availability WHERE history_date = @history_date", con);
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
            SqlCommand cmd = new SqlCommand("SELECT client_id,first_name, last_name, phone_number,Registration_Date,check_in FROM client", con);
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
