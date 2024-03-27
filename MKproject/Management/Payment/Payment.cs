using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GlobalFunctions;
using CustomizedTools;

namespace MKproject.Management
{
    public partial class Payment : Form
    {
        DataTable DesiredClientBalanceRowsdt;

        SqlConnection con = new SqlConnection(Program.DataLocation);
        public ClientManagementProfile ClientManagementProfileParentForm { get; set; }
        bool IsFromSchedule;
        public ClassClient DesiredClient;
        private double initialbalance;
        private int OldSessionOrDaysNumber;
        DateTime Date;//kermel datetime.now el kell yekheda
        private bool Editing = false;//to know if we clicked the edit button of the balance or not
        int AffectedRow;
        UCPayments UCPay;
        UCNumberButt UCNOSession;
        bool IsEditForm1;//we have 2 edit forms form pakacges , and for products

        Color ColorBackTExtbOxEditMode = Color.FromArgb(235, 235, 235);


        private bool isPayementMode = true;
        public bool IsPayementMode
        {
            get { return isPayementMode; }
            set
            {
                isPayementMode = value;
                if (isPayementMode == true)
                {
                    PaymentFormOn();
                }
                else
                {
                    if (IsEditForm1 == true)//if bundle
                    {
                        EditFormOn1();
                    }
                    else//of product or solo
                    {
                        EditFormOn2();
                    }

                }
            }
        }

        //DataTable here could be only one row or many rows if pay total
        public Payment(ClassClient desiredClient, double AmountSigned, DataTable desiredClientBalanceRowsdt, ClientManagementProfile clientManagementProfile, bool isFromSchedule)
        {
            InitializeComponent();
            this.Opacity = 0;

            IsFromSchedule = isFromSchedule;
            ClientManagementProfileParentForm = clientManagementProfile;
            initialbalance = AmountSigned;
            DesiredClientBalanceRowsdt = desiredClientBalanceRowsdt;
            DesiredClient = desiredClient;

            LoadForm();

            this.Opacity = 0;
            this.TopMost = true;
        }



