using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class CBrepeat : Form
    {
        Reminder ReminderForm;


        public CBrepeat(Reminder form1)
        {
            InitializeComponent();
            ReminderForm = form1;

            labelNoRepeat.Text = Reminder.NoRepeat;
            labelDay.Text = Reminder.Everyday;
            labelWeek.Text = Reminder.Everyweek;

            foreach (Label label in panel1.Controls)
            {
                if (label.Text == ReminderForm.labelrepeat.Text)
                {
                    RandomFunctionSchedule.HighlightUserControl(label);
                }
            }
        }


        //Click
        private void labelNoRepeat_Click(object sender, EventArgs e)
        {
            ReminderForm.DesiredReminder.Repeat = Reminder.NoRepeat;
            ReminderForm.labelrepeat.Text = labelNoRepeat.Text;

            ReminderForm.TLPReminder.RowStyles[2] = new RowStyle(SizeType.Absolute, 0F);//0 pixels
            ReminderForm.Height = 360;

            //For the Quote
            string datestart = ReminderForm.GetStringDateStart();
            ReminderForm.labelQuote.Text = "Only for " + datestart;


            //Getting the checkboxes from monday to sunday unchecked
            foreach (CheckBox checkbox in ReminderForm.panelDaysofTheWeek.Controls)
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
            ReminderForm.DesiredReminder.Repeat = Reminder.Everyday;
            ReminderForm.labelrepeat.Text = labelDay.Text;

            ReminderForm.TLPReminder.RowStyles[2] = new RowStyle(SizeType.Absolute, 0F);//0 pixels
            ReminderForm.Height = 360;

            //For the Quote
            //badda teje deghre baeed awal virgule  daily repitition
            string datestart = ReminderForm.GetStringDateStart();
            ReminderForm.labelQuote.Text = "Starting " + datestart + ", a daily repitition";


            //Getting the checkboxes from monday to sunday unchecked
            foreach (CheckBox checkbox in ReminderForm.panelDaysofTheWeek.Controls)
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
            string dayname = ReminderForm.ucSchedule.SelectedDate.DayOfWeek.ToString();
            ReminderForm.DesiredReminder.Repeat = Reminder.Everyweek + "/" + dayname;
            ReminderForm.labelrepeat.Text = labelWeek.Text;

            ReminderForm.TLPReminder.RowStyles[2] = new RowStyle(SizeType.Absolute, 66F);//66 pixels
            ReminderForm.Height = 426;

            //For the Quote
            //badda teje deghre baeed awal virgule  daily repitition on Monday(hasab date tabaee lstart time)
            string datestart = ReminderForm.GetStringDateStart();
            ReminderForm.labelQuote.Text = "Starting " + datestart + ", a weekley repitition on " + dayname;

            //I have to check the date that will be the repitition and this date will be the selected date of the calander
            foreach (CheckBox checkbox in ReminderForm.panelDaysofTheWeek.Controls)
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
            ReminderForm.TBLRepeat.BackColor = Color.FromArgb(206, 220, 255);
            this.Close();
        }


    }
}
