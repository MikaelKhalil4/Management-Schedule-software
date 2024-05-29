using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using MKproject.Management;
using System.Linq;

namespace MKproject.Schedule
{
    public partial class UCEmployee : UserControl
    {

        //PERFORMANCE:
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

       

        //GET SET:
        private ClassEmployee desiredemployee;
        public ClassEmployee DesiredEmployee
        {
            get { return desiredemployee; }
            set
            {
                desiredemployee = value;
                CheckBoxAppearance.Text = desiredemployee.Fname + " " + desiredemployee.Lname;
                labelRank.Text = desiredemployee.Rank.ToString();
                CheckBoxAppearance.Checked = (bool)desiredemployee.IsChecked;
            }
        }


        //VARIABLE:
        public EmployeeSchedule ParentFormEmployee;



        //INITIALISE:       
        public UCEmployee(ClassEmployee desiredemployee, EmployeeSchedule employee)
        {
            InitializeComponent();

            //Get Data
            ParentFormEmployee = employee;
            DesiredEmployee = desiredemployee;
            //Property
            Cursor = Cursors.Hand;
        }



        //EVENT:
        ///-CLICK
     
        private void buttonAvailability_Click(object sender, EventArgs e)
        {
          
        }

        ///-CHECKBOX
        private void CheckBoxAppearance_CheckStateChanged(object sender, EventArgs e)
        {
            DesiredEmployee.IsChecked = CheckBoxAppearance.Checked;

           
        }



        //Design 
        private void UCEmployee_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
        private void UCEmployee_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(229, 226, 244);
        }


    }
}
