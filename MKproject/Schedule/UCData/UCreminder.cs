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
                desiredreminder.Partsrepeat = desiredreminder.Repeat.Split('/'); 
                return desiredreminder;
            }
            set 
            {
                desiredreminder = value;
                checkBoxReminder.Checked = desiredreminder.IsChecked;
                checkBoxReminder.Text = desiredreminder.Reminder;
                linkLabelName.Text = desiredreminder.DesiredClient.Fname+" " + desiredreminder.DesiredClient.Lname;

            }
        }

        //Variables:
        UCDay ucday;
        Schedule schedule;
        ClientReminder clientReminder;
        bool Isclientreminder;


        //Initialise
        public UCreminder()
        {
            InitializeComponent();
        }

        //In Schedule
        //we want to add a ucreminder
        public UCreminder(ClassReminder desiredreminder, UCDay form1, Schedule form2)
        {
            InitializeComponent();
            Isclientreminder = false;

            DesiredReminder = desiredreminder;

            ucday = form1;
            schedule = form2;

            buttonDelete.Hide();
            if (DesiredReminder.DesiredClient == null)
            {
                linkLabelName.Visible = false;
            }
            else
            {
                linkLabelName.Visible = true;
            }
        }

        //we want to display from SQL
        public UCreminder(ClassReminder desiredreminder, UCDay form1, Schedule form2, bool isclientreminder)
        {
            InitializeComponent();
            ucday = form1;
            schedule = form2;

            DesiredReminder = desiredreminder;

            Isclientreminder = isclientreminder;
            buttonDelete.Hide();
            if (DesiredReminder.DesiredClient == null)
            {
                linkLabelName.Visible = false;
            }
            else
            {
                linkLabelName.Visible = true;
            }
        }


        //In ClientReminder(from select SQL once we open ClientReminder or when we ADD in ClientReminder)
        public UCreminder(ClassReminder desiredreminder , UCDay form1, Schedule form2, bool isclientreminder, ClientReminder clientreminder)
        {
            InitializeComponent();
            ucday = form1;
            schedule = form2;
            DesiredReminder = desiredreminder;

            clientReminder = clientreminder;
            Isclientreminder = isclientreminder;

            linkLabelName.Visible = false;
        }


        //Function
        public void UpdateReminder(ClassReminder desiredreminder)
        {
           DesiredReminder = desiredreminder;

            if (Isclientreminder)
            {
                linkLabelName.Visible = false;
            }
            else
            {
                if (DesiredReminder.DesiredClient == null)
                {
                    linkLabelName.Visible = false;
                }
                else
                {
                    linkLabelName.Visible = true;
                }
            }
        }


        //EVENTS
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Reminder reminder;
            if (Isclientreminder)
            {
                reminder = new Reminder(desiredreminder, ucday, schedule, Isclientreminder, clientReminder);
            }
            else
            {
                reminder = new Reminder(desiredreminder, ucday, schedule, Isclientreminder);
            }
            reminder.Show();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //SQL:
            DesiredReminder.DeleteReminderSQL();


            UCreminder foundUcReminder = ucday.ListUCreminder.Find(uc => uc.DesiredReminder.Idreminder == DesiredReminder.Idreminder);

            //BackEnd
            ucday.ListUCreminder.Remove(foundUcReminder);
            schedule.panelreminder.Controls.Remove(foundUcReminder);

            //Design
            foundUcReminder.Dispose();
            this.Dispose();
        }
        private void linkLabelName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClientReminder clientreminder = new ClientReminder(DesiredReminder.DesiredClient, schedule, ucday);
            clientreminder.ShowDialog();
        }
        private void checkBoxReminder_Click(object sender, EventArgs e)
        {
            //SQL
            DesiredReminder.checkBoxReminderChangedToSQL();

            //BackEnd
            DesiredReminder.IsChecked = checkBoxReminder.Checked;//tghayar l2esem hone bas houwe zeto ousoulan

            //Design
            if (Isclientreminder)
            {
                if (DesiredReminder.IsChecked)//hone lezim nzido
                {
                    UCreminder foundUcReminder = ucday.ListUCreminder.Find(uc => uc.DesiredReminder.Idreminder == DesiredReminder.Idreminder);//KERMEL NSHIL LI BEL panelreminderschedule
                    foundUcReminder.DesiredReminder.IsChecked = true;
                    schedule.panelreminder.Controls.Remove(foundUcReminder);
                }
                else
                {
                    UCreminder foundUcReminder = ucday.ListUCreminder.Find(uc => uc.DesiredReminder.Idreminder == DesiredReminder.Idreminder);//KERMEL NSHIL LI BEL panelreminderschedule
                    foundUcReminder.DesiredReminder.IsChecked = false;
                    foundUcReminder.tableLayoutPanel1.BackColor = Color.White;

                    foundUcReminder.Dock = DockStyle.Top;
                    schedule.panelreminder.Controls.Add(foundUcReminder);
                }
            }
            else
            {
                if (DesiredReminder.IsChecked)//hone lezim nzido
                {
                    this.tableLayoutPanel1.BackColor = Color.Lime;
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
        private void timer1_Tick(object sender, EventArgs e)
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
    }
}
