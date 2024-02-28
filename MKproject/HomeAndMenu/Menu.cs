using MKproject.Management;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject
{
    public partial class Menu : Form
    {
        public Home ParentFormHome { get; set; }
        public int InitialWidth { get; set; }
        public Form ActivatedForm;
        public Form SousActivatedForm;
        private Button currentButton;


        Color ColorActivatedButton = Color.FromArgb(89, 102, 204);
        Color ColorUnActivatedButton = Color.Transparent;
        public Menu()
        {
            InitializeComponent();
            InitialWidth = 250;


            foreach (Control co in FLPGlobal.Controls)
            {
                co.Width = FLPGlobal.Width;
            }

            LoadForm();
        }

        public void LoadForm()
        {

            FLPGlobal.Select();
            buttonMenu.Text = "Hello " + LOGIN.Employee.Fname + "!";


            //el order tabaaun bi assir aa their indexing
            if (LOGIN.Employee.CanAccessTransaction)
                buttonTransaction.Visible = true;
            else buttonTransaction.Visible = false;


            if (LOGIN.Employee.CanAccessStatistics)
                buttonStatistics.Visible = true;
            else buttonStatistics.Visible = false;

            if (LOGIN.Employee.CanAccessBackOffice)
            {
                buttonEmployee.Visible = true;
                buttonBundlesAndProducts.Visible = true;
            }
            else
            {
                buttonEmployee.Visible = false;
                buttonBundlesAndProducts.Visible = false;
            }
        }

 
        private void ActivateButton(Button desiredbtn)
        {
            if (desiredbtn != currentButton)
            {
                desiredbtn.BackColor = ColorActivatedButton;
                if (currentButton != null)
                {
                    currentButton.BackColor = ColorUnActivatedButton;
                }
                currentButton = desiredbtn;
            }
        }
        public void OpenChildForm(Form DesiredFormToOpen, Button desiredbtn, bool IsToProfile)
        {
            if (ParentFormHome.panelContainer.Controls.Count > 0)//specially made kermel el back ma nekhsar el data bel form li fetna menna
            {
                ParentFormHome.panelContainer.Controls[0].Visible = false;//we re sure only one control 
                ParentFormHome.panelContainer.Controls.Clear();
            }
            ParentFormHome.buttonBackHome.Visible = false;



            if (!IsToProfile)//so we can return to it on back click
            {
                if (ActivatedForm != DesiredFormToOpen)//kermel eza aam naamil back ma ysir fi error bel show tahet,w ha bet fout fiya lamma ma nkun rejiin men el back home,lieanno el activated form ha tkun hiyye li el search li banda yeha w ma badna nsakkera 
                {
                    if (ActivatedForm != null)
                        ActivatedForm.Close();

                    ActivatedForm = DesiredFormToOpen;
                    ActivateButton(desiredbtn);

                }
            }
            else
            {
                SousActivatedForm = DesiredFormToOpen;
            }

            DesiredFormToOpen.TopLevel = false;
            DesiredFormToOpen.FormBorderStyle = FormBorderStyle.None;
            DesiredFormToOpen.Dock = DockStyle.Fill;
            DesiredFormToOpen.Tag = ParentFormHome;
            ParentFormHome.panelContainer.Controls.Add(DesiredFormToOpen);
            DesiredFormToOpen.Show();

        }



        private void buttonSearchClient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SearchCurrentClient(), buttonSearchClient, false);
            HideMenu();

        }
        private void buttonTransaction_Click(object sender, EventArgs e)
        {
            SousActivatedForm = null;
            OpenChildForm(new BackOffice(null, null, null, null), buttonTransaction, false);
            HideMenu();
        }
        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            SousActivatedForm = null;
            OpenChildForm(new Statistics(), buttonStatistics, false);
            HideMenu();

        }
        private void buttonBundlesAndProducts_Click(object sender, EventArgs e)
        {
            SousActivatedForm = null;
            OpenChildForm(new ViewBundlesAndProducts(), buttonBundlesAndProducts, false);
            HideMenu();

        }
        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            SousActivatedForm = null;
            OpenChildForm(new ViewEmployee(), buttonEmployee, false);
            HideMenu();

        }
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (ParentFormHome.panelContainer.Controls.Count > 0)
            {
                ParentFormHome.panelContainer.Controls.Clear();//kermel lamma naamil dispose w fethin aal form eemlina caching metel el progile ma nekhsara bel dispose
            }
            ParentFormHome.Dispose();
            this.Dispose();
            Program.LoginForm.LoadForm();
            Program.LoginForm.Show();

        }




        void HideMenu()
        {
            if (!timerMenuOpen.Enabled)
            {
                timerMenuClose.Start();

                if (Program.GreyForm != null)
                {
                    Program.GreyForm.Close();
                    Program.GreyForm = null;
                }
            }
        }
        private void Menu_Deactivate(object sender, EventArgs e)
        {
            HideMenu();
        }
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            HideMenu();
        }
        private void timerMenuOpen_Tick(object sender, EventArgs e)
        {
            this.Select();
            if (this.Width >= this.InitialWidth)
            {
                timerMenuOpen.Stop();
                this.Width = this.InitialWidth;
            }
            else
            {
                this.Width += 50;
            }
        }
        private void timerMenuClose_Tick(object sender, EventArgs e)
        {
            if (this.Width <= 2)//lieanno ma aam tenzal lal 0 , since fiya content
            {
                timerMenuClose.Stop();
                this.Width = 2;
                this.Visible = false;
            }
            else
            {
                this.Width -= 50;
            }
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

    }
}
