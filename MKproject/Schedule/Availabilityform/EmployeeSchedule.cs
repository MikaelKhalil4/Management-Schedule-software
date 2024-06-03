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
                UCEmployee employee = new UCEmployee(ParentucSchedule.TotalEmployeeScheduleList[i], this);
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
            this.Close();
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
            foreach (UCEmployee uc in panelGlobal.Controls)
            {
                //UPDATE The references of TotalEmployeeScheduleList
                ClassEmployee EmployeeSelectedOfThisUC = ParentucSchedule.TotalEmployeeScheduleList.FirstOrDefault(emp => emp.EmployeeId == uc.DesiredEmployee.EmployeeId);
                EmployeeSelectedOfThisUC.IsChecked = uc.DesiredEmployee.IsChecked;
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

            for (int i = 0; i < ParentucSchedule.TotalEmployeeScheduleList.Count; i++)
            {
                ClassEmployee.UpdateRankEmployeeScheduleMemberSQL(ParentucSchedule.TotalEmployeeScheduleList[i]);
            }

            for (int i = 0; i < ParentucSchedule.TotalEmployeeScheduleList.Count; i++)//both of the string are in the order of the rank
            {
                int rank = i + 1;
                ProjectToSql.UpdateRank_HistoryEmployeeavailibility(DateTime.Now, ParentucSchedule.TotalEmployeeScheduleList[i].EmployeeId, rank);
            }

            Cursor.Current = Cursors.WaitCursor;
            ParentucSchedule.LoadForm(ParentucSchedule.SelectedDate, ParentucSchedule.IsDayOrWeek, false,false);
            Cursor.Current = Cursors.Default;

            this.Close();
        }
    }

}


