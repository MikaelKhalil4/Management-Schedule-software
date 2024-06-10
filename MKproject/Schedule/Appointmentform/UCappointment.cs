using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using MKproject.Management;
using GlobalFunctions;
using System.Data;
using CustomizedTools;
using System.Collections.Generic;


namespace MKproject.Schedule
{
    public partial class UCappointment : UserControl
    {

        public ClassAppointment DesiredAppointmentUCApp { get; set; }
        //kermel el drag and Drop
        public ClassAppointment OldDesiredAppointmentUCApp { get; set; }

        public int ColumnIndex { get; set; }//used for drag&drop operations
        public int RowIndexStart { get; set; }
        public int RowIndexEnd { get; set; }



        //
        public bool IsChildMode { get; set; }

        //VARIABLE
        public UCSchedule UcScheduleParentForm { get; set; }
        public static int OriginalWidth = 230;
        public static int OriginalHeiht = 75;
        private Point initialMouseDownPoint;
        public bool isDragging = false;


        //
        Label LabelBalance;
        static public Color WariningColor = Color.FromArgb(255, 234, 234);

        static public Color DefaultHoverColor= Color.WhiteSmoke;
        static public Color DefaultColor = Color.White;

        //ADD and SELECT (remember in add there's no uctime but in select there's) 
        public UCappointment(ClassAppointment desiredappointment, UCSchedule uCSchedule)
        {
            InitializeComponent();
            DesiredAppointmentUCApp = desiredappointment;
            UcScheduleParentForm = uCSchedule;



            (RowIndexStart, RowIndexEnd) = UcScheduleParentForm.GetUCAppointmentRowIndexes(DesiredAppointmentUCApp);


            SetUCDesign();
            SetServiceLogicAndDesign();

            this.MouseDown += Control_MouseDown;
            this.MouseClick += Control_MouseClick;

            TLPGlobal.MouseDown += Control_MouseDown;
            TLPGlobal.MouseClick += Control_MouseClick;
            foreach (Control control in TLPGlobal.Controls)
            {
                control.MouseDown += Control_MouseDown;
                control.MouseClick += Control_MouseClick;

            }

        }



        public void SetUCDesign()
        {

            //StartTime
            string timestring = DesiredAppointmentUCApp.StartTime.ToString("h:mm tt");
            string[] partstime = timestring.Split(' ');
            labelTime.Text = partstime[0];//eza baddak yeha 7:00 PM fik terjaee tghayera w thot timestring 

            //EndTime
            timestring = DesiredAppointmentUCApp.EndTime.ToString("h:mm tt");
            partstime = timestring.Split(' ');
            labelTime.Text += " - " + partstime[0];//eza baddak yeha 7:00 PM fik terjaee tghayera w thot timestring 


            //Client
            if (DesiredAppointmentUCApp.DesiredClient != null)
            {
                if (!TLPGlobal.Controls.Contains(labelFullName))
                {
                    TLPGlobal.Controls.Add(labelFullName, 0, 1);
                    TLPGlobal.SetRowSpan(labelService, 1);
                    TLPGlobal.SetColumnSpan(labelService, 2);

                    TLPGlobal.SetRow(labelTime, 1);
                    TLPGlobal.SetRowSpan(labelTime, 1);
                    labelTime.Margin = new Padding(0, 5, 0, 0);
                    labelTime.Dock = DockStyle.Fill;
                }

                labelFullName.Text = DesiredAppointmentUCApp.DesiredClient.Fname + " " + DesiredAppointmentUCApp.DesiredClient.Lname;

            }
            else
            {
                TLPGlobal.Controls.Remove(labelFullName);

                TLPGlobal.SetRowSpan(labelService, 2);
                TLPGlobal.SetColumnSpan(labelService, 1);

                TLPGlobal.SetRow(labelTime, 0);
                TLPGlobal.SetRowSpan(labelTime, 2);
                labelTime.Margin = new Padding(0, 0, 0, 0);
                labelTime.Dock=DockStyle.None;
                labelTime.Anchor = AnchorStyles.None;
            }




            if (DesiredAppointmentUCApp.StartTime.Date >= DateTime.Now.Date)//Present-Future
            {
                //Balance
                if (DesiredAppointmentUCApp.DesiredClient != null && DesiredAppointmentUCApp.DesiredClient.TotalBalance != 0)
                {
                    if (LabelBalance == null)
                    {
                        CreationOfLabelBalance();
                        //Eza badde bayyin el balace
                        TLPGlobal.ColumnCount += 1;
                        TLPGlobal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10));
                        TLPGlobal.Controls.Add(LabelBalance, 2, 0);

                        TLPGlobal.SetColumnSpan(labelTime, 2);

                    }
                    LabelBalance.Text = Program.SetBalanceFormat(DesiredAppointmentUCApp.DesiredClient.TotalBalance.ToString());
                }
                else
                {
                    if (LabelBalance != null)
                    {
                        LabelBalance.Dispose();
                        LabelBalance = null;
                        TLPGlobal.ColumnCount -= 1;
                        TLPGlobal.ColumnStyles.RemoveAt(TLPGlobal.ColumnCount - 1);

                        TLPGlobal.SetColumnSpan(labelTime, 1);
                    }
                }

