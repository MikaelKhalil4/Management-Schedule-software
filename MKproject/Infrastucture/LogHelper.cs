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
            HttpRequestsClass.CheckAndProcessLogs();

            System.Windows.Forms.Timer TimerLog = new System.Windows.Forms.Timer();
            TimerLog.Interval = 60000 * 1;//each  1min
            TimerLog.Tick += async (sender, args) => await HttpRequestsClass.CheckAndProcessLogs();
            TimerLog.Start();
        }
      
    }
}
