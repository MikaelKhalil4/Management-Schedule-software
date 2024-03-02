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
        public DataTable DataTableEmployeeavailabilityCopy { get; set; }//it's a copy of DataTableEmployeeavailability so we can edit the copy and when we click done we edit the originale and SQL
        public AvailabilityLayout availabilityLayout { get; set; }

        //The 3 of them are ordered by rank
        public List<UCEmployee> ListUCEmployee { get; set; }//All the employees that are active
        public List<UCEmployee> ListUCEmployeeChecked { get; set; }//All The employees that are checked  
        public List<int> ListUCEmployee_idOld { get; set; }//it will have value when we construct this form so we can compare it with ListUCEmployee to check if we changed the order

        //Variable:
        public Schedule schedule;


        //Initialise:
        public Employee(Schedule form1)
        {
            InitializeComponent();
            schedule = form1;
            ListUCEmployeeChecked = new List<UCEmployee>();
            ListUCEmployee = new List<UCEmployee>();
            ListUCEmployee_idOld = new List<int>();

            //Getting A copy of DataTableEmployeeavailability
            DataTableEmployeeavailabilityCopy = schedule.ucday.DataTableEmployeeavailability.Copy();

            //Getting reversedDataTable in a reversed order of DataTableEmployeeavailability because when we display them in the panel their user control will be reversed
            DataTable reversedDataTable = schedule.ucday.DataTableEmployeeavailability.Clone();
            var reversedRows = schedule.ucday.DataTableEmployeeavailability.AsEnumerable().Reverse();
            foreach (DataRow dr in reversedRows)
            {
                reversedDataTable.ImportRow(dr);
            }

            int Heightform = 0;//for the design of the form Employee
            foreach (DataRow dr in reversedDataTable.Rows)//bas hone men jib copy reverse li2anno panel bi zide uc men 2eleb
            {
                //Getting The Data
                int availability_id = (int)dr[0];
                int employee_id = (int)dr[1];
                string fullname = (string)dr[2] + " " + (string)dr[3];
                string availibility;
                if (dr[4] == DBNull.Value)
                {
                    availibility = "//////";//hayda signe bye3ne not available all the time
                }
                else
                {
                    availibility = (string)dr[4];
                }
                int rank = (int)dr[5];
                bool ischecked = (bool)dr[6];

                //Add UCEmployee
                UCEmployee ucemployee = new UCEmployee(availability_id, employee_id, fullname, availibility, rank, ischecked, this);
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
            ListUCEmployee = ListUCEmployee.OrderBy(employee => employee.Rank).ToList();

            //Getting ListUCEmployee_idOld
            foreach (UCEmployee ucemployee in ListUCEmployee)
            {
                ListUCEmployee_idOld.Add(ucemployee.Employee_id);
            }


        }



        //Event:
        private void buttonD_Click(object sender, EventArgs e)
        {
            bool NoEmployeeIsChecked = true;
            foreach (UCEmployee ucemployee in ListUCEmployee)
            {
                if (ucemployee.IsChecked == true)
                {
                    NoEmployeeIsChecked = false;
                }
            }
            if (NoEmployeeIsChecked == false)
            {
                Cursor = Cursors.WaitCursor;
                //SQL
                ProjectToSql.UpdateRankNIsCheckedEmployeeAvailabilitySQL(DataTableEmployeeavailabilityCopy);

                //Design 
                RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(schedule.ucday.TLPEmployees);
                RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(schedule.ucday.TLPAppointment);

                //Updating DataTableEmployeeavailability
                schedule.ucday.DataTableEmployeeavailability = DataTableEmployeeavailabilityCopy.Copy();


                //Getting The Checked Employeees
                ListUCEmployeeChecked = new List<UCEmployee>();
                foreach (UCEmployee ucemployee in ListUCEmployee)
                {
                    if (ucemployee.IsChecked == true)
                    {
                        ListUCEmployeeChecked.Add(ucemployee);//men hatine men rank 1 lal ekhir bi taratoubiye
                    }
                }


                //if it's history, only DataTableEmployeeavailability,ListEmployee_idChecked will change
                if (schedule.ucday.IsHistory)
                {
                    //Getting the new ListEmployee_idChecked
                    schedule.ucday.ListEmployee_idChecked.Clear();
                    for (int i = 0; i < ListUCEmployeeChecked.Count(); i++)
                    {
                        schedule.ucday.ListEmployee_idChecked.Add(ListUCEmployeeChecked[i].Employee_id);
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
                        string availibility = ListUCEmployeeChecked[i].Availability;
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

                            //Getting them to originale width
                            foreach (UCappointment ucappointment in flowLayoutPanel.Controls.OfType<UCappointment>())
                            {
                                ucappointment.Width = UCappointment.OriginalWidth; ;
                            }


                            //eza ee edit width
                            if (((UCappointment.OriginalWidth * flowLayoutPanel.Controls.Count) + schedule.ucday.KeepSpace) > columnwidth)
                            {
                                schedule.ucday.EditWidthAppointment(flowLayoutPanel, columnwidth);
                            }
                        }
                    }
                }


               




                //Getting the historyemployeeavailability

                //and we can add acondition to prevent the update  by knowing if someone has changed something in the manager program active or disactive
                string rank_employees = "";
                string availibility_employees = "";
                for (int i = 0; i < ListUCEmployee.Count; i++)//both of the string are in the order of the rank
                {
                    //getting rank_employees
                    rank_employees += ListUCEmployee[i].Employee_id.ToString();


                    //getting availibility for this day of every employee
                    int dayOfWeekInt = ((int)DateTime.Today.DayOfWeek + 6) % 7;
                    string availibility = ListUCEmployee[i].Availability;
                    string[] HoursOfThedays = availibility.Split('/');
                    availibility_employees += HoursOfThedays[dayOfWeekInt];

                    if (i != ListUCEmployee.Count - 1)
                    {
                        rank_employees += "/";
                        availibility_employees += "/";
                    }
                    else
                    {

                    }
                }
                ProjectToSql.UpdateHistoryEmployeeavailibility(DateTime.Now, rank_employees, availibility_employees);
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
                if (ListUCEmployeeChecked[i].Employee_id == schedule.ucday.ListEmployee_idChecked[i])
                {
                    //we already changed the availability when we clicked the button of AvailabilityLayout
                }
                else//ha yetghayar
                {
                    //Not the same employee so Updating ListEmployee_idChecked
                    schedule.ucday.ListEmployee_idChecked[i] = ListUCEmployeeChecked[i].Employee_id;

                    //If it's a different employee e will have to fill a new column with new appointments and availibity
                    schedule.ucday.UCappointmentsfillColumn(i + 1, ListUCEmployeeChecked[i].Employee_id, ListUCEmployeeChecked[i].Fullname);//BOOM COLUMNINDEX = i+1, LI2ANNO FI UCTime zyede w ha yon3ata employee_id taba3 ucemployee li maee rang 1
                }

                //Getting the new ListEmployee_idAllTime, it will be the same of ListEmployee_idChecked
                schedule.ucday.ListEmployee_idAllTime.Add(ListUCEmployeeChecked[i].Employee_id);
            }
        }

        private void Employee_Deactivate(object sender, EventArgs e)
        {
            this.Close();
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