                //FixUCDesign();

            }


            //State
            if (DesiredAppointmentUCApp.IsCompleted)
            {
                this.BackColor = this.BackColor = Color.FromArgb(124, 218, 124);//green

                if (!UcScheduleParentForm.ParentFormSchedule.checkBoxComplete.Checked)
                {
                    RemoveAppointmentFromTLP();
                }
            }
            else if (DesiredAppointmentUCApp.IsCanceled)
            {
                this.BackColor = Color.FromArgb(244, 86, 7);//orange

                if (!UcScheduleParentForm.ParentFormSchedule.checkBoxCancel.Checked)
                {
                    RemoveAppointmentFromTLP();

                }
            }
            else
            {
                this.BackColor = Program.BoldColor;

                if (!UcScheduleParentForm.ParentFormSchedule.checkBoxOnPending.Checked)
                {
                    RemoveAppointmentFromTLP();
                }

            }





        }
        public void FixUCDesign()
        {
            //initial Design, hattaynehun lieanno aam nghayerun tahet
            TLPGlobal.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 100f);
            TLPGlobal.RowStyles[0] = new RowStyle(SizeType.Percent, 40);
            labelFullName.Font = new Font(labelTime.Font.FontFamily, labelTime.Font.Size + 0.5f, labelTime.Font.Style);
            labelTime.TextAlign = ContentAlignment.TopLeft;
            labelFullName.Margin = new Padding(1, 5, 1, 0);
            labelTime.Margin = new Padding(0, 5, 0, 0);


            if (DesiredAppointmentUCApp.DesiredClient != null && DesiredAppointmentUCApp.DesiredClient.TotalBalance != 0 && DesiredAppointmentUCApp.StartTime.Date >= DateTime.Now.Date)//Present-Future           
            {
                TLPGlobal.ColumnStyles[2].Width = RandomFunctions.MeasureLabelText(LabelBalance) + 10;

                float RemaingBalance = RandomFunctions.MeasureLabelText(labelTime) - TLPGlobal.ColumnStyles[2].Width;
                if (RemaingBalance >= 0)
                {
                    TLPGlobal.ColumnStyles[1].Width = RemaingBalance + 10;
                }
                else
                {
                    TLPGlobal.ColumnStyles[1].Width = 0;
                }
            }
            else
            {
                TLPGlobal.ColumnStyles[1].Width = RandomFunctions.MeasureLabelText(labelTime) + 10;
            }


            //in the first aam nhot el full name pecentage w hawdie abs, in case el percentage ma kaffa aam nfout bel absolut thing
            //Secondary design , in case the first didn't fit properly
            int CellWidth = TLPGlobal.GetColumnWidths()[0];
            int cellHeight = TLPGlobal.GetRowHeights()[1];

            int DesiredHeightFortheLabelFullName = RandomFunctions.CalculateDesiredHeight(labelFullName, labelFullName.Width - 8);



            if (DesiredHeightFortheLabelFullName > cellHeight - 2 || CellWidth <= 0)//in case el label ma kenit sey3a
            {
                int MinimumNameWidth = RandomFunctions.CalculateDesiredWidth(labelFullName, labelFullName.Height) + 10;
                //Size MinimumNameSize = labelFullName.GetPreferredSize(new Size(0, labelFullName.Height));
                //int MinimumNameWidth = MinimumNameSize.Width;
                if (MinimumNameWidth < TLPGlobal.Width)
                {
                    TLPGlobal.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, MinimumNameWidth);


                    int x;
                    if (TLPGlobal.ColumnCount == 3)
                    {
                        x = TLPGlobal.Width - (TLPGlobal.GetColumnWidths()[0] + TLPGlobal.GetColumnWidths()[2]);
                    }
                    else
                    {
                        x = TLPGlobal.Width - TLPGlobal.GetColumnWidths()[0];
                    }


                    if (x >= 0)
                    {
                        TLPGlobal.ColumnStyles[1].Width = x;
                    }
                    else
                    {
                        TLPGlobal.ColumnStyles[1].Width = 0;

                        if (TLPGlobal.ColumnCount == 3)
                        {
                            TLPGlobal.ColumnStyles[2].Width -= x;
                        }
                    }


                }
                else
                {
                    TLPGlobal.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, TLPGlobal.Width);
                }

            }

            //this approah azbat lieanno bteetkil purely aal designn, bas be2e eendak ghalta, eza label service.text fadye w 15min duration
            //int cellHeightLabelService = TLPGlobal.GetRowHeights()[0];
            //int DesiredHeightFortheLabelService = RandomFunctions.CalculateDesiredHeight(labelService, 100000);//using raem khayele kermel odman enno one line,since i care only eza ken 15 min
            //if (DesiredHeightFortheLabelService - 5 > cellHeightLabelService)
            //{
            TimeSpan timeDifference = DesiredAppointmentUCApp.EndTime - DesiredAppointmentUCApp.StartTime;

            if (timeDifference <= TimeSpan.FromMinutes(15))
            {
                TLPGlobal.Controls.Remove(labelService);
                if (LabelBalance != null)
                {
                    TLPGlobal.Controls.Remove(LabelBalance);
                }
                TLPGlobal.RowStyles[0].Height = 0;
                labelFullName.Margin = new Padding(0);
                labelTime.Margin = new Padding(0);
                labelTime.TextAlign = ContentAlignment.TopRight;
                labelFullName.Font = new Font(labelTime.Font.FontFamily, labelTime.Font.Size, labelTime.Font.Style);
            }
            else
            {   
                TLPGlobal.Controls.Add(labelService, 0, 0);
                if (LabelBalance != null)
                {
                    TLPGlobal.Controls.Add(LabelBalance, 1, 0);

                }
            }


        }


        void CreationOfLabelBalance()
        {
            LabelBalance = new Label();
            LabelBalance.Font = new Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            LabelBalance.AutoSize = true;
            LabelBalance.Margin = new Padding(0, 0, 0, 0);
            LabelBalance.ForeColor = Color.Red;
            LabelBalance.Anchor = AnchorStyles.Left;
            LabelBalance.MouseDown += Control_MouseDown;
            LabelBalance.MouseClick += Control_MouseClick;
            LabelBalance.MouseMove += UCappointments_MouseMove;
            LabelBalance.MouseLeave += UCappointments_MouseLeave;
        }
        public void SetServiceLogicAndDesign()
        {
            //Service
            if (DesiredAppointmentUCApp.IsPackageMode)
            {
                if (DesiredAppointmentUCApp.StartTime.Date >= DateTime.Now.Date)//Present-future
                {

                    if (DesiredAppointmentUCApp.DesiredClientBalance != null)
                    {
                        if (!(bool)DesiredAppointmentUCApp.DesiredClientBalance.IsExpired)//Package exist and not expired
                        {
                            if (DesiredAppointmentUCApp.StartTime.Date >= DateTime.Now.Date)
                            {
                                if (DesiredAppointmentUCApp.StartTime.Date == DateTime.Now.Date)
                                {
                                    //SQl
                                    if (DesiredAppointmentUCApp.HistoryClientBalance != DesiredAppointmentUCApp.DesiredClientBalance.ClientBalanceSessionLeftDetails)//since eza kenna el future we dont save el history, once sorna bel present we need to save it
                                    {
                                        DesiredAppointmentUCApp.HistoryClientBalance = DesiredAppointmentUCApp.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                                        DesiredAppointmentUCApp.UpdateHistoryClientBalance();
                                    }

                                }

                                //Design
                                labelService.Text = DesiredAppointmentUCApp.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                                if (DesiredAppointmentUCApp.DesiredClientBalance.SessionLeftDays == 0)
                                {
                                    labelService.ForeColor = Color.Red;
                                }
                                else
                                {
                                    labelService.ForeColor = Color.FromArgb(94, 94, 94);
                                }
                            }
                        }
                        else if ((bool)DesiredAppointmentUCApp.DesiredClientBalance.IsExpired)//Package exist and  expired
                        {
                            //Design

                            labelService.ForeColor = Color.FromArgb(94, 94, 94);
                            labelService.Text = DesiredAppointmentUCApp.DesiredClientBalance.BundleName + " Package Expired";
                        }

                    }
                    else if (DesiredAppointmentUCApp.DesiredClientBalance == null)// Package is deleted
                    {
                        labelService.Text = "";
                    }
                }
                else if (DesiredAppointmentUCApp.StartTime.Date < DateTime.Now.Date)//Past
                {

                    //Design
                    if (DesiredAppointmentUCApp.DesiredClientBalance == null && DesiredAppointmentUCApp.HistoryClientBalance != null)//Usually deyman both diff or equal to null together,unless package was deleted w kenna bel past  
                    {
                        labelService.Text = "Client Package Deleted";
                    }
                    else if (DesiredAppointmentUCApp.DesiredClientBalance == null && DesiredAppointmentUCApp.HistoryClientBalance == null)//kenna mnaeyin package, bel future, w hayda el package mhine abel ma nusal lal future, so IsPCakage=true, w hawde null
                    {
                        labelService.Text = "";//could change in the future
                    }
                    else if (DesiredAppointmentUCApp.DesiredClientBalance != null && DesiredAppointmentUCApp.HistoryClientBalance != null)//normal case
                    {
                        labelService.Text = DesiredAppointmentUCApp.HistoryClientBalance;
                    }
                }
            }
            else if (DesiredAppointmentUCApp.ChosenBundlesList != null && DesiredAppointmentUCApp.ChoseBundlesString != null)
            {
                //Design
                labelService.Text = DesiredAppointmentUCApp.ChoseBundlesString;
            }
            else if (DesiredAppointmentUCApp.Title != null)
            {
                //Design
                labelService.Text = DesiredAppointmentUCApp.Title;
            }
            else //mesh mna2yin la service nor title nor package
            {
                labelService.Text = "";
            }
        }

        //UPDATE


        //EVENTS:
        ///-Click

        private void Appointmentupdate_OnAppointmentUndoCancelation(object sender, EventArgs e)
        {
            DesiredAppointmentUCApp.IsCanceled = false;
            SetUCDesign();
            FixUCDesign();
            SetServiceLogicAndDesign();
        }
        private void Appointmentupdate_OnAppUpdate(object sender, EventArgs e)
        {
            Appointment appointmentupdate = (Appointment)sender;
            DesiredAppointmentUCApp = appointmentupdate.DesiredAppointmentAppForm.Copy();

            //Updating the list in uc schedule
            int index = UcScheduleParentForm.AppointmentsListWorkingOn.FindIndex(a => a.AppointmentID == DesiredAppointmentUCApp.AppointmentID);
            UcScheduleParentForm.AppointmentsListWorkingOn[index] = DesiredAppointmentUCApp;//they should refer to each others, since bcz of the copy they have lost their refrence, kermel el checkbox filters 

            SetUCDesign();
            FixUCDesign();
            SetServiceLogicAndDesign();
        }



        public void Control_MouseClick(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Ignore clicks that are part of a drag operation
                isDragging = false; // Reset the dragging flag
                return;
            }

            UcScheduleParentForm.ParentFormSchedule.CloseNotfBanner();
            ScheduleForm schedule = this.UcScheduleParentForm.ParentFormSchedule;
            Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
            Program.GreyForm.Show();
            Appointment appointmentupdate = new Appointment(this, UcScheduleParentForm);
            appointmentupdate.OnAppointmentUpdate += Appointmentupdate_OnAppUpdate;
            appointmentupdate.OnAppointmentUndoCancelation += Appointmentupdate_OnAppointmentUndoCancelation;//ased zednehun ta eza aam naamil undo w ghayarna shi bel object ma yenzalo hone
            appointmentupdate.Show();


        }


        public void RemoveAppointmentFromTLP()
        {
            UcScheduleParentForm.RemoveUcAppointmentFromTLP(this);
        }
        private void UCappointment_Resize(object sender, EventArgs e)
        {
            FixUCDesign();//ejbare kermel tfout fiya aal add appointment w tkun badda tekhud original size, tkun bel designer different then the original width.
        }


        //DESIGN
        public void DragAndDropOperationDone()
        {
            NotificationBanner NotfBanner = NotificationBanner.Show("Appointment Rescheduled", NotificationBanner.EnumType.ConfirmationMode, true, Program.HomeForm, false);
            NotfBanner.UndoNotficationBanner += NotfBanner_UndoNotficationBanner;
        }
        private void NotfBanner_UndoNotficationBanner(object sender, EventArgs e)
        {
            UcScheduleParentForm.ChangePositionUCappointments(this, DesiredAppointmentUCApp, OldDesiredAppointmentUCApp);
            DesiredAppointmentUCApp = OldDesiredAppointmentUCApp.Copy();

            //Updating the list in uc schedule
            int index = UcScheduleParentForm.AppointmentsListWorkingOn.FindIndex(a => a.AppointmentID == DesiredAppointmentUCApp.AppointmentID);
            UcScheduleParentForm.AppointmentsListWorkingOn[index] = DesiredAppointmentUCApp;//they should refer to each others, since bcz of the copy they have lost their refrence, kermel el checkbox filters 

            SetUCDesign();
            NotificationBanner.Show("", NotificationBanner.EnumType.ConfirmationMode, true, Program.HomeForm, true);
        }




        public event EventHandler UCAppIsDroped;
        Cursor customCursor;
        private void UCappointments_MouseMove(object sender, MouseEventArgs e)
        {
          
            TLPGlobal.BackColor = DefaultHoverColor;

            if ((UcScheduleParentForm.IsDayOrWeek && DesiredAppointmentUCApp.StartTime.Date >= DateTime.Now.Date) || (DesiredAppointmentUCApp.StartTime.Date >= DateTime.Now.Date && !UcScheduleParentForm.IsDayOrWeek && UcScheduleParentForm.TheOnlyEmployee != null))//onlty present or future
            {

                if (!isDragging && e.Button == MouseButtons.Left)
                {
                    if (Math.Abs(e.X - initialMouseDownPoint.X) > SystemInformation.DoubleClickSize.Width ||
                        Math.Abs(e.Y - initialMouseDownPoint.Y) > SystemInformation.DoubleClickSize.Height)
                    {
                        isDragging = true; // Set the dragging flag

                        Bitmap controlImage = CaptureControlImage(this); // Capture the image of the control
                        customCursor = CreateCursorFromImage(controlImage); // Create a cursor


                        DoDragDrop(this, DragDropEffects.Move);//ha ndalna hone until naaml drop
                        UCAppIsDroped?.Invoke(null, EventArgs.Empty);
                    }
                }
            }
        }
        private void UCappointments_MouseLeave(object sender, EventArgs e)
        {

            TLPGlobal.BackColor = DefaultColor;

        }
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            initialMouseDownPoint = e.Location;
            isDragging = false; // Reset dragging flag


        }
        private Bitmap CaptureControlImage(Control control)
        {
            Bitmap controlImage = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(controlImage, new Rectangle(0, 0, control.Width, control.Height));
            return controlImage;
        }


        // DLL imports to use the GetIconInfo and CreateIconIndirect functions
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }
        private Cursor CreateCursorFromImage(Bitmap bmp)
        {
            int hotspotX = bmp.Width / 2;
            int hotspotY = 0; // Top of the image

            // Create a cursor with the specified hotspot
            IntPtr ptr = bmp.GetHicon();
            IconInfo tmp = new IconInfo();
            GetIconInfo(ptr, ref tmp);
            tmp.xHotspot = hotspotX;
            tmp.yHotspot = hotspotY;
            tmp.fIcon = false; // Specify that this is a cursor, not an icon

            ptr = CreateIconIndirect(ref tmp);
            return new Cursor(ptr);
        }

        private void UCappointment_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (e.Action == DragAction.Drop || e.Action == DragAction.Cancel)
            {
                isDragging = false; // Reset dragging state
            }
        }

        private void UCappointment_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false; // Prevent the system from setting default cursors
            if (isDragging)
            {
                Cursor.Current = customCursor; // Ensure the custom cursor is used
            }
        }





    }
}
