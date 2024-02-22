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
                if (LabelNoDataRecorded == null)
                {

                    CreatingTheNoDataLabel();
                    TLPglobal.Controls.Add(LabelNoDataRecorded, 0, 1);
                    TLPglobal.SetRowSpan(LabelNoDataRecorded, 2);
                    TLPglobal.SetColumnSpan(LabelNoDataRecorded, 5);
                }

            }

        }




        void CreatingTheClientModeOn()
        {
            IconProfile = new IconButton();
            IconProfile.Size = new Size(30, 28);
            IconProfile.Margin = new Padding(0);
            IconProfile.Anchor = AnchorStyles.None;
            IconProfile.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "userNude.png");
            IconProfile.BackgroundImageLayout = ImageLayout.Zoom;
            IconProfile.Click += IconProfile_Click; ;


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

        }

        void CreatingTheNoDataLabel()
        {
            LabelNoDataRecorded = new Label();
            LabelNoDataRecorded.Text = "No client chosen yet";
            LabelNoDataRecorded.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            LabelNoDataRecorded.ForeColor = Color.FromArgb(150, 150, 150);

            Color whiteSmoke = Color.WhiteSmoke;
            Color semiTransparentWhiteSmoke = Color.FromArgb(150, whiteSmoke.R, whiteSmoke.G, whiteSmoke.B); // 128 is the alpha value
            LabelNoDataRecorded.BackColor = semiTransparentWhiteSmoke;

            LabelNoDataRecorded.TextAlign = ContentAlignment.MiddleCenter;
            LabelNoDataRecorded.AutoSize = false;
            LabelNoDataRecorded.Dock = DockStyle.Fill;
            LabelNoDataRecorded.Margin = new Padding(5,0,5,0);
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

        private void customButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
