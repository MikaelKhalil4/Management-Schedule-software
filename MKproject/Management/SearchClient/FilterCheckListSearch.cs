using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GlobalFunctions;
using CustomizedTools;


namespace MKproject.Management
{
    public partial class FilterCheckListSearch : Form
    {


        public SearchCurrentClient ParentFormSearch { get; set; }

        public FilterCheckListSearch()
        {
            InitializeComponent();
        }


        public void FilterDatable()
        {       
            ParentFormSearch.firstVisibleRowIndex = 0;

            DataTable Filtereddt = ParentFormSearch.Originaldt.Copy();
            if (ParentFormSearch.textBoxSearch.Text != ParentFormSearch.textBoxSearch.PlaceholderText)
            {
                String Input = ParentFormSearch.textBoxSearch.Text.TrimEnd();

                if (RandomFunctions.CheckIfContainsOnlyDigits(Input))
                {
                    Filtereddt = FiltersDataTable.FilterDatatableIfContainsIgnoringCapitals("Phone Number", Input, Filtereddt);
                }
                else
                {
                    Filtereddt = FiltersDataTable.FilterDatatableIfContainsIgnoringCapitals("Full Name", Input, Filtereddt);
                }
            }

            if (ParentFormSearch.FLPFiltersSlideSDhow.Controls.Count > 0)
            {


                if (checkBoxGender.Checked)
                {
                    string selectedString = UCGender.comboBoxDetail.SelectedItem.ToString();
                    if (selectedString != UCComboBoxFilterSearch.All)
                    {
                        Filtereddt = FiltersDataTable.FilterDatatableIFStringEquality("Gender", selectedString, Filtereddt);
                    }
                }



                if (checkBoxAlbum.Checked)
                {
                    string selectedString = UCAlbum.comboBoxDetail.SelectedItem.ToString();
                    if (selectedString != UCComboBoxFilterSearch.All)
                    {

                        Filtereddt = FiltersDataTable.FilterDatatableIFStringEquality("Album", selectedString, Filtereddt);
                    }
                }


                if (checkBoxType.Checked)
                {
                    string selectedString = UCType.comboBoxDetail.SelectedItem.ToString();
                    if (selectedString != UCComboBoxFilterSearch.All)
                    {
                        Filtereddt = FiltersDataTable.FilterDatatableIFStringEquality("Type", selectedString, Filtereddt);
                    }
                }


                if (checkBoxAgeCategory.Checked)
                {
                    string selectedString = UCAgecategory.comboBoxDetail.SelectedItem.ToString();
                    if (selectedString != UCComboBoxFilterSearch.All)
                    {

                        Filtereddt = FiltersDataTable.FilterDatatableIFStringEquality("Age Category", selectedString, Filtereddt);
                    }

                }

                if (checkBoxSaveDate.Checked)
                {

                    string selectedString = UCSaveDate.comboBoxDetail.SelectedItem.ToString();
                    if (selectedString == UCComboBoxFilterSearch.ThisMonth)
                        Filtereddt = FiltersDataTable.FilterDatatableDateThisMonth("save_date", Filtereddt);
                    else if (selectedString == UCComboBoxFilterSearch.LastMonth)
                        Filtereddt = FiltersDataTable.FilterDatatableDateLastMonth("save_date", Filtereddt);
                    else if (selectedString == UCComboBoxFilterSearch.ThisYear)
                        Filtereddt = FiltersDataTable.FilterDatatableDateThisYear("save_date", Filtereddt);
                    else if (selectedString == UCComboBoxFilterSearch.LastYear)
                        Filtereddt = FiltersDataTable.FilterDatatableDateLastYear("save_date", Filtereddt);
                    else if (selectedString == UCComboBoxFilterSearch.CustomDate)
                    {
                        if (UCCustomeDateSave.Startdate != null && UCCustomeDateSave.Enddate != null)
                        {
                            Filtereddt = FiltersDataTable.FilterDatatableDateCustomDate("save_date", Filtereddt, (DateTime)UCCustomeDateSave.Startdate, (DateTime)UCCustomeDateSave.Enddate);
                        }
                    }

                }


                if (checkBoxLastVisit.Checked)
                {

                    string selectedString = UCLastVisit.comboBoxDetail.SelectedItem.ToString();
                    if (selectedString == UCComboBoxFilterSearch.ThisMonth)
                        Filtereddt = FiltersDataTable.FilterDatatableDateThisMonth("check_in", Filtereddt);
                    else if (selectedString == UCComboBoxFilterSearch.LastMonth)
                        Filtereddt = FiltersDataTable.FilterDatatableDateLastMonth("check_in", Filtereddt);
                    else if (selectedString == UCComboBoxFilterSearch.ThisYear)
                        Filtereddt = FiltersDataTable.FilterDatatableDateThisYear("check_in", Filtereddt);
                    else if (selectedString == UCComboBoxFilterSearch.LastYear)
                        Filtereddt = FiltersDataTable.FilterDatatableDateLastYear("check_in", Filtereddt);
                    else if (selectedString == UCComboBoxFilterSearch.CustomDate)
                    {
                        if (UCCustomeDateLastVisit.Startdate != null && UCCustomeDateLastVisit.Enddate != null)
                        {
                            Filtereddt = FiltersDataTable.FilterDatatableDateCustomDate("check_in", Filtereddt, (DateTime)UCCustomeDateLastVisit.Startdate, (DateTime)UCCustomeDateLastVisit.Enddate);
                        }
                    }

                }


                if (checkBoxRegistration.Checked)
                {

                    string selectedString = UCRegistrationDate.comboBoxDetail.SelectedItem.ToString();
                    if (selectedString == UCComboBoxFilterSearch.ThisMonth)
                        Filtereddt = FiltersDataTable.FilterDatatableDateThisMonth("Registration_Date", Filtereddt);
                    else if (selectedString == UCComboBoxFilterSearch.LastMonth)
                        Filtereddt = FiltersDataTable.FilterDatatableDateLastMonth("Registration_Date", Filtereddt);
                    else if (selectedString == UCComboBoxFilterSearch.ThisYear)
                        Filtereddt = FiltersDataTable.FilterDatatableDateThisYear("Registration_Date", Filtereddt);
                    else if (selectedString == UCComboBoxFilterSearch.LastYear)
                        Filtereddt = FiltersDataTable.FilterDatatableDateLastYear("Registration_Date", Filtereddt);
                    else if (selectedString == UCComboBoxFilterSearch.CustomDate)
                    {
                        if (UCCustomeDateRegistartion.Startdate != null && UCCustomeDateRegistartion.Enddate != null)
                        {
                            Filtereddt = FiltersDataTable.FilterDatatableDateCustomDate("Registration_Date", Filtereddt, (DateTime)UCCustomeDateRegistartion.Startdate, (DateTime)UCCustomeDateRegistartion.Enddate);
                        }
                    }
                }

                if (checkBoxJob.Checked)
                {
                    string selectedString = UCJob.textBox.Text.TrimEnd();
                    if (selectedString != UCJob.textBox.PlaceholderText && !String.IsNullOrEmpty(selectedString))
                    {
                        Filtereddt = FiltersDataTable.FilterDatatableIfContainsIgnoringCapitals("Job", selectedString, Filtereddt);
                    }
                }


                if (checkBoxAdress.Checked)
                {
                    string selectedString = UCAdress.textBox.Text.TrimEnd();
                    if (selectedString != UCAdress.textBox.PlaceholderText && !String.IsNullOrEmpty(selectedString))
                    {
                        Filtereddt = FiltersDataTable.FilterDatatableIfContainsIgnoringCapitals("Adress", selectedString, Filtereddt);
                    }
                }

            }

            ParentFormSearch.DataTableToDatagrid(Filtereddt);
        }




