using CustomizedTools;
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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MKproject.Schedule
{
    public partial class Appointment : Form
    {
        //testing the pu
        //Property
        TimeSpan DifferenceTime { get; set; }



        //VARIABLES
        UCDay UcDayParentForm;
        UCTime ucTime;

        bool isstarttime;
        bool IsAddOrUpdate;

        int PositionCol;
        int PositionRow;


        ClassAppointment DesiredAppointment;

        UCClientApp ucClientApp;
        UCappointment ucappointment;


        int ButtonWidthInUndoState = 134;
        int ButtonWidthInNormalState = 95;
        //ADD
        public Appointment(UCDay UCday, UCTime UCtime, int employeeid)
        {
            InitializeComponent();
            IsAddOrUpdate = true;
            ucTime = UCtime;
            UcDayParentForm = UCday;


            DesiredAppointment = new ClassAppointment();
            DesiredAppointment.EmployeeId = employeeid;
            TimeSpan endtime;
            if (ucTime.Time == new TimeSpan(23, 0, 0))
            {
                endtime = ucTime.Time + TimeSpan.FromMinutes(45);
            }
            else
            {
                endtime = ucTime.Time + TimeSpan.FromHours(1);
            }
            //badde yehoun kermel bel display ma hada yotlaee fo2 tene
            DesiredAppointment.StartTime = UcDayParentForm.DateUCDay.Date + ucTime.Time;
            DesiredAppointment.EndTime = UcDayParentForm.DateUCDay.Date + endtime;

            ucClientApp = new UCClientApp(DesiredAppointment);


            SetDesign();

        }

        //UPDATE
        public Appointment(UCappointment UCappointment, ClassAppointment desiredAppointment, UCDay UCday)
        {
            InitializeComponent();
            IsAddOrUpdate = false;
            UcDayParentForm = UCday;

            ucappointment = UCappointment;
            DesiredAppointment = desiredAppointment;

            //Aam nekhoud Col and Row pos taba3 lucappointment
            TimeSpan starttimeTimeSpan = DesiredAppointment.StartTime.TimeOfDay;//bas kermel le2e uctime
            int HourOfTheAppointment = starttimeTimeSpan.Hours;//row and hours same position
            int employeePosition = UcDayParentForm.ListEmployee_idAllTime.IndexOf((int)DesiredAppointment.EmployeeId);

            ucappointment.ColumnPosition = employeePosition + 1;//position flowlayoutpanel hiye position employee bel list-1 
            ucappointment.RowPosition = HourOfTheAppointment;



            ucClientApp = new UCClientApp(DesiredAppointment);

            SetDesign();


        }

        void SetDesign()
        {
            TLPGlobal.Controls.Add(ucClientApp, 0, 0);
            TLPGlobal.SetColumnSpan(ucClientApp, 2);
            ucClientApp.Dock = DockStyle.Fill;

            if (IsAddOrUpdate)
            {
                buttonDelete.Visible = false;
                ButtonAddOrUpdate.Text = "Add";
            }
            else
            {
                SetStartTimeAndEndTimeInDesign();
                ButtonAddOrUpdate.Text = "Update";
                buttonDelete.Visible = true;
            }
        }

        private void SetStartTimeAndEndTimeInDesign()
        {

            textBoxStartTime.Text = DesiredAppointment.StartTime.ToString("h:mm tt");

            textBoxEndTime.Text = DesiredAppointment.EndTime.ToString("h:mm tt");


            DifferenceTime = DesiredAppointment.EndTime.TimeOfDay - DesiredAppointment.StartTime.TimeOfDay;
            labelDifferenceTime.Text = DifferenceTime.ToString(@"hh\:mm\:ss");
            labelDifferenceTime.Select();

            if (!string.IsNullOrEmpty(DesiredAppointment.Notes))
            {
                textBoxNotes.Text = DesiredAppointment.Notes;
            }
        }


        ///UCSlidebutton

        ///Appointment
        void SetUCAppointmentAndSql()
        {
            //teletshi manna nekhoud endtime wel start time1  wen haweloun la datetime
            string starttimestring = (string)textBoxStartTime.Text;//7:00 PM
            string endtimestring = (string)textBoxEndTime.Text;

            DateTime HourStartTime;
            DateTime.TryParseExact(starttimestring, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out HourStartTime);//h for hour, mm for minutes and tt for AM/PM, we are converting string to DateTime.Time1
            DateTime HourEndTime;
            DateTime.TryParseExact(endtimestring, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out HourEndTime);

            DesiredAppointment.StartTime = UcDayParentForm.DateUCDay.Date + HourStartTime.TimeOfDay;
            DesiredAppointment.EndTime = UcDayParentForm.DateUCDay.Date + HourEndTime.TimeOfDay;


            string Note = textBoxNotes.Text;
            if (Note != textBoxNotes.PlaceholderText && !string.IsNullOrEmpty(Note))
            {
                DesiredAppointment.Notes = Note;
            }
            else
            {
                DesiredAppointment.Notes = null;
            }

            if (IsAddOrUpdate)
            {
                //SQL:

                DesiredAppointment.InsertOrUpdateAppointment(true);
                DesiredAppointment.IdAppointment = ClassAppointment.GetLastAppointmentId();

                //Design
                UcDayParentForm.AddUCappointments(DesiredAppointment, PositionCol, PositionRow);
            }
            else
            {
                //SQL:
                DesiredAppointment.InsertOrUpdateAppointment(false);

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
                UcDayParentForm.ChangePositionUCappointments(ucappointment, DesiredAppointment, PositionCol, PositionRow, IsUCAppPosChanged);
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




        ///Done Button
      
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ucappointment.RemoveAppointment();
            this.Close();
        }

        private void ButtonAddOrUpdate_Click(object sender, EventArgs e)
        {
            if (ucClientApp.IsServiceOrOthersMode)//service
            {
                ucClientApp.DesiredAppointment.Title = null;
            }
            else//others
            {
                string title = ucClientApp.textBoxTitle.Text;
                if (!String.IsNullOrEmpty(title) && title != ucClientApp.textBoxTitle.PlaceholderText)
                {
                    ucClientApp.FillObjectIfTitle(title);
                }

                ucClientApp.DesiredAppointment.ChosenBundlesList = null;
                ucClientApp.DesiredAppointment.DesiredClientBalance = null;
            }
            DesiredAppointment = ucClientApp.DesiredAppointment;


            //
            TimeSpan starttimeTimeSpan = DesiredAppointment.StartTime.TimeOfDay;//bas kermel le2e uctime
            int HourOfTheAppointment = starttimeTimeSpan.Hours;//row and hours same position
            int employeePosition = UcDayParentForm.ListEmployee_idAllTime.IndexOf((int)DesiredAppointment.EmployeeId);

            //ListEmployee_idAllTime and EmployeeAvailabilityByOrder both are ranked by order => both same index
            bool IsPanelAvailable = false;
            string HoursAvailability = UcDayParentForm.EmployeeAvailabilityByOrder[employeePosition];
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
                if (ucClientApp.IsServiceOrOthersMode)
                {

                    if (DesiredAppointment.DesiredClient == null)
                    {
                        ucClientApp.textBoxSearch.IsRequiredModeOn = true;
                    }
                    else if (DesiredAppointment.DesiredClientBalance == null && (DesiredAppointment.ChoseBundlesString == null && DesiredAppointment.ChosenBundlesList == null))
                    {
                        CustomMessageBox.Show("Select a package or a service", CustomMessageBox.Type.Ok);
                    }
                    else
                    {
                        SetUCAppointmentAndSql();
                    }

                }
                else if (!ucClientApp.IsServiceOrOthersMode)
                {
                    if (DesiredAppointment.Title == null)
                    {
                        ucClientApp.textBoxTitle.IsRequiredModeOn = true;
                    }
                    else
                    {
                        SetUCAppointmentAndSql();
                    }
                }
            }
            else
            {
                CustomMessageBox.Show("This Time is not available,Choose another one ", CustomMessageBox.Type.Ok);
            }
        }
    }
}
