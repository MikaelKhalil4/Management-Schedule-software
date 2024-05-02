using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using MKproject.Management;
using GlobalFunctions;
using System.Data;
using CustomizedTools;


namespace MKproject.Schedule
{
    public partial class UCappointment : UserControl
    {
        //PROPERTY:
        public ClassAppointment DesiredAppointmentUCApp { get; set; }
        public int ColumnPosition { get; set; }
        public int RowPosition { get; set; }

        //VARIABLE
        public UCDay ParentFormucday { get; set; }
        public static int OriginalWidth = 230;
        private Point initialMouseDownPoint;
        private bool isDragging = false;


        //
        Label LabelBalance;

    
        //ADD and SELECT (remember in add there's no uctime but in select there's) 
        public UCappointment(ClassAppointment desiredappointment, UCDay uCDay)
        {
            InitializeComponent();
            DesiredAppointmentUCApp = desiredappointment;
            ParentFormucday = uCDay;


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

                if (!ParentFormucday.ParentFormSchedule.checkBoxComplete.Checked)
                {
                    this.Visible = false;
                    RemoveAppointmentFromTLP();
                }
            }
            else if (DesiredAppointmentUCApp.IsCanceled)
            {
                this.BackColor = Color.FromArgb(244, 86, 7);//orange

                if (!ParentFormucday.ParentFormSchedule.checkBoxCancel.Checked)
                {
                    this.Visible = false;
                    RemoveAppointmentFromTLP();
                }
            }
            else
            {
                this.BackColor = Program.BoldColor;

                if (!ParentFormucday.ParentFormSchedule.checkBoxOnPending.Checked)
                {
                    this.Visible = false;
                    RemoveAppointmentFromTLP();
                }
            }


            //StartTime
            string timestring = DesiredAppointmentUCApp.StartTime.ToString("h:mm tt");
            string[] partstime = timestring.Split(' ');
            labelTime.Text = partstime[0];//eza baddak yeha 7:00 PM fik terjaee tghayera w thot timestring 

