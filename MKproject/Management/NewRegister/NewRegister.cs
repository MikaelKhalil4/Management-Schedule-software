
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FontStyle = System.Drawing.FontStyle;
using Size = System.Drawing.Size;
using MessageBox = System.Windows.Forms.MessageBox;
using GlobalFunctions;
using CustomizedTools;
using static MKproject.Management.ClassClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static MKproject.ClassClientCustom;

namespace MKproject.Management
{
    public partial class NewRegister : Form
    {
        public ClientManagementProfile ClientManagementProfileForm;
        public SearchCurrentClient SearchCurrentClientForm { get; set; }

        public DataTable dtUpdatedFields;//men hot fiya l fields bass n3adil l fields bi RegistrationFields
        bool IsChildMode;
        bool ISCallingFromTheConstructor;//ha kermerl ma teftahe el childparent form awwal ma nealli el from
        public int? ParentId;//exists only in case naeayna parent    
        bool PicHasChanged;//hayde kermel nestaamela eza el sura ma tghayyirit ma naamela upload
        int ControlsWidthInsideFLP;

        private bool parent_chosen;//lamma na2e parent lal child a parent w erjaa aal register el form  , el parent_chose bet sir true kermel lamma naamil save, ma nshayyik eza fi duplicates phonenumber
        public bool ParentChosen
        {
            get { return parent_chosen; }
            set { parent_chosen = value; }
        }




        private LabelWithIndex labelSportlInfo;
        private LabelWithIndex labelPersonalInfo;


        //Static
        private UCCamera UCProfileImage;
        private UCDoubleUCTextbox UCNamefamilyname;
        public UCTextbox1 UCPhoneNumber;
        private UCTextbox1 UCInsta;
        private UCTextbox1 UCJob;
        private UCTextbox1 UCAdress;
        private UCTextbox1 UCNotes;
        private UCTextbox1 UCEmail;
        private TLPOtherOptions UCBirthDate;
        private TLPCheckboxesAndRadioOptions UCGender;
        private TLPCheckboxesAndRadioOptions TLPMaritalstatus;
        private TLPCheckboxesAndRadioOptions TLPKnowaboutus;





        public ClassClientCustomFront classClientCustomFront { get; set; }




        public ClassClientCustom Client;//used for updates
        public ClassClientCustom TheNewInsertedClient;//used when we insert a client , we access it from the schedule or other external forms , with the help of the event ClientSavedEvent


        private List<UCTextbox1> TextBoxes = new List<UCTextbox1> { };
        public List<Control> RequiredControls = new List<Control> { };

        bool IsFromSchedule;

        public event EventHandler ClientSavedEvent;


        public NewRegister(ClassClientCustom Clients, bool isclientFromSchedule)
        {
            InitializeComponent();
            this.Size = new Size();
            this.Opacity = 0;
            this.Size = new Size(660, 670);//kell shi aam nhotoo juwwa aam naamela width=600, which is not accurate, try bi wpf taamil dock top
            ControlsWidthInsideFLP = 600;



            classClientCustomFront = new ClassClientCustomFront();
            classClientCustomFront.ExtentionNewRegister = this;//ejabre foe LoadForm

            LoadForm(Clients, isclientFromSchedule);


        }

        public void LoadForm(ClassClientCustom Clients, bool isclientFromSchedule)
        {
            ClientSavedEvent = null;
            radioButtonAdult.Checked = true;
            ClientManagementProfileForm = null;
            SearchCurrentClientForm = null;
            IsChildMode = false;
            ParentId = null;
            PicHasChanged = false;
            ParentChosen = false;
            ISCallingFromTheConstructor = true;

            IsFromSchedule = isclientFromSchedule;
            Client = Clients;


            if (Client != null)//update form
            {
                ISCallingFromTheConstructor = true;
                OpenUpdateOrInsertClient(true);

            }
            else
            {
                OpenUpdateOrInsertClient(false);
                radioButtonAdult.Checked = true;
            }

            UpdateOrCreateFields(false);//ejbare hone mahalla
            ISCallingFromTheConstructor = false;

            this.Opacity = 0;
            timer1.Start();
        }


        void OpenUpdateOrInsertClient(bool IsUpdateOrInsert)
        {
            if (IsUpdateOrInsert)
            {

                buttonAddToAlbumAndSave.Visible = false;
                buttonDelete.Visible = true;
                buttonSave.Text = "Update";

                if (Client.IsChild)
                    radioButtonChild.Checked = true;
                else
                    radioButtonAdult.Checked = true;
            }

            else
            {
                buttonAddToAlbumAndSave.Visible = true;
                buttonDelete.Visible = false;
                buttonSave.Text = "Save";
            }

        }
        public void OpenAsChildDesign(string familyName, string phoneNumber, string adress)//when we choose a parent
        {
            radioButtonChild.Checked = true;
            //famName
            if (UCNamefamilyname != null && familyName != null)
            {
                UCNamefamilyname.ucTextbox2.FillDesignValue(familyName);
            }
            //Adress
            if (UCAdress != null && adress != null)//sinceha el wahide li ma32oul ma ykun fiya value
            {
                UCAdress.FillDesignValue(adress);
            }

            //phone number
            if (UCPhoneNumber != null && phoneNumber != null)
            {
                UCPhoneNumber.FillDesignValue(phoneNumber);
                UCPhoneNumber.DisableUC();

            }



        }




