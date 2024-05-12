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

        public int ColumnPosition { get; set; }
        public int PositionRowStart { get; set; }
        public int PositionRowEnd { get; set; }



        //
        public bool IsChildMode { get; set; }

        //VARIABLE
        public UCDay UcDayParentForm { get; set; }
        public static int OriginalWidth = 230;
        public static int OriginalHeiht =82 ;
        private Point initialMouseDownPoint;
        public bool isDragging = false;


        //
        Label LabelBalance;

        public UCappointment(ClassAppointment desiredappointment)
        {
            InitializeComponent();
            //Aam nekhoud Col and Row pos taba3 lucappointment, bas lezim ykun mawjude honik, awwal ma yenkhalae el appointment

            DesiredAppointmentUCApp = desiredappointment;
            SetUCDesign();
            SetServiceLogicAndDesign();

        }
        //ADD and SELECT (remember in add there's no uctime but in select there's) 
        public UCappointment(ClassAppointment desiredappointment, UCDay uCDay, List<int> ListEmployee_id)
        {
            InitializeComponent();
            DesiredAppointmentUCApp = desiredappointment;
            UcDayParentForm = uCDay;


            
            (ColumnPosition,PositionRowStart, PositionRowEnd) = UcDayParentForm.GetUCAppointmentPosition(DesiredAppointmentUCApp, UcDayParentForm.ListEmployee_idAllTime);


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
                    labelTime.Anchor = AnchorStyles.Top;
                    labelTime.Margin = new Padding(0, 5, 0, 0);

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
                labelTime.Anchor = AnchorStyles.None;
                labelTime.Margin = new Padding(0, 0, 0, 0);
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

                if (!UcDayParentForm.ParentFormSchedule.checkBoxComplete.Checked && this.Visible)
                {
                    this.Visible = false;
                    RemoveAppointmentFromTLP();
                }
                else if(UcDayParentForm.ParentFormSchedule.checkBoxComplete.Checked && !this.Visible)
                {
                    this.Visible = true;
                }
            }
            else if (DesiredAppointmentUCApp.IsCanceled)
            {
                this.BackColor = Color.FromArgb(244, 86, 7);//orange

                if (!UcDayParentForm.ParentFormSchedule.checkBoxCancel.Checked && this.Visible)
                {
                    this.Visible = false;
                    RemoveAppointmentFromTLP();

                }
                if (UcDayParentForm.ParentFormSchedule.checkBoxCancel.Checked && !this.Visible)
                {
                    this.Visible = true;
                }
            }
            else
            {
                this.BackColor = Program.BoldColor;

                if (!UcDayParentForm.ParentFormSchedule.checkBoxOnPending.Checked && this.Visible)
                {
                    this.Visible = false;
                    RemoveAppointmentFromTLP();
                }
                else if (UcDayParentForm.ParentFormSchedule.checkBoxOnPending.Checked && !this.Visible)
                {
                    this.Visible = true;
                }
            }





        }
        void FixUCDesign()
        {
            //initial Design
            TLPGlobal.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 100f);

            if (DesiredAppointmentUCApp.DesiredClient != null && DesiredAppointmentUCApp.DesiredClient.TotalBalance != 0 && DesiredAppointmentUCApp.StartTime.Date >= DateTime.Now.Date)//Present-Future           
            {
                TLPGlobal.ColumnStyles[2].Width = RandomFunctions.MeasureLabelText(LabelBalance) + 20;

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

            int DesiredHeightFortheLabel = RandomFunctions.CalculateDesiredHeight(labelFullName, labelFullName.Width - 8);


            if (DesiredHeightFortheLabel > cellHeight || CellWidth <= 0)//in case el label ma kenit sey3a
            {
                int MinimumNameWidth = RandomFunctions.CalculateDesiredWidth(labelFullName, labelFullName.Height);
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



        }


        void CreationOfLabelBalance()
        {
            LabelBalance = new Label();
            LabelBalance.Font = new Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            LabelBalance.AutoSize = true;
            LabelBalance.Margin = new Padding(0, 5, 0, 0);
            LabelBalance.ForeColor = Color.Red;
            LabelBalance.Anchor = AnchorStyles.Top;
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

                            if (DesiredAppointmentUCApp.StartTime.Date == DateTime.Now.Date)
                            {
                                //SQl
                                if (DesiredAppointmentUCApp.HistoryClientBalance != DesiredAppointmentUCApp.DesiredClientBalance.ClientBalanceSessionLeftDetails)//since eza kenna el future we dont save el history, once sorna bel present we need to save it
                                {
                                    DesiredAppointmentUCApp.HistoryClientBalance = DesiredAppointmentUCApp.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                                    DesiredAppointmentUCApp.UpdateHistoryClientBalance();
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
                            else if (DesiredAppointmentUCApp.StartTime.Date > DateTime.Now.Date)
                            {
                                //Design
                                labelService.Text = DesiredAppointmentUCApp.DesiredClientBalance.BundleName + " Package";
                            }
                        }
                        else if ((bool)DesiredAppointmentUCApp.DesiredClientBalance.IsExpired)//Package exist and  expired
                        {
                            //Design
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
        private void Appointmentupdate_OnAppointmentUndoCompletion(object sender, EventArgs e)
        {
            Appointment appointmentupdate = (Appointment)sender;
            DesiredAppointmentUCApp.IsCompleted = false;
            DesiredAppointmentUCApp.DesiredClient.TotalBalance = appointmentupdate.DesiredAppointmentAppForm.DesiredClient.TotalBalance;

            if (DesiredAppointmentUCApp.DesiredClientBalance != null && DesiredAppointmentUCApp.DesiredClientBalance.DueDate == null && DesiredAppointmentUCApp.DesiredClientBalance.SessionLeftDays != null)//package of sessions
            {
                DesiredAppointmentUCApp.DesiredClientBalance.SessionLeftDays = appointmentupdate.DesiredAppointmentAppForm.DesiredClientBalance.SessionLeftDays;
                DesiredAppointmentUCApp.DesiredClientBalance.SetStringDetailsIfBundle();
            }

            SetUCDesign();
            FixUCDesign();
            SetServiceLogicAndDesign();
        }
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
            if (TouchScroll.MoveHoldClick == false)
            {
                if (DesiredAppointmentUCApp.StartTime.Date < DateTime.Now.Date && DesiredAppointmentUCApp.IsPackageMode && ((DesiredAppointmentUCApp.DesiredClientBalance == null && DesiredAppointmentUCApp.HistoryClientBalance != null) || (DesiredAppointmentUCApp.DesiredClientBalance == null && DesiredAppointmentUCApp.HistoryClientBalance == null)))//past
                {
                    //package deleted or package not selected In The Past

                    CustomMessageBox.Show(this.labelService.Text + "\nCan't open it", CustomMessageBox.Type.Ok);

                }
                else//present future
                {
                    ScheduleForm schedule = this.UcDayParentForm.ParentFormSchedule;
                    Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
                    Program.GreyForm.Show();
                    Appointment appointmentupdate = new Appointment(this, UcDayParentForm);
                    appointmentupdate.OnAppointmentUpdate += Appointmentupdate_OnAppUpdate;
                    appointmentupdate.OnAppointmentUndoCancelation += Appointmentupdate_OnAppointmentUndoCancelation;//ased zednehun ta eza aam naamil undo w ghayarna shi bel object ma yenzalo hone
                    appointmentupdate.OnAppointmentUndoCompletion += Appointmentupdate_OnAppointmentUndoCompletion;
                    appointmentupdate.Show();
                }
            }

        }
        public void RemoveAppointmentFromTLP()
        {
            //DESIGN
            TimeSpan starttimeTimeSpan = DesiredAppointmentUCApp.StartTime.TimeOfDay;
            int positionrow = starttimeTimeSpan.Hours;
            int positioncol = UcDayParentForm.ListEmployee_idChecked.IndexOf((int)DesiredAppointmentUCApp.EmployeeId) + 1;
            FlowLayoutPanel clickedflowLayoutPanel = UcDayParentForm.TLPAppointment.GetControlFromPosition(positioncol, positionrow) as FlowLayoutPanel;//position flowlayoutpanel hiye position employee bel list-1 


            int NumberOfVisibleControlsOfClickedFLP = 0;
            foreach (Control ctrl in clickedflowLayoutPanel.Controls)
            {
                if (ctrl.Visible)
                {
                    NumberOfVisibleControlsOfClickedFLP++;
                }
            }

            ResizeINRemovingUCAppInFLP(clickedflowLayoutPanel, NumberOfVisibleControlsOfClickedFLP, positioncol, positionrow);
        }
        public void ResizeINRemovingUCAppInFLP(FlowLayoutPanel clickedflowLayoutPanel, int NumberOfVisibleControlsOfClickedFLP, int positioncol, int positionrow)
        {
           
        }
        public bool IsThisTheMaxFLP(int positioncol, int positionrow, int NumberOfVisibleControlsOfClickedFLP)//WHO CONTAINS THE Biggest Count
        {
            //The FlowLayoutpanel where we dispose the ucdata does it have akbar aadad ucdata before we dispose this ucdata if yes it will affect the TBL
            bool havethemaxucdata = true;

            for (int i = 0; i < UcDayParentForm.TLPAppointment.RowCount; i++)
            {
                if (positionrow != i)
                {
                    Control cellControl = UcDayParentForm.TLPAppointment.GetControlFromPosition(positioncol, i);
                    if (cellControl is FlowLayoutPanel)
                    {
                        FlowLayoutPanel innerFlowLayoutPanel = (FlowLayoutPanel)cellControl;
                        int NumberOfVisibleControls = 0;
                        foreach (Control ctrl in innerFlowLayoutPanel.Controls)
                        {
                            if (ctrl.Visible)
                            {
                                NumberOfVisibleControls++;
                            }
                        }
                        if ((NumberOfVisibleControlsOfClickedFLP + 1)/*+1 li2anno manna na3rif abel ma yaeemil dispose*/ > NumberOfVisibleControls)
                        {

                        }

                        //eza hata = la hada bet batil zabta
                        else
                        {
                            //if it's equal or false then the supposition is false so we have to break
                            havethemaxucdata = false;
                            break;
                        }
                    }
                }

                //Eza ata3 bi halo akid ma y2arin halo
                else
                {

                }

            }
            return havethemaxucdata;
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
            DesiredAppointmentUCApp = OldDesiredAppointmentUCApp.Copy();
            (int OldPositionColumn, int OldPositionRowStart, int OldPositionRowEnd) = UcDayParentForm.GetUCAppointmentPosition(DesiredAppointmentUCApp, UcDayParentForm.ListEmployee_idAllTime);
            UcDayParentForm.ChangePositionUCappointments(this, OldPositionColumn, OldPositionRowStart, OldPositionRowEnd, true);

            SetUCDesign();
            NotificationBanner.Show("", NotificationBanner.EnumType.ConfirmationMode, true, Program.HomeForm, true);

        }





        Cursor customCursor;
        private void UCappointments_MouseMove(object sender, MouseEventArgs e)
        {
            if (TouchScroll.MoveHoldClick == false)
            {
                if (TLPGlobal.BackColor != UcDayParentForm.DisableColorTBUca)//229, 226, 244
                {
                    TLPGlobal.BackColor = Color.FromArgb(249, 246, 254);
                }
            }

            if (!isDragging && e.Button == MouseButtons.Left)
            {
                if (Math.Abs(e.X - initialMouseDownPoint.X) > SystemInformation.DoubleClickSize.Width ||
                    Math.Abs(e.Y - initialMouseDownPoint.Y) > SystemInformation.DoubleClickSize.Height)
                {
                    isDragging = true; // Set the dragging flag
                   
                    Bitmap controlImage = CaptureControlImage(this); // Capture the image of the control
                    customCursor = CreateCursorFromImage(controlImage); // Create a cursor

              
                    DoDragDrop(this, DragDropEffects.Move);
                    Cursor.Current = customCursor; // Set custom cursor during drag
                }
            }
        }
        private void UCappointments_MouseLeave(object sender, EventArgs e)
        {
            if (TLPGlobal.BackColor != UcDayParentForm.DisableColorTBUca)
            {
                TLPGlobal.BackColor = Color.White;
            }
        }
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            initialMouseDownPoint = e.Location;
            //UcDayParentForm.TouchscrollPanelUCDay.RemoveEventPanelUCDay(UcDayParentForm.TLPAppointment);
            isDragging = false; // Reset dragging flag


            //ParentFormUCday.TouchscrollPanelUCDay.RemoveEventPanelUCDay(ParentFormUCday.TLPAppointment);
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

        public event EventHandler UCAppIsDroped;
        private void UCappointment_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (e.Action == DragAction.Drop || e.Action == DragAction.Cancel)
            {

                Cursor.Current = Cursors.Default; // Reset the cursor to default
                isDragging = false; // Reset dragging state
                UCAppIsDroped?.Invoke(null, EventArgs.Empty);

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