            //EndTime
            timestring = DesiredAppointmentUCApp.EndTime.ToString("h:mm tt");
            partstime = timestring.Split(' ');
            labelTime.Text += " - " + partstime[0];//eza baddak yeha 7:00 PM fik terjaee tghayera w thot timestring 


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
                    ScheduleForm schedule = this.ParentFormucday.ParentFormSchedule;
                    Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
                    Program.GreyForm.Show();
                    Appointment appointmentupdate = new Appointment(this, ParentFormucday);
                    appointmentupdate.OnAppointmentUpdate += Appointmentupdate_OnAppUpdate;
                    appointmentupdate.OnAppointmentUndoCancelation += Appointmentupdate_OnAppointmentUndoCancelation;//ased zednehun ta eza aam naamil undo w ghayarna shi bel object ma yenzalo hone
                    appointmentupdate.OnAppointmentUndoCompletion += Appointmentupdate_OnAppointmentUndoCompletion;
                    appointmentupdate.Show();
                }
            }
            else
            {

            }
        }
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


        public void RemoveAppointmentFromTLP()
        {
            //DESIGN
            TimeSpan starttimeTimeSpan = DesiredAppointmentUCApp.StartTime.TimeOfDay;
            int positionrow = starttimeTimeSpan.Hours;
            int positioncol = ParentFormucday.ListEmployee_idChecked.IndexOf((int)DesiredAppointmentUCApp.EmployeeId) + 1;
            FlowLayoutPanel clickedflowLayoutPanel = ParentFormucday.TLPAppointment.GetControlFromPosition(positioncol, positionrow) as FlowLayoutPanel;//position flowlayoutpanel hiye position employee bel list-1 


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
            //Absolute
            if (ParentFormucday.TLPAppointment.ColumnStyles[positioncol].SizeType is SizeType.Absolute)
            {
                bool isThisTheMaxFLP = IsThisTheMaxFLP(positioncol, positionrow, NumberOfVisibleControlsOfClickedFLP);

                //hayde lconidtion => moujarad ma ysir lwidth taba3 kel lcontrols azghar men lpercentage width TLP
                int[] columnWidths = ParentFormucday.TLPAppointment.GetColumnWidths();

                int ColumnPercentageWidth = (ParentFormucday.TLPAppointment.Width - columnWidths[0]) / (ParentFormucday.TLPAppointment.ColumnCount - 1);
                int AppointemntsTotalWidth = UCappointment.OriginalWidth * NumberOfVisibleControlsOfClickedFLP;

                if (AppointemntsTotalWidth < ColumnPercentageWidth && isThisTheMaxFLP)
                {
                    RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(ParentFormucday.TLPAppointment);
                    RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(ParentFormucday.TLPEmployees);

                    int columnwidth = ParentFormucday.TLPAppointment.GetColumnWidths()[positioncol];
                    //eza ee edit width
                    if (((UCappointment.OriginalWidth * NumberOfVisibleControlsOfClickedFLP) + ParentFormucday.KeepSpace) > columnwidth)
                    {
                        ParentFormucday.EditWidthAppointment(clickedflowLayoutPanel, ColumnPercentageWidth, NumberOfVisibleControlsOfClickedFLP);
                    }
                    else
                    {
                        foreach (UCappointment ucappointment in clickedflowLayoutPanel.Controls.OfType<UCappointment>())
                        {
                            ucappointment.Width = UCappointment.OriginalWidth;
                        }
                    }
                }

                //eza ken lflow layout panel li mahayna fiyo ucappointment aando akbar aada hone it may edit the size of the absolute column
                else if (isThisTheMaxFLP)
                {
                    ParentFormucday.EditColumnAbsoluteSize(positioncol, positionrow);
                }

                //se3eta bas momkin yet2asar lwidthucappointment
                else
                {
                    int columnwidth = ParentFormucday.TLPAppointment.GetColumnWidths()[positioncol];
                    //eza ee edit width
                    if (((UCappointment.OriginalWidth * NumberOfVisibleControlsOfClickedFLP) + ParentFormucday.KeepSpace) > columnwidth)
                    {
                        ParentFormucday.EditWidthAppointment(clickedflowLayoutPanel, columnwidth, NumberOfVisibleControlsOfClickedFLP);
                    }
                    else
                    {
                        foreach (UCappointment ucappointment in clickedflowLayoutPanel.Controls.OfType<UCappointment>())
                        {
                            ucappointment.Width = UCappointment.OriginalWidth;
                        }
                    }
                }
            }

            //Percentage
            else
            {
                int columnwidth = ParentFormucday.TLPAppointment.GetColumnWidths()[positioncol];
                //eza ee edit width
                if (((UCappointment.OriginalWidth * NumberOfVisibleControlsOfClickedFLP) + ParentFormucday.KeepSpace) > columnwidth)
                {
                    ParentFormucday.EditWidthAppointment(clickedflowLayoutPanel, columnwidth, NumberOfVisibleControlsOfClickedFLP);
                }
                else
                {
                    foreach (UCappointment ucappointment in clickedflowLayoutPanel.Controls.OfType<UCappointment>())
                    {
                        ucappointment.Width = UCappointment.OriginalWidth;
                    }
                }
            }
        }
        public bool IsThisTheMaxFLP(int positioncol,int positionrow, int NumberOfVisibleControlsOfClickedFLP)//WHO CONTAINS THE Biggest Count
        {
            //The FlowLayoutpanel where we dispose the ucdata does it have akbar aadad ucdata before we dispose this ucdata if yes it will affect the TBL
            bool havethemaxucdata = true;

            for (int i = 0; i < ParentFormucday.TLPAppointment.RowCount; i++)
            {
                if (positionrow != i)
                {
                    Control cellControl = ParentFormucday.TLPAppointment.GetControlFromPosition(positioncol, i);
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






        //DESIGN
        private void UCappointments_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if the mouse has moved enough to be considered a drag.
            if (!isDragging && e.Button == MouseButtons.Left)
            {
                if (Math.Abs(e.X - initialMouseDownPoint.X) > SystemInformation.DoubleClickSize.Width ||
                    Math.Abs(e.Y - initialMouseDownPoint.Y) > SystemInformation.DoubleClickSize.Height)
                {
                    isDragging = true; // The control is being dragged.

                    DoDragDrop(this, DragDropEffects.Move);
                }
            }

            if (TouchScroll.MoveHoldClick == false)
            {
                if (TLPGlobal.BackColor != ParentFormucday.DisableColorTBUca)//229, 226, 244
                {
                    TLPGlobal.BackColor = Color.FromArgb(249, 246, 254);
                }
            }
            else
            {

            }
        }
        private void UCappointments_MouseLeave(object sender, EventArgs e)
        {
            if (TLPGlobal.BackColor != ParentFormucday.DisableColorTBUca)
            {
                TLPGlobal.BackColor = Color.White;
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            initialMouseDownPoint = e.Location;
            ParentFormucday.TouchscrollPanelUCDay.RemoveEventPanelUCDay(ParentFormucday.TLPAppointment);
            isDragging = false; // Reset dragging flag
        }

        
        private void UCappointment_Resize(object sender, EventArgs e)
        {
            FixUCDesign();//ejbare kermel tfout fiya aal add appointment w tkun badda tekhud original size, tkun bel designer different then the original width.
        }

       
    }
}
