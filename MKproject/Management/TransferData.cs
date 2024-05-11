
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
        
        List<(ClassEmployee, List<int>)> ListOfAlIGroups = new List<(ClassEmployee, List<int>)>();


        (ClassEmployee, List<int>) OldGroupOfDraggedUC;
        int OldColumn;//old column is the exact column li ken aalaya el uc
      
        
        
        int OldStartingColumn;//haya el old colmn mesh el exact, as enno men awwal column tb3 el hayda employee
        int OldEndingColumn;
        int OldStartingRow;
        int OldEndingRow;


        List<UCappointment> ListAllConnectedUCsToTheOneWereRemoving;//this serpent doesn tonly cover the area of the removed uc, but also outside the are, which
                                                                  //Which we care about , because the one we dont see could cause us problems, that s why the one we dont see if they exist, we dont do the auto size



        UCappointment UCApointmentDraged;
        (ClassEmployee, List<int>) GroupOfDraggedUC = (null, null);//stores the index columns Related To employee , when we re dragging a uc
        private (int, int) hoveredCellColmnRow = (-1, -1);  // Stores the  (column,row) of the hovered cell


        int NbreofRowsHighlighted = -1;//how many rows we need to highlight while mouse hover or dragging
        Brush hoverBrush = new SolidBrush(Color.LightGray); // Change the color as needed



        public TransferData()
        {
            InitializeComponent();




            List<ClassEmployee> ListEmployeeSchedule = ClassEmployee.GetEmployeeScheduleMemberASC();

            //these indexes value, should initially be t Setbased on the ranks and on there s more then 2 appointment in the same hour, and any changes dureing the way, this list will be modifid , and apply to it one of the AppPercentage Design
            List<int> Employee0 = new List<int>() { 1 };
            List<int> Employee1 = new List<int>() { 2};
            List<int> Employee2 = new List<int>() { 3};
            List<int> Employee3 = new List<int>() { 4 };
            List<int> Employee4 = new List<int>() { 5 };
            List<int> Employee5 = new List<int>() { 6 };

            ListOfAlIGroups.Add((ListEmployeeSchedule[0], Employee0));
            ListOfAlIGroups.Add((ListEmployeeSchedule[1], Employee1));
            ListOfAlIGroups.Add((ListEmployeeSchedule[2], Employee2));

            ListOfAlIGroups.Add((ListEmployeeSchedule[3], Employee3));
            ListOfAlIGroups.Add((ListEmployeeSchedule[4], Employee4));
            ListOfAlIGroups.Add((ListEmployeeSchedule[5], Employee5));


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
            //ExpandTableLayoutPanelColumn(ListOfAlIGroups[3], 700);
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

            foreach ((ClassEmployee, List<int>) Group in ListOfAlIGroups)
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
                OldGroupOfDraggedUC = GetWichDesiredIndexesGroup(OldColumn);

                (OldStartingColumn, OldEndingColumn, OldStartingRow, OldEndingRow) = GetRectangle4Points(TLPSchedule.GetRow(UCApointmentDraged), OldGroupOfDraggedUC);//ejbare ouaa tshila, hole el values mestaamlin baaden

                ClassucAppointmentGrouping grouper = new ClassucAppointmentGrouping(TLPSchedule, null, OldGroupOfDraggedUC.Item2);
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
        private void Uc1_UCAppIsDroped(object sender, EventArgs e)//kermel eza kabbayneha outside the bounds what to,
        {
            Point cursorPosition = this.PointToClient(Cursor.Position);
            if (!TLPSchedule.ClientRectangle.Contains(cursorPosition))
            {
                TLPSchedule.Controls.Add(UCApointmentDraged, OldColumn, OldStartingRow);//lezim tekhlaa column aw tsayoo haddo
                ResetSelection();
            }
        }
    
        
        
        private void TLPSchedule_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = TLPSchedule.PointToClient(new Point(e.X, e.Y)); // Convert the screen coordinates to client coordinates
            (int column, int row) = GetCellPosition(TLPSchedule, clientPoint);
           
            
            (int StartingColumn, int EndingColumn, int StartingRow, int EndingRow) = GetRectangle4Points(row, GroupOfDraggedUC);
            List<UCappointment> NewListUC = GetListOfAllControlsInSpecifiedArea(StartingColumn, EndingColumn, StartingRow, EndingRow);//it  will give the list, without the uc we re adding
           
            
            ClassucAppointmentGrouping grouper2 = new ClassucAppointmentGrouping(TLPSchedule, NewListUC, null);
            Dictionary<int, List<UCappointment>> NewgroupedUCsCoverredByTheArea = grouper2.ClassifyGroupsThatAreConnected();
            List<UCappointment> AllNewdUCInTheArea = NewgroupedUCsCoverredByTheArea.SelectMany(pair => pair.Value).ToList();




            //removing
            List<UCappointment> OldListUC = GetListOfAllControlsInSpecifiedArea(OldStartingColumn, OldEndingColumn, OldStartingRow, OldEndingRow);//it will give the list, without the uc we re removing
            ClassucAppointmentGrouping grouper1 = new ClassucAppointmentGrouping(TLPSchedule, OldListUC, null);
            Dictionary<int, List<UCappointment>> OldGroupedUCsCoverByTheArea = grouper1.ClassifyGroupsThatAreConnected();
            List<UCappointment> AllOldUCInTheArea = OldGroupedUCsCoverByTheArea.SelectMany(pair => pair.Value).ToList();


            //ListSerpentConnectedUCsBeforeRemoving.Count > 0 , eza men matrah ma aam nshila ma ken connected cotrols ela ma darure naamil shi
            // !ListsHaveSameElements(AllOldUC, AllNewdUC) , eza eendun same elements, yaane shelneha w radayneha mahalla, no need to perform the reomove operation
            //ListsHaveSameElements(AllOldUCInTheArea, ListAllConnectedUCsToTheOneWereRemoving), eza ma keno metel baaed, yaane el fi hidden controls related lal groups juwwet OldGroupedUCsCoverByTheArea,
            //bas mesh mbaynin, lieannoun mannun covered by the area,which will cause errors fetna bel function
           
            if (ListAllConnectedUCsToTheOneWereRemoving.Count > 0 && ListsHaveSameElements(AllOldUCInTheArea, ListAllConnectedUCsToTheOneWereRemoving) && !ListsHaveSameElements(AllOldUCInTheArea, AllNewdUCInTheArea))
            {
                foreach (KeyValuePair<int, List<UCappointment>> Oldentry in OldGroupedUCsCoverByTheArea)
                {
                    if (!CheckColumnOverlappingUcApp(Oldentry.Value))//Only GOOD SERPENT I FIX THEM
                    {
                        List<UCappointment> ListucAppointments = Oldentry.Value;

                        SetNewColumnSpanAndIndex(OldGroupOfDraggedUC, ListucAppointments, false);

                    }
                }
            }






            //adding
            if (UCApointmentDraged != null && column >= 1 && row >= 0)
            {
                Cursor = Cursors.WaitCursor;
                bool IsUCAppScheduled;


                IsUCAppScheduled = FittingUCIfPlaceExist(StartingColumn, EndingColumn, StartingRow, EndingRow);

                if (!IsUCAppScheduled)
                {

                    Dictionary<int, List<(int, int)>> OriginalCoulunIndexAndSpanForEachGroup = new Dictionary<int, List<(int, int)>>();//inside the list the original spans are ordered like the list appointmnent

                    foreach (KeyValuePair<int, List<UCappointment>> entry in NewgroupedUCsCoverredByTheArea)//lama ykuno hadd baeed bi tariea mafhume
                    {
                        OriginalCoulunIndexAndSpanForEachGroup.Add(entry.Key, new List<(int, int)>());
                        foreach (UCappointment uc in entry.Value)
                        {
                            int OriginalIndex = uc.ColumnIndex;
                            int originalSpan = TLPSchedule.GetColumnSpan(uc);
                            OriginalCoulunIndexAndSpanForEachGroup[entry.Key].Add((OriginalIndex, originalSpan));

                        }

                        //if (ListsHaveSameElements(entry.Value, EachGroupWithItsSerpents[entry.Key]))
                        //{
                        bool OverLapByColumnsExists;//bad serpent
                        if (entry.Value.Count() > 2)
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

                            SetNewColumnSpanAndIndex(GroupOfDraggedUC, entry.Value, true);
                        }
                        else
                        {

                            foreach (UCappointment uc in entry.Value)
                            {
                                int originalSpan = TLPSchedule.GetColumnSpan(uc);
                                if (originalSpan > 1)
                                {
                                    TLPSchedule.SetColumnSpan(uc, originalSpan - 1);
                                }
                            }
                        }
                        //}

                    }//foreach ejbare hone tekhlas

                    //after fixing the span of all affected groups, we try to fit it

                    IsUCAppScheduled = FittingUCIfPlaceExist(StartingColumn, EndingColumn, StartingRow, EndingRow);//now men baaed ma zabatna el row spans tb3 el ucappointments, sar fi mahal elo lal appointment



                    Dictionary<int, List<UCappointment>> EachGroupWithItsSerpents = new Dictionary<int, List<UCappointment>>();
                    ClassucAppointmentGrouping grouper = new ClassucAppointmentGrouping(TLPSchedule, null, GroupOfDraggedUC.Item2);//it will give all the uc , including the one we added
                    foreach (KeyValuePair<int, List<UCappointment>> entry in NewgroupedUCsCoverredByTheArea)
                    {
                        List<UCappointment> ListSerpentConnectedUCsBeforeAdding = grouper.GetConnectedComponent(entry.Value[0]);//bi hemne one uc men kell small serpent , ta eedar ekmush the whole serpent
                                                                                                                                // Add the key and the connected components to the dictionary
                        EachGroupWithItsSerpents.Add(entry.Key, ListSerpentConnectedUCsBeforeAdding);
                    }


                    //first condition eza ken fi groups w zabtna el span tb3un bas ma elo mahal, secd condition eza sar fi error bel design
                    if (!IsUCAppScheduled && NewgroupedUCsCoverredByTheArea.Count > 0 || (IsUCAppScheduled && !CheckIfUCIsIntheRightColumn(EachGroupWithItsSerpents)))//resetting to oginal spans, eza ma le2a mahal yoeuud fi el appointment
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
                        int ColumnToInsert = GroupOfDraggedUC.Item2[GroupOfDraggedUC.Item2.Count() - 1] + 1;
                        InsertColumn(ColumnToInsert);
                        (StartingColumn, EndingColumn, StartingRow, EndingRow) = GetRectangle4Points(row, GroupOfDraggedUC);
                        FittingUCIfPlaceExist(StartingColumn, EndingColumn, StartingRow, EndingRow);


                        // optimization check here
                        Stack<UCappointment> stack = new Stack<UCappointment>();//this stackis mde to prevent repition, since for a range of rows we can pass by the same uc
                        ClassucAppointmentGrouping grouperInsert = new ClassucAppointmentGrouping(TLPSchedule, null, GroupOfDraggedUC.Item2);//aam nekhlae el ajdency tb3 the whol DesiredgroupIndexes

                        for (int rows = 0; rows < TLPSchedule.RowCount; rows++)//we need to change all the span of ucs groups in same DesiredIndexGroup(Same Big Column or Employee), ella AffectedGroup li already tghayaro foe
                        {
                            UCappointment ucapp = (UCappointment)TLPSchedule.GetControlFromPosition(ColumnToInsert - 1, rows);
                            if (ucapp != null)
                            {
                                bool UcInTheAffectedGroups = false;
                                foreach (KeyValuePair<int, List<UCappointment>> entry in EachGroupWithItsSerpents)
                                {
                                    if (entry.Value.Contains(ucapp))
                                    {
                                        UcInTheAffectedGroups = true;//el affected groups ma mnaamul span aw shi, lieanno henne naamalo foe, 
                                    }
                                }
                                if (!UcInTheAffectedGroups && (stack.Count == 0 || stack.Count > 0 && stack.Peek().DesiredAppointmentUCApp.AppointmentID != ucapp.DesiredAppointmentUCApp.AppointmentID))
                                {
                                    stack.Push(ucapp);//we use stack kermel naadil only once aal groups , mesh aa kell row naadela

                                    List<UCappointment> ListSerpentConnectedUCs = grouperInsert.GetConnectedComponent(ucapp);//it gives us a list of all connected uc in these columns to this ucappp 

                                    if (CheckColumnOverlappingUcApp(ListSerpentConnectedUCs))
                                    {
                                        TLPSchedule.SetColumnSpan(ucapp, TLPSchedule.GetColumnSpan(ucapp) + 1);

                                    }
                                    else
                                    {
                                        SetNewColumnSpanAndIndex(GroupOfDraggedUC, ListSerpentConnectedUCs, false);
                                    }
                                }

                            }


                        }
                    }
                }


                //ma32oul yseebo sawa, in the same group of columns

                int BigColumnCount = OldGroupOfDraggedUC.Item2.Count();
                Queue<UCappointment> QueueUCApp= new Queue<UCappointment>();//this one will be used ,to fix the columns span affected by remiving the last column
                Stack<UCappointment> stackucApp = new Stack<UCappointment>();//this stackis mde to prevent repition, since for a range of rows we can pass by the same uc
                if (BigColumnCount > 1)
                {

                    int LastColumn = OldGroupOfDraggedUC.Item2[BigColumnCount - 1];

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

                        RemoveColumn(OldGroupOfDraggedUC.Item2[OldGroupOfDraggedUC.Item2.Count() - 1]);                    
                    }

                }

                UCApointmentDraged.Dock = DockStyle.Fill;
                UCApointmentDraged.isDragging = false;
                UCApointmentDraged.Show();
                UCApointmentDraged = null;

                ResetSelection();
                Cursor = Cursors.Default;

            }
            else
            {
                TLPSchedule.Controls.Add(UCApointmentDraged, OldColumn, OldStartingRow);
                ResetSelection();
            }
        }



        private void InsertColumn(int columnIndex)
        {
            TLPSchedule.ColumnCount++;

            //finding the desiredIndexesgroup
            int i;
            for (i = 0; i < ListOfAlIGroups.Count; i++)
            {
                if (ListOfAlIGroups[i].Item2.Contains(columnIndex - 1))
                {
                    ListOfAlIGroups[i].Item2.Add(columnIndex);

                    i++;
                    break;
                }

            }


            //fixing the size
            (ClassEmployee, List<int>) TargetedIndexesGroup = ListOfAlIGroups[i - 1];
            float PercentageOfEachGroup = 100 / ListOfAlIGroups.Count;
            float PercentageOfEachColumn = PercentageOfEachGroup / TargetedIndexesGroup.Item2.Count;

            TLPSchedule.ColumnStyles.Insert(columnIndex, new ColumnStyle(SizeType.Percent, PercentageOfEachColumn));

            foreach (int ColumnIndex in TargetedIndexesGroup.Item2)
            {
                TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
            }

            //fixing the calues in AllIndexesGroupList 
            while (i < ListOfAlIGroups.Count)
            {
                for (int j = 0; j < ListOfAlIGroups[i].Item2.Count; j++)
                {
                    ListOfAlIGroups[i].Item2[j]++;
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
            for (i = 0; i < ListOfAlIGroups.Count; i++)
            {
                if (ListOfAlIGroups[i].Item2.Contains(columnIndex - 1))
                {
                    ListOfAlIGroups[i].Item2.Remove(columnIndex);

                    i++;
                    break;
                }
            }

            //fixing the size
            (ClassEmployee, List<int>) TargetedIndexesGroup = ListOfAlIGroups[i - 1];
            float PercentageOfEachGroup = 100 / ListOfAlIGroups.Count-1;
            float PercentageOfEachColumn = PercentageOfEachGroup / TargetedIndexesGroup.Item2.Count;

            TLPSchedule.ColumnStyles.RemoveAt(columnIndex);

            foreach (int ColumnIndex in TargetedIndexesGroup.Item2)
            {
                TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn );
            }

            //fixing the calues in AllIndexesGroupList 
            while (i < ListOfAlIGroups.Count)
            {
                for (int j = 0; j < ListOfAlIGroups[i].Item2.Count; j++)
                {
                    ListOfAlIGroups[i].Item2[j]--;
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



        void SetNewColumnSpanAndIndex((ClassEmployee, List<int>) DesiredIndexesGroup, List<UCappointment> ListucAppointments, bool IsAddingMode)//based ayya employee w nehna w el targeted controls baddun tozbit Span and index
        {
            int totalSpan= DesiredIndexesGroup.Item2.Count;
            int NewNumOfUCs = ListucAppointments.Count ;
          
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
        public bool CheckColumnOverlappingUcApp(List<UCappointment> ucAppList)//kermel naarif eza controls inside  listofserpent, eemlin column overlapp => bad serpent, we handle it in a specific way 
        {
            // Sort appointments by start column to make overlap detection easier
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




        bool ListsHaveSameElements(List<UCappointment> list1, List<UCappointment> list2)
        {
            var sortedList1 = list1.OrderBy(x => x.DesiredAppointmentUCApp.AppointmentID).ToList();
            var sortedList2 = list2.OrderBy(x => x.DesiredAppointmentUCApp.AppointmentID).ToList();
            return sortedList1.SequenceEqual(sortedList2);
        }
        (ClassEmployee, List<int>) GetWichDesiredIndexesGroup(int StartingColumn)
        {
            int WhichEmployee = 0;
            foreach ((ClassEmployee, List<int>) Group in ListOfAlIGroups)
            {
                if (Group.Item2.Contains(StartingColumn))
                {
                    return ListOfAlIGroups[WhichEmployee];
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
                if (currentGroup == hoveredGroup && (GroupOfDraggedUC != (null, null) && GroupOfDraggedUC.Item2.Contains(e.Column)))
                {

                    g.FillRectangle(hoverBrush, r);
                }
            }
            else
            {
                if ((e.Row >= hoveredCellColmnRow.Item2 && e.Row < (hoveredCellColmnRow.Item2 + NbrRowShouldPass)) && (GroupOfDraggedUC != (null, null) && GroupOfDraggedUC.Item2.Contains(e.Column)))
                {

                    g.FillRectangle(hoverBrush, r);
                }
            }





            ////Check if we're in the last column; if not, don't draw vertical lines
            if (e.Column < TLPSchedule.ColumnCount)
            {
                foreach ((ClassEmployee, List<int>) va in ListOfAlIGroups)
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
                foreach ((ClassEmployee, List<int>) Group in ListOfAlIGroups)
                {
                    if (Group.Item2.Contains(hoveredCellColmnRow.Item1))
                    {
                        GroupOfDraggedUC = ListOfAlIGroups[WhichEmployee];
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
            GroupOfDraggedUC = (null, null);
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
            float PercentageOfEachGroup = 100 / ListOfAlIGroups.Count;

            foreach ((ClassEmployee, List<int>) Group in ListOfAlIGroups)
            {
                float PercentageOfEachColumn = PercentageOfEachGroup / Group.Item2.Count;

                foreach (int ColumnIndex in Group.Item2)
                {
                    TLPSchedule.ColumnStyles[ColumnIndex] = new ColumnStyle(SizeType.Percent, PercentageOfEachColumn);
                }
            }
        }

        
    }


}
