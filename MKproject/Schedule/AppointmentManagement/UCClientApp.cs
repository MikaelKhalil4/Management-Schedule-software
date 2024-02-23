using CustomizedTools;
using GlobalFunctions;
using MKproject.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class UCClientApp : UserControl
    {

        Label LabelServiceOutput;
        Label LabelService;
        Label LabelNoDataRecorded;
        IconButton IconProfile;
        PictureBox pictureBoxSearch;
        CustomButton ButtonChangeORChooseService;



        ClassClient DesiredClient;
        public UCClientApp()
        {
            InitializeComponent();
            DesiredClient = new ClassClient();    
            SetDesignMode();
        }
        public UCClientApp(ClassClient desiredClient)//used in appointment form

        {
            InitializeComponent();
            DesiredClient = desiredClient;
            DesiredClient = new ClassClient();//to be removed          
            SetDesignMode();
        }

        void SetDesignMode()
        {
            if (DesiredClient.ClientId != null)
            {
                //kermel l LabelNoDataRecorded
                if (TLPglobal.Controls.Contains(LabelNoDataRecorded))
                {
                    pictureBoxSearch.Dispose();
                    LabelNoDataRecorded.Dispose();
                    LabelNoDataRecorded = null;
                    pictureBoxSearch = null;                      
                }
                if (!TLPglobal.Controls.Contains(IconProfile))
                {
                    CreatingTheClientModeOn();
                    TLPglobal.Controls.Add(IconProfile, 0, 0);
                    TLPglobal.Controls.Add(ButtonChangeORChooseService, 2, 1);
                    TLPglobal.Controls.Add(LabelServiceOutput, 0, 1);
                    TLPglobal.Controls.Add(LabelService, 1, 1);;
                }

                //LabelFullName.Text = DesiredClient.FullName;
                LabelService.Text = "Confidence: 12 sess/-$10";

            }
            else
            {
                if (TLPglobal.Controls.Contains(IconProfile))
                {
                    TLPglobal.Controls.Remove(IconProfile);
                    TLPglobal.Controls.Remove(ButtonChangeORChooseService);
                    TLPglobal.Controls.Remove(LabelServiceOutput);
                    TLPglobal.Controls.Remove(LabelService);
                }
                if (LabelNoDataRecorded == null)
                {

                    CreatingTheClientModeOff();
                    TLPglobal.Controls.Add(pictureBoxSearch, 0, 0);

                    TLPglobal.Controls.Add(LabelNoDataRecorded, 0, 1);
                    TLPglobal.SetRowSpan(LabelNoDataRecorded, 2);
                    TLPglobal.SetColumnSpan(LabelNoDataRecorded, 5);
                }


            }

        }


        void CreatingTheClientModeOn()
        {          
            ToolTip toolTip1 = new ToolTip();
            toolTip1.InitialDelay = 500;
            toolTip1.AutoPopDelay = 5000;          
            toolTip1.ShowAlways = true;
          


            IconProfile = new IconButton();
            IconProfile.Size = new Size(30, 28);
            IconProfile.Margin = new Padding(0);
            IconProfile.Anchor = AnchorStyles.None;
            IconProfile.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "userNude.png");
            IconProfile.BackgroundImageLayout = ImageLayout.Zoom;       
            IconProfile.Click += IconProfile_Click; ;
            toolTip1.SetToolTip(IconProfile, "Client Profile");


            ButtonChangeORChooseService = new CustomButton();
            ButtonChangeORChooseService.Text = "Change";
            ButtonChangeORChooseService.Size = new Size(92, 29);
            ButtonChangeORChooseService.BackAndMouseHoverColor = Program.BoldColor;
            ButtonChangeORChooseService.Font = new Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ButtonChangeORChooseService.Click += ButtonChangeORChooseService_Click;
            ButtonChangeORChooseService.Anchor = AnchorStyles.None;


            LabelServiceOutput = new Label();
            LabelServiceOutput.Text = "Service:";
            LabelServiceOutput.Font = new Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            LabelServiceOutput.AutoSize = true;
            LabelServiceOutput.Margin = new Padding(0);
            LabelServiceOutput.Anchor = AnchorStyles.None;

            LabelService = new Label();
            LabelService.Text = "Confidence: 12 sess/-$10";
            LabelService.Font = new Font("Segoe UI", 12, FontStyle.Bold);        
            LabelService.AutoSize = true;
            LabelService.Margin = new Padding(0);
            LabelService.Anchor = AnchorStyles.Left;
         
        }

     
        private void ButtonChangeORChooseService_Click(object sender, EventArgs e)
        {

        }

        private void IconProfile_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DesiredClient = ClassClient.CreateClientObject((int)DesiredClient.ClientId);
          
            if (Program.clientManagementProfile == null)
            {
                Program.clientManagementProfile = new ClientManagementProfile(DesiredClient, true);
            }
            else
            {
                Program.clientManagementProfile.LoadData(DesiredClient, true);
                Program.clientManagementProfile.FormatDatagridviewDesign();// ma aam tozbat men wara el show dialog, bas eemlna glitch bel event visible chnaged on the form
            }
            Program.clientManagementProfile.Size = new Size(1000, 659);          
            Program.clientManagementProfile.FormBorderStyle= FormBorderStyle.Sizable;
            Program.clientManagementProfile.Tag = Program.clientManagementProfile;
            Program.clientManagementProfile.FormClosing += ClientManagementProfile_FormClosing;
            Program.clientManagementProfile.ShowDialog();          
            Cursor = Cursors.Default;

        }
     

        private void ClientManagementProfile_FormClosing(object sender, FormClosingEventArgs e)
        {            
            e.Cancel = true;
            Program.clientManagementProfile.Hide();
            Program.clientManagementProfile.FormClosing -= ClientManagementProfile_FormClosing;
            UpdateValues();
        }

        void UpdateValues()
        {
            if (DesiredClient.ClientId != null)
            {
                textBoxSearch.Text = DesiredClient.Fname + " " + DesiredClient.Lname;
            }
            else
            {
                textBoxSearch.Text = textBoxSearch.PlaceholderText;
            }
        }

        void CreatingTheClientModeOff()
        {
            LabelNoDataRecorded = new Label();
            LabelNoDataRecorded.Text = "No client chosen yet";
            LabelNoDataRecorded.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            LabelNoDataRecorded.ForeColor = Color.FromArgb(150, 150, 150);
            LabelNoDataRecorded.BackColor = Color.FromArgb(150, Color.WhiteSmoke.R, Color.WhiteSmoke.G, Color.WhiteSmoke.B); // 128 is the alpha value
            LabelNoDataRecorded.TextAlign = ContentAlignment.MiddleCenter;
            LabelNoDataRecorded.AutoSize = false;
            LabelNoDataRecorded.Dock = DockStyle.Fill;
            LabelNoDataRecorded.Margin = new Padding(5,0,5,0);


            pictureBoxSearch = new PictureBox();
            pictureBoxSearch.Size = new Size(25, 25);
            pictureBoxSearch.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "search2.png");
            pictureBoxSearch.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxSearch.Anchor = AnchorStyles.Right;
        }
        private void textBoxSearch_Click(object sender, EventArgs e)
        {

            Search searchname = new Search(textBoxSearch, DesiredClient);
            searchname.Deactivate += Searchname_Deactivate; ;
            Point locationRelativeToScreen = textBoxSearch.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-2, -2);
            searchname.Location = locationRelativeToScreen;
            searchname.Show();

        }

        private void Searchname_Deactivate(object sender, EventArgs e)
        {
            label1.Select();
            UpdateValues();
            SetDesignMode();
        }

        private void TLPAddNewClient_MouseMove(object sender, MouseEventArgs e)
        {
            TLPAddNewClient.BackColor = Color.FromArgb(Program.BoldColor.R + 20, Program.BoldColor.G + 20, Program.BoldColor.B + 20);
        }
        private void TLPAddNewClient_MouseLeave(object sender, EventArgs e)
        {
            TLPAddNewClient.BackColor = Program.BoldColor;
        }

        private void TLPAddNewClient_Click(object sender, EventArgs e)
        {
            if (Program.NewRegisterForm == null)
            {
                Program.NewRegisterForm = new NewRegister(null, DesiredClient);
            }
            else
            {
                Program.NewRegisterForm.Resetcontrols();
                Program.NewRegisterForm.LoadForm(null, DesiredClient);
            }
            Program.NewRegisterForm.FormClosed += NewRegisterForm_FormClosed;
            Program.NewRegisterForm.ShowDialog();
        }

        private void NewRegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {          
            UpdateValues();
            SetDesignMode();
            Program.NewRegisterForm.FormClosed -= NewRegisterForm_FormClosed;
        }
    }
}
