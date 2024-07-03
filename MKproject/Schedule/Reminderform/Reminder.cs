using CustomizedTools;
using GlobalFunctions;
using MKproject.Management;
using MKproject.Schedule.Reminderform;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class Reminder : Form
    {
        //Variables
        public static string NoRepeat = "Does not repeat", Everyday = "Every day", Everyweek = "Every week";
        public static string Monday = "Monday", Tuesday = "Tuesday", Wednesday = "Wednesday", Thursday = "Thursday", Friday = "Friday", Saturday = "Saturday", Sunday = "Sunday";


        ScheduleForm ParentFormSchedule;
        UCreminder UCReminderClientReminder;
        UCreminder UCReminderSchedule;
        public UCSchedule ucSchedule;
        ClientReminder clientReminder;

        public bool isupdate;
        public bool isLoadUpdate;
        bool Isclientreminder;


        //Kel ma yenfatah hayda lform lezim yenkhala2 object DesiredReminder
        public ClassReminder DesiredReminder = new ClassReminder();
        //Just to get the check boxes in the order thet we want
        CheckBox[] checkBoxes;
        public bool DisableClosingOnDisactivating;


        public static int HeightWithoutchekBoxes = 416, HeightWithchekBoxes = 482;




        ///-From ClientReminder
        ///ADD
        public Reminder(ScheduleForm form1, UCSchedule form2, ClientReminder clientreminder)
        {
            InitializeComponent();
            ParentFormSchedule = form1;
            ucSchedule = form2;
            clientReminder = clientreminder;

            Isclientreminder = true;
            isupdate = false;

            //Getting the needed values
            if (clientreminder.DesiredClient != null)
            {
                DesiredReminder.DesiredClient = clientreminder.DesiredClient;
                textBoxSearch.Text = DesiredReminder.DesiredClient.Fname + " " + DesiredReminder.DesiredClient.Lname;
            }
            LoadAddForm();
        }
        ///UPDATE
        public Reminder(UCreminder UCreminderfromClientReminder, UCSchedule form2, ScheduleForm form3, bool isclientreminder, ClientReminder clientreminder)
        {
            InitializeComponent();

            UCReminderClientReminder = UCreminderfromClientReminder;

            DesiredReminder = UCReminderClientReminder.DesiredReminder;

            ucSchedule = form2;
            ParentFormSchedule = form3;

            clientReminder = clientreminder;

            //Getting The Type Of this form from where it comes and if it's update or add
            isupdate = true;
            Isclientreminder = isclientreminder;

            LoadUpdateForm();
        }


        ///-From Schedule
        ///ADD
        public Reminder(ScheduleForm form1, UCSchedule form2)
        {
            InitializeComponent();
            ParentFormSchedule = form1;
            ucSchedule = form2;


            Isclientreminder = false;
            isupdate = false;
            LoadAddForm();

        }
        ///UPDATE
        public Reminder(UCreminder ucreminderInSchedule, UCSchedule form2, ScheduleForm form3, bool isclientreminder)
        {
            InitializeComponent();

            UCReminderSchedule = ucreminderInSchedule;
            DesiredReminder = UCReminderSchedule.DesiredReminder;
            ucSchedule = form2;
            ParentFormSchedule = form3;

            //Getting The Type Of this form from where it comes and if it's update or add
            isupdate = true;
            Isclientreminder = isclientreminder;

            LoadUpdateForm();
        }


        void LoadAddForm()
        {
            checkBoxes = new CheckBox[] { checkBoxMonday, checkBoxTuesday, checkBoxWednesday, checkBoxThursday, checkBoxFriday, checkBoxSaturday, checkBoxSunday };
            TLPReminder.RowStyles[2] = new RowStyle(SizeType.Absolute, 0F);//0 pixels
            Height = HeightWithoutchekBoxes;

            DesiredReminder.StartTime = ucSchedule.SelectedDate.Date;
            DesiredReminder.Repeat = Reminder.NoRepeat;

            labelDate.Text = DesiredReminder.StartTime.ToString("ddd, MMM dd, yyyy");
            labelDate.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
            RandomFunctions.FixedFont(labelDate, FontStyle.Bold);
            GetQuoteWhenReminderOpens();
            ParentFormSchedule.calanderFormForReminder.SelectedDateChanged += SelectedDateReminder_Changed;

            labelQuote.Select();
        }
        void LoadUpdateForm()
        {
            checkBoxes = new CheckBox[] { checkBoxMonday, checkBoxTuesday, checkBoxWednesday, checkBoxThursday, checkBoxFriday, checkBoxSaturday, checkBoxSunday };
            isLoadUpdate = true;
            if (DesiredReminder.DesiredClient != null) { textBoxSearch.Text = DesiredReminder.DesiredClient.Fname + " " + DesiredReminder.DesiredClient.Lname; }

            textBoxReminder.Text = DesiredReminder.Reminder;
            labelrepeat.Text = DesiredReminder.PartsRepeat[0];//exemple:Every week/Monday/Friday


            //if it's every week then we have to make panelDaysofTheWeek visible and check the dates

            if (DesiredReminder.PartsRepeat.Length > 1)//baddo yshouf min checked men wara parts repeat
            {
                for (int i = 1; i < DesiredReminder.PartsRepeat.Length; i++)
                {
                    foreach (CheckBox checkbox in panelDaysofTheWeek.Controls)
                    {
                        if (checkbox.Text == DesiredReminder.PartsRepeat[i])
                        {
                            checkbox.Checked = true;
                        }
                    }
                }
            }

            if (DesiredReminder.PartsRepeat[0] == Reminder.NoRepeat)//Checking the random state we didn't yet get it
            {
                TLPReminder.RowStyles[2] = new RowStyle(SizeType.Absolute, 0F);//0 pixels
                Height = Reminder.HeightWithoutchekBoxes;
            }
            else if (DesiredReminder.PartsRepeat[0] == Reminder.Everyday)
            {
                TLPReminder.RowStyles[2] = new RowStyle(SizeType.Absolute, 0F);//0 pixels
                Height = Reminder.HeightWithoutchekBoxes;
            }
            else
            {
                TLPReminder.RowStyles[2] = new RowStyle(SizeType.Absolute, 66F);//66 pixels
                Height = Reminder.HeightWithchekBoxes;
            }

            labelDate.Text = DesiredReminder.StartTime.ToString("ddd, MMM dd, yyyy");
            labelDate.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
            RandomFunctions.FixedFont(labelDate, FontStyle.Bold);
            GetQuoteWhenReminderOpens();

            ParentFormSchedule.calanderFormForReminder.SelectedDateChanged += SelectedDateReminder_Changed;
            isLoadUpdate = false;
            labelQuote.Select();
        }



        //EVENTS:
        ///-Click:
        private void buttonD_Click(object sender, EventArgs e)
        {
            //Error Message
            if (textBoxReminder.Text == textBoxReminder.PlaceholderText)
            {
                textBoxReminder.IsRequiredModeOn = true;
            }
            //The title is here
            else
            {
                //Bi koun akhad lDesiredCient men abel
                DesiredReminder.Reminder = textBoxReminder.Text;

                //UPDATE
                if (isupdate)
                {
                    //SQL
                    DesiredReminder.UpdateFromRemindertoSQL();

                    //DESIGN
                    //FROM ClientReminder
                    if (Isclientreminder)
                    {

                        //KERMEL NSHIL LI BEL List taba3 lschedule w n3adlo
                        UCreminder UcReminderSchedule = ucSchedule.ListUCreminderForTheSelectedDate.Find(uc => uc.DesiredReminder.Idreminder == DesiredReminder.Idreminder);
                        if (UcReminderSchedule != null)
                        {
                            UcReminderSchedule.DesiredReminder = DesiredReminder;
                        }

                        //Design Schedule
                        //Eza ken mawjoud UcReminderSchedule menshouf men wara DesiredReminder ljdid tab3oulo eza ha nshilo
                        if (ucSchedule.isThedayofUCreminder(DesiredReminder) == false && UcReminderSchedule != null)
                        {
                            ParentFormSchedule.panelreminder.Controls.Remove(UcReminderSchedule);
                            ucSchedule.ListUCreminderForTheSelectedDate.Remove(UcReminderSchedule);
                        }

                        //Eza ma ken mawjoud UcReminderSchedule menshouf men wara DesiredReminder ljdid tab3oulo eza ha nhato
                        else if (ucSchedule.isThedayofUCreminder(DesiredReminder) == true && UcReminderSchedule == null)
                        {
                            UCreminder NewUcReminderSchedule = new UCreminder(DesiredReminder, ucSchedule, ParentFormSchedule);
                            ucSchedule.ListUCreminderForTheSelectedDate.Add(NewUcReminderSchedule);
                            ParentFormSchedule.panelreminder.Controls.Add(NewUcReminderSchedule);
                            NewUcReminderSchedule.Dock = DockStyle.Top;
                            //ParentFormSchedule.TouchscrollPanelreminder.ReAssignEventPanelreminder(ParentFormSchedule.panelreminder);
                        }

                        //DESIGN ClientReminder
                        //If it still linked to the same client so we just change the info of this reminder
                        if (clientReminder.DesiredClient == null)
                        {
                            //the ucreminder that we clicked on to update
                            UCReminderClientReminder.DesiredReminder = DesiredReminder;
                        }
                        //clientReminder.DesiredClient != null laken  UCReminderClientReminder.DesiredReminder.DesiredClient.ClientId moustahil ykoun null
                        else if (DesiredReminder.DesiredClient != null && DesiredReminder.DesiredClient.ClientId == UCReminderClientReminder.DesiredReminder.DesiredClient.ClientId)
                        {
                            //the ucreminder that we clicked on to update
                            UCReminderClientReminder.DesiredReminder = DesiredReminder;
                        }

                        //if it's not we have to remove from the clientReminder.panelreminder because the reminder isn't linked anymore to this client ma daroure n3adela
                        else
                        {
                            clientReminder.panelreminder.Controls.Remove(UCReminderClientReminder);
                        }

                    }

                    //FROM Schedule
                    else
                    {
                        UCReminderSchedule.DesiredReminder = DesiredReminder;

                        //DESIGN Schedule
                        //Howe la ha date mawjoud ha nshouf eza ha ybattil mawjoud
                        if (ucSchedule.isThedayofUCreminder(DesiredReminder) == false)
                        {
                            ParentFormSchedule.panelreminder.Controls.Remove(UCReminderSchedule);
                            ucSchedule.ListUCreminderForTheSelectedDate.Remove(UCReminderSchedule);
                        }

                    }


                }

                //ADD
                else
                {
                    //SQL
                    DesiredReminder.AddRemindertoSQL();//hone byekhoud lid bi zet lwa2et


                    //DESIGN SCHEDULE
                    if (ucSchedule.isThedayofUCreminder(DesiredReminder))//ma daroure chouf eza checked akid ha tkoun la2
                    {
                        UCreminder ucreminderSchedule = new UCreminder(DesiredReminder, ucSchedule, ParentFormSchedule);//we add it to the SQL in the same time
                        ucSchedule.ListUCreminderForTheSelectedDate.Add(ucreminderSchedule);//li2anno nehna aam men mashe lprogram lezim na3mello add
                        ParentFormSchedule.panelreminder.Controls.Add(ucreminderSchedule);

                        ucreminderSchedule.Dock = DockStyle.Top;
                        //ParentFormSchedule.TouchscrollPanelreminder.ReAssignEventPanelreminder(ParentFormSchedule.panelreminder);
                    }

                    //DESIGN IF IT'S IN ClientReminder
                    if (Isclientreminder && clientReminder.IsCompletedButtonMode == false)
                    {
                        if (clientReminder.DesiredClient == null)//hone aal akid byaeemil add li2anno all
                        {
                            AddUCReminderInClientReminderForm();
                        }

                        else if (DesiredReminder.DesiredClient != null && DesiredReminder.DesiredClient.ClientId == clientReminder.DesiredClient.ClientId)
                        {
                            AddUCReminderInClientReminderForm();
                        }
                    }
                }

                this.Close();
            }
        }
        void AddUCReminderInClientReminderForm()
        {
            if (clientReminder.panelreminder.Controls.OfType<Label>().Any())
            {
                clientReminder.panelreminder.Controls.Remove(clientReminder.LabelNoReminder);
            }
            UCreminder ucreminderClientReminder = new UCreminder(DesiredReminder, ucSchedule, ParentFormSchedule, clientReminder);
            clientReminder.panelreminder.Controls.Add(ucreminderClientReminder);
            ucreminderClientReminder.Dock = DockStyle.Top;
        }
        private void flowLayoutPanelRepeat_Click(object sender, EventArgs e)
        {
            DisableClosingOnDisactivating = true;
            CBrepeat repeat = new CBrepeat(this);
            repeat.Deactivate += Repeat_Deactivate;
            //Kermel Color tabaee ComboBoxRepeat ybayin active
            TBLRepeat.BackColor = Color.FromArgb(109, 122, 224);
            TBLRepeat.Select();
            Point locationRelativeToScreen = TBLRepeat.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-6, 27);
            repeat.Location = locationRelativeToScreen;
            repeat.Show();

        }

        private void Repeat_Deactivate(object sender, EventArgs e)
        {
            DisableClosingOnDisactivating = false;
        }

        private void textBoxSearch_Click(object sender, EventArgs e)
        {


            //reset
            DisableClosingOnDisactivating = true;
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
        private void Searchname_Deactivate(object sender, EventArgs e)
        {
            this.Select();
            DisableClosingOnDisactivating = false;
        }


        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TLPDate_Click(object sender, EventArgs e)
        {
            DisableClosingOnDisactivating = true;

            //UCmonth show         
            Point locationRelativeToScreen = labelDate.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-45, 25);

            ParentFormSchedule.calanderFormForReminder.IsFromReminder = true;
            ParentFormSchedule.calanderFormForReminder.Location = locationRelativeToScreen;
            ParentFormSchedule.calanderFormForReminder.Show();


            //Showing the ucmonth from the calanderday in the date that we are
            ParentFormSchedule.calanderFormForReminder.DateCalander = DesiredReminder.StartTime;
            ParentFormSchedule.calanderFormForReminder.SelectedDate = DesiredReminder.StartTime;
            if (ParentFormSchedule.calanderFormForReminder.wichuccalander == 2)
            {
                ParentFormSchedule.calanderFormForReminder.wichuccalander = 1;
                ParentFormSchedule.calanderFormForReminder.tableLayoutPanelMonth.Controls.Remove(ParentFormSchedule.calanderFormForReminder.uccalandermonth);
                ParentFormSchedule.calanderFormForReminder.tableLayoutPanelMonth.Controls.Add(ParentFormSchedule.calanderFormForReminder.uccalanderday);
            }
            else if (ParentFormSchedule.calanderFormForReminder.wichuccalander == 3)
            {
                ParentFormSchedule.calanderFormForReminder.wichuccalander = 1;
                ParentFormSchedule.calanderFormForReminder.tableLayoutPanelMonth.Controls.Remove(ParentFormSchedule.calanderFormForReminder.uccalanderyear);
                ParentFormSchedule.calanderFormForReminder.tableLayoutPanelMonth.Controls.Add(ParentFormSchedule.calanderFormForReminder.uccalanderday);

            }

            ParentFormSchedule.calanderFormForReminder.EditLabelUCdays();
            EditingTheSizeOfTheCalander();
        }
        private void EditingTheSizeOfTheCalander()
        {
            ParentFormSchedule.calanderFormForReminder.labelTitleDay.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            ParentFormSchedule.calanderFormForReminder.buttonToday.Font = new Font("Segoe UI", 7F);

            for (int col = 0; col < ParentFormSchedule.calanderFormForReminder.uccalanderday.tableLayoutPanelDays.ColumnCount; col++)
            {
                Control LabelDaysName = ParentFormSchedule.calanderFormForReminder.uccalanderday.tableLayoutPanelDays.GetControlFromPosition(col, 0);
                LabelDaysName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            ParentFormSchedule.calanderFormForReminder.MaximumSize = new Size(260, 240);
            ParentFormSchedule.calanderFormForReminder.MinimumSize = new Size(260, 240);
        }
        public void SelectedDateReminder_Changed(object sender, EventArgs e)
        {
            //edit DateUCDay
            DesiredReminder.StartTime = ParentFormSchedule.calanderFormForReminder.DateCalander.Date;

            ChangingTheDateOfLabelQuote();
            labelDate.Text = DesiredReminder.StartTime.ToString("ddd, MMM dd, yyyy");
            labelDate.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
            RandomFunctions.FixedFont(labelDate, FontStyle.Bold);
            ParentFormSchedule.calanderFormForReminder.Hide();
            ParentFormSchedule.calanderFormForReminder.IsFromReminder = false;
            DisableClosingOnDisactivating = false;
        }
        private void ChangingTheDateOfLabelQuote()
        {
            //Getting the Quote
            string datestart = GetStringDateStart();


            //no repeat
            if (DesiredReminder.PartsRepeat[0] == Reminder.NoRepeat)
            {
                labelQuote.Text = "Only for " + datestart;
            }

            //every day or every week
            else
            {
                string[] PartsSplitByVirgule = labelQuote.Text.Split(new string[] { "," }, StringSplitOptions.None);
                try//aam yotlaale errors w mannamhemme
                {
                    labelQuote.Text = "Starting " + datestart + "," + PartsSplitByVirgule[1];
                }
                catch
                {

                }
            }
        }



        ///-Check Boxes Changed(monday to sunday):
        private void checkBoxMonday_CheckedChanged(object sender, EventArgs e)
        {
            //Getting Quote
            if (DesiredReminder.PartsRepeat[0] == Reminder.Everyweek && isLoadUpdate == false)
            {
                DesiredReminder.Repeat = Reminder.Everyweek;
                string[] PartsSplitByON = labelQuote.Text.Split(new string[] { " on " }, StringSplitOptions.None);
                labelQuote.Text = PartsSplitByON[0] + " on ";
                foreach (CheckBox checkBox in checkBoxes)
                {
                    if (checkBox.Checked)
                    {
                        labelQuote.Text += checkBox.Text + " ";
                        DesiredReminder.Repeat += "/" + checkBox.Text;
                    }
                }
                //labelQuote.Text = labelQuote.Text.Remove(labelQuote.Text.Length - 1);
            }
        }

        ///-Close



        //FUNCTION:
        private void GetQuoteWhenReminderOpens()
        {
            //Getting the Quote
            string datestart = GetStringDateStart();


            //no repeat
            if (DesiredReminder.PartsRepeat[0] == Reminder.NoRepeat)
            {
                labelQuote.Text = "Only for " + datestart;
            }

            //every day 
            else if (DesiredReminder.PartsRepeat[0] == Reminder.Everyday)
            {
                labelQuote.Text = "Starting " + datestart + ", a daily repitition";
            }

            //Every week
            else
            {
                labelQuote.Text = "Starting " + datestart + ", a weekley repitition on ";
                for (int i = 1; i < DesiredReminder.PartsRepeat.Length; i++)//lalvirqule fi haken bein monday w sunday
                {
                    labelQuote.Text += DesiredReminder.PartsRepeat[i] + " ";
                }

            }
        }
        public string GetStringDateStart()
        {
            string datestart;
            if (DesiredReminder.StartTime == DateTime.Today.Date)
            {
                datestart = "today";
            }
            else
            {
                datestart = DesiredReminder.StartTime.ToString("dddd d MMMM");
            }
            return datestart;
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

        private void labelDate_MouseMove(object sender, MouseEventArgs e)
        {
            labelDate.ForeColor = Program.BoldColor;
        }
        private void labelDate_MouseLeave(object sender, EventArgs e)
        {
            labelDate.ForeColor = Color.Black;
        }

        private void Reminder_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParentFormSchedule.calanderFormForReminder.SelectedDateChanged -= SelectedDateReminder_Changed;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .1;
        }

        private void Reminder_Deactivate(object sender, EventArgs e)
        {
            if (!DisableClosingOnDisactivating)
            {
                if (Program.GreyFormJunior != null)
                {
                    Program.GreyFormJunior.Close();
                    Program.GreyFormJunior = null;
                }
                else if (Program.GreyForm != null)
                {
                    Program.GreyForm.Close();
                    Program.GreyForm = null;
                }
                this.Close();
            }
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
