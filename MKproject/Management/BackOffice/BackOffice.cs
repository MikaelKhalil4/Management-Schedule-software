using CustomizedTools;
using GlobalFunctions;
using System;
using System.Data;
using System.Drawing;
using System.Reflection.Metadata;
using System.Windows.Forms;


namespace MKproject.Management
{

    public partial class BackOffice : Form
    {
        public ClientManagementProfile ParentFormClientManagem { get; set; }
        bool IsChildMode;
        int? ClientId;//kermel eza feyit men profile check all transaction of a client
        public DataRow DesiredBalanceRowBinded;// in case of all transaction el desired row ha yetghayar kell ma nekbus aa undo, amma bel specific balance ha ydall huwwe zeito
                                               //that s why in all transaction case mnaamello initialisation kell ma nekbus aa undo, amma specific balance  , mnaamela only bel constructor lieanno ha tdalla maana kell w

        public DataTable OriginalBackOfficeDt;
        public DataTable FilteredBackOfficeDt;

        UCComboBoxFilterBackOffice UCDate;
        UCComboBoxFilterBackOffice UCActions;
        UCComboBoxFilterBackOffice UCEmployee;
        UCTextBoxFilterOriginal UCClient;


        bool IsAllIsRetrieved;

        Label LabelNoDataRecorded;
        //For Filter
        ClassClient ClientForFilter;


        public BackOffice(ClientManagementProfile clientManagement, int? ClientBalanceId, DataTable desiredBalanceRowsdt, int? clientId)//we have 3 modes: child mode(1-spcifc baland and specific client/2-specific client) mode 3: all backoffice
        {
            InitializeComponent();
            ParentFormClientManagem = clientManagement;
            ClientId = clientId;
            if ((ParentFormClientManagem != null && ClientBalanceId != null && desiredBalanceRowsdt != null) || ClientId != null)//child mode
            {
                IsChildMode = true;
                if (desiredBalanceRowsdt != null)
                {
                    DesiredBalanceRowBinded = desiredBalanceRowsdt.Rows[0];//it will be null if AllTransactionofSpecificClient = true, lieanno tahet lamma naamil undo aam nerjaa nmaliya hasab kell client_balance_id,(more explination foe bel declaration)
                    SetLogicMode(ClientBalanceId, desiredBalanceRowsdt);
                }
                else
                {
                    SetLogicMode(ClientBalanceId, null);
                }
            }
            else
            {
                IsChildMode = false;
                SetLogicMode(null, null);
            }


            SetDesignMode();

            FormatBackOfficeDatagridview();//cz el design tabaa el columns tabaa el datagridview mnaamlo marra wahde since huwwe static ma byetghayar during run time

            FLPFilters.Select();//kermel el selection


        }


        private void BackOffice_Load(object sender, EventArgs e)
        {
            dataGridViewBackOffice.ClearSelection();
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
                UCClient.Title = "Client";
                UCClient.PlaceHolderOfTextBox = "Search by name or phone number...";
                RandomFunctions.SetWidth(UCClient, UCClient.textBox, UCClient.labelTitle);
                FLPFilters.Controls.Add(UCClient);
            }

