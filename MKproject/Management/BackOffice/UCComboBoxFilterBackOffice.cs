using System;
using System.Data;
using GlobalFunctions;
using CustomizedTools;

namespace MKproject.Management
{
    public partial class UCComboBoxFilterBackOffice : UCComboBoxFilterOriginal
    {
        public BackOffice ParentFormBackOffice { get; set; }
        public enum FiltersType
        {
            Date,
            Actions,
            Employee
        }
      
        public static string All = "All";
        public static string Today = "Today", Last7Days = "Last 7 Days", Last30Days = "Last 30 days", Last90Days = "Last 90 days", Last365Days = "Last 365 Days";

       
        private FiltersType filterType;
        public FiltersType FilterType
        {
            get { return filterType; }
            set
            {
                filterType = value;
                SetValuesForComboBox();
            }
        }//try catch
       
        
        public UCComboBoxFilterBackOffice()
        {
          
            comboBoxDetail.SelectedIndexChanged += ComboBoxDetail_SelectedIndexChanged;
          
        }

        bool IsOneYearOrAll=false;//default value, lieanno we re selecting Today at the start, so badna nhatta kaeanno all kermel tfout bel condition tahet
      
        public event EventHandler ComboBoxDetailSelectedIndexChanged;
        private void ComboBoxDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
             ComboBoxDetailSelectedIndexChanged?.Invoke(this, e);
            if (LastState != comboBoxDetail.SelectedItem.ToString())
            {
                ParentFormBackOffice.FilterDatable();
            }
            LastState = comboBoxDetail.SelectedItem.ToString();
        }//try cach

        public void SetValuesForComboBox()
        {
            if (filterType == FiltersType.Actions)
            {
                comboBoxDetail.Items.Add(All);
                comboBoxDetail.Items.Add(ActionsEnum.Purchases.GetStringValue());
                comboBoxDetail.Items.Add(ActionsEnum.Payments.GetStringValue());
                comboBoxDetail.Items.Add(ActionsEnum.Offers.GetStringValue());
                comboBoxDetail.Items.Add(ActionsEnum.SessionDone.GetStringValue());
            }
            else if (filterType == FiltersType.Date)
            {
                comboBoxDetail.Items.Add(Today);
                comboBoxDetail.Items.Add(Last7Days);
                comboBoxDetail.Items.Add(Last30Days);
                comboBoxDetail.Items.Add(Last90Days);
                comboBoxDetail.Items.Add(Last365Days);
                comboBoxDetail.Items.Add(All);

            }
            else if (filterType == FiltersType.Employee)
            {
                comboBoxDetail.Items.Add(All);

                DataTable dtEmployees = ClassEmployee.GetActiveEmployees();
                foreach (DataRow Employee in dtEmployees.Rows)
                {
                    comboBoxDetail.Items.Add(Employee["first_name"] + " " + Employee["last_name"]);
                }
            }
            SetUCComboBoxWidth(this, comboBoxDetail, labelTitle);
        }//try catch
    }
}
