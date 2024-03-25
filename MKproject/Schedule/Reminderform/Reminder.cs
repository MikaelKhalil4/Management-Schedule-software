using MKproject.Management;
using MKproject.Schedule.UCData;
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
        UCreminder ucreminderInClientReminder;
        public UCDay ucday;
        ClientReminder clientReminder;

        public bool isupdate;
        public int typerepeats3;//1:no repeat, 2:everyday, 3:everyweek
        bool Isclientreminder;

        //For the ClientReminder(Add Button) bas eeyiz ClassClient la ta3tiya la search
        ClassClient DesiredClient = new ClassClient();

        //Kel ma yenfatah hayda lform lezim yenkhala2 object DesiredReminder
        ClassReminder DesiredReminder = new ClassReminder();

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
            DesiredReminder.DesiredClient = clientreminder.DesiredClient;
            textBoxSearch.Text = DesiredReminder.DesiredClient.Fname + " " + DesiredReminder.DesiredClient.Lname;

            GetQuoteFromDate();

        }
        ///UPDATE
        public Reminder(UCreminder UCreminderfromClientReminder, UCDay form2, Schedule form3, bool isclientreminder, ClientReminder clientreminder)
        {
            InitializeComponent();

            ucreminderInClientReminder = UCreminderfromClientReminder;
            DesiredReminder = ucreminderInClientReminder.DesiredReminder;

            ucday = form2;
            schedule = form3;

            clientReminder = clientreminder;

            //Getting The Type Of this form from where it comes and if it's update or add
            isupdate = true;
            Isclientreminder = isclientreminder;


            if (DesiredReminder.DesiredClient != null) { textBoxSearch.Text = DesiredReminder.DesiredClient.Fname + " " + DesiredReminder.DesiredClient.Lname; }

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


            

            textBoxReminder.Text = DesiredReminder.Reminder;
            labelrepeat.Text = DesiredReminder.Partsrepeat[0];//exemple:Every week/Monday/Friday
            labelQuote.Text = DesiredReminder.LabelQuote;


            //if it's every week then we have to make panelDaysofTheWeek visible and check the dates
            if (DesiredReminder.Partsrepeat.Length > 1)//baddo yshouf min checked men wara parts repeat
            {
                panelDaysofTheWeek.Visible = true;
                int i = 1;
                foreach (CheckBox checkbox in panelDaysofTheWeek.Controls)
                {
                    if (i != DesiredReminder.Partsrepeat.Length)
                    {
                        if (checkbox.Text == DesiredReminder.Partsrepeat[i])
                        {
                            checkbox.Checked = true;
                            i++;
                        }
                    }
                }
            }
            GetQuoteFromDate();

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
            GetQuoteFromDate();

        }
        ///UPDATE
        public Reminder(ClassReminder desiredreminder, UCDay form2, Schedule form3, bool isclientreminder)
        {
            InitializeComponent();

            DesiredReminder = desiredreminder;
            ucday = form2;
            schedule = form3;

            //Getting The Type Of this form from where it comes and if it's update or add
            isupdate = true;
            Isclientreminder = isclientreminder;


            if (DesiredReminder.DesiredClient != null) { textBoxSearch.Text = DesiredReminder.DesiredClient.Fname + " " + DesiredReminder.DesiredClient.Lname; }


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


          
            textBoxReminder.Text = DesiredReminder.Reminder;
            labelrepeat.Text = DesiredReminder.Partsrepeat[0];//exemple:Every week/Monday/Friday
            labelQuote.Text = DesiredReminder.LabelQuote;


            //if it's every week then we have to make panelDaysofTheWeek visible and check the dates
            if (DesiredReminder.Partsrepeat.Length > 1)//baddo yshouf min checked men wara parts repeat
            {
                panelDaysofTheWeek.Visible = true;
                int i = 1;
                foreach (CheckBox checkbox in panelDaysofTheWeek.Controls)
                {
                    if (i != DesiredReminder.Partsrepeat.Length)
                    {
                        if (checkbox.Text == DesiredReminder.Partsrepeat[i])
                        {
                            checkbox.Checked = true;
                            i++;
                        }
                    }
                }
            }
            GetQuoteFromDate();
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
                if (labelrepeat.Text == Reminder.Everyweek)
                {
                    foreach (CheckBox checkbox in panelDaysofTheWeek.Controls)//exemple:Monday/Friday
                    {
                        if (checkbox.Checked)
                        {
                            repeat += "/" + checkbox.Text;
                        }

                    }
                }
                //Bi koun akhad lDesiredCient men abel
                DesiredReminder.Reminder = textBoxReminder.Text;
                DesiredReminder.Repeat = repeat;
                DesiredReminder.StartTime = ucday.SelectedDate;
                DesiredReminder.LabelQuote = labelQuote.Text;

                //UPDATE
                if (isupdate)
                {
                    //SQL
                    DesiredReminder.UpdateFromRemindertoSQL();

                    //DESIGN

                    //KERMEL NSHIL LI BEL List taba3 lschedule w n3adlo
                    UCreminder UcReminderSchedule = ucday.ListUCreminder.Find(uc => uc.DesiredReminder.Idreminder == DesiredReminder.Idreminder);
                    UcReminderSchedule.DesiredReminder = DesiredReminder;



                    //FROM ClientReminder
                    if (Isclientreminder)
                    {

                        //Design Schedule
                        //Addinds or removing a reminder in panelreminder
                        if (ucday.isThedayofUCreminder(UcReminderSchedule, ucday.SelectedDate) == false)
                        {
                            //fik tzid condition IsControlInPanel(foundUcReminder, schedule.panelreminder) bas ma daroure law ma kenit mawjoude
                            schedule.panelreminder.Controls.Remove(UcReminderSchedule);
                        }
                        else
                        {
                            if (!RandomFunctionSchedule.IsControlInPanel(UcReminderSchedule, schedule.panelreminder))
                            {
                                schedule.panelreminder.Controls.Add(UcReminderSchedule);
                            }
                        }

                        //DESIGN ClientReminder
                        //If it still linked to the same client so we just change the info of this reminder
                        if (DesiredReminder.DesiredClient.ClientId == clientReminder.DesiredClient.ClientId)
                        {
                            //the ucreminder that we clicked on to update
                            ucreminderInClientReminder.DesiredReminder = DesiredReminder;
                        }

                        //if it's not we have to remove from the clientReminder.panelreminder because the reminder isn't linked anymore to this client ma daroure n3adela
                        else
                        {
                            clientReminder.panelreminder.Controls.Remove(ucreminderInClientReminder);
                        }

                    }

                    //FROM Schedule
                    else
                    {
                        //DESIGN Schedule
                        if (ucday.isThedayofUCreminder(UcReminderSchedule, ucday.SelectedDate) == false)
                        {
                            schedule.panelreminder.Controls.Remove(UcReminderSchedule);
                        }

                    }


                }

                //ADD
                else
                {
                    //SQL
                    DesiredReminder.AddRemindertoSQL();//hone byekhoud lid bi zet lwa2et

                    //BackEnd
                    UCreminder ucreminder = new UCreminder(DesiredReminder, ucday, schedule);//we add it to the SQL in the same time
                    ucday.ListUCreminder.Add(ucreminder);//li2anno nehna aam men mashe lprogram lezim na3mello add

                    //DESIGN SCHEDULE
                    if (ucday.isThedayofUCreminder(ucreminder, ucday.SelectedDate))//ma daroure chouf eza checked akid ha tkoun la2
                    {
                        ucreminder.Dock = DockStyle.Top;
                        schedule.panelreminder.Controls.Add(ucreminder);
                        schedule.TouchscrollPanelreminder.ReAssignEventPanelreminder(schedule.panelreminder);
                    }

                    //DESIGN IF IT'S IN ClientReminder
                    if (Isclientreminder && DesiredReminder.DesiredClient.ClientId == clientReminder.ClientId)
                    {
                        UCreminder ucreminder1 = new UCreminder(DesiredReminder, ucday, schedule, clientReminder);
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
            //Kermel Color tabaee ComboBoxRepeat ybayin active
            TBLRepeat.BackColor = Color.FromArgb(109, 122, 224);
            TBLRepeat.Select();
            Point locationRelativeToScreen = TBLRepeat.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-6, 27);
            repeat.Location = locationRelativeToScreen;
            repeat.Show();

        }
        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            //Search searchname = new Search(textBoxSearch, DesiredClient);
            //searchname.Deactivate += Searchname_Deactivate;
            //Point locationRelativeToScreen = textBoxSearch.PointToScreen(Point.Empty);
            //locationRelativeToScreen.Offset(0, 0);
            //searchname.Location = locationRelativeToScreen;
            //searchname.Show();

            //reset
            Search searchname = new Search(textBoxSearch, DesiredReminder.DesiredClient);
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
            DesiredReminder.DesiredClient = searchname.NewDesiredClient;
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
        private void Searchname_Deactivate(object sender, EventArgs e)
        {
            this.Select();
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
        private void GetQuoteFromDate()
        {
            //Getting the Quote
            string datestart;
            if (ucday.SelectedDate.Date == DateTime.Today.Date)
            {
                datestart = "today";
            }
            else
            {
                datestart = ucday.SelectedDate.Date.ToString("dddd d MMMM");
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
            //labelrepeat.ForeColor = Color.White;
        }
        private void flowLayoutPanelRepeat_MouseMove(object sender, MouseEventArgs e)
        {
            //labelrepeat.ForeColor = Color.FromArgb(229, 226, 244);
        }
    }
}
