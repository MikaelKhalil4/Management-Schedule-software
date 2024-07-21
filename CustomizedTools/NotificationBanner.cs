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
        public string Text { get; set; }
        public EnumType type { get; set; }
        bool UndoFromNotficationBannerClicked { get; set; }
        bool WithOrWithoutButtonDone { get; set; }


        Color GreenColor = Color.FromArgb(2, 162, 111);//green
        Color OrangeColor = Color.FromArgb(244, 86, 7);//orange

        public enum EnumType
        {
            ConfirmationMode,//Green
            CanceledMode,//orange color
            UndoMode,//metel lamma ekbus undii cancelation or undo comletion
            DeletedMode,//red color
            InformativeMode

        }
        private NotificationBanner(string text, EnumType type, bool withOrWithoutButtonDone, Form parentFormHome, bool undoFromNotficationBannerModeOn, bool IsUnlimtedTime)
        {
            InitializeComponent();
            if (IsUnlimtedTime)
            {
                timerAppearanceDuation.Interval = 500000;//which is 1000 seconds , don t why , glitch
            }
            else
            {
                timerAppearanceDuation.Interval = 5000;//which is 10 secods , don t why , glitch

            }
            this.Opacity = 0;


            this.TopMost = true;
            UndoFromNotficationBannerClicked = undoFromNotficationBannerModeOn;
            WithOrWithoutButtonDone = withOrWithoutButtonDone;
            this.type = type;
            Text = text;
            ParentFormHome = parentFormHome;
            ParentFormHome.Resize += ParentFormHome_Resize;
            ParentFormHome.LocationChanged += ParentFormHome_LocationChanged;
            ParentFormHome.Deactivate += ParentFormHome_Deactivate;
            LoadForm();
        }

      
        private void ParentFormHome_Deactivate(object sender, EventArgs e)
        {
            NotificationBanner.CloseTheNotfBanner();
        }

        private void ParentFormHome_LocationChanged(object sender, EventArgs e)
        {
            SetLocation();
        }

        private void ParentFormHome_Resize(object sender, EventArgs e)
        {
            SetLocation();
        }

        void SetDeignWithoutUndoButton()
        {
            ButtonUndo.Dispose();
            TLPglobal.ColumnStyles[2].Width = 0;

        }
        void LoadForm()
        {
            int ButtonUndoWidth;


            if (UndoFromNotficationBannerClicked)
            {
                SetDeignWithoutUndoButton();
                ButtonUndoWidth = 40;//since the text is so small
                Text = "Undone";
            }
            else
            {
                if (WithOrWithoutButtonDone)
                {
                    ButtonUndoWidth = ButtonUndo.Width;
                }
                else
                {
                    SetDeignWithoutUndoButton();
                    ButtonUndoWidth = 0;
                }
            }



            labelText.Text = Text;
            this.Width = Convert.ToInt16(RandomFunctions.MeasureLabelText(labelText)) + pictureBox.Width + ButtonUndoWidth + 17;

            Image DesiredIcon = null;
            if (!UndoFromNotficationBannerClicked)
            {
                if (type == EnumType.ConfirmationMode)
                {
                    DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "checkCircle.png");
                    this.TLPglobal.BackColor = GreenColor;
                }
                else if (type == EnumType.UndoMode)
                {
                    DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "checkCircle.png");
                    this.TLPglobal.BackColor = GreenColor;
                }
                else if (type == EnumType.CanceledMode)
                {
                    DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "xCircle.png");
                    this.TLPglobal.BackColor = OrangeColor;
                }
                else if (type == EnumType.DeletedMode)
                {
                    DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "xCircle.png");
                    this.TLPglobal.BackColor = Color.Red;
                }
                else if (type == EnumType.InformativeMode)
                {
                    DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "info.png");
                    this.TLPglobal.BackColor = Color.FromArgb(109, 122, 224);
                }
            }
            else
            {
                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "checkCircle.png");
                this.TLPglobal.BackColor = GreenColor;
            }

            ButtonUndo.BackAndMouseHoverColor = this.TLPglobal.BackColor;
            pictureBox.BackgroundImage = DesiredIcon;


            SetLocation();
            //Event
            TLPglobal.MouseLeave += TLPglobal_MouseLeave; ;
            TLPglobal.MouseMove += TLPglobal_MouseMove; ;
            foreach (Control control in TLPglobal.Controls)
            {
                control.MouseMove += TLPglobal_MouseMove;
                control.MouseLeave += TLPglobal_MouseLeave;
            }

        }
        public void SetLocation()
        {
            //LOCATION
            int Delta;
            if (ParentFormHome.ControlBox)
            {
                Delta = 40;
            }
            else
            {
                Delta = 20;
            }


            Point locationRelativeToScreen = ParentFormHome.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(ParentFormHome.Width / 2 - (this.Width / 2), ParentFormHome.Height - this.Height - Delta);
            this.Location = locationRelativeToScreen;
        }
        private void TLPglobal_MouseMove(object sender, MouseEventArgs e)
        {
            if (Opacity == 1)
            {
                timerAppearanceDuation.Stop();
                timerLocation.Stop();
            }
        }
        private void TLPglobal_MouseLeave(object sender, EventArgs e)
        {
            timerAppearanceDuation.Start();
        }




        private void timer1_Tick_1(object sender, EventArgs e)
        {

            if (Opacity == 1)
            {
                timerLocation.Stop();
                timerAppearanceDuation.Start();
            }
            Opacity += .2;
            this.Location = new Point(this.Location.X, this.Location.Y - 2);
        }

        bool FirstCyclePassed = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (FirstCyclePassed)
            {
                timerAppearanceDuation.Stop();
                this.Close();
                this.Dispose();
                //mamnuu thot null hone elak
            }
            FirstCyclePassed = true;
        }

        public event EventHandler UndoNotficationBanner;
        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();

            if (CurrentNotfBanner != null)
            {
                CurrentNotfBanner = null;
            }

            UndoNotficationBanner?.Invoke(sender, e);//ejare tahet hawde
        }



        public static NotificationBanner CurrentNotfBanner;
        public static NotificationBanner Show(string message, EnumType type, bool WithOrWithoutButtonDone, Form parentFormHome, bool UndoFromNotficationBannerCliked, bool IsUnlimtedTime)
        {
            //closing the old one
            CloseTheNotfBanner();

            //starting the new one
            CurrentNotfBanner = new NotificationBanner(message, type, WithOrWithoutButtonDone, parentFormHome, UndoFromNotficationBannerCliked, IsUnlimtedTime);
            CurrentNotfBanner.Show();
            CurrentNotfBanner.timerLocation.Start();

            return CurrentNotfBanner;
        }
        public static void CloseTheNotfBanner()
        {
            if (CurrentNotfBanner != null)
            {
                CurrentNotfBanner.Close();
                CurrentNotfBanner.Dispose();
                CurrentNotfBanner = null;
            }
        }


        private void NotificationBanner_Deactivate(object sender, EventArgs e)
        {
            labelText.Select();//kermel ma el button ybayyin eendo borders
        }
    }
}
