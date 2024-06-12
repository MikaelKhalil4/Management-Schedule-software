using CustomizedTools;
using GlobalFunctions;
using MKproject.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GlobalFunctions.ClassGlobalEnum;
using static MKproject.ClassClientCustom;
using static MKproject.Management.ClassClient;

namespace MKproject
{
    public class ClassClientCustomFront
    {

        public ClientManagementProfile ExtentionClientManagementProfile { get; set; }
        public NewRegister ExtentionNewRegister { get; set; }

        public ClassClientCustomFront()
        {
                
        }

      


        //ClientManagementProfile
        private UCLabelAndDetail UCSessionPerWeek;
        private UCLabelAndDetail UCHand;
        private UCLabelAndDetail UCInjuries;
        private UCLabelAndDetail UCMuscleFocusOn;
        private UCLabelAndDetail UCShapeTarget;
        private UCLabelAndDetail UCWeight;
        private UCLabelAndDetail UCHeight;
        private UCLabelAndDetail UCGoalsTimeline;
        private UCLabelAndDetail UCAlcohol;
        private UCLabelAndDetail UCSmoking;
        private UCLabelAndDetail UCExerciseHistory;
        private UCLabelAndDetail UCSleepPattern;
        private UCLabelAndDetail UCStressLevel;
        private UCLabelAndDetail UCBoxingSkills;

