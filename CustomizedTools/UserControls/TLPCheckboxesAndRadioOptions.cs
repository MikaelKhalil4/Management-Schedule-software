using GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static GlobalFunctions.ClassGlobalEnum;
using CheckBox = System.Windows.Forms.CheckBox;
using Control = System.Windows.Forms.Control;
using Label = System.Windows.Forms.Label;
using RadioButton = System.Windows.Forms.RadioButton;

namespace CustomizedTools
{

    public class TLPCheckboxesAndRadioOptions : TableLayoutPanel
    {

        public bool IsMotherOrChild { get; set; }//l=child lamma hatt tlp juwwet tlp

        public bool IsCheckBoxesOrRadioButtons { get; set; }//static

        private bool isModeWithRadioTitle;
        public bool IsModeWithTwoRadioTButtons//static
        {
            get { return isModeWithRadioTitle; }
            set { isModeWithRadioTitle = value; }
        }




        private int index;//to order by index in the FLPInfo in newregister
        public int Index
        {
            get { return index; }
            set { index = value; }
        }


        private string value;
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }



        public bool ISActiveRequiredModeOn { get; set; }

        private bool isrequired;
        public bool IsRequired//dynamic
        {
            get { return isrequired; }
            set
            {

                isrequired = value;

                if (!isrequired)//optional
                {

                    if (labelRequired != null)
                    {
                        labelRequired.Dispose();//in case ken mawjud
                        labelRequired = null;
                    }
                    if (labelOptional == null)
                    {

                        CreateLabelOptional();
                        this.Controls.Add(labelOptional, 1, 0);
                    }

                    ISActiveRequiredModeOn = false;

                }
                else//not optional, required
                {
                    if (labelOptional != null)
                    {
                        labelOptional.Dispose();//in case ken mawjud
                        labelOptional = null;
                    }
                    if (labelRequired == null)
                    {
                        CreateLabelRequired();
                        this.Controls.Add(labelRequired, 1, 0);
                    }

                }

            }
        }

        void CreateLabelOptional()
        {
            labelOptional = new Label();
            labelOptional.Anchor = AnchorStyles.Left;
            labelOptional.Text = "(Optional)";
            labelOptional.Font = new Font("Segoe UI", 12f);
            labelOptional.ForeColor = Color.Black;
        }
        void CreateLabelRequired()
        {
            labelRequired = new Label();
            labelRequired.Visible = false;//dynamic
            labelRequired.Anchor = AnchorStyles.Left;
            labelRequired.AutoSize = true;
            labelRequired.Text = "* field is required";
            labelRequired.Font = new Font("Segoe UI", 9.75f);
            labelRequired.ForeColor = Color.Red;
        }


        private string title;
        public string Title//static
        {
            get { return title; }
            set
            {
                title = value;
                CreateLabelTitle();
            }
        }

        void CreateLabelTitle()
        {
            labelTitle = new Label();
            labelTitle.Text = Title;
            labelTitle.Anchor = AnchorStyles.Left;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Semibold", 14.25f, FontStyle.Bold);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Margin = new Padding(0, 3, 0, 0);
        }



        Timer timer1;
        Timer timer2;

        Label labelOptional;
        Label labelTitle;
        public  Label labelRequired;
        FlowLayoutPanel FLPTwoRadioButtons;
        FlowLayoutPanel FLPOptions;


        List<(string, Control, string)> Options { get; set; }//(enumOptionText,OptionText,ControlExtention,Control InitialValueOrPlaceHolde)    
        Font OptionsFont = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

      


        public TLPCheckboxesAndRadioOptions(string title, bool? isrequired, bool isCheckBoxesOrRadioButtons, List<(string, Control, string)> options, string rb1Text, string rb2Text, bool isMotherOrChild)
        {
            IsMotherOrChild = isMotherOrChild;

            if (rb1Text == null && rb2Text == null)
            {
                IsModeWithTwoRadioTButtons = false;
            }
            else
            {
                IsModeWithTwoRadioTButtons = true;
            }

            IsCheckBoxesOrRadioButtons = isCheckBoxesOrRadioButtons;


            if (title != null)
            {
                Title = title;
            }
            if (isrequired != null)
            {
                IsRequired = (bool)isrequired;
            }

            Options = options;

            CreateTlpAndItsComponents(rb1Text, rb2Text);

        }

