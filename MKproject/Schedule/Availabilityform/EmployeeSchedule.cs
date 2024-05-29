using MKproject.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class EmployeeSchedule : Form
    {
        //Property:
    
     
        public List<ClassEmployee> EmployeeScheduleList { get; set; }//All the employees that are active

        //Variable:
        public UCSchedule ParentucSchedule;
        public bool IsButtonAvailability = false;//Kermel watta yeftah lavailability form ma ysakir lemployee form

        //Initialise:
        public EmployeeSchedule(List<ClassEmployee> employeeScheduleList)
        {
            InitializeComponent();
            this.Opacity = 0;


            EmployeeScheduleList = employeeScheduleList;

      

            int Heightform = 0;//for the design of the form Employee
            for (int i = EmployeeScheduleList.Count - 1; i >= 0; i--)//bas hone men jib copy reverse li2anno panel bi zide uc men 2eleb
            {

                //Add UCEmployee
                UCEmployee employee = new UCEmployee(EmployeeScheduleList[i], this);
                panelContainsEmployees.Controls.Add(employee);
                employee.Dock = DockStyle.Top;

                //Design
                Heightform += employee.Size.Height;
            }
            //Design
            if (Heightform < this.Size.Height)
            {
                this.Size = new Size(this.Size.Width, Heightform + 80);
            }
            this.Width = 246;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void Employee_Deactivate(object sender, EventArgs e)
        {
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
            //Kermel watta yeftah lavailability form ma ysakir lemployee form
            if (IsButtonAvailability == false)
            {
                this.Close();
            }
            else
            {
                IsButtonAvailability = false;//eza ken true byerjaee bi sir false
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .1;
        }

        private void ButtonDone_Click(object sender, EventArgs e)
        {
            foreach(UCEmployee uc in panelContainsEmployees.Controls)
            {
                //UPDATE ListEmployeeScheduleCopy
                ClassEmployee  EmployeeSelectedOfThisUC = EmployeeScheduleList.FirstOrDefault(emp => emp.EmployeeId == uc.DesiredEmployee.EmployeeId);
                EmployeeSelectedOfThisUC.IsChecked = uc.DesiredEmployee.IsChecked;
            }
            foreach (ClassEmployee emp in EmployeeScheduleList)
            {
                emp.UpdateEmployee();
            }

            Cursor.Current = Cursors.WaitCursor;    
            ParentucSchedule.LoadForm(ParentucSchedule.SelectedDate, ParentucSchedule.IsDayOrWeek,false);
            Cursor.Current = Cursors.Default;

            this.Close();
        }
    }

}


