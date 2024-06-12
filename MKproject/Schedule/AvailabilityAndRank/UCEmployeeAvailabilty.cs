
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using System.Windows.Xps.Serialization;
using GlobalFunctions;
using MKproject.Management;
using MKproject.Schedule;
using MKproject.Schedule.Availabilityform;


namespace MKproject.Schedule
{

    public partial class UCEmployeeAvailabilty : UserControl
    {

        public TableLayoutPanel TLPScheduleAv;
        public TableLayoutPanel TLPDays;
        public EmployeeAvailabiltyForm ParentEmployeeAvailabilityForm;

        ClassEmployee DesiredEmploye;
        List<List<int>> DailyRowsAvailability;//it will contain 7 list of the rows, for the availabilty of this specifivc employee for the 7 days


        List<string> ListdaysOfWeek = new List<string>()
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };

        Color DefaultColor = Color.FromArgb(249, 246, 254);
        Color SelectionColor = Color.FromArgb(100, 109, 122, 224);
        Color HoverColor = Color.FromArgb(40, 109, 122, 224);

        Brush AddingBrush; // Change the color as needed
        Brush DeletionBrush;
        Brush Hoverbrush;

        private (int, int) MouseDownPosition = (-1, -1);//used only for ux, in case kabas matrah w rejii harrak el cursor
        private (int, int) hoveredCellColmnRow = (-1, -1);  // Stores the  (column,row) of the hovered cell
        bool IsAddingOrDeleting;

        public UCEmployeeAvailabilty(ClassEmployee desiredEmploye, EmployeeAvailabiltyForm parentEmployeeForm)
        {
            InitializeComponent();
            ParentEmployeeAvailabilityForm = parentEmployeeForm;
            DesiredEmploye = desiredEmploye;

            Hoverbrush = new SolidBrush(HoverColor);
            AddingBrush = new SolidBrush(SelectionColor);
            DeletionBrush = new SolidBrush(DefaultColor);


            CreateTLP();
            SetTLPColumns();

            DailyRowsAvailability = ClassEmployeeFront.GetRowsAvailabilityForTheWholeWeek(DesiredEmploye.Availability,TLPScheduleAv);

            labelEmployeeName.Text = desiredEmploye.Fname + " " + desiredEmploye.Lname;
        }
       

        void SetTLPColumns()
        {
            float PercentageOfEachGroup = 100 / ListdaysOfWeek.Count;
            for (int i = 0; i < ListdaysOfWeek.Count; i++)
            {
                //Days
                TLPDays.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, PercentageOfEachGroup));
                TLPDays.ColumnCount++;
                ButtonEmployeeOrDay buttonEmployeeOrDay = new ButtonEmployeeOrDay();
                buttonEmployeeOrDay.Dock = DockStyle.Fill;
                buttonEmployeeOrDay.Text = ListdaysOfWeek[i];
                buttonEmployeeOrDay.DesiredDate = DateTime.Now.AddDays(1);//hayyalla shi bas kermel tkun diffenet null, w tekhud el future design
                buttonEmployeeOrDay.SetButtonDesignBehavor(false, true);//ejbare tahet el Set fow
                TLPDays.Controls.Add(buttonEmployeeOrDay, i + 1, 0);//i+1, lieanno first column kermel el time

