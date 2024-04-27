using CustomizedTools;
using GlobalFunctions;
using MKproject.Schedule;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace MKproject.Management
{
    public partial class UCBundlePackage : UserControl
    {
        Label labelBalanceDetails;
        Label labelBalance;
        CustomButton buttonRemove;
        CustomButton buttonRenew;
        CustomButton buttonReduceSession;
        CustomButton buttonFreeze;
        //Button buttonReduceSession = new Button();
        bool IsActiveMode = false;
        bool IsDesactiveMode = false;

        public Color ColorMouseOver = Color.FromArgb(222, 222, 222);
        public Color ColorDedault = Color.White;

        Color ColorActiveMode = Color.FromArgb(128, 128, 255);
        Color ColorDesActiveMode = Color.Red;
        Color ColorFreezing = Color.FromArgb(3, 177, 241);

        string Freeze = "Freeze", Reduce = "Reduce";

        public ClientManagementProfile ParentFormClientMan { get; set; }
        public int? BundleId { get; set; }// in order when we want to renew njib el original information of the bundle


        private int desiredClientBalanceId;
        public int DesiredClientBalanceId
        {
            get { return desiredClientBalanceId; }
            set
            {
                desiredClientBalanceId = value;

            }
        }
        private int fakeid;
        public int FakeId
        {
            get { return fakeid; }
            set
            {
                fakeid = value;
                labelIDDetails.Text = fakeid.ToString();
            }
        }

        private string bundleDescription;
        public string BundleDescription
        {
            get { return bundleDescription; }
            set
            {
                bundleDescription = value;
                labelBundleDescription.Text = bundleDescription;
            }
        }


        private ClassBundles.enumBundle bundleType;
        public ClassBundles.enumBundle BundleType
        {
            get { return bundleType; }
            set
            {
                bundleType = value;
                if (bundleType == ClassBundles.enumBundle.Sessions)
                {

                    BundleSessionsMode();
                }
                else if (bundleType == ClassBundles.enumBundle.Days)
                {

                    BundleDaysMode();

                }
            }
        }


        private DateTime? dueDate;
        public DateTime? DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                if (labelDueDateDetails != null)
                {
                    labelDueDateDetails.Text = RandomFunctions.SetDateFormatWithDayWithoutHour(dueDate.ToString());
                }

            }
        }


        private int sessionOrDaysLeft;
        public int SessionDaysLeft
        {
            get { return sessionOrDaysLeft; }
            set
            {
                sessionOrDaysLeft = value;
                labelSessiosOrDaysDetails.Text = Convert.ToString(sessionOrDaysLeft);
                if (bundleType == ClassBundles.enumBundle.Sessions)
                {
                    if (sessionOrDaysLeft == 0)
                    {

                        if (!IsDesactiveMode)
                        {

                            DesactiveModeOn();
                        }
                    }
                    else
                    {
                        if (!IsActiveMode)
                        {
                            ActiveModeOn();
                        }
                    }
                }
                else if (bundleType == ClassBundles.enumBundle.Days)
                {
                    if (sessionOrDaysLeft < 0)
                    {
                        labelSessiosOrDaysDetails.Text = "No Days Left";
                        if (!IsDesactiveMode)
                        {

                            DesactiveModeOn();
                        }
                    }
                    else
                    {
                        if (sessionOrDaysLeft == 0)
                        {
                            labelSessiosOrDaysDetails.Text = "Last Day";
                            if (!IsDesactiveMode)
                            {
                                DesactiveModeOn();
                            }
                        }
                        else
                        {
                            if (!IsActiveMode)
                            {
                                ActiveModeOn();
                            }
                        }


                    }
                }
            }
        }


        private bool isFreezingMode;
        public bool IsFreezingMode
        {
            get { return isFreezingMode; }
            set
            {
                isFreezingMode = value;
                if (IsFreezingMode == false)
                {
                    if (!IsFromSchedule)
                    {
                        buttonFreeze.Text = Freeze;
                        buttonFreeze.BackAndMouseHoverColor = ColorActiveMode;
                    }
                    labelSessiosOrDaysDetails.ForeColor = Color.Green;
                    labelDueDateDetails.ForeColor = Color.Black;
                    panelColor.BackColor = ColorActiveMode;
                }
                else
                {
                    if (!IsFromSchedule)
                    {
                        buttonFreeze.Text = "Reacticate";
                        buttonFreeze.BackAndMouseHoverColor = ColorFreezing;
                    }
                    labelSessiosOrDaysDetails.ForeColor = ColorFreezing;
                    labelDueDateDetails.ForeColor = ColorFreezing;
                    panelColor.BackColor = ColorFreezing;

                }
            }
        }


        public bool IsInDebtForSessionLeft { get; set; }//hayde w li tahta same meaning bas ha mnestaamla kermel ma ysir fi crashes tahet

        private bool isInDebt;
        public bool IsInDebt
        {
            get { return isInDebt; }
            set
            {
                isInDebt = value;

                if (IsInDebt)
                {
                    if (!IsFromSchedule)
                    {
                        buttonRemove.Text = "Pay&&Remove";
                    }
                }
                else
                {
                    if (!IsFromSchedule)
                    {
                        buttonRemove.Text = "Remove";
                    }

                }
                if (IsInDebt)
                {
                    if (!IsFromSchedule)
                    {
                        buttonRenew.Text = "Pay&&Renew";
                    }
                }
                else
                {
                    if (!IsFromSchedule)
                    {
                        buttonRenew.Text = "Renew";
                    }
                }

            }
        }

        Label labelDueDate;
        Label labelDueDateDetails;
        bool IsFromSchedule;
        public DataRow DesiredRow;//this row, huwwe men el table client balance, and it s going to be used bel sechdule
        public UCBundlePackage(bool isFromSchedule, DataRow DesiredRow)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            IsFromSchedule = isFromSchedule;
            if (!IsFromSchedule)
            {
                CreateButtons();
            }
            else
            {
                CreateBalanceLabels();
                this.Padding = new Padding(0);
                TLPglobal.ColumnCount -= 1;
              

                TLPglobal.RowStyles[1].Height = 0;//ID ma badna yeha
                TLPglobal.RowStyles[2].Height = 30;
                TLPglobal.RowStyles[3].Height = 30;
                TLPglobal.RowStyles[4].Height = 20;

                //Eza badde bayyin el balace
                //TLPglobal.RowCount += 1;
                //TLPglobal.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
                //TLPglobal.Controls.Add(labelBalance, 0, 5);
                //TLPglobal.Controls.Add(labelBalanceDetails, 1, 5);

                this.Width = Convert.ToInt16(TLPglobal.ColumnStyles[0].Width + TLPglobal.ColumnStyles[1].Width);
                this.Height = this.Height - 20;
            }

            CreateUCPackage(DesiredRow);
        }

        void CreateBalanceLabels()
        {
            labelBalance = new Label();
            labelBalance.Text = "Balance:";
            labelBalance.TextAlign = ContentAlignment.MiddleLeft;
            labelBalance.ForeColor = Color.FromArgb(64, 64, 64);
            labelBalance.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            labelBalance.Dock = DockStyle.Fill;
            labelBalance.AutoSize = false;

            labelBalanceDetails = new Label();
            labelBalanceDetails.TextAlign = ContentAlignment.MiddleLeft;
            labelBalanceDetails.ForeColor = Color.Black;
            labelBalanceDetails.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelBalanceDetails.Dock = DockStyle.Fill;
            labelBalanceDetails.AutoSize = false;

        }
        void CreateButtons()
        {
            buttonReduceSession = new CustomButton();
            buttonReduceSession.Text ="Reduce";
            buttonReduceSession.Size = new Size(122, 34);
            buttonReduceSession.Margin = new Padding(0,0,5,0);
            buttonReduceSession.BackAndMouseHoverColor = Color.FromArgb(109, 122, 224);
            buttonReduceSession.Anchor = AnchorStyles.None;
            buttonReduceSession.Click += ButtonReduceSession_Click;
            buttonReduceSession.MouseMove += Control_MouseMove;
            buttonReduceSession.MouseLeave += Control_MouseLeave;

            buttonFreeze = new CustomButton();
            buttonFreeze.Size = new Size(122, 34);
            buttonFreeze.Margin = new Padding(0, 0, 5, 0);
            buttonFreeze.BackAndMouseHoverColor = Color.FromArgb(109, 122, 224);
            buttonFreeze.Anchor = AnchorStyles.None;
            buttonFreeze.Click += ButtonFreeze_Click;
            buttonFreeze.MouseMove += Control_MouseMove;
            buttonFreeze.MouseLeave += Control_MouseLeave;

            buttonRemove = new CustomButton();
            buttonRemove.Size = new Size(122, 34);
            buttonRemove.Margin = new Padding(0, 0, 5, 0);
            buttonRemove.BackAndMouseHoverColor = Color.Red;
            buttonRemove.FlatAppearance.MouseOverBackColor= Color.FromArgb(255 - 30, 0, 0);
           buttonRemove.FlatAppearance.MouseDownBackColor= Color.FromArgb(255 - 90, 0, 0);
            buttonRemove.Anchor = AnchorStyles.None;
            buttonRemove.Click += ButtonRemove_Click;
            buttonRemove.MouseMove += Control_MouseMove;
            buttonRemove.MouseLeave += Control_MouseLeave;

            buttonRenew = new CustomButton();
            buttonRenew.Size = new Size(122, 34);
            buttonRenew.Margin = new Padding(0, 0, 5, 0);
            buttonRenew.BackAndMouseHoverColor = Color.FromArgb(109, 122, 224);
            buttonRenew.Anchor = AnchorStyles.None;
            buttonRenew.Click += ButtonRenew_Click;
            buttonRenew.MouseMove += Control_MouseMove;
            buttonRenew.MouseLeave += Control_MouseLeave;
        }

        public void CreateUCPackage(DataRow dr)
        {
            DesiredRow = dr;
            this.BundleId = Convert.ToInt16(dr["bundle_id"]);
            this.DesiredClientBalanceId = Convert.ToInt16(dr["client_balance_id"]);

            
            this.BundleDescription = dr["Description"].ToString();//Decription = bundle Name


            if (dr["due_date"] != DBNull.Value && dr["is_freezed"] != DBNull.Value)
            {
                this.BundleType = ClassBundles.enumBundle.Days;
                this.DueDate = (DateTime)dr["due_date"];

                if ((bool)dr["is_freezed"] == true)
                {
                    this.IsFreezingMode = true;
                    this.SessionDaysLeft = Convert.ToInt16(dr["session_left_days"]);
                }
                else
                {
                    this.IsFreezingMode = false;
                    this.SessionDaysLeft = RandomFunctions.GetDaysDifference(DateTime.Now, (DateTime)dr["due_date"]);//tene wahde - awwal wahde
                }
                //hay ejbare tahta cz el desactivate mode eenda priority abel el freezing mode

            }
            else
            {
                this.BundleType = ClassBundles.enumBundle.Sessions;
                this.DueDate = null;
                this.SessionDaysLeft = Convert.ToInt16(dr["session_left_days"]);
            }


            if (!IsFromSchedule)
            {


                if ((double)dr["balance"] != 0)
                {
                    this.IsInDebt = true;
                }
                else
                {
                    this.IsInDebt = false;
                }
            }
            else
            {

                string balance = dr["balance"].ToString();           
                if (balance.Contains("-"))
                {
                    labelBalanceDetails.ForeColor = Color.Red;
                    this.IsInDebt = true;
                }
                else
                {
                    labelBalanceDetails.ForeColor = Color.Black;
                    this.IsInDebt = false;
                }
                labelBalanceDetails.Text = Program.SetBalanceFormat(balance); 

            }



          
            TLPglobal.MouseLeave += Control_MouseLeave;
            TLPglobal.MouseMove += Control_MouseMove;      
             TLPglobal.MouseClick += Control_MouseClick;
            if (IsFromSchedule)
            {        
                TLPglobal.Cursor = Cursors.Hand;         
            }
            foreach (Control control in TLPglobal.Controls)
            {
                if (!(control is CustomButton))
                {
                    control.MouseClick += Control_MouseClick;
                }

                control.MouseMove += Control_MouseMove;
                control.MouseLeave += Control_MouseLeave;
                if (IsFromSchedule)
                {
                  
                    control.Cursor = Cursors.Hand;
                }

            }

        }

        public event EventHandler UCMouseClick;
        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            UCMouseClick?.Invoke(this, e);
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            TLPglobal.BackColor = ColorDedault;

        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            TLPglobal.BackColor = ColorMouseOver;
        }

        public void BundleDaysMode()
        {

            if (labelDueDate == null && labelDueDateDetails == null)
            {
                // Create first label
                labelDueDate = new Label();
                labelDueDate.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold);
                labelDueDate.ForeColor = Color.FromArgb(64, 64, 64);
                labelDueDate.TextAlign = ContentAlignment.MiddleLeft;
                labelDueDate.Text = "Due Date:";
                labelDueDate.BackColor = Color.Transparent;
                labelDueDate.Dock = DockStyle.Fill;

                // Create second label
                labelDueDateDetails = new Label();
                labelDueDateDetails.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
                labelDueDateDetails.ForeColor = Color.Black;
                labelDueDateDetails.TextAlign = ContentAlignment.MiddleLeft;
                labelDueDateDetails.BackColor = Color.Transparent;
                labelDueDateDetails.Dock = DockStyle.Fill;


                TLPglobal.Controls.Add(labelDueDate, 0, 3);
                TLPglobal.Controls.Add(labelDueDateDetails, 1, 3);

                if (!IsFromSchedule)
                {
                    TLPglobal.SetRowSpan(labelBundle, 1);
                    TLPglobal.SetRowSpan(labelBundleDescription, 1);

                }
                else
                {

                    TLPglobal.SetRow(labelSessiosOrDays, 4);
                    TLPglobal.SetRow(labelSessiosOrDaysDetails, 4);
                    TLPglobal.SetRowSpan(labelSessiosOrDays, 1);
                    TLPglobal.SetRowSpan(labelSessiosOrDaysDetails, 1);
                }
            }

            labelSessiosOrDays.Text = "Days Left:";

            if (!IsFromSchedule)
            {
                TLPglobal.Controls.Add(buttonFreeze, 2, 2);
                TLPglobal.SetRowSpan(buttonFreeze, 2);
            }

        }
        public void BundleSessionsMode()
        {
            if (!IsFromSchedule)
            {
                TLPglobal.Controls.Add(buttonReduceSession, 2, 2);
                TLPglobal.SetRowSpan(buttonReduceSession, 2);
            }
            ///
            if (!IsFromSchedule)
            {
                TLPglobal.SetRowSpan(labelBundle, 2);
                TLPglobal.SetRowSpan(labelBundleDescription, 2);
            }
            else
            {
                TLPglobal.SetRow(labelSessiosOrDays, 3);
                TLPglobal.SetRow(labelSessiosOrDaysDetails, 3);
                TLPglobal.SetRowSpan(labelSessiosOrDays, 2);
                TLPglobal.SetRowSpan(labelSessiosOrDaysDetails, 2);

            }
            labelSessiosOrDays.Text = "Sessions Left:";
        }


        public void ActiveModeOn()
        {
            IsDesactiveMode = false;
            IsActiveMode = true;

            //color design 
            if (!IsFreezingMode)//cz el freezing mode eenda its colors
            {
                labelSessiosOrDaysDetails.ForeColor = Color.Green;
                panelColor.BackColor = ColorActiveMode;

            }

            if (!IsFromSchedule)
            {
                if (TLPglobal.Controls.Contains(buttonRenew) && TLPglobal.Controls.Contains(buttonRemove))
                {
                    TLPglobal.Controls.Remove(buttonRenew);
                    TLPglobal.Controls.Remove(buttonRemove);

                }


                if (BundleType == ClassBundles.enumBundle.Sessions)
                {
                    if (!TLPglobal.Controls.Contains(buttonReduceSession))
                    {
                        TLPglobal.Controls.Add(buttonReduceSession, 2, 2);
                        TLPglobal.SetRowSpan(buttonReduceSession, 2);
                    }

                }
                else
                {
                    if (!TLPglobal.Controls.Contains(buttonFreeze))
                    {
                        TLPglobal.Controls.Add(buttonFreeze, 2, 2);
                        TLPglobal.SetRowSpan(buttonFreeze, 2);
                    }
                }
            }
        }
        public void DesactiveModeOn()
        {
            IsDesactiveMode = true;
            IsActiveMode = false;
            if (!IsFromSchedule)
            {
                if (TLPglobal.Controls.Contains(buttonReduceSession))
                {
                    TLPglobal.Controls.Remove(buttonReduceSession);
                }
                else if (TLPglobal.Controls.Contains(buttonFreeze))
                {
                    TLPglobal.Controls.Remove(buttonFreeze);
                }
            }
            labelSessiosOrDaysDetails.ForeColor = Color.Red;
            panelColor.BackColor = ColorDesActiveMode;
            //

            if (!IsFromSchedule)
            {
                if (IsInDebt)
                {
                    buttonRemove.Text = "PayToRemove";
                }
                else
                {
                    buttonRemove.Text = "Remove";
                }
                if (IsInDebt)
                {
                    buttonRenew.Text = "PayToRenew";
                }
                else
                {
                    buttonRenew.Text = "Renew";
                }


                TLPglobal.Controls.Add(buttonRenew, 2, 2);
                TLPglobal.Controls.Add(buttonRemove, 2, 3);
            }
            //
            if (isFreezingMode == true)//we re Reactivating the package, hayde will be use only, lamma naamil edit el package, w nhattello days left 0, so eza ken eendo freeze, men shello el freeze
            {
                ReActivateMode();
            }

        }


        //but we still need to see eza aale masare aw abaeed before using this buttons
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (IsInDebt == false)//if balance=0 & session=0
            {
                RemovePackage();
            }
            else
            {
                PayIfInDebt();
            }

        }//try catch
        public void RemovePackage()
        {

            //Sql
            ClassClientBalance.UpdateIsexpiredClientBalanceRemoveUC(DesiredClientBalanceId, true);//true because the bundle has expired

            //Design
            this.Dispose();
            DataRow foundRow = ParentFormClientMan.dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);
            foundRow["is_expired"] = true;
            ParentFormClientMan.ResortOriginalDataTableAndSetDatasource();
            ParentFormClientMan.FormatDatagridviewDesign();
            ParentFormClientMan.dataGridViewBalance.FirstDisplayedScrollingRowIndex = 0;
            ParentFormClientMan.CheckAndSetNoBundleLabel();



        }//try catch


        //but we still need to see eza aale masare aw abaeed before using this buttons
        private void ButtonRenew_Click(object sender, EventArgs e)
        {
            if (IsInDebt == false)//if balance=0 & session=0
            {
                RenewPackage();

            }
            else
            {
                PayIfInDebt();
            }
        }//try catch
        public void RenewPackage()
        {

            //sql
            int lastClientId = ParentFormClientMan.Client.ClientId;
            if (BundleId != null)
            {
                ClassClientBalance.InsertToClientBalance(lastClientId, (int)BundleId, BundleType.ToString());
            }

            //select the last inserted row 
            DataTable dtRewedPackage = ClassClientBalance.GetClientBalanceSpecificOrLastInsert(null);
            DataRow InsertedRow = dtRewedPackage.Rows[0];//0 since it s only one row retrieve which is the new one                     


            ClassClientBalance.UpdateIsexpiredClientBalanceRemoveUC(DesiredClientBalanceId, true);//true because the bundle has expired
                                                                                                  //backoffice

            ClassAppointment.SwapClientBalanceIdOnRenewPackage(DesiredClientBalanceId, (int)InsertedRow["client_balance_id"]);


            ClassBackOffice backOffice = new ClassBackOffice(ParentFormClientMan.Client.ClientId, ActionsEnum.Purchases, LOGIN.Employee.EmployeeId, (int)InsertedRow["client_balance_id"], null, null,null, null, null, DateTime.Now);
            backOffice.CreateActionDetails(InsertedRow);
            backOffice.InsertToArchiveSQL();


            //design

            // datagrid of profile     
            DataRow NewRow = ParentFormClientMan.dtClientBalanceOriginal.NewRow();
            NewRow.ItemArray = InsertedRow.ItemArray; // Copy the data from InsertedRow to NewRow
            ParentFormClientMan.dtClientBalanceOriginal.Rows.Add(NewRow);
            //ma hattayna hone condition eza ken el new package fakeid==1 shu mnaamil cz hone renew yaane akid ma ha ykun el fakeid==1
            NewRow["AutoIncrementColumn"] = Convert.ToInt32(ParentFormClientMan.dtClientBalanceOriginal.Compute("MAX(AutoIncrementColumn)", "")) + 1;

            //set is expiried for the old package
            DataRow RowOldPackage = ParentFormClientMan.dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);
            RowOldPackage["is_expired"] = true;

            //refresh parent form
            ParentFormClientMan.ResortOriginalDataTableAndSetDatasource();
            ParentFormClientMan.FormatDatagridviewDesign();
            ParentFormClientMan.dataGridViewBalance.FirstDisplayedScrollingRowIndex = 0;
            ParentFormClientMan.CalculatingTotalBalancesDesignAndSql(true);


            //Setting the new values of teh uc for the new package
            DesiredClientBalanceId = Convert.ToInt16(NewRow["client_balance_id"]);
            FakeId = Convert.ToInt16(NewRow["AutoIncrementColumn"]);//mafina nekhud this info gher men el orgnal table
            BundleDescription = NewRow["Description"].ToString();
            if (NewRow["due_date"] != DBNull.Value)
            {
                BundleType = ClassBundles.enumBundle.Days;
                DueDate = (DateTime)NewRow["due_date"];
                isFreezingMode = false;

            }
            else
            {
                BundleType = ClassBundles.enumBundle.Sessions;
                DueDate = null;
            }

            SessionDaysLeft = Convert.ToInt16(NewRow["session_left_days"]);
            if ((double)NewRow["balance"] != 0)
            {
                IsInDebt = true;
            }
            else
            {
                IsInDebt = false;
            }

            if (BundleId != null)
            {
                ParentFormClientMan.UCTokenServices.Detail = Convert.ToString(Convert.ToInt16(ParentFormClientMan.UCTokenServices.Detail) + 1);
            }

        }//try catch


        //only for sessions bundles
        private void ButtonReduceSession_Click(object sender, EventArgs e)
        {

            if (SessionDaysLeft > 0)
            {
                if (ParentFormClientMan.Client.LastVisit != null)
                {
                    DateTime LastVisi = (DateTime)ParentFormClientMan.Client.LastVisit;
                    if (LastVisi.Day == DateTime.Today.Day && LastVisi.Month == DateTime.Today.Month && LastVisi.Year == DateTime.Today.Year)
                    {
                        DialogResult dialogResult = CustomMessageBox.Show("Last client's session was today, are you sure u want to reduce a session", CustomMessageBox.Type.YesNoWarning);
                        if (dialogResult == DialogResult.Yes)
                        {

                            ReduceSession();
                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                    }
                    else
                    {
                        ReduceSession();
                    }
                }
                else
                {
                    ReduceSession();
                }

            }

        }//try catch      
        public void ReduceSession()
        {
            //Sql update
            DateTime date = DateTime.Now;
            bool IfLastVisitDateChanged= ClassClientBalance.ReduceSessionFromPackageOfSessions(ParentFormClientMan.Client.ClientId, DesiredClientBalanceId, SessionDaysLeft - 1,null, date, date);

            //design
            SessionDaysLeft--;
            DataRow rowToEdit = ParentFormClientMan.dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);
            rowToEdit["session_left_days"] = sessionOrDaysLeft;
          
            if (IfLastVisitDateChanged)
            {
                ParentFormClientMan.UCLastVisit.Detail = RandomFunctions.SetDateFormat(date.ToString());
                ParentFormClientMan.Client.LastVisit = date;
            }
            ParentFormClientMan.Client.TotalAttendance++;
            ParentFormClientMan.UCTotalAttendance.Detail = Convert.ToString(ParentFormClientMan.Client.TotalAttendance);
        }//try catch


        private void ButtonFreeze_Click(object sender, EventArgs e)
        {
            if (IsFreezingMode == true)//reactivate mode
            {
                ReActivateMode();

            }
            else//we re freezing the ackage
            {
                ClassClientBalance.UpdateClientBalanceOnFreezingDays(DesiredClientBalanceId, sessionOrDaysLeft, null);
                //design
                IsFreezingMode = true;
                DataRow rowToEdit = ParentFormClientMan.dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);
                rowToEdit["is_freezed"] = IsFreezingMode;
            }
        }//try catch
        void ReActivateMode()
        {
            DateTime newDueDate = DateTime.Now.AddDays(sessionOrDaysLeft);
            ClassClientBalance.UpdateClientBalanceOnFreezingDays(DesiredClientBalanceId, sessionOrDaysLeft, newDueDate);

            //Design
            this.DueDate = newDueDate;
            IsFreezingMode = false;
            DataRow rowToEdit = ParentFormClientMan.dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);
            rowToEdit["is_freezed"] = IsFreezingMode;
            rowToEdit["due_date"] = DueDate;

        }
        public void PayIfInDebt()
        {
            DataRow foundRow = ParentFormClientMan.dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);
            double EntetityAmount = (double)foundRow["balance"];


            Payment payment = new Payment(ParentFormClientMan.Client, ParentFormClientMan.RetrievingSpecificRowsInDt(false, DesiredClientBalanceId), ParentFormClientMan,false);
            payment.ClientManagementProfileParentForm = this.ParentFormClientMan;
            payment.Show();
        }

      

    }
}
