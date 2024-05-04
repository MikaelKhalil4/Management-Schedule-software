using CustomizedTools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace MKproject.Management
{
    public class UCLabelFilterSearch : UCLabelFilterOriginal
    {
        public FiltersCategories Category { get; set; }//if false bet kun Statistics
        public FilterCheckListSearch FilterCheckListSearchForm { get; set; }
        public enum FiltersCategories
        {
            SaveDate,
            RegisterDate,
            LastVisitDate,
        }


        public UCLabelFilterSearch(FiltersCategories type)
        {
            Category = type;

            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            labelDetail.TextAlign = ContentAlignment.MiddleLeft;
            this.Disposed += UCLabelFilterSearch_Disposed;
            buttonSwitch.Click += ButtonSwitch_Click;
            buttonRemove.Click += ButtonRemove_Click;
            labelDetail.TextChanged += LabelDetail_TextChanged; ;
        }

      

        private void LabelDetail_TextChanged(object sender, EventArgs e)
        {
            FilterCheckListSearchForm.FilterDatable();
            SetLabelWidth();
            TLPAll.Dock = DockStyle.Fill;
        }

        private void LabelDetail_Click(object sender, EventArgs e)
        {

        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {

            Startdate = null;
            Enddate = null;
            this.Dispose();
       
            FilterCheckListSearchForm.ParentFormSearch.pictureBoxSearch.Select();
            FilterCheckListSearchForm.FixGrandParentFilterSize();
            FilterCheckListSearchForm.FilterDatable();
           
        }
        private void UCLabelFilterSearch_Disposed(object sender, EventArgs e)
        {
            if (Category == FiltersCategories.LastVisitDate)
            {
                FilterCheckListSearchForm.UCLastVisit.comboBoxDetail.SelectedIndex = 0;
            }
            else if (Category == FiltersCategories.RegisterDate)
            {
                FilterCheckListSearchForm.UCRegistrationDate.comboBoxDetail.SelectedIndex = 0;
            }
            else if (Category == FiltersCategories.SaveDate)
            {
                FilterCheckListSearchForm.UCSaveDate.comboBoxDetail.SelectedIndex = 0;
            }
        }
        private void ButtonSwitch_Click(object sender, EventArgs e)
        {
            if (Program.GreyForm == null)
            {
                Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);        
                Program.GreyForm.Show();
                FilterCustomDate filterDate = new FilterCustomDate(this);
                filterDate.Show();
            }
        }
    }
}
