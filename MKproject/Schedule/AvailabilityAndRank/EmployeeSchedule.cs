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



        //Variable:
        public UCSchedule ParentucSchedule;
        public bool IsButtonAvailabilitylClicked = false;//Kermel watta yeftah lavailability form ma ysakir lemployee form
        public bool IsFormShouldClose = true;
        //Initialise:
        public EmployeeSchedule(UCSchedule parentucSchedule)
        {
            InitializeComponent();
            this.Opacity = 0;

            ParentucSchedule = parentucSchedule;



            int Heightform = 0;
            for (int i = ParentucSchedule.TotalEmployeeScheduleList.Count - 1; i >= 0; i--)
            {

                //Add UCEmployee
                UCEmployee employee = new UCEmployee(ParentucSchedule.TotalEmployeeScheduleList[i].Copy(), this);
                panelGlobal.Controls.Add(employee);
                employee.Dock = DockStyle.Top;

                //Design
                Heightform += employee.Size.Height;
            }
            //Design
            if (Heightform < this.Size.Height)
            {
                this.Size = new Size(this.Size.Width, Heightform + 80);
            }
            this.Width = 320;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void Employee_Deactivate(object sender, EventArgs e)
        {
            if (IsFormShouldClose)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .25;
        }

        private void ButtonDone_Click(object sender, EventArgs e)
        {
            OnDoneClick();      
        }


        public void OnDoneClick()
        {

            foreach (UCEmployee uc in panelGlobal.Controls)
            {
                //UPDATE The references of TotalEmployeeScheduleList
                ClassEmployee EmployeeSelectedOfThisUC = ParentucSchedule.TotalEmployeeScheduleList.FirstOrDefault(emp => emp.EmployeeId == uc.DesiredEmployee.EmployeeId);
                EmployeeSelectedOfThisUC.IsChecked = uc.DesiredEmployee.IsChecked;
                EmployeeSelectedOfThisUC.Rank = uc.DesiredEmployee.Rank;
                EmployeeSelectedOfThisUC.Availability = uc.DesiredEmployee.Availability;
            }

            foreach (ClassEmployee emp in ParentucSchedule.TotalEmployeeScheduleList)
            {
                if (!emp.IsChecked)
                {
                    ParentucSchedule.IsEmployeeFilterModeOn = true;
                    break;
                }
                ParentucSchedule.IsEmployeeFilterModeOn = false;//in case all of them are checked
            }

            ParentucSchedule.TotalEmployeeScheduleList = ParentucSchedule.TotalEmployeeScheduleList.OrderBy(s => s.Rank).ToList();

            for (int i = 0; i < ParentucSchedule.TotalEmployeeScheduleList.Count; i++)//updating the employee table
            {
                ParentucSchedule.TotalEmployeeScheduleList[i].UpdateEmployee();
            }

            for (int i = 0; i < ParentucSchedule.TotalEmployeeScheduleList.Count; i++)//Updating the history table
            {
                int rank = (int)ParentucSchedule.TotalEmployeeScheduleList[i].Rank;
             
                string DesiredAvailabiltyOfSpecificDay = ClassEmployeeFront.GetAvailabiltyAsAstringFromWeekAvailability(DateTime.Now, ParentucSchedule.TotalEmployeeScheduleList[i].Availability);


                ProjectToSql.UpdateRank_HistoryEmployeeavailibility(DateTime.Now, ParentucSchedule.TotalEmployeeScheduleList[i].EmployeeId, rank, DesiredAvailabiltyOfSpecificDay);
            }


            Cursor.Current = Cursors.WaitCursor;
            this.Close();
            ParentucSchedule.LoadForm(ParentucSchedule.SelectedDate, ParentucSchedule.IsDayOrWeek, false, false);
            Cursor.Current = Cursors.Default;
        }
    }

}


