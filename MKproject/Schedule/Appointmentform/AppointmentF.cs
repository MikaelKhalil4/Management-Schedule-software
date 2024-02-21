using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace MKproject.Schedule
{
    public partial class AppointmentF : Form
    {
        //SQL
        SqlConnection con = new SqlConnection(Program.DataLocation);

        //VARIABLES:
        DateTime dateTime;

        UCTime uctime;
        UCDay ucday;
        UCClient ucclient;
        UCMeetingInAppointment ucmeetinginap;

        bool isbuttonclientclicked;
        int coach_id;

        

        //INITIALISE
        public AppointmentF(UCDay form2, UCTime form1, int number1)//HAYDA APPOINTMENT BYENFATAH EZA KENNA BI UCTableDay1 se3eta variable uctableday1 byekhdo
        {
            InitializeComponent();
            uctime = form1;
            ucday = form2;
            coach_id=number1;

            isbuttonclientclicked = true;
            ucmeetinginap = new UCMeetingInAppointment(ucday, this,coach_id);
            ucclient = new UCClient(ucday, this,coach_id);
            tableLayoutPanel2.Controls.Add(ucclient);
            ucclient.Dock = DockStyle.Fill;
            ucmeetinginap.Dock = DockStyle.Fill;


            
            TimeSpan endtime;
            if (uctime.Time == new TimeSpan(23, 0, 0))
            {
                endtime = uctime.Time + TimeSpan.FromMinutes(45);
            }
            else
            {
                endtime = uctime.Time + TimeSpan.FromHours(1);
            }
        
            //hone event relation ma3 ucclient wel ucmeeting fa tnaynetoun ha yet3adalo
            StaticClass.StartTime = uctime.Time;//badde yehoun kermel bel display ma hada yotlaee fo2 tene
            StaticClass.OnStaticStartTimeChanged();

            StaticClass.EndTime = endtime;
            StaticClass.OnStaticEndTimeChanged();


            StaticClass.DifferenceTime = StaticClass.EndTime - StaticClass.StartTime;
            StaticClass.OnStaticDifferenceTimeChanged();

           

            ucclient.pictureBox1.Select();
        }

       
       

        //EVENTS
        private void buttonClient_Click(object sender, EventArgs e)
        {
            if (isbuttonclientclicked)
            {
            }
            else
            {
                buttonClient.BackColor = Color.FromArgb(109, 122, 224);
                buttonMeeting.BackColor = Color.FromArgb(196, 210, 245);
                tableLayoutPanel2.Controls.Remove(ucmeetinginap);
                tableLayoutPanel2.Controls.Add(ucclient);
            }
            isbuttonclientclicked = true;
        }
        private void buttonMeeting_Click(object sender, EventArgs e)
        {
            if (isbuttonclientclicked)
            {
                buttonClient.BackColor = Color.FromArgb(196, 210, 245);
                buttonMeeting.BackColor = Color.FromArgb(109, 122, 224);
                tableLayoutPanel2.Controls.Remove(ucclient);
                tableLayoutPanel2.Controls.Add(ucmeetinginap);
            }
            else
            {
            }
            isbuttonclientclicked = false;
        }
        private void Appointment_FormClosed(object sender, FormClosedEventArgs e)
        {
            //moujarad ma yenfatah lappointment time byetghayar aand ltnen
            ucclient.Dispose();
            StaticClass.StaticStartTimeChanged -= ucclient.HandleStartTimeChanged;
            StaticClass.StaticEndTimeChanged -=  ucclient.HandleEndTimeChanged;
            StaticClass.StaticDifferenceTimeChanged -=  ucclient.HandleDifferenceTimeChanged;
            StaticClass.StaticClientNameChanged -=  ucclient.HandleClientNameChanged;
            StaticClass.StaticClientTypeChanged -=  ucclient.HandleClientTypeChanged;

            ucmeetinginap.Dispose();
            StaticClass.StaticStartTimeChanged -= ucmeetinginap.HandleStartTimeChanged;
            StaticClass.StaticEndTimeChanged -= ucmeetinginap.HandleEndTimeChanged;
            StaticClass.StaticDifferenceTimeChanged -= ucmeetinginap.HandleDifferenceTimeChanged;
        }
    }
}



///kermel starttime ma ykoun fo2 endtime wel endtime ma ykoun tahet starttime
//static public TimeSpan StartTime { get; set; }
//static public TimeSpan EndTime { get; set; }
//static public TimeSpan DifferenceTime { get; set; }




///protected override CreateParams CreateParams
//{
//    get
//    {
//        CreateParams cp = base.CreateParams;
//        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
//        return cp;
//    }
//}