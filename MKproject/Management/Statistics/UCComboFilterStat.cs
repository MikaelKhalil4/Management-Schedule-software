using CustomizedTools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Management
{
    public class UCComboFilterStat : UCComboBoxFilterOriginal
    {
        public Statistics StatisticsForm { get; set; }


        public static string All = "All";

        public static string ThisMonth = "This Month", LastMonth = "Last Month", ThisYear = "This Year", LastYear = "Last Year", AllYears = "All Years", ChooseMonth = "Choose Month", ChooseYear = "Choose year";
        public static string Services = "Services", Products = "Products";



        public enum FiltersType
        {

            DateSessions,
            DateIncome,
            TypeIncome,
            ServiceIncome
        }


        private FiltersType filterType;
        public FiltersType FilterType
        {
            get { return filterType; }
            set
            {
                filterType = value;
                SetValuesForComboBox();
            }
        }


        public UCComboFilterStat()
        {
            comboBoxDetail.SelectedIndexChanged += ComboBoxDetail_SelectedIndexChanged;

            this.Size = new Size(133, 64);
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            TLP.RowStyles[0] = new RowStyle(SizeType.Percent, 40);
            TLP.RowStyles[1] = new RowStyle(SizeType.Percent, 60);
            labelTitle.Dock = DockStyle.Bottom;
            comboBoxDetail.Dock = DockStyle.None;
            comboBoxDetail.Anchor = AnchorStyles.None;
        }

        private void ComboBoxDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LastState != comboBoxDetail.SelectedItem.ToString())
            {
                DateTime currentDate = DateTime.Now;

                if (filterType == FiltersType.DateSessions)
                {

                    StatisticsForm.CreateUCCustomeDateSessions();
                }

                else if (filterType == FiltersType.DateIncome || filterType == FiltersType.TypeIncome || filterType == FiltersType.ServiceIncome)
                {
                    if (filterType == FiltersType.DateIncome)
                    {
                        StatisticsForm.CreateUCCustomeDateIncome();
                    }
                    else
                    {
                        StatisticsForm.FilterDatatbleIncome();
                    }

                }
            }

            LastState = comboBoxDetail.SelectedItem.ToString();

        }

        public void SetValuesForComboBox()
        {
            if (filterType == FiltersType.TypeIncome)
            {
                comboBoxDetail.Items.Add(All);
                comboBoxDetail.Items.Add(UCComboBoxFilterSearch.Member);
                comboBoxDetail.Items.Add(UCComboBoxFilterSearch.Visitor);
                comboBoxDetail.Items.Add(UCComboBoxFilterSearch.NoneVisitor);

            }

            else if (filterType == FiltersType.DateSessions || filterType == FiltersType.DateIncome)
            {
                comboBoxDetail.Items.Add(ThisMonth);
                comboBoxDetail.Items.Add(LastMonth);
                comboBoxDetail.Items.Add(ChooseMonth);
                comboBoxDetail.Items.Add(ThisYear);
                comboBoxDetail.Items.Add(LastYear);
                comboBoxDetail.Items.Add(ChooseYear);
                comboBoxDetail.Items.Add(AllYears);
            }
            else if (filterType == FiltersType.ServiceIncome)
            {
                comboBoxDetail.Items.Add(All);
                comboBoxDetail.Items.Add(Services);
                comboBoxDetail.Items.Add(Products);


            }
            comboBoxDetail.SelectedIndex = 0;



        }

    }
}
