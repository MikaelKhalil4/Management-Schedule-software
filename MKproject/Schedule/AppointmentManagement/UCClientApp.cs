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

namespace MKproject.Schedule
{
    public partial class UCClientApp : UserControl
    {

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

        public UCClientApp(ClassAppointment appointmentToUpdate)//used in appointment form
        {
            InitializeComponent();
            DesiredAppointment = appointmentToUpdate.Copy();
           
            if (DesiredAppointment.IdAppointment == null)//adding new appointment
            {
                SetDesignMode(null,false);
            }
            else//update form
            {
                SetDesignMode(null, true);
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

            LabelServiceOutput = new Label();
            LabelServiceOutput.Text = "Service:";
            LabelServiceOutput.Font = new Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            LabelServiceOutput.AutoSize = true;
            LabelServiceOutput.Margin = new Padding(0);
            LabelServiceOutput.Anchor = AnchorStyles.None;



            LabelServiceBundle = new Label();
            LabelServiceBundle.Font = new Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            LabelServiceBundle.AutoSize = true;
            LabelServiceBundle.Margin = new Padding(0);
            LabelServiceBundle.Anchor = AnchorStyles.Left;

            //LabelServiceBalance = new Label();
            //LabelServiceBalance.Font = new Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            //LabelServiceBalance.AutoSize = true;
            //LabelServiceBalance.Margin = new Padding(0);
            //LabelServiceBalance.Anchor = AnchorStyles.Left;


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
            LabelNoDataRecorded.Margin = new Padding(5, 0, 5, 0);


            pictureBoxSearch = new PictureBox();
            pictureBoxSearch.Size = new Size(25, 25);
            pictureBoxSearch.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "search2.png");
            pictureBoxSearch.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxSearch.Anchor = AnchorStyles.Right;
        }


        void SetDesignIfServiceOrPackageSelected()//sous level design, lamma naee service maayane it will b called
        {

            if (!TLPglobal.Controls.Contains(LabelServiceBundle))
            {
                TLPglobal.Controls.Add(LabelServiceBundle, 1, 1);
            }
            TLPglobal.SetColumn(ButtonChangeORChooseService, 2);
            TLPglobal.SetRow(ButtonChangeORChooseService, 1);
            ButtonChangeORChooseService.Text = "Change";

        }

