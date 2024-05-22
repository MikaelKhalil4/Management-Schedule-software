using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class LabelYear : Label
    {
        //PROPERTY:
        private int year;
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                this.Text = year.ToString();
            }
        }

        //VARIABLE:
        public CalanderForm ucmonths;



        //INITIALISE:
        public LabelYear()
        {
            this.Font = new Font("Segoe UI", 9.75f);
            this.BackColor = Color.White;
            this.ForeColor = Color.FromArgb(109, 122, 224);
            this.Margin = new Padding(0);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.MouseMove += labelYear_MouseMove;
            this.MouseLeave += labelYear_MouseLeave;
            this.MouseClick += labelYear_Click;
        }



        //EVENT:
        private void labelYear_Click(object sender, EventArgs e)
        {
            ucmonths.wichuccalander = 2;

            LabelYear label = (LabelYear)sender;
            ucmonths.DateCalander = new DateTime(label.Year, 1, 1);//laken bas lmonth byetghayr

            ucmonths.tableLayoutPanelMonth.Controls.Remove(ucmonths.uccalanderyear);
            ucmonths.tableLayoutPanelMonth.Controls.Add(ucmonths.uccalandermonth);

            ucmonths.labelTitleDay.Text = ucmonths.DateCalander.Year.ToString();
            ucmonths.HighlightSelectedMonth();

        }



        //DESIGN:
        private void labelYear_MouseMove(object sender, MouseEventArgs e)
        {
            // MouseMove event handler
            LabelYear label = (LabelYear)sender;
            label.BackColor = Color.FromArgb(229, 226, 244);
        }
        private void labelYear_MouseLeave(object sender, EventArgs e)
        {
            // MouseLeave event handler
            LabelYear label = (LabelYear)sender;
            if (ucmonths.labelyearcopy == this)
            {

            }
            else
            {
                label.BackColor = Color.White;

            }
        }
    }
}
