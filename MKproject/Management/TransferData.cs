
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using System.Windows.Xps.Serialization;
using GlobalFunctions;
using MKproject.Schedule;
using MKproject.Schedule.Appointmentform;

namespace MKproject.Management
{

    public partial class TransferData : Form
    {


        TableLayoutPanelDoubleBufferedNoscroll TLPSchedule;


        UCappointment UCApointmentDraged;
        //Stores the old postion of Draged Control
        int OldColumn;//old column is the exact column li ken aalaya el uc
        int OldStartingColumn;//haya el old colmn mesh el exact, as enno men awwal column tb3 el hayda employee
        int OldEndingColumn;
        int OldStartingRow;
        int OldEndingRow;
        //kermel when i m removing a uc, bi hemne shuf el el uc ma32oul yetghyara shaklun men wara
        List<UCappointment> SerpentConnectedgroupedUCsBeforeRemoving;



        List<(ClassEmployee, List<int>)> AllIndexesGroupList = new List<(ClassEmployee, List<int>)>();


        (ClassEmployee, List<int>) DesiredIndexesGroupOfDraggedUc = (null, null);//stores the index columns Related To employee , when we re dragging a uc

        private (int, int) hoveredCellColmnRow = (-1, -1);  // Stores the  (column,row) of the hovered cell


        int NbreofRowsHighlighted = -1;//how many rows we need to highlight while mouse hover or dragging

        Brush hoverBrush = new SolidBrush(Color.LightGray); // Change the color as needed

        public TransferData()
        {
            InitializeComponent();




            List<ClassEmployee> ListEmployeeSchedule = ClassEmployee.GetEmployeeScheduleMemberASC();

            //these indexes value, should initially be t Setbased on the ranks and on there s more then 2 appointment in the same hour, and any changes dureing the way, this list will be modifid , and apply to it one of the AppPercentage Design
            List<int> Employee0 = new List<int>() { 1, 2, 3 };
            List<int> Employee1 = new List<int>() { 4, 5, 6 };
            List<int> Employee2 = new List<int>() { 7, 8, 9 };
            List<int> Employee3 = new List<int>() { 10 };
            List<int> Employee4 = new List<int>() { 11 };
            List<int> Employee5 = new List<int>() { 12 };

            AllIndexesGroupList.Add((ListEmployeeSchedule[0], Employee0));
            AllIndexesGroupList.Add((ListEmployeeSchedule[1], Employee1));
            AllIndexesGroupList.Add((ListEmployeeSchedule[2], Employee2));

            AllIndexesGroupList.Add((ListEmployeeSchedule[3], Employee3));
            AllIndexesGroupList.Add((ListEmployeeSchedule[4], Employee4));
            AllIndexesGroupList.Add((ListEmployeeSchedule[5], Employee5));


            CreateTLP();//before creating our TLP we need AllIndexesGroupList
            UCappointment uc1;
            for (int i = 1; i < 9; i++)
            {
                uc1 = new UCappointment(ClassAppointment.CreateObjectClassAppointment(40 + i));
                uc1.Dock = DockStyle.Fill;
                uc1.ColumnIndex = 1;
                uc1.RowIndex = i * 3;
                TLPSchedule.Controls.Add(uc1, 1, uc1.RowIndex);
                TLPSchedule.SetRowSpan(uc1, 4);
                uc1.UCAppIsDroped += Uc1_UCAppIsDroped;
            }


            uc1 = new UCappointment(ClassAppointment.CreateObjectClassAppointment(51));
            uc1.Dock = DockStyle.Fill;
            uc1.ColumnIndex = 2;
            uc1.RowIndex = 3;
            TLPSchedule.Controls.Add(uc1, uc1.ColumnIndex, uc1.RowIndex);
            TLPSchedule.SetRowSpan(uc1, 6);
            uc1.UCAppIsDroped += Uc1_UCAppIsDroped;

            uc1 = new UCappointment(ClassAppointment.CreateObjectClassAppointment(60));
            uc1.ColumnIndex = 1;
            uc1.RowIndex = 8;
            TLPSchedule.Controls.Add(uc1, uc1.ColumnIndex, uc1.RowIndex);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 4);
            uc1.UCAppIsDroped += Uc1_UCAppIsDroped;




