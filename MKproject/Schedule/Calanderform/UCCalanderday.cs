using System.Linq;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class UCCalanderday : UserControl
    {
        public UCCalanderday(ScheduleForm schedule, CalanderForm ucmonths)
        {
            InitializeComponent();
            FillTLPWithLabelDates();
            foreach (UCDays ucdays in tableLayoutPanelDays.Controls.OfType<UCDays>())
            {
                ucdays.scheduleForm = schedule;  
                ucdays.calanderForm = ucmonths;
            }
        }
        public void FillTLPWithLabelDates()
        {
            for(int i =1 ;i <= 6; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    UCDays ucdays = new UCDays();
                    ucdays.Dock = DockStyle.Fill;
                    tableLayoutPanelDays.Controls.Add(ucdays,j,i);
                }
            }
        }
    }
}

