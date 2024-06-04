using System;
using System.Windows.Forms;
using CustomizedTools;

namespace MKproject.Management
{
    public partial class LOGIN : Form
    {
        public static ClassEmployee Employee;


        public LOGIN()
        {
            InitializeComponent();

            LoadForm();
        }
        public void LoadForm()
        {
            textBoxPassword.Text = "";
            textBoxPassword.Select();
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



        private void buttonLogin_Click(object sender, EventArgs e)
        {

            int EmpId = ClassEmployee.CheckIfEmployeeExist(textBoxPassword.Text);

            if (EmpId != -1)
            {
                Employee = new ClassEmployee();
                Employee = ClassEmployee.CreateEmployeeObject(EmpId);
                Employee.SetEmployeeAccess();
                this.Hide();
                Program.HomeForm = new Home();
                Program.HomeForm.Show();
            }
            else
            {
                CustomMessageBox.Show("wrong password or phone number, please try again", CustomMessageBox.Type.Error);
                textBoxPassword.Select();
            }
        }


        private void buttonHide_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.UseSystemPasswordChar == false)
            {
                buttonShow.BringToFront();
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }
        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.UseSystemPasswordChar == true)
            {
                buttonHide.BringToFront();
                textBoxPassword.UseSystemPasswordChar = false;
            }
        }
        private void textBoxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignore the key press
                return;
            }
        }
        private void textBoxPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxPassword.Select();
                e.SuppressKeyPress = true;
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(this, new EventArgs());
                e.SuppressKeyPress = true;
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2;

        }


    }
}