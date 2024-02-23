
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GlobalFunctions;
using CustomizedTools;


namespace MKproject.Management
{
    public partial class SearchCurrentClient : Form
    {
        public int firstVisibleRowIndex = 0;
        FilterCheckListSearch filterCheckList;//aam bekhlae el form tabaa el checkbox    


        public DataTable Originaldt;
        public DataTable Filtereddt;

        bool ISAscPackageStatusDate = true;
        bool ISAscSaveDate = true;
        bool ISAscLastVisit = true;
        bool ISAscRegiter = true;
        bool ISAscPayment = true;
        bool ISAscBalance = true;
        bool ISAscSessionDone = true;

        public SearchCurrentClient()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            FLPFiltersSlideSDhow.Click += ClearDataGridSelectionOnClick_Click;
            TLPSearchAndFilter.Click += ClearDataGridSelectionOnClick_Click;
            TLPGlobal.Click += ClearDataGridSelectionOnClick_Click;
            panelResults.Click += ClearDataGridSelectionOnClick_Click;
            //FilterOn


            LoadForm();


        }
        private void SearchCurrentClient_Load(object sender, EventArgs e)
        {
            dataGridViewClients.ClearSelection();
        }




        public void LoadForm()
        {
            filterCheckList = new FilterCheckListSearch();
            filterCheckList.ParentFormSearch = this;



            FLPFiltersSlideSDhow.Height = 0;
            buttonResetOrder.Visible = false;

            SearchOldText = textBoxSearch.PlaceholderText;//daruriye ma tshila
            textBoxSearch.Text = textBoxSearch.PlaceholderText;

            Originaldt = ClassClient.GetAllClientsSQL();

            //Datatble
            FormatOrginaldt();
            DataTableToDatagrid(Originaldt.Copy());
            FormatDatagridView();


        }//try catch
        public void RefreshSQL()//used in case ma ken fi updates aal datagridview (addrows,or update) w need to return to the initial state
        {

            Originaldt = ClassClient.GetAllClientsSQL();
            FormatOrginaldt();
            DataTableToDatagrid(Originaldt.Copy());
            filterCheckList.FilterDatable();

        }
        public void SetFiltersToInitialState()
        {
            filterCheckList.ClearFilters();
            textBoxSearch.Text = textBoxSearch.PlaceholderText;//this one will also enable the filtre eza ken text, eza ma ken fi text ma btaamil enable lal filter 
        }
        public void FocusOnADesiredRow(int ClientId)
        {
            DataGridViewRow DesiredRow = null;
            foreach (DataGridViewRow row in dataGridViewClients.Rows)
            {
                if ((int)row.Cells["client_id"].Value == ClientId)
                {
                    // Found the phone number, select the row and scroll to it.
                    DesiredRow = row;
                    break; // Exit the loop once found.
                }
            }

            if (DesiredRow == null)
            {
                SetFiltersToInitialState();
                FocusOnADesiredRow(ClientId);

            }
            else
            {

                DesiredRow.Selected = true;
                int rowIndex = DesiredRow.Index;

                if (rowIndex >= 0 && rowIndex < dataGridViewClients.RowCount)
                {
                    // Calculate the number of rows that can be displayed
                    int displayedRowCount = dataGridViewClients.DisplayedRowCount(false);

                    // Calculate the maximum possible first displayed row index
                    int maxFirstRow = dataGridViewClients.RowCount - displayedRowCount;

                    if (maxFirstRow > 0 && rowIndex > maxFirstRow)//first condition kermel ma ysir el rowIndex Tahet -1
                    {
                        rowIndex = maxFirstRow - 1;
                    }
                    dataGridViewClients.FirstDisplayedScrollingRowIndex = rowIndex;

                }
            }
        }

        private void ClearDataGridSelectionOnClick_Click(object sender, EventArgs e)
        {
            dataGridViewClients.ClearSelection();
            label1.Focus();//kermel eza kenit juwwet el textbox search
        }

