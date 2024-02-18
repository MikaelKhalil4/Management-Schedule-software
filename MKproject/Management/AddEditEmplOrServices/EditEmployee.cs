
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GlobalFunctions;
using CustomizedTools;
using static MKproject.Management.Features;

namespace MKproject.Management
{
    public partial class EditEmployee : Form
    {
        Font seguiFont = new Font("Segoe UI", 12, FontStyle.Regular);//kermel 8ayir kel l fonts taba3 l controls li bzidoun
        int GroupBoxOldHeight;//la e5oud l oldheight taba3 l groupBox abel ma 8ayerla siza


        private CheckBox CheckboxWorkout;
        private CheckBox CheckBoxEditOffres;
        private CheckBox CheckBoxSchedule;
        private CheckBox CheckBoxMarketing;
        private CheckBox CheckBoxTransactions;
        private CheckBox CheckBoxBackOffice;
        private CheckBox CheckBoxStatistics;


        private bool IsFeatures;//he la nchouf eza fi features aw keloun turned off
        public int? EmployeeId;
        DataRow DesiredRow;
        public ViewEmployee ParentFormViewEmpl;


        // id is not null lammal employee 3m ya3mil edit la halo , meanwhile this feature will not be used, bas ha nkhalliya cz elc code maamoul
        public EditEmployee(int? id, DataRow desiredRow)
        {
            InitializeComponent();
            DesiredRow = desiredRow;
            EmployeeId = id;

            GroupBoxOldHeight = groupBoxFeatures.Size.Height;
            LoadForm();

            if (DesiredRow != null || EmployeeId != null)//edit mode not add
            {
                LoadInfo();
            }
            else
            {
                ucTextboxFirstName.myTextBox1.Select();

            }


            this.Opacity = 0;
            this.TopMost = true;
        }
        void LoadForm()
        {
            //hone since ma aam nekjhlaeulun construtc ntebhih that el type men baaed is required cz el function SetUcMode mawjude bel set tabaa string type aw enum Type
            ucTextboxFirstName.IsRequired = true;
            ucTextboxFirstName.StringType = "First Name";
            ucTextboxFirstName.NextControl = ucTextboxLastName;


            ucTextboxLastName.IsRequired = true;
            ucTextboxLastName.StringType = "Last Name";

            ucTextboxLastName.NextControl = ucTextboxPhoneNumber;
            ucTextboxPhoneNumber.IsPhoneNumber = true;
            ucTextboxPhoneNumber.StringType = ClassClient.enumType.PhoneNumber.GetStringValue();
            ucTextboxPhoneNumber.IsRequired = true;

            ucTextboxPassword.StringType = "Password";
            ucTextboxPhoneNumber.NextControl = ucTextboxPassword;
            ucTextboxPassword.IsRequired = true;


            if ((DesiredRow == null && EmployeeId == null) || (EmployeeId != null))//Add Employee men el editemployeeForm Or edit men el homepageForm 
            {
                checkBoxStatus.Visible = false;
                this.Size = new Size(this.Width, this.Height - checkBoxStatus.Size.Height - checkBoxStatus.Margin.Top - checkBoxStatus.Margin.Bottom);
                buttonDelete.Visible = false;
            }

            if ((!Features.Workout && !Features.Management && !Features.Management && !Features.Schedule && !Features.Marketing) || (EmployeeId != null))
            {
                // Remove the groupBoxFeatures from the form's controls
                this.Controls.Remove(groupBoxFeatures);
                // Dispose of the groupBoxFeatures to release its resources
                groupBoxFeatures.Dispose();
                IsFeatures = false;
                ChangeFormSize(false);
            }
            else
            {
                IsFeatures = true;
                if (Features.Workout)
                {
                    CheckboxWorkout = new CheckBox();
                    CheckboxWorkout.Text = enumFeatures.Workout.GetStringValue();
                    CheckboxWorkout.Font = seguiFont;
                    CheckboxWorkout.AutoSize = true;
                    FLPFeatures.Controls.Add(CheckboxWorkout);
                }
                if (Features.Schedule)
                {
                    CheckBoxSchedule = new CheckBox();
                    CheckBoxSchedule.Text = enumFeatures.Schedule.GetStringValue();
                    CheckBoxSchedule.Font = seguiFont;
                    CheckBoxSchedule.AutoSize = true;
                    FLPFeatures.Controls.Add(CheckBoxSchedule);
                }
                if (Features.Marketing)
                {
                    CheckBoxMarketing = new CheckBox();
                    CheckBoxMarketing.Text = enumFeatures.Marketing.GetStringValue();
                    CheckBoxMarketing.Font = seguiFont;
                    CheckBoxMarketing.AutoSize = true;
                    FLPFeatures.Controls.Add(CheckBoxMarketing);
                }
                if (Features.Management)
                {
                   
                    CheckBoxTransactions = new CheckBox();
                    CheckBoxTransactions.Text = enumFeatures.Transactions.GetStringValue();
                    CheckBoxTransactions.Font = seguiFont;
                    CheckBoxTransactions.AutoSize = true;
                    FLPFeatures.Controls.Add(CheckBoxTransactions);

                    CheckBoxBackOffice = new CheckBox();
                    CheckBoxBackOffice.Text = enumFeatures.BackOffice.GetStringValue();
                    CheckBoxBackOffice.Font = seguiFont;
                    CheckBoxBackOffice.AutoSize = true;
                    FLPFeatures.Controls.Add(CheckBoxBackOffice);

                    CheckBoxStatistics = new CheckBox();
                    CheckBoxStatistics.Text = enumFeatures.Statistics.GetStringValue();
                    CheckBoxStatistics.Font = seguiFont;
                    CheckBoxStatistics.AutoSize = true;
                    FLPFeatures.Controls.Add(CheckBoxStatistics);

                    CheckBoxEditOffres = new CheckBox();
                    CheckBoxEditOffres.Text = enumFeatures.EditOffres.GetStringValue();
                    CheckBoxEditOffres.Font = seguiFont;
                    CheckBoxEditOffres.AutoSize = true;
                    FLPFeatures.Controls.Add(CheckBoxEditOffres);
                

                }
                AdjustFeaturesSize();
                ChangeFormSize(true);
            
            
            
            }
        }


     

