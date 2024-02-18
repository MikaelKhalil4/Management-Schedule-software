using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class UCNumberLabelButt : UserControl
    {
        public UCNumberLabelButt()
        {
            InitializeComponent();
        }

        private string unit;

        public string Unit
        {
            get { return unit; }
            set { unit = value;
                labelUnit.Text = value;
            }
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
                textBoxValue.Text = Convert.ToString(number);
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
            if (enteredText.Length > maximum_number.ToString().Length && e.KeyChar != '\b' && textBox.SelectionLength != textBox.Text.Length)
            {
                e.Handled = true; // Ignore the key press
            }


        }
     
        public event EventHandler textBoxValueTextChanged;
        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {
            if (textBoxValue.Text != "")
            {

                if (Convert.ToInt64(textBoxValue.Text) < minimum_number)//kermel eza hattayna raem akbar men el maximum ma nkhalli
                {

                    Number = minimum_number;
                }
                else if (Convert.ToInt64(textBoxValue.Text) > maximum_number)//kermel eza hattayna raem akbar men el maximum ma nkhalli
                {

                    Number = (int)maximum_number;
                }
                else
                {
                    number = Convert.ToInt32(textBoxValue.Text);//number zghire cz ma bda nerjaa naabe el text cz already mawjud
                }


            }

            textBoxValueTextChanged?.Invoke(this, e);

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
