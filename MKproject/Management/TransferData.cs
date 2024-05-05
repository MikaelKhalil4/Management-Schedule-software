
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using GlobalFunctions;
using MKproject.Schedule;

namespace MKproject.Management
{

    public partial class TransferData : Form
    {


        TableLayoutPanelDoubleBufferedNoscroll TLPSchedule;
        UCappointment UCApointmentDraged;

        List<(ClassEmployee, List<int>)> AllIndexesGroupList = new List<(ClassEmployee, List<int>)>();


        (ClassEmployee, List<int>) DesiredIndexesGroup = (null, null);//stores the index columns Related To dame employee 

        private (int, int) hoveredCellColmnRow = (-1, -1);  // Stores the  (column,row) of the hovered cell
        private (int, int) OldUCColumnRow = (-1, -1); //Stores the old postion of Draged Control

        int NbreofRowsHighlighted = -1;

        Brush hoverBrush = new SolidBrush(Color.LightGray); // Change the color as needed

        public TransferData()
        {
            InitializeComponent();




            List<ClassEmployee> ListEmployeeSchedule = ClassEmployee.GetEmployeeScheduleMemberASC();

            //these indexes value, should initially be t Setbased on the ranks and on there s more then 2 appointment in the same hour, and any changes dureing the way, this list will be modifid , and apply to it one of the AppPercentage Design
            List<int> Employee0 = new List<int>() { 1, 2 };
            List<int> Employee1 = new List<int>() { 3, 4 };
            List<int> Employee2 = new List<int>() { 5, 6 };
            List<int> Employee3 = new List<int>() { 7, 8, 9 };
            List<int> Employee4 = new List<int>() { 10 };
            List<int> Employee5 = new List<int>() { 11, 12 };

            AllIndexesGroupList.Add((ListEmployeeSchedule[0], Employee0));
            AllIndexesGroupList.Add((ListEmployeeSchedule[1], Employee1));
            AllIndexesGroupList.Add((ListEmployeeSchedule[2], Employee2));

            AllIndexesGroupList.Add((ListEmployeeSchedule[3], Employee3));
            AllIndexesGroupList.Add((ListEmployeeSchedule[4], Employee4));
            AllIndexesGroupList.Add((ListEmployeeSchedule[5], Employee5));


            CreateTLP();//before creating our TLP we need AllIndexesGroupList
            UCappointment uc1;
            for (int i = 1; i < 25; i++)
            {
                uc1 = new UCappointment();
                uc1.Dock = DockStyle.Fill;
                TLPSchedule.Controls.Add(uc1, 1, i + 4);
                TLPSchedule.SetRowSpan(uc1, 4);
            }


            uc1 = new UCappointment();
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.Controls.Add(uc1, 2, 3);
            TLPSchedule.SetRowSpan(uc1, 6);

            uc1 = new UCappointment();
            TLPSchedule.Controls.Add(uc1, 1, 8);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 4);

            uc1 = new UCappointment();
            TLPSchedule.Controls.Add(uc1, 7, 10);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 6);

