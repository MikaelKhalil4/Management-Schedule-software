using GlobalFunctions;
using System;
using System.Windows.Forms;

namespace CustomizedTools
{

    public partial class UCComboBoxFilterOriginal : UserControl
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

        public string LastState { get; set; }

        public UCComboBoxFilterOriginal()
        {
            InitializeComponent();
        }
      

 
        public void SetUCComboBoxWidth(UserControl MainUserControl, ComboBox comboBoxDetail, Label labelTitle)
        {
            int maxComboBoxWidth =FunctionsForWinformsTool.ReturnComboBoxWidth(comboBoxDetail);
        
            int labelwidth = TextRenderer.MeasureText(labelTitle.Text, labelTitle.Font).Width;

            if (labelwidth < maxComboBoxWidth)
                MainUserControl.Width = maxComboBoxWidth + SystemInformation.VerticalScrollBarWidth + 5;
            else
                MainUserControl.Width = labelwidth + SystemInformation.VerticalScrollBarWidth + 5;
        }

        private void comboBoxDetail_SelectedIndexChanged(object sender, EventArgs e)
        {

            labelTitle.Select();

          
        }

        private void comboBoxDetail_DropDownClosed(object sender, EventArgs e)
        {

            labelTitle.Select();
        }
    }
}