                TLPScheduleAv.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, PercentageOfEachGroup));
                TLPScheduleAv.ColumnCount++;
            }
        }

        void CreateTLP()
        {
            //uc1.UCAppIsDroped += Uc1_UCAppIsDroped;


            //
            if (TLPScheduleAv == null && TLPDays == null)
            {
                //TLPSchedule
                TLPScheduleAv = new TableLayoutPanel();
                TLPScheduleAv.AllowDrop = true;
                TLPScheduleAv.Dock = DockStyle.Fill;
                TLPScheduleAv.AutoScroll = true;
                TLPScheduleAv.BackColor = DefaultColor;
                TLPScheduleAv.Margin = new Padding(0, 0, 0, 0);
                TLPScheduleAv.AutoSize = false;
                //Hours
                TLPScheduleAv.RowCount = 96;
                for (int i = 0; i < TLPScheduleAv.RowCount; i++)
                {
                    TLPScheduleAv.RowStyles.Add(new RowStyle(SizeType.Absolute, 9));
                }


                //TLPEmployee
                TLPDays = new TableLayoutPanel();
                TLPDays.Dock = DockStyle.Fill;
                TLPDays.RowCount = 1;
                TLPDays.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
                TLPDays.Margin = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                TLPDays.BackColor = TLPScheduleAv.BackColor;

                //Time

                //Time in Tlp employee
                TLPDays.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
                TLPDays.ColumnCount++;

                //Time in TLP Schedule, ejbare absoloute
                TLPScheduleAv.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
                TLPScheduleAv.ColumnCount++;



                //
                for (int i = 0; i < TLPScheduleAv.RowCount; i += 4)
                {
                    Label LabelTime = new Label();
                    LabelTime.Dock = DockStyle.Fill;
                    LabelTime.BackColor = TLPScheduleAv.BackColor;
                    LabelTime.ForeColor = Color.FromArgb(64, 64, 64);
                    LabelTime.Dock = DockStyle.Fill;
                    LabelTime.TextAlign = ContentAlignment.TopRight;
                    LabelTime.Font = new Font("Segoe UI", 10, FontStyle.Regular);

                    TimeSpan Time = TimeSpan.FromHours(i / 4);

                    DateTime dateTime = DateTime.Today.Add(Time);//datetime it's a reference
                    string timestring = dateTime.ToString("h tt");
                    string[] partstime = timestring.Split(' ');
                    LabelTime.Text = partstime[0] + " " + partstime[1];


                    TLPScheduleAv.Controls.Add(LabelTime, 0, i);
                    TLPScheduleAv.SetRowSpan(LabelTime, 4);
                }


                //Events

                TLPScheduleAv.MouseWheel += TLPScheduleAv_MouseMove;
                TLPScheduleAv.MouseMove += TLPScheduleAv_MouseMove;

                TLPScheduleAv.MouseLeave += TLPScheduleAv_MouseLeave;

                TLPScheduleAv.CellPaint += TLPScheduleAv_CellPaint; ;
                TLPScheduleAv.MouseDown += TLPScheduleAv_MouseDown;
                TLPScheduleAv.MouseUp += TLPScheduleAv_MouseUp;
                //TLPScheduleAv.DragDrop += TLPScheduleAv_DragDrop; ;
                //TLPScheduleAv.DragEnter += TLPScheduleAv_DragEnter; ;
                //TLPScheduleAv.DragOver += TLPScheduleAv_DragOver; ;

                //TLPScheduleAv.MouseClick += TLPScheduleAv_MouseClick; ;
                //
                this.TLPGlobal.Controls.Add(TLPDays, 0, 1);
                this.TLPGlobal.Controls.Add(TLPScheduleAv, 0, 2);

            }

        }
    
        private void TLPScheduleAv_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Hoverbrush = new SolidBrush(HoverColor);

                if (hoveredCellColmnRow.Item1 != -1)
                {
                    string NewAvailability = GetIntervalBetweenTwoTime(ClassEmployeeFront.GetTimeFromRow(MouseDownPosition.Item2, false,TLPScheduleAv).ToString(@"hh\:mm"), ClassEmployeeFront.GetTimeFromRow(hoveredCellColmnRow.Item2, false,TLPScheduleAv).ToString(@"hh\:mm"));
                    string[] availabilities = DesiredEmploye.Availability.Split('/');
                    string OldavailabalityOfDesiredDay = availabilities[MouseDownPosition.Item1 - 1];

                    if (IsAddingOrDeleting)
                    {
                        if (String.IsNullOrEmpty(OldavailabalityOfDesiredDay))
                        {
                            availabilities[MouseDownPosition.Item1 - 1] = NewAvailability;
                        }
                        else
                        {
                            availabilities[MouseDownPosition.Item1 - 1] = MergeAvailabilities(OldavailabalityOfDesiredDay, NewAvailability);
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(OldavailabalityOfDesiredDay))
                        {
                            availabilities[MouseDownPosition.Item1 - 1] = RetrieveRemainingAvailability(OldavailabalityOfDesiredDay, NewAvailability);
                        }
                    }




                    DesiredEmploye.Availability = string.Join("/", availabilities);

                    DailyRowsAvailability = ClassEmployeeFront.GetRowsAvailabilityForTheWholeWeek(DesiredEmploye.Availability,TLPScheduleAv);
                    TLPScheduleAv.Invalidate();
                }
                MouseDownPosition = (-1, -1);
            }
        }

        private void TLPScheduleAv_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownPosition = GetCellPosition(TLPScheduleAv, e.Location);

                if (DailyRowsAvailability[MouseDownPosition.Item1 - 1].Contains(MouseDownPosition.Item2))
                {
                    IsAddingOrDeleting = false;
                }
                else
                {
                    IsAddingOrDeleting = true;
                }
            }
        }

        private void TLPScheduleAv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void TLPScheduleAv_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;



            if (MouseDownPosition != (-1, -1))//this while putting smthgnew
            {
                if (e.Column == MouseDownPosition.Item1 && e.Row <= hoveredCellColmnRow.Item2 && e.Row >= MouseDownPosition.Item2)
                {
                    if (IsAddingOrDeleting)
                    {
                        g.FillRectangle(AddingBrush, r);
                    }
                    else
                    {
                        g.FillRectangle(DeletionBrush, r);
                    }

                    if (e.Row == MouseDownPosition.Item2)
                    {
                        DrawTextOnCell(e.Graphics, r, e.Row);
                    }
                    else if (e.Row == hoveredCellColmnRow.Item2)
                    {
                        DrawTextOnCell(e.Graphics, r, e.Row + 1);//+1 lieanno bade el endTime
                    }
                }
            }


            ////Check if we're in the last column; if not, don't draw vertical lines
            if (e.Column < TLPScheduleAv.ColumnCount)
            {
                for (int i = 0; i < ListdaysOfWeek.Count; i++) //+1 lieanno awwal wahde el time
                {
                    if (e.Column == i + 1 && e.Column != 0)
                    {
                        g.DrawLine(Pens.LightGray, r.Left, r.Top, r.Left, r.Bottom);
                    }
                }
            }

            //noew we re creating the existing blocks that represents the availabilty
            if (e.Column > 0 && DailyRowsAvailability.Count > 0 && DailyRowsAvailability[e.Column - 1].Contains(e.Row))
            {
                if (MouseDownPosition != (-1, -1) && e.Column == MouseDownPosition.Item1 && e.Row <= hoveredCellColmnRow.Item2 && e.Row >= MouseDownPosition.Item2)
                {
                    //in here we re creating a new block or deleteing a block which my intersects with rendering of the block, thatwhy ma mnersemo
                    //if (e.Row < TLPScheduleAv.RowCount)
                    //{
                    //    if (e.Row % 4 == 0)
                    //    {
                    //        if (e.Row != 0)
                    //        {
                    //            g.DrawLine(Pens.LightGray, r.Left, r.Top, r.Right, r.Top);
                    //        }
                    //    }

                    //}
                }
                else//to be able to add a new section bala ma hayde tkun aam teassir aalaya
                {
                    List<List<int>> result = SplitContinuousSublists(DailyRowsAvailability[e.Column - 1], 1);

                    foreach (List<int> sublist in result)
                    {
                        int firstRow = sublist[0];
                        int lastRow = sublist[sublist.Count - 1];

                        if (e.Row >= firstRow && e.Row <= lastRow)
                        {
                            g.FillRectangle(AddingBrush, r);

                            if (e.Row == firstRow)//if its the first row
                            {
                                DrawTextOnCell(e.Graphics, r, e.Row);
                            }
                            else if (e.Row == lastRow)//if its the last row
                            {
                                DrawTextOnCell(e.Graphics, r, e.Row + 1);//+1 kermel nektub 12:00 instead of 11:45, EndRow!
                            }
                        }
                    }


                    if (MouseDownPosition == (-1, -1))//in case of hoover upward this block,ha ybayyin el deletion color 
                    {
                        if (e.Column == hoveredCellColmnRow.Item1 && e.Row == hoveredCellColmnRow.Item2)
                        {
                            g.FillRectangle(AddingBrush, r);

                            if (e.Row != DailyRowsAvailability[e.Column - 1][DailyRowsAvailability[e.Column - 1].Count - 1])//kermel ma ysir fi conflict bel endtime w starttime w yenkatabo foe baaed w tokhus
                            {
                                DrawTextOnCell(e.Graphics, r, e.Row);
                            }
                        }
                    }
                }
            }
            else// Always draw horizontal lines below the cell if not the last row, w since hiyye else, yane juwwe el bloack ma ha ybayno el rows
            {
                if (MouseDownPosition != (-1, -1) && e.Column == MouseDownPosition.Item1 && e.Row <= hoveredCellColmnRow.Item2 && e.Row >= MouseDownPosition.Item2)
                {
                }
                else
                {
                    if (e.Row < TLPScheduleAv.RowCount)
                    {
                        if (e.Row % 4 == 0)
                        {
                            if (e.Row != 0)
                            {
                                g.DrawLine(Pens.LightGray, r.Left, r.Top, r.Right, r.Top);
                            }
                        }

                    }

                    if (MouseDownPosition == (-1, -1))//hattayneha hone to prevent highlight on section fiya el availability
                    {
                        if (e.Column == hoveredCellColmnRow.Item1 && e.Row == hoveredCellColmnRow.Item2)
                        {
                            g.FillRectangle(Hoverbrush, r);
                            DrawTextOnCell(e.Graphics, r, e.Row);
                        }
                    }
                }


            }
        }
        private void TLPScheduleAv_MouseLeave(object sender, EventArgs e)
        {
            ResetSelection();
        }
        private void TLPScheduleAv_MouseMove(object sender, MouseEventArgs e)
        {
            if (!ParentEmployeeAvailabilityForm.timer1.Enabled)//to prevent flickiring
            {
                SetValuesthatWillAffectselection(e.Location);

            }
        }





        private readonly Brush CellTextBrush = new SolidBrush(Color.Blue);
        private readonly Font CellTextFont = new Font("Arial", 8, FontStyle.Regular);
        private void DrawTextOnCell(Graphics g, Rectangle cellBounds, int rowIndex)
        {

            // Assuming GetTimeFromRow is a method that returns a TimeSpan for the given row
            DateTime dateTime = DateTime.Today.Add(ClassEmployeeFront.GetTimeFromRow(rowIndex, false,TLPScheduleAv));//the end time is handled from where we re calling
            string textToDraw = dateTime.ToString("hh:mm tt");

            // Define the format for the text
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near; // Horizontal alignment
                sf.LineAlignment = StringAlignment.Center; // Vertical alignment
                g.DrawString(textToDraw, CellTextFont, CellTextBrush, cellBounds, sf);
            }

        }
      
       
        void ResetSelection()
        {
            hoveredCellColmnRow = (-1, -1);
            Cursor.Current = Cursors.Default; // Reset the cursor to the default
            TLPScheduleAv.Invalidate();
        }
        void SetValuesthatWillAffectselection(Point Loaction)
        {
            (int, int) cellPos = GetCellPosition(TLPScheduleAv, Loaction);

            if (cellPos != hoveredCellColmnRow)
            {
                hoveredCellColmnRow = cellPos; //set whichcolumn and row we are
            }
            TLPScheduleAv.Invalidate();
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


        string GetIntervalBetweenTwoTime(string StartTime, string Endtime)
        {
            TimeSpan start = TimeSpan.Parse(StartTime);
            TimeSpan end = TimeSpan.Parse(Endtime);
            string result = "";

            for (TimeSpan time = start; time < end; time = time.Add(TimeSpan.FromMinutes(15)))
            {
                result += time.ToString(@"hh\:mm") + "-";
            }

            // Add the end time as the final interval
            result += end.ToString(@"hh\:mm");

            return result;

        }




        string MergeAvailabilities(string oldAvailability, string newAvailability)
        {
            List<TimeSpan> oldIntervals = ClassEmployeeFront.GetTimeSpanAvailabiltyOfDesiredDay(oldAvailability);
            List<TimeSpan> newIntervals = ClassEmployeeFront.GetTimeSpanAvailabiltyOfDesiredDay(newAvailability);
            List<TimeSpan> mergedIntervals = new List<TimeSpan>();

            int i = 0, j = 0;

            while (i < oldIntervals.Count && j < newIntervals.Count)
            {
                TimeSpan oldInterval = oldIntervals[i];
                TimeSpan newInterval = newIntervals[j];

                if (oldInterval < newInterval)
                {
                    AddInterval(mergedIntervals, oldInterval);
                    i++;
                }
                else
                {
                    AddInterval(mergedIntervals, newInterval);
                    j++;
                }
            }

            while (i < oldIntervals.Count)
            {
                AddInterval(mergedIntervals, oldIntervals[i]);
                i++;
            }

            while (j < newIntervals.Count)
            {
                AddInterval(mergedIntervals, newIntervals[j]);
                j++;
            }

            return FormatAvailability(mergedIntervals);
        }
        string RetrieveRemainingAvailability(string oldAvailability, string newAvailability)
        {
            List<TimeSpan> oldIntervals = ClassEmployeeFront.GetTimeSpanAvailabiltyOfDesiredDay(oldAvailability);
            List<TimeSpan> newIntervals = ClassEmployeeFront.GetTimeSpanAvailabiltyOfDesiredDay(newAvailability);

            List<TimeSpan> remainingIntervals = oldIntervals.Except(newIntervals).ToList();

            return FormatAvailability(remainingIntervals);
        }
         void AddInterval(List<TimeSpan> mergedIntervals, TimeSpan interval)
        {
            if (mergedIntervals.Count == 0 || interval > mergedIntervals[mergedIntervals.Count - 1].Add(TimeSpan.FromMinutes(15)))
            {
                mergedIntervals.Add(interval);
            }
            else if (interval == mergedIntervals[mergedIntervals.Count - 1].Add(TimeSpan.FromMinutes(15)))
            {
                mergedIntervals.Add(interval);
            }
        }
        string FormatAvailability(List<TimeSpan> intervals)
        {
            List<string> formattedIntervals = new List<string>();

            foreach (var interval in intervals)
            {
                formattedIntervals.Add(interval.ToString(@"hh\:mm"));
            }

            return string.Join("-", formattedIntervals);
        }



        public static List<List<int>> SplitContinuousSublists(List<int> list, int interval)
        {
            List<List<int>> result = new List<List<int>>();
            if (list == null || list.Count == 0)
            {
                return result;
            }

            List<int> currentSublist = new List<int> { list[0] };

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] - list[i - 1] == interval)
                {
                    currentSublist.Add(list[i]);
                }
                else
                {
                    result.Add(new List<int>(currentSublist));
                    currentSublist.Clear();
                    currentSublist.Add(list[i]);
                }
            }

            // Add the last sublist
            if (currentSublist.Count > 0)
            {
                result.Add(currentSublist);
            }

            return result;
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            ParentEmployeeAvailabilityForm.ParentUCEmployee.ParentFormEmployee.OnDoneClick();        
            ParentEmployeeAvailabilityForm.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ParentEmployeeAvailabilityForm.Close();
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
