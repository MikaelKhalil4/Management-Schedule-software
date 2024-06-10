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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Converters;
using static System.Net.Mime.MediaTypeNames;

namespace MKproject.Schedule
{
    public partial class UCClientApp : UserControl
    {
        public Appointment ParentFormAppointment { get; set; }
        public bool IsReadOrEdit { get; set; }

        public TextBoxWithPlaceHolder textBoxTitle;
        Label LabelServiceOutput;
        Label LabelService;
        Label LabelBalanceOutput;
        Label LabelBalance;
        Label LabelNoDataRecorded;
        IconButton IconProfile;
        PictureBox pictureBoxSearch;
        CustomButton ButtonChangeORChooseService;
        IconButton IconDeleteService;
        UCSlideButton ucSlideButtonServicerOthers;
        Label labelFullName;

        ToolTip toolTip1;

        public ClassAppointment DesiredAppointmentUCClientApp;
        public DataTable PackageRemainingsDt;
        public DataTable OldPackageRemainingsDtDesiredClient;//will be reset to null, kell ma ngahyyir client

        bool NewClientIsAdded = false;
        public bool IsServiceOrOthersMode;
        public UCClientApp(Appointment parentFormAppointment)//used in appointment form
        {
            InitializeComponent();
            ParentFormAppointment = parentFormAppointment;
            DesiredAppointmentUCClientApp = ParentFormAppointment.DesiredAppointmentAppForm;
            IsReadOrEdit = ParentFormAppointment.IsReadOrEdit;

            CreateCommunTools();//ReadOnly,And Edit

            if (!IsReadOrEdit)
            {
                CreateEditTools();

                if (DesiredAppointmentUCClientApp.Title == null)
                {
                    //since by default bet kunaa l button service
                    IsServiceOrOthersMode = true;
                    SetLogicAndDesignEditAndServiceMode(false, true);//update or Add appointment will be handled iside this function
                }
                else
                {
                    ucSlideButtonServicerOthers.button2_Click(null, EventArgs.Empty);// SetDesignIfOthersMode(); will be called
                    textBoxTitle.Text = DesiredAppointmentUCClientApp.Title;
                }
            }
            else
            {
                SetReadOnlyDesign();
            }
        }



        //used for Past
        void SetReadOnlyDesign()
        {
            SetDesignIfServiceOrPackageSelected();
            FillLabelServiceFields();

            if (DesiredAppointmentUCClientApp.DesiredClient != null)
            {
                SetLabelbalanceDesign();
               
            }
            else
            {
                TLPglobal.RowStyles[3].Height = 0;
            }
            TLPglobal.RowStyles[0].Height = 0;
            //
            ButtonNewClient.Dispose();
            textBoxSearch.Dispose();
            //


            if (DesiredAppointmentUCClientApp.DesiredClient != null)
            {
                SetDesignIfClientExist();
                if (labelFullName == null)
                {
                    labelFullName = new Label();
                    labelFullName.Font = new Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
                    labelFullName.AutoSize = true;
                    labelFullName.Margin = new Padding(6);
                    labelFullName.Anchor = AnchorStyles.Left;
                    TLPglobal.Controls.Add(labelFullName, 1, 1);
                    TLPglobal.SetColumnSpan(labelFullName, 3);
                }
                labelFullName.Text = DesiredAppointmentUCClientApp.DesiredClient.Fname + " " + DesiredAppointmentUCClientApp.DesiredClient.Lname;

            }
            else
            {
                TLPglobal.RowStyles[1].Height = 0;//ClientName
            }


            //
            TLPglobal.SetColumnSpan(LabelService, 3);
            LabelService.Anchor = AnchorStyles.Right;

            TLPglobal.SetColumnSpan(LabelBalance, 3);
            LabelBalance.Anchor = AnchorStyles.Right;

            if (DesiredAppointmentUCClientApp.Title != null)
            {

                if (!string.IsNullOrEmpty(DesiredAppointmentUCClientApp.Title))
                {
                    LabelService.Text = DesiredAppointmentUCClientApp.Title;

                }
                else
                {
                    LabelService.Text = "N/A";
                }

                LabelServiceOutput.Text = "Title:";
            }
            else if (DesiredAppointmentUCClientApp.IsPackageMode)
            {
                LabelServiceOutput.Text = "Service:";
            }
            else
            {
                LabelServiceOutput.Text = "Service/Title:";
            }

            FunctionsForWinformsTool.AdjustTableLayoutPanelHeight(TLPglobal);
            this.Height = TLPglobal.Height;
            TLPglobal.Dock = DockStyle.Fill;
        }

