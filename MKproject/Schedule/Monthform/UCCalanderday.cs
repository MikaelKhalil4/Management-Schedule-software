using System.Linq;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class UCCalanderday : UserControl
    {
        public UCCalanderday(Schedule schedule, UCMonth ucmonths, UCDay ucday)
        {
            InitializeComponent();
            foreach (UCDays u in tableLayoutPanel1.Controls.OfType<UCDays>())
            {
                u.schedule = schedule;  
                u.ucmonths = ucmonths;
                u.ucday = ucday;
            }
        }
    }
}

