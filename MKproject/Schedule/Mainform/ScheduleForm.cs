using CustomizedTools;
using MKproject.Management;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class ScheduleForm : Form
    {

        //VARIABLES:
        public CalanderForm calanderFormForschedule;
        public CalanderForm calanderFormForReminder;
        public UCSchedule ucSchedule;
        public EmployeeSchedule employee;

        //INITIALISE:
        public ScheduleForm()
        {
            InitializeComponent();
     
            ucSchedule = new UCSchedule(this);
            Cursor.Current = Cursors.WaitCursor;


            ucSchedule.Dock = DockStyle.Fill;
            ucSchedule.Margin = new Padding(10, 10, 0, 0);

            ucSchedule.TLPSchedule.SuspendLayout();
            tableLayoutPanelForm.Controls.Add(ucSchedule, 1, 0);
            ucSchedule.TLPSchedule.ResumeLayout();


           
            calanderFormForschedule = new CalanderForm(this, ucSchedule.SelectedDate);//nkhala2 men halla2 kermel watta a3mil click deghre yendfatah
            calanderFormForschedule.SelectedDateChanged += ucSchedule.SelectedDateUCSchedule_Changed;
            calanderFormForschedule.Dock = DockStyle.Fill;
            calanderFormForschedule.Margin = new Padding(10, 15, 10, 10);//(left, top, right, bottom)
            TLPSide.Margin = new Padding(0, 0, 0, 0);


       
            calanderFormForReminder = new CalanderForm(this, ucSchedule.SelectedDate);//nkhala2 men halla2 kermel watta a3mil click deghre yendfatah
            calanderFormForReminder.Dock = DockStyle.Fill;
            calanderFormForReminder.Margin = new Padding(10, 15, 10, 10);//(left, top, right, bottom)
            TLPSide.Margin = new Padding(0, 0, 0, 0);

            Cursor.Current = Cursors.Default;


            //
            checkBoxOnPending.Click += CloseNotfBanner_Click;
            checkBoxComplete.Click += CloseNotfBanner_Click;
            checkBoxCancel.Click += CloseNotfBanner_Click;

   
        }

        public void LoadScheduleForm()
        {
            checkBoxOnPending.Checked = true;
            checkBoxComplete.Checked = true;
            checkBoxCancel.Checked = true;


            ucSchedule.LoadGlobalyTheForm();
            ucSchedule.ScrollToRow(ClassEmployee.GetRowFromTime(DateTime.Now.TimeOfDay, false, ucSchedule.TLPSchedule), ucSchedule.TLPSchedule);//leh hattina marrra tenye hone , maa enno mawjude bel load, form, cz hone la tekhud el form the right size

        }

        private void CloseNotfBanner_Click(object sender, EventArgs e)
        {
            CloseNotfBanner();

        }
        public void CloseNotfBanner()
        {
            if (CustomizedTools.NotificationBanner.CurrentNotfBanner != null)
            {
                CustomizedTools.NotificationBanner.CloseTheNotfBanner();
            }
        }

        //-CLICK
        private void buttonAllReminder_Click(object sender, EventArgs e)
        {
            CloseNotfBanner();
            //
            Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
            Program.GreyForm.Show();
            ClientReminder clientReminderForm = new ClientReminder(null, this, ucSchedule);
            clientReminderForm.Show();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            CloseNotfBanner();
            //
            Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
            Program.GreyForm.Show();
            Reminder reminder = new Reminder(this, ucSchedule);
            reminder.Show();
        }

        ///-CHECK BOX
        private void checkBoxOnPending_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (checkBoxOnPending.Checked)
            {
                ucSchedule.IsCursorBlocked = true;
                foreach (ClassAppointment desiredAppointment in ucSchedule.AppointmentsListWorkingOn)
                {
                    if (!desiredAppointment.IsCompleted && !desiredAppointment.IsCanceled)
                    {
                        ucSchedule.AddUCappointmentsInTLP(desiredAppointment);
                    }
                }
                ucSchedule.IsCursorBlocked = false;
            }
            else
            {
                List<UCappointment> ControlsShouldBeRemoved = new List<UCappointment>();
                foreach (Control control in ucSchedule.TLPSchedule.Controls)
                {
                    if (control is UCappointment)
                    {
                        UCappointment DesiredUC = control as UCappointment;

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
                ucSchedule.IsCursorBlocked = true;
                foreach (ClassAppointment desiredAppointment in ucSchedule.AppointmentsListWorkingOn)
                {
                    if (desiredAppointment.IsCompleted)
                    {

                        ucSchedule.AddUCappointmentsInTLP(desiredAppointment);
                    }
                }
                ucSchedule.IsCursorBlocked = false;
            }
            else
            {
                List<UCappointment> ControlsShouldBeRemoved = new List<UCappointment>();
                foreach (Control control in ucSchedule.TLPSchedule.Controls)
                {
                    if (control is UCappointment)
                    {
                        UCappointment DesiredUC = control as UCappointment;

                        if (DesiredUC.DesiredAppointmentUCApp.IsCompleted)
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
                ucSchedule.IsCursorBlocked = true;
                foreach (ClassAppointment desiredAppointment in ucSchedule.AppointmentsListWorkingOn)
                {
                    if (desiredAppointment.IsCanceled)
                    {
                        ucSchedule.AddUCappointmentsInTLP(desiredAppointment);
                    }
                }
                ucSchedule.IsCursorBlocked = false;
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



        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            ucSchedule.ScrollToRow(ClassEmployee.GetRowFromTime(DateTime.Now.TimeOfDay, false, ucSchedule.TLPSchedule), ucSchedule.TLPSchedule);//leh hattina marrra tenye hone , maa enno mawjude bel load, form, cz hone la tekhud el form the right size
            ucSchedule.UpdateTimeIndicatorLinePosition();
        }
        public event EventHandler ScheduleFormResize;
        private void ScheduleForm_Resize(object sender, EventArgs e)
        {
            ScheduleFormResize?.Invoke(this, e);
        }
    }
}
