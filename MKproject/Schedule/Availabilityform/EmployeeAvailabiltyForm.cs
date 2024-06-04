using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKproject.Schedule.Availabilityform
{
    public partial class EmployeeAvailabiltyForm : Form
    {
        public EmployeeAvailabiltyForm()//kermel el flickering, fuck winforms
        {
            InitializeComponent();
            this.Width = Program.HomeForm.Width - 100;
            this.Height = Program.HomeForm.Height - 80;

            UCEmployeeAvailabilty uc = new UCEmployeeAvailabilty();
            this.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .1;
        }

        private void EmployeeAvailabiltyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }
    }

}