        public void FixGrandParentFilterSize()//lamma ysir eena 3 rows w tlouu bet battil tozbat, it can bi fixed better
        {

            decimal totalChildControlwidtht = 0;
            foreach (Control control in ParentFormSearch.FLPFiltersSlideSDhow.Controls)
            {
                if (control.Visible == true)
                {
                    totalChildControlwidtht += control.Width + control.Margin.Left + control.Margin.Right;
                }
            }

            decimal originalValue = totalChildControlwidtht / ParentFormSearch.FLPFiltersSlideSDhow.Width;
            int roundedValue = (int)Math.Ceiling(originalValue);

            int newHeightValue = 70 * roundedValue;


            if (ParentFormSearch.targetedHeight < newHeightValue)
            {
                ParentFormSearch.targetedHeight = newHeightValue;
                ParentFormSearch.timerFilterOn.Start();
            }
            else if (ParentFormSearch.targetedHeight > newHeightValue)
            {
                ParentFormSearch.targetedHeight = newHeightValue;
                ParentFormSearch.timerFilterOff.Start();
            }

        }


        UCLabelFilterOriginal UCCustomDate;//kermel nestaamela bel event closing
        public void OpenDateFilterForm(UCLabelFilterOriginal ucCustomDate)
        {
            if (Program.GreyForm == null)
            {
                UCCustomDate = ucCustomDate;
                Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
                Program.GreyForm.Show();
                FilterCustomDate filterDate = new FilterCustomDate(UCCustomDate);
                filterDate.FormClosed += FilterDate_FormClosed;
                filterDate.Show();
            }
        }

