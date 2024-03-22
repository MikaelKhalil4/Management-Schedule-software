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
        public int AppointmentID { get; set; }
      
        private int employeeId;
        public int EmployeeId
        {
            get { return employeeId; }
            set {
                
                employeeId = value;
                EmployeeFullName = ClassEmployee.GetEmployeeFullName(value);
            }
        }
        public string EmployeeFullName { get; set; }//this one is additional

        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Notes { get; set; }
        public string HistoryClientBalance { get; set; }
        public bool IsCompleted { get; set; }//default false, which we want
        public bool IsCanceled { get; set; }//default false, which we want

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
            SqlCommand cmd = new SqlCommand("select ab.bundle_id from appointments as a , appointment_has_bundles as ab where a.appointment_id=ab.appointment_id And a.appointment_id=@appointment_id ORDER BY app_bundle_id ASC", con);
            cmd.Parameters.AddWithValue("@appointment_id", appointmentId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static List<int> DisplayEmployeesIdWhoTrained(UCDay ucday, List<int> listrankemployees_id)
        {
            string querry = "SELECT DISTINCT employee_id FROM appointments WHERE CAST(start_time AS DATE) = @Date ";
            if (listrankemployees_id.Count > 0)
            {
                querry += "AND employee_id IN (";

                for (int i = 0; i < listrankemployees_id.Count; i++)
                {
                    querry += listrankemployees_id[i];
                    if (i < listrankemployees_id.Count - 1)
                    {
                        querry += ", ";
                    }
                }

                querry += ")";
            }
            SqlCommand command1 = new SqlCommand(querry, con);
            command1.Parameters.AddWithValue("@Date", ucday.SelectedDate.Date);
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
            string query = @"SELECT appointment_id 
                          FROM appointments                                 
                          WHERE CAST(start_time AS DATE) = @Date ";

            if (listrankemployees_id.Count > 0)
            {
                query += "AND employee_id IN (";

                for (int i = 0; i < listrankemployees_id.Count; i++)
                {
                    query += listrankemployees_id[i];
                    if (i < listrankemployees_id.Count - 1)
                    {
                        query += ", ";
                    }
                }
                query += ")";
            }

            SqlCommand command1 = new SqlCommand(query, con);
            command1.Parameters.AddWithValue("@Date", ucday.SelectedDate.Date);
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
            SqlCommand command1 = new SqlCommand(@"SELECT appointment_id
                                                   FROM appointments 
                                                   WHERE CAST(start_time AS DATE) = @Date  AND employee_id =@employee_id", con);

            command1.Parameters.AddWithValue("@Date", ucday.SelectedDate.Date);
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
        public static DataTable GetRelatedSoloBundles(int appointmentId)
        {
            SqlCommand cmd = new SqlCommand("Select * from appointment_has_bundles WHERE  appointment_id = @appointment_id", con);
            cmd.Parameters.AddWithValue("@appointment_id", appointmentId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static void DeleteRelatedSoloBundle(int appointmentId,int bundleId)
        {
            SqlCommand cmdDeleteOldBundlesToApp = new SqlCommand(@"Delete from appointment_has_bundles WHERE  appointment_id = @appointment_id And bundle_id=@bundle_id ", con);
            cmdDeleteOldBundlesToApp.Parameters.AddWithValue("@appointment_id", appointmentId);
            cmdDeleteOldBundlesToApp.Parameters.AddWithValue("@bundle_id", bundleId);
            con.Open();
            cmdDeleteOldBundlesToApp.ExecuteNonQuery();
            con.Close();
        }




        public void InsertOrUpdateAppointment(bool InsertOrUpdate)
        {
            string queryInsert = @"INSERT INTO appointments (employee_id, client_id, client_balance_id,title, start_time, end_time, Note,is_completed,is_canceled) 
                                                                  VALUES (@employee_id, @client_id,@client_balance_id ,@title, @start_time, @end_time, @Note,@is_completed,@is_canceled) ";

            string queryUpdate = @"  Update appointments SET  
                            employee_id=@employee_id ,client_id=@client_id , client_balance_id=@client_balance_id, title=@title, 
                                                        start_time=@start_time, end_time=@end_time, Note=@Note ,is_completed=@is_completed,is_canceled=@is_canceled
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
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@appointment_id", AppointmentID);
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

            cmdInsertOrUpdateApp.Parameters.AddWithValue("@is_completed", IsCompleted);
            cmdInsertOrUpdateApp.Parameters.AddWithValue("@is_canceled", IsCanceled);



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
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@client_balance_id", DesiredClientBalance.ClientBalanceID);
            }
            else
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@client_balance_id", DBNull.Value);
            }


            con.Open();
            cmdInsertOrUpdateApp.ExecuteNonQuery();//ejbare foe el cmd tahet mahalla    
            con.Close();


            if (!InsertOrUpdate)
            {
                SqlCommand cmdDeleteOldBundlesToApp = new SqlCommand(@"Delete from appointment_has_bundles WHERE  appointment_id = @appointment_id ", con);
                cmdDeleteOldBundlesToApp.Parameters.AddWithValue("@appointment_id", (int)AppointmentID);
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
                    DesiredAppointmentId = (int)AppointmentID;


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
            //ejbare bhal order men wara el rlt
            UndoCompletionAppointment();

            con.Open();

            //Battal ela aaze Since aam yenma7o bel UndoCompletionAppointment
            //string queryDeleteArchive = "DELETE FROM archive WHERE appointment_id='" + (int)AppointmentID + "'";
            //SqlCommand cmd1 = new SqlCommand(queryDeleteArchive, con);
            //cmd1.ExecuteNonQuery();

            string queryDeleteRelation = "DELETE FROM appointment_has_bundles WHERE appointment_id='" + (int)AppointmentID + "'";
            SqlCommand cmd3 = new SqlCommand(queryDeleteRelation, con);
            cmd3.ExecuteNonQuery();


            string QueryDeleteClientAttendace = "DELETE FROM client_services_attendance WHERE appointment_id = '" + (int)AppointmentID + "'";
            SqlCommand cmd4 = new SqlCommand(QueryDeleteClientAttendace, con);
            cmd4.ExecuteNonQuery();

            string queryDelteApp = "DELETE FROM appointments WHERE appointment_id='" + (int)AppointmentID + "'";
            SqlCommand cmd2 = new SqlCommand(queryDelteApp, con);
            cmd2.ExecuteNonQuery();


            con.Close();
        }
        public void UndoCompletionAppointment()
        {

            //kermel naamil Undo lal Purchases 

            SqlCommand cmd = new SqlCommand("select archive_id,attendance_id,client_balance_id,action_type from archive where appointment_id=@appointment_id", con);
            cmd.Parameters.AddWithValue("@appointment_id", (int)AppointmentID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           
            foreach (DataRow dr in dt.Rows)
            {               
                int ClientBalanceId = (int)dr["client_balance_id"];
                if (dr["action_type"].ToString() == ActionsEnum.SoloPurchases.ToString())
                {
                    ClassBackOffice.UndoSoloPurchaseActionsSQL(DesiredClient.ClientId, (int)dr["attendance_id"],(int)dr["archive_id"], ClientBalanceId,null,null, null);//ased mnebaat appointmnet id null, lieanno this id meant to be bas men el classbackoffice, hone in this we handled shu bi sir eza ken apointment, bas bel backoffice fi ykun appoint fi ma ykun
                }
                else if (dr["action_type"].ToString() == ActionsEnum.SessionDone.ToString())
                {
                    ClassBackOffice.UndoSessionDoneActionsSQL(DesiredClient.ClientId, (int)dr["attendance_id"], (int)dr["archive_id"], ClientBalanceId, false, null, null);
                }
            }

            SetOrResetIsCompleted();       

        }
        public void SetOrResetIsCompleted()
        {
            SqlCommand cmdUpdateCompletion = new SqlCommand(@" Update appointments SET  is_completed=@is_completed  WHERE  appointment_id=@appointment_id ", con); ;
            cmdUpdateCompletion.Parameters.AddWithValue("@appointment_id", (int)AppointmentID);
            cmdUpdateCompletion.Parameters.AddWithValue("@is_completed", IsCompleted);
            con.Open();
            cmdUpdateCompletion.ExecuteNonQuery();
            con.Close();
        }
        public void SetOrResetIsCanceled()
        {
            SqlCommand cmdUpdateCompletion = new SqlCommand(@" Update appointments SET  is_canceled=@is_canceled  WHERE  appointment_id=@appointment_id ", con); ;
            cmdUpdateCompletion.Parameters.AddWithValue("@appointment_id", (int)AppointmentID);
            cmdUpdateCompletion.Parameters.AddWithValue("@is_canceled", IsCanceled);
            con.Open();
            cmdUpdateCompletion.ExecuteNonQuery();
            con.Close();
        }
        public static ClassAppointment CreateObjectClassAppointment(int appointmentId)
        {
            DataTable dt;
            dt = ClassAppointment.GetAllAppointmentInfoSql(appointmentId);
            DataRow datarow = dt.Rows[0];//since we re expecting one row of return


            ClassAppointment DesiredApp = new ClassAppointment();


            DesiredApp.AppointmentID = (int)datarow["appointment_id"];//noway ykun bel db fi client ma endo clientid

            if (!(datarow["client_id"] is DBNull))
            {
                //DesiredApp.DesiredClient = ClassClient.CreateClientObject((int)datarow["client_id"]);
                //less time men el fawea this method
                DesiredApp.DesiredClient = new ClassClient();
                DataTable dtClient = ClassClient.GetAllClientsInfoSQL((int)datarow["client_id"]);

                DesiredApp.DesiredClient.ClientId = (int)dtClient.Rows[0]["client_id"];//noway ykun bel db fi client ma endo clientid
                DesiredApp.DesiredClient.Fname = dtClient.Rows[0]["name"] is DBNull ? null : (string)dtClient.Rows[0]["name"];
                DesiredApp.DesiredClient.Lname = dtClient.Rows[0]["family_name"] is DBNull ? null : (string)dtClient.Rows[0]["family_name"];
                DesiredApp.DesiredClient.RegistrationDate = dtClient.Rows[0]["Registration_Date"] is DBNull ?  null : (DateTime)dtClient.Rows[0]["Registration_Date"];//kermel eza shataryna package with Membership
            }

            DesiredApp.EmployeeId = (int)datarow["employee_id"];
            DesiredApp.Title = datarow["title"] is DBNull ? null : (string)datarow["title"];
            DesiredApp.Notes = datarow["Note"] is DBNull ? null : (string)datarow["Note"];


            DesiredApp.StartTime = (DateTime)datarow["start_time"];
            DesiredApp.EndTime = (DateTime)datarow["end_time"];


            DesiredApp.IsCompleted= (bool)datarow["is_completed"];
            DesiredApp.IsCanceled = (bool)datarow["is_canceled"];


            if (!(datarow["client_balance_id"] is DBNull))
            {
                DesiredApp.DesiredClientBalance = ClassClientBalance.CreateClientBalanceObject((int)datarow["client_balance_id"]);
                DesiredApp.DesiredClientBalance.SetStringDetailsIfBundle();
            }


            DataTable ChosenBundles = GetAllNewChosenBundles((int)DesiredApp.AppointmentID);
            if (ChosenBundles.Rows.Count > 0)
            {
                List<ClassBundles> bundles = new List<ClassBundles>();
                foreach (DataRow dr in ChosenBundles.Rows)
                {
                    bundles.Add(ClassBundles.CreateBundleObject((int)dr["bundle_id"]));
                }
                DesiredApp.ChosenBundlesList = bundles;//ased eemelneha kermel yenkhalae el string ma3a
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