        DateTimePicker CreateDateTimePicker()
        {

            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.CloseUp += event_RemoveSelection;
            dateTimePicker.Font = new Font("Segoe UI ", 11.5f);
            dateTimePicker.Cursor = Cursors.Hand;
            dateTimePicker.Size = new Size(267, 27);
            dateTimePicker.Value = DateTime.Today;
            dateTimePicker.MaxDate = DateTime.Now;
            return dateTimePicker;

        }
        public void event_RemoveSelection(object sender, EventArgs e)
        {
            labelAdultOrChild.Focus();
        }



        public void UpdateOrCreateFields(bool IsUpdateOrCreate)
        {

            Cursor.Current = Cursors.WaitCursor;
            DataTable dt;

            dt = SQLToProject.GetAllVisibleFields();


            foreach (DataRow row in dt.Rows)
            {
                bool isRequired = Convert.ToBoolean(row["Required"]);
                bool isVisible = Convert.ToBoolean(row["Visible"]);
                string FieldName = row["Fields"].ToString();

                // Check if the "Full Name" field exists in the table

                //Static
                if (FieldName == enumStaticFields.FullName.ToString())
                {
                    if (isVisible)
                    {
                        if (UCNamefamilyname == null)
                        {
                            UCNamefamilyname = new UCDoubleUCTextbox("Name", "Family Name", true);//ejbare true, idc abt the sql                    
                            UCNamefamilyname.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCNamefamilyname);
                        }
                        else
                        {
                            //if (isRequired && !UCNamefamilyname.IsRequired)
                            //{
                                UCNamefamilyname.IsRequired = true;//always
                            //}
                            //else if (!isRequired && UCNamefamilyname.IsRequired)
                            //{
                            //    UCNamefamilyname.IsRequired = false;
                            //}
                        }

                        if (Client != null && Client.Fname != null && Client.Lname != null)
                            UCNamefamilyname.FillDesignValue(Client.Fname, Client.Lname);

                        UCNamefamilyname.Index = (int)enumStaticFields.FullName;
                    }
                    else
                    {
                        if (UCNamefamilyname != null)
                        {

                            this.Controls.Remove(UCNamefamilyname);
                            UCNamefamilyname.Dispose();
                            UCNamefamilyname = null;
                        }
                    }

                }
                else if (FieldName == enumStaticFields.PhoneNumber.ToString())
                {
                    if (isVisible)
                    {
                        if (UCPhoneNumber == null)
                        {
                            UCPhoneNumber = new UCTextbox1(enumStaticFields.PhoneNumber.ToString(), true);//ejbare true, idc abt the sql
                            UCPhoneNumber.IsPhoneNumber = true;
                            UCPhoneNumber.textboxtextchange += UCPhoneNumber_textboxtextchange;

                            UCPhoneNumber.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCPhoneNumber);

                        }
                        else
                        {
                            //if (isRequired && !UCPhoneNumber.IsRequired)
                            //{
                                UCPhoneNumber.IsRequired = true;//always
                            //}
                            //else if (!isRequired && UCPhoneNumber.IsRequired)
                            //{
                            //    UCPhoneNumber.IsRequired = false;
                            //}
                        }

                        if (Client != null && Client.PhoneNumber != null)//to fill the info if i am editing a client
                        {
                            UCPhoneNumber.FillDesignValue(Client.PhoneNumber);

                            if (Client.IsChild == true)//yaane only lamma neftah el update el form w ykun child
                            {
                                UCPhoneNumber.DisableUC();
                            }
                        }
                        UCPhoneNumber.Index = (int)enumStaticFields.PhoneNumber;

                    }
                    else
                    {
                        if (UCPhoneNumber != null)
                        {

                            this.Controls.Remove(UCPhoneNumber);
                            UCPhoneNumber.Dispose();
                            UCPhoneNumber = null;
                        }
                    }
                }
                else if (FieldName == ClassClient.enumStaticFields.Gender.ToString())
                {
                    if (isVisible)
                    {
                        if (UCGender == null)
                        {
                            UCGender = new TLPCheckboxesAndRadioOptions(ClassClient.enumStaticFields.Gender.GetStringValue(), isRequired, false, null, ClassClient.enumGender.Male.GetStringValue(), ClassClient.enumGender.Female.GetStringValue(), true);
                            UCGender.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCGender);
                        }
                        else
                        {
                            if (isRequired && !UCGender.IsRequired)
                            {
                                UCGender.IsRequired = true;
                            }
                            else if (!isRequired && UCGender.IsRequired)
                            {
                                UCGender.IsRequired = false;
                            }
                        }
                        if (Client != null && Client.Gender != null)//to fill the info if i am editing a client
                        {
                            UCGender.FillDesignValues(Client.Gender);
                        }
                        UCGender.Index = (int)enumStaticFields.Gender;

                    }
                    else
                    {
                        if (UCGender != null)
                        {

                            this.Controls.Remove(UCGender);
                            UCGender.Dispose();
                            UCGender = null;
                        }
                    }
                }

