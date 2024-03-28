using CustomizedTools;
using GlobalFunctions;
using MKproject.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Converters;
using static System.Net.Mime.MediaTypeNames;

namespace MKproject.Schedule
{
    public partial class UCClientApp : UserControl
    {
        public Appointment ParentFormAppointment { get; set; }

        public TextBoxWithPlaceHolder textBoxTitle;
        Label LabelServiceOutput;
        Label LabelService;
        Label LabelBalanceOutput;
        Label LabelBalance;
        Label LabelNoDataRecorded;
        IconButton IconProfile;
        PictureBox pictureBoxSearch;
        CustomButton ButtonChangeORChooseService;

        int OldClientId = -1;
        public ClassAppointment DesiredAppointmentUCClientApp;
        public DataTable PackageRemainingsDt;
        public DataTable OldPackageRemainingsDtDesiredClient;//will be reset to null, kell ma ngahyyir client

        bool NewClientIsAdded = false;
        public bool IsServiceOrOthersMode;
        public UCClientApp(ClassAppointment desiredAppointment)//used in appointment form
        {
            InitializeComponent();
            DesiredAppointmentUCClientApp = desiredAppointment;
            CreatingTheClientModeOn();

            if (DesiredAppointmentUCClientApp.Title == null)
            {
                //since by default bet kunaa l button service
                IsServiceOrOthersMode = true;
                if (DesiredAppointmentUCClientApp.AppointmentID == null)//adding new appointment
                {
                    SetLogicAndDesignMode(false, false);
                }
                else//update form
                {
                    SetLogicAndDesignMode(false, true);
                }

            }
            else
            {
                ucSlideButtonServicerOthers.button2_Click(null, EventArgs.Empty);//setdesign mode otherswill be called
                textBoxTitle.Text = DesiredAppointmentUCClientApp.Title;
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
            ButtonChangeORChooseService.Size = new Size(220, 29);
            ButtonChangeORChooseService.FlatAppearance.BorderSize = 1;
            ButtonChangeORChooseService.BackColor = Color.Transparent;
            ButtonChangeORChooseService.ForeColor = Program.BoldColor;
            ButtonChangeORChooseService.FlatAppearance.MouseOverBackColor = Color.FromArgb(Program.MediumColor.R - 20, Program.MediumColor.G - 20, Program.MediumColor.B - 20);
            ButtonChangeORChooseService.FlatAppearance.MouseDownBackColor = Color.FromArgb(Program.MediumColor.R + 10, Program.MediumColor.G + 10, Program.MediumColor.B + 10);
            ButtonChangeORChooseService.Font = new Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            ButtonChangeORChooseService.Click += ButtonChangeORChooseService_Click;
            ButtonChangeORChooseService.Anchor = AnchorStyles.Left;
            ButtonChangeORChooseService.Margin = new Padding(0, 0, 6, 0);

            LabelServiceOutput = new Label();
            LabelServiceOutput.Text = "Service:";
            LabelServiceOutput.Margin = new Padding(6);
            LabelServiceOutput.Font = new Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular | System.Drawing.FontStyle.Italic);
            LabelServiceOutput.AutoSize = true;
            LabelServiceOutput.Anchor = AnchorStyles.Left;


            LabelService = new Label();
            LabelService.Font = new Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            LabelService.AutoSize = true;
            LabelService.Margin = new Padding(6);
            LabelService.Anchor = AnchorStyles.Left;


            LabelBalanceOutput = new Label();
            LabelBalanceOutput.Text = "Balance:";
            LabelBalanceOutput.Margin = new Padding(6);
            LabelBalanceOutput.Font = new Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular | System.Drawing.FontStyle.Italic);
            LabelBalanceOutput.AutoSize = true;
            LabelBalanceOutput.Anchor = AnchorStyles.Left;

            LabelBalance = new Label();
            LabelBalance.Font = new Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            LabelBalance.AutoSize = true;
            LabelBalance.Margin = new Padding(0);
            LabelBalance.Anchor = AnchorStyles.Left;


            textBoxTitle = new TextBoxWithPlaceHolder();
            textBoxTitle.PlaceholderText = "Title";
            textBoxTitle.BackColor = this.BackColor;
            textBoxTitle.BorderStyle = BorderStyle.Fixed3D;
            textBoxTitle.Margin = new Padding(0);
            textBoxTitle.Font = new Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            textBoxTitle.Multiline = true;
            textBoxTitle.Dock = DockStyle.Fill;



