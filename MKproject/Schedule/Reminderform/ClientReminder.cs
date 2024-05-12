using MKproject.Management;
using MKproject.Schedule.UCData;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class ClientReminder : Form
    {
        public bool DisableClosingOnDisactivating;
        private ClassClient desiredclient;
        public ClassClient DesiredClient
        {
            get { return desiredclient; }
            set
            {
                desiredclient = value;

            }
        }

        public DataTable tablereminder { get; set; }
        public TouchScroll TouchscrollPanelclientreminder { get; set; }

        ScheduleForm schedule;
        UCDay ucday;
        Label LabelNoReminder;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public ClientReminder()
        {
            InitializeComponent();
        }
        public ClientReminder(ClassClient desiredclient, ScheduleForm form1, UCDay uc1)
        {
            InitializeComponent();
            schedule = form1;
            ucday = uc1;

            //panelreminder.PerformLayout();
            DisplayUCReminder(desiredclient);


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
        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            Search searchname = new Search(textBoxSearch, this.DesiredClient);
            searchname.Deactivate += Searchname_Deactivate;
            searchname.ChosenClientChanged += Searchname_ChosenClientChanged;
            Point locationRelativeToScreen = textBoxSearch.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-2, -2);
            searchname.Location = locationRelativeToScreen;
            searchname.Show();
        }


        private void Searchname_ChosenClientChanged(object sender, EventArgs e)
        {
            //reset
            Search searchname = (Search)sender;
            DesiredClient = searchname.NewDesiredClient;
            DisplayUCReminder(DesiredClient);
        }
        private void Searchname_Deactivate(object sender, EventArgs e)
        {
            this.Select();
        }


        private void DisplayUCReminder(ClassClient desiredclient)
        {
            Cursor = Cursors.WaitCursor;
            panelreminder.Controls.Clear();
            if (desiredclient == null)
            {
                tablereminder = ClassReminder.DisplayReminder();
            }
            else
            {
                textBoxSearch.Text = desiredclient.Fname + " " + desiredclient.Lname;
                DesiredClient = desiredclient;
                tablereminder = ClassReminder.DisplayReminderByClientName(DesiredClient);
            }
            foreach (DataRow dr in tablereminder.Rows)
            {
                ClassReminder DesiredReminder = new ClassReminder();
                DesiredReminder.Idreminder = (int)dr["reminder_id"];
                if (desiredclient == null && dr["client_id"] != DBNull.Value)
                {
                    DesiredReminder.DesiredClient = new ClassClient();
                    DesiredReminder.DesiredClient.ClientId = (int)dr["client_id"];
                    DesiredReminder.DesiredClient.Fname = (string)dr["name"];
                    DesiredReminder.DesiredClient.Lname = (string)dr["family_name"];
                    DesiredReminder.DesiredClient.PhoneNumber = (string)dr["phone_number"];
                }
                else
                {
                    DesiredReminder.DesiredClient = DesiredClient;
                }
                DesiredReminder.Reminder = (string)dr["reminder"];
                DesiredReminder.Repeat = (string)dr["repeat"];
                DesiredReminder.StartTime = (DateTime)dr["starttime"];
                DesiredReminder.LabelQuote = (string)dr["labelquote"];
                DesiredReminder.IsChecked = (bool)dr["is_checked"];


                UCreminder ucreminder = new UCreminder(DesiredReminder, ucday, schedule, this);//zedna true kermel naeemela construction khas la ela
                ucreminder.Dock = DockStyle.Top;
                panelreminder.Controls.Add(ucreminder);
            }
            if (tablereminder.Rows.Count == 0)
            {
                LabelNoReminder = GetNoReminderLable("N/A");
                panelreminder.Controls.Add(LabelNoReminder);
            }
            else
            {
                TouchscrollPanelclientreminder = new TouchScroll(panelreminder, this);
            }
            Cursor = Cursors.Default;
        }

        public Label GetNoReminderLable(string Text)//in case we had no bundles
        {
            Label labelNoReminder = new Label();
            labelNoReminder.AutoSize = false;
            labelNoReminder.Dock = DockStyle.Fill;
            labelNoReminder.TextAlign = ContentAlignment.MiddleCenter;
            labelNoReminder.Font = new Font("Segoe UI Semibold", 20.25f, FontStyle.Bold);
            labelNoReminder.BackColor = Color.FromArgb(238, 241, 254);
            labelNoReminder.ForeColor = Color.FromArgb(150, 150, 150);
            labelNoReminder.Text = Text;
            return labelNoReminder;
        }
    }
}
