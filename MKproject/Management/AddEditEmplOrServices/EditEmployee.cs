
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GlobalFunctions;
using CustomizedTools;
using static MKproject.Management.Features;
using MKproject.Schedule;

namespace MKproject.Management
{
    public partial class EditEmployee : Form
    {
        Font seguiFont = new Font("Segoe UI", 12, FontStyle.Regular);//kermel 8ayir kel l fonts taba3 l controls li bzidoun
        int GroupBoxOldHeight;//la e5oud l oldheight taba3 l groupBox abel ma 8ayerla siza


        private CheckBox CheckBoxEditOffres;
        private CheckBox CheckBoxTransactions;
        private CheckBox CheckBoxEditEmployeesServicesProducts;
        private CheckBox CheckBoxStatistics;
        private CheckBox CheckBoxEditClients;
        private CheckBox CheckBoxDeleteClient;
        private CheckBox CheckBoxRegistrationFields;

        private CheckBox CheckBoxSchedule;




        DataRow DesiredRow;
        public ViewEmployee ParentFormViewEmpl;



        public EditEmployee(DataRow desiredRow)
        {
            InitializeComponent();
            DesiredRow = desiredRow;


            GroupBoxOldHeight = groupBoxFeatures.Size.Height;
            LoadForm();

            if (DesiredRow != null)//edit mode not add
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

            if (DesiredRow == null) //Add Employee men el editemployeeForm 
            {
                checkBoxStatus.Checked = true;
            }


            ToolTip toolTip1 = new ToolTip();
            toolTip1.InitialDelay = 800;
            toolTip1.AutoPopDelay = 30000;
            toolTip1.ShowAlways = true;


            CheckBoxSchedule = new CheckBox();
            CheckBoxSchedule.Text = enumFeatures.Schedule.GetStringValue();
            CheckBoxSchedule.Font = seguiFont;
            CheckBoxSchedule.AutoSize = true;
            FLPFeatures.Controls.Add(CheckBoxSchedule);
            toolTip1.SetToolTip(CheckBoxSchedule, "This feature allows employees to access the schedule");

            CheckBoxEditOffres = new CheckBox();
            CheckBoxEditOffres.Text = enumFeatures.EditOffres.GetStringValue();
            CheckBoxEditOffres.Font = seguiFont;
            CheckBoxEditOffres.AutoSize = true;
            FLPFeatures.Controls.Add(CheckBoxEditOffres);
            toolTip1.SetToolTip(CheckBoxEditOffres, "This feature allows employees to edit the offers of the client while purchasing a service or product");

            CheckBoxRegistrationFields = new CheckBox();
            CheckBoxRegistrationFields.Text = enumFeatures.RegistrationFields.GetStringValue();
            CheckBoxRegistrationFields.Font = seguiFont;
            CheckBoxRegistrationFields.AutoSize = true;
            FLPFeatures.Controls.Add(CheckBoxRegistrationFields);
            toolTip1.SetToolTip(CheckBoxRegistrationFields, "This feature allows employees to show or hide fields or set them as required for the client's information");

            CheckBoxEditClients = new CheckBox();
            CheckBoxEditClients.Text = enumFeatures.EditClients.GetStringValue();
            CheckBoxEditClients.Font = seguiFont;
            CheckBoxEditClients.AutoSize = true;
            FLPFeatures.Controls.Add(CheckBoxEditClients);
            toolTip1.SetToolTip(CheckBoxEditClients, "This feature allows employees to insert or edit clients' information");

            CheckBoxDeleteClient = new CheckBox();
            CheckBoxDeleteClient.Text = enumFeatures.DeleteClients.GetStringValue();
            CheckBoxDeleteClient.Font = seguiFont;
            CheckBoxDeleteClient.AutoSize = true;
            FLPFeatures.Controls.Add(CheckBoxDeleteClient);
            toolTip1.SetToolTip(CheckBoxDeleteClient, "This feature allows employees to delete clients");

            CheckBoxTransactions = new CheckBox();
            CheckBoxTransactions.Text = enumFeatures.Transactions.GetStringValue();
            CheckBoxTransactions.Font = seguiFont;
            CheckBoxTransactions.AutoSize = true;
            FLPFeatures.Controls.Add(CheckBoxTransactions);
            toolTip1.SetToolTip(CheckBoxTransactions, "This feature enables employees to access all interactions made on the system. At the client level, they can access all interactions made by this client and can undo actions");

            CheckBoxStatistics = new CheckBox();
            CheckBoxStatistics.Text = enumFeatures.Statistics.GetStringValue();
            CheckBoxStatistics.Font = seguiFont;
            CheckBoxStatistics.AutoSize = true;
            FLPFeatures.Controls.Add(CheckBoxStatistics);
            toolTip1.SetToolTip(CheckBoxStatistics, "This feature allows employees to view all statistics, from income to client attendance, in real time or for any selected date");

            CheckBoxEditEmployeesServicesProducts = new CheckBox();
            CheckBoxEditEmployeesServicesProducts.Text = enumFeatures.ServicesProductsEmployees.GetStringValue();
            CheckBoxEditEmployeesServicesProducts.Font = seguiFont;
            CheckBoxEditEmployeesServicesProducts.AutoSize = true;
            FLPFeatures.Controls.Add(CheckBoxEditEmployeesServicesProducts);
            toolTip1.SetToolTip(CheckBoxEditEmployeesServicesProducts, "This feature enables employees, to add/Edit/Delete services, products or employee");




            AdjustFeaturesSize();
            ChangeFormSize(true);




        }




