using MKproject.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MKproject.Schedule
{
    public partial class Appointment : Form
    {
        //VARIABLES
        UCDay ucday;
        DateTime dateTime;

        UCTime uctime;

        bool isstarttime;
        int coach_id;

        ClassClient DesiredClient = new ClassClient();

        public Appointment()
        {
            InitializeComponent();
        }
        public Appointment(UCDay form2, UCTime form1, int number1)
        {
            InitializeComponent();
            uctime = form1;
            ucday = form2;
            coach_id = number1;


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

        }

        private void textBoxStartTime_Click(object sender, EventArgs e)
        {
            isstarttime = true;

            //Constructor
            CBdisplayTime displaytime = new CBdisplayTime(textBoxStartTime.Text, isstarttime);//MEN SE3A 12:00 AM (00:00:00) lal 11:30 PM

            //Design
            Point locationRelativeToScreen = textBoxStartTime.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(0, 0);
            displaytime.Location = locationRelativeToScreen;
            displaytime.Show();
        }

        private void textBoxEndTime_Click(object sender, EventArgs e)
        {
            isstarttime = false;

            //Constructor
            CBdisplayTime displayendtime = new CBdisplayTime(textBoxEndTime.Text, isstarttime);//MEN SE3A 12:00 AM (00:00:00) lal 11:30 PM

            //Design
            Point locationRelativeToScreen = textBoxEndTime.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(0, 0);
            displayendtime.Location = locationRelativeToScreen;
            displayendtime.Show();
        }
    }
}
