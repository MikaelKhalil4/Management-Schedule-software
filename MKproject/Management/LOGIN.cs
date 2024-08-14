using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomizedTools;
using GlobalFunctions;

namespace MKproject.Management
{
    public partial class LOGIN : Form
    {



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
                Cursor = Cursors.WaitCursor;

                Program.Employee = new ClassEmployee();
                Program.Employee = ClassEmployee.CreateEmployeeObject(EmpId);
                Program.Employee.SetEmployeeAccess();
                Program.HomeForm = new Home();
                Program.HomeForm.Show();
                this.Hide();
                Cursor = Cursors.Default;

            }
            else
            {
                CustomMessageBox.Show("wrong password , please try again", CustomMessageBox.Type.Error);
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

        private void buttonLogin_MouseHover(object sender, EventArgs e)
        {
            //buttonLogin.ForeColor = Color.White;
            //buttonLogin.BackColor = Color.FromArgb(61, 121, 219);
        }

        private void buttonLogin_MouseLeave(object sender, EventArgs e)
        {
            //buttonLogin.ForeColor = Color.FromArgb(61, 121, 219);
            //buttonLogin.BackColor = Color.White;
        }
    }
}