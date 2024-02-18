using System;
using System.Data.SqlClient;
using System.Data;

namespace MKproject.Schedule
{
    public class ProjectToSqlSchedule
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);

        //HistoryCoachavailibility
        public static void UpdateHistoryCoachavailibility(DateTime history_date, string rank_coaches, string availability_coaches)
        {
            SqlCommand command = new SqlCommand("UPDATE history_coach_availability SET rank_coaches=@rank_coaches, availability_coaches=@availability_coaches WHERE history_date =@history_date", con);

            command.Parameters.AddWithValue("@history_date", history_date);
            command.Parameters.AddWithValue("@rank_coaches", rank_coaches);
            command.Parameters.AddWithValue("@availability_coaches", availability_coaches);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void InsertHistoryCoachavailibility(DateTime history_date, string rank_coaches, string availability_coaches)
        {

           
            SqlCommand command = new SqlCommand(@"INSERT INTO history_coach_availability (history_date, rank_coaches, availability_coaches) 
                                                                  VALUES (@history_date,@rank_coaches,@availability_coaches) ", con);
         
            command.Parameters.AddWithValue("@history_date", history_date);
            command.Parameters.AddWithValue("@rank_coaches", rank_coaches);
            command.Parameters.AddWithValue("@availability_coaches", availability_coaches);
          

            con.Open();
            command.ExecuteNonQuery();//first command
            con.Close();
        }



        //CoachAvailability
        public static void UpdateCoachAvailabilitySQL(int Availability_id,string Availability)
        {
            SqlCommand command = new SqlCommand("UPDATE coach_availability SET availability=@availability  WHERE availability_id = @availability_id", con);
            command.Parameters.AddWithValue("@availability", Availability);
            command.Parameters.AddWithValue("@availability_id", Availability_id);

           
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateRankNIsCheckedCoachAvailabilitySQL(DataTable DataTableCoachavailability)
        {
            foreach (DataRow row in DataTableCoachavailability.Rows)
            {
                int availabilityId = Convert.ToInt32(row["availability_id"]); // Assuming column name is 'availablity_id'
                int newRank = Convert.ToInt32(row["rank"]); // Replace 'new_rank' with your new rank column name
                bool isChecked = Convert.ToBoolean(row["is_checked"]); // Replace 'is_checked' with your is checked column name

                // Construct the SQL query for updating
                string updateQuery = "UPDATE coach_availability SET rank = @rank, is_checked = @is_checked WHERE availability_id = @availability_id";

                // Create and configure the SqlCommand
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@availability_id", availabilityId);
                    cmd.Parameters.AddWithValue("@rank", newRank);
                    cmd.Parameters.AddWithValue("@is_checked", isChecked);

                    // Open the connection and execute the command
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }



        //Appointments
        public static int AddFromAppoitementtoSQL(int coach_id, int? client_id, DateTime start_time, DateTime end_time, string Note, bool onpending, string clienttype)
        {
            int idappointment;
            SqlCommand command = new SqlCommand(@"INSERT INTO appointments (coach_id,client_id,start_time,end_time,Note,onpending,client_type,isappointment) 
                                                                  VALUES (@coach_id,@client_id,@start_time, @end_time, @Note, @onpending, @client_type, @isappointment) ", con);
            SqlCommand cmd = new SqlCommand("SELECT Max(appointment_id) FROM appointments", con);
            //string[] parts = fullname.Split(' ');
         
            command.Parameters.AddWithValue("@coach_id", coach_id);
            command.Parameters.AddWithValue("@client_id", client_id);
            command.Parameters.AddWithValue("@start_time", start_time);
            command.Parameters.AddWithValue("@end_time", end_time);
            command.Parameters.AddWithValue("@Note", Note);
            command.Parameters.AddWithValue("@onpending", onpending);
            command.Parameters.AddWithValue("@client_type", clienttype);
            command.Parameters.AddWithValue("@isappointment", true);


            con.Open();
            command.ExecuteNonQuery();//first command
            object result = cmd.ExecuteScalar();//return the first cell
            int.TryParse(result.ToString(), out idappointment);//we got the idtime second command
            con.Close();

            return idappointment;

        }
        public static void UpdateFromAppoitementtoSQL(int idappointment, int? idclient, DateTime starttime, DateTime endtime, string notes, bool onpending, string clienttype)
        {
            SqlCommand command = new SqlCommand(@"UPDATE appointments
                                                  SET client_id=@client_id, start_time=@start_time, end_time=@end_time, Note=@Note, onpending=@onpending,client_type=@client_type
                                                  WHERE appointment_id =@appointment_id", con);


            command.Parameters.AddWithValue("@client_id", idclient);
            command.Parameters.AddWithValue("@start_time", starttime);
            command.Parameters.AddWithValue("@end_time", endtime);
            command.Parameters.AddWithValue("@Note", notes);
            command.Parameters.AddWithValue("@onpending", onpending);
            command.Parameters.AddWithValue("@client_type", clienttype);
            command.Parameters.AddWithValue("@appointment_id", idappointment);


            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void DeleteAppointment(int idappointment)
        {
            SqlCommand command = new SqlCommand("DELETE FROM appointments WHERE appointment_id = @value1 ", con);
            command.Parameters.AddWithValue("@value1", idappointment);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateAppointmentCheck(int idappointment,bool onpending)
        {
            SqlCommand command = new SqlCommand(@"UPDATE appointments
                                                  SET onpending=@onpending
                                                  WHERE appointment_id =@appointment_id", con);
            command.Parameters.AddWithValue("@onpending", onpending);
            command.Parameters.AddWithValue("@appointment_id", idappointment);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }



        //Meeting
        public static int AddFromMeetingtoSQL(int idcoach, string title, DateTime starttime, DateTime endtime, string Note, bool onpending)
        {
            int idmeeting;
            SqlCommand command = new SqlCommand(@"INSERT INTO appointments(coach_id,title,start_time,end_time,Note,onpending,isappointment) 
                                                                  VALUES (@coach_id,@title,@start_time, @end_time, @Note, @onpending, @isappointment) ", con);
            SqlCommand cmd = new SqlCommand("SELECT Max(appointment_id) FROM appointments", con);
            
           
            command.Parameters.AddWithValue("@coach_id", idcoach);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@start_time", starttime);
            command.Parameters.AddWithValue("@end_time", endtime);
            command.Parameters.AddWithValue("@Note", Note);
            command.Parameters.AddWithValue("@onpending", onpending);
            command.Parameters.AddWithValue("@isappointment", false);


            con.Open();
            command.ExecuteNonQuery();//first command
            object result = cmd.ExecuteScalar();//return the first cell
            int.TryParse(result.ToString(), out idmeeting);//we got the idtime second command
            con.Close();

            return idmeeting;

        }
        public static void UpdateFromMeetingtoSQL(int idmeeting, string title, DateTime starttime, DateTime endtime, string note, bool onpending)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Appointment
                                                  SET title=@title, start_time=@start_time, end_time=@end_time, Note=@Note, onpending=@onpending
                                                  WHERE appointment_id =@appointment_id", con);

            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@start_time", starttime);
            command.Parameters.AddWithValue("@end_time", endtime);
            command.Parameters.AddWithValue("@Note", note);
            command.Parameters.AddWithValue("@onpending", onpending);
            command.Parameters.AddWithValue("@appointment_id", idmeeting);


            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void DeleteMeeting(int idmeeting)
        {
            SqlCommand command = new SqlCommand("DELETE FROM appointments WHERE appointment_id = @value1 ", con);
            command.Parameters.AddWithValue("@value1", idmeeting);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateMeetingCheck(int idmeeting, bool onpending)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Appointment
                                                  SET onpending=@onpending
                                                  WHERE appointment_id =@appointment_id", con);
            command.Parameters.AddWithValue("@onpending", onpending);
            command.Parameters.AddWithValue("@appointment_id", idmeeting);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }



        //Reminder
        public static int AddRemindertoSQL(int? clientid, string reminder, string repeat, DateTime starttime, string labelquote)
        {
            SqlCommand command = new SqlCommand("INSERT INTO reminder VALUES (@client_id,@reminder,@repeat,@starttime,@labelquote,@is_checked) ", con);
            SqlCommand cmd = new SqlCommand("SELECT Max(reminder_id) FROM reminder", con);


            int idreminder;
            bool ischecked = false;
            SqlParameter clientParam = new SqlParameter("@client_id", SqlDbType.Int);
            if (clientid.HasValue)
            {
                clientParam.Value = clientid.Value;
            }
            else
            {
                clientParam.Value = DBNull.Value;
            }


            command.Parameters.AddWithValue("@reminder", reminder);
            command.Parameters.Add(clientParam);
            command.Parameters.AddWithValue("@repeat", repeat);
            command.Parameters.AddWithValue("@starttime", starttime);
            command.Parameters.AddWithValue("@labelquote", labelquote);
            command.Parameters.AddWithValue("@is_checked", ischecked);

            con.Open();
            command.ExecuteNonQuery();//first command
            object result = cmd.ExecuteScalar();//return the first cell
            int.TryParse(result.ToString(), out idreminder);//we got the idreminder second command
            con.Close();

            return idreminder;

        }
        public static void  UpdateFromRemindertoSQL(int idreminder,int? clientid, string reminder, string repeat, DateTime starttime, string labelquote)
        {
            SqlCommand command = new SqlCommand("UPDATE reminder SET client_id=@client_id,reminder=@reminder, repeat=@repeat, starttime=@starttime,labelquote=@labelquote WHERE reminder_id =@reminder_id", con);


            //WE did we can transfer the value in case ClientId is NULL
            SqlParameter clientParam = new SqlParameter("@client_id", SqlDbType.Int);
            if (clientid.HasValue)
            {
                clientParam.Value = clientid.Value;
            }
            else
            {
                clientParam.Value = DBNull.Value;
            }


            command.Parameters.AddWithValue("@reminder", reminder);
            command.Parameters.Add(clientParam);
            command.Parameters.AddWithValue("@repeat", repeat);
            command.Parameters.AddWithValue("@starttime", starttime);
            command.Parameters.AddWithValue("@labelquote", labelquote);
            command.Parameters.AddWithValue("@reminder_id", idreminder);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void  DeleteReminderSQL(int idreminder)
        {
            SqlCommand command = new SqlCommand("DELETE FROM reminder WHERE reminder_id = @value1 ", con);
            command.Parameters.AddWithValue("@value1", idreminder);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static  void checkBoxReminderChangedToSQL(int idreminder,bool ischeck)
        {
            SqlCommand command = new SqlCommand(@"UPDATE reminder
                                                  SET is_checked=@is_checked
                                                  WHERE reminder_id =@reminder_id", con);
            command.Parameters.AddWithValue("@is_checked", ischeck);
            command.Parameters.AddWithValue("@reminder_id", idreminder);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
