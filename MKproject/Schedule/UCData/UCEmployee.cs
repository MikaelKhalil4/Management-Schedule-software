using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

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
        private string fullname;
        public string Fullname
        {
            get { return fullname; }
            set
            {
                fullname = value;
                LabelNameemployee.Text = fullname;
            }
        }

        private int rank ;
        public int Rank
        {
            get { return rank; }
            set
            {
                rank = value;
                labelRank.Text = rank.ToString();
            }
        }

        private bool ischecked;
        public bool IsChecked

        {
            get { return ischecked; }
            set
            {
                ischecked = value;
                CheckBoxAppearance.Checked = ischecked;
            }
        }

        //VARIABLE:
        public Employee employees;



        //INITIALISE:
        public UCEmployee(Employee employee)
        {
            InitializeComponent();
            employees = employee;   
        }
        public UCEmployee(int availability_id, int employee_id, string fullname, string availability, int rank,bool ischecked, Employee form1)
        {
            InitializeComponent();

            //Get Data
            Availability_id = availability_id;
            Employee_id = employee_id;
            Fullname = fullname;
            Availability = availability;
            employees = form1;
            Rank = rank;
            IsChecked = ischecked;

            //Property
            Cursor = Cursors.Hand;
        }
       


        //EVENT:
        ///-CLICK
        private void buttonDown_Click(object sender, EventArgs e)
        {
            UCEmployee TempUCEmployee = new UCEmployee(employees);

            foreach (UCEmployee ucemployee in employees.ListUCEmployee)//hone kamen bi zet lwa2et aam nghayir ListUCEmployee
            {
                //Getting The ucemployee that's after him to do the swap
                if (ucemployee.Rank == this.Rank + 1)
                {

                    //UPDATE DataTableEmployeeavailabilityCopy
                    foreach (DataRow row in employees.DataTableEmployeeavailabilityCopy.Rows)
                    {
                        //Updating rank for the employee that we clicked on
                        if ((int)row["availability_id"] == this.Availability_id)
                        {
                            row["rank"] = (this.rank + 1);
                        }

                        //Updating rank for the other employee
                        else if((int)row["availability_id"] == ucemployee.Availability_id)
                        {
                            row["rank"] = this.rank;
                        }
                    }

                    //Design doing the swap of the 2 ucemployee
                    Swapucemployee(ucemployee, TempUCEmployee);
                    break;
                }
            }


            //keeping the DataTableEmployeeavailabilityCopy ASC
            employees.DataTableEmployeeavailabilityCopy.DefaultView.Sort = "Rank ASC";//the null values will be last
            DataTable sortedTable = employees.DataTableEmployeeavailabilityCopy.DefaultView.ToTable();
            employees.DataTableEmployeeavailabilityCopy = sortedTable;


        }
        private void buttonUp_Click(object sender, EventArgs e)
        {
            UCEmployee TempUCEmployee = new UCEmployee(employees);
            foreach (UCEmployee ucemployee in employees.ListUCEmployee)
            {
                //Getting The ucemployee that's before him to do the swap
                if (ucemployee.Rank == this.Rank - 1)//yaeene tahto
                {

                    //UPDATE DataTableEmployeeavailabilityCopy
                    foreach (DataRow row in employees.DataTableEmployeeavailabilityCopy.Rows)
                    {
                        //Updating rank for the employee that we clicked on
                        if ((int)row["availability_id"] == this.Availability_id)
                        {
                            row["rank"] = (this.rank - 1);
                        }

                        //Updating rank for the other employee
                        else if ((int)row["availability_id"] == ucemployee.Availability_id)
                        {
                            row["rank"] = this.rank;
                        }
                    }

                    //Design doing the swap of the 2 ucemployee 
                    Swapucemployee(ucemployee,TempUCEmployee);
                    break;
                }
            }

            //keeping the DataTableEmployeeavailabilityCopy ASC
            employees.DataTableEmployeeavailabilityCopy.DefaultView.Sort = "Rank ASC";//the null values will be last
            DataTable sortedTable = employees.DataTableEmployeeavailabilityCopy.DefaultView.ToTable();
            employees.DataTableEmployeeavailabilityCopy = sortedTable;
        }
        private void UCEmployee_Click(object sender, EventArgs e)
        {
            //Kermel yaeemil la marra wehde load w baeeden laa
            if(employees.availabilityLayout == null)
            {
                Cursor = Cursors.WaitCursor;
                employees.availabilityLayout = new AvailabilityLayout();
                Cursor = Cursors.Default;
            }
            //Doing the design of availabilityLayout 
            employees.availabilityLayout.AvailibilitySpecificEmployee(this);
            employees.availabilityLayout.ShowDialog();
        }

        ///-CHECKBOX
        private void CheckBoxAppearance_CheckStateChanged(object sender, EventArgs e)
        {
            IsChecked = CheckBoxAppearance.Checked;

            //UPDATE DataTableEmployeeavailabilityCopy
            foreach (DataRow row in employees.DataTableEmployeeavailabilityCopy.Rows)
            {
                //Updating rank for the employee that we clicked on
                if ((int)row["availability_id"] == this.Availability_id)
                {
                    row["is_checked"] = this.IsChecked;
                }
            }
        }



        //FUNCTION:
        private void Swapucemployee(UCEmployee ucemployee,UCEmployee TempUCEmployee)//ntebih hone byekhdo kel shi ella rank
        {
            //temp=a
            TempUCEmployee.Availability_id = this.Availability_id;
            TempUCEmployee.Employee_id = this.Employee_id;
            TempUCEmployee.Availability = this.Availability;
            TempUCEmployee.Fullname = this.Fullname;
            TempUCEmployee.IsChecked = this.IsChecked;

            //a=b
            this.Availability_id = ucemployee.Availability_id;
            this.Employee_id = ucemployee.Employee_id;
            this.Availability = ucemployee.Availability;
            this.Fullname = ucemployee.Fullname;
            this.IsChecked = ucemployee.IsChecked;

            //b=temp
            ucemployee.Availability_id = TempUCEmployee.Availability_id;
            ucemployee.Employee_id = TempUCEmployee.Employee_id;
            ucemployee.Availability = TempUCEmployee.Availability;
            ucemployee.Fullname = TempUCEmployee.Fullname;
            ucemployee.IsChecked = TempUCEmployee.IsChecked;


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
