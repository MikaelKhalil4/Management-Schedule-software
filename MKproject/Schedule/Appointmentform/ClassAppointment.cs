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
        static SqlConnection con = new SqlConnection(Program.DataLocation);
        //Property
        public int? IdAppointment { get; set; }
        public int? EmployeeId { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Notes { get; set; }
        public string HistoryClientBalance { get; set; }

        //used in UCClientApp
        public ClassClient DesiredClient { get; set; }

        //Service
        public ClassClientBalance DesiredClientBalance { get; set; }//used when we re selecting an available package      
        //others
        private List<ClassBundles> chosenBundlesList;//used when selecting new services
        public List<ClassBundles> ChosenBundlesList
        {
            get { return chosenBundlesList; }
            set
            {
                chosenBundlesList = value;
                if (value == null)
                {
                    ChoseBundlesString = null;
                }
                else
                {
                    string details = "";
                    foreach (ClassBundles Bundle in ChosenBundlesList)
                    {
                        details += Bundle.BundleName + "/";
                    }
                    if (details.Length > 0)
                    {
                        details = details.Remove(details.Length - 1);
                    }
                    ChoseBundlesString = details;
                }
            }
        }
        public string ChoseBundlesString;//e.g: hair/Beard

        public ClassAppointment()
        {

        }

        //SQL    
        public static DataTable GetAllAppointmentInfoSql(int appointmentId)
        {
            SqlCommand cmd = new SqlCommand("select * from appointments where appointment_id=@appointment_id", con);
            cmd.Parameters.AddWithValue("@appointment_id", appointmentId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable GetAllNewChosenBundles(int appointmentId)
        {
            SqlCommand cmd = new SqlCommand("select ab.bundle_id from appointments as a , appointment_has_bundles as ab where a.appointment_id=ab.appointment_id And a.appointment_id=@appointment_id", con);
            cmd.Parameters.AddWithValue("@appointment_id", appointmentId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
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
        public static DataTable DisplayAppointmentsWhereEmployees(UCDay ucday, List<int> listrankemployees_id)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.AppendLine(@"SELECT t.appointment_id , c.client_id , c.name, c.family_name  
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
        public static DataTable DisplayAppointmentsOneEmployee(UCDay ucday, int employee_id)
        {
            SqlCommand command1 = new SqlCommand(@"SELECT t.appointment_id, c.client_id, c.name,  c.family_name 
                                                   FROM appointments t JOIN client c ON t.client_id = c.client_id 
                                                   WHERE CAST(t.start_time AS DATE) = @value1  AND t.employee_id =@employee_id", con);

            string datetime = ucday.DateUCDay.ToString();
            string[] date = datetime.Split(' ');
            command1.Parameters.AddWithValue("@value1", date[0]);
            command1.Parameters.AddWithValue("@employee_id", employee_id);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;

        }
        public static int GetLastAppointmentId()
        {
            SqlCommand cmd = new SqlCommand("SELECT Max(appointment_id) FROM appointments", con);
            con.Open();
            object result = cmd.ExecuteScalar();//return the first cell
            con.Close();
            return (int)result;
        }




        public void InsertOrUpdateAppointment(bool InsertOrUpdate)
        {
            string queryInsert = @"INSERT INTO appointments (employee_id, client_id, desired_client_balance_id,title, start_time, end_time, Note) 
                                                                  VALUES (@employee_id, @client_id,@desired_client_balance_id ,@title, @start_time, @end_time, @Note) ";

            string queryUpdate = @"  Update appointments SET  
                            employee_id=@employee_id ,client_id=@client_id , desired_client_balance_id=@desired_client_balance_id, title=@title, start_time=@start_time, end_time=@end_time, Note=@Note
                                                                WHERE  appointment_id=@appointment_id ";

            SqlCommand cmdInsertOrUpdateApp;
            if (InsertOrUpdate)
            {
                cmdInsertOrUpdateApp = new SqlCommand(queryInsert, con);

            }
            else
            {
                cmdInsertOrUpdateApp = new SqlCommand(queryUpdate, con);

            }


            if (!InsertOrUpdate)
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@appointment_id", IdAppointment);
            }


            if (DesiredClient != null)
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@client_id", DesiredClient.ClientId);
            }
            else
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@client_id", DBNull.Value);

            }

            cmdInsertOrUpdateApp.Parameters.AddWithValue("@employee_id", (int)EmployeeId);



            cmdInsertOrUpdateApp.Parameters.AddWithValue("@start_time", StartTime);
            cmdInsertOrUpdateApp.Parameters.AddWithValue("@end_time", EndTime);


            if (Notes != null)
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@Note", Notes);
            }
            else
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@Note", DBNull.Value);
            }

            if (Title != null)
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@title", Title);
            }
            else
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@title", DBNull.Value);
            }
            //wahad mennun only ha ykun mawjud, ya el bundles ya chosen balance
            if (DesiredClientBalance != null)
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@desired_client_balance_id", DesiredClientBalance.ClientBalanceID);
            }
            else
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@desired_client_balance_id", DBNull.Value);
            }


            con.Open();
            cmdInsertOrUpdateApp.ExecuteNonQuery();//ejbare foe el cmd tahet mahalla    
            con.Close();


            if (!InsertOrUpdate)
            {
                SqlCommand cmdDeleteOldBundlesToApp = new SqlCommand(@"Delete from appointment_has_bundles WHERE  appointment_id = @appointment_id ", con);
                cmdDeleteOldBundlesToApp.Parameters.AddWithValue("@appointment_id", (int)IdAppointment);
                con.Open();
                cmdDeleteOldBundlesToApp.ExecuteNonQuery();
                con.Close();
            }


            if (chosenBundlesList != null && chosenBundlesList.Count > 0)
            {
                int DesiredAppointmentId;

                if (InsertOrUpdate)
                {
                    DesiredAppointmentId = GetLastAppointmentId();
                }
                else
                {
                    DesiredAppointmentId = (int)IdAppointment;


                }


                foreach (ClassBundles bundle in chosenBundlesList)
                {
                    SqlCommand cmdInsertBundleToApp = new SqlCommand(@"INSERT INTO appointment_has_bundles (appointment_id, bundle_id) 
                                                                  VALUES (@appointment_id, @bundle_id) ", con);

                    cmdInsertBundleToApp.Parameters.AddWithValue("@appointment_id", DesiredAppointmentId);
                    cmdInsertBundleToApp.Parameters.AddWithValue("@bundle_id", bundle.BundleID);
                    con.Open();
                    cmdInsertBundleToApp.ExecuteNonQuery();
                    con.Close();
                }
            }


        }
        public void DeleteAppointment()
        {
            SqlCommand command = new SqlCommand("DELETE FROM appointments WHERE appointment_id = @appointment_id ", con);
            command.Parameters.AddWithValue("@appointment_id", (int)IdAppointment);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
   



        public static ClassAppointment CreateObjectClassAppointment (int appointmentId)
        {
            DataTable dt;
            dt = ClassAppointment.GetAllAppointmentInfoSql(appointmentId);
            DataRow datarow = dt.Rows[0];//since we re expecting one row of return


            ClassAppointment DesiredApp = new ClassAppointment();


            DesiredApp.IdAppointment = (int)datarow["appointment_id"];//noway ykun bel db fi client ma endo clientid
           
            if (!(datarow["client_id"] is DBNull))
            {
                //DesiredApp.DesiredClient = ClassClient.CreateClientObject((int)datarow["client_id"]);
                //less time men el fawea this method
                DesiredApp.DesiredClient = new ClassClient();
                DataTable dtClient = ClassClient.GetAllClientsInfoSQL((int)datarow["client_id"]);

                DesiredApp.DesiredClient.ClientId = (int)dtClient.Rows[0]["client_id"];//noway ykun bel db fi client ma endo clientid
                DesiredApp.DesiredClient.Fname = dtClient.Rows[0]["name"] is DBNull ? null : (string)dtClient.Rows[0]["name"];
                DesiredApp.DesiredClient.Lname = dtClient.Rows[0]["family_name"] is DBNull ? null : (string)dtClient.Rows[0]["family_name"];
            }
          
            
            DesiredApp.EmployeeId = datarow["employee_id"] is DBNull ? (int?)null : (int)datarow["employee_id"];  
            DesiredApp.Title = datarow["title"] is DBNull ? null : (string)datarow["title"];
            DesiredApp.Notes = datarow["Note"] is DBNull ? null : (string)datarow["Note"];

            DesiredApp.StartTime = (DateTime)datarow["start_time"];
            DesiredApp.EndTime = (DateTime)datarow["end_time"];
         
            
            if (!(datarow["desired_client_balance_id"] is DBNull))
            {
                DesiredApp.DesiredClientBalance = ClassClientBalance.CreateClientBalanceObject((int)datarow["desired_client_balance_id"]);
                DesiredApp.DesiredClientBalance.SetStringDetailsIfBundle();
            }


            DataTable ChosenBundles = GetAllNewChosenBundles((int)DesiredApp.IdAppointment);
            if (ChosenBundles.Rows.Count > 0)
            {
                List<ClassBundles> bundles = new List<ClassBundles>();
                foreach (DataRow dr in ChosenBundles.Rows)
                {
                    bundles.Add(ClassBundles.CreateBundleObject((int)dr["bundle_id"]));
                }
                DesiredApp.ChosenBundlesList= bundles;//ased eemelneha kermel yenkhalae el string ma3a
            }

            // baaed fi bundle object detection 

            return DesiredApp;
        }

        // Method to clone the object
        public ClassAppointment Copy()
        {
            return (ClassAppointment)this.MemberwiseClone();
        }
    }
}