        private void LoadForm()
        {
            SetUCSlidebutton();

            //UCBALANCE
            if (initialbalance <= 0)//ejbare always, cz all ways will lead us to negative balance  bel system
            {
                UCBalance.Sign = "-";
            }
            else
            {
                UCBalance.Sign = "+";
            }
            UCBalance.Amount = Math.Abs(initialbalance);
            UCBalance.textBoxPayment.BackColor = ColorBackTExtbOxEditMode;
            UCBalance.EditModeOn = false;

            //UCPAY
            UCPay = new UCPayments();
            UCPay.EditModeOn = true;
            UCPay.textBoxPayment.BackColor = ColorBackTExtbOxEditMode;
            UCPay.Sign = "+";
            UCPay.Amount = UCBalance.Amount;
            UCPay.Dock = DockStyle.Fill;
            TLPEditInfo.Controls.Add(UCPay, 0, 1);

            //UCSESSIOn
            if (DesiredClientBalanceRowsdt.Rows.Count > 0 && DesiredClientBalanceRowsdt.Rows[0]["bundle_id"] != DBNull.Value)//bundles
            {
                if (DesiredClientBalanceRowsdt.Rows[0]["session_left_days"] != DBNull.Value)//package not solo
                {
                    UCNOSession = new UCNumberButt();
                    UCNOSession.Anchor = AnchorStyles.Top;
                    UCNOSession.Margin = new Padding(0, 5, 0, 0);
                    UCNOSession.textBoxValue.BackColor = ColorBackTExtbOxEditMode;
                    TLPEditInfo.Controls.Add(UCNOSession, 0, 1);


                    if (DesiredClientBalanceRowsdt.Rows[0]["due_date"] == DBNull.Value)
                    {
                        OldSessionOrDaysNumber = Convert.ToInt16(DesiredClientBalanceRowsdt.Rows[0]["session_left_days"]);

                    }
                    else
                    {
                        if ((bool)DesiredClientBalanceRowsdt.Rows[0]["is_freezed"])
                        {
                            OldSessionOrDaysNumber = Convert.ToInt16(DesiredClientBalanceRowsdt.Rows[0]["session_left_days"]);
                        }
                        else
                        {
                            OldSessionOrDaysNumber = RandomFunctions.GetDaysDifference(DateTime.Now, (DateTime)DesiredClientBalanceRowsdt.Rows[0]["due_date"]);//tene wahde- awwal wahde                
                        }
                    }
                    if (OldSessionOrDaysNumber < 0)//SINCE HAYDE EL CALUE LI BET BAYYIN BEL update bel days w we know enno minimum bet kun 0 days , even law kenit negative men hott 0 as enno no days left
                    {
                        UCNOSession.IsNegative = true;
                    }
                    else
                    {
                        UCNOSession.IsNegative = false;
                    }
                    UCNOSession.Number = OldSessionOrDaysNumber;
                }

            }


            //DatagridView
            dataGridViewBalance.DataSource = DesiredClientBalanceRowsdt;//badak that mahalla datatble aw mb#rf shu
            ClassClientBalance.FormatDatagridview(dataGridViewBalance, false);
            dataGridViewBalance.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewBalance.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;//kermel taamil stretch aa kell surface  horizontally
            dataGridViewBalance.RowTemplate.MinimumHeight = 40; // Set minimum row height

            if (DesiredClientBalanceRowsdt.Rows.Count >= 1)//ma lezim tkun =0, this execption should be handled by design
            {
                if (DesiredClientBalanceRowsdt.Rows[0]["due_date"] != DBNull.Value)
                {
                    dataGridViewBalance.Columns["due_date"].Visible = true;
                }
            }
            if (IsFromSchedule)
            {
                dataGridViewBalance.Columns["AutoIncrementColumn"].Visible = false;
            }

            dataGridViewBalance.ApplyStyle1();

            // for the design
            if (DesiredClientBalanceRowsdt.Rows.Count > 1)//in case of total payment 
            {
                ucSlideButtonPayOrEdit.Visible = false;
            }
            else if (DesiredClientBalanceRowsdt.Rows.Count == 1 && !IsFromSchedule)
            {
                if (DesiredClientBalanceRowsdt.Rows[0]["bundle_id"] != DBNull.Value && DesiredClientBalanceRowsdt.Rows[0]["session_left_days"] != DBNull.Value)//package
                {
                    IsEditForm1 = true;
                }
                else//solo or product
                {
                    IsEditForm1 = false;
                }
            }
            IsPayementMode = true;
        }


        void SetUCSlidebutton()
        {


            PaymentModeOn();

            ucSlideButtonPayOrEdit.Button1Clicked += UcSlideButtonPayOrEdit_Button1Clicked;
            ucSlideButtonPayOrEdit.Button2Clicked += UcSlideButtonPayOrEdit_Button2Clicked;

            ucSlideButtonPayOrEdit.button1.Text = "Payment";
            ucSlideButtonPayOrEdit.button2.Text = "Edit";
        }
        private void UcSlideButtonPayOrEdit_Button2Clicked(object sender, EventArgs e)
        {
            if (LOGIN.Employee.CanEditOffre)
            {
                if (IsPayementMode)//eza already kenit edit mode ma btaamil shi
                {
                    EditModeOn();
                }
            }
            else
            {
                CustomMessageBox.Show("You don't have access", CustomMessageBox.Type.Ok);
                ucSlideButtonPayOrEdit.button1_Click(null, EventArgs.Empty);

            }

        }
        private void UcSlideButtonPayOrEdit_Button1Clicked(object sender, EventArgs e)
        {
            if (!IsPayementMode)//eza already kenit Payment mode ma btaamil shi
            {
                UCBalance.Amount = Math.Abs(initialbalance);
                if (UCNOSession != null)
                {
                    if (OldSessionOrDaysNumber < 0)
                    {
                        UCNOSession.IsNegative = true;
                    }
                    else
                    {
                        UCNOSession.IsNegative = false;
                    }
                    UCNOSession.Number = OldSessionOrDaysNumber;
                }
                PaymentModeOn();

            }
        }



