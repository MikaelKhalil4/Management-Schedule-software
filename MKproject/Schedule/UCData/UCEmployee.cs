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
        //SQL:
        SqlConnection con = new SqlConnection(Program.DataLocation);

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

        //PROPERTY:
        public int Availability_id { get; set; }
        public int Employee_id { get; set; }
        public string Availability { get; set; }




        //GET SET:
        private ClassEmployee desiredemployee;
        public ClassEmployee DesiredEmployee
        {
            get { return desiredemployee; }
            set
            {
                desiredemployee = value;
                LabelNameemployee.Text = desiredemployee.Fname + " " + desiredemployee.Lname;
                labelRank.Text = desiredemployee.Rank.ToString();
                CheckBoxAppearance.Checked = (bool)desiredemployee.IsChecked;
            }
        }


        //VARIABLE:
        public Employee employees;



        //INITIALISE:
        public UCEmployee()
        {
            InitializeComponent();
        }
        public UCEmployee(ClassEmployee desiredemployee, Employee employee)
        {
            InitializeComponent();

            //Get Data
            DesiredEmployee = desiredemployee;
            employees = employee;
            //Property
            Cursor = Cursors.Hand;
        }



        //EVENT:
        ///-CLICK
        private void buttonDown_Click(object sender, EventArgs e)
        {
            UCEmployee TempUCEmployee = new UCEmployee();

            foreach (UCEmployee ucemployee in employees.ListUCEmployee)//hone kamen bi zet lwa2et aam nghayir ListUCEmployee
            {
                //Getting The ucemployee that's after him to do the swap
                if (ucemployee.DesiredEmployee.Rank == this.DesiredEmployee.Rank + 1)
                {
                    //UPDATE ListEmployeeScheduleCopy

                    ClassEmployee EmployeeSelectedOfTheOtherUC = employees.ListEmployeeScheduleCopy.FirstOrDefault(emp => emp.EmployeeId == ucemployee.DesiredEmployee.EmployeeId);
                    EmployeeSelectedOfTheOtherUC.Rank = this.DesiredEmployee.Rank;

                    ClassEmployee EmployeeSelectedOfThisUC = employees.ListEmployeeScheduleCopy.FirstOrDefault(emp => emp.EmployeeId == this.DesiredEmployee.EmployeeId);
                    EmployeeSelectedOfThisUC.Rank = this.DesiredEmployee.Rank + 1;


                    //Design doing the swap of the 2 ucemployee
                    Swapucemployee(ucemployee, TempUCEmployee);
                    break;
                }
            }
        }
        private void buttonUp_Click(object sender, EventArgs e)
        {
            UCEmployee TempUCEmployee = new UCEmployee();
            foreach (UCEmployee ucemployee in employees.ListUCEmployee)
            {
                //Getting The ucemployee that's before him to do the swap
                if (ucemployee.DesiredEmployee.Rank == this.DesiredEmployee.Rank - 1)//yaeene faw2o
                {
                    //UPDATE ListEmployeeScheduleCopy

                    ClassEmployee EmployeeSelectedOfTheOtherUC = employees.ListEmployeeScheduleCopy.FirstOrDefault(emp => emp.EmployeeId == ucemployee.DesiredEmployee.EmployeeId);
                    EmployeeSelectedOfTheOtherUC.Rank = this.DesiredEmployee.Rank;

                    ClassEmployee EmployeeSelectedOfThisUC = employees.ListEmployeeScheduleCopy.FirstOrDefault(emp => emp.EmployeeId == this.DesiredEmployee.EmployeeId);
                    EmployeeSelectedOfThisUC.Rank = this.DesiredEmployee.Rank - 1;



                    //Design doing the swap of the 2 ucemployee 
                    Swapucemployee(ucemployee, TempUCEmployee);
                    break;
                }
            }

        }
        private void buttonAvailability_Click(object sender, EventArgs e)
        {
            //Kermel yaeemil la marra wehde load w baeeden laa
            if (employees.availabilityLayout == null)
            {
                Cursor = Cursors.WaitCursor;
                employees.availabilityLayout = new AvailabilityLayout();
                Cursor = Cursors.Default;
            }

            employees.IsButtonAvailability = true;

            //Doing the design of availabilityLayout 
            employees.availabilityLayout.AvailibilitySpecificEmployee(this);
            employees.availabilityLayout.ShowDialog();
        }

        ///-CHECKBOX
        private void CheckBoxAppearance_CheckStateChanged(object sender, EventArgs e)
        {
            DesiredEmployee.IsChecked = CheckBoxAppearance.Checked;

            //UPDATE ListEmployeeScheduleCopy
            ClassEmployee EmployeeSelectedOfThisUC = employees.ListEmployeeScheduleCopy.FirstOrDefault(emp => emp.EmployeeId == this.DesiredEmployee.EmployeeId);
            EmployeeSelectedOfThisUC.IsChecked = this.DesiredEmployee.IsChecked;
        }



        //FUNCTION:
        private void Swapucemployee(UCEmployee ucemployee, UCEmployee TempUCEmployee)//ntebih hone byekhdo kel shi ella rank
        {
            //temp=a
            TempUCEmployee.DesiredEmployee = this.DesiredEmployee;

            //a=b
            this.DesiredEmployee = ucemployee.DesiredEmployee;

            //b=temp
            ucemployee.DesiredEmployee = TempUCEmployee.DesiredEmployee;
            TempUCEmployee.Dispose();
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
