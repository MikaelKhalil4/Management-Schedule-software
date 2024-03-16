using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using static MKproject.Schedule.StaticClass;
using MKproject.Management;

namespace MKproject.Schedule
{
    public partial class UCappointment : UserControl
    {
        //PROPERTY:
        private ClassAppointment desiredappointment;
        public ClassAppointment DesiredAppointment
        {
            get { return desiredappointment; }
            set
            {
                desiredappointment = value;
                SetDesign();
            }
        }

        public int ColumnPosition { get; set; }
        public int RowPosition { get; set; }

        //VARIABLE
        UCDay ucday;
        public static int OriginalWidth = 230;

        //INITIALISE
        public UCappointment()
        {
            InitializeComponent();
        }


        //ADD and SELECT (remember in add there's no uctime but in select there's)
        public UCappointment(ClassAppointment desiredappointment, UCDay uCDay)
        {
            InitializeComponent();
            DesiredAppointment = desiredappointment;
            ucday = uCDay;
        }


        void SetDesign()
        {
            //Name
            if (DesiredAppointment.DesiredClient != null)
            {
                labelFullName.Text = DesiredAppointment.DesiredClient.Fname + " " + DesiredAppointment.DesiredClient.Lname;
            }
            else
            {
                labelFullName.Text = "No Client Chosen";
            }


            //Service
            if (DesiredAppointment.DesiredClientBalance != null)
            {
                labelService.Text = DesiredAppointment.DesiredClientBalance.ClientBalanceFullDetails;
            }
            else if (DesiredAppointment.ChosenBundlesList != null && DesiredAppointment.ChoseBundlesString != null)
            {
                labelService.Text = DesiredAppointment.ChoseBundlesString;
            }
            else if (DesiredAppointment.Title != null)
            {
                labelService.Text = DesiredAppointment.Title;
            }


            //StartTime
            string timestring = DesiredAppointment.StartTime.ToString("h:mm tt");

            string[] partstime = timestring.Split(' ');
            labelTime.Text = partstime[0];//eza baddak yeha 7:00 PM fik terjaee tghayera w thot timestring 

            //EndTime
            timestring = DesiredAppointment.EndTime.ToString("h:mm tt");
            partstime = timestring.Split(' ');
            labelTime.Text += " - " + partstime[0];//eza baddak yeha 7:00 PM fik terjaee tghayera w thot timestring 


        }
        //UPDATE
        public void UpdateAppointments(ClassAppointment desiredappointment)
        {
            //UPDATE DESIGN
            DesiredAppointment = desiredappointment;
        }


        //EVENTS:
        ///-Click
        private void UCappointments_Click(object sender, EventArgs e)
        {
            if (TouchScroll.MoveHoldClick == false && ucday.IsHistory == false)
            {
                Appointment appointmentupdate = new Appointment(this, DesiredAppointment, ucday);
                appointmentupdate.ShowDialog();
            }
            else
            {

            }
        }

        public void RemoveAppointment()
        {
            //SQL
            DesiredAppointment.DeleteAppointment();

            //DESIGN
            TimeSpan starttimeTimeSpan = DesiredAppointment.StartTime.TimeOfDay;
            int positionrow = starttimeTimeSpan.Hours;
            int positioncol = ucday.ListEmployee_idChecked.IndexOf((int)DesiredAppointment.EmployeeId) + 1;
            FlowLayoutPanel clickedflowLayoutPanel = ucday.TLPAppointment.GetControlFromPosition(positioncol, positionrow) as FlowLayoutPanel;//position flowlayoutpanel hiye position employee bel list-1 
            this.Dispose();


            //Fi hal ucdata ma ken eendoun originale lwidth lezim nredoun la na3if eza byo2ta3 limit
            foreach (UCappointment ucappointment in clickedflowLayoutPanel.Controls.OfType<UCappointment>())
            {
                ucappointment.Width = UCappointment.OriginalWidth;//UCAddClick.Width it's static width that I declared it
            }




            //Absolute
            if (ucday.TLPAppointment.ColumnStyles[positioncol].SizeType is SizeType.Absolute)
            {

                //The FlowLayoutpanel where we dispose the ucdata does it have akbar aadad ucdata before we dispose this ucdata if yes it will affect the TBL
                bool havethemaxucdata = true;

                for (int i = 0; i < ucday.TLPAppointment.RowCount; i++)
                {
                    if (positionrow != i)
                    {
                        Control cellControl = ucday.TLPAppointment.GetControlFromPosition(positioncol, i);
                        if (cellControl is FlowLayoutPanel)
                        {
                            FlowLayoutPanel innerFlowLayoutPanel = (FlowLayoutPanel)cellControl;
                            if ((clickedflowLayoutPanel.Controls.Count + 1)/*+1 li2anno manna na3rif abel ma yaeemil dispose*/ > innerFlowLayoutPanel.Controls.Count)
                            {

                            }

                            //eza hata = la hada bet batil zabta
                            else
                            {
                                //if it's equal or false then the supposition is false so we have to break
                                havethemaxucdata = false;
                                break;
                            }
                        }
                    }

                    //Eza ata3 bi halo akid ma y2arin halo
                    else
                    {

                    }

                }

                //hayde lconidtion => kel flowlayoutpanel ma aandoun wala ucappointment because eza lmax 0 yaeene kelo 0
                if (clickedflowLayoutPanel.Controls.Count == 0 && havethemaxucdata)
                {
                    RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(ucday.TLPAppointment);
                    RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(ucday.TLPEmployees);
                }

                //eza ken lflow layout panel li mahayna fiyo ucappointment aando akbar aada hone it may edit the size of the absolute column
                else if (havethemaxucdata)
                {
                    ucday.EditColumnAbsoluteSize(positioncol, positionrow);
                }

                //se3eta bas momkin yet2asar lwidthucappointment
                else
                {
                    int columnwidth = ucday.TLPAppointment.GetColumnWidths()[positioncol];
                    //eza ee edit width
                    if (((UCappointment.OriginalWidth * clickedflowLayoutPanel.Controls.Count) + ucday.KeepSpace) > columnwidth)
                    {
                        ucday.EditWidthAppointment(clickedflowLayoutPanel, columnwidth);
                    }
                }
            }

            //Percentage
            else
            {
                int columnwidth = ucday.TLPAppointment.GetColumnWidths()[positioncol];
                //eza ee edit width
                if (((UCappointment.OriginalWidth * clickedflowLayoutPanel.Controls.Count) + ucday.KeepSpace) > columnwidth)
                {
                    ucday.EditWidthAppointment(clickedflowLayoutPanel, columnwidth);
                }
            }
        }







        //DESIGN
        private void UCappointments_MouseMove(object sender, MouseEventArgs e)
        {
            if (TouchScroll.MoveHoldClick == false)
            {
                if (tableLayoutPanel2.BackColor != ucday.DisableColorTBUca)//229, 226, 244
                {
                    tableLayoutPanel2.BackColor = Color.FromArgb(249, 246, 254);
                }
            }
            else
            {

            }
        }
        private void UCappointments_MouseLeave(object sender, EventArgs e)
        {
            if (tableLayoutPanel2.BackColor != ucday.DisableColorTBUca)
            {
                tableLayoutPanel2.BackColor = Color.White;
            }
        }

       
        
    }
}
