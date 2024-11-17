using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GlobalFunctions;
using CustomizedTools;
using Microsoft.VisualBasic;

namespace MKproject.Management
{
    public partial class Payment : Form
    {
        DataTable OriginalDesiredClientBalanceRowsdt;
        DataRow SelectedClientBalanceRow;//it will be != null if: eende one row only, or eende kaza row w mna2a wahad, lamma tkun null, means: eende kaza row  mesh mnaea wala wahad


        public ClientManagementProfile ClientManagementProfileParentForm { get; set; }
        bool IsFromSchedule;
        DateTime DesiredDateOfPayment;
        public ClassClientCustom DesiredClient;
        private double initialbalance;
        private int OldSessionOrDaysNumber;
        private DateTime OldStartDate;//used only for packge of days

        DateTime Date;//kermel datetime.now el kell yekheda



        UCSlideButton ucSlideButtonPayOrEdit;
        UCPayments UCPay;
        UCNumberButt UCNOSessionOrDays;

        Color ColorBackTExtbOxEditMode = Color.FromArgb(235, 235, 235);

        public bool IsPayementOrEditMode { get; set; }


        //DataTable here could be only one row or many rows if pay total
        public Payment(ClassClientCustom desiredClient, DataTable desiredClientBalanceRowsdt, ClientManagementProfile clientManagementProfile, bool isFromSchedule, DateTime desiredDatePfPayment)
        {
            InitializeComponent();
            this.Opacity = 0;
            this.TopMost = true;

            IsFromSchedule = isFromSchedule;
            DesiredDateOfPayment= desiredDatePfPayment;
            ClientManagementProfileParentForm = clientManagementProfile;
            OriginalDesiredClientBalanceRowsdt = desiredClientBalanceRowsdt;
            DesiredClient = desiredClient;


            if (OriginalDesiredClientBalanceRowsdt.Rows.Count == 1)
            {
                SelectedClientBalanceRow = OriginalDesiredClientBalanceRowsdt.Rows[0];
                dataGridViewBalance.IsRowColorChangeonMouseMove = false;
                dataGridViewBalance.IsSelectRow = false;
            }
            else if (OriginalDesiredClientBalanceRowsdt.Rows.Count > 1)
            {
                dataGridViewBalance.IsRowColorChangeonMouseMove = true;
                dataGridViewBalance.IsSelectRow = true;
                dataGridViewBalance.CellClick += dataGridViewBalance_CellClick;

            }
            CalculatingInitialBalance();//ejbare ha tahet el block el foeane
            LoadForm();
        }



