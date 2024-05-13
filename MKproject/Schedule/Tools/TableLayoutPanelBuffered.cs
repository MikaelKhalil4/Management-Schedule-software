using System;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public class TableLayoutPanelBuffered : TableLayoutPanel
    {
        public VScrollBar VerticalScrollBarTable { get; set; }
        public TableLayoutPanelBuffered PanelAppointment { get; set; }
        public TableLayoutPanelBuffered PanelUCTime { get; set; }
        public TableLayoutPanelBuffered()
        {
            AutoScroll = true;
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



        public int currentRow = 0;
        public int rowHeight = 0;
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            //rowHeight = this.GetRowHeights()[0]; // Assuming a static row height for simplicity

            //// Determine if we're scrolling up or down
            //if (e.Delta > 0)
            //{
            //    // Scrolling up
            //    currentRow = Math.Max(0, currentRow - 4);
            //}
            //else
            //{
            //    // Scrolling down
            //    currentRow = Math.Min(this.RowCount - GetVisibleRowsCount(), currentRow + 4);
            //}
        }

        public int GetVisibleRowsCount()
        {
            // Check if the TableLayoutPanel has rows
            if (this.RowCount == 0)
                return 0;


            int visibleHeight = this.ClientSize.Height;
            // Calculate the number of visible rows
            int visibleRowsCount = (visibleHeight / rowHeight);
            return visibleRowsCount;
        }

    }
}
