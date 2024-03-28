using MKproject.Management;
using MKproject.Schedule.UCData;
using System;
using System.Data;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class ClientReminder : Form
    {

        private ClassClient desiredclient;
        public ClassClient DesiredClient
        {
            get { return desiredclient; }
            set
            {
                desiredclient = value;
                labelFullName.Text = desiredclient.Fname + " " + desiredclient.Lname;
            }
        }

        public DataTable tablereminder { get; set; }
        public int? ClientId { get; set; }
        public TouchScroll TouchscrollPanelclientreminder { get; set; }

        ScheduleForm schedule;
        UCDay ucday;
      

        public ClientReminder()
        {
            InitializeComponent();
        }
        public ClientReminder(ClassClient desiredclient, ScheduleForm form1, UCDay uc1)
        {
            InitializeComponent();
            DesiredClient = desiredclient;  
            schedule = form1;
            ucday = uc1;
            panelreminder.Controls.Clear();
            tablereminder = ClassReminder.DisplayReminderByClientName(DesiredClient);
            foreach (DataRow dr in tablereminder.Rows)
            {
                ClassReminder DesiredReminder = new ClassReminder();
                DesiredReminder.Idreminder = (int)dr["reminder_id"];
                DesiredReminder.DesiredClient = DesiredClient;
                DesiredReminder.Reminder = (string)dr["reminder"];
                DesiredReminder.Repeat = (string)dr["repeat"];
                DesiredReminder.StartTime = (DateTime)dr["starttime"];
                DesiredReminder.LabelQuote = (string)dr["labelquote"];
                DesiredReminder.IsChecked = (bool)dr["is_checked"];


                UCreminder ucreminder = new UCreminder(DesiredReminder, ucday, schedule, this);//zedna true kermel naeemela construction khas la ela
                ucreminder.Dock = DockStyle.Top;
                panelreminder.Controls.Add(ucreminder);
            }
            TouchscrollPanelclientreminder = new TouchScroll(panelreminder, this);
            //panelreminder.PerformLayout();
        }
        private void ClientReminder_Load(object sender, EventArgs e)
        {
            panelreminder.AutoScroll = true;
            panelreminder.AutoScrollPosition = new System.Drawing.Point(0, 0);

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Reminder reminder = new Reminder(schedule, ucday, this);
            reminder.ShowDialog();
        }
    }
}
