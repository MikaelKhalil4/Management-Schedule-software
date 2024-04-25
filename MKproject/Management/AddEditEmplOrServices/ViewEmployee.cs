
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GlobalFunctions;
using CustomizedTools;


namespace MKproject.Management
{

    public partial class ViewEmployee : Form
    {
        public DataTable dtEmployee;
        public ViewEmployee()
        {
            InitializeComponent();
            LoadInfo();
        }

        private void ViewEmployee_Load(object sender, EventArgs e)
        {
            dataGridViewEdit.ClearSelection();
        }


        public void LoadInfo()
        {

            dtEmployee = ClassEmployee.GetAllEmployees();

            FormatOriginaldt(dtEmployee);

            dataGridViewEdit.DataSource = dtEmployee;

            FormatDatagridView();

        }//try catch


        public void FormatOriginaldt(DataTable Desireddt)
        {
            Desireddt.Columns.Add("FakeStatus", typeof(string));
            Desireddt.Columns.Add("FakeIsScheduleMember", typeof(string));
            foreach (DataRow row in Desireddt.Rows)
            {

                if ((bool)row["status"] == true)
                {
                    row["FakeStatus"] = "True";
                }
                else
                {
                    row["FakeStatus"] = "False";
                }

                if ((bool)row["is_schedule_member"] == true)
                {
                    row["FakeIsScheduleMember"] = "True";
                }
                else
                {
                    row["FakeIsScheduleMember"] = "False";
                }
            }

            //ordering
            int columnIndexToMove;
            int newIndex;

            columnIndexToMove = Desireddt.Columns.IndexOf("first_name"); // Replace with the actual column name
            newIndex = 0; // The new desired index
            Desireddt.Columns[columnIndexToMove].SetOrdinal(newIndex);


            columnIndexToMove = Desireddt.Columns.IndexOf("last_name"); // Replace with the actual column name
            newIndex = 1; // The new desired index
            Desireddt.Columns[columnIndexToMove].SetOrdinal(newIndex);



            columnIndexToMove = Desireddt.Columns.IndexOf("phone_number"); // Replace with the actual column name
            newIndex = 2; // The new desired index
            Desireddt.Columns[columnIndexToMove].SetOrdinal(newIndex);


            columnIndexToMove = Desireddt.Columns.IndexOf("password"); // Replace with the actual column name
            newIndex = 3; // The new desired index
            Desireddt.Columns[columnIndexToMove].SetOrdinal(newIndex);



            columnIndexToMove = Desireddt.Columns.IndexOf("access"); // Replace with the actual column name
            newIndex = 4; // The new desired index
            Desireddt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = Desireddt.Columns.IndexOf("FakeIsScheduleMember"); // Replace with the actual column name
            newIndex = 5; // The new desired index
            Desireddt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = Desireddt.Columns.IndexOf("FakeStatus"); // Replace with the actual column name
            newIndex = 6; // The new desired index
            Desireddt.Columns[columnIndexToMove].SetOrdinal(newIndex);



        }

   

