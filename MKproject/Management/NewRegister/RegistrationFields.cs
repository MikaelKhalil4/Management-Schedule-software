
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GlobalFunctions;
//in this form the index of the cell when i change the value o the visible column i have a problem with the index ,need to be fixed
namespace MKproject.Management
{
    public partial class RegistrationFields : Form
    {
        DataTable dtRegistrationFields;
        DataTable dtDeletedRows;
        public NewRegister NewRegisterForm { get; set; }





        public RegistrationFields(NewRegister newregisterForm)
        {

            NewRegisterForm = newregisterForm;
            InitializeComponent();
            this.Opacity = 0;

            LoadData();

            this.Opacity = 0;
            this.TopMost = true;

        }
        private void RegistrationFields_Load(object sender, EventArgs e)
        {
            FormatDatagridviewDesign();
        }
        public void FormatDatagridviewDesign()//kermel ma taamil flikceirng aal cellformat awwal ma t2alii elform w naamil scroll
        {
            foreach (DataGridViewRow row in dataGridViewFieldsNew.Rows)
            {
                DataGridViewCell cell = (DataGridViewCell)row.Cells["Visible"];
                DataGridViewCell CellToModifie = (DataGridViewCell)row.Cells["Required"];
                if (!Convert.ToBoolean(cell.Value))
                {
                    CellToModifie.ReadOnly = true;
                    CellToModifie.Style.BackColor = Color.LightGray;
                }
                else
                {
                    CellToModifie.ReadOnly = false;
                    CellToModifie.Style.BackColor = Color.White;
                }
            }
        }


        void FormatOriginalDt()
        {
            dtRegistrationFields.Columns.Add("FakeFields", typeof(string));

            foreach (DataRow row in dtRegistrationFields.Rows)
            {
                string FieldName = row["Fields"].ToString();
                if (FieldName == ClassClient.enumType.FullName.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.FullName.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.FaceImage.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.FaceImage.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.PhoneNumber.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.PhoneNumber.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.Gender.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.Gender.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.Job.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.Job.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.Adress.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.Adress.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.InstaUserName.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.InstaUserName.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.BirthDate.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.BirthDate.GetStringValue();

                }
                else if (FieldName == ClassClient.enumType.Email.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.Email.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.MaritalStatus.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.MaritalStatus.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.HowDidYouKnowAboutUs.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.HowDidYouKnowAboutUs.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.Note.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.Note.GetStringValue();
                }
                //custom 
                else if (FieldName == ClassClient.enumType.Height.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.Height.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.Weight.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.Weight.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.BodyShapeTarget.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.BodyShapeTarget.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.MuscleFocusOn.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.MuscleFocusOn.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.Injuries.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.Injuries.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.Hand.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.Hand.GetStringValue();
                }

                else if (FieldName == ClassClient.enumType.SessionPerWeek.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.SessionPerWeek.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.GoalsTimeline.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.GoalsTimeline.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.Smoking.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.Smoking.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.Alcohol.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.Alcohol.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.ExerciseHistory.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.ExerciseHistory.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.SleepPattern.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.SleepPattern.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.StressLevel.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.StressLevel.GetStringValue();
                }
                else if (FieldName == ClassClient.enumType.BoxingSkills.ToString())
                {
                    row["FakeFields"] = ClassClient.enumType.BoxingSkills.GetStringValue();
                }
            }

            int columnIndexToMove;
            int newIndex;

            columnIndexToMove = dtRegistrationFields.Columns.IndexOf("FakeFields"); // Replace with the actual column name
            newIndex = 0; // The new desired index
            dtRegistrationFields.Columns[columnIndexToMove].SetOrdinal(newIndex);



            columnIndexToMove = dtRegistrationFields.Columns.IndexOf("Visible"); // Replace with the actual column name
            newIndex = 1; // The new desired index
            dtRegistrationFields.Columns[columnIndexToMove].SetOrdinal(newIndex);



            columnIndexToMove = dtRegistrationFields.Columns.IndexOf("Required"); // Replace with the actual column name
            newIndex = 2; // The new desired index
            dtRegistrationFields.Columns[columnIndexToMove].SetOrdinal(newIndex);

        }
        void LoadData()
        {
            dtRegistrationFields = SQLToProject.GetAllVisibleFields();

            FormatOriginalDt();


            DataRow[] rowsToRemove = dtRegistrationFields.Select("Fields = 'FullName' OR Fields = 'PhoneNumber'");

            //copy the rows of name and phone number ta nerjaa nzidun bel ekhir
            dtDeletedRows = dtRegistrationFields.Clone();
            foreach (DataRow row in rowsToRemove)
            {
                DataRow copyRow = dtDeletedRows.NewRow();
                copyRow.ItemArray = row.ItemArray; // Copy the data
                dtDeletedRows.Rows.Add(copyRow); // Add the copied row to the new DataTable
            }

            // Remove the selected rows
            foreach (DataRow row in rowsToRemove)
            {
                dtRegistrationFields.Rows.Remove(row);
            }



            DataTableToDatagridView();

        }


