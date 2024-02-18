using System;
using System.Drawing;
using System.Windows.Forms;


namespace MKproject.Schedule
{
    public partial class MeetingUpdate : Form
    {
        UCmeeting ucmeeting;
        bool isstarttime;
        public MeetingUpdate()
        {
            InitializeComponent();
        }

        public MeetingUpdate(UCmeeting uc1)
        {
            InitializeComponent();
            ucmeeting = uc1;

            StaticClass.StaticStartTimeChanged += HandleStartTimeChanged;
            StaticClass.StaticEndTimeChanged += HandleEndTimeChanged;
            StaticClass.StaticDifferenceTimeChanged += HandleDifferenceTimeChanged;
        }
        private void MeetingUpdate_Load(object sender, EventArgs e)
        {
           

            textBoxTitle.Text = ucmeeting.Title;
            textBoxNotes.Text = ucmeeting.Notes;
            checkBoxOnPending.Checked = ucmeeting.OnPending;

            StaticClass.StartTime = ucmeeting.StartTime.TimeOfDay;//badde yehoun kermel bel display ma hada yotlaee fo2 tene
            textBoxStartTime.Text = ucmeeting.StartTime.ToString("h:mm tt");

            StaticClass.EndTime = ucmeeting.EndTime.TimeOfDay;
            textBoxEndTime.Text = ucmeeting.EndTime.ToString("h:mm tt");


            StaticClass.DifferenceTime = StaticClass.EndTime - StaticClass.StartTime;
            string formattedTime;
            if (StaticClass.DifferenceTime.Minutes == 0)
            {
                formattedTime = $"{(int)StaticClass.DifferenceTime.Hours}h";
            }
            else if (StaticClass.DifferenceTime.Hours == 0)
            {
                formattedTime = $"{(int)StaticClass.DifferenceTime.Minutes}m";
            }
            else
            {
                formattedTime = $"{(int)StaticClass.DifferenceTime.Hours}h {(int)StaticClass.DifferenceTime.Minutes}m";
            }
            labeldifferencetime.Text = formattedTime;

            pictureBox1.Select();
        }

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
            if (StaticClass.DifferenceTime.Minutes == 0 && StaticClass.DifferenceTime.Hours == 0)
            {
                formattedTime = StaticClass.DifferenceTime.ToString(@"hh\:mm\:ss");
            }
            else if (StaticClass.DifferenceTime.Minutes == 0)
            {
                formattedTime = $"{(int)StaticClass.DifferenceTime.Hours}h";
            }
            else if (StaticClass.DifferenceTime.Hours == 0)
            {
                formattedTime = $"{(int)StaticClass.DifferenceTime.Minutes}m";
            }
            else if (StaticClass.DifferenceTime.Minutes == 0 && StaticClass.DifferenceTime.Hours == 0)
            {
                formattedTime = StaticClass.DifferenceTime.ToString(@"hh\:mm\:ss");
            }
            else
            {
                formattedTime = $"{(int)StaticClass.DifferenceTime.Hours}h {(int)StaticClass.DifferenceTime.Minutes}m";
            }
            labeldifferencetime.Text = formattedTime;
            pictureBox1.Select();

        }



        private void textBoxStartTime_Click(object sender, EventArgs e)
        {
            isstarttime = true;
            CBdisplayTime displaytime = new CBdisplayTime(textBoxStartTime.Text, isstarttime);//MEN SE3A 12:00 AM (00:00:00) lal 11:30 PM
            Point locationRelativeToScreen = textBoxStartTime.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(0, 0);
            displaytime.Location = locationRelativeToScreen;
            displaytime.Show();
        }
        private void textBoxEndTime_Click(object sender, EventArgs e)
        {
            isstarttime = false;
            CBdisplayTime displayendtime = new CBdisplayTime(textBoxEndTime.Text, isstarttime);//MEN SE3A 12:00 AM (00:00:00) lal 11:30 PM
            Point locationRelativeToScreen = textBoxEndTime.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(0, 0);
            displayendtime.Location = locationRelativeToScreen;
            displayendtime.Show();
        }
        private void buttonD_Click(object sender, EventArgs e)
        {
            if (textBoxTitle.Text == textBoxTitle.PlaceholderText)
            {
                MessageBox.Show("Enter the Title");
            }
            else
            {
                //awal shi manna nekhoud fullname
                string title = textBoxTitle.Text;

                //teletshi manna nekhoud endtime wel start time1  wen haweloun la datetime
                string starttimestring = (string)textBoxStartTime.Text;//7:00 PM
                string endtimestring = (string)textBoxEndTime.Text;

                DateTime HourStartTime;
                DateTime.TryParseExact(starttimestring, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out HourStartTime);//h for hour, mm for minutes and tt for AM/PM, we are converting string to DateTime.Time1
                DateTime HourEndTime;
                DateTime.TryParseExact(endtimestring, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out HourEndTime);

                DateTime starttime = ucmeeting.StartTime.Date + HourStartTime.TimeOfDay;//ucmeeting.StartTime.Date bet hottelna date aw lpage li nehna fiya
                DateTime endtime = ucmeeting.StartTime.Date + HourEndTime.TimeOfDay;

                //ekhir shi lba2we
                string notes = textBoxNotes.Text;
                bool onpending = checkBoxOnPending.Checked;//if it's checked ,thn it's true

               ucmeeting.UpdateMeeting(title, starttime, endtime, notes, onpending);

                this.Close();
            }
        }
        private void buttonRemoveAppointment_Click(object sender, EventArgs e)
        {
            ucmeeting.RemoveMeeting();
            this.Close();
        }
    }
}