        void FormatDatagridView()
        {
            // Hide the "ID" column by referencing its name
            foreach (DataGridViewColumn col in dataGridViewEdit.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridViewEdit.Columns["employee_id"].Visible = false;
            dataGridViewEdit.Columns["status"].Visible = false;
            dataGridViewEdit.Columns["is_schedule_member"].Visible = false;
            dataGridViewEdit.Columns["rank"].Visible = false;
            dataGridViewEdit.Columns["availability"].Visible = false;
            dataGridViewEdit.Columns["is_checked"].Visible = false;
            dataGridViewEdit.Columns["cash"].Visible = false;
            dataGridViewEdit.Columns["clearcash_date"].Visible = false;

            dataGridViewEdit.Columns["first_name"].HeaderCell.Value = "First Name";
            dataGridViewEdit.Columns["last_name"].HeaderCell.Value = "Last Name";
            dataGridViewEdit.Columns["phone_number"].HeaderCell.Value = "Phone Number";
            dataGridViewEdit.Columns["password"].HeaderCell.Value = "Password";
            dataGridViewEdit.Columns["FakeStatus"].HeaderCell.Value = "Status";
            dataGridViewEdit.Columns["FakeIsScheduleMember"].HeaderCell.Value = "Schedule Member";
            dataGridViewEdit.Columns["access"].HeaderCell.Value = "Access";


            dataGridViewEdit.Columns["first_name"].FillWeight = 11;
            dataGridViewEdit.Columns["last_name"].FillWeight = 11;
            dataGridViewEdit.Columns["phone_number"].FillWeight = 11;
            dataGridViewEdit.Columns["password"].FillWeight = 11;
            dataGridViewEdit.Columns["access"].FillWeight = 25;
            dataGridViewEdit.Columns["Edit"].FillWeight = 14;
            dataGridViewEdit.Columns["FakeStatus"].FillWeight = 7;
            dataGridViewEdit.Columns["FakeIsScheduleMember"].FillWeight = 10;
            //
            dataGridViewEdit.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewEdit.Columns["Edit"].DisplayIndex = dtEmployee.Columns.Count;
            dataGridViewEdit.Columns["Edit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewEdit.Columns["Edit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewEdit.ApplyStyle1();
        }


        private void dataGridViewEdit_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dataGridViewEdit.Rows.Count && e.ColumnIndex < dataGridViewEdit.Columns.Count)
            {
                if (e.Value == DBNull.Value || string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.Value = "N/A";
                }
                else
                {
                    //text display
                    if (dataGridViewEdit.Columns[e.ColumnIndex].Name == "access")
                    {
                        e.Value = ReplaceLastCharacterWithDot(e.Value.ToString(), '/');
                        e.Value = ((string)e.Value).Replace("/", ", ");
                    }
                }
                //Design Display
                if (dataGridViewEdit.Columns[e.ColumnIndex].Name == "FakeStatus")
                {
                    DataGridViewCell cell = dataGridViewEdit.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (Convert.ToString(cell.Value) == "False")
                    {
                        cell.Style.ForeColor = Color.Red;
                        cell.Style.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        cell.Style.ForeColor = Color.Green;
                        cell.Style.SelectionForeColor = Color.Green;
                    }
                }
                if (dataGridViewEdit.Columns[e.ColumnIndex].Name == "FakeIsScheduleMember")
                {
                    DataGridViewCell cell = dataGridViewEdit.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (Convert.ToString(cell.Value) == "False")
                    {
                        cell.Style.ForeColor = Color.Red;
                        cell.Style.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        cell.Style.ForeColor = Color.Green;
                        cell.Style.SelectionForeColor = Color.Green;
                    }
                }
            }
        }

        string ReplaceLastCharacterWithDot(string input, char targetCharacter)
        {
            // Find the last occurrence of the target character
            int lastIndex = input.LastIndexOf(targetCharacter);

            // Check if the target character was found and if it's at the end
            if (lastIndex != -1 && lastIndex == input.Length - 1)
            {
                // Replace the last occurrence with '.'
                input = input.Remove(lastIndex, 1).Insert(lastIndex, ".");
            }

            return input;
        }



        private void dataGridViewEdit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                if (dataGridViewEdit.Columns[e.ColumnIndex].Name == "Edit")//this condition aal name tabaa el column mesh el text
                {
                    DataGridViewRow selectedRow = dataGridViewEdit.Rows[e.RowIndex];
                    int ID = Convert.ToInt32(selectedRow.Cells["employee_id"].Value);

                    DataRow[] rows = dtEmployee.Select("employee_id =" + ID);
                    DataRow desiredRow = null;
                    if (rows.Length > 0)//wwe re we re going to have 1 row
                    {
                        desiredRow = rows[0];
                    }

                    Program.GreyForm = new GreyColor((Form)this.Tag, true, false);
                    Program.GreyForm.Show();
                    EditEmployee p = new EditEmployee(desiredRow);
                    p.ParentFormViewEmpl = this;
                    p.ShowDialog();
                }
                dataGridViewEdit.ClearSelection();
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Program.GreyForm = new GreyColor((Form)this.Tag, true, false);
            Program.GreyForm.Show();
            EditEmployee p = new EditEmployee(null);
            p.ParentFormViewEmpl = this;
            p.ShowDialog();

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
