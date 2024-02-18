using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MKproject.Schedule
{
    public partial class UCCoach : UserControl
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
        public int Coach_id { get; set; }
        public string Availability { get; set; }

        //GET SET:
        private string fullname;
        public string Fullname
        {
            get { return fullname; }
            set
            {
                fullname = value;
                LabelNamecoach.Text = fullname;
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
        public Coach coaches;



        //INITIALISE:
        public UCCoach(Coach coach)
        {
            InitializeComponent();
            coaches = coach;   
        }
        public UCCoach(int availability_id, int coach_id, string fullname, string availability, int rank,bool ischecked, Coach form1)
        {
            InitializeComponent();

            //Get Data
            Availability_id = availability_id;
            Coach_id = coach_id;
            Fullname = fullname;
            Availability = availability;
            coaches = form1;
            Rank = rank;
            IsChecked = ischecked;

            //Property
            Cursor = Cursors.Hand;
        }
       


        //EVENT:
        ///-CLICK
        private void buttonDown_Click(object sender, EventArgs e)
        {
            UCCoach TempUCCoach = new UCCoach(coaches);

            foreach (UCCoach uccoach in coaches.ListUCCoach)//hone kamen bi zet lwa2et aam nghayir ListUCCoach
            {
                //Getting The uccoach that's after him to do the swap
                if (uccoach.Rank == this.Rank + 1)
                {

                    //UPDATE DataTableCoachavailabilityCopy
                    foreach (DataRow row in coaches.DataTableCoachavailabilityCopy.Rows)
                    {
                        //Updating rank for the coach that we clicked on
                        if ((int)row["availability_id"] == this.Availability_id)
                        {
                            row["rank"] = (this.rank + 1);
                        }

                        //Updating rank for the other coach
                        else if((int)row["availability_id"] == uccoach.Availability_id)
                        {
                            row["rank"] = this.rank;
                        }
                    }

                    //Design doing the swap of the 2 uccoach
                    Swapuccoach(uccoach, TempUCCoach);
                    break;
                }
            }


            //keeping the DataTableCoachavailabilityCopy ASC
            coaches.DataTableCoachavailabilityCopy.DefaultView.Sort = "Rank ASC";//the null values will be last
            DataTable sortedTable = coaches.DataTableCoachavailabilityCopy.DefaultView.ToTable();
            coaches.DataTableCoachavailabilityCopy = sortedTable;


        }
        private void buttonUp_Click(object sender, EventArgs e)
        {
            UCCoach TempUCCoach = new UCCoach(coaches);
            foreach (UCCoach uccoach in coaches.ListUCCoach)
            {
                //Getting The uccoach that's before him to do the swap
                if (uccoach.Rank == this.Rank - 1)//yaeene tahto
                {

                    //UPDATE DataTableCoachavailabilityCopy
                    foreach (DataRow row in coaches.DataTableCoachavailabilityCopy.Rows)
                    {
                        //Updating rank for the coach that we clicked on
                        if ((int)row["availability_id"] == this.Availability_id)
                        {
                            row["rank"] = (this.rank - 1);
                        }

                        //Updating rank for the other coach
                        else if ((int)row["availability_id"] == uccoach.Availability_id)
                        {
                            row["rank"] = this.rank;
                        }
                    }

                    //Design doing the swap of the 2 uccoach 
                    Swapuccoach(uccoach,TempUCCoach);
                    break;
                }
            }

            //keeping the DataTableCoachavailabilityCopy ASC
            coaches.DataTableCoachavailabilityCopy.DefaultView.Sort = "Rank ASC";//the null values will be last
            DataTable sortedTable = coaches.DataTableCoachavailabilityCopy.DefaultView.ToTable();
            coaches.DataTableCoachavailabilityCopy = sortedTable;
        }
        private void UCCoach_Click(object sender, EventArgs e)
        {
            //Kermel yaeemil la marra wehde load w baeeden laa
            if(coaches.availabilityLayout == null)
            {
                Cursor = Cursors.WaitCursor;
                coaches.availabilityLayout = new AvailabilityLayout();
                Cursor = Cursors.Default;
            }
            //Doing the design of availabilityLayout 
            coaches.availabilityLayout.AvailibilitySpecificCoach(this);
            coaches.availabilityLayout.ShowDialog();
        }

        ///-CHECKBOX
        private void CheckBoxAppearance_CheckStateChanged(object sender, EventArgs e)
        {
            IsChecked = CheckBoxAppearance.Checked;

            //UPDATE DataTableCoachavailabilityCopy
            foreach (DataRow row in coaches.DataTableCoachavailabilityCopy.Rows)
            {
                //Updating rank for the coach that we clicked on
                if ((int)row["availability_id"] == this.Availability_id)
                {
                    row["is_checked"] = this.IsChecked;
                }
            }
        }



        //FUNCTION:
        private void Swapuccoach(UCCoach uccoach,UCCoach TempUCCoach)//ntebih hone byekhdo kel shi ella rank
        {
            //temp=a
            TempUCCoach.Availability_id = this.Availability_id;
            TempUCCoach.Coach_id = this.Coach_id;
            TempUCCoach.Availability = this.Availability;
            TempUCCoach.Fullname = this.Fullname;
            TempUCCoach.IsChecked = this.IsChecked;

            //a=b
            this.Availability_id = uccoach.Availability_id;
            this.Coach_id = uccoach.Coach_id;
            this.Availability = uccoach.Availability;
            this.Fullname = uccoach.Fullname;
            this.IsChecked = uccoach.IsChecked;

            //b=temp
            uccoach.Availability_id = TempUCCoach.Availability_id;
            uccoach.Coach_id = TempUCCoach.Coach_id;
            uccoach.Availability = TempUCCoach.Availability;
            uccoach.Fullname = TempUCCoach.Fullname;
            uccoach.IsChecked = TempUCCoach.IsChecked;


            TempUCCoach.Dispose();
        }



        //Design 
        private void UCCoach_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
        private void UCCoach_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(229, 226, 244);
        }

       
    }
}
