using CustomizedTools;
using GlobalFunctions;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace MKproject.Management
{

    public partial class BackOffice : Form
    {
        public ClientManagementProfile ParentFormClientManagem { get; set; }
        bool IsChildMode;
        int? ClientId;//kermel eza feyit men profile check all transaction of a client
        public DataTable DesiredBalanceRowsdt;// in case of all transaction el desired row ha yetghayar kell ma nekbus aa undo, amma bel specific balance ha ydall huwwe zeito
                                              //that s why in all transaction case mnaamello initialisation kell ma nekbus aa undo, amma specific balance  , mnaamela only bel constructor lieanno ha tdalla maana kell w

        public DataTable OriginalBackOfficeDt;
        public DataTable FilteredBackOfficeDt;

        UCComboBoxFilterBackOffice UCDate;
        UCComboBoxFilterBackOffice UCActions;
        UCComboBoxFilterBackOffice UCEmployee;
        UCTextBoxFilterOriginal UCClient;



        Label LabelNoDataRecorded;
        //For Filter
        ClassClient ClientForFilter=new ClassClient();


        public BackOffice(ClientManagementProfile clientManagement, int? ClientBalanceId, DataTable desiredRowsdt, int? clientId)//we have 3 modes: child mode(1-spcifc baland and specific client/2-specific client) mode 3: all backoffice
        {
            InitializeComponent();
            ParentFormClientManagem = clientManagement;
            ClientId = clientId;
            if ((ParentFormClientManagem != null && ClientBalanceId != null && desiredRowsdt != null) || ClientId != null)//child mode
            {
                IsChildMode = true;
                DesiredBalanceRowsdt = desiredRowsdt;//it will be null if AllTransactionofSpecificClient = true
                SetLogicMode(ClientBalanceId);
            }
            else
            {
                IsChildMode = false;
                SetLogicMode(null);
            }


            SetDesignMode();

            FormatBackOfficeDatagridview();//cz el design tabaa el columns tabaa el datagridview mnaamlo marra wahde since huwwe static ma byetghayar during run time

            FLPFilters.Select();//kermel el selection


        }


        private void BackOffice_Load(object sender, EventArgs e)
        {
            dataGridViewBackOffice.ClearSelection();
        }





        public void FormatBackOfficeOriginalDt()
        {
            OriginalBackOfficeDt.Columns.Add("Clients", typeof(string));
            OriginalBackOfficeDt.Columns.Add("Employees", typeof(string));
            OriginalBackOfficeDt.Columns.Add("Date", typeof(string));

            foreach (DataRow row in OriginalBackOfficeDt.Rows)
            {
                string Client = row["ClientFN"] + " " + row["ClientLN"];
                if (row["ClientPhoneNumber"] != DBNull.Value)
                {
                    Client += " (" + row["ClientPhoneNumber"] + ")";
                }

                row["Clients"] = Client;
                row["Employees"] = row["EmployeeFN"] + " " + row["EmpoyeeLN"];
                row["Date"] = RandomFunctions.SetDateFormat(row["RealDate"].ToString());

            }

            //
            OriginalBackOfficeDt.Columns.Remove("ClientFN");
            OriginalBackOfficeDt.Columns.Remove("ClientLN");
            OriginalBackOfficeDt.Columns.Remove("ClientPhoneNumber");
            OriginalBackOfficeDt.Columns.Remove("EmployeeFN");
            OriginalBackOfficeDt.Columns.Remove("EmpoyeeLN");


            //ordering
            int columnIndexToMove;
            int newIndex;

            columnIndexToMove = OriginalBackOfficeDt.Columns.IndexOf("Clients");
            newIndex = 0; // The new desired index
            OriginalBackOfficeDt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = OriginalBackOfficeDt.Columns.IndexOf("Activity History");
            newIndex = 1; // The new desired index
            OriginalBackOfficeDt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = OriginalBackOfficeDt.Columns.IndexOf("Date");
            newIndex = 2; // The new desired index
            OriginalBackOfficeDt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = OriginalBackOfficeDt.Columns.IndexOf("Employees");
            newIndex = 3; // The new desired index
            OriginalBackOfficeDt.Columns[columnIndexToMove].SetOrdinal(newIndex);



        }
        public void FillBackOfficeDataGridView(DataTable DesiredDataTable)//it could original or filters
        {
            SetDataGridViewMode(DesiredDataTable);

            FilteredBackOfficeDt = DesiredDataTable;
            dataGridViewBackOffice.DataSource = FilteredBackOfficeDt;
            dataGridViewBackOffice.ClearSelection();
        }
        void FormatBackOfficeDatagridview()
        {
            foreach (DataGridViewColumn col in dataGridViewBackOffice.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridViewBackOffice.Columns["client_id"].Visible = false;
            dataGridViewBackOffice.Columns["employee_id"].Visible = false;
            dataGridViewBackOffice.Columns["archive_id"].Visible = false;
            dataGridViewBackOffice.Columns["id_client_balance"].Visible = false;
            dataGridViewBackOffice.Columns["action_type"].Visible = false;
            dataGridViewBackOffice.Columns["RealDate"].Visible = false;
            dataGridViewBackOffice.Columns["amount_paid"].Visible = false;
            dataGridViewBackOffice.Columns["attendance_id"].Visible = false;
            dataGridViewBackOffice.Columns["is_moneyOrsession_offre"].Visible = false;
            dataGridViewBackOffice.Columns["previousBalanceOrSession_Offre"].Visible = false;
            if (IsChildMode)
            {
                dataGridViewBackOffice.Columns["Clients"].Visible = false;
            }

            ////
            dataGridViewBackOffice.Columns["Action"].DisplayIndex = dataGridViewBackOffice.ColumnCount - 1;
            dataGridViewBackOffice.Columns["Action"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBackOffice.Columns["Action"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ////
            dataGridViewBackOffice.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;//kermel yaamlo wrap kell el colunns li mawjudin aal sheshe w ma btaamil delay metel all cels, w eza hattina abel, it can cause us delays bel visible = false
            dataGridViewBackOffice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//kermel taamil stretch aa kell surface  horizontally
            dataGridViewBackOffice.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewBackOffice.RowTemplate.MinimumHeight = 40;
            ///
            dataGridViewBackOffice.Columns["Clients"].FillWeight = 25;
            dataGridViewBackOffice.Columns["Activity History"].FillWeight = 25;
            dataGridViewBackOffice.Columns["Date"].FillWeight = 15;
            dataGridViewBackOffice.Columns["Employees"].FillWeight = 10;
            dataGridViewBackOffice.Columns["Action"].FillWeight = 10;

            dataGridViewBackOffice.ApplyStyle1();
        }
        public void FilterDatable()
        {
            DataTable Filtereddt = OriginalBackOfficeDt.Copy();
            if ((UCActions != null && UCEmployee != null && UCDate != null && UCClient != null) || (ClientId != null && UCDate != null && UCActions != null && UCEmployee != null))
            {
                string selectedStringAction = UCActions.comboBoxDetail.SelectedItem.ToString();
                if (selectedStringAction != UCComboBoxFilterBackOffice.All)
                {

                    if (selectedStringAction == ActionsEnum.Purchases.GetStringValue())
                    {
                        string TargetedString1 = ActionsEnum.Purchases.ToString();
                        string TargetedString2 = ActionsEnum.SoloPurchases.ToString();

                        Filtereddt = FiltersDataTable.FilterDatatableIF2StringEquality("action_type", TargetedString1, TargetedString2, Filtereddt);
                    }
                    else
                    {
                        string TargetedString;

                        if (selectedStringAction == ActionsEnum.Payments.GetStringValue())
                        {
                            TargetedString = ActionsEnum.Payments.ToString();
                        }
                        else if (selectedStringAction == ActionsEnum.Offers.GetStringValue())
                        {
                            TargetedString = ActionsEnum.Offers.ToString();
                        }
                        else if (selectedStringAction == ActionsEnum.SessionDone.GetStringValue())
                        {
                            TargetedString = ActionsEnum.SessionDone.ToString();
                        }
                        else//which is impossible
                        {
                            TargetedString = "";
                        }

                        Filtereddt = FiltersDataTable.FilterDatatableIFStringEquality("action_type", TargetedString, Filtereddt);
                    }
                }


                string selectedStringEmployee = UCEmployee.comboBoxDetail.SelectedItem.ToString();
                if (selectedStringEmployee != UCComboBoxFilterBackOffice.All)
                {

                    Filtereddt = FiltersDataTable.FilterDatatableIFStringEquality("Employees", selectedStringEmployee, Filtereddt);
                }

                string selectedStringDate = UCDate.comboBoxDetail.SelectedItem.ToString();
                if (selectedStringDate != UCComboBoxFilterBackOffice.All)
                {
                    DateTime EndDate = DateTime.Now;
                    DateTime StartDate;
                    if (selectedStringDate == UCComboBoxFilterBackOffice.Today)/////////////hatta kamen la cust service lamma nicos yebaata
                    {
                        StartDate = EndDate.Date;//midnight (00:00:00).
                    }
                    else if (selectedStringDate == UCComboBoxFilterBackOffice.Last7Days)
                    {
                        StartDate = EndDate.AddDays(-7).Date;
                    }
                    else if (selectedStringDate == UCComboBoxFilterBackOffice.Last30Days)
                    {
                        StartDate = EndDate.AddDays(-30).Date;
                    }
                    else if (selectedStringDate == UCComboBoxFilterBackOffice.Last90Days)
                    {
                        StartDate = EndDate.AddDays(-90).Date;
                    }
                    else if (selectedStringDate == UCComboBoxFilterBackOffice.Last365Days)
                    {
                        StartDate = EndDate.AddDays(-365).Date;
                    }
                    else//imoossible
                    {
                        StartDate = EndDate;
                    }
                    Filtereddt = FiltersDataTable.FilterDatatableDateCustomDate("RealDate", Filtereddt, StartDate, EndDate);
                }

                if (UCClient != null && ClientForFilter.ClientId != null)// awwal condition eza kena feytin men profile nshuf all transaction tb3 a client/scd condtion eza feytin backoffice w aam nshuf eza eemelna search aa client
                {
                    Filtereddt = FiltersDataTable.FilterDatatableIFIntEquality("client_id", (int)ClientForFilter.ClientId, Filtereddt);
                }

                FillBackOfficeDataGridView(Filtereddt);
            }

        }

        void SetDataGridViewMode(DataTable DesiredDataTable)
        {
            if (DesiredDataTable.Rows.Count > 0)
            {
                //kermel l LabelNoDataRecorded
                if (TLPGlobal.Controls.Contains(LabelNoDataRecorded))
                {
                    LabelNoDataRecorded.Dispose();
                    LabelNoDataRecorded = null;
                    TLPGlobal.Controls.Remove(LabelNoDataRecorded);
                }

                dataGridViewBackOffice.Visible = true;


            }
            else
            {
                if (LabelNoDataRecorded == null)
                {
                    CreatingTheNoDataLabel();
                    TLPGlobal.Controls.Add(LabelNoDataRecorded, 0, 1);

                   dataGridViewBackOffice.Visible = false;                                    
                }

            }
        }
        void CreatingTheNoDataLabel()
        {
            LabelNoDataRecorded = new Label();
            // Set the label properties
            LabelNoDataRecorded.Text = "No Transaction Recorded";
            LabelNoDataRecorded.Font = new System.Drawing.Font("Segoe UI", 30, FontStyle.Italic);
            LabelNoDataRecorded.ForeColor = Color.FromArgb(150, 150, 150);

            Color whiteSmoke = Color.WhiteSmoke;
            Color semiTransparentWhiteSmoke = Color.FromArgb(150, whiteSmoke.R, whiteSmoke.G, whiteSmoke.B); // 128 is the alpha value
            LabelNoDataRecorded.BackColor = semiTransparentWhiteSmoke;

            LabelNoDataRecorded.TextAlign = ContentAlignment.MiddleCenter;
            LabelNoDataRecorded.AutoSize = false;
            LabelNoDataRecorded.Dock = DockStyle.Fill;
            LabelNoDataRecorded.Margin = new Padding(10, 10, 10, 10);
        }


        void SetLogicMode(int? ClientBalanceId)
        {
            if (!IsChildMode)
            {

                this.Opacity = 1;
                CreateUCFilters();
                //in this case   FormatBackOfficeOriginalDt() btenaamal bel event comboboxselectchanged/FillBackOfficeDataGridView(OriginalBackOfficeDt) btenaamal bel filterdata()
            }
            else
            {

                //opening the form

                this.Opacity = 0;
                timer1.Start();

                //sql
                if (ClientId != null)//aam neshab all transaction tabaa specific client
                {
                    OriginalBackOfficeDt = ClassBackOffice.GetBackOffice(true, null, ClientId);//only this year
                    FormatBackOfficeOriginalDt();//since el event ma mnekhlaeo eza in this case so modtarin nzid ha hon w 
                    CreateUCFilters(); //FillBackOfficeDataGridView(OriginalBackOfficeDt) btenaamal bel filterdata()

                }
                else//aam beshab only el backoffice tabaa specific client for a specicf clientbalance
                {
                    OriginalBackOfficeDt = ClassBackOffice.GetBackOffice(false, ClientBalanceId, null);//all transac
                    //scd datagridview 
                    dataGridViewBalance.DataSource = DesiredBalanceRowsdt;//badak that mahalla datatble aw mb#rf shu
                    ParentFormClientManagem.FormatDatagridview(dataGridViewBalance, false);
                    dataGridViewBalance.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dataGridViewBalance.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;//kermel taamil stretch aa kell surface  horizontally
                    dataGridViewBalance.RowTemplate.MinimumHeight = 40; // Set minimum row height
                    if (DesiredBalanceRowsdt.Rows[0]["due_date"] != DBNull.Value)
                    {
                        dataGridViewBalance.Columns["DueDate"].Visible = true;
                    }
                    FormatBackOfficeOriginalDt();

                    //design          
                    FillBackOfficeDataGridView(OriginalBackOfficeDt);
                    FilteredBackOfficeDt = OriginalBackOfficeDt.Copy();
                }




            }
        }//try catch



        void SetDesignMode()
        {
            if (!IsChildMode)//feytin men el back office
            {

                TLPGlobal.RowStyles[0].Height = 66;
                TLPGlobal.RowStyles[2].Height = 0;
                TLPGlobal.RowStyles[3].Height = 0;
                dataGridViewBalance.Dispose();

            }
            else// feytin men el profile
            {
                if (ClientId == null)
                {

                    TLPGlobal.RowStyles[0].Height = 0;
                    TLPGlobal.RowStyles[2].Height = 120;
                    TLPGlobal.RowStyles[3].Height = 40;
                }
                else
                {

                    TLPGlobal.RowStyles[0].Height = 66;
                    TLPGlobal.RowStyles[2].Height = 0;
                    TLPGlobal.RowStyles[3].Height = 40;
                    dataGridViewBalance.Dispose();

                }
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Size = new Size(860, 479);
            }
        }
        //hone bi hal function aam bmalle el el datatble men sql
        void CreateUCFilters()//cz fi eena filter eza ken mode all client transaction
        {

            UCDate = new UCComboBoxFilterBackOffice();
            UCDate.ParentFormBackOffice = this;
            UCDate.ComboBoxDetailSelectedIndexChanged += UCDate_ComboBoxDetailSelectedIndexChanged;
            UCDate.Title = "Date";
            UCDate.FilterType = UCComboBoxFilterBackOffice.FiltersType.Date;//in here i m filling the originaldt
            if (IsChildMode)
            {
                UCDate.comboBoxDetail.SelectedIndex = UCDate.comboBoxDetail.FindString(UCComboBoxFilterBackOffice.All);
            }
            else
            {
                UCDate.comboBoxDetail.SelectedIndex = 0;
            }

            FLPFilters.Controls.Add(UCDate);


            UCActions = new UCComboBoxFilterBackOffice();
            UCActions.ParentFormBackOffice = this;
            UCActions.Title = "Actions";
            UCActions.FilterType = UCComboBoxFilterBackOffice.FiltersType.Actions;
            UCActions.comboBoxDetail.SelectedIndex = 0;
            FLPFilters.Controls.Add(UCActions);


            UCEmployee = new UCComboBoxFilterBackOffice();
            UCEmployee.ParentFormBackOffice = this;
            UCEmployee.Title = "Employee";
            UCEmployee.FilterType = UCComboBoxFilterBackOffice.FiltersType.Employee;
            UCEmployee.comboBoxDetail.SelectedIndex = 0;
            FLPFilters.Controls.Add(UCEmployee);


            if (!IsChildMode)
            {
                UCClient = new UCTextBoxFilterOriginal();
                UCClient.TextBoxClicked += UCClient_TextBoxClicked;
                UCClient.TextBoxTextChanged += UCClient_TextBoxTextChanged;
                UCClient.Title = "Client";
                UCClient.PlaceHolderOfTextBox = "Search by name or phone number...";
                RandomFunctions.SetWidth(UCClient, UCClient.textBox, UCClient.labelTitle);
                FLPFilters.Controls.Add(UCClient);
            }



        }//try catch 

        bool IsOneYearOrAll = false;//default value, lieanno we re selecting Today at the start, so badna nhatta kaeanno all kermel tfout bel condition tahet
        private void UCDate_ComboBoxDetailSelectedIndexChanged(object sender, EventArgs e)
        {
            if (UCDate.comboBoxDetail.SelectedItem.ToString() == UCComboBoxFilterBackOffice.All)
            {
                if (IsOneYearOrAll == true)//to prevent repitions
                {
                    OriginalBackOfficeDt = ClassBackOffice.GetBackOffice(IsOneYearOrAll, null, null);
                    IsOneYearOrAll = false;
                    FormatBackOfficeOriginalDt();

                }
            }
            else
            {
                if (IsOneYearOrAll == false)//eza kenit all bet fout fiya kermel nghayera
                {
                    OriginalBackOfficeDt = ClassBackOffice.GetBackOffice(IsOneYearOrAll, null, null);
                    IsOneYearOrAll = true;
                    FormatBackOfficeOriginalDt();

                }

            }
        }

        private void UCClient_TextBoxTextChanged(object sender, EventArgs e)//CBsearch form, hiyye el wahide li bet ghayyir
        {
            if (!string.IsNullOrEmpty(UCClient.textBox.Text))
            {
                FilterDatable();//should be async kermel el taeakhor tabaa el textbox changing
            }

        }
        private void UCClient_TextBoxClicked(object sender, EventArgs e)
        {
            
            Search searchname = new Search(UCClient.textBox, ClientForFilter);
            searchname.Deactivate += Searchname_Deactivate;
            Point locationRelativeToScreen = UCClient.textBox.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-2, -2);
            searchname.Location = locationRelativeToScreen;
            searchname.Show();

        }

        private void Searchname_Deactivate(object sender, EventArgs e)
        {
            UCClient.labelTitle.Select();
        }

        void DeletingDatagridRows(int ArchiveId)
        {

            FilteredBackOfficeDt.PrimaryKey = new DataColumn[] { FilteredBackOfficeDt.Columns["archive_id"] };//kermel el refresh 
            DataRow DesiredRowF = FilteredBackOfficeDt.Rows.Find(ArchiveId);
            if (DesiredRowF != null)
            {
                DesiredRowF.Delete();
                FilteredBackOfficeDt.AcceptChanges();
                SetDataGridViewMode(FilteredBackOfficeDt);
            }
         

            OriginalBackOfficeDt.PrimaryKey = new DataColumn[] { OriginalBackOfficeDt.Columns["archive_id"] };//kermel el refresh           
            DataRow DesiredRowO = OriginalBackOfficeDt.Rows.Find(ArchiveId);
            DesiredRowO.Delete();
            OriginalBackOfficeDt.AcceptChanges();



        }


        private void dataGridViewBackOffice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewCell cell = dataGridViewBackOffice.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.OwningColumn.Name == "Action")
                {

                    string ActionType = dataGridViewBackOffice.Rows[e.RowIndex].Cells["action_type"].Value.ToString();
                    int clientId = Convert.ToInt16(dataGridViewBackOffice.Rows[e.RowIndex].Cells["client_id"].Value);
                    int ArchiveId = Convert.ToInt16(dataGridViewBackOffice.Rows[e.RowIndex].Cells["archive_id"].Value);
                    int clientBalanceId = Convert.ToInt16(dataGridViewBackOffice.Rows[e.RowIndex].Cells["id_client_balance"].Value);




                    BackOffice backofficeform = null;
                    if (IsChildMode)
                    {
                        backofficeform = this;
                        if (ClientId != null)//we initialise again because it could be not the same balance or specific balance we only initialise at the construtc once
                        {
                            DesiredBalanceRowsdt = ParentFormClientManagem.RetrievingSpecificRowsInDt(false, clientBalanceId);
                        }
                    }



                    string MessageSow = "";
                    if (ActionType == ActionsEnum.Purchases.ToString() || ActionType == ActionsEnum.SoloPurchases.ToString())
                    {

                        MessageSow = "Undoing this action could result in the deletion of all associated data related to this action.";
                        DialogResult dialogResult = CustomMessageBox.Show(MessageSow + "\nAre you sure you want to proceed?", CustomMessageBox.Type.YesNoWarning);
                        if (dialogResult == DialogResult.Yes)
                        {


                            if (ActionType == ActionsEnum.Purchases.ToString())
                            {

                                DataRow[] foundOriginRows = OriginalBackOfficeDt.Select("id_client_balance = " + clientBalanceId + " AND archive_id <> " + Convert.ToInt16(dataGridViewBackOffice.Rows[e.RowIndex].Cells["archive_id"].Value));//seelcting all the rows, with same balance_id gher li aam nekbesa now
                                for (int i = 0; i < foundOriginRows.Length; i++)//we will be deleting kell tl rows, foe ayda el row li elun aalea fi
                                {

                                    int DesiredArchiveID = Convert.ToInt16(foundOriginRows[i]["archive_id"]);

                                    if (foundOriginRows[i]["attendance_id"] != DBNull.Value)//only for packages, not for products,nor solo
                                    {
                                        int DesiredStructId = Convert.ToInt16(foundOriginRows[i]["attendance_id"]);
                                        ClassBackOffice.UndoSessionDoneActionsSQL(clientId, DesiredStructId, DesiredArchiveID, clientBalanceId, true, backofficeform);//oly hayde lieanno eenda gher ab3ad(last visit) , or hawdik by cascade on delete bi tiro

                                    }

                                    //design
                                    DeletingDatagridRows(DesiredArchiveID);

                                }

                                ClassBackOffice.UndoPurchaseActionsSQL(clientId, clientBalanceId, backofficeform);

                            }
                            else if (ActionType == ActionsEnum.SoloPurchases.ToString())
                            {

                                int structId = Convert.ToInt16(dataGridViewBackOffice.Rows[e.RowIndex].Cells["attendance_id"].Value);
                                ClassBackOffice.UndoSoloPurchaseActionsSQL(clientId, structId, ArchiveId, clientBalanceId, backofficeform);


                                //design

                                DataRow[] foundOriginRows = OriginalBackOfficeDt.Select("id_client_balance = " + clientBalanceId + " AND archive_id <> " + Convert.ToInt16(dataGridViewBackOffice.Rows[e.RowIndex].Cells["archive_id"].Value));//seelcting all the rows, with same balance_id gher li aam nekbesa now
                                for (int i = 0; i < foundOriginRows.Length; i++)//we will be deleting kell tl rows, foe ayda el row li elun aalea fi
                                {

                                    int DesiredArchiveID = Convert.ToInt16(foundOriginRows[i]["archive_id"]);
                                    DeletingDatagridRows(DesiredArchiveID);
                                }

                                }

                            //design
                            DeletingDatagridRows(ArchiveId);
                            dataGridViewBackOffice.ClearSelection();

                            if (backofficeform != null && ClientId == null)//childmode not all transaction
                            {
                                backofficeform.timer2.Start();//closeing 
                            }

                        }

                    }
                    else if (ActionType == ActionsEnum.SessionDone.ToString())
                    {
                        int structId = Convert.ToInt16(dataGridViewBackOffice.Rows[e.RowIndex].Cells["attendance_id"].Value);

                        DialogResult dialogResult = CustomMessageBox.Show("Are you sure you want to proceed?", CustomMessageBox.Type.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            ClassBackOffice.UndoSessionDoneActionsSQL(clientId, structId, ArchiveId, clientBalanceId, false, backofficeform);
                            //design
                            DeletingDatagridRows(ArchiveId);
                            dataGridViewBackOffice.ClearSelection();
                        }

                    }
                    else if (ActionType == ActionsEnum.Payments.ToString())
                    {

                        double AmountPaid = Convert.ToDouble(dataGridViewBackOffice.Rows[e.RowIndex].Cells["amount_paid"].Value);
                        DateTime ArchiveDate = Convert.ToDateTime(dataGridViewBackOffice.Rows[e.RowIndex].Cells["RealDate"].Value);

                        DialogResult dialogResult = CustomMessageBox.Show("Are you sure you want to proceed?", CustomMessageBox.Type.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            ClassBackOffice.UndoPaymentActionsSQL(clientId, clientBalanceId, ArchiveId, ArchiveDate, AmountPaid, backofficeform);
                            //design
                            DeletingDatagridRows(ArchiveId);
                            dataGridViewBackOffice.ClearSelection();
                        }


                    }
                    else if (ActionType == ActionsEnum.Offers.ToString())
                    {
                        DialogResult dialogResult = CustomMessageBox.Show("Are you sure you want to proceed?", CustomMessageBox.Type.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            bool IsMoneyOrSession = Convert.ToBoolean(dataGridViewBackOffice.Rows[e.RowIndex].Cells["is_moneyOrsession_offre"].Value);
                            string PreviousOffre = Convert.ToString(dataGridViewBackOffice.Rows[e.RowIndex].Cells["previousBalanceOrSession_Offre"].Value);
                            bool ISUndo = ClassBackOffice.UndoOffresSQL(clientId, ArchiveId, clientBalanceId, IsMoneyOrSession, PreviousOffre, backofficeform);//if archive is undone

                            if (!ISUndo)
                            {
                                MessageSow = "This action cannot be undone to avoid conflicts with other offers unlesss it was the last action made.";
                                DialogResult dialogResult1 = CustomMessageBox.Show(MessageSow + "\nOther Wise you can Edit it from the client Profile directly.", CustomMessageBox.Type.Ok);
                            }
                            else
                            {
                                DeletingDatagridRows(ArchiveId);
                            }

                        }

                    }

                }
            }
        }


        private void dataGridViewBalance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0) // Assuming "balance" is the name of your balance column
            {
                DataGridViewCell cell = dataGridViewBalance.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (e.ColumnIndex == dataGridViewBalance.Columns["FakeBalance"].Index)
                {
                    if (Convert.ToString(cell.Value) != "$0")
                    {
                        cell.Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        cell.Style.ForeColor = Color.Black;
                    }
                }
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
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {

                timer2.Stop();
                this.Close();
            }
            Opacity -= .1;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }




        private void BackOffice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
