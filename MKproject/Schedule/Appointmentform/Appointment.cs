using CustomizedTools;
using GlobalFunctions;
using MKproject.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        //VARIABLES
        public UCDay UcDayParentForm;
        UCTime ucTime;

        bool isstarttime;
        bool IsAddOrUpdate;

        int PositionCol;
        int PositionRow;


        public ClassAppointment DesiredAppointmentAppForm;

        public UCClientApp ucClientApp;
        public UCappointment ucappointment;


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



        //ADD
        public Appointment(UCDay UCday, UCTime UCtime, int employeeid)
        {
            InitializeComponent();
            Opacity = 0;

            IsReadOrEdit = false;//adding Mode
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

            ucClientApp = new UCClientApp(this);

            SetDesign();

        }

        //UPDATE
        public Appointment(UCappointment UCappointment, UCDay UCday)
        {
            InitializeComponent();
            Opacity = 0;

            DesiredAppointmentAppForm = UCappointment.DesiredAppointmentUCApp.Copy();//as we see hone eena copy aan el ucappointmnet, bas ucClientApp refers to the same DesiredAppointmentAppForm metel el appointment form


            if (DesiredAppointmentAppForm.StartTime.Date < DateTime.Now.Date || DesiredAppointmentAppForm.IsCompleted || DesiredAppointmentAppForm.IsCanceled)
            {
                IsReadOrEdit = true;
            }
            IsAddOrUpdate = false;
            UcDayParentForm = UCday;

            ucappointment = UCappointment;


            //Aam nekhoud Col and Row pos taba3 lucappointment
            TimeSpan starttimeTimeSpan = DesiredAppointmentAppForm.StartTime.TimeOfDay;//bas kermel le2e uctime
            int HourOfTheAppointment = starttimeTimeSpan.Hours;//row and hours same position
            int employeePosition = UcDayParentForm.ListEmployee_idAllTime.IndexOf((int)DesiredAppointmentAppForm.EmployeeId);

            ucappointment.ColumnPosition = employeePosition + 1;//position flowlayoutpanel hiye position employee bel list-1 
            ucappointment.RowPosition = HourOfTheAppointment;



            ucClientApp = new UCClientApp(this);

            ucClientApp.OnClientProfileInfoChanging += UcClientApp_OnClientProfileInfoChanging;
            ucClientApp.OnUpdatingTheChosenClientBalance += UcClientApp_OnUpdatingTheChosenClientBalance;
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
            LabelDuration.Text = DifferenceTime.ToString(@"hh\:mm\:ss");

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
                foreach (ClassEmployee emp in UcDayParentForm.ListEmployeeSchedule)
                {
                    if ((bool)emp.IsChecked)
                    {
                        var item = new
                        {
                            Text = $"{emp.Fname} {emp.Lname}",
                            Value = emp.EmployeeId
                        };

                        comboBoxEmployee.Items.Add(item);
                        comboBoxEmployee.DisplayMember = "Text";
                        comboBoxEmployee.ValueMember = "Value";
                    }
                    comboBoxEmployee.Width = FunctionsForWinformsTool.ReturnComboBoxWidth(comboBoxEmployee) + 17;
                }
                comboBoxEmployee.SelectedIndex = comboBoxEmployee.FindString(DesiredAppointmentAppForm.EmployeeFullName);

                //

                TLPGlobal.Controls.Add(textBoxNotes, 0, 5);
                TLPGlobal.SetColumnSpan(textBoxNotes, 2);
                if (!string.IsNullOrEmpty(DesiredAppointmentAppForm.Notes))
                {
                    textBoxNotes.Text = DesiredAppointmentAppForm.Notes;
                }

                //
                if (IsAddOrUpdate)//ma mneedar nfout aalaya since bel past mamnuu to add an apointment
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

                labelEmployee.Text = DesiredAppointmentAppForm.EmployeeFullName;
                TLPGlobal.Controls.Add(labelEmployee, 1, 4);

            }


            if (DesiredAppointmentAppForm.StartTime.Date <= DateTime.Now.Date)//present-past
            {
                //Always
                if (!IsAddOrUpdate)
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
        ///StartTime & EndTime
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
            LabelDuration.Text = DifferenceTime.ToString(@"hh\:mm\:ss");
            LabelDuration.Select();
        }
        public void textBoxEndTime_TextChanged(object sender, EventArgs e)
        {
            DifferenceTime = DesiredAppointmentAppForm.EndTime.TimeOfDay - DesiredAppointmentAppForm.StartTime.TimeOfDay;
            LabelDuration.Text = DifferenceTime.ToString(@"hh\:mm\:ss");
            LabelDuration.Select();
        }





        //these 3 event change the desin of the UCappointment, eloun aalea eza baamil complete aw cancel a undo bel appointment form
        public event EventHandler OnAppointmentUpdate;
        public event EventHandler OnAppointmentUndoCompletion;
        public event EventHandler OnAppointmentUndoCancelation;
        //used present-future
        bool ISRequiredFieldsExists(bool IsCallingFromComplete)
        {

            bool IsPanelAvailable = CheckIfTimeAvailableAndSetAppointmentPosition();//kermel naarif eza ghayarna waet el appointment, eza fi mahal ela, w mnaamella set also

            if (!IsReadOrEdit)//Edit Mode
            {
                if (IsPanelAvailable)
                {
                    if (ucClientApp.IsServiceOrOthersMode)
                    {

                        if (DesiredAppointmentAppForm.DesiredClient == null)
                        {
                            ucClientApp.textBoxSearch.IsRequiredModeOn = true;
                            return true;
                        }
                        else if (IsCallingFromComplete && DesiredAppointmentAppForm.DesiredClientBalance == null && (DesiredAppointmentAppForm.ChoseBundlesString == null && DesiredAppointmentAppForm.ChosenBundlesList == null))
                        {
                            DisableClosingOnDisactivating = true;
                            CustomMessageBox.Show("Select a package or a service", CustomMessageBox.Type.Ok);
                            DisableClosingOnDisactivating = false;
                            return true;
                        }
                    }
                    else if (DesiredAppointmentAppForm.Title == null)
                    {
                        ucClientApp.textBoxTitle.IsRequiredModeOn = true;
                        return true;
                    }
                }
                else
                {
                    DisableClosingOnDisactivating = true;
                    CustomMessageBox.Show("This Time is not available,Choose another one ", CustomMessageBox.Type.Ok);
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
        void FillDesiredClientObject()//only used eza aam naamil changes aal appointment w aam nsayevun: Complete/Cancel/Update Or kell shi Undo NoSense, lieanno ha ykuno read only
        {

            if (!IsReadOrEdit)// lieanno  mamnuu nkun aam nghayyr  shi eza ken not read only w asln el design tghayar so ha taamil mashekil
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
                else//others
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

                //Employee
                dynamic selectedItem = comboBoxEmployee.SelectedItem;
                DesiredAppointmentAppForm.EmployeeId = Convert.ToInt16(selectedItem.Value);
            }
        }
        bool AddOrUpdateSQL()
        {
            if (!ISRequiredFieldsExists(false))
            {
                if (IsAddOrUpdate)
                {
                    //SQL:
                    DesiredAppointmentAppForm.InsertOrUpdateAppointment(true);
                    DesiredAppointmentAppForm.AppointmentID = ClassAppointment.GetLastAppointmentId();
                    //Design
                    UcDayParentForm.AddUCappointments(DesiredAppointmentAppForm, PositionCol, PositionRow);
                    OnAppointmentUpdate?.Invoke(this, EventArgs.Empty);

                }
                else
                {
                    //SQL:
                    DesiredAppointmentAppForm.InsertOrUpdateAppointment(false);
                    //Design
                    ChangeAppointmentLocation();//Aam taamil error lamma aamil undocompletion
                    OnAppointmentUpdate?.Invoke(this, EventArgs.Empty);
                }
                this.Close();
                return true;//which means naamalit , meshe el hal
            }
            else
            {
                return false;
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
        void CompletingOrUndoingCompletionAppointment(bool IsCompleting)
        {
            if (IsCompleting)
            {
                DesiredAppointmentAppForm.IsCompleted = true;
                AddOrUpdateSQL();//ejbare tahet el completed
                OnAppointmentUpdate?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                DesiredAppointmentAppForm.IsCompleted = false;
                DesiredAppointmentAppForm.UndoCompletionAppointmentSQL();

                DesiredAppointmentAppForm.DesiredClient.TotalBalance = ClassClient.GetClientTotalBalance(DesiredAppointmentAppForm.DesiredClient.ClientId);//ejbare tahet UndoCompletionAppointment();
                                                                                                                                                           //used not always, only in case ken undoing a new solo service cz ma32oul tetghayar el balance

                OnAppointmentUndoCompletion?.Invoke(this, EventArgs.Empty);//!!! Bas ejbare bel Undo nkun aam nemna3o yaamil update aa hayyala field(ReadOnly) aa hayalla field w ela ha yenzalo bel uCAppointment
            }
            this.Close();
        }






        private void ButtonAddOrUpdate_Click(object sender, EventArgs e)
        {
            FillDesiredClientObject();
            bool IsActionDone = AddOrUpdateSQL();
            if (IsActionDone)
            {
                if (IsAddOrUpdate)
                {
                    NotificationBanner.Show("New Appointment Added", NotificationBanner.Type.ConfirmationMode, Program.HomeForm);
                }
                else
                {
                    NotificationBanner.Show("Appointment Updated", NotificationBanner.Type.ConfirmationMode, Program.HomeForm);
                }
            }

        }
        private void buttonCompleted_Click(object sender, EventArgs e)
        {
            if (!DesiredAppointmentAppForm.IsCompleted)
            {
                FillDesiredClientObject();

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
                                    ClassClientBalance.ReduceSessionFromPackageOfSessions(DesiredAppointmentAppForm.DesiredClient.ClientId, DesiredAppointmentAppForm.DesiredClientBalance.ClientBalanceID, (int)DesiredAppointmentAppForm.DesiredClientBalance.SessionLeftDays, DesiredAppointmentAppForm.AppointmentID, DateTime.Now, DesiredAppointmentAppForm.StartTime);

                                    //
                                    CompletingOrUndoingCompletionAppointment(true);
                                    NotificationBanner.Show("Appointment Completed, Session Reduced", NotificationBanner.Type.ConfirmationMode, Program.HomeForm);
                                }
                                else
                                {
                                    DisableClosingOnDisactivating = true;
                                    CustomMessageBox.Show("Can't complete this appointment because there are no sessions left.\nPlease renew the package or choose another service.", CustomMessageBox.Type.Ok);
                                    DisableClosingOnDisactivating = false;
                                }
                            }
                            else
                            {
                                DisableClosingOnDisactivating = true;
                                CustomMessageBox.Show("Can't complete this appointment because the chosen package is expired", CustomMessageBox.Type.Ok);
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
                            NotificationBanner.Show("Appointment completion undo succeeded", NotificationBanner.Type.UndoMode, Program.HomeForm);
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
                            NotificationBanner.Show("Appointment Completed", NotificationBanner.Type.ConfirmationMode, Program.HomeForm);
                        }
                        else
                        {
                            CompletingOrUndoingCompletionAppointment(false);
                            NotificationBanner.Show("Appointment Completion Undo Succeeded", NotificationBanner.Type.UndoMode, Program.HomeForm);
                        }
                    }
                }

                else if (DesiredAppointmentAppForm.ChosenBundlesList != null && DesiredAppointmentAppForm.DesiredClient != null)
                {

                    if (!DesiredAppointmentAppForm.IsCompleted)
                    {

                        (double initialbalance, DataTable PurchasedBundles) = PurchaseNewSoloServices();

                        DisableClosingOnDisactivating = true;
                        Program.GreyFormJunior = new GreyColor(this, false, true);
                        Program.GreyFormJunior.Show();
                        Payment paymentform = new Payment(DesiredAppointmentAppForm.DesiredClient, PurchasedBundles, null, true);
                        paymentform.ShowDialog();
                        DisableClosingOnDisactivating = false;
                        //
                        CompletingOrUndoingCompletionAppointment(true);
                        NotificationBanner.Show("Appointment Completed, Services Purchased", NotificationBanner.Type.ConfirmationMode, Program.HomeForm);
                    }
                    else
                    {
                        CompletingOrUndoingCompletionAppointment(false);
                        NotificationBanner.Show("Appointment Completion Undo Succeeded", NotificationBanner.Type.UndoMode, Program.HomeForm);
                    }
                }
                else if (DesiredAppointmentAppForm.Title != null)
                {

                    if (!DesiredAppointmentAppForm.IsCompleted)
                    {
                        CompletingOrUndoingCompletionAppointment(true);
                        NotificationBanner.Show("Appointment Completed", NotificationBanner.Type.ConfirmationMode, Program.HomeForm);
                    }
                    else
                    {
                        CompletingOrUndoingCompletionAppointment(false);
                        NotificationBanner.Show("Appointment Completion Undo Succeeded", NotificationBanner.Type.UndoMode, Program.HomeForm);
                    }
                }


            }

        }
        private void buttonCanceled_Click(object sender, EventArgs e)
        {

            if (!DesiredAppointmentAppForm.IsCanceled)
            {
                FillDesiredClientObject();
            }

            if (!ISRequiredFieldsExists(false))
            {

                if (!DesiredAppointmentAppForm.IsCanceled)
                {

                    DesiredAppointmentAppForm.IsCanceled = true;
                    AddOrUpdateSQL(); //ejabre tahtha
                    NotificationBanner.Show("Appointment Canceled", NotificationBanner.Type.CanceledMode, Program.HomeForm);
                    OnAppointmentUpdate?.Invoke(this, EventArgs.Empty);
                }
                else//in this case bi kun kell shi read only, that why ma mnaamil update la kell el info
                {
                    DesiredAppointmentAppForm.IsCanceled = false;//lezim nemnaa yghayir hayalla shi foe, read only kello
                    DesiredAppointmentAppForm.SetOrResetIsCanceled();
                    NotificationBanner.Show("Appointment Cancelation Undo Succeeded", NotificationBanner.Type.UndoMode, Program.HomeForm);
                    OnAppointmentUndoCancelation?.Invoke(this, EventArgs.Empty);
                }

                this.Close();
            }

        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //SQL
            ucappointment.DesiredAppointmentUCApp.DeleteAppointment();//ejbare hone mahalla mesh bel appointment form

            ucappointment.Dispose();
            ucappointment.RemoveAppointmentFromTLP();

            NotificationBanner.Show("Appointment Deleted", NotificationBanner.Type.DeletedMode, Program.HomeForm);
            this.Close();
        }





        //hole el 3 event bi asro bel state tb3 el UCAppointment w tb3 Appointment Form
        //And they appear lamma eftah el profile tb3 el customer and modify the information(PErsonal/Clientbalance)
        private void UcClientApp_OnClientProfileInfoChanging(object sender, EventArgs e)
        {
            ucappointment.DesiredAppointmentUCApp.DesiredClient = ucClientApp.DesiredAppointmentUCClientApp.DesiredClient;
            ucappointment.SetUCDesign();
        }
        private void UcClientApp_OnUpdatingTheChosenClientBalance(object sender, EventArgs e)
        {
            ucappointment.DesiredAppointmentUCApp = ClassAppointment.CreateObjectClassAppointment(ucappointment.DesiredAppointmentUCApp.AppointmentID);//refreshing the info
            ucappointment.SetServiceLogicAndDesign();
        }
        private void BackOffice_UndoHappened(object sender, EventArgs e)//this is only design wise cz kell shi backend happened aal undo action
        {

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

                        //ucApp design
                        OnAppointmentUndoCompletion?.Invoke(this, EventArgs.Empty);
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
                                bundles.Add(ClassBundles.CreateBundleObject((int)dr["bundle_id"]));
                            }
                            DesiredAppointmentAppForm.ChosenBundlesList = bundles;//ased eemelneha kermel yenkhalae el string ma3a
                            ucappointment.DesiredAppointmentUCApp.ChosenBundlesList = new List<ClassBundles>(DesiredAppointmentAppForm.ChosenBundlesList);
                            ucappointment.SetServiceLogicAndDesign();
                        }
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
            Opacity += .1;
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
