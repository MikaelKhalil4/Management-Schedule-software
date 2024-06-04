using System;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public class CustomFlowLayoutPanel : FlowLayoutPanel
    {
        public int currentRowIndex = 0;
        int totalControlHeight = 0;
        public bool IsCustomScrolled { get; set; }
        public bool IsDoubleBuffer { get; set; }
        public CustomFlowLayoutPanel()
        {
       
            this.AutoScroll = true;
            this.Scroll += CustomFlowLayoutPanel_Scroll;
        }

       public void SetScrollIndex()
        {
            int thumbPosition = VerticalScroll.Value;
            totalControlHeight = this.Controls[0].Height + this.Controls[0].Margin.Top + this.Controls[0].Margin.Bottom;
            currentRowIndex = thumbPosition / totalControlHeight;
        }
        private void CustomFlowLayoutPanel_Scroll(object sender, ScrollEventArgs e)
        {
            if (IsCustomScrolled)
            {
                SetScrollIndex();
            }
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (IsCustomScrolled)
            {
                if (VerticalScroll.Visible)
                {
                    //base.OnMouseWheel(e);
                    int MaxRows = GetMaxRows();
                    if (this.Controls.Count == 0)
                        return;



                    // Determine if we're scrolling up or down
                    if (e.Delta > 0)
                    {
                        // Scrolling up
                        currentRowIndex = Math.Max(0, currentRowIndex - 1);
                    }
                    else
                    {
                        // Scrolling down
                        currentRowIndex = Math.Min(MaxRows - GetVisibleRowsCount(), currentRowIndex + 1);
                    }

                    // Ensure we're not exceeding the maximum allowable value

                    int newValue = currentRowIndex * totalControlHeight;

                    AutoScroll = false;
                    this.VerticalScroll.Value = Math.Min(newValue, VerticalScroll.Maximum);
                    AutoScroll = true;



                    System.Diagnostics.Debug.WriteLine($"After Adjustment: {VerticalScroll.Value}" + "\n newValue=" + newValue + "\nCurrent Row=" + currentRowIndex + "\n Max rows" + MaxRows);
                }
            }
            else
            {
                base.OnMouseWheel(e);

            }
           
        }


        private int GetMaxRows()
        {
            int widthAccumulated = 0;
            int rowCount = 0;

            foreach (Control control in this.Controls)
            {
                int totalControlWidth = control.Width + control.Margin.Left + control.Margin.Right;

                if (widthAccumulated + totalControlWidth > this.ClientSize.Width)
                {
                    // Start a new row
                    rowCount++;
                    widthAccumulated = 0;
                }

                widthAccumulated += totalControlWidth;
            }

            // Account for any remaining controls that form an incomplete row
            if (widthAccumulated > 0)
            {
                rowCount++;
            }

            return rowCount;
        }
        public int GetVisibleRowsCount()
        {
          
                totalControlHeight = this.Controls[0].Height + this.Controls[0].Margin.Top + this.Controls[0].Margin.Bottom;
                int visibleHeight = this.ClientSize.Height;
                // Calculate the number of visible rows
                int visibleRowsCount = (visibleHeight / totalControlHeight);
                return visibleRowsCount;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (IsDoubleBuffer)
                {
                    cp.ExStyle |= 0x02000000;  // WS_CLIPCHILDREN
                }
                return cp;
            }
        }
    }
}
