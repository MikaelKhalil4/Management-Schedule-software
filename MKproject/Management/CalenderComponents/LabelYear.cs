using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class LabelYear : Label
    {
        public Calanderyear CalenderYearForm { get; set; }
        public Calander CalanderForm { get; set; }

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
        //public UCMonth ucmonths { get; set; }

        public LabelYear()
        {
            this.Font = new Font("Segoe UI", 14.25f);
            this.BackColor = Color.White;
            this.ForeColor = Color.FromArgb(109, 122, 224);
            this.Margin = new Padding(0);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.MouseMove += labelYear_MouseMove;
            this.MouseLeave += labelYear_MouseLeave;
            this.MouseClick += labelYear_Click;
        }


        private void labelYear_Click(object sender, EventArgs e)
        {

            
            DateTime thisYearStartDate = new DateTime(Year, 1, 1);
         
            DateTime thisYearEndDate = new DateTime(Year, 1, 1).AddYears(1).AddSeconds(-1);
          
            if (CalenderYearForm != null)
            {
                CalenderYearForm.Close();

                CalenderYearForm.UCCustomDate.Startdate = thisYearStartDate;
                CalenderYearForm. UCCustomDate.Enddate = thisYearEndDate;
                CalenderYearForm.UCCustomDate.Detail = thisYearStartDate.ToString("yyyy");



            }
            else if (CalanderForm != null)
            {
                CalanderForm.VarYear = Year;// bas hamna nghayyir el year ma hamna nghayyir el month
                CalanderForm.uccalandermonth.DisplayOnVarYearValue();
                CalanderForm.uccalanderyear.Hide();
                CalanderForm.uccalandermonth.Show();
             
            }
           
        }
        private void labelYear_MouseMove(object sender, MouseEventArgs e)
        {
            // MouseMove event handler
            this.Cursor = Cursors.Hand;
            LabelYear label = (LabelYear)sender;
            label.BackColor = Color.FromArgb(229, 226, 244);
        }
        private void labelYear_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            if (CalenderYearForm != null)
            {
                    if (Year == CalenderYearForm.DesiredDate.Year)
                    {
                    }
                    else
                    {
                        // MouseLeave event handler
                        LabelYear label = (LabelYear)sender;
                        label.BackColor = Color.White;
                    }                         

            }
            else if (CalanderForm != null)
            {
                if (Year == CalanderForm.DesiredDate.Year)
                {
                }
                else
                {
                    // MouseLeave event handler
                    LabelYear label = (LabelYear)sender;
                    label.BackColor = Color.White;
                }
                
            }
            }

    }
}
