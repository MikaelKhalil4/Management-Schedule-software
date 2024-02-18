
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
