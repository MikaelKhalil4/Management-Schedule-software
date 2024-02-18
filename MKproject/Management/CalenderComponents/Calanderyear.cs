using CustomizedTools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class Calanderyear : Form
    {
        public Statistics StatisticsForm { get; set; }
        public UCLabelFilterOriginal UCCustomDate;    
        public DateTime DesiredDate;
        public int Year { get; set; } 
        public int NOYearsInOnePage = 11;    
        public LabelYear labelyearcopy;
      
        public Calanderyear(UCLabelFilterOriginal ucCustomeDate, DateTime desiredDate)//isincome false yaane sessions
        {
            InitializeComponent();
            UCCustomDate = ucCustomeDate;
            DesiredDate = desiredDate;
            Year = DesiredDate.Year;

            this.Opacity = 0;
            this.TopMost = true;


            if ((Year + NOYearsInOnePage) > DateTime.Now.Year)
            {
                Year = DateTime.Now.Year - NOYearsInOnePage;
                labelTitle.Text = Year + "-" + (Year + NOYearsInOnePage);
               


            }
            else
            {
                labelTitle.Text = Year + "-" + (Year + NOYearsInOnePage);
                
            }
            int year = Year;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Control control = tableLayoutPanel1.GetControlFromPosition(j, i);//to get the labels by order
                    if (control is LabelYear y)
                    {
                        if (DesiredDate.Year == year)
                        {
                            labelyearcopy = y;
                            y.BackColor = Color.FromArgb(229, 226, 244);
                        }
                        y.Year = year;
                        y.CalenderYearForm = this;
                        year++;
                    }
                }
            }
        }

        private void iconButtonNext_Click(object sender, EventArgs e)
        {
            
            if (Year + NOYearsInOnePage == DateTime.Now.Year)
            {

            }
            else
            {
                Year += NOYearsInOnePage;
                labelTitle.Text = Year + "-" + (Year + NOYearsInOnePage);
                if ((Year + NOYearsInOnePage) > DateTime.Now.Year)//hone eza display ma ha yen3amal aal ekhir
                {
                    if (labelyearcopy != null)
                    {
                        labelyearcopy.BackColor = Color.White;
                        labelyearcopy = null;
                    }
                    Year = DateTime.Now.Year - NOYearsInOnePage;
                    DisplayNHighlightSelectedYear();

                }
                else
                {
                    if (labelyearcopy != null)
                    {
                        labelyearcopy.BackColor = Color.White;
                        labelyearcopy = null;
                    }
                    DisplayNHighlightSelectedYear();

                }
            }          
        }
        private void iconButtonPrevious_Click(object sender, EventArgs e)
        {
            if (labelyearcopy != null)
            {
                labelyearcopy.BackColor = Color.White;
                labelyearcopy = null;
            }
            Year -= NOYearsInOnePage;
            labelTitle.Text = Year + "-" + (Year + NOYearsInOnePage);
            DisplayNHighlightSelectedYear();


        }
        private void DisplayNHighlightSelectedYear()
        {
            int year = Year;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Control control = tableLayoutPanel1.GetControlFromPosition(j, i);//to get the labels by order
                    if (control is LabelYear y)
                    {
                        if (DesiredDate.Year == year)
                        {
                            labelyearcopy = y;
                            y.BackColor = Color.FromArgb(229, 226, 244);
                        }
                        y.Year = year;
                        year++;
                    }
                }
            }
        }

        private void Calanderyear_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }

        private void Calanderyear_Deactivate(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
                this.Select();
            }
            Opacity += .1;
        }
    }
}
