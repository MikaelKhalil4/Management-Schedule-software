using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GlobalFunctions;
using CustomizedTools;
using MKproject.Management;
using System.Threading.Tasks;

namespace MKproject
{
    public partial class Search : Form
    {

        public DataTable Originaldt { get; set; }
        public DataTable FilterDt { get; set; }

        TextBoxWithPlaceHolder DesiredTextbox;

        public ClassClientCustom NewDesiredClient;
        ClassClientCustom ComingDesiredClient;

        //what will hapen to access the new selected client , we use the evemt ChosenClientChanged in the other form and we access NewDesiredClient
        public Search(TextBoxWithPlaceHolder desiredTextbox, ClassClientCustom comingDesiredClient)
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

            Originaldt = ClassClientCustom.GetAllClientSpecificInfoSQL();
            FormatOriginaldt();
            FillDataGridview();

        }//try catch
        private void FormatOriginaldt()
        {
            Originaldt.Columns.Add("Full Name", typeof(string));

            foreach (DataRow d in Originaldt.Rows)
            {
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
        private void dataGridViewMembers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dataGridViewMembers.Rows.Count && e.ColumnIndex < dataGridViewMembers.Columns.Count)
            {
                if (e.Value == DBNull.Value || string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.Value = "N/A";
                }

            }
        }

        private void FillDataGridview()
        {

            dataGridViewMembers.DataSource = FilterDt;

            dataGridViewMembers.Columns["client_id"].Visible = false;
            dataGridViewMembers.Columns["Registration_Date"].Visible = false;
            dataGridViewMembers.Columns["total_balance"].Visible = false;
            dataGridViewMembers.Columns["name"].Visible = false;
            dataGridViewMembers.Columns["family_name"].Visible = false;


            dataGridViewMembers.Columns["Full Name"].FillWeight = 67;
            dataGridViewMembers.Columns["Phone Number"].FillWeight = 33;
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
                int Id = Convert.ToInt32(row.Cells["client_id"].Value);
                double totaBalance = Convert.ToDouble(row.Cells["total_balance"].Value);

                NewDesiredClient = new ClassClientCustom();
                NewDesiredClient.ClientId = Id;//ejbare ha foe li tahta cz el filter aal textchange
                NewDesiredClient.Fname = FName;
                NewDesiredClient.Lname = LName;
                NewDesiredClient.TotalBalance = totaBalance;

                textBoxSearch.Text = FName + " " + LName;
                DesiredTextbox.Text = textBoxSearch.Text;//ejbare hone kermel el packoffice

                this.Close();//ejbare foe el event,glitch: kermel teftah el choose el service, since, bel event aam neftaha,
                ChosenClientChanged?.Invoke(this, EventArgs.Empty);
            }

        }
        private async void Search_Deactivate(object sender, EventArgs e)
        {

            if (ComingDesiredClient != null && string.IsNullOrEmpty(textBoxSearch.Text))//which mean ghayarne
            {
                NewDesiredClient = null;

                DesiredTextbox.Text = DesiredTextbox.PlaceholderText;

               
                ChosenClientChanged?.Invoke(this, EventArgs.Empty);
            }

            await Task.Delay(1); //kermel to activate li tahta
            this.Close(); // First, hide the form.
       
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