        private void AdjustFeaturesSize()
        {
            // Get the preferred size of FLPFeatures
            Size preferredSize = FLPFeatures.PreferredSize;

            // Add some extra padding if needed
            int padding = 2; // You can adjust the padding as per your preference

            int SizeDifference = groupBoxFeatures.Size.Height - FLPFeatures.Size.Height;//kermel nchouf l fare2 ben l groupbox wel FLP

            // Set the new size for groupBoxFeatures
            groupBoxFeatures.Size = new Size(groupBoxFeatures.Size.Width, preferredSize.Height + padding + SizeDifference);
        }
        void ChangeFormSize(bool ContainFeatures)
        {
            if (ContainFeatures)
                this.Size = new Size(this.Width, this.Height + groupBoxFeatures.Height - GroupBoxOldHeight);
            else
                this.Size = new Size(this.Width, this.Height - GroupBoxOldHeight);
        }



        void LoadInfo()
        {

            // Retrieve the values from the DataTable
            string FN;
            string LN;
            string PhoneNumber;
            string Password;
            string Access;
            bool status;

            if (EmployeeId != null)
            {
                DataTable dt = ClassEmployee.GetAllEmployeesInfo((int)EmployeeId);
                DataRow row = dt.Rows[0];
                FN = row["first_name"].ToString();
                LN = row["last_name"].ToString();
                PhoneNumber = row["phone_number"].ToString();
                Password = row["password"].ToString();
                Access = row["access"].ToString();
                status = Convert.ToBoolean(row["status"]);
            }
            else//hone diered ro ha tkun !=null
            {
                FN = DesiredRow["first_name"].ToString();
                LN = DesiredRow["last_name"].ToString();
                PhoneNumber = DesiredRow["phone_number"].ToString();
                Password = DesiredRow["password"].ToString();
                Access = DesiredRow["access"].ToString();
                status = Convert.ToBoolean(DesiredRow["status"]);
            }

            if (FN != null && FN != "")
            {
                ucTextboxFirstName.FillDesignValue(FN);
            }

            if (LN != null && LN != "")
            {
                ucTextboxLastName.FillDesignValue(LN);
            }
            if (PhoneNumber != null && PhoneNumber != "")
            {
                ucTextboxPhoneNumber.FillDesignValue(PhoneNumber);
            }
            if (Password != null && Password != "")
            {
                ucTextboxPassword.FillDesignValue(Password);
            }

            checkBoxStatus.Checked = status;

            if (Access != null && Access != "")
            {
                string[] accessWords = Access.Split('/');

                foreach (string word in accessWords)
                {
                    if (word == enumFeatures.Workout.GetStringValue())
                    {
                        if (CheckboxWorkout != null)
                        {
                            CheckboxWorkout.Checked = true;
                        }
                    }
                    else if (word == enumFeatures.Schedule.GetStringValue())
                    {
                        if (CheckBoxSchedule != null)
                        {
                            CheckBoxSchedule.Checked = true;
                        }
                    }

                    else if (word == enumFeatures.Marketing.GetStringValue())
                    {
                        if (CheckBoxMarketing != null)
                        {
                            CheckBoxMarketing.Checked = true;
                        }
                    }
                    else if (word==enumFeatures.Transactions.GetStringValue())
                    {
                        
                        if (CheckBoxTransactions != null)
                        {
                            CheckBoxTransactions.Checked = true;
                        }
                    }
                    else if (word == enumFeatures.BackOffice.GetStringValue())
                    {

                        if (CheckBoxBackOffice != null)
                        {
                            CheckBoxBackOffice.Checked = true;
                        }
                    }
                    else if (word == enumFeatures.Statistics.GetStringValue())
                    {

                        if (CheckBoxStatistics != null)
                        {
                            CheckBoxStatistics.Checked = true;
                        }
                    }
                    else if (word == enumFeatures.EditOffres.GetStringValue())
                    {               
                        if (CheckBoxStatistics != null)
                        {
                            CheckBoxEditOffres.Checked = true;
                        }
                    }
                   
              

                }
            }
        }
        bool CheckRequired()
        {
            bool a = true;
            if (ucTextboxFirstName != null && ucTextboxFirstName.ActiveRequiredMode())
            {
                a = false;
            }
            if (ucTextboxLastName != null && ucTextboxLastName.ActiveRequiredMode())
            {
                a = false;
            }
            if (ucTextboxPassword != null && ucTextboxPassword.ActiveRequiredMode())
            {
                a = false;
            }
            if (ucTextboxPhoneNumber != null && ucTextboxPhoneNumber.ActiveRequiredMode())
            {
                a = false;
            }
            else
            {
                if (CheckPhoneNumber())
                {
                    CustomMessageBox.Show("This Phone Number is already taken", CustomMessageBox.Type.Ok);
                    a = false;
                }
            }
            return a;
        }
        bool CheckPhoneNumber()
        {
            string PhoneNumber = ucTextboxPhoneNumber.myTextBox1.Text;
            if (DesiredRow != null || EmployeeId != null)//edit mode not add
            {
                int employeeid;

                if (EmployeeId != null)
                {
                    employeeid = (int)EmployeeId;
                }
                else
                {
                    employeeid = (int)DesiredRow["employee_id"];
                }


                return ClassEmployee.SearchEmployeePhoneNumber(employeeid, PhoneNumber);
            }
            else
            {
                return ClassEmployee.SearchEmployeePhoneNumber(null, PhoneNumber);
            }
        }
        string GetAccess()
        {

            if (EmployeeId != null)//update men el homr
            {
                return LOGIN.Employee.Access;
            }
            else//add pr update
            {
                if (IsFeatures)
                {
                    string Access = "";

                    foreach (Control control in FLPFeatures.Controls)
                    {
                        if (control is CheckBox checkbox)
                        {
                            if (checkbox.Checked)
                            {
                                Access += checkbox.Text;                          
                                Access += "/";
                            }
                        }
                    }
                    return Access;
                }
                else
                    return null;
            }
        }



