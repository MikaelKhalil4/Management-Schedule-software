using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
using MKproject.Schedule.Reminderform;
using CustomizedTools;
using GlobalFunctions;
using System.Linq;

namespace MKproject.Schedule
{
    public partial class UCreminder : UserControl
    {
        //SQL
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);
        Color ColorCompletedReminedr = Color.FromArgb(124, 218, 124);
        //PROPERTY:
        private ClassReminder desiredreminder;
        public ClassReminder DesiredReminder
        {
            get
            {
                return desiredreminder;
            }
            set
            {
                desiredreminder = value;
                checkBoxReminder.Checked = desiredreminder.IsChecked;
                if (checkBoxReminder.Checked)
                {
                    this.panelColoredReminder.BackColor = ColorCompletedReminedr;
                }
                checkBoxReminder.Text = desiredreminder.Reminder;
                if (desiredreminder.DesiredClient == null)
                {
                    linkLabelName.Visible = false;
                }
                else if (Isclientreminder)
                {
                    linkLabelName.Visible = true;
                    linkLabelName.Enabled = false;
                    linkLabelName.Text = desiredreminder.DesiredClient.Fname + " " + desiredreminder.DesiredClient.Lname;
                }
                else
                {
                    linkLabelName.Visible = true;
                    linkLabelName.Enabled = true;
                    linkLabelName.Text = desiredreminder.DesiredClient.Fname + " " + desiredreminder.DesiredClient.Lname;
                }

                if (desiredreminder.PartsRepeat[0] == Reminder.NoRepeat)
                {
                    LabelReminderType.Text = desiredreminder.StartTime.ToString("dddd");
                }
                else if (desiredreminder.PartsRepeat[0] == Reminder.Everyday)
                {
                    LabelReminderType.Text = "Daily Repetition";
                }
                else
                {
                    LabelReminderType.Text = "Weekly Repetition";
                }

            }
        }

        //Variables:
        UCSchedule ucday;
        ScheduleForm schedule;
        ClientReminder clientReminder;
        bool Isclientreminder;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        //Initialise
        public UCreminder()
        {
            InitializeComponent();
        }

        //In Schedule
        //we want to add a ucreminder or we want to display from SQL
        public UCreminder(ClassReminder desiredReminder, UCSchedule ucschedule, ScheduleForm scheduleform)
        {
            InitializeComponent();
            Isclientreminder = false;
            DesiredReminder = desiredReminder;

            ucday = ucschedule;
            schedule = scheduleform;

            this.BackColor = scheduleform.panelreminder.BackColor;

        }

        //In ClientReminder(from select SQL once we open ClientReminder or when we ADD in ClientReminder)
        public UCreminder(ClassReminder desiredReminder, UCSchedule ucschedule, ScheduleForm scheduleform, ClientReminder clientreminder)
        {
            InitializeComponent();
            Isclientreminder = true;
            DesiredReminder = desiredReminder;

            clientReminder = clientreminder;
            ucday = ucschedule;
            schedule = scheduleform;

            this.BackColor = clientreminder.panelreminder.BackColor;

            if (DesiredReminder.IsChecked)
            {
                this.panelColoredReminder.BackColor = ColorCompletedReminedr;
            }
            else
            {
                this.panelColoredReminder.BackColor = Color.FromArgb(109, 122, 224);
            }

        }



        //EVENTS
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Reminder reminder;
            if (Isclientreminder)
            {
                Program.GreyFormJunior = new GreyColor(this.clientReminder, true, true, null);
                Program.GreyFormJunior.Show();
                reminder = new Reminder(this, ucday, schedule, Isclientreminder, clientReminder);
            }
            else
            {
                Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
                Program.GreyForm.Show();
                reminder = new Reminder(this, ucday, schedule, Isclientreminder);
            }
            reminder.Show();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (Isclientreminder)
            {
                clientReminder.DisableClosingOnDisactivating = true;
            }

