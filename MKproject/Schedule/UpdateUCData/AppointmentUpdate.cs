using MKproject.Management;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace MKproject.Schedule
{
    public partial class AppointmentUpdate : Form
    {
        //Hawde properties ma aam nestaeemeloun bas mawjoudin bel static
        public int Client_id { get; set; }
        public string ClientType { get; set; }


        //Variables
        UCappointments ucappointments;
        bool isstarttime;

        ClassClient DesiredClient = new ClassClient();

        //Initialise
        public AppointmentUpdate(UCappointments uc1)
        {

            InitializeComponent();
            ucappointments = uc1;


            StaticClass.StaticStartTimeChanged += HandleStartTimeChanged;
            StaticClass.StaticEndTimeChanged += HandleEndTimeChanged;
            StaticClass.StaticDifferenceTimeChanged += HandleDifferenceTimeChanged;

            StaticClass.StaticClientNameChanged += HandleClientNameChanged;
            StaticClass.StaticClientTypeChanged += HandleClientTypeChanged;

        }
        private void AppointmentUpdate_Load(object sender, EventArgs e)
        {
            DesiredClient.FullName = ucappointments.FullName;
            DesiredClient.ClientId = ucappointments.IdClient;

            textBoxFullName.Text = ucappointments.FullName;
            textBoxNotes.Text = ucappointments.Notes;
            checkBoxOnPending.Checked = ucappointments.OnPending;

            StaticClass.StartTime = ucappointments.StartTime.TimeOfDay;//badde yehoun kermel bel display ma hada yotlaee fo2 tene
            textBoxStartTime.Text = ucappointments.StartTime.ToString("h:mm tt");

            StaticClass.EndTime = ucappointments.EndTime.TimeOfDay;
            textBoxEndTime.Text = ucappointments.EndTime.ToString("h:mm tt");


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

            StaticClass.ClientType = ucappointments.ClientType;        
            pictureBox1.Select();

        }



        //EVENTS
        ///-CLICK
        private void buttonD_Click(object sender, EventArgs e)
        {
            if (textBoxFullName.Text == textBoxFullName.PlaceholderText)
            {
                MessageBox.Show("Enter the Name of the client");
            }
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


                DateTime starttime = ucappointments.StartTime.Date + HourStartTime.TimeOfDay;
                DateTime endtime = ucappointments.EndTime.Date + HourEndTime.TimeOfDay;

                //ekhir shi lba2we
                string notes = textBoxNotes.Text;
                bool onpending = checkBoxOnPending.Checked;//if it's checked ,thn it's true

                ucappointments.UpdateAppointments(DesiredClient.ClientId, fullname, starttime, endtime, notes, onpending, StaticClass.ClientType);
                this.Close();
            }
        }
        private void textBoxFullName_Click(object sender, EventArgs e)
        {
      
            Search searchname = new Search(textBoxFullName, DesiredClient);
            searchname.Deactivate += Searchname_Deactivate;    
            Point locationRelativeToScreen = textBoxFullName.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(0, 0);
            searchname.Location = locationRelativeToScreen;
            searchname.Show();
        }

        private void Searchname_Deactivate(object sender, EventArgs e)
        {
            label1.Select();
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

        ///-Those events is when we change the static lass immediatle there will be an interaction in the design changing textbox...
        private void HandleStartTimeChanged(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Today.Add(StaticClass.StartTime);//datetime it's a reference
            textBoxStartTime.Text = dateTime.ToString("h:mm tt");
            pictureBox1.Select();
        }
        private void HandleEndTimeChanged(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Today.Add(StaticClass.EndTime);//datetime it's a reference
            textBoxEndTime.Text = dateTime.ToString("h:mm tt");
            pictureBox1.Select();

        }
        private void HandleDifferenceTimeChanged(object sender, EventArgs e)
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
 
        private void HandleClientNameChanged(object sender, EventArgs e)
        {
            textBoxFullName.Text = DesiredClient.FullName;
        }
        private void HandleClientTypeChanged(object sender, EventArgs e)
        {
            if (DesiredClient.RegistrationDate != null)
            {

            }
            else
            {

            }
            pictureBox1.Select();
        }

        ///-RadioChanged
     

        ///-Closed
        private void AppointmentUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticClass.StaticStartTimeChanged -= HandleStartTimeChanged;
            StaticClass.StaticEndTimeChanged -= HandleEndTimeChanged;
            StaticClass.StaticDifferenceTimeChanged -= HandleDifferenceTimeChanged;
            StaticClass.StaticClientNameChanged -= HandleClientNameChanged;
            StaticClass.StaticClientTypeChanged -= HandleClientTypeChanged;
        }

        private void buttonRemoveAppointment_Click(object sender, EventArgs e)
        {
            ucappointments.RemoveAppointment();
            this.Close();
        }
    }
}