        public void UpdateOrCreateUCLabelAndDetail(ref bool NewUCCreated, string FieldName, ClassClientCustom Client, bool isVisible)
        {
            if (FieldName == enumDynamicFields.Height.ToString())
            {
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCHeight, enumDynamicFields.Height.GetStringValue(), RandomFunctions.SetStringFormatSpaceInsteadOflash(Client.Height), isVisible, (int)enumDynamicFields.Height);
            }
            else if (FieldName == enumDynamicFields.Weight.ToString())
            {
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCWeight, enumDynamicFields.Weight.GetStringValue(), RandomFunctions.SetStringFormatSpaceInsteadOflash(Client.Weight), isVisible, (int)enumDynamicFields.Weight);
            }
            else if (FieldName == enumDynamicFields.BodyShapeTarget.ToString())
            {
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCShapeTarget, enumDynamicFields.BodyShapeTarget.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.BodyShapeTarget), isVisible, (int)enumDynamicFields.BodyShapeTarget);
            }
            else if (FieldName == enumDynamicFields.MuscleFocusOn.ToString())
            {
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCMuscleFocusOn, enumDynamicFields.MuscleFocusOn.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.MuscleFocusOn), isVisible, (int)enumDynamicFields.MuscleFocusOn);
            }
            else if (FieldName == enumDynamicFields.Injuries.ToString())
            {
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCInjuries, enumDynamicFields.Injuries.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.Injuries), isVisible, (int)enumDynamicFields.Injuries);
            }
            else if (FieldName == enumDynamicFields.Hand.ToString())
            {
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCHand, enumDynamicFields.Hand.GetStringValue(), Client.Hand, isVisible, (int)enumDynamicFields.Hand);
            }

            else if (FieldName == enumDynamicFields.SessionPerWeek.ToString())
            {
                string Details = Client.SessionPerWeek != null ? Convert.ToString(Client.SessionPerWeek) : null;//staamelneha cz eena convertion, w bel convertionn el null bet ruh
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCSessionPerWeek, enumDynamicFields.SessionPerWeek.GetStringValue(), RandomFunctions.SetStringFullFormat(Details), isVisible, (int)enumDynamicFields.SessionPerWeek);
            }
           
         
            else if (FieldName == enumDynamicFields.GoalsTimeline.ToString())
            {
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCGoalsTimeline, enumDynamicFields.GoalsTimeline.GetStringValue(), RandomFunctions.SetStringFormatSpaceInsteadOflash(Client.GoalsTimeline), isVisible, (int)enumDynamicFields.GoalsTimeline);
            }
            else if (FieldName == enumDynamicFields.Smoking.ToString())
            {
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCSmoking, enumDynamicFields.Smoking.GetStringValue(), Client.Smoking, isVisible, (int)enumDynamicFields.Smoking);
            }
            else if (FieldName == enumDynamicFields.Alcohol.ToString())
            {
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCAlcohol, enumDynamicFields.Alcohol.GetStringValue(), Client.Alcohol, isVisible, (int)enumDynamicFields.Alcohol);
            }
            else if (FieldName == enumDynamicFields.ExerciseHistory.ToString())
            {
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCExerciseHistory, enumDynamicFields.ExerciseHistory.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.ExerciseHistory), isVisible, (int)enumDynamicFields.ExerciseHistory);
            }
            else if (FieldName == enumDynamicFields.SleepPattern.ToString())
            {
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCSleepPattern, enumDynamicFields.SleepPattern.GetStringValue(), RandomFunctions.SetStringFormatSpaceInsteadOflash(Client.SleepPattern), isVisible, (int)enumDynamicFields.SleepPattern);
            }
            else if (FieldName == enumDynamicFields.StressLevel.ToString())
            {
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCStressLevel, enumDynamicFields.StressLevel.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.StressLevel), isVisible, (int)enumDynamicFields.StressLevel);
            }
            else if (FieldName == enumDynamicFields.BoxingSkills.ToString())
            {
                NewUCCreated = ExtentionClientManagementProfile.CreateDesiredUCLabelDetails(ref UCBoxingSkills, enumDynamicFields.BoxingSkills.GetStringValue(), RandomFunctions.SetStringFullFormat(Client.FightingSkills), isVisible, (int)enumDynamicFields.BoxingSkills);
            }
        }





        //NEw Register
        private TLPOtherOptions TLPHeight;
        private TLPOtherOptions TLPWeight;
        private TLPOtherOptions TLPTimelinegoals;
        private TLPOtherOptions TLPSleeppattern;

        //two radio buttons
        private TLPCheckboxesAndRadioOptions TLPHand;
        private TLPCheckboxesAndRadioOptions TLPSmoking;
        private TLPCheckboxesAndRadioOptions TLPAlcohol;
        //checkbox or radio buttons with exntension
        private TLPCheckboxesAndRadioOptions TLPExercisehistory;
        private TLPCheckboxesAndRadioOptions TLPStresslevel;
        private TLPCheckboxesAndRadioOptions TLPBodyshapetarget;
        private TLPCheckboxesAndRadioOptions TLPinjuries;
        private TLPCheckboxesAndRadioOptions TLPMusclesfocuson;
        private TLPCheckboxesAndRadioOptions TLPSessionperweek;
        private TLPCheckboxesAndRadioOptions TLPFightingSkills;

     
        
        //custome tools for funtion creating and updating fields
        UCNumberComboButt uc;//in order to access it from the event
        UCNumberComboButt CreateGoalTimeLineUCNumberComboButt()
        {
            if (uc == null)
            {
                uc = new UCNumberComboButt();
                uc.comboBoxUnit.SelectedIndexChanged += ExtentionNewRegister.event_RemoveSelection;
                uc.comboBoxUnit.DropDownClosed += ExtentionNewRegister.event_RemoveSelection;

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
            uc.comboBoxUnit.SelectedIndexChanged += ExtentionNewRegister.event_RemoveSelection;
            uc.comboBoxUnit.DropDownClosed += ExtentionNewRegister.event_RemoveSelection;

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
            uc.comboBoxUnit.SelectedIndexChanged += ExtentionNewRegister.event_RemoveSelection;
            uc.comboBoxUnit.DropDownClosed += ExtentionNewRegister.event_RemoveSelection;

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
       
       


        public  void UpdateOrCreateFields(string FieldName,bool isVisible,bool isRequired,int ControlsWidthInsideFLP,ClassClientCustom Client, FlowLayoutPanel FLPInfo)
        {
              //Dynamic
           if (FieldName == enumDynamicFields.GoalsTimeline.ToString())
            {
                if (isVisible)
                {
                    if (TLPTimelinegoals == null)
                    {

                        TLPTimelinegoals = new TLPOtherOptions(enumDynamicFields.GoalsTimeline.GetStringValue(), isRequired, CreateGoalTimeLineUCNumberComboButt());
                        TLPTimelinegoals.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPTimelinegoals);

                    }
                    else
                    {
                        if (isRequired && !TLPTimelinegoals.IsRequired)
                        {
                            TLPTimelinegoals.IsRequired = true;
                        }
                        else if (!isRequired && TLPTimelinegoals.IsRequired)
                        {
                            TLPTimelinegoals.IsRequired = false;
                        }
                    }

                    if (Client != null && Client.GoalsTimeline != null)//to fill the info if i am editing a client
                    {
                        TLPTimelinegoals.FillDesignValues(Client.GoalsTimeline);
                    }
                    TLPTimelinegoals.Index = (int)enumDynamicFields.GoalsTimeline;

                }
                else
                {
                    if (TLPTimelinegoals != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPTimelinegoals);
                        TLPTimelinegoals.Dispose();
                        TLPTimelinegoals = null;
                    }
                }
            }

            else if (FieldName == enumDynamicFields.Smoking.ToString())
            {
                if (isVisible)
                {
                    if (TLPSmoking == null)
                    {
                        TLPSmoking = new TLPCheckboxesAndRadioOptions(enumDynamicFields.Smoking.GetStringValue(), isRequired, false, null, enumYesNo.Yes.GetStringValue(), enumYesNo.No.GetStringValue(), true);
                        TLPSmoking.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPSmoking);

                    }
                    else
                    {
                        if (isRequired && !TLPSmoking.IsRequired)
                        {
                            TLPSmoking.IsRequired = true;
                        }
                        else if (!isRequired && TLPSmoking.IsRequired)
                        {
                            TLPSmoking.IsRequired = false;
                        }
                    }

                    if (Client != null && Client.Smoking != null)//to fill the info if i am editing a client
                    {
                        TLPSmoking.FillDesignValues(Client.Smoking.ToString());
                    }
                    TLPSmoking.Index = (int)enumDynamicFields.Smoking;

                }
                else
                {
                    if (TLPSmoking != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPSmoking);
                        TLPSmoking.Dispose();
                        TLPSmoking = null;
                    }
                }
            }

            else if (FieldName == enumDynamicFields.Alcohol.ToString())
            {
                if (isVisible)
                {
                    if (TLPAlcohol == null)
                    {
                        TLPAlcohol = new TLPCheckboxesAndRadioOptions(enumDynamicFields.Alcohol.GetStringValue(), isRequired, false, null, enumYesNo.Yes.GetStringValue(), enumYesNo.No.GetStringValue(), true);
                        TLPAlcohol.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPAlcohol);


                    }
                    else
                    {
                        if (isRequired && !TLPAlcohol.IsRequired)
                        {
                            TLPAlcohol.IsRequired = true;
                        }
                        else if (!isRequired && TLPAlcohol.IsRequired)
                        {
                            TLPAlcohol.IsRequired = false;
                        }
                    }

                    if (Client != null && Client.Alcohol != null)//to fill the info if i am editing a client
                    {
                        TLPAlcohol.FillDesignValues(Client.Alcohol.ToString());
                    }
                    TLPAlcohol.Index = (int)enumDynamicFields.Alcohol;

                }
                else
                {
                    if (TLPAlcohol != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPAlcohol);
                        TLPAlcohol.Dispose();
                        TLPAlcohol = null;
                    }
                }
            }

            else if (FieldName == enumDynamicFields.ExerciseHistory.ToString())
            {
                if (isVisible)
                {
                    if (TLPExercisehistory == null)
                    {

                        List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };
                        foreach (enumExerciseHistory enumValue in Enum.GetValues(typeof(enumExerciseHistory)))
                        {
                            if (enumValue == enumExerciseHistory.Others)
                            {
                                ListOptions.Add((enumValue.GetStringValue(), new TextBoxWithPlaceHolder(), ""));
                            }
                            else
                            {
                                ListOptions.Add((enumValue.GetStringValue(), null, null));
                            }
                        }
                        TLPExercisehistory = new TLPCheckboxesAndRadioOptions(enumDynamicFields.ExerciseHistory.GetStringValue(), isRequired, true, ListOptions, null, null, true);
                        TLPExercisehistory.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPExercisehistory);



                    }
                    else
                    {
                        if (isRequired && !TLPExercisehistory.IsRequired)
                        {
                            TLPExercisehistory.IsRequired = true;
                        }
                        else if (!isRequired && TLPExercisehistory.IsRequired)
                        {
                            TLPExercisehistory.IsRequired = false;
                        }
                    }

                    if (Client != null && Client.ExerciseHistory != null)
                    {
                        TLPExercisehistory.FillDesignValues(Client.ExerciseHistory);
                    }
                    TLPExercisehistory.Index = (int)enumDynamicFields.ExerciseHistory;

                }
                else
                {
                    if (TLPExercisehistory != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPExercisehistory);
                        TLPExercisehistory.Dispose();
                        TLPExercisehistory = null;
                    }
                }
            }

            else if (FieldName == enumDynamicFields.SleepPattern.ToString())
            {
                if (isVisible)
                {
                    if (TLPSleeppattern == null)
                    {
                        TLPSleeppattern = new TLPOtherOptions(enumDynamicFields.SleepPattern.GetStringValue(), isRequired, CreateSleepPatternUCNumberLabelButt());
                        TLPSleeppattern.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPSleeppattern);

                    }
                    else
                    {
                        if (isRequired && !TLPSleeppattern.IsRequired)
                        {
                            TLPSleeppattern.IsRequired = true;
                        }
                        else if (!isRequired && TLPSleeppattern.IsRequired)
                        {
                            TLPSleeppattern.IsRequired = false;
                        }
                    }

                    if (Client != null && Client.SleepPattern != null)//to fill the info if i am editing a client
                    {
                        TLPSleeppattern.FillDesignValues(Client.SleepPattern.ToString());
                    }
                    TLPSleeppattern.Index = (int)enumDynamicFields.SleepPattern;

                }
                else
                {
                    if (TLPSleeppattern != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPSleeppattern);
                        TLPSleeppattern.Dispose();
                        TLPSleeppattern = null;
                    }
                }
            }

            else if (FieldName == enumDynamicFields.StressLevel.ToString())
            {
                if (isVisible)
                {
                    if (TLPStresslevel == null)
                    {

                        List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };
                        foreach (enumStressLevel enumValue in Enum.GetValues(typeof(enumStressLevel)))
                        {
                            ListOptions.Add((enumValue.GetStringValue(), null, null));
                        }


                        TLPStresslevel = new TLPCheckboxesAndRadioOptions(enumDynamicFields.StressLevel.GetStringValue(), isRequired, false, ListOptions, null, null, true);
                        TLPStresslevel.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPStresslevel);

                    }
                    else
                    {
                        if (isRequired && !TLPStresslevel.IsRequired)
                        {
                            TLPStresslevel.IsRequired = true;
                        }
                        else if (!isRequired && TLPStresslevel.IsRequired)
                        {
                            TLPStresslevel.IsRequired = false;
                        }
                    }

                    if (Client != null && Client.StressLevel != null)
                    {
                        TLPStresslevel.FillDesignValues(Client.StressLevel);
                    }
                    TLPStresslevel.Index = (int)enumDynamicFields.StressLevel;

                }
                else
                {
                    if (TLPStresslevel != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPStresslevel);
                        TLPStresslevel.Dispose();
                        TLPStresslevel = null;
                    }
                }
            }

            else if (FieldName == enumDynamicFields.BoxingSkills.ToString())
            {
                if (isVisible)
                {
                    if (TLPFightingSkills == null)
                    {

                        List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };

                        foreach (enumFightingSkills enumValue in Enum.GetValues(typeof(enumFightingSkills)))
                        {
                            ListOptions.Add((enumValue.GetStringValue(), null, null));
                        }

                        TLPFightingSkills = new TLPCheckboxesAndRadioOptions(enumDynamicFields.BoxingSkills.GetStringValue(), isRequired, true, ListOptions, enumYesNo.Yes.GetStringValue(), enumYesNo.No.GetStringValue(), true);
                        TLPFightingSkills.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPFightingSkills);


                    }
                    else
                    {
                        if (isRequired && !TLPFightingSkills.IsRequired)
                        {
                            TLPFightingSkills.IsRequired = true;
                        }
                        else if (!isRequired && TLPFightingSkills.IsRequired)
                        {
                            TLPFightingSkills.IsRequired = false;
                        }
                    }

                    if (Client != null && Client.FightingSkills != null)
                    {
                        TLPFightingSkills.FillDesignValues(Client.FightingSkills);
                    }
                    TLPFightingSkills.Index = (int)enumDynamicFields.BoxingSkills;

                }
                else
                {
                    if (TLPFightingSkills != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPFightingSkills);
                        TLPFightingSkills.Dispose();
                        TLPFightingSkills = null;
                    }
                }
            }

            else if (FieldName == enumDynamicFields.Height.ToString())
            {
                if (isVisible)
                {
                    if (TLPHeight == null)
                    {
                        TLPHeight = new TLPOtherOptions(enumDynamicFields.Height.GetStringValue(), isRequired, CreateHeightUCDoubleCombo());
                        TLPHeight.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPHeight);
                    }
                    else
                    {
                        if (isRequired && !TLPHeight.IsRequired)
                        {
                            TLPHeight.IsRequired = true;
                        }
                        else if (!isRequired && TLPHeight.IsRequired)
                        {
                            TLPHeight.IsRequired = false;
                        }
                    }
                    if (Client != null)
                    {
                        TLPHeight.FillDesignValues(Client.Height);
                    }
                    TLPHeight.Index = (int)enumDynamicFields.Height;

                }
                else
                {
                    if (TLPHeight != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPHeight);
                        TLPHeight.Dispose();
                        TLPHeight = null;
                    }
                }
            }

            else if (FieldName == enumDynamicFields.Weight.ToString())
            {
                if (isVisible)
                {
                    if (TLPWeight == null)
                    {
                        TLPWeight = new TLPOtherOptions(enumDynamicFields.Weight.GetStringValue(), isRequired, CreateWeightUCDoubleCombo());
                        TLPWeight.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPWeight);
                    }
                    else
                    {
                        if (isRequired && !TLPWeight.IsRequired)
                        {
                            TLPWeight.IsRequired = true;
                        }
                        else if (!isRequired && TLPWeight.IsRequired)
                        {
                            TLPWeight.IsRequired = false;
                        }
                    }
                    if (Client != null)
                    {
                        TLPWeight.FillDesignValues(Client.Weight);
                    }
                    TLPWeight.Index = (int)enumDynamicFields.Weight;

                }
                else
                {
                    if (TLPWeight != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPWeight);
                        TLPWeight.Dispose();
                        TLPWeight = null;
                    }
                }
            }

            else if (FieldName == enumDynamicFields.BodyShapeTarget.ToString())
            {
                if (isVisible)
                {
                    if (TLPBodyshapetarget == null)
                    {

                        List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };
                        foreach (enumBodyShapeTarget enumValue in Enum.GetValues(typeof(enumBodyShapeTarget)))
                        {
                            ListOptions.Add((enumValue.GetStringValue(), null, null));
                        }


                        TLPBodyshapetarget = new TLPCheckboxesAndRadioOptions(enumDynamicFields.BodyShapeTarget.GetStringValue(), isRequired, true, ListOptions, null, null, true);
                        TLPBodyshapetarget.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPBodyshapetarget);
                    }
                    else
                    {
                        if (isRequired && !TLPBodyshapetarget.IsRequired)
                        {
                            TLPBodyshapetarget.IsRequired = true;
                        }
                        else if (!isRequired && TLPBodyshapetarget.IsRequired)
                        {
                            TLPBodyshapetarget.IsRequired = false;
                        }
                    }
                    if (Client != null && Client.BodyShapeTarget != null)
                    {
                        TLPBodyshapetarget.FillDesignValues(Client.BodyShapeTarget);
                    }
                    TLPBodyshapetarget.Index = (int)enumDynamicFields.BodyShapeTarget;

                }
                else
                {
                    if (TLPBodyshapetarget != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPBodyshapetarget);
                        TLPBodyshapetarget.Dispose();
                        TLPBodyshapetarget = null;
                    }
                }
            }

            else if (FieldName == enumDynamicFields.MuscleFocusOn.ToString())
            {
                if (isVisible)
                {
                    if (TLPMusclesfocuson == null)
                    {



                        List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };

                        foreach (enumMuscleFocusOn enumValue in Enum.GetValues(typeof(enumMuscleFocusOn)))
                        {
                            ListOptions.Add((enumValue.GetStringValue(), null, null));
                        }
                        TLPMusclesfocuson = new TLPCheckboxesAndRadioOptions(enumDynamicFields.MuscleFocusOn.GetStringValue(), isRequired, true, ListOptions, null, null, true);
                        TLPMusclesfocuson.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPMusclesfocuson);


                    }
                    else
                    {
                        if (isRequired && !TLPMusclesfocuson.IsRequired)
                        {
                            TLPMusclesfocuson.IsRequired = true;
                        }
                        else if (!isRequired && TLPMusclesfocuson.IsRequired)
                        {
                            TLPMusclesfocuson.IsRequired = false;
                        }
                    }
                    if (Client != null && Client.MuscleFocusOn != null)
                    {
                        TLPMusclesfocuson.FillDesignValues(Client.MuscleFocusOn);
                    }
                    TLPMusclesfocuson.Index = (int)enumDynamicFields.MuscleFocusOn;

                }
                else
                {
                    if (TLPMusclesfocuson != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPMusclesfocuson);
                        TLPMusclesfocuson.Dispose();
                        TLPMusclesfocuson = null;
                    }
                }
            }

            else if (FieldName == enumDynamicFields.Injuries.ToString())
            {
                if (isVisible)
                {

                    if (TLPinjuries == null)
                    {
                        List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };

                        ListOptions.Add((enumNone.None.GetStringValue(), null, null));

                        foreach (enumInjuries enumValue in Enum.GetValues(typeof(enumInjuries)))
                        {

                            if (enumValue == enumInjuries.Others)
                            {
                                ListOptions.Add((enumValue.GetStringValue(), new TextBoxWithPlaceHolder(), ""));
                            }
                            else
                            {
                                ListOptions.Add((enumValue.GetStringValue(), null, null));
                            }
                        }


                        TLPinjuries = new TLPCheckboxesAndRadioOptions(enumDynamicFields.Injuries.GetStringValue(), isRequired, true, ListOptions, null, null, true);
                        TLPinjuries.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPinjuries);

                    }
                    else
                    {
                        if (isRequired && !TLPinjuries.IsRequired)
                        {
                            TLPinjuries.IsRequired = true;
                        }
                        else if (!isRequired && TLPinjuries.IsRequired)
                        {
                            TLPinjuries.IsRequired = false;
                        }
                    }
                    if (Client != null && Client.Injuries != null)
                    {
                        TLPinjuries.FillDesignValues(Client.Injuries);
                    }
                    TLPinjuries.Index = (int)enumDynamicFields.Injuries;

                }
                else
                {
                    if (TLPinjuries != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPinjuries);
                        TLPinjuries.Dispose();
                        TLPinjuries = null;
                    }
                }
            }

            else if (FieldName == enumDynamicFields.Hand.ToString())
            {
                if (isVisible)
                {
                    if (TLPHand == null)
                    {
                        TLPHand = new TLPCheckboxesAndRadioOptions(enumDynamicFields.Hand.GetStringValue(), isRequired, false, null, RightLeft.Right.GetStringValue(), RightLeft.Left.GetStringValue(), true);
                        TLPHand.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPHand);

                    }
                    else
                    {
                        if (isRequired && !TLPHand.IsRequired)
                        {
                            TLPHand.IsRequired = true;
                        }
                        else if (!isRequired && TLPHand.IsRequired)
                        {
                            TLPHand.IsRequired = false;
                        }
                    }
                    if (Client != null && Client.Hand != null)//to fill the info if i am editing a client
                    {
                        TLPHand.FillDesignValues(Client.Hand);
                    }

                    TLPHand.Index = (int)enumDynamicFields.Hand;

                }
                else
                {
                    if (TLPHand != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPHand);
                        TLPHand.Dispose();
                        TLPHand = null;
                    }
                }
            }

            else if (FieldName == enumDynamicFields.SessionPerWeek.ToString())
            {
                if (isVisible)
                {
                    if (TLPSessionperweek == null)
                    {

                        List<(string, Control, string)> ListOptions = new List<(string, Control, string)> { };
                        foreach (enumSessionPerWeek enumValue in Enum.GetValues(typeof(enumSessionPerWeek)))
                        {
                            ListOptions.Add((enumValue.GetStringValue(), null, null));
                        }
                        TLPSessionperweek = new TLPCheckboxesAndRadioOptions(enumDynamicFields.SessionPerWeek.GetStringValue(), isRequired, false, ListOptions, null, null, true);
                        TLPSessionperweek.Width = ControlsWidthInsideFLP;
                        FLPInfo.Controls.Add(TLPSessionperweek);

                    }
                    else
                    {
                        if (isRequired && !TLPSessionperweek.IsRequired)
                        {
                            TLPSessionperweek.IsRequired = true;
                        }
                        else if (!isRequired && TLPSessionperweek.IsRequired)
                        {
                            TLPSessionperweek.IsRequired = false;
                        }
                    }

                    if (Client != null && Client.SessionPerWeek != null)
                    {
                        TLPSessionperweek.FillDesignValues(Client.SessionPerWeek.ToString());
                    }
                    TLPSessionperweek.Index = (int)enumDynamicFields.SessionPerWeek;

                }
                else
                {
                    if (TLPSessionperweek != null)
                    {

                        ExtentionNewRegister.Controls.Remove(TLPSessionperweek);
                        TLPSessionperweek.Dispose();
                        TLPSessionperweek = null;
                    }
                }
            }

         

          

        }
        public bool CheckRequired(ref bool a,List<Control> RequiredControls)
        {
          
            if (TLPHand != null && TLPHand.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPHand);
            }
            if (TLPBodyshapetarget != null && TLPBodyshapetarget.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPBodyshapetarget);
            }
            if (TLPinjuries != null && TLPinjuries.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPinjuries);
            }
            if (TLPMusclesfocuson != null && TLPMusclesfocuson.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPMusclesfocuson);
            }
            if (TLPSessionperweek != null && TLPSessionperweek.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPSessionperweek);
            }

            if (TLPHeight != null && TLPHeight.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPHeight);
            }
            if (TLPWeight != null && TLPWeight.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPWeight);
            }
          
         
            if (TLPTimelinegoals != null && TLPTimelinegoals.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPTimelinegoals);
            }
            if (TLPSmoking != null && TLPSmoking.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPSmoking);
            }
            if (TLPAlcohol != null && TLPAlcohol.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPAlcohol);
            }
            if (TLPExercisehistory != null && TLPExercisehistory.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPExercisehistory);
            }
            if (TLPSleeppattern != null && TLPSleeppattern.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPSleeppattern);
            }
            if (TLPStresslevel != null && TLPStresslevel.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPStresslevel);
            }
            if (TLPFightingSkills != null && TLPFightingSkills.ActiveRequiredMode())
            {
                a = false;
                RequiredControls.Add(TLPFightingSkills);
            }

            return a;
        }






        //Registation Fields
        public void FormatOriginalDt(DataRow row, string FieldName)
        {
                   
                //Dynamic 
                if (FieldName == enumDynamicFields.Height.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.Height;
                row["FakeFields"] = enumDynamicFields.Height.GetStringValue();
                }
                else if (FieldName == enumDynamicFields.Weight.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.Weight;
                row["FakeFields"] = enumDynamicFields.Weight.GetStringValue();
                }
                else if (FieldName == enumDynamicFields.BodyShapeTarget.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.BodyShapeTarget;
                row["FakeFields"] = enumDynamicFields.BodyShapeTarget.GetStringValue();
                }
                else if (FieldName == enumDynamicFields.MuscleFocusOn.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.MuscleFocusOn;
                row["FakeFields"] = enumDynamicFields.MuscleFocusOn.GetStringValue();
                }
                else if (FieldName == enumDynamicFields.Injuries.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.Injuries;
                row["FakeFields"] = enumDynamicFields.Injuries.GetStringValue();
                }
                else if (FieldName == enumDynamicFields.Hand.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.Hand;
                row["FakeFields"] = enumDynamicFields.Hand.GetStringValue();
                }
                else if (FieldName == enumDynamicFields.SessionPerWeek.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.SessionPerWeek;
                row["FakeFields"] = enumDynamicFields.SessionPerWeek.GetStringValue();
                }
              
             
                else if (FieldName == enumDynamicFields.GoalsTimeline.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.GoalsTimeline;
                row["FakeFields"] = enumDynamicFields.GoalsTimeline.GetStringValue();
                }
                else if (FieldName == enumDynamicFields.Smoking.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.Smoking;
                row["FakeFields"] = enumDynamicFields.Smoking.GetStringValue();
                }
                else if (FieldName == enumDynamicFields.Alcohol.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.Alcohol;
                row["FakeFields"] = enumDynamicFields.Alcohol.GetStringValue();
                }
                else if (FieldName == enumDynamicFields.ExerciseHistory.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.ExerciseHistory;
                row["FakeFields"] = enumDynamicFields.ExerciseHistory.GetStringValue();
                }
                else if (FieldName == enumDynamicFields.SleepPattern.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.SleepPattern;
                row["FakeFields"] = enumDynamicFields.SleepPattern.GetStringValue();
                }
                else if (FieldName == enumDynamicFields.StressLevel.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.StressLevel;
                row["FakeFields"] = enumDynamicFields.StressLevel.GetStringValue();
                }
                else if (FieldName == enumDynamicFields.BoxingSkills.ToString())
                {
                row["design_index"] = (int)enumDynamicFields.BoxingSkills;
                row["FakeFields"] = enumDynamicFields.BoxingSkills.GetStringValue();
                }
            
        }
    }
}
