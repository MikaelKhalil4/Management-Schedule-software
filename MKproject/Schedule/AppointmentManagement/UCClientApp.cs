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
    public partial class UCClientApp : Form
    {

        Label LabelNoDataRecorded;
        ClassClient DesiredClient;
        public UCClientApp()
        {
            InitializeComponent();
            DesiredClient = new ClassClient();
            //SetDesignMode();           
        }
        public UCClientApp(ClassClient desiredClient)//used in appointment form

        {
            InitializeComponent();        
            DesiredClient =desiredClient;
            DesiredClient = new ClassClient();//to be removed
            SetDesignMode();
        }

        void SetDesignMode()
        {
            if (DesiredClient.ClientId!=null)
            {
                //kermel l LabelNoDataRecorded
                if (TLPglobal.Controls.Contains(LabelNoDataRecorded))
                {
                    LabelNoDataRecorded.Dispose();
                    LabelNoDataRecorded = null;
                    TLPglobal.Controls.Remove(LabelNoDataRecorded);
                }
                CreatingTheClientModeOn();
            }
            else
            {
                if (LabelNoDataRecorded == null)
                {                              

                    CreatingTheNoDataLabel();
                    TLPglobal.Controls.Add(LabelNoDataRecorded, 0, 1);
                    TLPglobal.SetRowSpan(LabelNoDataRecorded, 2);
                    TLPglobal.SetColumnSpan(LabelNoDataRecorded, 4);


                }

            }
           
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
            textBoxSearch.Text = textBoxSearch.PlaceholderText;
            SetDesignMode();
        }

        private void TLPAddNewClient_MouseMove(object sender, MouseEventArgs e)
        {
            TLPAddNewClient.BackColor = Program.BoldColorHover;
        }
        private void TLPAddNewClient_MouseLeave(object sender, EventArgs e)
        {
            TLPAddNewClient.BackColor = Program.BoldColor;
        }

        IconButton IconProfile;
        Button ButtonChangeORChooseService;
        void CreatingTheClientModeOn()
        {
            IconProfile = new IconButton();
            IconProfile.Size = new Size(122, 34);
            IconProfile.Margin = new Padding(5);
            IconProfile.BackColor = Color.FromArgb(109, 122, 224);
            IconProfile.ForeColor = Color.White;
            IconProfile.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            IconProfile.Anchor = AnchorStyles.None;
            IconProfile.FlatStyle = FlatStyle.Flat;
            IconProfile.Cursor = Cursors.Hand;
            IconProfile.BackgroundImage=ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory,"images", "userNude.png");
            IconProfile.Click += IconProfile_Click; ;

            ButtonChangeORChooseService = new Button();
            ButtonChangeORChooseService.Size = new Size(122, 34);
            ButtonChangeORChooseService.Margin = new Padding(5);
            ButtonChangeORChooseService.BackColor = Color.FromArgb(109, 122, 224);
            ButtonChangeORChooseService.ForeColor = Color.White;
            ButtonChangeORChooseService.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            ButtonChangeORChooseService.Anchor = AnchorStyles.None;
            ButtonChangeORChooseService.FlatStyle = FlatStyle.Flat;
            ButtonChangeORChooseService.Cursor = Cursors.Hand;
            ButtonChangeORChooseService.Click += ButtonChangeORChooseService_Click; ;
        }

        private void ButtonChangeORChooseService_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void IconProfile_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void CreatingTheNoDataLabel()
        {
            LabelNoDataRecorded = new Label();
            // Set the label properties
            LabelNoDataRecorded.Text = "No client chosen yet";
            LabelNoDataRecorded.Font = new System.Drawing.Font("Segoe UI", 12, FontStyle.Italic);
            LabelNoDataRecorded.ForeColor = Color.FromArgb(150, 150, 150);

            Color whiteSmoke = Color.WhiteSmoke;
            Color semiTransparentWhiteSmoke = Color.FromArgb(150, whiteSmoke.R, whiteSmoke.G, whiteSmoke.B); // 128 is the alpha value
            LabelNoDataRecorded.BackColor = semiTransparentWhiteSmoke;

            LabelNoDataRecorded.TextAlign = ContentAlignment.MiddleCenter;
            LabelNoDataRecorded.AutoSize = false;
            LabelNoDataRecorded.Dock = DockStyle.Fill;
            LabelNoDataRecorded.Margin = new Padding(0, 0, 0, 0);
        }

        private void TLPglobal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
