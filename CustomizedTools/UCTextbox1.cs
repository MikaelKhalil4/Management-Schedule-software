using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using GlobalFunctions;

namespace CustomizedTools
{
    public partial class UCTextbox1 : UserControl
    {

        public Label labelEmail;

        public bool IsPhoneNumber { get; set; }//once it s set , bi battil fi el user gher yfawwit digits

        private bool isEmail;
        public bool IsEmail
        {
            get { return isEmail; }
            set
            {

                isEmail = value;
            }
        }


        private string stringType;
        public string StringType
        {
            get { return stringType; }
            set
            {
                stringType = value;
                SetUCModeForString();
            }//ejbare tahta

        }



        private string value;
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }


        private bool isRequired;
        public bool IsRequired
        {
            get { return isRequired; }
            set
            {

                isRequired = value;
                SetUCModeForString();
            }
        }


        public Control ParentOfNextControl { get; set; }

        private Control nextcontrol;//kermel 3a event l enter nnot men control lal tene
        public Control NextControl
        {
            get { return nextcontrol; }
            set
            {
                nextcontrol = value;
            }
        }

        private int index;//to order by index in the FLPInfo in newregister
        public int Index
        {
            get { return index; }
            set { index = value; }
        }


        private bool hasRightEmailFormat=true;//eza ma ken right email format men hotto bel required fields
        public bool HasRightEmailFormat
        {
            get
            {
                return hasRightEmailFormat;
            }
            set { hasRightEmailFormat = value; }

        }

   

        public UCTextbox1()
        {
            InitializeComponent();
        }
        public UCTextbox1(String stringtype, bool isrequired)
        {
            InitializeComponent();
            isRequired = isrequired;
            StringType = stringtype;//hattayna hone el property kermel naayit lal SetUCModeForString,
                                    //w ejbare tkun tahet isRequired = isrequired;
        }



        public void FillDesignValue(string data)
        {
            if (data != null)
            {
                groupBox1.Text = StringType;
                groupBox1.Font = new Font(groupBox1.Font, FontStyle.Bold);
                myTextBox1.ForeColor = Color.Black;
                myTextBox1.Text = data;
                SetValue();
            }
        }
        public void SetValue()
        {
            if (!string.IsNullOrEmpty(myTextBox1.Text) && myTextBox1.Text != myTextBox1.PlaceholderText)
            {
                Value = myTextBox1.Text.Trim();
            }
            else
            {
                Value = null;
            }
        }
        public void SetUCModeForString()
        {
            myTextBox1.PlaceholderText = StringType;
            groupBox1.Text = "";
            if (!IsRequired)
            {
                myTextBox1.PlaceholderText = StringType + " (optional)";
                myTextBox1.IsRequiredModeOn = false;

            }
        }
        public bool ActiveRequiredMode()
        {
            if (!IsRequired)
            {
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(this.Value))
                {
                    myTextBox1.IsRequiredModeOn = true;
                    groupBox1.Text = "";
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


        //bas moustaamale now lal phone number bel regist form
        public void Reset()
        {
            Value = null;
            
            groupBox1.ForeColor = Color.Black;
            myTextBox1.Enabled = true;
            myTextBox1.IsRequiredModeOn = false;
            SetUCModeForString();
        }
        public void DisableUC()
        {
            myTextBox1.Enabled = false;
            groupBox1.ForeColor = Color.FromArgb(88, 88, 88);
        }


        public void CreatEmailFormat()
        {
            if (labelEmail==null)
            {
                labelEmail = new Label();
                labelEmail.Visible = false;
                labelEmail.Text = "Fix Email Formatting";
                groupBox1.Controls.Add(labelEmail);
                labelEmail.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular);
                labelEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                labelEmail.ForeColor = Color.Red;
                labelEmail.AutoSize = true;
            }
            labelEmail.Location = new Point(this.Width - Convert.ToInt16(RandomFunctions.MeasureLabelText(labelEmail)), 0);
        }



        private void myTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (nextcontrol != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true; // Prevent the Enter key from being processed in the current control
                    if (ParentOfNextControl != null)
                    {
                        ParentOfNextControl.Focus();
                    }
                    nextcontrol.Focus();
                    e.SuppressKeyPress = true;//to remove the sound when u press enter
                }
            }

        }
        private void myTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsPhoneNumber)
            {
                e.Handled = !char.IsDigit(e.KeyChar) &&  e.KeyChar != '\b' && !char.IsControl(e.KeyChar);
            }

        }
        private void myTextBox1_Enter(object sender, EventArgs e)
        {
            groupBox1.Text = StringType;
            groupBox1.ForeColor = Color.White;

        }
        private void myTextBox1_Leave(object sender, EventArgs e)
        {

            //
            if (myTextBox1.Text == "")
                groupBox1.Text = "";

            groupBox1.ForeColor = Color.Black;
            groupBox1.Font = new Font(groupBox1.Font, FontStyle.Bold);
        }

        public event EventHandler textboxtextchange;
        private void myTextBox1_TextChanged(object sender, EventArgs e)
        {

            if (IsEmail)
            {
                CreatEmailFormat();
                SetValue();

                Regex mRegxExpression;
                if (value != null)
                {
                    mRegxExpression = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
                    if (mRegxExpression.IsMatch(myTextBox1.Text.Trim()))
                    {
                        // Valid email format
                        HasRightEmailFormat = true;
                        labelEmail.Visible = false;

                    }
                    else
                    {
                        // Invalid email format
                        HasRightEmailFormat = false;
                        labelEmail.Visible = true;
                    }
                }
                else
                {
                    HasRightEmailFormat = true;
                    labelEmail.Visible = false;
                }

            }
            else
            {
                SetValue();
            }
            textboxtextchange?.Invoke(this, e);
        }



    }
}
