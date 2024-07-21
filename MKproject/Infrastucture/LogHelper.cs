using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKproject.Infrastucture
{
    public class LogHelper
    {
        public static async Task SetupTimerAndStartLogsTimer()
        {
            System.Windows.Forms.Timer TimerLog = new System.Windows.Forms.Timer();
            TimerLog.Interval = 60000 * 15;//each  xmin
            TimerLog.Tick += MyFormsTimer_Tick;

            HttpRequestsClass.CheckAndProcessLogs();

            TimerLog.Start();
        }
        private static void MyFormsTimer_Tick(object sender, EventArgs e)
        {
            HttpRequestsClass.CheckAndProcessLogs();

        }
    }
}