            LabelNoDataRecorded = new Label();
            LabelNoDataRecorded.Text = "No client chosen yet";
            LabelNoDataRecorded.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            LabelNoDataRecorded.ForeColor = Color.FromArgb(150, 150, 150);
            LabelNoDataRecorded.BackColor = Color.FromArgb(150, Color.WhiteSmoke.R, Color.WhiteSmoke.G, Color.WhiteSmoke.B); // 128 is the alpha value
            LabelNoDataRecorded.TextAlign = ContentAlignment.MiddleCenter;
            LabelNoDataRecorded.AutoSize = false;
            LabelNoDataRecorded.Dock = DockStyle.Fill;
            LabelNoDataRecorded.Margin = new Padding(5, 0, 5, 0);


            pictureBoxSearch = new PictureBox();
            pictureBoxSearch.Size = new Size(25, 25);
            pictureBoxSearch.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "search2.png");
            pictureBoxSearch.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxSearch.Anchor = AnchorStyles.Right;


            ucSlideButtonServicerOthers.Button1Clicked += UcSlideButtonClientOrOthers_Button1Clicked;
            ucSlideButtonServicerOthers.Button2Clicked += UcSlideButtonClientOrOthers_Button2Clicked;
        }
        private void UcSlideButtonClientOrOthers_Button1Clicked(object sender, EventArgs e)
        {
            if (ucSlideButtonServicerOthers.ClickedButton != ucSlideButtonServicerOthers.button1)
            {
                SetLogicAndDesignMode(false, false);
                IsServiceOrOthersMode = true;
            }
        }
        private void UcSlideButtonClientOrOthers_Button2Clicked(object sender, EventArgs e)
        {
            if (ucSlideButtonServicerOthers.ClickedButton != ucSlideButtonServicerOthers.button2)
            {
                SetDesignIfOthersMode();
                IsServiceOrOthersMode = false;
            }
        }




        void SetDesignIfClientExist()
        {
            textBoxSearch.Text = DesiredAppointmentUCClientApp.DesiredClient.Fname + " " + DesiredAppointmentUCClientApp.DesiredClient.Lname;
            if (TLPglobal.Controls.Contains(pictureBoxSearch))
            {
                TLPglobal.Controls.Remove(pictureBoxSearch);
            }

            if (!TLPglobal.Controls.Contains(IconProfile))
            {
                TLPglobal.Controls.Add(IconProfile, 0, 1);  //the scd row will be set tahet hasab el conditions    
                TLPglobal.Controls.Add(LabelBalance, 1, 3);
                TLPglobal.Controls.Add(LabelBalanceOutput, 0, 3);
            }

        }
        void SetDesignIfClientNotExist()
        {

            if (TLPglobal.Controls.Contains(IconProfile))
            {
                TLPglobal.Controls.Remove(IconProfile);
                TLPglobal.Controls.Remove(LabelBalance);
                TLPglobal.Controls.Remove(LabelBalanceOutput);
            }

            if (!TLPglobal.Controls.Contains(pictureBoxSearch))
            {
                TLPglobal.Controls.Add(pictureBoxSearch, 0, 1);
            }
        }




        public event EventHandler OnUpdatingTheChosenClientBalance;//hayde ha ykun fiya event only to excute only eza update mode not add mode
        public void SetLogicAndDesignMode(bool IsNewServiceOrOneOfMultipleIsSelected, bool IsUpdateAndCallingFromConstruction)//high level design/ w the param, huuwe not null lamma na2e shi men el choose el service
        {
            textBoxSearch.PlaceholderText = "By name or phone";
            textBoxSearch.IsRequiredModeOn = false;

            //Design Higher level
            if (DesiredAppointmentUCClientApp.DesiredClient != null)
            {

                SetDesignIfClientExist();
            }
            else
            {
                RemoveAllControlsAtRowIndex(TLPglobal, 2);//ejbare awwal shi

                SetDesignIfClientNotExist();

                if (!TLPglobal.Controls.Contains(LabelNoDataRecorded))
                {
                    TLPglobal.Controls.Add(LabelNoDataRecorded, 0, 2);
                    TLPglobal.SetColumnSpan(LabelNoDataRecorded, 3);
                    TLPglobal.SetRowSpan(LabelNoDataRecorded, 2);
                }

                textBoxSearch.Text = textBoxSearch.PlaceholderText;
                pictureBoxSearch.Select();
            }






            if (!IsUpdateAndCallingFromConstruction)
            {
                if (!IsNewServiceOrOneOfMultipleIsSelected)
                {


                    if (DesiredAppointmentUCClientApp.DesiredClient != null)
                    {
                        //Sql
                        PackageRemainingsDt = ClassClientBalance.GetClientBalanceNotExpiredPackage(DesiredAppointmentUCClientApp.DesiredClient.ClientId);
                        SetLabelbalanceDesign();

                        if (DesiredAppointmentUCClientApp.ChosenBundlesList == null)//in case ma kenet mnaea wala service
                        {
                            //Menfout eza kenna aam nruh men other la service bel slide buttons (First Or),eza kenna bel serviceMode, men fout eza (scd OR) true) 
                            if (!IsServiceOrOthersMode || (OldPackageRemainingsDtDesiredClient == null || !AreTablesTheSame(OldPackageRemainingsDtDesiredClient, PackageRemainingsDt)))//after choosing a client, old=null ha nfout/ w eza ghayarna shi bel packages tb3 profile ha nfout
                            {

                                OldPackageRemainingsDtDesiredClient = PackageRemainingsDt.Copy();

                                //chosing the right service
                                if (PackageRemainingsDt.Rows.Count == 1)
                                {

                                    SetDesignIfServiceOrPackageSelected();
                                    FillObjectOfAvailablePackage(PackageRemainingsDt.Rows[0]);
                                    LabelService.Text = DesiredAppointmentUCClientApp.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                                    OnUpdatingTheChosenClientBalance?.Invoke(this, EventArgs.Empty);//deyman eza eena package wahad , we should force el update bel ucapp w bel form
                                                                                                    //hayde ha ykun fiya event only to excute only eza update mode not add mode

                                }
                                else //no packages or multiple packages
                                {
                                    if (PackageRemainingsDt.Rows.Count > 1)//mutiple packages
                                    {
                                        if (DesiredAppointmentUCClientApp.DesiredClientBalance == null)//fi kaza package w mesh mnaeyin wala wahad abel
                                        {
                                            SetDesignModeIfMultipleOrNoPackagesExist();
                                        }
                                        else//fi kaza package bas mna2yin wahad already, w hayda el wahad mnerjaa mnaamelo update always, maybe ghayrna shi fi aw mayble shelne men el profile
                                        {
                                            DataRow[] selectedRows = PackageRemainingsDt.Select("client_balance_id =" + DesiredAppointmentUCClientApp.DesiredClientBalance.ClientBalanceID);
                                            if (selectedRows.Length == 1)
                                            {
                                                SetDesignIfServiceOrPackageSelected();
                                                FillObjectOfAvailablePackage(selectedRows[0]);
                                                LabelService.Text = DesiredAppointmentUCClientApp.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                                                OnUpdatingTheChosenClientBalance?.Invoke(this, EventArgs.Empty); //hayde ha ykun fiya event only to excute only eza update mode not add mode
                                            }
                                            else//in case ken fi selected package, w shelne men profil bas still fi kaza package
                                            {
                                                SetDesignModeIfMultipleOrNoPackagesExist();
                                                FillObjectOfAvailablePackage(null);
                                            }
                                        }
                                    }
                                    else//no packages at all
                                    {
                                        SetDesignModeIfMultipleOrNoPackagesExist();
                                        FillObjectOfAvailablePackage(null);
                                        OnUpdatingTheChosenClientBalance?.Invoke(this, EventArgs.Empty); //hayde ha ykun fiya event only to excute only eza update mode not add mode
                                    }
                                }
                            }
                        }
                        else
                        {
                            SetDesignIfServiceOrPackageSelected();
                            LabelService.Text = DesiredAppointmentUCClientApp.ChoseBundlesString;

                        }
                    }



                }
                else
                {
                    if (DesiredAppointmentUCClientApp.ChosenBundlesList != null)
                    {
                        SetDesignIfServiceOrPackageSelected();
                        LabelService.Text = DesiredAppointmentUCClientApp.ChoseBundlesString;
                    }
                    else if (DesiredAppointmentUCClientApp.DesiredClientBalance != null)
                    {
                        SetDesignIfServiceOrPackageSelected();
                        LabelService.Text = DesiredAppointmentUCClientApp.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                    }
                    else
                    {
                        SetDesignModeIfMultipleOrNoPackagesExist();
                    }
                }
            }
            else//bet fout fiya bas eza update mode w awwal ma neftah el form
            {
                if (DesiredAppointmentUCClientApp.DesiredClient != null)
                {
                    PackageRemainingsDt = Management.ClassClientBalance.GetClientBalanceNotExpiredPackage(DesiredAppointmentUCClientApp.DesiredClient.ClientId);
                    OldPackageRemainingsDtDesiredClient = PackageRemainingsDt;

                    SetLabelbalanceDesign();

                    if (DesiredAppointmentUCClientApp.DesiredClientBalance != null)
                    {
                        SetDesignIfServiceOrPackageSelected();
                        LabelService.Text = DesiredAppointmentUCClientApp.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                    }
                    else if (DesiredAppointmentUCClientApp.ChoseBundlesString != null && DesiredAppointmentUCClientApp.ChosenBundlesList != null)
                    {
                        SetDesignIfServiceOrPackageSelected();
                        LabelService.Text = DesiredAppointmentUCClientApp.ChoseBundlesString;
                    }

                    else if (DesiredAppointmentUCClientApp.IsPackageMode == true && DesiredAppointmentUCClientApp.DesiredClientBalance == null)//AutSelectPackage
                    {

                        if (DesiredAppointmentUCClientApp.StartTime.Date == DateTime.Now.Date)//present
                        {
                            SetDesignModeIfMultipleOrNoPackagesExist();
                        }
                        else if (DesiredAppointmentUCClientApp.StartTime.Date > DateTime.Now.Date)//future
                        {
                            //badna naamela special design
                        }
                        else//past 
                        {
                            //badna naamela special design
                        }

                    }
                }
            }

            //if (DesiredAppointmentUCClientApp.DesiredClient != null)//ejabre tahet
            //{
            //    OldClientId = DesiredAppointmentUCClientApp.DesiredClient.ClientId;
            //}
            //else
            //{
            //    OldClientId = -1;
            //}

        }
        void SetDesignIfOthersMode()
        {
            textBoxSearch.PlaceholderText = "By name or phone (Optional)";
            textBoxSearch.IsRequiredModeOn = false;

            if (DesiredAppointmentUCClientApp.DesiredClient != null)
            {
                SetDesignIfClientExist();
                SetLabelbalanceDesign();
            }
            else
            {
                SetDesignIfClientNotExist();
            }


            if (!TLPglobal.Controls.Contains(textBoxTitle))
            {
                RemoveAllControlsAtRowIndex(TLPglobal, 2);
                TLPglobal.Controls.Add(textBoxTitle, 1, 2);
            }

            //if (DesiredAppointmentUCClientApp.DesiredClient != null)//ejabre tahet
            //{
            //    OldClientId = DesiredAppointmentUCClientApp.DesiredClient.ClientId;
            //}
            //else
            //{
            //    OldClientId = -1;
            //}

        }






        void SetDesignIfServiceOrPackageSelected()
        {
            RemoveAllControlsAtRowIndex(TLPglobal, 2);

            TLPglobal.Controls.Add(LabelServiceOutput, 0, 2);

            TLPglobal.Controls.Add(LabelService, 1, 2);

            TLPglobal.Controls.Add(ButtonChangeORChooseService);
            TLPglobal.SetColumn(ButtonChangeORChooseService, 2);
            TLPglobal.SetRow(ButtonChangeORChooseService, 2);


            ButtonChangeORChooseService.Text = "Change";
        }
        void SetDesignModeIfMultipleOrNoPackagesExist()
        {

            RemoveAllControlsAtRowIndex(TLPglobal, 2);

            TLPglobal.Controls.Add(LabelServiceOutput, 0, 2);

            TLPglobal.Controls.Add(ButtonChangeORChooseService);
            TLPglobal.SetColumn(ButtonChangeORChooseService, 1);
            TLPglobal.SetRow(ButtonChangeORChooseService, 2);


            if (PackageRemainingsDt.Rows.Count > 1)
            {
                ButtonChangeORChooseService.Text = "Choose an available package";
            }
            else if (PackageRemainingsDt.Rows.Count == 0)
            {
                ButtonChangeORChooseService.Text = "Choose one or more service";
            }


            //if (OldClientId != DesiredAppointmentUCClientApp.DesiredClient.ClientId && NewClientIsAdded == false)
            //{
            //    ChooseService chooseService = new ChooseService(this);
            //    chooseService.ShowDialog();
            //}



        }
        void SetLabelbalanceDesign()
        {
            LabelBalance.Text = Program.SetBalanceFormat(DesiredAppointmentUCClientApp.DesiredClient.TotalBalance.ToString());
            if (LabelBalance.Text.Contains('-'))
            {
                LabelBalance.ForeColor = Color.Red;
            }
            else
            {
                LabelBalance.ForeColor = Color.Black;
            }
        }




        public void FillObjectIfTitle(string Title)
        {
            DesiredAppointmentUCClientApp.Title = Title;
        }
        public void FillObjectOfNewChosenBundles(List<ClassBundles> BundleList)
        {

            if (BundleList != null)
            {
                DesiredAppointmentUCClientApp.ChosenBundlesList = new List<ClassBundles>(BundleList);
                //and chosenservice string is set automatically by default bel set tb3 ChosenServicesList

            }
            else
            {
                DesiredAppointmentUCClientApp.ChosenBundlesList = null;
            }
        }
        public void FillObjectOfAvailablePackage(DataRow DesiredRow)//only used if we were selecting an available package ( a specified balance) from table sql clientbalance
        {

            if (DesiredRow != null)
            {
                DesiredAppointmentUCClientApp.DesiredClientBalance = ClassClientBalance.CreateClientBalanceObject((int)DesiredRow["client_balance_id"]);
                DesiredAppointmentUCClientApp.DesiredClientBalance.SetStringDetailsIfBundle();
                DesiredAppointmentUCClientApp.IsPackageMode = true;
            }
            else
            {
                DesiredAppointmentUCClientApp.DesiredClientBalance = null;
                DesiredAppointmentUCClientApp.IsPackageMode = false;
            }

        }





        public void ResetDesiredAppointmentspecificValues()
        {
            DesiredAppointmentUCClientApp.ChosenBundlesList = null;
            DesiredAppointmentUCClientApp.DesiredClientBalance = null;
            DesiredAppointmentUCClientApp.IsPackageMode = false;
            DesiredAppointmentUCClientApp.Title = null;
            OldPackageRemainingsDtDesiredClient = null;
        }





        private void ButtonChangeORChooseService_Click(object sender, EventArgs e)
        {
            ParentFormAppointment.DisableClosingOnDisactivating = true;
            Program.GreyFormJunior = new GreyColor(this.ParentFormAppointment, true, true);
            Program.GreyFormJunior.Show();
            ChooseService chooseService = new ChooseService(this);
            chooseService.FormClosed += ChooseService_FormClosed;
            chooseService.ShowDialog();
        }

        private void ChooseService_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParentFormAppointment.DisableClosingOnDisactivating = false;
        }

        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            ParentFormAppointment.DisableClosingOnDisactivating = true;
            Search searchname = new Search(textBoxSearch, DesiredAppointmentUCClientApp.DesiredClient);
            searchname.Deactivate += Searchname_Deactivate;
            searchname.ChosenClientChanged += Searchname_ChosenClientChanged;
            Point locationRelativeToScreen = textBoxSearch.PointToScreen(Point.Empty);
            locationRelativeToScreen.Offset(-2, -2);
            searchname.Location = locationRelativeToScreen;
            searchname.Show();
        }
        private void Searchname_ChosenClientChanged(object sender, EventArgs e)
        {
            //reset
            Search searchname = (Search)sender;
            DesiredAppointmentUCClientApp.DesiredClient = searchname.NewDesiredClient;
            ResetDesiredAppointmentspecificValues();
            if (IsServiceOrOthersMode)//only eza kenna bel survice mode
            {
                SetLogicAndDesignMode(false, false);
            }
            else
            {
                SetDesignIfOthersMode();
            }


        }
        private void Searchname_Deactivate(object sender, EventArgs e)
        {
            label1.Select();
            ParentFormAppointment.DisableClosingOnDisactivating = false;
        }




        public event EventHandler OnClientProfileInfoChanging;
        private void IconProfile_Click(object sender, EventArgs e)
        {
            ParentFormAppointment.DisableClosingOnDisactivating = true;
            ParentFormAppointment.Visible = false;

            Cursor = Cursors.WaitCursor;

            ScheduleForm schedule = this.ParentFormAppointment.UcDayParentForm.ParentFormSchedule;
            Menu menu = ((Home)schedule.Tag).menu;
            menu.GoingFromSousChildToChild += Menu_GoingFromSousChildToChild;
            menu.GoingFromChildToChild += Menu_GoingFromChildToChild;
            if (Program.clientManagementProfile == null)
            {
                Program.clientManagementProfile = new ClientManagementProfile(ClassClient.CreateClientObject(DesiredAppointmentUCClientApp.DesiredClient.ClientId), true);
            }
            else
            {
                Program.clientManagementProfile.LoadData(ClassClient.CreateClientObject(DesiredAppointmentUCClientApp.DesiredClient.ClientId), true);
                // ma aam tozbat el formatdatatgrid men wara el show dialog, bas eemlna glitch bel event visible chnaged on the form
            }

            Program.clientManagementProfile.Size = schedule.Size;
            menu.OpenChildForm(Program.clientManagementProfile, menu.buttonSearchClient, true);

            ((Home)schedule.Tag).buttonBackHome.Text = "Schedule";
            ((Home)schedule.Tag).buttonBackHome.Visible = true;



            Cursor = Cursors.Default;


        }
        private void Menu_GoingFromChildToChild(object sender, EventArgs e)
        {
            Menu menu = (Menu)sender;
            menu.GoingFromChildToChild -= Menu_GoingFromChildToChild;//ejbare since ma aam nekhlae new instance
        }
        private void Menu_GoingFromSousChildToChild(object sender, EventArgs e)
        {
            ScheduleForm schedule = this.ParentFormAppointment.UcDayParentForm.ParentFormSchedule;
            Program.GreyForm = new GreyColor(((Home)schedule.Tag), true, false);
            Program.GreyForm.Show();


            Menu menu = (Menu)sender;
            menu.GoingFromSousChildToChild -= Menu_GoingFromSousChildToChild;//ejbare since ma aam nekhlae new instance

            DesiredAppointmentUCClientApp.DesiredClient = Program.clientManagementProfile.Client;

            if (DesiredAppointmentUCClientApp.DesiredClient == null)//means the client was deleted
            {
                ResetDesiredAppointmentspecificValues();
            }
            SetLogicAndDesignMode(false, false);

            OnClientProfileInfoChanging?.Invoke(this, EventArgs.Empty);//ejbare tahta

            ParentFormAppointment.DisableClosingOnDisactivating = false;
            ParentFormAppointment.Show();
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
            ParentFormAppointment.DisableClosingOnDisactivating = true;


            Program.GreyFormJunior = new GreyColor(this.ParentFormAppointment, true, true);
            Program.GreyFormJunior.Show();
            if (Program.NewRegisterForm == null)
            {
                Program.NewRegisterForm = new NewRegister(null, true);
            }
            else
            {
                Program.NewRegisterForm.Resetcontrols();
                Program.NewRegisterForm.LoadForm(null, true);
            }
            Program.NewRegisterForm.ClientSavedEvent += NewRegisterForm_ClientSaved;
            Program.NewRegisterForm.VisibleChanged += NewRegisterForm_VisibleChanged;
            Program.NewRegisterForm.ShowDialog();
        }

        private void NewRegisterForm_VisibleChanged(object sender, EventArgs e)
        {
            NewRegister newRegister = (NewRegister)sender;
            if (newRegister.Visible == false)
            {
                ParentFormAppointment.DisableClosingOnDisactivating = false;
            }
            Program.NewRegisterForm.VisibleChanged -= NewRegisterForm_VisibleChanged;
        }

        private void NewRegisterForm_ClientSaved(object sender, EventArgs e)
        {
            NewRegister newRegister = (NewRegister)sender;
            DesiredAppointmentUCClientApp.DesiredClient = newRegister.TheNewInsertedClient;
            ResetDesiredAppointmentspecificValues();
            NewClientIsAdded = true;//set
            SetLogicAndDesignMode(false, false);//fi shi depends men hal value, open choose service
            NewClientIsAdded = false;//reset
            Program.NewRegisterForm.FormClosed -= NewRegisterForm_ClientSaved;
        }






        bool AreTablesTheSame(DataTable table1, DataTable table2)
        {
            if (table1.Rows.Count != table2.Rows.Count || table1.Columns.Count != table2.Columns.Count)
                return false;

            for (int i = 0; i < table1.Rows.Count; i++)
            {
                for (int j = 0; j < table1.Columns.Count; j++)
                {
                    if (!Equals(table1.Rows[i][j], table2.Rows[i][j]))
                        return false;
                }
            }

            return true;
        }
        void RemoveAllControlsAtRowIndex(TableLayoutPanel desiredtlp, int row)
        {
            for (int i = desiredtlp.Controls.Count - 1; i >= 0; i--)
            {
                var control = desiredtlp.Controls[i];
                if (desiredtlp.GetRow(control) == row) // If the control is in row 2 (index 1)
                {
                    desiredtlp.Controls.Remove(control);
                }
            }

        }


    }
}
