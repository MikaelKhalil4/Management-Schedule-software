using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using MKproject.Schedule.UCData;
using MKproject.Management;
using CustomizedTools;
using MKproject.Schedule.Dayform;

namespace MKproject.Schedule
{
    public partial class UCDay : UserControl
    {




        //PROPERTY:
        ///-Date
        public DateTime SelectedDate { get; set; }

        ///-Reminder
        public DataTable tablereminder { get; set; }
        public List<UCreminder> ListUCreminder { get; set; }//we get it once we open the schedule then if something happened to a ucreminder add,update,delete dureing the runtime it will hapen to the List

        ///-Employees Listed From Day Now to Infinity 
        public List<int> ListEmployee_idChecked { get; set; }
        public List<ClassEmployee> ListEmployeeSchedule { get; set; }// it has the availibility of all the 7 days of each employee checked and unchecked , Don't forget he has to be always asc by rank, so if you modify his rank make him again asc you can see UCemployee

        ///-Employees Listed All Time
        public List<int> ListEmployee_idAllTime { get; set; }
        public List<string> EmployeeAvailabilityByOrder { get; set; }//it hase the availibility if this day of each employee exemple: 1-2-3/1-4-5,so there's 2 employees they are ranked in this order

        ///-Time
        private bool ishistory;
        public bool IsHistory

        {
            get { return ishistory; }
            set
            {
                ishistory = value;
            }
        }

        ///-Touch
        public TouchScroll TouchscrollPanelUCDay { get; set; }



        //VARIABLES:
        public ScheduleForm ParentFormSchedule;





        ///-Copies
        DateTime date; public int day, month, year, days; string dayname, monthname;
        int PreviousValue;
        int FutureValue;

        ///-Bool
        public bool isAssigned = false;
        bool Isloaducday = false;
        bool IsHistoryToAfterToday = false;
        bool IsFirstTimeTouchAssigned = true;
        public bool IsClickEmployeNameToExpandColumn;//eza kabasna aa hada men lemployeeiye la yekbar colummn

        ///-Position
        public int OneUCARowPosition, OneUCAColumnPosition;//hiye ousoulan lal flowlayoutpanel jouweta UCA

        ///-Color
        public Color StaticColorFLP = Color.White, DisableColorFLP = Color.FromArgb(238, 241, 254), StaticColorTBUca = Color.White, DisableColorTBUca = Color.FromArgb(250, 246, 254)
                  , MoveColor = Color.FromArgb(249, 246, 254)/*table taba3 lucap wel FLP*/
                  , ErrorColor = Color.FromArgb(252, 0, 5), MemberColor = Color.FromArgb(109, 122, 224)/*ucappointment*/;

        //Size
        int ucdayoldwidth;//kermel resizing ysir optemized aktar
        public int KeepSpace = 25;//for the ucappointments to keep the space for clicking on the FLP


