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
        //Property
        TimeSpan DifferenceTime { get; set; }
        private bool isClientModeOn = true;
        public bool IsClientModeOn
        {
            get { return isClientModeOn; }
            set
            {
                isClientModeOn = value;
                if (isClientModeOn == true)
                {
                    ClientModeOn();
                }
                else
                {
                    OthersModeOn();
                }
            }
        }


        //VARIABLES
        UCDay ucday;
        UCTime uctime;

        DateTime dateTime;
        bool isstarttime;
        int coach_id;

      
        ClassAppointment DesiredAppointment = new ClassAppointment();

        UCOthersApp ucOthersApp;
        UCClientApp ucClientApp;


        //Initialise:
        public Appointment(UCappointments ucappointments)
        {
            InitializeComponent();
        }
        public Appointment(UCDay form2, UCTime form1, int number1)
        {
            InitializeComponent();
            uctime = form1;
            ucday = form2;
            coach_id = number1;

            LoadForm();
        }


        //Functions:
        ///Initialise
        private void LoadForm()
        {
            SetUCSlidebutton();

            TimeSpan endtime;
            if (uctime.Time == new TimeSpan(23, 0, 0))
            {
                endtime = uctime.Time + TimeSpan.FromMinutes(45);
            }
            else
            {
                endtime = uctime.Time + TimeSpan.FromHours(1);
            }

            //badde yehoun kermel bel display ma hada yotlaee fo2 tene
            DesiredAppointment.StartTime = ucday.DateUCDay.Date + uctime.Time;
            textBoxStartTime.Text = DesiredAppointment.StartTime.ToString("h:mm tt");

            DesiredAppointment.EndTime = ucday.DateUCDay.Date + endtime;
            textBoxEndTime.Text = DesiredAppointment.EndTime.ToString("h:mm tt");


            DifferenceTime = DesiredAppointment.EndTime.TimeOfDay - DesiredAppointment.StartTime.TimeOfDay;
            labelDifferenceTime.Text = DifferenceTime.ToString(@"hh\:mm\:ss");
            labelDifferenceTime.Select();
        }

        ///DifferenceTime
        public void HandleDifferenceTimeChanged()
        {
            string formattedTime;

            //00:00:00
            if (DifferenceTime.Minutes == 0 && DifferenceTime.Hours == 0)
            {
                formattedTime = DifferenceTime.ToString(@"hh\:mm\:ss");
            }
            //3h
            else if (DifferenceTime.Minutes == 0)
            {
                formattedTime = $"{(int)DifferenceTime.Hours}h";
            }
            //3m
            else if (DifferenceTime.Hours == 0)
            {
                formattedTime = $"{(int)DifferenceTime.Minutes}m";
            }
            //3h 20m
            else
            {
                formattedTime = $"{(int)DifferenceTime.Hours}h {(int)DifferenceTime.Minutes}m";
            }
            labelDifferenceTime.Text = formattedTime;
            labelDifferenceTime.Select();
        }

        ///UCSlidebutton
        void SetUCSlidebutton()
        {
            //Awal ma yenkhala2 lform byenkhala2 lobject
            ucClientApp = new UCClientApp();
            ClientModeOn();

            ucSlideButtonClientOrOthers.Button1Clicked += UcSlideButtonPayOrEdit_Button1Clicked;
            ucSlideButtonClientOrOthers.Button2Clicked += UcSlideButtonPayOrEdit_Button2Clicked;

            ucSlideButtonClientOrOthers.button1.Text = "Client";
            ucSlideButtonClientOrOthers.button2.Text = "Others";
        }
        void ClientModeOn()
        {
            if (TLPGlobal.Controls.Contains(ucOthersApp))
            {
                TLPGlobal.Controls.Remove(ucOthersApp);
            }
            TLPGlobal.Controls.Add(ucClientApp, 0, 1);
            ucClientApp.Dock = DockStyle.Fill;
        }
        void OthersModeOn()
        {
            if (TLPGlobal.Controls.Contains(ucClientApp))
            {
                TLPGlobal.Controls.Remove(ucClientApp);
            }
            TLPGlobal.Controls.Add(ucOthersApp, 0, 1);
            ucOthersApp.Dock = DockStyle.Fill;
        }

        ///Appointment
        void SetUPUCAppointment()
        {
            //teletshi manna nekhoud endtime wel start time1  wen haweloun la datetime
            string starttimestring = (string)textBoxStartTime.Text;//7:00 PM
            string endtimestring = (string)textBoxEndTime.Text;

            DateTime HourStartTime;
            DateTime.TryParseExact(starttimestring, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out HourStartTime);//h for hour, mm for minutes and tt for AM/PM, we are converting string to DateTime.Time1
            DateTime HourEndTime;
            DateTime.TryParseExact(endtimestring, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out HourEndTime);

            DesiredAppointment.StartTime = ucday.DateUCDay.Date + HourStartTime.TimeOfDay;
            DesiredAppointment.EndTime = ucday.DateUCDay.Date + HourEndTime.TimeOfDay;

            //ekhir shi lba2we
            DesiredAppointment.Notes = textBoxNotes.Text;
            DesiredAppointment.OnPending = false;//if it's checked ,thn it's true

            //SQL:
            int idappointment = DesiredAppointment.AddFromAppoitementtoSQL();
            DesiredAppointment.IdAppointment = idappointment;   

            ucday.AddUCappointments(DesiredAppointment);

            this.Close();
        }


        //Events:
        ///StartTime & EndTime
        private void textBoxStartTime_Click(object sender, EventArgs e)
        {
            isstarttime = true;

            //Constructor
            CBdisplayTime displaytime = new CBdisplayTime(textBoxStartTime.Text, isstarttime, DesiredAppointment, textBoxStartTime);//MEN SE3A 12:00 AM (00:00:00) lal 11:30 PM

            //Design
            Point locationRelativeToScreen = textBoxStartTime.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-2, -2);
            displaytime.Location = locationRelativeToScreen;
            displaytime.Show();
        }
        private void textBoxEndTime_Click(object sender, EventArgs e)
        {
            isstarttime = false;

            //Constructor
            CBdisplayTime displayendtime = new CBdisplayTime(textBoxEndTime.Text, isstarttime, DesiredAppointment, textBoxEndTime);//MEN SE3A 12:00 AM (00:00:00) lal 11:30 PM

            //Design
            Point locationRelativeToScreen = textBoxEndTime.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-2, -2);
            displayendtime.Location = locationRelativeToScreen;
            displayendtime.Show();
        }
        private void textBoxStartTime_TextChanged(object sender, EventArgs e)
        {
            DifferenceTime = DesiredAppointment.EndTime.TimeOfDay - DesiredAppointment.StartTime.TimeOfDay;
            labelDifferenceTime.Text = DifferenceTime.ToString(@"hh\:mm\:ss");
            labelDifferenceTime.Select();
        }
        private void textBoxEndTime_TextChanged(object sender, EventArgs e)
        {
            DifferenceTime = DesiredAppointment.EndTime.TimeOfDay - DesiredAppointment.StartTime.TimeOfDay;
            labelDifferenceTime.Text = DifferenceTime.ToString(@"hh\:mm\:ss");
            labelDifferenceTime.Select();
        }


        ///SetUCSlidebutton
        private void UcSlideButtonPayOrEdit_Button1Clicked(object sender, EventArgs e)
        {
            //Eza Kenna aa Others mana nrouh aa Client
            if (IsClientModeOn == false)
            {
                IsClientModeOn = true;//men wara set value ha taeemil lfunctions
            }
        }
        private void UcSlideButtonPayOrEdit_Button2Clicked(object sender, EventArgs e)
        {
            //Eza Kenna aa Client mana nrouh aa Others
            if (IsClientModeOn)
            {
                //Hek eza kabasana button2 la awal marra se3eta mnekhla2 lobject
                if(ucOthersApp == null)
                {
                    ucOthersApp = new UCOthersApp();
                }
                IsClientModeOn = false;//men wara set value ha taeemil lfunctions
            }
        }


        ///Done Button
        private void ButtonDone_Click(object sender, EventArgs e)
        {
            if (isClientModeOn)
            {
                if (DesiredAppointment.DesiredClient.ClientId == null)
                {
                    MessageBox.Show("Enter the Name of the client");
                }
                else
                {
                    //awal shi manna nekhoud title
                    //DesiredAppointment.DesiredClient = ucClientApp.textBoxSearch.Text;
                    SetUPUCAppointment();
                }
            }
            else
            {
                if (ucOthersApp.textBoxOthers.Text == ucOthersApp.textBoxOthers.PlaceholderText)
                {
                    MessageBox.Show("Enter the Title");
                }
                else
                {
                    //awal shi manna nekhoud title
                    DesiredAppointment.Title = ucOthersApp.textBoxOthers.Text;
                    SetUPUCAppointment();
                }
            }
        }
    }
}
