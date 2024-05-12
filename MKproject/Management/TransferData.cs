
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
using MKproject.Schedule;
using MKproject.Schedule.Appointmentform;

namespace MKproject.Management
{

    public partial class TransferData : Form
    {

        TableLayoutPanelDoubleBufferedNoscroll TLPSchedule;

        List<(ClassEmployee, List<int>)> ListOfAllColumnIndexesGroups = new List<(ClassEmployee, List<int>)>();
        (ClassEmployee, List<int>) FocusOnColumnIndexGroup;
        int FocusOnMaxWidth;

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





        public TransferData()
        {
            InitializeComponent();




            List<ClassEmployee> ListEmployeeSchedule = ClassEmployee.GetEmployeeScheduleMemberASC();
            //these indexes value, should initially be t Setbased on the ranks and on there s more then 2 appointment in the same hour, and any changes dureing the way, this list will be modifid , and apply to it one of the AppPercentage Design
            List<int> Employee0 = new List<int>() { 1 };
            List<int> Employee1 = new List<int>() { 2 };
            List<int> Employee2 = new List<int>() { 3 };
            List<int> Employee3 = new List<int>() { 4 };
            List<int> Employee4 = new List<int>() { 5 };
            List<int> Employee5 = new List<int>() { 6 };

            ListOfAllColumnIndexesGroups.Add((ListEmployeeSchedule[0], Employee0));
            ListOfAllColumnIndexesGroups.Add((ListEmployeeSchedule[1], Employee1));
            ListOfAllColumnIndexesGroups.Add((ListEmployeeSchedule[2], Employee2));

            ListOfAllColumnIndexesGroups.Add((ListEmployeeSchedule[3], Employee3));
            ListOfAllColumnIndexesGroups.Add((ListEmployeeSchedule[4], Employee4));
            ListOfAllColumnIndexesGroups.Add((ListEmployeeSchedule[5], Employee5));


            CreateTLP();//before creating our TLP we need AllIndexesGroupList
            UCappointment uc1;
            int value = 0;
            for (int i = 1; i <= 6; i++)
            {

                uc1 = new UCappointment(ClassAppointment.CreateObjectClassAppointment(40 + i));
                uc1.Dock = DockStyle.Fill;
                uc1.ColumnIndex = 1;
                uc1.RowIndex = value;
                value += 4;
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
            uc1.ColumnIndex = 3;
            uc1.RowIndex = 8;
            TLPSchedule.Controls.Add(uc1, uc1.ColumnIndex, uc1.RowIndex);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 4);
            uc1.UCAppIsDroped += Uc1_UCAppIsDroped;




            uc1 = new UCappointment(ClassAppointment.CreateObjectClassAppointment(52));
            uc1.ColumnIndex = 4;
            uc1.RowIndex = 10;
            TLPSchedule.Controls.Add(uc1, uc1.ColumnIndex, uc1.RowIndex);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 6);
            uc1.UCAppIsDroped += Uc1_UCAppIsDroped;

            uc1 = new UCappointment(ClassAppointment.CreateObjectClassAppointment(53));
            uc1.ColumnIndex = 5;
            uc1.RowIndex = 12;
            TLPSchedule.Controls.Add(uc1, uc1.ColumnIndex, uc1.RowIndex);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 6);
            uc1.UCAppIsDroped += Uc1_UCAppIsDroped;

