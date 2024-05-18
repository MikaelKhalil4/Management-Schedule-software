using CustomizedTools;
using MKproject.Management;
using MKproject.Schedule.UCData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;


namespace MKproject.Schedule
{
    public partial class UCSchedule : UserControl
    {
        public ScheduleForm ParentFormSchedule { get; set; }

        public DateTime SelectedDate { get; set; }


        public List<ClassEmployee> EmployeeScheduleList { get; set; }//present-future
        public List<ClassAppointment> AppointmentsList { get; set; }


        public TableLayoutPanelDoubleBufferedNoscroll TLPEmployees;
        public TableLayoutPanelBuffered TLPSchedule;
        List<(ClassEmployee, List<int>)> ListOfAllColumnIndexesGroups = new List<(ClassEmployee, List<int>)>();
        (ClassEmployee, List<int>) FocusOnColumnIndexGroup;
        int FocusOnMaxWidth;


        //Reminder
        public List<UCreminder> ListUCreminderForTheSelectedDate { get; set; } = new List<UCreminder>();//we get it once we open the schedule then if something happened to a ucreminder add,update,delete dureing the runtime it will hapen to the List


        public UCSchedule(ScheduleForm parentform)
        {
            InitializeComponent();
            ParentFormSchedule = parentform;
            LoadForm(DateTime.Now);
            InsertHistroyToSqlIfNecessary();

        }

        public void LoadForm(DateTime selectedDate)
        {
            Cursor.Current = Cursors.WaitCursor;

            FocusOnColumnIndexGroup = (null, null);

            if (EmployeeScheduleList != null)
                EmployeeScheduleList.Clear();

            if (AppointmentsList != null)
                AppointmentsList.Clear();

            if (ListOfAllColumnIndexesGroups != null)
                ListOfAllColumnIndexesGroups.Clear();




            SelectedDate = selectedDate;

            FillEmployeLists();

            AppointmentsList = ClassAppointment.GetAppointmentOfSpecificEmployees(SelectedDate, EmployeeScheduleList);


            CreateTLPDesign();

            if (AppointmentsList.Count == 0 && SelectedDate.Date < DateTime.Now.Date)
            {
                IsDesignBlocked = true;

                BlockedModeDesign("No Appointments Available");

            }
            else if (EmployeeScheduleList.Count == 0 && SelectedDate.Date <= DateTime.Now.Date)
            {
                IsDesignBlocked = true;

                BlockedModeDesign("No Employees Available");

            }
            else
            {

                SetListOfAllColumnIndexesGroups();//ejbare men baaed li foe

                //Colmns Groups, ha ykun percentage
                SetTLPEmployeesColumn();
                SetTLPSchGroupColumn();//el resizing bi sir juwweta lal tnen Employees and TlpAppointmnet
                                       //

                AddAppointmentsToTlpSchedule();

                IsDesignBlocked = false;
            }

            Cursor.Current = Cursors.Default;

            //Reminder
            DisplayUCReminderForTheSelectedDate();
        }






        LabelEmployee CreateLabelEmployee()
        {
            //Design 
            LabelEmployee labelEmployee = new LabelEmployee();
            labelEmployee.Dock = DockStyle.Fill;
            labelEmployee.BackColor = Color.FromArgb(119, 132, 234);
            labelEmployee.ForeColor = Color.White;
            labelEmployee.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            labelEmployee.AutoSize = true;
            labelEmployee.TextAlign = ContentAlignment.MiddleCenter;
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
        void ActiveDesiredLabel(LabelEmployee DesiredLabelEmployee)
        {
            //Design
            foreach (LabelEmployee labelEmployee in TLPEmployees.Controls)
            {
                if (labelEmployee.IsClicked && labelEmployee != DesiredLabelEmployee)
                {
                    labelEmployee.IsClicked = false;
                    labelEmployee.SetDefaultModeDesign();
                }
                else if (labelEmployee == DesiredLabelEmployee)
                {
                    labelEmployee.IsClicked = true;
                    labelEmployee.SetActiveModeDesign();
                }
            }
        }
        public void DesActiveAllLabels()
        {
            foreach (LabelEmployee labelEmployee in TLPEmployees.Controls)
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


            if (sender is LabelEmployee)
            {
                Cursor = Cursors.WaitCursor;

                LabelEmployee clickedLabel = (LabelEmployee)sender;


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
                    ExpandTableLayoutPanelColumn(clickedLabel.DesiredEmployee.EmployeeId);

                    //label design
                    ActiveDesiredLabel(clickedLabel);

                }

            }

            Cursor = Cursors.Default;




        }//changing size column of the Table Layout Panel
        private void LabelEmployee_MouseMove(object sender, MouseEventArgs e)
        {

            LabelEmployee labelEmployee = (LabelEmployee)sender;
            if (!labelEmployee.IsClicked)
            {
                labelEmployee.SetActiveModeDesign();
            }

        }
        private void LabelEmployee_MouseLeave(object sender, EventArgs e)
        {
            LabelEmployee labelEmployee = (LabelEmployee)sender;
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
                DesiredReminder.Idreminder = (int)dr["reminder_id"];
                if (dr["client_id"] != DBNull.Value)
                {
                    DesiredReminder.DesiredClient = new ClassClient();
                    DesiredReminder.DesiredClient.ClientId = (int)dr["client_id"];
                    DesiredReminder.DesiredClient.Fname = (string)dr["name"];
                    DesiredReminder.DesiredClient.Lname = (string)dr["family_name"];
                }
                DesiredReminder.Reminder = (string)dr["reminder"];
                DesiredReminder.Repeat = (string)dr["repeat"];
                DesiredReminder.StartTime = (DateTime)dr["starttime"];
                DesiredReminder.IsChecked = (bool)dr["is_checked"];
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


            if (column > 0)
            {
                TimeSpan StartTime = GetTimeFromRow(row);
                ClassEmployee SelectedEmployee = GetWhichEmployeeForSpecifieColumn(column);


                ScheduleForm schedule = this.ParentFormSchedule;
                Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
                Program.GreyForm.Show();
                Appointment appointment = new Appointment(this, SelectedEmployee, StartTime);
                appointment.Show();
                //

            }
        }




