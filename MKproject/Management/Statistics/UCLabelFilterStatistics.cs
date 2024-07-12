using CustomizedTools;
using GlobalFunctions;
using System;
using System.Drawing;

namespace MKproject.Management
{
    public class UCLabelFilterStatistics : UCLabelFilterOriginal
    {
        public FiltersCategories Category { get; set; }//if false bet kun Statistics
        public Statistics StatisticsForm { get; set; }
        public enum FiltersCategories
        {
            IncomeSessions,
        }

        public UCLabelFilterStatistics(FiltersCategories type)
        {
            Category = type;

            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelDetail.TextAlign = ContentAlignment.MiddleCenter;

            buttonSwitch.Click += ButtonSwitch_Click;
            buttonRemove.Click += ButtonRemove_Click;
            labelDetail.TextChanged += LabelDetail_TextChanged;
        }

        private void LabelDetail_TextChanged(object sender, EventArgs e)
        {
            if (Category == FiltersCategories.IncomeSessions)
            {
                StatisticsForm.FilterDatatbleIncomeSessions();
                labelDetail.Font = new Font(labelDetail.Font.FontFamily, 12);

                ///
                RandomFunctions.FixedFont(labelDetail,null);
                //SetLabelWidth();aam taamil mashekil
                //TLPAll.Dock = DockStyle.None;
                //TLPAll.Width = itemWidth + buttonRemove.Width + buttonSwitch.Width + 3 * buttonSwitch.Margin.Left + 30;
                //TLPAll.Anchor = AnchorStyles.None;

            }          
        }



        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (Category == FiltersCategories.IncomeSessions)
            {
                StatisticsForm.labelIncome.Select();
                StatisticsForm.FilterDatatbleIncomeSessions();
                StatisticsForm.UCComboFilterDateIncome.comboBoxDetail.SelectedIndex = 0;
            }          
        }



        private void ButtonSwitch_Click(object sender, EventArgs e)
        {
            if (Category == FiltersCategories.IncomeSessions)
            {
                if (StatisticsForm.UCComboFilterDateIncome.comboBoxDetail.SelectedItem.ToString() == UCComboFilterStat.ChooseMonth)
                {
                    StatisticsForm.OpenDateMonthForm(this, (DateTime)Startdate);
                }
                if (StatisticsForm.UCComboFilterDateIncome.comboBoxDetail.SelectedItem.ToString() == UCComboFilterStat.ChooseYear)
                {
                    StatisticsForm.OpenDateYearForm(this, (DateTime)Startdate);
                }
            }          
        }
    }
}
