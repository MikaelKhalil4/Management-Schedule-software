using MKproject.Management;
using MKproject.Schedule.UCData;
using System;
using System.Data;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class ClientReminder : Form
    {

        private string clientName;
        public string ClientName
        {
            get { return clientName; }
            set
            {
                clientName = value;
                labelFullName.Text = clientName;
            }
        }

        public DataTable tablereminder { get; set; }
        public int? ClientId { get; set; }
        public TouchScroll TouchscrollPanelclientreminder { get; set; }

        Schedule schedule;
        UCDay ucday;
        ClassClient DesiredClient;
        ClassReminder DesiredReminder;

        public ClientReminder()
        {
            InitializeComponent();
        }
        public ClientReminder(ClassClient desiredclient, Schedule form1, UCDay uc1)
        {
            InitializeComponent();
            DesiredClient = desiredclient;  
            schedule = form1;
            ucday = uc1;
            panelreminder.Controls.Clear();
            //tablereminder = SQLToProject.DisplayReminderByClientName(ClientId);
            foreach (DataRow dr in tablereminder.Rows)
            {
                DesiredReminder.Idreminder = (int)dr[0];
                DesiredReminder.DesiredClient = DesiredClient;
                DesiredReminder.Reminder = (string)dr[1];
                DesiredReminder.Repeat = (string)dr[2];
                DesiredReminder.StartTime = (DateTime)dr[3];
                DesiredReminder.LabelQuote = (string)dr[4];
                DesiredReminder.IsChecked = (bool)dr[5];
                UCreminder ucreminder = new UCreminder(DesiredReminder, ucday, schedule, true, this);//zedna true kermel naeemela construction khas la ela
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Reminder reminder = new Reminder(schedule, ucday, this);
            reminder.ShowDialog();
        }
    }
}
