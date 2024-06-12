using System;
using System.Drawing;
using System.Windows.Forms;


namespace CustomizedTools
{
    public class TLPOtherOptions : TableLayoutPanel
    {
        Label labelOptional;
        Label labelTitle;
        Label labelRequired;


        public Control DesiredControl { get; set; }

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


        public TLPOtherOptions(string title, bool? isrequired, Control desiredControl)
        {
            Title = title;
            IsRequired = (bool)isrequired;
            DesiredControl = desiredControl;


            ColumnCount = 2;
            this.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            RowCount = 2;
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, labelTitle.Height + labelTitle.Margin.Top + labelTitle.Margin.Bottom + 5));
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, DesiredControl.Height + DesiredControl.Margin.Top + DesiredControl.Margin.Bottom));

            this.Controls.Add(labelTitle, 0, 0);
            this.Controls.Add(DesiredControl, 0, 1);
            this.SetColumnSpan(DesiredControl, 2);


        
            this.Margin = new Padding(3, 5, 3, 5);
            this.Leave += TLPOtherOptions_Leave;


            DesiredControl.Anchor = AnchorStyles.Left;
            if (DesiredControl is UCNumberComboButt)
            {
                ((UCNumberComboButt)DesiredControl).ucPureNumber1.TextBoxValueTextBoxValueTextChange += UCNumberComboButt_TextBoxValueTextBoxValueTextChange;
            }
            else if (DesiredControl is UCNumberLabelButt)
            {
                ((UCNumberLabelButt)DesiredControl).textBoxValueTextChanged += UCNumberLabelButt_textBoxValueTextChanged; ;
            }
            else if (DesiredControl is UCDoubleCombo)
            {
                ((UCDoubleCombo)DesiredControl).textBoxValueTextChanged += UCDoubleCombo_textBoxValueTextChanged; ;
            }
            else if (DesiredControl is DateTimePicker)
            {
                ((DateTimePicker)DesiredControl).ValueChanged += DateTimePicker_ValueChanged;
            }



        }



        private void UCDoubleCombo_textBoxValueTextChanged(object sender, EventArgs e)
        {

            if (ISActiveRequiredModeOn)
            {
                if (((UCDoubleCombo)sender).textBoxValue.Text == "0")
                {

                    labelRequired.Visible = true;

                }
                else
                {
                    labelRequired.Visible = false;
                }

            }
        }
        private void UCNumberComboButt_TextBoxValueTextBoxValueTextChange(object sender, EventArgs e)
        {

            if (ISActiveRequiredModeOn)
            {
                //only hone hattayna UCNumberButt instead UCNumberComboButt, eena uc juwwet uc
                if (((UCNumberButt)sender).textBoxValue.Text == "0")
                {

                    labelRequired.Visible = true;

                }
                else
                {
                    labelRequired.Visible = false;
                }

            }

        }
        private void UCNumberLabelButt_textBoxValueTextChanged(object sender, EventArgs e)
        {
            if (ISActiveRequiredModeOn)
            {
                if (((UCNumberLabelButt)sender).textBoxValue.Text == "0")
                {

                    labelRequired.Visible = true;

                }
                else
                {
                    labelRequired.Visible = false;
                }
            }
        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (ISActiveRequiredModeOn)
            {
                if (((DateTimePicker)sender).Value.Date == DateTime.Today)
                {
                    labelRequired.Visible = true;

                }
                else
                {
                    labelRequired.Visible = false;
                }
            }

        }




        public void FillDesignValues(string data)
        {
            if (data != null)
            {
                if (DesiredControl is UCNumberComboButt)
                {
                    UCNumberComboButt uc = (UCNumberComboButt)DesiredControl;
                    string[] substrings = data.Split('/');
                    uc.ucPureNumber1.Number = Convert.ToInt32(substrings[0]);
                    uc.comboBoxUnit.SelectedIndex = uc.comboBoxUnit.FindString(substrings[1]);
                }
                else if (DesiredControl is UCNumberLabelButt)
                {
                    UCNumberLabelButt uc = (UCNumberLabelButt)DesiredControl;
                    string[] substrings = data.Split('/');
                    uc.Number = Convert.ToInt32(substrings[0]);
                    uc.Unit = substrings[1];
                }
                else if (DesiredControl is UCDoubleCombo)
                {
                    UCDoubleCombo uc = (UCDoubleCombo)DesiredControl;
                    string[] Weightparts = data.Split('/');

                    double value = Convert.ToDouble(Weightparts[0]);
                    string unit = Weightparts[1];

                    uc.Number = value;
                    uc.comboBoxUnit.SelectedIndex = uc.comboBoxUnit.FindString(unit);


                }
                else if (DesiredControl is DateTimePicker)
                {
                    DateTimePicker DateTimePicker = (DateTimePicker)DesiredControl;
                    DateTimePicker.Value = Convert.ToDateTime(data);//la2n l type taba3na fiyo ?

                }
                SetValue();
            }
        }
        public void SetValue()
        {//ased hattay uc.textbox.text instead of uc.number, lieanno sometimes aam bet fout bel event tlp leave, abel ma taamil setup lal Number
            if (DesiredControl is UCNumberComboButt)
            {
                UCNumberComboButt uc = (UCNumberComboButt)DesiredControl;
                if (uc.ucPureNumber1.Number != 0)
                {
                    Value = uc.ucPureNumber1.textBoxValue.Text + "/" + uc.comboBoxUnit.Text;
                }
                else
                {
                    Value = null;
                }
            }
            else if (DesiredControl is UCNumberLabelButt)
            {
                UCNumberLabelButt uc = (UCNumberLabelButt)DesiredControl;
                if (uc.Number != 0)
                {
                    Value = uc.textBoxValue.Text + "/" + uc.labelUnit.Text;
                }
                else
                {
                    Value = null;
                }

            }
            else if (DesiredControl is UCDoubleCombo)
            {
                UCDoubleCombo uc = (UCDoubleCombo)DesiredControl;
                if (uc.Number != 0)
                {
                    Value = uc.textBoxValue.Text + "/" + uc.comboBoxUnit.Text;
                }
                else
                {
                    Value = null;
                }
            }
            else if (DesiredControl is DateTimePicker)
            {
                DateTimePicker DateTimePicker = (DateTimePicker)DesiredControl;
                if (DateTimePicker.Value.Date != DateTime.Today)
                {
                    Value = DateTimePicker.Value.ToString();
                }
                else
                {
                    Value = null;
                }

            }
        }
       
        //battalit moustaamela bas treka in case
        public void Reset()
        {
            Value = null;
            if (labelRequired != null)//ma that condition zyede,deghre tfiya
            {
                labelRequired.Visible = false;
            }
            ISActiveRequiredModeOn = false;


            if (DesiredControl is UCNumberComboButt)
            {
                UCNumberComboButt uc = (UCNumberComboButt)DesiredControl;
                uc.comboBoxUnit.SelectedIndex = 0;
                uc.ucPureNumber1.Number = uc.ucPureNumber1.Minimum_number;
            }
            else if (DesiredControl is UCNumberLabelButt)
            {
                UCNumberLabelButt uc = (UCNumberLabelButt)DesiredControl;
                uc.Number = 0;

            }
            else if (DesiredControl is UCDoubleCombo)
            {
                UCDoubleCombo uc = (UCDoubleCombo)DesiredControl;
                uc.Number = 0;
                uc.comboBoxUnit.SelectedIndex = 0;

            }
            else if (DesiredControl is DateTimePicker)
            {
                DateTimePicker DateTimePicker = (DateTimePicker)DesiredControl;
                DateTimePicker.MaxDate = DateTime.Today;
                DateTimePicker.Value = DateTime.Today;
            }
        }




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




        private void TLPOtherOptions_Leave(object sender, EventArgs e)
        {
            SetValue();
        }
    }
}