            uc1 = new UCappointment(ClassAppointment.CreateObjectClassAppointment(52));
            uc1.ColumnIndex = 7;
            uc1.RowIndex = 10;
            TLPSchedule.Controls.Add(uc1, uc1.ColumnIndex, uc1.RowIndex);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 6);
            uc1.UCAppIsDroped += Uc1_UCAppIsDroped;

            uc1 = new UCappointment(ClassAppointment.CreateObjectClassAppointment(53));
            uc1.ColumnIndex = 8;
            uc1.RowIndex = 12;
            TLPSchedule.Controls.Add(uc1, uc1.ColumnIndex, uc1.RowIndex);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 6);
            uc1.UCAppIsDroped += Uc1_UCAppIsDroped;

            uc1 = new UCappointment(ClassAppointment.CreateObjectClassAppointment(54));
            uc1.ColumnIndex = 9;
            uc1.RowIndex = 14;
            TLPSchedule.Controls.Add(uc1, uc1.ColumnIndex, uc1.RowIndex);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 6);
            uc1.UCAppIsDroped += Uc1_UCAppIsDroped;

            uc1 = new UCappointment(ClassAppointment.CreateObjectClassAppointment(56));
            uc1.ColumnIndex = 10;
            uc1.RowIndex = 12;
            TLPSchedule.Controls.Add(uc1, uc1.ColumnIndex, uc1.RowIndex);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 8);
            uc1.UCAppIsDroped += Uc1_UCAppIsDroped;



            ResizeTableLayoutPanelToPerc();
            //ExpandTableLayoutPanelColumn(AllIndexesGroupList[3], 700);
        }

        static int columnIndex = 4;
        private void button1_Click(object sender, EventArgs e)
        {        
            InsertColumn(columnIndex);
            TLPSchedule.Invalidate();
            columnIndex++;
        }
        private void InsertColumn(int columnIndex)
        {
            TLPSchedule.ColumnCount++;
          
            //finding the desiredIndexesgroup
            int i;
            for (i = 0; i < AllIndexesGroupList.Count; i++)
            {
                if (AllIndexesGroupList[i].Item2.Contains(columnIndex - 1))
                {
                    AllIndexesGroupList[i].Item2.Add(columnIndex);
                   
                    i++;
                    break;
                }

            }


            //fixing the size
            (ClassEmployee, List<int>) TargetedIndexesGroup = AllIndexesGroupList[i - 1];
            float PercentageOfEachGroup = 100 / AllIndexesGroupList.Count;
            float PercentageOfEachColumn = PercentageOfEachGroup / TargetedIndexesGroup.Item2.Count;
            foreach (int ColumnIndex in TargetedIndexesGroup.Item2)
            {
                TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
            }


            //fixing the calues in AllIndexesGroupList 
            while (i < AllIndexesGroupList.Count)
            {
                for (int j = 0; j < AllIndexesGroupList[i].Item2.Count; j++)
                {
                    AllIndexesGroupList[i].Item2[j]++;
                }
                i++;
            }


            //fixing the indexes 
            foreach (Control co in TLPSchedule.Controls)
            {
                int OldColumnsIndex = TLPSchedule.GetColumn(co);
                if (co is UCappointment && TLPSchedule.GetColumn(co) >= columnIndex)
                {
                    TLPSchedule.SetColumn(co, OldColumnsIndex + 1);
                }
            }
        }

        void CreateTLP()
        {
            TLPSchedule = new TableLayoutPanelDoubleBufferedNoscroll();
            TLPSchedule.AllowDrop = true;
            TLPSchedule.Dock = DockStyle.Fill;
            TLPSchedule.AutoScroll = true;



            //Hours
            TLPSchedule.RowCount = 96;
            for (int i = 0; i < TLPSchedule.RowCount; i++)
            {
                TLPSchedule.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));


            }



            //Colmns Groups,Employees
            TLPSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
            TLPSchedule.ColumnCount++;

            foreach ((ClassEmployee, List<int>) Group in AllIndexesGroupList)
            {
                foreach (int ColumnIndex in Group.Item2)
                {

                    TLPSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                    TLPSchedule.ColumnCount++;

                }
            }



            //
            for (int i = 0; i < TLPSchedule.RowCount; i += 4)
            {
                Label LabelTime = new Label();
                LabelTime.Dock = DockStyle.Fill;
                LabelTime.BackColor = Color.White;
                LabelTime.Dock = DockStyle.Fill;
                LabelTime.TextAlign = ContentAlignment.TopRight;
                LabelTime.Font = new Font("Arial", 10f, System.Drawing.FontStyle.Regular);
                TimeSpan Time = TimeSpan.FromHours(i / 4);

                DateTime dateTime = DateTime.Today.Add(Time);//datetime it's a reference
                string timestring = dateTime.ToString("h:mm tt");
                string[] partstime = timestring.Split(' ');
                LabelTime.Text = partstime[0] + " " + partstime[1];


                TLPSchedule.Controls.Add(LabelTime, 0, i);
                TLPSchedule.SetRowSpan(LabelTime, 4);
            }



            //Events
            TLPSchedule.MouseWheel += TLPSchedule_MouseMove;
            TLPSchedule.MouseMove += TLPSchedule_MouseMove;

            TLPSchedule.MouseLeave += TLPSchedule_MouseLeave;

            TLPSchedule.CellPaint += TLPSchedule_CellPaint;
            TLPSchedule.DragDrop += TLPSchedule_DragDrop;
            TLPSchedule.DragEnter += TLPSchedule_DragEnter;
            TLPSchedule.DragOver += TLPSchedule_DragOver;

            this.Controls.Add(TLPSchedule);
        }



        private void TLPSchedule_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            UCApointmentDraged = e.Data.GetData(typeof(UCappointment)) as UCappointment;
            if (UCApointmentDraged.Parent != null)
            {

                OldColumn = TLPSchedule.GetColumn(UCApointmentDraged);
                (ClassEmployee, List<int>) OldDesiredIndexesGroup = GetWichDesiredIndexesGroup(OldColumn);

                (OldStartingColumn, OldEndingColumn, OldStartingRow, OldEndingRow) = Get4RectanglePoints(TLPSchedule.GetRow(UCApointmentDraged), OldDesiredIndexesGroup);

                ClassucAppointmentGrouping grouper = new ClassucAppointmentGrouping(TLPSchedule, null, OldDesiredIndexesGroup.Item2);
                SerpentConnectedgroupedUCsBeforeRemoving = grouper.GetConnectedComponent(UCApointmentDraged);

                TLPSchedule.Controls.Remove(UCApointmentDraged);

            }
        }
        private void TLPSchedule_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

            Point clientPoint = TLPSchedule.PointToClient(new Point(e.X, e.Y));
            SetValuesthatWillAffectselection(clientPoint);
        }
        private void Uc1_UCAppIsDroped(object sender, EventArgs e)//kermel eza kabbayneha outside the bounds what to
        {
            Point cursorPosition = this.PointToClient(Cursor.Position);
            if (!TLPSchedule.ClientRectangle.Contains(cursorPosition))
            {
                TLPSchedule.Controls.Add(UCApointmentDraged, OldStartingColumn, OldStartingRow);//lezim tekhlaa column aw tsayoo haddo
                ResetSelection();
            }
        }
        private void TLPSchedule_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = TLPSchedule.PointToClient(new Point(e.X, e.Y));   // Convert the screen coordinates to client coordinates
            (int column, int row) = GetCellPosition(TLPSchedule, clientPoint);
            (int StartingColumn, int EndingColumn, int StartingRow, int EndingRow) = Get4RectanglePoints(row, DesiredIndexesGroupOfDraggedUc);


            List<UCappointment> NewListUC = GetListOfAllControlsInSpecifiedArea(StartingColumn, EndingColumn, StartingRow, EndingRow);
            ClassucAppointmentGrouping grouper2 = new ClassucAppointmentGrouping(TLPSchedule, NewListUC, null);
            Dictionary<int, List<UCappointment>> NewgroupedUCs = grouper2.ClassifyGroupsThatIntersectsIndependly();
            List<UCappointment> AllNewdUC = NewgroupedUCs.SelectMany(pair => pair.Value).ToList();

            //removing
            List<UCappointment> OldListUC = GetListOfAllControlsInSpecifiedArea(OldStartingColumn, OldEndingColumn, OldStartingRow, OldEndingRow);//it will give the list, without the one we re removing
            ClassucAppointmentGrouping grouper1 = new ClassucAppointmentGrouping(TLPSchedule, OldListUC, null);
            Dictionary<int, List<UCappointment>> OldIndependentgroupedUCs = grouper1.ClassifyGroupsThatIntersectsIndependly();
            List<UCappointment> AllOldUC = OldIndependentgroupedUCs.SelectMany(pair => pair.Value).ToList();


            if (SerpentConnectedgroupedUCsBeforeRemoving.Count > 0 && ListsHaveSameElements(AllOldUC, SerpentConnectedgroupedUCsBeforeRemoving) && !ListsHaveSameElements(AllOldUC, AllNewdUC))
            {
                foreach (KeyValuePair<int, List<UCappointment>> Oldentry in OldIndependentgroupedUCs)
                {
                    List<UCappointment> ListucAppointments = Oldentry.Value;

                    SetNewRowSpan(OldStartingColumn, ListucAppointments, false);

                    //fixing the indexes
                    int ColumnIndexToStartWith = OldStartingColumn;
                    foreach (UCappointment ucapp in ListucAppointments)
                    {
                        TLPSchedule.SetColumn(ucapp, ColumnIndexToStartWith);
                        ColumnIndexToStartWith += TLPSchedule.GetColumnSpan(ucapp);
                    }

                }
            }






            //adding
            if (UCApointmentDraged != null && column >= 1 && row >= 0)
            {

                bool PlaceExist = FittingUCIfPlaceExist(StartingColumn, EndingColumn, StartingRow, EndingRow);

                if (!PlaceExist)
                {

                    List<UCappointment> ListucAppointments = null;
                    List<int> originalSpans = null;




                    foreach (KeyValuePair<int, List<UCappointment>> entry in NewgroupedUCs)//lama ykuno hadd baeed bi tariea mafhume
                    {
                        bool OverLapByColumnsExists;//bad serpent
                        if (entry.Value.Count() > 2)
                        {
                            OverLapByColumnsExists = CheckForOverlappingAppointments(NewgroupedUCs);
                        }
                        else
                        {
                            OverLapByColumnsExists = false;
                        }

                        if (!OverLapByColumnsExists)
                        {
                            // Get the single group's list of UCappointment
                            ListucAppointments = entry.Value;

                            originalSpans = new List<int>();  // List to store original column spans
                            foreach (UCappointment uc in ListucAppointments)
                            {
                                int originalSpan = TLPSchedule.GetColumnSpan(uc);
                                originalSpans.Add(originalSpan);
                            }

                            SetNewRowSpan(StartingColumn, ListucAppointments, true);
                        }
                        else
                        {
                            ListucAppointments = entry.Value;

                            originalSpans = new List<int>();  // List to store original column spans
                            foreach (UCappointment uc in ListucAppointments)
                            {
                                int originalSpan = TLPSchedule.GetColumnSpan(uc);
                                originalSpans.Add(originalSpan);

                                if (originalSpan > 1)
                                {
                                    TLPSchedule.SetColumnSpan(uc, originalSpan - 1);
                                }
                            }



                        }
                    }

                    PlaceExist = FittingUCIfPlaceExist(StartingColumn, EndingColumn, StartingRow, EndingRow);//now men baaed ma zabatna el row spans tb3 el ucappointments, sar fi mahal elo lal appointment

                    if (PlaceExist && NewgroupedUCs.Count > 1)//to fix errors in when independent groups exists
                    {
                        //List<UCappointment> NewListUCAfterAdding = GetListOfAllControlsInSpecifiedArea(StartingColumn, EndingColumn, StartingRow, EndingRow);
                        //ClassucAppointmentGrouping grouper2AfterAdding = new ClassucAppointmentGrouping(TLPSchedule, NewListUC, null);
                        //Dictionary<int, List<UCappointment>> NewgroupedUCsAfterAdding = grouper2.ClassifyGroupsThatIntersectsIndependly();
                        //foreach (KeyValuePair<int, List<UCappointment>> Oldentry in NewgroupedUCsAfterAdding)
                        //{
                        //    List<UCappointment> ListucAppointmentsAfterAdding = Oldentry.Value;

                        //    SetNewRowSpan(StartingColumn, ListucAppointmentsAfterAdding, false);

                        //}

                    }

                    if (!PlaceExist && originalSpans != null && ListucAppointments != null)//resetting to oginal spans, eza ma le2a mahal yoeuud fi el appointment
                    {
                        for (int i = 0; i < originalSpans.Count; i++)
                        {
                            if (i < ListucAppointments.Count)//Existing UCappointment
                            {
                                TLPSchedule.SetColumnSpan(ListucAppointments[i], originalSpans[i]);
                            }
                        }
                    }

                    if (!PlaceExist)
                    {
                        TLPSchedule.Controls.Add(UCApointmentDraged, OldStartingColumn, OldStartingRow);//lezim tekhlaa column aw tsayoo haddo
                        ResetSelection();
                    }



                    //TLPSchedule.Controls.Add(UCApointmentDraged, OldUCColumnRow.Item1, OldUCColumnRow.Item2);//lezim tekhlaa column aw tsayoo haddo
                    //ResetSelection();
                }


                UCApointmentDraged.Dock = DockStyle.Fill;
                UCApointmentDraged.isDragging = false;
                UCApointmentDraged.Show();
                UCApointmentDraged = null;

                ResetSelection();
            }
            else
            {
                TLPSchedule.Controls.Add(UCApointmentDraged, OldStartingColumn, OldStartingRow);//lezim tekhlaa column aw tsayoo haddo
                ResetSelection();
            }
        }




        int RecursiveDrop(int StartingColumn, int EndingColumn, int StartingRow, int EndingRow, bool ModeLRorRL)//l mnaamlo enno men sir na2is el area tabaa el rectangle, by reducing el starting if ModeLRorRL=true; or reducing el ending if ModeLRorRL=false, w once ma bi kun fi wala control in this area men hatto
        {
            int TargetedColumn;//it could be the starting or the ending clolumn


            if (ModeLRorRL)
            {
                if (StartingColumn > EndingColumn)
                {
                    TargetedColumn = -1;
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
                    TargetedColumn = -1;
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
                    UCappointment founducapp = GetUCIfOverlapSpecifiedCell(j, i);//we re checking each cell eza fiya shi, which will cover the whole area of the usercontrol
                    if (founducapp != null)
                    {
                        if (ModeLRorRL)
                        {
                            TargetedColumn = RecursiveDrop(StartingColumn + 1, EndingColumn, StartingRow, EndingRow, true);
                        }
                        else
                        {
                            TargetedColumn = RecursiveDrop(StartingColumn, EndingColumn - 1, StartingRow, EndingRow, false);
                        }

                    }
                }
            }


            return TargetedColumn;

        }
        bool FittingUCIfPlaceExist(int StartingColumn, int EndingColumn, int StartingRow, int EndingRow)
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
                TLPSchedule.Controls.Add(UCApointmentDraged, StartingColumn, StartingRow);
                UCApointmentDraged.ColumnIndex = StartingColumn;
                UCApointmentDraged.RowIndex = StartingRow;
                TLPSchedule.SetColumnSpan(UCApointmentDraged, (EndingColumn - StartingColumn) + 1);
            }
            return PlaceExist;

        }
       
        
        void SetNewRowSpan(int ColumnIndexToStartWith, List<UCappointment> ListucAppointments, bool AddingOrRemoving)
        {
            int totalSpan;
            int newuc;
            if (AddingOrRemoving)
            {
                newuc = 1;
                totalSpan = ListucAppointments.Sum(uc => TLPSchedule.GetColumnSpan(uc));
            }
            else
            {
                newuc = 0;
                (ClassEmployee, List<int>) OldDesiredIndexesGroup = GetWichDesiredIndexesGroup(OldStartingColumn);
                totalSpan = OldDesiredIndexesGroup.Item2.Count;
            }
            int numUCs = ListucAppointments.Count + newuc; // +newuc for the new UCappointment if adding mode

            // Calculate the fair span to be distributed to each UCappointment
            int fairSpan = totalSpan / numUCs;
            int remainder = totalSpan % numUCs;

            // Distribute the spans
            List<int> spans = new List<int>();

            // Each UC gets at least the fairSpan
            for (int i = 0; i < numUCs; i++)
            {
                if (i < remainder)
                {
                    // Distribute the remainder by adding 1 to the first 'remainder' UCs,yaane akbar values aam naatiyun li aa shmel
                    spans.Add(fairSpan + 1);
                }
                else
                {
                    spans.Add(fairSpan);
                }
            }


            for (int i = 0; i < spans.Count; i++)
            {
                if (i < ListucAppointments.Count)//Existing UCappointment
                {
                    TLPSchedule.SetColumnSpan(ListucAppointments[i], spans[i]);
                }
            }

            foreach (UCappointment ucapp in ListucAppointments)
            {
                TLPSchedule.SetColumn(ucapp, ColumnIndexToStartWith);
                int col = TLPSchedule.GetColumn(ucapp);
                ColumnIndexToStartWith += TLPSchedule.GetColumnSpan(ucapp);
            }
        }
        public bool CheckForOverlappingAppointments(Dictionary<int, List<UCappointment>> groupedUCs)
        {
            foreach (var entry in groupedUCs)
            {
                var appointments = entry.Value;
                // Sort appointments by start column to make overlap detection easier
                appointments.Sort((a, b) => TLPSchedule.GetColumn(a).CompareTo(TLPSchedule.GetColumn(b)));

                for (int i = 0; i < appointments.Count - 1; i++)
                {
                    // Get the current appointment and the next one
                    var current = appointments[i];
                    var next = appointments[i + 1];

                    // Retrieve start column and column span from the TableLayoutPanel
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
            }

            // No overlaps found
            return false;
        }



        bool ListsHaveSameElements(List<UCappointment> list1, List<UCappointment> list2)
        {
            var sortedList1 = list1.OrderBy(x => x.DesiredAppointmentUCApp.AppointmentID).ToList();
            var sortedList2 = list2.OrderBy(x => x.DesiredAppointmentUCApp.AppointmentID).ToList();
            return sortedList1.SequenceEqual(sortedList2);
        }
        (ClassEmployee, List<int>) GetWichDesiredIndexesGroup(int StartingColumn)
        {
            int WhichEmployee = 0;
            foreach ((ClassEmployee, List<int>) Group in AllIndexesGroupList)
            {
                if (Group.Item2.Contains(StartingColumn))
                {
                    return AllIndexesGroupList[WhichEmployee];
                }
                WhichEmployee++;
            }
            return (null, null);
        }
        (int, int, int, int) Get4RectanglePoints(int DesiredRow, (ClassEmployee, List<int>) desiredIndexesGroup)
        {
            int StartingColumn = desiredIndexesGroup.Item2[0];
            int EndingColumn = desiredIndexesGroup.Item2[desiredIndexesGroup.Item2.Count - 1];


            int StartingRow = DesiredRow;
            int EndingRow = DesiredRow + TLPSchedule.GetRowSpan(UCApointmentDraged) - 1;

            return (StartingColumn, EndingColumn, StartingRow, EndingRow);
        }
        private UCappointment GetUCIfOverlapSpecifiedCell(int checkCol, int checkRow)//check for these specific indexes,foreach cell if its occupied, eza fi hdn aalayun
        {
            foreach (Control control in TLPSchedule.Controls)
            {
                if (control is UCappointment ucApp)
                {
                    int startColumn = TLPSchedule.GetColumn(ucApp);
                    int startRow = TLPSchedule.GetRow(ucApp);

                    int columnSpan = TLPSchedule.GetColumnSpan(ucApp);
                    int rowSpan = TLPSchedule.GetRowSpan(ucApp);

                    // Check if the control spans over the checked cells (column and row of the cell)
                    if (startColumn <= checkCol && (startColumn + columnSpan) > checkCol &&
                        startRow <= checkRow && (startRow + rowSpan) > checkRow)
                    {
                        return ucApp;
                    }
                }
            }
            return null; // No control found spanning this position
        }

        List<UCappointment> GetListOfAllControlsInSpecifiedArea(int StartingColumn, int EndingColumn, int StartingRow, int EndingRow)
        {
            List<UCappointment> ListUC = new List<UCappointment> { };
            for (int i = StartingRow; i <= EndingRow; i++)
            {
                for (int j = StartingColumn; j <= EndingColumn; j++)
                {
                    UCappointment founducapp = GetUCIfOverlapSpecifiedCell(j, i);
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
                NbrRowShouldPass = TLPSchedule.GetRowSpan(UCApointmentDraged);

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
                if (currentGroup == hoveredGroup && (DesiredIndexesGroupOfDraggedUc != (null, null) && DesiredIndexesGroupOfDraggedUc.Item2.Contains(e.Column)))
                {

                    g.FillRectangle(hoverBrush, r);
                }
            }
            else
            {
                if ((e.Row >= hoveredCellColmnRow.Item2 && e.Row < (hoveredCellColmnRow.Item2 + NbrRowShouldPass)) && (DesiredIndexesGroupOfDraggedUc != (null, null) && DesiredIndexesGroupOfDraggedUc.Item2.Contains(e.Column)))
                {

                    g.FillRectangle(hoverBrush, r);
                }
            }





            ////Check if we're in the last column; if not, don't draw vertical lines
            if (e.Column < TLPSchedule.ColumnCount)
            {
                foreach ((ClassEmployee, List<int>) va in AllIndexesGroupList)
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
            NbreofRowsHighlighted = 4;
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

                //set whichcolumn and row we are
                hoveredCellColmnRow = cellPos;

                //Set which employee we re in
                int WhichEmployee = 0;
                foreach ((ClassEmployee, List<int>) Group in AllIndexesGroupList)
                {
                    if (Group.Item2.Contains(hoveredCellColmnRow.Item1))
                    {
                        DesiredIndexesGroupOfDraggedUc = AllIndexesGroupList[WhichEmployee];
                        break;
                    }
                    WhichEmployee++;
                }


                TLPSchedule.Invalidate();
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
            DesiredIndexesGroupOfDraggedUc = (null, null);
            Cursor.Current = Cursors.Default; // Reset the cursor to the default
            TLPSchedule.Invalidate();
        }






        public void ExpandTableLayoutPanelColumn((ClassEmployee, List<int>) DesiredIndexesGroup, int MaxWidth)
        {

            int OriginalWidthOfDesiredGroup = UCappointment.OriginalWidth * DesiredIndexesGroup.Item2.Count;

            int DesiredWidthOfTheGroup = OriginalWidthOfDesiredGroup < MaxWidth ? OriginalWidthOfDesiredGroup : MaxWidth;



            int DesiredWidthPerColumn = DesiredWidthOfTheGroup / DesiredIndexesGroup.Item2.Count;

            foreach (int ColumnIndex in DesiredIndexesGroup.Item2)
            {
                TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Absolute, DesiredWidthPerColumn);
            }
        }
        void ResizeTableLayoutPanelToPerc()
        {
            float PercentageOfEachGroup = 100 / AllIndexesGroupList.Count;

            foreach ((ClassEmployee, List<int>) Group in AllIndexesGroupList)
            {
                float PercentageOfEachColumn = PercentageOfEachGroup / Group.Item2.Count;

                foreach (int ColumnIndex in Group.Item2)
                {
                    TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
