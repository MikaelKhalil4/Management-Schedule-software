using CustomizedTools;
using GlobalFunctions;
using MKproject.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
        public TextBoxWithPlaceHolder textBoxTitle;
        Label LabelServiceOutput;
        Label LabelServiceBundle;
        Label LabelNoDataRecorded;
        IconButton IconProfile;
        PictureBox pictureBoxSearch;
        CustomButton ButtonChangeORChooseService;

        int OldClientId = -1;
        public ClassAppointment DesiredAppointment;
        public DataTable PackageRemainingsDt;
        public DataTable OldPackageRemainingsDtDesiredClient;//will be reset to null, kell ma ngahyyir client

        bool NewClientIsAdded = false;
        public bool IsServiceOrOthersMode;
        public UCClientApp(ClassAppointment appointmentToUpdate)//used in appointment form
        {
            InitializeComponent();
            DesiredAppointment = appointmentToUpdate.Copy();
            CreatingTheClientModeOn();

            if (DesiredAppointment.Title == null)
            {
                //since by default bet kunaa l button service
                IsServiceOrOthersMode = true;
                if (DesiredAppointment.IdAppointment == null)//adding new appointment
                {
                    SetDesignMode(false, false);
                }
                else//update form
                {
                    SetDesignMode(false, true);
                }

            }
            else
            {
              ucSlideButtonServicerOthers.button2_Click(null, EventArgs.Empty);
              textBoxTitle.Text = DesiredAppointment.Title;
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
            LabelServiceOutput.Font = new Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);
            LabelServiceOutput.AutoSize = true;
            LabelServiceOutput.Anchor = AnchorStyles.Left;


            LabelServiceBundle = new Label();
            LabelServiceBundle.Font = new Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            LabelServiceBundle.AutoSize = true;
            LabelServiceBundle.Margin = new Padding(6);
            LabelServiceBundle.Anchor = AnchorStyles.Left;




            textBoxTitle = new TextBoxWithPlaceHolder();
            textBoxTitle.PlaceholderText = "Title";
            textBoxTitle.BackColor = this.BackColor;
            textBoxTitle.BorderStyle = BorderStyle.Fixed3D;
            textBoxTitle.Margin = new Padding(0);
            textBoxTitle.Font = new Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            textBoxTitle.Multiline = true;
            textBoxTitle.Dock = DockStyle.Fill;

            //LabelServiceBalance = new Label();
            //LabelServiceBalance.Font = new Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            //LabelServiceBalance.AutoSize = true;
            //LabelServiceBalance.Margin = new Padding(0);
            //LabelServiceBalance.Anchor = AnchorStyles.Left;

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
                SetDesignMode(false, false);
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







        public void SetDesignMode(bool IsNewServiceOrOneOfMultipleIsSelected, bool IsUpdateAndCallingFromConstruction)//high level design/ w the param, huuwe not null lamma na2e shi men el choose el service
        {
            textBoxSearch.PlaceholderText = "By name or phone";
            textBoxSearch.IsRequiredModeOn = false;

            //Design Higher level
            if (DesiredAppointment.DesiredClient != null || DesiredAppointment.Title != null)
            {
                textBoxSearch.Text = DesiredAppointment.DesiredClient.Fname + " " + DesiredAppointment.DesiredClient.Lname;

                if (TLPglobal.Controls.Contains(pictureBoxSearch))
                {
                    TLPglobal.Controls.Remove(pictureBoxSearch);
                }

                if (!TLPglobal.Controls.Contains(IconProfile))
                {
                    TLPglobal.Controls.Add(IconProfile, 0, 1);  //the scd row will be set tahet hasab el conditions    
                }


            }
            else
            {
                RemoveAllControlsAtRowIndex(TLPglobal, 2);//ejbare awwal shi


                if (TLPglobal.Controls.Contains(IconProfile))
                {
                    TLPglobal.Controls.Remove(IconProfile);
                }

                if (!TLPglobal.Controls.Contains(pictureBoxSearch))
                {
                    TLPglobal.Controls.Add(pictureBoxSearch, 0, 1);
                }
                if (!TLPglobal.Controls.Contains(LabelNoDataRecorded))
                {
                    TLPglobal.Controls.Add(LabelNoDataRecorded, 0, 2);
                    TLPglobal.SetColumnSpan(LabelNoDataRecorded, 3);
                }

                textBoxSearch.Text = textBoxSearch.PlaceholderText;
                pictureBoxSearch.Select();
            }



           


            if (!IsUpdateAndCallingFromConstruction)
            {
                if (!IsNewServiceOrOneOfMultipleIsSelected)
                {


                    if (DesiredAppointment.DesiredClient != null)
                    {
                        //Sql
                        PackageRemainingsDt =ClassClientBalance.GetClientBalanceNotExpiredPackage(DesiredAppointment.DesiredClient.ClientId);

                        if (DesiredAppointment.ChosenBundlesList == null)//in case ma kenet mnaea wala service
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
                                    LabelServiceBundle.Text = DesiredAppointment.DesiredClientBalance.ClientBalanceFullDetails;
                                }
                                else //no packages or multiple packages
                                {
                                    if (PackageRemainingsDt.Rows.Count > 1)//mutiple packages
                                    {
                                        if (DesiredAppointment.DesiredClientBalance == null)//fi kaza package w mesh mnaeyin wala wahad abel
                                        {
                                            SetDesignModeIfMultipleOrNoPackagesExist();
                                        }
                                        else//fi kaza package bas mna2yin wahad already, w hayda el wahad mnerjaa mnaamelo update always, maybe ghayrna shi fi aw mayble shelne men el profile
                                        {
                                            DataRow[] selectedRows = PackageRemainingsDt.Select("ID =" + DesiredAppointment.DesiredClientBalance.ClientBalanceID);
                                            if (selectedRows.Length == 1)
                                            {
                                                SetDesignIfServiceOrPackageSelected();
                                                FillObjectOfAvailablePackage(selectedRows[0]);
                                                LabelServiceBundle.Text = DesiredAppointment.DesiredClientBalance.ClientBalanceFullDetails;
                                            }
                                            else//in case ken fi selected package, w shelne men profil bas still fi kaza package
                                            {
                                                SetDesignModeIfMultipleOrNoPackagesExist();
                                            }
                                        }
                                    }
                                    else//no packages at all
                                    {
                                        SetDesignModeIfMultipleOrNoPackagesExist();                                     
                                    }
                                }
                            }
                        }
                        else
                        {
                            SetDesignIfServiceOrPackageSelected();
                            LabelServiceBundle.Text = DesiredAppointment.ChoseBundlesString;

                        }
                    }



                }
                else
                {
                    if (DesiredAppointment.ChosenBundlesList != null)
                    {
                        SetDesignIfServiceOrPackageSelected();
                        LabelServiceBundle.Text = DesiredAppointment.ChoseBundlesString;
                    }
                    else if (DesiredAppointment.DesiredClientBalance != null)
                    {
                        SetDesignIfServiceOrPackageSelected();
                        LabelServiceBundle.Text = DesiredAppointment.DesiredClientBalance.ClientBalanceFullDetails;
                    }
                    else
                    {
                        SetDesignModeIfMultipleOrNoPackagesExist();
                    }
                }        
            }
            else//bet fout fiya bas eza update mode w awwal ma neftah el form
            {
                if (DesiredAppointment.DesiredClient != null)
                {
                    PackageRemainingsDt = Management.ClassClientBalance.GetClientBalanceNotExpiredPackage(DesiredAppointment.DesiredClient.ClientId);
                    OldPackageRemainingsDtDesiredClient = PackageRemainingsDt;
                    if (DesiredAppointment.DesiredClientBalance != null)
                    {
                        SetDesignIfServiceOrPackageSelected();
                        LabelServiceBundle.Text = DesiredAppointment.DesiredClientBalance.ClientBalanceFullDetails;
                    }
                    else if (DesiredAppointment.ChoseBundlesString != null && DesiredAppointment.ChosenBundlesList != null)
                    {
                        SetDesignIfServiceOrPackageSelected();
                        LabelServiceBundle.Text = DesiredAppointment.ChoseBundlesString;
                    }
                }
            }


            if (DesiredAppointment.DesiredClient != null)
            {
                OldClientId = DesiredAppointment.DesiredClient.ClientId;
            }
            else
            {
                OldClientId = -1;
            }
        }
        void SetDesignIfOthersMode()
        {
            textBoxSearch.PlaceholderText = "By name or phone (Optional)";
            textBoxSearch.IsRequiredModeOn = false;

            if (DesiredAppointment.DesiredClient != null)
            {
                textBoxSearch.Text = DesiredAppointment.DesiredClient.Fname + " " + DesiredAppointment.DesiredClient.Lname;
            }


            RemoveAllControlsAtRowIndex(TLPglobal, 2);
            TLPglobal.Controls.Add(textBoxTitle, 1, 2);

         
        }





        void SetDesignIfServiceOrPackageSelected()
        {
            RemoveAllControlsAtRowIndex(TLPglobal, 2);

            TLPglobal.Controls.Add(LabelServiceOutput, 0, 2);

            TLPglobal.Controls.Add(LabelServiceBundle, 1, 2);

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


            if (OldClientId != DesiredAppointment.DesiredClient.ClientId && NewClientIsAdded == false)
            {
                ChooseService chooseService = new ChooseService(this);
                chooseService.ShowDialog();
            }



        }





        public void FillObjectIfTitle(string Title)
        {
            DesiredAppointment.Title = Title;
        }
        public void FillObjectOfNewChosenBundles(List<ClassBundles> BundleList)
        {

            if (BundleList != null)
            {
                DesiredAppointment.ChosenBundlesList = new List<ClassBundles>(BundleList);
                //and chosenservice string is set automatically by default bel set tb3 ChosenServicesList

            }
            else
            {
                DesiredAppointment.ChosenBundlesList = null;
            }
        }
        public void FillObjectOfAvailablePackage(DataRow DesiredRow)//only used if we were selecting an available package ( a specified balance) from table sql clientbalance
        {

            if (DesiredRow != null)
            {
                DesiredAppointment.DesiredClientBalance = ClassClientBalance.CreateClientBalanceObject((int)PackageRemainingsDt.Rows[0]["ID"]);
                DesiredAppointment.DesiredClientBalance.SetStringDetailsIfBundle();         
            }
            else
            {
                DesiredAppointment.DesiredClientBalance = null;
            }

        }





        public void ResetDesiredAppointmentspecificValues()
        {
            DesiredAppointment.ChosenBundlesList = null;
            DesiredAppointment.DesiredClientBalance = null;
            DesiredAppointment.Title = null;
            OldPackageRemainingsDtDesiredClient = null;
        }




        private void ButtonChangeORChooseService_Click(object sender, EventArgs e)
        {
            ChooseService chooseService = new ChooseService(this);
            chooseService.ShowDialog();
        }





        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            Search searchname = new Search(textBoxSearch, DesiredAppointment.DesiredClient);
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
            DesiredAppointment.DesiredClient = searchname.NewDesiredClient;
            ResetDesiredAppointmentspecificValues();
            if (IsServiceOrOthersMode)//only eza kenna bel survice mode
            {
                SetDesignMode(false, false);
            }
        }
        private void Searchname_Deactivate(object sender, EventArgs e)
        {
            label1.Select();
        }





        private void IconProfile_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (Program.clientManagementProfile == null)
            {
                Program.clientManagementProfile = new ClientManagementProfile(ClassClient.CreateClientObject(DesiredAppointment.DesiredClient.ClientId), true);
            }
            else
            {
                Program.clientManagementProfile.LoadData(ClassClient.CreateClientObject(DesiredAppointment.DesiredClient.ClientId), true);
                // ma aam tozbat el formatdatatgrid men wara el show dialog, bas eemlna glitch bel event visible chnaged on the form
            }
            Program.clientManagementProfile.Size = new Size(1000, 659);
            Program.clientManagementProfile.FormBorderStyle = FormBorderStyle.Sizable;
            Program.clientManagementProfile.Tag = Program.clientManagementProfile;
            Program.clientManagementProfile.FormClosing += ClientManagementProfile_FormClosing;
            Program.clientManagementProfile.TopLevel = true;//ejbare
            Program.clientManagementProfile.ShowDialog();
            Cursor = Cursors.Default;

        }
        private void ClientManagementProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Program.clientManagementProfile.TopLevel = false;//ejbare kermel ma tsakkir li tahta
            Program.clientManagementProfile.Visible = false;
            Program.clientManagementProfile.FormClosing -= ClientManagementProfile_FormClosing;

            //in case we have changed the name
            DesiredAppointment.DesiredClient = Program.clientManagementProfile.Client;
            if (DesiredAppointment.DesiredClient == null)//means the client was deleted
            {
                ResetDesiredAppointmentspecificValues();
            }
            SetDesignMode(false, false);
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
                Program.NewRegisterForm = new NewRegister(null, true);
            }
            else
            {
                Program.NewRegisterForm.Resetcontrols();
                Program.NewRegisterForm.LoadForm(null, true);
            }
            Program.NewRegisterForm.ClientSavedEvent += NewRegisterForm_ClientSaved;
            Program.NewRegisterForm.ShowDialog();
        }
        private void NewRegisterForm_ClientSaved(object sender, EventArgs e)
        {
            NewRegister newRegister = (NewRegister)sender;
            DesiredAppointment.DesiredClient = newRegister.TheNewInsertedClient;
            ResetDesiredAppointmentspecificValues();
            NewClientIsAdded = true;//set
            SetDesignMode(false, false);//fi shi depends men hal value, open choose service
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