                else if (FieldName == enumStaticFields.BirthDate.ToString())
                {
                    if (isVisible)
                    {
                        if (UCBirthDate == null)
                        {
                            UCBirthDate = new TLPOtherOptions(enumStaticFields.BirthDate.GetStringValue(), isRequired, CreateDateTimePicker());
                            UCBirthDate.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCBirthDate);
                        }
                        else
                        {
                            if (isRequired && !UCBirthDate.IsRequired)
                            {
                                UCBirthDate.IsRequired = true;
                            }
                            else if (!isRequired && UCBirthDate.IsRequired)
                            {
                                UCBirthDate.IsRequired = false;
                            }
                        }

                        if (Client != null && Client.BirthDate != null)
                            UCBirthDate.FillDesignValues(Client.BirthDate.ToString());

                        UCBirthDate.Index = (int)enumStaticFields.BirthDate;

                    }
                    else
                    {
                        if (UCBirthDate != null)
                        {

                            this.Controls.Remove(UCBirthDate);
                            UCBirthDate.Dispose();
                            UCBirthDate = null;
                        }
                    }

                }

              

                else if (FieldName == enumStaticFields.Job.ToString())
                {
                    if (isVisible)
                    {

                        if (UCJob == null)
                        {
                            UCJob = new UCTextbox1(enumStaticFields.Job.ToString(), isRequired);
                            UCJob.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCJob);


                        }
                        else
                        {
                            if (isRequired && !UCJob.IsRequired)
                            {
                                UCJob.IsRequired = true;
                            }
                            else if (!isRequired && UCJob.IsRequired)
                            {
                                UCJob.IsRequired = false;
                            }
                        }
                        if (Client != null && Client.Job != null)//to fill the info if i am editing a client
                        {
                            UCJob.FillDesignValue(Client.Job);
                        }
                        UCJob.Index = (int)enumStaticFields.Job;

                    }
                    else
                    {
                        if (UCJob != null)
                        {

                            this.Controls.Remove(UCJob);
                            UCJob.Dispose();
                            UCJob = null;
                        }
                    }
                }

                else if (FieldName == enumStaticFields.Adress.ToString())
                {
                    if (isVisible)
                    {
                        if (UCAdress == null)
                        {
                            UCAdress = new UCTextbox1(enumStaticFields.Adress.ToString(), isRequired);
                            UCAdress.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCAdress);
                        }

                        else
                        {
                            if (isRequired && !UCAdress.IsRequired)
                            {
                                UCAdress.IsRequired = true;
                            }
                            else if (!isRequired && UCAdress.IsRequired)
                            {
                                UCAdress.IsRequired = false;
                            }
                        }
                        if (Client != null && Client.Adress != null)//to fill the info if i am editing a client
                        {
                            UCAdress.FillDesignValue(Client.Adress);
                        }
                        UCAdress.Index = (int)enumStaticFields.Adress;

                    }
                    else
                    {
                        if (UCAdress != null)
                        {

                            this.Controls.Remove(UCAdress);
                            UCAdress.Dispose();
                            UCAdress = null;
                        }
                    }
                }

                else if (FieldName == enumStaticFields.InstaUserName.ToString())
                {

                    if (isVisible)
                    {
                        if (UCInsta == null)
                        {
                            UCInsta = new UCTextbox1(enumStaticFields.InstaUserName.GetStringValue(), isRequired);
                            UCInsta.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCInsta);


                        }
                        else
                        {
                            if (isRequired && !UCInsta.IsRequired)
                            {
                                UCInsta.IsRequired = true;
                            }
                            else if (!isRequired && UCInsta.IsRequired)
                            {
                                UCInsta.IsRequired = false;
                            }
                        }
                        if (Client != null && Client.InstaUserName != null)//to fill the info if i am editing a client
                        {
                            UCInsta.FillDesignValue(Client.InstaUserName);
                        }
                        UCInsta.Index = (int)enumStaticFields.InstaUserName;

                    }
                    else
                    {
                        if (UCInsta != null)
                        {

                            this.Controls.Remove(UCInsta);
                            UCInsta.Dispose();
                            UCInsta = null;
                        }
                    }
                }

                else if (FieldName == enumStaticFields.Note.ToString())
                {
                    if (isVisible)
                    {
                        if (UCNotes == null)
                        {
                            UCNotes = new UCTextbox1(enumStaticFields.Note.ToString(), isRequired);
                            UCNotes.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCNotes);
                        }
                        else
                        {
                            if (isRequired && !UCNotes.IsRequired)
                            {
                                UCNotes.IsRequired = true;
                            }
                            else if (!isRequired && UCNotes.IsRequired)
                            {
                                UCNotes.IsRequired = false;
                            }
                        }
                        if (Client != null && Client.Note != null)//to fill the info if i am editing a client
                        {
                            UCNotes.FillDesignValue(Client.Note);
                        }
                        UCNotes.Index = (int)enumStaticFields.Note;

                    }
                    else
                    {
                        if (UCNotes != null)
                        {

                            this.Controls.Remove(UCNotes);
                            UCNotes.Dispose();
                            UCNotes = null;
                        }
                    }
                }

                else if (FieldName == enumStaticFields.Email.ToString())
                {
                    if (isVisible)
                    {
                        if (UCEmail == null)
                        {
                            UCEmail = new UCTextbox1(enumStaticFields.Email.ToString(), isRequired);
                            UCEmail.IsEmail = true;
                            UCEmail.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCEmail);
                        }
                        else
                        {
                            if (isRequired && !UCEmail.IsRequired)
                            {
                                UCEmail.IsRequired = true;
                            }
                            else if (!isRequired && UCEmail.IsRequired)
                            {
                                UCEmail.IsRequired = false;
                            }
                        }

                        if (Client != null && Client.Email != null)//to fill the info if i am editing a client
                        {
                            UCEmail.FillDesignValue(Client.Email);
                        }
                        UCEmail.Index = (int)enumStaticFields.Email;

                    }
                    else
                    {
                        if (UCEmail != null)
                        {

                            this.Controls.Remove(UCEmail);
                            UCEmail.Dispose();
                            UCEmail = null;
                        }
                    }
                }

                else if (FieldName == enumStaticFields.ProfileImage.ToString())
                {
                    if (isVisible)
                    {
                        if (UCProfileImage == null)
                        {
                            UCProfileImage = new UCCamera("Profile Picture", isRequired);
                            UCProfileImage.Tag = this;
                            UCProfileImage.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCProfileImage);
                        }
                        else
                        {
                            if (isRequired && !UCProfileImage.IsRequired)
                            {
                                UCProfileImage.IsRequired = true;
                            }
                            else if (!isRequired && UCProfileImage.IsRequired)
                            {
                                UCProfileImage.IsRequired = false;
                            }
                        }

                        if (Client != null && Client.ProfileImage != null)
                        {
                            UCProfileImage.FillDesignValues(Client.ProfileImage);
                        }

                        UCProfileImage.Index = (int)enumStaticFields.ProfileImage;

                    }
                    else
                    {
                        if (UCProfileImage != null)
                        {

                            this.Controls.Remove(UCProfileImage);
                            UCProfileImage.Dispose();
                            UCProfileImage = null;
                        }
                    }
                }
                else if (FieldName == enumStaticFields.MaritalStatus.ToString())
                {
                    if (isVisible)
                    {
                        if (TLPMaritalstatus == null)
                        {
                            List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };
                            foreach (enumMaritalStatus enumValue in Enum.GetValues(typeof(enumMaritalStatus)))
                            {
                                if (enumValue == enumMaritalStatus.HaveChildren)
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), new UCNumberButt(), "1"));
                                }
                                else
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), null, null));
                                }

                            }

                            TLPMaritalstatus = new TLPCheckboxesAndRadioOptions(enumStaticFields.MaritalStatus.GetStringValue(), isRequired, true, ListOptions, null, null, true);
                            TLPMaritalstatus.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(TLPMaritalstatus);

                        }
                        else
                        {
                            if (isRequired && !TLPMaritalstatus.IsRequired)
                            {
                                TLPMaritalstatus.IsRequired = true;
                            }
                            else if (!isRequired && TLPMaritalstatus.IsRequired)
                            {
                                TLPMaritalstatus.IsRequired = false;
                            }

                        }
                        if (Client != null && Client.MaritalStatus != null)
                        {
                            TLPMaritalstatus.FillDesignValues(Client.MaritalStatus);
                        }
                        TLPMaritalstatus.Index = (int)enumStaticFields.MaritalStatus;

                    }
                    else
                    {
                        if (TLPMaritalstatus != null)
                        {

                            Controls.Remove(TLPMaritalstatus);
                            TLPMaritalstatus.Dispose();
                            TLPMaritalstatus = null;
                        }
                    }
                }
                else if (FieldName == enumStaticFields.HowDidYouKnowAboutUs.ToString())
                {
                    if (isVisible)
                    {
                        if (TLPKnowaboutus == null)
                        {


                            List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };
                            foreach (enumInsta enumValue in Enum.GetValues(typeof(enumInsta)))
                            {
                                if (enumValue == enumInsta.CustomerMention)
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), new TextBoxWithPlaceHolder(), "Customer Name"));
                                }
                                else
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), null, null));
                                }
                            }
                            TLPCheckboxesAndRadioOptions UCInsta = new TLPCheckboxesAndRadioOptions(null, null, true, ListOptions, null, null, false);


                            ListOptions = new List<(string, Control, string)> { };
                            foreach (enumHowDidYouKnowAboutUs enumValue in Enum.GetValues(typeof(enumHowDidYouKnowAboutUs)))
                            {
                                if (enumValue == enumHowDidYouKnowAboutUs.instagram)
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), UCInsta, ""));
                                }
                                else if (enumValue == enumHowDidYouKnowAboutUs.BoucheAOreille)
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), new TextBoxWithPlaceHolder(), "Person Name"));
                                }
                                else if (enumValue == enumHowDidYouKnowAboutUs.Others)
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), new TextBoxWithPlaceHolder(), ""));
                                }
                                else
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), null, null));
                                }
                            }

                            TLPKnowaboutus = new TLPCheckboxesAndRadioOptions(enumStaticFields.HowDidYouKnowAboutUs.GetStringValue(), isRequired, true, ListOptions, null, null, true);
                            TLPKnowaboutus.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(TLPKnowaboutus);

                        }
                        else
                        {
                            if (isRequired && !TLPKnowaboutus.IsRequired)
                            {
                                TLPKnowaboutus.IsRequired = true;
                            }
                            else if (!isRequired && TLPKnowaboutus.IsRequired)
                            {
                                TLPKnowaboutus.IsRequired = false;
                            }

                        }

                        if (Client != null && Client.KnowAboutUs != null)
                        {
                            TLPKnowaboutus.FillDesignValues(Client.KnowAboutUs);
                        }
                        TLPKnowaboutus.Index = (int)enumStaticFields.HowDidYouKnowAboutUs;

                    }
                    else
                    {
                        if (TLPKnowaboutus != null)
                        {

                            Controls.Remove(TLPKnowaboutus);
                            TLPKnowaboutus.Dispose();
                            TLPKnowaboutus = null;
                        }
                    }
                }
                classClientCustomFront.UpdateOrCreateFields(FieldName, isVisible, isRequired, ControlsWidthInsideFLP, Client, FLPInfo);

            }

            if (IsUpdateOrCreate)
            {
                dtUpdatedFields = null;
            }

            if (labelPersonalInfo == null)
            {
                labelPersonalInfo = new LabelWithIndex();
                labelPersonalInfo.Text = "Personal Informations";
                labelPersonalInfo.Font = new System.Drawing.Font("Segoe UI", 14, FontStyle.Bold | FontStyle.Italic);
                labelPersonalInfo.ForeColor = Color.Black;
                labelPersonalInfo.TextAlign = ContentAlignment.MiddleCenter;
                labelPersonalInfo.AutoSize = false;
                labelPersonalInfo.Size = new System.Drawing.Size(605, 38);
                labelPersonalInfo.Margin = new Padding(3, 3, 3, 3);
                FLPInfo.Controls.Add(labelPersonalInfo);
            }

            labelPersonalInfo.Index = 0;


            if (Enum.GetValues(typeof(enumDynamicFields)).Length > 0)
            {
                if (labelSportlInfo == null)
                {
                    labelSportlInfo = new LabelWithIndex();
                    labelSportlInfo.Text = "Business Informations";
                    labelSportlInfo.Font = new System.Drawing.Font("Segoe UI", 14, FontStyle.Bold | FontStyle.Italic);
                    labelSportlInfo.ForeColor = Color.Black;
                    labelSportlInfo.TextAlign = ContentAlignment.MiddleCenter;
                    labelSportlInfo.AutoSize = false;
                    labelSportlInfo.Size = new System.Drawing.Size(605, 38);
                    labelSportlInfo.Margin = new Padding(3, 3, 3, 3);
                    FLPInfo.Controls.Add(labelSportlInfo);
                }

                labelSportlInfo.Index = 100;

            }




            ResetIndex();
            Cursor.Current = Cursors.Default;

        }//try catch
      
        
        void ResetIndex()
        {
            // Get all controls within the FlowLayoutPanel
            List<Control> controls = FLPInfo.Controls.Cast<Control>().ToList();

            // Sort the controls based on their "Index" property in ascending order
            controls.Sort((a, b) => ((Int32)a.GetType().GetProperty("Index").GetValue(a)).CompareTo((Int32)b.GetType().GetProperty("Index").GetValue(b)));

            // Assign new indexes in ascending order
            for (int i = 0; i < controls.Count; i++)
            {

                controls[i].GetType().GetProperty("Index").SetValue(controls[i], i);



                if (i < controls.Count - 1)
                {
                    if (controls[i] is UCTextbox1 || controls[i] is UCDoubleUCTextbox)
                    {
                        //we need to handle baaed el name w famname
                        if (controls[i + 1] is UCTextbox1)
                        {
                            controls[i].GetType().GetProperty("ParentOfNextControl").SetValue(controls[i], ((UCTextbox1)controls[i + 1]).groupBox1);
                            controls[i].GetType().GetProperty("NextControl").SetValue(controls[i], ((UCTextbox1)controls[i + 1]).myTextBox1);


                        }
                        else if (controls[i + 1] is UCDoubleUCTextbox)
                        {

                            controls[i].GetType().GetProperty("ParentOfNextControl").SetValue(controls[i], ((UCDoubleUCTextbox)controls[i + 1]).ucTextbox1.groupBox1);
                            controls[i].GetType().GetProperty("NextControl").SetValue(controls[i], ((UCDoubleUCTextbox)controls[i + 1]).ucTextbox1.myTextBox1);


                        }
                        else
                        {

                            controls[i].GetType().GetProperty("NextControl").SetValue(controls[i], controls[i + 1]);

                        }
                    }
                }

            }

            // Update the FlowLayoutPanel's control collection with the sorted controls
            FLPInfo.Controls.Clear();
            FLPInfo.Controls.AddRange(controls.ToArray());
        }




        public void UpdateOrInsertToSQLAndObj(string AlbumType)
        {
            Cursor.Current = Cursors.WaitCursor;



            ClassClientCustom UpdatedOrNewClient = new ClassClientCustom();//only used bel insert client
            if (Client != null)//update
            {
                //in this case mnekhlae new object UpdatedOrNewClient w ekhir shi mnaamello replace eza ma sar fi wala crash

                bool OldISChild = Client.IsChild;
                if (radioButtonAdult.Checked)
                {
                    UpdatedOrNewClient.IsChild = false;
                }
                else
                {
                    UpdatedOrNewClient.IsChild = true;
                }

                string OldPhoneNumbre = Client.PhoneNumber;
                if (UCPhoneNumber != null)//ejbare el phone number ykun foe el check is parent
                {
                    UpdatedOrNewClient.PhoneNumber = UCPhoneNumber.Value;
                }


                if (UCProfileImage != null)
                {
                    if (Client.ProfileImage != UCProfileImage.ValueImage)
                    {
                        PicHasChanged = true;
                    }
                    else
                    {
                        PicHasChanged = false;
                    }
                    UpdatedOrNewClient.ProfileImage = UCProfileImage.ValueImage;
                }

            }
            else//insert mode
            {
                UpdatedOrNewClient.IsChild = true;
                UpdatedOrNewClient.IsParent = false;
                UpdatedOrNewClient.AlbumType = AlbumType;


                if (radioButtonAdult.Checked)
                {
                    UpdatedOrNewClient.IsChild = false;
                }
                else
                {
                    UpdatedOrNewClient.IsChild = true;
                }

                if (UCPhoneNumber != null)
                {
                    UpdatedOrNewClient.PhoneNumber = UCPhoneNumber.Value;
                }

                if (UCProfileImage != null)
                {
                    UpdatedOrNewClient.ProfileImage = UCProfileImage.ValueImage;
                }
            }



            //common section for both
            if (UCGender != null)
            {
                UpdatedOrNewClient.Gender = UCGender.Value;
            }

            if (UCBirthDate != null)
            {
                if (UCBirthDate.Value != null)//bas hone eemelna hek cz eea converting
                {
                    UpdatedOrNewClient.BirthDate = Convert.ToDateTime(UCBirthDate.Value);
                }
                else
                {
                    UpdatedOrNewClient.BirthDate = null;
                }
            }



            if (UCNamefamilyname != null)
            {
                UpdatedOrNewClient.Fname = UCNamefamilyname.ucTextbox1.Value;
                UpdatedOrNewClient.Lname = UCNamefamilyname.ucTextbox2.Value;
            }


            if (UCJob != null)
            {
                UpdatedOrNewClient.Job = UCJob.Value;
            }

            if (UCAdress != null)
            {
                UpdatedOrNewClient.Adress = UCAdress.Value;
            }

            if (UCNotes != null)
            {
                UpdatedOrNewClient.Note = UCNotes.Value;
            }

            if (UCInsta != null)
            {
                UpdatedOrNewClient.InstaUserName = UCInsta.Value;
            }

            if (UCEmail != null)
            {
                UpdatedOrNewClient.Email = UCEmail.Value;
            }
            if (TLPMaritalstatus != null)
            {
                UpdatedOrNewClient.MaritalStatus = TLPMaritalstatus.Value;
            }
            if (TLPKnowaboutus != null)
            {
                UpdatedOrNewClient.KnowAboutUs = TLPKnowaboutus.Value;
            }

            //Dynamic fields
            classClientCustomFront.UpdateOrInsertToSQLAndObj(ref UpdatedOrNewClient, ref Client);



            if (Client != null)//Update Mode
            {
                Client.IsChild = UpdatedOrNewClient.IsChild;



                Client.ProfileImage = UpdatedOrNewClient.ProfileImage;
                Client.PhoneNumber = UpdatedOrNewClient.PhoneNumber;
                Client.Gender = UpdatedOrNewClient.Gender;
                Client.BirthDate = UpdatedOrNewClient.BirthDate;
                Client.Job = UpdatedOrNewClient.Job;
                Client.Adress = UpdatedOrNewClient.Adress;
                Client.Note = UpdatedOrNewClient.Note;
                Client.InstaUserName = UpdatedOrNewClient.InstaUserName;
                Client.Email = UpdatedOrNewClient.Email;
                Client.Fname = UpdatedOrNewClient.Fname;
                Client.Lname = UpdatedOrNewClient.Lname;
                Client.MaritalStatus = UpdatedOrNewClient.MaritalStatus;
                Client.KnowAboutUs = UpdatedOrNewClient.KnowAboutUs;





                Client.UpdateClientToSQL(PicHasChanged);
            }
            else//iinsert Mode
            {
                UpdatedOrNewClient.InsertClientToSQL();
            }


        }//try catch 




        bool CheckIfDuplicatesPhoneNumberExistAndCannotOccur()//yaane eza cannot occur w exist ha tredele true
        {
            bool IsPhoneExist;
            if (!IsChildMode && ParentChosen == false && UCPhoneNumber != null && UCPhoneNumber.Value != null && UCPhoneNumber.IsPhoneNumber)//to search if the phone number already exists when i enter more then 8 digitds
            {//in case there s duplicates and we care ,can not occure

                if (Client != null)
                {
                    IsPhoneExist = SearchClientPhoneNumberSQL(Client.ClientId, UCPhoneNumber.Value);//update form
                }
                else
                {
                    IsPhoneExist = SearchClientPhoneNumberSQL(null, UCPhoneNumber.Value);//insert form
                }

                if (IsPhoneExist == true)
                {//sorna cannot occur=true with exist =true

                    return true;
                }
                else//true
                {//sorna cannot occur=true with exist =false

                    return false;
                }

            }
            else//in case there s duplicates but we dont care or the UCphone is null or no number inside of it(btenzal null bel database)
            {
                return false;
            }

        }
        bool CheckRequired()//fonction that will check if the required fields are entered and we return false or true in order not or to the save function
        {
            bool a = true;
            RequiredControls.Clear();

            if (UCGender != null && UCGender.ActiveRequiredMode())//hole mafiyun
            {
                a = false;
                RequiredControls.Add(UCGender);
            }

            if (UCBirthDate != null && UCBirthDate.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCBirthDate);
            }


            if (UCNamefamilyname != null && UCNamefamilyname.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCNamefamilyname);
            }

            if (UCPhoneNumber != null && UCPhoneNumber.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCPhoneNumber);
            }
            if (UCJob != null && UCJob.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCJob);
            }
            if (UCInsta != null && UCInsta.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCInsta);
            }
            if (UCAdress != null && UCAdress.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCAdress);
            }
            if (UCNotes != null && UCNotes.ActiveRequiredMode())

            {
                a = false;
                RequiredControls.Add(UCNotes);
            }
            if (UCEmail != null && (UCEmail.ActiveRequiredMode() || !UCEmail.HasRightEmailFormat))
            {
                a = false;
                RequiredControls.Add(UCEmail);
            }

            if (UCProfileImage != null && UCProfileImage.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCProfileImage);
            }
            if (TLPMaritalstatus != null && TLPMaritalstatus.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPMaritalstatus);
            }
            if (TLPKnowaboutus != null && TLPKnowaboutus.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPKnowaboutus);
            }

            classClientCustomFront.CheckRequired(ref a, RequiredControls);


            if (RequiredControls.Count > 0)
            {
                //RequiredControls[0].Focus();
                FLPInfo.ScrollControlIntoView(RequiredControls[0]);
            }
            return a;
        }
        //kenit tostaamal men child lal adult, bas tolii ma ela aaze
        public void Resetcontrols()
        {

            foreach (Control control in FLPInfo.Controls)
            {
                if (control is TLPCheckboxesAndRadioOptions)
                {
                    ((TLPCheckboxesAndRadioOptions)control).Reset();
                }
                else if (control is TLPOtherOptions)
                {
                    ((TLPOtherOptions)control).Reset();
                }
                else if (control is UCTextbox1)
                {
                    ((UCTextbox1)control).Reset();
                }
                else if (control is UCDoubleUCTextbox)
                {
                    ((UCDoubleUCTextbox)control).Reset();
                }
                else if (control is UCCamera)
                {
                    ((UCCamera)control).Reset();
                }
            }
        }




        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (Program.Employee.CanEditRegistrationFields)
            {
                if (!IsFromSchedule)
                {
                    Program.GreyFormJunior = new GreyColor(this, true, true, null);
                    Program.GreyFormJunior.Show();
                }
                else
                {
                    Program.GreyFormJuniorJunior = new GreyColor(this, true, true, null);
                    Program.GreyFormJuniorJunior.Show();
                }

                RegistrationFields r = new RegistrationFields(this);
                r.ShowDialog();
            }
            else
            {
                CustomMessageBox.Show("You don't have access", CustomMessageBox.Type.OkInfo);
            }
        }


        public void SaveOrUpdate(string AlbumName, bool FromRegistrationFields)//album name could be null,w only used on insert NOT UPDATE
        {

            if (Client == null)//insert
            {
                if (ParentId != null)
                {
                    UpdateClientIsParentSQL((int)ParentId, true);
                }
                UpdateOrInsertToSQLAndObj(AlbumName);//album name could be null
                int lastClientId = GetLastClientIDSQL();
                TheNewInsertedClient = ClassClientCustom.CreateClientObject(lastClientId);

                if (!IsFromSchedule)
                {
                    OpenClientManagementForm(TheNewInsertedClient);
                }

                ClientSavedEvent?.Invoke(this, EventArgs.Empty);

                this.Close();
            }
            else//update
            {

                bool OldISChild = Client.IsChild;
                bool NewIsClhild;
                if (radioButtonAdult.Checked)
                {
                    NewIsClhild = false;
                }
                else
                {
                    NewIsClhild = true;
                }

                string OldPhoneNumbre = Client.PhoneNumber;
                string NewPhoneNumber = UCPhoneNumber.Value;


                if (Client.IsParent == true && OldISChild == false && NewIsClhild == true)//aam nkhalle a parent ysir child!
                {
                    CustomMessageBox.Show("In order to make the client a child , you need first to remove all his childrens", CustomMessageBox.Type.OkInfo);
                }
                else
                {

                    if (ParentId != null)
                    {
                        UpdateClientIsParentSQL((int)ParentId, true);
                    }

                    if (OldISChild)
                    {
                        RemoveParentIfMust(OldPhoneNumbre, false);
                    }
                    //ma hattaya oldIsparent, cz no way tetghayar IsParent, badna nfout w nodhar ta tetghayar
                    if (Client.IsParent && OldPhoneNumbre != NewPhoneNumber)//we need to change all his children phone number also
                    {
                        Program.IsANewParentAddedOrParentPhoneUpdated = true;
                        UpdateAllChildrensPhoneNumberSQL(OldPhoneNumbre, NewPhoneNumber);
                    }

                    UpdateOrInsertToSQLAndObj(null);//treka hone better

                    ClientManagementProfileForm.UpdateOrCreateUCLabelAndDetail(true);

                    if (!FromRegistrationFields)
                    {
                        this.Close();
                    }
                }

            }
        }

        private void buttonAddToAlbumAndSave_Click(object sender, EventArgs e)
        {
            if (CheckRequired())
            {
                if (!CheckIfDuplicatesPhoneNumberExistAndCannotOccur())
                {
                    if (!IsFromSchedule)
                    {
                        Program.GreyFormJunior = new GreyColor(this, true, true, null);
                        Program.GreyFormJunior.Show();
                    }
                    else
                    {
                        Program.GreyFormJuniorJunior = new GreyColor(this, true, true, null);
                        Program.GreyFormJuniorJunior.Show();
                    }
                    Album album = new Album(this);
                    album.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Phone Number already exists, please choose another one");
                    FLPInfo.ScrollControlIntoView(UCPhoneNumber);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Program.Employee.CanInsertOrEditClients)
            {
                if (CheckRequired())
                {
                    if (!CheckIfDuplicatesPhoneNumberExistAndCannotOccur())
                    {
                        SaveOrUpdate(null, false);
                    }
                    else
                    {
                        CustomMessageBox.Show("Phone Number already exists, please choose another one", CustomMessageBox.Type.Error);
                        FLPInfo.ScrollControlIntoView(UCPhoneNumber);
                    }
                }
            }
            else
            {
                CustomMessageBox.Show("You don't have access", CustomMessageBox.Type.OkInfo);
            }
        }//try catch


        void RemoveParentIfMust(string OldPhoneNumber, bool IsDeleteMode)
        {
            //remove old parent
            DataTable dtParent = GetLinkedPArentsSQL(OldPhoneNumber);//hayda el phone number abel ma yetghyar
            if (dtParent.Rows.Count > 0)//ejbare
            {
                if (IsDeleteMode || radioButtonAdult.Checked || (ParentId != null && Convert.ToInt32(dtParent.Rows[0]["client_id"]) != ParentId))//case1 we re deleting the client,case2: eza ken child w sar adult /case3: eza ken child w raddayna child la gher parent aw same parent
                {
                    int NumberOfChilds = CalculateNumberOfChildrenSQL(dtParent.Rows[0]["phone_number"].ToString()) - 1;//-1 cz aam nshil hayda, since baaed ma eemelna update aa sql
                    if (NumberOfChilds == 0)
                    {
                        //update parent as adult based aal id
                        UpdateClientIsParentSQL(Convert.ToInt32(dtParent.Rows[0]["client_id"]), false);
                    }
                }
            }

        }

        public void OpenClientManagementForm(ClassClientCustom DesiredCLient)
        {

            //form creation
            Menu menu = Program.HomeForm.menu;
            if (Program.clientManagementProfile == null)
            {
                Program.clientManagementProfile = new ClientManagementProfile(DesiredCLient, false);
            }
            else
            {
                Program.clientManagementProfile.LoadData(DesiredCLient, false);
            }
            Program.clientManagementProfile.Size = SearchCurrentClientForm.Size;
            Program.clientManagementProfile.SearchCurrentClientform = SearchCurrentClientForm;
            menu.OpenChildForm(Program.clientManagementProfile, menu.buttonSearchClient, true);
            Program.HomeForm.buttonBackHome.Text = "Clients";
            Program.HomeForm.buttonBackHome.Visible = true;

        }


        private void radioButtonChild_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonChild.Checked)//kermel eza feytin men select parent ha t8ayir la child w teftah l form men awwal w jdid
            {
                IsChildMode = true;

                if (!ISCallingFromTheConstructor)///eza aam aayetla awwal ma teftah el form , kermel ma tfout fiya
                {
                    if (!IsFromSchedule)
                    {
                        Program.GreyFormJunior = new GreyColor(this, true, true, null);
                        Program.GreyFormJunior.Show();
                    }
                    else
                    {
                        Program.GreyFormJuniorJunior = new GreyColor(this, true, true, null);
                        Program.GreyFormJuniorJunior.Show();
                    }

                    ChildParent c = new ChildParent(this);
                    c.ShowDialog();
                }

            }

        }

        private void radioButtonAdult_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonAdult.Checked)//kermel eza feytin men select parent ha t8ayir la child w teftah l form men awwal w jdid
            {
                //hal condition eza naelna men chil la adult, lieano fi waeto el radio butt byetghayyar el checks tabaaoun bas men kun naelna, bas kermel neftah el childparent form w fiyye erjaa sakera , so el adult radio will be again selected bas ma eemelna shi, so ma bet fout bel condition li tahet
                if ((ParentChosen && Client == null) || (Client != null && (Client.IsChild || ParentChosen)))//first one in case insert form, scd one  in case of update form
                {
                    //ResetUsercontrols();
                    if (UCPhoneNumber != null)
                    {
                        UCPhoneNumber.Reset();

                    }

                    ParentId = null;
                    if (UCPhoneNumber != null)
                    {
                        ParentChosen = false;//lamma rajoo adult, yaane childmode=false, yaane akid battal fi parent, yaane parentchosen=false
                    }
                }
                IsChildMode = false;
            }
        }



        private void UCPhoneNumber_textboxtextchange(object sender, EventArgs e)
        {
            if (UCPhoneNumber.Value != null && UCPhoneNumber.Value.Length >= 8)//to search if the phone number already exists when i enter more then 8 digitds
            {

                if (CheckIfDuplicatesPhoneNumberExistAndCannotOccur())
                {
                    if (IsFromSchedule == false)//from management
                    {
                        DialogResult dialogResult = CustomMessageBox.Show("The Client With this Phone Number Already Exists, Do you want to Check its profile?", CustomMessageBox.Type.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int clientid = GetClientIdFromPhoneNumberSQL(UCPhoneNumber.Value);
                            OpenClientManagementForm(ClassClientCustom.CreateClientObject(clientid));
                            this.Close();
                        }
                    }
                    else//from schedule
                    {
                        CustomMessageBox.Show("The Client With this Phone Number Already Exists", CustomMessageBox.Type.Error);
                    }
                }
            }
        }




        private void buttonCancel_Click(object sender, EventArgs e)
        {

            this.Close();

        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!Program.Employee.CanDeleteClient)
            {
                CustomMessageBox.Show("You don't have access", CustomMessageBox.Type.OkInfo);
            }
            else if (ClientManagementProfileForm.IsFromSchedule || IsFromSchedule)//to be deleted one the restriction is put on the delete
            {
                CustomMessageBox.Show("You can't delete a client while you re in the Schedule, Please delete it from the Management", CustomMessageBox.Type.Error);
            }
            else
            {

                if (Client.IsParent == false)
                {
                    // Show a message box with "Yes" and "No" buttons

                    if (Client.CheckIfCLientHasClientBalanceRefrences())
                    {
                        CustomMessageBox.Show("You must remove all transactions for this client before you can delete their profile.", CustomMessageBox.Type.Error);
                    }
                    else
                    {
                        DialogResult result = CustomMessageBox.Show("Are you sure you want to delete this client profile?\nYou will loose all his informations", CustomMessageBox.Type.YesNoWarning);

                        // Check the user's choice
                        if (result == DialogResult.Yes)
                        {


                            if (ClientManagementProfileForm != null)
                            {
                                ClientManagementProfileForm.IsClientDeleted = true;
                            }
                            if (Client.IsChild)
                            {
                                RemoveParentIfMust(Client.PhoneNumber, true);//eza aam nshil a child eendo parent
                            }

                            Client.DeleteClientToSQL();//ejbare tahet el RemoveParentIfMust
                            this.Close();
                        }
                    }
                }
                else
                {
                    CustomMessageBox.Show("In order to Delete this Client , you need first to remove all his childrens", CustomMessageBox.Type.OkInfo);
                }

            }

        }//try catch

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .1;
        }
        private void flowLayoutPanelInfo_Scroll(object sender, ScrollEventArgs e)
        {
            labelEditClient.Focus();
        }

        private void NewRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.GreyFormJunior != null)
            {
                Program.GreyFormJunior.Close();
                Program.GreyFormJunior = null;
            }
            else if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }
    }
}
