using CustomizedTools;
using System;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class Calander : Form
    {
        public Statistics StatisticsForm { get; set; }


        public UCLabelFilterOriginal UCCustomDate;
        public DateTime DesiredDate;
        public int VarYear;
        public  UCCalanderMonth uccalandermonth { get; set; }
        public UCCalanderYear uccalanderyear { get; set; }
      

        public Calander(UCLabelFilterOriginal ucCustomeDate,DateTime desiredDate)
        {
            InitializeComponent();
            UCCustomDate = ucCustomeDate;

              DesiredDate = desiredDate;
            VarYear = DesiredDate.Year;

            uccalandermonth = new UCCalanderMonth(this);
            uccalanderyear = new UCCalanderYear(this);
            uccalandermonth.Dock = DockStyle.Fill;
            uccalanderyear.Dock = DockStyle.Fill;

            panel1.Controls.Add(uccalandermonth);
            panel1.Controls.Add(uccalanderyear);

            uccalandermonth.Show();
            uccalanderyear.Hide();

            this.Opacity = 0;
            this.TopMost = true;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }


        private void Calander_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }

        private void Calander_Deactivate(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
                this.Select();
            }
            Opacity += .1;
        }
    }
}