        void PaymentModeOn()
        {
            if (IsPayementMode == false)
            {
                IsPayementMode = true; //in order bas nekbus  marra wahde
                buttonUpdateOrPay.Text = "Pay";
            }
        }
        void EditModeOn()
        {
            if (IsPayementMode == true)
            {
                IsPayementMode = false;//in order bas nekbus  marra wahde
                buttonUpdateOrPay.Text = "Update";
            }
        }
        private void PaymentFormOn()
        {


            UCBalance.EditModeOn = false;

            labelPaymentSession.Text = "Down Payment";
            labelPaymentSession.Visible = true;

            TLPEditInfo.Visible = true;
            UCPay.Visible = true;
            UCPay.Amount = UCBalance.Amount;

            if (UCNOSession != null)
            {
                UCNOSession.Visible = false;
            }



        }
        private void EditFormOn1()//for bundles
        {


            UCBalance.EditModeOn = true;

            labelPaymentSession.Visible = true;
            if (DesiredClientBalanceRowsdt.Rows[0]["due_date"] != DBNull.Value)
            {
                labelPaymentSession.Text = "Days Left";
            }
            else
            {

                labelPaymentSession.Text = "Sessions Left";
            }

            UCPay.Visible = false;

            if (UCNOSession != null)
            {
                UCNOSession.Visible = true;
            }


        }
        private void EditFormOn2()//for products and Solo
        {

            UCBalance.EditModeOn = true;
            labelPaymentSession.Visible = false;

            TLPEditInfo.Visible = false;
            UCPay.Visible = false;
            if (UCNOSession != null)
            {
                UCNOSession.Visible = false;
            }




        }




        private void buttonUpdateOrPay_Click(object sender, EventArgs e)
        {
            if (IsPayementMode == false)//edit mode
            {
                Date = DateTime.Now;

                if (Convert.ToDouble(UCBalance.Sign + UCBalance.Amount) != initialbalance)//products and solo
                {
                    ClientManagementProfileParentForm.UpdateBalance(DesiredClientBalanceRowsdt, Convert.ToDouble(UCBalance.Sign + UCBalance.Amount), ref initialbalance, Date);
                }
                if (DesiredClientBalanceRowsdt.Rows[0]["bundle_id"] != DBNull.Value && DesiredClientBalanceRowsdt.Rows[0]["session_left_days"] != DBNull.Value && OldSessionOrDaysNumber != UCNOSession.Number)//packages /ucnosession ma32oul tkun null bas ma mnusalla men wara awwal condition
                {
                    ClientManagementProfileParentForm.UpdateSessionNumber(DesiredClientBalanceRowsdt, UCNOSession.Number, ref OldSessionOrDaysNumber, Date);
                }


                IsPayementMode = true; //in order bas nekbus  marra wahde

                buttonUpdateOrPay.Text = "Pay";

            }
            else//we re paying
            {
                if (UCPay.Amount <= UCBalance.Amount)//ejbare hon ma nekhud el sign into cosideration , cz in this case kermel el design modtarring neetebir el balance deyman -
                {
                    double AmountPaid = Convert.ToDouble(UCPay.Sign + UCPay.Amount);
                    initialbalance += AmountPaid;
                    labelPaymentSession.Focus();//kermel nchil l focus 3n l textbox w ybayin l place holder
                    PayBalance(AmountPaid);
                    UCBalance.Amount += AmountPaid;
                    UCPay.Amount = 0;
                    this.Close();
                }
                else
                {
                    CustomMessageBox.Show("The amount entered exceed the balance of the client", CustomMessageBox.Type.Ok);
                }

            }

        }//try catch as mother

