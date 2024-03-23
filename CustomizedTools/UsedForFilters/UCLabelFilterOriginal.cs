
using System;
using System.Windows.Forms;

namespace CustomizedTools
{
    public partial class UCLabelFilterOriginal : UserControl//mestaamela also lal filter and search
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

        private string detail;
        public string Detail
        {
            get { return detail; }
            set
            {
                detail = value;
                labelDetail.Text = detail;

            }
        }

        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public UCLabelFilterOriginal()
        {
            InitializeComponent();
        }


        public void SetLabelWidth()
        {

            int itemWidth = TextRenderer.MeasureText(Detail, labelDetail.Font).Width;
            int labelwidth = TextRenderer.MeasureText(Title, labelTitle.Font).Width;

            if (labelwidth < itemWidth)
            {
                this.Width = itemWidth + buttonRemove.Width + buttonSwitch.Width + 3 * buttonSwitch.Margin.Left + 40;
            }
            else
            {
                this.Width = labelwidth + buttonRemove.Width + buttonSwitch.Width + 3 * buttonSwitch.Margin.Left + 40;
            }
        }
    }
}
