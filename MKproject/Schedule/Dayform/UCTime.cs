using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace MKproject.Schedule
{
    public partial class UCTime : UserControl
    {

        private TimeSpan time;
        public TimeSpan Time
        {
            get { return time; }
            set
            {
                time = value;

                {
                    DateTime dateTime = DateTime.Today.Add(Time);//datetime it's a reference
                    string timestring = dateTime.ToString("h:mm tt");
                    string[] partstime = timestring.Split(' ');
                    labelTime.Text = partstime[0];
                    labelAm.Text = partstime[1];
                }//to transform a timespan into a string

            }
        }
       
        public UCTime()
        {
            InitializeComponent();
            DoubleBuffered = true;

        }

        public List<TimeSpan> DisplayStartTime()
        {
            List<TimeSpan> displaystarttime = new List<TimeSpan>();

            displaystarttime.Add(Time);
            for (int i = 1; i < 4; i++)
            {
                displaystarttime.Add(displaystarttime[i - 1].Add(new TimeSpan(0, 15, 0)));
            }
            return displaystarttime;    
        }


        public List<TimeSpan> DisplayEndTime()//hone shi zyede enno manna nhotollo se3ten mesh bas se3a
        {
            List<TimeSpan> displayendtime = new List<TimeSpan>(9);

            displayendtime.Add(Time);
            for (int i = 1; i < 9; i++)
            {
                displayendtime.Add(displayendtime[i - 1].Add(new TimeSpan(0, 15, 0)));
            }
            return displayendtime;
        }


    }
}
