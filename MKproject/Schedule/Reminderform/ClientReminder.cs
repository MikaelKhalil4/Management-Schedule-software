using CustomizedTools;
using MKproject.Management;
using MKproject.Schedule.Reminderform;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class ClientReminder : Form
    {
        public bool DisableClosingOnDisactivating;
        private ClassClientCustom desiredclient;
        public ClassClientCustom DesiredClient
        {
            get { return desiredclient; }
            set
            {
                desiredclient = value;

            }
        }

        public DataTable tablereminder { get; set; }

        ScheduleForm schedule;
        UCSchedule ucday;
        Label LabelNoReminder;



        public ClientReminder()
        {
            InitializeComponent();
        }
        public ClientReminder(ClassClientCustom desiredclient, ScheduleForm form1, UCSchedule uc1)
        {
            InitializeComponent();
            schedule = form1;
            ucday = uc1;

            //panelreminder.PerformLayout();
            DisplayUCReminder(desiredclient);
            panelreminder.VerticalScroll.Value = 0;

        }
        private void ClientReminder_Load(object sender, EventArgs e)
        {
            panelreminder.AutoScroll = true;
            panelreminder.AutoScrollPosition = new System.Drawing.Point(0, 0);

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Program.GreyFormJunior = new GreyColor(this, true, true, null);
            Program.GreyFormJunior.Show();
            Reminder reminder = new Reminder(schedule, ucday, this);
            reminder.Show();
        }
        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            DisableClosingOnDisactivating = true;
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
            DisableClosingOnDisactivating = false;
        }


        private void DisplayUCReminder(ClassClientCustom desiredclient)
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
                DesiredReminder.Idreminder = Convert.ToInt32(dr["reminder_id"]);
                if (desiredclient == null && dr["client_id"] != DBNull.Value)
                {
                    DesiredReminder.DesiredClient = new ClassClientCustom();
                    DesiredReminder.DesiredClient.ClientId = Convert.ToInt32(dr["client_id"]);
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
                DesiredReminder.StartTime = Convert.ToDateTime(dr["starttime"]);
                DesiredReminder.IsChecked = Convert.ToBoolean(dr["is_checked"]);


                UCreminder ucreminder = new UCreminder(DesiredReminder, ucday, schedule, this);//zedna true kermel naeemela construction khas la ela
                ucreminder.Dock = DockStyle.Top;
                panelreminder.Controls.Add(ucreminder);
            }
            if (tablereminder.Rows.Count == 0)
            {
                LabelNoReminder = GetNoReminderLable("N/A");
                panelreminder.Controls.Add(LabelNoReminder);
            }

            Cursor = Cursors.Default;
            panelreminder.VerticalScroll.Value = 0;
            panelreminder.AutoScroll = false;
            panelreminder.AutoScroll = true;
            panelreminder.AutoScrollPosition = new Point(0, 0);
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

        private void ClientReminder_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .1;
        }

        private void ClientReminder_Deactivate(object sender, EventArgs e)
        {
            if(!DisableClosingOnDisactivating)
            this.Close();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}