        void CalculatingInitialBalance()
        {
            if (SelectedClientBalanceRow == null)
            {
                (initialbalance, _, _) = ClassClientBalance.CalculatingClientBalance(OriginalDesiredClientBalanceRowsdt);
            }
            else
            {
                initialbalance = Convert.ToDouble(SelectedClientBalanceRow["balance"]);
            }
        }
        private void dataGridViewBalance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridViewBalance.SelectedRows.Count > 0)
                {
                    DataGridViewRow SelectedRow = dataGridViewBalance.SelectedRows[0];
                    int clientbalanceId = Convert.ToInt32(SelectedRow.Cells["client_balance_id"].Value);
                    SelectedClientBalanceRow = OriginalDesiredClientBalanceRowsdt.AsEnumerable().FirstOrDefault(row => row.Field<Int64>("client_balance_id") == clientbalanceId);

                    CalculatingInitialBalance();//ejbare foe el events

                    if (IsPayementOrEditMode)
                    {
                        ucSlideButtonPayOrEdit.button1_Click(null, EventArgs.Empty);
                    }
                    else
                    {
                        ucSlideButtonPayOrEdit.button2_Click(null, EventArgs.Empty);
                    }
                    buttonClearSelection.Visible = true;
                }
            }
        }
        private void buttonClearSelection_Click(object sender, EventArgs e)
        {
            dataGridViewBalance.ClearSelection();
            buttonClearSelection.Visible = false;


            SelectedClientBalanceRow = null;
            CalculatingInitialBalance();//ejbare foe el event
            ucSlideButtonPayOrEdit.button1_Click(null, EventArgs.Empty);
        }






        private void LoadForm()
        {
            SetUCSlidebutton();
            buttonClearSelection.Visible = false;

            //UCBALANCE
            if (initialbalance <= 0)//ejbare always, cz all ways will lead us to negative balance  bel system
            {
                UCBalance.Sign = "-";
            }
            else
            {
                UCBalance.Sign = "+";
            }
            UCBalance.textBoxPayment.BackColor = ColorBackTExtbOxEditMode;
            UCBalance.EditModeOn = false;

            //UCPAY
            UCPay = new UCPayments();
            UCPay.EditModeOn = true;
            UCPay.textBoxPayment.BackColor = ColorBackTExtbOxEditMode;
            UCPay.Sign = "+";
            UCPay.Dock = DockStyle.Fill;
            TLPEditInfo.Controls.Add(UCPay, 0, 1);

            //ejbare tahet UCBALANCE w UCPAY 
            IsPayementOrEditMode = true;
            SetDesignPaymentMode();



            //DatagridView
            dataGridViewBalance.DataSource = OriginalDesiredClientBalanceRowsdt;//badak that mahalla datatble aw mb#rf shu
            ClassClientBalanceFront.FormatDatagridview(dataGridViewBalance, false);
            dataGridViewBalance.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewBalance.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;//kermel taamil stretch aa kell surface  horizontally
            dataGridViewBalance.RowTemplate.MinimumHeight = 40; // Set minimum row height



            foreach (DataRow dr in OriginalDesiredClientBalanceRowsdt.Rows)
            {
                if (dr["due_date"] != DBNull.Value && dr["start_date"] != DBNull.Value)
                {
                    dataGridViewBalance.Columns["due_date"].Visible = true;
                    dataGridViewBalance.Columns["start_date"].Visible = true;
                    break;
                }

            }

            if (IsFromSchedule)
            {
                dataGridViewBalance.Columns["AutoIncrementColumn"].Visible = false;
            }

            dataGridViewBalance.ApplyStyle1();


        }



        void SetUCSlidebutton()
        {
            ucSlideButtonPayOrEdit = new UCSlideButton();
            ucSlideButtonPayOrEdit.Size = new Size(268, 37);
            ucSlideButtonPayOrEdit.Anchor = AnchorStyles.None;
            ucSlideButtonPayOrEdit.Margin = new Padding(3);


            TLPForm.Controls.Add(ucSlideButtonPayOrEdit, 0, 0);
            TLPForm.SetColumnSpan(ucSlideButtonPayOrEdit, 2);


            ucSlideButtonPayOrEdit.Button1Clicked += UcSlideButtonPayOrEdit_Button1Clicked;
            ucSlideButtonPayOrEdit.Button2Clicked += UcSlideButtonPayOrEdit_Button2Clicked;

            ucSlideButtonPayOrEdit.button1.Text = "Payment";
            ucSlideButtonPayOrEdit.button2.Text = "Edit";
        }

        void RemoveTLPStartDate()
        {
            TLPForm.Controls.Remove(TLPStartDate);
            TLPForm.SetRow(TLPEditInfo, 2);
            TLPForm.SetRowSpan(TLPEditInfo, 1);
        }
        private void SetDesignPaymentMode()
        {

            RemoveTLPStartDate();

            if (SelectedClientBalanceRow != null)
            {
                buttonUpdateOrPay.Text = "Pay";
                labelBalance.Text = "Balance";
            }
            else //eza kenit null, yaane eende kaza wahde w mesh mna2a
            {
                buttonUpdateOrPay.Text = "Pay All";
                labelBalance.Text = "Total Balance";
            }
            UCBalance.EditModeOn = false;

            labelPaymentSession.Text = "Down Payment";
            labelPaymentSession.Visible = true;

            TLPEditInfo.Visible = true;
            UCPay.Visible = true;

            UCBalance.Amount = Math.Abs(initialbalance);
            UCPay.Amount = UCBalance.Amount;

            if (UCNOSessionOrDays != null)
            {
                UCNOSessionOrDays.Dispose();
                UCNOSessionOrDays = null;
            }

        }
        void SetDesignEditMode(DataRow DesiredClientBalanceRow)
        {
            RemoveTLPStartDate();


            buttonUpdateOrPay.Text = "Update";
            UCBalance.Amount = Math.Abs(initialbalance);
            UCBalance.EditModeOn = true;

            if (DesiredClientBalanceRow["bundle_id"] != DBNull.Value && DesiredClientBalanceRow["session_left_days"] != DBNull.Value)//if bundle
            {

                labelPaymentSession.Visible = true;
                UCPay.Visible = false;
                TLPEditInfo.Visible = true;

                //UCSESSIOn

                if (UCNOSessionOrDays == null)
                {
                    UCNOSessionOrDays = new UCNumberButt();
                    UCNOSessionOrDays.Anchor = AnchorStyles.Top;
                    UCNOSessionOrDays.Margin = new Padding(0, 5, 0, 0);
                    UCNOSessionOrDays.textBoxValue.BackColor = ColorBackTExtbOxEditMode;
                    TLPEditInfo.Controls.Add(UCNOSessionOrDays, 0, 1);
                }


                labelPaymentSession.Text = "Sessions Left";

                if (DesiredClientBalanceRow["due_date"] == DBNull.Value)//package of sessions
                {
                    OldSessionOrDaysNumber = Convert.ToInt32(DesiredClientBalanceRow["session_left_days"]);
                }
                else//package of days
                {

                    TLPForm.Controls.Add(TLPStartDate, 1, 1);
                    TLPForm.SetRow(TLPEditInfo, 2);
                    TLPForm.SetRowSpan(TLPEditInfo, 1);

                    //DateTime Picker
                    dateTimePickerStartDate.MinDate = Convert.ToDateTime(DesiredClientBalanceRow["purchase_date"]).Date;

                    OldStartDate = Convert.ToDateTime(DesiredClientBalanceRow["start_date"]);
                    dateTimePickerStartDate.Value = OldStartDate;




                    if (Convert.ToBoolean(DesiredClientBalanceRow["is_freezed"]))
                    {
                        OldSessionOrDaysNumber = Convert.ToInt32(DesiredClientBalanceRow["session_left_days"]);
                    }
                    else
                    {
                        DateTime DesiredDate;
                        if (OldStartDate.Date <= DateTime.Now.Date)
                        {
                            DesiredDate = DateTime.Now;
                            labelPaymentSession.Text = "Days Left";
                        }
                        else//start time akbar, pakcage ma naamalo activate yet
                        {
                            DesiredDate = OldStartDate.Date;
                            labelPaymentSession.Text = "Number of days";
                        }
                        OldSessionOrDaysNumber = RandomFunctions.GetDaysDifference(DesiredDate, Convert.ToDateTime(DesiredClientBalanceRow["due_date"]));//tene wahde- awwal wahde                
                    }
                }

                if (OldSessionOrDaysNumber < 0)//SINCE HAYDE EL CALUE LI BET BAYYIN BEL update bel days w we know enno minimum bet kun 0 days , even law kenit negative men hott 0 as enno no days left
                {
                    UCNOSessionOrDays.IsNegative = true;
                }
                else
                {
                    UCNOSessionOrDays.IsNegative = false;
                }

                UCNOSessionOrDays.Number = OldSessionOrDaysNumber;


            }
            else//solo or product
            {

                labelPaymentSession.Visible = false;

                TLPEditInfo.Visible = false;
                UCPay.Visible = false;
                if (UCNOSessionOrDays != null)
                {
                    UCNOSessionOrDays.Dispose();
                    UCNOSessionOrDays = null;
                }
            }

        }



        private void UcSlideButtonPayOrEdit_Button1Clicked(object sender, EventArgs e)
        {

            IsPayementOrEditMode = true;
            SetDesignPaymentMode();

        }
        private void UcSlideButtonPayOrEdit_Button2Clicked(object sender, EventArgs e)
        {
            if (Program.Employee.CanEditOffre)
            {
                if (SelectedClientBalanceRow != null)
                {

                    IsPayementOrEditMode = false;
                    SetDesignEditMode(SelectedClientBalanceRow);


                }
                else
                {
                    CustomMessageBox.Show("Choose only one entity, in order to edit it.", CustomMessageBox.Type.OkInfo);
                    ucSlideButtonPayOrEdit.button1_Click(null, EventArgs.Empty);
                }
            }
            else
            {
                CustomMessageBox.Show("You don't have access", CustomMessageBox.Type.OkInfo);
                ucSlideButtonPayOrEdit.button1_Click(null, EventArgs.Empty);
            }
        }






        private void buttonUpdateOrPay_Click(object sender, EventArgs e)
        {
            Date = DateTime.Now;

            if (IsPayementOrEditMode == false)//edit mode
            {

                if (Convert.ToDouble(UCBalance.Sign + UCBalance.Amount) != initialbalance)//products and solo
                {
                    //SqlUpdate        
                    double ToBalance = Convert.ToDouble(UCBalance.Sign + UCBalance.Amount);
                    (double UpdatedBalance, string UpdatedOffre, bool NewIsExpired) = ClassClientBalance.UpdateClientBalanceOnEditingBalanceOffre(DesiredClient.ClientId, SelectedClientBalanceRow, ToBalance, initialbalance, Date, true);

                    //datagrid payment form
                    SelectedClientBalanceRow["balance"] = UpdatedBalance;
                    SelectedClientBalanceRow["offre"] = UpdatedOffre;
                    SelectedClientBalanceRow["is_expired"] = NewIsExpired;

                    if (ClientManagementProfileParentForm != null)
                    {
                        ClientManagementProfileParentForm.UpdateBalance(SelectedClientBalanceRow, initialbalance);
                    }

                    CalculatingInitialBalance();//ejbare tahet PayBalance UpdateClientBalanceOnEditingBalanceOffre

                }
                if (SelectedClientBalanceRow["bundle_id"] != DBNull.Value && SelectedClientBalanceRow["session_left_days"] != DBNull.Value && OldSessionOrDaysNumber != UCNOSessionOrDays.Number)//packages /ucnosession ma32oul tkun null bas ma mnusalla men wara awwal condition
                {


                    (int UpdatedSessionLeftORNoDays, string newoffre, DateTime? NewDueDate, bool NewIsExpired) = ClassClientBalance.UpdateClientBalanceOnEditingSessionOffre(DesiredClient.ClientId, SelectedClientBalanceRow, UCNOSessionOrDays.Number, OldSessionOrDaysNumber, Date, true);


                    //design
                    //datatgrid Payment form
                    SelectedClientBalanceRow["offre"] = newoffre;
                    SelectedClientBalanceRow["is_expired"] = NewIsExpired;

                    if (NewDueDate == null)//session bundle
                    {
                        SelectedClientBalanceRow["session_left_days"] = UpdatedSessionLeftORNoDays;
                    }
                    else//days bundle
                    {
                        SelectedClientBalanceRow["session_left_days"] = UpdatedSessionLeftORNoDays;
                        SelectedClientBalanceRow["due_date"] = NewDueDate;
                    }

                    if (ClientManagementProfileParentForm != null)
                    {
                        ClientManagementProfileParentForm.UpdateSessionNumber(SelectedClientBalanceRow);
                    }

                    OldSessionOrDaysNumber = UCNOSessionOrDays.Number;//reset lal OldSessionNumber             

                }


                DateTime NewStartDate = dateTimePickerStartDate.Value;
                if (SelectedClientBalanceRow["bundle_id"] != DBNull.Value && SelectedClientBalanceRow["start_date"] != DBNull.Value && NewStartDate != OldStartDate.Date)//package of days
                {
                    DateTime NewDueDate;
                    int TotalNOOfDays = Convert.ToInt32(SelectedClientBalanceRow["session_left_days"]);
                    //if (NewStartDate <= DateTime.Now.Date)
                    //{
                    //     int DaysToBeReduce=RandomFunctions.GetDaysDifference(NewStartDate, DateTime.Now.Date);
                    //     NewDueDate = NewStartDate.AddDays(TotalNOOfDays);
                    //}
                    //else//not activated
                    //{
                         NewDueDate = NewStartDate.AddDays(TotalNOOfDays);
                    //}


                    //sql
                    ClassClientBalance.UpdateStartDateDueDate(NewStartDate, NewDueDate, Convert.ToInt32(SelectedClientBalanceRow["client_balance_id"]));



                    //design

                    //datagrid of this form
                    SelectedClientBalanceRow["start_date"] = NewStartDate;
                    SelectedClientBalanceRow["due_date"] = NewDueDate;

                    //datagrid of cliemntmanagemnt form and uc
                    if (ClientManagementProfileParentForm != null)
                    {
                        ClientManagementProfileParentForm.UpdateStartDate(SelectedClientBalanceRow);

                    }
                }



                ucSlideButtonPayOrEdit.button1_Click(null, EventArgs.Empty);

            }
            else//we re paying
            {
                if (UCPay.Amount <= UCBalance.Amount)//ejbare hon ma nekhud el sign into cosideration , cz in this case kermel el design modtarring neetebir el balance deyman -
                {
                    double AmountPaid = Convert.ToDouble(UCPay.Sign + UCPay.Amount);

                    if (AmountPaid > 0)
                    {
                        PayBalance(AmountPaid);
                        CalculatingInitialBalance();//ejbare tahet PayBalance
                        UCBalance.Amount -= AmountPaid;
                        UCPay.Amount = 0;
                    }

                    if ((SelectedClientBalanceRow != null && OriginalDesiredClientBalanceRowsdt.Rows.Count == 1) || SelectedClientBalanceRow == null)
                    {
                        this.Close();
                    }




                    labelPaymentSession.Focus();//kermel nchil l focus 3n l textbox w ybayin l place holder     
                }
                else
                {
                    CustomMessageBox.Show("The amount entered exceed the balance of the client", CustomMessageBox.Type.Error);
                }
            }

        }//try catch as mother
        //it can be for one row or total balance
        public void PayBalance(double AmountPaid)
        {

            if (SelectedClientBalanceRow != null)
            {
                PayBalanceRowByRow(SelectedClientBalanceRow, ref AmountPaid);
            }
            else
            {
                int i = 0;
                while (AmountPaid > 0)
                {
                    if ((double)OriginalDesiredClientBalanceRowsdt.Rows[i]["balance"] != 0)
                    {
                        PayBalanceRowByRow(OriginalDesiredClientBalanceRowsdt.Rows[i], ref AmountPaid);
                    }
                    i++;
                }
            }

            if (ClientManagementProfileParentForm != null)
            {
                //Design lal profile           
                ClientManagementProfileParentForm.ResortOriginalDataTableAndSetDatasource();
                ClientManagementProfileParentForm.FormatDatagridviewDesign();
                ClientManagementProfileParentForm.dataGridViewBalance.FirstDisplayedScrollingRowIndex = 0;
                ClientManagementProfileParentForm.CalculatingTotalBalancesDesignAndSql(true);
                ClientManagementProfileParentForm.CalculatingClientHistoryDesignAndSql(true);
            }
            else if (ClientManagementProfileParentForm == null)
            {
                UpdateClientBalanceIfNotProfile(true);//eza men el schedule for example
            }
        }
        public void PayBalanceRowByRow(DataRow DesiredClientBalanceRow, ref double TotalAmountPaid)
        {

            double AmountPaidPerRow;
            double TotalBalancePerRow;
            int ClientBalanceId;
            bool IsBundleOrProduct;
            bool? IsPackageOrSolo = null;//null in case of product



            //logic started
            if (DesiredClientBalanceRow["product_id"] != DBNull.Value)//product
            {
                IsBundleOrProduct = false;

            }
            else //bundle
            {

                IsBundleOrProduct = true;
                if (DesiredClientBalanceRow["session_left_days"] == DBNull.Value)//solo
                {
                    IsPackageOrSolo = false;
                }
                else//package
                {
                    IsPackageOrSolo = true;
                }

            }


            TotalBalancePerRow = Math.Abs(Convert.ToDouble(DesiredClientBalanceRow["balance"].ToString()));
            ClientBalanceId = Convert.ToInt32(DesiredClientBalanceRow["client_balance_id"]);


            if (TotalAmountPaid >= TotalBalancePerRow)
            {
                double balance = 0;

                //Design
                DesiredClientBalanceRow["balance"] = balance;
                DesiredClientBalanceRow["amount_paid"] = TotalBalancePerRow + (double)DesiredClientBalanceRow["amount_paid"];
                //IsExpired and only for products cz bundles mesh men hone
                if (!IsBundleOrProduct)//product or sevice
                {

                    DesiredClientBalanceRow["is_expired"] = true;
                }
                else//if he is pakcage
                {
                    if ((bool)IsPackageOrSolo)//package
                    {
                        if (ClientManagementProfileParentForm != null)
                        {
                            ClientManagementProfileParentForm.UpdateIsInDebteToUCBundle(Convert.ToInt32(DesiredClientBalanceRow["client_balance_id"]), false);
                        }
                    }
                    else//solo
                    {
                        DesiredClientBalanceRow["is_expired"] = true;
                    }
                }

                //
                AmountPaidPerRow = TotalBalancePerRow;
                TotalAmountPaid -= TotalBalancePerRow;
            }
            else
            {
                double balance = -(TotalBalancePerRow - TotalAmountPaid);

                //Design
                DesiredClientBalanceRow["balance"] = balance;
                DesiredClientBalanceRow["amount_paid"] = TotalAmountPaid + (double)DesiredClientBalanceRow["amount_paid"];

                //
                AmountPaidPerRow = TotalAmountPaid;
                TotalAmountPaid = 0;

            }


            //SQL
            //TimeSpan difference = Date - DesiredDateOfPayment;
            //if (Math.Abs(difference.TotalMinutes) < 1)
            //{
            //    DesiredDateOfPayment = Date; // lieanno both b kun azdna dateTime.Now, bas lieanno fi baynetun faree bel algo, byenzalo gher
            //    //w el desired date bas mostaamele lal solo services, w hawdike ma eenda meshekle bel undo tb3un since men shil based aal client_balance_id 
            //    //or this staamalnehna kermel el undo mesh men el sc
            //}
          

            ClassBackOffice backOffice = new ClassBackOffice(DesiredClient.ClientId, ActionsEnum.Payments, Program.Employee.EmployeeId, ClientBalanceId, AmountPaidPerRow, null, null, null, null, Date);
            backOffice.CreateActionDetails(DesiredClientBalanceRow);
            long NewarchiveId = backOffice.InsertToArchiveSQL();


            ClassClientBalance.UpdateClientBalanceAndInsertingFinanceOnPay(DesiredClientBalanceRow, ClientBalanceId, AmountPaidPerRow, DesiredDateOfPayment, DesiredClient.AlbumType, NewarchiveId);//ejbare tahet el design section foe, cz el values yetghdayaro b DesiredClientBalanceRow


            //RefreshParent Design
            if (ClientManagementProfileParentForm != null)
            {
                ////transfering info to the parent form
                DataRow rowToEdit = ClientManagementProfileParentForm.dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceRow["client_balance_id"]);
                rowToEdit["balance"] = DesiredClientBalanceRow["balance"];
                rowToEdit["amount_paid"] = DesiredClientBalanceRow["amount_paid"];
                rowToEdit["is_expired"] = DesiredClientBalanceRow["is_expired"];
            }

        } //try catch




        void UpdateClientBalanceIfNotProfile(bool PayOrCancel)//since el profile eenda it s own, eza fatahna men gher matrah , ta taamil update
        {
            DataTable dtOriginalClientBalance = ClassClientBalance.GetClientBalanceSpecificOrLastInsert(DesiredClient.ClientId);

            (double TotalBalanceAmount, _, _) = ClassClientBalance.CalculatingClientBalance(dtOriginalClientBalance);
            (double TotalPayment, _, _, _, _) = ClassClientBalance.CalculatingClientPayment(dtOriginalClientBalance);

            //Sql
            if (PayOrCancel)
            {
                ClassClientCustom.UpdateClientTotalBalanceSQL(DesiredClient.ClientId, TotalBalanceAmount, true);//hayde kermel el table el client el asesie
                ClassClientCustom.UpdateClientTotalPaymentSQL(DesiredClient.ClientId, TotalPayment, true);
            }

            //Object
            DesiredClient.TotalBalance = TotalBalanceAmount;//since aam nuuza bel schedule w ma men uuz el payment
            DesiredClient.TotalPayment = TotalPayment;
        }




        private void buttonCancel_Click(object sender, EventArgs e)
        {
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
        private void Payment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClientManagementProfileParentForm == null)
            {
                UpdateClientBalanceIfNotProfile(false);
            }

            //
            if (Program.GreyFormJunior != null)
            {
                Program.GreyFormJunior.Close();
                Program.GreyFormJunior = null;
            }
            else if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }
        //mawjude matrahen hone w bel profile
        private void dataGridViewBalance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dataGridViewBalance.Rows.Count && e.ColumnIndex < dataGridViewBalance.Columns.Count)
            {
                ClassClientBalanceFront.FixCellsFormat(dataGridViewBalance, e);
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            dataGridViewBalance.ClearSelection();

        }

       

        private void dateTimePickerStartDate_CloseUp(object sender, EventArgs e)
        {
            label1.Select();
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