        public void FormatOrginaldt()
        {

            //creating the new columns and deletening the old ones
            Originaldt.Columns.Add("Full Name", typeof(string));
            Originaldt.Columns.Add("Age Category", typeof(string));
            Originaldt.Columns.Add("Type", typeof(string));
            Originaldt.Columns.Add("Total Balance", typeof(string));
            Originaldt.Columns.Add("Total payment", typeof(string));
            Originaldt.Columns.Add("Save Date", typeof(string));
            Originaldt.Columns.Add("Last Visit", typeof(string));
            Originaldt.Columns.Add("Registration Date", typeof(string));
            Originaldt.Columns.Add("Total Attendance", typeof(int));
            Originaldt.Columns.Add("Packages Remaining", typeof(string));
            Originaldt.Columns.Add("Packages Status", typeof(int));//ha ykun fiya only 3 values, 2:black,1:orange,0: red, so when we order, it will order respecteing to the status
            Originaldt.Columns.Add("Packages HasStatus", typeof(int));//ha ykun fiya only 2 values 1:if value exisit 0,if value is null

            string NotAvailable = "N/A";
            foreach (DataRow d in Originaldt.Rows)
            {

                string phone_number = NotAvailable;
                if (d["Phone Number"] != DBNull.Value)
                {
                    phone_number = d["Phone Number"].ToString();
                }


                string ClientType = NotAvailable;
                if (d["Registration_Date"] != DBNull.Value)
                {
                    ClientType = UCComboBoxFilterSearch.Member;
                }
                else if (d["Registration_Date"] == DBNull.Value && d["check_in"] != DBNull.Value)//visitor byaamil check in lieanno, aakes el non visitor
                {
                    ClientType = UCComboBoxFilterSearch.Visitor;
                }
                else if (d["Registration_Date"] == DBNull.Value && d["check_in"] == DBNull.Value)
                {
                    ClientType = UCComboBoxFilterSearch.NoneVisitor;
                }



                string Album = NotAvailable;
                if (d["Album"] != DBNull.Value)
                {
                    Album = d["Album"].ToString();
                }

                string SaveDate = NotAvailable;
                if (d["save_date"] != DBNull.Value)
                {
                    SaveDate = RandomFunctions.SetDateFormat(d["save_date"].ToString());
                }


                string LastVisit = NotAvailable;
                if (d["check_in"] != DBNull.Value)
                {
                    LastVisit = RandomFunctions.SetDateFormat(d["check_in"].ToString());
                }

                string RegistrationDate = NotAvailable;
                if (d["Registration_Date"] != DBNull.Value)
                {
                    RegistrationDate = RandomFunctions.SetDateFormat(d["Registration_Date"].ToString());
                }

                string AgeCategory = NotAvailable;
                if (d["IsChild"] != DBNull.Value)
                {
                    if ((bool)d["IsChild"])
                        AgeCategory = UCComboBoxFilterSearch.Child;
                    else
                        AgeCategory = UCComboBoxFilterSearch.Adult;
                }

                string Gender = NotAvailable;
                if (d["Gender"] != DBNull.Value)
                {
                    Gender = d["Gender"].ToString();
                }

                string Job = NotAvailable;
                if (d["Job"] != DBNull.Value)
                {
                    Job = d["job"].ToString();
                }


                string Adress = NotAvailable;
                if (d["Adress"] != DBNull.Value)
                {
                    Adress = d["Adress"].ToString();
                }

                string balance = d["total_balance"].ToString();//cannnot be null
                if (balance.Contains('-'))
                {
                    balance = balance.Substring(1);
                    balance = "-" + Currency.Symbol + balance;

                }
                else
                {
                    balance = Currency.Symbol + balance;
                }

                string Payment = d["total_payment"].ToString();//cannnot be null
                if (Payment != "0")
                {

                    Payment = "+" + Currency.Symbol + Payment;

                }
                else
                {
                    Payment = Currency.Symbol + Payment;
                }





                //new original dt
                d["Full Name"] = d["name"] + " " + d["family_name"];
                d["Phone Number"] = phone_number;
                d["Gender"] = Gender;
                d["Age Category"] = AgeCategory;
                d["Job"] = Job;
                d["Adress"] = Adress;
                d["Type"] = ClientType;
                d["Album"] = Album;
                d["Save Date"] = SaveDate;
                d["Last Visit"] = LastVisit;
                d["Registration Date"] = RegistrationDate;
                d["Total Balance"] = balance;
                d["Total payment"] = Payment;

                //the rest should obligatory have values

            }

            Originaldt.Columns.Remove("name");
            Originaldt.Columns.Remove("family_name");
            Originaldt.Columns.Remove("IsChild");

            //ordering
            int columnIndexToMove;
            int newIndex;

            columnIndexToMove = Originaldt.Columns.IndexOf("Full Name"); // Replace with the actual column name
            newIndex = 0; // The new desired index
            Originaldt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = Originaldt.Columns.IndexOf("Phone Number"); // Replace with the actual column name
            newIndex = 1; // The new desired index
            Originaldt.Columns[columnIndexToMove].SetOrdinal(newIndex);


        }
        public void DataTableToDatagrid(DataTable newFilterddt)//for initialising, and filtering(most of the times)
        {
            Filtereddt = newFilterddt;

            dataGridViewClients.DataSource = Filtereddt;//eza ghayaret shi value aw mhit shi row inside the filterddt, byetghayar deghre bel datagridview,
            //bas eza eetita gher instance
            //el datagrid view ejbare kamen taatiyan el new instance metel hone,, lieanno eza ma eetita, el datagridview ha tdala refering aa awwal instance,
            //w el updates li bi sir aa this instance bi sir aal data gridviw
            // so the datagridview is like a mirror lal instance datatbale not el reference tabaa el datatbale

            dataGridViewClients.ClearSelection();//mahalla hone darure , cz lamma taamil filter lezim tekhtefe
            labelResults.Text = Convert.ToString(Filtereddt.Rows.Count);


        }
        public void FormatDatagridView()
        {

            foreach (DataGridViewColumn column in dataGridViewClients.Columns)
            {
                if (column.Name == "Full Name" || column.Name == "Phone Number")
                {
                    column.Visible = true;
                }
                else
                {
                    column.Visible = false;
                }

            }
            dataGridViewClients.ApplyStyle1();
            dataGridViewClients.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//kermel taamil stretch aa kell surface  horizontally
            dataGridViewClients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;//kermel yaamlo wrap kell el colunns li mawjudin aal sheshe w ma btaamil delay metel all cels
            dataGridViewClients.RowTemplate.MinimumHeight = 40; // Set minimum row height
            pictureBoxSearch.Select();

        }






