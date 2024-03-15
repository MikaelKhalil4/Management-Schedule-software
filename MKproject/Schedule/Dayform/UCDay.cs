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

namespace MKproject.Schedule
{
    public partial class UCDay : UserControl
    {
        //SQL:
        SqlConnection con = new SqlConnection(Program.DataLocation);



        //PROPERTY:
        ///-Date
        public DateTime DateUCDay { get; set; }

        ///-Reminder
        public DataTable tablereminder { get; set; }
        public List<UCreminder> ListUCreminder { get; set; }//we get it once we open the schedule then if something happened to a ucreminder add,update,delete dureing the runtime it will hapen to the List

        ///-Employees Listed From Day Now to Infinity 
        public List<int> ListEmployee_idChecked { get; set; }
        public DataTable DataTableEmployeeavailability { get; set; }// it has the availibility of all the 7 days of each employee checked and unchecked , Don't forget he has to be always asc by rank, so if you modify his rank make him again asc you can see UCemployee

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
        private TouchScroll TouchscrollPanelUCDay { get; set; }



        //VARIABLES:
        public Schedule schedule;

 



        ///-Copies
        DateTime date; public int day, month, year, days; string dayname, monthname;
        int PreviousValue;
        int FutureValue;

        ///-Bool
        public bool isAssigned = false;
        bool Isloaducday = false;
        bool IsHistoryToAfterToday = false;
        bool IsFirstTimeTouchAssigned = true;
        bool IsClick;//eza kabasna aa hada men lemployeeiye la yekbar colummn

        ///-Position
        public int OneUCARowPosition, OneUCAColumnPosition;//hiye ousoulan lal flowlayoutpanel jouweta UCA

        ///-Color
        public Color StaticColorFLP = Color.White, DisableColorFLP = Color.FromArgb(250, 246, 254), StaticColorTBUca = Color.White, DisableColorTBUca = Color.FromArgb(250, 246, 254)
                  , MoveColor = Color.FromArgb(249, 246, 254)/*table taba3 lucap wel FLP*/
                  , ErrorColor = Color.FromArgb(252, 0, 5), MemberColor = Color.FromArgb(109, 122, 224)/*ucappointment*/;

        //Size
        int ucdayoldwidth;//kermel resizing ysir optemized aktar
        public int KeepSpace = 25;//for the ucappointments to keep the space for clicking on the FLP


        //INITIALISE:
        public UCDay(Schedule form)
        {
            InitializeComponent();
            schedule = form;

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
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                //Properties
                flowLayoutPanel.Dock = DockStyle.Fill;
                flowLayoutPanel.BackColor = Color.White;
                flowLayoutPanel.Cursor = Cursors.Hand;
                flowLayoutPanel.FlowDirection = FlowDirection.TopDown;

                //Events
                flowLayoutPanel.Click += flowLayoutPanel1_Click;
                flowLayoutPanel.MouseMove += flowLayoutPanel1_MouseMove;
                flowLayoutPanel.MouseLeave += flowLayoutPanel1_MouseLeave;


                TLPAppointment.Controls.Add(flowLayoutPanel, 1, i);
            }