        //INITIALISE:
        public UCDay(ScheduleForm form)
        {
            InitializeComponent();
            ParentFormSchedule = form;

            //Scroll
            TLPAppointment.AutoScroll = true;
            TLPAppointment.VerticalScrollBarTable = VScrollBar1;

            ucdayoldwidth = this.Size.Width;

            //Fill TBP
            for (int i = 0; i < 24; i++)
            {
                UCTime uctime = new UCTime();
                uctime.Dock = DockStyle.Fill;
                uctime.Time = TimeSpan.FromHours(i);

                TLPAppointment.Controls.Add(uctime, 0, i);
            }
            for (int i = 0; i < 24; i++)
            {
                TLPAppointment.Controls.Add(CreateFLP(), 1, i);
            }

            //ColumnStyle
            TLPAppointment.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 125);
            TLPEmployees.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 125);
        }


        private void FlowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            FlowLayoutPanel AddflowLayoutPanel = sender as FlowLayoutPanel;
            UCappointment UCApointmentDraged = e.Data.GetData(typeof(UCappointment)) as UCappointment;

            int NewPositionrow = TLPAppointment.GetRow(AddflowLayoutPanel);
            int NewPositioncol = TLPAppointment.GetColumn(AddflowLayoutPanel);

            int OldPositionrow = UCApointmentDraged.RowPosition;
            int OldPositioncol = UCApointmentDraged.ColumnPosition;

            if (AddflowLayoutPanel != null && UCApointmentDraged != null && (NewPositioncol != OldPositioncol || NewPositionrow != OldPositionrow))
            {
                if (CheckIfTimeAvailable(NewPositionrow, NewPositioncol))
                {


                    FlowLayoutPanel RemoveflowLayoutPanel = UCApointmentDraged.Parent as FlowLayoutPanel;
                    if (RemoveflowLayoutPanel != null)
                    {
                        RemoveflowLayoutPanel.Controls.Remove(UCApointmentDraged);
                    }
                    AddflowLayoutPanel.Controls.Add(UCApointmentDraged);
                    AddflowLayoutPanel.Invalidate();






                    int NumberOfVisibleControlsRemoveFLP = 0;
                    foreach (Control ctrl in RemoveflowLayoutPanel.Controls)
                    {
                        if (ctrl.Visible)
                        {
                            NumberOfVisibleControlsRemoveFLP++;
                        }
                    }
                    int NumberOfVisibleControlsAddFLP = 0;
                    foreach (Control ctrl in AddflowLayoutPanel.Controls)
                    {
                        if (ctrl.Visible)
                        {
                            NumberOfVisibleControlsAddFLP++;
                        }
                    }

                    ResizeINAddingUCAppInFLP(AddflowLayoutPanel, UCApointmentDraged, NumberOfVisibleControlsAddFLP, NewPositionrow, NewPositioncol);
                    UCApointmentDraged.ResizeINRemovingUCAppInFLP(RemoveflowLayoutPanel, NumberOfVisibleControlsRemoveFLP, OldPositioncol, OldPositionrow);


                    UCApointmentDraged.RowPosition = NewPositionrow;
                    UCApointmentDraged.ColumnPosition = NewPositioncol;


                    UCApointmentDraged.OldDesiredAppointmentUCApp = UCApointmentDraged.DesiredAppointmentUCApp.Copy();//we should copy before changing to the new time

                    //StartTime
                    TimeSpan OldStartTime = UCApointmentDraged.DesiredAppointmentUCApp.StartTime.TimeOfDay;
                    TimeSpan NewStartTime = new TimeSpan(NewPositionrow, OldStartTime.Minutes, 0);
                    UCApointmentDraged.DesiredAppointmentUCApp.StartTime = UCApointmentDraged.DesiredAppointmentUCApp.StartTime.Date + NewStartTime;


                    //EndTime
                    int DifferenceHours = NewStartTime.Hours - OldStartTime.Hours;//Ma sta3malna loriginale starttime li2anno bi koun sar new
                    int NewHour = UCApointmentDraged.DesiredAppointmentUCApp.EndTime.TimeOfDay.Hours + DifferenceHours;//Hasab kam hour bi adim aw bi rajiee lstarttime zet shi lal endtime


                    TimeSpan NewEndTime = new TimeSpan(NewHour, UCApointmentDraged.DesiredAppointmentUCApp.EndTime.TimeOfDay.Minutes, 0);
                    UCApointmentDraged.DesiredAppointmentUCApp.EndTime = UCApointmentDraged.DesiredAppointmentUCApp.EndTime.Date + NewEndTime;




                    //Employee
                    UCApointmentDraged.DesiredAppointmentUCApp.EmployeeId = ListEmployee_idChecked[NewPositioncol - 1];

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


            TouchscrollPanelUCDay.AssignEventPanelUCDay(TLPAppointment);
        }
        private void FlowLayoutPanel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void FlowLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(UCappointment)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        public bool CheckIfTimeAvailable(int UCNewPositionRow, int UCNewPositionCol)//rae
        {
            //ListEmployee_idAllTime and EmployeeAvailabilityByOrder both are ranked by order => both same index
            string HoursAvailability = EmployeeAvailabilityByOrder[UCNewPositionCol - 1];// employeePosition=PositionCol - 1

            string positionrowstring = UCNewPositionRow.ToString();


            string[] TheHoursAvailability = HoursAvailability.Split('-');


            bool IsPanelAvailable = false;
            for (int i = 0; i < TheHoursAvailability.Count(); i++)
            {
                if (TheHoursAvailability[i] == positionrowstring)
                {
                    IsPanelAvailable = true;
                    break;
                }
            }

            return IsPanelAvailable;
        }

        public (int, int) GetUCAppointmentPosition(ClassAppointment DesiredAppointment)
        {
            TimeSpan starttimeTimeSpan = DesiredAppointment.StartTime.TimeOfDay;//bas kermel le2e uctime
            int HourOfTheAppointment = starttimeTimeSpan.Hours;//row and hours same position
            int employeePosition = ListEmployee_idAllTime.IndexOf((int)DesiredAppointment.EmployeeId);

            return (employeePosition + 1, HourOfTheAppointment);//position flowlayoutpanel hiye position employee bel list-1 
        }


        private void UCDay_Load(object sender, EventArgs e)
        {
            //Initialise List
            ListEmployee_idAllTime = new List<int>();
            EmployeeAvailabilityByOrder = new List<string>();
            ListEmployee_idChecked = new List<int>();

            //Getting Employees & Their Availability
            ListEmployeeSchedule = ClassEmployee.GetEmployeeScheduleMemberASC();//they are in the order of a rank

            //To get the TBL structure with ListEmployee_idChecked structure
            if (ListEmployeeSchedule.Count != 0)
            {
                if (TLPEmployees.Controls.Count == 0)
                {
                    LabelEmployee labelEmployee = CreateLabelEmployee();
                    TLPEmployees.Controls.Add(labelEmployee, 1, 0);

                    //Getting the name and the family of the first employee who is checked but not adding it to the list because we want to add the first employee and the other employees at the same time
                    for (int i = 0; i < ListEmployeeSchedule.Count; i++)
                    {
                        if (ListEmployeeSchedule[i].IsChecked == true)
                        {
                            labelEmployee.Text = ListEmployeeSchedule[i].Fname + " " + ListEmployeeSchedule[i].Lname;
                            break;//he will get the first one and then get out
                        }
                    }
                }

                //Getting ListEmployee_idChecked
                for (int i = 0; i < ListEmployeeSchedule.Count; i++)
                {
                    if (ListEmployeeSchedule[i].IsChecked == true)
                    {
                        ListEmployee_idChecked.Add(ListEmployeeSchedule[i].EmployeeId);
                    }
                }

                int difference = ListEmployee_idChecked.Count - TLPAppointment.ColumnCount + 1;//BOOM aadad lemployees bel datatable hene rows w aadad lemployees bel tablelayout ma3 wahad la uctime houwe aada lcolumms

                if (difference > 0)
                {
                    for (int i = 0; i < difference; i++)
                    {
                        Isloaducday = true;//because it's the only situation that we will add to the listemployeeid in the AddColumnUCDay
                        AddColumnUCDay();// there's in it add to the ListEmployee_idChecked

                        ClassEmployee EmployeeSelected = ListEmployeeSchedule.FirstOrDefault(emp => emp.EmployeeId == ListEmployee_idChecked[i + 1]);
                        LabelEmployee labelEmployee = (LabelEmployee)TLPEmployees.GetControlFromPosition(i + 2, 0);
                        labelEmployee.Text = EmployeeSelected.Fname + " " + EmployeeSelected.Lname;
                    }
                }

                //else will not happen 
                else
                {
                    for (int i = 0; i < Math.Abs(difference); i++)
                    {
                        RemoveColumnUCDay();
                    }
                }

            }


            displayNow();

            //Scroll
            TLPAppointment.rowHeight = TLPAppointment.GetRowHeights()[0];
            TLPAppointment.AutoScrollPosition = new Point(0, TLPAppointment.rowHeight * 6);
            TLPAppointment.currentRow = 6;//for weel and touch scroll reason
            PreviousValue = (TLPAppointment.currentRow) * (TLPAppointment.rowHeight);
            FutureValue = (TLPAppointment.currentRow + 1) * (TLPAppointment.rowHeight);

            VScrollBar1.Minimum = TLPAppointment.VerticalScroll.Minimum;
            VScrollBar1.Maximum = TLPAppointment.VerticalScroll.Maximum;//hone aam hot ra2em hasab hayda table li2anno manno lmax value,baeed ma 3refet shu relation bein lvalue wel max barke tool tumb bi 2asir
            VScrollBar1.Value = TLPAppointment.VerticalScroll.Value;
            VScrollBar1.LargeChange = TLPAppointment.VerticalScroll.LargeChange;
            VScrollBar1.SmallChange = 165;


            //REMINDER
            //CREATING ALL THE ucreminder and putting it on a list
            ListUCreminder = new List<UCreminder>();
            tablereminder = ClassReminder.DisplayReminder();

            foreach (DataRow dr in tablereminder.Rows)
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

                ListUCreminder.Add(ucreminder);

                ParentFormSchedule.TouchscrollPanelreminder = new TouchScroll(ParentFormSchedule.panelreminder, ParentFormSchedule);
                //If it's Checked, then it will not appear in schedule.panelreminder
                if (ucreminder.DesiredReminder.IsChecked == false)
                {
                    if (isThedayofUCreminder(ucreminder, SelectedDate))
                    {
                        ucreminder.Dock = DockStyle.Top;
                        ParentFormSchedule.panelreminder.Controls.Add(ucreminder);
                    }
                }
            }
            ParentFormSchedule.TouchscrollPanelreminder = new TouchScroll(ParentFormSchedule.panelreminder, ParentFormSchedule);



            //HistoryEmployeeAvailability
            //Putting the  Availability And The ID of the Employees   who are in the ListEmployee_idChecked of today in the historyemployeeavailability
            if (SQLToProject.CheckIfHistoryExistsToday(DateTime.Now))//eza exists update 
            {
                ////Code For SQL 
                ////and we can add a condition to prevent the update  by knowing if someone has changed something in the manager program active or disactive
                //string rank_employees = "";
                //string availibility_employees = "";
                //for (int i = 0; i < ListEmployee_idChecked.Count; i++)//both of the string are in the order of the rank
                //{
                //    //getting rank_employees
                //    rank_employees += ListEmployee_idChecked[i].ToString();


                //    //getting availibility for this day of every employee
                //    int dayOfWeekInt = ((int)DateTime.Today.DayOfWeek + 6) % 7;
                //    var query = from row in ParentFormSchedule.ucday.ListEmployeeSchedule.AsEnumerable()
                //                where row.Field<int>("employee_id") == ListEmployee_idChecked[i]
                //                select row.Field<string>("availability");

                //    string availibility = query.First();
                //    string[] HoursOfThedays = availibility.Split('/');
                //    availibility_employees += HoursOfThedays[dayOfWeekInt];

                //    if (i != ListEmployee_idChecked.Count - 1)
                //    {
                //        rank_employees += "/";
                //    }
                //    else
                //    {

                //    }
                //}

                ////Update SQL
                //ProjectToSql.UpdateRankHistoryEmployeeavailibility(DateTime.Now, rank_employees, availibility_employees);
            }

            else//if it doesn't exist insert
            {
                //Code For SQL 
                for (int i = 0; i < ListEmployeeSchedule.Count; i++)//both of the string are in the order of the rank
                {
                    //getting availibility for this day of every employee
                    int dayOfWeekInt = ((int)DateTime.Today.DayOfWeek + 6) % 7;

                    string availability = "";
                    string[] HoursOfThedays = ListEmployeeSchedule[i].Availability.Split('/');
                    availability += HoursOfThedays[dayOfWeekInt];

                    ProjectToSql.InsertHistoryEmployeeavailibility(DateTime.Now, ListEmployeeSchedule[i].EmployeeId, (int)ListEmployeeSchedule[i].Rank, availability);
                }
            }
        }


        public FlowLayoutPanel CreateFLP()
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            //Properties
            flowLayoutPanel.AllowDrop = true;
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.BackColor = Color.White;
            flowLayoutPanel.Cursor = Cursors.Hand;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;

            //Events
            flowLayoutPanel.Click += flowLayoutPanel1_Click;
            flowLayoutPanel.MouseMove += flowLayoutPanel1_MouseMove;
            flowLayoutPanel.MouseLeave += flowLayoutPanel1_MouseLeave;

            flowLayoutPanel.DragEnter += FlowLayoutPanel_DragEnter;
            flowLayoutPanel.DragOver += FlowLayoutPanel_DragOver;
            flowLayoutPanel.DragDrop += FlowLayoutPanel_DragDrop;
            return flowLayoutPanel;
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
            labelEmployee.Cursor = Cursors.Hand;
            //Events
            labelEmployee.Click += TLPEmployees_Click;
            labelEmployee.MouseMove += LabelEmployee_MouseMove;
            labelEmployee.MouseLeave += LabelEmployee_MouseLeave;
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



        private void TLPEmployees_Click(object sender, EventArgs e)
        {
            IsClickEmployeNameToExpandColumn = true;


            if (TLPAppointment.ColumnCount != 2)//if ==2 , It's when the table has one columnemployee of course this column will be always in percentage
            {

                if (sender is LabelEmployee)
                {
                    Cursor = Cursors.WaitCursor;

                    LabelEmployee clickedLabel = (LabelEmployee)sender;
                    int ClickedRow = TLPEmployees.GetRow(clickedLabel);
                    int ClickedCol = TLPEmployees.GetColumn(clickedLabel);

                    //The click event will activate, if it's not the first cell where's there's no name of a employee in tableLayoutPanelEmployees
                    if (ClickedCol != 0)
                    {



                        //Absolute -> Percentage
                        if (TLPAppointment.ColumnStyles[ClickedCol].SizeType is SizeType.Absolute)
                        {
                            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPEmployees);
                            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPAppointment);

                            //kermel kel ucappointment ybaynoma bel column
                            for (int j = 1; j < TLPAppointment.ColumnCount; j++)
                            {
                                ResizeWidthAppointmentInTheColumnPecentage(j);
                            }


                            //Design
                            DesActiveAllLabels();
                        }


                        //Percentage -> Absolute
                        else
                        {
                            //eza toli3 fi column absolute gher li eemelnela  click laken mana nredo percentage
                            if (CheckOtherColumnsStylesType(TLPAppointment, ClickedCol))
                            {
                                RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPEmployees);
                                RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPAppointment);
                            }

                            bool HasChanged = EditTLPWithTheColumnAbsolute(ClickedCol);

                            if (HasChanged)
                            {
                                ActiveDesiredLabel(clickedLabel);
                            }
                            else
                            {
                                DesActiveAllLabels();
                            }
                        }

                    }


                    Cursor = Cursors.Default;
                }
            }

            IsClickEmployeNameToExpandColumn = false;

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






        //EVENT:
        ///-Click

        public void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            if (TouchScroll.MoveHoldClick == false && IsHistory == false)
            {
                FlowLayoutPanel clickedPanel = sender as FlowLayoutPanel;
                if (clickedPanel.BackColor == DisableColorTBUca)
                {

                }
                else
                {
                    int rowIndex = TLPAppointment.GetRow(clickedPanel);//get the row of the flowlayoutpanel
                    UCTime uctime = (UCTime)TLPAppointment.GetControlFromPosition(0, rowIndex);//get the uctime wich he has the same row to get the time1 and display it in the combobox  of the appointment

                    int columnIndex = TLPAppointment.GetColumn(clickedPanel);

                    ScheduleForm schedule = this.ParentFormSchedule;
                    Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
                    Program.GreyForm.Show();
                    Appointment appointment = new Appointment(this, uctime, ListEmployee_idAllTime[columnIndex - 1]);//-1 li2anno list mafiya uctim Boom
                    appointment.Show();
                    //TouchscrollPanelUCDay.RemoveEventPanelUCDay(TLPAppointment);
                    TouchscrollPanelUCDay.mouseDownPoint = Cursor.Position;
                }
            }
            else
            {

            }
        }//inside TableLayoutPanel Of UcDay
        private void buttonToday_Click(object sender, EventArgs e)
        {
            if (SelectedDate.Date != DateTime.Now.Date)
            {
                Cursor = Cursors.WaitCursor;
                displayNow();
                Cursor = Cursors.Default;
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                Cursor = Cursors.Default;
            }
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (SelectedDate.Day != DateTime.DaysInMonth(SelectedDate.Year, SelectedDate.Month))//add day
            {
                SelectedDate = SelectedDate.AddDays(+1);
                displayDay();
            }
            else if (SelectedDate.Month != 12)//day=1, add month
            {
                SelectedDate = SelectedDate.AddMonths(+1);
                month = SelectedDate.Month;
                year = SelectedDate.Year;
                SelectedDate = new DateTime(year, month, 1);
                displayDay();
            }
            else//day=1,month=1,add year
            {
                SelectedDate = SelectedDate.AddYears(+1);
                SelectedDate = new DateTime(year, 1, 1);
                displayDay();
            }

            //Scroll
            TLPAppointment.AutoScrollPosition = new Point(0, 0);
            TLPAppointment.AutoScrollPosition = new Point(0, TLPAppointment.rowHeight * 6);
            VScrollBar1.Value = TLPAppointment.VerticalScroll.Value;
            TLPAppointment.currentRow = 6;

            //Reminder
            DisplayUCReminder();

            Cursor = Cursors.Default;
        }
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (SelectedDate.Day != 1)//remove day
            {
                SelectedDate = SelectedDate.AddDays(-1);
                displayDay();
            }
            else if (SelectedDate.Month != 1)//day= last day, remove month
            {
                SelectedDate = SelectedDate.AddMonths(-1);
                month = SelectedDate.Month;
                year = SelectedDate.Year;
                SelectedDate = new DateTime(year, month, DateTime.DaysInMonth(SelectedDate.Year, SelectedDate.Month));
                displayDay();
            }
            else//day=last day,month=12,remove year
            {
                SelectedDate = SelectedDate.AddYears(-1);
                year = SelectedDate.Year;
                SelectedDate = new DateTime(year, 12, DateTime.DaysInMonth(SelectedDate.Year, SelectedDate.Month));
                displayDay();
            }
            TLPAppointment.AutoScrollPosition = new Point(0, 0);
            TLPAppointment.AutoScrollPosition = new Point(0, TLPAppointment.rowHeight * 6);
            VScrollBar1.Value = TLPAppointment.VerticalScroll.Value;
            TLPAppointment.currentRow = 6;

            DisplayUCReminder();

            Cursor = Cursors.Default;
        }
        private void labelDate_Click(object sender, EventArgs e)
        {
            Program.GreyForm = new GreyColor(Program.HomeForm, true, false, Color.Transparent);
            Program.GreyForm.Show();
            //UCmonth show
            Point locationRelativeToScreen = labelDate.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-6, 25);
            ParentFormSchedule.ucmonths.Location = locationRelativeToScreen;
            ParentFormSchedule.ucmonths.Show();


            //Showing the ucmonth from the calanderday in the date that we are
            ParentFormSchedule.ucmonths.DateUCMonth = SelectedDate;
            if (ParentFormSchedule.ucmonths.wichuccalander == 2)
            {
                ParentFormSchedule.ucmonths.wichuccalander = 1;
                ParentFormSchedule.ucmonths.tableLayoutPanelMonth.Controls.Remove(ParentFormSchedule.ucmonths.uccalandermonth);
                ParentFormSchedule.ucmonths.tableLayoutPanelMonth.Controls.Add(ParentFormSchedule.ucmonths.uccalanderday);
            }
            else if (ParentFormSchedule.ucmonths.wichuccalander == 3)
            {
                ParentFormSchedule.ucmonths.wichuccalander = 1;
                ParentFormSchedule.ucmonths.tableLayoutPanelMonth.Controls.Remove(ParentFormSchedule.ucmonths.uccalanderyear);
                ParentFormSchedule.ucmonths.tableLayoutPanelMonth.Controls.Add(ParentFormSchedule.ucmonths.uccalanderday);

            }

            ParentFormSchedule.ucmonths.EditLabelUCdays();

        }
        private void labelMember_Click(object sender, EventArgs e)
        {
            Program.GreyForm = new GreyColor(Program.HomeForm, true, false, Color.Transparent);
            Program.GreyForm.Show();
            Point locationRelativeToScreen = labelMember.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-200, 25);
            ParentFormSchedule.employee = new Employee(ParentFormSchedule);
            ParentFormSchedule.employee.Location = locationRelativeToScreen;
            ParentFormSchedule.employee.Show();
        }


        ///-Size Change
        private void UCDay_SizeChanged(object sender, EventArgs e)
        {
            VScrollBar1.LargeChange = TLPAppointment.VerticalScroll.LargeChange;


            int col = GettingAbsoluteColumn(TLPEmployees);

            //if col = 0 that means the absolute column doesn't exist because it's the column of the uctime
            if (col != 0)
            {
                RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPEmployees);
                RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPAppointment);
            }



            //kermel kel ucappointment ybaynoma bel column
            for (int j = 0; j < TLPAppointment.ColumnCount; j++)
            {
                int columnwidth = TLPAppointment.GetColumnWidths()[j];
                for (int i = 0; i < TLPAppointment.RowCount; i++)
                {
                    Control cellControl = TLPAppointment.GetControlFromPosition(j, i);//cell li fi yo akbar aadad ucappointment
                    if (cellControl is FlowLayoutPanel)
                    {
                        FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)cellControl;

                        int NumberOfVisibleControls = 0;
                        foreach (Control ctrl in flowLayoutPanel.Controls)
                        {
                            if (ctrl.Visible)
                            {
                                NumberOfVisibleControls++;
                            }
                        }


                        //Getting to know if we have to EditWidthAppointment
                        if (((UCappointment.OriginalWidth * NumberOfVisibleControls) + KeepSpace) > columnwidth)
                        {
                            EditWidthAppointment(flowLayoutPanel, columnwidth, NumberOfVisibleControls);
                        }
                        else
                        {
                            //eza lwidth aam ykbar laken maybe it will surpass the limit eza aam yezghar akid laa faeza aam yozghar ma daroure taeemil originale size
                            if (this.Size.Width > ucdayoldwidth)
                            {
                                //Getting them to their true width to know if they ll surpass the limit
                                foreach (UCappointment ucappointment in flowLayoutPanel.Controls.OfType<UCappointment>())
                                {
                                    ucappointment.Width = UCappointment.OriginalWidth;
                                }
                            }
                        }
                    }
                }
            }
            DesActiveAllLabels();
            ucdayoldwidth = this.Size.Width;
        }



        //FUNCTIONS:
        ///-Display
        public void displayNow()
        {
            if (DateTime.Now != SelectedDate)
            {
                SelectedDate = DateTime.Now;

                displayDay();
            }
            else
            {

            }
        }
        public void displayDay()
        {
            //copies
            date = SelectedDate;
            year = SelectedDate.Year;
            month = SelectedDate.Month;
            day = SelectedDate.Day;


            //Fill with ucappointments

            ///Now To Infinity or From History to now
            if (DateTime.Now.Date <= SelectedDate.Date)
            {
                //We Have ListEmployee_idChecked now we have to get the availabily of each employee by the same order
                List<string> availabilityrankorder = new List<string>();
                for (int i = 0; i < ListEmployee_idChecked.Count(); i++)
                {
                    int dayOfWeekInt = ((int)SelectedDate.DayOfWeek + 6) % 7;
                    ClassEmployee EmployeeSelected = ListEmployeeSchedule.FirstOrDefault(emp => emp.EmployeeId == ListEmployee_idChecked[i]);

                    string[] HoursOfThedays = EmployeeSelected.Availability.Split('/');//availibility for the day of DateUCDay EXEMPEL: it could be Monday
                    availabilityrankorder.Add(HoursOfThedays[dayOfWeekInt]);
                }

                //From History To Today
                if (IsHistory)//eza ken li abla men lhistory ya3ne barke ysir fi add column aw remove... 
                {
                    IsHistory = false;
                    IsHistoryToAfterToday = true;
                    EditTBPbyChangingDates(ListEmployee_idChecked, availabilityrankorder);
                    IsHistoryToAfterToday = false;
                }

                //Between Present And Future
                else//eza laa bas 3layna nghayir lavailibility wel appointments
                {
                    IsHistory = false;
                    UCappointmentsfillTodayToFuture();
                }

                //Updating the new List
                ListEmployee_idAllTime = ListEmployee_idChecked.ToList();
                EmployeeAvailabilityByOrder = availabilityrankorder;
            }

            //History
            else
            {
                IsHistory = true;

                //Getting the Rank and Availability of the employees who were checked and trained in this day

                //3mela Debug
                DataTable RankNAvailabilityEmployeesASC = SQLToProject.DisplayRankEmployeesNAvailabilityASC(SelectedDate);

                //Variables

                List<int> rankemployees_id = new List<int>();
                List<string> availabilityrankorder = new List<string>();



                //there's Active Employees In this Day
                if (RankNAvailabilityEmployeesASC.Rows.Count > 0)
                {
                    //The Employeeid are set in the row by rank order ascendant from 1 to n
                    foreach (DataRow datarow in RankNAvailabilityEmployeesASC.Rows)
                    {
                        //The Rank and Availability of the employees who were active in this day
                        rankemployees_id.Add(int.Parse(datarow["employee_id"].ToString()));
                        availabilityrankorder.Add((string)datarow["availability"]);
                    }

                    EditTBPbyChangingDates(rankemployees_id, availabilityrankorder);


                }

                //there's No Checked Employees In this Day
                else
                {
                    rankemployees_id.Add(0);
                    availabilityrankorder.Add("");
                    EditTBPbyChangingDates(rankemployees_id, availabilityrankorder);
                }


                //Updating The New List
                ListEmployee_idAllTime = rankemployees_id;
                EmployeeAvailabilityByOrder = availabilityrankorder;
            }

            //Changing Date
            dayname = SelectedDate.ToString("dddd");
            monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            labelDate.Text = dayname + "," + monthname + " " + day + "," + year;


        }//Display the title and the ucappointments

        ///-Add
        public UCappointment AddUCappointments(ClassAppointment DesiredAppointment, int positioncol, int positionrow)
        {
            //Design
            FlowLayoutPanel AddflowLayoutPanel = TLPAppointment.GetControlFromPosition(positioncol, positionrow) as FlowLayoutPanel;
            UCappointment AddUCAppointment = new UCappointment(DesiredAppointment, this, ListEmployee_idAllTime);
            AddflowLayoutPanel.Controls.Add(AddUCAppointment);//hone lezim hatta hasab lstarttime tabaee desired appointment

            int NumberOfVisibleControlsOfAddFLP = 0;
            foreach (Control ctrl in AddflowLayoutPanel.Controls)
            {
                if (ctrl.Visible)
                {
                    NumberOfVisibleControlsOfAddFLP++;
                }
            }

            ResizeINAddingUCAppInFLP(AddflowLayoutPanel, AddUCAppointment, NumberOfVisibleControlsOfAddFLP, positionrow, positioncol);

            TouchscrollPanelUCDay.ReAssignEventPanelUCDay(TLPAppointment);
            return AddUCAppointment;
        }

        public void ResizeINAddingUCAppInFLP(FlowLayoutPanel AddflowLayoutPanel, UCappointment AddUCAppointment, int NumberOfVisibleControlsOfAddFLP, int positionrow, int positioncol)
        {
            //Absolute
            if (TLPAppointment.ColumnStyles[positioncol].SizeType is SizeType.Absolute)
            {

                (int rowOfThemaxflowLayPan, int MaxNumberOfUcData) = FindingTheRowOfMaxFlowLayoutPanel(positioncol);

                //If Clicked FLP is MaxFlowLayoutPanel then it may affect the column absolute size
                if (rowOfThemaxflowLayPan == positionrow)
                {
                    EditColumnAbsoluteSize(positioncol, positionrow);
                }

                //se3eta bas momkin yet2asar lwidthucappointment
                else
                {
                    int columnwidth = TLPAppointment.GetColumnWidths()[positioncol];

                    //eza ee edit width
                    if ((UCappointment.OriginalWidth * NumberOfVisibleControlsOfAddFLP) + KeepSpace > columnwidth)
                    {
                        EditWidthAppointment(AddflowLayoutPanel, columnwidth, NumberOfVisibleControlsOfAddFLP);
                    }
                    else
                    {
                        //lba2we aal akid aandoun originale size
                        AddUCAppointment.Width = UCappointment.OriginalWidth;
                    }
                }
            }


            //Percentage
            else
            {
                int columnwidth = TLPAppointment.GetColumnWidths()[positioncol];

                //eza ee edit width
                if ((UCappointment.OriginalWidth * NumberOfVisibleControlsOfAddFLP) + KeepSpace > columnwidth)//bala ucaddclick
                {
                    EditWidthAppointment(AddflowLayoutPanel, columnwidth, NumberOfVisibleControlsOfAddFLP);
                }
                else
                {
                    //lba2we aal akid aandoun originale size
                    AddUCAppointment.Width = UCappointment.OriginalWidth;
                }
            }
        }
        (int, int) FindingTheRowOfMaxFlowLayoutPanel(int positioncol)
        {
            //FLP That has the biggest number of ucdata
            int MaxNumberOfUcData = 0;
            int rowOfThemaxflowLayPan = 0;
            for (int i = 0; i < TLPAppointment.RowCount; i++)
            {
                Control cellControl = TLPAppointment.GetControlFromPosition(positioncol, i);
                if (cellControl is FlowLayoutPanel)
                {
                    FlowLayoutPanel MaxFlowLayoutPanel = (FlowLayoutPanel)cellControl;
                    int NumberOfVisibleControls = 0;
                    foreach (Control ctrl in MaxFlowLayoutPanel.Controls)
                    {
                        if (ctrl.Visible)
                        {
                            NumberOfVisibleControls++;
                        }
                    }

                    if (MaxNumberOfUcData < NumberOfVisibleControls)
                    {
                        MaxNumberOfUcData = NumberOfVisibleControls;
                        rowOfThemaxflowLayPan = i;
                    }
                }
            }
            return (rowOfThemaxflowLayPan, MaxNumberOfUcData);
        }
        public void ChangePositionUCappointments(UCappointment ucappointmentclicked, int NewPositionCol, int NewPositionRow, bool IsUCAppPosChanged)
        {

            if (IsUCAppPosChanged)
            {
                int OldPositioncol = ucappointmentclicked.ColumnPosition;
                int OldPositionrow = ucappointmentclicked.RowPosition;


                //Changing the palce of the ucappointmentclicked
                //Remove
                FlowLayoutPanel RemoveflowLayoutPanel = TLPAppointment.GetControlFromPosition(ucappointmentclicked.ColumnPosition, ucappointmentclicked.RowPosition) as FlowLayoutPanel;
                RemoveflowLayoutPanel.Controls.Remove(ucappointmentclicked);//hone lezim hatta hasab lstarttime tabaee desired appointment

                int NumberOfVisibleControlsRemoveFLP = 0;
                foreach (Control ctrl in RemoveflowLayoutPanel.Controls)
                {
                    if (ctrl.Visible)
                    {
                        NumberOfVisibleControlsRemoveFLP++;
                    }
                }

                //Add
                FlowLayoutPanel AddflowLayoutPanel = TLPAppointment.GetControlFromPosition(NewPositionCol, NewPositionRow) as FlowLayoutPanel;
                AddflowLayoutPanel.Controls.Add(ucappointmentclicked);//hone lezim hatta hasab lstarttime tabaee desired appointment

                int NumberOfVisibleControlsAddFLP = 0;
                foreach (Control ctrl in AddflowLayoutPanel.Controls)
                {
                    if (ctrl.Visible)
                    {
                        NumberOfVisibleControlsAddFLP++;
                    }
                }

                ResizeINAddingUCAppInFLP(AddflowLayoutPanel, ucappointmentclicked, NumberOfVisibleControlsAddFLP, NewPositionRow, NewPositionCol);
                ucappointmentclicked.ResizeINRemovingUCAppInFLP(RemoveflowLayoutPanel, NumberOfVisibleControlsRemoveFLP, OldPositioncol, OldPositionrow);



                ucappointmentclicked.RowPosition = NewPositionRow;
                ucappointmentclicked.ColumnPosition = NewPositionCol;


                TouchscrollPanelUCDay.ReAssignEventPanelUCDay(TLPAppointment);
            }
        }

        ///-Fill With Appointments
        private void UCappointmentsfillTodayToFuture()
        {

            int dayOfWeekInt = ((int)SelectedDate.DayOfWeek + 6) % 7; //0 Monday to 6 Sunday

            //Clear all the flow layout panel
            for (int j = 1; j < TLPAppointment.ColumnCount; j++)//1 li2anno bala uctime BOOM
            {
                //Getting the Hours of Availibility of this Employee Of This Day
                ClassEmployee EmployeeSelected = ListEmployeeSchedule.FirstOrDefault(emp => emp.EmployeeId == ListEmployee_idChecked[j - 1]);

                string[] HoursOfThedays = EmployeeSelected.Availability.Split('/');// "/" it's the split between days
                string[] HoursOfTheday = HoursOfThedays[dayOfWeekInt].Split('-');// "-" it's the split between hours

                //Editing TBP
                AvailibilityColumnNClearUCA(j, HoursOfTheday);
            }

            //Getting From SQL Appointments & Meetings of this day and the Listed Employees

            UCappointmentsFill(ClassAppointment.DisplayAppointmentsWhereEmployees(this, ListEmployee_idChecked), ListEmployee_idChecked);

            //TouchScroll
            if (IsFirstTimeTouchAssigned)//hiye ousoulan ejit true moujarad ma to2taee bi hayde bet sir aan aatoul false
            {
                TouchscrollPanelUCDay = new TouchScroll(TLPAppointment, this, VScrollBar1);
                IsFirstTimeTouchAssigned = false;
            }
            else
            {
                TouchscrollPanelUCDay.ReAssignEventPanelUCDay(TLPAppointment);
            }

            //Fihal ken fi shi column absolute
            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPEmployees);
            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPAppointment);


            //kermel kel ucappointment ybaynoma bel column
            for (int j = 0; j < TLPAppointment.ColumnCount; j++)
            {
                ResizeWidthAppointmentInTheColumnPecentage(j);
            }

        }//hone lal load,next,previous w eza jina mnel month

        public void UCappointmentsfillColumn(int columnindex, int employee_id, string employeename)
        {

            int dayOfWeekInt = ((int)SelectedDate.DayOfWeek + 6) % 7; //0 Monday to 6 Sunday
                                                                      //Getting the Hours of Availibility of this Employee Of This Day
            ClassEmployee EmployeeSelected = ListEmployeeSchedule.FirstOrDefault(emp => emp.EmployeeId == ListEmployee_idChecked[columnindex - 1]);

            string[] HoursOfThedays = EmployeeSelected.Availability.Split('/');// "/" it's the split between days
            string[] HoursOfTheday = HoursOfThedays[dayOfWeekInt].Split('-');// "-" it's the split between hours

            //Editing TBP
            AvailibilityColumnNClearUCA(columnindex, HoursOfTheday);

            DataTable AppointmentsOfOneEmployeeDt = ClassAppointment.DisplayAppointmentsOneEmployee(this, employee_id);



            foreach (DataRow dr in AppointmentsOfOneEmployeeDt.Rows)
            {
                ClassAppointment DesiredAppointment = ClassAppointment.CreateObjectClassAppointment((int)dr["appointment_id"]);

                UCappointment ucappointments = new UCappointment(DesiredAppointment, this, ListEmployee_idAllTime);


                TimeSpan starttimeTimeSpan = DesiredAppointment.StartTime.TimeOfDay;//bas kermel le2e uctime
                int positionrow = starttimeTimeSpan.Hours;
                int positioncol = ListEmployee_idChecked.IndexOf(employee_id) + 1;//BOOM
                FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition(positioncol, positionrow) as FlowLayoutPanel;//position flowlayoutpanel hiye position employee bel list-1 


                //Check Appointmnent if hide or show
                if (ParentFormSchedule.checkBoxComplete.Checked == false && DesiredAppointment.IsCompleted)
                {
                    ucappointments.Hide();
                }
                if (ParentFormSchedule.checkBoxCancel.Checked == false && DesiredAppointment.IsCanceled)
                {
                    ucappointments.Hide();
                }
                if (ParentFormSchedule.checkBoxOnPending.Checked == false && DesiredAppointment.IsCanceled == false && DesiredAppointment.IsCompleted == false)
                {
                    ucappointments.Hide();
                }


                if (flowLayoutPanel.BackColor == DisableColorFLP)
                {
                    ucappointments.BackColor = ErrorColor;
                    ucappointments.TLPGlobal.BackColor = DisableColorTBUca;
                }

                flowLayoutPanel.Controls.Add(ucappointments);

                //EditWidthAppointment(flowLayoutPanel);
            }



            LabelEmployee labelEmployee = (LabelEmployee)TLPEmployees.GetControlFromPosition(columnindex, 0);
            labelEmployee.Text = employeename;
            TouchscrollPanelUCDay.ReAssignEventPanelUCDay(TLPAppointment);



            //Fihal ken fi shi column absolute
            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPEmployees);
            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPAppointment);


            //kermel kel ucappointment ybaynoma bel column
            for (int j = 0; j < TLPAppointment.ColumnCount; j++)
            {
                ResizeWidthAppointmentInTheColumnPecentage(j);
            }
        }//When we Change ListEmployeeSelected 
        private void UCappointmentsfillHistory(List<int> rankemployees_id)
        {

            //now we have to display the appointemnts
            UCappointmentsFill(ClassAppointment.DisplayAppointmentsWhereEmployees(this, rankemployees_id), rankemployees_id);


            TouchscrollPanelUCDay.ReAssignEventPanelUCDay(TLPAppointment);


            //Fihal ken fi shi column absolute
            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPEmployees);
            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPAppointment);


            //kermel kel ucappointment ybaynoma bel column
            for (int j = 0; j < TLPAppointment.ColumnCount; j++)
            {
                ResizeWidthAppointmentInTheColumnPecentage(j);
            }
        }//hone lal load,next,previous w eza jina mnel month

        ///-Function to Fill by getting a List
        private void UCappointmentsFill(DataTable thisdaydatatableAppointments, List<int> rankemployees_id)
        {
            foreach (DataRow dr in thisdaydatatableAppointments.Rows)
            {

                ClassAppointment DesiredAppointment = ClassAppointment.CreateObjectClassAppointment((int)dr["appointment_id"]);
                UCappointment ucappointments = new UCappointment(DesiredAppointment, this, rankemployees_id);


                TimeSpan starttimeTimeSpan = DesiredAppointment.StartTime.TimeOfDay;//bas kermel le2e uctime
                int positionrow = starttimeTimeSpan.Hours;
                int positioncol = rankemployees_id.IndexOf((int)DesiredAppointment.EmployeeId) + 1;
                FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition(positioncol, positionrow) as FlowLayoutPanel;//position flowlayoutpanel hiye position employee bel list-1 

                //Check Appointmnent if hide or show
                if (ParentFormSchedule.checkBoxComplete.Checked == false && DesiredAppointment.IsCompleted)
                {
                    ucappointments.Hide();
                }
                if (ParentFormSchedule.checkBoxCancel.Checked == false && DesiredAppointment.IsCanceled)
                {
                    ucappointments.Hide();
                }
                if (ParentFormSchedule.checkBoxOnPending.Checked == false && DesiredAppointment.IsCanceled == false && DesiredAppointment.IsCompleted == false)
                {
                    ucappointments.Hide();
                }


                if (flowLayoutPanel.BackColor == DisableColorFLP)
                {
                    ucappointments.BackColor = ErrorColor;
                    ucappointments.TLPGlobal.BackColor = DisableColorTBUca;
                }
                flowLayoutPanel.Controls.Add(ucappointments);
                //EditWidthAppointment(flowLayoutPanel);
            }


        }

        ///-Editing The Table Layout Panel
        public void EditTBPbyChangingDates(List<int> listrankemployee_id, List<string> listavailabilityrankorder)
        {
            int difference = listrankemployee_id.Count() /*it will give me the number of employees*/ - ListEmployee_idAllTime.Count();//ListEmployee_idAllTime hone hal property sarit l2adime badda tetjadad

            //there's more employees 
            if (difference > 0)
            {
                //hataynehoun monfoslin kermel lcount taba3 ListUCEmployeeChecked ma yotla3 fo2 lcount taba3 schedule.ucday.ListEmployee_id
                for (int i = 0; i < difference; i++)
                {
                    ParentFormSchedule.ucday.AddColumnUCDay();
                }
                SwitchEmployeeIfDifferent(listrankemployee_id, listavailabilityrankorder);
            }

            //There's less employees
            else if (difference < 0)
            {
                for (int i = 0; i < Math.Abs(difference); i++)
                {
                    ParentFormSchedule.ucday.RemoveColumnUCDay();
                }
                SwitchEmployeeIfDifferent(listrankemployee_id, listavailabilityrankorder);
            }

            //there's the same number of employees
            else
            {
                SwitchEmployeeIfDifferent(listrankemployee_id, listavailabilityrankorder);
            }
        }
        public void SwitchEmployeeIfDifferent(List<int> rankemployees_id, List<string> availabilityrankorder)
        {
            //there's Employees
            if (rankemployees_id[0] != 0)
            {
                //Checking Each Column T0 Swap it
                for (int i = 0; i < rankemployees_id.Count(); i++)//exemple column 0 men shabeha lal rank 1 eza aandoun zet lemployee_id laken ma bi sir chi eza laa byetghayar
                {

                    int columnindex = i + 1;//BOOM 

                    //The Column Has The Same Employee
                    if (rankemployees_id[i] == ListEmployee_idAllTime[i])//ma sar shi hone ha tes2al barke nmaha column rejiee nrad ma bi 2assir li2anno bel addcolumn hatit employee_id=0
                    {
                        //The Column Has The Same AvailibilityEmployee
                        if (availabilityrankorder[i] == EmployeeAvailabilityByOrder[i])
                        {
                            //Then No Change Just Clear FLP
                            for (int j = 0; j < TLPAppointment.RowCount; j++)
                            {
                                FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition(columnindex, j) as FlowLayoutPanel;
                                flowLayoutPanel.Controls.Clear();
                            }
                        }
                        //The Column Does Not Have The Same AvailibilityEmployee
                        else
                        {
                            //then we have to change the color of the FLP and clear them
                            string[] HoursOfTheday = availabilityrankorder[i].Split('-');
                            AvailibilityColumnNClearUCA(columnindex, HoursOfTheday);
                        }
                    }
                    //The Column Does Not Have The Same Employee
                    else
                    {
                        //hone mafik tehkheda list li2anno momkin ykoun men employee disactive
                        string employeename = SQLToProject.DisplayEmployeeName(rankemployees_id[i]);
                        LabelEmployee labelEmployee = (LabelEmployee)TLPEmployees.GetControlFromPosition(columnindex, 0);
                        labelEmployee.Text = employeename;
                        string[] HoursOfTheday = availabilityrankorder[i].Split('-');
                        AvailibilityColumnNClearUCA(columnindex, HoursOfTheday);//listemployeeid ma3 tanesou2 columns BOOM
                    }
                }
                UCappointmentsfillHistory(rankemployees_id);
            }

            //There's no employees
            else
            {
                string employeename = "No Appointments were assigned";
                LabelEmployee labelEmployee = (LabelEmployee)TLPEmployees.GetControlFromPosition(1, 0);//BOOM
                labelEmployee.Text = employeename;
                string[] HoursOfTheday = availabilityrankorder[0].Split('-');
                AvailibilityColumnNClearUCA(1, HoursOfTheday);//listemployeeid ma3 tanesou2 columns BOOM
            }
        }//hone bi aadil lcolumns w byaeemeloun clear byerjaee bi aabe lal kel


        ///-Fill and Remove (Column)
        public void RemoveColumnUCDay()
        {
            if (TLPAppointment.ColumnCount != 2)
            {
                //History or From History To Today
                if (IsHistory || IsHistoryToAfterToday)
                {
                    ListEmployee_idAllTime.RemoveAt(ListEmployee_idAllTime.Count - 1);
                    EmployeeAvailabilityByOrder.RemoveAt(EmployeeAvailabilityByOrder.Count - 1);
                }

                //From Today To Infinity
                else
                {
                    ListEmployee_idChecked.RemoveAt(ListEmployee_idChecked.Count - 1);
                }

                //Removing A Column to the 2 TableLayoutPanel 
                RemoveControlsFromLastColumnPanelApCo();
                RandomFunctionSchedule.RemoveColumnTableLayoutPanel(TLPEmployees, TLPEmployees.ColumnCount - 1);
                RandomFunctionSchedule.RemoveColumnTableLayoutPanel(TLPAppointment, TLPAppointment.ColumnCount - 1);
            }
        }
        public void AddColumnUCDay()
        {
            //Adding A Column to the 2 TableLayoutPanel 
            RandomFunctionSchedule.AddColumnTableLayoutPanel(TLPAppointment);
            FillLastColumnPanelAppointmentsWithFlowLayoutPanel();
            RandomFunctionSchedule.AddColumnTableLayoutPanel(TLPEmployees);
            FillLastColumnPanelEmployeesWithLabels();



            if (Isloaducday)
            {
                Isloaducday = false;
            }
            //History or From History To Today
            else if (IsHistory || IsHistoryToAfterToday)
            {
                ListEmployee_idAllTime.Add(0);
                EmployeeAvailabilityByOrder.Add("0");
            }

            //From Today To Infinity
            else
            {
                ListEmployee_idChecked.Add(0);//bte3teberoun 0 li2anno ha yet3adal baeeden bel switch
            }


        }

        ///-Fill and Remove (Labels & Flow Layout Panel)

        public void FillLastColumnPanelAppointmentsWithFlowLayoutPanel()
        {
            for (int j = 0; j < 24; j++)
            {
                TLPAppointment.Controls.Add(CreateFLP(), TLPAppointment.ColumnCount - 1, j);
            }
        }
        public void FillLastColumnPanelEmployeesWithLabels()
        {
            TLPEmployees.Controls.Add(CreateLabelEmployee(), TLPEmployees.ColumnCount - 1, 0);
        }
        public void RemoveControlsFromLastColumnPanelApCo()
        {
            for (int j = 0; j < TLPAppointment.RowCount; j++)
            {
                Control control = TLPAppointment.GetControlFromPosition(TLPAppointment.ColumnCount - 1, j);
                TLPAppointment.Controls.Remove(control);
                control.Dispose();
            }
            Control control1 = TLPEmployees.GetControlFromPosition(TLPEmployees.ColumnCount - 1, 0);
            TLPEmployees.Controls.Remove(control1);
            control1.Dispose();
        }

        ///-Remove & Fill The Column with UCA
        public void AvailibilityColumnNClearUCA(int columnindex, string[] HoursOfTheday)
        {
            //Editing the column of the employee
            int k = 0;
            for (int i = 0; i < TLPAppointment.RowCount; i++)
            {
                if (k != HoursOfTheday.Length)
                {
                    if (i.ToString() == HoursOfTheday[k])
                    {
                        FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition(columnindex, i) as FlowLayoutPanel;
                        flowLayoutPanel.Controls.Clear();
                        flowLayoutPanel.BackColor = StaticColorFLP;
                        k++;
                    }
                    else
                    {
                        FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition(columnindex, i) as FlowLayoutPanel;
                        flowLayoutPanel.Controls.Clear();
                        flowLayoutPanel.BackColor = DisableColorFLP;
                    }
                }
                else
                {
                    FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition(columnindex, i) as FlowLayoutPanel;
                    flowLayoutPanel.Controls.Clear();
                    flowLayoutPanel.BackColor = DisableColorFLP;
                }
            }
        }
        public void AvailibilityColumnChanged(int? columnindex, string[] HoursOfTheday)
        {
            int k = 0;//number of flow layout panel with staticcolor
            for (int i = 0; i < TLPAppointment.RowCount; i++)
            {
                //number of flow layout panel with staticcolor = number of availibility then the rest is disable
                if (k != HoursOfTheday.Length)
                {
                    if (i.ToString() == HoursOfTheday[k])
                    {
                        FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition((int)columnindex, i) as FlowLayoutPanel;
                        flowLayoutPanel.BackColor = StaticColorFLP;
                        if (flowLayoutPanel.Controls.Count > 0)
                        {
                            //W have to change the color of ucappointment that the error is gone
                            foreach (Control childControl in flowLayoutPanel.Controls)
                            {
                                if (childControl is UCappointment)
                                {
                                    UCappointment ucappointments = (UCappointment)childControl;
                                    ucappointments.BackColor = MemberColor;
                                    ucappointments.TLPGlobal.BackColor = StaticColorTBUca;
                                }
                            }
                        }

                        k++;
                    }
                    else
                    {
                        FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition((int)columnindex, i) as FlowLayoutPanel;
                        flowLayoutPanel.BackColor = DisableColorFLP;
                        if (flowLayoutPanel.Controls.Count > 0)
                        {
                            //To show that there's an error
                            foreach (Control childControl in flowLayoutPanel.Controls)
                            {
                                if (childControl is UCappointment)
                                {
                                    UCappointment ucappointments = (UCappointment)childControl;
                                    ucappointments.BackColor = ErrorColor;
                                    ucappointments.TLPGlobal.BackColor = DisableColorTBUca;
                                }
                            }
                        }
                    }
                }
                else
                {
                    FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition((int)columnindex, i) as FlowLayoutPanel;
                    flowLayoutPanel.BackColor = DisableColorFLP;
                    if (flowLayoutPanel.Controls.Count > 0)
                    {
                        foreach (Control childControl in flowLayoutPanel.Controls)
                        {
                            if (childControl is UCappointment)
                            {
                                UCappointment ucappointments = (UCappointment)childControl;
                                ucappointments.BackColor = ErrorColor;
                                ucappointments.TLPGlobal.BackColor = DisableColorTBUca;
                            }
                        }
                    }
                }
            }
        }



        ///-Reminder
        public bool isThedayofUCreminder(UCreminder ucreminder, DateTime date)
        {
            //For every day, no repeat
            if (ucreminder.DesiredReminder.Partsrepeat.Length == 1)
            {
                if (ucreminder.DesiredReminder.Partsrepeat[0] == Reminder.NoRepeat)
                {
                    if (date.Date == ucreminder.DesiredReminder.StartTime.Date)
                    {
                        return true;
                    }

                }

                else if (ucreminder.DesiredReminder.Partsrepeat[0] == Reminder.Everyday)
                {
                    if (date.Date >= ucreminder.DesiredReminder.StartTime.Date)
                    {
                        return true;
                    }
                }

            }


            //For every week
            else
            {
                if (date.Date >= ucreminder.DesiredReminder.StartTime.Date)//metel everyweek bas lfare2 gher starttime w fik enta thadid aya date yaeemil repeat
                {
                    for (int i = 1; i < ucreminder.DesiredReminder.Partsrepeat.Length; i++)
                    {
                        if (date.DayOfWeek.ToString() == ucreminder.DesiredReminder.Partsrepeat[i])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;

        }



        public void DisplayUCReminder()
        {
            ParentFormSchedule.panelreminder.Controls.Clear();
            foreach (UCreminder ucreminder in ListUCreminder)
            {
                if (ucreminder.DesiredReminder.IsChecked == false)//moujarad ma ykoun checked bel ucday ma bi bayin
                {
                    if (isThedayofUCreminder(ucreminder, SelectedDate))
                    {
                        ucreminder.Dock = DockStyle.Top;
                        ParentFormSchedule.panelreminder.Controls.Add(ucreminder);
                    }
                }
                else
                {

                }

            }
            ParentFormSchedule.TouchscrollPanelreminder.ReAssignEventPanelreminder(ParentFormSchedule.panelreminder);
        }


        ////Design TLP
        public void EditColumnAbsoluteSize(int column, int rowOfThemaxflowLayPan)
        {
            int expectedwidth = 0;


            //Getting the maximum width of the absolute column so that other columns always appear
            double ClikedColumnPercWidth = 0.9;
            int maxwidth = (int)((TLPAppointment.Width - TLPAppointment.GetColumnWidths()[0]) * ClikedColumnPercWidth);//so he will be 90 % of the columns without the first column


            //FLP li fiyo akbar aadad ucappointment
            Control cellControl = TLPAppointment.GetControlFromPosition(column, rowOfThemaxflowLayPan);
            if (cellControl is FlowLayoutPanel)
            {
                FlowLayoutPanel MaxFlowLayoutPanel = (FlowLayoutPanel)cellControl;

                int NumberOfVisibleControlsOfMaxFLP = 0;
                // Getting the  summation of the controls width inside the flowlayoutpanel(that has the biggest number) with margin and padding
                foreach (Control control in MaxFlowLayoutPanel.Controls)
                {
                    if (control.Visible)
                    {
                        NumberOfVisibleControlsOfMaxFLP++;
                    }
                }

                expectedwidth = ((UCappointment.OriginalWidth + MaxFlowLayoutPanel.Margin.Horizontal) * NumberOfVisibleControlsOfMaxFLP) + MaxFlowLayoutPanel.Padding.Horizontal + KeepSpace;



                //If Yes : the width of the absolute column has to take the maxwidth and here we will have to edit the ucappointments width 
                if (expectedwidth > maxwidth)
                {
                    //Column TLP Expand so maxwidth it's the same columnwidth
                    RandomFunctionSchedule.ExpandTableLayoutPanelColumn(TLPAppointment, column, maxwidth);
                    RandomFunctionSchedule.ExpandTableLayoutPanelColumn(TLPEmployees, column, maxwidth);


                    //If yes: Manna nemrou2 bi kel FLP jouwet lclicked column
                    if (IsClickEmployeNameToExpandColumn)
                    {
                        //Getting every row of the column  that we clicked on
                        for (int i = 0; i < TLPAppointment.RowCount; i++)
                        {
                            Control cellControl1 = TLPAppointment.GetControlFromPosition(column, i);

                            if (cellControl1 is FlowLayoutPanel)
                            {
                                FlowLayoutPanel innerFlowLayoutPanel1 = (FlowLayoutPanel)cellControl1;
                                int NumberOfVisibleControls = 0;
                                foreach (Control ctrl in innerFlowLayoutPanel1.Controls)
                                {
                                    if (ctrl.Visible)
                                    {
                                        NumberOfVisibleControls++;
                                    }
                                }

                                //check if the number of their ucappointment will reach the limit
                                if (((UCappointment.OriginalWidth * NumberOfVisibleControls) + KeepSpace) > maxwidth)//(innerFlowLayoutPanel1.Controls.Count-1)without the adducclick
                                {
                                    //if yes then edit the width of their ucappointment
                                    EditWidthAppointment(innerFlowLayoutPanel1, maxwidth, NumberOfVisibleControls);
                                }
                                else
                                {
                                    foreach (UCappointment ucappointment in innerFlowLayoutPanel1.Controls.OfType<UCappointment>())
                                    {
                                        ucappointment.Width = UCappointment.OriginalWidth;
                                    }
                                }

                            }

                        }
                    }

                    //Eza Kenit Delete Aw Add bas eelayna nemrou2 bel clickedFLP
                    else
                    {
                        //hone ma men hot the condition of MaxNumberUCAppointment li2anno hayda houwe MaxFLP li 2atta3 hayde lcondition  (expectedwidth > maxwidth) fa akid ha tsir EditWidthAppointment
                        EditWidthAppointment(MaxFlowLayoutPanel, maxwidth, NumberOfVisibleControlsOfMaxFLP);
                    }

                }


                //Here the width of the absolute column has the to take the expectedwidth and there's no edit to the width of ucappointments
                else
                {
                    //Column TLP Expand 
                    RandomFunctionSchedule.ExpandTableLayoutPanelColumn(TLPAppointment, column, expectedwidth);
                    RandomFunctionSchedule.ExpandTableLayoutPanelColumn(TLPEmployees, column, expectedwidth);
                    if (IsClickEmployeNameToExpandColumn)
                    {
                        GettingWidthAppointmentToOriginal(column);
                    }
                    else
                    {
                        foreach (UCappointment ucappointment in MaxFlowLayoutPanel.Controls.OfType<UCappointment>())
                        {
                            ucappointment.Width = UCappointment.OriginalWidth;
                        }
                    }


                    //kermel kel ucappointment ybaynoma bel column
                    for (int j = 1; j < TLPAppointment.ColumnCount; j++)
                    {
                        //Ma lezim yemrou2 bel absolute column
                        if (j != column)
                        {
                            //Lezim y3adil lwidth taba3 be2e lappointments li bi columns percentage
                            ResizeWidthAppointmentInTheColumnPecentage(j);
                        }
                    }
                }
            }
        }//so we need wich column that we will edit and the row where it contains the biggest number of ucdata
        public void EditWidthAppointment(FlowLayoutPanel flowLayoutPanel, int columnwidth, int NumberOfVisibleControls)
        {
            if (NumberOfVisibleControls != 0)
            {
                foreach (UCappointment ucappointment in flowLayoutPanel.Controls.OfType<UCappointment>())
                {
                    ucappointment.Width = (columnwidth - KeepSpace - (NumberOfVisibleControls * ucappointment.Margin.Horizontal)) / (NumberOfVisibleControls);//UCAddClick.Width it's static width that I declared it
                }
            }

        }//When the count of the ucappointments in the FLP is Above 3 

        public void ResizeWidthAppointmentInTheColumnPecentage(int j)
        {
            for (int i = 0; i < TLPAppointment.RowCount; i++)
            {
                Control cellControl1 = TLPAppointment.GetControlFromPosition(j, i);

                if (cellControl1 is FlowLayoutPanel)
                {
                    FlowLayoutPanel innerFlowLayoutPanel1 = (FlowLayoutPanel)cellControl1;
                    int NumberOfVisibleControls = 0;
                    foreach (Control ctrl in innerFlowLayoutPanel1.Controls)
                    {
                        if (ctrl.Visible)
                        {
                            NumberOfVisibleControls++;
                        }
                    }
                    int columnwidth = TLPAppointment.GetColumnWidths()[j];


                    //So watta yzawim: eza bi shi flowlayoutpanel , lmax width tabaee lappointment maee kel aadadoun ma byetkhata column width fa ma byaeemlo streched(lie2anno eza eemil streched byetkhata lwidth tabeeoulo)
                    if ((UCappointment.OriginalWidth * NumberOfVisibleControls) + KeepSpace > columnwidth)
                    {
                        EditWidthAppointment(innerFlowLayoutPanel1, columnwidth, NumberOfVisibleControls);
                    }
                    else
                    {
                        foreach (UCappointment ucappointment in innerFlowLayoutPanel1.Controls.OfType<UCappointment>())
                        {
                            ucappointment.Width = UCappointment.OriginalWidth;
                        }
                    }
                }
            }
        }
        public bool EditTLPWithTheColumnAbsolute(int AbsoluteColumn)
        {
            bool HasChangedToAbsolute;


            //FLP That has the biggest number of ucdata
            (int rowOfThemaxflowLayPan, int MaxNumberOfUcData) = FindingTheRowOfMaxFlowLayoutPanel(AbsoluteColumn);


            int columnwidth = TLPAppointment.GetColumnWidths()[AbsoluteColumn];

            // If the summation of the controls width inside the flowlayoutpanel(that has the biggest number) is approximately same as the column width then it's better to keep it in percentage
            if (MaxNumberOfUcData == 0 || ((UCappointment.OriginalWidth * MaxNumberOfUcData) + KeepSpace) < columnwidth)//approximately because without using the margins to compare
            {
                //It will Stay Percentage
                HasChangedToAbsolute = false;
            }
            //If not then we will Edit The Clicked Column making him to absolute
            else
            {
                EditColumnAbsoluteSize(AbsoluteColumn, rowOfThemaxflowLayPan);
                //kermel kel ucappointment ybaynoma bel column
                for (int j = 1; j < TLPAppointment.ColumnCount; j++)
                {
                    //Ma lezim yemrou2 bel absolute column
                    if (j != AbsoluteColumn)
                    {
                        //Lezim y3adil lwidth taba3 be2e lappointments li bi columns percentage
                        ResizeWidthAppointmentInTheColumnPecentage(j);
                    }
                }
                HasChangedToAbsolute = true;
            }
            return HasChangedToAbsolute;
        }


        public void GettingWidthAppointmentToOriginal(int column)
        {
            //Getting every row of the absolutecolumn and getting back  the original width to  the ucappointment where their width has been edited if there is
            for (int i = 0; i < TLPAppointment.RowCount; i++)
            {
                Control cellControl1 = TLPAppointment.GetControlFromPosition(column, i);

                if (cellControl1 is FlowLayoutPanel)
                {
                    FlowLayoutPanel innerFlowLayoutPanel1 = (FlowLayoutPanel)cellControl1;


                    //if yes then we give back the original width to  the ucappointment where their width has been edited 
                    foreach (UCappointment ucappointment in innerFlowLayoutPanel1.Controls.OfType<UCappointment>())
                    {
                        ucappointment.Width = UCappointment.OriginalWidth;//UCAddClick.Width it's static width that I declared it
                    }

                }
            }
        }//when we get the column absolute to perc we will give back the ucappointments the originale size
        private bool CheckOtherColumnsStylesType(TableLayoutPanel tableLayoutPanel, int col)
        {
            bool SomeoneIsAbsolute = false;
            for (int i = 1; i < tableLayoutPanel.ColumnCount; i++)
            {
                if (i != col)//ma lezim yshouf lcol li eemelnelo double click lezim bas yshouf lba2we
                {
                    if (TLPAppointment.ColumnStyles[i].SizeType is SizeType.Absolute)
                    {
                        SomeoneIsAbsolute = true;
                    }
                }
            }
            return SomeoneIsAbsolute;
        }
        private int GettingAbsoluteColumn(TableLayoutPanel tableLayoutPanel)
        {
            for (int i = 1; i < tableLayoutPanel.ColumnCount; i++)
            {
                if (TLPAppointment.ColumnStyles[i].SizeType is SizeType.Absolute)
                {
                    return i;//getting the column that's absolute
                }
            }
            return 0;//that means there's no column that's absolute
        }





        ///I can't do it because there's add and dispose fora specific type of user control so this function can't be generale
        public void EditTLPByAddingUCData(FlowLayoutPanel flowLayoutPanel)
        {

        }
        public void EditTLPByDisposingUCData(FlowLayoutPanel flowLayoutPanel)
        {

        }


        //DESIGN:
        public void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TouchScroll.MoveHoldClick == false)
            {
                Panel panel = sender as Panel;
                if (panel.BackColor == DisableColorFLP)
                {
                }
                else
                {
                    panel.BackColor = MoveColor;
                }

            }
            else
            {

            }

        }
        private void flowLayoutPanel1_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel.BackColor == DisableColorFLP)
            {
            }
            else
            {
                panel.BackColor = StaticColorFLP;
            }
        }

        //Scroll Bar Appeared
        public void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

            //if (VScrollBar1.Value < 4)
            //{
            //    tableLayoutPanel1.AutoScroll = false;
            //    tableLayoutPanel1.VerticalScroll.Value = 0;//the maximum value is autotaken when autoscroll is on, if not we need to initialise it awwal shi, 
            //    tableLayoutPanel1.AutoScroll = true;
            //}

            if (VScrollBar1.Value < PreviousValue || VScrollBar1.Value > FutureValue)
            {
                if (VScrollBar1.Value < PreviousValue)
                {
                    TLPAppointment.currentRow = Math.Max(0, TLPAppointment.currentRow - 1);
                }
                else
                {
                    TLPAppointment.currentRow = Math.Min(TLPAppointment.RowCount - TLPAppointment.GetVisibleRowsCount(), TLPAppointment.currentRow + 1);
                }


                PreviousValue = (TLPAppointment.currentRow) * (TLPAppointment.rowHeight);
                int newValue = TLPAppointment.currentRow * TLPAppointment.rowHeight;
                FutureValue = (TLPAppointment.currentRow + 1) * (TLPAppointment.rowHeight);


                TLPAppointment.AutoScroll = false;
                TLPAppointment.VerticalScroll.Value = Math.Min(newValue, TLPAppointment.VerticalScroll.Maximum);//the maximum value is autotaken when autoscroll is on, if not we need to initialise it awwal shi, 
                TLPAppointment.AutoScroll = true;
                Console.WriteLine("Value: " + TLPAppointment.VerticalScroll.Value + "\nValueCust: " + VScrollBar1.Value + "\nMax= " + TLPAppointment.VerticalScroll.Maximum + "\nMaxCust " + VScrollBar1.Maximum + "\n");
            }

            //for (int i = 0; i < 24; i++)
            //{
            //    if ((i * tableLayoutPanelAppointments.rowHeight) <= VScrollBar1.Value && VScrollBar1.Value < ((i + 1) * tableLayoutPanelAppointments.rowHeight))
            //    {
            //        int newValue = i * tableLayoutPanelAppointments.rowHeight;
            //        tableLayoutPanelAppointments.currentRow = i;
            //        tableLayoutPanelAppointments.AutoScroll = false;
            //        tableLayoutPanelAppointments.VerticalScroll.Value = Math.Min(newValue, tableLayoutPanelAppointments.rowHeight * 24);//the maximum value is autotaken when autoscroll is on, if not we need to initialise it awwal shi, 
            //        tableLayoutPanelAppointments.AutoScroll = true;
            //    }
            //}


        }
    }
}


