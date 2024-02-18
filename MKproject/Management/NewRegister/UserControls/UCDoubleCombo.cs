using System;
using System.Linq;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class UCDoubleCombo : UserControl
    {
        public UCDoubleCombo()
        {
            InitializeComponent();
        }


        private string unit;

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }


        private double number;////just for testing, but usually we take it from the constrctor while we drag and drop
        public double Number
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

      
        private double minimum_number = 0;
        public double Minimum_number
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

      
        private double maximum_number = Double.MaxValue;
        public double Maximum_number
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



        private void textBoxValue_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                Number = 0;
            }
            else if (textBox.Text.EndsWith("."))
            {
                Number = Convert.ToDouble(textBox.Text.Substring(0, textBox.Text.Length - 1));
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

     

        public event EventHandler textBoxValueTextChanged;
        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {        
                if (textBoxValue.Text != "")
                {
                    if (Convert.ToDouble(textBoxValue.Text) < minimum_number)
                    {

                        Number = minimum_number;

                    }
                    else if (Convert.ToDouble(textBoxValue.Text) > maximum_number)//kermel eza hattayna raem akbar men el maximum ma nkhalli
                    {

                        Number = (int)maximum_number;
                    }
                    else
                    {
                        number = Convert.ToDouble(textBoxValue.Text);
                    }
                }      

                textBoxValueTextChanged?.Invoke(this, e);
        }
        private void textBoxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Check if the key pressed is a digit or a decimal point
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignore the key press
                return;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && textBox.Text.Contains('.') && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignore the key press
                return;
            }

            //To make sure you don'y start the number with a point
            if (e.KeyChar == '.' && (string.IsNullOrWhiteSpace(textBox.Text) || textBox.SelectionLength == textBox.Text.Length))
            {
                e.Handled = true; // Ignore the key press
                return;
            }

            string enteredText = textBox.Text + e.KeyChar;

            // Check if the entered text contains a decimal point
            bool containsDecimalPoint = enteredText.Contains('.');
            int cursorPosition = textBox.SelectionStart;

            // Validate if the entered text is a valid decimal number with one or no decimal places
            decimal value;
            if (decimal.TryParse(enteredText, out value))
            {
                // Check if the entered number has more than one digit after the decimal point
                int decimalPlaces = enteredText.Split('.').Length > 1 ? enteredText.Split('.')[1].Length : 0;
                if (decimalPlaces > 1 && e.KeyChar != '\b' && cursorPosition > textBox.Text.IndexOf('.'))
                {
                    e.Handled = true; // Ignore the key press
                    return;
                }
            }

            if ((enteredText.Length > maximum_number.ToString().Length) && e.KeyChar != '\b' && textBox.SelectionLength != textBox.Text.Length)
            {
                if (enteredText.Contains('.'))
                {
                    if (enteredText.Length > maximum_number.ToString().Length+2)
                    {
                        e.Handled = true; // Ignore the key press
                        return;
                    }
                }
                else
                {
                    e.Handled = true; // Ignore the key press
                    return;
                }
            }
        }


    
        private void comboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Unit = comboBoxUnit.SelectedItem.ToString();

        }
      
    }
}
