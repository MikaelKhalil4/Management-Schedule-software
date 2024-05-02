using MKproject.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class Employee : Form
    {
        //Property:
        public List<ClassEmployee> ListEmployeeScheduleCopy { get; set; }//it's a copy of ListEmployeeSchedule so we can edit the copy and when we click done we edit the originale and SQL
        public AvailabilityLayout availabilityLayout { get; set; }

        //The 3 of them are ordered by rank
        public List<UCEmployee> ListUCEmployee { get; set; }//All the employees that are active
        public List<UCEmployee> ListUCEmployeeChecked { get; set; }//All The employees that are checked  
        public List<int> ListUCEmployee_idOld { get; set; }//it will have value when we construct this form so we can compare it with ListUCEmployee to check if we changed the order

        //Variable:
        public ScheduleForm schedule;
        public bool IsButtonAvailability = false;//Kermel watta yeftah lavailability form ma ysakir lemployee form

        //Initialise:
        public Employee(ScheduleForm form1)
        {
            InitializeComponent();
            this.Opacity =0;

            schedule = form1;
            ListUCEmployeeChecked = new List<UCEmployee>();
            ListUCEmployee = new List<UCEmployee>();
            ListUCEmployee_idOld = new List<int>();

            //Getting A copy of ListEmployeeSchedule
            ListEmployeeScheduleCopy = new List<ClassEmployee>(schedule.ucday.ListEmployeeSchedule);

            //Getting reversedListemployee in a reversed order of ListEmployeeSchedule because when we display them in the panel their user control will be reversed
            List<ClassEmployee> reversedListemployee = schedule.ucday.ListEmployeeSchedule.OrderByDescending(emp => emp.Rank).ToList();



            int Heightform = 0;//for the design of the form Employee
            for (int i = 0; i < reversedListemployee.Count; i++)//bas hone men jib copy reverse li2anno panel bi zide uc men 2eleb
            {

                //Add UCEmployee
                UCEmployee ucemployee = new UCEmployee(reversedListemployee[i], this);

                ListUCEmployee.Add(ucemployee);
                panelContainsEmployees.Controls.Add(ucemployee);
                ucemployee.Dock = DockStyle.Top;

                //Design
                Heightform += ucemployee.Size.Height;
            }

            //Design
            if (Heightform < this.Size.Height)
            {
                this.Size = new Size(this.Size.Width, Heightform + 100);
            }

            //Getting ListUCEmployee
            ListUCEmployee = ListUCEmployee.OrderBy(employee => employee.DesiredEmployee.Rank).ToList();

            //Getting ListUCEmployee_idOld
            foreach (UCEmployee ucemployee in ListUCEmployee)
            {
                ListUCEmployee_idOld.Add(ucemployee.DesiredEmployee.EmployeeId);
            }


        }



        //Event:
        private void buttonD_Click(object sender, EventArgs e)
        {
            bool NoEmployeeIsChecked = true;
            foreach (UCEmployee ucemployee in ListUCEmployee)
            {
                if (ucemployee.DesiredEmployee.IsChecked == true)
                {
                    NoEmployeeIsChecked = false;
                }
            }
            if (NoEmployeeIsChecked == false)
            {
                Cursor = Cursors.WaitCursor;
                //SQL
                //Getting the EmployeeAvailability
                ClassEmployee.UpdateRankNIsCheckedEmployeeScheduleMemberSQL(ListEmployeeScheduleCopy);

                //Getting the historyemployeeavailability
                //and we can add acondition to prevent the update  by knowing if someone has changed something in the manager program active or disactive
                for (int i = 0; i < ListUCEmployee.Count; i++)//both of the string are in the order of the rank
                {
                    int rank = i + 1;
                    ProjectToSql.UpdateRank_HistoryEmployeeavailibility(DateTime.Now, ListUCEmployee[i].DesiredEmployee.EmployeeId, rank);
                }

                //Design 
                RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(schedule.ucday.TLPEmployees);
                RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(schedule.ucday.TLPAppointment);

                //Updating ListEmployeeSchedule
                schedule.ucday.ListEmployeeSchedule = ListEmployeeScheduleCopy;


                //Getting The Checked Employeees
                ListUCEmployeeChecked = new List<UCEmployee>();
                foreach (UCEmployee ucemployee in ListUCEmployee)
                {
                    if (ucemployee.DesiredEmployee.IsChecked == true)
                    {
                        ListUCEmployeeChecked.Add(ucemployee);//men hatine men rank 1 lal ekhir bi taratoubiye
                    }
                }


                //if it's history, only ListEmployeeSchedule,ListEmployee_idChecked will change
                if (schedule.ucday.IsHistory)
                {
                    //Getting the new ListEmployee_idChecked
                    schedule.ucday.ListEmployee_idChecked.Clear();
                    for (int i = 0; i < ListUCEmployeeChecked.Count(); i++)
                    {
                        schedule.ucday.ListEmployee_idChecked.Add(ListUCEmployeeChecked[i].DesiredEmployee.EmployeeId);
                    }
                }

                //if not, The design, EmployeeAvailabilityByOrder, ListEmployee_idAllTime will also change
                else
                {

                    int difference = ListUCEmployeeChecked.Count() - schedule.ucday.TLPAppointment.ColumnCount + 1;//BOOM aadad lemployees bel datatable hene rows w aadad lemployees bel tablelayout ma3 wahad la uctime houwe aada lcolumms
                    ///men lekhir li ha yen3aml te3dil bi aadad column table ma3 tefwit aw shel kel shi jouwet hal column , te3dil bein aadad list, teedil bi madmoun list w ekher shi lcolumn ucappointment



                    if (difference > 0)//fi hal li keno unchecked rjeena eemelnehoun checked
                    {
                        //hataynehoun monfoslin kermel lcount taba3 ListUCEmployeeChecked ma yotla3 fo2 lcount taba3 schedule.ucday.ListEmployee_id
                        for (int i = 0; i < difference; i++)
                        {
                            schedule.ucday.AddColumnUCDay();
                        }
                        SwitchEmployeeIfDifferent();

                    }
                    else if (difference < 0)
                    {
                        for (int i = 0; i < Math.Abs(difference); i++)
                        {
                            schedule.ucday.RemoveColumnUCDay();
                        }
                        SwitchEmployeeIfDifferent();
                    }
                    else
                    {
                        SwitchEmployeeIfDifferent();
                    }


                    schedule.ucday.EmployeeAvailabilityByOrder.Clear();
                    //Getting EmployeeAvailabilityByOrder for ListEmployee_idAllTime
                    for (int i = 0; i < ListUCEmployeeChecked.Count; i++)//both of the string are in the order of the rank
                    {
                        //getting availibility for this day of every employeechecked
                        int dayOfWeekInt = ((int)DateTime.Today.DayOfWeek + 6) % 7;
                        string availibility = ListUCEmployeeChecked[i].DesiredEmployee.Availability;
                        string[] HoursOfThedays = availibility.Split('/');
                        schedule.ucday.EmployeeAvailabilityByOrder.Add(HoursOfThedays[dayOfWeekInt]);
                    }
                }


                //kermel kel ucappointment ybaynoma bel column
                for (int j = 0; j < schedule.ucday.TLPAppointment.ColumnCount; j++)
                {
                    int columnwidth = schedule.ucday.TLPAppointment.GetColumnWidths()[j];
                    for (int i = 0; i < schedule.ucday.TLPAppointment.RowCount; i++)
                    {
                        Control cellControl = schedule.ucday.TLPAppointment.GetControlFromPosition(j, i);//cell li fi yo akbar aadad ucappointment
                        if (cellControl is FlowLayoutPanel)
                        {
                            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)cellControl;
                            int NumberOfVisibleControls = 0;
                            foreach (Control ctrl in flowLayoutPanel.Controls)
                            {
                                if (ctrl.Visible)
                                {
                                    NumberOfVisibleControls++;
                                }
                            }

                            //Getting them to originale width
                            foreach (UCappointment ucappointment in flowLayoutPanel.Controls.OfType<UCappointment>())
                            {
                                ucappointment.Width = UCappointment.OriginalWidth; 
                            }


                            //eza ee edit width
                            if (((UCappointment.OriginalWidth * NumberOfVisibleControls) + schedule.ucday.KeepSpace) > columnwidth)
                            {
                                schedule.ucday.EditWidthAppointment(flowLayoutPanel, columnwidth);
                            }
                        }
                    }
                }

                this.Close();
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Check at least one employee");
            }
        }



        //Function:
        void SwitchEmployeeIfDifferent()
        {
            schedule.ucday.ListEmployee_idAllTime.Clear();

            //Editing the Design of the table layout panel and in the same time, Getting the new ListEmployee_idAllTime and the new  ListEmployee_idChecked, But don't forget we used ListEmployee_idChecked as comparaison before we update it
            for (int i = 0; i < ListUCEmployeeChecked.Count(); i++)
            {
                //Comparing if the first employee is still the same, the second...
                if (ListUCEmployeeChecked[i].DesiredEmployee.EmployeeId == schedule.ucday.ListEmployee_idChecked[i])
                {
                    //we already changed the availability when we clicked the button of AvailabilityLayout
                }
                else//ha yetghayar
                {
                    //Not the same employee so Updating ListEmployee_idChecked
                    schedule.ucday.ListEmployee_idChecked[i] = ListUCEmployeeChecked[i].DesiredEmployee.EmployeeId;

                    string EmployeeFullName = ListUCEmployeeChecked[i].DesiredEmployee.Fname + " " + ListUCEmployeeChecked[i].DesiredEmployee.Lname;
                    //If it's a different employee e will have to fill a new column with new appointments and availibity
                    schedule.ucday.UCappointmentsfillColumn(i + 1, ListUCEmployeeChecked[i].DesiredEmployee.EmployeeId, EmployeeFullName);//BOOM COLUMNINDEX = i+1, LI2ANNO FI UCTime zyede w ha yon3ata employee_id taba3 ucemployee li maee rang 1
                }

                //Getting the new ListEmployee_idAllTime, it will be the same of ListEmployee_idChecked
                schedule.ucday.ListEmployee_idAllTime.Add(ListUCEmployeeChecked[i].DesiredEmployee.EmployeeId);
            }
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
    }

}

///if (schedule.ucday.ListEmployee_idChecked.Contains(employee_id))
//{
//    ischecked = true;
//}
//else
//{
//    ischecked = false;
//}



///If we to check if the order has changed but we didn't use because we can't use checking check box changed and even if we can it's a lot bit not that big of a deal
///bool IsOrderChanged(List<UCEmployee> list1, List<int> list2)
//{

//    // Check for content equality based on some property (e.g., Name)
//    for (int i = 0; i < list1.Count; i++)
//    {
//        if (list1[i].Employee_id != list2[i])
//        {
//            return true;
//        }
//    }

//    return false;
//}

