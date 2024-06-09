using CustomizedTools;
using GlobalFunctions;
using MKproject.Management;
using MKproject.Schedule;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MKproject
{
    public partial class Home : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        public Menu menu;

        Image MaximizeImage;
        Image RestoreDownImage;

        public Home()
        {
            InitializeComponent();
            LoadImages();
            menu = new Menu();
            menu.ParentFormHome = this;
            menu.OpenChildForm(new ScheduleForm(), menu.buttonSchedule, false);
            buttonMaximize.Select();
        }
        void LoadImages()
        {
            MaximizeImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "maximizee.png");
            RestoreDownImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "restore-down.png");
        }


        public void buttonBackHome_Click(object sender, EventArgs e)
        {
            if (menu.SousActivatedForm is ClientManagementProfile && menu.ActivatedForm is SearchCurrentClient)//ejbare hone mahalla , lieanno eenda  kaza form aam taayit la hal function
            {
                ClientManagementProfile clientManagementProfile = (ClientManagementProfile)menu.SousActivatedForm;
                SearchCurrentClient searchCurrentClient= (SearchCurrentClient)menu.ActivatedForm;
                if (Program.IsANewParentAddedOrParentPhoneUpdated)
                {
                    searchCurrentClient.RefreshSQL();
                    Program.IsANewParentAddedOrParentPhoneUpdated = false;
                }
                else
                {
                    clientManagementProfile.TransferInformationToSearch();
                }
                
                menu.OpenChildForm(searchCurrentClient, menu.buttonSearchClient, false);
                buttonBackHome.Visible = false;
            }
            else if (menu.SousActivatedForm is ClientManagementProfile && menu.ActivatedForm is ScheduleForm)
            {
                ScheduleForm scheduleForm = (ScheduleForm)menu.ActivatedForm;
                menu.OpenChildForm(scheduleForm, menu.buttonSchedule, false);
                buttonBackHome.Visible = false;
            }
        }




        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {

                this.WindowState = FormWindowState.Maximized;
                ((Button)sender).BackgroundImage = RestoreDownImage;

            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                ((Button)sender).BackgroundImage = MaximizeImage;

            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {

            Program.GreyForm = new GreyColor(this, true, false,null);
            Program.GreyForm.Show();
            menu.Visible = true;
            Point locationRelativeToScreen = TLPHome.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(0, 0);
            menu.Location = locationRelativeToScreen;
            menu.Show();
            menu.Height = TLPHome.Height;
            menu.MinimumSize = new Size(0, 0);
            menu.Width = 2;//lieanno ma aam tenzal lal 0 , since fiya contnent
            menu.timerMenuOpen.Start();

        }

    }
}
