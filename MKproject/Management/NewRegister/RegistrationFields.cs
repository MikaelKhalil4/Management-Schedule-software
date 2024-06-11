
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
                DataGridViewCell cell = (DataGridViewCell)row.Cells["FakeVisible"];
                DataGridViewCell CellToModifie = (DataGridViewCell)row.Cells["FakeRequired"];
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
        private void dataGridViewFieldsNew_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)//kermel l selection color lal cell ma ykoun abyad w yet8ayar eza t8ayar l cell back color
        {

            DataGridViewCell cell = dataGridViewFieldsNew.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dataGridViewFieldsNew.Rows.Count && e.ColumnIndex < dataGridViewFieldsNew.Columns.Count) // Exclude header cells
            {
                cell.Style.SelectionBackColor = cell.Style.BackColor;

                if (e.ColumnIndex == dataGridViewFieldsNew.Columns["FakeVisible"].Index)
                {
                    DataGridViewCell CellToModifie = dataGridViewFieldsNew.Rows[e.RowIndex].Cells["FakeRequired"];
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

        void FormatOriginalDt()
        {
            dtRegistrationFields.Columns.Add("FakeFields", typeof(string));
            dtRegistrationFields.Columns.Add("FakeVisible", typeof(Boolean));
            dtRegistrationFields.Columns.Add("FakeRequired", typeof(Boolean));
            foreach (DataRow row in dtRegistrationFields.Rows)
            {

                row["FakeVisible"] = Convert.ToBoolean(row["Visible"]);
                row["FakeRequired"] = Convert.ToBoolean(row["Required"]);

               string FieldName = row["Fields"].ToString();

                //static
                if (FieldName == ClassClient.enumStaticFields.FullName.ToString())
                {
                    row["FakeFields"] = ClassClient.enumStaticFields.FullName.GetStringValue();
                }
                else if (FieldName == ClassClient.enumStaticFields.FaceImage.ToString())
                {
                    row["FakeFields"] = ClassClient.enumStaticFields.FaceImage.GetStringValue();
                }
                else if (FieldName == ClassClient.enumStaticFields.PhoneNumber.ToString())
                {
                    row["FakeFields"] = ClassClient.enumStaticFields.PhoneNumber.GetStringValue();
                }
                else if (FieldName == ClassClient.enumStaticFields.Gender.ToString())
                {
                    row["FakeFields"] = ClassClient.enumStaticFields.Gender.GetStringValue();
                }
                else if (FieldName == ClassClient.enumStaticFields.Job.ToString())
                {
                    row["FakeFields"] = ClassClient.enumStaticFields.Job.GetStringValue();
                }
                else if (FieldName == ClassClient.enumStaticFields.Adress.ToString())
                {
                    row["FakeFields"] = ClassClient.enumStaticFields.Adress.GetStringValue();
                }
                else if (FieldName == ClassClient.enumStaticFields.InstaUserName.ToString())
                {
                    row["FakeFields"] = ClassClient.enumStaticFields.InstaUserName.GetStringValue();
                }
                else if (FieldName == ClassClient.enumStaticFields.BirthDate.ToString())
                {
                    row["FakeFields"] = ClassClient.enumStaticFields.BirthDate.GetStringValue();

                }
                else if (FieldName == ClassClient.enumStaticFields.Email.ToString())
                {
                    row["FakeFields"] = ClassClient.enumStaticFields.Email.GetStringValue();
                }
                
                else if (FieldName == ClassClient.enumStaticFields.Note.ToString())
                {
                    row["FakeFields"] = ClassClient.enumStaticFields.Note.GetStringValue();
                }




                //Dynamic 
                else if (FieldName == ClassClient.enumDynamicFields.Height.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.Height.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.Weight.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.Weight.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.BodyShapeTarget.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.BodyShapeTarget.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.MuscleFocusOn.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.MuscleFocusOn.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.Injuries.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.Injuries.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.Hand.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.Hand.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.SessionPerWeek.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.SessionPerWeek.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.MaritalStatus.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.MaritalStatus.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.HowDidYouKnowAboutUs.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.HowDidYouKnowAboutUs.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.GoalsTimeline.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.GoalsTimeline.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.Smoking.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.Smoking.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.Alcohol.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.Alcohol.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.ExerciseHistory.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.ExerciseHistory.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.SleepPattern.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.SleepPattern.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.StressLevel.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.StressLevel.GetStringValue();
                }
                else if (FieldName == ClassClient.enumDynamicFields.BoxingSkills.ToString())
                {
                    row["FakeFields"] = ClassClient.enumDynamicFields.BoxingSkills.GetStringValue();
                }
            }


            int columnIndexToMove;
            int newIndex;

            columnIndexToMove = dtRegistrationFields.Columns.IndexOf("FakeFields"); // Replace with the actual column name
            newIndex = 0; // The new desired index
            dtRegistrationFields.Columns[columnIndexToMove].SetOrdinal(newIndex);



            columnIndexToMove = dtRegistrationFields.Columns.IndexOf("FakeVisible"); // Replace with the actual column name
            newIndex = 1; // The new desired index
            dtRegistrationFields.Columns[columnIndexToMove].SetOrdinal(newIndex);



            columnIndexToMove = dtRegistrationFields.Columns.IndexOf("FakeRequired"); // Replace with the actual column name
            newIndex = 2; // The new desired index
            dtRegistrationFields.Columns[columnIndexToMove].SetOrdinal(newIndex);


            dtRegistrationFields.Columns.Remove("Visible");
            dtRegistrationFields.Columns.Remove("Required");
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
            dataGridViewFieldsNew.Columns["fields_id"].Visible = false;
            dataGridViewFieldsNew.Columns["Fields"].Visible = false;


            dataGridViewFieldsNew.Columns["FakeRequired"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewFieldsNew.Columns["FakeVisible"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewFieldsNew.Columns["FakeFields"].HeaderText = "Fields";
            dataGridViewFieldsNew.Columns["FakeRequired"].HeaderText = "Required";
            dataGridViewFieldsNew.Columns["FakeVisible"].HeaderText = "Visible";
        }



        private void buttonSave_Click(object sender, EventArgs e)
        {


            foreach (DataGridViewRow row in dataGridViewFieldsNew.Rows)
            {
                ProjectToSQL.UpdateField(Convert.ToBoolean(row.Cells["FakeVisible"].Value), Convert.ToBoolean(row.Cells["FakeRequired"].Value), Convert.ToInt32(row.Cells["fields_id"].Value));
            }


            NewRegisterForm.dtUpdatedFields = dtRegistrationFields.Copy();
            foreach (DataRow copiedRow in dtDeletedRows.Rows)
            {
                NewRegisterForm.dtUpdatedFields.Rows.Add(copiedRow.ItemArray);
            }

            NewRegisterForm.UpdateOrCreateFields(true);

            if (NewRegisterForm.Client != null)//update mode
            {
                NewRegisterForm.SaveOrUpdate(null, true);
            }
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
                    bool currentState = Convert.ToBoolean(checkBoxCell.Value);
                    checkBoxCell.Value = !currentState;

                    // Commit the change to the underlying data source if required.
                    //dataGridViewFieldsNew.EndEdit();
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
            //ejbare hek
            if (Program.GreyFormJuniorJunior != null)
            {
                Program.GreyFormJuniorJunior.Close();
                Program.GreyFormJuniorJunior = null;
            }
            else if (Program.GreyFormJunior != null)
            {
                Program.GreyFormJunior.Close();
                Program.GreyFormJunior = null;
            }         
        }

        
    }
}
