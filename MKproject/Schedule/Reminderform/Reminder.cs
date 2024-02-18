using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class Reminder : Form
    {
        //Variables
        public static string NoRepeat = "Does not repeat", Everyday = "Every day", Everyweek = "Every week";
        public static string Monday = "Monday", Tuesday = "Tuesday", Wednesday = "Wednesday", Thursday = "Thursday", Friday = "Friday", Saturday = "Saturday", Sunday = "Sunday";


        Schedule schedule;
        UCreminder ucreminder;
        UCDay ucday;
        ClientReminder clientReminder;

        public bool isupdate;
        public int typerepeats3;//1:no repeat, 2:everyday, 3:everyweek
        bool Isclientreminder;


        //Initialise
        public Reminder()
        {
            InitializeComponent();
        }

        ///-From ClientReminder
        ///ADD
        public Reminder(Schedule form1, UCDay form2, ClientReminder clientreminder)
        {
            InitializeComponent();
            schedule = form1;
            ucday = form2;
            clientReminder = clientreminder;

            Isclientreminder = true;
            isupdate = false;
            typerepeats3 = 1;

            //Getting the needed values
            StaticClass.ClientName = clientreminder.ClientName;
            StaticClass.Client_id = (int)clientreminder.ClientId;
            textBoxFullName.Text = clientreminder.ClientName;


            StaticClass.StaticClientNameChanged += HandleClientNameChanged;

            checkBoxMonday.Text = Reminder.Monday;
            checkBoxTuesday.Text = Reminder.Tuesday;
            checkBoxWednesday.Text = Reminder.Wednesday;
            checkBoxThursday.Text = Reminder.Thursday;
            checkBoxFriday.Text = Reminder.Friday;
            checkBoxSaturday.Text = Reminder.Saturday;
            checkBoxSunday.Text = Reminder.Sunday;

            monthCalendarStart.SelectionStart = DateTime.Today;
            monthCalendarStart.MinDate = DateTime.Today;
        }
        ///UPDATE
        public Reminder(UCreminder form1, UCDay form2, Schedule form3, bool isclientreminder, ClientReminder clientreminder)
        {
            InitializeComponent();
            ucreminder = form1;
            ucday = form2;
            schedule = form3;
            clientReminder = clientreminder;

            //Getting The Type Of this form from where it comes and if it's update or add
            isupdate = true;
            Isclientreminder = isclientreminder;

            //Getting the properties of the ucreminder that we clicked on
            StaticClass.ClientName = ucreminder.ClientName;
            StaticClass.Client_id = (int)ucreminder.ClientId;
            StaticClass.StaticClientNameChanged += HandleClientNameChanged;//Event for the name if he changed


            if (labelrepeat.Text == Reminder.NoRepeat)//Checking the random state we didn't yet get it
            {
                typerepeats3 = 1;
            }
            else if (labelrepeat.Text == Reminder.Everyday)
            {
                typerepeats3 = 2;
            }
            else
            {
                typerepeats3 = 3;
            }

            checkBoxMonday.Text = Reminder.Monday;
            checkBoxTuesday.Text = Reminder.Tuesday;
            checkBoxWednesday.Text = Reminder.Wednesday;
            checkBoxThursday.Text = Reminder.Thursday;
            checkBoxFriday.Text = Reminder.Friday;
            checkBoxSaturday.Text = Reminder.Saturday;
            checkBoxSunday.Text = Reminder.Sunday;

            monthCalendarStart.SelectionStart = ucreminder.Starttime;
            monthCalendarStart.MinDate = DateTime.Today;

            textBoxReminder.Text = ucreminder.Reminder;
            labelrepeat.Text = ucreminder.Partsrepeat[0];//exemple:Every week/Monday/Friday
            labelQuote.Text = ucreminder.LabelQuote;


            //if it's every week then we have to make panelDaysofTheWeek visible and check the dates
            if (ucreminder.Partsrepeat.Length > 1)//baddo yshouf min checked men wara parts repeat
            {
                panelDaysofTheWeek.Visible = true;
                int i = 1;
                foreach (CheckBox checkbox in panelDaysofTheWeek.Controls)
                {
                    if (i != ucreminder.Partsrepeat.Length)
                    {
                        if (checkbox.Text == ucreminder.Partsrepeat[i])
                        {
                            checkbox.Checked = true;
                            i++;
                        }
                    }
                }
            }

            if (ucreminder.ClientId == null)
            {
                textBoxFullName.Text = textBoxFullName.PlaceholderText;
            }
            else
            {
                textBoxFullName.Text = ucreminder.ClientName;
            }

        }


        ///-From Schedule
        ///ADD
        public Reminder(Schedule form1, UCDay form2)
        {
            InitializeComponent();
            schedule = form1;
            ucday = form2;


            Isclientreminder = false;
            isupdate = false;
            typerepeats3 = 1;

            StaticClass.StaticClientNameChanged += HandleClientNameChanged;

            checkBoxMonday.Text = Reminder.Monday;
            checkBoxTuesday.Text = Reminder.Tuesday;
            checkBoxWednesday.Text = Reminder.Wednesday;
            checkBoxThursday.Text = Reminder.Thursday;
            checkBoxFriday.Text = Reminder.Friday;
            checkBoxSaturday.Text = Reminder.Saturday;
            checkBoxSunday.Text = Reminder.Sunday;

            monthCalendarStart.SelectionStart = DateTime.Today;
            monthCalendarStart.MinDate = DateTime.Today;
        }
        ///UPDATE
        public Reminder(UCreminder form1, UCDay form2, Schedule form3, bool isclientreminder)
        {
            InitializeComponent();
            ucreminder = form1;
            ucday = form2;
            schedule = form3;

            //Getting The Type Of this form from where it comes and if it's update or add
            isupdate = true;
            Isclientreminder = isclientreminder;

            //Getting the properties of the ucreminder that we clicked on
            StaticClass.ClientName = ucreminder.ClientName;
            StaticClass.Client_id = ucreminder.ClientId;
            StaticClass.StaticClientNameChanged += HandleClientNameChanged;

            if (labelrepeat.Text == Reminder.NoRepeat)//Checking the random state we didn't yet get it
            {
                typerepeats3 = 1;
            }
            else if (labelrepeat.Text == Reminder.Everyday)
            {
                typerepeats3 = 2;
            }
            else
            {
                typerepeats3 = 3;
            }

            checkBoxMonday.Text = Reminder.Monday;
            checkBoxTuesday.Text = Reminder.Tuesday;
            checkBoxWednesday.Text = Reminder.Wednesday;
            checkBoxThursday.Text = Reminder.Thursday;
            checkBoxFriday.Text = Reminder.Friday;
            checkBoxSaturday.Text = Reminder.Saturday;
            checkBoxSunday.Text = Reminder.Sunday;

            monthCalendarStart.SelectionStart = ucreminder.Starttime;
            monthCalendarStart.MinDate = DateTime.Today;

            textBoxReminder.Text = ucreminder.Reminder;
            labelrepeat.Text = ucreminder.Partsrepeat[0];//exemple:Every week/Monday/Friday
            labelQuote.Text = ucreminder.LabelQuote;


            //if it's every week then we have to make panelDaysofTheWeek visible and check the dates
            if (ucreminder.Partsrepeat.Length > 1)//baddo yshouf min checked men wara parts repeat
            {
                panelDaysofTheWeek.Visible = true;
                int i = 1;
                foreach (CheckBox checkbox in panelDaysofTheWeek.Controls)
                {
                    if (i != ucreminder.Partsrepeat.Length)
                    {
                        if (checkbox.Text == ucreminder.Partsrepeat[i])
                        {
                            checkbox.Checked = true;
                            i++;
                        }
                    }
                }
            }

            if (ucreminder.ClientId == null)
            {
                textBoxFullName.Text = textBoxFullName.PlaceholderText;
            }
            else
            {
                textBoxFullName.Text = ucreminder.ClientName;
            }

        }



        //EVENTS:
        ///-Click:
        private void buttonD_Click(object sender, EventArgs e)
        {
            //Error Message
            if (textBoxReminder.Text == textBoxReminder.PlaceholderText)
            {
                MessageBox.Show("Enter the add reminder");
            }
            //The title is here
            else
            {

                string repeat = labelrepeat.Text;
                if(labelrepeat.Text == Reminder.Everyweek)
                {
                    foreach (CheckBox checkbox in panelDaysofTheWeek.Controls)//exemple:Monday/Friday
                    {
                        if (checkbox.Checked)
                        {
                            repeat += "/" + checkbox.Text;
                        }

                    }
                }

                //UPDATE
                if (isupdate)
                {
                    //FROM ClientReminder
                    if (Isclientreminder)
                    {
                        UCreminder foundUcReminder = ucday.ListUCreminder.Find(uc => uc.Idreminder == ucreminder.Idreminder);//KERMEL NSHIL LI BEL panelreminderschedule


                        int? clientid;
                        string clientname;
                        if (this.textBoxFullName.Text == this.textBoxFullName.PlaceholderText)
                        {
                            clientname = String.Empty;
                            clientid = null;
                        }
                        else
                        {
                            clientname = StaticClass.ClientName;
                            clientid = StaticClass.Client_id;
                        }
                        //SQL
                        ProjectToSqlSchedule.UpdateFromRemindertoSQL(foundUcReminder.Idreminder, clientid, textBoxReminder.Text, repeat, monthCalendarStart.SelectionStart, labelQuote.Text);



                        //DESIGN
                        //DESIGN Schedule
                        foundUcReminder.UpdateReminder(clientid, clientname, textBoxReminder.Text, repeat, monthCalendarStart.SelectionStart, labelQuote.Text);//we update also the ucreminder that's in the schedule
                        //Addinds or removing a reminder in panelreminder
                        if (ucday.isThedayofUCreminder(foundUcReminder, ucday.DateUCDay) == false)
                        {
                            //fik tzid condition IsControlInPanel(foundUcReminder, schedule.panelreminder) bas ma daroure law ma kenit mawjoude
                            schedule.panelreminder.Controls.Remove(foundUcReminder);
                        }
                        else
                        {
                            if (!RandomFunctionSchedule.IsControlInPanel(foundUcReminder, schedule.panelreminder))
                            {
                                schedule.panelreminder.Controls.Add(foundUcReminder);
                            }
                        }


                        //DESIGN ClientReminder
                        //If it still linked to the same client so we just change the info of this reminder
                        if (StaticClass.Client_id == clientReminder.ClientId)
                        {
                            //the ucreminder that we clicked on to update
                            ucreminder.UpdateReminder(clientid, clientname, textBoxReminder.Text, repeat, monthCalendarStart.SelectionStart, labelQuote.Text);
                        }

                        //if it's not we have to remove from the clientReminder.panelreminder because the reminder isn't linked anymore to this client
                        else
                        {
                            clientReminder.panelreminder.Controls.Remove(ucreminder);
                        }

                    }

                    //FROM Schedule
                    else
                    {
                        int? clientid;
                        string clientname;
                        if (this.textBoxFullName.Text == this.textBoxFullName.PlaceholderText)
                        {
                            clientname = String.Empty;
                            clientid = null;
                        }
                        else
                        {
                            clientname = StaticClass.ClientName;
                            clientid = StaticClass.Client_id;
                        }
                        //SQL
                        ProjectToSqlSchedule.UpdateFromRemindertoSQL(ucreminder.Idreminder, clientid, textBoxReminder.Text, repeat, monthCalendarStart.SelectionStart, labelQuote.Text);


                        //DESIGN Schedule
                        ucreminder.UpdateReminder(clientid, clientname, textBoxReminder.Text, repeat, monthCalendarStart.SelectionStart, labelQuote.Text);//we update also the ucreminder that's in the schedule
                        if (ucday.isThedayofUCreminder(ucreminder, ucday.DateUCDay) == false)
                        {
                            schedule.panelreminder.Controls.Remove(ucreminder);
                        }

                    }


                }

                //ADD
                else
                {
                    int? clientid;
                    string clientname;
                    if (this.textBoxFullName.Text == this.textBoxFullName.PlaceholderText)
                    {
                        clientname = String.Empty;
                        clientid = null;
                    }
                    else
                    {
                        clientname = StaticClass.ClientName;
                        clientid = StaticClass.Client_id;
                    }
                    //SQL
                    int idreminder = ProjectToSqlSchedule.AddRemindertoSQL(clientid, textBoxReminder.Text, repeat, monthCalendarStart.SelectionStart, labelQuote.Text);

                    //BackEnd
                    UCreminder ucreminder = new UCreminder(idreminder,clientid,clientname, textBoxReminder.Text, repeat, monthCalendarStart.SelectionStart, labelQuote.Text, ucday, schedule);//we add it to the SQL in the same time
                    ucday.ListUCreminder.Add(ucreminder);//li2anno nehna aam men mashe lprogram lezim na3mello add

                    //DESIGN SCHEDULE
                    if (ucday.isThedayofUCreminder(ucreminder, ucday.DateUCDay))//ma daroure chouf eza checked akid ha tkoun la2
                    {
                        ucreminder.Dock = DockStyle.Top;
                        schedule.panelreminder.Controls.Add(ucreminder);
                        schedule.TouchscrollPanelreminder.ReAssignEventPanelreminder(schedule.panelreminder);
                    }

                    //DESIGN IF IT'S IN ClientReminder
                    if (Isclientreminder && StaticClass.Client_id == clientReminder.ClientId)
                    {
                        UCreminder ucreminder1 = new UCreminder(ucreminder.Idreminder, ucreminder.ClientId, textBoxReminder.Text, repeat, monthCalendarStart.SelectionStart, labelQuote.Text, false, ucreminder.ClientName, ucday, schedule, true, clientReminder);
                        clientReminder.panelreminder.Controls.Add(ucreminder1);
                        ucreminder1.Dock = DockStyle.Top;
                        clientReminder.TouchscrollPanelclientreminder.ReAssignEventPanelclientreminder(clientReminder.panelreminder);
                    }
                }

                this.Close();
            }
        }
        private void flowLayoutPanelRepeat_Click(object sender, EventArgs e)
        {
            CBrepeat repeat = new CBrepeat(this);
            flowLayoutPanelRepeat.Select();
            Point locationRelativeToScreen = flowLayoutPanelRepeat.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(0, 24);
            repeat.Location = locationRelativeToScreen;
            repeat.Show();

        }
        private void textBoxFullName_Click(object sender, EventArgs e)
        {
            bool isreminder = true;
            CBsearchName searchname = new CBsearchName(textBoxFullName.Text, isreminder);
            Point locationRelativeToScreen = textBoxFullName.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(0, 0);
            searchname.Location = locationRelativeToScreen;
            searchname.Show();
        }

        ///-Change:
        public void HandleClientNameChanged(object sender, EventArgs e)
        {
            textBoxFullName.Text = StaticClass.ClientName;
            pictureBox1.Select();
        }
        private void monthCalendarStart_DateChanged(object sender, DateRangeEventArgs e)
        {
            //Getting the Quote
            string datestart;
            if (monthCalendarStart.SelectionStart.Date == DateTime.Today.Date)
            {
                datestart = "today";
            }
            else
            {
                datestart = monthCalendarStart.SelectionStart.Date.ToString("dddd d MMMM");
            }

            //no repeat
            if (typerepeats3 == 1)
            {
                labelQuote.Text = "Only for " + datestart;
            }

            //every day or every week
            else
            {
                string[] parts = labelQuote.Text.Split(',');
                labelQuote.Text = "Starting " + datestart + "," + parts[1];

                //for (int i = 1; i < parts.Length; i++)//lalvirqule fi haken bein monday w sunday
                //{
                //    labelQuote.Text += parts[i];
                //}
            }
        }
        
        ///-Check Boxes Changed(monday to sunday):
        private void checkBoxMonday_CheckedChanged(object sender, EventArgs e)
        {
            //Getting Quote
            if (typerepeats3 == 3)
            {
                string[] partson = labelQuote.Text.Split(new string[] { " on " }, StringSplitOptions.None);
                labelQuote.Text = partson[0] + " on ";
                foreach (CheckBox checkBox in panelDaysofTheWeek.Controls)
                {
                    if (checkBox.Checked)
                    {
                        labelQuote.Text += checkBox.Text + " ";
                    }
                }
                //labelQuote.Text = labelQuote.Text.Remove(labelQuote.Text.Length - 1);
            }
        }

        ///-Close
        private void Reminder_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticClass.StaticClientNameChanged -= HandleClientNameChanged;
        }



        //FUNCTION:
        private bool IsControlInPanel(Control control, Panel panel)
        {
            foreach (Control panelControl in panel.Controls)
            {
                if (panelControl == control)
                {
                    return true; // The control is in the panel
                }
            }
            return false; // The control is not in the panel
        }



        //DESIGN
        private void flowLayoutPanelRepeat_Paint(object sender, PaintEventArgs e)
        {
            using (Pen Pen = new Pen(Color.FromArgb(109, 122, 224), 1)) // 2 is the width of the border
            {
                // Get the panel
                Panel panel = sender as Panel;

                // Draw the red border around the panel
                e.Graphics.DrawRectangle(Pen, new Rectangle(0, 0, panel.Width - 1, panel.Height - 1));
            }
        }
        private void flowLayoutPanelRepeat_MouseLeave(object sender, EventArgs e)
        {
            flowLayoutPanelRepeat.BackColor = Color.White;
        }
        private void flowLayoutPanelRepeat_MouseMove(object sender, MouseEventArgs e)
        {
            flowLayoutPanelRepeat.BackColor = Color.FromArgb(229, 226, 244);
        }
    }
}
