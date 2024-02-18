
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
using static MKproject.Management.ClassOptionsInsideFields;

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



        private UCCamera UCProfileImage;

        //track all uc if they are used in the right way
        private UCDoubleUCTextbox UCNamefamilyname;
        public UCTextbox1 UCPhoneNumber;
        private UCTextbox1 UCInsta;
        private UCTextbox1 UCJob;
        private UCTextbox1 UCAdress;
        private UCTextbox1 UCNotes;
        private UCTextbox1 UCEmail;



        //custom tools
        private TLPOtherOptions UCBirthDate;
        private TLPOtherOptions UCHeight;
        private TLPOtherOptions UCWeight;
        private TLPOtherOptions UCTimelinegoals;
        private TLPOtherOptions UCSleeppattern;

        //two radio buttons
        private TLPCheckboxesAndRadioOptions UCGender;
        private TLPCheckboxesAndRadioOptions UCHand;
        private TLPCheckboxesAndRadioOptions UCSmoking;
        private TLPCheckboxesAndRadioOptions UCAlcohol;
        //checkbox or radio buttons with exntension
        private TLPCheckboxesAndRadioOptions UCKnowaboutus;
        private TLPCheckboxesAndRadioOptions UCMaritalstatus;
        private TLPCheckboxesAndRadioOptions UCExercisehistory;
        private TLPCheckboxesAndRadioOptions UCStresslevel;
        private TLPCheckboxesAndRadioOptions UCBodyshapetarget;
        private TLPCheckboxesAndRadioOptions UCinjuries;
        private TLPCheckboxesAndRadioOptions UCMusclesfocuson;
        private TLPCheckboxesAndRadioOptions UCSessionperweek;
        private TLPCheckboxesAndRadioOptions UCFightingSkills;



        public ClassClient Client;
        private List<UCTextbox1> TextBoxes = new List<UCTextbox1> { };
        public List<Control> RequiredControls = new List<Control> { };


        public NewRegister(ClassClient Clients)
        {
            InitializeComponent();

            this.Size = new Size();
            this.Opacity = 0;
            this.Size = new Size(660, 650);//kell shi aam nhotoo juwwa aam naamela width=600, which is not accurate, try bi wpf taamil dock top
            ControlsWidthInsideFLP = 600;
            LoadForm(Clients);
        }

        public void LoadForm(ClassClient Clients)
        {
            radioButtonAdult.Checked = true;
            ClientManagementProfileForm = null;
            SearchCurrentClientForm = null;
            IsChildMode = false;
            ParentId = null;
            PicHasChanged = false;
            ParentChosen = false;
            ISCallingFromTheConstructor = true;


            


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




        //custome tools for funtion creating and updating fields

        UCNumberComboButt uc;//in order to access it from the event
        UCNumberComboButt CreateGoalTimeLineUCNumberComboButt()
        {
            if (uc == null)
            {
                uc = new UCNumberComboButt();
                uc.comboBoxUnit.SelectedIndexChanged += event_RemoveSelection;
                uc.comboBoxUnit.DropDownClosed += event_RemoveSelection;

                Color col = Color.White;
                uc.BackColor = col;
                uc.TLPTimeline.BackColor = col;
                uc.ucPureNumber1.textBoxValue.BackColor = col;
                uc.ucPureNumber1.BackColor = col;
                uc.comboBoxUnit.BackColor = col;

                uc.Size = new Size(220, 37);
                uc.ucPureNumber1.TextBoxFont = new Font("Segoe UI Semibold", 20.25f, FontStyle.Bold);
                uc.comboBoxUnit.Font = new Font("Segoe UI  Semibold", 14.25f); ;
                uc.ucPureNumber1.ButtonSizeMinus = new Size(27, 30);
                uc.ucPureNumber1.ButtonSizePlus = new Size(27, 30);



                uc.comboBoxUnit.SelectedIndexChanged += ComboBoxUnit_SelectedIndexChanged;
                Period[] periods = (Period[])Enum.GetValues(typeof(Period));

                foreach (Period period in periods)
                {
                    uc.comboBoxUnit.Items.Add(period.ToString());
                }
                uc.comboBoxUnit.SelectedIndex = 0;
            }
            return uc;
        }
        private void ComboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

            //uc.ucPureNumber1.Number = 0;
            //if (uc.comboBoxUnit.Text == Period.Weeks.ToString())
            //{
            //    uc.ucPureNumber1.Maximum_number = 4;
            //}
            //else if (uc.comboBoxUnit.Text == Period.Months.ToString())
            //{
            //    uc.ucPureNumber1.Maximum_number = 12;
            //}
            //else if (uc.comboBoxUnit.Text == Period.Years.ToString())
            //{
            //    uc.ucPureNumber1.Maximum_number = 10;
            //}
        }

        UCNumberLabelButt CreateSleepPatternUCNumberLabelButt()
        {
            UCNumberLabelButt uc = new UCNumberLabelButt();
            uc.Unit = "hrs";
            uc.Maximum_number = 24;
            uc.Number = 0;

            uc.Size = new Size(149, 37);
            uc.buttonValuePlus.Size = new Size(27, 30);
            uc.buttonValueMinus.Size = new Size(27, 30);
            uc.textBoxValue.Font = new Font("Segoe UI Semibold", 20.25f, FontStyle.Bold);




            Color col = Color.White;
            uc.BackColor = col;
            uc.TLPGlobal.BackColor = col;
            uc.textBoxValue.BackColor = col;
            uc.buttonValueMinus.BackColor = col;
            uc.buttonValuePlus.BackColor = col;
            uc.labelUnit.BackColor = col;



            return uc;
        }
        UCDoubleCombo CreateWeightUCDoubleCombo()
        {
            UCDoubleCombo uc = new UCDoubleCombo();
            uc.comboBoxUnit.SelectedIndexChanged += event_RemoveSelection;
            uc.comboBoxUnit.DropDownClosed += event_RemoveSelection;

            uc.Maximum_number = 999;
            uc.Size = new Size(175, 37);
            uc.textBoxValue.Font = new Font("Segoe UI Semibold", 20.25f, FontStyle.Bold);
            uc.comboBoxUnit.Font = new Font("Segoe UI  Semibold", 14.25f); ;

            Color col = Color.White;
            uc.textBoxValue.BackColor = col;
            uc.comboBoxUnit.BackColor = col;


            foreach (UnitWeight unit in Enum.GetValues(typeof(UnitWeight)))
            {
                uc.comboBoxUnit.Items.Add(unit);
            }
            uc.comboBoxUnit.SelectedIndex = uc.comboBoxUnit.FindString(UnitWeight.kg.ToString());
            return uc;
        }
        UCDoubleCombo CreateHeightUCDoubleCombo()
        {
            UCDoubleCombo uc = new UCDoubleCombo();
            uc.comboBoxUnit.SelectedIndexChanged += event_RemoveSelection;
            uc.comboBoxUnit.DropDownClosed += event_RemoveSelection;

            uc.Maximum_number = 999;
            uc.Size = new Size(175, 37);
            uc.textBoxValue.Font = new Font("Segoe UI Semibold", 20.25f, FontStyle.Bold);
            uc.comboBoxUnit.Font = new Font("Segoe UI  Semibold", 14.25f); ;

            Color col = Color.White;
            uc.textBoxValue.BackColor = col;
            uc.comboBoxUnit.BackColor = col;

            foreach (UnitHeight unit in Enum.GetValues(typeof(UnitHeight)))
            {
                uc.comboBoxUnit.Items.Add(unit);
            }
            uc.comboBoxUnit.SelectedIndex = uc.comboBoxUnit.FindString(UnitHeight.cm.ToString());
            return uc;
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
        private void event_RemoveSelection(object sender, EventArgs e)
        {
            labelAdultOrChild.Focus();
        }




        public void UpdateOrCreateFields(bool IsUpdateOrCreate)
        {

            Cursor.Current = Cursors.WaitCursor;
            DataTable dt;
            if (IsUpdateOrCreate)
            {
                dt = dtUpdatedFields;
            }
            else
            {
                dt = SQLToProject.GetAllVisibleFields();
            }



            foreach (DataRow row in dt.Rows)
            {
                bool isRequired = Convert.ToBoolean(row["Required"]);
                bool isVisible = Convert.ToBoolean(row["Visible"]);
                int DesignIndex = Convert.ToInt16(row["design_index"]);
                string FieldName = row["Fields"].ToString();

                // Check if the "Full Name" field exists in the table
                if (FieldName == ClassClient.enumType.FullName.ToString())
                {
                    if (isVisible)
                    {
                        if (UCNamefamilyname == null)
                        {
                            UCNamefamilyname = new UCDoubleUCTextbox("Name", "Family Name", isRequired);//kermel l nejme                        
                            UCNamefamilyname.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCNamefamilyname);
                        }
                        else
                        {
                            if (isRequired && !UCNamefamilyname.IsRequired)
                            {
                                UCNamefamilyname.IsRequired = true;
                            }
                            else if (!isRequired && UCNamefamilyname.IsRequired)
                            {
                                UCNamefamilyname.IsRequired = false;
                            }
                        }

                        if (Client != null && Client.Fname != null && Client.Lname != null)
                            UCNamefamilyname.FillDesignValue(Client.Fname, Client.Lname);

                        UCNamefamilyname.Index = DesignIndex;
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

                else if (FieldName == ClassClient.enumType.Height.ToString())
                {
                    if (isVisible)
                    {
                        if (UCHeight == null)
                        {
                            UCHeight = new TLPOtherOptions(ClassClient.enumType.Height.GetStringValue(), isRequired, CreateHeightUCDoubleCombo());
                            UCHeight.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCHeight);
                        }
                        else
                        {
                            if (isRequired && !UCHeight.IsRequired)
                            {
                                UCHeight.IsRequired = true;
                            }
                            else if (!isRequired && UCHeight.IsRequired)
                            {
                                UCHeight.IsRequired = false;
                            }
                        }
                        if (Client != null)
                        {
                            UCHeight.FillDesignValues(Client.Height);
                        }
                        UCHeight.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCHeight != null)
                        {

                            this.Controls.Remove(UCHeight);
                            UCHeight.Dispose();
                            UCHeight = null;
                        }
                    }
                }
                else if (FieldName == ClassClient.enumType.Weight.ToString())
                {
                    if (isVisible)
                    {
                        if (UCWeight == null)
                        {
                            UCWeight = new TLPOtherOptions(ClassClient.enumType.Weight.GetStringValue(), isRequired, CreateWeightUCDoubleCombo());
                            UCWeight.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCWeight);
                        }
                        else
                        {
                            if (isRequired && !UCWeight.IsRequired)
                            {
                                UCWeight.IsRequired = true;
                            }
                            else if (!isRequired && UCWeight.IsRequired)
                            {
                                UCWeight.IsRequired = false;
                            }
                        }
                        if (Client != null)
                        {
                            UCWeight.FillDesignValues(Client.Weight);
                        }
                        UCWeight.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCWeight != null)
                        {

                            this.Controls.Remove(UCWeight);
                            UCWeight.Dispose();
                            UCWeight = null;
                        }
                    }
                }


                else if (FieldName == ClassClient.enumType.Gender.ToString())
                {
                    if (isVisible)
                    {
                        if (UCGender == null)
                        {
                            UCGender = new TLPCheckboxesAndRadioOptions(ClassClient.enumType.Gender.GetStringValue(), isRequired, false, null, ClassOptionsInsideFields.Gender.Male.GetStringValue(), ClassOptionsInsideFields.Gender.Female.GetStringValue(), true);
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
                        UCGender.Index = DesignIndex;

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


                else if (FieldName == ClassClient.enumType.BirthDate.ToString())
                {
                    if (isVisible)
                    {
                        if (UCBirthDate == null)
                        {
                            UCBirthDate = new TLPOtherOptions(ClassClient.enumType.BirthDate.GetStringValue(), isRequired, CreateDateTimePicker());
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

                        UCBirthDate.Index = DesignIndex;

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

                else if (FieldName == ClassClient.enumType.BodyShapeTarget.ToString())
                {
                    if (isVisible)
                    {
                        if (UCBodyshapetarget == null)
                        {

                            List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };
                            foreach (ClassOptionsInsideFields.enumBodyShapeTarget enumValue in Enum.GetValues(typeof(ClassOptionsInsideFields.enumBodyShapeTarget)))
                            {
                                ListOptions.Add((enumValue.GetStringValue(), null, null));
                            }


                            UCBodyshapetarget = new TLPCheckboxesAndRadioOptions(ClassClient.enumType.BodyShapeTarget.GetStringValue(), isRequired, true, ListOptions, null, null, true);
                            UCBodyshapetarget.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCBodyshapetarget);
                        }
                        else
                        {
                            if (isRequired && !UCBodyshapetarget.IsRequired)
                            {
                                UCBodyshapetarget.IsRequired = true;
                            }
                            else if (!isRequired && UCBodyshapetarget.IsRequired)
                            {
                                UCBodyshapetarget.IsRequired = false;
                            }
                        }
                        if (Client != null && Client.BodyShapeTarget != null)
                        {
                            UCBodyshapetarget.FillDesignValues(Client.BodyShapeTarget);
                        }
                        UCBodyshapetarget.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCBodyshapetarget != null)
                        {

                            this.Controls.Remove(UCBodyshapetarget);
                            UCBodyshapetarget.Dispose();
                            UCBodyshapetarget = null;
                        }
                    }
                }

                else if (FieldName == ClassClient.enumType.Hand.ToString())
                {
                    if (isVisible)
                    {
                        if (UCHand == null)
                        {
                            UCHand = new TLPCheckboxesAndRadioOptions(ClassClient.enumType.Hand.GetStringValue(), isRequired, false, null, ClassOptionsInsideFields.RightLeft.Right.GetStringValue(), ClassOptionsInsideFields.RightLeft.Left.GetStringValue(), true);
                            UCHand.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCHand);

                        }
                        else
                        {
                            if (isRequired && !UCHand.IsRequired)
                            {
                                UCHand.IsRequired = true;
                            }
                            else if (!isRequired && UCHand.IsRequired)
                            {
                                UCHand.IsRequired = false;
                            }
                        }
                        if (Client != null && Client.Hand != null)//to fill the info if i am editing a client
                        {
                            UCHand.FillDesignValues(Client.Hand);
                        }

                        UCHand.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCHand != null)
                        {

                            this.Controls.Remove(UCHand);
                            UCHand.Dispose();
                            UCHand = null;
                        }
                    }
                }

                else if (FieldName == ClassClient.enumType.Injuries.ToString())
                {
                    if (isVisible)
                    {

                        if (UCinjuries == null)
                        {
                            List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };

                            ListOptions.Add((ClassOptionsInsideFields.enumNone.None.GetStringValue(), null, null));

                            foreach (ClassOptionsInsideFields.enumInjuries enumValue in Enum.GetValues(typeof(ClassOptionsInsideFields.enumInjuries)))
                            {

                                if (enumValue == ClassOptionsInsideFields.enumInjuries.Others)
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), new TextBoxWithPlaceHolder(), ""));
                                }
                                else
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), null, null));
                                }
                            }


                            UCinjuries = new TLPCheckboxesAndRadioOptions(ClassClient.enumType.Injuries.GetStringValue(), isRequired, true, ListOptions, null, null, true);
                            UCinjuries.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCinjuries);

                        }
                        else
                        {
                            if (isRequired && !UCinjuries.IsRequired)
                            {
                                UCinjuries.IsRequired = true;
                            }
                            else if (!isRequired && UCinjuries.IsRequired)
                            {
                                UCinjuries.IsRequired = false;
                            }
                        }
                        if (Client != null && Client.Injuries != null)
                        {
                            UCinjuries.FillDesignValues(Client.Injuries);
                        }
                        UCinjuries.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCinjuries != null)
                        {

                            this.Controls.Remove(UCinjuries);
                            UCinjuries.Dispose();
                            UCinjuries = null;
                        }
                    }
                }

                else if (FieldName == ClassClient.enumType.MuscleFocusOn.ToString())
                {
                    if (isVisible)
                    {
                        if (UCMusclesfocuson == null)
                        {



                            List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };

                            foreach (ClassOptionsInsideFields.enumMuscleFocusOn enumValue in Enum.GetValues(typeof(ClassOptionsInsideFields.enumMuscleFocusOn)))
                            {
                                ListOptions.Add((enumValue.GetStringValue(), null, null));
                            }
                            UCMusclesfocuson = new TLPCheckboxesAndRadioOptions(ClassClient.enumType.MuscleFocusOn.GetStringValue(), isRequired, true, ListOptions, null, null, true);
                            UCMusclesfocuson.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCMusclesfocuson);


                        }
                        else
                        {
                            if (isRequired && !UCMusclesfocuson.IsRequired)
                            {
                                UCMusclesfocuson.IsRequired = true;
                            }
                            else if (!isRequired && UCMusclesfocuson.IsRequired)
                            {
                                UCMusclesfocuson.IsRequired = false;
                            }
                        }
                        if (Client != null && Client.MuscleFocusOn != null)
                        {
                            UCMusclesfocuson.FillDesignValues(Client.MuscleFocusOn);
                        }
                        UCMusclesfocuson.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCMusclesfocuson != null)
                        {

                            this.Controls.Remove(UCMusclesfocuson);
                            UCMusclesfocuson.Dispose();
                            UCMusclesfocuson = null;
                        }
                    }
                }

                else if (FieldName == ClassClient.enumType.SessionPerWeek.ToString())
                {
                    if (isVisible)
                    {
                        if (UCSessionperweek == null)
                        {

                            List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };
                            foreach (ClassOptionsInsideFields.enumSessionPerWeek enumValue in Enum.GetValues(typeof(ClassOptionsInsideFields.enumSessionPerWeek)))
                            {
                                ListOptions.Add((enumValue.GetStringValue(), null, null));
                            }
                            UCSessionperweek = new TLPCheckboxesAndRadioOptions(ClassClient.enumType.SessionPerWeek.GetStringValue(), isRequired, false, ListOptions, null, null, true);
                            UCSessionperweek.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCSessionperweek);

                        }
                        else
                        {
                            if (isRequired && !UCSessionperweek.IsRequired)
                            {
                                UCSessionperweek.IsRequired = true;
                            }
                            else if (!isRequired && UCSessionperweek.IsRequired)
                            {
                                UCSessionperweek.IsRequired = false;
                            }
                        }

                        if (Client != null && Client.SessionPerWeek != null)
                        {
                            UCSessionperweek.FillDesignValues(Client.SessionPerWeek.ToString());
                        }
                        UCSessionperweek.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCSessionperweek != null)
                        {

                            this.Controls.Remove(UCSessionperweek);
                            UCSessionperweek.Dispose();
                            UCSessionperweek = null;
                        }
                    }
                }

                else if (FieldName == ClassClient.enumType.PhoneNumber.ToString())
                {
                    if (isVisible)
                    {
                        if (UCPhoneNumber == null)
                        {
                            UCPhoneNumber = new UCTextbox1(ClassClient.enumType.PhoneNumber.ToString(), isRequired);
                            UCPhoneNumber.IsPhoneNumber = true;
                            UCPhoneNumber.textboxtextchange += UCPhoneNumber_textboxtextchange;

                            UCPhoneNumber.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCPhoneNumber);

                        }
                        else
                        {
                            if (isRequired && !UCPhoneNumber.IsRequired)
                            {
                                UCPhoneNumber.IsRequired = true;
                            }
                            else if (!isRequired && UCPhoneNumber.IsRequired)
                            {
                                UCPhoneNumber.IsRequired = false;
                            }
                        }

                        if (Client != null && Client.PhoneNumber != null)//to fill the info if i am editing a client
                        {
                            UCPhoneNumber.FillDesignValue(Client.PhoneNumber);

                            if (Client.IsChild == true)//yaane only lamma neftah el update el form w ykun child
                            {
                                UCPhoneNumber.DisableUC();
                            }
                        }
                        UCPhoneNumber.Index = DesignIndex;

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

                else if (FieldName == ClassClient.enumType.Job.ToString())
                {
                    if (isVisible)
                    {

                        if (UCJob == null)
                        {
                            UCJob = new UCTextbox1(ClassClient.enumType.Job.ToString(), isRequired);
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
                        UCJob.Index = DesignIndex;

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

                else if (FieldName == ClassClient.enumType.Adress.ToString())
                {
                    if (isVisible)
                    {
                        if (UCAdress == null)
                        {
                            UCAdress = new UCTextbox1(ClassClient.enumType.Adress.ToString(), isRequired);
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
                        UCAdress.Index = DesignIndex;

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

                else if (FieldName == ClassClient.enumType.InstaUserName.ToString())
                {

                    if (isVisible)
                    {
                        if (UCInsta == null)
                        {
                            UCInsta = new UCTextbox1(ClassClient.enumType.InstaUserName.GetStringValue(), isRequired);
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
                        UCInsta.Index = DesignIndex;

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

                else if (FieldName == ClassClient.enumType.Note.ToString())
                {
                    if (isVisible)
                    {
                        if (UCNotes == null)
                        {
                            UCNotes = new UCTextbox1(ClassClient.enumType.Note.ToString(), isRequired);
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
                        UCNotes.Index = DesignIndex;

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

                else if (FieldName == ClassClient.enumType.Email.ToString())
                {
                    if (isVisible)
                    {
                        if (UCEmail == null)
                        {
                            UCEmail = new UCTextbox1(ClassClient.enumType.Email.ToString(), isRequired);
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
                        UCEmail.Index = DesignIndex;

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

                else if (FieldName == ClassClient.enumType.MaritalStatus.ToString())
                {
                    if (isVisible)
                    {
                        if (UCMaritalstatus == null)
                        {
                            List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };
                            foreach (ClassOptionsInsideFields.enumMaritalStatus enumValue in Enum.GetValues(typeof(ClassOptionsInsideFields.enumMaritalStatus)))
                            {
                                if (enumValue == ClassOptionsInsideFields.enumMaritalStatus.HaveChildren)
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), new UCNumberButt(), "1"));
                                }
                                else
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), null, null));
                                }

                            }

                            UCMaritalstatus = new TLPCheckboxesAndRadioOptions(ClassClient.enumType.MaritalStatus.GetStringValue(), isRequired, true, ListOptions, null, null, true);
                            UCMaritalstatus.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCMaritalstatus);

                        }
                        else
                        {
                            if (isRequired && !UCMaritalstatus.IsRequired)
                            {
                                UCMaritalstatus.IsRequired = true;
                            }
                            else if (!isRequired && UCMaritalstatus.IsRequired)
                            {
                                UCMaritalstatus.IsRequired = false;
                            }

                        }
                        if (Client != null && Client.MaritalStatus != null)
                        {
                            UCMaritalstatus.FillDesignValues(Client.MaritalStatus);
                        }
                        UCMaritalstatus.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCMaritalstatus != null)
                        {

                            this.Controls.Remove(UCMaritalstatus);
                            UCMaritalstatus.Dispose();
                            UCMaritalstatus = null;
                        }
                    }
                }

                else if (FieldName == ClassClient.enumType.HowDidYouKnowAboutUs.ToString())
                {
                    if (isVisible)
                    {
                        if (UCKnowaboutus == null)
                        {


                            List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };
                            foreach (ClassOptionsInsideFields.enumInsta enumValue in Enum.GetValues(typeof(ClassOptionsInsideFields.enumInsta)))
                            {
                                if (enumValue == ClassOptionsInsideFields.enumInsta.CustomerMention)
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
                            foreach (ClassOptionsInsideFields.enumHowDidYouKnowAboutUs enumValue in Enum.GetValues(typeof(ClassOptionsInsideFields.enumHowDidYouKnowAboutUs)))
                            {
                                if (enumValue == ClassOptionsInsideFields.enumHowDidYouKnowAboutUs.instagram)
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), UCInsta, ""));
                                }
                                else if (enumValue == ClassOptionsInsideFields.enumHowDidYouKnowAboutUs.BoucheAOreille)
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), new TextBoxWithPlaceHolder(), "Person Name"));
                                }
                                else if (enumValue == ClassOptionsInsideFields.enumHowDidYouKnowAboutUs.Others)
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), new TextBoxWithPlaceHolder(), ""));
                                }
                                else
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), null, null));
                                }
                            }

                            UCKnowaboutus = new TLPCheckboxesAndRadioOptions(ClassClient.enumType.HowDidYouKnowAboutUs.GetStringValue(), isRequired, true, ListOptions, null, null, true);
                            UCKnowaboutus.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCKnowaboutus);

                        }
                        else
                        {
                            if (isRequired && !UCKnowaboutus.IsRequired)
                            {
                                UCKnowaboutus.IsRequired = true;
                            }
                            else if (!isRequired && UCKnowaboutus.IsRequired)
                            {
                                UCKnowaboutus.IsRequired = false;
                            }

                        }

                        if (Client != null && Client.KnowAboutUs != null)
                        {
                            UCKnowaboutus.FillDesignValues(Client.KnowAboutUs);
                        }
                        UCKnowaboutus.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCKnowaboutus != null)
                        {

                            this.Controls.Remove(UCKnowaboutus);
                            UCKnowaboutus.Dispose();
                            UCKnowaboutus = null;
                        }
                    }
                }

                else if (FieldName == ClassClient.enumType.GoalsTimeline.ToString())
                {
                    if (isVisible)
                    {
                        if (UCTimelinegoals == null)
                        {

                            UCTimelinegoals = new TLPOtherOptions(ClassClient.enumType.GoalsTimeline.GetStringValue(), isRequired, CreateGoalTimeLineUCNumberComboButt());
                            UCTimelinegoals.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCTimelinegoals);

                        }
                        else
                        {
                            if (isRequired && !UCTimelinegoals.IsRequired)
                            {
                                UCTimelinegoals.IsRequired = true;
                            }
                            else if (!isRequired && UCTimelinegoals.IsRequired)
                            {
                                UCTimelinegoals.IsRequired = false;
                            }
                        }

                        if (Client != null && Client.GoalsTimeline != null)//to fill the info if i am editing a client
                        {
                            UCTimelinegoals.FillDesignValues(Client.GoalsTimeline);
                        }
                        UCTimelinegoals.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCTimelinegoals != null)
                        {

                            this.Controls.Remove(UCTimelinegoals);
                            UCTimelinegoals.Dispose();
                            UCTimelinegoals = null;
                        }
                    }
                }

                else if (FieldName == ClassClient.enumType.Smoking.ToString())
                {
                    if (isVisible)
                    {
                        if (UCSmoking == null)
                        {
                            UCSmoking = new TLPCheckboxesAndRadioOptions(ClassClient.enumType.Smoking.GetStringValue(), isRequired, false, null, ClassOptionsInsideFields.YesNo.Yes.GetStringValue(), ClassOptionsInsideFields.YesNo.No.GetStringValue(), true);
                            UCSmoking.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCSmoking);

                        }
                        else
                        {
                            if (isRequired && !UCSmoking.IsRequired)
                            {
                                UCSmoking.IsRequired = true;
                            }
                            else if (!isRequired && UCSmoking.IsRequired)
                            {
                                UCSmoking.IsRequired = false;
                            }
                        }

                        if (Client != null && Client.Smoking != null)//to fill the info if i am editing a client
                        {
                            UCSmoking.FillDesignValues(Client.Smoking.ToString());
                        }
                        UCSmoking.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCSmoking != null)
                        {

                            this.Controls.Remove(UCSmoking);
                            UCSmoking.Dispose();
                            UCSmoking = null;
                        }
                    }
                }

                else if (FieldName == ClassClient.enumType.Alcohol.ToString())
                {
                    if (isVisible)
                    {
                        if (UCAlcohol == null)
                        {
                            UCAlcohol = new TLPCheckboxesAndRadioOptions(ClassClient.enumType.Alcohol.GetStringValue(), isRequired, false, null, ClassOptionsInsideFields.YesNo.Yes.GetStringValue(), ClassOptionsInsideFields.YesNo.No.GetStringValue(), true);
                            UCAlcohol.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCAlcohol);


                        }
                        else
                        {
                            if (isRequired && !UCAlcohol.IsRequired)
                            {
                                UCAlcohol.IsRequired = true;
                            }
                            else if (!isRequired && UCAlcohol.IsRequired)
                            {
                                UCAlcohol.IsRequired = false;
                            }
                        }

                        if (Client != null && Client.Alcohol != null)//to fill the info if i am editing a client
                        {
                            UCAlcohol.FillDesignValues(Client.Alcohol.ToString());
                        }
                        UCAlcohol.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCAlcohol != null)
                        {

                            this.Controls.Remove(UCAlcohol);
                            UCAlcohol.Dispose();
                            UCAlcohol = null;
                        }
                    }
                }

                else if (FieldName == ClassClient.enumType.ExerciseHistory.ToString())
                {
                    if (isVisible)
                    {
                        if (UCExercisehistory == null)
                        {

                            List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };
                            foreach (ClassOptionsInsideFields.enumExerciseHistory enumValue in Enum.GetValues(typeof(ClassOptionsInsideFields.enumExerciseHistory)))
                            {
                                if (enumValue == ClassOptionsInsideFields.enumExerciseHistory.Others)
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), new TextBoxWithPlaceHolder(), ""));
                                }
                                else
                                {
                                    ListOptions.Add((enumValue.GetStringValue(), null, null));
                                }
                            }
                            UCExercisehistory = new TLPCheckboxesAndRadioOptions(ClassClient.enumType.ExerciseHistory.GetStringValue(), isRequired, true, ListOptions, null, null, true);
                            UCExercisehistory.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCExercisehistory);



                        }
                        else
                        {
                            if (isRequired && !UCExercisehistory.IsRequired)
                            {
                                UCExercisehistory.IsRequired = true;
                            }
                            else if (!isRequired && UCExercisehistory.IsRequired)
                            {
                                UCExercisehistory.IsRequired = false;
                            }
                        }

                        if (Client != null && Client.ExerciseHistory != null)
                        {
                            UCExercisehistory.FillDesignValues(Client.ExerciseHistory);
                        }
                        UCExercisehistory.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCExercisehistory != null)
                        {

                            this.Controls.Remove(UCExercisehistory);
                            UCExercisehistory.Dispose();
                            UCExercisehistory = null;
                        }
                    }
                }

                else if (FieldName == ClassClient.enumType.SleepPattern.ToString())
                {
                    if (isVisible)
                    {
                        if (UCSleeppattern == null)
                        {
                            UCSleeppattern = new TLPOtherOptions(ClassClient.enumType.SleepPattern.GetStringValue(), isRequired, CreateSleepPatternUCNumberLabelButt());
                            UCSleeppattern.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCSleeppattern);

                        }
                        else
                        {
                            if (isRequired && !UCSleeppattern.IsRequired)
                            {
                                UCSleeppattern.IsRequired = true;
                            }
                            else if (!isRequired && UCSleeppattern.IsRequired)
                            {
                                UCSleeppattern.IsRequired = false;
                            }
                        }

                        if (Client != null && Client.SleepPattern != null)//to fill the info if i am editing a client
                        {
                            UCSleeppattern.FillDesignValues(Client.SleepPattern.ToString());
                        }
                        UCSleeppattern.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCSleeppattern != null)
                        {

                            this.Controls.Remove(UCSleeppattern);
                            UCSleeppattern.Dispose();
                            UCSleeppattern = null;
                        }
                    }
                }

                else if (FieldName == ClassClient.enumType.StressLevel.ToString())
                {
                    if (isVisible)
                    {
                        if (UCStresslevel == null)
                        {

                            List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };
                            foreach (ClassOptionsInsideFields.enumStressLevel enumValue in Enum.GetValues(typeof(ClassOptionsInsideFields.enumStressLevel)))
                            {
                                ListOptions.Add((enumValue.GetStringValue(), null, null));
                            }


                            UCStresslevel = new TLPCheckboxesAndRadioOptions(ClassClient.enumType.StressLevel.GetStringValue(), isRequired, false, ListOptions, null, null, true);
                            UCStresslevel.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCStresslevel);

                        }
                        else
                        {
                            if (isRequired && !UCStresslevel.IsRequired)
                            {
                                UCStresslevel.IsRequired = true;
                            }
                            else if (!isRequired && UCStresslevel.IsRequired)
                            {
                                UCStresslevel.IsRequired = false;
                            }
                        }

                        if (Client != null && Client.StressLevel != null)
                        {
                            UCStresslevel.FillDesignValues(Client.StressLevel);
                        }
                        UCStresslevel.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCStresslevel != null)
                        {

                            this.Controls.Remove(UCStresslevel);
                            UCStresslevel.Dispose();
                            UCStresslevel = null;
                        }
                    }
                }

                else if (FieldName == ClassClient.enumType.FaceImage.ToString())
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

                        UCProfileImage.Index = DesignIndex;

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

                else if (FieldName == ClassClient.enumType.BoxingSkills.ToString())
                {
                    if (isVisible)
                    {
                        if (UCFightingSkills == null)
                        {

                            List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };

                            foreach (ClassOptionsInsideFields.enumFightingSkills enumValue in Enum.GetValues(typeof(ClassOptionsInsideFields.enumFightingSkills)))
                            {
                                ListOptions.Add((enumValue.GetStringValue(), null, null));
                            }

                            UCFightingSkills = new TLPCheckboxesAndRadioOptions(ClassClient.enumType.BoxingSkills.GetStringValue(), isRequired, true, ListOptions, ClassOptionsInsideFields.YesNo.Yes.GetStringValue(), ClassOptionsInsideFields.YesNo.No.GetStringValue(), true);
                            UCFightingSkills.Width = ControlsWidthInsideFLP;
                            FLPInfo.Controls.Add(UCFightingSkills);


                        }
                        else
                        {
                            if (isRequired && !UCFightingSkills.IsRequired)
                            {
                                UCFightingSkills.IsRequired = true;
                            }
                            else if (!isRequired && UCFightingSkills.IsRequired)
                            {
                                UCFightingSkills.IsRequired = false;
                            }
                        }

                        if (Client != null && Client.FightingSkills != null)
                        {
                            UCFightingSkills.FillDesignValues(Client.FightingSkills);
                        }
                        UCFightingSkills.Index = DesignIndex;

                    }
                    else
                    {
                        if (UCFightingSkills != null)
                        {

                            this.Controls.Remove(UCFightingSkills);
                            UCFightingSkills.Dispose();
                            UCFightingSkills = null;
                        }
                    }
                }
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
                labelPersonalInfo.Index = 0;
            }
            else
            {
                labelPersonalInfo.Index = 0;
            }

            if (labelSportlInfo == null)
            {
                labelSportlInfo = new LabelWithIndex();
                labelSportlInfo.Text = "Sport Informations";
                labelSportlInfo.Font = new System.Drawing.Font("Segoe UI", 14, FontStyle.Bold | FontStyle.Italic);
                labelSportlInfo.ForeColor = Color.Black;
                labelSportlInfo.TextAlign = ContentAlignment.MiddleCenter;
                labelSportlInfo.AutoSize = false;
                labelSportlInfo.Size = new System.Drawing.Size(605, 38);
                labelSportlInfo.Margin = new Padding(3, 3, 3, 3);
                FLPInfo.Controls.Add(labelSportlInfo);
                labelSportlInfo.Index = 100;
            }
            else
            {
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
            controls.Sort((a, b) => ((int)a.GetType().GetProperty("Index").GetValue(a)).CompareTo((int)b.GetType().GetProperty("Index").GetValue(b)));

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



            ClassClient UpdatedOrNewClient = new ClassClient();//only used bel insert client
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

            if (UCBodyshapetarget != null)
            {

                UpdatedOrNewClient.BodyShapeTarget = UCBodyshapetarget.Value;


            }

            if (UCHand != null)
            {
                UpdatedOrNewClient.Hand = UCHand.Value;
            }



            if (UCinjuries != null)
            {
                UpdatedOrNewClient.Injuries = UCinjuries.Value;
            }

            if (UCMusclesfocuson != null)
            {
                UpdatedOrNewClient.MuscleFocusOn = UCMusclesfocuson.Value;
            }

            if (UCSessionperweek != null)
            {
                UpdatedOrNewClient.SessionPerWeek = UCSessionperweek.Value != null ? Convert.ToInt32(UCSessionperweek.Value) : (int?)null;//eza kenit null w eemelneha convert bet sir 0
            }

            if (UCHeight != null)
            {
                UpdatedOrNewClient.Height = UCHeight.Value;
            }
            if (UCWeight != null)
            {
                UpdatedOrNewClient.Weight = UCWeight.Value;
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

            if (UCMaritalstatus != null)
            {
                UpdatedOrNewClient.MaritalStatus = UCMaritalstatus.Value;
            }

            if (UCKnowaboutus != null)
            {
                UpdatedOrNewClient.KnowAboutUs = UCKnowaboutus.Value;
            }

            if (UCTimelinegoals != null)
            {
                UpdatedOrNewClient.GoalsTimeline = UCTimelinegoals.Value;
            }

            if (UCSmoking != null)
            {
                UpdatedOrNewClient.Smoking = UCSmoking.Value;
            }

            if (UCAlcohol != null)
            {
                UpdatedOrNewClient.Alcohol = UCAlcohol.Value;
            }

            if (UCExercisehistory != null)
            {
                UpdatedOrNewClient.ExerciseHistory = UCExercisehistory.Value;
            }

            if (UCSleeppattern != null)
            {
                if (UCSleeppattern.Value != null)
                    UpdatedOrNewClient.SleepPattern = UCSleeppattern.Value;
                else
                    UpdatedOrNewClient.SleepPattern = null;
            }

            if (UCStresslevel != null)
            {
                UpdatedOrNewClient.StressLevel = UCStresslevel.Value;
            }

            if (UCFightingSkills != null)
            {
                UpdatedOrNewClient.FightingSkills = UCFightingSkills.Value;
            }



            if (Client != null)
            {
                Client.IsChild = UpdatedOrNewClient.IsChild;
                Client.ProfileImage = UpdatedOrNewClient.ProfileImage;
                Client.PhoneNumber = UpdatedOrNewClient.PhoneNumber;

                Client.Gender = UpdatedOrNewClient.Gender;
                Client.BirthDate = UpdatedOrNewClient.BirthDate;
                Client.BodyShapeTarget = UpdatedOrNewClient.BodyShapeTarget;
                Client.Hand = UpdatedOrNewClient.Hand;
                Client.Injuries = UpdatedOrNewClient.Injuries;
                Client.MuscleFocusOn = UpdatedOrNewClient.MuscleFocusOn;
                Client.SessionPerWeek = UpdatedOrNewClient.SessionPerWeek;
                Client.Weight = UpdatedOrNewClient.Weight;
                Client.Height = UpdatedOrNewClient.Height;
                Client.Job = UpdatedOrNewClient.Job;
                Client.Adress = UpdatedOrNewClient.Adress;
                Client.Note = UpdatedOrNewClient.Note;
                Client.InstaUserName = UpdatedOrNewClient.InstaUserName;
                Client.Email = UpdatedOrNewClient.Email;
                Client.MaritalStatus = UpdatedOrNewClient.MaritalStatus;
                Client.KnowAboutUs = UpdatedOrNewClient.KnowAboutUs;
                Client.GoalsTimeline = UpdatedOrNewClient.GoalsTimeline;
                Client.Smoking = UpdatedOrNewClient.Smoking;
                Client.Alcohol = UpdatedOrNewClient.Alcohol;
                Client.ExerciseHistory = UpdatedOrNewClient.ExerciseHistory;
                Client.SleepPattern = UpdatedOrNewClient.SleepPattern;
                Client.StressLevel = UpdatedOrNewClient.StressLevel;
                Client.FightingSkills = UpdatedOrNewClient.FightingSkills;
                Client.Fname = UpdatedOrNewClient.Fname;
                Client.Lname = UpdatedOrNewClient.Lname;


                Client.UpdateClientToSQL(PicHasChanged);
            }
            else
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
                    IsPhoneExist = ClassClient.SearchClientPhoneNumberSQL(Client.ClientId, UCPhoneNumber.Value);//update form
                }
                else
                {
                    IsPhoneExist = ClassClient.SearchClientPhoneNumberSQL(null, UCPhoneNumber.Value);//insert form
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
            if (UCHand != null && UCHand.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCHand);
            }
            if (UCBirthDate != null && UCBirthDate.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCBirthDate);
            }
            if (UCBodyshapetarget != null && UCBodyshapetarget.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCBodyshapetarget);
            }
            if (UCinjuries != null && UCinjuries.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCinjuries);
            }
            if (UCMusclesfocuson != null && UCMusclesfocuson.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCMusclesfocuson);
            }
            if (UCSessionperweek != null && UCSessionperweek.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCSessionperweek);
            }

            if (UCHeight != null && UCHeight.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCHeight);
            }
            if (UCWeight != null && UCWeight.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCWeight);
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
            if (UCMaritalstatus != null && UCMaritalstatus.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCMaritalstatus);
            }
            if (UCKnowaboutus != null && UCKnowaboutus.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCKnowaboutus);
            }
            if (UCTimelinegoals != null && UCTimelinegoals.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCTimelinegoals);
            }
            if (UCSmoking != null && UCSmoking.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCSmoking);
            }
            if (UCAlcohol != null && UCAlcohol.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCAlcohol);
            }
            if (UCExercisehistory != null && UCExercisehistory.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCExercisehistory);
            }
            if (UCSleeppattern != null && UCSleeppattern.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCSleeppattern);
            }
            if (UCStresslevel != null && UCStresslevel.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCStresslevel);
            }
            if (UCProfileImage != null && UCProfileImage.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCProfileImage);
            }
            if (UCFightingSkills != null && UCFightingSkills.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(UCFightingSkills);
            }
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
            Program.GreyFormJunior = new GreyColor(this, true, true);
            Program.GreyFormJunior.Show();
            RegistrationFields r = new RegistrationFields(this);
            r.ShowDialog();
        }


        public void SaveOrUpdate(string AlbumName)//album name could be null,w only used on insert NOT UPDATE
        {

            if (Client == null)//insert
            {
                if (ParentId != null)
                {
                    ClassClient.UpdateClientIsParentSQL((int)ParentId, true);
                }
                UpdateOrInsertToSQLAndObj(AlbumName);//album name could be null
                int lastClientId = ClassClient.GetLastClientIDSQL();
                OpenClientManagementForm(lastClientId);
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
                    CustomMessageBox.Show("In order to make the client a child , you need first to remove all his childrens", CustomMessageBox.Type.Error);
                }
                else
                {

                    if (ParentId != null)
                    {
                        ClassClient.UpdateClientIsParentSQL((int)ParentId, true);
                    }

                    if (OldISChild)
                    {
                        RemoveParentIfMust(OldPhoneNumbre, false);
                    }
                    //ma hattaya oldIsparent, cz no way tetghayar IsParent, badna nfout w nodhar ta tetghayar
                    if (Client.IsParent && OldPhoneNumbre != NewPhoneNumber)//we need to change all his children phone number also
                    {
                        Program.IsANewParentAddedOrParentPhoneUpdated = true;
                        ClassClient.UpdateAllChildrensPhoneNumberSQL(OldPhoneNumbre, NewPhoneNumber);
                    }

                    UpdateOrInsertToSQLAndObj(null);//treka hone better

                    ClientManagementProfileForm.UpdateOrCreateUCLabelAndDetail(true);
                    this.Close();
                }

            }
        }

        private void buttonAddToAlbumAndSave_Click(object sender, EventArgs e)
        {
            if (CheckRequired())
            {
                if (!CheckIfDuplicatesPhoneNumberExistAndCannotOccur())
                {
                    Program.GreyFormJunior = new GreyColor(this, true, true);
                    Program.GreyFormJunior.Show();
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
            if (CheckRequired())
            {
                if (!CheckIfDuplicatesPhoneNumberExistAndCannotOccur())
                {
                    SaveOrUpdate(null);
                }
                else
                {
                    MessageBox.Show("Phone Number already exists, please choose another one");
                    FLPInfo.ScrollControlIntoView(UCPhoneNumber);
                }
            }
        }//try catch


        void RemoveParentIfMust(string OldPhoneNumber, bool IsDeleteMode)
        {
            //remove old parent
            DataTable dtParent = ClassClient.GetLinkedPArentsSQL(OldPhoneNumber);//hayda el phone number abel ma yetghyar
            if (dtParent.Rows.Count > 0)//ejbare
            {
                if (IsDeleteMode || radioButtonAdult.Checked || (ParentId != null && (int)dtParent.Rows[0]["client_id"] != ParentId))//case1 we re deleting the client,case2: eza ken child w sar adult /case3: eza ken child w raddayna child la gher parent aw same parent
                {
                    int NumberOfChilds = ClassClient.CalculateNumberOfChildrenSQL(dtParent.Rows[0]["phone_number"].ToString()) - 1;//-1 cz aam nshil hayda, since baaed ma eemelna update aa sql
                    if (NumberOfChilds == 0)
                    {
                        //update parent as adult based aal id
                        ClassClient.UpdateClientIsParentSQL((int)dtParent.Rows[0]["client_id"], false);
                    }
                }
            }

        }

        public void OpenClientManagementForm(int ClientID)
        {
            ClassClient DesiredCLient = ClassClient.CreateClientObject(ClientID);
            //form creation
            Menu menu = ((Home)SearchCurrentClientForm.Tag).menu;
            if (Program.clientManagementProfile == null)
            {
                Program.clientManagementProfile = new ClientManagementProfile(DesiredCLient);

            }
            else
            {
                Program.clientManagementProfile.LoadData(DesiredCLient);
                Program.clientManagementProfile.FormatDatagridviewDesign();
            }
            Program.clientManagementProfile.Size = SearchCurrentClientForm.Size;
            Program.clientManagementProfile.SearchCurrentClientform = SearchCurrentClientForm;
            menu.OpenChildForm(Program.clientManagementProfile, menu.buttonSearchClient, true);
            ((Home)SearchCurrentClientForm.Tag).buttonBackHome.Visible = true;
        }


        private void radioButtonChild_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonChild.Checked)//kermel eza feytin men select parent ha t8ayir la child w teftah l form men awwal w jdid
            {
                IsChildMode = true;

                if (!ISCallingFromTheConstructor)///eza aam aayetla awwal ma teftah el form , kermel ma tfout fiya
                {
                    Program.GreyFormJunior = new GreyColor(this, true, true);
                    Program.GreyFormJunior.Show();
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
                    DialogResult dialogResult = CustomMessageBox.Show("The Client With this Phone Number Already Exists, Do you want to Check its profile?", CustomMessageBox.Type.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int clientid = ClassClient.GetClientIdFromPhoneNumberSQL(UCPhoneNumber.Value);
                        OpenClientManagementForm(clientid);
                        this.Close();
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
            if (Client.IsParent == false)
            {
                // Show a message box with "Yes" and "No" buttons
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
            else
            {
                CustomMessageBox.Show("In order to Delete this Client , you need first to remove all his childrens", CustomMessageBox.Type.Error);
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
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }
    }
}
