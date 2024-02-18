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

        public ClientReminder()
        {
            InitializeComponent();
        }
        public ClientReminder(int? clientid, string clientname, Schedule form1, UCDay uc1)
        {
            InitializeComponent();
            ClientId = clientid;
            ClientName = clientname;
            schedule = form1;
            ucday = uc1;
            panelreminder.Controls.Clear();
            tablereminder = SQLToProject.DisplayReminderByClientName(ClientId);
            foreach (DataRow dr in tablereminder.Rows)
            {
                UCreminder ucreminder = new UCreminder((int)dr[0], ClientId, (string)dr[1], (string)dr[2], (DateTime)dr[3], (string)dr[4], (bool)dr[5], ClientName, ucday, schedule, true, this);//zedna true kermel naeemela construction khas la ela
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
