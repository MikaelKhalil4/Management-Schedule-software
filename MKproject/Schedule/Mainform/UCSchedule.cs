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


namespace MKproject.Schedule
{
    public partial class UCSchedule : UserControl
    {
        public ScheduleForm ParentFormSchedule { get; set; }

        public DateTime SelectedDate { get; set; }


        public List<ClassEmployee> EmployeeScheduleList { get; set; }//present-future
        public List<ClassAppointment> AppointmentsList { get; set; }



        public TableLayoutPanelBuffered TLPAppointment;
        List<(ClassEmployee, List<int>)> ListOfAllColumnIndexesGroups = new List<(ClassEmployee, List<int>)>();
        (ClassEmployee, List<int>) FocusOnColumnIndexGroup;
        int FocusOnMaxWidth;


        ///-Reminder
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
            SelectedDate = selectedDate;

            FillEmployeLists();

            AppointmentsList = ClassAppointment.GetAppointmentOfSpecificEmployees(SelectedDate, EmployeeScheduleList);

            SetListOfAllColumnIndexesGroups();//ejbare men baaed li foe
            AddAppointmentsToTlpSchedule();
            CreateTLPDesign();
        }

        ///-Reminder
        ///-Reminder
        public bool isThedayofUCreminder(ClassReminder DesiredReminder, DateTime date)
        {
            //For every day, no repeat
            if (DesiredReminder.Partsrepeat.Length == 1)
            {
                if (DesiredReminder.Partsrepeat[0] == Reminder.NoRepeat)
                {
                    if (date.Date == DesiredReminder.StartTime.Date)
                    {
                        return true;
                    }

                }

                else if (DesiredReminder.Partsrepeat[0] == Reminder.Everyday)
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
                    for (int i = 1; i < DesiredReminder.Partsrepeat.Length; i++)
                    {
                        if (date.DayOfWeek.ToString() == DesiredReminder.Partsrepeat[i])
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
                DesiredReminder.LabelQuote = (string)dr["labelquote"];
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
            ParentFormSchedule.TouchscrollPanelreminder.ReAssignEventPanelreminder(ParentFormSchedule.panelreminder);
        }
        void SetListOfAllColumnIndexesGroups()
        {
            int StartintColumnIndex = 1;//lieanno fi el time 0

            foreach (ClassEmployee employee in EmployeeScheduleList)
            {
                var events = new List<(DateTime time, bool isStart)>();

                foreach (var appt in AppointmentsList.Where(a => a.EmployeeId == employee.EmployeeId))
                {
                    events.Add((appt.StartTime, true)); // start time
                    events.Add((appt.EndTime, false)); // end time
                }

                // Sorting events
                events.Sort((a, b) => a.time == b.time ? (a.isStart == b.isStart ? 0 : (a.isStart ? -1 : 1)) : a.time.CompareTo(b.time));

                int maxOverlap = 0, currentOverlap = 0;
                foreach (var e in events)
                {
                    if (e.isStart)
                        currentOverlap++;
                    else
                        currentOverlap--;

                    if (currentOverlap > maxOverlap)
                        maxOverlap = currentOverlap;
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
                UCappointment ucappointments = new UCappointment(DesiredAppointment, this);
                AddUCappointmentsInTLP(ucappointments);
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
                        EmployeeScheduleList.Add(employee);
                    }
                }
            }

            //Changing Date
            labelDate.Text = SelectedDate.ToString("dddd,MMMM dd,yyyy");


        }//Display the title and the ucappointments



        public void ChangePositionUCappointments(UCappointment DesiredUCApp, ClassAppointment OldAppointment, ClassAppointment UpdatedAppointment)
        {
            int EmployeeId = DesiredUCApp.DesiredAppointmentUCApp.EmployeeId;

            (int RowIndexStart, int RowIndexEnd) = GetUCAppointmentRowIndexes(OldAppointment);//hone el el start  w el end time before updating
            PurelyRemovingUcApp(EmployeeId, RowIndexStart, DesiredUCApp);


            (RowIndexStart, RowIndexEnd) = GetUCAppointmentRowIndexes(UpdatedAppointment);//hone el  start  w el end time after updating
            PurellyAddingUcApp(EmployeeId, RowIndexStart, DesiredUCApp);

            //TouchscrollPanelUCDay.ReAssignEventPanelUCDay(TLPAppointment);
        }
        public void RemoveUcAppointmentFromTLP(UCappointment DesiredUCApp)
        {
            int EmployeeId = DesiredUCApp.DesiredAppointmentUCApp.EmployeeId;

            (int RowIndexStart, int RowIndexEnd) = GetUCAppointmentRowIndexes(DesiredUCApp.DesiredAppointmentUCApp);

            PurelyRemovingUcApp(EmployeeId, RowIndexStart, DesiredUCApp);
        }
        public void AddUCappointmentsInTLP(UCappointment DesiredUCApp)
        {
            int EmployeeId = DesiredUCApp.DesiredAppointmentUCApp.EmployeeId;

            (int RowIndexStart, int RowIndexEnd) = GetUCAppointmentRowIndexes(DesiredUCApp.DesiredAppointmentUCApp);

            int RowSpan = RowIndexEnd - RowIndexStart;
            TLPAppointment.SetRowSpan(DesiredUCApp, RowSpan);


            PurellyAddingUcApp(EmployeeId, RowIndexStart, DesiredUCApp);
        }

        public (int, int) GetUCAppointmentRowIndexes(ClassAppointment DesiredAppointment)
        {
            TimeSpan starttimeTimeSpan = DesiredAppointment.StartTime.TimeOfDay;
            int PositionRowStart = GetRowFromTime(starttimeTimeSpan);

            TimeSpan endtimeTimeSpan = DesiredAppointment.EndTime.TimeOfDay;
            int PositionRowEnd = GetRowFromTime(endtimeTimeSpan);


            return (PositionRowStart, PositionRowEnd);//position flowlayoutpanel hiye position employee bel list-1 
        }




        ///////////////////////////////////////



        //these are for the values of the uc while drag/drop operation
        (ClassEmployee, List<int>) OldColumnIndexGroupOfDesiredUC;
        int OldColumnofDraggedUC;//old column is the exact column li ken aalaya el uc
        int OldRowOfDraggedUC;

        List<UCappointment> ListAllConnectedUCsToTheOneWereRemoving;//this serpent doesn tonly cover the area of the removed uc, but also outside the are, which
                                                                    //Which we care about , because the one we dont see could cause us problems, that s why the one we dont see if they exist, we dont do the auto size



        UCappointment UCApointmentDraged;
        (ClassEmployee, List<int>) ColumnIndexGroupOfDraggingUC = (null, null);//stores the index columns Related To employee , when we re dragging a uc
        private (int, int) hoveredCellColmnRow = (-1, -1);  // Stores the  (column,row) of the hovered cell


        int NbreofRowsHighlighted = -1;//how many rows we need to highlight while mouse hover or dragging
        Brush hoverBrush = new SolidBrush(Color.FromArgb(225, 235, 245)); // Change the color as needed

        Dictionary<Point, bool> AvailableCells = new Dictionary<Point, bool>();



        void CreateTLPDesign()
        {

            //uc1.UCAppIsDroped += Uc1_UCAppIsDroped;


            //
            if (TLPAppointment == null)
            {

                TLPAppointment = new TableLayoutPanelBuffered();
                TLPAppointment.AllowDrop = true;
                TLPAppointment.Dock = DockStyle.Fill;
                TLPAppointment.AutoScroll = true;
                TLPAppointment.BackColor = Color.FromArgb(245, 245, 245);


                //Hours
                TLPAppointment.RowCount = 96;
                for (int i = 0; i < TLPAppointment.RowCount; i++)
                {
                    TLPAppointment.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));

                }



                //Time

                //Time in Tlp employee
                TLPEmployees.ColumnStyles[0].Width = 100f;

                //Time in TLP Schedule, ejbare absoloute
                TLPAppointment.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
                TLPAppointment.ColumnCount++;



                //
                for (int i = 0; i < TLPAppointment.RowCount; i += 4)
                {
                    Label LabelTime = new Label();
                    LabelTime.Dock = DockStyle.Fill;
                    LabelTime.BackColor = TLPAppointment.BackColor;
                    LabelTime.ForeColor = Color.FromArgb(50, 50, 50);
                    LabelTime.Dock = DockStyle.Fill;
                    LabelTime.TextAlign = ContentAlignment.TopRight;
                    LabelTime.Font = new Font("Segoe UI", 10, FontStyle.Regular);

                    TimeSpan Time = TimeSpan.FromHours(i / 4);

                    DateTime dateTime = DateTime.Today.Add(Time);//datetime it's a reference
                    string timestring = dateTime.ToString("h tt");
                    string[] partstime = timestring.Split(' ');
                    LabelTime.Text = partstime[0] + " " + partstime[1];


                    TLPAppointment.Controls.Add(LabelTime, 0, i);
                    TLPAppointment.SetRowSpan(LabelTime, 4);
                }


                //Events
                TLPAppointment.Resize += TLPSchedule_Resize;

                TLPAppointment.MouseWheel += TLPSchedule_MouseMove;
                TLPAppointment.MouseMove += TLPSchedule_MouseMove;

                TLPAppointment.MouseLeave += TLPSchedule_MouseLeave;

                TLPAppointment.CellPaint += TLPSchedule_CellPaint;
                TLPAppointment.DragDrop += TLPSchedule_DragDrop;
                TLPAppointment.DragEnter += TLPSchedule_DragEnter;
                TLPAppointment.DragOver += TLPSchedule_DragOver;

                this.TLPGlobal.Controls.Add(TLPAppointment,0,2);


            }

