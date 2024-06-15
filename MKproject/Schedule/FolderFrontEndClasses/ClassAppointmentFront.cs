using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public class ClassAppointmentFront
    {
        public static void SetServiceLabelModeInCaseOfDumble(Label labelService, ClassAppointment DesiredAppointment,Color DefaultLAbelColor)
        {
            

            if (DesiredAppointment.StartTime.Date < DateTime.Now.Date && (DesiredAppointment.IsCompleted || DesiredAppointment.IsCanceled))
            {
                labelService.Text = DesiredAppointment.DesiredClientBalance.BundleName + " Package";
            }
            else//future present and (past for appoinmtnet on pending)
            {
                if (!(bool)DesiredAppointment.DesiredClientBalance.IsExpired)//Package exist and not expired
                {
                    //Design
                    labelService.Text = DesiredAppointment.DesiredClientBalance.ClientBalanceSessionLeftDetails;
                    if (DesiredAppointment.DesiredClientBalance.SessionLeftDays == 0)
                    {
                        labelService.ForeColor = Color.Red;
                    }
                    else
                    {
                        labelService.ForeColor = DefaultLAbelColor;
                    }

                }
                else if ((bool)DesiredAppointment.DesiredClientBalance.IsExpired)//Package exist and  expired
                {
                    //Design

                    labelService.ForeColor = DefaultLAbelColor;
                    labelService.Text = DesiredAppointment.DesiredClientBalance.BundleName + " Package Expired";
                }
            }

        }

    }
}
