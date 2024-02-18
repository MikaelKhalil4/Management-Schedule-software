using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class UCCalanderYear : UserControl
    {
      

        public int NOYearsInOnePage = 11;
        public LabelYear labelyearcopy;
        public int Year;//for the display

        
        public Calander CalanderForm { get; set; }
    
 

        public UCCalanderYear()
        {
            InitializeComponent();
            
        }
        public UCCalanderYear(Calander calanderForm)
        {
            InitializeComponent();
            CalanderForm = calanderForm;
            Year = CalanderForm.VarYear;

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
                        if (CalanderForm.DesiredDate.Year == year)
                        {
                            labelyearcopy = y;
                            y.BackColor = Color.FromArgb(229, 226, 244);
                        }
                        y.Year = year;
                        y.CalanderForm = CalanderForm;
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
                labelTitle.Text = Year + "-" + (Year + NOYearsInOnePage);
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
                        if (CalanderForm.DesiredDate.Year == year)
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
        public void DisplayNHighlightSelectedYeaFromLabelTile(int year)
        {
            Year = year;
            if ((Year + NOYearsInOnePage) > DateTime.Now.Year)//hone eza display ma ha yen3amal aal ekhir
            {
                Year = DateTime.Now.Year - NOYearsInOnePage;
            }
            labelTitle.Text = Year + "-" + (Year + NOYearsInOnePage);
            DisplayNHighlightSelectedYear();
        }

    }
}
