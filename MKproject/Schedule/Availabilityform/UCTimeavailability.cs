using System;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class UCTimeavailability : UserControl
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
                    if(partstime[1]=="AM")
                    {
                        labelAm.Text = "am";
                    }
                    else
                    {
                        labelAm.Text = "pm";
                    }
                }//to transform a timespan into a string

            }
        }

        public UCTimeavailability()
        {
            InitializeComponent();
        }

        private void UCTimeavailability_Click(object sender, EventArgs e)
        {

        }


    }
}