        void SetListOfAllColumnIndexesGroups()
        {
            int StartintColumnIndex = 1; // Initial column index, assuming 0 is reserved

            foreach (ClassEmployee employee in EmployeeScheduleList)
            {
                if ((bool)employee.IsChecked)
                {
                    var events = new List<(DateTime time, bool isStart)>();

                    foreach (var appt in AppointmentsList.Where(a => a.DesiredEmployee.EmployeeId == employee.EmployeeId))
                    {
                        events.Add((appt.StartTime, true)); // start time
                        events.Add((appt.EndTime, false)); // end time
                    }

                    // Sorting events
                    events.Sort((a, b) =>
                    {
                        int timeComparison = a.time.CompareTo(b.time);
                        if (timeComparison != 0)
                        {
                            return timeComparison;
                        }
                        // Ensure that end times come before start times when times are equal
                        if (!a.isStart && b.isStart)
                        {
                            return -1;
                        }
                        if (a.isStart && !b.isStart)
                        {
                            return 1;
                        }
                        return 0;
                    });

                    int maxOverlap = 0, currentOverlap = 0;
                    foreach (var e in events)
                    {
                        if (e.isStart)
                        {
                            currentOverlap++;
                        }
                        else
                        {
                            currentOverlap--;
                        }

                        if (currentOverlap > maxOverlap)
                        {
                            maxOverlap = currentOverlap;
                        }
                    }

                    var indices = new List<int>();
                    if (maxOverlap > 0)
                    {
                        for (int i = 0; i < maxOverlap; i++)
                        {
                            indices.Add(StartintColumnIndex++);
                        }
                    }
                    else
                    {
                        indices.Add(StartintColumnIndex++);
                    }

                    ListOfAllColumnIndexesGroups.Add((employee, indices));
                }
            }
        }

        void InsertHistroyToSqlIfNecessary()
        {
            if (!SQLToProject.CheckIfHistoryExistsToday(DateTime.Now))//eza exists update 
            {
                for (int i = 0; i < EmployeeScheduleList.Count; i++)//both of the string are in the order of the rank
                {
                    //getting availibility for this day of every employee
                    int dayOfWeekInt = ((int)DateTime.Today.DayOfWeek + 6) % 7;

                    string availability = "";
                    string[] HoursOfThedays = EmployeeScheduleList[i].Availability.Split('/');
                    availability += HoursOfThedays[dayOfWeekInt];

                    ProjectToSql.InsertHistoryEmployeeavailibility(DateTime.Now, EmployeeScheduleList[i].EmployeeId, (int)EmployeeScheduleList[i].Rank, availability);
                }
            }
        }
        void AddAppointmentsToTlpSchedule()
        {

            foreach (ClassAppointment DesiredAppointment in AppointmentsList)
            {
                AddUCappointmentsInTLP(DesiredAppointment);
            }


        }



        public void FillEmployeLists()
        {
            if (SelectedDate.Date >= DateTime.Now.Date)//present-future
            {
                EmployeeScheduleList = ClassEmployee.GetEmployeeScheduleMemberASC();
            }
            else  //History
            {
                EmployeeScheduleList = new List<ClassEmployee>();

                DataTable RankNAvailabilityEmployeesASC = SQLToProject.DisplayRankEmployeesNAvailabilityASC(SelectedDate);

                //there was Active Employees In this Day
                if (RankNAvailabilityEmployeesASC.Rows.Count > 0)
                {
                    foreach (DataRow datarow in RankNAvailabilityEmployeesASC.Rows)
                    {
                        //this is like a View Model object
                        ClassEmployee employee = new ClassEmployee();
                        employee.EmployeeId = (int)datarow["employee_id"];
                        employee.Fname = datarow["first_name"] is DBNull ? null : (string)datarow["first_name"];
                        employee.Lname = datarow["last_name"] is DBNull ? null : (string)datarow["last_name"];
                        employee.Rank = datarow["rank"] is DBNull ? null : (int)datarow["rank"];
                        employee.Availability = datarow["availability"] is DBNull ? null : (string)datarow["availability"];
                        employee.IsChecked = true;//since he is from the past
                        EmployeeScheduleList.Add(employee);
                    }
                }
            }

            //Changing Date
            labelDate.Text = SelectedDate.ToString("dddd,MMMM dd,yyyy");


        }//Display the title and the ucappointments



