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
        //testing the pu
        //Property
        TimeSpan DifferenceTime { get; set; }
        private bool isClientModeOn;
        public bool IsClientModeOn
        {
            get { return isClientModeOn; }
            set
            {
                isClientModeOn = value;
                if (isClientModeOn == true)
                {
                    ClientModeOnDesign();
                }
                else
                {
                    //ucClientApp.DesiredAppointment.DesiredClient = null;//fine shil ucClientApp., same references
                    //ucClientApp.ResetDesiredAppointmentspecificValues();
                    //ucClientApp.SetDesignMode(null);
                    OthersModeOnDesign();
                }
            }
        }


        //VARIABLES
        UCDay ucday;
        UCTime uctime;

        bool isstarttime;
        bool isAdd;

        int PositionCol;
        int PositionRow;


        ClassAppointment DesiredAppointment;

        UCOthersApp ucOthersApp;
        UCClientApp ucClientApp;
        UCappointment ucappointment;


       
        ///ADD
        public Appointment(UCDay UCday, UCTime UCtime, int employeeid)
        {
            InitializeComponent();
            isAdd = true;
            uctime = UCtime;
            ucday = UCday;

          
            DesiredAppointment = new ClassAppointment();
            DesiredAppointment.EmployeeId = employeeid;                      
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
            DesiredAppointment.EndTime = ucday.DateUCDay.Date + endtime;

            ucClientApp = new UCClientApp(DesiredAppointment);

            //Fill Design
            IsClientModeOn = true;
            SetUCSlidebutton();
            SetStartTimeAndEndTimeInDesign();
        }

        ///UPDATE
        public Appointment(UCappointment UCappointment, ClassAppointment desiredAppointment, UCDay UCday)
        {
            InitializeComponent();
            isAdd = false;
            ucday = UCday;

            ucappointment = UCappointment;
            DesiredAppointment = desiredAppointment;

            //Aam nekhoud Col and Row pos taba3 lucappointment
            TimeSpan starttimeTimeSpan = DesiredAppointment.StartTime.TimeOfDay;//bas kermel le2e uctime
            int HourOfTheAppointment = starttimeTimeSpan.Hours;//row and hours same position
            int employeePosition = ucday.ListEmployee_idAllTime.IndexOf((int)DesiredAppointment.EmployeeId);

            ucappointment.ColumnPosition = employeePosition + 1;//position flowlayoutpanel hiye position employee bel list-1 
            ucappointment.RowPosition = HourOfTheAppointment;

            SetUCSlidebutton();
            SetStartTimeAndEndTimeInDesign();

            ucOthersApp = new UCOthersApp(DesiredAppointment);
            ucClientApp = new UCClientApp(DesiredAppointment);

            if (DesiredAppointment.DesiredClient != null && DesiredAppointment.Title == null)
            {
                IsClientModeOn = true;
            }
            else if (DesiredAppointment.DesiredClient == null && DesiredAppointment.Title != null)
            {
                IsClientModeOn = false;
            }
        }

        //Functions:

        private void SetStartTimeAndEndTimeInDesign()
        {
          
            textBoxStartTime.Text = DesiredAppointment.StartTime.ToString("h:mm tt");

            textBoxEndTime.Text = DesiredAppointment.EndTime.ToString("h:mm tt");


            DifferenceTime = DesiredAppointment.EndTime.TimeOfDay - DesiredAppointment.StartTime.TimeOfDay;
            labelDifferenceTime.Text = DifferenceTime.ToString(@"hh\:mm\:ss");
            labelDifferenceTime.Select();

            textBoxNotes.Text = DesiredAppointment.Notes;
        }

      
        ///UCSlidebutton
        void SetUCSlidebutton()
        {
            ucSlideButtonClientOrOthers.Button1Clicked += UcSlideButtonPayOrEdit_Button1Clicked;
            ucSlideButtonClientOrOthers.Button2Clicked += UcSlideButtonPayOrEdit_Button2Clicked;

         
        }
        void ClientModeOnDesign()
        {
            if (TLPGlobal.Controls.Contains(ucOthersApp))
            {
                TLPGlobal.Controls.Remove(ucOthersApp);
            }
            TLPGlobal.Controls.Add(ucClientApp, 0, 1);
            ucClientApp.Dock = DockStyle.Fill;
        }
        void OthersModeOnDesign()
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


            if (isAdd)
            {
                //SQL:
                int idappointment = DesiredAppointment.AddFromAppoitementtoSQL();
                DesiredAppointment.IdAppointment = idappointment;


                //Design
                ucday.AddUCappointments(DesiredAppointment,PositionCol,PositionRow);
            }
            else
            {
                //SQL:
                DesiredAppointment.UpdateFromAppoitementtoSQL();

                //Design
                bool IsUCAppPosChanged;
                if (ucappointment.RowPosition == PositionRow && ucappointment.ColumnPosition == PositionCol)
                {
                    IsUCAppPosChanged = false;
                }
                else
                {
                    IsUCAppPosChanged = true;
                }
                ucappointment.UpdateAppointments(DesiredAppointment);
                ucday.ChangePositionUCappointments(ucappointment,DesiredAppointment, PositionCol, PositionRow, IsUCAppPosChanged);
            }

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
                //Hek eza kabasana button1 la awal marra se3eta mnekhla2 lobject
                if (ucClientApp == null)
                {
                    ucClientApp = new UCClientApp(DesiredAppointment);
                }
                IsClientModeOn = true;//men wara set value ha taeemil lfunctions
            }
        }
        private void UcSlideButtonPayOrEdit_Button2Clicked(object sender, EventArgs e)
        {
            //Eza Kenna aa Client mana nrouh aa Others
            if (IsClientModeOn)
            {
                //Hek eza kabasana button2 la awal marra se3eta mnekhla2 lobject
                if (ucOthersApp == null)
                {
                    ucOthersApp = new UCOthersApp(DesiredAppointment);
                }
                IsClientModeOn = false;//men wara set value ha taeemil lfunctions
            }
        }


        ///Done Button
        private void ButtonDone_Click(object sender, EventArgs e)
        {
            DesiredAppointment = ucClientApp.DesiredAppointment;
            //
            TimeSpan starttimeTimeSpan = DesiredAppointment.StartTime.TimeOfDay;//bas kermel le2e uctime
            int HourOfTheAppointment = starttimeTimeSpan.Hours;//row and hours same position
            int employeePosition = ucday.ListEmployee_idAllTime.IndexOf((int)DesiredAppointment.EmployeeId);

            //ListEmployee_idAllTime and EmployeeAvailabilityByOrder both are ranked by order => both same index
            bool IsPanelAvailable = false;
            string HoursAvailability = ucday.EmployeeAvailabilityByOrder[employeePosition];
            string[] TheHoursAvailability = HoursAvailability.Split('-');
            for (int i = 0; i < TheHoursAvailability.Count(); i++)
            {
                string positionrowstring = HourOfTheAppointment.ToString();

                if (TheHoursAvailability[i] == positionrowstring)
                {
                    IsPanelAvailable = true;
                    break;
                }
            }

            PositionCol = employeePosition + 1;//position flowlayoutpanel hiye position employee bel list-1 
            PositionRow = HourOfTheAppointment;

            if (IsPanelAvailable)
            {
                if (isClientModeOn)
                {
                    if (DesiredAppointment.DesiredClient == null)
                    {
                        MessageBox.Show("Enter the Name of the client");
                    }
                    else
                    {
                        //DesiredClient byekhdo deghre men search eza ken fi
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
            else
            {
                MessageBox.Show("This Time is not available");
            }
        }
    }
}
