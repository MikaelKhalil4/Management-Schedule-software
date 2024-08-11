using CustomizedTools;
using MKproject.Management;
using MKproject.Schedule;
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
            buttonMenu.Text = "Hello " + Program.Employee.Fname + "!";


            //el order tabaaun bi assir aa their indexing
            if (Program.Employee.CanAccessTransaction)
                buttonTransaction.Visible = true;
            else buttonTransaction.Visible = false;


            if (Program.Employee.CanAccessStatistics)
                buttonStatistics.Visible = true;
            else buttonStatistics.Visible = false;


            if (Program.Employee.CanAccesSchedule)
                buttonSchedule.Visible = true;
            else buttonSchedule.Visible = false;



            if (Program.Employee.CanAccessSevicesProductsEmployees)
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

        public event EventHandler GoingFromSousChildToChild;
        public event EventHandler GoingFromChildToChild;
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
        public void OpenChildForm(Form DesiredFormToOpen, Button desiredbtn, bool IsOpeningASousChild)
        {
            if (ParentFormHome.panelContainer.Controls.Count > 0)//specially made kermel el back ma nekhsar el data bel form li fetna menna
            {
                Form OpenendForm = ((Form)ParentFormHome.panelContainer.Controls[0]);
                ParentFormHome.panelContainer.Controls[0].Visible = false;//we re sure only one control 
                ParentFormHome.panelContainer.Controls.RemoveAt(0);
                OpenendForm.TopLevel = true;
            }
            ParentFormHome.buttonBackHome.Visible = false;//ejbare, in case tloona men el form, men el menu, mesh men el backhome btn


            bool IsFromSousChildToChild = false;
            if (!IsOpeningASousChild)//so we can return to it on back click
            {
                if (ActivatedForm != DesiredFormToOpen)//kermel eza aam naamil back,ma men fout bel condition kermel ma ysir fi error bel show tahet, bcz: DesiredFormToOpen and ActivatedForm will refer to the same form
                {
                    if (ActivatedForm != null)
                    {
                        if (!(ActivatedForm is ScheduleForm))//since it s cashed
                        {
                            ActivatedForm.Close();
                        }

                    }

                    ActivatedForm = DesiredFormToOpen;
                    ActivateButton(desiredbtn);
                }
                else
                {
                    IsFromSousChildToChild = true;
                }
            }
            else//in case we re going lal client profile, el Activated Form bte2a el search w el sous activated hiyye el profile ha tkun
            {
                SousActivatedForm = DesiredFormToOpen;
            }

            DesiredFormToOpen.Size = ParentFormHome.panelContainer.Size;
            DesiredFormToOpen.TopLevel = false;
            DesiredFormToOpen.FormBorderStyle = FormBorderStyle.None;
            DesiredFormToOpen.Dock = DockStyle.Fill;
            ParentFormHome.panelContainer.Controls.Add(DesiredFormToOpen);
            DesiredFormToOpen.Show();
            DesiredFormToOpen.Focus();//ejbariye kermel el datatgridview el toooltip teb2a meshye
            if (IsFromSousChildToChild)
            {
                GoingFromSousChildToChild?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                GoingFromChildToChild?.Invoke(this, EventArgs.Empty);
            }


            //for user exprience
            CloseNotfBanner();

        }
        public void CloseNotfBanner()
        {
            if (CustomizedTools.NotificationBanner.CurrentNotfBanner != null)
            {
                CustomizedTools.NotificationBanner.CloseTheNotfBanner();
            }
        }


        private void buttonSearchClient_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            OpenChildForm(new SearchCurrentClient(), buttonSearchClient, false);
            HideMenu();
            Cursor = Cursors.Default;
        }
        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SousActivatedForm = null;
            HideMenu();
            if (Program.ScheduleFormGlobal == null)
            {
                Program.ScheduleFormGlobal = new ScheduleForm();
            }
            else
            {
                Program.ScheduleFormGlobal.LoadScheduleForm();
            }
            OpenChildForm(Program.ScheduleFormGlobal, buttonSchedule, false);
            Cursor = Cursors.Default;
        }
        private void buttonTransaction_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SousActivatedForm = null;
            OpenChildForm(new BackOffice(null, null, null, null), buttonTransaction, false);
            HideMenu();
            Cursor = Cursors.Default;
        }
        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SousActivatedForm = null;
            OpenChildForm(new Statistics(), buttonStatistics, false);
            HideMenu();
            Cursor = Cursors.Default;
        }
        private void buttonBundlesAndProducts_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SousActivatedForm = null;
            OpenChildForm(new ViewBundlesAndProducts(), buttonBundlesAndProducts, false);
            HideMenu();
            Cursor = Cursors.Default;
        }
        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SousActivatedForm = null;
            OpenChildForm(new ViewEmployee(), buttonEmployee, false);
            HideMenu();
            Cursor = Cursors.Default;
        }
        private void buttonBackUp_Click(object sender, EventArgs e)
        {
            HideMenu();
            Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
            Program.GreyForm.Show();
            PlanAndBackUp backup = new PlanAndBackUp();
            backup.Show();
            //for user exprience
            CloseNotfBanner();
        }
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (ParentFormHome.panelContainer.Controls.Count > 0)
            {
                ParentFormHome.panelContainer.Controls.Clear();//kermel lamma naamil dispose w fethin aal form eemlina caching metel el progile ma nekhsara bel dispose
            }
            ParentFormHome.Dispose();
            this.Dispose();
            if (Program.LoginForm != null)
            {
                Program.LoginForm.LoadForm();
                Program.LoginForm.Show();
            }
         else
            {
                Program.LoginForm = new LOGIN();
                Program.LoginForm.Show();
            }

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
