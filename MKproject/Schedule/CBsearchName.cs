using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MKproject.Schedule
{
    public partial class CBsearchName : Form
    {
        SqlConnection con = new SqlConnection(Program.DataLocation);

        public DataTable Originaldt { get; set; }

        bool isreminder;

        public CBsearchName()
        {
            InitializeComponent();
        }
        public CBsearchName(string contenue,bool boolean1)
        {
            InitializeComponent();
            isreminder = boolean1;
            populategrid();
            dataGridViewMembers.ClearSelection();
            textBoxSearch.Select();
            if (contenue != "Search by name or phone number...")
            {
                textBoxSearch.Text = contenue;
            }

            if(isreminder)
            {
                this.Size = new Size(290, 185);
            }
            else
            {
                this.Size = new Size(355, 185);
            }
        }

        public void populategrid()
        {
            Originaldt = SQLToProjectSchedule.DisplayDataGidViewSearchName();
            if (Originaldt.Rows.Count > 0)
            {
                foreach (DataRow d in Originaldt.Rows)
                {
                    dataGridViewMembers.Rows.Add(d["client_id"], d["name"] + " " + d["family_name"], d["phone_number"], d["Registration_Date"], d["check_in"]);
                }
            }
            if (dataGridViewMembers.DisplayedRowCount(false) < dataGridViewMembers.RowCount)
            {
                this.Size = new Size(355, 185);
            }
            else
            {
                this.Size = new Size(this.Size.Width, ((dataGridViewMembers.RowTemplate.Height) * (dataGridViewMembers.RowCount)) + 30);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

            String Input = textBoxSearch.Text.TrimEnd();
            if (RandomFunctions.CheckIfContainsOnlyDigits(Input))
            {
                DataTableToDatagrid(RandomFunctions.FilterDatatableByPhoneNumber(Input, Originaldt));

            }
            else
            {
                DataTableToDatagrid(RandomFunctions.FilterDatatableByName(Input, Originaldt));
            }
        }

        private void DataTableToDatagrid(DataTable Originaldt)
        {
            dataGridViewMembers.Rows.Clear();
            foreach (DataRow d in Originaldt.Rows)
            {
                dataGridViewMembers.Rows.Add(d["client_id"], d["name"] + " " + d["family_name"], d["phone_number"], d["Registration_Date"], d["check_in"]);
            }
            dataGridViewMembers.ClearSelection();
            if (dataGridViewMembers.DisplayedRowCount(false) < dataGridViewMembers.RowCount)
            {
                if (isreminder)
                {
                    this.Size = new Size(290, 185);
                }
                else
                {
                    this.Size = new Size(355, 185);
                }
            }
            else
            {
                this.Size = new Size(this.Size.Width, ((dataGridViewMembers.RowTemplate.Height) * (dataGridViewMembers.RowCount)) + 30);
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
            style2.BackColor = Color.White;
            if (e.RowIndex > -1)
            {
                dataGridViewMembers.Rows[e.RowIndex].DefaultCellStyle = style2;
            }
        }

        private void dataGridViewMembers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewMembers.Rows[e.RowIndex];
                StaticClass.ClientName = row.Cells["fullname"].Value.ToString();
                StaticClass.Client_id = Convert.ToInt32(row.Cells["id_client"].Value);
                StaticClass.OnStaticClientNameChanged();

                if (row.Cells["Registration_Date"].Value != DBNull.Value || row.Cells["check_in"].Value != DBNull.Value)//wza eja marra aw eza ken member eena yaeena batal trial aw invitation
                {

                    StaticClass.ClientType = StaticClass.Member;
                }
                else
                {

                    StaticClass.ClientType = StaticClass.Trial;
                }
                StaticClass.OnStaticClientTypeChanged();
                this.Close();
            }

        }

        private void CBsearchName_Deactivate(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}
