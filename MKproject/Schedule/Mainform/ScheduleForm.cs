using MKproject.Management;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class ScheduleForm : Form
    {
        //Properties:
        public TouchScroll TouchscrollPanelreminder { get; set; }

        //VARIABLES:
        public CalanderForm calanderForm;
        public UCSchedule ucSchedule;
        public Employee employee;



        //INITIALISE:
        public ScheduleForm()
        {
            InitializeComponent();
            ucSchedule = new UCSchedule(this);
            calanderForm = new CalanderForm(this, ucSchedule.SelectedDate);//nkhala2 men halla2 kermel watta a3mil click deghre yendfatah
            calanderForm.Dock = DockStyle.Fill;
            ucSchedule.Dock = DockStyle.Fill;
            calanderForm.Margin = new Padding(10, 15, 10, 10);//(left, top, right, bottom)
            ucSchedule.Margin = new Padding(10, 10, 0, 0);

            TLPSide.Margin = new Padding(0, 0, 0, 0);
            tableLayoutPanelForm.Controls.Add(ucSchedule, 1, 0);
        }


        //EVENTS:

        ///-CLICK
        private void buttonAllReminder_Click(object sender, EventArgs e)
        {
            ClientReminder clientReminderForm = new ClientReminder(null, this, ucSchedule);
            clientReminderForm.ShowDialog();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            Reminder reminder = new Reminder(this, ucSchedule);
            reminder.ShowDialog();
        }

        ///-CHECK BOX
        private void checkBoxCancel_CheckedChanged(object sender, EventArgs e)
        {
            bool IsUCAppCanceldExist = false;
            if (checkBoxCancel.Checked)
            {
                for (int row = 0; row < ucSchedule.TLPSchedule.RowCount; row++)
                {
                    for (int col = 1; col < ucSchedule.TLPSchedule.ColumnCount; col++) // Start from column 1
                    {
                        Control cellControl = ucSchedule.TLPSchedule.GetControlFromPosition(col, row);

                        if (cellControl is FlowLayoutPanel flowLayoutPanel)
                        {
                            foreach (Control innerControl in flowLayoutPanel.Controls)
                            {
                                if (innerControl is UCappointment ucappointment &&
                                    ucappointment.DesiredAppointmentUCApp.IsCanceled == true)
                                {
                                    ucappointment.Show();
                                    IsUCAppCanceldExist = true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int row = 0; row < ucSchedule.TLPSchedule.RowCount; row++)
                {
                    for (int col = 1; col < ucSchedule.TLPSchedule.ColumnCount; col++) // Start from column 1
                    {
                        Control cellControl = ucSchedule.TLPSchedule.GetControlFromPosition(col, row);

                        if (cellControl is FlowLayoutPanel flowLayoutPanel)
                        {
                            foreach (Control innerControl in flowLayoutPanel.Controls)
                            {
                                if (innerControl is UCappointment ucappointment &&
                                    ucappointment.DesiredAppointmentUCApp.IsCanceled == true)
                                {
                                    ucappointment.Hide();
                                    IsUCAppCanceldExist = true;
                                }
                            }
                        }
                    }
                }
            }
            if (IsUCAppCanceldExist)
            {
                ucSchedule.PercentageResizeTLPScheduleAndTlpEmp();
            }
        }
        private void checkBoxComplete_CheckedChanged(object sender, EventArgs e)
        {
            bool ISUCAppCompleteExist = false;
            if (checkBoxComplete.Checked)
            {
                for (int row = 0; row < ucSchedule.TLPSchedule.RowCount; row++)
                {
                    for (int col = 1; col < ucSchedule.TLPSchedule.ColumnCount; col++) // Start from column 1
                    {
                        Control cellControl = ucSchedule.TLPSchedule.GetControlFromPosition(col, row);

                        if (cellControl is FlowLayoutPanel flowLayoutPanel)
                        {
                            foreach (Control innerControl in flowLayoutPanel.Controls)
                            {
                                if (innerControl is UCappointment ucappointment &&
                                    ucappointment.DesiredAppointmentUCApp.IsCompleted == true)
                                {
                                    ucappointment.Show();
                                    ISUCAppCompleteExist = true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int row = 0; row < ucSchedule.TLPSchedule.RowCount; row++)
                {
                    for (int col = 1; col < ucSchedule.TLPSchedule.ColumnCount; col++) // Start from column 1
                    {
                        Control cellControl = ucSchedule.TLPSchedule.GetControlFromPosition(col, row);

                        if (cellControl is FlowLayoutPanel flowLayoutPanel)
                        {
                            foreach (Control innerControl in flowLayoutPanel.Controls)
                            {
                                if (innerControl is UCappointment ucappointment &&
                                    ucappointment.DesiredAppointmentUCApp.IsCompleted == true)
                                {
                                    ucappointment.Hide();
                                    ISUCAppCompleteExist = true;
                                }
                            }
                        }
                    }
                }
            }
            if (ISUCAppCompleteExist)
            {
                ucSchedule.PercentageResizeTLPScheduleAndTlpEmp();
            }
        }
        private void checkBoxOnPending_CheckedChanged(object sender, EventArgs e)
        {
            bool IsUCAppOnPendingExist = false;
            if (checkBoxOnPending.Checked)
            {
                for (int row = 0; row < ucSchedule.TLPSchedule.RowCount; row++)
                {
                    for (int col = 1; col < ucSchedule.TLPSchedule.ColumnCount; col++) // Start from column 1
                    {
                        Control cellControl = ucSchedule.TLPSchedule.GetControlFromPosition(col, row);

                        if (cellControl is FlowLayoutPanel flowLayoutPanel)
                        {
                            foreach (Control innerControl in flowLayoutPanel.Controls)
                            {
                                if (innerControl is UCappointment ucappointment &&
                                     ucappointment.DesiredAppointmentUCApp.IsCompleted == false && ucappointment.DesiredAppointmentUCApp.IsCanceled == false)
                                {
                                    ucappointment.Show();
                                    IsUCAppOnPendingExist = true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int row = 0; row < ucSchedule.TLPSchedule.RowCount; row++)
                {
                    for (int col = 1; col < ucSchedule.TLPSchedule.ColumnCount; col++) // Start from column 1
                    {
                        Control cellControl = ucSchedule.TLPSchedule.GetControlFromPosition(col, row);

                        if (cellControl is FlowLayoutPanel flowLayoutPanel)
                        {
                            foreach (Control innerControl in flowLayoutPanel.Controls)
                            {
                                if (innerControl is UCappointment ucappointment &&
                                    ucappointment.DesiredAppointmentUCApp.IsCompleted == false && ucappointment.DesiredAppointmentUCApp.IsCanceled == false)
                                {
                                    ucappointment.Hide();
                                    IsUCAppOnPendingExist = true;
                                }
                            }
                        }
                    }
                }
            }

            if (IsUCAppOnPendingExist)
            {

                ucSchedule.PercentageResizeTLPScheduleAndTlpEmp();
            }
        }

    }
}


///protected override CreateParams CreateParams
//{
//    get
//    {
//        CreateParams cp = base.CreateParams;
//        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
//        return cp;
//    }
//}


///private void flowLayoutPanelReminder_Paint(object sender, PaintEventArgs e)
//{
//    using (Pen Pen = new Pen(Color.FromArgb(109, 122, 224), 1)) // 2 is the width of the border
//    {
//        // Get the panel
//        Panel panel = sender as Panel;

//        // Draw the red border around the panel
//        e.Graphics.DrawRectangle(Pen, new Rectangle(0, 0, panel.Width - 1, panel.Height - 1));
//    }
//}


///public bool isautobuttonD { get; set; }//kermel wa2et a3mil click lal ucdays w byerja3 click aal buttonD ma yerjaee yaeemil calander date generate aal date tabaee calander month l2adim
///bool isucmonths = false; //awalshi bet koun false watta yenfatah lschedule
/// isucmonths = false;