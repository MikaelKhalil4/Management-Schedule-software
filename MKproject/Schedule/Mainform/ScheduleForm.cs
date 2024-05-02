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
        public UCMonth ucmonths;
        public UCDay ucday;
        public Employee employee;



        //INITIALISE:
        public ScheduleForm()
        {
            InitializeComponent();
            ucday = new UCDay(this);
            ucmonths = new UCMonth(this, ucday);//nkhala2 men halla2 kermel watta a3mil click deghre yendfatah

            ucmonths.Dock = DockStyle.Fill;
            ucday.Dock = DockStyle.Fill;
            ucmonths.Margin = new Padding(10, 15, 10, 10);//(left, top, right, bottom)
            ucday.Margin = new Padding(10, 15, 10, 10);

            tableLayoutPanelForm.Controls.Add(ucday);
            new TouchScroll(panelreminder, this);
        }



        //EVENTS:

        ///-CLICK
        private void buttonAllReminder_Click(object sender, EventArgs e)
        {

        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            Reminder reminder = new Reminder(this, ucday);
            reminder.ShowDialog();
        }

        ///-CHECK BOX
        private void checkBoxCancel_CheckedChanged(object sender, EventArgs e)
        {
            bool IsUCAppCanceldExist = false;
            if (checkBoxCancel.Checked)
            {
                for (int row = 0; row < ucday.TLPAppointment.RowCount; row++)
                {
                    for (int col = 1; col < ucday.TLPAppointment.ColumnCount; col++) // Start from column 1
                    {
                        Control cellControl = ucday.TLPAppointment.GetControlFromPosition(col, row);

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
                for (int row = 0; row < ucday.TLPAppointment.RowCount; row++)
                {
                    for (int col = 1; col < ucday.TLPAppointment.ColumnCount; col++) // Start from column 1
                    {
                        Control cellControl = ucday.TLPAppointment.GetControlFromPosition(col, row);

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
                EditTLPWithUCAppWidth();
            }
        }
        private void checkBoxComplete_CheckedChanged(object sender, EventArgs e)
        {
            bool ISUCAppCompleteExist = false;
            if (checkBoxComplete.Checked)
            {
                for (int row = 0; row < ucday.TLPAppointment.RowCount; row++)
                {
                    for (int col = 1; col < ucday.TLPAppointment.ColumnCount; col++) // Start from column 1
                    {
                        Control cellControl = ucday.TLPAppointment.GetControlFromPosition(col, row);

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
                for (int row = 0; row < ucday.TLPAppointment.RowCount; row++)
                {
                    for (int col = 1; col < ucday.TLPAppointment.ColumnCount; col++) // Start from column 1
                    {
                        Control cellControl = ucday.TLPAppointment.GetControlFromPosition(col, row);

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
                EditTLPWithUCAppWidth();
            }
        }
        private void checkBoxOnPending_CheckedChanged(object sender, EventArgs e)
        {
            bool IsUCAppOnPendingExist = false;
            if (checkBoxOnPending.Checked)
            {
                for (int row = 0; row < ucday.TLPAppointment.RowCount; row++)
                {
                    for (int col = 1; col < ucday.TLPAppointment.ColumnCount; col++) // Start from column 1
                    {
                        Control cellControl = ucday.TLPAppointment.GetControlFromPosition(col, row);

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
                for (int row = 0; row < ucday.TLPAppointment.RowCount; row++)
                {
                    for (int col = 1; col < ucday.TLPAppointment.ColumnCount; col++) // Start from column 1
                    {
                        Control cellControl = ucday.TLPAppointment.GetControlFromPosition(col, row);

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

                EditTLPWithUCAppWidth();
            }
        }



        //FUNCTIONS:
        private void EditTLPWithUCAppWidth()
        {
            bool IsAbsoluteCondition = false;
            int ColumnAbsolute = -1;
            for (int j = 1; j < ucday.TLPAppointment.ColumnCount; j++)
            {
                if (ucday.TLPAppointment.ColumnStyles[j].SizeType is SizeType.Absolute)
                {
                    IsAbsoluteCondition = true;
                    ColumnAbsolute = j;
                }
            }
            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(ucday.TLPEmployees);
            RandomFunctionSchedule.ResizeTableLayoutPanelToPerc(ucday.TLPAppointment);

            if (IsAbsoluteCondition)
            {
                ucday.IsClickEmployeNameToExpandColumn = true;
                ucday.EditTLPWithTheColumnAbsolute(ColumnAbsolute);
                ucday.IsClickEmployeNameToExpandColumn = false;
            }
            else
            {
               
                for (int j = 1; j < ucday.TLPAppointment.ColumnCount; j++)
                {
                    ucday.ResizeWidthAppointmentInTheColumnPecentage(j);
                }
            }
        }
        public void UCDaysClick()
        {
            EditUCDay();
            ucmonths.Hide();
        }//click on a day of UCMONTH
        public void EditUCDay()
        {
            //Scroll
            ucday.TLPAppointment.AutoScrollPosition = new Point(0, 0);
            ucday.TLPAppointment.AutoScrollPosition = new Point(0, ucday.TLPAppointment.rowHeight * 6);
            ucday.VScrollBar1.Value = ucday.TLPAppointment.VerticalScroll.Value;
            ucday.TLPAppointment.currentRow = 6;

            //edit DateUCDay
            if (ucday.SelectedDate.Date != ucmonths.DateUCMonth.Date)
            {
                ucday.SelectedDate = ucmonths.DateUCMonth;
                ucday.displayDay();
            }


            //reminder
            ucday.DisplayUCReminder();

        }// changing DateUCDAY

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