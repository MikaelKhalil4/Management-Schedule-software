using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class CBrepeat : Form
    {
        Reminder reminder;


        public CBrepeat(Reminder form1)
        {
            InitializeComponent();
            reminder = form1;

            labelNoRepeat.Text = Reminder.NoRepeat;
            labelDay.Text = Reminder.Everyday;
            labelWeek.Text = Reminder.Everyweek;

            foreach (Label label in panel1.Controls)
            {
                if (label.Text == reminder.labelrepeat.Text)
                {
                    RandomFunctionSchedule.HighlightUserControl(label);
                }
            }
        }


        //Click
        private void labelNoRepeat_Click(object sender, EventArgs e)
        {
            reminder.typerepeats3 = 1;
            reminder.labelrepeat.Text = labelNoRepeat.Text;
            reminder.panelDaysofTheWeek.Visible = false;

            //For the Quote
            string datestart;
            if (reminder.ucday.DateUCDay.Date == DateTime.Today.Date)
            {
                datestart = "today";
            }
            else
            {
                datestart = reminder.ucday.DateUCDay.Date.ToString("dddd d MMMM");
            }
            reminder.labelQuote.Text = "Only for " + datestart;


            //Getting the checkboxes from monday to sunday unchecked
            foreach (CheckBox checkbox in reminder.panelDaysofTheWeek.Controls)
            {
                if (checkbox.Checked)
                {
                    checkbox.Checked = false;
                }
            }

            this.Close();
        }
        private void labelDay_Click(object sender, EventArgs e)
        {
            reminder.typerepeats3 = 2;
            reminder.labelrepeat.Text = labelDay.Text;
            reminder.panelDaysofTheWeek.Visible = false;

            //For the Quote
            //badda teje deghre baeed awal virgule  daily repitition
            string datestart;
            if (reminder.ucday.DateUCDay.Date == DateTime.Today.Date)
            {
                datestart = "today";
            }
            else
            {
                datestart = reminder.ucday.DateUCDay.Date.ToString("dddd d MMMM");
            }
            reminder.labelQuote.Text = "Starting " + datestart + ", a daily repitition";

            //Getting the checkboxes from monday to sunday unchecked
            foreach (CheckBox checkbox in reminder.panelDaysofTheWeek.Controls)
            {
                if (checkbox.Checked)
                {
                    checkbox.Checked = false;
                }
            }
            this.Close();
        }
        private void labelWeek_Click(object sender, EventArgs e)
        {
            reminder.typerepeats3 = 3;
            reminder.labelrepeat.Text = labelWeek.Text;
            reminder.panelDaysofTheWeek.Visible = true;

            //For the Quote
            //badda teje deghre baeed awal virgule  daily repitition on Monday(hasab date tabaee lstart time)
            string dayname;
            dayname = reminder.ucday.DateUCDay.DayOfWeek.ToString();
            string datestart;
            if (reminder.ucday.DateUCDay.Date == DateTime.Today.Date)
            {
                datestart = "today";
            }
            else
            {
                datestart = reminder.ucday.DateUCDay.Date.ToString("dddd d MMMM");
            }
            reminder.labelQuote.Text = "Starting " + datestart + ", a weekley repitition on " + dayname;

            //I have to check the date that will be the repitition and this date will be the selected date of the calander
            foreach (CheckBox checkbox in reminder.panelDaysofTheWeek.Controls)
            {
                if (dayname == checkbox.Text)
                {
                    checkbox.Checked = true;
                }
            }
            this.Close();
        }


        //Design
        private void labelNoRepeat_MouseMove(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.BackColor = Color.FromArgb(229, 226, 244);
        }
        private void labelNoRepeat_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.BackColor = Color.White;
        }
        private void Repeat_Deactivate(object sender, EventArgs e)
        {
            //Kermel Color tabaee ComboBoxRepeat ybayin disactive
            reminder.TBLRepeat.BackColor = Color.FromArgb(206, 220, 255);
            this.Close();
        }


    }
}