            //ColumnStyle
            TLPAppointment.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 125);
            TLPEmployees.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 125);
        }
        private void UCDay_Load(object sender, EventArgs e)
        {
            //Initialise List
            ListEmployee_idAllTime = new List<int>();
            EmployeeAvailabilityByOrder = new List<string>();
            ListEmployee_idChecked = new List<int>();

            //Getting Employees & Their Availability
            DataTableEmployeeavailability = SQLToProject.DisplayEmployeeAvailabilityASC();//they are in the order of a rank

            //To get the TBL structure with ListEmployee_idChecked structure
            if (DataTableEmployeeavailability.Rows.Count != 0)
            {
                if (TLPEmployees.Controls.Count == 0)
                {
                    //Label Add
                    Label label = new Label();
                    label.Dock = DockStyle.Fill;
                    label.BackColor = Color.FromArgb(229, 226, 244);
                    label.Font = new Font("Segoe UI", 12);
                    label.AutoSize = true;
                    label.TextAlign = ContentAlignment.MiddleCenter;

                    TLPEmployees.Controls.Add(label, 1, 0);
                    label.Click += TLPEmployees_Click;

                    //Getting the name and the family of the first employee who is checked but not adding it to the list because we want to add the first employee and the other employees at the same time
                    for (int i = 0; i < DataTableEmployeeavailability.Rows.Count; i++)
                    {
                        if ((bool)DataTableEmployeeavailability.Rows[i][6] == true)
                        {
                            label.Text = (string)DataTableEmployeeavailability.Rows[i][2] + " " + (string)DataTableEmployeeavailability.Rows[i][3];
                            break;//he will get the first one and then get out
                        }
                    }
                }

                //Getting ListEmployee_idChecked
                for (int i = 0; i < DataTableEmployeeavailability.Rows.Count; i++)
                {
                    if ((bool)DataTableEmployeeavailability.Rows[i][6] == true)
                    {
                        ListEmployee_idChecked.Add((int)DataTableEmployeeavailability.Rows[i][1]);
                    }
                }

                int difference = ListEmployee_idChecked.Count - TLPAppointment.ColumnCount + 1;//BOOM aadad lemployees bel datatable hene rows w aadad lemployees bel tablelayout ma3 wahad la uctime houwe aada lcolumms

                if (difference > 0)
                {
                    for (int i = 0; i < difference; i++)
                    {
                        Isloaducday = true;//because it's the only situation that we will add to the listemployeeid in the AddColumnUCDay
                        AddColumnUCDay();// there's in it add to the ListEmployee_idChecked
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
                int? clientid = dr[1] as int?;//hayde fi hal kenit null
                string clientname;
                if (dr.IsNull(7))
                {
                    clientname = "";
                }
                else
                {
                    clientname = (string)dr["name"] + " " + (string)dr["family_name"];
                }

                ClassReminder DesiredReminder = new ClassReminder();
                DesiredReminder.DesiredClient = new ClassClient();
                DesiredReminder.Idreminder = (int)dr[0];
                if (clientid != null)
                {
                    DesiredReminder.DesiredClient.ClientId = (int)clientid;
                }
                DesiredReminder.Reminder = (string)dr[2];
                DesiredReminder.Repeat = (string)dr[3];
                DesiredReminder.StartTime = (DateTime)dr[4];
                DesiredReminder.LabelQuote = (string)dr[5];
                DesiredReminder.IsChecked = (bool)dr[6];
                UCreminder ucreminder = new UCreminder(DesiredReminder, this, schedule, false);//li2anno manna bi client reminder

                ListUCreminder.Add(ucreminder);

                schedule.TouchscrollPanelreminder = new TouchScroll(schedule.panelreminder, schedule);
                //If it's Checked, then it will not appear in schedule.panelreminder
                if (ucreminder.DesiredReminder.IsChecked == false)
                {
                    if (isThedayofUCreminder(ucreminder, DateUCDay))
                    {
                        ucreminder.Dock = DockStyle.Top;
                        schedule.panelreminder.Controls.Add(ucreminder);
                    }
                }
                else
                {

                    //    }
                    //}
                    schedule.TouchscrollPanelreminder = new TouchScroll(schedule.panelreminder, schedule);


                    //HistoryEmployeeAvailability
                    //Putting the  Availability And The ID of the Employees   who are in the ListEmployee_idChecked of today in the historyemployeeavailability
                    if (SQLToProject.DataExistsForToday(DateTime.Now))//eza exists update 
                    {
                        //Code For SQL 
                        //and we can add a condition to prevent the update  by knowing if someone has changed something in the manager program active or disactive
                        string rank_employees = "";
                        string availibility_employees = "";
                        for (int i = 0; i < ListEmployee_idChecked.Count; i++)//both of the string are in the order of the rank
                        {
                            //getting rank_employees
                            rank_employees += ListEmployee_idChecked[i].ToString();


                            //getting availibility for this day of every employee
                            int dayOfWeekInt = ((int)DateTime.Today.DayOfWeek + 6) % 7;
                            var query = from row in schedule.ucday.DataTableEmployeeavailability.AsEnumerable()
                                        where row.Field<int>("employee_id") == ListEmployee_idChecked[i]
                                        select row.Field<string>("availability");

                            string availibility = query.First();
                            string[] HoursOfThedays = availibility.Split('/');
                            availibility_employees += HoursOfThedays[dayOfWeekInt];

                            if (i != ListEmployee_idChecked.Count - 1)
                            {
                                rank_employees += "/";
                            }
                            else
                            {

                            }
                        }

                        //Update SQL
                        ProjectToSql.UpdateHistoryEmployeeavailibility(DateTime.Now, rank_employees, availibility_employees);
                    }
                    else//if it doesn't exist insert
                    {
                        //Code For SQL 
                        string rank_employees = "";
                        string availibility_employees = "";
                        for (int i = 0; i < ListEmployee_idChecked.Count; i++)//both of the string are in the order of the rank
                        {
                            //getting rank_employees
                            rank_employees += ListEmployee_idChecked[i].ToString();


                            //getting availibility for this day of every employee
                            int dayOfWeekInt = ((int)DateTime.Today.DayOfWeek + 6) % 7;
                            var query = from row in schedule.ucday.DataTableEmployeeavailability.AsEnumerable()
                                        where row.Field<int>("employee_id") == ListEmployee_idChecked[i]
                                        select row.Field<string>("availability");

                            string availibility = query.First();
                            string[] HoursOfThedays = availibility.Split('/');
                            availibility_employees += HoursOfThedays[dayOfWeekInt];

                            if (i != ListEmployee_idChecked.Count - 1)
                            {
                                rank_employees += "/";
                                availibility_employees += "/";
                            }
                            else
                            {

                            }
                        }

                        //Update SQL
                        ProjectToSql.InsertHistoryEmployeeavailibility(DateTime.Now, rank_employees, availibility_employees);
                    }
                }
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
                    Appointment appointment = new Appointment(this, uctime, ListEmployee_idAllTime[columnIndex - 1]);//-1 li2anno list mafiya uctim Boom
                    appointment.ShowDialog();
                }
            }
            else
            {

            }
        }//inside TableLayoutPanel Of UcDay
        private void TLPEmployees_Click(object sender, EventArgs e)
        {
            IsClick = true;
            //It's when the table has one columnemployee of course this column will be always in percentage
            if (TLPAppointment.ColumnCount == 2)
            {

            }

            else
            {

                if (sender is Label)
                {
                    Cursor = Cursors.WaitCursor;

                    Label clickedLabel = (Label)sender;
                    int row = TLPEmployees.GetRow(clickedLabel);
                    int col = TLPEmployees.GetColumn(clickedLabel);

                    //The click event will activate, if it's not the first cell where's there's no name of a employee in tableLayoutPanelEmployees
                    if (col != 0)
                    {

                        //Absolute -> Percentage
                        if (TLPAppointment.ColumnStyles[col].SizeType is SizeType.Absolute)
                        {
                            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPEmployees);
                            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPAppointment);

                            //kermel kel ucappointment ybaynoma bel column
                            for (int i = 0; i < TLPAppointment.RowCount; i++)
                            {

                                Control cellControl1 = TLPAppointment.GetControlFromPosition(col, i);

                                if (cellControl1 is FlowLayoutPanel)
                                {
                                    FlowLayoutPanel innerFlowLayoutPanel1 = (FlowLayoutPanel)cellControl1;
                                    int columnwidth = TLPAppointment.GetColumnWidths()[col];


                                    //So watta yzawim: eza bi shi flowlayoutpanel , lmax width tabaee lappointment maee kel aadadoun ma byetkhata column width fa ma byaeemlo streched(lie2anno eza eemil streched byetkhata lwidth tabeeoulo)
                                    if (UCappointment.OriginalWidth * (innerFlowLayoutPanel1.Controls.Count) < clickedLabel.Width)
                                    {

                                    }
                                    else
                                    {
                                        EditWidthAppointment(innerFlowLayoutPanel1, columnwidth);

                                    }
                                }
                            }
                        }


                        //Percentage -> Absolute
                        else
                        {
                            //badna nrajiee ucappointment lal originale size li2anno sar column absolute size
                            GettingWidthAppointmentToOriginal(col);


                            //FLP That has the biggest number of ucdata
                            int MaxNumberOfUcData = 0;
                            int rowOfThemaxflowLayPan = 0;
                            for (int i = 0; i < TLPAppointment.RowCount; i++)
                            {
                                Control cellControl = TLPAppointment.GetControlFromPosition(col, i);
                                if (cellControl is FlowLayoutPanel)
                                {
                                    FlowLayoutPanel MaxFlowLayoutPanel = (FlowLayoutPanel)cellControl;
                                    if (MaxNumberOfUcData < MaxFlowLayoutPanel.Controls.Count)
                                    {
                                        MaxNumberOfUcData = MaxFlowLayoutPanel.Controls.Count;
                                        rowOfThemaxflowLayPan = i;
                                    }
                                }
                            }


                            //eza toli3 fi column absolute gher li eemelnela  click laken mana nredo percentage
                            if (CheckOtherColumnsStylesType(TLPAppointment, col))
                            {
                                RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPEmployees);
                                RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPAppointment);
                            }


                            // If the summation of the controls width inside the flowlayoutpanel(that has the biggest number) is approximately same as the column width then it's better to keep it in percentage
                            if (MaxNumberOfUcData == 0 || ((UCappointment.OriginalWidth * MaxNumberOfUcData) + KeepSpace) < clickedLabel.Width)//approximately because without using the margins to compare
                            {

                            }
                            //If not then we will Edit The Clicked Column making him to absolute
                            else
                            {
                                EditColumnAbsoluteSize(col, rowOfThemaxflowLayPan);
                            }


                        }

                    }


                    else
                    {

                    }

                    Cursor = Cursors.Default;
                }
            }

            IsClick = false;

        }//changing size column of the Table Layout Panel
        private void buttonToday_Click(object sender, EventArgs e)
        {
            if (DateUCDay.Date != DateTime.Now.Date)
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
            if (DateUCDay.Day != DateTime.DaysInMonth(DateUCDay.Year, DateUCDay.Month))//add day
            {
                DateUCDay = DateUCDay.AddDays(+1);
                displayDay();
            }
            else if (DateUCDay.Month != 12)//day=1, add month
            {
                DateUCDay = DateUCDay.AddMonths(+1);
                month = DateUCDay.Month;
                year = DateUCDay.Year;
                DateUCDay = new DateTime(year, month, 1);
                displayDay();
            }
            else//day=1,month=1,add year
            {
                DateUCDay = DateUCDay.AddYears(+1);
                DateUCDay = new DateTime(year, 1, 1);
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
            if (DateUCDay.Day != 1)//remove day
            {
                DateUCDay = DateUCDay.AddDays(-1);
                displayDay();
            }
            else if (DateUCDay.Month != 1)//day= last day, remove month
            {
                DateUCDay = DateUCDay.AddMonths(-1);
                month = DateUCDay.Month;
                year = DateUCDay.Year;
                DateUCDay = new DateTime(year, month, DateTime.DaysInMonth(DateUCDay.Year, DateUCDay.Month));
                displayDay();
            }
            else//day=last day,month=12,remove year
            {
                DateUCDay = DateUCDay.AddYears(-1);
                year = DateUCDay.Year;
                DateUCDay = new DateTime(year, 12, DateTime.DaysInMonth(DateUCDay.Year, DateUCDay.Month));
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
            //UCmonth show
            Point locationRelativeToScreen = labelDate.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(0, 20);
            schedule.ucmonths.Location = locationRelativeToScreen;
            schedule.ucmonths.Show();


            //Showing the ucmonth from the calanderday in the date that we are
            schedule.ucmonths.DateUCMonth = DateUCDay;
            if (schedule.ucmonths.wichuccalander == 2)
            {
                schedule.ucmonths.wichuccalander = 1;
                schedule.ucmonths.tableLayoutPanelMonth.Controls.Remove(schedule.ucmonths.uccalandermonth);
                schedule.ucmonths.tableLayoutPanelMonth.Controls.Add(schedule.ucmonths.uccalanderday);
            }
            else if (schedule.ucmonths.wichuccalander == 3)
            {
                schedule.ucmonths.wichuccalander = 1;
                schedule.ucmonths.tableLayoutPanelMonth.Controls.Remove(schedule.ucmonths.uccalanderyear);
                schedule.ucmonths.tableLayoutPanelMonth.Controls.Add(schedule.ucmonths.uccalanderday);

            }

            schedule.ucmonths.buttonTypeDateChange.Text = "Month";
            schedule.ucmonths.EditLabelUCdays();

        }
        private void labelMember_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Point locationRelativeToScreen = labelMember.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-150, 20);
            schedule.employee = new Employee(schedule);
            schedule.employee.Location = locationRelativeToScreen;
            schedule.employee.Show();
            Cursor = Cursors.Default;
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



                        //eza lwidth aam ykbar laken maybe it will surpass the limit eza aam yezghar akid laa faeza aam yozghar ma daroure taeemil originale size
                        if (this.Size.Width > ucdayoldwidth)
                        {
                            //Getting them to their true width to know if they ll surpass the limit
                            foreach (UCappointment ucappointment in flowLayoutPanel.Controls.OfType<UCappointment>())
                            {
                                ucappointment.Width = UCappointment.OriginalWidth;
                            }

                        }



                        //Getting to know if we have to EditWidthAppointment
                        if (((UCappointment.OriginalWidth * flowLayoutPanel.Controls.Count) + KeepSpace) > columnwidth)
                        {
                            EditWidthAppointment(flowLayoutPanel, columnwidth);
                        }
                    }
                }
            }

            ucdayoldwidth = this.Size.Width;
        }



        //FUNCTIONS:
        ///-Display
        public void displayNow()
        {
            if (DateTime.Now != DateUCDay)
            {
                DateUCDay = DateTime.Now;

                displayDay();
            }
            else
            {

            }
        }
        public void displayDay()
        {
            //copies
            date = DateUCDay;
            year = DateUCDay.Year;
            month = DateUCDay.Month;
            day = DateUCDay.Day;


            //Fill with ucappointments

            ///Now To Infinity or From History to now
            if (DateTime.Now.Date <= DateUCDay.Date)
            {
                //We Have ListEmployee_idChecked now we have to get the availabily of each employee by the same order
                List<string> availabilityrankorder = new List<string>();
                for (int i = 0; i < ListEmployee_idChecked.Count(); i++)
                {
                    int dayOfWeekInt = ((int)DateUCDay.DayOfWeek + 6) % 7;
                    var query = from row in DataTableEmployeeavailability.AsEnumerable()
                                where row.Field<int>("employee_id") == ListEmployee_idChecked[i]
                                select row.Field<string>("availability");
                    string availibility = query.First();//availibility for all the days
                    string[] HoursOfThedays = availibility.Split('/');//availibility for the day of DateUCDay EXEMPEL: it could be Monday
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
                DataTable RankNAvailabilityEmployees = SQLToProject.DisplayRankEmployeesNAvailability(DateUCDay);

                //Variables
                string[] rankEmployees;
                string[] availabilityEmployees;

                List<int> rankemployees_id = new List<int>();
                List<string> availabilityrankorder = new List<string>();


                List<int> rankemployees_idwhotrainedAp = new List<int>();
                List<int> rankemployees_idwhotrainedMeet = new List<int>();

                List<int> rankemployees_idwhotrained = new List<int>();
                List<string> availabilityrankorderwhotrained = new List<string>();

                //there's Checked Employees In this Day
                if (RankNAvailabilityEmployees.Rows.Count > 0)
                {

                    //The Rank and Availability of the employees who were checked in this day
                    DataRow row = RankNAvailabilityEmployees.Rows[0];

                    rankEmployees = row["rank_employees"].ToString().Split('/');
                    availabilityEmployees = row["availability_employees"].ToString().Split('/');
                    for (int i = 0; i < rankEmployees.Length; i++)
                    {
                        rankemployees_id.Add(int.Parse(rankEmployees[i]));
                        availabilityrankorder.Add(availabilityEmployees[i]);
                    }

                    //Getting From SQL Employees who trained and haved Meeting
                    List<int> employees_idwhotrained = ClassAppointment.DisplayEmployeesIdWhoTrained(this, rankemployees_id);


                    //Getting the finale List Of the Rank and Availability of the employees who were checked and trained in this day
                    for (int i = 0; i < rankemployees_id.Count; i++)
                    {
                        bool IsEmployeeTrain = false;
                        for (int j = 0; j < employees_idwhotrained.Count; j++)
                        {
                            if (rankemployees_id[i] == employees_idwhotrained[j])
                            {
                                rankemployees_idwhotrained.Add(rankemployees_id[i]);
                                IsEmployeeTrain = true;
                            }

                        }
                        if (IsEmployeeTrain == true)//eza maken lemployee mawjoid bi hal day taba3 lhistory laken mana nshilo men lavailibility
                        {
                            availabilityrankorderwhotrained.Add(availabilityrankorder[i]);
                        }
                    }

                    //There's Employees who trained in this day
                    if (rankemployees_idwhotrained.Count > 0)
                    {
                        EditTBPbyChangingDates(rankemployees_idwhotrained, availabilityrankorderwhotrained);
                    }
                    //There's no one who trained in this day
                    else
                    {
                        rankemployees_idwhotrained.Clear();
                        availabilityrankorderwhotrained.Clear();
                        rankemployees_idwhotrained.Add(0);
                        availabilityrankorderwhotrained.Add("");
                        EditTBPbyChangingDates(rankemployees_idwhotrained, availabilityrankorderwhotrained);
                    }
                }

                //there's No Checked Employees In this Day
                else
                {
                    rankemployees_idwhotrained.Add(0);
                    availabilityrankorderwhotrained.Add("");
                    EditTBPbyChangingDates(rankemployees_idwhotrained, availabilityrankorderwhotrained);
                }


                //Updating The New List
                ListEmployee_idAllTime = rankemployees_idwhotrained;
                EmployeeAvailabilityByOrder = availabilityrankorderwhotrained;
            }

            //Changing Date
            dayname = DateUCDay.ToString("dddd");
            monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            labelDate.Text = dayname + "," + monthname + " " + day + "," + year;


        }//Display the title and the ucappointments

        ///-Add
        public void AddUCappointments(ClassAppointment DesiredAppointment, int positioncol, int positionrow)
        {
            //Design

            FlowLayoutPanel AddflowLayoutPanel = TLPAppointment.GetControlFromPosition(positioncol, positionrow) as FlowLayoutPanel;
            UCappointment ucappointments = new UCappointment(DesiredAppointment, this);
            ucappointments.Width = UCappointment.OriginalWidth;
            AddflowLayoutPanel.Controls.Add(ucappointments);//hone lezim hatta hasab lstarttime tabaee desired appointment



            //Absolute
            if (TLPAppointment.ColumnStyles[positioncol].SizeType is SizeType.Absolute)
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
                        if (MaxNumberOfUcData < MaxFlowLayoutPanel.Controls.Count)
                        {
                            MaxNumberOfUcData = MaxFlowLayoutPanel.Controls.Count;
                            rowOfThemaxflowLayPan = i;
                        }
                    }
                }

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
                    if (((UCappointment.OriginalWidth * AddflowLayoutPanel.Controls.Count) + KeepSpace) > columnwidth)
                    {
                        EditWidthAppointment(AddflowLayoutPanel, columnwidth);
                    }
                }
            }


            //Percentage
            else
            {
                for (int i = 0; i < TLPAppointment.RowCount; i++)
                {

                    Control cellControl1 = TLPAppointment.GetControlFromPosition(positioncol, i);

                    if (cellControl1 is FlowLayoutPanel)
                    {
                        FlowLayoutPanel innerFlowLayoutPanel1 = (FlowLayoutPanel)cellControl1;


                        int columnwidth = TLPAppointment.GetColumnWidths()[positioncol];

                        //eza ee edit width
                        if (((UCappointment.OriginalWidth * AddflowLayoutPanel.Controls.Count) + KeepSpace) > columnwidth)//bala ucaddclick
                        {
                            EditWidthAppointment(AddflowLayoutPanel, columnwidth);
                        }
                    }
                }
            }

            TouchscrollPanelUCDay.ReAssignEventPanelUCDay(TLPAppointment);
        }
        public void ChangePositionUCappointments(UCappointment ucappointmentclicked, ClassAppointment DesiredAppointment, int newpositioncol, int newpositionrow, bool IsUCAppPosChanged)
        {
            if (IsUCAppPosChanged == false)
            {

            }
            else
            {
                //SetTheUCappointment
                ucappointmentclicked.Width = UCappointment.OriginalWidth;

                //Changing the palce of the ucappointmentclicked
                //Remove
                FlowLayoutPanel RemoveflowLayoutPanel = TLPAppointment.GetControlFromPosition(ucappointmentclicked.ColumnPosition, ucappointmentclicked.RowPosition) as FlowLayoutPanel;
                RemoveflowLayoutPanel.Controls.Remove(ucappointmentclicked);//hone lezim hatta hasab lstarttime tabaee desired appointment

                //Add
                FlowLayoutPanel AddflowLayoutPanel = TLPAppointment.GetControlFromPosition(newpositioncol, newpositionrow) as FlowLayoutPanel;
                AddflowLayoutPanel.Controls.Add(ucappointmentclicked);//hone lezim hatta hasab lstarttime tabaee desired appointment


                //FOR ADD

                //Absolute
                if (TLPAppointment.ColumnStyles[newpositioncol].SizeType is SizeType.Absolute)
                {
                    //FOR THE ADD
                    //FLP That has the biggest number of ucdata
                    int MaxNumberOfUcData = 0;
                    int rowOfThemaxflowLayPan = 0;
                    for (int i = 0; i < TLPAppointment.RowCount; i++)
                    {
                        Control cellControl = TLPAppointment.GetControlFromPosition(newpositioncol, i);
                        if (cellControl is FlowLayoutPanel)
                        {
                            FlowLayoutPanel MaxFlowLayoutPanel = (FlowLayoutPanel)cellControl;
                            if (MaxNumberOfUcData < MaxFlowLayoutPanel.Controls.Count)
                            {
                                MaxNumberOfUcData = MaxFlowLayoutPanel.Controls.Count;
                                rowOfThemaxflowLayPan = i;
                            }
                        }
                    }

                    //If Clicked FLP is MaxFlowLayoutPanel then it may affect the column absolute size
                    if (rowOfThemaxflowLayPan == newpositionrow)
                    {
                        EditColumnAbsoluteSize(newpositioncol, newpositionrow);
                    }

                    //se3eta bas momkin yet2asar lwidthucappointment
                    else
                    {
                        int columnwidth = TLPAppointment.GetColumnWidths()[newpositioncol];

                        //eza ee edit width
                        if (((UCappointment.OriginalWidth * AddflowLayoutPanel.Controls.Count) + KeepSpace) > columnwidth)
                        {
                            EditWidthAppointment(AddflowLayoutPanel, columnwidth);
                        }
                    }



                    //FOR THE REMOVE

                    //The FlowLayoutpanel where we dispose the ucdata does it have akbar aadad ucdata before we dispose this ucdata if yes it will affect the TBL
                    bool havethemaxucdata = true;

                    for (int i = 0; i < TLPAppointment.RowCount; i++)
                    {
                        if (ucappointmentclicked.RowPosition != i)
                        {
                            Control cellControl = TLPAppointment.GetControlFromPosition(ucappointmentclicked.ColumnPosition, i);
                            if (cellControl is FlowLayoutPanel)
                            {
                                FlowLayoutPanel innerFlowLayoutPanel = (FlowLayoutPanel)cellControl;
                                if ((RemoveflowLayoutPanel.Controls.Count + 1)/*+1 li2anno manna na3rif abel ma yaeemil dispose*/ > innerFlowLayoutPanel.Controls.Count)
                                {

                                }

                                //eza hata = la hada bet batil zabta
                                else
                                {
                                    //if it's equal or false then the supposition is false so we have to break
                                    havethemaxucdata = false;
                                    break;
                                }
                            }
                        }

                        //Eza ata3 bi halo akid ma y2arin halo
                        else
                        {

                        }

                    }

                    //hayde lconidtion => kel flowlayoutpanel ma aandoun wala ucappointment because eza lmax 0 yaeene kelo 0
                    if (RemoveflowLayoutPanel.Controls.Count == 0 && havethemaxucdata)
                    {
                        RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPAppointment);
                        RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPEmployees);
                    }

                    //eza ken lflow layout panel li mahayna fiyo ucappointment aando akbar aada hone it may edit the size of the absolute column
                    else if (havethemaxucdata)
                    {
                        EditColumnAbsoluteSize(ucappointmentclicked.ColumnPosition, ucappointmentclicked.RowPosition);
                    }

                    //se3eta bas momkin yet2asar lwidthucappointment
                    else
                    {
                        int columnwidth = TLPAppointment.GetColumnWidths()[ucappointmentclicked.ColumnPosition];
                        //eza ee edit width
                        if (((UCappointment.OriginalWidth * RemoveflowLayoutPanel.Controls.Count) + KeepSpace) > columnwidth)
                        {
                            EditWidthAppointment(RemoveflowLayoutPanel, columnwidth);
                        }
                    }
                }


                //Percentage
                else
                {
                    for (int i = 0; i < TLPAppointment.RowCount; i++)
                    {

                        Control cellControl1 = TLPAppointment.GetControlFromPosition(newpositioncol, i);

                        if (cellControl1 is FlowLayoutPanel)
                        {
                            FlowLayoutPanel innerFlowLayoutPanel1 = (FlowLayoutPanel)cellControl1;


                            int columnwidth = TLPAppointment.GetColumnWidths()[newpositioncol];

                            //eza ee edit width
                            if (((UCappointment.OriginalWidth * AddflowLayoutPanel.Controls.Count) + KeepSpace) > columnwidth)//bala ucaddclick
                            {
                                EditWidthAppointment(AddflowLayoutPanel, columnwidth);
                            }
                        }
                    }
                }


                ucappointmentclicked.RowPosition = newpositionrow;
                ucappointmentclicked.ColumnPosition = newpositioncol;
                TouchscrollPanelUCDay.ReAssignEventPanelUCDay(TLPAppointment);
            }
        }

        ///-Fill With Appointments
        private void UCappointmentsfillTodayToFuture()
        {

            int dayOfWeekInt = ((int)DateUCDay.DayOfWeek + 6) % 7; //0 Monday to 6 Sunday

            //Clear all the flow layout panel
            for (int j = 1; j < TLPAppointment.ColumnCount; j++)//1 li2anno bala uctime BOOM
            {
                //Getting the Hours of Availibility of this Employee Of This Day
                var query = from row in schedule.ucday.DataTableEmployeeavailability.AsEnumerable()
                            where row.Field<int>("employee_id") == ListEmployee_idChecked[j - 1]
                            select row.Field<string>("availability");

                string availibility = query.First();
                string[] HoursOfThedays = availibility.Split('/');// "/" it's the split between days
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
                int columnwidth = TLPAppointment.GetColumnWidths()[j];

                for (int i = 0; i < TLPAppointment.RowCount; i++)
                {
                    Control cellControl1 = TLPAppointment.GetControlFromPosition(j, i);

                    if (cellControl1 is FlowLayoutPanel)
                    {
                        FlowLayoutPanel innerFlowLayoutPanel1 = (FlowLayoutPanel)cellControl1;

                        //eza ee edit width
                        if (((UCappointment.OriginalWidth * innerFlowLayoutPanel1.Controls.Count) + KeepSpace) > columnwidth)
                        {
                            EditWidthAppointment(innerFlowLayoutPanel1, columnwidth);
                        }
                    }
                }
            }

        }//hone lal load,next,previous w eza jina mnel month

        public void UCappointmentsfillColumn(int columnindex, int employee_id, string employeename)
        {

            int dayOfWeekInt = ((int)DateUCDay.DayOfWeek + 6) % 7; //0 Monday to 6 Sunday
                                                                   //Getting the Hours of Availibility of this Employee Of This Day
            var query = from row in schedule.ucday.DataTableEmployeeavailability.AsEnumerable()
                        where row.Field<int>("employee_id") == ListEmployee_idChecked[columnindex - 1]
                        select row.Field<string>("availability");

            string availibility = query.First();
            string[] HoursOfThedays = availibility.Split('/');// "/" it's the split between days
            string[] HoursOfTheday = HoursOfThedays[dayOfWeekInt].Split('-');// "-" it's the split between hours

            //Editing TBP
            AvailibilityColumnNClearUCA(columnindex, HoursOfTheday);

           DataTable  AppointmentsOfOneEmployeeDt = ClassAppointment.DisplayAppointmentsOneEmployee(this, employee_id);

          

            foreach (DataRow dr in AppointmentsOfOneEmployeeDt.Rows)
            {
                ClassAppointment DesiredAppointment = ClassAppointment.CreateObjectClassAppointment((int)dr["appointment_id"]);
         
                UCappointment ucappointments = new UCappointment(DesiredAppointment, this);


                TimeSpan starttimeTimeSpan = DesiredAppointment.StartTime.TimeOfDay;//bas kermel le2e uctime
                int positionrow = starttimeTimeSpan.Hours;
                int positioncol = ListEmployee_idChecked.IndexOf(employee_id) + 1;//BOOM
                FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition(positioncol, positionrow) as FlowLayoutPanel;//position flowlayoutpanel hiye position employee bel list-1 



                if (flowLayoutPanel.BackColor == DisableColorFLP)
                {
                    ucappointments.BackColor = ErrorColor;
                    ucappointments.tableLayoutPanel2.BackColor = DisableColorTBUca;
                }

                flowLayoutPanel.Controls.Add(ucappointments);

                //EditWidthAppointment(flowLayoutPanel);
            }



            Label label = (Label)TLPEmployees.GetControlFromPosition(columnindex, 0);
            label.Text = employeename;
            TouchscrollPanelUCDay.ReAssignEventPanelUCDay(TLPAppointment);



            ///kermel kel ucappointment ybaynoma bel column
            for (int j = 0; j < TLPAppointment.ColumnCount; j++)
            {
                int columnwidth = TLPAppointment.GetColumnWidths()[j];

                for (int i = 0; i < TLPAppointment.RowCount; i++)
                {
                    Control cellControl1 = TLPAppointment.GetControlFromPosition(j, i);

                    if (cellControl1 is FlowLayoutPanel)
                    {
                        FlowLayoutPanel innerFlowLayoutPanel1 = (FlowLayoutPanel)cellControl1;

                        //eza ee edit width
                        if (((UCappointment.OriginalWidth * innerFlowLayoutPanel1.Controls.Count) + KeepSpace) > columnwidth)
                        {
                            EditWidthAppointment(innerFlowLayoutPanel1, columnwidth);
                        }
                    }
                }
            }
        }//When we Change ListEmployeeSelected 
        private void UCappointmentsfillHistory(List<int> rankemployees_id)
        {

            //now we have to display the appointemnts
            UCappointmentsFill(ClassAppointment.DisplayAppointmentsWhereEmployees(this, rankemployees_id),rankemployees_id);


            TouchscrollPanelUCDay.ReAssignEventPanelUCDay(TLPAppointment);


            //Fihal ken fi shi column absolute
            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPEmployees);
            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(TLPAppointment);

            //kermel kel ucappointment ybaynoma bel column
            for (int j = 0; j < TLPAppointment.ColumnCount; j++)
            {
                int columnwidth = TLPAppointment.GetColumnWidths()[j];

                for (int i = 0; i < TLPAppointment.RowCount; i++)
                {
                    Control cellControl1 = TLPAppointment.GetControlFromPosition(j, i);

                    if (cellControl1 is FlowLayoutPanel)
                    {
                        FlowLayoutPanel innerFlowLayoutPanel1 = (FlowLayoutPanel)cellControl1;
                        //eza ee edit width
                        if (((UCappointment.OriginalWidth * innerFlowLayoutPanel1.Controls.Count) + KeepSpace) > columnwidth)
                        {
                            EditWidthAppointment(innerFlowLayoutPanel1, columnwidth);
                        }
                    }
                }
            }
        }//hone lal load,next,previous w eza jina mnel month

        ///-Function to Fill by getting a List
        private void UCappointmentsFill(DataTable thisdaydatatableAppointments, List<int> rankemployees_id)
        {
            foreach (DataRow dr in thisdaydatatableAppointments.Rows)
            {
                ClassAppointment DesiredAppointment = ClassAppointment.CreateObjectClassAppointment((int)dr["appointment_id"]);
            }
            foreach (DataRow dr in thisdaydatatableAppointments.Rows)
            {

                ClassAppointment DesiredAppointment = ClassAppointment.CreateObjectClassAppointment((int)dr["appointment_id"]);             
                UCappointment ucappointments = new UCappointment(DesiredAppointment, this);


                TimeSpan starttimeTimeSpan = DesiredAppointment.StartTime.TimeOfDay;//bas kermel le2e uctime
                int positionrow = starttimeTimeSpan.Hours;
                int positioncol = rankemployees_id.IndexOf((int)DesiredAppointment.EmployeeId) + 1;
                FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition(positioncol, positionrow) as FlowLayoutPanel;//position flowlayoutpanel hiye position employee bel list-1 



                if (flowLayoutPanel.BackColor == DisableColorFLP)
                {
                    ucappointments.BackColor = ErrorColor;
                    ucappointments.tableLayoutPanel2.BackColor = DisableColorTBUca;
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
                    schedule.ucday.AddColumnUCDay();
                }
                SwitchEmployeeIfDifferent(listrankemployee_id, listavailabilityrankorder);
            }

            //There's less employees
            else if (difference < 0)
            {
                for (int i = 0; i < Math.Abs(difference); i++)
                {
                    schedule.ucday.RemoveColumnUCDay();
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

                        string employeename = SQLToProject.DisplayEmployeeName(rankemployees_id[i]);
                        Label label = (Label)TLPEmployees.GetControlFromPosition(columnindex, 0);
                        label.Text = employeename;
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
                Label label = (Label)TLPEmployees.GetControlFromPosition(1, 0);//BOOM
                label.Text = employeename;
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


            //hone awal display bi koun mafiyo list manna nfawetlo list aa kel add column
            if (Isloaducday)
            {
                //ListEmployee_idChecked.Add((int)DataTableEmployeeavailability.Rows[tableLayoutPanelEmployees.ColumnCount - 2][1]);//BOOM
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
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                //Properties
                flowLayoutPanel.Dock = DockStyle.Fill;
                flowLayoutPanel.BackColor = Color.White;
                flowLayoutPanel.Cursor = Cursors.Hand;
                flowLayoutPanel.FlowDirection = FlowDirection.TopDown;

                //Events
                flowLayoutPanel.Click += flowLayoutPanel1_Click;
                flowLayoutPanel.MouseMove += flowLayoutPanel1_MouseMove;
                flowLayoutPanel.MouseLeave += flowLayoutPanel1_MouseLeave;


                TLPAppointment.Controls.Add(flowLayoutPanel, TLPAppointment.ColumnCount - 1, j);
            }
        }
        public void FillLastColumnPanelEmployeesWithLabels()
        {
            //Design 
            Label label = new Label();
            label.Dock = DockStyle.Fill;
            label.BackColor = Color.FromArgb(229, 226, 244);
            label.Font = new Font("Segoe UI", 12);
            label.AutoSize = true;
            label.TextAlign = ContentAlignment.MiddleCenter;

            //eza bet lahiz awal sater count-2 li2annoo lal DataTable w mafiya uctime w tene sater lal table -1 fiya uctime
            if (Isloaducday)
            {
                label.Text = (string)DataTableEmployeeavailability.Rows[TLPEmployees.ColumnCount - 2][2] + " " + (string)DataTableEmployeeavailability.Rows[TLPEmployees.ColumnCount - 2][3];//BOOM aam yenzwd column laken lcount lahalo aam bi zid, -2 li2anno wehde lal uctime w wehde lal count
            }
            else//fi hal kenit mnel employeeswitch mahada hammo li2anno text ha terjaee tekhed men fillappointmentcolumn
            {

            }
            TLPEmployees.Controls.Add(label, TLPEmployees.ColumnCount - 1, 0);

            //Events
            label.Click += TLPEmployees_Click;
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
        public void AvailibilityColumnChanged(int columnindex, string[] HoursOfTheday)
        {
            int k = 0;//number of flow layout panel with staticcolor
            for (int i = 0; i < TLPAppointment.RowCount; i++)
            {
                //number of flow layout panel with staticcolor = number of availibility then the rest is disable
                if (k != HoursOfTheday.Length)
                {
                    if (i.ToString() == HoursOfTheday[k])
                    {
                        FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition(columnindex, i) as FlowLayoutPanel;
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
                                    ucappointments.tableLayoutPanel2.BackColor = StaticColorTBUca;
                                }
                            }
                        }

                        k++;
                    }
                    else
                    {
                        FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition(columnindex, i) as FlowLayoutPanel;
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
                                    ucappointments.tableLayoutPanel2.BackColor = DisableColorTBUca;
                                }
                            }
                        }
                    }
                }
                else
                {
                    FlowLayoutPanel flowLayoutPanel = TLPAppointment.GetControlFromPosition(columnindex, i) as FlowLayoutPanel;
                    flowLayoutPanel.BackColor = DisableColorFLP;
                    if (flowLayoutPanel.Controls.Count > 0)
                    {
                        foreach (Control childControl in flowLayoutPanel.Controls)
                        {
                            if (childControl is UCappointment)
                            {
                                UCappointment ucappointments = (UCappointment)childControl;
                                ucappointments.BackColor = ErrorColor;
                                ucappointments.tableLayoutPanel2.BackColor = DisableColorTBUca;
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
            schedule.panelreminder.Controls.Clear();
            foreach (UCreminder ucreminder in ListUCreminder)
            {
                if (ucreminder.DesiredReminder.IsChecked == false)//moujarad ma ykoun checked bel ucday ma bi bayin
                {
                    if (isThedayofUCreminder(ucreminder, DateUCDay))
                    {
                        ucreminder.Dock = DockStyle.Top;
                        schedule.panelreminder.Controls.Add(ucreminder);
                    }
                }
                else
                {

                }

            }
            schedule.TouchscrollPanelreminder.ReAssignEventPanelreminder(schedule.panelreminder);
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

                // Getting the  summation of the controls width inside the flowlayoutpanel(that has the biggest number) with margin and padding
                foreach (Control control in MaxFlowLayoutPanel.Controls)
                {
                    expectedwidth += control.Width + MaxFlowLayoutPanel.Margin.Horizontal;
                }

                expectedwidth = expectedwidth + MaxFlowLayoutPanel.Padding.Horizontal + KeepSpace;



                //If Yes : the width of the absolute column has to take the maxwidth and here we will have to edit the ucappointments width 
                if (expectedwidth > maxwidth)
                {
                    //Column TLP Expand so maxwidth it's the same columnwidth
                    RandomFunctionSchedule.ExpandTableLayoutPanelColumn(TLPAppointment, column, maxwidth);
                    RandomFunctionSchedule.ExpandTableLayoutPanelColumn(TLPEmployees, column, maxwidth);




                    //If yes: Manna nemrou2 bi kel FLP jouwet lclicked column
                    if (IsClick)
                    {
                        //Here The column has a certain width, We are getting the number of ucappointements with original width that can appear in this width
                        double MaxNumberUCAppointment = maxwidth / UCappointment.OriginalWidth;

                        //Getting every row of the column  that we clicked on
                        for (int i = 0; i < TLPAppointment.RowCount; i++)
                        {
                            Control cellControl1 = TLPAppointment.GetControlFromPosition(column, i);

                            if (cellControl1 is FlowLayoutPanel)
                            {
                                FlowLayoutPanel innerFlowLayoutPanel1 = (FlowLayoutPanel)cellControl1;


                                //check if the number of their ucappointment will reach the limit
                                if (((UCappointment.OriginalWidth * innerFlowLayoutPanel1.Controls.Count) + KeepSpace) > maxwidth)//(innerFlowLayoutPanel1.Controls.Count-1)without the adducclick
                                {
                                    //if yes then edit the width of their ucappointment
                                    EditWidthAppointment(innerFlowLayoutPanel1, maxwidth);
                                }
                            }

                        }
                    }

                    //Eza Kenit Delete Aw Add bas eelayna nemrou2 bel clickedFLP
                    else
                    {
                        //hone ma men hot the condition of MaxNumberUCAppointment li2anno hayda houwe MaxFLP li 2atta3 hayde lcondition  (expectedwidth > maxwidth) fa akid ha tsir EditWidthAppointment
                        EditWidthAppointment(MaxFlowLayoutPanel, maxwidth);
                    }

                }


                //Here the width of the absolute column has the to take the expectedwidth and there's no edit to the width of ucappointments
                else
                {
                    //Column TLP Expand 
                    RandomFunctionSchedule.ExpandTableLayoutPanelColumn(TLPAppointment, column, expectedwidth);
                    RandomFunctionSchedule.ExpandTableLayoutPanelColumn(TLPEmployees, column, expectedwidth);
                }
            }
        }//so we need wich column that we will edit and the row where it contains the biggest number of ucdata
        public void EditWidthAppointment(FlowLayoutPanel flowLayoutPanel, int columnwidth)
        {
            int NumberOfControls = flowLayoutPanel.Controls.Count;
            foreach (UCappointment ucappointment in flowLayoutPanel.Controls.OfType<UCappointment>())
            {
                ucappointment.Width = (columnwidth - KeepSpace - (NumberOfControls * ucappointment.Margin.Horizontal)) / (NumberOfControls);//UCAddClick.Width it's static width that I declared it
            }
        }//When the count of the ucappointments in the FLP is Above 3 



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