////ma fina nejmaee hawde 2 bools li2anno kel wahde la event m3ayane wahde la color w wehde eza mnekbous aw laa
//public bool HoldClick = false;
//public bool MoveHoldClick = false;//for the event move of the controls


//tari2it TouchScroll l2adim
//public int WhatKindOfAdd = 0;*/// 0 for for the clear All ucappointment and then Fill All,1 for ADDUCAcolumn inside the FLP,2 for  AddFLPColumn , 3 for AddOneUCA



///hayda logique eza ken every 2 day jouwet display reminder function
//else if (ucreminder.Partsrepeat.Length == 3)
//{

//    else if (ucreminder.Partsrepeat[2] == Reminder.day2)
//    {
//        if (date >= ucreminder.Starttime.Date)
//        {
//            DateTime datetimeevery2days = ucreminder.Starttime.Date;
//            while (date >= datetimeevery2days)//starttime ha nsir nzido 2 day moujarad ma ysir akbar men date w ma sar equal la date  laken manno men levery 2 days
//            {
//                if (date == datetimeevery2days)
//                {
//                    ucreminder.Dock = DockStyle.Top;
//                    schedule.panelreminder.Controls.Add(ucreminder);
//                    break;
//                }
//                datetimeevery2days = datetimeevery2days.AddDays(2);
//            }
//        }
//    }

