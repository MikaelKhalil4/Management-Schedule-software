using CustomizedTools;
using GlobalFunctions;
using MKproject.Management;
using MKproject.Schedule.Reminderform;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class ClientReminder : Form
    {
        public bool DisableClosingOnDisactivating;
        public bool IsCompletedButtonMode;
        private ClassClientCustom desiredclient;
        public ClassClientCustom DesiredClient
        {
            get { return desiredclient; }
            set
            {
                desiredclient = value;

            }
        }

        public DataTable datatablereminder { get; set; }

        ScheduleForm schedule;
        UCSchedule ucday;
        public  Label LabelNoReminder;


        public Label LoadLabel;
        List<UCreminder> ListUCReminders = new List<UCreminder>();
        private int MaxDisplayUCReminders = 3;

        public ClientReminder()
        {
            InitializeComponent();
        }   
        public ClientReminder(ClassClientCustom desiredclient, ScheduleForm form1, UCSchedule uc1)
        {
            InitializeComponent();
            schedule = form1;
            ucday = uc1;
            LabelNoReminder = GetNoReminderLable("N/A");
            LoadLabel = GetLoadLabel();

            ucSlideButtonCompleted.Button1Clicked += UcSlideButtonCompleted_Button1Clicked;
            ucSlideButtonCompleted.Button2Clicked += UcSlideButtonCompleted_Button2Clicked;

            IsCompletedButtonMode = false;
            DesiredClient = desiredclient;
        }

        private void ClientReminder_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                panelreminder.VerticalScroll.Value = 0;
                panelreminder.PerformLayout(); // Forces the panel to update its layout if necessary
            });
            DisplayUCReminder(desiredclient);

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
        private void UcSlideButtonCompleted_Button1Clicked(object sender, EventArgs e)
        {
            if (ucSlideButtonCompleted.ClickedButton != ucSlideButtonCompleted.button1)
            {
                IsCompletedButtonMode = false;
                DisplayUCReminder(DesiredClient);
            }
        }
        private void UcSlideButtonCompleted_Button2Clicked(object sender, EventArgs e)
        {
            if (ucSlideButtonCompleted.ClickedButton != ucSlideButtonCompleted.button2)
            {
                IsCompletedButtonMode = true;
                DisplayUCReminder(DesiredClient);
            }
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
                datatablereminder = ClassReminder.DisplayReminder(IsCompletedButtonMode);
            }
            else
            {
                textBoxSearch.Text = desiredclient.Fname + " " + desiredclient.Lname;
                DesiredClient = desiredclient;
                datatablereminder = ClassReminder.DisplayReminderByClientName(DesiredClient, IsCompletedButtonMode);
            }

            int counter = 0;

            foreach (DataRow dr in datatablereminder.Rows)
            {
                if (counter >= MaxDisplayUCReminders)
                {
                    panelreminder.Controls.Add(LoadLabel);
                    break;
                }

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
                ListUCReminders.Add(ucreminder);
                counter++;
            }

            for (int i = 0; i < ListUCReminders.Count; i++)
            {
                var ucreminder = ListUCReminders[i];
                panelreminder.Controls.SetChildIndex(ucreminder, i);
            }
            panelreminder.Controls.SetChildIndex(LoadLabel, ListUCReminders.Count);

            if (datatablereminder.Rows.Count == 0)
            {
                panelreminder.Controls.Add(LabelNoReminder);
            }
            Cursor = Cursors.Default;
        }
        public Label GetLoadLabel()
        {
            Label loadLable = new Label();
            // Set the properties
            loadLable.BackColor = Program.MediumColor;
            loadLable.Cursor = Cursors.Hand;
            loadLable.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular);
            loadLable.TextAlign = ContentAlignment.MiddleCenter;
            loadLable.Text = "Show More";
            loadLable.AutoSize = false;
            loadLable.Dock = DockStyle.Top;
            loadLable.Click += new EventHandler(LoadLabel_Click);
            return loadLable;
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


        private void LoadLabel_Click(object sender, EventArgs e)
        {
            panelreminder.Controls.Remove(LoadLabel);

            int NumberOfAddingUCReminder = 10;
            int startRow = panelreminder.Controls.Count-1;
            int endRow = startRow + NumberOfAddingUCReminder;

            bool NoMoreLoad = endRow > datatablereminder.Rows.Count - 1;
            endRow = Math.Min(endRow, datatablereminder.Rows.Count - 1);

            for (int i = startRow; i <= endRow; i++)
            {
                DataRow dr = datatablereminder.Rows[i];
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

                UCreminder ucreminder = new UCreminder(DesiredReminder, ucday, schedule, this);
                ucreminder.Dock = DockStyle.Top;
                panelreminder.Controls.Add(ucreminder);
            }

            if (NoMoreLoad == false)
            {
                panelreminder.Controls.Add(LoadLabel);
                panelreminder.Controls.SetChildIndex(LoadLabel, 4);
            }
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
            if (!DisableClosingOnDisactivating)
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
