using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GlobalFunctions;
using CustomizedTools;
using MKproject.Management;

namespace MKproject
{
    public partial class Search : Form
    {

        public DataTable Originaldt { get; set; }
        public DataTable FilterDt { get; set; }

        TextBoxWithPlaceHolder DesiredTextbox;

        public ClassClient NewDesiredClient;
        ClassClient ComingDesiredClient;

        //what will hapen to access the new selected client , we use the evemt ChosenClientChanged in the other form and we access NewDesiredClient
        public Search(TextBoxWithPlaceHolder desiredTextbox, ClassClient comingDesiredClient)
        {
            InitializeComponent();
            DesiredTextbox = desiredTextbox;
            ComingDesiredClient = comingDesiredClient;

            LoadForm();

            textBoxSearch.BackColor = desiredTextbox.BackColor;
            textBoxSearch.Font = desiredTextbox.Font;
            textBoxSearch.Select();
            if (DesiredTextbox.Text != DesiredTextbox.PlaceholderText)//don t use strings use 
            {
                textBoxSearch.Text = DesiredTextbox.Text;
            }
        }
        private void Search_Load(object sender, EventArgs e)
        {
            dataGridViewMembers.ClearSelection();
        }


        void LoadForm()
        {

            Originaldt = ClassClient.GetAllClientSpecificInfoSQL();
            FormatOriginaldt();
            FillDataGridview();

        }//try catch
        private void FormatOriginaldt()
        {
            Originaldt.Columns.Add("Full Name", typeof(string));

            string NotAvailable = "N/A";
            foreach (DataRow d in Originaldt.Rows)
            {
                string phone_number = NotAvailable;
                if (d["Phone Number"] != DBNull.Value)
                {
                    phone_number = d["Phone Number"].ToString();
                }
                d["Phone Number"] = phone_number;

                d["Full Name"] = d["name"] + " " + d["family_name"];
            }
            //ordering
            int columnIndexToMove;
            int newIndex;

            columnIndexToMove = Originaldt.Columns.IndexOf("client_id");
            newIndex = 0; // The new desired index
            Originaldt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = Originaldt.Columns.IndexOf("Full Name");
            newIndex = 1; // The new desired index
            Originaldt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = Originaldt.Columns.IndexOf("Phone Number");
            newIndex = 2; // The new desired index
            Originaldt.Columns[columnIndexToMove].SetOrdinal(newIndex);
            //
            FilterDt = Originaldt;

        }
        private void FillDataGridview()
        {

            dataGridViewMembers.DataSource = FilterDt;

            dataGridViewMembers.Columns["client_id"].Visible = false;
            dataGridViewMembers.Columns["Registration_Date"].Visible = false;
            dataGridViewMembers.Columns["name"].Visible = false;
            dataGridViewMembers.Columns["family_name"].Visible = false;

            dataGridViewMembers.ClearSelection();

            FixFormSize();
        }


        public void FixFormSize()
        {

            if (dataGridViewMembers.DisplayedRowCount(false) < dataGridViewMembers.RowCount)
            {
                this.Size = new Size(DesiredTextbox.Width, 185);
            }
            else
            {
                this.Size = new Size(DesiredTextbox.Width, ((dataGridViewMembers.RowTemplate.Height) * (dataGridViewMembers.RowCount)) + 30);
            }
        }

        bool IsRowClicked = false;
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (!IsRowClicked)
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

        private void dataGridViewMembers_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewMembers.ClearSelection();
            DataGridViewCellStyle style1 = new DataGridViewCellStyle();
            style1.BackColor = Color.FromArgb(229, 226, 244);

            if (e.RowIndex > -1)
            {
                dataGridViewMembers.Rows[e.RowIndex].DefaultCellStyle = style1;
            }
        }

        private void dataGridViewMembers_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.BackColor = dataGridViewMembers.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor;
            if (e.RowIndex > -1)
            {
                dataGridViewMembers.Rows[e.RowIndex].DefaultCellStyle = style2;
            }
        }

        public event EventHandler ChosenClientChanged;
        private void dataGridViewMembers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                IsRowClicked = true;
                DataGridViewRow row = dataGridViewMembers.Rows[e.RowIndex];
                string FName = row.Cells["name"].Value.ToString();
                string LName = row.Cells["family_name"].Value.ToString();
                int Id = Convert.ToInt16(row.Cells["client_id"].Value);

                NewDesiredClient = new ClassClient();
                NewDesiredClient.ClientId = Id;//ejbare ha foe li tahta cz el filter aal textchange
                NewDesiredClient.Fname = FName;
                NewDesiredClient.Lname = LName;


                textBoxSearch.Text = FName + " " + LName;
                DesiredTextbox.Text = textBoxSearch.Text;//ejbare hone kermel el packoffice

                this.Close();//ejbare foe el event,glitch: kermel teftah el choose el service, since, bel event aam neftaha,
                ChosenClientChanged?.Invoke(this, EventArgs.Empty);


                this.Close();
            }

        }
        private void Search_Deactivate(object sender, EventArgs e)
        {
            if (ComingDesiredClient != null && string.IsNullOrEmpty(textBoxSearch.Text))//which mean ghayarne
            {
                NewDesiredClient = null;

                DesiredTextbox.Text = DesiredTextbox.PlaceholderText;

                this.Close();//ejbare foe el event,glitch: kermel teftah el choose el service, since, bel event aam neftaha
                ChosenClientChanged?.Invoke(this, EventArgs.Empty);
            }
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
