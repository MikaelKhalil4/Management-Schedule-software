using System;
using System.Drawing;
using System.Windows.Forms;
using GlobalFunctions;


namespace CustomizedTools
{
    public partial class UCLabelAndDetail : UserControl
    {
        int minimum_height = 42;
       

        private int index;//to order by index in the Panel
        public int Index
        {
            get { return index; }
            set { index = value; }
        }


        private string type;
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                labelType.Text = type;
                CheckSize(labelType.Width, labelDetail.Width);
            }
        }


        private string detail;
        public string Detail
        {
            get { return detail; }
            set
            {
                detail = value;
                labelDetail.Text = detail;             
                CheckSize(labelType.Width,labelDetail.Width);
            }
        }


        public UCLabelAndDetail()
        {
            InitializeComponent();
        }
        public void CheckSize(int type_width,int detail_width)
        {
            int desiredHeightDetail = RandomFunctions.CalculateDesiredHeight(labelDetail,detail_width);
            int desiredHeightType = RandomFunctions.CalculateDesiredHeight(labelType,type_width);
            int desiredHeight = Math.Max(desiredHeightType, desiredHeightDetail);
            if (desiredHeight < minimum_height)
            {
                desiredHeight = minimum_height;
            }            
            if (desiredHeight != this.Height)
            {
                this.Height = desiredHeight;
                labelType.TextAlign = ContentAlignment.TopLeft;

                if (desiredHeightDetail > desiredHeightType)
                {
                    labelDetail.TextAlign = ContentAlignment.TopRight;
                }
            }
            if (desiredHeight == minimum_height)
            {
                labelType.TextAlign = ContentAlignment.MiddleLeft;
                labelDetail.TextAlign = ContentAlignment.MiddleRight;
            }
        }
        public void SetDesign()
        {
            this.BackColor = Color.LightGray;
            this.Dock = DockStyle.Top;
            tableLayoutPanel1.BackColor = Color.FromArgb(238, 241, 254);
            this.Padding = new Padding(0, 1, 0, 0);
        }
      
    }
}
