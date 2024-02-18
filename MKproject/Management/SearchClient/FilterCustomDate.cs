using System;
using System.Windows.Forms;
using CustomizedTools;
using GlobalFunctions;


namespace MKproject.Management
{
    public partial class FilterCustomDate : Form
    {
       
        UCLabelFilterOriginal UCCustomDate;


        public FilterCustomDate(UCLabelFilterOriginal uCCustomDate)
        {
            InitializeComponent();
            UCCustomDate = uCCustomDate;
            buttonDone.Enabled = false;


            this.Opacity = 0;
            this.TopMost = true;



            if (uCCustomDate.Startdate == null && uCCustomDate.Enddate == null)
            {
                dateTimePickerStart.Value = DateTime.Now;
                dateTimePickerEnd.Value = DateTime.Now;
                dateTimePickerStart.Checked = false;
                dateTimePickerEnd.Checked = false;
            }
            else if (uCCustomDate.Startdate != null && uCCustomDate.Enddate != null)
            {
                dateTimePickerStart.Value = (DateTime)uCCustomDate.Startdate;
                dateTimePickerEnd.Value = (DateTime)uCCustomDate.Enddate;
                dateTimePickerStart.Checked = true;
                dateTimePickerEnd.Checked = true;
            }
            dateTimePickerStart.MaxDate = DateTime.Now;
            dateTimePickerEnd.MaxDate = DateTime.Now;
            this.Opacity = 0;

        }

       

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            if (buttonDone.Enabled==false)
            {
                buttonDone.Enabled = true;
            }
            dateTimePickerStart.Value = dateTimePickerStart.Value.Date;//kermel nekheda starting at 12:00:00Am
            dateTimePickerEnd.MinDate = dateTimePickerStart.Value.Date;
            if (dateTimePickerEnd.Value.Date < dateTimePickerStart.Value.Date)
            {
                dateTimePickerEnd.Value = dateTimePickerStart.Value.Date;
            }
            dateTimePickerStart.Checked = true;
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (buttonDone.Enabled == false)
            {
                buttonDone.Enabled = true;
            }
            dateTimePickerEnd.Checked = true;
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
           
            string CustomDate= RandomFunctions.SetDateFormatWithoutHour(dateTimePickerStart.Value.ToString()) + " -> " + RandomFunctions.SetDateFormatWithoutHour(dateTimePickerEnd.Value.ToString());
            UCCustomDate.Startdate = dateTimePickerStart.Value;
            UCCustomDate.Enddate = dateTimePickerEnd.Value;
            UCCustomDate.Detail = CustomDate;        
            UCCustomDate.Show();
            this.Close();
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
                this.Select();
            }
            Opacity += .1;
        }

        private void FilterCustomDate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }

        private void FilterCustomDate_Deactivate(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                this.Close();
            }
        }
    }
}