        private void AdjustFeaturesSize()
        {
            int MaxHeight = 220;
            // Get the preferred size of FLPFeatures
            Size preferredSize = FLPFeatures.PreferredSize;

            // Add some extra padding if needed
            int padding = 2; // You can adjust the padding as per your preference

            int SizeDifference = groupBoxFeatures.Size.Height - FLPFeatures.Size.Height;//kermel nchouf l fare2 ben l groupbox wel FLP
            int DesiredHeight = preferredSize.Height + padding + SizeDifference;
            if (DesiredHeight > MaxHeight)
            {
                groupBoxFeatures.Size = new Size(groupBoxFeatures.Size.Width, MaxHeight);

            }
            else
            {
                groupBoxFeatures.Size = new Size(groupBoxFeatures.Size.Width, preferredSize.Height + padding + SizeDifference);

            }
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
            bool isScheduleMember;


            FN = DesiredRow["first_name"].ToString();
            LN = DesiredRow["last_name"].ToString();
            PhoneNumber = DesiredRow["phone_number"].ToString();
            Password = DesiredRow["password"].ToString();
            Access = DesiredRow["access"].ToString();
            status = Convert.ToBoolean(DesiredRow["status"]);
            isScheduleMember = Convert.ToBoolean(DesiredRow["is_schedule_member"]);


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
            checkBoxScheduleMember.Checked = isScheduleMember;
            if (Access != null && Access != "")
            {
                string[] accessWords = Access.Split('/');

                foreach (string word in accessWords)
                {
                    //schedule
                    if (word == enumFeatures.Schedule.GetStringValue())
                    {
                        if (CheckBoxSchedule != null)
                        {
                            CheckBoxSchedule.Checked = true;
                        }
                    }

                    //management
                    else if (word == enumFeatures.Transactions.GetStringValue())
                    {

                        if (CheckBoxTransactions != null)
                        {
                            CheckBoxTransactions.Checked = true;
                        }
                    }
                    else if (word == enumFeatures.ServicesProductsEmployees.GetStringValue())
                    {

                        if (CheckBoxEditEmployeesServicesProducts != null)
                        {
                            CheckBoxEditEmployeesServicesProducts.Checked = true;
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
                        if (CheckBoxEditOffres != null)
                        {
                            CheckBoxEditOffres.Checked = true;
                        }
                    }
                    else if (word == enumFeatures.RegistrationFields.GetStringValue())
                    {
                        if (CheckBoxRegistrationFields != null)
                        {
                            CheckBoxRegistrationFields.Checked = true;
                        }
                    }
                    else if (word == enumFeatures.EditClients.GetStringValue())
                    {
                        if (CheckBoxEditClients != null)
                        {
                            CheckBoxEditClients.Checked = true;
                        }
                    }
                    else if (word == enumFeatures.DeleteClients.GetStringValue())
                    {
                        if (CheckBoxDeleteClient != null)
                        {
                            CheckBoxDeleteClient.Checked = true;
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
            if (DesiredRow != null)//edit mode not add
            {
                return ClassEmployee.SearchEmployeePhoneNumber((int)DesiredRow["employee_id"], PhoneNumber);
            }
            else
            {
                return ClassEmployee.SearchEmployeePhoneNumber(null, PhoneNumber);
            }
        }
        string GetAccess()
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

            if (String.IsNullOrEmpty(Access))
            {
                return null;
            }
            else
            {
                return Access;
            }

        }




        public void AddEmployee()
        {
            ClassEmployee employee = new ClassEmployee();

            employee.Fname = ucTextboxFirstName.Value;
            employee.Lname = ucTextboxLastName.Value;
            employee.PhoneNumber = ucTextboxPhoneNumber.Value;
            employee.Password = ucTextboxPassword.Value;
            employee.Status = checkBoxStatus.Checked;
            employee.IsScheduleMember = checkBoxScheduleMember.Checked;
            employee.Access = GetAccess();



            if (employee.CheckIfPAsswordExist(null))
            {
                CustomMessageBox.Show("Password already exists , choose another one", CustomMessageBox.Type.Ok);
            }
            else
            {

                employee.InsertEmployee();


                DataTable dtinserteditem = ClassEmployee.GetAllEmployeesOrLAstInseted(false);
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
            ClassEmployee employee = new ClassEmployee();



            employee.Fname = ucTextboxFirstName.Value;
            employee.Lname = ucTextboxLastName.Value;
            employee.PhoneNumber = ucTextboxPhoneNumber.Value;
            employee.Password = ucTextboxPassword.Value;
            employee.Access = GetAccess();
            employee.Status = checkBoxStatus.Checked;
            employee.IsScheduleMember = checkBoxScheduleMember.Checked;
            //
            employee.EmployeeId = (int)DesiredRow["employee_id"];
         
            employee.Rank = DesiredRow["rank"] is DBNull ? null : (int)DesiredRow["rank"];
            employee.Availability= DesiredRow["availability"] is DBNull? null : (string)DesiredRow["availability"];

            bool OldIsScheduleMember = (bool)DesiredRow["is_schedule_member"];
            bool NewIsScheduleMember = checkBoxScheduleMember.Checked;



            if (employee.CheckIfPAsswordExist(DesiredRow["password"].ToString()))
            {
                CustomMessageBox.Show("Password already exists , choose another one.", CustomMessageBox.Type.Ok);
            }
            else if (OldIsScheduleMember == true && NewIsScheduleMember == false && employee.CheckIfEmployeeHasAppointments())//in case aam notfe el employee as schedule member
            {
                CustomMessageBox.Show("To deactivate the employee's schedule, cancel all their existing appointments.", CustomMessageBox.Type.Ok);
            }
            else
            {
                employee.UpdateEmployee();

                //design in datatgrid
                if (DesiredRow != null)//we re updating only the fields that could change
                {
                    //hole byetghayro by desing
                    DesiredRow["first_name"] = employee.Fname;
                    DesiredRow["last_name"] = employee.Lname;
                    DesiredRow["phone_number"] = employee.PhoneNumber;
                    DesiredRow["password"] = employee.Password;
                    DesiredRow["access"] = employee.Access;
                    DesiredRow["FakeStatus"] = employee.Status;
                    DesiredRow["status"] = employee.Status;
                    DesiredRow["FakeIsScheduleMember"] = employee.IsScheduleMember;
                    DesiredRow["is_schedule_member"] = employee.IsScheduleMember;

                    //hle ma32oul yetghdayaro by   employee.UpdateEmployee();
                    DesiredRow["availability"] = employee.Availability is null? DBNull.Value : employee.Availability;
                    DesiredRow["rank"] = employee.Rank is  null ? DBNull.Value : employee.Rank; ;
                }
                this.Close();

            }
        }



        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckRequired())
            {
                if (DesiredRow != null)
                {
                    UpdateEmployee();
                }
                else
                {
                    AddEmployee();
                }

            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ClassEmployee employee = ClassEmployee.CreateEmployeeObject((int)DesiredRow["employee_id"]);
          
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