            //Colmns Groups, ha ykun percentage
            SetTLPSchGroupColumnAndTLPEmpColumns();

            //
            SetMaxWidth();

        }
        void SetTLPSchGroupColumnAndTLPEmpColumns()
        {

            TLPAppointment.SuspendLayout();  // Suspend layout to improve performance        
            TLPAppointment.ColumnCount = 1;
            while (TLPAppointment.ColumnStyles.Count > 1)
            {
                TLPAppointment.ColumnStyles.RemoveAt(1);
            }
            TLPAppointment.ResumeLayout();  // Resume layout after making changes




            if (ListOfAllColumnIndexesGroups.Count > 0)
            {
                //Employees, ejbare percentage
                foreach ((ClassEmployee, List<int>) Group in ListOfAllColumnIndexesGroups)
                {
                    foreach (int ColumnIndex in Group.Item2)
                    {
                        TLPAppointment.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                        TLPAppointment.ColumnCount++;
                    }
                }

                ResizeTLPScheduleToPerc();
                SetTLPEmployeesColumn();
            }
            else
            {
                BlockedModeDesign("No Employees Available");
            }
        }
        void SetTLPEmployeesColumn()//always called after SetTLPSchGroupColumn 
        {
            float PercentageOfEachGroup = 100 / ListOfAllColumnIndexesGroups.Count;
            for (int i = 0; i < ListOfAllColumnIndexesGroups.Count; i++)
            {
                TLPEmployees.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, PercentageOfEachGroup));
                TLPEmployees.ColumnCount++;
            }
        }
        void BlockedModeDesign(string OutputText)
        {
            LabelEmployee labelEmployee = (LabelEmployee)TLPEmployees.GetControlFromPosition(1, 0);//BOOM
            labelEmployee.Text = OutputText;
            TLPAppointment.Enabled = false;
        }


        public void ExpandTableLayoutPanelColumn()
        {

            int OriginalWidthOfDesiredGroup = UCappointment.OriginalWidth * FocusOnColumnIndexGroup.Item2.Count;

            int DesiredWidthOfTheGroup = OriginalWidthOfDesiredGroup < FocusOnMaxWidth ? OriginalWidthOfDesiredGroup : FocusOnMaxWidth;


            int DesiredWidthPerColumn = DesiredWidthOfTheGroup / FocusOnColumnIndexGroup.Item2.Count;

            foreach (int ColumnIndex in FocusOnColumnIndexGroup.Item2)
            {
                TLPAppointment.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Absolute, DesiredWidthPerColumn);
            }
        }
        public void ResizeTLPScheduleToPerc()
        {
            float PercentageOfEachGroup = 100 / ListOfAllColumnIndexesGroups.Count;

            foreach ((ClassEmployee, List<int>) Group in ListOfAllColumnIndexesGroups)
            {
                float PercentageOfEachColumn = PercentageOfEachGroup / Group.Item2.Count;

                foreach (int ColumnIndex in Group.Item2)
                {
                    TLPAppointment.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
                }
            }
        }



        private void TLPSchedule_Resize(object sender, EventArgs e)
        {
            if (TLPAppointment.ColumnCount > 1)
            {
                SetMaxWidth();
                ResizeTLPScheduleToPerc();
                FocusOnColumnIndexGroup = (null, null);
            }
         
        }
        void SetMaxWidth()
        {
            FocusOnMaxWidth = (int)((TLPAppointment.Width - TLPAppointment.GetColumnWidths()[0]) * 0.85);//so he will be 90 % of the columns without the first column
        }
        void FocusOnEmployee(int empId)
        {

            FocusOnColumnIndexGroup = GetWhichDesiredGroup(empId);

            ExpandTableLayoutPanelColumn();
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
            CheckIfLastColumnsShouldBeRemoved();
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
        TimeSpan GetHourFromRow(int row)
        {
            int TotalHour = 24;
            int TotalRow = TLPAppointment.RowCount;

            int hours = (row * TotalHour) / TotalRow;

            int remainderRows = row % (TotalRow / TotalHour);
            int minutes = remainderRows * 15;


            return new TimeSpan(hours, minutes, 0);
        }
        public int GetRowFromTime(TimeSpan Time)
        {
            int TotalHour = 24;
            int TotalRow = TLPAppointment.RowCount;

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

                OldColumnofDraggedUC = TLPAppointment.GetColumn(UCApointmentDraged);
                OldRowOfDraggedUC = TLPAppointment.GetRow(UCApointmentDraged);

                OldColumnIndexGroupOfDesiredUC = GetWichDesiredIndexesGroup(OldColumnofDraggedUC);

                SetSerpentBeforeRemovingAndThenRemoveIt(OldColumnIndexGroupOfDesiredUC, UCApointmentDraged);

            }
        }
        private void TLPSchedule_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

            Point clientPoint = TLPAppointment.PointToClient(new Point(e.X, e.Y));
            SetValuesthatWillAffectselection(clientPoint);
        }
        private void Uc1_UCAppIsDroped(object sender, EventArgs e)//kermel eza kabbayneha outside the bounds what to return it mahalla
        {
            Point cursorPosition = this.PointToClient(Cursor.Position);
            if (!TLPAppointment.ClientRectangle.Contains(cursorPosition))
            {
                TLPAppointment.Controls.Add(UCApointmentDraged, OldColumnofDraggedUC, OldRowOfDraggedUC);//lezim tekhlaa column aw tsayoo haddo
                ResetSelection();
            }
        }
        private void TLPSchedule_DragDrop(object sender, DragEventArgs e)
        {

            Point clientPoint = TLPAppointment.PointToClient(new Point(e.X, e.Y)); // Convert the screen coordinates to client coordinates
            (int ColumnIndex, int RowIndexStart) = GetCellPosition(TLPAppointment, clientPoint);

            (int StartingColumn, int EndingColumn, int StartingRow, int EndingRow) = GetRectangle4Points(RowIndexStart, ColumnIndexGroupOfDraggingUC, UCApointmentDraged);



            if (ColumnIndexGroupOfDraggingUC != (null, null))
            {
                //adding
                if (UCApointmentDraged != null && StartingColumn >= 1 && StartingRow >= 0 && CheckIfPositionAvailable(StartingColumn, StartingRow))//first column for the timer
                {

                    DragDropBusinessLogic(ColumnIndex, RowIndexStart);

                    //

                    List<UCappointment> NewListUC = GetListOfAllControlsInSpecifiedArea(StartingColumn, EndingColumn, StartingRow, EndingRow);//it  will give the list, without the uc we re adding

                    ClassucAppointmentGrouping grouper2 = new ClassucAppointmentGrouping(TLPAppointment, NewListUC, null);
                    Dictionary<int, List<UCappointment>> NewgroupedUCsCoverredByTheArea = grouper2.ClassifyGroupsThatAreConnected();
                    List<UCappointment> AllNewdUCInTheArea = NewgroupedUCsCoverredByTheArea.SelectMany(pair => pair.Value).ToList();



                    //Removing Mode
                    RemoveUc(OldColumnIndexGroupOfDesiredUC, OldRowOfDraggedUC, AllNewdUCInTheArea, UCApointmentDraged);//mafina abel el add, lieanno ma32oul yse2ib bel old area, ykun intesects maa el ucapp li aam yonhatt in its new position
                                                                                                                        //so when we call el remove, we need to make ykun sure enno el appointment baaed ma nhatt, yaane ma aayetna baeed lal AddUc


                    AddUc(ColumnIndexGroupOfDraggingUC, RowIndexStart, UCApointmentDraged);


                    UCApointmentDraged.Dock = DockStyle.Fill;
                    UCApointmentDraged.isDragging = false;
                    UCApointmentDraged.Show();
                    UCApointmentDraged = null;

                    ResetSelection();

                }
                else
                {
                    TLPAppointment.Controls.Add(UCApointmentDraged, OldColumnofDraggedUC, OldRowOfDraggedUC);
                    ResetSelection();
                }

            }
            else
            {
                TLPAppointment.Controls.Add(UCApointmentDraged, OldColumnofDraggedUC, OldRowOfDraggedUC);
                ResetSelection();
            }
            //TouchscrollPanelUCDay.AssignEventPanelUCDay(TLPSchedule);

        }

        bool CheckIfPositionAvailable(int StartingColumn, int StartingRow)
        {
            return true;
        }

        void DragDropBusinessLogic(int NewColumnIndex, int NewRowIndexStart)//Test
        {

            int NewRowIndexEnd = NewRowIndexStart + TLPAppointment.GetRowSpan(UCApointmentDraged) - 1;

            int OldPositionrowStart = UCApointmentDraged.RowIndexStart;
            int OldPositioncol = UCApointmentDraged.ColumnIndex;

            if (UCApointmentDraged != null && (NewColumnIndex != OldPositioncol || NewRowIndexStart != OldPositionrowStart))
            {

                UCApointmentDraged.RowIndexStart = NewRowIndexStart;
                UCApointmentDraged.RowIndexEnd = NewRowIndexEnd;
                UCApointmentDraged.ColumnIndex = NewColumnIndex;

                UCApointmentDraged.OldDesiredAppointmentUCApp = UCApointmentDraged.DesiredAppointmentUCApp.Copy();//we should copy before changing to the new time

                //StartTime
                TimeSpan NewStartTime = GetHourFromRow(NewRowIndexStart);
                UCApointmentDraged.DesiredAppointmentUCApp.StartTime = UCApointmentDraged.DesiredAppointmentUCApp.StartTime.Date + NewStartTime;


                //EndTime
                TimeSpan NewEndTime = GetHourFromRow(NewRowIndexEnd); ;
                UCApointmentDraged.DesiredAppointmentUCApp.EndTime = UCApointmentDraged.DesiredAppointmentUCApp.EndTime.Date + NewEndTime;


                //Employee
                UCApointmentDraged.DesiredAppointmentUCApp.EmployeeId = ((ClassEmployee)GetWhichEmployeeForSpecifieColumn(NewColumnIndex)).EmployeeId;

                //SQL
                UCApointmentDraged.DesiredAppointmentUCApp.InsertOrUpdateAppointment(false);

                //
                UCApointmentDraged.SetUCDesign();
                UCApointmentDraged.DragAndDropOperationDone();
            }
            else
            {
                NotificationBanner.Show("Time Not Available!", NotificationBanner.EnumType.DeletedMode, false, Program.HomeForm, false);
            }


        }




        void AddUc((ClassEmployee, List<int>) DesiredColumnIndexesGroup, int NewRow, UCappointment DesiredUCApp)//eza from drag:DesiredGroupOfUC=GroupOfDraggingUC , eza by code:DesiredGroupOfUC=Shi nehna ha nebaato hasab wen aam naamil add or undo
        {

            Cursor = Cursors.WaitCursor;

            (int StartingColumn, int EndingColumn, int StartingRow, int EndingRow) = GetRectangle4Points(NewRow, DesiredColumnIndexesGroup, DesiredUCApp);
            List<UCappointment> NewListUC = GetListOfAllControlsInSpecifiedArea(StartingColumn, EndingColumn, StartingRow, EndingRow);//it  will give the list, without the uc we re adding


            ClassucAppointmentGrouping grouper2 = new ClassucAppointmentGrouping(TLPAppointment, NewListUC, null);
            Dictionary<int, List<UCappointment>> NewgroupedUCsCoverredByTheArea = grouper2.ClassifyGroupsThatAreConnected();
            List<UCappointment> AllNewdUCInTheArea = NewgroupedUCsCoverredByTheArea.SelectMany(pair => pair.Value).ToList();



            bool IsUCAppScheduled;

            IsUCAppScheduled = FittingUCIfPlaceExist(DesiredUCApp, StartingColumn, EndingColumn, StartingRow, EndingRow);

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
                        int originalSpan = TLPAppointment.GetColumnSpan(uc);
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
                ClassucAppointmentGrouping grouper = new ClassucAppointmentGrouping(TLPAppointment, null, DesiredColumnIndexesGroup.Item2);//it will give all the uc , including the one we added
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

                            TLPAppointment.SetColumn(TargetedUCToFix, OriginalIndex);
                            TargetedUCToFix.ColumnIndex = OriginalIndex;

                            TLPAppointment.SetColumnSpan(TargetedUCToFix, OriginalSpan);
                        }
                    }



                    //Insert
                    int ColumnToInsert = DesiredColumnIndexesGroup.Item2[DesiredColumnIndexesGroup.Item2.Count() - 1] + 1;
                    InsertColumn(ColumnToInsert);
                    (StartingColumn, EndingColumn, StartingRow, EndingRow) = GetRectangle4Points(NewRow, DesiredColumnIndexesGroup, DesiredUCApp);
                    FittingUCIfPlaceExist(DesiredUCApp, StartingColumn, EndingColumn, StartingRow, EndingRow);


                    List<UCappointment> ListOfAppPassed = new List<UCappointment>();//this stackis mde to prevent repition, since for a range of rows we can pass by the same uc
                    ClassucAppointmentGrouping grouperInsert = new ClassucAppointmentGrouping(TLPAppointment, null, DesiredColumnIndexesGroup.Item2);//aam nekhlae el ajdency tb3 the whol DesiredgroupIndexes

                    for (int rows = 0; rows < TLPAppointment.RowCount; rows++)//we need to change all the span of ucs groups in same DesiredIndexGroup(Same Big Column or Employee), ella AffectedGroup li already tghayaro foe
                    {
                        UCappointment ucapp = (UCappointment)TLPAppointment.GetControlFromPosition(ColumnToInsert - 1, rows);
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
                                        TLPAppointment.SetColumnSpan(ucapp, TLPAppointment.GetColumnSpan(ucapp) + 1);

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

            //ejbare men baeed el add, Read why 
            CheckIfLastColumnsShouldBeRemoved();


            Cursor = Cursors.Default;

        }
        void CheckIfLastColumnsShouldBeRemoved()//if add exists,ejbare men baeed el add, lieanno eza ken in the Same column shelnha men matrah w hattayna matrah tene (hayda el uc li aam aam yaamil insert la new column, huwwe zeit baddo yemnaa hayde el column ma tenmehe bhal code, lieanno ha ykun eendo latest index)
        {
            //ma32oul yseebo sawa, in the same group of columns
            int BigColumnCount = OldColumnIndexGroupOfDesiredUC.Item2.Count();
            Queue<UCappointment> QueueUCApp = new Queue<UCappointment>();//this one will be used ,to fix the columns span affected by removing the last column
            Stack<UCappointment> stackucApp = new Stack<UCappointment>();//this stackis mde to prevent repition, since for a range of rows we can pass by the same uc
            if (BigColumnCount > 1)
            {

                int LastColumn = OldColumnIndexGroupOfDesiredUC.Item2[BigColumnCount - 1];

                bool IsUCAppExistOnTheLastColumn = false;
                for (int rows = 0; rows < TLPAppointment.RowCount; rows++)
                {
                    UCappointment ucapp = (UCappointment)TLPAppointment.GetControlFromPosition(LastColumn, rows);
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
                        TLPAppointment.SetColumnSpan(ucapp, TLPAppointment.GetColumnSpan(ucapp) - 1);
                    }

                    RemoveColumn(OldColumnIndexGroupOfDesiredUC.Item2[OldColumnIndexGroupOfDesiredUC.Item2.Count() - 1]);
                }

            }

        }

        void RemoveUc((ClassEmployee, List<int>) DesiredColumnIndexesGroup, int Row, List<UCappointment> AllNewdUCInTheArea, UCappointment DesiredUCApp)//it will be !=null only in dragdrop operation
        {
            //removing

            (int OldStartingColumn, int OldEndingColumn, int OldStartingRow, int OldEndingRow) = GetRectangle4Points(Row, DesiredColumnIndexesGroup, DesiredUCApp);//ejbare ouaa tshila, hole el values mestaamlin baaden
            List<UCappointment> OldListUC = GetListOfAllControlsInSpecifiedArea(OldStartingColumn, OldEndingColumn, OldStartingRow, OldEndingRow);//it will give the list, without the uc we re removing


            ClassucAppointmentGrouping grouper1 = new ClassucAppointmentGrouping(TLPAppointment, OldListUC, null);
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
            ClassucAppointmentGrouping grouper = new ClassucAppointmentGrouping(TLPAppointment, null, DesiredColumnIndexesGroup.Item2);
            ListAllConnectedUCsToTheOneWereRemoving = grouper.GetConnectedComponent(DesiredUcApp);//it gives us a list of all connected uc in these columns to this ucappp 
            ListAllConnectedUCsToTheOneWereRemoving.Remove(DesiredUcApp);//so now i have the list of the uc that are connecetd to this targeteduc, but without the targeteduc, so can compare it later on


            TLPAppointment.Controls.Remove(DesiredUcApp);
        }



        float PricisionError = 0f;//ma aa eedir le2e the error value
        private void InsertColumn(int columnIndex)
        {
            TLPAppointment.ColumnCount++;

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
                TLPAppointment.ColumnStyles.Insert(columnIndex, new ColumnStyle(SizeType.Percent, 0F));
                ExpandTableLayoutPanelColumn();
            }
            else
            {


                (ClassEmployee, List<int>) TargetedIndexesGroup = ListOfAllColumnIndexesGroups[i - 1];
                float PercentageOfEachGroup = 100f / ListOfAllColumnIndexesGroups.Count + PricisionError;
                float PercentageOfEachColumn = PercentageOfEachGroup / TargetedIndexesGroup.Item2.Count;

                TLPAppointment.ColumnStyles.Insert(columnIndex, new ColumnStyle(SizeType.Percent, PercentageOfEachColumn));


                foreach (int ColumnIndex in TargetedIndexesGroup.Item2)
                {
                    TLPAppointment.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
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
            foreach (Control co in TLPAppointment.Controls)
            {
                int OldColumnsIndex = TLPAppointment.GetColumn(co);
                if (co is UCappointment && TLPAppointment.GetColumn(co) >= columnIndex)
                {
                    int newIndex = OldColumnsIndex + 1;
                    TLPAppointment.SetColumn(co, newIndex);
                    ((UCappointment)co).ColumnIndex = newIndex;
                }
            }
        }
        private void RemoveColumn(int columnIndex)
        {
            TLPAppointment.ColumnCount--;
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
            TLPAppointment.ColumnStyles.RemoveAt(columnIndex);

            if (FocusOnColumnIndexGroup != (null, null))
            {
                ExpandTableLayoutPanelColumn();
            }
            else
            {
                (ClassEmployee, List<int>) TargetedIndexesGroup = ListOfAllColumnIndexesGroups[i - 1];
                float PercentageOfEachGroup = 100f / ListOfAllColumnIndexesGroups.Count - PricisionError;
                float PercentageOfEachColumn = PercentageOfEachGroup / TargetedIndexesGroup.Item2.Count;

                foreach (int ColumnIndex in TargetedIndexesGroup.Item2)
                {
                    TLPAppointment.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
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
            foreach (Control co in TLPAppointment.Controls)
            {
                int OldColumnsIndex = TLPAppointment.GetColumn(co);
                if (co is UCappointment && TLPAppointment.GetColumn(co) >= columnIndex)
                {
                    int newIndex = OldColumnsIndex - 1;
                    TLPAppointment.SetColumn(co, newIndex);
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
                    var DesignPos = TLPAppointment.GetPositionFromControl(TaregetedUCApp);

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
                    UCappointment founducapp = (UCappointment)TLPAppointment.GetControlFromPosition(j, i);//we re checking each cell eza fiya shi, which will cover the whole area of the usercontrol
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
                TLPAppointment.Controls.Add(DesiredUCApp, StartingColumn, StartingRow);
                DesiredUCApp.ColumnIndex = StartingColumn;
                DesiredUCApp.RowIndexStart = StartingRow;
                TLPAppointment.SetColumnSpan(DesiredUCApp, (EndingColumn - StartingColumn) + 1);
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
                    TLPAppointment.SetColumnSpan(ListucAppointments[i], spans[i]);
                }
            }



            //Set Index
            int ColumnIndexToStartWith = DesiredIndexesGroup.Item2[0];
            foreach (UCappointment ucapp in ListucAppointments)
            {
                TLPAppointment.SetColumn(ucapp, ColumnIndexToStartWith);
                ucapp.ColumnIndex = ColumnIndexToStartWith;
                ColumnIndexToStartWith += TLPAppointment.GetColumnSpan(ucapp);
            }
        }
        public bool CheckColumnOverlappingUcApp(List<UCappointment> UcAppListOrig)//kermel naarif eza controls inside  listofserpent, eemlin column overlapp => bad serpent, we handle it in a specific way 
        {
            // Sort appointments by start column to make overlap detection easier
            List<UCappointment> ucAppList = new List<UCappointment>(UcAppListOrig);
            ucAppList.Sort((a, b) => TLPAppointment.GetColumn(a).CompareTo(TLPAppointment.GetColumn(b)));

            for (int i = 0; i < ucAppList.Count - 1; i++)
            {
                var current = ucAppList[i];
                var next = ucAppList[i + 1];

                int currentStartColumn = TLPAppointment.GetColumn(current);
                int currentColumnSpan = TLPAppointment.GetColumnSpan(current);
                int nextStartColumn = TLPAppointment.GetColumn(next);

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
            int EndingRow = DesiredRow + TLPAppointment.GetRowSpan(DesiredUCApp) - 1;

            return (StartingColumn, EndingColumn, StartingRow, EndingRow);
        }
        List<UCappointment> GetListOfAllControlsInSpecifiedArea(int StartingColumn, int EndingColumn, int StartingRow, int EndingRow)
        {
            List<UCappointment> ListUC = new List<UCappointment> { };
            for (int i = StartingRow; i <= EndingRow; i++)
            {
                for (int j = StartingColumn; j <= EndingColumn; j++)
                {
                    UCappointment founducapp = (UCappointment)TLPAppointment.GetControlFromPosition(j, i);
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







        private void TLPSchedule_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {


            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;


            int NbrRowShouldPass;
            int currentGroup = -1;
            int hoveredGroup = -1;
            if (UCApointmentDraged != null)
            {
                NbrRowShouldPass = TLPAppointment.GetRowSpan(UCApointmentDraged) - 1;

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

                    //if (e.Row == hoveredCellColmnRow.Item2 && e.Column == ColumnIndexGroupOfDraggingUC.Item2[0])
                    //{

                    //    string textToDraw = "12:00 am";

                    //    // Define the format for the text
                    //    using (StringFormat sf = new StringFormat())
                    //    {
                    //        sf.Alignment = StringAlignment.Near; // Horizontal alignment
                    //        sf.LineAlignment = StringAlignment.Center; // Vertical alignment

                    //        // Define the brush and font for the text
                    //        using (Brush textBrush = new SolidBrush(Color.Blue))
                    //        using (Font textFont = new Font("Arial", 10, FontStyle.Regular))
                    //        {
                    //            g.DrawString(textToDraw, textFont, textBrush, r, sf);
                    //        }
                    //    }
                    //}
                }
            }
            else
            {
                if ((e.Row >= hoveredCellColmnRow.Item2 && e.Row <= (hoveredCellColmnRow.Item2 + NbrRowShouldPass)) && (ColumnIndexGroupOfDraggingUC != (null, null) && ColumnIndexGroupOfDraggingUC.Item2.Contains(e.Column)))
                {

                    g.FillRectangle(hoverBrush, r);

                   
                }
            }





            ////Check if we're in the last column; if not, don't draw vertical lines
            if (e.Column < TLPAppointment.ColumnCount)
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
            if (e.Row < TLPAppointment.RowCount)
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
            (int, int) cellPos = GetCellPosition(TLPAppointment, Loaction);

            if (cellPos != hoveredCellColmnRow)
            {

                //set whichcolumn and row we are
                hoveredCellColmnRow = cellPos;

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


                TLPAppointment.Invalidate();
                //InvalidateSpecificCells(); // Causes the control to be redrawn
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
            Cursor.Current = Cursors.Default; // Reset the cursor to the default
            TLPAppointment.Invalidate();
        }



    }
}
