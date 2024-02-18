using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Management
{
    public class LabelMonth : Label
    {
        private int month;
        public Calander CalenderForm { get; set; }

        public int Month
        {
            get { return month; }
            set
            {
                month = value;
                DateTime dt = new DateTime(1, month, 1);
                this.Text = dt.ToString("MMMM");
            }
        }


        public LabelMonth()
        {
            this.Font = new Font("Segoe UI", 14.25f);
            this.BackColor = Color.White;
            this.ForeColor = Color.FromArgb(109, 122, 224);
            this.Margin = new Padding(0);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.MouseMove += labelMonth_MouseMove;
            this.MouseLeave += labelMonth_MouseLeave;
            this.MouseClick += labelMonth_Click;
        }
        private void labelMonth_Click(object sender, EventArgs e)
        {
            DateTime lastMonthStartDate = new DateTime(CalenderForm.VarYear, month, 1);
            DateTime lastMonthEndDate = new DateTime(CalenderForm.VarYear, month, 1).AddMonths(1).AddSeconds(-1);

            CalenderForm.UCCustomDate.Startdate = lastMonthStartDate;
            CalenderForm.UCCustomDate.Enddate = lastMonthEndDate;
            CalenderForm.UCCustomDate.Detail = lastMonthStartDate.ToString("MMMM") + " " + lastMonthEndDate.ToString("yyyy");



            if (CalenderForm != null)
            {
                CalenderForm.Close();
            }
        }


        private void labelMonth_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            // MouseMove event handler
            LabelMonth label = (LabelMonth)sender;
            label.BackColor = Color.FromArgb(229, 226, 244);
        }
        private void labelMonth_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

            if (Month == CalenderForm.DesiredDate.Month)
            {

            }
            else
            {
                // MouseLeave event handler
                LabelMonth label = (LabelMonth)sender;
                label.BackColor = Color.White;
            }


        }


    }
}