            uc1 = new UCappointment();
            TLPSchedule.Controls.Add(uc1, 8, 10);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 6);

            uc1 = new UCappointment();
            TLPSchedule.Controls.Add(uc1, 9, 10);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 6);

            uc1 = new UCappointment();
            TLPSchedule.Controls.Add(uc1, 10, 8);
            uc1.Dock = DockStyle.Fill;
            TLPSchedule.SetRowSpan(uc1, 6);




            ResizeTableLayoutPanelToPerc();
            //ExpandTableLayoutPanelColumn(AllIndexesGroupList[2], 700);
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

        private void TLPSchedule_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            NbreofRowsHighlighted = 1;

            Point clientPoint = TLPSchedule.PointToClient(new Point(e.X, e.Y));
            SetValuesthatweillAffectselection(clientPoint);
        }
        private void TLPSchedule_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            UCApointmentDraged = e.Data.GetData(typeof(UCappointment)) as UCappointment;
            if (UCApointmentDraged.Parent != null)
            {
                OldUCColumnRow = (TLPSchedule.GetColumn(UCApointmentDraged), TLPSchedule.GetRow(UCApointmentDraged));
                TLPSchedule.Controls.Remove(UCApointmentDraged);

            }
        }
        private void TLPSchedule_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = TLPSchedule.PointToClient(new Point(e.X, e.Y));   // Convert the screen coordinates to client coordinates

            (int column, int row) = GetCellPosition(TLPSchedule, clientPoint);


            if (UCApointmentDraged != null && column >= 0 && row >= 0)
            {
               


                int StartingRow = row;
                int EndingRow = row+TLPSchedule.GetRowSpan(UCApointmentDraged);

                int StartingColumn = DesiredIndexesGroup.Item2[0];
                int EndingColumn = DesiredIndexesGroup.Item2[DesiredIndexesGroup.Item2.Count - 1];
              
                bool OtherUCExists = false; ;
             
               
                for(int i= StartingRow; i < EndingRow; i++)
                {
                   for (int j = StartingColumn; j < EndingColumn; j++)
                    {
                        Control foundControl = GetControlFromPositionWithSpan(j, i);//we re checking each cell eza fiya shi, which will cover the whole area of the usercontrol
                        if (foundControl != null)
                        {
                            OtherUCExists = true;
                        }                     
                    }
                }

                if (!OtherUCExists)
                {
                    TLPSchedule.Controls.Add(UCApointmentDraged, StartingColumn, StartingRow);
                    TLPSchedule.SetColumnSpan(UCApointmentDraged, (EndingColumn- StartingColumn)+1);
                }
                else
                {
                    TLPSchedule.Controls.Add(UCApointmentDraged, column, row);//lezim tekhlaa column aw tsayoo haddo
                }



                UCApointmentDraged.Dock = DockStyle.Fill;
                UCApointmentDraged.isDragging = false;
                UCApointmentDraged.Show();
                UCApointmentDraged = null;

                ResetSelection();
            }
        }
        private Control GetControlFromPositionWithSpan(int checkCol, int checkRow)//check for these specific indexes, eza fi hdn aalayun
        {
            foreach (Control control in TLPSchedule.Controls)
            {
                int startColumn = TLPSchedule.GetColumn(control);
                int startRow = TLPSchedule.GetRow(control);

                int columnSpan = TLPSchedule.GetColumnSpan(control);
                int rowSpan = TLPSchedule.GetRowSpan(control);

                // Check if the control spans over the checked cells (column and row of the cell)
                if (startColumn <= checkCol && (startColumn + columnSpan) > checkCol &&
                    startRow <= checkRow && (startRow + rowSpan) > checkRow)
                {
                    return control;
                }
            }
            return null; // No control found spanning this position
        }




        private void TLPSchedule_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {


            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;


            int NbrRowShouldPass;
            int currentGroup=-1;
            int hoveredGroup=-1;
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
                if (currentGroup == hoveredGroup && (DesiredIndexesGroup != (null, null) && DesiredIndexesGroup.Item2.Contains(e.Column)))
                {

                    g.FillRectangle(hoverBrush, r);
                }
            }
              else
            {
                if ((e.Row>= hoveredCellColmnRow.Item2 && e.Row< (hoveredCellColmnRow.Item2+ NbrRowShouldPass)) && (DesiredIndexesGroup != (null, null) && DesiredIndexesGroup.Item2.Contains(e.Column)))
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
            SetValuesthatweillAffectselection(e.Location);
        }
        private void TLPSchedule_MouseLeave(object sender, EventArgs e)
        {
            ResetSelection();
        }

        //private void InvalidateSpecificCells()
        //{
        //    // Find the desired group of column indices
        //    List<int> columnIndices = null;
        //    foreach (var group in AllIndexesGroupList)
        //    {
        //        if (group.Item2.Contains(hoveredCell.Item1))
        //        {
        //            columnIndices = group.Item2;
        //            break;
        //        }
        //    }
        //    if (columnIndices == null)
        //        return; // No columns found, nothing to do)

        //    // Calculate the group index for rows
        //    int hoveredGroup = hoveredCell.Item2 / NbreofRowsHighlighted;



        //    int NbrRowShouldPass;
        //    if (UCApointmentDraged != null)
        //    {
        //        NbrRowShouldPass = TLPSchedule.GetRowSpan(UCApointmentDraged);

        //    }
        //    else
        //    {
        //        NbrRowShouldPass = NbreofRowsHighlighted;
        //    }


        //    for (int row = 0; row < TLPSchedule.RowCount; row++)
        //    {
        //        int rowGroup = row / NbreofRowsHighlighted;

        //        if (rowGroup == hoveredGroup)
        //        {
        //            for (int i = 0; i < NbrRowShouldPass; i++)
        //            {
        //                foreach (int col in columnIndices)
        //                {
        //                    if (col < TLPSchedule.ColumnCount)
        //                    {
        //                        // Calculate the cell bounds
        //                        Rectangle cellBounds = GetCellBounds(col, row);
        //                        TLPSchedule.Invalidate(cellBounds, false); // Invalidate cell
        //                    }
        //                }
        //            }
        //            break;
        //        }
        //    }
        //}

        //private Rectangle GetCellBounds(int column, int row)
        //{
        //    // Calculate the cell bounds within the table layout panel
        //    Rectangle cellRect = new Rectangle();
        //    Control control = TLPSchedule.GetControlFromPosition(column, row);
        //    if (control != null)
        //    {
        //        cellRect = new Rectangle(control.Location, control.Size);
        //    }
        //    return cellRect;
        //}



        void SetValuesthatweillAffectselection(Point Loaction)
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
                        DesiredIndexesGroup = AllIndexesGroupList[WhichEmployee];
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
            DesiredIndexesGroup = (null, null);
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







    }


}
