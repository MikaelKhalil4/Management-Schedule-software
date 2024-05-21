using MKproject.Management;
using System;
using System.Collections.Generic;
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
        public UCSchedule ucSchedule;
        public Employee employee;



        //INITIALISE:
        public ScheduleForm()
        {
            InitializeComponent();


            TLPSide.Margin = new Padding(0, 0, 0, 0);

            ucSchedule = new UCSchedule(this);
            ucSchedule.Dock = DockStyle.Fill;
            ucSchedule.Margin = new Padding(10, 10, 0, 0);

            tableLayoutPanelForm.Controls.Add(ucSchedule, 1, 0);
            ucSchedule.ScrollToRow(ucSchedule.GetRowFromTime(DateTime.Now.TimeOfDay,false));//leh hattina marrra tenye hone , maa enno mawjude bel load, form, cz hone la tekhud el form the right size

            //ejare tahet ucSchedule
            ucmonths = new UCMonth(this, ucSchedule);//nkhala2 men halla2 kermel watta a3mil click deghre yendfatah
            ucmonths.Dock = DockStyle.Fill;
            ucmonths.Margin = new Padding(10, 15, 10, 10);//(left, top, right, bottom)

        }


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
        private void checkBoxOnPending_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (checkBoxOnPending.Checked)
            {
              foreach (ClassAppointment desiredAppointment in ucSchedule.AppointmentsList)
                {
                    if (!desiredAppointment.IsCompleted && !desiredAppointment.IsCanceled)
                    {
                        ucSchedule.AddUCappointmentsInTLP(desiredAppointment);
                    }
                }
            }
            else
            {
                List<UCappointment> ControlsShouldBeRemoved = new List<UCappointment>();
                foreach (Control control in ucSchedule.TLPSchedule.Controls)
                {
                    if (control is UCappointment)
                    {
                        UCappointment DesiredUC=control as UCappointment;

                        if (!DesiredUC.DesiredAppointmentUCApp.IsCompleted && !DesiredUC.DesiredAppointmentUCApp.IsCanceled)
                        {
                            ControlsShouldBeRemoved.Add(DesiredUC);
                        }
                    }
                }

                foreach (UCappointment ucapp in ControlsShouldBeRemoved)
                {
                    ucSchedule.RemoveUcAppointmentFromTLP(ucapp);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void checkBoxComplete_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (checkBoxComplete.Checked)
            {
                foreach (ClassAppointment desiredAppointment in ucSchedule.AppointmentsList)
                {
                    if (desiredAppointment.IsCompleted)
                    {
                        ucSchedule.AddUCappointmentsInTLP(desiredAppointment);
                    }
                }
            }
            else
            {
                List<UCappointment> ControlsShouldBeRemoved = new List<UCappointment>();
                foreach (Control control in ucSchedule.TLPSchedule.Controls)
                {
                    if (control is UCappointment)
                    {
                        UCappointment DesiredUC = control as UCappointment;

                        if (DesiredUC.DesiredAppointmentUCApp.IsCompleted )
                        {
                            ControlsShouldBeRemoved.Add(DesiredUC);
                        }
                    }
                }
                foreach (UCappointment ucapp in ControlsShouldBeRemoved)
                {
                    ucSchedule.RemoveUcAppointmentFromTLP(ucapp);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void checkBoxCancel_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (checkBoxCancel.Checked)
            {
                foreach (ClassAppointment desiredAppointment in ucSchedule.AppointmentsList)
                {
                    if (desiredAppointment.IsCanceled)
                    {
                        ucSchedule.AddUCappointmentsInTLP(desiredAppointment);
                    }
                }
            }
            else
            {
                List<UCappointment> ControlsShouldBeRemoved = new List<UCappointment>();
                foreach (Control control in ucSchedule.TLPSchedule.Controls)
                {
                    if (control is UCappointment)
                    {
                        UCappointment DesiredUC = control as UCappointment;

                        if (DesiredUC.DesiredAppointmentUCApp.IsCanceled)
                        {
                            ControlsShouldBeRemoved.Add(DesiredUC);
                        }
                    }
                }
                foreach (UCappointment ucapp in ControlsShouldBeRemoved)
                {
                    ucSchedule.RemoveUcAppointmentFromTLP(ucapp);
                }
            }
            Cursor.Current = Cursors.Default;
        }



        //FUNCTIONS:

        public void UCDaysClick()
        {
            EditUCDay();
            ucmonths.Hide();
        }//click on a day of UCMONTH
        public void EditUCDay()
        {
            //Scroll
            ucSchedule.TLPSchedule.AutoScrollPosition = new Point(0, 0);
            ucSchedule.TLPSchedule.AutoScrollPosition = new Point(0, ucSchedule.TLPSchedule.rowHeight * 6);
            ucSchedule.TLPSchedule.currentRow = 6;

            //edit DateUCDay
            if (ucSchedule.SelectedDate.Date != ucmonths.DateUCMonth.Date)
            {
                ucSchedule.LoadForm(ucmonths.DateUCMonth);
            }




        }// changing DateUCDAY

      
    }
}
