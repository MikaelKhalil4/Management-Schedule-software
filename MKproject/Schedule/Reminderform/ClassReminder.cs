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
using Amazon.S3.Model;

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
        public DateTime ModifiedDate { get; set; }

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


        //Reminder
        public static DataTable DisplayReminder(bool IsChecked)
        {
            var command1 = Program.CreateCommand(@"SELECT reminder.*, client.name, client.family_name, client.phone_number
                                                        FROM reminder
                                                        LEFT JOIN client ON reminder.client_id = client.client_id
                                                        WHERE is_checked = @is_checked
                                                        ORDER BY modified_date DESC");
            command1.AddWithValue("@is_checked", IsChecked);
            var adapter1 = Program.CreateDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["reminder_id"] };
            Program.conOpen();
            command1.ExecuteNonQuery();
            Program.con.Close();
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
            {//DATE(reminder.checked_date) can be a null value 
                query += @"
            AND (
                       (reminder.repeat = 'Does not repeat' AND DATE(reminder.starttime) = DATE(@SelectedDate))
                       OR
                       (  reminder.repeat = 'Every day' AND ( (DATE(reminder.starttime) <= DATE(@SelectedDate) AND  is_checked = 0) OR (DATE(reminder.checked_date) = DATE(@SelectedDate) AND  is_checked = 1) ) )
                       OR
                       (reminder.repeat LIKE 'Every week%' AND ( ( INSTR(reminder.repeat, DayName.day_name) > 0 AND DATE(reminder.starttime) <= DATE(@SelectedDate)  AND  is_checked = 0) OR (DATE(reminder.checked_date) = DATE(@SelectedDate) AND  is_checked = 1) ))
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

            query += " And is_checked=0 ORDER BY CASE WHEN is_checked = 1 THEN 0 ELSE 1 END, modified_date DESC";//el order by case ma ela aaze, unless shelet is_checked=0



            var command1 = Program.CreateCommand(query);

            command1.AddWithValue("@SelectedDate", SelectedDate.ToString("yyyy-MM-dd"));

            if (StartDate != null && EndDate != null)
            {
                command1.AddWithValue("@StartDate", ((DateTime)StartDate).ToString("yyyy-MM-dd"));
                command1.AddWithValue("@EndDate", ((DateTime)EndDate).ToString("yyyy-MM-dd"));
            }
            var adapter1 = Program.CreateDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["reminder_id"] };
            Program.conOpen();
            command1.ExecuteNonQuery();
            Program.con.Close();
            return dt1;
        }


        //ORDER BY CASE WHEN is_checked = 1 THEN 0 ELSE 1 END, starttime ASC
        public static DataTable DisplayReminderByClientName(ClassClientCustom DesiredClient, bool IsChecked)
        {
            var command1 = Program.CreateCommand(@"SELECT reminder_id, reminder, repeat, starttime, is_checked
                                                         FROM reminder
                                                         WHERE client_id = @client_id AND is_checked = @is_checked
                                                         ORDER BY modified_date DESC");
            command1.AddWithValue("@client_id", DesiredClient.ClientId);
            command1.AddWithValue("@is_checked", IsChecked);
            var adapter1 = Program.CreateDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["reminder_id"] };
            Program.conOpen();
            command1.ExecuteNonQuery();
            Program.con.Close();
            return dt1;
        }


        public void AddRemindertoSQL()
        {
            int idreminder;
            IsChecked = false;

            var command = Program.CreateCommand("INSERT INTO reminder  (client_id,reminder,repeat,starttime,is_checked,modified_date)  VALUES (@client_id,@reminder,@repeat,@starttime,@is_checked,@modified_date) ");
            var cmd = Program.CreateCommand("SELECT Max(reminder_id) FROM reminder");


            command.AddWithValue("@reminder", Reminder);
            if (DesiredClient != null)
            {
                command.AddWithValue("@client_id", DesiredClient.ClientId);
            }
            else
            {
                command.AddWithValue("@client_id", DBNull.Value);
            }
            command.AddWithValue("@repeat", Repeat);
            command.AddWithValue("@starttime", StartTime.ToString("yyyy-MM-dd"));
            command.AddWithValue("@is_checked", IsChecked);
            command.AddWithValue("@modified_date", ModifiedDate);

            Program.conOpen();
            command.ExecuteNonQuery();//first command       
            Idreminder = Convert.ToInt32(cmd.ExecuteScalar());
            Program.con.Close();
        }
        public void UpdateFromRemindertoSQL()
        {
            var command = Program.CreateCommand("UPDATE reminder SET client_id=@client_id,reminder=@reminder, repeat=@repeat, starttime=@starttime, modified_date=@modified_date WHERE reminder_id =@reminder_id");


            command.AddWithValue("@reminder", Reminder);
            if (DesiredClient != null)
            {
                command.AddWithValue("@client_id", DesiredClient.ClientId);
            }
            else
            {
                command.AddWithValue("@client_id", DBNull.Value);
            }
            command.AddWithValue("@repeat", Repeat);
            command.AddWithValue("@starttime", StartTime.ToString("yyyy-MM-dd"));
            command.AddWithValue("@is_checked", IsChecked);
            command.AddWithValue("@reminder_id", Idreminder);
            command.AddWithValue("@modified_date", ModifiedDate);


            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();
        }
        public void DeleteReminderSQL()
        {
            var command = Program.CreateCommand("DELETE FROM reminder WHERE reminder_id = @value1 ");
            command.AddWithValue("@value1", Idreminder);
            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();
        }
        public void checkBoxReminderChangedToSQL(DateTime? CheckedDate)
        {
            var command = Program.CreateCommand(@"UPDATE reminder 
                                                  SET is_checked=@is_checked,checked_date=@checked_date
                                                  WHERE reminder_id =@reminder_id");
            command.AddWithValue("@is_checked", IsChecked);
            command.AddWithValue("@reminder_id", Idreminder);
            if (CheckedDate != null)
            {
                command.AddWithValue("@checked_date", ((DateTime)CheckedDate).ToString("yyyy-MM-dd"));
            }
            else
            {
                command.AddWithValue("@checked_date", DBNull.Value);
            }
            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();

        }
    }
}
