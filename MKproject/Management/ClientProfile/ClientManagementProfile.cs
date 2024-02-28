using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GlobalFunctions;
using CustomizedTools; // Make sure to add this namespace

namespace MKproject.Management
{
    public partial class ClientManagementProfile : Form
    {
        public ClassClient Client;
        double TotalBalanceAmount;
        string NotAvailableText = "N/A";
        public bool IsClientDeleted = false;
        int? ParentIdInProfile;//eza ken child w eendo parent ha ha tkun not null 
        bool IsFromSchedule;

        public Panel panelBundles;//kermel lamma ykun eena bundles nhotta    

        public DataTable dtClientBalanceOriginal;

        public SearchCurrentClient SearchCurrentClientform { get; set; }

        private UCLabelAndDetail UCNote;
        private UCLabelAndDetail UCSessionPerWeek;
        private UCLabelAndDetail UCHand;
        private UCLabelAndDetail UCInjuries;
        private UCLabelAndDetail UCMuscleFocusOn;
        private UCLabelAndDetail UCShapeTarget;
        private UCLabelAndDetail UCWeight;
        private UCLabelAndDetail UCHeight;
        private UCLabelAndDetail UCInsta;
        private UCLabelAndDetail UCAdress;
        private UCLabelAndDetail UCJob;
        private UCLabelAndDetail UCPhoneNumber;
        private UCLabelAndDetail UCBirthday;
        private UCLabelAndDetail UCAge;
        private UCLabelAndDetail UCGender;
        private UCLabelAndDetail UCEmail;
        private UCLabelAndDetail UCKnowAboutUs;
        private UCLabelAndDetail UCMaritalStatus;
        private UCLabelAndDetail UCGoalsTimeline;
        private UCLabelAndDetail UCAlcohol;
        private UCLabelAndDetail UCSmoking;
        private UCLabelAndDetail UCExerciseHistory;
        private UCLabelAndDetail UCSleepPattern;
        private UCLabelAndDetail UCStressLevel;
        private UCLabelAndDetail UCBoxingSkills;

        UCLabelAndDetail ucLabelAndDetailLinked;
        TableLayoutPanel TLPLinked;
        IconButton iconViewOrProfile;

        public static Image PayOrEditImage;
        Image PayOrEditImagePopUp;
        Image BackOfficeImage;
        Image BackOfficeImagePopUp;
        public static Image EmptyImage;



        public ClientManagementProfile(ClassClient client, bool isFromSchedule)//new register
        {
            InitializeComponent();

            LoadImages();


            LoadData(client, isFromSchedule);

            dataGridViewBalance.ApplyStyle1();
        }

