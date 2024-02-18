using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using static MKproject.Schedule.StaticClass;

namespace MKproject.Schedule
{
    public partial class UCappointments : UserControl
    {
        //SQL
        static SqlConnection con = new SqlConnection(Program.DataLocation);

        //PROPERTY:
        public int IdAppointment { get; set; }
        public int? IdClient { get; set; }
        public int IdCoach { get; set; }
        public string Notes { get; set; }


        private DateTime starttime;
        public DateTime StartTime
        {
            get { return starttime; }
            set
            {
                starttime = value;
                string timestring = starttime.ToString("h:mm tt");
                string[] partstime = timestring.Split(' ');
                labelStartTime.Text = partstime[0];//eza baddak yeha 7:00 PM fik terjaee tghayera w thot timestring 
            }
        }


        private DateTime endtime;
        public DateTime EndTime
        {
            get { return endtime; }
            set
            {
                endtime = value;
                string timestring = endtime.ToString("h:mm tt");
                string[] partstime = timestring.Split(' ');
                labelEndTime.Text = partstime[0];//eza baddak yeha 7:00 PM fik terjaee tghayera w thot timestring 
            }
        }


        private bool onpending;
        public bool OnPending
        {
            get { return onpending; }
            set { onpending = value; checkBoxAppointment.Checked = onpending; }
        }


        private string fullname;
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; checkBoxAppointment.Text = fullname; }
        }

        private string clienttype;

        public string ClientType
        {
            get { return clienttype; }
            set
            {
                clienttype = value;
                if (clienttype == StaticClass.AppointmentType.Member.ToString())
                {
                    this.BackColor = Color.FromArgb(109, 122, 224);
                }
                else if (clienttype == StaticClass.AppointmentType.Solo.ToString())
                {
                    this.BackColor = Color.FromArgb(202, 88, 229);
                }
                else if (clienttype == StaticClass.AppointmentType.Solo.ToString())
                {
                    this.BackColor = Color.FromArgb(74, 220, 168);
                }
                else//Meeting
                {
                    this.BackColor = Color.FromArgb(255, 102, 147);
                }
            }
        }



        //VARIABLE
        UCDay ucday;
        public static int OriginalWidth = 230;


        //INITIALISE
        public UCappointments()
        {
            InitializeComponent();
        }


        //ADD and SELECT (remember in add there's no uctime but in select there's)
        public UCappointments(int appointment_id, int coach_id, int? idclient, string fullname, DateTime starttime, DateTime endtime, string notes, bool onpending, UCDay form1, string clienttype)
        {
            InitializeComponent();
            IdAppointment = appointment_id;
            IdCoach = coach_id;
            IdClient = idclient;
            StartTime = starttime;
            EndTime = endtime;
            Notes = notes;
            OnPending = onpending;
            FullName = fullname;
            ucday = form1;
            ClientType = clienttype;
        }


        //UPDATE
        public void UpdateAppointments(int? idclient, string fullname, DateTime starttime, DateTime endtime, string notes, bool onpending, string clienttype)
        {
            //SQL
            ProjectToSql.UpdateFromAppoitementtoSQL(IdAppointment, idclient, starttime, endtime, notes, onpending, clienttype);

            //UPDATE DESIGN
            IdClient = idclient;
            StartTime = starttime;
            EndTime = endtime;
            Notes = notes;
            OnPending = onpending;
            FullName = fullname;
            ClientType = clienttype;
        }


        //EVENTS:
        ///-Click
        private void UCappointments_Click(object sender, EventArgs e)
        {
            if (TouchScroll.MoveHoldClick == false && ucday.IsHistory == false)
            {
                AppointmentUpdate appointmentupdate = new AppointmentUpdate(this);
                appointmentupdate.ShowDialog();
            }
            else
            {

            }
        }
        private void checkBoxOnPending_Click(object sender, EventArgs e)
        {
            //SQL
            ProjectToSql.UpdateAppointmentCheck(IdAppointment, checkBoxAppointment.Checked);

            //DESIGN
            OnPending = checkBoxAppointment.Checked;//tghayar l2esem hone bas houwe zeto ousoulan
           
        }

        public void RemoveAppointment()
        {
            //SQL
            ProjectToSql.DeleteAppointment(IdAppointment);

            //DESIGN
            TimeSpan starttimeTimeSpan = StartTime.TimeOfDay;
            int positionrow = starttimeTimeSpan.Hours;
            int positioncol = ucday.ListCoach_idChecked.IndexOf(IdCoach) + 1;
            FlowLayoutPanel clickedflowLayoutPanel = ucday.TLPAppointment.GetControlFromPosition(positioncol, positionrow) as FlowLayoutPanel;//position flowlayoutpanel hiye position coach bel list-1 
            this.Dispose();


            //Fi hal ucdata ma ken eendoun originale lwidth lezim nredoun la na3if eza byo2ta3 limit
            foreach (UCappointments ucappointment in clickedflowLayoutPanel.Controls.OfType<UCappointments>())
            {
                ucappointment.Width = UCappointments.OriginalWidth;//UCAddClick.Width it's static width that I declared it
            }


            foreach (UCmeeting ucmeeting in clickedflowLayoutPanel.Controls.OfType<UCmeeting>())
            {
                ucmeeting.Width = UCappointments.OriginalWidth;//UCAddClick.Width it's static width that I declared it
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
                    RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(ucday.TLPCoaches);
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
                    if (((UCappointments.OriginalWidth * clickedflowLayoutPanel.Controls.Count) + ucday.KeepSpace) > columnwidth)
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
                if (((UCappointments.OriginalWidth * clickedflowLayoutPanel.Controls.Count) + ucday.KeepSpace) > columnwidth)
                {
                    ucday.EditWidthAppointment(clickedflowLayoutPanel, columnwidth);
                }
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            RemoveAppointment();
              
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
