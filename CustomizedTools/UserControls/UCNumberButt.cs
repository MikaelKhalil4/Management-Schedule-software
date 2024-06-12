using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomizedTools
{
    public partial class UCNumberButt : UserControl
    {


        //li farae bayno wben ghayra , the negative number that can occur
        public UCNumberButt()
        {
            InitializeComponent();
        }

        private Int32 number;////just for testing, but usually we take it from the constrctor while we drag and drop
        public Int32 Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                if (isNegative)
                {
                    textBoxValue.ForeColor = Color.Red;
                }
                textBoxValue.Text = Convert.ToString(number);
            }
        }

        private bool isNegative = false;//default value 
        public bool IsNegative//stroy:,to know if the textbox will contain positive or negative numbers, w bas ha tkun negative , w ha tkun output only bel profile, lamma ekbus ha tekhtefe w tsi positive kella
        {
            get { return isNegative; }
            set
            {
                isNegative = value;


            }
        }

        private Int32 minimum_number = 0;
        public Int32 Minimum_number
        {
            get { return minimum_number; }
            set
            {
                if (maximum_number > value)
                {
                    minimum_number = value;
                }
                else
                {
                    minimum_number = (int)maximum_number - 1;
                }
            }
        }

        private Int32 maximum_number = Int32.MaxValue;
        public Int32 Maximum_number
        {
            get { return maximum_number; }
            set
            {
                if (value > minimum_number)
                {
                    maximum_number = value;
                }
                else
                {
                    maximum_number = minimum_number + 1;
                }
            }
        }


        public Font TextBoxFont
        {
            get
            {
                return textBoxValue.Font;
            }
            set
            {
                textBoxValue.Font = value;
            }
        }
        public Color TextBoxBackColor
        {
            get { return textBoxValue.BackColor; }
            set { textBoxValue.BackColor = value; }
        }
        public Size ButtonSizeMinus
        {
            get { return buttonValueMinus.Size; }
            set { buttonValueMinus.Size = value; }
        }
        public Size ButtonSizePlus
        {
            get { return buttonValuePlus.Size; }
            set { buttonValuePlus.Size = value; }
        }


        private void textBoxValue_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                Number = minimum_number;
            }
        }
        private void textBoxValue_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;


            textBox.BeginInvoke(new Action(() =>
            {
                textBox.SelectAll();

            }));


        }
        private void textBoxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;


            // write only digits and .
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignore the key press
                return;
            }

            string enteredText = textBox.Text + e.KeyChar;

            //Length kermel masalan eza ken el max number toula 4 digits, ma nkhalli yektub aktar men 4 digits
            if (enteredText.Length > maximum_number.ToString().Length && e.KeyChar != '\b' && textBox.SelectionLength != textBox.Text.Length)
            {
                    e.Handled = true;   
            }


        }

        public event EventHandler TextBoxValueTextBoxValueTextChange;
        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {

            if (textBoxValue.Text != "")
            {
                if (Number >= 0)//a rare case but we need to handle it, cz ma32oul tkun red in case kenit negative el number
                {
                    textBoxValue.ForeColor = Color.Black;
                }

                if (IsNegative == false && Convert.ToInt64(textBoxValue.Text) < minimum_number)//convert to 64 lieanno eza katabla raem akbar men 32 ma yaamil crash
                {

                    Number = minimum_number;

                }
                else if (Convert.ToInt64(textBoxValue.Text) > maximum_number)//kermel eza hattayna raem akbar men el maximum ma nkhalli
                {

                    Number = (int)maximum_number;
                }
                else
                {
                    number = Convert.ToInt32(textBoxValue.Text);//32 lieanno ta yusal la hone ejbare ykkun 32 
                }

                IsNegative = false;//is negative ha tkun available bas awwal ma nfout w ykun eena negative days left, w ha tkun output only bel profile, lamma ekbus ha tekhtefe w tsi positive kella


            }

            //
            TextBoxValueTextBoxValueTextChange?.Invoke(this, e);
        }



        private void buttonValueMinus_Click(object sender, EventArgs e)
        {
            if (number > minimum_number)
            {
                Number--;
            }
        }
        private void buttonValuePlus_Click(object sender, EventArgs e)
        {
            if (number < maximum_number)
            {
                Number++;
            }
        }


    }
}