        //it can be for one row or total balance
        public void PayBalance(double AmountPaid)
        {
            ClassBackOffice backOffice;
            Date = DateTime.Now;
            double AmoutPerRow;
            int ClientBalanceId;
            bool IsBundleOrProduct;
            bool? IsPackageOrSolo = null;//null in case of product
            int CategoryId;
            string catregoryType;//kermel el financeList
            string BackOfficeCatType;
            string BackOfficeCatName;
            bool IsProduct = false;//only kermel IsExpired tahet          
            List<(double, int)> ListFinanceUpdates = new List<(double, int)>();//category type/amount paid/clientbalanceid


            AffectedRow = 0;
            int i = 0;

            while (AmountPaid > 0)
            {
                //logic started
                if (DesiredClientBalanceRowsdt.Rows[i]["product_id"] != DBNull.Value)//product
                {
                    IsBundleOrProduct = false;

                }
                else //bundle
                {

                    IsBundleOrProduct = true;
                    if (DesiredClientBalanceRowsdt.Rows[i]["session_left_days"] == DBNull.Value)//solo
                    {
                        IsPackageOrSolo = false;
                    }
                    else//package
                    {
                        IsPackageOrSolo = true;
                    }

                }


                AmoutPerRow = Math.Abs(Convert.ToDouble(DesiredClientBalanceRowsdt.Rows[i]["balance"].ToString()));
                ClientBalanceId = (int)DesiredClientBalanceRowsdt.Rows[i]["client_balance_id"];

                if (AmountPaid >= AmoutPerRow)
                {
                    //dt update
                    string balance = "0";


                    //SQL
                    backOffice = new ClassBackOffice(DesiredClient.ClientId, ActionsEnum.Payments, LOGIN.Employee.EmployeeId, ClientBalanceId, AmoutPerRow, null, null, null, null, Date);
                    backOffice.CreateActionDetails(DesiredClientBalanceRowsdt.Rows[i]);
                    backOffice.InsertToArchiveSQL();

                    //Design

                    DesiredClientBalanceRowsdt.Rows[i]["balance"] = balance;
                    DesiredClientBalanceRowsdt.Rows[i]["amount_paid"] = AmoutPerRow + (double)DesiredClientBalanceRowsdt.Rows[i]["amount_paid"];
                    //IsExpired and only for products cz bundles mesh men hone
                    if (!IsBundleOrProduct)//product or sevice
                    {
                        IsProduct = true;
                        DesiredClientBalanceRowsdt.Rows[i]["is_expired"] = true;
                    }
                    else//if he is pakcage
                    {
                        if ((bool)IsPackageOrSolo)//package
                        {
                            if (ClientManagementProfileParentForm != null)
                            {
                                ClientManagementProfileParentForm.UpdateIsInDebteToUCBundle(Convert.ToInt16(DesiredClientBalanceRowsdt.Rows[i]["client_balance_id"]), false);
                            }
                        }
                        else//solo
                        {
                            DesiredClientBalanceRowsdt.Rows[i]["is_expired"] = true;
                        }
                    }



                    //finance
                    ListFinanceUpdates.Add((AmoutPerRow, ClientBalanceId));

                    //
                    AmountPaid -= AmoutPerRow;
                    AffectedRow++;

                }
                else /* if (AmountPaid < AmoutPerRow)*/
                {
                    //logic started
                    string balance = Convert.ToString(-(AmoutPerRow - AmountPaid));
                    //logic ended

                    //Sql
                    backOffice = new ClassBackOffice(DesiredClient.ClientId, ActionsEnum.Payments, LOGIN.Employee.EmployeeId, ClientBalanceId, AmountPaid, null, null, null, null, Date);
                    backOffice.CreateActionDetails(DesiredClientBalanceRowsdt.Rows[i]);
                    backOffice.InsertToArchiveSQL();

                    //Design
                    DesiredClientBalanceRowsdt.Rows[i]["balance"] = balance;
                    DesiredClientBalanceRowsdt.Rows[i]["amount_paid"] = AmountPaid + (double)DesiredClientBalanceRowsdt.Rows[i]["amount_paid"];


                    //finance
                    ListFinanceUpdates.Add((AmountPaid, ClientBalanceId));
                    //
                    AmountPaid = 0;
                    AffectedRow++;
                }

                i++;
            }



            PaymentRefreshParentANDSql(ListFinanceUpdates, IsProduct, IsPackageOrSolo, Date);//mahalla mazbut w mah ateassir law eemil crash backoffice masalan w el disign tabaa el payment ha yotlaa ghalat i agree bas el parent form ma tkun accurate, w eza tolii ghalat bel payment men sakkir el form fina



        }//try catch
        void PaymentRefreshParentANDSql(List<(double, int)> ListFinanceUpdates, bool IsProduct, bool? IsPackageOrSolo, DateTime Date)
        {
            //SQL
            ClassClientBalance.UpdateClientBalanceAndInsertingFinanceOnPay(DesiredClientBalanceRowsdt, AffectedRow, ListFinanceUpdates, Date, DesiredClient.AlbumType);//mafik tsil affected row, ma32oul affected row awal men el count tabaa el desired dt

            if (ClientManagementProfileParentForm != null)
            {
                ////transfering info to the parent form
                for (int k = 0; k < AffectedRow; k++)
                {
                    DataRow rowToEdit = ClientManagementProfileParentForm.dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceRowsdt.Rows[k]["client_balance_id"]);
                    rowToEdit["balance"] = DesiredClientBalanceRowsdt.Rows[k]["balance"];
                    rowToEdit["amount_paid"] = DesiredClientBalanceRowsdt.Rows[k]["amount_paid"];
                    rowToEdit["is_expired"] = DesiredClientBalanceRowsdt.Rows[k]["is_expired"];

                    if (IsProduct || (IsPackageOrSolo != null && !(bool)IsPackageOrSolo))//lieano el bundle men shello el expiry bel remove or renew
                    {
                        rowToEdit["is_expired"] = DesiredClientBalanceRowsdt.Rows[k]["is_expired"];
                    }
                }
                if (IsProduct || (IsPackageOrSolo != null && !(bool)IsPackageOrSolo))//lieanno el resorting only aal date which is fix and Is expired, since eza ma ken product isexpired ha teb2a metel a hiyye , so ma ela aaze ynaamal sorting lal bundle
                {
                    ClientManagementProfileParentForm.ResortOriginalDataTableAndSetDatasource();
                }

                ClientManagementProfileParentForm.FormatDatagridviewDesign();
                ClientManagementProfileParentForm.dataGridViewBalance.FirstDisplayedScrollingRowIndex = 0;
                ClientManagementProfileParentForm.CalculatingTotalBalancesDesignAndSql(true);
                ClientManagementProfileParentForm.CalculatingClientHistoryDesignAndSql(true);

            }
            else if (ClientManagementProfileParentForm == null)
            {
                UpdateClientBalanceIfNotProfile(true);
            }

        }//try catch


