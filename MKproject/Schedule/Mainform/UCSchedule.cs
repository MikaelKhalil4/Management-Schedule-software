using CustomizedTools;
using GlobalFunctions;
using MKproject.Management;
using MKproject.Schedule.UCData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace MKproject.Schedule
{
    public partial class UCSchedule : UserControl
    {
        public ScheduleForm ParentFormSchedule { get; set; }
        private Panel timeIndicatorLine;

        public DateTime SelectedDate { get; set; }

        List<DateTime> PresentWeek { get; set; }
        public List<DateTime> ListDaysOfDesiredWeek { get; set; }//used if week mode on

        public bool IsEmployeeFilterModeOn;
        public List<ClassEmployee> EmployeeScheduleListWorkingOn { get; set; }//used if days mode on
        public List<ClassEmployee> TotalEmployeeScheduleList { get; set; }//used to store the check state of the members during run mode, lamma ngahhyir shi checkbox, ha naayit deyman lal load w hone hasab eza past aw present aw future bi sir fi 
        //shi algo bel fill EmployeeList ben TotalEmployeeScheduleList and EmployeeScheduleListWorkingOn


        public List<ClassAppointment> AppointmentsListWorkingOn { get; set; }//this one you should use it every where

        public TableLayoutPanel TLPEmployees;
        public TableLayoutPanel TLPSchedule;
        List<(ClassEmployee, DateTime?, List<int>)> ListOfAllColumnIndexesGroups = new List<(ClassEmployee, DateTime?, List<int>)>();
        (ClassEmployee, DateTime?, List<int>) FocusOnColumnIndexGroup;
        int FocusOnMaxWidth;
        bool IsHistory;
        public bool IsCursorBlocked;
        bool IsLoadingTheForm;

        public bool IsDayOrWeek;
        public ClassEmployee TheOnlyEmployee;//eza fi aktar menn wahad bi null, used in 7 days, ta naarif if we can editt bel 7 days mode




        //Reminder
        public List<UCreminder> ListUCreminderForTheSelectedDate { get; set; } = new List<UCreminder>();//we get it once we open the schedule then if something happened to a ucreminder add,update,delete dureing the runtime it will hapen to the List

        private enum EnumDaysOrWeek
        {
            Day,
            Week,
        }

        public UCSchedule(ScheduleForm parentform)
        {
            InitializeComponent();

            ParentFormSchedule = parentform;
            ParentFormSchedule.ScheduleFormResize += ParentFormSchedule_ScheduleFormResize;

            comboBoxDaysOrWeek.Items.Add(EnumDaysOrWeek.Day.ToString());
            comboBoxDaysOrWeek.Items.Add(EnumDaysOrWeek.Week.ToString());

            scrollTimer = new Timer();
            scrollTimer.Interval = 100; // Adjust as needed
            scrollTimer.Tick += ScrollTimer_Tick; ;

            TotalEmployeeScheduleList = ClassEmployee.GetEmployeeScheduleMemberASC();
            foreach (ClassEmployee emp in TotalEmployeeScheduleList)
            {
                emp.IsChecked = true;//by default bdawwe kell el existing employees
            }

            LoadForm(DateTime.Now, true, true, true);
            InsertHistroyToSqlIfNecessary();


        }



        public void LoadForm(DateTime selectedDate, bool isDayOrWeek, bool IsScrollToNowHour, bool DateHasChanged)
        {

            IsLoadingTheForm = true;
            FocusOnColumnIndexGroup = (null, null, null);

            if (EmployeeScheduleListWorkingOn != null)
                EmployeeScheduleListWorkingOn.Clear();

            if (AppointmentsListWorkingOn != null)
                AppointmentsListWorkingOn.Clear();



            if (ListOfAllColumnIndexesGroups != null)
                ListOfAllColumnIndexesGroups.Clear();

            //only TotalEmployeeScheduleList ma mnaamela clear,


            IsDayOrWeek = isDayOrWeek;
            SelectedDate = selectedDate;


            CreateTLPDesign();


            FillEmployeLists();

            if (isDayOrWeek)
            {

                //flling the appointmetn list
                FillAppointmentList(isDayOrWeek);

                if (SelectedDate.Date < DateTime.Now.Date)
                {
                    IsHistory = true;
                }
                else
                {
                    IsHistory = false;

                }
                if (AppointmentsListWorkingOn.Count == 0 && SelectedDate.Date < DateTime.Now.Date)
                {
                    IsDesignBlocked = true;

                    BlockedModeDesign("No Appointments Available");

                }
                else if (!CheckIfAnyEmployeeAvailable())
                {
                    IsDesignBlocked = true;
                    if (SelectedDate.Date >= DateTime.Now.Date)
                    {
                        BlockedModeDesign("No Employees Available");
                    }

                }
                else
                {
                    SetListOfAllColumnIndexesGroups();//ejbare men baaed li foe



                    //Colmns Groups, ha ykun percentage
                    SetTLPEmployeesColumn();
                    SetTLPSchGroupColumn();

                    IsCursorBlocked = true;
                    AddAppointmentsToTlpSchedule();//takes time
                    PercentageResizeTLPScheduleAndTlpEmp();

                    if (TLPSchedule.HorizontalScroll.Visible)//ejbariye , lieannommarrat aam tofsul
                    {
                        TLPSchedule.AutoScroll = false;
                        TLPSchedule.AutoScroll = true;
                        //TLPSchedule.HorizontalScroll.Visible = false;
                        this.Width += 50;
                    }
                    IsCursorBlocked = false;
                    IsDesignBlocked = false;
                }
            }
            else
            {
                ListDaysOfDesiredWeek = FillWeekLists(SelectedDate);
                PresentWeek = FillWeekLists(DateTime.Now);
                FillAppointmentList(isDayOrWeek);
                SetListOfAllColumnIndexesGroups();
                SetTLPEmployeesColumn();
                SetTLPSchGroupColumn();


                IsCursorBlocked = true;
                AddAppointmentsToTlpSchedule();//takes time
                PercentageResizeTLPScheduleAndTlpEmp();


                if (TLPSchedule.HorizontalScroll.Visible)//ejbariye , lieannommarrat aam tofsul
                {
                    TLPSchedule.AutoScroll = false;
                    TLPSchedule.AutoScroll = true;
                    //TLPSchedule.HorizontalScroll.Visible = false;
                    this.Width += 50;
                }
                IsCursorBlocked = false;
                IsDesignBlocked = false;
            }


            //LabelText
            if (isDayOrWeek)
            {
                labelDate.Text = SelectedDate.ToString("dddd,MMMM dd yyyy");
            }
            else
            {
                labelDate.Text = GetLabelDateifWeek();
            }

            //Reminder
            if (DateHasChanged)
            {
                DisplayUCReminderForTheSelectedDate();
            }




            //Scrol
            if (IsScrollToNowHour)
            {
                ScrollToRow(GetRowFromTime(DateTime.Now.TimeOfDay, false));
            }


            if (timeIndicatorLine != null)
            {
                timeIndicatorLine.Dispose();
                timeIndicatorLine = null;
            }
            if (isDayOrWeek)
            {
                if (SelectedDate.Date == DateTime.Now.Date)//oly bel present men bayyin real tme 
                {
                    CreateIndicatorLine();
                    UpdateTimeIndicatorLinePosition();
                }
            }
            else
            {

                if (PresentWeek.Any(d => d.Date == SelectedDate.Date))
                {
                    CreateIndicatorLine();
                    UpdateTimeIndicatorLinePosition();
                }

            }


            if (IsEmployeeFilterModeOn)
            {
                labelMember.ForeColor = Color.Green;
                pictureBoxMember.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "down-arrow-GreenColor.png");
            }
            else
            {
                labelMember.ForeColor = Color.Black;
                pictureBoxMember.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "down-arrow-Black.png");
            }

            if (IsDayOrWeek)//Treka bel ekhir lieanno,amm tghayir el curso to default
            {
                comboBoxDaysOrWeek.SelectedIndex = 0;

            }
            else
            {
                comboBoxDaysOrWeek.SelectedIndex = 1;
            }
            IsLoadingTheForm = false;
        }


        public void RefreshAllRelatedAppointments(int TargetClientId)
        {
            List<ClassAppointment> appointmentsWithClientId = AppointmentsListWorkingOn.Where(appointment => appointment.DesiredClient != null && appointment.DesiredClient.ClientId == TargetClientId).ToList();
            List<ClassAppointment> ListAppointmentsToUpdate = new List<ClassAppointment>();
            foreach (ClassAppointment desiredApointment in appointmentsWithClientId)
            {
                ListAppointmentsToUpdate.Add(ClassAppointment.CreateObjectClassAppointment(desiredApointment.AppointmentID));
            }

            //Update the list
            foreach (ClassAppointment UpdatedAppointment in ListAppointmentsToUpdate)
            {
                ClassAppointment DesiredAppToUpdate = AppointmentsListWorkingOn.FirstOrDefault(appointment => appointment.DesiredClient != null && appointment.AppointmentID == UpdatedAppointment.AppointmentID);
                DesiredAppToUpdate = UpdatedAppointment;
            }
            //Update the design
            foreach (Control ucapp in TLPSchedule.Controls)
            {
                if (ucapp is UCappointment && ((UCappointment)ucapp).DesiredAppointmentUCApp.DesiredClient != null && ((UCappointment)ucapp).DesiredAppointmentUCApp.DesiredClient.ClientId == TargetClientId)
                {
                    ((UCappointment)ucapp).DesiredAppointmentUCApp = ListAppointmentsToUpdate.FirstOrDefault(appointment => appointment.DesiredClient != null && appointment.AppointmentID == ((UCappointment)ucapp).DesiredAppointmentUCApp.AppointmentID);
                    ((UCappointment)ucapp).SetUCDesign();
                    ((UCappointment)ucapp).SetServiceLogicAndDesign();
                    ((UCappointment)ucapp).FixUCDesign();
                }
            }
        }
        public void RefreshDesiredAppointment(UCappointment DesiredUcApp)
        {
            DesiredUcApp.DesiredAppointmentUCApp = ClassAppointment.CreateObjectClassAppointment(DesiredUcApp.DesiredAppointmentUCApp.AppointmentID);
            DesiredUcApp.SetUCDesign();
            DesiredUcApp.SetServiceLogicAndDesign();
            DesiredUcApp.FixUCDesign();

        }




        void CreateIndicatorLine()
        {
            timeIndicatorLine = new Panel();
            timeIndicatorLine.Height = 3;
            timeIndicatorLine.BackColor = Color.Green;
            int column1Left = TLPSchedule.GetColumnWidths()[0];
            timeIndicatorLine.Width = 10;
            timeIndicatorLine.Left = TLPSchedule.Left + column1Left - timeIndicatorLine.Width / 2 - 2;


            this.Controls.Add(timeIndicatorLine);

            // Position the line above the TableLayoutPanel
            timeIndicatorLine.BringToFront();

            // Update the line position periodically
            Timer timer = new Timer
            {
                Interval = 60000 // Update every minute
            };
            timer.Tick += Timer_Tick; ;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTimeIndicatorLinePosition();
        }
        private void UpdateTimeIndicatorLinePosition()
        {
            if (timeIndicatorLine != null)
            {
                // Calculate the position based on the current time
                DateTime now = DateTime.Now;
                int hours = now.Hour;
                int minutes = now.Minute;

                // Assuming each row represents 15 minutes and row height is constant
                int rowHeight = TLPSchedule.GetRowHeights()[0];
                int totalMinutes = hours * 60 + minutes;
                int yOffset = (totalMinutes / 15) * rowHeight + (int)((rowHeight / 15.0) * (totalMinutes % 15));

                // Adjust the position based on the scroll position of the Panel
                int scrollOffset = TLPSchedule.VerticalScroll.Value;

                // Position the line
                timeIndicatorLine.Top = TLPSchedule.Top + yOffset - scrollOffset - (timeIndicatorLine.Height / 2);


                // Determine if the line should be visible
                int panelVisibleTop = scrollOffset;
                int panelVisibleBottom = panelVisibleTop + TLPSchedule.ClientSize.Height;
                timeIndicatorLine.Visible = yOffset >= panelVisibleTop && yOffset <= panelVisibleBottom;

                //change color Label:
                //int row = GetRowFromTime(DateTime.Now.TimeOfDay);
                //Label Labeltime = (Label)TLPSchedule.GetControlFromPosition(0, row);
                //Labeltime.ForeColor = timeIndicatorLine.BackColor;
                //Labeltime.Font= new Font("Segoe UI SemiBold", 10, FontStyle.Regular);
            }
        }
        public void ScrollToRow(int rowIndex)
        {

            // Calculate the vertical position of the specified row
            int rowYPosition = 0;
            for (int i = 0; i < rowIndex; i++)
            {
                rowYPosition += TLPSchedule.GetRowHeights()[i];
            }

            // Calculate the height of the specified row
            int rowHeight = TLPSchedule.GetRowHeights()[rowIndex];

            // Calculate the visible area height of the TableLayoutPanel
            int visibleHeight = TLPSchedule.ClientSize.Height;

            // Calculate the position to scroll so the row is in the middle
            int targetScrollPosition = rowYPosition - rowHeight * 4;

            // Set the AutoScrollPosition to the target position
            TLPSchedule.AutoScrollPosition = new Point(0, targetScrollPosition);
        }




        void FillAppointmentList(bool isDayOrWeek)
        {
            List<ClassAppointment> TotalAppointmentsList;

            if (isDayOrWeek)
            {
                TotalAppointmentsList = ClassAppointment.GetAppointmentOfSpecificEmployees(SelectedDate, EmployeeScheduleListWorkingOn);
            }
            else
            {
                TotalAppointmentsList = ClassAppointment.GetAppointmentOfSpecificDays(ListDaysOfDesiredWeek);
            }

            AppointmentsListWorkingOn = new List<ClassAppointment>();
            foreach (ClassAppointment Desiredapp in TotalAppointmentsList)
            {
                ClassEmployee DesiredEmp = EmployeeScheduleListWorkingOn.FirstOrDefault(e => e.EmployeeId == Desiredapp.DesiredEmployee.EmployeeId);
                if (DesiredEmp != null && DesiredEmp.IsChecked)//ma lezim tkun different then null, lieanno mafina nemhe employee eendo appointment in the past, bas lieanno eena old wrong data hattayneha w for rahit el ras
                {
                    AppointmentsListWorkingOn.Add(Desiredapp);
                }
            }
        }

        public string GetLabelDateifWeek()
        {
            var distinctMonths = ListDaysOfDesiredWeek.Select(d => new { d.Month, d.Year }).Distinct().ToList();

            string labelDateText;

            if (distinctMonths.Count == 1)
            {
                var singleMonth = distinctMonths.First();
                labelDateText = $"{GetMonthName(singleMonth.Month)} {singleMonth.Year}";
            }
            else
            {
                var firstMonth = distinctMonths.First();
                var lastMonth = distinctMonths.Last();
                labelDateText = $"{GetMonthName(firstMonth.Month)}-{GetMonthName(lastMonth.Month)} {firstMonth.Year}";
            }

            return labelDateText; // Replace with labelDate.Text = labelDateText; in your actual application
        }
        public static string GetMonthName(int month)
        {
            return new DateTime(1, month, 1).ToString("MMMM");
        }




        ButtonEmployeeOrDay CreateLabelEmployee()
        {
            //Design 
            ButtonEmployeeOrDay labelEmployee = new ButtonEmployeeOrDay();
            labelEmployee.Dock = DockStyle.Fill;

            //Events
            if (!IsDesignBlocked)
            {
                labelEmployee.Cursor = Cursors.Hand;
                labelEmployee.Click += LAbelEmployee_Click;
                labelEmployee.MouseMove += LabelEmployee_MouseMove;
                labelEmployee.MouseLeave += LabelEmployee_MouseLeave;
            }

            return labelEmployee;
        }
        void ActiveDesiredLabel(ButtonEmployeeOrDay DesiredLabelEmployee)
        {
            //Design
            foreach (ButtonEmployeeOrDay labelEmployee in TLPEmployees.Controls)
            {
                if (labelEmployee.IsClicked && labelEmployee != DesiredLabelEmployee)
                {
                    labelEmployee.IsClicked = false;
                    labelEmployee.SetDefaultModeDesign();
                }
                else if (labelEmployee == DesiredLabelEmployee)
                {
                    labelEmployee.IsClicked = true;
                }
            }
        }
        public void DesActiveAllLabels()
        {
            foreach (ButtonEmployeeOrDay labelEmployee in TLPEmployees.Controls)
            {
                if (labelEmployee.IsClicked)//we re turnin them off all
                {
                    labelEmployee.IsClicked = false;
                    labelEmployee.SetDefaultModeDesign();
                }
            }
        }
        private void LAbelEmployee_Click(object sender, EventArgs e)
        {


            if (sender is ButtonEmployeeOrDay)
            {
                Cursor.Current = Cursors.WaitCursor;

                ButtonEmployeeOrDay clickedLabel = (ButtonEmployeeOrDay)sender;


                //Absolute -> Percentage
                if (clickedLabel.IsClicked)
                {
                    PercentageResizeTLPScheduleAndTlpEmp();

                    //label design
                    DesActiveAllLabels();
                }
                //Percentage -> Absolute
                else
                {
                    if (FocusOnColumnIndexGroup != (null, null, null))
                    {
                        PercentageResizeTLPScheduleAndTlpEmp();
                    }
                    if (IsDayOrWeek)
                    {
                        if (ListOfAllColumnIndexesGroups.Count > 1)
                        {
                            ExpandTableLayoutPanelColumn(clickedLabel.DesiredEmployee.EmployeeId);
                            //label design
                            ActiveDesiredLabel(clickedLabel);
                        }
                    }
                    else
                    {
                        LoadForm(((DateTime)clickedLabel.DesiredDate), true, false, true);
                    }


                }

                Cursor.Current = Cursors.Default;
            }



        }//changing size column of the Table Layout Panel
        private void LabelEmployee_MouseMove(object sender, MouseEventArgs e)
        {

            ButtonEmployeeOrDay labelEmployee = (ButtonEmployeeOrDay)sender;
            if (!labelEmployee.IsClicked)
            {
                labelEmployee.SetActiveModeDesign();
            }

        }
        private void LabelEmployee_MouseLeave(object sender, EventArgs e)
        {
            ButtonEmployeeOrDay labelEmployee = (ButtonEmployeeOrDay)sender;
            if (!labelEmployee.IsClicked)
            {
                labelEmployee.SetDefaultModeDesign();
            }
        }





        ///-Reminder
        public bool isThedayofUCreminder(ClassReminder DesiredReminder, DateTime date)
        {
            //For every day, no repeat
            if (DesiredReminder.PartsRepeat.Length == 1)
            {
                if (DesiredReminder.PartsRepeat[0] == Reminder.NoRepeat)
                {
                    if (date.Date == DesiredReminder.StartTime.Date)
                    {
                        return true;
                    }

                }

                else if (DesiredReminder.PartsRepeat[0] == Reminder.Everyday)
                {
                    if (date.Date >= DesiredReminder.StartTime.Date)
                    {
                        return true;
                    }
                }

            }


            //For every week
            else
            {
                if (date.Date >= DesiredReminder.StartTime.Date)//metel everyweek bas lfare2 gher starttime w fik enta thadid aya date yaeemil repeat
                {
                    for (int i = 1; i < DesiredReminder.PartsRepeat.Length; i++)
                    {
                        if (date.DayOfWeek.ToString() == DesiredReminder.PartsRepeat[i])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;

        }
        public void DisplayUCReminderForTheSelectedDate()
        {
            ParentFormSchedule.panelreminder.Controls.Clear();
            ListUCreminderForTheSelectedDate.Clear();

            DataTable AllReminders = ClassReminder.DisplayReminderInASpecificDate(SelectedDate);

            foreach (DataRow dr in AllReminders.Rows)
            {
                //Badna nt2akad eza lezim ton3ata lal DesiredReminder.DesiredClient
                ClassReminder DesiredReminder = new ClassReminder();

                //Fill DesiredReminder
                DesiredReminder.Idreminder = Convert.ToInt32(dr["reminder_id"]);
                if (dr["client_id"] != DBNull.Value)
                {
                    DesiredReminder.DesiredClient = new ClassClient();
                    DesiredReminder.DesiredClient.ClientId = Convert.ToInt32(dr["client_id"]);
                    DesiredReminder.DesiredClient.Fname = (string)dr["name"];
                    DesiredReminder.DesiredClient.Lname = (string)dr["family_name"];
                }
                DesiredReminder.Reminder = (string)dr["reminder"];
                DesiredReminder.Repeat = (string)dr["repeat"];
                DesiredReminder.StartTime = Convert.ToDateTime(dr["starttime"]);
                UCreminder ucreminder = new UCreminder(DesiredReminder, this, ParentFormSchedule);//li2anno manna bi client reminder

                ListUCreminderForTheSelectedDate.Add(ucreminder);

                //If it's Checked, then it will not appear in schedule.panelreminder
                if (ucreminder.DesiredReminder.IsChecked == false)
                {
                    ucreminder.Dock = DockStyle.Top;
                    ParentFormSchedule.panelreminder.Controls.Add(ucreminder);
                }
            }

        }





        private void TLPSchedule_MouseClick(object sender, MouseEventArgs e)
        {
            (int column, int row) = GetCellPosition(TLPSchedule, e.Location);

            if ((IsDayOrWeek && !IsHistory && !IsDesignBlocked) || (!IsDayOrWeek && TheOnlyEmployee != null && GetWhichEmployeeOrDateForSpecifieColumn(column, false).Item2 >= DateTime.Now.Date))
            {

                if (column > 0)
                {
                    DateTime? StartTime = null;
                    ClassEmployee SelectedEmployee = null;
                    if (IsDayOrWeek)
                    {
                        StartTime = SelectedDate.Date + GetTimeFromRow(row, false);
                        (SelectedEmployee, _) = GetWhichEmployeeOrDateForSpecifieColumn(column, IsDayOrWeek);
                    }
                    else
                    {
                        (_, StartTime) = GetWhichEmployeeOrDateForSpecifieColumn(column, IsDayOrWeek);
                        StartTime += GetTimeFromRow(row, false);
                        if (TheOnlyEmployee != null)
                        {
                            SelectedEmployee = TheOnlyEmployee;
                        }
                        else
                        {
                            //it should be restrictd to dragand drop
                        }

                    }

                    ScheduleForm schedule = this.ParentFormSchedule;
                    Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
                    Program.GreyForm.Show();
                    Appointment appointment = new Appointment(this, SelectedEmployee, (DateTime)StartTime);
                    appointment.Show();
                    //

                }
            }
        }





        void SetListOfAllColumnIndexesGroups()
        {
            int StartintColumnIndex = 1; // Initial column index, assuming 0 is reserved for the time
            if (IsDayOrWeek)
            {
                foreach (ClassEmployee employee in EmployeeScheduleListWorkingOn)
                {
                    if (employee.IsChecked)
                    {
                        var indices = new List<int>();
                        indices.Add(StartintColumnIndex++);
                        ListOfAllColumnIndexesGroups.Add((employee, null, indices));
                    }
                }
            }
            else
            {
                foreach (DateTime desireddate in ListDaysOfDesiredWeek)
                {
                    var indices = new List<int>();
                    indices.Add(StartintColumnIndex++);
                    ListOfAllColumnIndexesGroups.Add((null, desireddate, indices));
                }
            }

        }
        void InsertHistroyToSqlIfNecessary()
        {
            if (!SQLToProject.CheckIfHistoryExistsToday(DateTime.Now))//eza exists update 
            {
                for (int i = 0; i < TotalEmployeeScheduleList.Count; i++)//both of the string are in the order of the rank
                {
                    //getting availibility for this day of every employee
                    int dayOfWeekInt = ((int)DateTime.Today.DayOfWeek + 6) % 7;

                    string availability = "";
                    string[] HoursOfThedays = EmployeeScheduleListWorkingOn[i].Availability.Split('/');
                    availability += HoursOfThedays[dayOfWeekInt];

                    ProjectToSql.InsertHistoryEmployeeavailibility(DateTime.Now, EmployeeScheduleListWorkingOn[i].EmployeeId, (int)EmployeeScheduleListWorkingOn[i].Rank, availability);
                }
            }
        }
        void AddAppointmentsToTlpSchedule()
        {

            foreach (ClassAppointment DesiredAppointment in AppointmentsListWorkingOn)
            {
                if ((DesiredAppointment.IsCompleted && ParentFormSchedule.checkBoxComplete.Checked) || (DesiredAppointment.IsCanceled && ParentFormSchedule.checkBoxCancel.Checked) || (!DesiredAppointment.IsCompleted && !DesiredAppointment.IsCanceled && ParentFormSchedule.checkBoxOnPending.Checked))
                {
                    AddUCappointmentsInTLP(DesiredAppointment);
                }

            }


        }




        public List<DateTime> FillWeekLists(DateTime SelectedDate)
        {
            // Adjust the start of the week to be Monday, and include Sunday as the last day of the week
            int delta = (int)DayOfWeek.Monday - (SelectedDate.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)SelectedDate.DayOfWeek);
            DateTime startOfWeek = SelectedDate.AddDays(delta);

            List<DateTime> listDaysOfDesiredWeek = new List<DateTime>();

            for (int i = 0; i < 7; i++)
            {
                listDaysOfDesiredWeek.Add(startOfWeek.AddDays(i).Date);
            }

            return listDaysOfDesiredWeek;
        }
        public void FillEmployeLists()
        {
            if (SelectedDate.Date >= DateTime.Now.Date)//present-future
            {
                EmployeeScheduleListWorkingOn = ClassEmployee.GetEmployeeScheduleMemberASC();

                int NoEmployeeChecked = 0;
                for (int i = 0; i < EmployeeScheduleListWorkingOn.Count; i++)
                {
                    ClassEmployee DesiredEmp = TotalEmployeeScheduleList.FirstOrDefault(e => e.EmployeeId == EmployeeScheduleListWorkingOn[i].EmployeeId);
                    if (DesiredEmp.IsChecked)
                    {
                        EmployeeScheduleListWorkingOn[i].IsChecked = true;
                        NoEmployeeChecked++;
                        TheOnlyEmployee = EmployeeScheduleListWorkingOn[i];
                    }

                }
                if (NoEmployeeChecked != 1)
                {
                    TheOnlyEmployee = null;
                }
            }
            else  //History
            {
                EmployeeScheduleListWorkingOn = new List<ClassEmployee>();

                DataTable RankNAvailabilityEmployeesASC = SQLToProject.DisplayRankEmployeesNAvailabilityASC(SelectedDate);

                //there was Active Employees In this Day
                if (RankNAvailabilityEmployeesASC.Rows.Count > 0)
                {
                    foreach (DataRow datarow in RankNAvailabilityEmployeesASC.Rows)
                    {
                        //this is like a View Model object
                        ClassEmployee employee = new ClassEmployee();
                        employee.EmployeeId = Convert.ToInt32(datarow["employee_id"]);
                        employee.Fname = datarow["first_name"] is DBNull ? null : (string)datarow["first_name"];
                        employee.Lname = datarow["last_name"] is DBNull ? null : (string)datarow["last_name"];
                        employee.Rank = datarow["rank"] is DBNull ? null : Convert.ToInt32(datarow["rank"]);
                        employee.Availability = datarow["availability"] is DBNull ? null : (string)datarow["availability"];

                        //IsChecked Property
                        ClassEmployee DesiredEmp = TotalEmployeeScheduleList.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
                        //so in the past, by default men bayno , even la shelne men el management, since eendo history, bas men bayno in case no fliter mode is available, yaane all the coaches mdawayin
                        if (DesiredEmp != null && DesiredEmp.IsChecked)
                        {
                            employee.IsChecked = true;//since he is from the past
                        }
                        else
                        {
                            if (IsEmployeeFilterModeOn)
                            {
                                employee.IsChecked = false;
                            }
                            else
                            {
                                employee.IsChecked = true;
                            }
                        }



                        EmployeeScheduleListWorkingOn.Add(employee);
                    }
                }
            }




        }//Display the title and the ucappointments
        bool CheckIfAnyEmployeeAvailable()
        {

            foreach (ClassEmployee emp in EmployeeScheduleListWorkingOn)
            {
                if (emp.IsChecked == true)
                {
                    return true;
                }
            }
            return false;

        }


        public void ChangePositionUCappointments(UCappointment DesiredUCApp, ClassAppointment OldAppointment, ClassAppointment UpdatedAppointment)
        {
            (int OldRowIndexStart, int OldRowIndexEnd) = GetUCAppointmentRowIndexes(OldAppointment);//hone el el start  w el end time before updating
            (int NewRowIndexStart, int NewRowIndexEnd) = GetUCAppointmentRowIndexes(UpdatedAppointment);//hone el  start  w el end time after updating

            int RowSpan = GetControlSpan(NewRowIndexStart, NewRowIndexEnd);

            TLPSchedule.SetRowSpan(DesiredUCApp, RowSpan);

            if (IsDayOrWeek)
            {
                PurellyAddingAndRemovingUC(UpdatedAppointment.DesiredEmployee.EmployeeId, null, NewRowIndexStart, OldAppointment.DesiredEmployee.EmployeeId, null, OldRowIndexStart, DesiredUCApp);

            }
            else
            {
                PurellyAddingAndRemovingUC(null, UpdatedAppointment.StartTime, NewRowIndexStart, null, OldAppointment.StartTime, OldRowIndexStart, DesiredUCApp);
            }
        }
        public void RemoveUcAppointmentFromTLP(UCappointment DesiredUCApp)
        {
            DateTime? DesiredDate = null;
            int? EmployeeId = null;

            if (IsDayOrWeek)
            {
                EmployeeId = DesiredUCApp.DesiredAppointmentUCApp.DesiredEmployee.EmployeeId;
            }
            else
            {
                DesiredDate = DesiredUCApp.DesiredAppointmentUCApp.StartTime.Date;
            }

            (int RowIndexStart, int RowIndexEnd) = GetUCAppointmentRowIndexes(DesiredUCApp.DesiredAppointmentUCApp);

            PurelyRemovingUcApp(EmployeeId, DesiredDate, RowIndexStart, DesiredUCApp);
        }
        public UCappointment AddUCappointmentsInTLP(ClassAppointment DesiredAppointment)
        {

            UCappointment DesiredUCApp = new UCappointment(DesiredAppointment, this);
            DesiredUCApp.Dock = DockStyle.Fill;
            DesiredUCApp.UCAppIsDroped += Uc_UCAppIsDroped;

            DateTime? DesiredDate = null;
            int? EmployeeId = null;

            if (IsDayOrWeek)
            {
                EmployeeId = DesiredUCApp.DesiredAppointmentUCApp.DesiredEmployee.EmployeeId;
            }
            else
            {
                DesiredDate = DesiredUCApp.DesiredAppointmentUCApp.StartTime.Date;
            }

            (int RowIndexStart, int RowIndexEnd) = GetUCAppointmentRowIndexes(DesiredUCApp.DesiredAppointmentUCApp);

            int RowSpan = GetControlSpan(RowIndexStart, RowIndexEnd);
            TLPSchedule.SetRowSpan(DesiredUCApp, RowSpan);


            PurellyAddingUcApp(EmployeeId, DesiredDate, RowIndexStart, DesiredUCApp);

            return DesiredUCApp;
        }
        int GetControlSpan(int StartIndex, int EndIndex)
        {
            int RowSpan = (EndIndex - StartIndex) + 1;
            if (RowSpan <= 0)//in case naeayna same hours
            {
                RowSpan = 1;
            }
            return RowSpan;
        }
        public (int, int) GetUCAppointmentRowIndexes(ClassAppointment DesiredAppointment)
        {
            TimeSpan starttimeTimeSpan = DesiredAppointment.StartTime.TimeOfDay;
            int PositionRowStart = GetRowFromTime(starttimeTimeSpan, false);

            TimeSpan endtimeTimeSpan = DesiredAppointment.EndTime.TimeOfDay;
            int PositionRowEnd = GetRowFromTime(endtimeTimeSpan, true);


            return (PositionRowStart, PositionRowEnd);//position flowlayoutpanel hiye position employee bel list-1 
        }


        private void labelMember_Click(object sender, EventArgs e)
        {
            EmployeeSchedule empSch = new EmployeeSchedule(this);
            empSch.ParentucSchedule = this;
            Point locationRelativeToScreen = labelMember.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(FLPMembers.Width - empSch.Width, 25);
            empSch.Location = locationRelativeToScreen;
            empSch.Show();
            //
            ParentFormSchedule.CloseNotfBanner();
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (IsDayOrWeek)
            {
                LoadForm(SelectedDate.AddDays(+1), IsDayOrWeek, false, true);
            }
            else
            {
                DateTime TargetedDate = SelectedDate.AddDays(+7);
                LoadForm(TargetedDate, IsDayOrWeek, false, true);
            }
            Cursor.Current = Cursors.Default;

            //
            ParentFormSchedule.CloseNotfBanner();
        }
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (IsDayOrWeek)
            {
                LoadForm(SelectedDate.AddDays(-1), IsDayOrWeek, false, true);
            }
            else
            {
                DateTime TargetedDate = SelectedDate.AddDays(-7);
                LoadForm(TargetedDate, IsDayOrWeek, false, true);
            }
            Cursor.Current = Cursors.Default;

            //
            ParentFormSchedule.CloseNotfBanner();
        }
        private void buttonToday_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            if (IsDayOrWeek)
            {
                if (DateTime.Now.Date != SelectedDate.Date)
                {
                    LoadForm(DateTime.Now, IsDayOrWeek, true, true);
                }
            }
            else
            {
                if (!PresentWeek.Any(d => d.Date == SelectedDate.Date))
                {
                    LoadForm(DateTime.Now, IsDayOrWeek, true, true);
                }
            }



            Cursor.Current = Cursors.Default;

            //
            ParentFormSchedule.CloseNotfBanner();
        }
        private void labelDate_Click(object sender, EventArgs e)
        {
            Program.GreyForm = new GreyColor(Program.HomeForm, true, false, Color.Transparent);
            Program.GreyForm.Show();
            //UCmonth show
            Point locationRelativeToScreen = labelDate.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-6, 25);
            ParentFormSchedule.calanderForm.Location = locationRelativeToScreen;
            ParentFormSchedule.calanderForm.Size = new Size(365, 307);
            ParentFormSchedule.calanderForm.Show();

            ParentFormSchedule.calanderForm.SelectedDateChanged += SelectedDate_Changed;

            //Showing the ucmonth from the calanderday in the date that we are
            ParentFormSchedule.calanderForm.DateCalander = SelectedDate;
            ParentFormSchedule.calanderForm.SelectedDate = SelectedDate;
            if (ParentFormSchedule.calanderForm.wichuccalander == 2)
            {
                ParentFormSchedule.calanderForm.wichuccalander = 1;
                ParentFormSchedule.calanderForm.tableLayoutPanelMonth.Controls.Remove(ParentFormSchedule.calanderForm.uccalandermonth);
                ParentFormSchedule.calanderForm.tableLayoutPanelMonth.Controls.Add(ParentFormSchedule.calanderForm.uccalanderday);
            }
            else if (ParentFormSchedule.calanderForm.wichuccalander == 3)
            {
                ParentFormSchedule.calanderForm.wichuccalander = 1;
                ParentFormSchedule.calanderForm.tableLayoutPanelMonth.Controls.Remove(ParentFormSchedule.calanderForm.uccalanderyear);
                ParentFormSchedule.calanderForm.tableLayoutPanelMonth.Controls.Add(ParentFormSchedule.calanderForm.uccalanderday);

            }

            ParentFormSchedule.calanderForm.EditLabelUCdays();


            //
            ParentFormSchedule.CloseNotfBanner();
        }
        public void SelectedDate_Changed(object sender, EventArgs e)
        {
            if (SelectedDate.Date != ParentFormSchedule.calanderForm.DateCalander.Date)
            {


                //edit DateUCDay

                SelectedDate = ParentFormSchedule.calanderForm.DateCalander.Date;
                if (IsDayOrWeek)
                {
                    LoadForm(ParentFormSchedule.calanderForm.DateCalander, IsDayOrWeek, false, true);
                }
                else
                {
                    if (!ListDaysOfDesiredWeek.Any(d => d.Date == SelectedDate.Date))
                    {
                        LoadForm(ParentFormSchedule.calanderForm.DateCalander, IsDayOrWeek, false, true);
                    }
                }

                ParentFormSchedule.calanderForm.Hide();

                //
                ParentFormSchedule.CloseNotfBanner();
            }
        }






        private void labelDate_MouseMove(object sender, MouseEventArgs e)
        {
            labelDate.ForeColor = Program.BoldColor;
            DownArrow.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "down-arrow-BoldColor.png");
        }
        private void labelDate_MouseLeave(object sender, EventArgs e)
        {
            labelDate.ForeColor = Color.Black;
            DownArrow.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "down-arrow-Black.png");
        }
        private void labelMember_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsEmployeeFilterModeOn)
            {
                labelMember.ForeColor = Color.FromArgb(0, 160, 0);
                pictureBoxMember.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "down-arrow-LighterGreenColor.png");
            }
            else
            {
                labelMember.ForeColor = Program.BoldColor;
                pictureBoxMember.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "down-arrow-BoldColor.png");
            }
        }
        private void labelMember_MouseLeave(object sender, EventArgs e)
        {
            if (IsEmployeeFilterModeOn)
            {
                labelMember.ForeColor = Color.Green;
                pictureBoxMember.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "down-arrow-GreenColor.png");
            }
            else
            {
                labelMember.ForeColor = Color.Black;
                pictureBoxMember.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "down-arrow-Black.png");
            }
        }
        private void comboBoxDaysOrWeek_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
        private void comboBoxDaysOrWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelDate.Select();
            Cursor.Current = Cursors.WaitCursor;
            //

            if (!IsDayOrWeek && comboBoxDaysOrWeek.SelectedItem.ToString() == EnumDaysOrWeek.Day.ToString())
            {
                LoadForm(SelectedDate, true, false, true);
            }
            else if (IsDayOrWeek && comboBoxDaysOrWeek.SelectedItem.ToString() == EnumDaysOrWeek.Week.ToString())
            {
                LoadForm(SelectedDate, false, false, true);
            }

            Cursor.Current = Cursors.Default;

        }
        private void comboBoxDaysOrWeek_DropDownClosed(object sender, EventArgs e)
        {
            labelDate.Select();
        }
        private void comboBoxDaysOrWeek_MouseLeave(object sender, EventArgs e)
        {

        }



        /////////these are for the values of the uc while drag/drop operation

        (ClassEmployee, DateTime?, List<int>) OldColumnIndexGroupOfDesiredUC;
        int OldColumnofDraggedUC;//old column is the exact column li ken aalaya el uc
        int OldRowOfDraggedUC;

        List<UCappointment> ListAllConnectedUCsToTheOneWereRemoving;//this serpent doesn tonly cover the area of the removed uc, but also outside the are, which
                                                                    //Which we care about , because the one we dont see could cause us problems, that s why the one we dont see if they exist, we dont do the auto size



        UCappointment UCApointmentDraged;
        (ClassEmployee, DateTime?, List<int>) ColumnIndexGroupOfDraggingUC = (null, null, null);//stores the index columns Related To employee , when we re dragging a uc
        private (int, int) hoveredCellColmnRow = (-1, -1);  // Stores the  (column,row) of the hovered cell


        int NbreofRowsHighlighted = -1;//how many rows we need to highlight while mouse hover or dragging
        Brush hoverBrush = new SolidBrush(Color.FromArgb(50, 109, 122, 224)); // Change the color as needed




        void CreateTLPDesign()
        {

            //uc1.UCAppIsDroped += Uc1_UCAppIsDroped;

            //         
            if (TLPSchedule == null && TLPEmployees == null)
            {
                //TLPSchedule
                TLPSchedule = new TableLayoutPanel();
                TLPSchedule.AllowDrop = true;
                TLPSchedule.Dock = DockStyle.Fill;
                TLPSchedule.AutoScroll = true;
                TLPSchedule.BackColor = Color.FromArgb(249, 246, 254);
                TLPSchedule.Margin = new Padding(0, 0, 0, 0);
                TLPSchedule.AutoSize = false;
                //Hours
                TLPSchedule.RowCount = 96;
                for (int i = 0; i < TLPSchedule.RowCount; i++)
                {
                    TLPSchedule.RowStyles.Add(new RowStyle(SizeType.Absolute, 19));
                }


                //TLPEmployee
                TLPEmployees = new TableLayoutPanel();
                TLPEmployees.Dock = DockStyle.Fill;
                TLPEmployees.RowCount = 1;
                TLPEmployees.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
                TLPEmployees.Margin = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                TLPEmployees.BackColor = TLPSchedule.BackColor;

                //Time

                //Time in Tlp employee
                TLPEmployees.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
                TLPEmployees.ColumnCount++;

                //Time in TLP Schedule, ejbare absoloute
                TLPSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
                TLPSchedule.ColumnCount++;



                //
                for (int i = 0; i < TLPSchedule.RowCount; i += 4)
                {
                    Label LabelTime = new Label();
                    LabelTime.Dock = DockStyle.Fill;
                    LabelTime.BackColor = TLPSchedule.BackColor;
                    LabelTime.ForeColor = Color.FromArgb(64, 64, 64);
                    LabelTime.Dock = DockStyle.Fill;
                    LabelTime.TextAlign = ContentAlignment.TopRight;
                    LabelTime.Font = new Font("Segoe UI", 10, FontStyle.Regular);

                    TimeSpan Time = TimeSpan.FromHours(i / 4);

                    DateTime dateTime = DateTime.Today.Add(Time);//datetime it's a reference
                    string timestring = dateTime.ToString("h tt");
                    string[] partstime = timestring.Split(' ');
                    LabelTime.Text = partstime[0] + " " + partstime[1];


                    TLPSchedule.Controls.Add(LabelTime, 0, i);
                    TLPSchedule.SetRowSpan(LabelTime, 4);
                }


                //Events
                TLPSchedule.Scroll += TLPSchedule_Scroll;
                TLPSchedule.MouseWheel += TLPSchedule_MouseWheel; ;

                TLPSchedule.MouseWheel += TLPSchedule_MouseMove;
                TLPSchedule.MouseMove += TLPSchedule_MouseMove;

                TLPSchedule.MouseLeave += TLPSchedule_MouseLeave;

                TLPSchedule.CellPaint += TLPSchedule_CellPaint;
                TLPSchedule.DragDrop += TLPSchedule_DragDrop;
                TLPSchedule.DragEnter += TLPSchedule_DragEnter;
                TLPSchedule.DragOver += TLPSchedule_DragOver;

                TLPSchedule.MouseClick += TLPSchedule_MouseClick;
                //
                this.TLPGlobal.Controls.Add(TLPEmployees, 0, 1);
                this.TLPGlobal.Controls.Add(TLPSchedule, 0, 2);



            }

        }



        void SetTLPSchGroupColumn()
        {
            ResetTLPScheduleToInitialState();

            TLPSchedule.SuspendLayout();

            if (ListOfAllColumnIndexesGroups.Count > 0)
            {
                //Employees, ejbare percentage
                foreach ((ClassEmployee, DateTime?, List<int>) Group in ListOfAllColumnIndexesGroups)
                {
                    foreach (int ColumnIndex in Group.Item3)
                    {
                        TLPSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                        TLPSchedule.ColumnCount++;
                    }
                }


            }
            else
            {
                TLPSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                TLPSchedule.ColumnCount++;
            }

            TLPSchedule.ResumeLayout();
        }
        void SetTLPEmployeesColumn()//always called after SetTLPSchGroupColumn 
        {
            ResetTLPEmployeeToInitialState();

            TLPSchedule.SuspendLayout();
            for (int i = 0; i < ListOfAllColumnIndexesGroups.Count; i++)
            {
                TLPEmployees.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                TLPEmployees.ColumnCount++;


                ButtonEmployeeOrDay buttonEmployeeOrDay = CreateLabelEmployee();


                if (IsDayOrWeek)
                {
                    buttonEmployeeOrDay.DesiredEmployee = ListOfAllColumnIndexesGroups[i].Item1;
                    buttonEmployeeOrDay.Text = ListOfAllColumnIndexesGroups[i].Item1.Fname + " " + ListOfAllColumnIndexesGroups[i].Item1.Lname;
                }
                else
                {
                    buttonEmployeeOrDay.DesiredDate = (DateTime)ListOfAllColumnIndexesGroups[i].Item2;
                    buttonEmployeeOrDay.Text = ((DateTime)ListOfAllColumnIndexesGroups[i].Item2).ToString("ddd dd");
                }

                buttonEmployeeOrDay.SetButtonDesignBehavor(IsDayOrWeek, false);//ejbare tahet el Set fow

                TLPEmployees.Controls.Add(buttonEmployeeOrDay, i + 1, 0);//i+1, lieanno first column kermel el time
            }
            TLPSchedule.ResumeLayout();
        }
        void ResetTLPScheduleToInitialState()
        {
            TLPSchedule.SuspendLayout();  // Suspend layout to improve performance
            TLPSchedule.ColumnCount = 1;

            for (int i = TLPSchedule.Controls.Count - 1; i >= 0; i--)
            {
                var control = TLPSchedule.Controls[i];
                if (TLPSchedule.GetColumn(control) != 0)  //kermel eltime label
                {
                    TLPSchedule.Controls.Remove(control);
                }
            }
            while (TLPSchedule.ColumnStyles.Count > 1)
            {
                TLPSchedule.ColumnStyles.RemoveAt(1);
            }
            TLPSchedule.ResumeLayout();
        }
        void ResetTLPEmployeeToInitialState()
        {
            TLPEmployees.SuspendLayout();  // Suspend layout to improve performance
            TLPEmployees.ColumnCount = 1;

            for (int i = TLPEmployees.Controls.Count - 1; i >= 0; i--)
            {
                var control = TLPEmployees.Controls[i];

                TLPEmployees.Controls.Remove(control);

            }
            while (TLPEmployees.ColumnStyles.Count > 1)
            {
                TLPEmployees.ColumnStyles.RemoveAt(1);
            }
            TLPEmployees.ResumeLayout();
        }
        bool IsDesignBlocked;
        void BlockedModeDesign(string OutputText)
        {
            ResetTLPEmployeeToInitialState();
            ResetTLPScheduleToInitialState();

            //we add only one column in the block design
            TLPEmployees.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            TLPEmployees.ColumnCount++;
            TLPSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            TLPSchedule.ColumnCount++;

            ButtonEmployeeOrDay buttonEmployee = CreateLabelEmployee();
            buttonEmployee.Text = OutputText;
            buttonEmployee.SetButtonDesignBehavor(IsDayOrWeek, true);//ejbare tahet el Set fow

            TLPEmployees.Controls.Add(buttonEmployee, 1, 0);//1, lieanno first column kermel el time

            //TLPSchedule.Enabled = false;

        }


        public void ExpandTableLayoutPanelColumn(int? empId)
        {
            TLPSchedule.SuspendLayout();


            FocusOnMaxWidth = (int)((TLPSchedule.Width - TLPSchedule.GetColumnWidths()[0]) * 0.85);//so he will be 90 % of the columns without the first column


            if (empId != null)//eza kenit null,yaane i  m using same FocusOnColumnIndexGroup, usd in remove or insert column
            {
                FocusOnColumnIndexGroup = GetWhichDesiredGroup((int)empId, null);
            }


            int DesiredWidthOfTheGroup = FocusOnMaxWidth;
            //TLPAppointment 

            int DesiredWidthPerColumn = DesiredWidthOfTheGroup / FocusOnColumnIndexGroup.Item3.Count;
            foreach (int ColumnIndex in FocusOnColumnIndexGroup.Item3)
            {
                TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Absolute, DesiredWidthPerColumn);
            }


            //Employee tlp
            int i = 1;//i=0 lal time
            foreach ((ClassEmployee, DateTime?, List<int>) Group in ListOfAllColumnIndexesGroups)
            {
                if (FocusOnColumnIndexGroup.Item1.EmployeeId == Group.Item1.EmployeeId)
                {
                    TLPEmployees.ColumnStyles[i] = new ColumnStyle(SizeType.Absolute, DesiredWidthOfTheGroup);
                    break;
                }
                else
                {
                    i++;
                }
            }



            TLPSchedule.ResumeLayout();
        }
        public void PercentageResizeTLPScheduleAndTlpEmp()
        {
            TLPSchedule.SuspendLayout();  // Suspend layout to improve performance();

            FocusOnColumnIndexGroup = (null, null, null);
            //
            if (ListOfAllColumnIndexesGroups.Count > 0)
            {
                float PercentageOfEachGroup = 100 / ListOfAllColumnIndexesGroups.Count;

                float TotalPercent = 0;
                int i = 1;


                foreach ((ClassEmployee, DateTime?, List<int>) Group in ListOfAllColumnIndexesGroups)
                {
                    //TLPSchedule
                    TLPEmployees.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, PercentageOfEachGroup);
                    i++;
                    //TLPAppoitment
                    float PercentageOfEachColumn = PercentageOfEachGroup / Group.Item3.Count;
                    foreach (int ColumnIndex in Group.Item3)
                    {
                        TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
                        TotalPercent += PercentageOfEachColumn;
                    }
                }
            }

            TLPSchedule.ResumeLayout();  // Suspend layout to improve performance();

        }


        private void ParentFormSchedule_ScheduleFormResize(object sender, EventArgs e)
        {
            if (TLPSchedule.ColumnCount > 1)
            {
                PercentageResizeTLPScheduleAndTlpEmp();
                DesActiveAllLabels();
                FocusOnColumnIndexGroup = (null, null, null);
                UpdateTimeIndicatorLinePosition();
            }
        }

        private void TLPSchedule_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateTimeIndicatorLinePosition();
        }
        private void TLPSchedule_MouseWheel(object sender, MouseEventArgs e)
        {
            UpdateTimeIndicatorLinePosition();
        }



        //Functions Used By code
        //void UndoMode((ClassEmployee, List<int>) DesiredColumnIndexesGroup, int NewRow)
        //{
        //    AddUc(DesiredColumnIndexesGroup, NewRow);
        //    RemoveUc(null);
        //}


        void PurellyAddingAndRemovingUC(int? AddempId, DateTime? AddDesiredDate, int AddRow, int? RmvempId, DateTime? RmvDesiredDate, int RmvRow, UCappointment DesiredUCApp)
        {//it will opeate kaeeano dragrop

            if (!IsCursorBlocked)
            {
                Cursor.Current = Cursors.WaitCursor;
            }


            (ClassEmployee, DateTime?, List<int>) RmvDesiredColumnIndexesGroup = (null, null, null);
            if (RmvempId != null)
            {
                RmvDesiredColumnIndexesGroup = GetWhichDesiredGroup((int)RmvempId, null);
            }
            else if (RmvDesiredDate != null)
            {
                RmvDesiredColumnIndexesGroup = GetWhichDesiredGroup(null, (DateTime)RmvDesiredDate);
            }


            SetSerpentBeforeRemovingAndThenRemoveIt(RmvDesiredColumnIndexesGroup, DesiredUCApp);

            bool IsDesignFixed = RemoveUc(RmvDesiredColumnIndexesGroup, RmvRow, null, DesiredUCApp);



            (ClassEmployee, DateTime?, List<int>) AddDesiredColumnIndexesGroup = (null, null, null);
            if (AddempId != null)
            {
                AddDesiredColumnIndexesGroup = GetWhichDesiredGroup((int)AddempId, null);
            }
            else if (AddDesiredDate != null)
            {
                AddDesiredColumnIndexesGroup = GetWhichDesiredGroup(null, (DateTime)AddDesiredDate);
            }

            AddUc(AddDesiredColumnIndexesGroup, AddRow, DesiredUCApp);



            if (IsDesignFixed)
            {
                CheckIfLastColumnsShouldBeRemoved(RmvDesiredColumnIndexesGroup);//lieanno once design is fixed, controls byetghara el idex tb3un wbi taria to empty the last column and remove it
            }

            if (!IsCursorBlocked)
            {
                Cursor.Current = Cursors.Default;
            }
        }
        void PurellyAddingUcApp(int? empId, DateTime? DesiredDate, int NewRow, UCappointment DesiredUCApp)
        {
            if (!IsCursorBlocked)
            {
                Cursor.Current = Cursors.WaitCursor;
            }

            (ClassEmployee, DateTime?, List<int>) DesiredGroup = (null, null, null);
            if (empId != null)
            {
                DesiredGroup = GetWhichDesiredGroup((int)empId, null);
            }
            else if (DesiredDate != null)
            {
                DesiredGroup = GetWhichDesiredGroup(null, (DateTime)DesiredDate);
            }


            AddUc(DesiredGroup, NewRow, DesiredUCApp);


            if (!IsCursorBlocked)
            {
                Cursor.Current = Cursors.Default;
            }
        }
        void PurelyRemovingUcApp(int? empId, DateTime? DesiredDate, int Row, UCappointment DesiredUCApp)
        {
            if (!IsCursorBlocked)
            {
                Cursor.Current = Cursors.WaitCursor;
            }

            (ClassEmployee, DateTime?, List<int>) DesiredColumnIndexesGroup = (null, null, null);
            if (empId != null)
            {
                DesiredColumnIndexesGroup = GetWhichDesiredGroup((int)empId, null);
            }
            else if (DesiredDate != null)
            {
                DesiredColumnIndexesGroup = GetWhichDesiredGroup(null, (DateTime)DesiredDate);
            }

            SetSerpentBeforeRemovingAndThenRemoveIt(DesiredColumnIndexesGroup, DesiredUCApp);
            bool IsDesignFixed = RemoveUc(DesiredColumnIndexesGroup, Row, null, DesiredUCApp);
            if (IsDesignFixed)
            {
                CheckIfLastColumnsShouldBeRemoved(DesiredColumnIndexesGroup);//lieanno once design is fixed, controls byetghara el idex tb3un wbi taria to empty the last column and remove it
            }


            if (!IsCursorBlocked)
            {
                Cursor.Current = Cursors.Default;
            }

        }


        (ClassEmployee, DateTime?, List<int>) GetWhichDesiredGroup(int? empId, DateTime? DesiredDate)
        {
            if (empId != null)
            {
                foreach ((ClassEmployee, DateTime?, List<int>) Group in ListOfAllColumnIndexesGroups)
                {
                    if (Group.Item1.EmployeeId == empId)
                    {
                        return Group;
                    }
                }
            }
            else if (DesiredDate != null)
            {
                foreach ((ClassEmployee, DateTime?, List<int>) Group in ListOfAllColumnIndexesGroups)
                {
                    if (((DateTime)Group.Item2).Date == ((DateTime)DesiredDate).Date)
                    {
                        return Group;
                    }
                }
            }

            return (null, null, null);
        }
        TimeSpan GetTimeFromRow(int row, bool IsEndTIme)
        {
            if (IsEndTIme)
            {
                row++;
            }

            int TotalHour = 24;
            int TotalRow = TLPSchedule.RowCount;

            int hours = (row * TotalHour) / TotalRow;

            int remainderRows = row % (TotalRow / TotalHour);
            int minutes = remainderRows * 15;


            return new TimeSpan(hours, minutes, 0);
        }
        public int GetRowFromTime(TimeSpan Time, bool IsEndTime)
        {
            int TotalHour = 24;
            int TotalRow = TLPSchedule.RowCount;

            int PositionRow = (Time.Hours * TotalRow) / TotalHour;

            //1 Row -> 15 min
            int j = 0;
            for (int i = 0; i <= 45; i += 15)
            {
                if (i <= Time.Minutes && Time.Minutes < (i + 15))
                {
                    PositionRow += j;
                    break;
                }
                j++;
            }

            if (IsEndTime)
            {
                // Adjust for end time
                if (Time.Minutes % 15 == 0 && Time.Hours != 0)
                {
                    PositionRow -= 1;
                }
            }


            return PositionRow;
        }

        (ClassEmployee, DateTime?) GetWhichEmployeeOrDateForSpecifieColumn(int ColumnIndex, bool isDayOrWeek)
        {
            foreach ((ClassEmployee, DateTime?, List<int>) Group in ListOfAllColumnIndexesGroups)
            {
                if (Group.Item3.Contains(ColumnIndex))
                {
                    if (isDayOrWeek)
                    {
                        return (Group.Item1, null);
                    }
                    else
                    {
                        return (null, Group.Item2);
                    }
                }
            }
            return (null, null);
        }


        private void TLPSchedule_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

            UCApointmentDraged = e.Data.GetData(typeof(UCappointment)) as UCappointment;
            if (UCApointmentDraged.Parent != null)
            {

                OldColumnofDraggedUC = TLPSchedule.GetColumn(UCApointmentDraged);
                OldRowOfDraggedUC = TLPSchedule.GetRow(UCApointmentDraged);

                OldColumnIndexGroupOfDesiredUC = GetWichDesiredIndexesGroup(OldColumnofDraggedUC);

                SetSerpentBeforeRemovingAndThenRemoveIt(OldColumnIndexGroupOfDesiredUC, UCApointmentDraged);

            }
        }


        //Scrolling
        private Timer scrollTimer;

        private const int ScrollMarginSmall = 30; // Smaller distance from the edge to start scrolling
        private const int ScrollSpeedFast = 30;   // Faster scrolling speed

        private const int ScrollMarginLarge = 60; // Larger distance from the edge to start scrolling
        private const int ScrollSpeedSlow = 10;   // Slower scrolling speed

        private void TLPSchedule_DragOver(object sender, DragEventArgs e)
        {

            Point clientPoint = TLPSchedule.PointToClient(new Point(e.X, e.Y));
            SetValuesthatWillAffectselection(clientPoint);


            // Check if mouse is near the edges
            if (clientPoint.Y <= ScrollMarginLarge)
            {
                // Near the top edge, determine scroll speed
                if (clientPoint.Y <= ScrollMarginSmall)
                {
                    StartScrolling("Up", ScrollSpeedFast);
                }
                else
                {
                    StartScrolling("Up", ScrollSpeedSlow);
                }
            }
            else if (clientPoint.Y >= TLPSchedule.Height - ScrollMarginLarge)
            {
                // Near the bottom edge, determine scroll speed
                if (clientPoint.Y >= TLPSchedule.Height - ScrollMarginSmall)
                {
                    StartScrolling("Down", ScrollSpeedFast);
                }
                else
                {
                    StartScrolling("Down", ScrollSpeedSlow);
                }
            }
            else
            {
                scrollTimer.Stop();
            }

            e.Effect = DragDropEffects.Move;

        }
        private void StartScrolling(string direction, int speed)
        {
            scrollTimer.Tag = new ScrollInfo { Direction = direction, Speed = speed };
            scrollTimer.Start();
        }
        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            if (scrollTimer.Tag is ScrollInfo scrollInfo)
            {
                if (scrollInfo.Direction == "Up")
                {
                    // Scroll up
                    if (TLPSchedule.VerticalScroll.Value > 0)
                    {
                        TLPSchedule.VerticalScroll.Value = Math.Max(0, TLPSchedule.VerticalScroll.Value - scrollInfo.Speed);
                        TLPSchedule.PerformLayout();
                        UpdateTimeIndicatorLinePosition();


                    }
                }
                else if (scrollInfo.Direction == "Down")
                {
                    // Scroll down
                    if (TLPSchedule.VerticalScroll.Value < TLPSchedule.VerticalScroll.Maximum)
                    {
                        TLPSchedule.VerticalScroll.Value = Math.Min(TLPSchedule.VerticalScroll.Maximum, TLPSchedule.VerticalScroll.Value + scrollInfo.Speed);
                        TLPSchedule.PerformLayout();
                        UpdateTimeIndicatorLinePosition();

                    }
                }
            }
        }
        private class ScrollInfo
        {
            public string Direction { get; set; }
            public int Speed { get; set; }
        }




        bool DragDropIsEntered;
        private void Uc_UCAppIsDroped(object sender, EventArgs e)//kermel eza kabbayneha outside the bounds what to return it mahalla
        {
            scrollTimer.Stop();

            if (!DragDropIsEntered)//which mean we ve started an dragdrop operation but we throw it outside the bound, which mean dragdrop event wont be activated, so we need to reset the values
            {
                TLPSchedule.Controls.Add(UCApointmentDraged, OldColumnofDraggedUC, OldRowOfDraggedUC);
                ResetSelection();
            }
            DragDropIsEntered = false;//reset the value

        }
        private void TLPSchedule_DragDrop(object sender, DragEventArgs e)
        {
            DragDropIsEntered = true;
            Point clientPoint = TLPSchedule.PointToClient(new Point(e.X, e.Y)); // Convert the screen coordinates to client coordinates
            (int ColumnIndex, int RowIndexStart) = GetCellPosition(TLPSchedule, clientPoint);


            if (ColumnIndexGroupOfDraggingUC != (null, null, null))//ejbariyye
            {
                if (RowIndexStart > 0)
                {
                    RowIndexStart--;//lieanno deyman aam nhotto fawea bel row matrah ma el cursor, for visual things
                }


                //adding
                if (UCApointmentDraged != null && ColumnIndex >= 1 && RowIndexStart >= 0)//first column for the timer
                {
                    (int StartingColumn, int EndingColumn, int StartingRow, int EndingRow) = GetRectangle4Points(RowIndexStart, ColumnIndexGroupOfDraggingUC, UCApointmentDraged);


                    if (CheckIfPositionAvailable(StartingColumn, StartingRow))
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        DragDropBusinessLogic(ColumnIndex, RowIndexStart);

                        //

                        List<UCappointment> NewListUC = GetListOfAllControlsInSpecifiedArea(StartingColumn, EndingColumn, StartingRow, EndingRow);//it  will give the list, without the uc we re adding

                        ClassucAppointmentGrouping grouper2 = new ClassucAppointmentGrouping(TLPSchedule, NewListUC, null);
                        Dictionary<int, List<UCappointment>> NewgroupedUCsCoverredByTheArea = grouper2.ClassifyGroupsThatAreConnected();
                        List<UCappointment> AllNewdUCInTheArea = NewgroupedUCsCoverredByTheArea.SelectMany(pair => pair.Value).ToList();



                        //Removing Mode
                        bool IsDesignFixed = RemoveUc(OldColumnIndexGroupOfDesiredUC, OldRowOfDraggedUC, AllNewdUCInTheArea, UCApointmentDraged);//mafina baaed el add, lieanno ma32oul yse2ib bel old area, ykun intesects maa el ucapp li aam yonhatt in its new position
                                                                                                                                                 //so when we call el remove, we need to make ykun sure enno el appointment baaed ma nhatt, yaane ma aayetna baeed lal AddUc


                        AddUc(ColumnIndexGroupOfDraggingUC, RowIndexStart, UCApointmentDraged);

                        if (IsDesignFixed) //ejbare men baeed el add in drag drop cases, Read why 
                        {
                            CheckIfLastColumnsShouldBeRemoved(OldColumnIndexGroupOfDesiredUC);//lieanno once design is fixed, controls byetghara el idex tb3un wbi taria to empty the last column and remove it
                        }



                        UCApointmentDraged.Dock = DockStyle.Fill;
                        UCApointmentDraged.isDragging = false;
                        UCApointmentDraged.Show();
                        UCApointmentDraged = null;

                        ResetSelection();

                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {

                        NotificationBanner.Show("Cannot schedule here!", NotificationBanner.EnumType.DeletedMode, false, Program.HomeForm, false);
                        TLPSchedule.Controls.Add(UCApointmentDraged, OldColumnofDraggedUC, OldRowOfDraggedUC);
                        ResetSelection();
                    }
                }
                else
                {
                    if (UCApointmentDraged != null)
                    {
                        TLPSchedule.Controls.Add(UCApointmentDraged, OldColumnofDraggedUC, OldRowOfDraggedUC);
                        ResetSelection();
                    }
                }

            }
            else
            {
                if (UCApointmentDraged != null)
                {
                    TLPSchedule.Controls.Add(UCApointmentDraged, OldColumnofDraggedUC, OldRowOfDraggedUC);
                    ResetSelection();
                }
            }

        }

        bool CheckIfPositionAvailable(int StartingColumn, int StartingRow)
        {
            if (IsDayOrWeek || (!IsDayOrWeek && GetWhichEmployeeOrDateForSpecifieColumn(StartingColumn, false).Item2 >= DateTime.Now.Date))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        void DragDropBusinessLogic(int NewColumnIndex, int NewRowIndexStart)//Test
        {

            int NewRowIndexEnd = NewRowIndexStart + TLPSchedule.GetRowSpan(UCApointmentDraged) - 1;

            int OldRowIndexStart = UCApointmentDraged.RowIndexStart;

            int OldCollumnsIndex = UCApointmentDraged.ColumnIndex;


            ClassEmployee OldEmp = null;
            ClassEmployee NewEmp = null;
            DateTime? OldDesiredDate = null;
            DateTime? NewDesiredDate = null;

            if (UCApointmentDraged != null)
            {
                bool DragAndDropCanProceed = false;
                if (IsDayOrWeek)
                {

                    (NewEmp, _) = GetWhichEmployeeOrDateForSpecifieColumn(NewColumnIndex, IsDayOrWeek);
                    (OldEmp, _) = GetWhichEmployeeOrDateForSpecifieColumn(OldCollumnsIndex, IsDayOrWeek);
                    if (NewEmp.EmployeeId != OldEmp.EmployeeId || NewRowIndexStart != OldRowIndexStart)
                    {
                        DragAndDropCanProceed = true;
                    }

                }
                else
                {
                    (_, NewDesiredDate) = GetWhichEmployeeOrDateForSpecifieColumn(NewColumnIndex, IsDayOrWeek);
                    (_, OldDesiredDate) = GetWhichEmployeeOrDateForSpecifieColumn(OldCollumnsIndex, IsDayOrWeek);
                    if (NewDesiredDate != OldDesiredDate || NewRowIndexStart != OldRowIndexStart)
                    {
                        DragAndDropCanProceed = true;
                    }
                }
                if (DragAndDropCanProceed)
                {

                    UCApointmentDraged.OldDesiredAppointmentUCApp = UCApointmentDraged.DesiredAppointmentUCApp.Copy();//we should copy before changing to the new time

                    UCApointmentDraged.RowIndexStart = NewRowIndexStart;
                    UCApointmentDraged.RowIndexEnd = NewRowIndexEnd;
                    UCApointmentDraged.ColumnIndex = NewColumnIndex;

                    if (IsDayOrWeek)
                    {
                        //StartTime
                        TimeSpan NewStartTime = GetTimeFromRow(NewRowIndexStart, false);
                        UCApointmentDraged.DesiredAppointmentUCApp.StartTime = UCApointmentDraged.DesiredAppointmentUCApp.StartTime.Date + NewStartTime;


                        //EndTime
                        TimeSpan NewEndTime = UCApointmentDraged.DesiredAppointmentUCApp.StartTime.TimeOfDay+(UCApointmentDraged.OldDesiredAppointmentUCApp.EndTime.TimeOfDay - UCApointmentDraged.OldDesiredAppointmentUCApp.StartTime.TimeOfDay);
                        UCApointmentDraged.DesiredAppointmentUCApp.EndTime = UCApointmentDraged.DesiredAppointmentUCApp.EndTime.Date + NewEndTime;


                        //Employee
                        UCApointmentDraged.DesiredAppointmentUCApp.DesiredEmployee = NewEmp;
                    }
                    else
                    {
                        if (TheOnlyEmployee != null)
                        {
                            DateTime NewStartTime = ((DateTime)NewDesiredDate).Date + GetTimeFromRow(NewRowIndexStart, false);
                            UCApointmentDraged.DesiredAppointmentUCApp.StartTime = NewStartTime;


                            //EndTime
                            DateTime NewEndTime = ((DateTime)NewDesiredDate).Date + GetTimeFromRow(NewRowIndexEnd, true); ;
                            UCApointmentDraged.DesiredAppointmentUCApp.EndTime = NewEndTime;


                            //Employee
                            UCApointmentDraged.DesiredAppointmentUCApp.DesiredEmployee = TheOnlyEmployee;
                        }
                        else
                        {
                            //drag and drop should be restricted in this case
                        }

                    }
                    //SQL
                    UCApointmentDraged.DesiredAppointmentUCApp.InsertOrUpdateAppointment(false);

                    //
                    UCApointmentDraged.SetUCDesign();
                    UCApointmentDraged.DragAndDropOperationDone();
                }
            }



        }



        //How It Works,first
        //1-we check if there s place and put it
        //2-in case no place, we try to fix the spans in order to fit it
        //3- if didn work, we create a new column , and fit the uc in it
        void AddUc((ClassEmployee, DateTime?, List<int>) DesiredColumnIndexesGroup, int NewRow, UCappointment DesiredUCApp)//eza from drag:DesiredGroupOfUC=GroupOfDraggingUC , eza by code:DesiredGroupOfUC=Shi nehna ha nebaato hasab wen aam naamil add or undo
        {


            (int StartingColumn, int EndingColumn, int StartingRow, int EndingRow) = GetRectangle4Points(NewRow, DesiredColumnIndexesGroup, DesiredUCApp);
            List<UCappointment> NewListUC = GetListOfAllControlsInSpecifiedArea(StartingColumn, EndingColumn, StartingRow, EndingRow);//it  will give the list, without the uc we re adding


            ClassucAppointmentGrouping grouper2 = new ClassucAppointmentGrouping(TLPSchedule, NewListUC, null);
            Dictionary<int, List<UCappointment>> NewgroupedUCsCoverredByTheArea = grouper2.ClassifyGroupsThatAreConnected();
            List<UCappointment> AllNewdUCInTheArea = NewgroupedUCsCoverredByTheArea.SelectMany(pair => pair.Value).ToList();




            bool IsUCAppScheduled = false;

            IsUCAppScheduled = FittingUCIfPlaceExist(DesiredUCApp, StartingColumn, EndingColumn, StartingRow, EndingRow);




            if (!IsUCAppScheduled)//eza ma l2ina empty space men el asel, mnekhlaela mahal, ya men zabbit el spans w men saye3a, if not we create a new column 
            {


                foreach (KeyValuePair<int, List<UCappointment>> entry in NewgroupedUCsCoverredByTheArea)//now we study each group, trying to fix its design to the max
                {

                    bool OverLapByColumnsExists;//bad serpent
                    if (entry.Value.Count() > 2)//not possible ykun eendak bad serpent eza ken el count aeal men 2
                    {
                        OverLapByColumnsExists = CheckColumnOverlappingUcApp(entry.Value);
                    }
                    else
                    {
                        OverLapByColumnsExists = false;
                    }

                    if (!OverLapByColumnsExists)
                    {
                        // Get the single group's list of UCappointment
                        bool PlaceExist = SetNewColumnSpanAndIndex(DesiredColumnIndexesGroup, entry.Value, true);

                        if (PlaceExist)
                        {
                            IsUCAppScheduled = FittingUCIfPlaceExist(DesiredUCApp, StartingColumn, EndingColumn, StartingRow, EndingRow);//now men baaed ma zabatna el row spans tb3 el ucappointments, sar fi mahal elo lal appointment
                        }
                    }

                }//foreach ejbare hone tekhlas





                Dictionary<int, List<UCappointment>> EachGroupWithItsSerpents = new Dictionary<int, List<UCappointment>>();
                ClassucAppointmentGrouping grouper = new ClassucAppointmentGrouping(TLPSchedule, null, DesiredColumnIndexesGroup.Item3);//it will give all the uc , including the one we added
                foreach (KeyValuePair<int, List<UCappointment>> entry in NewgroupedUCsCoverredByTheArea)
                {
                    List<UCappointment> ListSerpentConnectedUCsBeforeAdding = grouper.GetConnectedComponent(entry.Value[0]);//bi hemne one uc men kell small serpent , ta eedar ekmush the whole serpent
                                                                                                                            // Add the key and the connected components to the dictionary
                    EachGroupWithItsSerpents.Add(entry.Key, ListSerpentConnectedUCsBeforeAdding);
                }


                //resetting to oginal spans, eza ma le2a mahal yoeuud fi el appointment
                //first condition eza ken fi groups w zabtna el span tb3un bas ma elo mahal, secd condition eza sar fi error bel design
                if (!IsUCAppScheduled && NewgroupedUCsCoverredByTheArea.Count > 0 || (IsUCAppScheduled && !CheckIfUCIsIntheRightColumn(EachGroupWithItsSerpents)))
                {
                    IsUCAppScheduled = false;
                    TLPSchedule.SetColumnSpan(DesiredUCApp, 1);//reseting its value, since ma32oul tetghayar bel FittingUCIfPlaceExist





                    //Insert
                    int ColumnToInsert = DesiredColumnIndexesGroup.Item3[DesiredColumnIndexesGroup.Item3.Count() - 1] + 1;
                    InsertColumn(ColumnToInsert);
                    Debug.WriteLine("Number: " + DesiredColumnIndexesGroup.Item3.Count());
                    (StartingColumn, EndingColumn, StartingRow, EndingRow) = GetRectangle4Points(NewRow, DesiredColumnIndexesGroup, DesiredUCApp);//aam nerjaa naamela lieano new column is added,EndingColumn will change
                    FittingUCIfPlaceExist(DesiredUCApp, StartingColumn, EndingColumn, StartingRow, EndingRow);






                    //we need to change all the span of ucs groups in same DesiredIndexGroup(Same Big Column or Employee), ella AffectedGroup li already tghayaro foe
                    List<UCappointment> ListOfAppPassed = new List<UCappointment>();//this stackis mde to prevent repition, since for a range of rows we can pass by the same uc
                    ClassucAppointmentGrouping grouperInsert = new ClassucAppointmentGrouping(TLPSchedule, null, DesiredColumnIndexesGroup.Item3);//aam nekhlae el ajdency tb3 the whol DesiredgroupIndexes

                    for (int rows = 0; rows < TLPSchedule.RowCount; rows++)
                    {
                        UCappointment ucapp = (UCappointment)TLPSchedule.GetControlFromPosition(ColumnToInsert - 1, rows);
                        if (ucapp != null)
                        {
                            if (!ListOfAppPassed.Contains(ucapp))
                            {
                                ListOfAppPassed.Add(ucapp);//we use stack kermel naadil only once aal groups , mesh aa kell row naadela

                                bool UcInTheAffectedGroups = false;
                                foreach (KeyValuePair<int, List<UCappointment>> entry in EachGroupWithItsSerpents)
                                {
                                    if (entry.Value.Contains(ucapp))
                                    {
                                        UcInTheAffectedGroups = true;//el affected groups ma mnaamul span aw shi, lieanno henne naamalo foe, 
                                        break;
                                    }
                                }
                                if (!UcInTheAffectedGroups)
                                {

                                    List<UCappointment> ListSerpentConnectedUCs = grouperInsert.GetConnectedComponent(ucapp);//it gives us a list of all connected uc in these columns to this ucappp 

                                    if (CheckColumnOverlappingUcApp(ListSerpentConnectedUCs))
                                    {
                                        TLPSchedule.SetColumnSpan(ucapp, TLPSchedule.GetColumnSpan(ucapp) + 1);//since fi eenda bad serpent , kell li mnaamlo enno el column li abel li nzedit, mnaamella span+1, ta tgahttiya w ma ybayyin fi faragh

                                    }
                                    else
                                    {
                                        SetNewColumnSpanAndIndex(DesiredColumnIndexesGroup, ListSerpentConnectedUCs, false);
                                    }
                                }

                            }
                        }
                    }
                }
                if (!CheckIfUCIsIntheRightColumn(EachGroupWithItsSerpents))
                {
                    string FUllNAme = DesiredUCApp.DesiredAppointmentUCApp.DesiredClient.Fname + DesiredUCApp.DesiredAppointmentUCApp.DesiredClient.Lname;
                    TimeSpan time = DesiredUCApp.DesiredAppointmentUCApp.StartTime.TimeOfDay;
                    CustomMessageBox.Show("Error in:\n" + FUllNAme + " at " + time, CustomMessageBox.Type.Error);
                    //LoadForm(SelectedDate);
                }
            }





            ClassucAppointmentGrouping grouper3 = new ClassucAppointmentGrouping(TLPSchedule, null, DesiredColumnIndexesGroup.Item3);//it will give all the uc , including the one we added
            UpdateItsMargins(DesiredColumnIndexesGroup, grouper3.GetConnectedComponent(DesiredUCApp));





        }


        //how it works
        //1- when we remove if it was clean serpent and no bad serpent, if fixes its spans, and delete unnessary columns at the end
        //2- in case of bad serpents, nothing happen spans stay the same and unesscearry column sary,bas it starts autofixing itself lamma tsir good serpent
        bool RemoveUc((ClassEmployee, DateTime?, List<int>) DesiredColumnIndexesGroup, int Row, List<UCappointment> AllNewdUCInTheArea, UCappointment DesiredUCApp)//it will be !=null only in dragdrop operation
        {
            //removing

            (int OldStartingColumn, int OldEndingColumn, int OldStartingRow, int OldEndingRow) = GetRectangle4Points(Row, DesiredColumnIndexesGroup, DesiredUCApp);//ejbare ouaa tshila, hole el values mestaamlin baaden
            List<UCappointment> OldListUC = GetListOfAllControlsInSpecifiedArea(OldStartingColumn, OldEndingColumn, OldStartingRow, OldEndingRow);//it will give the list, without the uc we re removing


            ClassucAppointmentGrouping grouper1 = new ClassucAppointmentGrouping(TLPSchedule, OldListUC, null);
            Dictionary<int, List<UCappointment>> OldGroupedUCsCoverByTheArea = grouper1.ClassifyGroupsThatAreConnected();

            List<UCappointment> AllOldUCInTheArea = OldGroupedUCsCoverByTheArea.SelectMany(pair => pair.Value).ToList();


            //ListSerpentConnectedUCsBeforeRemoving.Count > 0 , eza men matrah ma aam nshila ma ken connected cotrols ela ma darure naamil shi
            // !ListsHaveSameElements(AllOldUC, AllNewdUC) , eza eendun same elements, yaane shelneha w radayneha mahalla, no need to perform the reomove operation
            //ListsHaveSameElements(AllOldUCInTheArea, ListAllConnectedUCsToTheOneWereRemoving), eza ma keno metel baaed, yaane el fi hidden controls related lal groups juwwet OldGroupedUCsCoverByTheArea,
            //bas mesh mbaynin, lieannoun mannun covered by the area,which will cause errors fetna bel function

            bool IsDesignFixed = false;
            if (AllNewdUCInTheArea == null || (AllNewdUCInTheArea != null && !ListsHaveSameElements(AllOldUCInTheArea, AllNewdUCInTheArea)))//first case, eza kennaaam naamil undo lal postion changing, w eza el Undo mawjud yaane aal akid tghayyar mahallo lal ucAppoint, scd case, eza kenna aam naamil dragdrop
            {

                if (ListAllConnectedUCsToTheOneWereRemoving.Count > 0 && ListsHaveSameElements(AllOldUCInTheArea, ListAllConnectedUCsToTheOneWereRemoving))
                {
                    foreach (KeyValuePair<int, List<UCappointment>> Oldentry in OldGroupedUCsCoverByTheArea)
                    {
                        if (!CheckColumnOverlappingUcApp(Oldentry.Value))//Only GOOD SERPENT I FIX THEM
                        {
                            List<UCappointment> ListucAppointments = Oldentry.Value;

                            SetNewColumnSpanAndIndex(DesiredColumnIndexesGroup, ListucAppointments, false);
                            IsDesignFixed = true;
                        }
                    }
                }
                UpdateItsMargins(DesiredColumnIndexesGroup, ListAllConnectedUCsToTheOneWereRemoving);
            }
            if (ListAllConnectedUCsToTheOneWereRemoving.Count == 0)
            {
                IsDesignFixed = true;
            }

            return true;

        }
        void SetSerpentBeforeRemovingAndThenRemoveIt((ClassEmployee, DateTime?, List<int>) DesiredColumnIndexesGroup, UCappointment DesiredUcApp)//uaed in dragdDrop or programatically
        {
            ClassucAppointmentGrouping grouper = new ClassucAppointmentGrouping(TLPSchedule, null, DesiredColumnIndexesGroup.Item3);
            ListAllConnectedUCsToTheOneWereRemoving = grouper.GetConnectedComponent(DesiredUcApp);//it gives us a list of all connected uc in these columns to this ucappp 
            ListAllConnectedUCsToTheOneWereRemoving.Remove(DesiredUcApp);//so now i have the list of the uc that are connecetd to this targeteduc, but without the targeteduc, so can compare it later on


            TLPSchedule.Controls.Remove(DesiredUcApp);
        }
        bool CheckIfLastColumnsShouldBeRemoved((ClassEmployee, DateTime?, List<int>) DesiredColumnIndexesGroup)//in case of dragrdrop, and we re removing and adding the same column ,ejbare men baeed el add, lieanno eza ken in the Same column shelnha men matrah w hattayna matrah tene (hayda el uc li aam aam yaamil insert la new column, huwwe zeit baddo yemnaa hayde el column ma tenmehe bhal code, lieanno ha ykun eendo latest index)
        {
            //ma32oul yseebo sawa, in the same group of columns
            int BigColumnCount = DesiredColumnIndexesGroup.Item3.Count();
            Queue<UCappointment> QueueUCApp = new Queue<UCappointment>();//this one will be used ,to fix the columns span affected by removing the last column
            Stack<UCappointment> stackucApp = new Stack<UCappointment>();//this stackis mde to prevent repition, since for a range of rows we can pass by the same uc
            if (BigColumnCount > 1)
            {
                int LastColumn = DesiredColumnIndexesGroup.Item3[BigColumnCount - 1];

                bool IsUCAppExistOnTheLastColumn = false;
                for (int rows = 0; rows < TLPSchedule.RowCount; rows++)
                {
                    UCappointment ucapp = (UCappointment)TLPSchedule.GetControlFromPosition(LastColumn, rows);
                    if (ucapp != null && (stackucApp.Count == 0 || stackucApp.Count > 0 && stackucApp.Peek().DesiredAppointmentUCApp.AppointmentID != ucapp.DesiredAppointmentUCApp.AppointmentID))
                    {
                        if (ucapp.ColumnIndex == LastColumn)
                        {
                            IsUCAppExistOnTheLastColumn = true;
                            break;
                        }
                        else//in case mesh el Column Index tabaa li ken mawjud, which mean hayda el span, men naesla el span
                        {

                            stackucApp.Push(ucapp);
                            QueueUCApp.Enqueue(ucapp);
                        }
                    }
                }
                if (!IsUCAppExistOnTheLastColumn)
                {
                    foreach (UCappointment ucapp in QueueUCApp)
                    {
                        int ControlColumnSpan = TLPSchedule.GetColumnSpan(ucapp);
                        if (ControlColumnSpan > 1)
                        {
                            ControlColumnSpan--;
                        }
                        TLPSchedule.SetColumnSpan(ucapp, ControlColumnSpan);
                    }
                    RemoveColumn(DesiredColumnIndexesGroup.Item3[DesiredColumnIndexesGroup.Item3.Count() - 1]);
                    Debug.WriteLine("Number: " + DesiredColumnIndexesGroup.Item3.Count());
                    UpdateItsMargins(DesiredColumnIndexesGroup, ListAllConnectedUCsToTheOneWereRemoving);
                    return true;
                }

            }
            return false;

        }




        void UpdateItsMargins((ClassEmployee, DateTime?, List<int>) DesiredColumnIndexesGroup, List<UCappointment> ListSerpentConnectedUCs)
        {
            Padding DefaultMarging = new Padding(3, 2, 2, 2);



            int LastColumnIndexInTheGroup = DesiredColumnIndexesGroup.Item3[DesiredColumnIndexesGroup.Item3.Count - 1];

            foreach (UCappointment desiredApp in ListSerpentConnectedUCs)
            {
                int OccupiedRow = desiredApp.RowIndexStart;
                UCappointment controlOccupied = (UCappointment)TLPSchedule.GetControlFromPosition(LastColumnIndexInTheGroup, OccupiedRow);


                if (controlOccupied != null)
                {
                    if (controlOccupied.DesiredAppointmentUCApp.AppointmentID == desiredApp.DesiredAppointmentUCApp.AppointmentID)
                    {
                        desiredApp.Margin = new Padding(DefaultMarging.Left, DefaultMarging.Top, DefaultMarging.Right + 10, DefaultMarging.Bottom);
                    }
                    else
                    {
                        desiredApp.Margin = DefaultMarging;
                    }
                }
                else
                {
                    desiredApp.Margin = DefaultMarging;
                }
            }

        }



        float PricisionError = 0f;//ma aa eedir le2e the error value
        private void InsertColumn(int columnIndex)
        {
            TLPSchedule.SuspendLayout();


            TLPSchedule.ColumnCount++;

            //finding the desiredIndexesgroup
            int i;
            for (i = 0; i < ListOfAllColumnIndexesGroups.Count; i++)
            {
                if (ListOfAllColumnIndexesGroups[i].Item3.Contains(columnIndex - 1))
                {
                    ListOfAllColumnIndexesGroups[i].Item3.Add(columnIndex);

                    i++;
                    break;
                }

            }


            ////fixing the size
            if (FocusOnColumnIndexGroup != (null, null, null))
            {
                TLPSchedule.ColumnStyles.Insert(columnIndex, new ColumnStyle(SizeType.Percent, 0F));
                ExpandTableLayoutPanelColumn(null);
            }
            else
            {

                TLPSchedule.ColumnStyles.Insert(columnIndex, new ColumnStyle(SizeType.Percent, 100f));

                if (!IsLoadingTheForm)
                {
                    (ClassEmployee, DateTime?, List<int>) TargetedIndexesGroup = ListOfAllColumnIndexesGroups[i - 1];
                    float PercentageOfEachGroup = 100f / ListOfAllColumnIndexesGroups.Count + PricisionError;
                    float PercentageOfEachColumn = PercentageOfEachGroup / TargetedIndexesGroup.Item3.Count;

                    foreach (int ColumnIndex in TargetedIndexesGroup.Item3)
                    {
                        TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
                    }
                }
            }


            //fixing the values in AllIndexesGroupList 
            while (i < ListOfAllColumnIndexesGroups.Count)
            {
                for (int j = 0; j < ListOfAllColumnIndexesGroups[i].Item3.Count; j++)
                {
                    ListOfAllColumnIndexesGroups[i].Item3[j]++;
                }
                i++;
            }


            //fixing the indexes 
            foreach (Control co in TLPSchedule.Controls)
            {
                int OldColumnsIndex = TLPSchedule.GetColumn(co);
                if (co is UCappointment && TLPSchedule.GetColumn(co) >= columnIndex)
                {
                    int newIndex = OldColumnsIndex + 1;
                    TLPSchedule.SetColumn(co, newIndex);
                    ((UCappointment)co).ColumnIndex = newIndex;
                }
            }



            TLPSchedule.ResumeLayout();
        }
        private void RemoveColumn(int columnIndex)
        {
            TLPSchedule.SuspendLayout();  // Suspend layout to improve performance();


            TLPSchedule.ColumnCount--;
            //finding the desiredIndexesgroup
            int i;
            for (i = 0; i < ListOfAllColumnIndexesGroups.Count; i++)
            {
                if (ListOfAllColumnIndexesGroups[i].Item3.Contains(columnIndex - 1))
                {
                    ListOfAllColumnIndexesGroups[i].Item3.Remove(columnIndex);

                    i++;
                    break;
                }
            }

            //fixing the size
            TLPSchedule.ColumnStyles.RemoveAt(columnIndex);

            if (FocusOnColumnIndexGroup != (null, null, null))
            {
                ExpandTableLayoutPanelColumn(null);
            }
            else
            {
                (ClassEmployee, DateTime?, List<int>) TargetedIndexesGroup = ListOfAllColumnIndexesGroups[i - 1];
                float PercentageOfEachGroup = 100f / ListOfAllColumnIndexesGroups.Count - PricisionError;
                float PercentageOfEachColumn = PercentageOfEachGroup / TargetedIndexesGroup.Item3.Count;

                foreach (int ColumnIndex in TargetedIndexesGroup.Item3)
                {
                    TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
                }

            }

            //fixing the calues in AllIndexesGroupList 
            while (i < ListOfAllColumnIndexesGroups.Count)
            {
                for (int j = 0; j < ListOfAllColumnIndexesGroups[i].Item3.Count; j++)
                {
                    ListOfAllColumnIndexesGroups[i].Item3[j]--;
                }
                i++;
            }

            //fixing the indexes 
            foreach (Control co in TLPSchedule.Controls)
            {
                int OldColumnsIndex = TLPSchedule.GetColumn(co);
                if (co is UCappointment && TLPSchedule.GetColumn(co) >= columnIndex)
                {
                    int newIndex = OldColumnsIndex - 1;
                    TLPSchedule.SetColumn(co, newIndex);
                    ((UCappointment)co).ColumnIndex = newIndex;
                }
            }



            TLPSchedule.ResumeLayout();
        }




        bool CheckIfUCIsIntheRightColumn(Dictionary<int, List<UCappointment>> EachGroupWithItsSerpents)//usually used after performing an add operation, bel adding el index li byonhatt logic, bas sometimes, bcz of bad serpent, the control bel design byekab matrah ghalat, yaae lets ucapp index3, byenkab aal design index 4, bas bi hafiz aal index 3 , ma byetghayar
        {


            foreach (KeyValuePair<int, List<UCappointment>> entry in EachGroupWithItsSerpents)
            {
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    UCappointment TaregetedUCApp = entry.Value[i];
                    var DesignPos = TLPSchedule.GetPositionFromControl(TaregetedUCApp);

                    if (DesignPos.Column != TaregetedUCApp.ColumnIndex)
                    {
                        return false;
                    }
                }
            }


            return true;

        }




        int RecursiveDrop(int StartingColumn, int EndingColumn, int StartingRow, int EndingRow, bool ModeLRorRL)//l mnaamlo enno men sir na2is el area tabaa el rectangle, by reducing el starting if ModeLRorRL=true; or reducing el ending if ModeLRorRL=false, Until no uc exist in the filtered area we put el uc bhayda el mahal
        {
            int TargetedColumn;//it could be the starting or the ending clolumn


            if (ModeLRorRL)
            {
                if (StartingColumn > EndingColumn)
                {
                    return -1;//in case ma 2derna nle2e wala wahad
                }
                else
                {
                    TargetedColumn = StartingColumn;

                }
            }
            else
            {
                if (EndingColumn < StartingColumn)
                {
                    return -1;
                }
                else
                {
                    TargetedColumn = EndingColumn;

                }
            }





            for (int i = StartingRow; i <= EndingRow; i++)
            {
                for (int j = StartingColumn; j <= EndingColumn; j++)
                {
                    UCappointment founducapp = (UCappointment)TLPSchedule.GetControlFromPosition(j, i);//we re checking each cell eza fiya shi, which will cover the whole area of the usercontrol
                    if (founducapp != null)//l2ina shi 
                    {
                        if (ModeLRorRL)
                        {
                            TargetedColumn = RecursiveDrop(StartingColumn + 1, EndingColumn, StartingRow, EndingRow, true);
                            return TargetedColumn;
                        }
                        else
                        {
                            TargetedColumn = RecursiveDrop(StartingColumn, EndingColumn - 1, StartingRow, EndingRow, false);
                            return TargetedColumn;

                        }

                    }
                }
            }


            return TargetedColumn;//eza woslit la hone , yaane le2it el targeted one, w ha treddo

        }
        bool FittingUCIfPlaceExist(UCappointment DesiredUCApp, int StartingColumn, int EndingColumn, int StartingRow, int EndingRow)//this code is related RecursiveDrop, where we keep ( (startingcolumn++,endingColumn--) then call RecursiveDrop until needir nhotto lal appointment, aw eza jarabna all possible cases , and no empty spoy is available
                                                                                                                                    //eemlina hek to cover all possible forms, it s 100% accurate
        {

            bool PlaceExist = false;


            while (StartingColumn <= EndingColumn)
            {

                int NewEndingColumn;

                NewEndingColumn = RecursiveDrop(StartingColumn, EndingColumn, StartingRow, EndingRow, false);
                if (NewEndingColumn != -1)
                {
                    PlaceExist = true;
                    EndingColumn = NewEndingColumn;
                    break;
                }
                else
                {
                    int NewStartingColumn = RecursiveDrop(StartingColumn, EndingColumn, StartingRow, EndingRow, true);

                    if (NewStartingColumn != -1)
                    {
                        StartingColumn = NewStartingColumn;
                        PlaceExist = true;
                        break;
                    }
                }

                StartingColumn++;
                EndingColumn--;
            }

            if (PlaceExist)
            {
                TLPSchedule.Controls.Add(DesiredUCApp, StartingColumn, StartingRow);
                DesiredUCApp.ColumnIndex = StartingColumn;
                DesiredUCApp.RowIndexStart = StartingRow;
                TLPSchedule.SetColumnSpan(DesiredUCApp, (EndingColumn - StartingColumn) + 1);
            }
            return PlaceExist;

        }




        bool SetNewColumnSpanAndIndex((ClassEmployee, DateTime?, List<int>) DesiredIndexesGroup, List<UCappointment> ListucAppointments, bool IsAddingMode)//using this method make sure  to be sorted Column Asc, Row Asc                                                                                                                                                //based ayya employee w nehna w el targeted controls baddun tozbit Span and index
        {
            int totalSpan = DesiredIndexesGroup.Item3.Count;
            int NewNumOfUCs = ListucAppointments.Count;

            if (IsAddingMode)
            {
                NewNumOfUCs++;//we re taking into considaration el the control lui ha yenzed , kermel naarif kif nwazii el spans 
            }


            if (totalSpan < NewNumOfUCs)//in this case we should insert a column
            {
                return false;
            }




            // Calculate the fair span to be distributed to each UCappointment
            int fairSpan = totalSpan / NewNumOfUCs;
            int remainder = totalSpan % NewNumOfUCs;

            List<int> spans = new List<int>();
            for (int i = 0; i < NewNumOfUCs; i++)  // Each UC gets at least the fairSpan
            {
                if (i >= NewNumOfUCs - remainder)
                {
                    // akbar values aam naatiyun li aa yamin
                    spans.Add(fairSpan + 1);
                }
                else
                {
                    spans.Add(fairSpan);
                }
            }


            //PreStudy if it will work without ambiguity


            //here we check if after fixing the indexes, willm my controls intersect with ucapp mannun ListucAppointments men wara el bad serpents
            //if yes, nothing will happen, returm false, so in the add we can add a column
            //if no, we fix the span the indexes and make room to the new uc
            int ColumnIndexToStartWithTest = DesiredIndexesGroup.Item3[0];
            for (int i = 0; i < spans.Count; i++)
            {
                if (i < ListucAppointments.Count)//Existing UCappointment
                {
                    for (int j = 0; j < spans[0]; j++)
                    {
                        for (int k = ListucAppointments[i].RowIndexStart; k <= ListucAppointments[i].RowIndexEnd; k++)
                        {
                            UCappointment Ucapp = (UCappointment)TLPSchedule.GetControlFromPosition(ColumnIndexToStartWithTest + j, k);

                            if (Ucapp != null)//we can t put this control at this index
                            {
                                bool IntersectsWithKnownControls = ListucAppointments.Any(ucapp => Ucapp.DesiredAppointmentUCApp.AppointmentID == ucapp.DesiredAppointmentUCApp.AppointmentID);
                                if (!IntersectsWithKnownControls)
                                {//eza fetna yaane intersects with unkonwo uc mesh sheyfino
                                    return false;
                                }
                            }
                        }
                    }
                    ColumnIndexToStartWithTest += spans[i];
                }
            }


            //Set Column Span
            for (int i = 0; i < spans.Count; i++)
            {
                if (i < ListucAppointments.Count)//Existing UCappointment
                {
                    TLPSchedule.SetColumnSpan(ListucAppointments[i], spans[i]);
                }
            }



            //Set Index
            int ColumnIndexToStartWith = DesiredIndexesGroup.Item3[0];
            foreach (UCappointment ucapp in ListucAppointments)
            {
                TLPSchedule.SetColumn(ucapp, ColumnIndexToStartWith);
                ucapp.ColumnIndex = ColumnIndexToStartWith;
                ColumnIndexToStartWith += TLPSchedule.GetColumnSpan(ucapp);
            }
            return true;
        }
        public bool CheckColumnOverlappingUcApp(List<UCappointment> UcAppListOrig)//kermel naarif eza controls inside  listofserpent, eemlin column overlapp => bad serpent, we handle it in a specific way 
        {
            // Sort appointments by start column to make overlap detection easier
            List<UCappointment> ucAppList = new List<UCappointment>(UcAppListOrig);
            ucAppList.Sort((a, b) => TLPSchedule.GetColumn(a).CompareTo(TLPSchedule.GetColumn(b)));

            for (int i = 0; i < ucAppList.Count - 1; i++)
            {
                var current = ucAppList[i];
                var next = ucAppList[i + 1];

                int currentStartColumn = TLPSchedule.GetColumn(current);
                int currentColumnSpan = TLPSchedule.GetColumnSpan(current);
                int nextStartColumn = TLPSchedule.GetColumn(next);

                // Calculate the end column of the current appointment
                int currentEndColumn = currentStartColumn + currentColumnSpan - 1;

                // Check if the next appointment starts before the current one ends
                if (nextStartColumn <= currentEndColumn)
                {
                    // Overlap found
                    return true;
                }
            }

            // No overlaps found
            return false;
        }




        bool ListsHaveSameElements(List<UCappointment> Origlist1, List<UCappointment> Origlist2)
        {
            List<UCappointment> sortedList1 = new List<UCappointment>(Origlist1);
            List<UCappointment> sortedList2 = new List<UCappointment>(Origlist2);

            sortedList1 = Origlist1.OrderBy(x => x.DesiredAppointmentUCApp.AppointmentID).ToList();
            sortedList2 = Origlist2.OrderBy(x => x.DesiredAppointmentUCApp.AppointmentID).ToList();

            return sortedList1.SequenceEqual(sortedList2);
        }
        (ClassEmployee, DateTime?, List<int>) GetWichDesiredIndexesGroup(int StartingColumn)
        {
            int WhichEmployee = 0;

            foreach ((ClassEmployee, DateTime?, List<int>) Group in ListOfAllColumnIndexesGroups)
            {
                if (Group.Item3.Contains(StartingColumn))
                {
                    return ListOfAllColumnIndexesGroups[WhichEmployee];
                }
                WhichEmployee++;
            }

            return (null, null, null);
        }
        (int, int, int, int) GetRectangle4Points(int DesiredRow, (ClassEmployee, DateTime?, List<int>) desiredIndexesGroup, UCappointment DesiredUCApp)
        {
            int StartingColumn = desiredIndexesGroup.Item3[0];//in case  NULLLLLLLL bcz of debugging mode mesh aktar
            int EndingColumn = desiredIndexesGroup.Item3[desiredIndexesGroup.Item3.Count - 1];


            int StartingRow = DesiredRow;
            int EndingRow = DesiredRow + TLPSchedule.GetRowSpan(DesiredUCApp) - 1;


            return (StartingColumn, EndingColumn, StartingRow, EndingRow);
        }
        List<UCappointment> GetListOfAllControlsInSpecifiedArea(int StartingColumn, int EndingColumn, int StartingRow, int EndingRow)
        {
            List<UCappointment> ListUC = new List<UCappointment> { };
            for (int i = StartingRow; i <= EndingRow; i++)
            {
                for (int j = StartingColumn; j <= EndingColumn; j++)
                {
                    UCappointment founducapp = (UCappointment)TLPSchedule.GetControlFromPosition(j, i);
                    if (founducapp != null)
                    {
                        if (!ListUC.Contains(founducapp))
                        {
                            ListUC.Add(founducapp);

                        }

                    }
                }
            }
            // Now sort the list by ColumnIndex
            ListUC = ListUC.OrderBy(uc => uc.ColumnIndex).ToList();
            return ListUC;
        }





        private readonly Brush CellTextBrush = new SolidBrush(Color.Blue);
        private readonly Font CellTextFont = new Font("Arial", 9, FontStyle.Regular);
        private void DrawTextOnCell(Graphics g, Rectangle cellBounds, int rowIndex)
        {

            // Assuming GetTimeFromRow is a method that returns a TimeSpan for the given row
            DateTime dateTime = DateTime.Today.Add(GetTimeFromRow(rowIndex, false));
            string textToDraw = dateTime.ToString("hh:mm tt");

            // Define the format for the text
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near; // Horizontal alignment
                sf.LineAlignment = StringAlignment.Center; // Vertical alignment


                g.DrawString(textToDraw, CellTextFont, CellTextBrush, cellBounds, sf);

            }
        }
        private Rectangle GetSpannedCellBounds(TableLayoutCellPaintEventArgs e, int NbrOfCells)
        {

            // Get the initial cell bounds
            Rectangle cellBounds = e.CellBounds;

            // Calculate the total width for the spanned cells
            for (int i = 1; i < NbrOfCells; i++)
            {
                if (e.Column + i < TLPSchedule.ColumnCount)
                {
                    cellBounds.Width += TLPSchedule.GetColumnWidths()[e.Column + i];
                }
            }

            return cellBounds;
        }
        private void TLPSchedule_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;

            if ((IsDayOrWeek && !IsHistory && !IsDesignBlocked) || (!IsDayOrWeek && TheOnlyEmployee != null))
            {




                int NbrRowShouldPass;
                int currentGroup = -1;
                int hoveredGroup = -1;
                if (UCApointmentDraged != null)
                {
                    NbrRowShouldPass = TLPSchedule.GetRowSpan(UCApointmentDraged) - 1;

                }
                else
                {
                    NbrRowShouldPass = -1;
                    currentGroup = e.Row / NbreofRowsHighlighted;//hone ha temrue aa all cells tb3 el tlp
                    hoveredGroup = hoveredCellColmnRow.Item2 / NbreofRowsHighlighted;//hone fix
                }



                if (NbrRowShouldPass == -1 && (IsDayOrWeek || !IsDayOrWeek && GetWhichEmployeeOrDateForSpecifieColumn(e.Column, false).Item2 >= DateTime.Now.Date))//while hovering normally
                {
                    // Check if this cell's row belongs to the same group as the hovered cell
                    if (currentGroup == hoveredGroup && (ColumnIndexGroupOfDraggingUC != (null, null, null) && ColumnIndexGroupOfDraggingUC.Item3.Contains(e.Column)))
                    {

                        g.FillRectangle(hoverBrush, r);


                        //drwaing the text only
                        if (e.Row == hoveredCellColmnRow.Item2 && e.Column == ColumnIndexGroupOfDraggingUC.Item3[0])
                        {
                            // Get the bounds for the spanned cells
                            Rectangle spanBounds = GetSpannedCellBounds(e, ColumnIndexGroupOfDraggingUC.Item3.Count);


                            // Draw text on the specified cell
                            DrawTextOnCell(e.Graphics, spanBounds, e.Row);


                        }
                    }
                }
                else if (IsDayOrWeek || (!IsDayOrWeek && ColumnIndexGroupOfDraggingUC.Item2 >= DateTime.Now.Date))//While dragging a uc
                {
                    if ((e.Row >= hoveredCellColmnRow.Item2 - 1 && e.Row <= (hoveredCellColmnRow.Item2 + NbrRowShouldPass - 1)) && (ColumnIndexGroupOfDraggingUC != (null, null, null) && ColumnIndexGroupOfDraggingUC.Item3.Contains(e.Column)))
                    {

                        g.FillRectangle(hoverBrush, r);

                        if (e.Row == hoveredCellColmnRow.Item2 - 1 && e.Column == ColumnIndexGroupOfDraggingUC.Item3[0])
                        {
                            Rectangle spanBounds = GetSpannedCellBounds(e, ColumnIndexGroupOfDraggingUC.Item3.Count);

                            // Draw text on the specified cell
                            DrawTextOnCell(g, spanBounds, e.Row);


                        }

                    }
                }


            }


            ////Check if we're in the last column; if not, don't draw vertical lines
            if (e.Column < TLPSchedule.ColumnCount)
            {
                foreach ((ClassEmployee, DateTime?, List<int>) va in ListOfAllColumnIndexesGroups)
                {

                    if (e.Column == va.Item3[0] && e.Column != 0)
                    {
                        g.DrawLine(Pens.LightGray, r.Left, r.Top, r.Left, r.Bottom);
                    }

                }

            }

            // Always draw horizontal lines below the cell if not the last row
            if (e.Row < TLPSchedule.RowCount)
            {
                if (e.Row % 4 == 0)
                {
                    if (e.Row != 0)
                    {
                        g.DrawLine(Pens.LightGray, r.Left, r.Top, r.Right, r.Top);

                    }
                }
                else//hone el hidden rows
                {
                    //g.DrawLine(Pens.WhiteSmoke, r.Left, r.Top, r.Right, r.Top);
                }
            }

        }
        private void TLPSchedule_MouseMove(object sender, MouseEventArgs e)
        {
            NbreofRowsHighlighted = 1;
            SetValuesthatWillAffectselection(e.Location);
        }
        private void TLPSchedule_MouseLeave(object sender, EventArgs e)
        {
            ResetSelection();
        }



        void SetValuesthatWillAffectselection(Point Loaction)
        {
            (int, int) cellPos = GetCellPosition(TLPSchedule, Loaction);

            if (cellPos != hoveredCellColmnRow)
            {
                hoveredCellColmnRow = cellPos; //set whichcolumn and row we are

                //Set which employee we re in
                int WhichEmployee = 0;
                foreach ((ClassEmployee, DateTime?, List<int>) Group in ListOfAllColumnIndexesGroups)
                {
                    if (Group.Item3.Contains(hoveredCellColmnRow.Item1))
                    {
                        ColumnIndexGroupOfDraggingUC = ListOfAllColumnIndexesGroups[WhichEmployee];
                        break;
                    }
                    WhichEmployee++;
                }


                TLPSchedule.Invalidate();

            }
        }
        private (int, int) GetCellPosition(TableLayoutPanel panel, Point location)
        {
            // Adjusting location based on the scroll position
            Point scrollPosition = panel.AutoScrollPosition;
            int adjustedX = location.X - scrollPosition.X;
            int adjustedY = location.Y - scrollPosition.Y;

            int width = 0;
            int height = 0;

            // Iterate through rows to find the row
            int row;
            for (row = 0; row < panel.RowCount; row++)
            {
                int rowHeight = panel.GetRowHeights()[row];
                height += rowHeight;
                if (height > adjustedY)
                    break;
            }

            // Iterate through columns to find the column
            int column;
            for (column = 0; column < panel.ColumnCount; column++)
            {
                int columnWidth = panel.GetColumnWidths()[column];
                width += columnWidth;
                if (width > adjustedX)
                    break;
            }

            // If the point is out of the bounds of the actual cells, reset to -1, -1
            if (row >= panel.RowCount || column >= panel.ColumnCount)
                return (-1, -1);

            return (column, row);
        }

        void ResetSelection()
        {
            hoveredCellColmnRow = (-1, -1);
            ColumnIndexGroupOfDraggingUC = (null, null, null);
            UCApointmentDraged = null;
            Cursor.Current = Cursors.Default; // Reset the cursor to the default
            TLPSchedule.Invalidate();
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
