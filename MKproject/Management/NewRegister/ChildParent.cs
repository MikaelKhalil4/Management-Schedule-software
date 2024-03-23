using CustomizedTools;
using GlobalFunctions;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

//form made by nicolas
namespace MKproject.Management
{
    public partial class ChildParent : Form
    {
        public NewRegister ParentFormNewRegist { get; set; }
        public DataTable Originaldt { get; set; }
        public DataTable FilterDt { get; set; }

        string NotAvailable = "N/A";

        private UCTextbox1 UCPhone;
        private UCDoubleUCTextbox UCFullName;
        private UCTextbox1 UCAdress;

        public ChildParent(NewRegister newreistform)
        {
            InitializeComponent();
            ParentFormNewRegist = newreistform;

            LoadForm();

        }

        void LoadForm()
        {
            //Sql
            int? ClientId = null;
            if (ParentFormNewRegist.Client != null)
            {
                ClientId = ParentFormNewRegist.Client.ClientId;
            }
            Originaldt = ClassClient.GetAllParentsSQL(ClientId);

            FormatOriginaldt();
            FillDataGridview();

            ucSlideButton.button1.Text = "Select existing parent";
            ucSlideButton.button2.Text = "Add a new parent";
            ucSlideButton.Button1Clicked += UcSlideButton_Button1Clicked;
            ucSlideButton.Button2Clicked += UcSlideButton_Button2Clicked;

            this.Size = new Size(630, 450);
            this.Opacity = 0;
            this.TopMost = true;
            TLPGlobal.Dock = DockStyle.Fill;
            ucSlideButton.button1_Click(null, EventArgs.Empty);



        }//try catch
        private void ChildParent_Load(object sender, EventArgs e)
        {
            dataGridViewSelectParent.ClearSelection();
        }




        void SetModeDesign(bool SelectOrAddParent)
        {
            if (SelectOrAddParent)//select existing parent
            {
                if (TLPGlobal.Controls.Contains(TLPAddParent))
                {
                    TLPGlobal.Controls.Remove(TLPAddParent);
                }
                if (!TLPGlobal.Controls.Contains(TLPSelectParent))
                {
                    TLPGlobal.Controls.Add(TLPSelectParent, 0, 1);
                }
                TLPSelectParent.Dock = DockStyle.Fill;
                dataGridViewSelectParent.ClearSelection();
                buttonAdd.Visible = false;
            }
            else//add new parent
            {
                if (TLPGlobal.Controls.Contains(TLPSelectParent))
                {
                    TLPGlobal.Controls.Remove(TLPSelectParent);
                }
                if (!TLPGlobal.Controls.Contains(TLPAddParent))
                {
                    TLPGlobal.Controls.Add(TLPAddParent, 0, 1);
                }
                TLPAddParent.Dock = DockStyle.Fill;
                buttonAdd.Visible = true;
            }
        }




        bool NewParentFieldsCreated = false;
        //add parent
        void fillAddParentWithControls()
        {
            if (NewParentFieldsCreated == false)
            {
                NewParentFieldsCreated = true;//kermel nekhlaeun once bas
                                              //Sql
                DataTable dt = SQLToProject.GetChildParentVisibleFields();

                //Design
                int controlsWidth = FLPAddParent.Width - 10;
                foreach (DataRow row in dt.Rows)
                {
                    bool isRequired = (bool)row["Required"];
                    bool isVisible = (bool)row["Visible"];

                    if (row["Fields"].ToString() == ClassClient.enumType.FullName.ToString())
                    {
                        if (isVisible)
                        {
                            UCFullName = new UCDoubleUCTextbox("Name", "Family Name", isRequired);
                            FLPAddParent.Controls.Add(UCFullName);
                            UCFullName.Margin = new Padding(5, 5, 5, 5);
                            UCFullName.Width = controlsWidth;

                            if (isRequired)
                            {
                                UCFullName.IsRequired = true;
                            }
                            else
                            {
                                UCFullName.IsRequired = false;
                            }
                        }
                    }
                    else if (row["Fields"].ToString() == ClassClient.enumType.PhoneNumber.ToString())
                    {
                        if (isVisible)
                        {
                            UCPhone = new UCTextbox1(ClassClient.enumType.PhoneNumber.ToString(), isRequired);
                            UCPhone.IsPhoneNumber = true;
                            FLPAddParent.Controls.Add(UCPhone);
                            UCPhone.Margin = new Padding(5, 5, 5, 5);
                            UCPhone.Width = controlsWidth;

                        }
                    }
                    else if (row["Fields"].ToString() == ClassClient.enumType.Adress.ToString())
                    {
                        if (isVisible)
                        {
                            UCAdress = new UCTextbox1(ClassClient.enumType.Adress.ToString(), isRequired);
                            FLPAddParent.Controls.Add(UCAdress);
                            UCAdress.Margin = new Padding(5, 5, 5, 5);
                            UCAdress.Width = controlsWidth;


                        }
                    }
                }

                UCFullName.NextControl = UCPhone;
                UCPhone.NextControl = UCAdress;
            }

        }//try catch
        bool CheckRequired()
        {
            bool checkRequired = true;

            if (UCFullName != null && UCFullName.ActiveRequiredMode())
            {
                checkRequired = false;
            }

            if (UCPhone != null && UCPhone.ActiveRequiredMode())
            {
                checkRequired = false;
            }
            if (UCAdress != null && UCAdress.ActiveRequiredMode())
            {
                checkRequired = false;
            }

            return checkRequired;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //sql
            if (CheckRequired())
            {

                if (!ClassClient.SearchClientPhoneNumberSQL(null, UCPhone.myTextBox1.Text))
                {

                    ClassClient parent = new ClassClient();
                    parent.Fname = UCFullName.ucTextbox1.Value;
                    parent.Lname = UCFullName.ucTextbox2.Value;
                    parent.PhoneNumber = UCPhone.Value;
                    parent.Adress = UCAdress.Value;
                    parent.IsChild = false;
                    parent.IsParent = true;
                    parent.InsertClientToSQL();

                    ParentFormNewRegist.ParentId = ClassClient.GetLastClientIDSQL();


                    //design
                    Program.IsANewParentAddedOrParentPhoneUpdated = true;
                    ParentFormNewRegist.OpenAsChildDesign(parent.Lname, parent.PhoneNumber, parent.Adress);
                    ParentFormNewRegist.ParentChosen = true;
                    this.Close();

                }
                else
                {
                    CustomMessageBox.Show("Phone Number already exist", CustomMessageBox.Type.Ok);

                    //design
                    ucSlideButton.button1_Click(null, EventArgs.Empty);
                    ScrollAndSelectRowByPhoneNumber(UCPhone.myTextBox1.Text);

                }
            }
        }//try catch
        private void UCPhone_textboxKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }




