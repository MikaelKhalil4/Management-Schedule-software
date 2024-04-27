using GlobalFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace CustomizedTools
{
    public partial class NotificationBanner : Form
    {
        public Form ParentFormHome { get; set; }
        public string text { get; set; }
        public Type type { get; set; }

        public enum Type
        {
            ConfirmationMode,//Green
            CanceledMode,//orange color
            UndoMode,
            DeletedMode//red color
        }
        private NotificationBanner(string Text, Type type, Form parentFormHome)
        {
            InitializeComponent();
            this.Opacity = 0;
            this.TopMost = true;
            this.type = type;
            text = Text;
            ParentFormHome = parentFormHome;
            LoadForm();

        }

        void LoadForm()
        {

            labelText.Text = text;
            float LabelDesiredWeight = RandomFunctions.MeasureLabelText(labelText);
            this.Width = Convert.ToInt16(LabelDesiredWeight) + 70;

            Image DesiredIcon = null;
            if (type == Type.ConfirmationMode)
            {
                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "checkCircle.png");
                this.TLPGlobal.BackColor = Color.FromArgb(2, 162, 111);//green
            }
            else if (type == Type.UndoMode)
            {
                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "checkCircle.png");
                this.TLPGlobal.BackColor = Color.FromArgb(2, 162, 111);//green
            }
            else if (type == Type.CanceledMode)
            {
                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "xCircle.png");
                this.TLPGlobal.BackColor = Color.FromArgb(244, 86, 7);//orange
            }
            else if (type == Type.DeletedMode)
            {
                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "xCircle.png");
                this.TLPGlobal.BackColor = Color.Red;
            }

            pictureBox.BackgroundImage = DesiredIcon;

            //LOCATION

            Point locationRelativeToScreen = ParentFormHome.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(ParentFormHome.Width / 2-(this.Width/2), 8);
            this.Location = locationRelativeToScreen;

        }

        public static void Show(string message, Type type, Form parentFormHome)
        {
            NotificationBanner cmb = new NotificationBanner(message, type, parentFormHome);
            cmb.Show();

        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
                timer2.Start();
            }
            Opacity += .2;
            this.Location = new Point(this.Location.X, this.Location.Y + 4);
        }

        bool FirstCyclePassed = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (FirstCyclePassed)
            {
                timer2.Stop();
                this.Close();
                this.Dispose();
            }
            FirstCyclePassed = true;
        }

     


        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}

    }
}
