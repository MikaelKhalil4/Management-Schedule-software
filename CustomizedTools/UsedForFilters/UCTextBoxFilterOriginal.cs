using System;
using System.Windows.Forms;

namespace CustomizedTools
{
    public partial class UCTextBoxFilterOriginal : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

      


        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                labelTitle.Text = title;

            }
        }
        private string placeHolder;


        public string PlaceHolderOfTextBox
        {
            get { return placeHolder; }
            set {
                placeHolder = value;           
                textBox.PlaceholderText = placeHolder;
            }
        }



        public UCTextBoxFilterOriginal()
        {
            InitializeComponent();
        }

        public event EventHandler TextBoxTextChanged;//n the UserControl, we define a custom event called TextBoxTextChanged. This event is of type EventHandler, which is a delegate that can hold references to methods that have the same signature as the event.
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged?.Invoke(this, EventArgs.Empty);//this one activate the event foe, eza hayda el event kenna 3abyino events, ha yaamellun excute kellun, yaane eza bi gher form hattet fi event it will excute it
        }

        public event EventHandler TextBoxClicked;
        private void textBox_Click(object sender, EventArgs e)
        {
            TextBoxClicked?.Invoke(this, EventArgs.Empty);//this one activate the event foe, eza hayda el event kenna 3abyino events, ha yaamellun excute kellun, yaane eza bi gher form hattet fi event it will excute it

        }
    }
}
