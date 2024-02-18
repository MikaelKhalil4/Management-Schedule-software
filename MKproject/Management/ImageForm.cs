using GlobalFunctions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class ImageForm : Form
    {
        public ImageForm(Image image)
        {
            InitializeComponent();
            if (image != null)
            {
                pictureBoxImage.Image = image;
            }
            else
            {
                pictureBoxImage.Image = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "user1.png"); ;
            }

            this.Opacity = 0;
            this.TopMost = true;
        }

        private void ImageForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .1;
        }

        private void ImageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }
    }
}