        public void ChangePositionUCappointments(UCappointment DesiredUCApp, ClassAppointment OldAppointment, ClassAppointment UpdatedAppointment)
        {

            (int RowIndexStart, int RowIndexEnd) = GetUCAppointmentRowIndexes(OldAppointment);//hone el el start  w el end time before updating
            PurelyRemovingUcApp(OldAppointment.DesiredEmployee.EmployeeId, RowIndexStart, DesiredUCApp);


            (RowIndexStart, RowIndexEnd) = GetUCAppointmentRowIndexes(UpdatedAppointment);//hone el  start  w el end time after updating
            int RowSpan = RowIndexEnd - RowIndexStart;
            if (RowSpan == 0)
            {
                RowSpan = 1;
            }
            TLPSchedule.SetRowSpan(DesiredUCApp, RowSpan);

            PurellyAddingUcApp(UpdatedAppointment.DesiredEmployee.EmployeeId, RowIndexStart, DesiredUCApp);


        }
        public void RemoveUcAppointmentFromTLP(UCappointment DesiredUCApp)
        {
            int EmployeeId = DesiredUCApp.DesiredAppointmentUCApp.DesiredEmployee.EmployeeId;

            (int RowIndexStart, int RowIndexEnd) = GetUCAppointmentRowIndexes(DesiredUCApp.DesiredAppointmentUCApp);

            PurelyRemovingUcApp(EmployeeId, RowIndexStart, DesiredUCApp);
        }
        public UCappointment AddUCappointmentsInTLP(ClassAppointment DesiredAppointment)
        {
            UCappointment DesiredUCApp = new UCappointment(DesiredAppointment, this);
            DesiredUCApp.Dock = DockStyle.Fill;
            DesiredUCApp.UCAppIsDroped += Uc_UCAppIsDroped;


            int EmployeeId = DesiredUCApp.DesiredAppointmentUCApp.DesiredEmployee.EmployeeId;

            (int RowIndexStart, int RowIndexEnd) = GetUCAppointmentRowIndexes(DesiredUCApp.DesiredAppointmentUCApp);

            int RowSpan = RowIndexEnd - RowIndexStart;
            if (RowSpan == 0)
            {
                RowSpan = 1;
            }
            TLPSchedule.SetRowSpan(DesiredUCApp, RowSpan);


            PurellyAddingUcApp(EmployeeId, RowIndexStart, DesiredUCApp);

            return DesiredUCApp;
        }

        public (int, int) GetUCAppointmentRowIndexes(ClassAppointment DesiredAppointment)
        {
            TimeSpan starttimeTimeSpan = DesiredAppointment.StartTime.TimeOfDay;
            int PositionRowStart = GetRowFromTime(starttimeTimeSpan);

            TimeSpan endtimeTimeSpan = DesiredAppointment.EndTime.TimeOfDay;
            int PositionRowEnd = GetRowFromTime(endtimeTimeSpan);


            return (PositionRowStart, PositionRowEnd);//position flowlayoutpanel hiye position employee bel list-1 
        }


        private void buttonNext_Click(object sender, EventArgs e)
        {

            LoadForm(SelectedDate.AddDays(+1));
        }
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            LoadForm(SelectedDate.AddDays(-1));
        }
        private void buttonToday_Click(object sender, EventArgs e)
        {
            LoadForm(DateTime.Now);
        }


        



   
       /////////these are for the values of the uc while drag/drop operation
      
        (ClassEmployee, List<int>) OldColumnIndexGroupOfDesiredUC;
        int OldColumnofDraggedUC;//old column is the exact column li ken aalaya el uc
        int OldRowOfDraggedUC;

        List<UCappointment> ListAllConnectedUCsToTheOneWereRemoving;//this serpent doesn tonly cover the area of the removed uc, but also outside the are, which
                                                                    //Which we care about , because the one we dont see could cause us problems, that s why the one we dont see if they exist, we dont do the auto size



        UCappointment UCApointmentDraged;
        (ClassEmployee, List<int>) ColumnIndexGroupOfDraggingUC = (null, null);//stores the index columns Related To employee , when we re dragging a uc
        private (int, int) hoveredCellColmnRow = (-1, -1);  // Stores the  (column,row) of the hovered cell


        int NbreofRowsHighlighted = -1;//how many rows we need to highlight while mouse hover or dragging
        Brush hoverBrush = new SolidBrush(Color.FromArgb(50, 109, 122, 224)); // Change the color as needed

        Dictionary<Point, bool> AvailableCells = new Dictionary<Point, bool>();



        void CreateTLPDesign()
        {

            //uc1.UCAppIsDroped += Uc1_UCAppIsDroped;


            //
            if (TLPSchedule == null && TLPEmployees == null)
            {
                //TLPSchedule
                TLPSchedule = new TableLayoutPanelBuffered();
                TLPSchedule.AllowDrop = true;
                TLPSchedule.Dock = DockStyle.Fill;
                TLPSchedule.AutoScroll = true;
                TLPSchedule.BackColor = Color.FromArgb(249, 246, 254);


                //Hours
                TLPSchedule.RowCount = 96;
                for (int i = 0; i < TLPSchedule.RowCount; i++)
                {
                    TLPSchedule.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
                }


                //TLPEmployee
                TLPEmployees = new TableLayoutPanelDoubleBufferedNoscroll();
                TLPEmployees.Dock = DockStyle.Fill;
                TLPEmployees.RowCount = 1;
                TLPEmployees.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
                TLPEmployees.Margin = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth + 4, 0);


                //Time

                //Time in Tlp employee
                TLPEmployees.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
                TLPEmployees.ColumnCount++;

                //Time in TLP Schedule, ejbare absoloute
                TLPSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
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
                TLPSchedule.Resize += TLPSchedule_Resize;

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


            if (ListOfAllColumnIndexesGroups.Count > 0)
            {
                //Employees, ejbare percentage
                foreach ((ClassEmployee, List<int>) Group in ListOfAllColumnIndexesGroups)
                {
                    foreach (int ColumnIndex in Group.Item2)
                    {
                        TLPSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                        TLPSchedule.ColumnCount++;
                    }
                }
                PercentageResizeTLPScheduleAndTlpEmp();

                TLPSchedule.Enabled = true;
            }
            else
            {
                TLPSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                TLPSchedule.ColumnCount++;

            }
        }
        void SetTLPEmployeesColumn()//always called after SetTLPSchGroupColumn 
        {

            ResetTLPEmployeeToInitialState();

            TLPSchedule.Enabled = true;

            for (int i = 0; i < ListOfAllColumnIndexesGroups.Count; i++)
            {

                TLPEmployees.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                TLPEmployees.ColumnCount++;


                LabelEmployee labelEmployee = CreateLabelEmployee();
                labelEmployee.DesiredEmployee = ListOfAllColumnIndexesGroups[i].Item1;
                labelEmployee.Text = ListOfAllColumnIndexesGroups[i].Item1.Fname + " " + ListOfAllColumnIndexesGroups[i].Item1.Lname;
                TLPEmployees.Controls.Add(labelEmployee, i + 1, 0);//i+1, lieanno first column kermel el time
            }




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

            ResetTLPScheduleToInitialState();
            ResetTLPEmployeeToInitialState();

            //we add only one column in the block design
            TLPEmployees.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            TLPEmployees.ColumnCount++;
            TLPSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            TLPSchedule.ColumnCount++;

            LabelEmployee labelEmployee = CreateLabelEmployee();
            labelEmployee.Text = OutputText;


            TLPEmployees.Controls.Add(labelEmployee, 1, 0);//1, lieanno first column kermel el time

            TLPSchedule.Enabled = false;

        }


