using CustomizedTools;
using GlobalFunctions;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace MKproject.Management
{
    public partial class UCBundlePackage : UserControl
    {
        Currency Currency = new Currency();
        Button buttonRemove;
        Button buttonRenew;
        Button buttonReduceSession;
        Button buttonFreeze;
        //Button buttonReduceSession = new Button();
        bool IsActiveMode = false;
        bool IsDesactiveMode = false;

        Color ColorActiveMode = Color.FromArgb(128, 128, 255);
        Color ColorDesActiveMode = Color.Red;
        Color ColorFreezing = Color.FromArgb(3, 177, 241);

        string Freeze = "Freeze", Reduce = "Reduce";

        public ClientManagementProfile ParentFormClientMan { get; set; }
        public int? BundleId { get; set; }// in order when we want to renew njib el original information of the bundle


        private int id;//the real id of the bundle in the database and only used if it was a bundle,if product: Null
        public int Id
        {
            get { return id; }
            set
            {
                id = value;

            }
        }
        private int fakeid;
        public int FakeId
        {
            get { return fakeid; }
            set
            {
                fakeid = value;
                labelID.Text = fakeid.ToString();
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


        private ClassBundles.bundle bundleType;
        public ClassBundles.bundle BundleType
        {
            get { return bundleType; }
            set
            {
                bundleType = value;
                if (bundleType ==ClassBundles.bundle.Sessions)
                {

                    BundleSessionsMode();
                }
                else if (bundleType == ClassBundles.bundle.Days)
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
                    labelDueDateDetails.Text = RandomFunctions.SetFullDateFormat(dueDate.ToString());
                }

            }
        }


        private int sessionDaysLeft;
        public int SessionDaysLeft
        {
            get { return sessionDaysLeft; }
            set
            {
                sessionDaysLeft = value;
                labelSessiosOrDaysDetails.Text = Convert.ToString(sessionDaysLeft);
                if (bundleType ==  ClassBundles.bundle.Sessions)
                {
                    if (sessionDaysLeft == 0)
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
                else if (bundleType == ClassBundles.bundle.Days)
                {
                    if (sessionDaysLeft < 0)
                    {
                        labelSessiosOrDaysDetails.Text = "No Days Left";
                        if (!IsDesactiveMode)
                        {

                            DesactiveModeOn();
                        }
                    }
                    else
                    {
                        if (sessionDaysLeft == 0)
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

                    buttonFreeze.Text = Freeze;
                    buttonFreeze.BackColor = ColorActiveMode;
                    labelSessiosOrDaysDetails.ForeColor = Color.Green;
                    labelDueDateDetails.ForeColor = Color.Black;
                    panelColor.BackColor = ColorActiveMode;
                }
                else
                {

                    buttonFreeze.Text = "Reacticate";
                    buttonFreeze.BackColor = ColorFreezing;
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
                    buttonRemove.Text = "Pay&&Remove";
                }
                else
                {

                    buttonRemove.Text = "Remove";

                }
                if (IsInDebt)
                {
                    buttonRenew.Text = "Pay&&Renew";
                }
                else
                {

                    buttonRenew.Text = "Renew";

                }

            }
        }

        Label labelDueDate;
        Label labelDueDateDetails;
        public UCBundlePackage()
        {
            InitializeComponent();
            CreateButtons();
        }
       
        
        void CreateButtons()
        {
            buttonReduceSession = new Button();
            buttonReduceSession.Text = Reduce;
            buttonReduceSession.Size = new Size(122, 34);
            buttonReduceSession.Margin = new Padding(5);
            buttonReduceSession.BackColor = Color.FromArgb(109, 122, 224);
            buttonReduceSession.ForeColor = Color.White;
            buttonReduceSession.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            buttonReduceSession.Anchor = AnchorStyles.None;
            buttonReduceSession.FlatStyle = FlatStyle.Flat;
            buttonReduceSession.Cursor = Cursors.Hand;
            buttonReduceSession.Click += ButtonReduceSession_Click;

            buttonFreeze = new Button();
            buttonFreeze.Size = new Size(122, 34);
            buttonFreeze.Margin = new Padding(5);
            buttonFreeze.BackColor = Color.FromArgb(109, 122, 224);
            buttonFreeze.ForeColor = Color.White;
            buttonFreeze.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            buttonFreeze.Anchor = AnchorStyles.None;
            buttonFreeze.FlatStyle = FlatStyle.Flat;
            buttonFreeze.Cursor = Cursors.Hand;
            buttonFreeze.Click += ButtonFreeze_Click;

            buttonRemove = new Button();
            buttonRemove.Anchor = AnchorStyles.Top;
            buttonRemove.Size = new Size(128, 34);
            buttonRemove.Margin = new Padding(5);
            buttonRemove.BackColor = Color.Red;
            buttonRemove.ForeColor = Color.White;
            buttonRemove.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            buttonRemove.Anchor = AnchorStyles.None;
            buttonRemove.FlatStyle = FlatStyle.Flat;
            buttonRemove.Cursor = Cursors.Hand;
            buttonRemove.Click += ButtonRemove_Click;

            buttonRenew = new Button();
            buttonRenew.Anchor = AnchorStyles.Bottom;
            buttonRenew.Size = new Size(126, 34);
            buttonRenew.Margin = new Padding(5);
            buttonRenew.BackColor = Color.FromArgb(109, 122, 224);
            buttonRenew.ForeColor = Color.White;
            buttonRenew.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            buttonRenew.Anchor = AnchorStyles.None;
            buttonRenew.FlatStyle = FlatStyle.Flat;
            buttonRenew.Cursor = Cursors.Hand;
            buttonRenew.Click += ButtonRenew_Click;
        }
        public void CreateUCPackage(DataRow dr)
        {


            this.BundleId = Convert.ToInt16(dr["bundle_id"]);
            this.Id = Convert.ToInt16(dr["ID"]);
            this.BundleDescription = dr["Description"].ToString();

            if (dr["due_date"] != DBNull.Value && dr["is_freezed"] != DBNull.Value)
            {
                this.BundleType = ClassBundles.bundle.Days;
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
                this.BundleType =  ClassBundles.bundle.Sessions;
                this.DueDate = null;
                this.SessionDaysLeft = Convert.ToInt16(dr["session_left_days"]);
            }

            if ((double)dr["balance"] != 0)
            {
                this.IsInDebt = true;
            }
            else
            {
                this.IsInDebt = false;
            }
        }


        public void BundleDaysMode()
        {

            if (labelDueDate == null && labelDueDateDetails == null)
            {
                // Create first label
                labelDueDate = new Label();
                labelDueDate.Font = new Font("Segoe UI Semibold", 14f, FontStyle.Bold);
                labelDueDate.ForeColor = Color.FromArgb(64, 64, 64);
                labelDueDate.TextAlign = ContentAlignment.MiddleLeft;
                labelDueDate.Text = "Due Date";
                labelDueDate.BackColor = Color.Transparent;
                labelDueDate.Dock = DockStyle.Fill;

                // Create second label
                labelDueDateDetails = new Label();
                labelDueDateDetails.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
                labelDueDateDetails.ForeColor = Color.FromArgb(64, 64, 64);
                labelDueDateDetails.TextAlign = ContentAlignment.MiddleLeft;
                labelDueDateDetails.BackColor = Color.Transparent;
                labelDueDateDetails.Dock = DockStyle.Fill;

                TLPglobal.SetRowSpan(labelBundle, 1);
                TLPglobal.SetRowSpan(labelBundleDescription, 1);
                TLPglobal.Controls.Add(labelDueDate, 0, 3);
                TLPglobal.Controls.Add(labelDueDateDetails, 1, 3);
            }

            labelSessiosOrDays.Text = "Days Left:";


            TLPglobal.Controls.Add(buttonFreeze, 2, 2);
            TLPglobal.SetRowSpan(buttonFreeze, 2);

        }      
        public void BundleSessionsMode()
        {

            TLPglobal.Controls.Add(buttonReduceSession, 2, 2);
            TLPglobal.SetRowSpan(buttonReduceSession, 2);
            ///
            TLPglobal.SetRowSpan(labelBundle, 2);
            TLPglobal.SetRowSpan(labelBundleDescription, 2);
            labelSessiosOrDays.Text = "Sessions Left:";



        }
     
        
        public void ActiveModeOn()
        {
            IsDesactiveMode = false;
            IsActiveMode = true;

            if (TLPglobal.Controls.Contains(buttonRenew) && TLPglobal.Controls.Contains(buttonRemove))
            {
                TLPglobal.Controls.Remove(buttonRenew);
                TLPglobal.Controls.Remove(buttonRemove);

            }
            //color design 
            if (!IsFreezingMode)//cz el freezing mode eenda its colors
            {
                labelSessiosOrDaysDetails.ForeColor = Color.Green;
                panelColor.BackColor = ColorActiveMode;


            }

            if (BundleType == ClassBundles.bundle.Sessions)
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
        public void DesactiveModeOn()
        {
            IsDesactiveMode = true;
            IsActiveMode = false;
            if (TLPglobal.Controls.Contains(buttonReduceSession))
            {
                TLPglobal.Controls.Remove(buttonReduceSession);

            }
            else if (TLPglobal.Controls.Contains(buttonFreeze))
            {

                TLPglobal.Controls.Remove(buttonFreeze);

            }
            labelSessiosOrDaysDetails.ForeColor = Color.Red;
            panelColor.BackColor = ColorDesActiveMode;
            //

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
            ProjectToSQL.UpdateIsexpiredClientBalanceRemoveUC(Id, true);//true because the bundle has expired

            //Design
            this.Dispose();
            DataRow foundRow = ParentFormClientMan.dtClientBalanceOriginal.Rows.Find(Id);
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
            int lastClientId = (int)ParentFormClientMan.Client.ClientId;
            if (BundleId != null)
            {
                ProjectToSQL.InsertToClientBalance(lastClientId, (int)BundleId, BundleType.ToString());
            }

            //select the last inserted row 
            DataTable dtRewedPackage = SQLToProject.GetClientBalanceSpecificOrLastInsert(null);
            ParentFormClientMan.FormatOriginalDt(dtRewedPackage);
            DataRow InsertedRow = dtRewedPackage.Rows[0];//0 since it s only one row retrieve which is the new one                     


            ProjectToSQL.UpdateIsexpiredClientBalanceRemoveUC(Id, true);//true because the bundle has expired
                                                                                                    //backoffice
            string action;
            if (BundleType == ClassBundles.bundle.Solo)
            {
                action = "Purchased a " + BundleDescription+".";
            }
            else
            {
                action = "Purchased the " + BundleDescription + " Package.";
            }
            ClassBackOffice backOffice = new ClassBackOffice((int)ParentFormClientMan.Client.ClientId, action, ActionsEnum.Purchases, LOGIN.Employee.EmployeeId, (int)InsertedRow["ID"], null, null, null, null, DateTime.Now);
            backOffice.InsertToArchiveSQL();
            

            //design

            // datagrid of profile     
            DataRow NewRow = ParentFormClientMan.dtClientBalanceOriginal.NewRow();
            NewRow.ItemArray = InsertedRow.ItemArray; // Copy the data from InsertedRow to NewRow
            ParentFormClientMan.dtClientBalanceOriginal.Rows.Add(NewRow);
            //ma hattayna hone condition eza ken el new package fakeid==1 shu mnaamil cz hone renew yaane akid ma ha ykun el fakeid==1
            NewRow["AutoIncrementColumn"] = Convert.ToInt32(ParentFormClientMan.dtClientBalanceOriginal.Compute("MAX(AutoIncrementColumn)", "")) + 1;

            //set is expiried for the old package
            DataRow RowOldPackage = ParentFormClientMan.dtClientBalanceOriginal.Rows.Find(Id);
            RowOldPackage["is_expired"] = true;

            //refresh parent form
            ParentFormClientMan.ResortOriginalDataTableAndSetDatasource();
            ParentFormClientMan.FormatDatagridviewDesign();
            ParentFormClientMan.dataGridViewBalance.FirstDisplayedScrollingRowIndex = 0;
            ParentFormClientMan.CalculatingTotalBalances(true);
          

            //Setting the new values of teh uc for the new package
            Id = Convert.ToInt16(NewRow["ID"]);
            FakeId = Convert.ToInt16(NewRow["AutoIncrementColumn"]);//mafina nekhud this info gher men el orgnal table
            BundleDescription = NewRow["Description"].ToString();
            if (NewRow["due_date"] != DBNull.Value)
            {
                BundleType =  ClassBundles.bundle.Days;
                DueDate = (DateTime)NewRow["due_date"];
                isFreezingMode = false;

            }
            else
            {
                BundleType =ClassBundles.bundle.Sessions;
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
            int ID = Id;
            int UpdatedSessionLeft = SessionDaysLeft-1;
            DateTime Date = DateTime.Now;
            ProjectToSQL.UpdateClientBalanceOnEditingSessions(ID, UpdatedSessionLeft, null, null, false);//lieanno this function onlykermel el package sessiosns                   
            ClassClient.UpdateClientCheckInSQL((int)ParentFormClientMan.Client.ClientId, Date);
            ProjectToSQL.InsertToClientAttendance((int)ParentFormClientMan.Client.ClientId);
            ClassBackOffice backOffice = new ClassBackOffice((int)ParentFormClientMan.Client.ClientId, "Completed a session.", ActionsEnum.SessionDone, LOGIN.Employee.EmployeeId, Id, null, SQLToProject.GetLAstInsertedAttendance(), null, null, Date);
            backOffice.InsertToArchiveSQL();

            //design
            SessionDaysLeft--;
            DataRow rowToEdit = ParentFormClientMan.dtClientBalanceOriginal.Rows.Find(Id);
            rowToEdit["session_left_days"] = sessionDaysLeft;

            ParentFormClientMan.UCLastVisit.Detail = RandomFunctions.SetDateFormat(Date.ToString());
            ParentFormClientMan.Client.TotalAttendance++;
            ParentFormClientMan.Client.LastVisit = Date;
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
                ProjectToSQL.UpdateClientBalanceOnFreezingDays(Id, sessionDaysLeft, null);
                //design
                IsFreezingMode = true;
                DataRow rowToEdit = ParentFormClientMan.dtClientBalanceOriginal.Rows.Find(Id);
                rowToEdit["is_freezed"] = IsFreezingMode;
            }
        }//try catch
        void ReActivateMode()
        {
            DateTime newDueDate = DateTime.Now.AddDays(sessionDaysLeft);
            ProjectToSQL.UpdateClientBalanceOnFreezingDays(Id, sessionDaysLeft, newDueDate);
         
            //Design
            this.DueDate = newDueDate;
            IsFreezingMode = false;
            DataRow rowToEdit = ParentFormClientMan.dtClientBalanceOriginal.Rows.Find(Id);
            rowToEdit["is_freezed"] = IsFreezingMode;

        }
        public void PayIfInDebt()
        {
            DataRow foundRow = ParentFormClientMan.dtClientBalanceOriginal.Rows.Find(Id);
            double EntetityAmount = (double)foundRow["balance"];


            Payment payment = new Payment((int)ParentFormClientMan.Client.ClientId, EntetityAmount, ParentFormClientMan.RetrievingSpecificRowsInDt(false, Id), ParentFormClientMan);
            payment.ClientManagementProfileParentForm = this.ParentFormClientMan;
            payment.Show();
        }

       

    }
}