            uc1 = new UCappointment(ClassAppointment.CreateObjectClassAppointment(54));
            uc1.ColumnIndex = 6;
            uc1.RowIndex = 14;
            TLPSchedule.Controls.Add(uc1, uc1.ColumnIndex, uc1.RowIndex);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 6);
            uc1.UCAppIsDroped += Uc1_UCAppIsDroped;





            ResizeTableLayoutPanelToPerc();
            FocusOnEmployee(ListEmployeeSchedule[3]);

        }


        void CreateTLP()
        {
            //Getting the maximum width of the absolute column so that other columns always appear



            //
            TLPSchedule = new TableLayoutPanelDoubleBufferedNoscroll();
            TLPSchedule.AllowDrop = true;
            TLPSchedule.Dock = DockStyle.Fill;
            TLPSchedule.AutoScroll = true;
            TLPSchedule.BackColor = Color.FromArgb(245, 245, 245);


            //Hours
            TLPSchedule.RowCount = 96;
            for (int i = 0; i < TLPSchedule.RowCount; i++)
            {
                TLPSchedule.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));

            }



            //Colmns Groups,Employees
            TLPSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
            TLPSchedule.ColumnCount++;

            foreach ((ClassEmployee, List<int>) Group in ListOfAllColumnIndexesGroups)
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
                LabelTime.BackColor = TLPSchedule.BackColor;
                LabelTime.ForeColor = Color.FromArgb(50, 50, 50);
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

            this.Controls.Add(TLPSchedule);

            //

            SetFocusOnMaxWidth();

        }

        private void TLPSchedule_Resize(object sender, EventArgs e)
        {
            SetFocusOnMaxWidth();
            ResizeTableLayoutPanelToPerc();
            FocusOnColumnIndexGroup = (null, null);
        }

        void SetFocusOnMaxWidth()
        {
            FocusOnMaxWidth = (int)((TLPSchedule.Width - TLPSchedule.GetColumnWidths()[0]) * 0.85);//so he will be 90 % of the columns without the first column
        }
        void FocusOnEmployee(ClassEmployee emp)
        {
            foreach ((ClassEmployee, List<int>) Group in ListOfAllColumnIndexesGroups)
            {
                if (Group.Item1.EmployeeId == emp.EmployeeId)
                {
                    FocusOnColumnIndexGroup = Group;
                }
            }
            ExpandTableLayoutPanelColumn();
        }



        //Functions Used By code
        void UndoMode((ClassEmployee, List<int>) DesiredColumnIndexesGroup, int NewRow)
        {
            AddUc(DesiredColumnIndexesGroup, NewRow);
            RemoveUc(null);
        }
        void PurellyAddingUcApp((ClassEmployee, List<int>) DesiredColumnIndexesGroup, int NewRow)
        {
            AddUc(DesiredColumnIndexesGroup, NewRow);
        }
        void PurelyRemovingUcApp()
        {
            RemoveUc(null);
            CheckIfLastColumnsShouldBeRemoved();
        }
        int GetHourOfDesiredRow(int row)
        {
            return row / 4;
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


                ClassucAppointmentGrouping grouper = new ClassucAppointmentGrouping(TLPSchedule, null, OldColumnIndexGroupOfDesiredUC.Item2);
                ListAllConnectedUCsToTheOneWereRemoving = grouper.GetConnectedComponent(UCApointmentDraged);//it gives us a list of all connected uc in these columns to this ucappp 
                ListAllConnectedUCsToTheOneWereRemoving.Remove(UCApointmentDraged);//so now i have the list of the uc that are connecetd to this targeteduc, but without the targeteduc, so can compare it later on


                TLPSchedule.Controls.Remove(UCApointmentDraged);

            }
        }
        private void TLPSchedule_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

            Point clientPoint = TLPSchedule.PointToClient(new Point(e.X, e.Y));
            SetValuesthatWillAffectselection(clientPoint);
        }
        private void Uc1_UCAppIsDroped(object sender, EventArgs e)//kermel eza kabbayneha outside the bounds what to return it mahalla
        {
            Point cursorPosition = this.PointToClient(Cursor.Position);
            if (!TLPSchedule.ClientRectangle.Contains(cursorPosition))
            {
                TLPSchedule.Controls.Add(UCApointmentDraged, OldColumnofDraggedUC, OldRowOfDraggedUC);//lezim tekhlaa column aw tsayoo haddo
                ResetSelection();
            }
        }
        private void TLPSchedule_DragDrop(object sender, DragEventArgs e)
        {

            Point clientPoint = TLPSchedule.PointToClient(new Point(e.X, e.Y)); // Convert the screen coordinates to client coordinates
            (int column, int row) = GetCellPosition(TLPSchedule, clientPoint);

            if (ColumnIndexGroupOfDraggingUC != (null, null))
            {
                //adding
                if (UCApointmentDraged != null && column >= 1 && row >= 0)//first column for the timer
                {
                    (int StartingColumn, int EndingColumn, int StartingRow, int EndingRow) = GetRectangle4Points(row, ColumnIndexGroupOfDraggingUC);
                    List<UCappointment> NewListUC = GetListOfAllControlsInSpecifiedArea(StartingColumn, EndingColumn, StartingRow, EndingRow);//it  will give the list, without the uc we re adding

                    ClassucAppointmentGrouping grouper2 = new ClassucAppointmentGrouping(TLPSchedule, NewListUC, null);
                    Dictionary<int, List<UCappointment>> NewgroupedUCsCoverredByTheArea = grouper2.ClassifyGroupsThatAreConnected();
                    List<UCappointment> AllNewdUCInTheArea = NewgroupedUCsCoverredByTheArea.SelectMany(pair => pair.Value).ToList();



                    //Removing Mode
                    RemoveUc(AllNewdUCInTheArea);//mafina abel el add, lieanno ma32oul yse2ib bel old area, ykun intesects maa el ucapp li aam yonhatt in its new position
                                                 //so when we call el remove, we need to make ykun sure enno el appointment baaed ma nhatt, yaane ma aayetna baeed lal AddUc


                    AddUc(ColumnIndexGroupOfDraggingUC, row);


                    UCApointmentDraged.Dock = DockStyle.Fill;
                    UCApointmentDraged.isDragging = false;
                    UCApointmentDraged.Show();
                    UCApointmentDraged = null;

                    ResetSelection();
                }
                else
                {
                    TLPSchedule.Controls.Add(UCApointmentDraged, OldColumnofDraggedUC, OldRowOfDraggedUC);
                    ResetSelection();
                }
            }
            else
            {
                TLPSchedule.Controls.Add(UCApointmentDraged, OldColumnofDraggedUC, OldRowOfDraggedUC);
                ResetSelection();
            }
        }





        void AddUc((ClassEmployee, List<int>) DesiredColumnIndexesGroup, int NewRow)//eza from drag:DesiredGroupOfUC=GroupOfDraggingUC , eza by code:DesiredGroupOfUC=Shi nehna ha nebaato hasab wen aam naamil add or undo
        {

            Cursor = Cursors.WaitCursor;

            (int StartingColumn, int EndingColumn, int StartingRow, int EndingRow) = GetRectangle4Points(NewRow, DesiredColumnIndexesGroup);
            List<UCappointment> NewListUC = GetListOfAllControlsInSpecifiedArea(StartingColumn, EndingColumn, StartingRow, EndingRow);//it  will give the list, without the uc we re adding


            ClassucAppointmentGrouping grouper2 = new ClassucAppointmentGrouping(TLPSchedule, NewListUC, null);
            Dictionary<int, List<UCappointment>> NewgroupedUCsCoverredByTheArea = grouper2.ClassifyGroupsThatAreConnected();
            List<UCappointment> AllNewdUCInTheArea = NewgroupedUCsCoverredByTheArea.SelectMany(pair => pair.Value).ToList();



            bool IsUCAppScheduled;

            IsUCAppScheduled = FittingUCIfPlaceExist(StartingColumn, EndingColumn, StartingRow, EndingRow);

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

                IsUCAppScheduled = FittingUCIfPlaceExist(StartingColumn, EndingColumn, StartingRow, EndingRow);//now men baaed ma zabatna el row spans tb3 el ucappointments, sar fi mahal elo lal appointment


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
                    (StartingColumn, EndingColumn, StartingRow, EndingRow) = GetRectangle4Points(NewRow, DesiredColumnIndexesGroup);
                    FittingUCIfPlaceExist(StartingColumn, EndingColumn, StartingRow, EndingRow);


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

                    RemoveColumn(OldColumnIndexGroupOfDesiredUC.Item2[OldColumnIndexGroupOfDesiredUC.Item2.Count() - 1]);
                }

            }

        }
        void RemoveUc(List<UCappointment> AllNewdUCInTheArea)//it will be !=null only in dragdrop operation
        {
            //removing

            (int OldStartingColumn, int OldEndingColumn, int OldStartingRow, int OldEndingRow) = GetRectangle4Points(OldRowOfDraggedUC, OldColumnIndexGroupOfDesiredUC);//ejbare ouaa tshila, hole el values mestaamlin baaden
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

                            SetNewColumnSpanAndIndex(OldColumnIndexGroupOfDesiredUC, ListucAppointments, false);

                        }
                    }
                }



            }
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
                ExpandTableLayoutPanelColumn();
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
                ExpandTableLayoutPanelColumn();
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
        bool FittingUCIfPlaceExist(int StartingColumn, int EndingColumn, int StartingRow, int EndingRow)//this code is related RecursiveDrop, where we keep ( (startingcolumn++,endingColumn--) then call RecursiveDrop until needir nhotto lal appointment, aw eza jarabna all possible cases , and no empty spoy is available
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
                TLPSchedule.Controls.Add(UCApointmentDraged, StartingColumn, StartingRow);
                UCApointmentDraged.ColumnIndex = StartingColumn;
                UCApointmentDraged.RowIndex = StartingRow;
                TLPSchedule.SetColumnSpan(UCApointmentDraged, (EndingColumn - StartingColumn) + 1);
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
        (int, int, int, int) GetRectangle4Points(int DesiredRow, (ClassEmployee, List<int>) desiredIndexesGroup)
        {
            int StartingColumn = desiredIndexesGroup.Item2[0];//in case  NULLLLLLLL bcz of debugging mode mesh aktar
            int EndingColumn = desiredIndexesGroup.Item2[desiredIndexesGroup.Item2.Count - 1];


            int StartingRow = DesiredRow;
            int EndingRow = DesiredRow + TLPSchedule.GetRowSpan(UCApointmentDraged) - 1;

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



        public void ExpandTableLayoutPanelColumn()
        {

            int OriginalWidthOfDesiredGroup = UCappointment.OriginalWidth * FocusOnColumnIndexGroup.Item2.Count;

            int DesiredWidthOfTheGroup = OriginalWidthOfDesiredGroup < FocusOnMaxWidth ? OriginalWidthOfDesiredGroup : FocusOnMaxWidth;


            int DesiredWidthPerColumn = DesiredWidthOfTheGroup / FocusOnColumnIndexGroup.Item2.Count;

            foreach (int ColumnIndex in FocusOnColumnIndexGroup.Item2)
            {
                TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Absolute, DesiredWidthPerColumn);
            }
        }
        void ResizeTableLayoutPanelToPerc()
        {
            float PercentageOfEachGroup = 100 / ListOfAllColumnIndexesGroups.Count;

            foreach ((ClassEmployee, List<int>) Group in ListOfAllColumnIndexesGroups)
            {
                float PercentageOfEachColumn = PercentageOfEachGroup / Group.Item2.Count;

                foreach (int ColumnIndex in Group.Item2)
                {
                    TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
                }
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
                if (currentGroup == hoveredGroup && (ColumnIndexGroupOfDraggingUC != (null, null) && ColumnIndexGroupOfDraggingUC.Item2.Contains(e.Column)))
                {

                    g.FillRectangle(hoverBrush, r);
                }
            }
            else
            {
                if ((e.Row >= hoveredCellColmnRow.Item2 && e.Row < (hoveredCellColmnRow.Item2 + NbrRowShouldPass)) && (ColumnIndexGroupOfDraggingUC != (null, null) && ColumnIndexGroupOfDraggingUC.Item2.Contains(e.Column)))
                {

                    g.FillRectangle(hoverBrush, r);

                    //if (e.Row == hoveredCellColmnRow.Item2 && e.Column== ColumnIndexGroupOfDraggingUC.Item2[0])
                    //{

                    //    string textToDraw = "12:00 am";
                    //    Rectangle spanRect = new Rectangle(r.X, r.Y, r.Width * 2, r.Height);

                    //    // Define the format for the text
                    //    using (StringFormat sf = new StringFormat())
                    //    {
                    //        sf.Alignment = StringAlignment.Center; // Horizontal alignment
                    //        sf.LineAlignment = StringAlignment.Center; // Vertical alignment

                    //        // Define the brush and font for the text
                    //        using (Brush textBrush = new SolidBrush(Color.Gray))
                    //        using (Font textFont = new Font("Arial", 12, FontStyle.Regular))
                    //        {
                    //            g.DrawString(textToDraw, textFont, textBrush, r, sf);
                    //        }
                    //    }
                    //}
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
            TLPSchedule.Invalidate();
        }




    }


}
