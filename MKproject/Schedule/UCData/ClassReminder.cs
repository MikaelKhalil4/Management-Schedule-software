using MKproject.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKproject.Schedule.UCData
{
    public class ClassReminder
    {
        //Property
        public int Idreminder { get; set; }
        public string Reminder { get; set; }
        public ClassClient DesiredClient { get; set; }
      
        public string[] Partsrepeat { get; set; }
        private string repeat;
        public string Repeat
        {
            get { return repeat; }
            set { 
                repeat = value;
                Partsrepeat =Repeat.Split('/');
            }
        }

        public string LabelQuote { get; set; }
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
        static SqlConnection con = new SqlConnection(Program.DataLocation);


        //Reminder
        public static DataTable DisplayReminder()
        {
            SqlCommand command1 = new SqlCommand(@"SELECT reminder.*, client.name , client.family_name, client.phone_number
                                                   FROM reminder
                                                   LEFT JOIN client ON reminder.client_id = client.client_id
                                                   ORDER BY CASE WHEN is_checked = 1 THEN 0 ELSE 1 END, starttime ASC", con);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["reminder_id"] };
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;
        }
        public static DataTable DisplayReminderInASpecificDate(DateTime SelectedDate)
        {
            SqlCommand command1 = new SqlCommand(@"SELECT reminder.*, client.name, client.family_name, client.phone_number
                                                   FROM reminder
                                                   LEFT JOIN client ON reminder.client_id = client.client_id
                                                   WHERE
                                                   (
                                                       -- No Repeat: Reminder should occur only once on the exact date.
                                                       (reminder.repeat = 'Does not repeat' AND CAST(reminder.starttime AS date) = @SELECTED_DATE)

                                                       OR

                                                       -- Everyday: Reminder repeats daily starting from the starttime onward.
                                                       (reminder.repeat = 'Every day' AND CAST(reminder.starttime AS date) <= @SELECTED_DATE)

                                                       OR

                                                       -- Every Week: Checks if the current day is one of the specified weekdays in the repeat pattern.
                                                       (reminder.repeat LIKE 'Every week%' AND CAST(reminder.starttime AS date) <= @SELECTED_DATE
                                                       AND CHARINDEX(DATENAME(dw, @SELECTED_DATE), reminder.repeat) > 0)
                                                   )
                                                   ORDER BY CASE WHEN is_checked = 1 THEN 0 ELSE 1 END, starttime ASC", con);

            command1.Parameters.AddWithValue("@SELECTED_DATE", SelectedDate.Date);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["reminder_id"] };
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;
        }
        public static DataTable DisplayReminderByClientName(ClassClient DesiredClient)
        {
            SqlCommand command1 = new SqlCommand(@"SELECT reminder_id, reminder, repeat, starttime, labelquote, is_checked
                                                   FROM reminder
                                                   WHERE client_id = @client_id
                                                   ORDER BY CASE WHEN is_checked = 1 THEN 0 ELSE 1 END, starttime ASC", con);
            command1.Parameters.AddWithValue("@client_id", DesiredClient.ClientId);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["reminder_id"] };
            con.Open();
            command1.ExecuteNonQuery();
            con.Close();
            return dt1;
        }


        public  void AddRemindertoSQL()
        {
            int idreminder;
            IsChecked = false;

            SqlCommand command = new SqlCommand("INSERT INTO reminder VALUES (@client_id,@reminder,@repeat,@starttime,@labelquote,@is_checked) ", con);
            SqlCommand cmd = new SqlCommand("SELECT Max(reminder_id) FROM reminder", con);
          

            command.Parameters.AddWithValue("@reminder", Reminder);
            if(DesiredClient != null)
            {
                command.Parameters.AddWithValue("@client_id", DesiredClient.ClientId);
            }
            else
            {
                command.Parameters.AddWithValue("@client_id",DBNull.Value);
            }
            command.Parameters.AddWithValue("@repeat", Repeat);
            command.Parameters.AddWithValue("@starttime", StartTime);
            command.Parameters.AddWithValue("@labelquote", LabelQuote);
            command.Parameters.AddWithValue("@is_checked", IsChecked);

            con.Open();
            command.ExecuteNonQuery();//first command
            object result = cmd.ExecuteScalar();//return the first cell
            int.TryParse(result.ToString(), out idreminder);//we got the idreminder second command
            con.Close();

            Idreminder = idreminder;

        }
        public  void UpdateFromRemindertoSQL()
        {
            SqlCommand command = new SqlCommand("UPDATE reminder SET client_id=@client_id,reminder=@reminder, repeat=@repeat, starttime=@starttime,labelquote=@labelquote WHERE reminder_id =@reminder_id", con);


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
            command.Parameters.AddWithValue("@starttime", StartTime);
            command.Parameters.AddWithValue("@labelquote", LabelQuote);
            command.Parameters.AddWithValue("@is_checked", IsChecked);
            command.Parameters.AddWithValue("@reminder_id", Idreminder);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public  void DeleteReminderSQL()
        {
            SqlCommand command = new SqlCommand("DELETE FROM reminder WHERE reminder_id = @value1 ", con);
            command.Parameters.AddWithValue("@value1", Idreminder);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public  void checkBoxReminderChangedToSQL()
        {
            SqlCommand command = new SqlCommand(@"UPDATE reminder
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