        public void ExpandTableLayoutPanelColumn(int? empId)
        {
            FocusOnMaxWidth = (int)((TLPSchedule.Width - TLPSchedule.GetColumnWidths()[0]) * 0.85);//so he will be 90 % of the columns without the first column


            if (empId != null)//eza kenit null,yaane i  m usinf same FocusOnColumnIndexGroup, usd in remove or insert column
            {
                FocusOnColumnIndexGroup = GetWhichDesiredGroup((int)empId);
            }


            int OriginalWidthOfDesiredGroup = UCappointment.OriginalWidth * FocusOnColumnIndexGroup.Item2.Count;

            int DesiredWidthOfTheGroup = OriginalWidthOfDesiredGroup < FocusOnMaxWidth ? OriginalWidthOfDesiredGroup : FocusOnMaxWidth;


            //TLPAppointment 

            int DesiredWidthPerColumn = DesiredWidthOfTheGroup / FocusOnColumnIndexGroup.Item2.Count;
            foreach (int ColumnIndex in FocusOnColumnIndexGroup.Item2)
            {
                TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Absolute, DesiredWidthPerColumn);
            }


            //Employee tlp
            int i = 1;//i=0 lal time
            foreach ((ClassEmployee, List<int>) Group in ListOfAllColumnIndexesGroups)
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
        }
        public void PercentageResizeTLPScheduleAndTlpEmp()
        {
            FocusOnColumnIndexGroup = (null, null);
            //
            float PercentageOfEachGroup = 100 / ListOfAllColumnIndexesGroups.Count;

            int i = 1;
            foreach ((ClassEmployee, List<int>) Group in ListOfAllColumnIndexesGroups)
            {
                //TLPSchedule
                TLPEmployees.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, PercentageOfEachGroup);
                i++;

                //TLPAppoitment
                float PercentageOfEachColumn = PercentageOfEachGroup / Group.Item2.Count;
                foreach (int ColumnIndex in Group.Item2)
                {
                    TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
                }
            }
        }



        private void TLPSchedule_Resize(object sender, EventArgs e)
        {
            if (TLPSchedule.ColumnCount > 1)
            {
                PercentageResizeTLPScheduleAndTlpEmp();
                FocusOnColumnIndexGroup = (null, null);
            }

        }




        //Functions Used By code
        //void UndoMode((ClassEmployee, List<int>) DesiredColumnIndexesGroup, int NewRow)
        //{
        //    AddUc(DesiredColumnIndexesGroup, NewRow);
        //    RemoveUc(null);
        //}

        void PurellyAddingUcApp(int empId, int NewRow, UCappointment DesiredUCApp)
        {
            AddUc(GetWhichDesiredGroup(empId), NewRow, DesiredUCApp);
        }
        void PurelyRemovingUcApp(int empId, int Row, UCappointment DesiredUCApp)
        {
            (ClassEmployee, List<int>) DesiredColumnIndexesGroup = GetWhichDesiredGroup(empId);

            SetSerpentBeforeRemovingAndThenRemoveIt(DesiredColumnIndexesGroup, DesiredUCApp);
            RemoveUc(DesiredColumnIndexesGroup, Row, null, DesiredUCApp);
            CheckIfLastColumnsShouldBeRemoved(DesiredColumnIndexesGroup);
        }

        (ClassEmployee, List<int>) GetWhichDesiredGroup(int empId)
        {
            foreach ((ClassEmployee, List<int>) Group in ListOfAllColumnIndexesGroups)
            {
                if (Group.Item1.EmployeeId == empId)
                {
                    return Group;
                }
            }

            return (null, null);
        }
        TimeSpan GetTimeFromRow(int row)
        {
            int TotalHour = 24;
            int TotalRow = TLPSchedule.RowCount;

            int hours = (row * TotalHour) / TotalRow;

            int remainderRows = row % (TotalRow / TotalHour);
            int minutes = remainderRows * 15;


            return new TimeSpan(hours, minutes, 0);
        }
        public int GetRowFromTime(TimeSpan Time)
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
            return PositionRow;
        }

        ClassEmployee GetWhichEmployeeForSpecifieColumn(int ColumnIndex)
        {
            foreach ((ClassEmployee, List<int>) Group in ListOfAllColumnIndexesGroups)
            {
                if (Group.Item2.Contains(ColumnIndex))
                {
                    return Group.Item1;
                }
            }
            return null;
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
        private void TLPSchedule_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

            Point clientPoint = TLPSchedule.PointToClient(new Point(e.X, e.Y));
            SetValuesthatWillAffectselection(clientPoint);
        }


        bool DragDropIsEntered;
        private void Uc_UCAppIsDroped(object sender, EventArgs e)//kermel eza kabbayneha outside the bounds what to return it mahalla
        {

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


            if (ColumnIndexGroupOfDraggingUC != (null, null))//ejbariyye
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


                        DragDropBusinessLogic(ColumnIndex, RowIndexStart);

                        //

                        List<UCappointment> NewListUC = GetListOfAllControlsInSpecifiedArea(StartingColumn, EndingColumn, StartingRow, EndingRow);//it  will give the list, without the uc we re adding

                        ClassucAppointmentGrouping grouper2 = new ClassucAppointmentGrouping(TLPSchedule, NewListUC, null);
                        Dictionary<int, List<UCappointment>> NewgroupedUCsCoverredByTheArea = grouper2.ClassifyGroupsThatAreConnected();
                        List<UCappointment> AllNewdUCInTheArea = NewgroupedUCsCoverredByTheArea.SelectMany(pair => pair.Value).ToList();



                        //Removing Mode
                        RemoveUc(OldColumnIndexGroupOfDesiredUC, OldRowOfDraggedUC, AllNewdUCInTheArea, UCApointmentDraged);//mafina abel el add, lieanno ma32oul yse2ib bel old area, ykun intesects maa el ucapp li aam yonhatt in its new position
                                                                                                                            //so when we call el remove, we need to make ykun sure enno el appointment baaed ma nhatt, yaane ma aayetna baeed lal AddUc


                        AddUc(ColumnIndexGroupOfDraggingUC, RowIndexStart, UCApointmentDraged);

                        CheckIfLastColumnsShouldBeRemoved(OldColumnIndexGroupOfDesiredUC);  //ejbare men baeed el add in drag drop cases, Read why 

                        UCApointmentDraged.Dock = DockStyle.Fill;
                        UCApointmentDraged.isDragging = false;
                        UCApointmentDraged.Show();
                        UCApointmentDraged = null;

                        ResetSelection();
                    }
                    else
                    {

                        NotificationBanner.Show("Time Not Available!", NotificationBanner.EnumType.DeletedMode, false, Program.HomeForm, false);

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
            //TouchscrollPanelUCDay.AssignEventPanelUCDay(TLPSchedule);

        }

        bool CheckIfPositionAvailable(int StartingColumn, int StartingRow)
        {
            return true;
        }

        void DragDropBusinessLogic(int NewColumnIndex, int NewRowIndexStart)//Test
        {

            int NewRowIndexEnd = NewRowIndexStart + TLPSchedule.GetRowSpan(UCApointmentDraged);

            int OldRowIndexStart = UCApointmentDraged.RowIndexStart;

            int OldCollumnsIndex = UCApointmentDraged.ColumnIndex;



            if (UCApointmentDraged != null && (GetWhichEmployeeForSpecifieColumn(NewColumnIndex).EmployeeId != GetWhichEmployeeForSpecifieColumn(OldCollumnsIndex).EmployeeId || NewRowIndexStart != OldRowIndexStart))
            {

                UCApointmentDraged.RowIndexStart = NewRowIndexStart;
                UCApointmentDraged.RowIndexEnd = NewRowIndexEnd;
                UCApointmentDraged.ColumnIndex = NewColumnIndex;

                UCApointmentDraged.OldDesiredAppointmentUCApp = UCApointmentDraged.DesiredAppointmentUCApp.Copy();//we should copy before changing to the new time

                //StartTime
                TimeSpan NewStartTime = GetTimeFromRow(NewRowIndexStart);
                UCApointmentDraged.DesiredAppointmentUCApp.StartTime = UCApointmentDraged.DesiredAppointmentUCApp.StartTime.Date + NewStartTime;


                //EndTime
                TimeSpan NewEndTime = GetTimeFromRow(NewRowIndexEnd); ;
                UCApointmentDraged.DesiredAppointmentUCApp.EndTime = UCApointmentDraged.DesiredAppointmentUCApp.EndTime.Date + NewEndTime;


                //Employee
                UCApointmentDraged.DesiredAppointmentUCApp.DesiredEmployee = (ClassEmployee)GetWhichEmployeeForSpecifieColumn(NewColumnIndex);

                //SQL
                UCApointmentDraged.DesiredAppointmentUCApp.InsertOrUpdateAppointment(false);

                //
                UCApointmentDraged.SetUCDesign();
                UCApointmentDraged.DragAndDropOperationDone();
            }



        }




        void AddUc((ClassEmployee, List<int>) DesiredColumnIndexesGroup, int NewRow, UCappointment DesiredUCApp)//eza from drag:DesiredGroupOfUC=GroupOfDraggingUC , eza by code:DesiredGroupOfUC=Shi nehna ha nebaato hasab wen aam naamil add or undo
        {


            (int StartingColumn, int EndingColumn, int StartingRow, int EndingRow) = GetRectangle4Points(NewRow, DesiredColumnIndexesGroup, DesiredUCApp);
            List<UCappointment> NewListUC = GetListOfAllControlsInSpecifiedArea(StartingColumn, EndingColumn, StartingRow, EndingRow);//it  will give the list, without the uc we re adding


            ClassucAppointmentGrouping grouper2 = new ClassucAppointmentGrouping(TLPSchedule, NewListUC, null);
            Dictionary<int, List<UCappointment>> NewgroupedUCsCoverredByTheArea = grouper2.ClassifyGroupsThatAreConnected();
            List<UCappointment> AllNewdUCInTheArea = NewgroupedUCsCoverredByTheArea.SelectMany(pair => pair.Value).ToList();



            bool IsUCAppScheduled;

            IsUCAppScheduled = FittingUCIfPlaceExist(DesiredUCApp, StartingColumn, EndingColumn, StartingRow, EndingRow);

            if (UCApointmentDraged != null)
            {
                Cursor.Current = Cursors.WaitCursor;
            }

            if (!IsUCAppScheduled)//eza ma l2ina empty space men el asel, mnekhlaela mahal, ya men zabbit el spans w men saye3a, if not we create a new column 
            {

                Dictionary<int, List<(int, int)>> OriginalCoulunIndexAndSpanForEachGroup = new Dictionary<int, List<(int, int)>>();//inside the list the original spans are ordered like the list appointmnent
                                                                                                                                   //it is used, in case the span operation has failed, mnerjaa mnaamelun reset

                foreach (KeyValuePair<int, List<UCappointment>> entry in NewgroupedUCsCoverredByTheArea)//now we study each group, trying to fix its design to the max
                {


                    OriginalCoulunIndexAndSpanForEachGroup.Add(entry.Key, new List<(int, int)>());
                    foreach (UCappointment uc in entry.Value)
                    {
                        int OriginalIndex = uc.ColumnIndex;
                        int originalSpan = TLPSchedule.GetColumnSpan(uc);
                        OriginalCoulunIndexAndSpanForEachGroup[entry.Key].Add((OriginalIndex, originalSpan));

                    }



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
                        SetNewColumnSpanAndIndex(DesiredColumnIndexesGroup, entry.Value, true);
                    }




                }//foreach ejbare hone tekhlas

                //after fixing the span of all affected groups, we try to fit it

                IsUCAppScheduled = FittingUCIfPlaceExist(DesiredUCApp, StartingColumn, EndingColumn, StartingRow, EndingRow);//now men baaed ma zabatna el row spans tb3 el ucappointments, sar fi mahal elo lal appointment


                Dictionary<int, List<UCappointment>> EachGroupWithItsSerpents = new Dictionary<int, List<UCappointment>>();
                ClassucAppointmentGrouping grouper = new ClassucAppointmentGrouping(TLPSchedule, null, DesiredColumnIndexesGroup.Item2);//it will give all the uc , including the one we added
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

                    foreach (KeyValuePair<int, List<(int, int)>> OriginalSpanEntry in OriginalCoulunIndexAndSpanForEachGroup)
                    {
                        for (int i = 0; i < OriginalSpanEntry.Value.Count; i++)
                        {
                            UCappointment TargetedUCToFix = NewgroupedUCsCoverredByTheArea[OriginalSpanEntry.Key][i];

                            int OriginalIndex = OriginalSpanEntry.Value[i].Item1;
                            int OriginalSpan = OriginalSpanEntry.Value[i].Item2;

                            TLPSchedule.SetColumn(TargetedUCToFix, OriginalIndex);
                            TargetedUCToFix.ColumnIndex = OriginalIndex;

                            TLPSchedule.SetColumnSpan(TargetedUCToFix, OriginalSpan);
                        }
                    }



                    //Insert
                    int ColumnToInsert = DesiredColumnIndexesGroup.Item2[DesiredColumnIndexesGroup.Item2.Count() - 1] + 1;
                    InsertColumn(ColumnToInsert);
                    (StartingColumn, EndingColumn, StartingRow, EndingRow) = GetRectangle4Points(NewRow, DesiredColumnIndexesGroup, DesiredUCApp);//aam nerjaa naamela lieano new column is added,EndingColumn will change
                    FittingUCIfPlaceExist(DesiredUCApp, StartingColumn, EndingColumn, StartingRow, EndingRow);


                    List<UCappointment> ListOfAppPassed = new List<UCappointment>();//this stackis mde to prevent repition, since for a range of rows we can pass by the same uc
                    ClassucAppointmentGrouping grouperInsert = new ClassucAppointmentGrouping(TLPSchedule, null, DesiredColumnIndexesGroup.Item2);//aam nekhlae el ajdency tb3 the whol DesiredgroupIndexes

                    for (int rows = 0; rows < TLPSchedule.RowCount; rows++)//we need to change all the span of ucs groups in same DesiredIndexGroup(Same Big Column or Employee), ella AffectedGroup li already tghayaro foe
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
                                        TLPSchedule.SetColumnSpan(ucapp, TLPSchedule.GetColumnSpan(ucapp) + 1);

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
            }



            if (UCApointmentDraged != null)
            {
                Cursor.Current = Cursors.Default;
            }

        }
        void CheckIfLastColumnsShouldBeRemoved((ClassEmployee, List<int>) DesiredColumnIndexesGroup)//in case of dragrdrop, and we re removing and adding the same column ,ejbare men baeed el add, lieanno eza ken in the Same column shelnha men matrah w hattayna matrah tene (hayda el uc li aam aam yaamil insert la new column, huwwe zeit baddo yemnaa hayde el column ma tenmehe bhal code, lieanno ha ykun eendo latest index)
        {
            //ma32oul yseebo sawa, in the same group of columns
            int BigColumnCount = DesiredColumnIndexesGroup.Item2.Count();
            Queue<UCappointment> QueueUCApp = new Queue<UCappointment>();//this one will be used ,to fix the columns span affected by removing the last column
            Stack<UCappointment> stackucApp = new Stack<UCappointment>();//this stackis mde to prevent repition, since for a range of rows we can pass by the same uc
            if (BigColumnCount > 1)
            {

                int LastColumn = DesiredColumnIndexesGroup.Item2[BigColumnCount - 1];

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
                            //TLPSchedule.SetColumnSpan(ucapp, TLPSchedule.GetColumnSpan(ucapp) - 1);
                            stackucApp.Push(ucapp);
                            QueueUCApp.Enqueue(ucapp);
                        }
                    }
                }
                if (!IsUCAppExistOnTheLastColumn)
                {
                    foreach (UCappointment ucapp in QueueUCApp)
                    {
                        TLPSchedule.SetColumnSpan(ucapp, TLPSchedule.GetColumnSpan(ucapp) - 1);
                    }

                    RemoveColumn(DesiredColumnIndexesGroup.Item2[DesiredColumnIndexesGroup.Item2.Count() - 1]);
                }

            }

        }

        void RemoveUc((ClassEmployee, List<int>) DesiredColumnIndexesGroup, int Row, List<UCappointment> AllNewdUCInTheArea, UCappointment DesiredUCApp)//it will be !=null only in dragdrop operation
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


            if (AllNewdUCInTheArea != null && !ListsHaveSameElements(AllOldUCInTheArea, AllNewdUCInTheArea))
            {

                if (ListAllConnectedUCsToTheOneWereRemoving.Count > 0 && ListsHaveSameElements(AllOldUCInTheArea, ListAllConnectedUCsToTheOneWereRemoving))
                {
                    foreach (KeyValuePair<int, List<UCappointment>> Oldentry in OldGroupedUCsCoverByTheArea)
                    {
                        if (!CheckColumnOverlappingUcApp(Oldentry.Value))//Only GOOD SERPENT I FIX THEM
                        {
                            List<UCappointment> ListucAppointments = Oldentry.Value;

                            SetNewColumnSpanAndIndex(DesiredColumnIndexesGroup, ListucAppointments, false);

                        }
                    }
                }



            }
        }
        void SetSerpentBeforeRemovingAndThenRemoveIt((ClassEmployee, List<int>) DesiredColumnIndexesGroup, UCappointment DesiredUcApp)//uaed in dragdDrop or programatically
        {
            ClassucAppointmentGrouping grouper = new ClassucAppointmentGrouping(TLPSchedule, null, DesiredColumnIndexesGroup.Item2);
            ListAllConnectedUCsToTheOneWereRemoving = grouper.GetConnectedComponent(DesiredUcApp);//it gives us a list of all connected uc in these columns to this ucappp 
            ListAllConnectedUCsToTheOneWereRemoving.Remove(DesiredUcApp);//so now i have the list of the uc that are connecetd to this targeteduc, but without the targeteduc, so can compare it later on


            TLPSchedule.Controls.Remove(DesiredUcApp);
        }



        float PricisionError = 0f;//ma aa eedir le2e the error value
        private void InsertColumn(int columnIndex)
        {
            TLPSchedule.ColumnCount++;

            //finding the desiredIndexesgroup
            int i;
            for (i = 0; i < ListOfAllColumnIndexesGroups.Count; i++)
            {
                if (ListOfAllColumnIndexesGroups[i].Item2.Contains(columnIndex - 1))
                {
                    ListOfAllColumnIndexesGroups[i].Item2.Add(columnIndex);

                    i++;
                    break;
                }

            }

            ////fixing the size


            if (FocusOnColumnIndexGroup != (null, null))
            {
                TLPSchedule.ColumnStyles.Insert(columnIndex, new ColumnStyle(SizeType.Percent, 0F));
                ExpandTableLayoutPanelColumn(null);
            }
            else
            {


                (ClassEmployee, List<int>) TargetedIndexesGroup = ListOfAllColumnIndexesGroups[i - 1];
                float PercentageOfEachGroup = 100f / ListOfAllColumnIndexesGroups.Count + PricisionError;
                float PercentageOfEachColumn = PercentageOfEachGroup / TargetedIndexesGroup.Item2.Count;

                TLPSchedule.ColumnStyles.Insert(columnIndex, new ColumnStyle(SizeType.Percent, PercentageOfEachColumn));


                foreach (int ColumnIndex in TargetedIndexesGroup.Item2)
                {
                    TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
                }
            }


            //fixing the values in AllIndexesGroupList 
            while (i < ListOfAllColumnIndexesGroups.Count)
            {
                for (int j = 0; j < ListOfAllColumnIndexesGroups[i].Item2.Count; j++)
                {
                    ListOfAllColumnIndexesGroups[i].Item2[j]++;
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
        }
        private void RemoveColumn(int columnIndex)
        {
            TLPSchedule.ColumnCount--;
            //finding the desiredIndexesgroup
            int i;
            for (i = 0; i < ListOfAllColumnIndexesGroups.Count; i++)
            {
                if (ListOfAllColumnIndexesGroups[i].Item2.Contains(columnIndex - 1))
                {
                    ListOfAllColumnIndexesGroups[i].Item2.Remove(columnIndex);

                    i++;
                    break;
                }
            }

            //fixing the size
            TLPSchedule.ColumnStyles.RemoveAt(columnIndex);

            if (FocusOnColumnIndexGroup != (null, null))
            {
                ExpandTableLayoutPanelColumn(null);
            }
            else
            {
                (ClassEmployee, List<int>) TargetedIndexesGroup = ListOfAllColumnIndexesGroups[i - 1];
                float PercentageOfEachGroup = 100f / ListOfAllColumnIndexesGroups.Count - PricisionError;
                float PercentageOfEachColumn = PercentageOfEachGroup / TargetedIndexesGroup.Item2.Count;

                foreach (int ColumnIndex in TargetedIndexesGroup.Item2)
                {
                    TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
                }

            }

            //fixing the calues in AllIndexesGroupList 
            while (i < ListOfAllColumnIndexesGroups.Count)
            {
                for (int j = 0; j < ListOfAllColumnIndexesGroups[i].Item2.Count; j++)
                {
                    ListOfAllColumnIndexesGroups[i].Item2[j]--;
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
                    if (founducapp != null)
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




        void SetNewColumnSpanAndIndex((ClassEmployee, List<int>) DesiredIndexesGroup, List<UCappointment> ListucAppointments, bool IsAddingMode)//using this method make sure  to be sorted Column Asc, Row Asc
                                                                                                                                                //based ayya employee w nehna w el targeted controls baddun tozbit Span and index
        {
            int totalSpan = DesiredIndexesGroup.Item2.Count;
            int NewNumOfUCs = ListucAppointments.Count;

            if (IsAddingMode)
            {
                NewNumOfUCs++;//we re taking into considaration el the control lui ha yenzed , kermel naarif kif nwazii el spans 
            }


            if (totalSpan < NewNumOfUCs)//in this case we should insert a column
            {
                return;
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



            //Set Column Span
            for (int i = 0; i < spans.Count; i++)
            {
                if (i < ListucAppointments.Count)//Existing UCappointment
                {
                    TLPSchedule.SetColumnSpan(ListucAppointments[i], spans[i]);
                }
            }



            //Set Index
            int ColumnIndexToStartWith = DesiredIndexesGroup.Item2[0];
            foreach (UCappointment ucapp in ListucAppointments)
            {
                TLPSchedule.SetColumn(ucapp, ColumnIndexToStartWith);
                ucapp.ColumnIndex = ColumnIndexToStartWith;
                ColumnIndexToStartWith += TLPSchedule.GetColumnSpan(ucapp);
            }
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
        (ClassEmployee, List<int>) GetWichDesiredIndexesGroup(int StartingColumn)
        {
            int WhichEmployee = 0;
            foreach ((ClassEmployee, List<int>) Group in ListOfAllColumnIndexesGroups)
            {
                if (Group.Item2.Contains(StartingColumn))
                {
                    return ListOfAllColumnIndexesGroups[WhichEmployee];
                }
                WhichEmployee++;
            }
            return (null, null);
        }
        (int, int, int, int) GetRectangle4Points(int DesiredRow, (ClassEmployee, List<int>) desiredIndexesGroup, UCappointment DesiredUCApp)
        {
            int StartingColumn = desiredIndexesGroup.Item2[0];//in case  NULLLLLLLL bcz of debugging mode mesh aktar
            int EndingColumn = desiredIndexesGroup.Item2[desiredIndexesGroup.Item2.Count - 1];


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
            DateTime dateTime = DateTime.Today.Add(GetTimeFromRow(rowIndex));
            string textToDraw = dateTime.ToString("hh:mm tt");

            // Define the format for the text
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near; // Horizontal alignment
                sf.LineAlignment = StringAlignment.Center; // Vertical alignment


                g.DrawString(textToDraw, CellTextFont, CellTextBrush, cellBounds, sf);

            }
        }

        private void TLPSchedule_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {


            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;


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



            if (NbrRowShouldPass == -1)
            {
                // Check if this cell's row belongs to the same group as the hovered cell
                if (currentGroup == hoveredGroup && (ColumnIndexGroupOfDraggingUC != (null, null) && ColumnIndexGroupOfDraggingUC.Item2.Contains(e.Column)))
                {

                    g.FillRectangle(hoverBrush, r);


                    //drwaing the text only
                    if (e.Row == hoveredCellColmnRow.Item2 && e.Column == ColumnIndexGroupOfDraggingUC.Item2[0])
                    {
                        DrawTextOnCell(g, r, e.Row);
                    }
                }
            }
            else
            {
                if ((e.Row >= hoveredCellColmnRow.Item2 - 1 && e.Row <= (hoveredCellColmnRow.Item2 + NbrRowShouldPass - 1)) && (ColumnIndexGroupOfDraggingUC != (null, null) && ColumnIndexGroupOfDraggingUC.Item2.Contains(e.Column)))
                {

                    g.FillRectangle(hoverBrush, r);

                    if (e.Row == hoveredCellColmnRow.Item2 - 1 && e.Column == ColumnIndexGroupOfDraggingUC.Item2[0])
                    {

                        // Draw text on the specified cell
                        DrawTextOnCell(g, r, e.Row);


                    }

                }
            }





            ////Check if we're in the last column; if not, don't draw vertical lines
            if (e.Column < TLPSchedule.ColumnCount)
            {
                foreach ((ClassEmployee, List<int>) va in ListOfAllColumnIndexesGroups)
                {

                    if (e.Column == va.Item2[0] && e.Column != 0)
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
                    //g.DrawLine(Pens.LightGray, r.Left, r.Top, r.Right, r.Top);
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
                foreach ((ClassEmployee, List<int>) Group in ListOfAllColumnIndexesGroups)
                {
                    if (Group.Item2.Contains(hoveredCellColmnRow.Item1))
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
            ColumnIndexGroupOfDraggingUC = (null, null);
            UCApointmentDraged = null;
            Cursor.Current = Cursors.Default; // Reset the cursor to the default
            TLPSchedule.Invalidate();
        }

       
    }
}