//}



/// <summary>
/// Hayde kermel tl2e  user control hasab lposition tab3oulto
/// </summary>
/// 



///private UCTime FinductimeByProperty(TableLayoutPanel panel, TimeSpan time)
//{

//    for (int row = 0; row < panel.RowCount; row++)
//    {
//        Control control = panel.GetControlFromPosition(0, row);
//        if (control is UCTime uctime)
//        {
//            if (uctime.Time == time)//same TimeSpan
//            {
//                return uctime;
//            }
//        }
//    }
//    return null;
//}



///public void AvailibilityColumnChangedHistory(string HoursofThedays, int columnindex) //Fi Hal  badde  ghayir availibility bala clear UCappointment w aadil bi 2alwenoun w bi woujoud UCAddClick
//{
//    string[] HoursOfTheday = HoursofThedays.Split('-');
//    int k = 0;
//    for (int i = 0; i < tableLayoutPanelAppointments.RowCount; i++)
//    {
//        if (k != HoursOfTheday.Length)
//        {
//            if (i.ToString() == HoursOfTheday[k])
//            {
//                FlowLayoutPanel flowLayoutPanel = tableLayoutPanelAppointments.GetControlFromPosition(columnindex, i) as FlowLayoutPanel;
//                flowLayoutPanel.BackColor = StaticColorFLP;
//                if (flowLayoutPanel.Controls.Count > 0)
//                {
//                    foreach (Control childControl in flowLayoutPanel.Controls)
//                    {
//                        UCappointments ucappointments = (UCappointments)childControl;
//                        ucappointments.BackColor = MemberColor;
//                        ucappointments.tableLayoutPanel2.BackColor = StaticColorTBUca;
//                    }
//                }