        void UpdateClientBalanceIfNotProfile(bool PayOrCancel)//since el profile eenda it s own, eza fatahna men gher matrah , ta taamil update
        {
            DataTable dtOriginalClientBalance =ClassClientBalance.GetClientBalanceSpecificOrLastInsert(DesiredClient.ClientId);

            (double TotalBalanceAmount, _, _) = ClassClientBalance.CalculatingClientBalance(dtOriginalClientBalance);
            (double TotalPayment, _, _, _, _) = ClassClientBalance.CalculatingClientPayment(dtOriginalClientBalance);

            //Sql
           if (PayOrCancel)
            {
                ClassClient.UpdateClientTotalBalanceSQL(DesiredClient.ClientId, TotalBalanceAmount,true);//hayde kermel el table el client el asesie
                ClassClient.UpdateClientTotalPaymentSQL(DesiredClient.ClientId, TotalPayment, true);
            }
           
            //Object
            DesiredClient.TotalBalance = TotalBalanceAmount;//since aam nuuza bel schedule w ma men uuz el payment
            DesiredClient.TotalPayment = TotalPayment;
        }




        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (ClientManagementProfileParentForm == null)
            {
                UpdateClientBalanceIfNotProfile(false);
            }
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
            if (Program.GreyForm != null)
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
                ClassClientBalance.FixCellsFormat(dataGridViewBalance, e);
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            dataGridViewBalance.ClearSelection();

        }
    }
}