            FilterDatable();


        }//try catch 
        private void UCDate_ComboBoxDetailSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsAllIsRetrieved)
            {
                if (UCDate.comboBoxDetail.SelectedItem.ToString() == UCComboBoxFilterBackOffice.All)
                {
                    OriginalBackOfficeDt = ClassBackOffice.GetBackOffice(false, null, null);
                    IsAllIsRetrieved = true;//kell hal operation bi battil ela aaze since sar maana kell tabale hone
                    FormatBackOfficeOriginalDt();
                }

            }

        }
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






        void SetLogicMode(int? ClientBalanceId, DataTable desiredBalanceRowsdt)
        {
            if (!IsChildMode)
            {

                this.Opacity = 1;
                OriginalBackOfficeDt = ClassBackOffice.GetBackOffice(true, null, null);//all transac of this Speicific ClientBalance
                IsAllIsRetrieved = false;
                FormatBackOfficeOriginalDt();
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
                    OriginalBackOfficeDt = ClassBackOffice.GetBackOffice(false, null, ClientId);//all trans 
                    IsAllIsRetrieved = true;
                    FormatBackOfficeOriginalDt();//since el event ma mnekhlaeo eza in this case so modtarin nzid ha hon w 
                    CreateUCFilters(); //FillBackOfficeDataGridView(OriginalBackOfficeDt) btenaamal bel filterdata()

                }
                else//aam beshab only el backoffice tabaa specific client for a specicf clientbalance
                {
                    OriginalBackOfficeDt = ClassBackOffice.GetBackOffice(false, ClientBalanceId, null);//all transac of this Speicific ClientBalance
                    IsAllIsRetrieved = true;
                    //scd datagridview 
                    dataGridViewBalance.DataSource = desiredBalanceRowsdt;
                    ClassClientBalanceFront.FormatDatagridview(dataGridViewBalance, false);
                    dataGridViewBalance.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dataGridViewBalance.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;//kermel taamil stretch aa kell surface  horizontally
                    dataGridViewBalance.RowTemplate.MinimumHeight = 40; // Set minimum row height
                    if (DesiredBalanceRowBinded["due_date"] != DBNull.Value)
                    {
                        dataGridViewBalance.Columns["due_date"].Visible = true;
                    }
                    FormatBackOfficeOriginalDt();

                    //design          
                    FillBackOfficeDataGridView(OriginalBackOfficeDt);
                    FilteredBackOfficeDt = OriginalBackOfficeDt.Copy();
                }




            }
        }//try catch

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
                    Filtereddt = FiltersDataTable.FilterDatatableDateCustomDate("date", Filtereddt, StartDate, EndDate);
                }

                if (UCClient != null && ClientForFilter != null)// awwal condition eza kena feytin men profile nshuf all transaction tb3 a client/scd condtion eza feytin backoffice w aam nshuf eza eemelna search aa client
                {
                    Filtereddt = FiltersDataTable.FilterDatatableIFIntEquality("client_id", ClientForFilter.ClientId, Filtereddt);
                }

                FillBackOfficeDataGridView(Filtereddt);
            }

        }



        private void UCClient_TextBoxClicked(object sender, EventArgs e)
        {

            Search searchname = new Search(UCClient.textBox, ClientForFilter);
            searchname.ChosenClientChanged += Searchname_ChosenClientChanged;
            searchname.Deactivate += Searchname_Deactivate;
            Point locationRelativeToScreen = UCClient.textBox.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-2, -2);
            searchname.Location = locationRelativeToScreen;
            searchname.Show();

        }
        private void Searchname_ChosenClientChanged(object sender, EventArgs e)
        {
            Search searchname = (Search)sender;
            ClientForFilter = searchname.NewDesiredClient;

            FilterDatable();//should be async kermel el taeakhor tabaa el textbox changing

        }
        private void Searchname_Deactivate(object sender, EventArgs e)
        {
            UCClient.labelTitle.Select();
        }





        public void FormatBackOfficeOriginalDt()
        {
            OriginalBackOfficeDt.Columns.Add("Clients", typeof(string));
            OriginalBackOfficeDt.Columns.Add("Employees", typeof(string));

            foreach (DataRow row in OriginalBackOfficeDt.Rows)
            {
                string Client = row["ClientFN"] + " " + row["ClientLN"];
                if (row["ClientPhoneNumber"] != DBNull.Value)
                {
                    Client += " (" + row["ClientPhoneNumber"] + ")";
                }

                row["Clients"] = Client;
                row["Employees"] = row["EmployeeFN"] + " " + row["EmpoyeeLN"];

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



            columnIndexToMove = OriginalBackOfficeDt.Columns.IndexOf("Employees");
            newIndex = 2; // The new desired index
            OriginalBackOfficeDt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = OriginalBackOfficeDt.Columns.IndexOf("date");
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
                if (col.Name != "date")
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

            dataGridViewBackOffice.Columns["client_id"].Visible = false;
            dataGridViewBackOffice.Columns["employee_id"].Visible = false;
            dataGridViewBackOffice.Columns["archive_id"].Visible = false;
            dataGridViewBackOffice.Columns["client_balance_id"].Visible = false;
            dataGridViewBackOffice.Columns["appointment_id"].Visible = false;
            dataGridViewBackOffice.Columns["action_type"].Visible = false;
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
            dataGridViewBackOffice.ApplyStyle1();//ejbare foe el dusplay cells
            dataGridViewBackOffice.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;//kermel yaamlo wrap kell el colunns li mawjudin aal sheshe w ma btaamil delay metel all cels, w eza hattina abel, it can cause us delays bel visible = false
            dataGridViewBackOffice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//kermel taamil stretch aa kell surface  horizontally
            dataGridViewBackOffice.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewBackOffice.RowTemplate.MinimumHeight = 40;
            ///
            dataGridViewBackOffice.Columns["Clients"].FillWeight = 25;
            dataGridViewBackOffice.Columns["Activity History"].FillWeight = 25;
            dataGridViewBackOffice.Columns["date"].FillWeight = 15;
            dataGridViewBackOffice.Columns["Employees"].FillWeight = 10;
            dataGridViewBackOffice.Columns["Action"].FillWeight = 10;

            dataGridViewBackOffice.Columns["date"].HeaderText = "Date";

        }



        private void dataGridViewBackOffice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dataGridViewBackOffice.Rows.Count && e.ColumnIndex < dataGridViewBackOffice.Columns.Count)
            {
                if (dataGridViewBackOffice.Columns[e.ColumnIndex].Name == "date")
                {
                    if (e.Value != null)
                    {
                        e.Value = RandomFunctions.SetDateFormat(e.Value.ToString());
                    }
                }
            }
        }
        private void dataGridViewBackOffice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewCell cell = dataGridViewBackOffice.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.OwningColumn.Name == "Action")
                {

                    string ActionType = dataGridViewBackOffice.Rows[e.RowIndex].Cells["action_type"].Value.ToString();
                    int clientId = Convert.ToInt32(dataGridViewBackOffice.Rows[e.RowIndex].Cells["client_id"].Value);
                    int ArchiveId = Convert.ToInt32(dataGridViewBackOffice.Rows[e.RowIndex].Cells["archive_id"].Value);
                    int clientBalanceId = Convert.ToInt32(dataGridViewBackOffice.Rows[e.RowIndex].Cells["client_balance_id"].Value);
                    var cellValue = dataGridViewBackOffice.Rows[e.RowIndex].Cells["appointment_id"].Value;
                    int? AppointmentId = cellValue is DBNull ? (int?)null : Convert.ToInt32(cellValue);

                    DataRow DesiredClientBlanaceRow = ClassClientBalance.GetClientBalanceAllInfoSql(clientBalanceId);//not Binded bas men eeuza , since eeyzin some Values

                    if (IsChildMode)
                    {
                        if (ClientId != null)//meas fetna men AllTransactionTabaaaSpecific clients, So kell wahde mnekbesa we need to bind it maa el parent form, to reflect updates
                        {
                            DataTable dt = ParentFormClientManagem.RetrievingSpecificRowsInDt(false, clientBalanceId);
                            this.DesiredBalanceRowBinded = dt.Rows[0];
                        }
                    }





                    string MessageShow;
                    MessageShow = "Undoing this action could result in the deletion of all associated data related to this action.";
                    if (ActionType == ActionsEnum.Purchases.ToString() || ActionType == ActionsEnum.SoloPurchases.ToString())
                    {
                        if (ClassBackOffice.CheckIfDesiredArchiveHasRefrencesInTableArchive(clientBalanceId, ArchiveId))
                        {
                            MessageShow = "To undo this action, you must first undo all related actions associated with this data.";
                            CustomMessageBox.Show(MessageShow, CustomMessageBox.Type.Error);
                        }
                        else
                        {
                            DialogResult dialogResult = CustomMessageBox.Show(MessageShow + "\nAre you sure you want to proceed?", CustomMessageBox.Type.YesNoWarning);

                            if (dialogResult == DialogResult.Yes)
                            {


                                if (ActionType == ActionsEnum.Purchases.ToString())
                                {

                                    DataRow[] foundOriginRows = OriginalBackOfficeDt.Select("client_balance_id = " + clientBalanceId + " AND archive_id <> " + Convert.ToInt32(dataGridViewBackOffice.Rows[e.RowIndex].Cells["archive_id"].Value));//seelcting all the rows, with same balance_id gher li aam nekbesa now
                                    for (int i = 0; i < foundOriginRows.Length; i++)//we will be deleting kell tl rows, foe ayda el row li elun aalea fi
                                    {

                                        int DesiredArchiveID = Convert.ToInt32(foundOriginRows[i]["archive_id"]);

                                        if (foundOriginRows[i]["attendance_id"] != DBNull.Value)//only for packages, not for products,nor solo
                                        {
                                            int DesiredStructId = Convert.ToInt32(foundOriginRows[i]["attendance_id"]);
                                            int? AppointmentIdForSessionsDone = foundOriginRows[i]["appointment_id"] is DBNull ? null : Convert.ToInt32(foundOriginRows[i]["appointment_id"]);


                                            DateTime? NewLastVistDate = ClassBackOffice.UndoSessionDoneActionsSQL(clientId, DesiredStructId, DesiredArchiveID, clientBalanceId, true, AppointmentIdForSessionsDone);//oly hayde lieanno eenda gher ab3ad(last visit) , or hawdik by cascade on delete bi tiro


                                            //Design in Profile if Exists
                                            if (IsChildMode && this.ParentFormClientManagem != null)
                                            {
                                                UpdateProfileDesingOnUndoSession(NewLastVistDate);
                                            }

                                        }

                                        // //design in Backoffice form
                                        DeletingDatagridRowsAndActiveTheEvent(DesiredArchiveID);
                                    }


                                    (bool IsBundleOrProduct, DateTime? MembershipDate, bool IsMembershipDateChanged) = ClassBackOffice.UndoPurchaseActionsSQL(clientId, clientBalanceId);

                                    //Design in Profile if Exists
                                    if (IsChildMode && this.ParentFormClientManagem != null)
                                    {
                                        UpdateProfileDesingOnUndoPurchase(clientBalanceId, IsBundleOrProduct, MembershipDate, IsMembershipDateChanged);
                                    }

                                }
                                else if (ActionType == ActionsEnum.SoloPurchases.ToString())
                                {


                                    int structId = Convert.ToInt32(dataGridViewBackOffice.Rows[e.RowIndex].Cells["attendance_id"].Value);


                                    int? BundleId = null;
                                    if (AppointmentId != null)
                                    {
                                        BundleId = Convert.ToInt32(DesiredClientBlanaceRow["bundle_id"]);
                                    }

                                    (DateTime? NewLastVistDate, DateTime? MembershipDate, bool IsMembershipDateChanged) = ClassBackOffice.UndoSoloPurchaseActionsSQL(clientId, structId, ArchiveId, clientBalanceId, AppointmentId, BundleId);


                                    //Design in Profile if Exists
                                    if (IsChildMode && this.ParentFormClientManagem != null)
                                    {
                                        UpdateProfileDesingOnUndoSoloPurchase(clientBalanceId, NewLastVistDate, MembershipDate, IsMembershipDateChanged);
                                    }

                                    //design in Backoffice form
                                    DataRow[] foundOriginRows = OriginalBackOfficeDt.Select("client_balance_id = " + clientBalanceId + " AND archive_id <> " + Convert.ToInt32(dataGridViewBackOffice.Rows[e.RowIndex].Cells["archive_id"].Value));//seelcting all the rows, with same balance_id gher li aam nekbesa now
                                    for (int i = 0; i < foundOriginRows.Length; i++)//we will be deleting kell tl rows, foe ayda el row li elun aalea fi
                                    {
                                        int DesiredArchiveID = Convert.ToInt32(foundOriginRows[i]["archive_id"]);
                                        DeletingDatagridRowsAndActiveTheEvent(DesiredArchiveID);
                                    }

                                }



                                //design in Backoffice form
                                DeletingDatagridRowsAndActiveTheEvent(ArchiveId);
                                dataGridViewBackOffice.ClearSelection();

                                if (IsChildMode && ClientId == null)//childmode not all transaction
                                {
                                    this.timer2.Start();//closeing 
                                }

                            }
                        }

                    }
                    else if (ActionType == ActionsEnum.SessionDone.ToString())
                    {
                        int structId = Convert.ToInt32(dataGridViewBackOffice.Rows[e.RowIndex].Cells["attendance_id"].Value);
                        DialogResult dialogResult = CustomMessageBox.Show(MessageShow + "\nAre you sure you want to proceed?", CustomMessageBox.Type.YesNoWarning);
                        if (dialogResult == DialogResult.Yes)
                        {

                            DateTime? NewLastVistDate = ClassBackOffice.UndoSessionDoneActionsSQL(clientId, structId, ArchiveId, clientBalanceId, false, AppointmentId);

                            //Design in Profile if Exists
                            if (IsChildMode && this.ParentFormClientManagem != null)
                            {
                                UpdateProfileDesingOnUndoSession(NewLastVistDate);
                            }

                            //design in BackOfficeForm
                            DeletingDatagridRowsAndActiveTheEvent(ArchiveId);
                            dataGridViewBackOffice.ClearSelection();
                        }

                    }
                    else if (ActionType == ActionsEnum.Payments.ToString())
                    {

                        double AmountPaid = Convert.ToDouble(dataGridViewBackOffice.Rows[e.RowIndex].Cells["amount_paid"].Value);
                        DateTime ArchiveDate = Convert.ToDateTime(dataGridViewBackOffice.Rows[e.RowIndex].Cells["date"].Value);
                        DialogResult dialogResult = CustomMessageBox.Show(MessageShow + "\nAre you sure you want to proceed?", CustomMessageBox.Type.YesNoWarning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            ClassBackOffice.UndoPaymentActionsSQL(clientId, clientBalanceId, ArchiveId, ArchiveDate, AmountPaid);

                            //Design in Profile if Exists
                            if (IsChildMode && this.ParentFormClientManagem != null)
                            {
                                UpdateProfileDesingOnUndoPayment(AmountPaid, clientBalanceId);
                            }

                            //design in BackofficeForm
                            DeletingDatagridRowsAndActiveTheEvent(ArchiveId);
                            dataGridViewBackOffice.ClearSelection();
                        }


                    }
                    else if (ActionType == ActionsEnum.Offers.ToString())//only this exception updating el design mawjude hone fiya, since already eenda it s own algo
                    {

                        bool IsMoneyOrSession = Convert.ToBoolean(dataGridViewBackOffice.Rows[e.RowIndex].Cells["is_moneyOrsession_offre"].Value);
                        string PreviousOffre = Convert.ToString(dataGridViewBackOffice.Rows[e.RowIndex].Cells["previousBalanceOrSession_Offre"].Value);
                        bool CanUndo = ClassBackOffice.CanUndoOffresSQL(clientId, ArchiveId, clientBalanceId);//if archive is undone

                        if (!CanUndo)
                        {
                            MessageShow = "This action cannot be undone to avoid conflicts with other offers unlesss it was the last action made.";
                            DialogResult dialogResult1 = CustomMessageBox.Show(MessageShow + "\nOther Wise you can Edit it from the client Profile directly.", CustomMessageBox.Type.Error);
                        }
                        else
                        {
                            DialogResult dialogResult = CustomMessageBox.Show(MessageShow + "\nAre you sure you want to proceed?", CustomMessageBox.Type.YesNoWarning);
                            if (dialogResult == DialogResult.Yes)
                            {
                              
                                ClassBackOffice.UndoOffresSQL(ArchiveId);


                                if (IsMoneyOrSession == true)//undo money update
                                {
                                    double ToBalance = Convert.ToDouble(PreviousOffre.Split('/')[1]);
                                    double FromBalance = Convert.ToDouble(PreviousOffre.Split('/')[0]);
                                    (double UpdatedBalance, string UpdatedOffre, bool NewIsExpired) = ClassClientBalance.UpdateClientBalanceOnEditingBalanceOffre(clientId, DesiredClientBlanaceRow, FromBalance, ToBalance, null, false);


                                    //Design
                                    if (IsChildMode && this.ParentFormClientManagem != null)//we know if ChildMode, ha tkun only one row,
                                    {
                                        this.DesiredBalanceRowBinded["balance"] = UpdatedBalance;
                                        this.DesiredBalanceRowBinded["offre"] = UpdatedOffre;
                                        this.DesiredBalanceRowBinded["is_expired"] = NewIsExpired;

                                        this.ParentFormClientManagem.UpdateBalance(this.DesiredBalanceRowBinded, ToBalance);//ased aam nebaat To mahal from , lieanno undo
                                    }
                                }
                                else
                                {
                                    int ToSessionOrDays = Convert.ToInt32(PreviousOffre.Split('/')[1]);//ma ela aaze el refe hone, bas lieanno bi payment eezneha , medtarrin nhatta hone, bas ma ha teaddim w teakkhir
                                    int FromSessionOrDays = Convert.ToInt32(PreviousOffre.Split('/')[0]);

                                    (int UpdatedSessionLeftORNoDays, string newoffre, DateTime? NewDueDate, bool NewIsExpired) = ClassClientBalance.UpdateClientBalanceOnEditingSessionOffre(clientId, DesiredClientBlanaceRow, FromSessionOrDays, ToSessionOrDays, null, false);



                                    //Design 
                                    if (IsChildMode && this.ParentFormClientManagem != null)
                                    {
                                        //design                                      
                                        this.DesiredBalanceRowBinded["offre"] = newoffre;
                                        this.DesiredBalanceRowBinded["is_expired"] = NewIsExpired;
                                        if (NewDueDate == null)//session bundle
                                        {
                                            this.DesiredBalanceRowBinded["session_left_days"] = UpdatedSessionLeftORNoDays;
                                        }
                                        else//days bundle
                                        {
                                            this.DesiredBalanceRowBinded["session_left_days"] = RandomFunctions.GetDaysDifference(DateTime.Now, (DateTime)NewDueDate);//tene wahde - awwal wahde
                                            this.DesiredBalanceRowBinded["due_date"] = NewDueDate;
                                        }


                                        this.ParentFormClientManagem.UpdateSessionNumber(this.DesiredBalanceRowBinded);//from bel awwal ,lieanno hal value li badna nerjaa aalaya


                                    }
                                }

                                //Design in Profile if Exists

                                //design in BackofficeForm
                                DeletingDatagridRowsAndActiveTheEvent(ArchiveId);
                            }

                        }



                    }

                }

            }
        }


        void UpdateProfileDesingOnUndoSoloPurchase(int DesiredClientBalanceId, DateTime? NewLastVistDate, DateTime? MembershipDate, bool IsMembershipDateChanged)
        {

            //datagridbalance bel profile 

            DataRow rowToEdit = this.ParentFormClientManagem.dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);
            rowToEdit.Delete();
            this.ParentFormClientManagem.dtClientBalanceOriginal.AcceptChanges();
            this.ParentFormClientManagem.FormatDatagridviewDesign();
            //datagridbalance bel backoffice el tahteniye
            this.DesiredBalanceRowBinded.Delete();
            //deleting the uc pakcgae


            this.ParentFormClientManagem.CalculatingTotalBalancesDesignAndSql(false);
            this.ParentFormClientManagem.CalculatingClientHistoryDesignAndSql(false);
            this.ParentFormClientManagem.datagridviewBalanceMode();
            //
            if (IsMembershipDateChanged)
            {
                this.ParentFormClientManagem.Client.RegistrationDate = MembershipDate;
                if (MembershipDate != null)
                {
                    this.ParentFormClientManagem.UCMemberSince.Detail = RandomFunctions.SetDateFormat(((DateTime)MembershipDate).ToString());
                }
                else
                {
                    this.ParentFormClientManagem.UCMemberSince.Detail = "N/A";
                }

            }

            UpdateLastVisitDesign(NewLastVistDate, this);


            this.ParentFormClientManagem.Client.TotalAttendance--;
            this.ParentFormClientManagem.UCTotalAttendance.Detail = Convert.ToString(this.ParentFormClientManagem.Client.TotalAttendance);


        }
        void UpdateProfileDesingOnUndoPurchase(int DesiredClientBalanceId, bool IsBundleOrProduct, DateTime? MembershipDate, bool IsMembershipDateChanged)
        {
            //datagridBalance bel profile 
            DataRow rowToEdit = this.ParentFormClientManagem.dtClientBalanceOriginal.Rows.Find(DesiredClientBalanceId);
            rowToEdit.Delete();
            this.ParentFormClientManagem.dtClientBalanceOriginal.AcceptChanges();
            this.ParentFormClientManagem.FormatDatagridviewDesign();
            //datagridBalancebel backoffice el tahteniye
            this.DesiredBalanceRowBinded.Delete();//bel all transaction ma ha ysir shi lieannoo the desiredrow manno binded aa datagrid (which doesnt exists)
            //deleting the uc pakcgae
            if (IsBundleOrProduct)
            {
                this.ParentFormClientManagem.DeleteUcPackage(DesiredClientBalanceId);
            }

            this.ParentFormClientManagem.CalculatingTotalBalancesDesignAndSql(false);
            this.ParentFormClientManagem.CalculatingClientHistoryDesignAndSql(false);
            this.ParentFormClientManagem.datagridviewBalanceMode();
            //
            if (IsBundleOrProduct && IsMembershipDateChanged)//bundle
            {
                this.ParentFormClientManagem.Client.RegistrationDate = MembershipDate;
                if (MembershipDate != null)
                {
                    this.ParentFormClientManagem.UCMemberSince.Detail = RandomFunctions.SetDateFormat(((DateTime)MembershipDate).ToString());
                }
                else
                {
                    this.ParentFormClientManagem.UCMemberSince.Detail = "N/A";
                }
            }
        }
        void UpdateProfileDesingOnUndoPayment(double AmountPaid, int ClientBalanceId)
        {

            //design
            double OldBalance = (double)this.DesiredBalanceRowBinded["balance"];
            string balance = Convert.ToString(OldBalance - AmountPaid);//eza kenit balance=-50 w paid 50 bet sir balance -100

            //updating backoffice datatgridbalancce
            this.DesiredBalanceRowBinded["balance"] = balance;
            this.DesiredBalanceRowBinded["amount_paid"] = (double)this.DesiredBalanceRowBinded["amount_paid"] - AmountPaid;
            bool IsExpired = Convert.ToBoolean(this.DesiredBalanceRowBinded["is_expired"]);
            if (IsExpired == true)//in case kenit true, akid sarit false men baaed ma meemelna undo
            {
                this.DesiredBalanceRowBinded["is_expired"] = false;
            }
            //updating original datatbalance
            DataRow rowToEdit = this.ParentFormClientManagem.dtClientBalanceOriginal.Rows.Find(this.DesiredBalanceRowBinded["client_balance_id"]);
            rowToEdit["balance"] = this.DesiredBalanceRowBinded["balance"];
            rowToEdit["amount_paid"] = this.DesiredBalanceRowBinded["amount_paid"];
            if (IsExpired)
            {
                rowToEdit["is_expired"] = this.DesiredBalanceRowBinded["is_expired"];
                this.ParentFormClientManagem.ResortOriginalDataTableAndSetDatasource();

                if (rowToEdit["bundle_id"] != DBNull.Value && rowToEdit["session_left_days"] != DBNull.Value)//package
                {
                    //creating back the uc
                    //Add UCbundle
                    this.ParentFormClientManagem.CheckAndSetNoBundleLabel();
                    this.ParentFormClientManagem.CreateUCPackage(rowToEdit);
                }
            }

            if (rowToEdit["bundle_id"] != DBNull.Value && rowToEdit["session_left_days"] != DBNull.Value)//package
            {
                if (OldBalance == 0)// since eza kenit 0 w eemelna undo la payment yaane for sur ha tzid negativily wich means ha yetghayar el state
                {
                    this.ParentFormClientManagem.UpdateIsInDebteToUCBundle(ClientBalanceId, true);
                }
            }

            this.ParentFormClientManagem.FormatDatagridviewDesign();
            //
            this.ParentFormClientManagem.CalculatingTotalBalancesDesignAndSql(false);
            this.ParentFormClientManagem.CalculatingClientHistoryDesignAndSql(false);

        }
        void UpdateProfileDesingOnUndoSession(DateTime? NewLastVistDate)
        {

            //Datagridview 
            int ClientBalanceID = Convert.ToInt32(this.DesiredBalanceRowBinded["client_balance_id"]);
            int NoOfSessions = Convert.ToInt32(this.DesiredBalanceRowBinded["session_left_days"]) + 1;
            bool IsExpired = Convert.ToBoolean(this.DesiredBalanceRowBinded["is_expired"]);

            this.DesiredBalanceRowBinded["session_left_days"] = NoOfSessions;

            if (IsExpired == true)//in case kenit true, akid sarit false men baaed ma meemelna undo
            {
                this.DesiredBalanceRowBinded["is_expired"] = false;
            }

            //Updating the original datarow
            DataRow rowToEdit = this.ParentFormClientManagem.dtClientBalanceOriginal.Rows.Find(ClientBalanceID);
            rowToEdit["session_left_days"] = NoOfSessions;

            //Update related UC in client profile    
            if (IsExpired)
            {
                rowToEdit["is_expired"] = this.DesiredBalanceRowBinded["is_expired"];
                if (rowToEdit["bundle_id"] != DBNull.Value && rowToEdit["session_left_days"] != DBNull.Value)//packages
                {
                    //creating back the uc
                    //Add UCbundle
                    this.ParentFormClientManagem.CheckAndSetNoBundleLabel();
                    this.ParentFormClientManagem.CreateUCPackage(rowToEdit);

                }
                //bas hone staamelneha,cz bas in this case ha nkun aam nghayyir bel datagridview
                this.ParentFormClientManagem.ResortOriginalDataTableAndSetDatasource();
                this.ParentFormClientManagem.FormatDatagridviewDesign();

            }
            else
            {
                this.ParentFormClientManagem.ResetUCMode(ClientBalanceID, NoOfSessions, null);
            }



            UpdateLastVisitDesign(NewLastVistDate, this);


            this.ParentFormClientManagem.Client.TotalAttendance--;
            this.ParentFormClientManagem.UCTotalAttendance.Detail = Convert.ToString(this.ParentFormClientManagem.Client.TotalAttendance);


        }

        void UpdateLastVisitDesign(DateTime? NewLastVistDate, BackOffice backofficeform)
        {
            //Client Prodile 
            string StringNewLastVisitDate;
            if (NewLastVistDate != null)
            {
                StringNewLastVisitDate = RandomFunctions.SetDateFormat(Convert.ToString(NewLastVistDate));
            }
            else
            {
                StringNewLastVisitDate = "N/A";
            }
            backofficeform.ParentFormClientManagem.UCLastVisit.Detail = StringNewLastVisitDate;
            backofficeform.ParentFormClientManagem.Client.LastVisit = NewLastVistDate;
        }

        public static event EventHandler UndoHappened;
        void DeletingDatagridRowsAndActiveTheEvent(int ArchiveId)
        {

            UndoHappened?.Invoke(this, EventArgs.Empty);

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






        private void dataGridViewBalance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dataGridViewBalance.Rows.Count && e.ColumnIndex < dataGridViewBalance.Columns.Count)
            {
                ClassClientBalanceFront.FixCellsFormat(dataGridViewBalance, e);
            }
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