        //design
        private void CreateTlpAndItsComponents(string rb1Text, string rb2Text)
        {
            //CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;


            timer1 = new Timer();
            timer1.Interval = 1;
            timer1.Tick += Timer1_Tick;

            timer2 = new Timer();
            timer2.Interval = 1;
            timer2.Tick += Timer2_Tick;

            this.ColumnStyles.Clear();
            this.RowStyles.Clear();


            if (Title == null)
            {
                ColumnCount = 1;//ma bi asro directly aal columns but keep track how many columns we have
                this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

                RowCount = 0;
            }
            else
            {
                ColumnCount = 2;//ma bi asro directly aal columns but keep track how many columns we have
                this.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

                RowCount = 1;
                this.RowStyles.Add(new RowStyle(SizeType.Absolute, labelTitle.Height + labelTitle.Margin.Top + labelTitle.Margin.Bottom + 5));
            }





            if (IsModeWithTwoRadioTButtons)
            {


                CreateFlpWithTwoRadioButtons(rb1Text, rb2Text);



                this.RowStyles.Add(new RowStyle(SizeType.Absolute, FLPTwoRadioButtons.Controls[0].Height + FLPTwoRadioButtons.Controls[0].Margin.Top + FLPTwoRadioButtons.Controls[0].Margin.Bottom + 5));
                RowCount++;


                this.Controls.Add(FLPTwoRadioButtons, 0, 1);
                this.SetColumnSpan(FLPTwoRadioButtons, 2);



            }
            else
            {


                CreateFLPOptionsDesign(IsCheckBoxesOrRadioButtons);


                this.RowStyles.Add(new RowStyle(SizeType.Absolute, GetRowHeight(FLPOptions)));
                RowCount++;

                if (RowCount == 2)
                {
                    this.Controls.Add(FLPOptions, 0, 1);
                }
                else
                {
                    this.Controls.Add(FLPOptions, 0, 0);
                }


                if (ColumnCount == 2)
                {
                    this.SetColumnSpan(FLPOptions, 2);
                }



            }

            if (Title != null)
            {
                this.Controls.Add(labelTitle, 0, 0);
            }


            SetTLPGlobalHeight(false);          
            this.Margin = new Padding(3, 5, 3, 5);
            this.Leave += TlpGlobalOptions_Leave;

        }



        public int GetRowHeight(Control DesiredControl)
        {
            int TotalRowHeight = 0;
            foreach (Control control in DesiredControl.Controls)
            {
                TotalRowHeight += control.Height + control.Margin.Top + control.Margin.Bottom;
            }
            return TotalRowHeight += DesiredControl.Margin.Top + DesiredControl.Margin.Bottom;
        }

        int totalTLPHeight;
        void SetTLPGlobalHeight(bool SlideShow)
        {
            totalTLPHeight = 0;
            foreach (RowStyle rowStyle in this.RowStyles)
            {

                totalTLPHeight += (int)rowStyle.Height;

            }

            this.Height = totalTLPHeight;//shil ha eza baddak tredd el slide show

            //shelna el slideshow, lieanno in case of opening the form, caching mode, we re reseting these controls, w eende hole el timer aam yeshteghlo maa 2 other timer, which making a a flickering lieanno my laptop is weak


            //if (SlideShow)
            //{
            //    if (this.Height < totalTLPHeight)//expending
            //    {
            //        timer1.Start();

            //    }
            //    else//shrinking
            //    {
            //        timer2.Start();
            //    }

            //}
            //else
            //{
            //    this.Height = totalTLPHeight;
            //}


        }
        private void Timer1_Tick(object sender, EventArgs e)
        {

            if (this.Height >= totalTLPHeight)
            {
                timer1.Stop();
                this.Height = totalTLPHeight;

            }
            else
            {
                this.Height += 6;

            }


        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (this.Height <= totalTLPHeight)
            {
                timer2.Stop();
                this.Height = totalTLPHeight;

            }
            else
            {
                this.Height -= 6;

            }
        }



