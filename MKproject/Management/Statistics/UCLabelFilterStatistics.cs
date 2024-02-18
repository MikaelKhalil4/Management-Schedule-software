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
            Income,
            Sessions
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
            if (Category == FiltersCategories.Income)
            {
                StatisticsForm.FilterDatatbleIncome();
                labelDetail.Font = new Font(labelDetail.Font.FontFamily, 12);

                ///
                RandomFunctions.FixedFont(labelDetail,null);
                //SetLabelWidth();aam taamil mashekil
                //TLPAll.Dock = DockStyle.None;
                //TLPAll.Width = itemWidth + buttonRemove.Width + buttonSwitch.Width + 3 * buttonSwitch.Margin.Left + 30;
                //TLPAll.Anchor = AnchorStyles.None;

            }
            else if (Category == FiltersCategories.Sessions)
            {
                StatisticsForm.FilterDatatbleSessions();
                labelDetail.Font = new Font(labelDetail.Font.FontFamily, 12);

                ///
                RandomFunctions.FixedFont(labelDetail,null);

            }
        }



        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (Category == FiltersCategories.Income)
            {
                StatisticsForm.labelIncome.Select();
                StatisticsForm.FilterDatatbleIncome();
                StatisticsForm.UCComboFilterDateIncome.comboBoxDetail.SelectedIndex = 0;
            }
            else if (Category == FiltersCategories.Sessions)
            {
                StatisticsForm.labelSession.Select();
                StatisticsForm.FilterDatatbleSessions();
                StatisticsForm.UCComboFilterDateSessions.comboBoxDetail.SelectedIndex = 0;
            }
        }



        private void ButtonSwitch_Click(object sender, EventArgs e)
        {
            if (Category == FiltersCategories.Income)
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
            else if (Category == FiltersCategories.Sessions)
            {
                if (StatisticsForm.UCComboFilterDateSessions.comboBoxDetail.SelectedItem.ToString() == UCComboFilterStat.ChooseMonth)
                {
                    StatisticsForm.OpenDateMonthForm(this, (DateTime)Startdate);
                }
                if (StatisticsForm.UCComboFilterDateSessions.comboBoxDetail.SelectedItem.ToString() == UCComboFilterStat.ChooseYear)
                {
                    StatisticsForm.OpenDateYearForm(this, (DateTime)Startdate);
                }
            }
        }
    }
}