        string SearchOldText;
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string newText = textBoxSearch.Text;
            if (!(String.IsNullOrEmpty(SearchOldText) && newText == textBoxSearch.PlaceholderText) && !(String.IsNullOrEmpty(newText) && SearchOldText == textBoxSearch.PlaceholderText))//lamma yun eena emty text w ysir place holder mahallo aw el aakes, ma mnaamil filter
            {
                filterCheckList.FilterDatable();
            }
            SearchOldText = textBoxSearch.Text;
        }


        private void dataGridViewClients_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewClients.Rows[e.RowIndex];
                int ClientID = Convert.ToInt16(selectedRow.Cells["client_id"].Value);
                ClassClient.UpdateClientLastsearchedSQL(ClientID);


                ClassClient DesiredCLient = ClassClient.CreateClientObject(ClientID);
                //form creation
                Menu menu = ((Home)this.Tag).menu;
                if (Program.clientManagementProfile == null)
                {
                    Program.clientManagementProfile = new ClientManagementProfile(DesiredCLient,false);
                }
                else
                {
                    Program.clientManagementProfile.LoadData(DesiredCLient, false);
                    Program.clientManagementProfile.FormatDatagridviewDesign();
                }

                Program.clientManagementProfile.Size = this.Size;
                Program.clientManagementProfile.SearchCurrentClientform = this;
                menu.OpenChildForm(Program.clientManagementProfile, menu.buttonSearchClient, true);
                ((Home)this.Tag).buttonBackHome.Visible = true;

            }
            Cursor.Current = Cursors.Hand;
        }
        private void dataGridViewClients_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn clickedColumn = dataGridViewClients.Columns[e.ColumnIndex];


            if (dataGridViewClients.Columns[e.ColumnIndex].Name == "Packages Remaining")
            {
                DataView sortedView = Filtereddt.DefaultView;
                if (ISAscPackageStatusDate)
                {
                    sortedView.Sort = "Packages HasStatus Desc,Packages Status ASC";
                    ISAscPackageStatusDate = false;
                    clickedColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                }
                else
                {
                    sortedView.Sort = "Packages HasStatus Desc,Packages Status DESC";
                    ISAscPackageStatusDate = true;
                    clickedColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
                }
                Filtereddt = sortedView.ToTable(); // Reassigning dt here, which should still work
                DataTableToDatagrid(Filtereddt);

            }
            else if (dataGridViewClients.Columns[e.ColumnIndex].Name == "Save Date")
            {

                DataView sortedView = Filtereddt.DefaultView;
                if (ISAscSaveDate)
                {
                    sortedView.Sort = "save_date DESC";
                    ISAscSaveDate = false;
                    clickedColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    sortedView.Sort = "save_date ASC";
                    ISAscSaveDate = true;
                    clickedColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                }
                Filtereddt = sortedView.ToTable(); // Reassigning dt here, which should still work
                DataTableToDatagrid(Filtereddt);
            }
            else if (dataGridViewClients.Columns[e.ColumnIndex].Name == "Last Visit")
            {
                // Sort the DataTable by the new column in descending order
                DataView sortedView = Filtereddt.DefaultView;
                //sortedView.Sort = "AbsoluteValueBalance DESC";
                if (ISAscLastVisit)
                {
                    sortedView.Sort = "check_in DESC";
                    ISAscLastVisit = false;
                }
                else
                {
                    sortedView.Sort = "check_in ASC";
                    ISAscLastVisit = true;
                }
                Filtereddt = sortedView.ToTable(); // Reassigning dt here, which should still work
                DataTableToDatagrid(Filtereddt);
            }
            else if (dataGridViewClients.Columns[e.ColumnIndex].Name == "Registration Date")
            {
                // Sort the DataTable by the new column in descending order
                DataView sortedView = Filtereddt.DefaultView;
                //sortedView.Sort = "AbsoluteValueBalance DESC";
                if (ISAscRegiter)
                {
                    sortedView.Sort = "Registration_Date DESC";
                    ISAscRegiter = false;
                }
                else
                {
                    sortedView.Sort = "Registration_Date ASC";
                    ISAscRegiter = true;
                }
                Filtereddt = sortedView.ToTable(); // Reassigning dt here, which should still work
                DataTableToDatagrid(Filtereddt);
            }
            else if (dataGridViewClients.Columns[e.ColumnIndex].Name == "Total payment")
            {
                // Sort the DataTable by the new column in descending order
                DataView sortedView = Filtereddt.DefaultView;
                //sortedView.Sort = "AbsoluteValueBalance DESC";
                if (ISAscPayment)
                {
                    sortedView.Sort = "total_payment DESC";
                    ISAscPayment = false;
                }
                else
                {
                    sortedView.Sort = "total_payment ASC";
                    ISAscPayment = true;
                }
                Filtereddt = sortedView.ToTable(); // Reassigning dt here, which should still work
                DataTableToDatagrid(Filtereddt);
            }
            else if (dataGridViewClients.Columns[e.ColumnIndex].Name == "Total Balance")
            {

                // Sort the DataTable by the new column in descending order
                DataView sortedView = Filtereddt.DefaultView;
                //sortedView.Sort = "AbsoluteValueBalance DESC";
                if (!ISAscBalance)//hattayneha lieanno negative nuumbers
                {
                    sortedView.Sort = "total_balance DESC";
                    ISAscBalance = true;
                }
                else
                {
                    sortedView.Sort = "total_balance ASC";
                    ISAscBalance = false;
                }
                Filtereddt = sortedView.ToTable(); // Reassigning dt here, which should still work
                DataTableToDatagrid(Filtereddt);
            }
            else if (dataGridViewClients.Columns[e.ColumnIndex].Name == "Total Attendance")
            {
                DataView sortedView = Filtereddt.DefaultView;
                if (ISAscSessionDone)//hattayneha lieanno negative nuumbers
                {
                    sortedView.Sort = "Total Attendance DESC";
                    ISAscSessionDone = false;
                }
                else
                {
                    sortedView.Sort = "Total Attendance ASC";
                    ISAscSessionDone = true;
                }
                Filtereddt = sortedView.ToTable(); // Reassigning dt here, which should still work
                DataTableToDatagrid(Filtereddt);
            }
            dataGridViewClients.ClearSelection();
            buttonResetOrder.Visible = true;
        } //sorting
        private void dataGridViewClients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)//ejbare hone estaamil this methode, lieanno mb3rf exactly leh bas iguess  men warar el visibility
        {
            if (e.RowIndex >= 0) // Assuming "balance" is the name of your balance column
            {
                DataGridViewCell cell = dataGridViewClients.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (e.ColumnIndex == dataGridViewClients.Columns["Total Balance"].Index)
                {
                    if (!Convert.ToString(cell.Value).Contains("$0"))
                    {
                        cell.Style.ForeColor = Color.Red;
                        cell.Style.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        cell.Style.ForeColor = Color.FromArgb(64, 64, 64); ;
                        cell.Style.SelectionForeColor = Color.FromArgb(64, 64, 64); ;
                    }
                }
                else if (e.ColumnIndex == dataGridViewClients.Columns["Total Payment"].Index)
                {
                    if (!Convert.ToString(cell.Value).Contains("$0"))
                    {
                        cell.Style.ForeColor = Color.Green;
                        cell.Style.SelectionForeColor = Color.Green;
                    }
                    else
                    {
                        cell.Style.ForeColor = Color.FromArgb(64, 64, 64); ;
                        cell.Style.SelectionForeColor = Color.FromArgb(64, 64, 64); ;
                    }
                }
            }
        }
        private void dataGridViewClients_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewClients.Columns["Packages Remaining"].Index && e.RowIndex >= 0)
            {



                e.Handled = true; // Handle the painting manually
                                  // Apply the default cell style (background, borders, etc.)
                DataGridViewCellStyle cellStyle = e.CellStyle;
                Font cellFont = cellStyle.Font;
                if (cellFont.Bold)
                {
                    cellFont = new Font(cellFont, FontStyle.Regular);
                }


                e.PaintBackground(e.ClipBounds, true);

                // Split the cell content into lines
                string[] lines = e.Value?.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                int lineHeight = e.CellBounds.Height / lines.Length;

                StringFormat format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                };



                for (int i = 0; i < lines.Length; i++)
                {

                    Color textColor = DetermineColor(lines[i]);
                    using (Brush textBrush = new SolidBrush(textColor))
                    {


                        // Adjust the line rectangle for padding
                        Rectangle lineRect = new Rectangle(
                            e.CellBounds.Left + cellStyle.Padding.Left,
                            e.CellBounds.Top + (i * lineHeight) + cellStyle.Padding.Top,
                            e.CellBounds.Width - cellStyle.Padding.Horizontal,
                            lineHeight - cellStyle.Padding.Vertical
                        );

                        // Draw the line
                        e.Graphics.DrawString(lines[i], cellFont, textBrush, lineRect, format);
                    }
                }

                // Paint the cell border
                e.Paint(e.CellBounds, DataGridViewPaintParts.Border);



            }

        }
        private Color DetermineColor(string line)
        {
            // Your logic to determine the color based on the line content
            // Example:
            if (line.Contains(" 0 "))
            {
                return Color.Red; // Less sessions or days left, use red color
            }
            else if (line.Contains(" 1 "))
            {
                return Color.Orange; // Less sessions or days left, use red color
            }
            else if (line.Contains("(Freezed)"))
            {
                return Color.FromArgb(3, 177, 241); // Less sessions or days left, use red color
            }
            else if (line.Contains("N/A"))
            {
                return Color.FromArgb(64, 64, 64); // Default color
            }
            else
            {
                return Color.Green;
            }
        }



        //show the comboboxes for filters
        private void FLPFilter_Click(object sender, EventArgs e)
        {


            // Calculate the desired location below targetControl
            Point locationRelativeToScreen = FLPFilter.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(0, FLPFilter.Height + 2);
            filterCheckList.Location = locationRelativeToScreen;
            filterCheckList.Show();
            this.label1.Select();//bas eza kermel eza ken fi textbox bel filters fiyo katibe, kermel ma tekhtefe el filter, amma el combobox eenda gher method

        }

        private void buttonResetOrder_Click(object sender, EventArgs e)
        {
            pictureBoxSearch.Select();//hone mahalla ejbare, kermel ma tfout aal search
            DataView sortedView = Filtereddt.DefaultView;
            sortedView.Sort = "last_time_searched  DESC ";
            Originaldt = sortedView.ToTable(); // Reassigning dt here, which should still work
            DataTableToDatagrid(Originaldt);
            buttonResetOrder.Visible = false;

        }







        private void FLPFilter_MouseMove(object sender, MouseEventArgs e)
        {
            FLPFilter.BackColor = Color.Gray;
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            FLPFilter.BackColor = Color.Transparent;
        }

        bool InitialStart = true;////SINCE clearselection is't working we oversmart the system
        private void dataGridViewClients_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (InitialStart)
                {
                    dataGridViewClients.ClearSelection();
                    InitialStart = false;
                }

            }
        }

        private void dataGridViewClients_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            labelResults.Text = Convert.ToString(Filtereddt.Rows.Count);
        }

        public int targetedHeight = 0;
        private void timerFilterOn_Tick(object sender, EventArgs e)
        {
            if (FLPFiltersSlideSDhow.Height >= targetedHeight)//ha tkun multile de 70
            {
                timerFilterOn.Stop();
                FLPFiltersSlideSDhow.Height = targetedHeight;
            }
            else
            {
                FLPFiltersSlideSDhow.Height += 12;
            }

        }
        private void timerFilterOff_Tick(object sender, EventArgs e)
        {
            if (FLPFiltersSlideSDhow.Height <= targetedHeight)
            {
                timerFilterOff.Stop();
                FLPFiltersSlideSDhow.Height = targetedHeight;
            }
            else
            {
                FLPFiltersSlideSDhow.Height -= 12;
            }
        }
        private void SearchCurrentClient_Resize(object sender, EventArgs e)
        {
            filterCheckList.FixGrandParentFilterSize();
        }
        private void SearchCurrentClient_Deactivate(object sender, EventArgs e)
        {
            pictureBoxSearch.Select();
        }

        private void dataGridViewClients_Scroll(object sender, ScrollEventArgs e)
        {
            firstVisibleRowIndex = dataGridViewClients.FirstDisplayedScrollingRowIndex;
        }


        private void iconButtonViewBirthdays_Click(object sender, EventArgs e)
        {
            if (Program.GreyForm == null)//lieanno lamma nekbus too many clicks aam bi sir fi ghalat
            {
                Program.GreyForm = new GreyColor((Form)this.Tag, true, false);
                Program.GreyForm.Show();
                CustomerService cu = new CustomerService();
                cu.ParentFormSearch = this;
                cu.Show();
            }

        }

        private void iconButtonAddClient_Click(object sender, EventArgs e)
        {
            Program.GreyForm = new GreyColor((Form)this.Tag, true, false);
            Program.GreyForm.Show();
            if (Program.NewRegisterForm == null)
            {
                Program.NewRegisterForm = new NewRegister(null, null);
            }
            else
            {
                Program.NewRegisterForm.Resetcontrols();
                Program.NewRegisterForm.LoadForm(null, null);
            }
            Program.NewRegisterForm.SearchCurrentClientForm = this;
            Program.NewRegisterForm.ShowDialog();

        }

    }
}

