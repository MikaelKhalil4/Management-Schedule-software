using MKproject.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKproject.Schedule
{
    public class ClassAppointment
    {
        //Property
        public int? IdAppointment { get; set; }
        public int? EmployeeId { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Notes { get; set; }
     
        //just when it will be created it will be false
        private bool onPending = false;
        public bool OnPending
        {
            get
            {
                return onPending;
            }
            set
            {
                onPending = value;
            }
        }

        //used in UCClientApp
        public ClassClient DesiredClient { get; set; }
          
        public ClassChosenClientBalance DesiredClientBalance { get; set; }//used when we re selecting an available package      
        public List<ClassBundles> ChosenServicesList;//used when selecting new services
        public string ChosenServicesDetails;//e.g: hair/Beard
                                           
        //SQL
        static SqlConnection con = new SqlConnection(Program.DataLocation);

        //zid title
        public static List<int> DisplayEmployeesIdWhoTrained(UCDay ucday, List<int> listrankemployees_id)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("SELECT DISTINCT employee_id FROM appointments WHERE CAST(start_time AS DATE) = @value1 ");
            if (listrankemployees_id.Count > 0)
            {
                queryBuilder.AppendLine("AND employee_id IN (");

                for (int i = 0; i < listrankemployees_id.Count; i++)
                {
                    queryBuilder.Append($"@employee_id{i}");
                    if (i < listrankemployees_id.Count - 1)
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
            for (int i = 0; i < listrankemployees_id.Count; i++)
            {
                command1.Parameters.AddWithValue($"@employee_id{i}", listrankemployees_id[i]);
            }
            con.Open();

            // Execute the second query to get the list of employee IDs
            List<int> employeeIdsWithAppointments = new List<int>();
            using (SqlDataReader reader = command1.ExecuteReader())
            {
                while (reader.Read())
                {
                    employeeIdsWithAppointments.Add(reader.GetInt32(0));
                }
            }

            con.Close();
            return employeeIdsWithAppointments;
        }

        //zid title
        public static DataTable DisplayAppointmentsWhereEmployees(UCDay ucday, List<int> listrankemployees_id)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.AppendLine(@"SELECT t.appointment_id , t.employee_id, c.client_id, c.name,  c.family_name,
                                      t.start_time, t.end_time, t.Note, t.onpending, t.client_type
                                      FROM appointments t
                                      JOIN client c ON t.client_id = c.client_id
                                      WHERE CAST(t.start_time AS DATE) = @value1");
            if (listrankemployees_id.Count > 0)
            {
                queryBuilder.AppendLine("AND t.employee_id IN (");

                for (int i = 0; i < listrankemployees_id.Count; i++)
                {
                    queryBuilder.Append($"@employeeId{i}");
                    if (i < listrankemployees_id.Count - 1)
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
            for (int i = 0; i < listrankemployees_id.Count; i++)
            {
                command1.Parameters.AddWithValue($"@employeeId{i}", listrankemployees_id[i]);
            }
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;
        }

        //zid title
        public static DataTable DisplayAppointmentsOneEmployee(UCDay ucday, int employee_id)
        {
            SqlCommand command1 = new SqlCommand(@"SELECT t.appointment_id, c.client_id, c.name,  c.family_name,
                                                   t.start_time, t.end_time, t.Note, t.onpending, t.client_type
                                                   FROM appointments t JOIN client c ON t.client_id = c.client_id 
                                                   WHERE CAST(t.start_time AS DATE) = @value1  AND t.employee_id =@employee_id", con);
            string datetime = ucday.DateUCDay.ToString();
            string[] date = datetime.Split(' ');
            command1.Parameters.AddWithValue("@value1", date[0]);
            command1.Parameters.AddWithValue("@employee_id", employee_id);
            command1.Parameters.AddWithValue("@isappointment", true);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;

        }

        //if
        public int AddFromAppoitementtoSQL()//na2is ClientType
        {
            int idappointment;
            SqlCommand command = new SqlCommand(@"INSERT INTO appointments (employee_id,client_id,start_time,end_time,Note,onpending,client_type) 
                                                                  VALUES (@employee_id,@client_id,@start_time, @end_time, @Note, @onpending, @client_type) ", con);
            SqlCommand cmd = new SqlCommand("SELECT Max(appointment_id) FROM appointments", con);
            //string[] parts = fullname.Split(' ');

            command.Parameters.AddWithValue("@employee_id", (int)EmployeeId);
            if (DesiredClient != null && Title == null)
            {
                command.Parameters.AddWithValue("@client_id", DesiredClient.ClientId);
            }
            else if(DesiredClient == null && Title != null)
            {
                command.Parameters.AddWithValue("@client_id", DBNull.Value);
            }
            command.Parameters.AddWithValue("@start_time", StartTime);
            command.Parameters.AddWithValue("@end_time", EndTime);
            command.Parameters.AddWithValue("@Note", Notes);
            command.Parameters.AddWithValue("@onpending", OnPending);
            command.Parameters.AddWithValue("@client_type", DBNull.Value);

            command.Parameters.AddWithValue("@isappointment", true);


            con.Open();
            command.ExecuteNonQuery();//first command
            object result = cmd.ExecuteScalar();//return the first cell
            int.TryParse(result.ToString(), out idappointment);//we got the idtime second command
            con.Close();

            return idappointment;

        }
        //if
        public void UpdateFromAppoitementtoSQL()
        {
            SqlCommand command = new SqlCommand(@"UPDATE appointments
                                                  SET client_id=@client_id, start_time=@start_time, end_time=@end_time, Note=@Note, onpending=@onpending,client_type=@client_type
                                                  WHERE appointment_id =@appointment_id", con);


            command.Parameters.AddWithValue("@client_id", DesiredClient.ClientId);
            command.Parameters.AddWithValue("@start_time", StartTime);
            command.Parameters.AddWithValue("@end_time", EndTime);
            command.Parameters.AddWithValue("@Note", Notes);
            command.Parameters.AddWithValue("@onpending", OnPending);
            command.Parameters.AddWithValue("@client_type", DBNull.Value);
            command.Parameters.AddWithValue("@appointment_id", (int)IdAppointment);


            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteAppointment()
        {
            SqlCommand command = new SqlCommand("DELETE FROM appointments WHERE appointment_id = @appointment_id ", con);
            command.Parameters.AddWithValue("@appointment_id", (int)IdAppointment);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateAppointmentCheck()
        {
            SqlCommand command = new SqlCommand(@"UPDATE appointments
                                                  SET onpending=@onpending
                                                  WHERE appointment_id =@appointment_id", con);
            command.Parameters.AddWithValue("@onpending", OnPending);
            command.Parameters.AddWithValue("@appointment_id", (int)IdAppointment);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }


        // Method to clone the object
        public ClassAppointment Copy()
        {
            return (ClassAppointment)this.MemberwiseClone();
        }
    }
}
