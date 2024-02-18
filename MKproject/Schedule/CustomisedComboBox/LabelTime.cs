using System;
using System.Windows.Forms;
using System.Drawing;


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
        bool Isstarttime;
        CBdisplayTime displaytime;


        //INITIALISE
        public LabelTime()
        {
        }
        public LabelTime(TimeSpan time, CBdisplayTime form1,bool boolean)
        {
            Time = time;
            displaytime = form1;
            Isstarttime = boolean;

            this.Size = new Size(94, 24);
            this.Font = new Font("Segoe UI", 8.75f);
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

            if (Isstarttime)
            {
                displaytime.textBoxTime.Text = this.Text;
                displaytime.Close();
            }
            else
            {
                if (TouchScroll.MoveHoldClick == false)
                {
                    displaytime.textBoxTime.Text = this.Text;
                    displaytime.Close();
                }
                else
                {

                }
            }
        }



        //DESIGN
        private void labeltime_MouseMove(object sender, MouseEventArgs e)
        {
            if (TouchScroll.MoveHoldClick == false)
            {
                // MouseMove event handler
                Label label = (Label)sender;
                label.BackColor = Color.FromArgb(229, 226, 244);
            }
            else
            {

            }
        }

        private void labeltime_MouseLeave(object sender, EventArgs e)
        {
            // MouseLeave event handler
            Label label = (Label)sender;
            label.BackColor = Color.White;
        }

    }
}
