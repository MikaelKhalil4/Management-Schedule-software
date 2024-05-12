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
        protected override void WndProc(ref Message m)//hide sroll bars
        {
            // WM_NCCALCSIZE = 0x83
            // WM_NCPAINT = 0x85
            if (m.Msg == 0x83 || m.Msg == 0x85)
            {
                return;
            }
            base.WndProc(ref m);
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
            //if (this.AutoScroll == false)//la kel li ma byaeemlo scroll krmel ma yeneeamal error men lasel
            //{

            //}
            //else
            //{
                //base.OnMouseWheel(e);
                rowHeight = this.GetRowHeights()[0]; // Assuming a static row height for simplicity

                // Determine if we're scrolling up or down
                if (e.Delta > 0)
                {
                    // Scrolling up
                    currentRow = Math.Max(0, currentRow - 4);
                }
                else
                {
                    // Scrolling down
                    currentRow = Math.Min(this.RowCount - GetVisibleRowsCount(), currentRow + 4);
                }

                // Ensure we're not exceeding the maximum allowable value
                int newValue = currentRow * rowHeight;

                AutoScroll = false;
                this.VerticalScroll.Value = Math.Min(newValue, this.VerticalScroll.Maximum);//the maximum value is autotaken when autoscroll is on, if not we need to initialise it awwal shi, that s why ha nestaamil autoscrollw nkhabbiya
                VerticalScrollBarTable.Value = Math.Min(newValue, this.VerticalScroll.Maximum);
                if (PanelAppointment != null)
                {
                    PanelAppointment.VerticalScroll.Value = Math.Min(newValue, this.VerticalScroll.Maximum);
                }
                if (PanelUCTime != null)
                {
                    PanelUCTime.VerticalScroll.Value = Math.Min(newValue, this.VerticalScroll.Maximum);
                }
                AutoScroll = true;



                Console.WriteLine("Value: " + this.VerticalScroll.Value + "\nMax= " + this.VerticalScroll.Maximum + "\n");
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