//                k++;
//            }
//            else
//            {
//                FlowLayoutPanel flowLayoutPanel = tableLayoutPanelAppointments.GetControlFromPosition(columnindex, i) as FlowLayoutPanel;
//                flowLayoutPanel.BackColor = DisableColorFLP;
//                if (flowLayoutPanel.Controls.Count > 0)
//                {
//                    foreach (Control childControl in flowLayoutPanel.Controls)
//                    {
//                        UCappointments ucappointments = (UCappointments)childControl;
//                        ucappointments.BackColor = ErrorColor;
//                        ucappointments.tableLayoutPanel2.BackColor = DisableColorTBUca;
//                    }
//                }
//            }
//        }
//        else
//        {
//            FlowLayoutPanel flowLayoutPanel = tableLayoutPanelAppointments.GetControlFromPosition(columnindex, i) as FlowLayoutPanel;
//            flowLayoutPanel.BackColor = DisableColorFLP;
//            if (flowLayoutPanel.Controls.Count > 0)
//            {
//                foreach (Control childControl in flowLayoutPanel.Controls)
//                {
//                    UCappointments ucappointments = (UCappointments)childControl;
//                    ucappointments.BackColor = ErrorColor;
//                    ucappointments.tableLayoutPanel2.BackColor = DisableColorTBUca;
//                }
//            }
//        }
//    }
//}



///Fi Hal lcolumnwidth ken akbar bi shwe men lucdata  ma men khali yrouh absolute
//If the summation of the controls width inside the flowlayoutpanel(that has the biggest number) is approximately same as the column width then it's better to keep it in percentage
//if (MaxNumberOfUcData == 0 || ((UCappointments.OriginalWidth * (MaxNumberOfUcData - 1)/*bala usaddclick*/) + UCAddClick.OriginalWidth) < clickedLabel.Width)//approximately because without using the margins to compare
//{

//}
//If not then we will Edit The Clicked Column making him to absolute
//else
//{
//}