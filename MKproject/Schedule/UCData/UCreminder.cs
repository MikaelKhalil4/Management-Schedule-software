using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MKproject.Schedule
{
    public partial class UCreminder : UserControl
    {
        //SQL
        static SqlConnection con = new SqlConnection(Program.DataLocation);

        //PROPERTY:
        private int idreminder;
        public int Idreminder
        {
            get { return idreminder; }
            set { idreminder = value; }
        }


        private string reminder;
        public string Reminder
        {
            get { return reminder; }
            set { reminder = value; checkBoxReminder.Text = reminder; }
        }


        private string repeat;
        public string Repeat
        {
            get { return repeat; }
            set { repeat = value; }
        }

        private string[] partsrepeat;
        public string[] Partsrepeat
        {
            get { partsrepeat = Repeat.Split('/'); return partsrepeat; }
            set { partsrepeat = value; }
        }

        private DateTime starttime;
        public DateTime Starttime
        {
            get { return starttime; }
            set { starttime = value; }
        }

        private string clientName;
        public string ClientName
        {
            get { return clientName; }
            set
            {
                clientName = value;
                linkLabelName.Text = clientName;
            }
        }

        private bool ischecked;
        public bool IsChecked
        {
            get { return ischecked; }
            set { ischecked = value; checkBoxReminder.Checked = ischecked; }
        }

        public string LabelQuote { get; set; }
        public int? ClientId { get; set; }


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
        public UCreminder(int idreminder, int? clientid, string clientname, string reminder, string repeat, DateTime starttime, string labelquote, UCDay form1, Schedule form2)
        {
            InitializeComponent();
            Isclientreminder = false;
            Idreminder = idreminder;
            ClientId = clientid;
            ClientName = clientname;
            Reminder = reminder;
            Repeat = repeat;
            Starttime = starttime;
            LabelQuote = labelquote;
            ucday = form1;
            schedule = form2;

            buttonDelete.Hide();
            if (ClientId == null)
            {
                linkLabelName.Visible = false;
            }
            else
            {
                linkLabelName.Visible = true;
            }
        }

        //we want to display from SQL
        public UCreminder(int idreminder, int? clientid, string reminder, string repeat, DateTime starttime, string labelquote, bool ischecked, string clientname, UCDay form1, Schedule form2, bool isclientreminder)
        {
            InitializeComponent();
            Idreminder = idreminder;
            IsChecked = ischecked;
            Reminder = reminder;
            Repeat = repeat;
            Starttime = starttime;
            LabelQuote = labelquote;
            ClientName = clientname;
            ClientId = clientid;
            ucday = form1;
            schedule = form2;

            Isclientreminder = isclientreminder;
            buttonDelete.Hide();
            if (clientid == null)
            {
                linkLabelName.Visible = false;
                ClientName = String.Empty;
                ClientId = null;
            }
            else
            {
                linkLabelName.Visible = true;
                ClientName = clientname;
                ClientId = clientid;
            }
        }


        //In ClientReminder(from select SQL once we open ClientReminder or when we ADD in ClientReminder)
        public UCreminder(int idreminder, int? clientid, string reminder, string repeat, DateTime starttime, string labelquote, bool ischecked, string clientname, UCDay form1, Schedule form2, bool isclientreminder, ClientReminder clientreminder)
        {
            InitializeComponent();
            Idreminder = idreminder;
            IsChecked = ischecked;
            Reminder = reminder;
            Repeat = repeat;
            Starttime = starttime;
            LabelQuote = labelquote;
            ClientName = clientname;
            ClientId = clientid;
            ucday = form1;
            schedule = form2;

            clientReminder = clientreminder;
            Isclientreminder = isclientreminder;

            linkLabelName.Visible = false;

        }


        //Function
        public void UpdateReminder(int? clientid, string clientname, string reminder, string repeat, DateTime starttime, string labelquote)
        {
            Reminder = reminder;
            Repeat = repeat;
            Starttime = starttime;
            LabelQuote = labelquote;
            ClientId = clientid;
            ClientName = clientname;

            if (Isclientreminder)
            {
                linkLabelName.Visible = false;
            }
            else
            {
                if (ClientId == null)
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
                reminder = new Reminder(this, ucday, schedule, Isclientreminder, clientReminder);
            }
            else
            {
                reminder = new Reminder(this, ucday, schedule, Isclientreminder);
            }
            reminder.Show();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //SQL:
            ProjectToSqlSchedule.DeleteReminderSQL(Idreminder);


            UCreminder foundUcReminder = ucday.ListUCreminder.Find(uc => uc.idreminder == Idreminder);

            //BackEnd
            ucday.ListUCreminder.Remove(foundUcReminder);
            schedule.panelreminder.Controls.Remove(foundUcReminder);

            //Design
            foundUcReminder.Dispose();
            this.Dispose();
        }
        private void linkLabelName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClientReminder clientreminder = new ClientReminder(ClientId, ClientName, schedule, ucday);
            clientreminder.ShowDialog();
        }
        private void checkBoxReminder_Click(object sender, EventArgs e)
        {
            //SQL
            ProjectToSqlSchedule.checkBoxReminderChangedToSQL(Idreminder, checkBoxReminder.Checked);

            //BackEnd
            IsChecked = checkBoxReminder.Checked;//tghayar l2esem hone bas houwe zeto ousoulan

            //Design
            if (Isclientreminder)
            {
                if (IsChecked)//hone lezim nzido
                {
                    UCreminder foundUcReminder = ucday.ListUCreminder.Find(uc => uc.idreminder == Idreminder);//KERMEL NSHIL LI BEL panelreminderschedule
                    foundUcReminder.IsChecked = true;
                    schedule.panelreminder.Controls.Remove(foundUcReminder);
                }
                else
                {
                    UCreminder foundUcReminder = ucday.ListUCreminder.Find(uc => uc.idreminder == Idreminder);//KERMEL NSHIL LI BEL panelreminderschedule
                    foundUcReminder.IsChecked = false;
                    foundUcReminder.tableLayoutPanel1.BackColor = Color.White;

                    foundUcReminder.Dock = DockStyle.Top;
                    schedule.panelreminder.Controls.Add(foundUcReminder);
                }
            }
            else
            {
                if (IsChecked)//hone lezim nzido
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
                IsChecked = true;

            }
        }
    }
}