        //used for present-future
        void CreateEditTools()
        {

            ucSlideButtonServicerOthers = new UCSlideButton();
            ucSlideButtonServicerOthers.Size = new Size(236, 37);
            ucSlideButtonServicerOthers.Anchor = AnchorStyles.None;
            ucSlideButtonServicerOthers.Button1text = "Services";
            ucSlideButtonServicerOthers.Button2text = "Custom";
            TLPglobal.Controls.Add(ucSlideButtonServicerOthers, 0, 0);
            TLPglobal.SetColumnSpan(ucSlideButtonServicerOthers, 4);
            ucSlideButtonServicerOthers.Button1Clicked += UcSlideButtonClientOrOthers_Button1Clicked;
            ucSlideButtonServicerOthers.Button2Clicked += UcSlideButtonClientOrOthers_Button2Clicked;





            ButtonChangeORChooseService = new CustomButton();
            ButtonChangeORChooseService.Size = new Size(220, 30);
            ButtonChangeORChooseService.FlatAppearance.BorderSize = 1;
            ButtonChangeORChooseService.BackColor = Color.Transparent;
            ButtonChangeORChooseService.ForeColor = Program.BoldColor;
            ButtonChangeORChooseService.FlatAppearance.MouseOverBackColor = Color.FromArgb(Program.MediumColor.R - 20, Program.MediumColor.G - 20, Program.MediumColor.B - 20);
            ButtonChangeORChooseService.FlatAppearance.MouseDownBackColor = Color.FromArgb(Program.MediumColor.R + 10, Program.MediumColor.G + 10, Program.MediumColor.B + 10);
            ButtonChangeORChooseService.Font = new Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            ButtonChangeORChooseService.Click += ButtonChangeORChooseService_Click;
            ButtonChangeORChooseService.Anchor = AnchorStyles.Left;
            ButtonChangeORChooseService.Margin = new Padding(0, 0, 6, 0);


            IconDeleteService = new IconButton();
            IconDeleteService.Size = new Size(30, 30);
            IconDeleteService.Margin = new Padding(0);
            IconDeleteService.Anchor = AnchorStyles.None;
            IconDeleteService.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "eraser.png");
            IconDeleteService.BackgroundImageLayout = ImageLayout.Zoom;
            IconDeleteService.Click += IconDeleteService_Click;
            toolTip1.SetToolTip(IconDeleteService, "Remove Service");

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
            LabelNoDataRecorded.Margin = new Padding(5, 0, 5, 5);