        public void AddEmployee()
        {
            ClassEmployee employee = new ClassEmployee();

            employee.Fname = ucTextboxFirstName.Value;
            employee.Lname = ucTextboxLastName.Value;
            employee.PhoneNumber = ucTextboxPhoneNumber.Value;
            employee.Password = ucTextboxPassword.Value;
            if (GetAccess() != null)
            {
                employee.Access = GetAccess();
            }
            else
            {
                employee.Access = null;
            }

            if (employee.CheckIfPAsswordExist(null))
            {
                CustomMessageBox.Show("Password already exists , choose another one", CustomMessageBox.Type.Ok);
            }
            else
            {

                employee.InsertEmployee();


                DataTable dtinserteditem = ClassEmployee.GetLastInsertEmployee();
                ParentFormViewEmpl.FormatOriginaldt(dtinserteditem);
                DataRow InsertedRow = dtinserteditem.Rows[0];//0 since it s only one row retrieve which is the new one 

                //Design        
                DataRow NewRow = ParentFormViewEmpl.dtEmployee.NewRow();
                NewRow.ItemArray = InsertedRow.ItemArray; // Copy the data from InsertedRow to NewRow
                ParentFormViewEmpl.dtEmployee.Rows.InsertAt(NewRow, 0);
                ParentFormViewEmpl.dataGridViewEdit.FirstDisplayedScrollingRowIndex = 0;

                this.Close();

            }

        }
        public void UpdateEmployee()
        {

            ClassEmployee employee;
            if (EmployeeId != null)
            {
                employee = LOGIN.Employee;

            }
            else
            {
                employee = new ClassEmployee();
            }

            employee.Fname = ucTextboxFirstName.Value;
            employee.Lname = ucTextboxLastName.Value;
            employee.PhoneNumber = ucTextboxPhoneNumber.Value;
            employee.Password = ucTextboxPassword.Value;

            if (DesiredRow != null)
            {
                if (GetAccess() != null)
                {
                    employee.Access = GetAccess();
                }
                else
                {
                    employee.Access = null;
                }
                employee.Status = (checkBoxStatus.Checked ? true : false);
                employee.EmployeeId = (int)DesiredRow["employee_id"];

            }

            if (employee.CheckIfPAsswordExist(DesiredRow["password"].ToString()))
            {
                CustomMessageBox.Show("Password already exists , choose another one", CustomMessageBox.Type.Ok);
            }
            else
            {
                employee.UpdateEmployee();


                //design
                if (DesiredRow != null)
                {
                    DesiredRow["first_name"] = employee.Fname;
                    DesiredRow["last_name"] = employee.Lname;
                    DesiredRow["phone_number"] = employee.PhoneNumber;
                    DesiredRow["password"] = employee.Password;
                    DesiredRow["access"] = employee.Access;
                    DesiredRow["FakeStatus"] = employee.Status;
                    DesiredRow["status"] = employee.Status;
                    ParentFormViewEmpl.FixColumnFakeAccess(DesiredRow);
                }
                this.Close();

            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckRequired())
            {
                if (DesiredRow != null || EmployeeId != null)
                {
                    UpdateEmployee();
                    ParentFormViewEmpl.FormatDatagridViewColors();
                }
                else
                {
                    AddEmployee();
                    ParentFormViewEmpl.FormatDatagridViewColors();
                }
              
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ClassEmployee employee = new ClassEmployee();
            employee.EmployeeId = (int)DesiredRow["employee_id"];
            if (employee.CheckIfEmployeeHasReferences())
            {
                CustomMessageBox.Show("Cannot delete this employee as there is some data attached to them.", CustomMessageBox.Type.Ok);
            }
            else
            {
                employee.DeleteEmployee();
                DesiredRow.Delete();
                this.Close();
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

        private void EditEmployee_FormClosing(object sender, FormClosingEventArgs e)
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


    }
}
