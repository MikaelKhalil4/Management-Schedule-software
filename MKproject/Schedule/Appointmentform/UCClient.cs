using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class UCClient : UserControl
    {
        //VARIABLES
        UCDay ucday;
        Appointment appointment;


        bool isstarttime;
        int coach_id;



        //INITIALISE
        public UCClient()
        {
            InitializeComponent();
        }
        public UCClient(UCDay form1, Appointment form2, int number1)
        {
            InitializeComponent();
            ucday = form1;
            appointment = form2;
            coach_id = number1;

            StaticClass.StaticStartTimeChanged += HandleStartTimeChanged;
            StaticClass.StaticEndTimeChanged += HandleEndTimeChanged;
            StaticClass.StaticDifferenceTimeChanged += HandleDifferenceTimeChanged;

            StaticClass.StaticClientNameChanged += HandleClientNameChanged;
            StaticClass.StaticClientTypeChanged += HandleClientTypeChanged;
        }


        //EVENTS
        ///-Those events is when we change the static lass immediatle there will be an interaction in the design changing textbox...
        public void HandleStartTimeChanged(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Today.Add(StaticClass.StartTime);//datetime it's a reference
            textBoxStartTime.Text = dateTime.ToString("h:mm tt");
            pictureBox1.Select();
        }
        public void HandleEndTimeChanged(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Today.Add(StaticClass.EndTime);//datetime it's a reference
            textBoxEndTime.Text = dateTime.ToString("h:mm tt");
            pictureBox1.Select();

        }
        public void HandleDifferenceTimeChanged(object sender, EventArgs e)
        {
            string formattedTime;

            //00:00:00
            if (StaticClass.DifferenceTime.Minutes == 0 && StaticClass.DifferenceTime.Hours == 0)
            {
                formattedTime = StaticClass.DifferenceTime.ToString(@"hh\:mm\:ss");
            }
            //3h
            else if (StaticClass.DifferenceTime.Minutes == 0)
            {
                formattedTime = $"{(int)StaticClass.DifferenceTime.Hours}h";
            }
            //3m
            else if (StaticClass.DifferenceTime.Hours == 0)
            {
                formattedTime = $"{(int)StaticClass.DifferenceTime.Minutes}m";
            }
            //3h 20m
            else
            {
                formattedTime = $"{(int)StaticClass.DifferenceTime.Hours}h {(int)StaticClass.DifferenceTime.Minutes}m";
            }
            labeldifferencetime.Text = formattedTime;
            pictureBox1.Select();

        }

        public void HandleClientNameChanged(object sender, EventArgs e)
        {
            textBoxFullName.Text = StaticClass.ClientName;
        }
        public void HandleClientTypeChanged(object sender, EventArgs e)
        {
            if (StaticClass.ClientType == StaticClass.Member)
            {
                radioButtonInvitation.Visible = false;
                radioButtonTrial.Visible = false;
            }
            else
            {
                radioButtonInvitation.Visible = true;
                radioButtonTrial.Visible = true;
            }
            pictureBox1.Select();
        }

        ///-Click
        private void buttonD_Click(object sender, EventArgs e)
        {
            //THERE'S no name
            if (textBoxFullName.Text == textBoxFullName.PlaceholderText)
            {
                MessageBox.Show("Enter the Name of the client");
            }
            //there's a name
            else
            {
                //awal shi manna nekhoud fullname
                string fullname = textBoxFullName.Text;

                //teletshi manna nekhoud endtime wel start time1  wen haweloun la datetime
                string starttimestring = (string)textBoxStartTime.Text;//7:00 PM
                string endtimestring = (string)textBoxEndTime.Text;

                DateTime HourStartTime;
                DateTime.TryParseExact(starttimestring, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out HourStartTime);//h for hour, mm for minutes and tt for AM/PM, we are converting string to DateTime.Time1
                DateTime HourEndTime;
                DateTime.TryParseExact(endtimestring, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out HourEndTime);

                DateTime starttime = ucday.DateUCDay.Date + HourStartTime.TimeOfDay;
                DateTime endtime = ucday.DateUCDay.Date + HourEndTime.TimeOfDay;

                //ekhir shi lba2we
                string notes = textBoxNotes.Text;
                bool onpending = checkBoxOnPending.Checked;//if it's checked ,thn it's true

                ucday.AddUCappointments(coach_id, StaticClass.Client_id, fullname, starttime, endtime, notes, onpending, StaticClass.ClientType);

                appointment.Close();
            }
        }
        private void textBoxFullName_Click(object sender, EventArgs e)
        {
            bool isreminder = false;
            CBsearchName searchname = new CBsearchName(textBoxFullName.Text, isreminder);
            Point locationRelativeToScreen = textBoxFullName.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(0, 0);
            searchname.Location = locationRelativeToScreen;
            searchname.Show();
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

        ///-RadioChanged
        private void radioButtonTrial_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTrial.Checked)
            {
                StaticClass.ClientType = StaticClass.Trial;
            }
            else
            {
                StaticClass.ClientType = StaticClass.Invitation;
            }
        }



        //DESIGN
        private void flowLayoutPanelNew_MouseMove(object sender, MouseEventArgs e)
        {
            flowLayoutPanelNew.BackColor = Color.FromArgb(229, 226, 244);
        }
        private void flowLayoutPanelNew_MouseLeave(object sender, EventArgs e)
        {
            flowLayoutPanelNew.BackColor = Color.White;
        }
        private void flowLayoutPanelNew_Paint(object sender, PaintEventArgs e)
        {
            using (Pen Pen = new Pen(Color.FromArgb(109, 122, 224), 1)) // 2 is the width of the border
            {
                // Get the panel
                Panel panel = sender as Panel;

                // Draw the red border around the panel
                e.Graphics.DrawRectangle(Pen, new Rectangle(0, 0, panel.Width - 1, panel.Height - 1));
            }
        }
    }
}
