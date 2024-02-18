using System;
using System.Windows.Forms;


namespace CustomizedTools
{
    public partial class UCDoubleUCTextbox : UserControl
    {
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

        public UCDoubleUCTextbox()
        {
            InitializeComponent();

        }
        public UCDoubleUCTextbox(String stringtype1, String stringtype2, bool isrequired)
        {
            InitializeComponent();

            isRequired = isrequired;
            ucTextbox1.IsRequired = isrequired;
            ucTextbox2.IsRequired = isrequired;

            ucTextbox1.StringType = stringtype1;
            ucTextbox2.StringType = stringtype2;


            ucTextbox1.NextControl = ucTextbox2;
            ucTextbox2.NextControl = null;//sincemen el next control tabaa el double uc ha ykun aam yeshteghik
            ucTextbox2.myTextBox1.KeyDown += ucTextbox2MyTextBox1_KeyDown;

        }


        public void FillDesignValue(string firstData, string scdDData)
        {
            if (firstData != null)
            {
                ucTextbox1.FillDesignValue(firstData);
            }
            if (scdDData != null)
            {
                ucTextbox2.FillDesignValue(scdDData);
            }

          

        }

       
        public void SetUCModeForString()
        {


            ucTextbox1.IsRequired = isRequired;
            ucTextbox2.IsRequired = isRequired;

            ucTextbox1.SetUCModeForString();
            ucTextbox2.SetUCModeForString();
        }


        public bool ActiveRequiredMode()
        {
            if (!IsRequired)
            {
                return false;
            }
            else
            {
                if (ucTextbox1.Value == null || ucTextbox2.Value == null)
                {
                    if (ucTextbox1.Value == null)
                    {
                        ucTextbox1.ActiveRequiredMode();
                    }
                    if (ucTextbox2.Value == null)
                    {
                        ucTextbox2.ActiveRequiredMode();
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        
        //battalit moustaamela bas treka in case
        public void Reset()
        {
            ucTextbox1.Reset();
            ucTextbox2.Reset();
        }






        private void ucTextbox2MyTextBox1_KeyDown(object sender, KeyEventArgs e)
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
    }
}
