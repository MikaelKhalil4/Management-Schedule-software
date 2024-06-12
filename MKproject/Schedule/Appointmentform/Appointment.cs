using CustomizedTools;
using GlobalFunctions;
using MKproject.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
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
        public TimeSpan DifferenceTime { get; set; }

        public bool IsReadOrEdit { get; set; }
        bool IsAddOrUpdateMode { get; set; }

        //VARIABLES
        public UCSchedule UcScheduleParentForm;


        bool isstarttime;






        public ClassAppointment DesiredAppointmentAppForm;
        public ClassAppointment OldDesiredAppointmentAppForm;//al undo bel Notf banner

        public UCClientApp ucClientApp;
        public UCappointment UCappointment;


        int ButtonWidthInUndoState = 134;
        int ButtonWidthInNormalState = 95;
        public bool DisableClosingOnDisactivating;


        //Past Tools
        Label LabelNote;
        Label LabelNoteOutput;
        Label LabelStartTime;
        Label LabelEndTime;
        Label labelEmployee;
        //Present Tools
        TextBoxWithPlaceHolder textBoxNotes;

        NotificationBanner NotfBanner = null;
        bool UndoFromNotficationBannerModeOn = false;

        //ADD
        public Appointment(UCSchedule ucSch, ClassEmployee selectedEmployee, DateTime StartTime)
        {
            InitializeComponent();
            Opacity = 0;

            IsReadOrEdit = false;//adding Mode
            IsAddOrUpdateMode = true;

            UcScheduleParentForm = ucSch;


            DesiredAppointmentAppForm = new ClassAppointment();


            DesiredAppointmentAppForm.DesiredEmployee = selectedEmployee;


            DesiredAppointmentAppForm.StartTime = StartTime;

            if (DesiredAppointmentAppForm.StartTime.TimeOfDay < new TimeSpan(23, 0, 0))
            {
                DesiredAppointmentAppForm.EndTime = DesiredAppointmentAppForm.StartTime.AddHours(1);
            }
            else
            {
                DesiredAppointmentAppForm.EndTime = DesiredAppointmentAppForm.StartTime.Date + new TimeSpan(23, 45, 0);
            }


            ucClientApp = new UCClientApp(this);

            SetDesign();

        }

        //UPDATE
        public Appointment(UCappointment ucappointment, UCSchedule uCSchedule)
        {
            InitializeComponent();
            Opacity = 0;

            IsAddOrUpdateMode = false;
            UcScheduleParentForm = uCSchedule;
            UCappointment = ucappointment;


            DesiredAppointmentAppForm = ucappointment.DesiredAppointmentUCApp.Copy();//as we see hone eena copy aan el ucappointmnet, bas ucClientApp refers to the same DesiredAppointmentAppForm metel el appointment form


            if (DesiredAppointmentAppForm.StartTime.Date < DateTime.Now.Date || DesiredAppointmentAppForm.IsCompleted || DesiredAppointmentAppForm.IsCanceled || (!UcScheduleParentForm.IsDayOrWeek && UcScheduleParentForm.TheOnlyEmployee == null))
            {
                IsReadOrEdit = true;
            }


            ucClientApp = new UCClientApp(this);

            BackOffice.UndoHappened += BackOffice_UndoHappened;//khotra a static event lieanno baddak tentebih tnaesa kell marra bet sakkir el  form as we did tahet bel event on closed


            SetDesign();

        }



        void SetDesign()
        {


            TLPGlobal.Controls.Add(ucClientApp, 0, 0);
            TLPGlobal.SetColumnSpan(ucClientApp, 2);
            ucClientApp.Anchor = AnchorStyles.None;
            //
            //should be considered once hattayta combobox

            //Duration
            DifferenceTime = DesiredAppointmentAppForm.EndTime.TimeOfDay - DesiredAppointmentAppForm.StartTime.TimeOfDay;
            LabelDuration.Text = $"{(int)DifferenceTime.TotalMinutes} min";

            if (!IsReadOrEdit)
            {
                this.Width = 463;
                CreatingPresentTools();
                //
                textBoxEndTime.Visible = true;
                textBoxStartTime.Visible = true;
                textBoxStartTime.Text = DesiredAppointmentAppForm.StartTime.ToString("h:mm tt");
                textBoxEndTime.Text = DesiredAppointmentAppForm.EndTime.ToString("h:mm tt");

                //
                foreach (ClassEmployee emp in UcScheduleParentForm.EmployeeScheduleListWorkingOn)
                {
                    if (emp.IsChecked)
                    {
                        var item = new
                        {
                            Text = $"{emp.Fname} {emp.Lname}",
                            Value = emp
                        };

                        comboBoxEmployee.Items.Add(item);
                        comboBoxEmployee.DisplayMember = "Text";
                        comboBoxEmployee.ValueMember = "Value";
                    }
                    comboBoxEmployee.Width = FunctionsForWinformsTool.ReturnComboBoxWidth(comboBoxEmployee) + 17;
                }
                comboBoxEmployee.SelectedIndex = comboBoxEmployee.FindString($"{DesiredAppointmentAppForm.DesiredEmployee.Fname} {DesiredAppointmentAppForm.DesiredEmployee.Lname}");

                //

                TLPGlobal.Controls.Add(textBoxNotes, 0, 5);
                TLPGlobal.SetColumnSpan(textBoxNotes, 2);
                if (!string.IsNullOrEmpty(DesiredAppointmentAppForm.Notes))
                {
                    textBoxNotes.Text = DesiredAppointmentAppForm.Notes;
                }

                //
                if (IsAddOrUpdateMode)//ma mneedar nfout aalaya since bel past mamnuu to add an apointment
                {

                    ButtonAddOrUpdate.Text = "Add";

                    buttonDelete.Visible = false;
                    buttonCanceled.Visible = false;
                    buttonCompleted.Visible = false;
                }
                else
                {

                    ButtonAddOrUpdate.Visible = true;
                    ButtonAddOrUpdate.Text = "Update";
                    buttonDelete.Visible = true;
                }


            }
            else
            {
                this.Width = 360;

                ButtonAddOrUpdate.Visible = false;
                buttonDelete.Visible = false;
                textBoxEndTime.Visible = false;
                textBoxStartTime.Visible = false;
                comboBoxEmployee.Visible = false;
                //
                TLPGlobal.RowStyles[5].Height = TLPGlobal.RowStyles[4].Height;// making the height of the note add li fawea

                CreatingPastModeTools();
                TLPGlobal.Controls.Add(LabelNoteOutput, 0, 5);
                TLPGlobal.Controls.Add(LabelNote, 1, 5);
                //
                //MainMenuStrip lezim ykun mawjudin men e asel, lezim gab yaamellun global tools


                LabelStartTime.Text = DesiredAppointmentAppForm.StartTime.ToString("h:mm tt");
                TLPGlobal.Controls.Add(LabelStartTime, 1, 1);

                LabelEndTime.Text = DesiredAppointmentAppForm.EndTime.ToString("h:mm tt");
                TLPGlobal.Controls.Add(LabelEndTime, 1, 2);

                labelEmployee.Text = DesiredAppointmentAppForm.DesiredEmployee.Fname + " " + DesiredAppointmentAppForm.DesiredEmployee.Lname;
                TLPGlobal.Controls.Add(labelEmployee, 1, 4);

            }


            if (DesiredAppointmentAppForm.StartTime.Date <= DateTime.Now.Date)//present-past
            {
                //Always
                if (!IsAddOrUpdateMode)
                {
                    if (DesiredAppointmentAppForm.IsCanceled)
                    {
                        buttonCompleted.Visible = false;
                        buttonCanceled.Width = ButtonWidthInUndoState;
                        buttonCanceled.BackAndMouseHoverColor = Program.BoldColor;
                        buttonCanceled.Text = "Undo Cancelation";
                    }
                    else
                    {
                        buttonCompleted.Visible = true;
                        buttonCanceled.Width = ButtonWidthInNormalState;
                        buttonCanceled.BackAndMouseHoverColor = Color.Red;
                        buttonCanceled.Text = "Canceled";
                    }

                    SetCompletionModeDesign();
                }
                else//Add
                {
                    buttonCanceled.Visible = false;
                    buttonCompleted.Visible = false;
                }
            }
            else//future
            {
                buttonCanceled.Visible = false;
                buttonCompleted.Visible = false;
            }

            TLPGlobal.RowStyles[0].Height = ucClientApp.Height;
            FunctionsForWinformsTool.AdjustTableLayoutPanelHeight(TLPGlobal);

            this.Height = TLPGlobal.Height + 50;
            TLPGlobal.Dock = DockStyle.Fill;
        }
        void SetCompletionModeDesign()
        {
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
        public void UpdateTimeDesign()//used when we choose a service men cclientapp
        {
            //Duration
            DifferenceTime = DesiredAppointmentAppForm.EndTime.TimeOfDay - DesiredAppointmentAppForm.StartTime.TimeOfDay;
            LabelDuration.Text = $"{(int)DifferenceTime.TotalMinutes} min";
            textBoxStartTime.Text = DesiredAppointmentAppForm.StartTime.ToString("h:mm tt");
            textBoxEndTime.Text = DesiredAppointmentAppForm.EndTime.ToString("h:mm tt");
        }

        void CreatingPresentTools()//the other mawjuding by design
        {
            textBoxNotes = new TextBoxWithPlaceHolder();
            textBoxNotes.PlaceholderText = "Notes";
            textBoxNotes.BackColor = this.BackColor;
            textBoxNotes.BorderStyle = BorderStyle.Fixed3D;
            textBoxNotes.Margin = new Padding(7, 3, 6, 3);
            textBoxNotes.Font = new Font("Segoe UI ", 12F, System.Drawing.FontStyle.Regular);
            textBoxNotes.Multiline = true;
            textBoxNotes.Dock = DockStyle.Top;
            textBoxNotes.Height = 61;
        }
        void CreatingPastModeTools()
        {

            LabelNote = new Label();
            LabelNote.Font = new Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            LabelNote.AutoSize = true;
            LabelNote.Margin = new Padding(6);
            LabelNote.Anchor = AnchorStyles.Right;
            if (!string.IsNullOrEmpty(DesiredAppointmentAppForm.Notes))
            {
                LabelNote.Text = DesiredAppointmentAppForm.Notes;

            }
            else
            {
                LabelNote.Text = "N/A";
            }

            LabelNoteOutput = new Label();
            LabelNoteOutput.Text = "Note:";
            LabelNoteOutput.Margin = new Padding(6);
            LabelNoteOutput.Font = new Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular | System.Drawing.FontStyle.Italic);
            LabelNoteOutput.AutoSize = true;
            LabelNoteOutput.Anchor = AnchorStyles.Left;


            LabelStartTime = new Label();
            LabelStartTime.Font = new Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            LabelStartTime.AutoSize = true;
            LabelStartTime.Margin = new Padding(6);
            LabelStartTime.Anchor = AnchorStyles.Right;
            LabelStartTime.Text = DesiredAppointmentAppForm.StartTime.ToString("h:mm tt");

            LabelEndTime = new Label();
            LabelEndTime.Font = new Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            LabelEndTime.AutoSize = true;
            LabelEndTime.Margin = new Padding(6);
            LabelEndTime.Anchor = AnchorStyles.Right;
            LabelEndTime.Text = DesiredAppointmentAppForm.EndTime.ToString("h:mm tt");

            labelEmployee = new Label();
            labelEmployee.Font = new Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            labelEmployee.AutoSize = true;
            labelEmployee.Margin = new Padding(6);
            labelEmployee.Anchor = AnchorStyles.Right;

        }



        //Events:
        ///StartTime & EndTime GAB Section
        private void textBoxStartTime_Click(object sender, EventArgs e)
        {
            isstarttime = true;

            //Constructor
            DisableClosingOnDisactivating = true;
            CBdisplayTime displaystarttime = new CBdisplayTime(isstarttime, this);//MEN SE3A 12:00 AM (00:00:00) lal 11:30 PM
            displaystarttime.Deactivate += Displaytime_Deactivate;
            //Design
            Point locationRelativeToScreen = textBoxStartTime.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-2, -2);
            displaystarttime.Location = locationRelativeToScreen;
            displaystarttime.Show();
            displaystarttime.Size = new Size(118, 162);
            label1.Select();
        }
        private void textBoxEndTime_Click(object sender, EventArgs e)
        {
            isstarttime = false;

            //Constructor
            DisableClosingOnDisactivating = true;
            CBdisplayTime displayendtime = new CBdisplayTime(isstarttime, this);//MEN SE3A 12:00 AM (00:00:00) lal 11:30 PM
            displayendtime.Deactivate += Displaytime_Deactivate;
            //Design
            Point locationRelativeToScreen = textBoxEndTime.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-2, -2);
            displayendtime.Location = locationRelativeToScreen;
            displayendtime.Show();
            displayendtime.Width = 118;
            label1.Select();
        }
        private void Displaytime_Deactivate(object sender, EventArgs e)
        {
            DisableClosingOnDisactivating = false;
            this.Focus();
        }
        public void textBoxStartTime_TextChanged(object sender, EventArgs e)
        {
            DifferenceTime = DesiredAppointmentAppForm.EndTime.TimeOfDay - DesiredAppointmentAppForm.StartTime.TimeOfDay;
            LabelDuration.Text = $"{(int)DifferenceTime.TotalMinutes} min";
            LabelDuration.Select();
        }
        public void textBoxEndTime_TextChanged(object sender, EventArgs e)
        {
            DifferenceTime = DesiredAppointmentAppForm.EndTime.TimeOfDay - DesiredAppointmentAppForm.StartTime.TimeOfDay;
            LabelDuration.Text = $"{(int)DifferenceTime.TotalMinutes} min";
            LabelDuration.Select();
        }





        //used present-future
        void FillDesiredClientObject()//only used eza aam naamil changes aal appointment w aam nsayevun: Complete/Cancel/Update Or kell shi Undo NoSense, lieanno ha ykuno read only
        {


            if (!IsReadOrEdit && !UndoFromNotficationBannerModeOn)// lieanno  mamnuu nkun aam nghayyr  shi eza ken not read only w asln el design tghayar so ha taamil mashekil/or men el banner ma ha tkun aam ngahyyir wala info
            {
                //usually kell el valye elumn aalea bel chosen client aw balance, ha ykun aam yetaabo bel ucclient app
                if (ucClientApp.IsServiceOrOthersMode)//service
                {
                    DesiredAppointmentAppForm.Title = null;


                    if (DesiredAppointmentAppForm.DesiredClientBalance != null)
                    {
                        if (DesiredAppointmentAppForm.StartTime.Date == DateTime.Now.Date)//Present
                        {
                            DesiredAppointmentAppForm.HistoryClientBalance = DesiredAppointmentAppForm.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                        }
                        else if (DesiredAppointmentAppForm.StartTime.Date > DateTime.Now.Date)//future
                        {

                            DesiredAppointmentAppForm.HistoryClientBalance = DesiredAppointmentAppForm.DesiredClientBalance.BundleName + " Package";

                        }
                    }
                    else
                    {
                        DesiredAppointmentAppForm.HistoryClientBalance = null;
                    }

                }
                else//Custom
                {
                    ucClientApp.FillObjectIfTitle(ucClientApp.textBoxTitle.Text);
                    DesiredAppointmentAppForm.ChosenBundlesList = null;
                    DesiredAppointmentAppForm.DesiredClientBalance = null;
                    DesiredAppointmentAppForm.IsPackageMode = false;
                }

                //Time
                string starttimestring = (string)textBoxStartTime.Text;//7:00 PM
                DateTime HourStartTime;
                DateTime.TryParseExact(starttimestring, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out HourStartTime);//h for hour, mm for minutes and tt for AM/PM, we are converting string to DateTime.Time1

                string endtimestring = (string)textBoxEndTime.Text;
                DateTime HourEndTime;
                DateTime.TryParseExact(endtimestring, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out HourEndTime);


                DesiredAppointmentAppForm.StartTime = DesiredAppointmentAppForm.StartTime.Date + HourStartTime.TimeOfDay;
                DesiredAppointmentAppForm.EndTime = DesiredAppointmentAppForm.EndTime.Date + HourEndTime.TimeOfDay;

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

                //Employee
                dynamic selectedItem = comboBoxEmployee.SelectedItem;
                DesiredAppointmentAppForm.DesiredEmployee = (ClassEmployee)selectedItem.Value;


            }
        }
        bool ISRequiredFieldsExists(bool IsCallingFromComplete)
        {
            //hone el object is updated to the new values, aa hal ases we re checking it

            if (!IsReadOrEdit)//Edit Mode
            {
                if (CheckIfTimeAvailable())//kermel naarif eza ghayarna waet el appointment, eza fi mahal ela, w mnaamella set also
                {
                    if (ucClientApp.IsServiceOrOthersMode)
                    {

                        if (DesiredAppointmentAppForm.DesiredClient == null)
                        {
                            ucClientApp.textBoxSearch.IsRequiredModeOn = true;
                            return true;
                        }
                    }
                }
                else
                {
                    DisableClosingOnDisactivating = true;
                    CustomMessageBox.Show("This Time is not available,Choose another one ", CustomMessageBox.Type.OkWarning);
                    DisableClosingOnDisactivating = false;
                    return true;
                }

                return false;
            }
            else
            {
                return false;
            }

        }
        void ChangeAppointmentLocation()
        {
            //Design
            //hone UCappointment.DesiredAppointmentUCApp baeed ma sarit hiyye zeita DesiredAppointmentAppForm tb3 li hone, lieanno eza bet ruh bet shuf wen maaytin lal ChangeAppointmentLocation, abel el event 
            if (UCappointment.DesiredAppointmentUCApp.DesiredEmployee.EmployeeId != DesiredAppointmentAppForm.DesiredEmployee.EmployeeId || UCappointment.DesiredAppointmentUCApp.StartTime != DesiredAppointmentAppForm.StartTime || UCappointment.DesiredAppointmentUCApp.EndTime != DesiredAppointmentAppForm.EndTime)//checking eza tghayrarit its position or no
            {
                UcScheduleParentForm.ChangePositionUCappointments(UCappointment, UCappointment.DesiredAppointmentUCApp, DesiredAppointmentAppForm);
            }
        }

        bool CheckIfTimeAvailable()//it will work for both day an week, since bel week we can t shift days, but we can only shift hours
        {//you need to set the limit condition also

            int EmployeeIndex = UcScheduleParentForm.SelectedRowsAvailabilityForEachEmployeWorkingOn.FindIndex(item => item.Item1.EmployeeId == DesiredAppointmentAppForm.DesiredEmployee.EmployeeId);


            TimeSpan EndTime = DesiredAppointmentAppForm.EndTime.TimeOfDay;//let s say end time was 9:00, bel availabilty ha tkun 8:45, so that s why eemelna thismethd tahet
            int desiredRow = ClassEmployeeFront.GetRowFromTime(EndTime, true, UcScheduleParentForm.TLPSchedule);
            EndTime = ClassEmployeeFront.GetTimeFromRow(desiredRow, false, UcScheduleParentForm.TLPSchedule);


            if (UcScheduleParentForm.SelectedDateTimeAvailabilityForEachEmployeWorkingOn[EmployeeIndex].Item2.Contains(DesiredAppointmentAppForm.StartTime.TimeOfDay)
                && UcScheduleParentForm.SelectedDateTimeAvailabilityForEachEmployeWorkingOn[EmployeeIndex].Item2.Contains(EndTime))
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        //these 3 event change the desin of the UCappointment, eloun aalea eza baamil complete aw cancel a undo bel appointment form
        public event EventHandler OnAppointmentUpdate;
        public event EventHandler OnAppointmentUndoCompletion;
        public event EventHandler OnAppointmentUndoCancelation;


        void AddOrUpdateSQL()
        {

            if (IsAddOrUpdateMode)
            {
                //SQL:
                DesiredAppointmentAppForm.InsertOrUpdateAppointment(true);
                DesiredAppointmentAppForm.AppointmentID = ClassAppointment.GetLastAppointmentId();
                //Design
                UCappointment = UcScheduleParentForm.AddUCappointmentsInTLP(DesiredAppointmentAppForm);
                UcScheduleParentForm.AppointmentsListWorkingOn.Add(DesiredAppointmentAppForm);

                //OnAppointmentUpdate?.Invoke(this, EventArgs.Empty); // mahhal meshlogic hone, anw za toloolak mashekil bi kun ela reason, bas now keep it like this, cz aal undo men el notif aam taamil mashekil

                NotfBanner = NotificationBanner.Show("New Appointment Added", NotificationBanner.EnumType.ConfirmationMode, true, Program.HomeForm, UndoFromNotficationBannerModeOn);
                NotfBanner.UndoNotficationBanner += NotfBanner_UndoAddNotficationBanner;
            }
            else
            {
                //SQL:
                DesiredAppointmentAppForm.InsertOrUpdateAppointment(false);
                //Design
                OldDesiredAppointmentAppForm = UCappointment.DesiredAppointmentUCApp.Copy();//ejabre foe el event   OnAppointmentUpdate?.Invoke(this, EventArgs.Empty);, cz inside it amm tetghayar Cappointment.DesiredAppointmentUCApp
                ChangeAppointmentLocation();
                OnAppointmentUpdate?.Invoke(this, EventArgs.Empty);
            }

            this.Close();
        }
        void DeleteAppointment()
        {

        }
        void CompletingOrUndoingCompletionAppointment(bool IsCompleting)
        {
            if (IsCompleting)
            {
                DesiredAppointmentAppForm.IsCompleted = true;
                AddOrUpdateSQL();//ejbare tahet el completed, w hone mafi ISRequiredFieldsExists, since we used it abel ma naayit CompletingOrUndoingCompletionAppointment         
            }
            else
            {
                DesiredAppointmentAppForm.IsCompleted = false;
                DesiredAppointmentAppForm.UndoCompletionAppointmentSQL();
            }
            //Design of the ucappointment
            if (UCappointment != null)
            {
                if (DesiredAppointmentAppForm.DesiredClient != null && (DesiredAppointmentAppForm.IsPackageMode || DesiredAppointmentAppForm.ChosenBundlesList != null))
                {
                    UcScheduleParentForm.RefreshAllRelatedAppointments(this.DesiredAppointmentAppForm.DesiredClient.ClientId);
                }
                else
                {

                    UcScheduleParentForm.RefreshDesiredAppointment(UCappointment);
                }

            }

            this.Close();
        }
        (double, DataTable) PurchaseNewSoloServices()
        {
            DateTime BackOfficeDate = DateTime.Now;
            DateTime AttendanceDate = DesiredAppointmentAppForm.StartTime;
            DataTable PurchasedBundles = null;

            foreach (ClassBundles Bundle in DesiredAppointmentAppForm.ChosenBundlesList)
            {
                if (PurchasedBundles == null)//kermel yaamil clone w yekhud el shakel
                {
                    PurchasedBundles = ClassClient.PurchaseAService(Bundle, BackOfficeDate, AttendanceDate, DesiredAppointmentAppForm.DesiredClient, DesiredAppointmentAppForm.AppointmentID);
                }
                else
                {
                    DataTable dtinserteditem = ClassClient.PurchaseAService(Bundle, BackOfficeDate, AttendanceDate, DesiredAppointmentAppForm.DesiredClient, DesiredAppointmentAppForm.AppointmentID);

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
            FillDesiredClientObject();//ejabre foe ISRequiredFieldsExists

            if (!ISRequiredFieldsExists(false))
            {
                AddOrUpdateSQL();//Notf banner inside

                if (!IsAddOrUpdateMode)//NotificationBanner tb3 el add, inside of  AddOrUpdateSQL(); ased 
                {
                    NotfBanner = NotificationBanner.Show("Appointment Updated", NotificationBanner.EnumType.ConfirmationMode, true, Program.HomeForm, UndoFromNotficationBannerModeOn);
                    NotfBanner.UndoNotficationBanner += NotfBanner_UndoUpdateNotficationBanner;
                }
            }
        }
        private void buttonCompleted_Click(object sender, EventArgs e)
        {
            if (!LOGIN.Employee.CanEditPastAppSchedule && DesiredAppointmentAppForm.StartTime.Date < DateTime.Now.Date)
            {
                DisableClosingOnDisactivating = true;
                CustomMessageBox.Show("You don't have access", CustomMessageBox.Type.Error);
                DisableClosingOnDisactivating = false;

            }
            else
            {


                Cursor.Current = Cursors.WaitCursor;
                if (!DesiredAppointmentAppForm.IsCompleted)
                {
                    FillDesiredClientObject();//ejabre foe ISRequiredFieldsExists
                }
                if (!ISRequiredFieldsExists(true))
                {

                    //Package of sessions
                    if (DesiredAppointmentAppForm.DesiredClient != null && DesiredAppointmentAppForm.DesiredClientBalance != null)//Package Of Sessions
                    {
                        if (DesiredAppointmentAppForm.DesiredClientBalance.DueDate == null && DesiredAppointmentAppForm.DesiredClientBalance.SessionLeftDays != null)
                        {
                            if (!DesiredAppointmentAppForm.IsCompleted)
                            {
                                //  FillDesiredClientObject(); specially  lezim ykun  foe  CompletingOrUndoingAppointment(true); kermel el history yekheda mazbuta abel ma tetghayar tahet

                                if (!(bool)DesiredAppointmentAppForm.DesiredClientBalance.IsExpired)
                                {
                                    if (DesiredAppointmentAppForm.DesiredClientBalance.SessionLeftDays > 0)
                                    {
                                        DesiredAppointmentAppForm.DesiredClientBalance.SessionLeftDays--;
                                        DesiredAppointmentAppForm.DesiredClientBalance.SetStringDetailsIfBundle();//krmel el design
                                        ClassClientBalance.ReduceSessionFromPackageOfSessions(DesiredAppointmentAppForm.DesiredClient.ClientId, DesiredAppointmentAppForm.DesiredClientBalance.ClientBalanceID, Convert.ToInt32(DesiredAppointmentAppForm.DesiredClientBalance.SessionLeftDays), DesiredAppointmentAppForm.AppointmentID, DateTime.Now, DesiredAppointmentAppForm.StartTime);

                                        //
                                        CompletingOrUndoingCompletionAppointment(true);
                                        NotfBanner = NotificationBanner.Show("Appointment Completed, Session Reduced", NotificationBanner.EnumType.ConfirmationMode, true, Program.HomeForm, UndoFromNotficationBannerModeOn);
                                    }
                                    else
                                    {
                                        DisableClosingOnDisactivating = true;
                                        CustomMessageBox.Show("Can't complete this appointment because there are no sessions left.\nPlease renew the package or choose another service.", CustomMessageBox.Type.OkWarning);
                                        DisableClosingOnDisactivating = false;
                                    }
                                }
                                else
                                {
                                    DisableClosingOnDisactivating = true;
                                    CustomMessageBox.Show("Can't complete this appointment because the chosen package is expired", CustomMessageBox.Type.OkWarning);
                                    DisableClosingOnDisactivating = false;
                                }


                            }
                            else//mafrud kell shi ykun read only
                            {
                                //Design
                                DesiredAppointmentAppForm.DesiredClientBalance.SessionLeftDays++;
                                DesiredAppointmentAppForm.DesiredClientBalance.SetStringDetailsIfBundle();
                                //SQl
                                CompletingOrUndoingCompletionAppointment(false);
                                NotfBanner = NotificationBanner.Show("Appointment completion undo succeeded", NotificationBanner.EnumType.UndoMode, true, Program.HomeForm, UndoFromNotficationBannerModeOn);
                                if (DesiredAppointmentAppForm.StartTime.Date == DateTime.Now.Date)
                                {
                                    DesiredAppointmentAppForm.HistoryClientBalance = DesiredAppointmentAppForm.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                                    DesiredAppointmentAppForm.UpdateHistoryClientBalance();//just hone staamalneha since, bel undo ma mnaamil update la kell apointment bi sql,only men ghayyir is_completed state,So tdara naamil udate lal history hone manually

                                }
                            }
                        }
                        else if (DesiredAppointmentAppForm.DesiredClientBalance.DueDate != null)
                        {
                            if (!DesiredAppointmentAppForm.IsCompleted)
                            {
                                CompletingOrUndoingCompletionAppointment(true);
                                NotfBanner = NotificationBanner.Show("Appointment Completed", NotificationBanner.EnumType.ConfirmationMode, true, Program.HomeForm, UndoFromNotficationBannerModeOn);
                            }
                            else
                            {
                                CompletingOrUndoingCompletionAppointment(false);
                                NotfBanner = NotificationBanner.Show("Appointment Completion Undo Succeeded", NotificationBanner.EnumType.UndoMode, true, Program.HomeForm, UndoFromNotficationBannerModeOn);
                            }
                        }
                    }

                    else if (DesiredAppointmentAppForm.ChosenBundlesList != null && DesiredAppointmentAppForm.DesiredClient != null)
                    {

                        if (!DesiredAppointmentAppForm.IsCompleted)
                        {

                            (double initialbalance, DataTable PurchasedBundles) = PurchaseNewSoloServices();

                            DisableClosingOnDisactivating = true;
                            if (this.IsDisposed)//bet sir lamma naamil undo men el Notification Banner
                            {
                                Program.GreyFormJunior = new GreyColor(Program.HomeForm, true, false, null);
                            }
                            else
                            {
                                Program.GreyFormJunior = new GreyColor(this, false, true, null);
                            }
                            Program.GreyFormJunior.Show();
                            Payment paymentform = new Payment(DesiredAppointmentAppForm.DesiredClient, PurchasedBundles, null, true);
                            paymentform.ShowDialog();
                            DisableClosingOnDisactivating = false;
                            //
                            CompletingOrUndoingCompletionAppointment(true);
                            NotfBanner = NotificationBanner.Show("Appointment Completed, Services Purchased", NotificationBanner.EnumType.ConfirmationMode, true, Program.HomeForm, UndoFromNotficationBannerModeOn);
                        }
                        else
                        {
                            CompletingOrUndoingCompletionAppointment(false);
                            NotfBanner = NotificationBanner.Show("Appointment Completion Undo Succeeded", NotificationBanner.EnumType.UndoMode, true, Program.HomeForm, UndoFromNotficationBannerModeOn);
                        }
                    }
                    else //Tile Or Nothing
                    {

                        if (!DesiredAppointmentAppForm.IsCompleted)
                        {
                            CompletingOrUndoingCompletionAppointment(true);
                            NotfBanner = NotificationBanner.Show("Appointment Completed", NotificationBanner.EnumType.ConfirmationMode, true, Program.HomeForm, UndoFromNotficationBannerModeOn);
                        }
                        else
                        {
                            CompletingOrUndoingCompletionAppointment(false);
                            NotfBanner = NotificationBanner.Show("Appointment Completion Undo Succeeded", NotificationBanner.EnumType.UndoMode, true, Program.HomeForm, UndoFromNotficationBannerModeOn);
                        }
                    }

                    if (NotfBanner != null)
                    {
                        NotfBanner.UndoNotficationBanner += Notf_UndoComplitionNotficationBanner;
                    }
                }
                Cursor.Current = Cursors.Default;
            }
        }
        private void buttonCanceled_Click(object sender, EventArgs e)
        {
            if (!LOGIN.Employee.CanEditPastAppSchedule && DesiredAppointmentAppForm.StartTime.Date < DateTime.Now.Date)
            {
                DisableClosingOnDisactivating = true;
                CustomMessageBox.Show("You don't have access", CustomMessageBox.Type.Error);
                DisableClosingOnDisactivating = false;
            }
            else
            {

                if (!DesiredAppointmentAppForm.IsCanceled)
                {
                    FillDesiredClientObject();//ejabre foe ISRequiredFieldsExists
                }

                if (!ISRequiredFieldsExists(false))
                {

                    if (!DesiredAppointmentAppForm.IsCanceled)
                    {

                        DesiredAppointmentAppForm.IsCanceled = true;
                        AddOrUpdateSQL(); //ejabre tahtha
                        NotfBanner = NotificationBanner.Show("Appointment Canceled", NotificationBanner.EnumType.CanceledMode, true, Program.HomeForm, UndoFromNotficationBannerModeOn);
                        OnAppointmentUpdate?.Invoke(this, EventArgs.Empty);
                    }
                    else//in this case bi kun kell shi read only, that why ma mnaamil update la kell el info
                    {
                        DesiredAppointmentAppForm.IsCanceled = false;//lezim nemnaa yghayir hayalla shi foe, read only kello
                        DesiredAppointmentAppForm.SetOrResetIsCanceled();
                        NotfBanner = NotificationBanner.Show("Appointment Cancelation Undo Succeeded", NotificationBanner.EnumType.UndoMode, true, Program.HomeForm, UndoFromNotficationBannerModeOn);
                        OnAppointmentUndoCancelation?.Invoke(this, EventArgs.Empty);
                    }
                    if (NotfBanner != null)
                    {
                        NotfBanner.UndoNotficationBanner += NotfBanner_UndoCancelationNotficationBanner; ;
                    }
                    this.Close();
                }
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //SQL
            UCappointment.DesiredAppointmentUCApp.DeleteAppointment();//ejbare hone mahalla mesh bel appointment form

            UCappointment.RemoveAppointmentFromTLP();
            UcScheduleParentForm.AppointmentsListWorkingOn.Remove(DesiredAppointmentAppForm);

            NotfBanner = NotificationBanner.Show("Appointment Deleted", NotificationBanner.EnumType.DeletedMode, true, Program.HomeForm, UndoFromNotficationBannerModeOn);
            if (NotfBanner != null)
            {
                NotfBanner.UndoNotficationBanner += NotfBanner_UndoDeleteNotficationBanner; ;
            }
            this.Close();
        }




        private void NotfBanner_UndoAddNotficationBanner(object sender, EventArgs e)
        {
            UndoFromNotficationBannerModeOn = true;
            buttonDelete_Click(null, EventArgs.Empty);
        }
        private void NotfBanner_UndoUpdateNotficationBanner(object sender, EventArgs e)
        {
            UndoFromNotficationBannerModeOn = true;

            DesiredAppointmentAppForm = OldDesiredAppointmentAppForm.Copy();

            IsAddOrUpdateMode = false;
            AddOrUpdateSQL();
        }
        private void Notf_UndoComplitionNotficationBanner(object sender, EventArgs e)
        {
            UndoFromNotficationBannerModeOn = true;
            buttonCompleted_Click(null, EventArgs.Empty);
        }
        private void NotfBanner_UndoCancelationNotficationBanner(object sender, EventArgs e)
        {
            UndoFromNotficationBannerModeOn = true;
            buttonCanceled_Click(null, EventArgs.Empty);
        }
        private void NotfBanner_UndoDeleteNotficationBanner(object sender, EventArgs e)
        {
            UndoFromNotficationBannerModeOn = true;
            IsAddOrUpdateMode = true;
            AddOrUpdateSQL();
        }





        //hole el 3 event bi asro bel state tb3 el UCAppointment w tb3 Appointment Form
        //And they appear lamma eftah el profile tb3 el customer and modify the information(PErsonal/Clientbalance)

        private void BackOffice_UndoHappened(object sender, EventArgs e)//this is only design wise cz kell shi backend happened aal undo action
        {

            //this form desuign
            if (DesiredAppointmentAppForm.IsCompleted)
            {

                if (DesiredAppointmentAppForm.DesiredClientBalance != null || DesiredAppointmentAppForm.ChosenBundlesList != null)
                {
                    DataTable dt = DesiredAppointmentAppForm.AllRelatedRowsInArchiveTable();
                    if (dt.Rows.Count == 0)
                    {
                        //appointment form design
                        DesiredAppointmentAppForm.IsCompleted = false;
                        SetCompletionModeDesign();


                    }
                }


                if (DesiredAppointmentAppForm.ChosenBundlesList != null)
                {
                    DataTable dt = DesiredAppointmentAppForm.AllRelatedRowsInArchiveTable();
                    if (dt.Rows.Count != DesiredAppointmentAppForm.ChosenBundlesList.Count())
                    {
                        DesiredAppointmentAppForm.ChosenBundlesList.Clear();

                        DataTable ChosenBundles = ClassAppointment.GetAllChosenSoloBundles(DesiredAppointmentAppForm.AppointmentID);
                        if (ChosenBundles.Rows.Count > 0)
                        {
                            List<ClassBundles> bundles = new List<ClassBundles>();
                            foreach (DataRow dr in ChosenBundles.Rows)
                            {
                                bundles.Add(ClassBundles.CreateBundleObject(Convert.ToInt32(dr["bundle_id"])));
                            }
                            DesiredAppointmentAppForm.ChosenBundlesList = bundles;//ased eemelneha kermel yenkhalae el string ma3a



                        }
                    }

                }

                ////uc app design
                if (UCappointment != null)
                {
                    if (DesiredAppointmentAppForm.DesiredClient != null && (DesiredAppointmentAppForm.IsPackageMode || DesiredAppointmentAppForm.ChosenBundlesList != null))
                    {
                        UcScheduleParentForm.RefreshAllRelatedAppointments(this.DesiredAppointmentAppForm.DesiredClient.ClientId);
                    }
                    else
                    {
                        UcScheduleParentForm.RefreshDesiredAppointment(UCappointment);
                    }
                }
            }
        }
        private void Appointment_FormClosed(object sender, FormClosedEventArgs e)
        {
            BackOffice.UndoHappened -= BackOffice_UndoHappened;//since it s static!, not recomended
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2;
        }
        private void Appointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }
        private void Appointment_Deactivate(object sender, EventArgs e)
        {
            if (!DisableClosingOnDisactivating)
            {
                this.Close();
            }
        }
        private void Appointment_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible == false)
            {
                if (Program.GreyForm != null)
                {
                    Program.GreyForm.Close();
                    Program.GreyForm = null;
                }

            }

        }
        private void comboBoxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelEmployeeOutput.Select();
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
