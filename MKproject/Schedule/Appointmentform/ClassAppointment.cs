using MKproject.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MKproject.Schedule
{
    public class ClassAppointment
    {
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);
        //Property
        public int AppointmentID { get; set; }

        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Notes { get; set; }
        public bool IsCompleted { get; set; }//default false, which we want
        public bool IsCanceled { get; set; }//default false, which we want

        public ClassEmployee DesiredEmployee { get; set; }
        public ClassClientCustom DesiredClient { get; set; } //used in UCClientApp



        //Hole el tnen Wahde mennun Null Always, kermel naarif eza package or New Solo Service
        //Service:
        public bool IsPackageMode { get; set; }//Default Value False
                                               //if false,DesiredClientBalance will be null, if IsPackageMode true ,DesiredClientBalance can be null or not null
        public ClassClientBalance DesiredClientBalance { get; set; }//used when we re selecting an available package
        public string HistoryClientBalance { get; set; }
        //
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
        public string ChoseBundlesString { get; set; }//e.g: hair/Beard


        public ClassAppointment()
        {

        }

        //SQL    


        public static DataTable GetAllAppointmentInfoSql(int appointmentId)
        {
            SQLiteCommand cmd = new SQLiteCommand("select * from appointments where appointment_id=@appointment_id", con);
            cmd.Parameters.AddWithValue("@appointment_id", appointmentId);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable GetAllChosenSoloBundles(int appointmentId)
        {
            SQLiteCommand cmd = new SQLiteCommand("select ab.bundle_id from appointments as a , appointment_has_bundles as ab where a.appointment_id=ab.appointment_id And a.appointment_id=@appointment_id ORDER BY app_bundle_id ASC", con);
            cmd.Parameters.AddWithValue("@appointment_id", appointmentId);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static List<ClassAppointment> GetAppointmentOfSpecificEmployees(DateTime SelectedDate, List<ClassEmployee> ListEmployeeSchedule)
        {
            string query = @"SELECT * 
                          FROM appointments                                 
                          WHERE DATE(start_time) = @Date ";

            if (ListEmployeeSchedule.Count > 0)
            {
                query += "AND employee_id IN (";

                for (int i = 0; i < ListEmployeeSchedule.Count; i++)
                {
                    query += ListEmployeeSchedule[i].EmployeeId;
                    if (i < ListEmployeeSchedule.Count - 1)
                    {
                        query += ", ";
                    }
                }
                query += ")";
            }

            SQLiteCommand command1 = new SQLiteCommand(query, con);
            command1.Parameters.AddWithValue("@Date", SelectedDate.ToString("yyyy-MM-dd"));
            SQLiteDataAdapter adapter1 = new SQLiteDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();

            return DataTableToList(dt1);
        }
        public static List<ClassAppointment> GetAppointmentOfSpecificDays(List<DateTime> ListDaysOfDesiredWeek)
        {
            string query = @"SELECT * 
                     FROM appointments                                 
                     WHERE 1=1 ";

            if (ListDaysOfDesiredWeek.Count > 0)
            {
                query += " AND DATE(start_time) IN (";
                for (int i = 0; i < ListDaysOfDesiredWeek.Count; i++)
                {
                    query += $"@Date{i}";
                    if (i < ListDaysOfDesiredWeek.Count - 1)
                    {
                        query += ", ";
                    }
                }
                query += ")";
            }

            SQLiteCommand command1 = new SQLiteCommand(query, con);

            for (int i = 0; i < ListDaysOfDesiredWeek.Count; i++)
            {
                command1.Parameters.AddWithValue($"@Date{i}", ListDaysOfDesiredWeek[i].ToString("yyyy-MM-dd"));
            }

            SQLiteDataAdapter adapter1 = new SQLiteDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);

            return DataTableToList(dt1);
        }
        public static int GetLastAppointmentId()
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT Max(appointment_id) FROM appointments", con);
            con.Open();
            object result = cmd.ExecuteScalar();//return the first cell
            con.Close();
            return Convert.ToInt32(result);
        }
        public static DataTable GetRelatedSoloBundles(int appointmentId)
        {
            SQLiteCommand cmd = new SQLiteCommand("Select * from appointment_has_bundles WHERE  appointment_id = @appointment_id", con);
            cmd.Parameters.AddWithValue("@appointment_id", appointmentId);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static void DeleteRelatedSoloBundle(int appointmentId, int bundleId)
        {
            SQLiteCommand cmdDeleteOldBundlesToApp = new SQLiteCommand(@"Delete FROM  appointment_has_bundles WHERE  appointment_id = @appointment_id And bundle_id=@bundle_id ", con);
            cmdDeleteOldBundlesToApp.Parameters.AddWithValue("@appointment_id", appointmentId);
            cmdDeleteOldBundlesToApp.Parameters.AddWithValue("@bundle_id", bundleId);
            con.Open();
            cmdDeleteOldBundlesToApp.ExecuteNonQuery();
            con.Close();
        }
        public static void SwapClientBalanceIdOnRenewPackage(int ExistingClientBalanceId, int NewClientBalanceId)
        {
            string query = "Update appointments Set client_balance_id='" + NewClientBalanceId + "' Where start_time >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' And appointment_id in (Select appointment_id from appointments where client_balance_id='" + ExistingClientBalanceId + "')";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }



        public void InsertOrUpdateAppointment(bool InsertOrUpdate)
        {
            string queryInsert = @"INSERT INTO appointments (employee_id, client_id,is_package_mode ,client_balance_id,history_client_balance,title, start_time, end_time, Note,is_completed,is_canceled) 
                                                                  VALUES (@employee_id, @client_id,@is_package_mode,@client_balance_id,@history_client_balance ,@title, @start_time, @end_time, @Note,@is_completed,@is_canceled) ";

            string queryUpdate = @"  Update appointments SET  
                            employee_id=@employee_id ,client_id=@client_id ,is_package_mode=@is_package_mode ,client_balance_id=@client_balance_id,history_client_balance=@history_client_balance, title=@title, 
                                                        start_time=@start_time, end_time=@end_time, Note=@Note ,is_completed=@is_completed,is_canceled=@is_canceled
                                                                WHERE  appointment_id=@appointment_id ";

            SQLiteCommand cmdInsertOrUpdateApp;
            if (InsertOrUpdate)
            {
                cmdInsertOrUpdateApp = new SQLiteCommand(queryInsert, con);

            }
            else
            {
                cmdInsertOrUpdateApp = new SQLiteCommand(queryUpdate, con);

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

            cmdInsertOrUpdateApp.Parameters.AddWithValue("@employee_id", DesiredEmployee.EmployeeId);



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

            cmdInsertOrUpdateApp.Parameters.AddWithValue("@is_package_mode", IsPackageMode);


            if (DesiredClientBalance != null)
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@client_balance_id", DesiredClientBalance.ClientBalanceID);
            }
            else
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@client_balance_id", DBNull.Value);
            }

            if (HistoryClientBalance != null)
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@history_client_balance", HistoryClientBalance);
            }
            else
            {
                cmdInsertOrUpdateApp.Parameters.AddWithValue("@history_client_balance", DBNull.Value);
            }


            con.Open();
            cmdInsertOrUpdateApp.ExecuteNonQuery();//ejbare foe el cmd tahet mahalla    
            con.Close();


            if (!InsertOrUpdate)
            {
                SQLiteCommand cmdDeleteOldBundlesToApp = new SQLiteCommand(@"Delete FROM appointment_has_bundles WHERE  appointment_id = @appointment_id ", con);
                cmdDeleteOldBundlesToApp.Parameters.AddWithValue("@appointment_id", AppointmentID);
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
                    DesiredAppointmentId = AppointmentID;


                }


                foreach (ClassBundles bundle in chosenBundlesList)
                {
                    SQLiteCommand cmdInsertBundleToApp = new SQLiteCommand(@"INSERT INTO appointment_has_bundles (appointment_id, bundle_id) 
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
            UndoCompletionAppointmentSQL();

            con.Open();

            //Battal ela aaze Since aam yenma7o bel UndoCompletionAppointment
            //string queryDeleteArchive = "DELETE FROM archive WHERE appointment_id='" + (int)AppointmentID + "'";
            //SQLiteCommand cmd1 = new SQLiteCommand(queryDeleteArchive, con);
            //cmd1.ExecuteNonQuery();

            string queryDeleteRelation = "DELETE FROM appointment_has_bundles WHERE appointment_id='" + AppointmentID + "'";
            SQLiteCommand cmd3 = new SQLiteCommand(queryDeleteRelation, con);
            cmd3.ExecuteNonQuery();


            string QueryDeleteClientAttendace = "DELETE FROM client_services_attendance WHERE appointment_id = '" + AppointmentID + "'";
            SQLiteCommand cmd4 = new SQLiteCommand(QueryDeleteClientAttendace, con);
            cmd4.ExecuteNonQuery();

            string queryDelteApp = "DELETE FROM appointments WHERE appointment_id='" + AppointmentID + "'";
            SQLiteCommand cmd2 = new SQLiteCommand(queryDelteApp, con);
            cmd2.ExecuteNonQuery();


            con.Close();
        }
        public void UndoCompletionAppointmentSQL()
        {

            //kermel naamil Undo lal Purchases 

            SQLiteCommand cmd = new SQLiteCommand("select archive_id,attendance_id,client_balance_id,action_type from archive where appointment_id=@appointment_id", con);
            cmd.Parameters.AddWithValue("@appointment_id", AppointmentID);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                int ClientBalanceId = Convert.ToInt32(dr["client_balance_id"]);
                if (dr["action_type"].ToString() == ActionsEnum.SoloPurchases.ToString())//Solo service
                {
                    ClassBackOffice.UndoSoloPurchaseActionsSQL(DesiredClient.ClientId, Convert.ToInt32(dr["attendance_id"]), Convert.ToInt32(dr["archive_id"]), ClientBalanceId, null, null);//ased mnebaat appointmnet id null, lieanno this id meant to be bas men el classbackoffice, hone in this we handled shu bi sir eza ken apointment, bas bel backoffice fi ykun appoint fi ma ykun
                }
                else if (dr["action_type"].ToString() == ActionsEnum.SessionDone.ToString())// package 
                {
                    ClassBackOffice.UndoSessionDoneActionsSQL(DesiredClient.ClientId, Convert.ToInt32(dr["attendance_id"]), Convert.ToInt32(dr["archive_id"]), ClientBalanceId, false, null);

                }
            }

            SetOrResetIsCompleted();

        }
        public void UpdateHistoryClientBalance()
        {
            SQLiteCommand cmdUpdateCompletion = new SQLiteCommand(@" Update appointments SET  history_client_balance=@history_client_balance  WHERE  appointment_id=@appointment_id ", con); ;
            cmdUpdateCompletion.Parameters.AddWithValue("@appointment_id", AppointmentID);
            cmdUpdateCompletion.Parameters.AddWithValue("@history_client_balance", HistoryClientBalance);
            con.Open();
            cmdUpdateCompletion.ExecuteNonQuery();
            con.Close();
        }
        public void SetOrResetIsCompleted()
        {
            SQLiteCommand cmdUpdateCompletion = new SQLiteCommand(@" Update appointments SET  is_completed=@is_completed  WHERE  appointment_id=@appointment_id ", con); ;
            cmdUpdateCompletion.Parameters.AddWithValue("@appointment_id", AppointmentID);
            cmdUpdateCompletion.Parameters.AddWithValue("@is_completed", IsCompleted);
            con.Open();
            cmdUpdateCompletion.ExecuteNonQuery();
            con.Close();
        }
        public void SetOrResetIsCanceled()
        {
            SQLiteCommand cmdUpdateCompletion = new SQLiteCommand(@" Update appointments SET  is_canceled=@is_canceled  WHERE  appointment_id=@appointment_id ", con); ;
            cmdUpdateCompletion.Parameters.AddWithValue("@appointment_id", AppointmentID);
            cmdUpdateCompletion.Parameters.AddWithValue("@is_canceled", IsCanceled);
            con.Open();
            cmdUpdateCompletion.ExecuteNonQuery();
            con.Close();
        }
        public DataTable AllRelatedRowsInArchiveTable()
        {
            SQLiteCommand cmd = new SQLiteCommand("Select * from archive WHERE  appointment_id = @appointment_id", con);
            cmd.Parameters.AddWithValue("@appointment_id", AppointmentID);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }


        public static ClassAppointment CreateObjectClassAppointment(int appointmentId)//one appointment
        {
            DataTable dt;
            dt = ClassAppointment.GetAllAppointmentInfoSql(appointmentId);
            DataRow datarow = dt.Rows[0];//since we re expecting one row of return

            return DataTableRowToObject(datarow);
        }
        private static List<ClassAppointment> DataTableToList(DataTable dt)//in case of mutiple appointment
        {
            List<ClassAppointment> list = new List<ClassAppointment>();

            foreach (DataRow datarow in dt.Rows)
            {
                ClassAppointment appointment = DataTableRowToObject(datarow);
                list.Add(appointment);
            };
            return list;
        }


        private static ClassAppointment DataTableRowToObject(DataRow datarow)
        {

            ClassAppointment DesiredApp = new ClassAppointment();


            DesiredApp.AppointmentID = Convert.ToInt32(datarow["appointment_id"]);//noway ykun bel db fi client ma endo clientid


            if (!(datarow["client_id"] is DBNull))
            {
                //less time men el fawea this method
                DesiredApp.DesiredClient = new ClassClientCustom();
                DataTable dtClient = ClassClientCustom.GetAllClientsInfoSQL(Convert.ToInt32(datarow["client_id"]));

                DesiredApp.DesiredClient.ClientId = Convert.ToInt32(dtClient.Rows[0]["client_id"]);//noway ykun bel db fi client ma endo clientid
                DesiredApp.DesiredClient.Fname = dtClient.Rows[0]["name"] is DBNull ? null : (string)dtClient.Rows[0]["name"];
                DesiredApp.DesiredClient.Lname = dtClient.Rows[0]["family_name"] is DBNull ? null : (string)dtClient.Rows[0]["family_name"];
                DesiredApp.DesiredClient.RegistrationDate = dtClient.Rows[0]["Registration_Date"] is DBNull ? null : Convert.ToDateTime(dtClient.Rows[0]["Registration_Date"]);//kermel eza shataryna package with Membership
                DesiredApp.DesiredClient.TotalBalance = (double)dtClient.Rows[0]["total_balance"];//noway ykun bel db fi client ma endo totalBalance;
            }


            DesiredApp.DesiredEmployee = ClassEmployee.CreateEmployeeObject(Convert.ToInt32(datarow["employee_id"]));
            DesiredApp.Title = datarow["title"] is DBNull ? null : (string)datarow["title"];
            DesiredApp.Notes = datarow["Note"] is DBNull ? null : (string)datarow["Note"];


            DesiredApp.StartTime = Convert.ToDateTime(datarow["start_time"]);
            DesiredApp.EndTime = Convert.ToDateTime(datarow["end_time"]);


            DesiredApp.IsCompleted = Convert.ToBoolean(datarow["is_completed"]);
            DesiredApp.IsCanceled = Convert.ToBoolean(datarow["is_canceled"]);

            DesiredApp.IsPackageMode = Convert.ToBoolean(datarow["is_package_mode"]);

            if (!(datarow["client_balance_id"] is DBNull))
            {
                //this one will be used if present or future
                DesiredApp.DesiredClientBalance = ClassClientBalance.CreateClientBalanceObject(Convert.ToInt32(datarow["client_balance_id"]));
                DesiredApp.DesiredClientBalance.SetStringDetailsIfBundle();
            }

            DesiredApp.HistoryClientBalance = datarow["history_client_balance"] is DBNull ? null : (string)datarow["history_client_balance"];


            DataTable ChosenBundles = GetAllChosenSoloBundles(DesiredApp.AppointmentID);
            if (ChosenBundles.Rows.Count > 0)
            {
                List<ClassBundles> bundles = new List<ClassBundles>();
                foreach (DataRow dr in ChosenBundles.Rows)
                {
                    bundles.Add(ClassBundles.CreateBundleObject(Convert.ToInt32(dr["bundle_id"])));
                }
                DesiredApp.ChosenBundlesList = bundles;//ased eemelneha kermel yenkhalae el string ma3a
            }

            // baaed fi bundle object detection 

            return DesiredApp;
        }
        // Method to clone the object

        public ClassAppointment Copy()
        {
            var copy = (ClassAppointment)this.MemberwiseClone();

            // Perform deep copy on reference-type properties
            if (this.DesiredClient != null)
            {
                copy.DesiredClient = this.DesiredClient.Copy(); // Assuming ClassClientCustom has a Copy method
            }
            if (this.DesiredClientBalance != null)
            {
                copy.DesiredClientBalance = this.DesiredClientBalance.Copy(); // Assuming ClassClientBalance has a Copy method
            }
            if (this.ChosenBundlesList != null)
            {
                List<ClassBundles> BundleList = new List<ClassBundles>(this.ChosenBundlesList.Count);
                foreach (var bundle in this.ChosenBundlesList)
                {
                    BundleList.Add(bundle.Copy()); // Assuming ClassBundles has a Copy method
                }
                copy.ChosenBundlesList = BundleList;//kermel el string yenaamalo set deghre
            }

            // Continue with other reference types as necessary

            return copy;

        }
    }
}
