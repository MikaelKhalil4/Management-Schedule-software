using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public class LabelMonth : Label
    {
        //PROPERTY:
        private int month;
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

        //VARIABLE:
        public UCMonth ucmonths;
       


        //INITIALISE
        public LabelMonth()
        {
            //DESIGN
            this.Font = new Font("Segoe UI", 5.75f);
            this.BackColor = Color.White;
            this.ForeColor = Color.FromArgb(109, 122, 224);
            this.Margin = new Padding(0);
            this.TextAlign = ContentAlignment.MiddleCenter;

            //EVENTS
            this.MouseMove += labelMonth_MouseMove;
            this.MouseLeave += labelMonth_MouseLeave;
            this.MouseClick += labelMonth_Click;
        }



        //EVENTS:
        private void labelMonth_Click(object sender, EventArgs e)
        {
            ucmonths.wichuccalander = 1;

            LabelMonth label = (LabelMonth)sender;
            ucmonths.DateUCMonth = new DateTime(ucmonths.DateUCMonth.Year, label.Month, 1);//laken bas lmonth byetghayr

            ucmonths.tableLayoutPanelMonth.Controls.Remove(ucmonths.uccalandermonth);
            ucmonths.tableLayoutPanelMonth.Controls.Add(ucmonths.uccalanderday);

            ucmonths.EditLabelUCdays();
        }

        

        //DESIGN:
        private void labelMonth_MouseMove(object sender, MouseEventArgs e)
        {
            // MouseMove event handler
            LabelMonth label = (LabelMonth)sender;
            label.BackColor = Color.FromArgb(229, 226, 244);
        }
        private void labelMonth_MouseLeave(object sender, EventArgs e)
        {
            // MouseLeave event handler
            LabelMonth label = (LabelMonth)sender;
            if(ucmonths.labelmonthcopy == this)
            {

            }
            else
            {
                label.BackColor = Color.White;

            }
        }
       
    }
}
