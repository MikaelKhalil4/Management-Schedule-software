using GlobalFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
        public EnumType type { get; set; }

        public enum EnumType
        {
            ConfirmationMode,//Green
            CanceledMode,//orange color
            UndoMode,
            DeletedMode//red color
        }
        private NotificationBanner(string Text, EnumType type, Form parentFormHome)
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
            this.Width = Convert.ToInt16(LabelDesiredWeight) + pictureBox.Width + ButtonUndo.Width + 12;

            Image DesiredIcon = null;
            if (type == EnumType.ConfirmationMode)
            {
                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "checkCircle.png");
                this.TLPglobal.BackColor = Color.FromArgb(2, 162, 111);//green
            }
            else if (type == EnumType.UndoMode)
            {
                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "checkCircle.png");
                this.TLPglobal.BackColor = Color.FromArgb(2, 162, 111);//green
            }
            else if (type == EnumType.CanceledMode)
            {
                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "xCircle.png");
                this.TLPglobal.BackColor = Color.FromArgb(244, 86, 7);//orange
            }
            else if (type == EnumType.DeletedMode)
            {
                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "xCircle.png");
                this.TLPglobal.BackColor = Color.Red;
            }
            ButtonUndo.BackAndMouseHoverColor = this.TLPglobal.BackColor;
            pictureBox.BackgroundImage = DesiredIcon;

            //LOCATION

            Point locationRelativeToScreen = ParentFormHome.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(ParentFormHome.Width / 2 - (this.Width / 2), 8);
            this.Location = locationRelativeToScreen;

            //Event
            TLPglobal.MouseLeave += TLPglobal_MouseLeave; ;
            TLPglobal.MouseMove += TLPglobal_MouseMove; ;
            foreach (Control control in TLPglobal.Controls)
            {
                control.MouseMove += TLPglobal_MouseMove;
                control.MouseLeave += TLPglobal_MouseLeave;
            }

        }
        private void TLPglobal_MouseMove(object sender, MouseEventArgs e)
        {
            if (Opacity == 1)
            {
                timer2.Stop();
                timer1.Stop();
            }
        }
        private void TLPglobal_MouseLeave(object sender, EventArgs e)
        {
            timer2.Start();
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
                cmb = null;
            }
            FirstCyclePassed = true;
        }

        public event EventHandler UndoNotficationBanner;
        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();

            if (cmb != null)
            {
                cmb = null;
            }

            UndoNotficationBanner?.Invoke(sender, e);//ejare tahet hawde
        }



        static NotificationBanner cmb;
        public static NotificationBanner Show(string message, EnumType type, Form parentFormHome)
        {
            if (cmb != null)
            {
                cmb.Close();
                cmb.Dispose();
                cmb = null;
            }
            cmb = new NotificationBanner(message, type, parentFormHome);
            cmb.Show();
            return cmb;
        }

        private void NotificationBanner_Deactivate(object sender, EventArgs e)
        {
            labelText.Select();//kermel ma el button ybayyin eendo borders
        }
    }
}
