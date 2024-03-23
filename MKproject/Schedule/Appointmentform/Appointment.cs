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


        public ClassAppointment DesiredAppointmentAppForm;

        UCClientApp ucClientApp;
        UCappointment ucappointment;


        int ButtonWidthInUndoState = 134;
        int ButtonWidthInNormalState = 95;



        //ADD
        public Appointment(UCDay UCday, UCTime UCtime, int employeeid)
        {
            InitializeComponent();
            Opacity = 0;

            IsAddOrUpdate = true;
            ucTime = UCtime;
            UcDayParentForm = UCday;


            DesiredAppointmentAppForm = new ClassAppointment();
            DesiredAppointmentAppForm.EmployeeId = employeeid;
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
            DesiredAppointmentAppForm.StartTime = UcDayParentForm.SelectedDate.Date + ucTime.Time;
            DesiredAppointmentAppForm.EndTime = UcDayParentForm.SelectedDate.Date + endtime;

            ucClientApp = new UCClientApp(DesiredAppointmentAppForm);


            SetDesign();

        }

        //UPDATE
        public Appointment(UCappointment UCappointment, ClassAppointment desiredAppointment, UCDay UCday)
        {
            InitializeComponent();
            Opacity = 0;

            IsAddOrUpdate = false;
            UcDayParentForm = UCday;

            ucappointment = UCappointment;
            DesiredAppointmentAppForm = desiredAppointment;

            //Aam nekhoud Col and Row pos taba3 lucappointment
            TimeSpan starttimeTimeSpan = DesiredAppointmentAppForm.StartTime.TimeOfDay;//bas kermel le2e uctime
            int HourOfTheAppointment = starttimeTimeSpan.Hours;//row and hours same position
            int employeePosition = UcDayParentForm.ListEmployee_idAllTime.IndexOf((int)DesiredAppointmentAppForm.EmployeeId);

            ucappointment.ColumnPosition = employeePosition + 1;//position flowlayoutpanel hiye position employee bel list-1 
            ucappointment.RowPosition = HourOfTheAppointment;



            ucClientApp = new UCClientApp(DesiredAppointmentAppForm);

            SetDesign();


        }


        void SetDesign()
        {
            TLPGlobal.Controls.Add(ucClientApp, 0, 0);
            TLPGlobal.SetColumnSpan(ucClientApp, 2);
            ucClientApp.Dock = DockStyle.Fill;
            //
            textBoxStartTime.Text = DesiredAppointmentAppForm.StartTime.ToString("h:mm tt");
            textBoxEndTime.Text = DesiredAppointmentAppForm.EndTime.ToString("h:mm tt");

            DifferenceTime = DesiredAppointmentAppForm.EndTime.TimeOfDay - DesiredAppointmentAppForm.StartTime.TimeOfDay;
            labelDifferenceTime.Text = DifferenceTime.ToString(@"hh\:mm\:ss");
            labelDifferenceTime.Select();
            //

            labelEmployee.Text = DesiredAppointmentAppForm.EmployeeFullName;
            //
            if (!string.IsNullOrEmpty(DesiredAppointmentAppForm.Notes))
            {
                textBoxNotes.Text = DesiredAppointmentAppForm.Notes;
            }

            //
            if (IsAddOrUpdate)
            {

                ButtonAddOrUpdate.Text = "Add";

                buttonDelete.Visible = false;
                buttonCanceled.Visible = false;
                buttonCompleted.Visible = false;
            }
            else
            {


                ButtonAddOrUpdate.Text = "Update";
                buttonDelete.Visible = true;

                if (DesiredAppointmentAppForm.IsCanceled)
                {
                    buttonCompleted.Visible = false;
                    buttonCanceled.Width = ButtonWidthInUndoState;
                    buttonCanceled.Text = "Undo Cancelation";
                }
                else
                {
                    buttonCompleted.Visible = true;
                    buttonCanceled.Width = ButtonWidthInNormalState;
                    buttonCanceled.Text = "Canceled";
                }



                if (DesiredAppointmentAppForm.IsCompleted)
                {
                    buttonCanceled.Visible = false;
                    buttonCompleted.Width = ButtonWidthInUndoState;
                    buttonCompleted.Text = "Undo Completion";
                }
                else
                {
                    buttonCanceled.Visible = true;
                    buttonCompleted.Width = ButtonWidthInNormalState;
                    buttonCompleted.Text = "Completed";
                }
            }
        }




        //Events:
        ///StartTime & EndTime
        private void textBoxStartTime_Click(object sender, EventArgs e)
        {
            isstarttime = true;

            //Constructor
            CBdisplayTime displaytime = new CBdisplayTime(textBoxStartTime.Text, isstarttime, DesiredAppointmentAppForm, textBoxStartTime);//MEN SE3A 12:00 AM (00:00:00) lal 11:30 PM

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
            CBdisplayTime displayendtime = new CBdisplayTime(textBoxEndTime.Text, isstarttime, DesiredAppointmentAppForm, textBoxEndTime);//MEN SE3A 12:00 AM (00:00:00) lal 11:30 PM

            //Design
            Point locationRelativeToScreen = textBoxEndTime.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-2, -2);
            displayendtime.Location = locationRelativeToScreen;
            displayendtime.Show();
        }
        private void textBoxStartTime_TextChanged(object sender, EventArgs e)
        {
            DifferenceTime = DesiredAppointmentAppForm.EndTime.TimeOfDay - DesiredAppointmentAppForm.StartTime.TimeOfDay;
            labelDifferenceTime.Text = DifferenceTime.ToString(@"hh\:mm\:ss");
            labelDifferenceTime.Select();
        }
        private void textBoxEndTime_TextChanged(object sender, EventArgs e)
        {
            DifferenceTime = DesiredAppointmentAppForm.EndTime.TimeOfDay - DesiredAppointmentAppForm.StartTime.TimeOfDay;
            labelDifferenceTime.Text = DifferenceTime.ToString(@"hh\:mm\:ss");
            labelDifferenceTime.Select();
        }





        public event EventHandler OnAppointmentUpdate;//this event change the desin of the uc appointment
        void UpdateOrAddAppointment()
        {
            // Desiredclient tb3 el appointform w ucclientapp form are refering to the same block


            bool IsPanelAvailable = CheckIfTimeAvailableAndSetAppointmentPosition();//kermel naarif eza ghayarna waet el appointment, eza fi mahal ela

            if (IsPanelAvailable)
            {
                //Object
                FillDesiredClientObject();

                //Sql
                if (ucClientApp.IsServiceOrOthersMode)
                {

                    if (DesiredAppointmentAppForm.DesiredClient == null)
                    {
                        ucClientApp.textBoxSearch.IsRequiredModeOn = true;
                    }
                    else if (DesiredAppointmentAppForm.DesiredClientBalance == null && (DesiredAppointmentAppForm.ChoseBundlesString == null && DesiredAppointmentAppForm.ChosenBundlesList == null))
                    {
                        CustomMessageBox.Show("Select a package or a service", CustomMessageBox.Type.Ok);
                    }
                    else
                    {
                        AddOrUpdateSQL();
                    }
                }
                else if (!ucClientApp.IsServiceOrOthersMode)
                {
                    if (DesiredAppointmentAppForm.Title == null)
                    {
                        ucClientApp.textBoxTitle.IsRequiredModeOn = true;
                    }
                    else
                    {
                        AddOrUpdateSQL();
                    }
                }

            }
            else
            {
                CustomMessageBox.Show("This Time is not available,Choose another one ", CustomMessageBox.Type.Ok);
            }
        }
        void FillDesiredClientObject()
        {
            if (ucClientApp.IsServiceOrOthersMode)//service
            {
                DesiredAppointmentAppForm.Title = null;
            }
            else//others
            {
                string title = ucClientApp.textBoxTitle.Text;
                if (!String.IsNullOrEmpty(title) && title != ucClientApp.textBoxTitle.PlaceholderText)
                {
                    ucClientApp.FillObjectIfTitle(title);
                }
                DesiredAppointmentAppForm.ChosenBundlesList = null;
                DesiredAppointmentAppForm.DesiredClientBalance = null;
            }

            //Time
            string starttimestring = (string)textBoxStartTime.Text;//7:00 PM
            DateTime HourStartTime;
            DateTime.TryParseExact(starttimestring, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out HourStartTime);//h for hour, mm for minutes and tt for AM/PM, we are converting string to DateTime.Time1

            string endtimestring = (string)textBoxEndTime.Text;
            DateTime HourEndTime;
            DateTime.TryParseExact(endtimestring, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out HourEndTime);


            DesiredAppointmentAppForm.StartTime = UcDayParentForm.SelectedDate.Date + HourStartTime.TimeOfDay;
            DesiredAppointmentAppForm.EndTime = UcDayParentForm.SelectedDate.Date + HourEndTime.TimeOfDay;

            //Note
            string Note = textBoxNotes.Text;
            if (Note != textBoxNotes.PlaceholderText && !string.IsNullOrEmpty(Note))
            {
                DesiredAppointmentAppForm.Notes = Note;
            }
            else
            {
                DesiredAppointmentAppForm.Notes = null;
            }
        }
        void AddOrUpdateSQL()
        {
            if (IsAddOrUpdate)
            {
                //SQL:
                DesiredAppointmentAppForm.InsertOrUpdateAppointment(true);
                DesiredAppointmentAppForm.AppointmentID = ClassAppointment.GetLastAppointmentId();
                //Design
                UcDayParentForm.AddUCappointments(DesiredAppointmentAppForm, PositionCol, PositionRow);
            }
            else
            {
                //SQL:
                DesiredAppointmentAppForm.InsertOrUpdateAppointment(false);
                //Design
                ChangeAppointmentLocation();//Aam taamil error lamma aamil undocompletion
              
            }
        }
        bool CheckIfTimeAvailableAndSetAppointmentPosition()
        {
            //
            TimeSpan starttimeTimeSpan = DesiredAppointmentAppForm.StartTime.TimeOfDay;//bas kermel le2e uctime
            int HourOfTheAppointment = starttimeTimeSpan.Hours;//row and hours same position
            int employeePosition = UcDayParentForm.ListEmployee_idAllTime.IndexOf((int)DesiredAppointmentAppForm.EmployeeId);

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


            return IsPanelAvailable;
        }
        void ChangeAppointmentLocation()
        {
            //Design
            bool IsUCAppPosChanged;
            if (ucappointment.RowPosition == PositionRow && ucappointment.ColumnPosition == PositionCol)//checking eza tghayrarit its position or no
            {
                IsUCAppPosChanged = false;
            }
            else
            {
                IsUCAppPosChanged = true;
            }
            UcDayParentForm.ChangePositionUCappointments(ucappointment, DesiredAppointmentAppForm, PositionCol, PositionRow, IsUCAppPosChanged);
        }
        (double, DataTable) PurchaseNewSoloServices()
        {
            DateTime Date = DateTime.Now;
            DataTable PurchasedBundles = null;

            foreach (ClassBundles Bundle in DesiredAppointmentAppForm.ChosenBundlesList)
            {
                if (PurchasedBundles == null)//kermel yaamil clone w yekhud el shakel
                {
                    PurchasedBundles = ClassClient.PurchaseAService(Bundle, Date, DesiredAppointmentAppForm.DesiredClient, DesiredAppointmentAppForm.AppointmentID);
                }
                else
                {
                    DataTable dtinserteditem = ClassClient.PurchaseAService(Bundle, Date, DesiredAppointmentAppForm.DesiredClient, DesiredAppointmentAppForm.AppointmentID);

                    DataRow InsertedRow = dtinserteditem.Rows[0];//0 since it s only one row retrieve which is the new one       
                    DataRow NewRow = PurchasedBundles.NewRow();
                    NewRow.ItemArray = InsertedRow.ItemArray; // Copy the data from InsertedRow to NewRow
                    PurchasedBundles.Rows.Add(NewRow);
                }


            }

            double initialbalance = 0;
            foreach (DataRow row in PurchasedBundles.Rows)
            {
                initialbalance += (double)row["Balance"];
            }

            return (initialbalance, PurchasedBundles);

        }



        private void ButtonAddOrUpdate_Click(object sender, EventArgs e)
        {
            UpdateOrAddAppointment();
            OnAppointmentUpdate?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
        private void buttonCompleted_Click(object sender, EventArgs e)
        {
            if (!DesiredAppointmentAppForm.IsCompleted)
            {
                DesiredAppointmentAppForm.IsCompleted = true;
                UpdateOrAddAppointment();//ejbare tahet el completed

                if (DesiredAppointmentAppForm.ChosenBundlesList != null && DesiredAppointmentAppForm.DesiredClient != null)
                {
                    (double initialbalance, DataTable PurchasedBundles) = PurchaseNewSoloServices();

                    Payment paymentform = new Payment(DesiredAppointmentAppForm.DesiredClient, initialbalance, PurchasedBundles, null, true);
                    paymentform.ShowDialog();
                }
                else if (DesiredAppointmentAppForm.DesiredClientBalance != null && DesiredAppointmentAppForm.DesiredClient != null && DesiredAppointmentAppForm.DesiredClientBalance.ISPackageSessionsOrDays)
                {
                    if (DesiredAppointmentAppForm.DesiredClientBalance.SessionsLeft > 0)
                    {
                        ClassClientBalance.ReduceSessionFromPackageOfSessions(DesiredAppointmentAppForm.DesiredClient.ClientId, DesiredAppointmentAppForm.DesiredClientBalance.ClientBalanceID, (int)DesiredAppointmentAppForm.DesiredClientBalance.SessionsLeft - 1,DesiredAppointmentAppForm.AppointmentID);
                    }
                    else
                    {
                        //we can t reduce we need to show a notice
                    }
                }
            }
            else//in this case bi kun kell shi read only, that why ma mnaamil update la kell el info
            {
                DesiredAppointmentAppForm.IsCompleted = false;
                DesiredAppointmentAppForm.UndoCompletionAppointment();
            }

            OnAppointmentUpdate?.Invoke(this, EventArgs.Empty);
            this.Close();

        }
        private void buttonCanceled_Click(object sender, EventArgs e)
        {

            if (!DesiredAppointmentAppForm.IsCanceled)
            {
                DesiredAppointmentAppForm.IsCanceled = true;
                UpdateOrAddAppointment(); //ejabre tahtha
            }
            else//in this case bi kun kell shi read only, that why ma mnaamil update la kell el info

            {
                DesiredAppointmentAppForm.IsCanceled = false;//lezim nemnaa yghayir hayalla shi foe, read only kello
                DesiredAppointmentAppForm.SetOrResetIsCanceled();
                this.Close();
            }

            OnAppointmentUpdate?.Invoke(this, EventArgs.Empty);
            this.Close();

        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ucappointment.RemoveAppointment();
            this.Close();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .1;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}
