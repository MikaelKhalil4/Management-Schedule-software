using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using MKproject.Management;
using System.Linq;
using CustomizedTools;
using MKproject.Schedule.Availabilityform;

namespace MKproject.Schedule
{
    public partial class UCEmployee : UserControl
    {

     
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
                CheckBoxAppearance.Checked = desiredemployee.IsChecked;
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
            ParentFormEmployee.IsFormShouldClose = false;
            ParentFormEmployee.Hide();


            Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
            Program.GreyForm.Show();

            EmployeeAvailabiltyForm empAv = new EmployeeAvailabiltyForm(DesiredEmployee, this);//ejabre badde yeha reference
            empAv.ShowDialog();

            //eemelna hek in order the OnOnDoneClick() method works well li mawjude bel EmployeeSchedule!
            ParentFormEmployee.IsFormShouldClose = true;
            ParentFormEmployee.Close();
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

        private void iconButtonDown_Click(object sender, EventArgs e)
        {
            foreach (UCEmployee ucemployee in ParentFormEmployee.panelGlobal.Controls)//hone kamen bi zet lwa2et aam nghayir ListUCEmployee
            {
                //Getting The ucemployee that's after him to do the swap
                if (ucemployee.DesiredEmployee.Rank == this.DesiredEmployee.Rank + 1)
                {
                    ucemployee.DesiredEmployee.Rank = this.DesiredEmployee.Rank;
                    this.DesiredEmployee.Rank += 1;
                    //Design doing the swap of the 2 ucemployee
                    Swapucemployee(ucemployee);
                    break;
                }
            }
        }
        private void iconButtonUp_Click(object sender, EventArgs e)
        {
            foreach (UCEmployee ucemployee in ParentFormEmployee.panelGlobal.Controls)
            {
                //Getting The ucemployee that's before him to do the swap
                if (ucemployee.DesiredEmployee.Rank == this.DesiredEmployee.Rank - 1)//yaeene faw2o
                {
                    ucemployee.DesiredEmployee.Rank = this.DesiredEmployee.Rank;
                    this.DesiredEmployee.Rank -= 1;
                    //Design doing the swap of the 2 ucemployee 
                    Swapucemployee(ucemployee);
                    break;
                }
            }
        }
        private void Swapucemployee(UCEmployee ucemployee)//ntebih hone byekhdo kel shi ella rank
        {
            //temp=a
            ClassEmployee TempEmployee = this.DesiredEmployee;
         
            //a=b
            this.DesiredEmployee = ucemployee.DesiredEmployee;

            //b=temp
            ucemployee.DesiredEmployee = TempEmployee;
        }

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



    }
}