        void SetDesignModeIfMultiplePackagesExist()
        {
            if (TLPglobal.Controls.Contains(LabelServiceBundle))
            {
                TLPglobal.Controls.Remove(LabelServiceBundle);
            }
            TLPglobal.SetColumn(ButtonChangeORChooseService, 1);
            TLPglobal.SetRow(ButtonChangeORChooseService, 1);


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
      
        public void SetDesignMode(bool? IsNewServiceOrOneOfMultipleIsSelected, bool IsUpdateAndCallingFromConstruction)//high level design/ w the param, huuwe not null lamma na2e shi men el choose el service
        {

            //Design Higher level
            if (DesiredAppointment.DesiredClient != null)
            {
                textBoxSearch.Text = DesiredAppointment.DesiredClient.Fname + " " + DesiredAppointment.DesiredClient.Lname;
                if (TLPglobal.Controls.Contains(LabelNoDataRecorded))
                {
                    pictureBoxSearch.Dispose();
                    LabelNoDataRecorded.Dispose();
                    LabelNoDataRecorded = null;
                    pictureBoxSearch = null;
                }
                if (!TLPglobal.Controls.Contains(IconProfile) && !TLPglobal.Controls.Contains(LabelServiceOutput) && !TLPglobal.Controls.Contains(ButtonChangeORChooseService))
                {
                    CreatingTheClientModeOn();
                    TLPglobal.Controls.Add(IconProfile, 0, 0);
                    TLPglobal.Controls.Add(LabelServiceOutput, 0, 1);
                    TLPglobal.Controls.Add(ButtonChangeORChooseService);
                }
            }
            else
            {
                if (TLPglobal.Controls.Contains(IconProfile))
                {
                    TLPglobal.Controls.Remove(IconProfile);
                    TLPglobal.Controls.Remove(ButtonChangeORChooseService);
                    TLPglobal.Controls.Remove(LabelServiceOutput);
                    TLPglobal.Controls.Remove(LabelServiceBundle);
                }
                if (LabelNoDataRecorded == null)
                {

                    CreatingTheClientModeOff();
                    TLPglobal.Controls.Add(pictureBoxSearch, 0, 0);

                    TLPglobal.Controls.Add(LabelNoDataRecorded, 0, 1);
                    TLPglobal.SetRowSpan(LabelNoDataRecorded, 2);
                    TLPglobal.SetColumnSpan(LabelNoDataRecorded, 5);
                }

                textBoxSearch.Text = textBoxSearch.PlaceholderText;
                pictureBoxSearch.Select();
            }


            if (DesiredAppointment.DesiredClient != null)
            {
                OldClientId = DesiredAppointment.DesiredClient.ClientId;
            }
            else
            {
                OldClientId = -1;
            }


            if (!IsUpdateAndCallingFromConstruction)
            {
                if (DesiredAppointment.DesiredClient != null)
                {
                    if (IsNewServiceOrOneOfMultipleIsSelected == null)
                    {
                        //Sql
                        PackageRemainingsDt = Management.SQLToProject.GetClientBalanceNotExpiredPackage(DesiredAppointment.DesiredClient.ClientId);

                        if (DesiredAppointment.ChosenServicesList == null)//in case ma kenet mnaea wala service
                        {
                            if (OldPackageRemainingsDtDesiredClient == null || !AreTablesTheSame(OldPackageRemainingsDtDesiredClient, PackageRemainingsDt))//after choosing a client, old=null ha nfout/ w eza ghayarna shi bel packages tb3 profile ha nfout
                            {

                                OldPackageRemainingsDtDesiredClient = PackageRemainingsDt.Copy();

                                //chosing the right service
                                if (PackageRemainingsDt.Rows.Count == 1)
                                {
                                    SetDesignIfServiceOrPackageSelected();
                                    FillObjectAndDesignOfAvailablePackage(PackageRemainingsDt.Rows[0]);
                                }
                                else //no packages or multiple packages
                                {
                                    if (PackageRemainingsDt.Rows.Count > 1)//mutiple packages
                                    {
                                        if (DesiredAppointment.DesiredClientBalance == null)//fi kaza package w mesh mnaeyin wala wahad abel
                                        {

                                            SetDesignModeIfMultiplePackagesExist();

                                        }
                                        else//fi kaza package bas mna2yin wahad already, w hayda el wahad mnerjaa mnaamelo update always, maybe ghayrna shi fi aw mayble shelne men el profile
                                        {
                                            DataRow[] selectedRows = PackageRemainingsDt.Select("ID =" + DesiredAppointment.DesiredClientBalance.ClientBalanceID);
                                            if (selectedRows.Length == 1)
                                            {
                                                FillObjectAndDesignOfAvailablePackage(selectedRows[0]);
                                            }
                                            else//in case ken fi selected package, w shelne men profil
                                            {
                                                SetDesignModeIfMultiplePackagesExist();
                                            }
                                        }
                                    }
                                    else//no packages at all
                                    {
                                        SetDesignModeIfMultiplePackagesExist();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        SetDesignIfServiceOrPackageSelected();
                    }
                }

            }
            else//bet fout fiya bas eza update mode w awwal ma neftah el form
            {
                if (DesiredAppointment.DesiredClient != null)
                {
                    PackageRemainingsDt = Management.SQLToProject.GetClientBalanceNotExpiredPackage(DesiredAppointment.DesiredClient.ClientId);
                    OldPackageRemainingsDtDesiredClient = PackageRemainingsDt;
                    if (DesiredAppointment.DesiredClientBalance != null)
                    {
                        SetDesignIfServiceOrPackageSelected();
                        LabelServiceBundle.Text = DesiredAppointment.DesiredClientBalance.ClientBalanceFullDetails;
                    }
                    else if (DesiredAppointment.ChosenServicesDetails != null && DesiredAppointment.ChosenServicesList != null)
                    {
                        SetDesignIfServiceOrPackageSelected();
                        LabelServiceBundle.Text = DesiredAppointment.ChosenServicesDetails;
                    }
                }
            }
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



        public void FillObjectAndDesignOfNewServices()
        {
            string details = "";
            foreach (ClassBundles Bundle in DesiredAppointment.ChosenServicesList)
            {
                details += Bundle.Name + "/";
            }
            if (details.Length > 0)
            {
                details = details.Remove(details.Length - 1);
            }
            DesiredAppointment.ChosenServicesDetails = details;
            LabelServiceBundle.Text = DesiredAppointment.ChosenServicesDetails;
        }

        public void FillObjectAndDesignOfAvailablePackage(DataRow DesiredRow)//only used if we were selecting an available package ( a specified balance) from table sql clientbalance
        {
            //Filling the object

            //Number Of Sessions or days
            string ServiceName;
            ServiceName = (string)DesiredRow["Description"];
            DesiredAppointment.DesiredClientBalance = new ClassChosenClientBalance();
            DesiredAppointment.DesiredClientBalance.ClientBalanceID = Convert.ToInt32(DesiredRow["ID"]);
            //sessionleft
            if (DesiredRow["due_date"] == DBNull.Value)//package of sessions
            {
                DesiredAppointment.DesiredClientBalance.ISSessionsOrDays = true;
                DesiredAppointment.DesiredClientBalance.SessionLeft = Convert.ToInt32(DesiredRow["session_left_days"]);
                DesiredAppointment.DesiredClientBalance.ClientBalanceSessionLeftDetails = DesiredRow["session_left_days"] + " sess";
            }
            else if (DesiredRow["due_date"] != DBNull.Value)//package of days
            {
                DesiredAppointment.DesiredClientBalance.ISSessionsOrDays = false;

                if ((bool)DesiredRow["is_freezed"] == false)//only packgae of days not freezed
                {
                    int daysLeft = RandomFunctions.GetDaysDifference(DateTime.Now, (DateTime)DesiredRow["due_date"]);
                    if (daysLeft < 0)
                    {
                        daysLeft = 0;
                    }
                    DesiredAppointment.DesiredClientBalance.ClientBalanceSessionLeftDetails = daysLeft + " days";//tene wahde - awwal wahde
                }
                else//package days freezed
                {
                    ServiceName += "(Freezed)";
                }

            }

            //balance
            DesiredAppointment.DesiredClientBalance.ClientBalanceDetails = ClassChosenClientBalance.SetBalanceFormat(DesiredRow["balance"].ToString());
            DesiredAppointment.DesiredClientBalance.ClientBalanceFullDetails = ServiceName + ": " + DesiredAppointment.DesiredClientBalance.ClientBalanceSessionLeftDetails + " / " + DesiredAppointment.DesiredClientBalance.ClientBalanceDetails;

            //design
            LabelServiceBundle.Text = DesiredAppointment.DesiredClientBalance.ClientBalanceFullDetails;

        }




        private void ButtonChangeORChooseService_Click(object sender, EventArgs e)
        {
            ChooseService chooseService = new ChooseService(this);
            chooseService.ShowDialog();
        }



        public void ResetDesiredAppointmentspecificValues()
        {
            DesiredAppointment.ChosenServicesList = null;
            DesiredAppointment.ChosenServicesDetails = null;
            DesiredAppointment.DesiredClientBalance = null;
            OldPackageRemainingsDtDesiredClient = null;
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
            SetDesignMode(null, false);

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
            SetDesignMode(null, false);
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
            SetDesignMode(null, false);//fi shi depends men hal value, open choose service
            NewClientIsAdded = false;//reset
            Program.NewRegisterForm.FormClosed -= NewRegisterForm_ClientSaved;
        }
        private void TLPAddNewClient_MouseMove(object sender, MouseEventArgs e)
        {
            TLPAddNewClient.BackColor = Color.FromArgb(Program.BoldColor.R + 20, Program.BoldColor.G + 20, Program.BoldColor.B + 20);
        }
        private void TLPAddNewClient_MouseLeave(object sender, EventArgs e)
        {
            TLPAddNewClient.BackColor = Program.BoldColor;
        }
    }
}