        //seleect parent
        void FormatOriginaldt()
        {


            //Design
            //format datatable dt
            Originaldt.Columns.Add("Full Name", typeof(string));


            string NotAvailable = "N/A";
            foreach (DataRow d in Originaldt.Rows)
            {
               d["Full Name"] = d["name"] + " " + d["family_name"];       
            }


            //ordering
            int columnIndexToMove;
            int newIndex;

            columnIndexToMove = Originaldt.Columns.IndexOf("Full Name"); // Replace with the actual column name
            newIndex = 1; // The new desired index
            Originaldt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = Originaldt.Columns.IndexOf("Phone Number"); // Replace with the actual column name
            newIndex = 2; // The new desired index
            Originaldt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = Originaldt.Columns.IndexOf("Adress"); // Replace with the actual column name
            newIndex = 3; // The new desired index
            Originaldt.Columns[columnIndexToMove].SetOrdinal(newIndex);



            FilterDt = Originaldt;

        }
        private void dataGridViewSelectParent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dataGridViewSelectParent.Rows.Count && e.ColumnIndex < dataGridViewSelectParent.Columns.Count)
            {
                if (e.Value == DBNull.Value || string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.Value = "N/A";
                }
            }
        }
        private void FillDataGridview()
        {

            dataGridViewSelectParent.DataSource = FilterDt;

            // format datagridview
            dataGridViewSelectParent.Columns["client_id"].Visible = false;
            dataGridViewSelectParent.Columns["name"].Visible = false;
            dataGridViewSelectParent.Columns["family_name"].Visible = false;
            dataGridViewSelectParent.Columns["IsParent"].Visible = false;

            dataGridViewSelectParent.ApplyStyle1();

            dataGridViewSelectParent.ClearSelection();

        }
        private void ScrollAndSelectRowByPhoneNumber(string phoneNumber)
        {
            // Loop through the DataGridView rows to find the matching phone number.
            foreach (DataGridViewRow row in dataGridViewSelectParent.Rows)
            {
                if (row.Cells["Phone Number"].Value.ToString() != NotAvailable && row.Cells["Phone Number"].Value.ToString() == phoneNumber)
                {
                    // Found the phone number, select the row and scroll to it.
                    row.Selected = true;
                    dataGridViewSelectParent.FirstDisplayedScrollingRowIndex = row.Index;
                    break; // Exit the loop once found.
                }
            }
        }

        private void dataGridViewSelectParent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewSelectParent.Rows[e.RowIndex];

                int parenId = Convert.ToInt16(selectedRow.Cells["client_id"].Value);
                string phoneNumber = selectedRow.Cells["Phone Number"].Value.ToString(); // Replace "PhoneNumber" with the actual column name
                string familyName = selectedRow.Cells["family_name"].Value.ToString();

                string adress = selectedRow.Cells["Adress"].Value.ToString();
                if (adress == NotAvailable)
                {
                    adress = null;
                }



                ParentFormNewRegist.ParentId = parenId;

                ParentFormNewRegist.OpenAsChildDesign(familyName, phoneNumber, adress);
                ParentFormNewRegist.ParentChosen = true;
                this.Close();

            }
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text != textBoxSearch.PlaceholderText)
            {


                String Input = textBoxSearch.Text.TrimEnd();
                if (RandomFunctions.CheckIfContainsOnlyDigits(Input))
                {
                    FilterDt = FiltersDataTable.FilterDatatableIfContainsIgnoringCapitals("Phone Number", Input, Originaldt);

                }
                else
                {
                    FilterDt = FiltersDataTable.FilterDatatableIfContainsIgnoringCapitals("Full Name", Input, Originaldt);
                }
                FillDataGridview();
            }
        }






        private void UcSlideButton_Button2Clicked(object sender, EventArgs e)
        {
            SetModeDesign(false);
            fillAddParentWithControls();
        }
        private void UcSlideButton_Button1Clicked(object sender, EventArgs e)
        {
            SetModeDesign(true);
        }
        private void ChildParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ParentFormNewRegist.ParentChosen)
            {
                ParentFormNewRegist.radioButtonAdult.Checked = true;
            }
            if (Program.GreyFormJunior != null)
            {
                Program.GreyFormJunior.Close();
                Program.GreyFormJunior = null;
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
