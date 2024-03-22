
using System.Drawing;
using System.Windows.Forms;

namespace CustomizedTools
{
    public class DoubleBufferAndCustomScrollDataGrid : DataGridView
    {
      

        private bool isCustomScroll=true;
        public bool IsCustomScroll
        {
            get { return isCustomScroll; }
            set { isCustomScroll = value; }
        }

        public DoubleBufferAndCustomScrollDataGrid()
        {
            DoubleBuffered = true;       
        }
         protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseEnter(e);

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = this.Rows[e.RowIndex].Cells[e.ColumnIndex];

                //if (!this.Focused) this.Focus();

                if (cell.Value is Image)
                {
                    cell.ToolTipText = "";
                    //cell.ToolTipText= cell.OwningColumn.Name;
                }
                else
                {
                   using (Graphics graphics = this.CreateGraphics())
                    {
                        SizeF textSize = graphics.MeasureString(cell.ToolTipText, this.Font);

                        if (textSize.Width > cell.Size.Width)
                        {
                            cell.ToolTipText = cell.FormattedValue.ToString(); ;
                        }
                        else
                        {
                            cell.ToolTipText = "";
                        }
                    }
                }
            }
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (IsCustomScroll)
            {
                if (e.Delta > 0)//Scroll up
                {
                    if (FirstDisplayedScrollingRowIndex > 0)
                    {
                        FirstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex - 1;
                    }
                }
                else//scroll down
                {
                    if(FirstDisplayedScrollingRowIndex + 1<this.RowCount)

                    FirstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex + 1;
                }

            }
            else
            {
                base.OnMouseWheel(e);
            }
        }
    
    }
}
