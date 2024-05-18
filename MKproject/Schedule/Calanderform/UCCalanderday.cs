using System.Linq;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class UCCalanderday : UserControl
    {
        public UCCalanderday(ScheduleForm schedule, CalanderForm ucmonths)
        {
            InitializeComponent();
            foreach (UCDays ucdays in tableLayoutPanel1.Controls.OfType<UCDays>())
            {
                ucdays.scheduleForm = schedule;  
                ucdays.calanderForm = ucmonths;
            }
        }
    }
}

