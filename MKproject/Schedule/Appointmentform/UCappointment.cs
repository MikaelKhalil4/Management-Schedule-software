using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using static MKproject.Schedule.StaticClass;
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

        //
        Label LabelBalance;

        //INITIALISE
        public UCappointment()
        {
            InitializeComponent();
        }


        //ADD and SELECT (remember in add there's no uctime but in select there's) 
        public UCappointment(ClassAppointment desiredappointment, UCDay uCDay)
        {
            InitializeComponent();
            DesiredAppointmentUCApp = desiredappointment;
            ParentFormucday = uCDay;
            SetUCDesign();
            SetServiceLogicAndDesign();
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
                    if (LabelBalance != null)
                    {
                        LabelBalance.Dispose();
                        LabelBalance = null;
                        TLPGlobal.ColumnCount -= 1;
                        TLPGlobal.ColumnStyles.RemoveAt(TLPGlobal.ColumnCount - 1);

                        TLPGlobal.SetColumnSpan(labelTime, 1);
                    }
                    TLPGlobal.ColumnStyles[1].Width = RandomFunctions.MeasureLabelText(labelTime) + 10;
                }
            }

          
            //State
            if (DesiredAppointmentUCApp.IsCompleted)
            {
                this.BackColor = this.BackColor = Color.FromArgb(124, 218, 124);
            }
            else if (DesiredAppointmentUCApp.IsCanceled)
            {
                this.BackColor = Color.FromArgb(244, 86, 7);
            }
            else
            {
                this.BackColor = Program.BoldColor;
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
        public void SetServiceLogicAndDesign()
        {
            //Service
            if (DesiredAppointmentUCApp.IsPackageMode)
            {
                if (DesiredAppointmentUCApp.StartTime.Date == DateTime.Now.Date)//Present
                {

                    if (DesiredAppointmentUCApp.DesiredClientBalance != null && !(bool)DesiredAppointmentUCApp.DesiredClientBalance.IsExpired)
                    {
                        labelService.Text = DesiredAppointmentUCApp.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                      
                        if (DesiredAppointmentUCApp.HistoryClientBalance == null)//since eza kenna el future we dont save el history, once sorna bel present we need to save it
                        {
                            DesiredAppointmentUCApp.HistoryClientBalance = DesiredAppointmentUCApp.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                            DesiredAppointmentUCApp.UpdateHistoryClientBalance();
                        }
                    }
                    else
                    {
                        DataTable PackageRemainingsDt = ClassClientBalance.GetClientBalanceNotExpiredPackage(DesiredAppointmentUCApp.DesiredClient.ClientId);
                        if (PackageRemainingsDt.Rows.Count == 1)//deleted aw expired, in both , eza fi one w IsPackageMode=true , we will auto select the package
                        {

                            //sql
                            DesiredAppointmentUCApp.DesiredClientBalance = ClassClientBalance.CreateClientBalanceObject((int)(PackageRemainingsDt.Rows[0]["client_balance_id"]));
                            DesiredAppointmentUCApp.DesiredClientBalance.SetStringDetailsIfBundle();
                            DesiredAppointmentUCApp.HistoryClientBalance = DesiredAppointmentUCApp.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                            DesiredAppointmentUCApp.InsertOrUpdateAppointment(false);//ejbare tahet SetStringDetailsIfBundle();

                            //design
                            labelService.Text = DesiredAppointmentUCApp.DesiredClientBalance.ClientBalanceSessionLeftDetails;

                        }
                        else if (PackageRemainingsDt.Rows.Count > 1)
                        {
                            if (DesiredAppointmentUCApp.DesiredClientBalance != null)//in case the package still exists but expired , bet fout fiya to release the DesiredClientBalance, eza ken deleted ma bet fout fiya
                            {
                                DesiredAppointmentUCApp.DesiredClientBalance = null;
                                DesiredAppointmentUCApp.HistoryClientBalance = null;
                                DesiredAppointmentUCApp.InsertOrUpdateAppointment(false);
                            }

                            labelService.Text = "Choose a package";
                        }
                        else
                        {
                            if (DesiredAppointmentUCApp.DesiredClientBalance != null)//in case the package still exists but expired , bet fout fiya to release the DesiredClientBalance, eza ken deleted ma bet fout fiya
                            {
                                DesiredAppointmentUCApp.DesiredClientBalance = null;
                                DesiredAppointmentUCApp.HistoryClientBalance = null;
                                DesiredAppointmentUCApp.InsertOrUpdateAppointment(false);
                            }
                            labelService.Text = "No Available Packages ";
                        }
                    }


                }
                else if (DesiredAppointmentUCApp.StartTime.Date > DateTime.Now.Date)//future
                {
                    //sql
                    DataTable PackageRemainingsDt = ClassClientBalance.GetClientBalanceNotExpiredPackage(DesiredAppointmentUCApp.DesiredClient.ClientId);
                    DesiredAppointmentUCApp.DesiredClientBalance = ClassClientBalance.CreateClientBalanceObject((int)(PackageRemainingsDt.Rows[0]["client_balance_id"]));

                    string ServiceName = ClassBundles.FindBundleName((int)DesiredAppointmentUCApp.DesiredClientBalance.BundleId);
                    labelService.Text = ServiceName+" package autoselects at present";
                }
                else if (DesiredAppointmentUCApp.StartTime.Date < DateTime.Now.Date)//Past
                {

                    if (DesiredAppointmentUCApp.DesiredClientBalance == null && DesiredAppointmentUCApp.HistoryClientBalance != null)//Usually deyman both diff then null together , unless package was deleted w kenna bel past , 
                    {
                        labelService.Text = "Client Package Deleted";
                    }
                    else if (DesiredAppointmentUCApp.DesiredClientBalance != null && DesiredAppointmentUCApp.HistoryClientBalance == null || DesiredAppointmentUCApp.DesiredClientBalance == null && DesiredAppointmentUCApp.HistoryClientBalance == null)//hone IsPackageMode=true, bas ma fatath today schedule w ken fi appointment hatto bel future, so ma naamal automatic set lal historyClientBalance tb3 el appointment , so hek bir sir bel past
                    {
                        labelService.Text = "No Package was selected";
                    }
                    else if (DesiredAppointmentUCApp.DesiredClientBalance != null && DesiredAppointmentUCApp.HistoryClientBalance != null)//normal case
                    {
                        labelService.Text = DesiredAppointmentUCApp.HistoryClientBalance;
                    }

                }

            }

            else if (DesiredAppointmentUCApp.ChosenBundlesList != null && DesiredAppointmentUCApp.ChoseBundlesString != null)
            {
                labelService.Text = DesiredAppointmentUCApp.ChoseBundlesString;
            }
            else if (DesiredAppointmentUCApp.Title != null)
            {
                labelService.Text = DesiredAppointmentUCApp.Title;
            }


        }

        //UPDATE


        //EVENTS:
        ///-Click
        private void UCappointments_Click(object sender, EventArgs e)
        {
            if (TouchScroll.MoveHoldClick == false)
            {
                ScheduleForm schedule = this.ParentFormucday.ParentFormSchedule;
                Program.GreyForm = new GreyColor(((Home)schedule.Tag), true, false);
                Program.GreyForm.Show();
                Appointment appointmentupdate = new Appointment(this,ParentFormucday);
                appointmentupdate.OnAppointmentUpdate += Appointmentupdate_OnAppUpdate;
                appointmentupdate.OnAppointmentUndoCancelation += Appointmentupdate_OnAppointmentUndoCancelation;//ased zednehun ta eza aam naamil undo w ghayarna shi bel object ma yenzalo hone
                appointmentupdate.OnAppointmentUndoCompletion += Appointmentupdate_OnAppointmentUndoCompletion;
                appointmentupdate.Show();
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
            SetServiceLogicAndDesign();
        }

        private void Appointmentupdate_OnAppointmentUndoCancelation(object sender, EventArgs e)
        {
            DesiredAppointmentUCApp.IsCanceled = false;
            SetUCDesign();
            SetServiceLogicAndDesign();
        }

        private void Appointmentupdate_OnAppUpdate(object sender, EventArgs e)
        {
            Appointment appointmentupdate = (Appointment)sender;
            DesiredAppointmentUCApp = appointmentupdate.DesiredAppointmentAppForm.Copy();
            SetUCDesign();
            SetServiceLogicAndDesign();
        }

        public void RemoveAppointment()
        {
            //SQL
            DesiredAppointmentUCApp.DeleteAppointment();//ejbare hone mahalla mesh bel appointment form

            //DESIGN
            TimeSpan starttimeTimeSpan = DesiredAppointmentUCApp.StartTime.TimeOfDay;
            int positionrow = starttimeTimeSpan.Hours;
            int positioncol = ParentFormucday.ListEmployee_idChecked.IndexOf((int)DesiredAppointmentUCApp.EmployeeId) + 1;
            FlowLayoutPanel clickedflowLayoutPanel = ParentFormucday.TLPAppointment.GetControlFromPosition(positioncol, positionrow) as FlowLayoutPanel;//position flowlayoutpanel hiye position employee bel list-1 
            this.Dispose();


            //Fi hal ucdata ma ken eendoun originale lwidth lezim nredoun la na3if eza byo2ta3 limit
            foreach (UCappointment ucappointment in clickedflowLayoutPanel.Controls.OfType<UCappointment>())
            {
                ucappointment.Width = UCappointment.OriginalWidth;//UCAddClick.Width it's static width that I declared it
            }




            //Absolute
            if (ParentFormucday.TLPAppointment.ColumnStyles[positioncol].SizeType is SizeType.Absolute)
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
                            if ((clickedflowLayoutPanel.Controls.Count + 1)/*+1 li2anno manna na3rif abel ma yaeemil dispose*/ > innerFlowLayoutPanel.Controls.Count)
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

                //hayde lconidtion => kel flowlayoutpanel ma aandoun wala ucappointment because eza lmax 0 yaeene kelo 0
                if (clickedflowLayoutPanel.Controls.Count == 0 && havethemaxucdata)
                {
                    RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(ParentFormucday.TLPAppointment);
                    RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(ParentFormucday.TLPEmployees);
                }

                //eza ken lflow layout panel li mahayna fiyo ucappointment aando akbar aada hone it may edit the size of the absolute column
                else if (havethemaxucdata)
                {
                    ParentFormucday.EditColumnAbsoluteSize(positioncol, positionrow);
                }

                //se3eta bas momkin yet2asar lwidthucappointment
                else
                {
                    int columnwidth = ParentFormucday.TLPAppointment.GetColumnWidths()[positioncol];
                    //eza ee edit width
                    if (((UCappointment.OriginalWidth * clickedflowLayoutPanel.Controls.Count) + ParentFormucday.KeepSpace) > columnwidth)
                    {
                        ParentFormucday.EditWidthAppointment(clickedflowLayoutPanel, columnwidth);
                    }
                }
            }

            //Percentage
            else
            {
                int columnwidth = ParentFormucday.TLPAppointment.GetColumnWidths()[positioncol];
                //eza ee edit width
                if (((UCappointment.OriginalWidth * clickedflowLayoutPanel.Controls.Count) + ParentFormucday.KeepSpace) > columnwidth)
                {
                    ParentFormucday.EditWidthAppointment(clickedflowLayoutPanel, columnwidth);
                }
            }
        }







        //DESIGN
        private void UCappointments_MouseMove(object sender, MouseEventArgs e)
        {
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


    }
}