        void DataTableToDatagridView()
        {
            dataGridViewFieldsNew.DataSource = dtRegistrationFields;
            foreach (DataGridViewColumn col in dataGridViewFieldsNew.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridViewFieldsNew.Columns["design_index"].Visible = false;
            dataGridViewFieldsNew.Columns["ID"].Visible = false;
            dataGridViewFieldsNew.Columns["Fields"].Visible = false;
            dataGridViewFieldsNew.Columns["Required"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewFieldsNew.Columns["Visible"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewFieldsNew.Columns["FakeFields"].HeaderText = "Fields";
        }



        private void buttonSave_Click(object sender, EventArgs e)
        {


            foreach (DataGridViewRow row in dataGridViewFieldsNew.Rows)
            {
                ProjectToSQL.UpdateField((bool)row.Cells["Visible"].Value, (bool)row.Cells["Required"].Value,(int)row.Cells["ID"].Value);
            }


            NewRegisterForm.dtUpdatedFields = dtRegistrationFields.Copy();
            foreach (DataRow copiedRow in dtDeletedRows.Rows)
            {
                NewRegisterForm.dtUpdatedFields.Rows.Add(copiedRow.ItemArray);
            }

            NewRegisterForm.UpdateOrCreateFields(true);
            this.Close();
        }





        private void dataGridViewFieldsNew_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is a checkbox cell in the Visible or Required column.
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell clickedCell = dataGridViewFieldsNew.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if ((clickedCell is DataGridViewCheckBoxCell checkBoxCell) && (clickedCell.Style.BackColor != Color.LightGray))//kermel ma ne2dir n3adil eza readonly
                {
                    // Toggle the checkbox state when the cell is clicked.
                    bool currentState = (bool)checkBoxCell.Value;
                    checkBoxCell.Value = !currentState;

                    // Commit the change to the underlying data source if required.
                    //dataGridViewFieldsNew.EndEdit();
                }
            }
        }

        private void dataGridViewFieldsNew_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)//kermel l selection color lal cell ma ykoun abyad w yet8ayar eza t8ayar l cell back color
        {

            DataGridViewCell cell = dataGridViewFieldsNew.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Exclude header cells
            {
                cell.Style.SelectionBackColor = cell.Style.BackColor;
            }

            if (e.RowIndex >= 0) // Assuming "balance" is the name of your balance column
            {
                if (e.ColumnIndex == dataGridViewFieldsNew.Columns["Visible"].Index)
                {
                    DataGridViewCell CellToModifie = dataGridViewFieldsNew.Rows[e.RowIndex].Cells["Required"];
                    if (!Convert.ToBoolean(cell.Value))
                    {

                        CellToModifie.ReadOnly = true;
                        CellToModifie.Style.BackColor = Color.LightGray;
                        CellToModifie.Value = false;
                    }
                    else
                    {
                        CellToModifie.ReadOnly = false;
                        CellToModifie.Style.BackColor = Color.White;
                    }

                }
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

        private void RegistrationFields_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.GreyFormJunior != null)
            {
                Program.GreyFormJunior.Close();
                Program.GreyFormJunior = null;
            }
            
        }
    }
}