        //FLP Option
        void CreateFLPOptionsDesign(bool IsCheckBoxesOrRadioButtons)
        {
            FLPOptions = new FlowLayoutPanel();
            FLPOptions.Dock = DockStyle.Fill;
            FLPOptions.Margin = new Padding(6, 5, 3, 0);
            FLPOptions.FlowDirection = FlowDirection.TopDown;



            if (IsCheckBoxesOrRadioButtons)
            {

                foreach ((string optionString, _, _) in Options)
                {
                    CreateCheckBox(optionString);
                }
            }
            else
            {
                foreach ((string optionString, _, _) in Options)
                {
                    CreateRadioButton(optionString);
                }
            }

        }
        void CreateCheckBox(string text)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.CheckedChanged += CheckBoxOrRadioButton_CheckedChanged;
            checkBox.Font = OptionsFont;
            checkBox.Text = text;
            checkBox.AutoSize = true;
            checkBox.Cursor = Cursors.Hand;
            checkBox.Margin = new Padding(0, 3, 3, 3);
            FLPOptions.Controls.Add(checkBox);
        }
        void CreateRadioButton(string text)
        {
            RadioButton radioButton = new RadioButton();
            radioButton.CheckedChanged += CheckBoxOrRadioButton_CheckedChanged;
            radioButton.Font = OptionsFont;
            radioButton.Text = text;
            radioButton.AutoSize = true;
            radioButton.Cursor = Cursors.Hand;
            radioButton.Margin = new Padding(0, 3, 3, 3);
            FLPOptions.Controls.Add(radioButton);
        }
        private void CheckBoxOrRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            int indexInDesign;
            int indexInList;
            Control DesiredControl;

            if (IsCheckBoxesOrRadioButtons)//checkboxes
            {
                indexInDesign = FLPOptions.Controls.GetChildIndex((CheckBox)sender);
                indexInList = Options.FindIndex(tuple => tuple.Item1 == ((CheckBox)sender).Text);
            }
            else
            {
                indexInDesign = FLPOptions.Controls.GetChildIndex((RadioButton)sender);
                indexInList = Options.FindIndex(tuple => tuple.Item1 == ((RadioButton)sender).Text);
            }

            DesiredControl = Options[indexInList].Item2;


            if (DesiredControl != null)
            {

                bool AddingOrRemoving;
                if (IsCheckBoxesOrRadioButtons)//checkboxes
                {
                    AddingOrRemoving = AddOrRemoveControl(DesiredControl, sender, indexInDesign, Options[indexInList].Item3, true);
                }
                else
                {
                    AddingOrRemoving = AddOrRemoveControl(DesiredControl, sender, indexInDesign, Options[indexInList].Item3, false);
                }
                this.RowStyles[RowCount - 1] = new RowStyle(SizeType.Absolute, GetRowHeight(FLPOptions));


                if (!IsMotherOrChild)//in case we re changing the inside tlp, no timer should be existing
                {
                    SetTLPGlobalHeight(false);
                }
                else
                {
                    if (AddingOrRemoving)
                    {
                        if (indexInDesign == FLPOptions.Controls.Count - 2)
                        {
                            SetTLPGlobalHeight(true);
                        }
                        else
                        {
                            SetTLPGlobalHeight(false);
                        }
                    }
                    else//removing
                    {
                        if (indexInDesign == FLPOptions.Controls.Count - 1)
                        {
                            SetTLPGlobalHeight(true);
                        }
                        else
                        {
                            SetTLPGlobalHeight(false);
                        }
                    }
                }



                DesiredControl.Visible = true;//kermel el slide show yozbat

                if ((Options[indexInList].Item3 == "" && DesiredControl is TextBoxWithPlaceHolder) || !(DesiredControl is TextBoxWithPlaceHolder))//eza ken el placeholder fade ma badna naamil focus aale, all other cases mnaamil 
                {
                    DesiredControl.Focus();
                }

                DesiredControl.Margin = new Padding(21, 0, 0, 0);



                if (!IsMotherOrChild)
                {
                    TLPCheckboxesAndRadioOptions parentTlp = (TLPCheckboxesAndRadioOptions)(this.Parent.Parent);
                    parentTlp.RowStyles[parentTlp.RowCount - 1] = new RowStyle(SizeType.Absolute, GetRowHeight(parentTlp.FLPOptions));//it s geting the wrong row height because el timer ma kholis tbaa el tlp el juwwa
                    parentTlp.SetTLPGlobalHeight(false);
                }


            }

            if (IsCheckBoxesOrRadioButtons)//checkboxes
            {

                //handling the lable required
                if (ISActiveRequiredModeOn)
                {

                    bool allUnchecked = true;
                    if (!((CheckBox)sender).Checked)
                    {
                        foreach (CheckBox cb in FLPOptions.Controls)
                        {
                            if (cb.Checked)
                            {
                                allUnchecked = false;
                                break;
                            }
                        }

                        if (allUnchecked)
                        {
                            labelRequired.Visible = true;
                        }
                        else
                        {
                            labelRequired.Visible = false;
                        }
                    }
                    else
                    {
                        labelRequired.Visible = false;
                    }

                }



                //handling the none
                if (((CheckBox)sender).Text == enumNone.None.GetStringValue())
                {
                    if (((CheckBox)sender).Checked)
                    {
                        foreach (CheckBox cb in FLPOptions.Controls)
                        {
                            if (cb != ((CheckBox)sender))
                            {
                                cb.Enabled = false;
                                cb.Checked = false;
                            }

                        }
                    }
                    else
                    {
                        foreach (CheckBox cb in FLPOptions.Controls)
                        {
                            if (cb != ((CheckBox)sender))
                            {
                                cb.Enabled = true;

                            }
                        }
                    }
                }


            }
            else//radio button
            {
                //handling the lable required
                if (ISActiveRequiredModeOn)
                {
                    labelRequired.Visible = false;
                }
            }

        }
        bool AddOrRemoveControl(Control DesiredControl, object sender, int indexInDesign, string initialvalue, bool isCheckBox)
        {

            if (DesiredControl is TextBoxWithPlaceHolder)
            {
                if ((isCheckBox ? ((CheckBox)sender).Checked : ((RadioButton)sender).Checked))
                {
                    CreateTextBoxWithPlaceHolder((TextBoxWithPlaceHolder)DesiredControl, indexInDesign + 1, initialvalue);
                    return true;
                }

                else
                {
                    FLPOptions.Controls.RemoveAt(indexInDesign + 1);
                    return false;
                }
            }
            else if (DesiredControl is UCNumberButt)
            {
                if ((isCheckBox ? ((CheckBox)sender).Checked : ((RadioButton)sender).Checked))
                {
                    CreateUCPureNumber((UCNumberButt)DesiredControl, indexInDesign + 1, initialvalue);
                    return true;
                }
                else
                {
                    FLPOptions.Controls.RemoveAt(indexInDesign + 1);
                    return false;
                }
            }
            else //we are sure eno tlp ha tkun,bass mafina nhatt condition metel foe in order to all paths returna value
            {
                if ((isCheckBox ? ((CheckBox)sender).Checked : ((RadioButton)sender).Checked))
                {
                    CreatUnkownControl((TLPCheckboxesAndRadioOptions)DesiredControl, indexInDesign + 1, initialvalue);
                    return true;
                }
                else
                {
                    FLPOptions.Controls.RemoveAt(indexInDesign + 1);
                    return false;
                }
            }
        }

        //Creation of control extensions
        void CreateTextBoxWithPlaceHolder(TextBoxWithPlaceHolder textbox, int DesiredIndex, string placeholder)
        {
            textbox.KeyPress += Textbox_KeyPress;
            textbox.TextChanged += Textbox_TextChanged;
            textbox.PlaceholderText = placeholder;
            textbox.Visible = false;
            textbox.Size = new Size(150, 25);
            textbox.Font = OptionsFont;
            FLPOptions.Controls.Add(textbox);
            FLPOptions.Controls.SetChildIndex(textbox, DesiredIndex);


            if (string.IsNullOrEmpty(placeholder))
            {
                textbox.Text = "";

            }

        }
        private void Textbox_TextChanged(object sender, EventArgs e)
        {
            TextBoxWithPlaceHolder textBox = (TextBoxWithPlaceHolder)sender;
            if (ISActiveRequiredModeOn)
            {
                if (textBox.Text != textBox.PlaceholderText || !string.IsNullOrEmpty(textBox.Text))
                {
                    labelRequired.Visible = false;
                }
                else
                {
                    labelRequired.Visible = true;
                }
            }
        }
        private void Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] forbiddenChars = new char[] { '/', '|', ':', '[', ']' };
            if (forbiddenChars.Contains(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        void CreateUCPureNumber(UCNumberButt uCPureNumber, int DesiredIndex, string initialNumber)
        {

            uCPureNumber.Minimum_number = Convert.ToInt32(initialNumber);
            uCPureNumber.Number = Convert.ToInt32(initialNumber);
            uCPureNumber.Visible = false;

            uCPureNumber.Size = new Size(90, 28);
            uCPureNumber.textBoxValue.Font = new Font(uCPureNumber.textBoxValue.Font.FontFamily, 16, uCPureNumber.textBoxValue.Font.Style);

            uCPureNumber.textBoxValue.BackColor = this.BackColor;//kermel tekhud el backccolor mazbut, lezim tkun el tlp already menaamall add aal parent, in update case, that s why men hatt add aal parent abel fillvaluesDesin
            uCPureNumber.buttonValueMinus.BackColor = Color.Transparent;
            uCPureNumber.buttonValuePlus.BackColor = Color.Transparent;

            FLPOptions.Controls.Add(uCPureNumber);
            FLPOptions.Controls.SetChildIndex(uCPureNumber, DesiredIndex);

        }
        void CreatUnkownControl(TLPCheckboxesAndRadioOptions TlpGlobal, int DesiredIndex, string initialNumber)
        {

            FLPOptions.Controls.Add(TlpGlobal);
            FLPOptions.Controls.SetChildIndex(TlpGlobal, DesiredIndex);
        }



        //FLPTwoRadioButtons
        void CreateFlpWithTwoRadioButtons(string rb1Text, string rb2Text)
        {
            FLPTwoRadioButtons = new FlowLayoutPanel();
            FLPTwoRadioButtons.Dock = DockStyle.Fill;
            FLPTwoRadioButtons.Margin = new Padding(6, 5, 3, 0);


            RadioButton radioButton1 = new RadioButton();
            radioButton1.Text = rb1Text;
            radioButton1.Font = OptionsFont;
            radioButton1.AutoSize = true;
            radioButton1.Cursor = Cursors.Hand;
            radioButton1.Margin = new Padding(0, 5, 3, 0);
            radioButton1.CheckedChanged += RadioButtonTwoRadio_CheckedChanged;


            RadioButton radioButton2 = new RadioButton();
            radioButton2.Text = rb2Text;
            radioButton2.Font = OptionsFont;
            radioButton2.AutoSize = true;
            radioButton2.Cursor = Cursors.Hand;
            radioButton2.Margin = new Padding(0, 5, 3, 0);
            radioButton2.CheckedChanged += RadioButtonTwoRadio_CheckedChanged;

            FLPTwoRadioButtons.Controls.Add(radioButton1);
            FLPTwoRadioButtons.Controls.Add(radioButton2);


        }
        private void RadioButtonTwoRadio_CheckedChanged(object sender, EventArgs e)
        {

            if (Options != null && Options.Count > 0)
            {
                RadioButton RadioButton = (RadioButton)sender;
                if (RadioButton.Checked && RadioButton.Text==enumYesNo.Yes.ToString())
                {
                    AddOrRemoveFLPOptions(true);
                }
                else if (!RadioButton.Checked && RadioButton.Text == enumYesNo.Yes.ToString())
                {
                    AddOrRemoveFLPOptions(false);
                }
            }

            //handling the lable required
            if (ISActiveRequiredModeOn)
            {
                labelRequired.Visible = false;
            }
        }

        private void AddOrRemoveFLPOptions(bool IsAddOrRemove)
        {
            if (IsAddOrRemove)
            {
                CreateFLPOptionsDesign(IsCheckBoxesOrRadioButtons);
                this.RowStyles.Add(new RowStyle(SizeType.Absolute, GetRowHeight(FLPOptions)));
                this.Controls.Add(FLPOptions, 0, 2);
                this.SetColumnSpan(FLPOptions, 2);
                RowCount++;

            }
            else
            {

                if (RowCount == 3)
                {
                    this.RowStyles.RemoveAt(RowCount - 1);
                    RowCount--;
                }

                if (this.Controls.Contains(FLPOptions))
                {
                    FLPOptions.Dispose();
                    FLPOptions = null;
                }
            }

            SetTLPGlobalHeight(false);
            this.Focus();

        }




        //Logics
        public bool ActiveRequiredMode()
        {
            ISActiveRequiredModeOn = false;//default value

            if (!IsRequired)
            {
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(this.Value))
                {
                    labelRequired.Visible = true;
                    ISActiveRequiredModeOn = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



        Queue<(string, string)> FillTheQueue(string data, bool IsTlp)
        {
            string Seperator;
            if (!IsTlp)
            {
                Seperator = "/";
            }
            else
            {
                Seperator = "|";
            }


            Queue<(string, string)> myQueue = new Queue<(string, string)>();
            List<string> Title=new List<string>();

            if (data.Contains(Seperator))
            {
                Title = data.Split(new[] { Seperator }, StringSplitOptions.None).ToList();
                FillTuples(myQueue, Title);
            }
            else
            {
                Title.Add(data);
                FillTuples(myQueue, Title);
            }


            return myQueue;
        }
        void FillTuples(Queue<(string, string)>  myQueue, List<string> Title)
        {
            for (int i = 0; i < Title.Count; i++)
            {
                if (Title[i].Contains("[") && Title[i].Contains("]"))
                {
                    string pattern = @"\[(.*?)\]";
                    Match match = Regex.Match(Title[i], pattern);

                    string result = match.Success ? match.Groups[1].Value : "";//ejbare to success w ella ma kenit fetit bel condition men el ases

                    myQueue.Enqueue((Title[i].Split('[')[0], result));
                }
                else if (Title[i].Contains(":"))
                {
                    myQueue.Enqueue((Title[i].Split(':')[0], Title[i].Split(':')[1]));
                }
                else
                {
                    myQueue.Enqueue((Title[i], null));
                }
            }
        }

        public void FillDesignValues(string data)
        {

            if (data != null)
            {
                Queue<(string, string)> myQueue = FillTheQueue(data, false);

                if (isModeWithRadioTitle)//flptworadiobutt exist
                {
                    if (((RadioButton)(FLPTwoRadioButtons.Controls[0])).Text == (myQueue.Peek()).Item1)
                    {
                        ((RadioButton)(FLPTwoRadioButtons.Controls[0])).Checked = true;
                        myQueue.Dequeue();
                    }
                    else if (((RadioButton)(FLPTwoRadioButtons.Controls[1])).Text == (myQueue.Peek()).Item1)
                    {
                        ((RadioButton)(FLPTwoRadioButtons.Controls[1])).Checked = true;
                        myQueue.Dequeue();
                    }

                    if (FLPOptions != null)//true, flp option also exist
                    {
                        FillAllValues(ref myQueue, this.FLPOptions);

                    }

                }
                else//only Flpoption exist, no flptworadiobutt
                {
                    FillAllValues(ref myQueue, this.FLPOptions);
                }


                SetValue();//hek fi values ma elun checkboxes cz eemelna somemodification, bi tiro, kaeanno el system byerjaa bi zabbit halo
            }
        }
        void FillAllValues(ref Queue<(string, string)> myQueue, FlowLayoutPanel DesiredFLPOptions)
        {
            int UnableToFill = 0;
            for (int i = 0; i < DesiredFLPOptions.Controls.Count; i++)
            {
                if (myQueue.Count > 0)
                {
                    i = FillValueOfControlIfPossible(DesiredFLPOptions, i, ref myQueue, ref UnableToFill);
                }
                else
                {
                    break;
                }

            }

        }
        int FillValueOfControlIfPossible(FlowLayoutPanel DesiredFLPOptions, int i, ref Queue<(string, string)> myQueue, ref int UnableToFill)
        {



            (string, string) DesiredTuple = myQueue.Dequeue();


            if (DesiredFLPOptions.Controls[i].Text == DesiredTuple.Item1)
            {
                if (IsCheckBoxesOrRadioButtons)
                {
                    ((CheckBox)DesiredFLPOptions.Controls[i]).Checked = true;
                }
                else
                {
                    ((RadioButton)DesiredFLPOptions.Controls[i]).Checked = true;
                }


                if (DesiredTuple.Item2 != null)
                {

                    int j = i + 1;

                    if (DesiredFLPOptions.Controls[j] is TextBoxWithPlaceHolder)
                    {
                        ((TextBoxWithPlaceHolder)DesiredFLPOptions.Controls[j]).Text = DesiredTuple.Item2;
                        return j;
                    }
                    else if (DesiredFLPOptions.Controls[j] is UCNumberButt)
                    {
                        ((UCNumberButt)DesiredFLPOptions.Controls[j]).Number = Convert.ToInt32(DesiredTuple.Item2);
                        return j;
                    }
                    else if (IsMotherOrChild && DesiredFLPOptions.Controls[j] is TLPCheckboxesAndRadioOptions)//lieeanno eza feytin men child, imposiible ykun fi eena a scase tlp juwwet tlp juwwet tlp, max tlp inside tlp
                    {
                        Queue<(string, string)> myInnerQueue = FillTheQueue(DesiredTuple.Item2, true);
                        if (((TLPCheckboxesAndRadioOptions)DesiredFLPOptions.Controls[j]).FLPOptions != null)//always ha tkun true, flp option in the inner always exist based on this code
                        {
                            FillAllValues(ref myInnerQueue, ((TLPCheckboxesAndRadioOptions)DesiredFLPOptions.Controls[j]).FLPOptions);
                        }
                        return j;
                    }
                    else//shi gher kell el controls li foe, which isnt possible, unless ana kenet hatit shi abel rjeet shelto bi ruh 
                    {
                        return i;
                    }
                }
                else
                {
                    return i;
                }

            }
            else
            {
                //its job enno tkhalil zeit el i, ta emrue aa kell el query , once maraena aa kell el query we move forward to the next i(next checkbox
                UnableToFill++;
                myQueue.Enqueue(DesiredTuple);
                if (UnableToFill < myQueue.Count)
                {
                    return i - 1;
                }
                else
                {
                    UnableToFill = 0;//kermel the coming one
                    return i;
                }


            }
        }



        //format: insta[boosting|visitorTag:Mikael]/tiktok/facebook/bouche a loreiile:daniel
        //so eza ken eendo tlp tenye juwweto ,men hat [], else control aade men hatt :
        public void SetValue()
        {
            if (IsMotherOrChild)//because its handled lamma tkun child
            {
                //we have mode with two radio and mode without,in both  weh ave checkboxes or radio buttons and can have extentions as textbo,ucpure,Tlpglobal
                string valueToFind = "";
                if (isModeWithRadioTitle)
                {
                    if (((RadioButton)(FLPTwoRadioButtons.Controls[0])).Checked == true)//since always the first radio button ha yenzal tahto exxtension
                    {

                        valueToFind += FLPTwoRadioButtons.Controls[0].Text + "/";

                        if (FLPOptions != null)
                        {
                            PickAllValues(ref valueToFind);
                        }
                    }
                    else
                    {
                        valueToFind += FLPTwoRadioButtons.Controls[1].Text + "/";
                    }
                }
                else
                {
                    PickAllValues(ref valueToFind);
                }

                if (!String.IsNullOrEmpty(valueToFind))
                {
                    this.Value = valueToFind.TrimEnd('/');
                }
                else
                {
                    this.Value = null;
                }
            }

        }
        void PickAllValues(ref string valueToFind)
        {
            foreach (Control co in this.FLPOptions.Controls)
            {
                if (!(co is TLPCheckboxesAndRadioOptions))
                {
                    PickValueOfControlIfPossible(co, ref valueToFind, false);
                }
                else
                {
                    valueToFind = valueToFind.Substring(0, valueToFind.Length - 1);
                    valueToFind += "[";
                    foreach (Control InternelCo in ((TLPCheckboxesAndRadioOptions)co).FLPOptions.Controls)
                    {
                        PickValueOfControlIfPossible(InternelCo, ref valueToFind, true);
                    }
                    valueToFind = valueToFind.TrimEnd('|');
                    valueToFind += "]/";

                }
            }
        }
        void PickValueOfControlIfPossible(Control co, ref string valueToFind, bool IsTlp)
        {
            string Seperator;
            if (!IsTlp)
            {
                Seperator = "/";
            }
            else
            {
                Seperator = "|";
            }

            if (IsCheckBoxesOrRadioButtons)//Ma Tensa Eza AADALET SHI HONE,Copy PAste bel w RadioButton instead of CheckBox
            {
                if (co is CheckBox && ((CheckBox)co).Checked)
                {
                    valueToFind += co.Text + Seperator;
                }
                else if (co is TextBoxWithPlaceHolder)
                {
                    if (!String.IsNullOrEmpty(co.Text) && ((TextBoxWithPlaceHolder)co).Text != ((TextBoxWithPlaceHolder)co).PlaceholderText)
                    {
                        valueToFind = valueToFind.Substring(0, valueToFind.Length - 1);
                        valueToFind += ":" + co.Text + Seperator;
                    }
                    else
                    {

                        int secondToLastIndex = valueToFind.LastIndexOf(Seperator, valueToFind.LastIndexOf(Seperator) - 1);

                        // Check if the '/' was found
                        if (secondToLastIndex != -1)
                        {
                            // Include the '/' in the result
                            valueToFind = valueToFind.Substring(0, secondToLastIndex + 1);
                        }
                        else//YANE BAS MNA2YIN OTHERS w el textboxfade
                        {
                            valueToFind = "";
                        }
                    }
                }
                else if (co is UCNumberButt)
                {
                    valueToFind = valueToFind.Substring(0, valueToFind.Length - 1);
                    valueToFind += ":" + ((UCNumberButt)co).Number + Seperator;
                }
            }
            else
            {
                if (co is RadioButton && ((RadioButton)co).Checked)
                {
                    valueToFind += co.Text + Seperator;
                }
                else if (co is TextBoxWithPlaceHolder)
                {
                    if (!String.IsNullOrEmpty(co.Text) && ((TextBoxWithPlaceHolder)co).Text != ((TextBoxWithPlaceHolder)co).PlaceholderText)
                    {
                        valueToFind = valueToFind.Substring(0, valueToFind.Length - 1);
                        valueToFind += ":" + co.Text + Seperator;
                    }
                    else
                    {

                        int secondToLastIndex = valueToFind.LastIndexOf(Seperator, valueToFind.LastIndexOf(Seperator) - 1);


                        if (secondToLastIndex != -1)
                        {
                            valueToFind = valueToFind.Substring(0, secondToLastIndex + 1);
                        }
                        else//YANE BAS MNA2YIN OTHERS w el textboxfade
                        {
                            valueToFind = "";
                        }
                    }
                }
                else if (co is UCNumberButt)
                {
                    valueToFind = valueToFind.Substring(0, valueToFind.Length - 1);
                    valueToFind += ":" + ((UCNumberButt)co).Number + Seperator;
                }
            }
        }


        public void Reset()
        {
            Value = null;
            if (labelRequired != null)//ma that condition zyede,deghre tfiya
            {
                labelRequired.Visible = false;
            }
            ISActiveRequiredModeOn = false;



            if (isModeWithRadioTitle)
            {
                ((RadioButton)(FLPTwoRadioButtons.Controls[0])).Checked = false;
                ((RadioButton)(FLPTwoRadioButtons.Controls[1])).Checked = false;
            }

            if (FLPOptions != null)
            {
                foreach (Control co in this.FLPOptions.Controls)//ma eederna nhatta maa li tahet , lieanno lamma checkbox is false, it s disappearing w maa needar naamela reet
                {
                    if ((co is TLPCheckboxesAndRadioOptions))
                    {
                        ((TLPCheckboxesAndRadioOptions)co).Reset();
                    }
                }

                foreach (Control co in this.FLPOptions.Controls)
                {
                    if (!(co is TLPCheckboxesAndRadioOptions))
                    {
                        if (co is CheckBox)
                        {
                            ((CheckBox)co).Checked = false;
                        }
                        else if (co is RadioButton)
                        {
                            ((RadioButton)co).Checked = false;
                        }
                    }
                  
                }
            }


        }


        private void TlpGlobalOptions_Leave(object sender, EventArgs e)
        {
            SetValue();
        }


    }
}
