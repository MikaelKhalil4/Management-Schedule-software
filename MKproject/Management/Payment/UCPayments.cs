using CustomizedTools;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class UCPayments : UserControl
    {

        Currency Currency = new Currency();

        private bool editModeOn;


        public bool EditModeOn
        {
            get { return editModeOn; }
            set
            {
                editModeOn = value;
                if (editModeOn == true)
                {
                    HideLabel();
                }
                else ShowLabel();
            }
        }

 

        private Double amount = 200;////just for testing, but usually we take it from the constrctor while we drag and drop
        public Double Amount
        {
            get { return amount; }
            set { amount = value; SetValue(); }
        }

        private string sign = "+";//default value for testing while we drag and drop  
        public string Sign//to know if the textbox will contain positive or negative numbers
        {
            get { return sign; }
            set
            {
                sign = value;
                if (sign == "+")
                {
                    textBoxPayment.ForeColor = Color.Green;
                }
                else
                {
                    textBoxPayment.ForeColor = Color.Red;
                }
                labelPayment.ForeColor = textBoxPayment.ForeColor;
                SetValue();
            }
        }

      

        public UCPayments()
        {
            InitializeComponent();
            this.Size = new Size(311, 47);
            SetValue();
            ShowLabel();
        }
        void ShowLabel()
        {
            labelPayment.Dock = DockStyle.Top;

            labelPayment.Visible = true;
            textBoxPayment.Visible = false;

        }
        void HideLabel()
        {
            textBoxPayment.Dock = DockStyle.Fill;
            labelPayment.Visible = false;
            textBoxPayment.Visible = true;
        }
        void SetValue()
        {
            textBoxPayment.Text = sign + Currency.Symbol + Convert.ToString(amount);
            labelPayment.Text = textBoxPayment.Text;
        }
   

       
        private void textBoxPayment_Leave(object sender, EventArgs e)
        {
            try
            {
          
            TextBox textBox = (TextBox)sender;
            String AmountString = textBox.Text.Replace(Sign, "").Replace(Currency.Symbol, "");
          
            if (AmountString == "" )
            {
                Amount = 0;
                textBox.Text = sign + Currency.Symbol + Amount;
                textBox.Select(2, textBox.Text.Length - 2);
            }

           else if (AmountString.Contains("."))
            {

                int dotPosition = AmountString.IndexOf('.');
                string afterDot = AmountString.Substring(dotPosition + 1);

                if (string.IsNullOrWhiteSpace(afterDot))
                {
                    textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                    AmountString = AmountString.Substring(0, AmountString.Length - 1);
                }

                Amount = Convert.ToDouble(AmountString);

            }
            else
            {
                Amount= Convert.ToDouble(AmountString);
            }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("you can t insert such a large number", CustomMessageBox.Type.Ok);  //cz hayde will only occur eza el raem akbar el double Convert.ToDouble(textBoxValue.Text) 
                Amount = 0;
            }

        }
     
        private void textBoxPayment_KeyDown_1(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            // Get the current cursor position in the TextBox
            int cursorPosition = textBox.SelectionStart;



            //ma ne2dir nemhe awal 2 chars
            if (e.KeyCode == Keys.Back)
            {
                // Check if there is selected text
                if (textBox.SelectionLength > 0)
                {
                    // Check if the selected text contains your desired characters
                    if (!textBox.SelectedText.Contains(sign) && !textBox.SelectedText.Contains(Currency.Symbol))
                    {
                        // If the selected text doesn't contain the undesired characters,
                        // remove the selected text and set the cursor position after the deletion
                        textBox.Text = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength);
                        textBox.SelectionStart = cursorPosition;
                    }
                    // Suppress the key event, so the Backspace key doesn't act as a regular backspace
                    e.SuppressKeyPress = true;
                }
                // Check if the cursor is positioned after the first two characters
                else if (cursorPosition > 2)
                {
                    // Remove the character behind the cursor
                    textBox.Text = textBox.Text.Remove(cursorPosition - 1, 1);

                    // Move the cursor back one position
                    textBox.SelectionStart = cursorPosition - 1;

                    // Suppress the key event to prevent default Backspace behavior
                    e.SuppressKeyPress = true;
                }
                else
                {
                    // Suppress the key event to prevent default Backspace behavior
                    e.SuppressKeyPress = true;
                }
            }



            //kermel ma ne2dar n8ayir awal 2 char
            // Check if the cursor is positioned within the first two characters
            if (cursorPosition < 2)
            {
                // Set the cursor to the end of the second character
                textBox.SelectionStart = 2;

                // Suppress the key event to prevent user input before the second character
                e.SuppressKeyPress = true;
            }



            //bass ekbous l left arrow ma e2dir rouh ba3del $
            if (e.KeyCode == Keys.Left)
            {
                // Check if the cursor is positioned within the first two characters
                if (cursorPosition <= 2)
                {
                    e.Handled = true;
                }
            }
        }
        private void textBoxPayment_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            string enteredText = textBox.Text.Substring(2, textBox.Text.Length - 2);
            enteredText = enteredText + e.KeyChar;

            // write only digits and .

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

            // kermel ma khalliya tektub . bel awwal bala shi abla
            if (e.KeyChar == '.')
            {
                // If dot is the first character after considering the selection or if a dot is already present
                if ((textBoxPayment.SelectionStart == 2 && textBoxPayment.SelectedText.Length == textBoxPayment.Text.Length-2) ||
                    (textBoxPayment.TextLength - (textBoxPayment.SelectedText.Length-2) == 0) ||
                    textBoxPayment.Text.Contains('.'))
                {
                    e.Handled = true;
                    return;
                }
            }


            //to only write one digit after the .

            bool containsDecimalPoint = enteredText.Contains('.');
            int cursorPosition = textBox.SelectionStart;
            // Validate if the entered text is a valid decimal number with one or no decimal places
            decimal value;
            if (decimal.TryParse(enteredText, out value))
            {
                // Check if the entered number has more than one digit after the decimal point
                int decimalPlaces = enteredText.Split('.').Length > 1 ? enteredText.Split('.')[1].Length : 0;
                if (decimalPlaces > 1 && e.KeyChar != '\b' && cursorPosition > enteredText.IndexOf('.'))
                {
                    e.Handled = true; // Ignore the key press
                    return;
                }
            }
        }

        private void textBoxPayment_DoubleClick_1(object sender, EventArgs e)
        {
            SelectDigits();

        }
        private void textBoxPayment_Enter_1(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BeginInvoke(new Action(() =>
            {
                SelectDigits();

            }));
        }    
        private void textBoxPayment_Click_1(object sender, EventArgs e)
        {
            //on click for when we click before the currency symbol to exit the textbox

            TextBox textBox = (TextBox)sender;
            // Get the current cursor position in the TextBox
            int cursorPosition = textBox.SelectionStart;
            if (cursorPosition < 2)
            {
                this.Parent.Focus();//eza ma sta3malna parent ma btechte8il w mbf le
            }
            if (textBox.Text == (sign + Currency.Symbol + "0"))
            {
                textBox.Select(2, textBox.Text.Length - 2);
            }
        }


        public void SelectDigits()
        {
            int selectionStart = 2;
            int selectionLength = textBoxPayment.Text.Length - selectionStart;
            textBoxPayment.Select(selectionStart, selectionLength);
        }


    }
}