        void LoadImages()
        {

            PayOrEditImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "dollarSmall.png");
            PayOrEditImagePopUp = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "dollarBig.png");
            BackOfficeImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "BackOfficeSmall.png");
            BackOfficeImagePopUp = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "BackOfficeBig.png");
            EmptyImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "EmptyIcon.png");

        }


        public void LoadData(ClassClient client, bool isFromSchedule)
        {
            if (isFromSchedule)
            {
                Opacity = 0;
                timer1.Start();
            }

            Client = client;
            IsFromSchedule = isFromSchedule;
            IsClientDeleted = false;
            ParentIdInProfile = null;
            if (dtClientBalanceOriginal != null)
            {
                dtClientBalanceOriginal.Clear();
                dataGridViewBalance.Refresh();
            }


            panelSecondaryInfo.AutoScrollPosition = new Point(0, 0);
            RemoveLinkedChildOrParent();



            dtClientBalanceOriginal = SQLToProject.GetClientBalanceSpecificOrLastInsert(Client.ClientId);

            FormatOriginalDt(dtClientBalanceOriginal);
            DataTableToDatagridView();
            FormatDatagridview(dataGridViewBalance, true);
            //            
            InitialSetBundleMode();//lama ykun eena 10000 UC bundles mesh menshelin ma32eoul tekhud shwayyit waet
            datagridviewBalanceMode();
            UpdateOrCreateUCLabelAndDetail(false);//creating linked child in here at the end
            labelName.Select();
            //
            FormatDatagridviewDesign();
        }//try catch

        private void ClientManagementProfile_Load(object sender, EventArgs e)
        {
            AutosizeUCLabel();
            //FormatDatagridviewDesign();battal ela aaze, since hattayneha bel visible on off
            dataGridViewBalance.ClearSelection();
        }


        public void datagridviewBalanceMode()
        {

            int rowIndex = 1; // Replace with the desired row index
            int colIndex = 0; // Replace with the desired column index
            Control controlToRemove = TLPBalance.GetControlFromPosition(colIndex, rowIndex);

            if (!(controlToRemove is Label) && dtClientBalanceOriginal.Rows.Count == 0)
            {
                TLPBalance.Controls.Remove(controlToRemove);//we re removing the panel for the uc
                Label Nodata = GetNoBundleLable("No Data have been assigned");
                TLPBalance.Controls.Add(Nodata, colIndex, rowIndex);
                TLPBalance.SetColumnSpan(Nodata, 5);
            }
            else if ((controlToRemove is Label) && dtClientBalanceOriginal.Rows.Count != 0)
            {

                TLPBalance.Controls.Remove(controlToRemove);//we re removing the panel for the uc
                controlToRemove.Dispose(); // Optional, if you want to dispose of the removed control
                TLPBalance.Controls.Add(dataGridViewBalance, colIndex, rowIndex);
                TLPBalance.SetColumnSpan(dataGridViewBalance, 5);
            }
        }
        public void FormatOriginalDt(DataTable DtClientBalanceOriginal)
        {


            DtClientBalanceOriginal.Columns.Add("Purchase date", typeof(string));
            DtClientBalanceOriginal.Columns.Add("DueDate", typeof(string));
            DtClientBalanceOriginal.Columns.Add("FakeOrignalOffre", typeof(string));
            DtClientBalanceOriginal.Columns.Add("FakeOffer", typeof(string));
            DtClientBalanceOriginal.Columns.Add("Paid", typeof(string));
            DtClientBalanceOriginal.Columns.Add("FakeBalance", typeof(string));


            foreach (DataRow d in DtClientBalanceOriginal.Rows)
            {
                string currency = (string)d["Symbol"];
                string balance = Convert.ToString((double)d["balance"]);
                string PurchaseDate = "";
                string DueDate = "";

                DateTime dateTimeValue;

                if (DateTime.TryParse(d["purchase_date"].ToString(), out dateTimeValue))
                {
                    // Convert the DateTime value to a string in the format "MM/dd/yy"
                    PurchaseDate = dateTimeValue.ToString("MMMM/dd/yyyy");
                }
                else
                {
                    PurchaseDate = NotAvailableText;
                }

                if (DateTime.TryParse(d["due_date"].ToString(), out dateTimeValue))
                {
                    // Convert the DateTime value to a string in the format "MM/dd/yy"
                    DueDate = dateTimeValue.ToString("MMMM/dd/yyyy");
                }

                if (d["offre"] != DBNull.Value)
                {
                    d["FakeOffer"] = currency + d["offre"];
                }
                else
                {
                    d["FakeOffer"] = NotAvailableText;
                }

                if (d["original_offre"] != DBNull.Value)
                {
                    d["FakeOrignalOffre"] = currency + d["original_offre"];
                }
                else
                {
                    d["FakeOrignalOffre"] = NotAvailableText;
                }

                d["Purchase date"] = PurchaseDate;
                d["DueDate"] = DueDate;
                d["Paid"] = currency + d["amount_paid"];
                d["FakeBalance"] = ClassChosenClientBalance.SetBalanceFormat(balance);
            }

            // Add auto-increment column to existing DataTable
            DtClientBalanceOriginal.Columns.Add("AutoIncrementColumn", typeof(int));
            DtClientBalanceOriginal.Columns["AutoIncrementColumn"].AutoIncrement = true;
            DtClientBalanceOriginal.Columns["AutoIncrementColumn"].AutoIncrementSeed = 1;
            DtClientBalanceOriginal.Columns["AutoIncrementColumn"].AutoIncrementStep = 1;
            // Populate the auto-increment column
            int currentAutoIncrementValue = 1;
            foreach (DataRow row in DtClientBalanceOriginal.Rows)
            {
                row["AutoIncrementColumn"] = currentAutoIncrementValue;
                currentAutoIncrementValue++;
            }
            DtClientBalanceOriginal.PrimaryKey = new DataColumn[] { DtClientBalanceOriginal.Columns["ID"] };
            //


            //ordering
            int columnIndexToMove;
            int newIndex;

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("AutoIncrementColumn"); // Replace with the actual column name
            newIndex = 0; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("Description");//description bas kermel el design 
            newIndex = 1; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("Purchase date"); // Replace with the actual column name
            newIndex = 2; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("DueDate"); // Replace with the actual column name
            newIndex = 3; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("FakeOrignalOffre"); // Replace with the actual column name
            newIndex = 4; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("FakeOffer"); // Replace with the actual column name
            newIndex = 5; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("Paid"); // Replace with the actual column name
            newIndex = 6; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = DtClientBalanceOriginal.Columns.IndexOf("FakeBalance"); // Replace with the actual column name
            newIndex = 7; // The new desired index
            DtClientBalanceOriginal.Columns[columnIndexToMove].SetOrdinal(newIndex);

            if (DtClientBalanceOriginal.Rows.Count > 0)
            {
                buttonBackOffice.Enabled = true;
            }
            else
            {
                buttonBackOffice.Enabled = false;
            }

        }
        public void DataTableToDatagridView()
        {
            ResortOriginalDataTableAndSetDatasource();

            //dataGridViewBalance.DataSource = dtClientBalanceOriginal;

            CalculatingTotalBalances(false);
        }
        public void FormatDatagridview(DataGridView DesiredDataGrid, bool IsProfile)
        {
            foreach (DataGridViewColumn col in DesiredDataGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            DesiredDataGrid.Columns["ID"].Visible = false;
            DesiredDataGrid.Columns["bundle_id"].Visible = false;
            DesiredDataGrid.Columns["bundle_name"].Visible = false;
            DesiredDataGrid.Columns["product_id"].Visible = false;
            DesiredDataGrid.Columns["purchase_date"].Visible = false;
            DesiredDataGrid.Columns["original_offre"].Visible = false;
            DesiredDataGrid.Columns["offre"].Visible = false;
            DesiredDataGrid.Columns["amount_paid"].Visible = false;
            DesiredDataGrid.Columns["balance"].Visible = false;
            DesiredDataGrid.Columns["session_left_days"].Visible = false;
            DesiredDataGrid.Columns["due_date"].Visible = false;
            DesiredDataGrid.Columns["is_freezed"].Visible = false;
            DesiredDataGrid.Columns["is_expired"].Visible = false;
            DesiredDataGrid.Columns["Currency_Name"].Visible = false;
            DesiredDataGrid.Columns["Symbol"].Visible = false;
            DesiredDataGrid.Columns["DueDate"].Visible = false;

            if (IsProfile)
            {
                DesiredDataGrid.Columns["PayOrEdit"].DisplayIndex = DesiredDataGrid.ColumnCount - 2;
                DesiredDataGrid.Columns["BackOffice"].DisplayIndex = DesiredDataGrid.ColumnCount - 1;
            }

            ///

            DesiredDataGrid.Columns["AutoIncrementColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DesiredDataGrid.Columns["Description"].FillWeight = 13;
            DesiredDataGrid.Columns["Purchase date"].FillWeight = 20;
            DesiredDataGrid.Columns["FakeOrignalOffre"].FillWeight = 17;
            DesiredDataGrid.Columns["FakeOffer"].FillWeight = 17;
            DesiredDataGrid.Columns["Paid"].FillWeight = 9;
            DesiredDataGrid.Columns["FakeBalance"].FillWeight = 12;
            DesiredDataGrid.Columns["DueDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //
            DesiredDataGrid.Columns["FakeBalance"].HeaderText = "Balance";
            DesiredDataGrid.Columns["AutoIncrementColumn"].HeaderText = "ID";
            DesiredDataGrid.Columns["FakeOrignalOffre"].HeaderText = "Offre";
            DesiredDataGrid.Columns["FakeOffer"].HeaderText = "Deal";



        }
        public void FormatDatagridviewDesign()
        {

            foreach (DataGridViewRow row in dataGridViewBalance.Rows)
            {
                DataGridViewCell cell = (DataGridViewCell)row.Cells["FakeBalance"];
                if (Convert.ToString(cell.Value) != "$0")
                {
                    cell.Style.ForeColor = Color.Red;
                    cell.Style.SelectionForeColor = Color.Red;
                }
                else
                {
                    cell.Style.ForeColor = Color.Black;
                    cell.Style.SelectionForeColor = Color.Black;
                }

                DataGridViewCell cell1 = (DataGridViewCell)row.Cells["PayOrEdit"];
                if (Convert.ToBoolean(row.Cells["is_expired"].Value) == false)
                {
                    cell1.Value = PayOrEditImage;
                }
                else
                {
                    cell1.Value = EmptyImage;
                }


                DataGridViewCell cell2 = (DataGridViewCell)row.Cells["BackOffice"];
                cell2.Value = BackOfficeImage;
            }
            dataGridViewBalance.ClearSelection();
        }
        //it wont work , lieanno on mousehover aam tetezii
        private void dataGridViewBalance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //DataGridViewCell cell = dataGridViewBalance.Rows[e.RowIndex].Cells[e.ColumnIndex];

            //if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Assuming "balance" is the name of your balance column
            //{
            //    DataGridViewCell CellToModifie;

            //    if (e.ColumnIndex == dataGridViewBalance.Columns["FakeBalance"].Index)
            //    {
            //        CellToModifie = dataGridViewBalance.Rows[e.RowIndex].Cells["FakeBalance"];
            //        if (Convert.ToString(CellToModifie.Value) != "$0")
            //        {
            //            CellToModifie.Style.ForeColor = Color.Red;
            //            CellToModifie.Style.SelectionForeColor = Color.Red;
            //        }
            //        else
            //        {
            //            CellToModifie.Style.ForeColor = Color.Black;
            //            CellToModifie.Style.SelectionForeColor = Color.Black;
            //        }
            //    }

            //    if (e.ColumnIndex == dataGridViewBalance.Columns["PayOrEdit"].Index)
            //    {
            //        CellToModifie= dataGridViewBalance.Rows[e.RowIndex].Cells["PayOrEdit"];
            //        if (Convert.ToBoolean(dataGridViewBalance.Rows[e.RowIndex].Cells["is_expired"].Value) == false)
            //        {
            //            CellToModifie.Value = PayOrEditImage;
            //        }
            //        else
            //        {
            //            CellToModifie.Value = EmptyImage;
            //        }
            //    }

            //    if (e.ColumnIndex == dataGridViewBalance.Columns["BackOffice"].Index)
            //    {
            //        CellToModifie = dataGridViewBalance.Rows[e.RowIndex].Cells["BackOffice"];
            //        CellToModifie.Value = BackOfficeImage;
            //    }
            //}
        }
        //public static void ResortOriginalDataTable(DataTable Desireddt)//MAFINA!!! gher nebaat el datatbale as argument because we re losing the reference, still dk why
        //{

        //    DataView sortedView = Desireddt.DefaultView;

        //    sortedView.Sort = "is_expired ASC,purchase_date DESC";
        //    Desireddt = sortedView.ToTable(); // Reassigning dt here, which should still work
        //    Desireddt.PrimaryKey = new DataColumn[] { Desireddt.Columns["ID"] };

        //}
        //methode 2
        public void ResortOriginalDataTableAndSetDatasource()
        {
            DataView sortedView = dtClientBalanceOriginal.DefaultView;
            sortedView.Sort = "is_expired ASC,purchase_date DESC";

            dtClientBalanceOriginal = sortedView.ToTable();

            dtClientBalanceOriginal.PrimaryKey = new DataColumn[] { dtClientBalanceOriginal.Columns["ID"] };//since sarit new table w need to reassing el priimary key

            dataGridViewBalance.DataSource = dtClientBalanceOriginal;  //el data source will disconnect aan el dtoriginal,lieanno ghayarna el instance, that s why we reassign it

        }

        private void dataGridViewBalance_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridViewBalance.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Check if the cell is in the "ActionAttendance" column
                if (cell.OwningColumn.Name == "PayOrEdit")
                {
                    if (cell.Value == PayOrEditImage)
                    {
                        cell.Value = PayOrEditImagePopUp;
                    }

                }
                else if (cell.OwningColumn.Name == "BackOffice")
                {
                    cell.Value = BackOfficeImagePopUp;
                }

            }
        }
        private void dataGridViewBalance_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridViewBalance.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Check if the cell is in the "ActionAttendance" column
                if (cell.OwningColumn.Name == "PayOrEdit")
                {
                    if (cell.Value == PayOrEditImagePopUp)
                    {
                        cell.Value = PayOrEditImage;
                    }
                }
                else if (cell.OwningColumn.Name == "BackOffice")
                {
                    cell.Value = BackOfficeImage;
                }
            }
        }




        public void CalculatingClientHistory(bool UpdateMode)
        {
            //logic started
            int TokenBundles = 0;
            double BundlePayments = 0;
            int TokenProducts = 0;
            double ProductPayments = 0;
            double TotalPayment;

            foreach (DataRow row in dtClientBalanceOriginal.Rows)
            {
                if (row["bundle_id"] != DBNull.Value)
                {
                    TokenBundles++;
                    BundlePayments += (double)row["amount_paid"];
                }
                else if (row["product_id"] != DBNull.Value)
                {
                    TokenProducts++;
                    ProductPayments += (double)row["amount_paid"];
                }
            }


            TotalPayment = ProductPayments + BundlePayments;
            //logic Ended

            //SQL
            if (UpdateMode)//lieanno fi matarih men kun aam naamil update la sql men gher matrah
            {
                ClassClient.UpdateClientTotalPaymentSQL((int)Client.ClientId, TotalPayment);
            }

            //design
            Client.TotalPayment = TotalPayment;
            UCpaymentsTotal.Detail = Currency.Symbol + Convert.ToString(TotalPayment);
            UCTokenServices.Detail = Convert.ToString(TokenBundles);
            UCpaymentsServices.Detail = Currency.Symbol + Convert.ToString(BundlePayments);
            UCTokenProducts.Detail = Convert.ToString(TokenProducts);
            UCpaymentsProducts.Detail = Currency.Symbol + Convert.ToString(ProductPayments);
        }//try catch
        public void CalculatingTotalBalances(bool UpdateMode)
        {
            double bundleBalance = 0;
            double ProductBalance = 0;
            foreach (DataRow d in dtClientBalanceOriginal.Rows)
            {

                if (d["product_id"] != DBNull.Value)
                {
                    ProductBalance += Convert.ToDouble(d["balance"]);

                }
                else
                {
                    bundleBalance += Convert.ToDouble(d["balance"]);
                }
            }
            TotalBalanceAmount = bundleBalance + ProductBalance;

            //SQL
            if (UpdateMode)//lieanno fi matarih men kun aam naamil update la sql men gher matrah
            {
                ClassClient.UpdateClientTotalBalanceSQL((int)Client.ClientId, TotalBalanceAmount);//hayde kermel el table el client el asesie

            }

            //Design 
            Client.TotalBalance = TotalBalanceAmount;

            if (Math.Abs(bundleBalance) != 0)
            {
                labelServiceBalance.Text = "-" + Currency.Symbol + Math.Abs(bundleBalance).ToString();
                labelServiceBalance.ForeColor = Color.Red;
            }
            else
            {
                labelServiceBalance.Text = Currency.Symbol + Math.Abs(bundleBalance).ToString();
                labelServiceBalance.ForeColor = Color.Black;
            }



            if (Math.Abs(ProductBalance) != 0)
            {
                labelProductBalance.Text = "-" + Currency.Symbol + Math.Abs(ProductBalance).ToString();
                labelProductBalance.ForeColor = Color.Red;
            }
            else
            {
                labelProductBalance.Text = Currency.Symbol + Math.Abs(ProductBalance).ToString();
                labelProductBalance.ForeColor = Color.Black;
            }




            if (Math.Abs(TotalBalanceAmount) != 0)
            {
                labelTotalBalance.Text = "-" + Currency.Symbol + Math.Abs(TotalBalanceAmount).ToString();
                labelTotalBalance.ForeColor = Color.Red;
                buttonPayTotalBalance.Enabled = true;
            }
            else
            {
                labelTotalBalance.Text = Currency.Symbol + Math.Abs(TotalBalanceAmount).ToString();
                labelTotalBalance.ForeColor = Color.Black;
                buttonPayTotalBalance.Enabled = false;
            }


        }//try catch


        bool CreateDesiredUCLabelDetails(ref UCLabelAndDetail DesiredUC, string type, string detail, bool isVisible, int DesignIndex)//the details will be send formated
        {
            bool NewUCCreated = false;
            if (isVisible)
            {
                if (DesiredUC == null)
                {
                    NewUCCreated = true;
                    DesiredUC = new UCLabelAndDetail();
                    DesiredUC.SetDesign();
                    DesiredUC.Index = Convert.ToInt32(DesignIndex);
                    DesiredUC.Type = type;

                    panelSecondaryInfo.Controls.Add(DesiredUC);
                }

                if (detail != null)
                {
                    DesiredUC.Detail = detail;
                }
                else
                {
                    DesiredUC.Detail = NotAvailableText;
                }


            }
            else
            {
                if (DesiredUC != null)
                {
                    this.Controls.Remove(DesiredUC);
                    DesiredUC.Dispose();
                    DesiredUC = null;
                }
            }

            return NewUCCreated;
        }
        public void UpdateOrCreateUCLabelAndDetail(bool IsUpdateOrCreate)
        {
            //primary info
            //name
            string Name;

            if (Client.Fname != null && Client.Lname != null)
            {
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Client.Fname) + " " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Client.Lname);
            }
            else
            {
                Name = NotAvailableText;
            }

            string AdultOrChildOrParent = "";
            if (Client.IsChild)
            {
                AdultOrChildOrParent = "(Child)";
            }
            else
            {

                if (Client.IsParent)
                {
                    AdultOrChildOrParent = "(Adult/Parent)";
                }
                else
                {
                    AdultOrChildOrParent = "(Adult)";
                }
            }

            labelName.Text = Name + AdultOrChildOrParent;

            if (!IsUpdateOrCreate)
            {
                //LastVisit
                if (Client.LastVisit != null)
                {
                    UCLastVisit.Detail = RandomFunctions.SetDateFormat(Convert.ToString(Client.LastVisit));
                }
                else
                {
                    UCLastVisit.Detail = NotAvailableText;
                }
                //RegistrationDate
                if (Client.RegistrationDate != null)
                {
                    string regdate = RandomFunctions.SetDateFormat(Convert.ToString(Client.RegistrationDate));
                    UCMemberSince.Detail = regdate;
                }
                else
                {
                    UCMemberSince.Detail = NotAvailableText;
                }
                //album
                UpdateAlbum();
            }

            //seocndary info
            bool NewUCCreated = false;
            DataTable dt = SQLToProject.GetAllVisibleFields();
            foreach (DataRow row in dt.Rows)
            {
                bool isVisible = Convert.ToBoolean(row["Visible"]);
                int DesignIndex = Convert.ToInt16(row["design_index"]);
                string FieldName = row["Fields"].ToString();


                if (FieldName == ClassClient.enumType.FaceImage.ToString())
                {

                    if (isVisible)
                    {

                        if (Client.ProfileImage != null)
                        {

                            iconButtonImage.BackgroundImage = Client.ProfileImage;
                            NewUCCreated = true;
                        }
                        else
                        {
                            iconButtonImage.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "user1.png");
                        }
                    }
                    else
                    {
                        iconButtonImage.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "user1.png");
                    }

                }
                else if (FieldName == ClassClient.enumType.PhoneNumber.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCPhoneNumber, ClassClient.enumType.PhoneNumber.GetStringValue(), Client.PhoneNumber, isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.Gender.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCGender, ClassClient.enumType.Gender.GetStringValue(), Client.Gender, isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.Job.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCJob, ClassClient.enumType.Job.GetStringValue(), Client.Job, isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.Adress.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCAdress, ClassClient.enumType.Adress.GetStringValue(), Client.Adress, isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.InstaUserName.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCInsta, ClassClient.enumType.InstaUserName.GetStringValue(), Client.InstaUserName, isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.BirthDate.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCBirthday, ClassClient.enumType.BirthDate.GetStringValue(), RandomFunctions.SetDateFormat(Convert.ToString(Client.BirthDate)), isVisible, DesignIndex);

                    string Details = Client.Age != null ? Convert.ToString(Client.Age) : null;//staamelneha cz eena convertion, w bel convertionn el null bet ruh
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCAge, ClassClient.enumType.Age.GetStringValue(), Details, isVisible, DesignIndex);

                }
                else if (FieldName == ClassClient.enumType.Email.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCEmail, ClassClient.enumType.Email.GetStringValue(), Client.Email, isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.MaritalStatus.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCMaritalStatus, ClassClient.enumType.MaritalStatus.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.MaritalStatus), isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.HowDidYouKnowAboutUs.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCKnowAboutUs, ClassClient.enumType.HowDidYouKnowAboutUs.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.KnowAboutUs), isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.Note.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCNote, ClassClient.enumType.Note.GetStringValue(), Client.Note, isVisible, DesignIndex);
                }
                //custom 
                else if (FieldName == ClassClient.enumType.Height.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCHeight, ClassClient.enumType.Height.GetStringValue(), RandomFunctions.SetStringFormatSpaceInsteadOflash(Client.Height), isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.Weight.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCWeight, ClassClient.enumType.Weight.GetStringValue(), RandomFunctions.SetStringFormatSpaceInsteadOflash(Client.Weight), isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.BodyShapeTarget.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCShapeTarget, ClassClient.enumType.BodyShapeTarget.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.BodyShapeTarget), isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.MuscleFocusOn.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCMuscleFocusOn, ClassClient.enumType.MuscleFocusOn.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.MuscleFocusOn), isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.Injuries.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCInjuries, ClassClient.enumType.Injuries.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.Injuries), isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.Hand.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCHand, ClassClient.enumType.Hand.GetStringValue(), Client.Hand, isVisible, DesignIndex);
                }

                else if (FieldName == ClassClient.enumType.SessionPerWeek.ToString())
                {
                    string Details = Client.SessionPerWeek != null ? Convert.ToString(Client.SessionPerWeek) : null;//staamelneha cz eena convertion, w bel convertionn el null bet ruh
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCSessionPerWeek, ClassClient.enumType.SessionPerWeek.GetStringValue(), RandomFunctions.SetStringFullFormat(Details), isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.GoalsTimeline.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCGoalsTimeline, ClassClient.enumType.GoalsTimeline.GetStringValue(), RandomFunctions.SetStringFormatSpaceInsteadOflash(Client.GoalsTimeline), isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.Smoking.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCSmoking, ClassClient.enumType.Smoking.GetStringValue(), Client.Smoking, isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.Alcohol.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCAlcohol, ClassClient.enumType.Alcohol.GetStringValue(), Client.Alcohol, isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.ExerciseHistory.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCExerciseHistory, ClassClient.enumType.ExerciseHistory.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.ExerciseHistory), isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.SleepPattern.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCSleepPattern, ClassClient.enumType.SleepPattern.GetStringValue(), RandomFunctions.SetStringFormatSpaceInsteadOflash(Client.SleepPattern), isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.StressLevel.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCStressLevel, ClassClient.enumType.StressLevel.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.StressLevel), isVisible, DesignIndex);
                }
                else if (FieldName == ClassClient.enumType.BoxingSkills.ToString())
                {
                    NewUCCreated = CreateDesiredUCLabelDetails(ref UCBoxingSkills, ClassClient.enumType.BoxingSkills.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.FightingSkills), isVisible, DesignIndex);
                }
            }

            if (NewUCCreated)
                ResetIndex();

            if (!IsUpdateOrCreate)
            {
                CalculatingClientHistory(false);
                UCTotalAttendance.Detail = Convert.ToString(Client.TotalAttendance);
            }
            CreateOrUpdateLinkChild();//in case sar chile
        }
        public void UpdateAlbum()
        {
            if (Client.AlbumType != null)
                UCAlbum.Detail = Client.AlbumType;
            else
                UCAlbum.Detail = NotAvailableText;
        }
        private void ResetIndex()
        {

            List<UCLabelAndDetail> ucList = new List<UCLabelAndDetail>();

            foreach (Control control in panelSecondaryInfo.Controls)
            {
                if (control is UCLabelAndDetail ucLabelAndDetail)
                {
                    if (ucLabelAndDetail.Name != "UCAge")//kermel la2n ucage 3enda nafsel index taba3 ucbirthday, so men zida ekhir shi
                    {
                        ucList.Add(ucLabelAndDetail);
                    }
                }
            }

            ucList.Sort((x, y) => y.Index.CompareTo(x.Index)); // Reverse the sorting order

            int i = 0;
            // Add the sorted UCLabelAndDetail controls to the panel
            foreach (var ucLabelAndDetail in ucList)
            {
                panelSecondaryInfo.Controls.SetChildIndex(ucLabelAndDetail, i);
                i++;
            }
            if (UCBirthday != null)
            {
                panelSecondaryInfo.Controls.SetChildIndex(UCAge, panelSecondaryInfo.Controls.IndexOf(UCBirthday) + 1);
            }
        }
        public void AutosizeUCLabel()
        {
            //el album autosize ma aam tozbt w shi ktir illogic
            if (TLPLinked != null)
            {
                UCLabelAndDetail uCLabelAndDetail = (UCLabelAndDetail)(TLPLinked.GetControlFromPosition(0, 0));
                uCLabelAndDetail.CheckSize(uCLabelAndDetail.labelType.Width, uCLabelAndDetail.labelDetail.Width);
                TLPLinked.Size = uCLabelAndDetail.Size;
            }


            foreach (Control control in panelPrimaryInfo.Controls)
            {
                if (control is UCLabelAndDetail)
                {
                    ((UCLabelAndDetail)control).CheckSize(((UCLabelAndDetail)control).labelType.Width, ((UCLabelAndDetail)control).labelDetail.Width);

                }
            }
            foreach (UCLabelAndDetail uCLabelAndDetail in panelSecondaryInfo.Controls)
            {
                uCLabelAndDetail.CheckSize(uCLabelAndDetail.labelType.Width, uCLabelAndDetail.labelDetail.Width);
            }
            foreach (UCLabelAndDetail uCLabelAndDetail in TLPHistory.Controls)
            {
                uCLabelAndDetail.CheckSize(uCLabelAndDetail.labelType.Width, uCLabelAndDetail.labelDetail.Width);
            }
        }





        public void UpdateIsInDebteToUCBundle(int BundelID, bool isindebt)
        {
            foreach (UCBundlePackage uc in panelBundles.Controls)
            {
                if (uc.Id == BundelID)
                {
                    uc.IsInDebt = isindebt;
                }
            }
        }
        public void ResetUCMode(int BundelID, int SessionNumber, DateTime? NewDueDate)
        {
            foreach (UCBundlePackage uc in panelBundles.Controls)
            {
                if (uc.Id == BundelID)
                {
                    uc.SessionDaysLeft = SessionNumber;
                    if (NewDueDate != null)//days mode
                    {
                        uc.DueDate = NewDueDate;
                    }
                }
            }
        }
        public void DeleteUcPackage(int BundelID)
        {

            foreach (UCBundlePackage uc in panelBundles.Controls)
            {
                if (uc.Id == BundelID)
                {
                    uc.Dispose();
                }
            }


            CheckAndSetNoBundleLabel();

        }




        //this section is for the design handling tabaa el bundles
        //aam nshuf eza eena at least one bundle ta naarif shu naamil bel design
        public bool CheckIfBundleExist()
        {
            foreach (DataRow dr in dtClientBalanceOriginal.Rows)
            {
                if (dr["bundle_id"] != DBNull.Value && dr["session_left_days"] != DBNull.Value && Convert.ToBoolean(dr["is_expired"]) == false)//first condition kermel ykun package ejbare

                {
                    return true;

                }
            }
            return false;
        }
        //kermel estaamle bel new register, eza el cujstomer is saved or saved and pay session
        public void ClearAndInsertPanel()
        {
            int rowIndex = 1; // Replace with the desired row index
            int colIndex = 0; // Replace with the desired column index

            Control controlToRemove = TLPdatagrid.GetControlFromPosition(colIndex, rowIndex);
            if (controlToRemove != null)
            {
                TLPdatagrid.Controls.Remove(controlToRemove);
                controlToRemove.Dispose(); // Optional, if you want to dispose of the removed control
            }

            CreatePanelUCBundle();

        }
        //used only awwal ma nekhlae el form
        public void InitialSetBundleMode()
        {
            int rowIndex = 1; // Replace with the desired row index
            int colIndex = 0; // Replace with the desired column index

            Control controlToRemove = TLPdatagrid.GetControlFromPosition(colIndex, rowIndex);
            if (controlToRemove != null)
            {
                TLPdatagrid.Controls.Remove(controlToRemove);
                controlToRemove.Dispose(); // Optional, if you want to dispose of the removed control
            }





            if (CheckIfBundleExist())
            {
                CreatePanelUCBundle();

                for (int i = dtClientBalanceOriginal.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow DesiredRow = dtClientBalanceOriginal.Rows[i];
                    if (DesiredRow["bundle_id"] != DBNull.Value && DesiredRow["session_left_days"] != DBNull.Value && Convert.ToBoolean(DesiredRow["is_expired"]) == false)//since we have a condition on session left, which mean we re talking abt bundles or session nor products
                    {
                        CreateUCPackage(DesiredRow);
                    }
                }

            }

            else
            {
                TLPdatagrid.Controls.Add(GetNoBundleLable("No packages have been assigned"), 0, 1);
            }

        }
        //used for design updates, matrah el bundles
        public void CheckAndSetNoBundleLabel()
        {
            int rowIndex = 1; // Replace with the desired row index
            int colIndex = 0; // Replace with the desired column index
            Control controlToRemove = TLPdatagrid.GetControlFromPosition(colIndex, rowIndex);

            bool BundleExist = CheckIfBundleExist();
            if (!(controlToRemove is Label) && BundleExist == false)
            {

                TLPdatagrid.Controls.Remove(controlToRemove);//we re removing the panel for the uc
                controlToRemove.Dispose(); // Optional, if you want to dispose of the removed control

                TLPdatagrid.Controls.Add(GetNoBundleLable("No packages have been assigned"), colIndex, rowIndex);
            }
            else if ((controlToRemove is Label) && BundleExist == true)
            {

                TLPdatagrid.Controls.Remove(controlToRemove);//we re removing the panel for the uc
                controlToRemove.Dispose(); // Optional, if you want to dispose of the removed control
                CreatePanelUCBundle();
            }

        }
        void CreatePanelUCBundle()
        {
            panelBundles = new Panel();
            panelBundles.Dock = DockStyle.Fill;
            panelBundles.AutoScroll = true;
            panelBundles.Margin = new Padding(5);
            panelBundles.Padding = new Padding(10, 7, 10, 7);
            panelBundles.BackColor = Color.FromArgb(238, 241, 254);
            TLPdatagrid.Controls.Add(panelBundles, 0, 1);
        }
        public void CreateUCPackage(DataRow DesiredRow)
        {

            UCBundlePackage bundlePackage = new UCBundlePackage(false, DesiredRow);
            bundlePackage.FakeId = Convert.ToInt16(DesiredRow["AutoIncrementColumn"]);
            bundlePackage.ParentFormClientMan = this;
            bundlePackage.Dock = DockStyle.Left;
            panelBundles.Controls.Add(bundlePackage);
            bundlePackage.UCMouseClick += BundlePackage_UCMouseClick;

        }

        private void BundlePackage_UCMouseClick(object sender, EventArgs e)
        {
            UCBundlePackage desiredUC = (UCBundlePackage)sender;
            for (int i = 0; i < dataGridViewBalance.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridViewBalance.Rows[i];
                if (Convert.ToInt64(row.Cells["ID"].Value) == desiredUC.Id)
                {
                    if (!dataGridViewBalance.Rows[i].Displayed)
                    {
                        dataGridViewBalance.FirstDisplayedScrollingRowIndex = row.Index;
                    }
                    row.DefaultCellStyle.BackColor = dataGridViewBalance.ColorOnMouseMove;
                    Timer timer = new Timer();
                    timer.Interval = 1000;
                    timer.Tick += (timerSender, timerEventArgs) =>
                    {
                        row.DefaultCellStyle.BackColor = dataGridViewBalance.ColorDefault;
                        timer.Stop();
                        timer.Dispose();
                    };
                    timer.Start();
                    break;
                }
            }
        }

        public Label GetNoBundleLable(string Text)//in case we had no bundles
        {
            Label labelNoBundles = new Label();
            labelNoBundles.AutoSize = false;
            labelNoBundles.Dock = DockStyle.Fill;
            labelNoBundles.TextAlign = ContentAlignment.MiddleCenter;
            labelNoBundles.Font = new Font("Segoe UI Semibold", 20.25f, FontStyle.Bold);
            labelNoBundles.BackColor = Color.FromArgb(238, 241, 254);
            labelNoBundles.ForeColor = Color.FromArgb(150, 150, 150);
            labelNoBundles.Text = Text;
            return labelNoBundles;
        }

        //Design Handling,used in the datagridview location






        //desired row is in case of editing one row
        public DataTable RetrievingSpecificRowsInDt(bool IsTotalBalance, int? ClientBalanceId)
        {
            if (IsTotalBalance && ClientBalanceId == null)
            {
                DataTable dtClientBalanceCopy = dtClientBalanceOriginal.Copy();//copry stucture +data

                for (int i = dtClientBalanceCopy.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow d = dtClientBalanceCopy.Rows[i];
                    if (Convert.ToDouble(d["balance"].ToString()) == 0)
                    {
                        d.Delete();
                    }
                }
                dtClientBalanceCopy.AcceptChanges();
                return dtClientBalanceCopy;
            }
            else
            {
                DataRow[] rows = dtClientBalanceOriginal.Select("ID =" + ClientBalanceId);
                DataRow desiredRow = null;
                if (rows.Length > 0)
                {
                    desiredRow = rows[0];
                }
                DataTable dtClientBalanceOneRow = dtClientBalanceOriginal.Clone();//copry stucture
                dtClientBalanceOneRow.ImportRow(desiredRow);
                return dtClientBalanceOneRow;
            }

        }



        private void dataGridViewBalance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int ClientBalanceId = Convert.ToInt16(dataGridViewBalance.Rows[e.RowIndex].Cells["ID"].Value);

                if (dataGridViewBalance.Columns[e.ColumnIndex].Name == "PayOrEdit" && dataGridViewBalance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == PayOrEditImagePopUp)
                {

                    string EntetityAmount = dataGridViewBalance.Rows[e.RowIndex].Cells["Balance"].Value.ToString();
                    EntetityAmount = EntetityAmount.Replace(Currency.Symbol, "");


                    Program.GreyForm = new GreyColor((Form)this.Tag, true, IsFromSchedule);
                    Program.GreyForm.Show();
                    Payment payment = new Payment((int)Client.ClientId, Convert.ToDouble(EntetityAmount), RetrievingSpecificRowsInDt(false, ClientBalanceId), this);
                    payment.ClientManagementProfileParentForm = this;
                    payment.ShowDialog();



                }
                else if (dataGridViewBalance.Columns[e.ColumnIndex].Name == "BackOffice" && dataGridViewBalance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == BackOfficeImagePopUp)
                {
                    if (LOGIN.Employee.CanAccessTransaction)
                    {
                        Program.GreyForm = new GreyColor((Form)this.Tag, true, IsFromSchedule);
                        Program.GreyForm.Show();
                        BackOffice backOffice = new BackOffice(this, ClientBalanceId, RetrievingSpecificRowsInDt(false, ClientBalanceId), null);
                        backOffice.ShowDialog();
                    }
                    else
                    {
                        CustomMessageBox.Show("You don't have access", CustomMessageBox.Type.Ok);
                    }

                }
                else
                {
                    if (dataGridViewBalance.Rows[e.RowIndex].Cells["session_left_days"].Value != DBNull.Value && Convert.ToBoolean(dataGridViewBalance.Rows[e.RowIndex].Cells["is_expired"].Value) == false)//package 
                    {
                        if (panelBundles != null)
                        {
                            foreach (UCBundlePackage uc in panelBundles.Controls)
                            {
                                if (uc.Id == Convert.ToInt64(dataGridViewBalance.Rows[e.RowIndex].Cells["ID"].Value))
                                {
                                    uc.Focus();
                                    panelBundles.ScrollControlIntoView(uc);
                                    uc.TLPglobal.BackColor = uc.ColorMouseOver;
                                    Timer timer = new Timer();
                                    timer.Interval = 1000;
                                    timer.Tick += (timerSender, timerEventArgs) =>
                                    {
                                        uc.TLPglobal.BackColor = uc.ColorDedault;
                                        timer.Stop();
                                        timer.Dispose();
                                    };
                                    timer.Start();
                                    break;
                                }
                            }
                        }

                    }
                }
            }

        }
        private void buttonPayTotalBalance_Click(object sender, EventArgs e)
        {
            Program.GreyForm = new GreyColor((Form)this.Tag, true, IsFromSchedule);
            Program.GreyForm.Show();
            Payment payment = new Payment((int)Client.ClientId, Convert.ToDouble(TotalBalanceAmount), RetrievingSpecificRowsInDt(true, null), this);
            payment.ClientManagementProfileParentForm = this;
            payment.ShowDialog();

        }
        private void buttonBackOffice_Click(object sender, EventArgs e)
        {
            if (LOGIN.Employee.CanAccessTransaction)
            {
                Program.GreyForm = new GreyColor((Form)this.Tag, true, IsFromSchedule);
                Program.GreyForm.Show();
                BackOffice backOffice = new BackOffice(this, null, null, Client.ClientId);
                backOffice.ShowDialog();
            }
            else
            {
                CustomMessageBox.Show("You don't have access", CustomMessageBox.Type.Ok);
            }

        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (Program.GreyForm == null)
            {
                Program.GreyForm = new GreyColor((Form)this.Tag, true, IsFromSchedule);
                Program.GreyForm.Show();
                BuyBundleOrProudct BuyServiceOrProudct = new BuyBundleOrProudct(false);//true becuase it s a bundle
                BuyServiceOrProudct.ParentFormClientMang = this;
                BuyServiceOrProudct.Show();
            }

        }
        private void buttonAddPAckge_Click(object sender, EventArgs e)
        {
            if (Program.GreyForm == null)
            {
                Program.GreyForm = new GreyColor((Form)this.Tag, true, IsFromSchedule);
                Program.GreyForm.Show();
                BuyBundleOrProudct BuyServiceOrProudct = new BuyBundleOrProudct(true);//true becuase it s a product
                BuyServiceOrProudct.ParentFormClientMang = this;
                BuyServiceOrProudct.Show();
            }

        }


        private void buttonEditClientInfo_Click(object sender, EventArgs e)
        {

            Program.GreyForm = new GreyColor((Form)this.Tag, false, IsFromSchedule);//cz aam t3alie w ma tsakkir el form
            Program.GreyForm.Show();

            if (Program.NewRegisterForm == null)
            {
                Program.NewRegisterForm = new NewRegister(Client, null);
            }
            else
            {
                Program.NewRegisterForm.Resetcontrols();
                Program.NewRegisterForm.LoadForm(Client, null);
            }

            Program.NewRegisterForm.ClientManagementProfileForm = this;
            Program.NewRegisterForm.ShowDialog();
            if (IsClientDeleted)
            {
                ((Home)this.Tag).buttonBackHome_Click(null, EventArgs.Empty);
            }
        }

        private void buttonEditAlbum_Click(object sender, EventArgs e)
        {
            if (Program.GreyForm == null)
            {
                Program.GreyForm = new GreyColor((Form)this.Tag, true, IsFromSchedule);
                Program.GreyForm.Show();
                Album s = new Album(null);
                s.ClientManagementProfileForm = this;
                s.ShowDialog();
            }

        }

        private void iconButtonImage_Click(object sender, EventArgs e)
        {
            if (Client.ProfileImage != null)
            {
                Program.GreyForm = new GreyColor((Form)this.Tag, true, IsFromSchedule);
                Program.GreyForm.Show();
                ImageForm i = new ImageForm(Client.ProfileImage);
                i.Show();
            }

        }



        //kermel el payment w el backoffice forms
        //if date is null yaane undo men back office, eza lae yaane paymen, //w el ref bas ela aaze bel payment
        public void UpdateBalance(DataTable DesiredRowsdt, double ToBalance, ref double FromBalance, DateTime? Date)//date is not null coming from backoofice
        {

            //can implement try catch
            int ClientBalanceID = (int)DesiredRowsdt.Rows[0]["ID"];
            double BalanceAmount = (double)DesiredRowsdt.Rows[0]["balance"];
            string CurrencySymbol = (string)DesiredRowsdt.Rows[0]["Symbol"];
            int CategoryId;
            string BackOfficeCatName;
            string BackOfficeCatType;
            if (DesiredRowsdt.Rows[0]["product_id"] != DBNull.Value)//product
            {
                CategoryId = (int)DesiredRowsdt.Rows[0]["product_id"];
                BackOfficeCatName = ClassProduct.FindProductName(CategoryId);
                BackOfficeCatType = "";
            }
            else
            {
                CategoryId = (int)DesiredRowsdt.Rows[0]["bundle_id"];
                BackOfficeCatName = ClassBundles.FindBundleName(CategoryId);
                BackOfficeCatType = "Bundle";
            }

            //////Calculations started
            Double DifferenceBetweenToFrom;
            DifferenceBetweenToFrom = (ToBalance - FromBalance);//since ToBalance is my target, so if frombalance=-100 & tobalance=-50, diff=+50, which means zedtello 50 aal balance,yaane eetito masare


            string UpdatedBalance = Convert.ToString(BalanceAmount + DifferenceBetweenToFrom);



            //updating theoffre in the datatgridview's PAyment Form
            string UpdatedOffre = DesiredRowsdt.Rows[0]["offre"].ToString();
            double offrePrice;
            string OffreScdPart = null;
            if (UpdatedOffre.Contains('/'))//bundles and sessions
            {
                offrePrice = Convert.ToDouble(DesiredRowsdt.Rows[0]["offre"].ToString().Split('/')[0]);
                OffreScdPart = DesiredRowsdt.Rows[0]["offre"].ToString().Split('/')[1];
            }
            else//products
            {
                offrePrice = Convert.ToDouble(DesiredRowsdt.Rows[0]["offre"]);
            }

            offrePrice -= DifferenceBetweenToFrom;//eza ken el offre offre 300 w el diff hiyye +50, yaane ana eemltello 50 discount,offre=250


            if (OffreScdPart != null)
            {
                UpdatedOffre = offrePrice + "/" + OffreScdPart;
            }
            else
            {
                UpdatedOffre = offrePrice.ToString();
            }

            bool OldIsExpired = (bool)DesiredRowsdt.Rows[0]["is_expired"];
            bool NewIsExpired = OldIsExpired;//default value it s going to be used just in case eit was a bundle w feytin men el paymen aam naamil update, ma men ghayyir el expire tabaao , cz we click remove la nghayra haydik
            if (DesiredRowsdt.Rows[0]["product_id"] != DBNull.Value || (DesiredRowsdt.Rows[0]["bundle_id"] != DBNull.Value && DesiredRowsdt.Rows[0]["session_left_days"] == DBNull.Value))//product or solo
            {
                if (Convert.ToDouble(UpdatedBalance) == 0)
                {
                    NewIsExpired = true;// cz only el product could be expired by changing its balance
                }
                else
                {
                    NewIsExpired = false;
                }
            }
            else//package
            {
                if (Date == null)//it means coming from backoffice ,ma mnelaab bel expiry eza ken aam naadil men el payment lieanno el bundle ha ykun already mawjud, we only change the expire by clicking remove
                {
                    if (OldIsExpired == true && (Convert.ToDouble(UpdatedBalance) != 0 || (int)DesiredRowsdt.Rows[0]["session_left_days"] > 0))//only in this case men ghayyir el expiry date tabaa el bundle , eza aam naamil undo la shi w huwwe already ken expired
                    {
                        NewIsExpired = false;
                    }

                }
            }
            //Calculations ended

            //SqlUpdate        
            ProjectToSQL.UpdateClientBalanceOnEditingOffre(ClientBalanceID, UpdatedOffre, Convert.ToDouble(UpdatedBalance), NewIsExpired);
            //back office, ejbare  abel ma nghayyir el initialbalance
            if (Date != null)//yaane payment form
            {
                string Discount = Convert.ToString(DifferenceBetweenToFrom * -1);//leh hone aam nehke bundle side, yaane eza zedtello 50 aal balance tabaao, means eemeltello bundle discount 50
                if (Discount.Contains('-'))
                {
                    Discount = Discount.Substring(1);
                    Discount = CurrencySymbol + Discount + " Discount";

                }
                else
                {
                    Discount = CurrencySymbol + Discount + " Addition";
                }
                ClassBackOffice backOffice = new ClassBackOffice((int)Client.ClientId, "Received an offer on the " + BackOfficeCatName + " " + BackOfficeCatType + ":" + Currency.Symbol + Math.Abs(FromBalance) + "->" + Currency.Symbol + Math.Abs(ToBalance) + " (" + Discount + ")" + ".", ActionsEnum.Offers, LOGIN.Employee.EmployeeId, ClientBalanceID, null, null, true, FromBalance + "/" + ToBalance, (DateTime)Date);
                backOffice.InsertToArchiveSQL();

            }


            //Design
            //datagrid payment form
            DesiredRowsdt.Rows[0]["balance"] = UpdatedBalance;
            DesiredRowsdt.Rows[0]["FakeBalance"] = ClassChosenClientBalance.SetBalanceFormat(UpdatedBalance); ;
            DesiredRowsdt.Rows[0]["offre"] = UpdatedOffre;
            DesiredRowsdt.Rows[0]["FakeOffer"] = CurrencySymbol + UpdatedOffre;
            DesiredRowsdt.Rows[0]["is_expired"] = NewIsExpired;

            ///datagridgrid profile form
            DataRow rowToEdit = dtClientBalanceOriginal.Rows.Find(ClientBalanceID);
            rowToEdit["offre"] = DesiredRowsdt.Rows[0]["offre"];
            rowToEdit["FakeOffer"] = DesiredRowsdt.Rows[0]["FakeOffer"];
            rowToEdit["balance"] = DesiredRowsdt.Rows[0]["balance"];
            rowToEdit["FakeBalance"] = DesiredRowsdt.Rows[0]["FakeBalance"];
            rowToEdit["is_expired"] = DesiredRowsdt.Rows[0]["is_expired"];

            //IsExpired State

            if (DesiredRowsdt.Rows[0]["product_id"] != DBNull.Value || (DesiredRowsdt.Rows[0]["bundle_id"] != DBNull.Value && DesiredRowsdt.Rows[0]["session_left_days"] == DBNull.Value))//produt or solo
            {
                if ((FromBalance != 0 && UpdatedBalance == "0") || (FromBalance == 0 && UpdatedBalance != "0"))//cz only in these 2 case the expiry date is changed
                {
                    ResortOriginalDataTableAndSetDatasource();
                }
            }

            else//if it is  pakcage, bghayyir el state tabaa el bundle w bsir edir aamello Isexpired=false by clicking remove 
            {
                if (OldIsExpired == true && NewIsExpired == false)
                {
                    //Add UCbundle
                    CheckAndSetNoBundleLabel();
                    CreateUCPackage(rowToEdit);
                }
                else if (FromBalance != 0 && UpdatedBalance == "0")
                {
                    UpdateIsInDebteToUCBundle(Convert.ToInt16(ClientBalanceID), false);
                }
                else if (FromBalance == 0 && UpdatedBalance != "0")
                {
                    UpdateIsInDebteToUCBundle(Convert.ToInt16(ClientBalanceID), true);
                }
            }

            FormatDatagridviewDesign();
            dataGridViewBalance.FirstDisplayedScrollingRowIndex = 0;
            CalculatingTotalBalances(true);
            //
            FromBalance = ToBalance;//in order to reset it for coming updates when we still in payment form
        }//try catch
         //if date is null yaane undo men back office, eza lae yaane paymen, //w el ref bas ela aaze bel payment
        public void UpdateSessionNumber(DataTable DesiredRowsdt, int ToSessionOrDays, ref int FromSessionOrDays, DateTime? Date)
        {

            //ready for try catch
            //datatable update
            int ClientBalanceID = Convert.ToInt16(DesiredRowsdt.Rows[0]["ID"]);
            int CategoryId = (int)DesiredRowsdt.Rows[0]["bundle_id"];
            string BackOfficeCatName = ClassBundles.FindBundleName(CategoryId);
            string BackOfficeCatType = "Bundle";

            //calculation has started
            DateTime? DueDate = DesiredRowsdt.Rows[0]["due_date"] is DBNull ? (DateTime?)null : (DateTime)DesiredRowsdt.Rows[0]["due_date"];//null eza sessions not days
            DateTime? NewDueDate = null;
            int DifferenceInSessionOrDaysNumber;
            int UpdatedOffreScdPart = 0;//yaane session and days


            Match match1 = Regex.Match(DesiredRowsdt.Rows[0]["offre"].ToString(), @"(\d+)\s*" + ClassBundles.Session);
            Match match2 = Regex.Match(DesiredRowsdt.Rows[0]["offre"].ToString(), @"(\d+)\s*" + ClassBundles.Days);
            if (match1.Success)
            {
                UpdatedOffreScdPart = int.Parse(match1.Groups[1].Value);
            }
            else if (match2.Success)
            {
                UpdatedOffreScdPart = int.Parse(match2.Groups[1].Value);
            }
            else
            {
                CustomMessageBox.Show("Crash!!", CustomMessageBox.Type.Ok);

            }

            DifferenceInSessionOrDaysNumber = (ToSessionOrDays - FromSessionOrDays);
            UpdatedOffreScdPart += DifferenceInSessionOrDaysNumber;


            string type;
            if (DueDate == null)
            {
                type = ClassBundles.Session;
            }
            else
            {
                type = ClassBundles.Days;
            }
            string offre = DesiredRowsdt.Rows[0]["offre"].ToString().Split('/')[0] + "/" + UpdatedOffreScdPart + " " + type;//category name should take the name of the bundle
            int UpdatedSessionLeftORNoDays;
            if (DueDate == null)//updating session left
            {
                UpdatedSessionLeftORNoDays = (int)DesiredRowsdt.Rows[0]["session_left_days"] + DifferenceInSessionOrDaysNumber;
            }
            else//update days left
            {
                UpdatedSessionLeftORNoDays = UpdatedOffreScdPart;//lieanno nehna bi hemna bel days mesh el days left as el total days li mawjud bi tene part men el offre
                NewDueDate = ((DateTime)DueDate).AddDays(DifferenceInSessionOrDaysNumber);
            }


            bool OldIsExpired = (bool)DesiredRowsdt.Rows[0]["is_expired"];
            bool NewIsExpired = OldIsExpired;//default value it s going to be used just in case eit was a bundle w feytin men el paymen aam naamil update, ma men ghayyir el expire tabaao , cz we click remove la nghayra haydik

            if (DesiredRowsdt.Rows[0]["bundle_id"] != DBNull.Value && DesiredRowsdt.Rows[0]["session_left_days"] != DBNull.Value)//package
            {
                if (Date == null)// it means coming from backoffice,ma mnelaab bel expiry eza ken aam naadil men el paymen lieanno el bundle ha ykun already mawjud, we only change the expire by clicking remove
                {
                    if (OldIsExpired == true && (Convert.ToDouble(DesiredRowsdt.Rows[0]["balance"]) != 0 || UpdatedSessionLeftORNoDays > 0))//only in this case men ghayyir el expiry date tabaa el bundle , eza aam naamil undo la shi w huwwe already ken expired
                    {

                        NewIsExpired = false;
                    }

                }
            }

            //Calculation Finished

            //SQL                     
            if (DueDate == null)
            {
                ProjectToSQL.UpdateClientBalanceOnEditingSessions(ClientBalanceID, UpdatedSessionLeftORNoDays, offre, null, NewIsExpired);
            }
            else
            {
                ProjectToSQL.UpdateClientBalanceOnEditingSessions(ClientBalanceID, UpdatedSessionLeftORNoDays, offre, (DateTime)NewDueDate, NewIsExpired);//
            }
            if (Date != null)//yaane payment form
            {
                //Backoffice
                ClassBackOffice backOffice = new ClassBackOffice((int)Client.ClientId, "Received an offer on the " + BackOfficeCatName + " " + BackOfficeCatType + ":" + FromSessionOrDays + " " + type + "->" + ToSessionOrDays + " " + type + ".", ActionsEnum.Offers, LOGIN.Employee.EmployeeId, ClientBalanceID, null, null, false, FromSessionOrDays + "/" + ToSessionOrDays, (DateTime)Date);
                backOffice.InsertToArchiveSQL();
            }


            //design
            //datatgrid Payment form
            DesiredRowsdt.Rows[0]["offre"] = offre;
            DesiredRowsdt.Rows[0]["FakeOffer"] = (string)DesiredRowsdt.Rows[0]["Symbol"] + offre;
            DesiredRowsdt.Rows[0]["is_expired"] = NewIsExpired;
            if (DueDate == null)//session bundle
            {
                DesiredRowsdt.Rows[0]["session_left_days"] = UpdatedSessionLeftORNoDays;
            }
            else//days bundle
            {
                DesiredRowsdt.Rows[0]["session_left_days"] = UpdatedSessionLeftORNoDays;
                DesiredRowsdt.Rows[0]["due_date"] = NewDueDate;
                DesiredRowsdt.Rows[0]["DueDate"] = ((DateTime)NewDueDate).ToString("MMMM/dd/yyyy");
            }
            //datagrid profile form
            DataRow rowToEdit = dtClientBalanceOriginal.Rows.Find(ClientBalanceID);
            rowToEdit["offre"] = DesiredRowsdt.Rows[0]["offre"];
            rowToEdit["FakeOffer"] = DesiredRowsdt.Rows[0]["FakeOffer"];
            rowToEdit["session_left_days"] = DesiredRowsdt.Rows[0]["session_left_days"];
            rowToEdit["due_date"] = DesiredRowsdt.Rows[0]["due_date"];
            rowToEdit["DueDate"] = DesiredRowsdt.Rows[0]["DueDate"];
            rowToEdit["is_expired"] = DesiredRowsdt.Rows[0]["is_expired"];
            FormatDatagridviewDesign();

            //Update related UC in parent form
            if (DesiredRowsdt.Rows[0]["bundle_id"] != DBNull.Value && DesiredRowsdt.Rows[0]["session_left_days"] != DBNull.Value)//bundle
            {
                if (OldIsExpired == true && NewIsExpired == false)
                {
                    //Add UCpackage
                    CheckAndSetNoBundleLabel();
                    CreateUCPackage(rowToEdit);
                }

                if (DueDate == null)// package of session
                {
                    ResetUCMode(ClientBalanceID, ToSessionOrDays, null);
                }
                else// package of days
                {
                    ResetUCMode(ClientBalanceID, ToSessionOrDays, (DateTime)NewDueDate);
                }
            }



            //lezim nzide adde session left and days left
            //
            FromSessionOrDays = ToSessionOrDays;//reset lal OldSessionNumber             

        }//try catch



        void CreateOrUpdateLinkChild()
        {

            if (Client.IsParent == true || Client.IsChild == true)
            {


                if (TLPLinked == null && ucLabelAndDetailLinked == null && iconViewOrProfile == null)
                {

                    ucLabelAndDetailLinked = new UCLabelAndDetail();
                    ucLabelAndDetailLinked.Dock = DockStyle.Fill;

                    iconViewOrProfile = new IconButton();
                    iconViewOrProfile.Anchor = AnchorStyles.None;
                    iconViewOrProfile.Size = new Size(34, 26);
                    iconViewOrProfile.Click += IconViewOrProfile_Click;
                    iconViewOrProfile.Text = "";


                    TLPLinked = new TableLayoutPanel();
                    TLPLinked.Size = new Size(296, 42);
                    TLPLinked.Margin = new Padding(0);
                    TLPLinked.Name = "TLPLinked";
                    TLPLinked.Dock = DockStyle.Top;
                    panelPrimaryInfo.Controls.Add(TLPLinked);
                    TLPLinked.BringToFront();

                    // Set column percentages
                    TLPLinked.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80));
                    TLPLinked.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                    TLPLinked.Controls.Add(ucLabelAndDetailLinked, 0, 0);
                    TLPLinked.Controls.Add(iconViewOrProfile, 1, 0);
                    //

                }
                if (Client.IsParent == true)
                {


                    iconViewOrProfile.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "view.png");
                    ucLabelAndDetailLinked.Type = "Linked Childrens";
                    ucLabelAndDetailLinked.Detail = Convert.ToString(ClassClient.CalculateNumberOfChildrenSQL(Client.PhoneNumber));

                }
                else if (Client.IsChild == true)
                {
                    DataTable dt = ClassClient.GetLinkedPArentsSQL(Client.PhoneNumber);
                    ParentIdInProfile = (int)dt.Rows[0]["client_id"];
                    iconViewOrProfile.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "userNude.png");
                    ucLabelAndDetailLinked.Type = "Linked Parent";
                    ucLabelAndDetailLinked.Detail = dt.Rows[0]["Full Name"].ToString();

                }
            }
            else
            {
                RemoveLinkedChildOrParent();
            }
        }
        void RemoveLinkedChildOrParent()
        {
            if (TLPLinked != null && ucLabelAndDetailLinked != null && iconViewOrProfile != null)
            {
                TLPLinked.Dispose();
                TLPLinked = null;
                ucLabelAndDetailLinked.Dispose();
                ucLabelAndDetailLinked = null;
                iconViewOrProfile.Dispose();
                iconViewOrProfile = null;

                panelSecondaryInfo.Controls.Remove(TLPLinked);
            }
        }
        private void IconViewOrProfile_Click(object sender, EventArgs e)
        {
            if (Client.IsParent == true)
            {

                Program.GreyForm = new GreyColor((Form)this.Tag, true, IsFromSchedule);
                Program.GreyForm.Show();
                RelatedChildrens relatedChildrens = new RelatedChildrens(Client.PhoneNumber, true, IsFromSchedule);
                relatedChildrens.ParentFormClientMang = this;
                relatedChildrens.Show();
            }
            else if (Client.IsChild == true)
            {
                if (!IsFromSchedule)
                {
                    SearchCurrentClient searchform = ((SearchCurrentClient)(((Home)(this.Tag)).menu.ActivatedForm));
                    ((Home)this.Tag).buttonBackHome_Click(null, EventArgs.Empty);//ejbare  abel FocusOnADesiredRow,lieanno inside of it aam yenaamal reset lal datatable, go check
                    searchform.FocusOnADesiredRow((int)ParentIdInProfile);//we have only one trade off, lamma naamil add parent w nerjaa aamil navigation la barra ta nabish aales, li ha ysir, bel back ha yaamil refresh la sql w yaamil filter yerjaa,w yerjaa hone ynabbish aales, eza ma le2e ha yshil el filet  wyerjaa ynabbish aale
                }
                else
                {
                    CustomMessageBox.Show("Can't Navigate unless it was from the Home Page ", CustomMessageBox.Type.Ok);
                }
            }
        }

        public void TransferInformationToSearch()
        {

            if (SearchCurrentClientform != null)//in case it was coming from search
            {

                string NotAvailable = "N/A";
                SearchCurrentClientform.Filtereddt.PrimaryKey = new DataColumn[] { SearchCurrentClientform.Filtereddt.Columns["client_id"] };//kermel el refresh 
                SearchCurrentClientform.Originaldt.PrimaryKey = new DataColumn[] { SearchCurrentClientform.Originaldt.Columns["client_id"] };//kermel el refresh 
                DataRow DesiredRowF = SearchCurrentClientform.Filtereddt.Rows.Find(Client.ClientId);
                DataRow DesiredRowO = SearchCurrentClientform.Originaldt.Rows.Find(Client.ClientId);

                if (DesiredRowF == null && DesiredRowO == null)//adding a row
                {



                    DesiredRowF = SearchCurrentClientform.Filtereddt.NewRow();
                    DesiredRowO = SearchCurrentClientform.Originaldt.NewRow();

                    DesiredRowF["client_id"] = Client.ClientId;
                    DesiredRowO["client_id"] = Client.ClientId;

                    if (!SearchCurrentClientform.Filtereddt.AsEnumerable().Any(row => row.Field<int>("client_id").Equals(Client.ClientId)))//reaffirmation,
                    {
                        SearchCurrentClientform.Filtereddt.Rows.InsertAt(DesiredRowF, 0);
                    }
                    if (!SearchCurrentClientform.Originaldt.AsEnumerable().Any(row => row.Field<int>("client_id").Equals(Client.ClientId)))//reaffirmation,cz sometimes, kenit tfout lahone w teele this clientid already exist which isnt logic,cz mafiya tfout lahone eza client id exists
                    {
                        SearchCurrentClientform.Originaldt.Rows.InsertAt(DesiredRowO, 0);
                    }
                    SearchCurrentClientform.dataGridViewClients.FirstDisplayedScrollingRowIndex = 0;
                    SearchCurrentClientform.dataGridViewClients.Rows[0].Selected = true;

                }

                if (IsClientDeleted)//delteing as row
                {
                    DesiredRowF.Delete();
                    DesiredRowO.Delete();

                    SearchCurrentClientform.Originaldt.AcceptChanges();
                    SearchCurrentClientform.Filtereddt.AcceptChanges();


                }
                else//updating a row
                {
                    //Calculate the remaining Packages


                    DesiredRowF["Full Name"] = Client.Fname + " " + Client.Lname;
                    DesiredRowO["Full Name"] = Client.Fname + " " + Client.Lname;

                    DesiredRowF["Total Attendance"] = Client.TotalAttendance;
                    DesiredRowO["Total Attendance"] = Client.TotalAttendance;


                    string filterExpression = "session_left_days IS NOT NULL AND is_expired = 'false' AND bundle_id IS NOT NULL";
                    string sortExpression = "is_expired ASC, purchase_date DESC";
                    DataRow[] filteredAndSortedRows = dtClientBalanceOriginal.Select(filterExpression, sortExpression);
                    (Client.PackagesRemaining, Client.PackagesStatus, Client.PackagesHAsStatus) = FilterCheckListSearch.CalculateClientRemainingPackages(filteredAndSortedRows);
                    DesiredRowF["Packages Remaining"] = Client.PackagesRemaining;
                    DesiredRowO["Packages Remaining"] = Client.PackagesRemaining;
                    DesiredRowF["Packages Status"] = Client.PackagesStatus;
                    DesiredRowO["Packages Status"] = Client.PackagesStatus;

                    if (Client.PhoneNumber != null)
                    {
                        DesiredRowF["Phone Number"] = Client.PhoneNumber;
                        DesiredRowO["Phone Number"] = Client.PhoneNumber;
                    }
                    else
                    {
                        DesiredRowF["Phone Number"] = NotAvailable;
                        DesiredRowO["Phone Number"] = NotAvailable;
                    }



                    string AgeCategory = NotAvailable;
                    if (Client.IsChild == true)//it can t be null
                    {
                        AgeCategory = UCComboBoxFilterSearch.Child;
                    }
                    else
                    {
                        AgeCategory = UCComboBoxFilterSearch.Adult;
                    }
                    DesiredRowF["Age Category"] = AgeCategory;
                    DesiredRowO["Age Category"] = AgeCategory;




                    if (Client.Gender != null)
                    {
                        DesiredRowF["Gender"] = Client.Gender;
                        DesiredRowO["Gender"] = Client.Gender;
                    }
                    else
                    {
                        DesiredRowF["Gender"] = NotAvailable;
                        DesiredRowO["Gender"] = NotAvailable;
                    }

                    if (Client.Job != null)
                    {
                        DesiredRowF["Job"] = Client.Job;
                        DesiredRowO["Job"] = Client.Job;
                    }
                    else
                    {
                        DesiredRowF["Job"] = NotAvailable;
                        DesiredRowO["Job"] = NotAvailable;
                    }

                    if (Client.Adress != null)
                    {
                        DesiredRowF["Adress"] = Client.Adress;
                        DesiredRowO["Adress"] = Client.Adress;
                    }
                    else
                    {
                        DesiredRowF["Adress"] = NotAvailable;
                        DesiredRowO["Adress"] = NotAvailable;
                    }

                    if (Client.AlbumType != null)
                    {
                        DesiredRowF["Album"] = Client.AlbumType;
                        DesiredRowO["Album"] = Client.AlbumType;
                    }
                    else
                    {
                        DesiredRowF["Album"] = NotAvailable;
                        DesiredRowO["Album"] = NotAvailable;
                    }




                    if (Client.SaveDate != null)
                    {
                        DesiredRowF["Save Date"] = RandomFunctions.SetDateFormat(Convert.ToString(Client.SaveDate));
                        DesiredRowO["Save Date"] = RandomFunctions.SetDateFormat(Convert.ToString(Client.SaveDate));

                        DesiredRowF["save_date"] = Client.SaveDate;
                        DesiredRowO["save_date"] = Client.SaveDate;
                    }
                    else
                    {
                        DesiredRowF["Save Date"] = NotAvailable;
                        DesiredRowO["Save Date"] = NotAvailable;
                        DesiredRowF["save_date"] = DBNull.Value;
                        DesiredRowO["save_date"] = DBNull.Value;
                    }






                    if (Client.LastVisit != null)
                    {
                        DesiredRowF["Last Visit"] = RandomFunctions.SetDateFormat(Convert.ToString(Client.LastVisit));
                        DesiredRowO["Last Visit"] = RandomFunctions.SetDateFormat(Convert.ToString(Client.LastVisit));
                        DesiredRowF["check_in"] = Client.LastVisit;
                        DesiredRowO["check_in"] = Client.LastVisit;
                    }
                    else
                    {
                        DesiredRowF["Last Visit"] = NotAvailable;
                        DesiredRowO["Last Visit"] = NotAvailable;
                        DesiredRowF["check_in"] = DBNull.Value;
                        DesiredRowO["check_in"] = DBNull.Value;
                    }


                    if (Client.RegistrationDate != null)
                    {
                        DesiredRowF["Registration Date"] = RandomFunctions.SetDateFormat(Convert.ToString(Client.RegistrationDate));
                        DesiredRowO["Registration Date"] = RandomFunctions.SetDateFormat(Convert.ToString(Client.RegistrationDate));

                        DesiredRowF["Registration_Date"] = Client.RegistrationDate;
                        DesiredRowO["Registration_Date"] = Client.RegistrationDate;
                    }
                    else
                    {
                        DesiredRowF["Registration Date"] = NotAvailable;
                        DesiredRowO["Registration Date"] = NotAvailable;
                        DesiredRowF["Registration_Date"] = DBNull.Value;
                        DesiredRowO["Registration_Date"] = DBNull.Value;
                    }
                    if (Client.RegistrationDate != null)
                    {
                        DesiredRowF["Registration Date"] = RandomFunctions.SetDateFormat(Convert.ToString(Client.RegistrationDate));
                        DesiredRowO["Registration Date"] = RandomFunctions.SetDateFormat(Convert.ToString(Client.RegistrationDate));

                        DesiredRowF["Registration_Date"] = Client.RegistrationDate;
                        DesiredRowO["Registration_Date"] = Client.RegistrationDate;
                    }
                    else
                    {
                        DesiredRowF["Registration Date"] = NotAvailable;
                        DesiredRowO["Registration Date"] = NotAvailable;
                        DesiredRowF["Registration_Date"] = DBNull.Value;
                        DesiredRowO["Registration_Date"] = DBNull.Value;
                    }


                    string balance = Client.TotalBalance.ToString();//cannnot be null
                    if (balance.Contains('-'))
                    {
                        balance = balance.Substring(1);
                        DesiredRowF["Total Balance"] = "-" + Currency.Symbol + balance;
                        DesiredRowO["Total Balance"] = "-" + Currency.Symbol + balance;
                        DesiredRowF["total_balance"] = "-" + balance;
                        DesiredRowO["total_balance"] = "-" + balance;

                    }
                    else
                    {
                        DesiredRowF["Total Balance"] = Currency.Symbol + balance;
                        DesiredRowO["Total Balance"] = Currency.Symbol + balance;
                        DesiredRowF["total_balance"] = balance;
                        DesiredRowO["total_balance"] = balance;

                    }



                    string ClientType = NotAvailable;
                    if (Client.RegistrationDate != null)
                    {
                        ClientType = UCComboBoxFilterSearch.Member;
                    }
                    else if (Client.RegistrationDate == null && Client.LastVisit != null)//visitor byaamil check in lieanno, aakes el non visitor
                    {
                        ClientType = UCComboBoxFilterSearch.Visitor;
                    }
                    else if (Client.RegistrationDate == null && Client.LastVisit == null)
                    {
                        ClientType = UCComboBoxFilterSearch.NoneVisitor;
                    }
                    DesiredRowF["Type"] = ClientType;
                    DesiredRowO["Type"] = ClientType;


                    string Payment = Client.TotalPayment.ToString();//cannnot be null
                    if (Payment != "0")
                    {

                        DesiredRowF["Total payment"] = "+" + Currency.Symbol + Payment;
                        DesiredRowO["Total payment"] = "+" + Currency.Symbol + Payment;
                        DesiredRowF["total_payment"] = "+" + Payment;
                        DesiredRowO["total_payment"] = "+" + Payment;

                    }
                    else
                    {
                        DesiredRowF["Total payment"] = Currency.Symbol + Payment;
                        DesiredRowO["Total payment"] = Currency.Symbol + Payment;
                        DesiredRowF["total_payment"] = Payment;
                        DesiredRowO["total_payment"] = Payment;
                    }
                }
            }

        }


        private void ClientManagementProfile_Resize(object sender, EventArgs e)
        {
            AutosizeUCLabel();
        }


        private void ClientManagementProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            //TransferInformationToSearch();

        }



        private void ClientManagementProfile_VisibleChanged(object sender, EventArgs e)
        {
            //if (IsFromSchedule)//since aam nodtarr naamela show dialog, w lamma tkun cached w showdialo ma aam bi bayno bel usaully method el icons, so this glitsh worked
            //{

            //}
            if (Visible == true)
            {
                FormatDatagridviewDesign();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .1;
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