            pictureBoxSearch = new PictureBox();
            pictureBoxSearch.Size = new Size(25, 25);
            pictureBoxSearch.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "search2.png");
            pictureBoxSearch.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxSearch.Anchor = AnchorStyles.Right;

        }


        void CreateCommunTools()
        {
            toolTip1 = new ToolTip();
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
            LabelBalance.Margin = new Padding(6);
            LabelBalance.Anchor = AnchorStyles.Left;
        }




        //used for Past-present-future
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
                TLPglobal.SetColumnSpan(LabelBalance, 2);
                TLPglobal.Controls.Add(LabelBalanceOutput, 0, 3);
            }
        }
        void SetDesignIfClientNotExist()
        {

            if (TLPglobal.Controls.Contains(IconProfile))
            {
                TLPglobal.Controls.Remove(IconProfile);
            }
            if (TLPglobal.Controls.Contains(LabelBalance))
            {
                TLPglobal.Controls.Remove(LabelBalance);
            }
            if (TLPglobal.Controls.Contains(LabelBalanceOutput))
            {
                TLPglobal.Controls.Remove(LabelBalanceOutput);
            }


            if (!TLPglobal.Controls.Contains(pictureBoxSearch))
            {
                TLPglobal.Controls.Add(pictureBoxSearch, 0, 1);
            }
        }
        void SetDesignIfServiceOrPackageSelected()
        {
            RemoveAllControlsAtRowIndex(TLPglobal, 2);

            TLPglobal.Controls.Add(LabelServiceOutput, 0, 2);

            TLPglobal.Controls.Add(LabelService, 1, 2);

            if (!IsReadOrEdit)
            {

                TLPglobal.Controls.Add(ButtonChangeORChooseService, 2, 2);
                TLPglobal.Controls.Add(IconDeleteService, 3, 2);
                ButtonChangeORChooseService.Text = "Change";
            }
        }
        void SetLabelbalanceDesign()
        {
            if (DesiredAppointmentUCClientApp.StartTime.Date >= DateTime.Now.Date)//present-future
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
            else//past
            {
                LabelBalance.Text = "N/A";
            }
        }

        //used for Edit Mode
        void SetDesignModeIfMultipleOrNoPackagesExist()
        {

            RemoveAllControlsAtRowIndex(TLPglobal, 2);

            TLPglobal.Controls.Add(LabelServiceOutput, 0, 2);

            if (!IsReadOrEdit)//present-future
            {
                TLPglobal.Controls.Add(ButtonChangeORChooseService);
                TLPglobal.SetColumn(ButtonChangeORChooseService, 1);
                TLPglobal.SetRow(ButtonChangeORChooseService, 2);


                if (PackageRemainingsDt.Rows.Count >= 1)
                {
                    ButtonChangeORChooseService.Text = "Choose an available package";
                }
                else if (PackageRemainingsDt.Rows.Count == 0)
                {
                    ButtonChangeORChooseService.Text = "Choose one or more service";
                }
            }

        }






        //Edit Mode
        public void SetLogicAndDesignEditAndServiceMode(bool IsNewServiceOrOneOfMultipleIsSelected, bool IsCallingFromConstruction)//high level design/ w the param, huuwe not null lamma na2e shi men el choose el service
        {
            textBoxSearch.PlaceholderText = "By name or phone";
            textBoxSearch.IsRequiredModeOn = false;
            LabelServiceOutput.Text = "Service:";


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
                    TLPglobal.SetColumnSpan(LabelNoDataRecorded, 4);
                    TLPglobal.SetRowSpan(LabelNoDataRecorded, 2);
                }

                textBoxSearch.Text = textBoxSearch.PlaceholderText;
                pictureBoxSearch.Select();
            }



            if (!IsCallingFromConstruction)
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

                                if (PackageRemainingsDt.Rows.Count == 1)
                                {
                                    FillObjectOfAvailablePackageifPresent(PackageRemainingsDt.Rows[0]);
                                    FillLabelServiceFields();
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
                                                FillObjectOfAvailablePackageifPresent(selectedRows[0]);
                                                FillLabelServiceFields();
                                            }
                                            else//in case ken fi selected package, w shelne men profil bas still fi kaza package
                                            {
                                                SetDesignModeIfMultipleOrNoPackagesExist();
                                                FillObjectOfAvailablePackageifPresent(null);
                                            }
                                        }
                                    }
                                    else//no packages at all
                                    {
                                        SetDesignModeIfMultipleOrNoPackagesExist();
                                        FillObjectOfAvailablePackageifPresent(null);
                                    }
                                }
                            }

                        }
                        else
                        {
                            FillLabelServiceFields();
                        }
                    }
                }
                else//hone men kun naeayna shi men el ChooseServiceForm w rejiin la AppointmentForm
                {
                    FillLabelServiceFields();
                }
            }
            else//bet fout fiya bas eza update mode w awwal ma neftah el form
            {
                if (DesiredAppointmentUCClientApp.DesiredClient != null)//If Update, or eza kenit null bet kun add, fa ma bi sir shi
                {
                    PackageRemainingsDt = ClassClientBalance.GetClientBalanceNotExpiredPackage(DesiredAppointmentUCClientApp.DesiredClient.ClientId);
                    OldPackageRemainingsDtDesiredClient = PackageRemainingsDt;

                    SetLabelbalanceDesign();
                    FillLabelServiceFields();
                }
            }


        }
        void SetDesignIfEditAndOthersMode()
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

                LabelServiceOutput.Text = "Title:";
                TLPglobal.Controls.Add(LabelServiceOutput, 0, 2);

                TLPglobal.Controls.Add(textBoxTitle, 1, 2);
            }



        }


        //used for ReadOnly And Edit Mode
        void FillLabelServiceFields()
        {
            if (DesiredAppointmentUCClientApp.DesiredClientBalance != null)
            {
                SetDesignIfServiceOrPackageSelected();

                if (DesiredAppointmentUCClientApp.StartTime.Date >= DateTime.Now.Date)//present
                {


                    if (!(bool)DesiredAppointmentUCClientApp.DesiredClientBalance.IsExpired)//Package exist and not expired
                    {
                        if (DesiredAppointmentUCClientApp.StartTime.Date >= DateTime.Now.Date)//present-future
                        {
                            LabelService.Text = DesiredAppointmentUCClientApp.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                            if (DesiredAppointmentUCClientApp.DesiredClientBalance.SessionLeftDays == 0)
                            {
                                LabelService.ForeColor = Color.Red;
                            }
                            else
                            {
                                LabelService.ForeColor = Color.Black;
                            }
                        }
                    }
                    else//Package exist and expired
                    {
                        LabelService.Text = DesiredAppointmentUCClientApp.DesiredClientBalance.BundleName + " Package Expired";
                    }


                }
                else if (DesiredAppointmentUCClientApp.StartTime.Date < DateTime.Now.Date)// past
                {

                    LabelService.Text = DesiredAppointmentUCClientApp.HistoryClientBalance;

                }
            }

            else if (DesiredAppointmentUCClientApp.ChosenBundlesList != null)
            {

                SetDesignIfServiceOrPackageSelected();
                LabelService.Text = DesiredAppointmentUCClientApp.ChoseBundlesString;

            }
            else if (DesiredAppointmentUCClientApp.DesiredClientBalance == null && DesiredAppointmentUCClientApp.ChosenBundlesList == null)
            {

                if (!IsReadOrEdit)//present-future
                {
                    SetDesignModeIfMultipleOrNoPackagesExist();
                }
                else
                {
                    LabelService.Text = "N/A";
                }

            }
        }



        //used for Edit Mode
        public void FillObjectIfTitle(string title)
        {
            if (!String.IsNullOrEmpty(title) && title != textBoxTitle.PlaceholderText)
            {
                DesiredAppointmentUCClientApp.Title = title;
            }
            else
            {
                DesiredAppointmentUCClientApp.Title = null;
            }
        }
        public void FillObjectOfNewChosenBundles(List<ClassBundles> BundleList)
        {

            if (BundleList != null)
            {
                DesiredAppointmentUCClientApp.ChosenBundlesList = new List<ClassBundles>(BundleList);
                //and chosenservice string is set automatically by default bel set tb3 ChosenServicesList

                TimeSpan totalduration = TimeSpan.Zero;
                foreach (ClassBundles bund in DesiredAppointmentUCClientApp.ChosenBundlesList)
                {
                    totalduration+=bund.Duration;
                }

                UpdateDuration(totalduration);
            }
            else
            {
                DesiredAppointmentUCClientApp.ChosenBundlesList = null;
            }


         
        }
        public void FillObjectOfAvailablePackageifPresent(DataRow DesiredRow)//only used if we were selecting an available package ( a specified clientbalance) from table sql clientbalance
        {

            if (DesiredRow != null)
            {
                DesiredAppointmentUCClientApp.DesiredClientBalance = ClassClientBalance.CreateClientBalanceObject(Convert.ToInt32(DesiredRow["client_balance_id"]));
                DesiredAppointmentUCClientApp.DesiredClientBalance.SetStringDetailsIfBundle();
                DesiredAppointmentUCClientApp.IsPackageMode = true;
                UpdateDuration(DesiredAppointmentUCClientApp.DesiredClientBalance.BundleDuration);
            }
            else
            {
                DesiredAppointmentUCClientApp.DesiredClientBalance = null;
                DesiredAppointmentUCClientApp.IsPackageMode = false;
            }


         

        }

        void UpdateDuration(TimeSpan Duration)
        {
            DesiredAppointmentUCClientApp.EndTime = DesiredAppointmentUCClientApp.StartTime + Duration;
            ParentFormAppointment.UpdateTimeDesign();
        }




        public void ResetDesiredAppointmentspecificValues()
        {
            DesiredAppointmentUCClientApp.ChosenBundlesList = null;
            DesiredAppointmentUCClientApp.DesiredClientBalance = null;
            DesiredAppointmentUCClientApp.Title = null;
            OldPackageRemainingsDtDesiredClient = null;
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







        private void UcSlideButtonClientOrOthers_Button1Clicked(object sender, EventArgs e)
        {
            if (ucSlideButtonServicerOthers.ClickedButton != ucSlideButtonServicerOthers.button1)
            {
                SetLogicAndDesignEditAndServiceMode(false, false);
                IsServiceOrOthersMode = true;
            }
        }
        private void UcSlideButtonClientOrOthers_Button2Clicked(object sender, EventArgs e)
        {
            if (ucSlideButtonServicerOthers.ClickedButton != ucSlideButtonServicerOthers.button2)
            {
                SetDesignIfEditAndOthersMode();
                IsServiceOrOthersMode = false;
            }
        }



        private void ButtonChangeORChooseService_Click(object sender, EventArgs e)
        {
            ParentFormAppointment.DisableClosingOnDisactivating = true;
            Program.GreyFormJunior = new GreyColor(this.ParentFormAppointment, true, true, null);
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
                SetLogicAndDesignEditAndServiceMode(false, false);
            }
            else
            {
                SetDesignIfEditAndOthersMode();
            }


        }
        private void Searchname_Deactivate(object sender, EventArgs e)
        {
            ParentFormAppointment.Focus();
            ParentFormAppointment.DisableClosingOnDisactivating = false;
            ucSlideButtonServicerOthers.Select();
        }




        private void IconProfile_Click(object sender, EventArgs e)
        {
            ParentFormAppointment.DisableClosingOnDisactivating = true;
            ParentFormAppointment.Visible = false;

            Cursor = Cursors.WaitCursor;

            ScheduleForm schedule = this.ParentFormAppointment.UcScheduleParentForm.ParentFormSchedule;
            Home home = Program.HomeForm;


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
            home.menu.OpenChildForm(Program.clientManagementProfile, home.menu.buttonSearchClient, true);
            home.menu.GoingFromSousChildToChild += Menu_GoingFromSousChildToChild;//ejbare tahet el OpenChild, cz we need to use them once sorna bel profile w we re navigating Back or Through the Menu Bar
            home.menu.GoingFromChildToChild += Menu_GoingFromChildToChild;

            home.buttonBackHome.Text = "Schedule";
            home.buttonBackHome.Visible = true;



            Cursor = Cursors.Default;


        }
        private void Menu_GoingFromChildToChild(object sender, EventArgs e)
        {
            Menu menu = (Menu)sender;
            //ejbare To remove Both always ,since ma aam nekhlae new instance w ha ydallun maal2in fiya lal menu eza ma shelnehun w taamele mashekil
            menu.GoingFromChildToChild -= Menu_GoingFromChildToChild;
            menu.GoingFromSousChildToChild -= Menu_GoingFromSousChildToChild;
        }
        private void Menu_GoingFromSousChildToChild(object sender, EventArgs e)
        {
            //Ejbare bel awwal barke sar error during the code
            //ejbare To remove Both always ,since ma aam nekhlae new instance w ha ydallun maal2in fiya lal menu eza ma shelnehun w taamele mashekil
            Menu menu = (Menu)sender;
            menu.GoingFromSousChildToChild -= Menu_GoingFromSousChildToChild;
            menu.GoingFromChildToChild -= Menu_GoingFromChildToChild;


            ScheduleForm schedule = this.ParentFormAppointment.UcScheduleParentForm.ParentFormSchedule;
            Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
            Program.GreyForm.Show();


            DesiredAppointmentUCClientApp.DesiredClient = Program.clientManagementProfile.Client;//el balance and  Personal Info automatically will be set


            if (!IsReadOrEdit)
            {

                if (DesiredAppointmentUCClientApp.IsPackageMode && DesiredAppointmentUCClientApp.DesiredClientBalance != null && (bool)DesiredAppointmentUCClientApp.DesiredClientBalance.IsExpired) //Expired Package 
                {
                    //refresh lal maaloumet el cached  bas ma men ghayyir shi bel design
                    PackageRemainingsDt = ClassClientBalance.GetClientBalanceNotExpiredPackage(DesiredAppointmentUCClientApp.DesiredClient.ClientId);
                    SetLabelbalanceDesign();
                }
                else
                {
                    //men ghayir, automation is working
                    SetLogicAndDesignEditAndServiceMode(false, false);//only bel present baamil update lal ucclientapp, past eendo static design
                }

            }
            else
            {
                DesiredAppointmentUCClientApp = ClassAppointment.CreateObjectClassAppointment(DesiredAppointmentUCClientApp.AppointmentID);
                ParentFormAppointment.DesiredAppointmentAppForm = DesiredAppointmentUCClientApp;//since we have lost the reference foe
                SetReadOnlyDesign();
            }

            if (ParentFormAppointment.UCappointment != null)
            {
                if (DesiredAppointmentUCClientApp.DesiredClient != null && (DesiredAppointmentUCClientApp.IsPackageMode || DesiredAppointmentUCClientApp.ChosenBundlesList != null))
                {
                    ParentFormAppointment.UcScheduleParentForm.RefreshAllRelatedAppointments(DesiredAppointmentUCClientApp.DesiredClient.ClientId);
                }
                else
                {
                    ParentFormAppointment.UcScheduleParentForm.RefreshDesiredAppointment(ParentFormAppointment.UCappointment);
                }
            }
            if (IsReadOrEdit && !DesiredAppointmentUCClientApp.IsCompleted && DesiredAppointmentUCClientApp.StartTime.Date == DateTime.Now.Date)
            {// lamma nkun bel present , juwwet appointment completed yaane readonly, w fout aal profile w aamil undo lal session done w erjaa eje, , badde edit mode design yeje w since mafi design function lal edit mode, so mnodtar nekhlaae el form men jdid               

                ParentFormAppointment.Close();
                ParentFormAppointment.UCappointment.Control_MouseClick(null, null);

            }
            else
            {
                ParentFormAppointment.DisableClosingOnDisactivating = false;
                ParentFormAppointment.Show();
            }
        }



        private void ButtonNewClient_Click(object sender, EventArgs e)
        {
            ParentFormAppointment.DisableClosingOnDisactivating = true;


            Program.GreyFormJunior = new GreyColor(this.ParentFormAppointment, true, true, null);
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
            SetLogicAndDesignEditAndServiceMode(false, false);//fi shi depends men hal value, open choose service
            NewClientIsAdded = false;//reset
            Program.NewRegisterForm.FormClosed -= NewRegisterForm_ClientSaved;
        }

        private void IconDeleteService_Click(object sender, EventArgs e)
        {
            DesiredAppointmentUCClientApp.ChosenBundlesList = null;
            DesiredAppointmentUCClientApp.DesiredClientBalance = null;
            SetDesignModeIfMultipleOrNoPackagesExist();
        }


    }
}