        private void FilterDate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UCCustomDate.Startdate == null && UCCustomDate.Enddate == null)//yaane sakarna el filterdateform w ma naeyna shi wala date
            {
                UCCustomDate.Dispose();//this will activate an event which will reset the combobox since ma naena shi
            }
            FixGrandParentFilterSize();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }
        public void ClearFilters()
        {
            ParentFormSearch.buttonResetOrder.Visible = false;
            foreach (CheckBox c in panelCheckBoxes.Controls)
            {
                if (c.Checked)
                {
                    c.Checked = false;
                }
            }
            this.Hide();
        }

        //ejbare el order awwal shi bel events tahet, kermel naamil bnnzabeta bel original dt, abel ma nekhla new filterdt which is copy of the original
        void SetIndex(string ColumnName)
        {
            int SelectedRowBefore = ParentFormSearch.dataGridViewClients.SelectedRows.Count;

            int columnIndexToMove;
            columnIndexToMove = ParentFormSearch.Originaldt.Columns.IndexOf(ColumnName); // Replace with the actual column name    
            ParentFormSearch.Originaldt.Columns[columnIndexToMove].SetOrdinal(ParentFormSearch.Originaldt.Columns.Count - 1);

            columnIndexToMove = ParentFormSearch.Filtereddt.Columns.IndexOf(ColumnName); // Replace with the actual column name    
            ParentFormSearch.Filtereddt.Columns[columnIndexToMove].SetOrdinal(ParentFormSearch.Originaldt.Columns.Count - 1);

            ParentFormSearch.dataGridViewClients.Columns[ColumnName].DisplayIndex = ParentFormSearch.dataGridViewClients.Columns.Count - 1;
        
            if (ParentFormSearch.dataGridViewClients.Rows.Count > 0)
            {
                ParentFormSearch.dataGridViewClients.FirstDisplayedScrollingRowIndex = ParentFormSearch.firstVisibleRowIndex;
            }


            //so we changed he index in both kermel yemshe el hal, even law bel datatsource aam yetghayyar el order, bas en realite ma aam ysir shi, so its tricky, hopefulll to be understood better in wpf

            if (SelectedRowBefore == 0)
            {
                ParentFormSearch.dataGridViewClients.ClearSelection();
            }

        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.Checked)
            {

                foreach (CheckBox c in panelCheckBoxes.Controls)
                {
                    if (!c.Checked)
                    {
                        c.Checked = true;
                    }
                }

            }
            else if (!checkBoxSelectAll.Checked)
            {

                foreach (CheckBox c in panelCheckBoxes.Controls)
                {
                    if (c.Checked)
                    {
                        c.Checked = false;
                    }

                }


            }
            FixGrandParentFilterSize();
        }
        UCComboBoxFilterSearch UCAgecategory;
        private void checkBoxAgeCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAgeCategory.Checked)
            {
                SetIndex("Age Category");
                UCAgecategory = new UCComboBoxFilterSearch();
                UCAgecategory.Title = "Age Category";
                UCAgecategory.ParentFormFilter = this;
                UCAgecategory.FilterType = UCComboBoxFilterSearch.FiltersType.AgeCategory;
                UCAgecategory.Show();
                ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCAgecategory);
                ParentFormSearch.dataGridViewClients.Columns["Age Category"].Visible = true;

            }
            else
            {
                UCAgecategory.comboBoxDetail.SelectedIndex = 0;
                //we couldnt use Dispose, cz it s making the filter close
                UCAgecategory.Visible = false;
                UCAgecategory = null;
                ParentFormSearch.dataGridViewClients.Columns["Age Category"].Visible = false;

            }
            FixGrandParentFilterSize();
        }

        UCComboBoxFilterSearch UCGender;
        private void checkBoxGender_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGender.Checked)
            {
                SetIndex("Gender");
                UCGender = new UCComboBoxFilterSearch();
                UCGender.Title = "Gender";
                UCGender.ParentFormFilter = this;
                UCGender.FilterType = UCComboBoxFilterSearch.FiltersType.Gender;
                UCGender.Show();
                ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCGender);
                ParentFormSearch.dataGridViewClients.Columns["Gender"].Visible = true;


            }
            else
            {
                UCGender.comboBoxDetail.SelectedIndex = 0;
                //we couldnt use Dispose, cz it s making the filter close
                UCGender.Visible = false;
                UCGender =null;
                ParentFormSearch.dataGridViewClients.Columns["Gender"].Visible = false;                             
            }
            FixGrandParentFilterSize();
        }
        UCComboBoxFilterSearch UCType;
        private void checkBoxType_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxType.Checked)
            {
                SetIndex("Type");//ejbare el order hone, kermel naamil bnnzabeta bel original dt, abel ma nekhla new filterdt which is copy of the original
                UCType = new UCComboBoxFilterSearch();
                UCType.Title = "Type";
                UCType.ParentFormFilter = this;
                UCType.FilterType = UCComboBoxFilterSearch.FiltersType.Type;
                UCType.Show();

                ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCType);

                ParentFormSearch.dataGridViewClients.Columns["Type"].Visible = true;

            }
            else
            {
                UCType.comboBoxDetail.SelectedIndex = 0;
                //we couldnt use Dispose, cz it s making the filter close
                UCType.Visible = false;
                UCType = null;
                ParentFormSearch.dataGridViewClients.Columns["Type"].Visible = false;

            }
            FixGrandParentFilterSize();
        }

        UCComboBoxFilterSearch UCAlbum;
        private void checkBoxAlbum_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAlbum.Checked)
            {
                SetIndex("Album");
                UCAlbum = new UCComboBoxFilterSearch();
                UCAlbum.Title = "Album";
                UCAlbum.ParentFormFilter = this;
                UCAlbum.FilterType = UCComboBoxFilterSearch.FiltersType.Album;
                UCAlbum.Show();
                ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCAlbum);
                ParentFormSearch.dataGridViewClients.Columns["Album"].Visible = true;

            }
            else
            {
                UCAlbum.comboBoxDetail.SelectedIndex = 0;
                //we couldnt use Dispose, cz it s making the filter close
                UCAlbum.Visible = false;
                UCAlbum = null;
                ParentFormSearch.dataGridViewClients.Columns["Album"].Visible = false;

            }
            FixGrandParentFilterSize();
        }

        UCComboBoxFilterSearch UCBalance;
        private void checkBoxClientBalance_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClientBalance.Checked)
            {
                SetIndex("Total Balance");
                UCBalance = new UCComboBoxFilterSearch();
                UCBalance.Title = "Balance";
                UCBalance.ParentFormFilter = this;
                UCBalance.FilterType = UCComboBoxFilterSearch.FiltersType.Balance;
                UCBalance.Show();
                ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCBalance);
                ParentFormSearch.dataGridViewClients.Columns["Total Balance"].Visible = true;

            }
            else
            {
                UCBalance.comboBoxDetail.SelectedIndex = 0;
                //we couldnt use Dispose, cz it s making the filter close
                UCBalance.Visible = false;
                UCBalance = null;
                ParentFormSearch.dataGridViewClients.Columns["Total Balance"].Visible = false;

            }
            FixGrandParentFilterSize();
        }

        UCComboBoxFilterSearch UCPayment;
        private void checkBoxClientPayments_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClientPayments.Checked)
            {
                SetIndex("Total payment");
                UCPayment = new UCComboBoxFilterSearch();
                UCPayment.Title = "Payments";
                UCPayment.ParentFormFilter = this;
                UCPayment.FilterType = UCComboBoxFilterSearch.FiltersType.Payment;
                UCPayment.Show();
                ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCPayment);
                ParentFormSearch.dataGridViewClients.Columns["Total payment"].Visible = true;

            }
            else
            {
                UCPayment.comboBoxDetail.SelectedIndex = 0;
                //we couldnt use Dispose, cz it s making the filter close
                UCPayment.Visible = false;
                UCPayment = null;
                ParentFormSearch.dataGridViewClients.Columns["Total payment"].Visible = false;

            }
            FixGrandParentFilterSize();
        }




        public DataTable OriginalAttendDtt;
        Dictionary<int, int> GroupedAndFilteredDictionary = new Dictionary<int, int>();
        UCComboBoxFilterSearch UCSessionDone;
        private void checkBoxTotalAttendance_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTotalAttendance.Checked)
            {
                SetIndex("Total Attendance");
                UCSessionDone = new UCComboBoxFilterSearch();
                UCSessionDone.Title = "Total Attendance";
                UCSessionDone.ParentFormFilter = this;
                UCSessionDone.FilterType = UCComboBoxFilterSearch.FiltersType.SessionDone;
                UCSessionDone.Show();
                ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCSessionDone);
                ParentFormSearch.dataGridViewClients.Columns["Total Attendance"].Visible = true;
            }
            else
            {
                UCSessionDone.comboBoxDetail.SelectedIndex = 0;
                //we couldnt use Dispose, cz it s making the filter close
                UCSessionDone.Visible = false;
                UCSessionDone = null;
                ParentFormSearch.dataGridViewClients.Columns["Total Attendance"].Visible = false;
            }
            FixGrandParentFilterSize();
        }
        public void FillSessionDoneColumn()//will be called in comboxboxchangedindex
        {
            Cursor.Current = Cursors.WaitCursor;
            //client struct
            OriginalAttendDtt = SQLToProject.GetAllClientAttendance(null);//always, lieanno eza fetna profile w ghayrna w jina hattayna column check banda yeha taamil refresh, so ma tfakkir tshila

            FilterDatatableByDate(UCSessionDone.comboBoxDetail.SelectedItem.ToString());//filtering and grouping by

            foreach (DataRow row in ParentFormSearch.Filtereddt.Rows)
            {
                int SessionDone;
                GroupedAndFilteredDictionary.TryGetValue(Convert.ToInt32(row["client_id"]), out SessionDone);
                row["Total Attendance"] = SessionDone;
            }
            foreach (DataRow row in ParentFormSearch.Originaldt.Rows)
            {
                int SessionDone;
                GroupedAndFilteredDictionary.TryGetValue((Convert.ToInt32(row["client_id"])), out SessionDone);
                row["Total Attendance"] = SessionDone;
            }
            Cursor.Current = Cursors.Default;
        }
        void FilterDatatableByDate(string date)
        {
            DateTime FilterDate = new DateTime();
            DataTable FilteredStructdt = OriginalAttendDtt.Copy();
            if (date != UCComboBoxFilterSearch.All)
            {
                if (date == UCComboBoxFilterSearch.Last30Days)
                {
                    FilterDate = DateTime.Now.AddDays(-30);
                }
                else if (date == UCComboBoxFilterSearch.Last90Days)
                {
                    FilterDate = DateTime.Now.AddDays(-90);
                }
                else if (date == UCComboBoxFilterSearch.Last180Days)
                {
                    FilterDate = DateTime.Now.AddDays(-180); ;
                }
                else if (date == UCComboBoxFilterSearch.Last365Days)
                {
                    FilterDate = DateTime.Now.AddDays(-365); ;
                }
                FilteredStructdt = FiltersDataTable.FilterDatatableDateCustomDate("execute_date", FilteredStructdt, FilterDate, DateTime.Today);
            }
            GroupClients(FilteredStructdt);
        }
        void GroupClients(DataTable FilteredStructdt)
        {
            // Group by client_id and count sessions
            var groupedData = from row in FilteredStructdt.AsEnumerable()
                              group row by new
                              {
                                  ClientId = row.Field<Int64>("client_id"),
                              } into grp
                              select new
                              {
                                  ClientId = grp.Key.ClientId,
                                  NumberOfSessions = grp.Count()
                              };

            GroupedAndFilteredDictionary.Clear();
            foreach (var group in groupedData)
            {
                GroupedAndFilteredDictionary.Add(Convert.ToInt32(group.ClientId), group.NumberOfSessions);
            }

        }






        DataTable PackageRemainingsDt;
        UCComboBoxFilterSearch UCPackagesRemaing;
        private void checkBoxPackagesRemaining_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPackagesRemaining.Checked)
            {

                SetIndex("Packages Remaining");
                UCPackagesRemaing = new UCComboBoxFilterSearch();
                UCPackagesRemaing.Title = "Packages Remaining";
                UCPackagesRemaing.ParentFormFilter = this;
                FillPackagesRemainingColumn();//ejbare abel ma taamil filter aal table
                UCPackagesRemaing.FilterType = UCComboBoxFilterSearch.FiltersType.PackagesRemaining;//filter is done in here,comboboxchangedindex
                UCPackagesRemaing.Show();
                ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCPackagesRemaing);
                ParentFormSearch.dataGridViewClients.Columns["Packages Remaining"].Visible = true;

            }
            else
            {

                UCPackagesRemaing.comboBoxDetail.SelectedIndex = 0;
                //we couldnt use Dispose, cz it s making the filter close
                UCPackagesRemaing.Visible = false;
                UCPackagesRemaing = null;
                ParentFormSearch.dataGridViewClients.Columns["Packages Remaining"].Visible = false;

            }

            FixGrandParentFilterSize();
        }
        public void FillPackagesRemainingColumn()
        {

            if (PackageRemainingsDt == null)
            {
                Cursor = Cursors.WaitCursor;

                PackageRemainingsDt = ClassClientBalance.GetClientBalanceNotExpiredPackage(null);
                foreach (DataRow row in ParentFormSearch.Originaldt.Rows)//we re filling both the original dt and filtered dt
                {
                    string PackagesRemianing;
                    int status;
                    bool HasStatus;
                    (PackagesRemianing, status, HasStatus) = CalculateClientRemainingPackages(PackageRemainingsDt.Select("client_id = " + row["client_id"]));
                    (row["Packages Remaining"], row["Packages Status"], row["Packages HasStatus"]) = (PackagesRemianing, status, HasStatus);

                    DataRow DesiredRow;
                    DataRow[] foundRow = ParentFormSearch.Filtereddt.Select("client_id = " + row["client_id"]);
                    if (foundRow.Length == 1)//we re sure that we re going to have only one row   
                    {
                        DesiredRow = foundRow[0];
                        (DesiredRow["Packages Remaining"], DesiredRow["Packages Status"], DesiredRow["Packages HasStatus"]) = (PackagesRemianing, status, HasStatus);
                    }
                }
                Cursor = Cursors.Default;
            }

        }

        public static (string, int, bool) CalculateClientRemainingPackages(DataRow[] DtRows)
        {
            string NotAv = "N/A";
            string PackageRemainings = "";
            int PackageStatus;
            bool PackageHasStatus;//1 if has value, 0 if null
            foreach (DataRow dtrow in DtRows)
            {

                PackageRemainings += ClassClientBalance.SetPackageRemainingsFormat(dtrow);               
                PackageRemainings += Environment.NewLine;
            }

            if (PackageRemainings == "")
            {
                PackageRemainings = NotAv;
            }
            if (PackageRemainings.EndsWith("\r\n"))
                PackageRemainings = PackageRemainings.Substring(0, PackageRemainings.Length - 2);


            if (PackageRemainings.Contains(" 0 "))
            {
                PackageStatus = 0;
                PackageHasStatus = true;

            }
            else if (PackageRemainings.Contains(" 1 "))
            {
                PackageStatus = 1;
                PackageHasStatus = true;
            }
            else if (PackageRemainings.Contains(NotAv))
            {
                PackageStatus = -1;//bas ma bi hemna amra men el asel
                PackageHasStatus = false;
            }
            else
            {
                PackageStatus = 2;
                PackageHasStatus = true;

            }
            return (PackageRemainings, PackageStatus, PackageHasStatus);
        }







        string JobOldText;
        UCTextBoxFilterOriginal UCJob;
        private void checkBoxJob_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxJob.Checked)
            {
                SetIndex("Job");
                UCJob = new UCTextBoxFilterOriginal();
                UCJob.TextBoxTextChanged += UCJob_TextBoxTextChanged;
                UCJob.Title = "Job";
                UCJob.PlaceHolderOfTextBox = "Filter by job...";
                UCJob.Show();
                ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCJob);
                ParentFormSearch.dataGridViewClients.Columns["Job"].Visible = true;

            }
            else
            {
                UCJob.textBox.Text = "";//kremel yaamil refilter
                UCJob.Dispose();//hone fina netreka
                ParentFormSearch.dataGridViewClients.Columns["Job"].Visible = false;
                //eemelta ased hek lieanno ma btozbate gher hek , ma tfakkir tetzeka


            }
            FixGrandParentFilterSize();
        }
        private void UCJob_TextBoxTextChanged(object sender, EventArgs e)
        {
            string newText = UCJob.textBox.Text;
            if (!(String.IsNullOrEmpty(JobOldText) && newText == UCJob.textBox.PlaceholderText) && !(String.IsNullOrEmpty(newText) && JobOldText == UCJob.textBox.PlaceholderText))
            {
                FilterDatable();
            }
            JobOldText = UCJob.textBox.Text;
        }


        string AdressOldText;
        UCTextBoxFilterOriginal UCAdress;
        private void checkBoxAdress_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAdress.Checked)
            {
                SetIndex("Adress");
                UCAdress = new UCTextBoxFilterOriginal();
                UCAdress.TextBoxTextChanged += UCAdress_TextBoxTextChanged;
                UCAdress.Title = "Adress";
                UCAdress.PlaceHolderOfTextBox = "Filter by Adress...";
                UCAdress.Show();
                ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCAdress);

                ParentFormSearch.dataGridViewClients.Columns["Adress"].Visible = true;

            }
            else
            {
                UCAdress.textBox.Text = "";//kremel yaamil refilter
                UCAdress.Dispose();//hone fina netreka
                ParentFormSearch.dataGridViewClients.Columns["Adress"].Visible = false;
                //eemelta ased hek lieanno ma btozbate gher hek , ma tfakkir tetzeka

            }
            FixGrandParentFilterSize();
        }
        private void UCAdress_TextBoxTextChanged(object sender, EventArgs e)
        {
            string newText = UCAdress.textBox.Text;
            if (!(String.IsNullOrEmpty(AdressOldText) && newText == UCAdress.textBox.PlaceholderText) && !(String.IsNullOrEmpty(newText) && AdressOldText == UCAdress.textBox.PlaceholderText))
            {
                FilterDatable();
            }
            AdressOldText = UCAdress.textBox.Text;

        }





        public UCComboBoxFilterSearch UCSaveDate;
        private void checkBoxSaveDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSaveDate.Checked)
            {
                SetIndex("Save Date");
                UCSaveDate = new UCComboBoxFilterSearch();
                UCSaveDate.Title = "Save Date";
                UCSaveDate.ParentFormFilter = this;
                UCSaveDate.FilterType = UCComboBoxFilterSearch.FiltersType.SaveDate;
                UCSaveDate.Show();
                ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCSaveDate);
                ParentFormSearch.dataGridViewClients.Columns["Save Date"].Visible = true;

            }
            else
            {

                UCSaveDate.comboBoxDetail.SelectedIndex = 0;
                //we couldnt use Dispose, cz it s making the filter close
                UCSaveDate.Visible = false;
                UCSaveDate = null;
                ParentFormSearch.dataGridViewClients.Columns["Save Date"].Visible = false;

            }
            FixGrandParentFilterSize();
        }
        public UCLabelFilterSearch UCCustomeDateSave;
        public void CreateUCCustomeDateSave()
        {
            if (UCSaveDate.comboBoxDetail.SelectedItem.ToString() == UCComboBoxFilterSearch.CustomDate)
            {
                if (UCCustomeDateSave == null || UCCustomeDateSave.IsDisposed)
                {
                    UCCustomeDateSave = new UCLabelFilterSearch(UCLabelFilterSearch.FiltersCategories.SaveDate);
                    UCCustomeDateSave.FilterCheckListSearchForm = this;
                    UCCustomeDateSave.Title = " Custome Save Date";
                    UCCustomeDateSave.Visible = false;
                    ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCCustomeDateSave);
                    int indexFather = ParentFormSearch.FLPFiltersSlideSDhow.Controls.GetChildIndex(UCSaveDate);
                    ParentFormSearch.FLPFiltersSlideSDhow.Controls.SetChildIndex(UCCustomeDateSave, indexFather + 1);
                }
                OpenDateFilterForm(UCCustomeDateSave);
            }
            else
            {

                if (UCCustomeDateSave != null && !UCCustomeDateSave.IsDisposed)
                {
                    UCCustomeDateSave.Dispose();
                }
                FilterDatable();//in case kenit gher custom date taamil filter

            }
            FixGrandParentFilterSize();
        }



        public UCComboBoxFilterSearch UCLastVisit;
        private void checkBoxLastVisit_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLastVisit.Checked)
            {
                SetIndex("Last Visit");
                UCLastVisit = new UCComboBoxFilterSearch();
                UCLastVisit.Title = "Last Visit Date";
                UCLastVisit.ParentFormFilter = this;
                UCLastVisit.FilterType = UCComboBoxFilterSearch.FiltersType.LastVisit;
                UCLastVisit.Show();
                ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCLastVisit);
                ParentFormSearch.dataGridViewClients.Columns["Last Visit"].Visible = true;

            }
            else
            {
                UCLastVisit.comboBoxDetail.SelectedIndex = 0;
                //we couldnt use Dispose, cz it s making the filter close
                UCLastVisit.Visible = false;
                UCLastVisit = null;
                ParentFormSearch.dataGridViewClients.Columns["Last Visit"].Visible = false;

            }
            FixGrandParentFilterSize();
        }
        public UCLabelFilterSearch UCCustomeDateLastVisit;
        public void CreateUCCustomeDateLastVisit()
        {
            if (UCLastVisit.comboBoxDetail.SelectedItem.ToString() == UCComboBoxFilterSearch.CustomDate)
            {
                if (UCCustomeDateLastVisit == null || UCCustomeDateLastVisit.IsDisposed)
                {
                    UCCustomeDateLastVisit = new UCLabelFilterSearch(UCLabelFilterSearch.FiltersCategories.LastVisitDate);
                    UCCustomeDateLastVisit.FilterCheckListSearchForm = this;
                    UCCustomeDateLastVisit.Title = "Last Visit Custome Date";
                    UCCustomeDateLastVisit.Visible = false;
                    ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCCustomeDateLastVisit);
                    int indexFather = ParentFormSearch.FLPFiltersSlideSDhow.Controls.GetChildIndex(UCLastVisit);
                    ParentFormSearch.FLPFiltersSlideSDhow.Controls.SetChildIndex(UCCustomeDateLastVisit, indexFather + 1);

                }
                OpenDateFilterForm(UCCustomeDateLastVisit);
            }
            else
            {

                if (UCCustomeDateLastVisit != null && !UCCustomeDateLastVisit.IsDisposed)
                {
                    UCCustomeDateLastVisit.Dispose();
                }
                FilterDatable();//in case kenit gher custom date taamil filter

            }
            FixGrandParentFilterSize();
        }



        public UCComboBoxFilterSearch UCRegistrationDate;
        private void checkBoxRegistration_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRegistration.Checked)
            {
                SetIndex("Registration Date");
                UCRegistrationDate = new UCComboBoxFilterSearch();
                UCRegistrationDate.Title = "Registration Date";
                UCRegistrationDate.ParentFormFilter = this;
                UCRegistrationDate.FilterType = UCComboBoxFilterSearch.FiltersType.Registration;
                UCRegistrationDate.Show();
                ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCRegistrationDate);
                ParentFormSearch.dataGridViewClients.Columns["Registration Date"].Visible = true;


            }
            else
            {
                UCRegistrationDate.comboBoxDetail.SelectedIndex = 0;
                //we couldnt use Dispose, cz it s making the filter close
                UCRegistrationDate.Visible = false;
                UCRegistrationDate = null;
                ParentFormSearch.dataGridViewClients.Columns["Registration Date"].Visible = false;

            }
            FixGrandParentFilterSize();
        }
        public UCLabelFilterSearch UCCustomeDateRegistartion;
        public void CreateUCCustomeDateRegistration()
        {
            if (UCRegistrationDate.comboBoxDetail.SelectedItem.ToString() == UCComboBoxFilterSearch.CustomDate)
            {
                if (UCCustomeDateRegistartion == null || UCCustomeDateRegistartion.IsDisposed)
                {
                    UCCustomeDateRegistartion = new UCLabelFilterSearch(UCLabelFilterSearch.FiltersCategories.RegisterDate);
                    UCCustomeDateRegistartion.FilterCheckListSearchForm = this;
                    UCCustomeDateRegistartion.Title = "Registartion Custome Date";
                    UCCustomeDateRegistartion.Visible = false;
                    ParentFormSearch.FLPFiltersSlideSDhow.Controls.Add(UCCustomeDateRegistartion);
                    int indexFather = ParentFormSearch.FLPFiltersSlideSDhow.Controls.GetChildIndex(UCRegistrationDate);
                    ParentFormSearch.FLPFiltersSlideSDhow.Controls.SetChildIndex(UCCustomeDateRegistartion, indexFather + 1);
                }
                OpenDateFilterForm(UCCustomeDateRegistartion);
            }
            else
            {
                if (UCCustomeDateRegistartion != null && !UCCustomeDateRegistartion.IsDisposed)
                {
                    UCCustomeDateRegistartion.Dispose();
                }
                FilterDatable();//in case kenit gher custom date taamil filter
            }
            FixGrandParentFilterSize();
        }




        private void FilterCheckList_Deactivate(object sender, EventArgs e)
        {
            this.Hide();

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
