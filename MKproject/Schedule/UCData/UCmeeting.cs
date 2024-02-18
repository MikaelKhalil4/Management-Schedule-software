using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace MKproject.Schedule
{
    public partial class UCmeeting : UserControl
    {
        //SQL
        static SqlConnection con = new SqlConnection(Program.DataLocation);

        //PROPERTY
        public int IdMeeting { get; set; }
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
            set { onpending = value; checkBoxMeeting.Checked = onpending; }
        }


        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; checkBoxMeeting.Text = title; }
        }

        //VARIABLES
        UCDay ucday;



        //INITIALISE
        public UCmeeting()
        {
            InitializeComponent();
        }

        //For Add and Select
        public UCmeeting(int idmeeting,int idcoach, string title, DateTime starttime, DateTime endtime, string note, bool onpending, UCDay form1)
        {
            InitializeComponent();
            DoubleBuffered = true;

            IdMeeting = idmeeting;
            IdCoach = idcoach;
            Title = title;
            StartTime = starttime;
            EndTime = endtime;
            Notes = note;
            OnPending = onpending;
            ucday = form1;
        }



        //UPDATE
        public void UpdateMeeting(string title, DateTime starttime, DateTime endtime, string note, bool onpending)
        {
            //SQL
            ProjectToSqlSchedule.UpdateFromMeetingtoSQL(IdMeeting, title, starttime, endtime, note, onpending);

            //DESIGN    
            Title = title;
            StartTime = starttime;
            EndTime = endtime;
            Notes = note;
            OnPending = onpending;
        }


       


        //EVENTS
        ///-CLICK
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            RemoveMeeting();
        }
        public void RemoveMeeting()
        {
            //SQL
            ProjectToSqlSchedule.DeleteAppointment(IdMeeting);

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
        private void UCmeeting_Click(object sender, EventArgs e)
        {
            if (TouchScroll.MoveHoldClick == false && ucday.IsHistory == false)
            {
                MeetingUpdate meetingupdate = new MeetingUpdate(this);
                meetingupdate.ShowDialog();
            }
            else
            {

            }
        }
        private void checkBoxMeeting_Click(object sender, EventArgs e)
        {
            //SQL
            ProjectToSqlSchedule.UpdateMeetingCheck(IdMeeting, checkBoxMeeting.Checked);

            //DESIGN
            OnPending = checkBoxMeeting.Checked;//tghayar l2esem hone bas houwe zeto ousoulan
            
        }



        //DESIGN
        private void UCmeeting_MouseMove(object sender, MouseEventArgs e)
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
        private void UCmeeting_MouseLeave(object sender, EventArgs e)
        {
            if (tableLayoutPanel2.BackColor != ucday.DisableColorTBUca)
            {
                tableLayoutPanel2.BackColor = Color.White;
            }
        }
    }
}
