using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class Coach : Form
    {
        //Property:
        public DataTable DataTableCoachavailabilityCopy { get; set; }//it's a copy of DataTableCoachavailability so we can edit the copy and when we click done we edit the originale and SQL
        public AvailabilityLayout availabilityLayout { get; set; }

        //The 3 of them are ordered by rank
        public List<UCCoach> ListUCCoach { get; set; }//All the coaches that are active
        public List<UCCoach> ListUCCoachChecked { get; set; }//All The coaches that are checked  
        public List<int> ListUCCoach_idOld { get; set; }//it will have value when we construct this form so we can compare it with ListUCCoach to check if we changed the order

        //Variable:
        public Schedule schedule;


        //Initialise:
        public Coach(Schedule form1)
        {
            InitializeComponent();
            schedule = form1;
            ListUCCoachChecked = new List<UCCoach>();
            ListUCCoach = new List<UCCoach>();
            ListUCCoach_idOld = new List<int>();

            //Getting A copy of DataTableCoachavailability
            DataTableCoachavailabilityCopy = schedule.ucday.DataTableCoachavailability.Copy();

            //Getting reversedDataTable in a reversed order of DataTableCoachavailability because when we display them in the panel their user control will be reversed
            DataTable reversedDataTable = schedule.ucday.DataTableCoachavailability.Clone();
            var reversedRows = schedule.ucday.DataTableCoachavailability.AsEnumerable().Reverse();
            foreach (DataRow dr in reversedRows)
            {
                reversedDataTable.ImportRow(dr);
            }

            int Heightform = 0;//for the design of the form Coach
            foreach (DataRow dr in reversedDataTable.Rows)//bas hone men jib copy reverse li2anno panel bi zide uc men 2eleb
            {
                //Getting The Data
                int availability_id = (int)dr[0];
                int coach_id = (int)dr[1];
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

                //Add UCCoach
                UCCoach uccoach = new UCCoach(availability_id, coach_id, fullname, availibility, rank, ischecked, this);
                ListUCCoach.Add(uccoach);
                panelContainsCoaches.Controls.Add(uccoach);
                uccoach.Dock = DockStyle.Top;

                //Design
                Heightform += uccoach.Size.Height;
            }

            //Design
            if (Heightform < this.Size.Height)
            {
                this.Size = new Size(this.Size.Width, Heightform + 100);
            }

            //Getting ListUCCoach
            ListUCCoach = ListUCCoach.OrderBy(coach => coach.Rank).ToList();

            //Getting ListUCCoach_idOld
            foreach (UCCoach uccoach in ListUCCoach)
            {
                ListUCCoach_idOld.Add(uccoach.Coach_id);
            }


        }



        //Event:
        private void buttonD_Click(object sender, EventArgs e)
        {
            bool NoCoachIsChecked = true;
            foreach (UCCoach uccoach in ListUCCoach)
            {
                if (uccoach.IsChecked == true)
                {
                    NoCoachIsChecked = false;
                }
            }
            if (NoCoachIsChecked == false)
            {
                Cursor = Cursors.WaitCursor;
                //SQL
                ProjectToSql.UpdateRankNIsCheckedCoachAvailabilitySQL(DataTableCoachavailabilityCopy);

                //Design 
                RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(schedule.ucday.TLPCoaches);
                RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(schedule.ucday.TLPAppointment);

                //Updating DataTableCoachavailability
                schedule.ucday.DataTableCoachavailability = DataTableCoachavailabilityCopy.Copy();


                //Getting The Checked Coaches
                ListUCCoachChecked = new List<UCCoach>();
                foreach (UCCoach uccoach in ListUCCoach)
                {
                    if (uccoach.IsChecked == true)
                    {
                        ListUCCoachChecked.Add(uccoach);//men hatine men rank 1 lal ekhir bi taratoubiye
                    }
                }


                //if it's history, only DataTableCoachavailability,ListCoach_idChecked will change
                if (schedule.ucday.IsHistory)
                {
                    //Getting the new ListCoach_idChecked
                    schedule.ucday.ListCoach_idChecked.Clear();
                    for (int i = 0; i < ListUCCoachChecked.Count(); i++)
                    {
                        schedule.ucday.ListCoach_idChecked.Add(ListUCCoachChecked[i].Coach_id);
                    }
                }

                //if not, The design, CoachAvailabilityByOrder, ListCoach_idAllTime will also change
                else
                {

                    int difference = ListUCCoachChecked.Count() - schedule.ucday.TLPAppointment.ColumnCount + 1;//BOOM aadad lcoaches bel datatable hene rows w aadad lcoaches bel tablelayout ma3 wahad la uctime houwe aada lcolumms
                    ///men lekhir li ha yen3aml te3dil bi aadad column table ma3 tefwit aw shel kel shi jouwet hal column , te3dil bein aadad list, teedil bi madmoun list w ekher shi lcolumn ucappointment



                    if (difference > 0)//fi hal li keno unchecked rjeena eemelnehoun checked
                    {
                        //hataynehoun monfoslin kermel lcount taba3 ListUCCoachChecked ma yotla3 fo2 lcount taba3 schedule.ucday.ListCoach_id
                        for (int i = 0; i < difference; i++)
                        {
                            schedule.ucday.AddColumnUCDay();
                        }
                        SwitchCoachIfDifferent();

                    }
                    else if (difference < 0)
                    {
                        for (int i = 0; i < Math.Abs(difference); i++)
                        {
                            schedule.ucday.RemoveColumnUCDay();
                        }
                        SwitchCoachIfDifferent();
                    }
                    else
                    {
                        SwitchCoachIfDifferent();
                    }


                    schedule.ucday.CoachAvailabilityByOrder.Clear();
                    //Getting CoachAvailabilityByOrder for ListCoach_idAllTime
                    for (int i = 0; i < ListUCCoachChecked.Count; i++)//both of the string are in the order of the rank
                    {
                        //getting availibility for this day of every coachchecked
                        int dayOfWeekInt = ((int)DateTime.Today.DayOfWeek + 6) % 7;
                        string availibility = ListUCCoachChecked[i].Availability;
                        string[] HoursOfThedays = availibility.Split('/');
                        schedule.ucday.CoachAvailabilityByOrder.Add(HoursOfThedays[dayOfWeekInt]);
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
                            foreach (UCappointments ucappointment in flowLayoutPanel.Controls.OfType<UCappointments>())
                            {
                                ucappointment.Width = UCappointments.OriginalWidth; ;
                            }
                            foreach (UCmeeting ucmeeting in flowLayoutPanel.Controls.OfType<UCmeeting>())
                            {
                                ucmeeting.Width = UCappointments.OriginalWidth;
                            }


                            //eza ee edit width
                            if (((UCappointments.OriginalWidth * flowLayoutPanel.Controls.Count) + schedule.ucday.KeepSpace) > columnwidth)
                            {
                                schedule.ucday.EditWidthAppointment(flowLayoutPanel, columnwidth);
                            }
                        }
                    }
                }


               




                //Getting the historycoachavailability

                //and we can add acondition to prevent the update  by knowing if someone has changed something in the manager program active or disactive
                string rank_coaches = "";
                string availibility_coaches = "";
                for (int i = 0; i < ListUCCoach.Count; i++)//both of the string are in the order of the rank
                {
                    //getting rank_coaches
                    rank_coaches += ListUCCoach[i].Coach_id.ToString();


                    //getting availibility for this day of every coach
                    int dayOfWeekInt = ((int)DateTime.Today.DayOfWeek + 6) % 7;
                    string availibility = ListUCCoach[i].Availability;
                    string[] HoursOfThedays = availibility.Split('/');
                    availibility_coaches += HoursOfThedays[dayOfWeekInt];

                    if (i != ListUCCoach.Count - 1)
                    {
                        rank_coaches += "/";
                        availibility_coaches += "/";
                    }
                    else
                    {

                    }
                }
                ProjectToSql.UpdateHistoryCoachavailibility(DateTime.Now, rank_coaches, availibility_coaches);
                this.Close();
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Check at least one coach");
            }
        }



        //Function:
        void SwitchCoachIfDifferent()
        {
            schedule.ucday.ListCoach_idAllTime.Clear();

            //Editing the Design of the table layout panel and in the same time, Getting the new ListCoach_idAllTime and the new  ListCoach_idChecked, But don't forget we used ListCoach_idChecked as comparaison before we update it
            for (int i = 0; i < ListUCCoachChecked.Count(); i++)
            {
                //Comparing if the first coach is still the same, the second...
                if (ListUCCoachChecked[i].Coach_id == schedule.ucday.ListCoach_idChecked[i])
                {
                    //we already changed the availability when we clicked the button of AvailabilityLayout
                }
                else//ha yetghayar
                {
                    //Not the same coach so Updating ListCoach_idChecked
                    schedule.ucday.ListCoach_idChecked[i] = ListUCCoachChecked[i].Coach_id;

                    //If it's a different coach e will have to fill a new column with new appointments and availibity
                    schedule.ucday.UCappointmentsfillColumn(i + 1, ListUCCoachChecked[i].Coach_id, ListUCCoachChecked[i].Fullname);//BOOM COLUMNINDEX = i+1, LI2ANNO FI UCTime zyede w ha yon3ata coach_id taba3 uccoach li maee rang 1
                }

                //Getting the new ListCoach_idAllTime, it will be the same of ListCoach_idChecked
                schedule.ucday.ListCoach_idAllTime.Add(ListUCCoachChecked[i].Coach_id);
            }
        }

        private void Coach_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

///if (schedule.ucday.ListCoach_idChecked.Contains(coach_id))
//{
//    ischecked = true;
//}
//else
//{
//    ischecked = false;
//}



///If we to check if the order has changed but we didn't use because we can't use checking check box changed and even if we can it's a lot bit not that big of a deal
///bool IsOrderChanged(List<UCCoach> list1, List<int> list2)
//{

//    // Check for content equality based on some property (e.g., Name)
//    for (int i = 0; i < list1.Count; i++)
//    {
//        if (list1[i].Coach_id != list2[i])
//        {
//            return true;
//        }
//    }

//    return false;
//}

