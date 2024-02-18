using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class UCCalanderMonth : UserControl
    {
        public Calander CalenderForm { get; set; }
        LabelMonth labelmonthcopy;

        public UCCalanderMonth()
        {
            InitializeComponent();
        }

        public UCCalanderMonth(Calander calendarform)
        {
            InitializeComponent();
            CalenderForm = calendarform;
            DisplayOnVarYearValue();
        }

        private void iconButtonNext_Click(object sender, EventArgs e)
        {
            if (CalenderForm.VarYear == DateTime.Now.Year)//ma lezim yen3amal next li2anno hayda lmax
            {

            }
            else if (CalenderForm.VarYear == DateTime.Now.Year - 1)//hone se3eta fi lbaeed month m3ayan tkouno disabled
            {
                CalenderForm.VarYear++;
                labelTitle.Text = CalenderForm.VarYear.ToString();
                if (labelmonthcopy != null)
                {
                    labelmonthcopy.BackColor = Color.White;
                    labelmonthcopy = null;
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Control control = tableLayoutPanel1.GetControlFromPosition(j, i);//to get the labels by order
                        if (control is LabelMonth m)
                        {
                            if (CalenderForm.DesiredDate.Month == m.Month && CalenderForm.DesiredDate.Year == CalenderForm.VarYear)
                            {
                                labelmonthcopy = m;
                                m.BackColor = Color.FromArgb(229, 226, 244);
                            }
                            if (m.Month > DateTime.Now.Month)//bi koun atta3 bel month
                            {
                                m.Enabled = false;
                            }
                            m.CalenderForm = CalenderForm;
                        }
                    }
                }
            }
            else
            {
                CalenderForm.VarYear++;
                labelTitle.Text = CalenderForm.VarYear.ToString();
                if (labelmonthcopy != null)
                {
                    labelmonthcopy.BackColor = Color.White;
                    labelmonthcopy = null;
                }
                HighlightSelectedMonth();
            }

        }

        private void iconButtonPrevious_Click(object sender, EventArgs e)
        {
            CalenderForm.VarYear--;
            labelTitle.Text = CalenderForm.VarYear.ToString();
            if (labelmonthcopy != null)
            {
                labelmonthcopy.BackColor = Color.White;
                labelmonthcopy = null;
            }
            HighlightSelectedMonth();
        }

        private void HighlightSelectedMonth()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Control control = tableLayoutPanel1.GetControlFromPosition(j, i);//to get the labels by order
                    if (control is LabelMonth m)
                    {
                        if (CalenderForm.DesiredDate.Month == m.Month && CalenderForm.DesiredDate.Year == CalenderForm.VarYear)
                        {
                            labelmonthcopy = m;
                            m.BackColor = Color.FromArgb(229, 226, 244);
                        }
                        else
                        {
                            m.BackColor = Color.White;
                        }
                        m.Enabled = true;
                        m.CalenderForm = CalenderForm;
                       
                    }
                }
            }
        }

        public void DisplayOnVarYearValue()
        {
            labelTitle.Text = CalenderForm.VarYear.ToString();
            if (CalenderForm.VarYear == DateTime.Now.Year)//hone se3eta fi lbaeed month m3ayan tkouno disabled
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Control control = tableLayoutPanel1.GetControlFromPosition(j, i);//to get the labels by order
                        if (control is LabelMonth m)
                        {
                            if (CalenderForm.DesiredDate.Month == m.Month && CalenderForm.DesiredDate.Year == CalenderForm.VarYear)
                            {
                                labelmonthcopy = m;
                                m.BackColor = Color.FromArgb(229, 226, 244);
                            }
                            if (m.Month > DateTime.Now.Month)//bi koun atta3 bel month
                            {
                                m.Enabled = false;
                            }
                            m.CalenderForm = CalenderForm;
                        }
                    }
                }
            }
            else
            {

                HighlightSelectedMonth();
            }
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {
            this.Hide();
            CalenderForm.uccalanderyear.DisplayNHighlightSelectedYeaFromLabelTile(CalenderForm.VarYear);
           CalenderForm.uccalanderyear.Show();
        }

 
    }
}
