using MKproject.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Controls;

namespace MKproject.Schedule.Reminderform
{
    public class ClassReminder
    {
        //Property
        public int Idreminder { get; set; }
        public string Reminder { get; set; }
        public ClassClientCustom DesiredClient { get; set; }

        public string[] PartsRepeat { get; set; }
        private string repeat;
        public string Repeat
        {
            get { return repeat; }
            set
            {
                repeat = value;
                PartsRepeat = Repeat.Split('/');
            }
        }

        public DateTime StartTime { get; set; }

        //Awal ma yenkhala2 is checked ha ykou false
        private bool ischecked = false;
        public bool IsChecked
        {
            get
            {
                return ischecked;
            }
            set
            {
                ischecked = value;
            }
        }

        //SQL
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);


        //Reminder
        public static DataTable DisplayReminder(bool IsChecked)
        {
            SQLiteCommand command1 = new SQLiteCommand(@"SELECT reminder.*, client.name , client.family_name, client.phone_number
                                                         FROM reminder
                                                         LEFT JOIN client ON reminder.client_id = client.client_id
                                                         WHERE is_checked = @is_checked
                                                         ORDER BY CASE WHEN is_checked = 1 THEN 0 ELSE 1 END, starttime ASC", con);
            command1.Parameters.AddWithValue("@is_checked", IsChecked);
            SQLiteDataAdapter adapter1 = new SQLiteDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["reminder_id"] };
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;
        }
        public static DataTable DisplayReminderInASpecificDate(DateTime SelectedDate, DateTime? StartDate, DateTime? EndDate)
        {
            string query = @"WITH DayName AS (
            SELECT CASE strftime('%w', DATE(@SelectedDate))
            WHEN '0' THEN 'Sunday'
            WHEN '1' THEN 'Monday'
             WHEN '2' THEN 'Tuesday'
             WHEN '3' THEN 'Wednesday'
            WHEN '4' THEN 'Thursday'
            WHEN '5' THEN 'Friday'
            WHEN '6' THEN 'Saturday'
            END AS day_name)
         SELECT reminder.*, client.name, client.family_name, client.phone_number
         FROM reminder
         LEFT JOIN client ON reminder.client_id = client.client_id
         LEFT JOIN DayName ON INSTR(reminder.repeat, DayName.day_name) > 0 WHERE 1=1 ";

            if (EndDate == null)
            {
                query += @"
            AND (
                       (reminder.repeat = 'Does not repeat' AND DATE(reminder.starttime) = DATE(@SelectedDate))
                       OR
                       (reminder.repeat = 'Every day' AND DATE(reminder.starttime) <= DATE(@SelectedDate))
                       OR
                       (reminder.repeat LIKE 'Every week%' AND INSTR(reminder.repeat, DayName.day_name) > 0 AND DATE(reminder.starttime) <= DATE(@SelectedDate))
                )";
            }
            else
            {
                query += @" 
        AND (  
         
                   (reminder.repeat = 'Does not repeat'  AND DATE(reminder.starttime) <= DATE(@EndDate) AND DATE(reminder.starttime) >= DATE(@StartDate))             
                   OR
                   (reminder.repeat = 'Every day' AND  DATE(reminder.starttime) <= DATE(@EndDate))
                   OR
                  (reminder.repeat LIKE 'Every week%' AND DATE(reminder.starttime) <= DATE(@EndDate))
            )
            ";
            }

            query += " ORDER BY CASE WHEN is_checked = 1 THEN 0 ELSE 1 END, starttime ASC";



            SQLiteCommand command1 = new SQLiteCommand(query, con);

            command1.Parameters.AddWithValue("@SelectedDate", SelectedDate.ToString("yyyy-MM-dd"));

            if (StartDate != null && EndDate != null)
            {
                command1.Parameters.AddWithValue("@StartDate", ((DateTime)StartDate).ToString("yyyy-MM-dd"));
                command1.Parameters.AddWithValue("@EndDate", ((DateTime)EndDate).ToString("yyyy-MM-dd"));
            }
            SQLiteDataAdapter adapter1 = new SQLiteDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["reminder_id"] };
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;
        }
        public static DataTable DisplayReminderByClientName(ClassClientCustom DesiredClient, bool IsChecked)
        {
            SQLiteCommand command1 = new SQLiteCommand(@"SELECT reminder_id, reminder, repeat, starttime, is_checked
                                                         FROM reminder
                                                         WHERE client_id = @client_id AND is_checked = @is_checked
                                                         ORDER BY CASE WHEN is_checked = 1 THEN 0 ELSE 1 END, starttime ASC", con);
            command1.Parameters.AddWithValue("@client_id", DesiredClient.ClientId);
            command1.Parameters.AddWithValue("@is_checked", IsChecked);
            SQLiteDataAdapter adapter1 = new SQLiteDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["reminder_id"] };
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;
        }


        public void AddRemindertoSQL()
        {
            int idreminder;
            IsChecked = false;

            SQLiteCommand command = new SQLiteCommand("INSERT INTO reminder  (client_id,reminder,repeat,starttime,is_checked)  VALUES (@client_id,@reminder,@repeat,@starttime,@is_checked) ", con);
            SQLiteCommand cmd = new SQLiteCommand("SELECT Max(reminder_id) FROM reminder", con);


            command.Parameters.AddWithValue("@reminder", Reminder);
            if (DesiredClient != null)
            {
                command.Parameters.AddWithValue("@client_id", DesiredClient.ClientId);
            }
            else
            {
                command.Parameters.AddWithValue("@client_id", DBNull.Value);
            }
            command.Parameters.AddWithValue("@repeat", Repeat);
            command.Parameters.AddWithValue("@starttime", StartTime.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@is_checked", IsChecked);

            con.Open();
            command.ExecuteNonQuery();//first command       
            Idreminder = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }
        public void UpdateFromRemindertoSQL()
        {
            SQLiteCommand command = new SQLiteCommand("UPDATE reminder SET client_id=@client_id,reminder=@reminder, repeat=@repeat, starttime=@starttime WHERE reminder_id =@reminder_id", con);


            command.Parameters.AddWithValue("@reminder", Reminder);
            if (DesiredClient != null)
            {
                command.Parameters.AddWithValue("@client_id", DesiredClient.ClientId);
            }
            else
            {
                command.Parameters.AddWithValue("@client_id", DBNull.Value);
            }
            command.Parameters.AddWithValue("@repeat", Repeat);
            command.Parameters.AddWithValue("@starttime", StartTime.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@is_checked", IsChecked);
            command.Parameters.AddWithValue("@reminder_id", Idreminder);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteReminderSQL()
        {
            SQLiteCommand command = new SQLiteCommand("DELETE FROM reminder WHERE reminder_id = @value1 ", con);
            command.Parameters.AddWithValue("@value1", Idreminder);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public void checkBoxReminderChangedToSQL()
        {
            SQLiteCommand command = new SQLiteCommand(@"UPDATE reminder
                                                  SET is_checked=@is_checked
                                                  WHERE reminder_id =@reminder_id", con);
            command.Parameters.AddWithValue("@is_checked", IsChecked);
            command.Parameters.AddWithValue("@reminder_id", Idreminder);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