            DialogResult dialogResult = CustomMessageBox.Show("Are You sure Do you want to the delete the reminder?", CustomMessageBox.Type.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //SQL:
                DesiredReminder.DeleteReminderSQL();

                //Design:
                if (Isclientreminder)
                {

                    UCreminder foundUcReminder = ucday.ListUCreminderForTheSelectedDate.Find(uc => uc.DesiredReminder.Idreminder == DesiredReminder.Idreminder);

                    if (foundUcReminder != null)
                    {
                        ucday.ListUCreminderForTheSelectedDate.Remove(foundUcReminder);
                        schedule.panelreminder.Controls.Remove(foundUcReminder);
                        foundUcReminder.Dispose();
                    }

                    clientReminder.panelreminder.Controls.Remove(this);
                    this.Dispose();


                    if (clientReminder.panelreminder.Controls.Count == 0)
                    {
                        clientReminder.panelreminder.Controls.Add(clientReminder.LabelNoReminder);
                    }
                    clientReminder.DisableClosingOnDisactivating = false;
                }
                else
                {
                    ucday.ListUCreminderForTheSelectedDate.Remove(this);
                    schedule.panelreminder.Controls.Remove(this);

                    this.Dispose();
                }
            }

        }
        private void linkLabelName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
            Program.GreyForm.Show();
            ClientReminder clientreminder = new ClientReminder(DesiredReminder.DesiredClient, schedule, ucday);
            clientreminder.Show();
        }
        private void checkBoxReminder_Click(object sender, EventArgs e)
        {
            //BackEnd
            DesiredReminder.IsChecked = checkBoxReminder.Checked;//tghayar l2esem hone bas houwe zeto ousoulan

            DateTime? Checked_Date = null;

            //Design
            if (Isclientreminder)
            {

                if (DesiredReminder.IsChecked)//hone lezim nzido
                {
                    UCreminder foundUcReminder = ucday.ListUCreminderForTheSelectedDate.Find(uc => uc.DesiredReminder.Idreminder == DesiredReminder.Idreminder);//KERMEL NSHIL LI BEL panelreminderschedule
                    if (foundUcReminder != null)
                    {
                        foundUcReminder.DesiredReminder.IsChecked = true;
                        foundUcReminder.checkBoxReminder.Checked = true;
                        foundUcReminder.panelColoredReminder.BackColor = ColorCompletedReminedr;
                    }


                    this.panelColoredReminder.BackColor = ColorCompletedReminedr;
                }
                else
                {
                    UCreminder foundUcReminder = ucday.ListUCreminderForTheSelectedDate.Find(uc => uc.DesiredReminder.Idreminder == DesiredReminder.Idreminder);//KERMEL NSHIL LI BEL panelreminderschedule
                    if (foundUcReminder != null)
                    {
                        foundUcReminder.DesiredReminder.IsChecked = false;
                        foundUcReminder.checkBoxReminder.Checked = false;
                        foundUcReminder.panelColoredReminder.BackColor = Color.FromArgb(109, 122, 224);

                        if (ucday.isThedayofUCreminder(DesiredReminder))
                        {
                            foundUcReminder.Dock = DockStyle.Top;
                            schedule.panelreminder.Controls.Add(foundUcReminder);
                        }
                    }

                    this.panelColoredReminder.BackColor = Color.FromArgb(109, 122, 224);
                }
            }
            else
            {
                if (DesiredReminder.IsChecked)//hone lezim nzido
                {
                    this.panelColoredReminder.BackColor = ColorCompletedReminedr;
                    Checked_Date = ucday.SelectedDate;
                }
                else
                {

                }

            }

            //SQL
            DesiredReminder.checkBoxReminderChangedToSQL(Checked_Date);
        }



        //DESIGN
        private void checkBoxReminder_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxReminder.Checked == false)
            {
                this.panelColoredReminder.BackColor = Color.FromArgb(109, 122, 224);
            }
        }
        private void checkBoxReminder_TextChanged(object sender, EventArgs e)
        {
            FixDesign();
        }

        void FixDesign()
        {
            int DesiredHeight = RandomFunctions.CalculateDesiredHeight(checkBoxReminder, checkBoxReminder.Width-10);
            TLPGlobal.RowStyles[1].Height = DesiredHeight+13;

            this.Height = Convert.ToInt16(TLPGlobal.RowStyles[0].Height + TLPGlobal.RowStyles[1].Height + TLPGlobal.RowStyles[2].Height) + this.Padding.Bottom ;
        }

      
        private void UCreminder_Resize(object sender, EventArgs e)
        {
            FixDesign();

        }
    }
}
