using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using MKproject.Schedule.UCData;

namespace MKproject.Schedule
{
    public partial class UCreminder : UserControl
    {
        //SQL
        static SqlConnection con = new SqlConnection(Program.DataLocation);

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
            }
        }

        //Variables:
        UCDay ucday;
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
        public UCreminder(ClassReminder desiredReminder, UCDay form1, ScheduleForm form2)
        {
            InitializeComponent();
            Isclientreminder = false;
            DesiredReminder = desiredReminder;

            ucday = form1;
            schedule = form2;

            this.BackColor = Color.FromArgb(249, 246, 254);
        }

        //In ClientReminder(from select SQL once we open ClientReminder or when we ADD in ClientReminder)
        public UCreminder(ClassReminder desiredReminder, UCDay form1, ScheduleForm form2, ClientReminder clientreminder)
        {
            InitializeComponent();
            Isclientreminder = true;
            DesiredReminder = desiredReminder;

            clientReminder = clientreminder;
            ucday = form1;
            schedule = form2;

            this.BackColor = Color.FromArgb(238, 241, 254);

            if (DesiredReminder.IsChecked)
            {
                this.panelColoredReminder.BackColor = Color.Lime;
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
                reminder = new Reminder(this, ucday, schedule, Isclientreminder, clientReminder);
            }
            else
            {
                reminder = new Reminder(DesiredReminder, ucday, schedule, Isclientreminder);
            }
            reminder.Show();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //SQL:
            DesiredReminder.DeleteReminderSQL();

            //Design:
            if (Isclientreminder)
            {
                UCreminder foundUcReminder = ucday.ListUCreminderForTheSelectedDate.Find(uc => uc.DesiredReminder.Idreminder == DesiredReminder.Idreminder);

                if(foundUcReminder != null)
                {
                    ucday.ListUCreminderForTheSelectedDate.Remove(foundUcReminder);
                    schedule.panelreminder.Controls.Remove(foundUcReminder);
                }
             
                clientReminder.panelreminder.Controls.Remove(this);


                foundUcReminder.Dispose();
                this.Dispose();
            }
            else
            {
                ucday.ListUCreminderForTheSelectedDate.Remove(this);
                schedule.panelreminder.Controls.Remove(this);

                this.Dispose();
            }

        }
        private void linkLabelName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClientReminder clientreminder = new ClientReminder(DesiredReminder.DesiredClient, schedule, ucday);
            clientreminder.ShowDialog();
        }
        private void checkBoxReminder_Click(object sender, EventArgs e)
        {
            //BackEnd
            DesiredReminder.IsChecked = checkBoxReminder.Checked;//tghayar l2esem hone bas houwe zeto ousoulan

            //SQL
            DesiredReminder.checkBoxReminderChangedToSQL();

            //Design
            if (Isclientreminder)
            {

                if (DesiredReminder.IsChecked)//hone lezim nzido
                {
                    UCreminder foundUcReminder = ucday.ListUCreminderForTheSelectedDate.Find(uc => uc.DesiredReminder.Idreminder == DesiredReminder.Idreminder);//KERMEL NSHIL LI BEL panelreminderschedule
                    if(foundUcReminder != null)
                    {
                        foundUcReminder.DesiredReminder.IsChecked = true;
                        foundUcReminder.checkBoxReminder.Checked = true;
                        schedule.panelreminder.Controls.Remove(foundUcReminder);
                    }
                  

                    this.panelColoredReminder.BackColor = Color.Lime;
                }
                else
                {
                    UCreminder foundUcReminder = ucday.ListUCreminderForTheSelectedDate.Find(uc => uc.DesiredReminder.Idreminder == DesiredReminder.Idreminder);//KERMEL NSHIL LI BEL panelreminderschedule
                    if (foundUcReminder != null)
                    {
                        foundUcReminder.DesiredReminder.IsChecked = false;
                        foundUcReminder.checkBoxReminder.Checked = false;
                        foundUcReminder.panelColoredReminder.BackColor = Color.FromArgb(109, 122, 224);

                        if (ucday.isThedayofUCreminder(DesiredReminder, ucday.SelectedDate))
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
                    this.panelColoredReminder.BackColor = Color.Lime;
                    TimerReminderDispose.Start();
                }
                else
                {

                }

            }
        }



        //DESIGN
        ///-The time to hold the reminder from Hiding
        int i = 0;
        private void TimerReminderDispose_Tick(object sender, EventArgs e)
        {

            i++;
            if (i == 1)
            {
                TimerReminderDispose.Stop();
                schedule.panelreminder.Controls.Remove(this);
                i = 0;


                //if they put the check and try to remove it it will be always checked
                DesiredReminder.IsChecked = true;

            }
        }

        private void checkBoxReminder_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxReminder.Checked == false)
            {
                TimerReminderDispose.Stop();
                this.panelColoredReminder.BackColor = Color.FromArgb(109, 122, 224);
            }
        }
    }
}
