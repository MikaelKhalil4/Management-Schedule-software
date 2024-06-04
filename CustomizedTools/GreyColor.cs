using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomizedTools
{
    public partial class GreyColor : Form
    {
        private bool closed = true;//kermel l infinite loop 3l closing taba3 l form
        bool CloseSmoothly;
        bool FormBackColorIsTransparent = false;

        public GreyColor(Form parentForm, bool closeSmoothly, bool isJunior, Color? BackColor)//close smmoothly used only for el new register while delteing a client, el timer tabaa  el gray form aam bi assir enno ma needir nsakkir el management form
        {
            InitializeComponent();
            CloseSmoothly = closeSmoothly;


            // Set the overlay form properties
            this.FormBorderStyle = FormBorderStyle.None;
            if (BackColor == null)
            {
                this.BackColor = Color.Gray;
            }
            else
            {
                if (Color.Transparent == (Color)BackColor)
                {
                    FormBackColorIsTransparent = true;
                }
                else
                {
                    this.BackColor = (Color)BackColor;
                }
            }
            this.Opacity = 0;
            this.StartPosition = FormStartPosition.Manual;
            Point locationRelativeToScreen = parentForm.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(0, 0);
            this.Location = locationRelativeToScreen;
            if (!isJunior)
            {
                this.Height = parentForm.Height - 15;
                this.Width = parentForm.Width - 15;
            }
            else
            {
                this.Height = parentForm.Height - 37;
                this.Width = parentForm.Width - 15;
            }

            this.ShowInTaskbar = false;


            // Show the overlay form
            this.Show(parentForm);
            parentForm.Activate();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!FormBackColorIsTransparent)//if true opacity wil remain 0
            {
                if (timer2.Enabled == false)
                {
                    if (Opacity >= 0.5)
                    {
                        timer1.Stop();
                    }
                    Opacity += .1;
                }
            }
            else
            {
                Opacity = .01;

            }
        }

        double TransparentTime = .5;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!FormBackColorIsTransparent)
            {
                if (timer1.Enabled == false)
                {
                    if (Opacity <= 0)
                    {
                        closed = false;
                        timer2.Stop();
                        this.Close();
                    }
                    Opacity -= .1;
                }
            }
            else
            {
                if (timer1.Enabled == false)
                {
                    if (TransparentTime <= 0)
                    {
                        closed = false;
                        timer2.Stop();
                        this.Close();
                        TransparentTime = 0.5;
                    }
                    TransparentTime -= .1;
                }
            }
        }

        private void ModalOverlayForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (CloseSmoothly)
            {
                if (closed)
                {
                    e.Cancel = true;//ma bet sakkir el form
                    timer1.Stop();
                    timer2.Start();
                }
            }
        }

        private void GreyColor_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
