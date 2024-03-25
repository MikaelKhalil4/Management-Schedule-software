using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;


namespace CustomizedTools
{
    public class TextBoxWithPlaceHolder : TextBox
    {
        private string placeholderText;
        private bool isRequiredModeOn;

        public bool IsRequiredModeOn
        {
            get { return isRequiredModeOn; }
            set
            {
                isRequiredModeOn = value;
                if (PlaceholderText != null && isRequiredModeOn)
                {
                    if (!PlaceholderText.Contains(" *"))
                    {
                     placeholderText += " *";//ased hattayna el miniscule
                    }
                    SetPlaceholder();
                }  
                else
                {
                    if (PlaceholderText!=null && PlaceholderText.Contains(" *"))
                    {
                        placeholderText=PlaceholderText.Replace("*", "");//ased hattayna el miniscule
                    }
                    SetPlaceholder();
                }
            }



        }

        public TextBoxWithPlaceHolder()
        {
            //// Set a default placeholder text
            //PlaceholderText = "Enter text here...";
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Appearance")]
        [Description("The placeholder text displayed in the text box when it is empty.")]

        public string PlaceholderText//Property
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;

                SetPlaceholder();
            }
        }


        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (Text != placeholderText)//kermel eza ghayarna el text by code
            {
                ForeColor = Color.Black;
            }
            else
            {
                ForeColor = Color.Gray;
            }
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (Text == placeholderText)
            {
                Text = "";
                //ForeColor = Color.Black; hattayneha bel textchange
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (string.IsNullOrWhiteSpace(Text) || Text == placeholderText)
            {
                SetPlaceholder();
            }
        }



        private void SetPlaceholder()
        {
            ForeColor = Color.FromArgb(80, 80, 80);
            Text = placeholderText;
            if (IsRequiredModeOn)
            {           
                ForeColor = Color.Red;
            }
            else
            {
                ForeColor = Color.Gray;
            }

        }

    }
}
