using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel.Design;


namespace MKproject.Schedule
{
    public partial class LabelTime : Label
    {
        //PROPERTY:
        private TimeSpan time;
        public TimeSpan Time
        {
            get { return time; }
            set
            {
                time = value;
                DateTime dateTime = DateTime.Today.Add(Time);//datetime it's a reference
                this.Text = dateTime.ToString("h:mm tt");
            }
        }

        //VARIABLE:
        CBdisplayTime displaytime;


        //INITIALISE
        public LabelTime()
        {
        }
        public LabelTime(TimeSpan time, CBdisplayTime form1)
        {
            Time = time;
            displaytime = form1;

            this.Size = new Size(101, 30);
            this.Font = new Font("Segoe UI", 10.25f);
            this.BackColor = Color.White;
            this.Margin = new Padding(0);
            this.TextAlign = ContentAlignment.MiddleCenter;

            this.MouseMove += labeltime_MouseMove;
            this.MouseLeave += labeltime_MouseLeave;
            this.MouseClick += labeltime_MouseClick;

            this.MouseEnter += displaytime.flowLayoutPanelContainerTime_MouseEnter;
        }



        //CLICK
        private void labeltime_MouseClick(object sender, MouseEventArgs e)
        {


            displaytime.textBoxTime.Text = this.Text;
            displaytime.Close();

        }



        //DESIGN
        private void labeltime_MouseMove(object sender, MouseEventArgs e)
        {
           
                // MouseMove event handler
                Label label = (Label)sender;
                label.BackColor = Color.FromArgb(229, 226, 244);
           
        }

        private void labeltime_MouseLeave(object sender, EventArgs e)
        {
            if (displaytime.targetlabeltimeHighlight.Time == this.Time)
            {

            }
            else
            {
                // MouseLeave event handler
                Label label = (Label)sender;
                label.BackColor = Color.White;
            }
        }

    }
}
