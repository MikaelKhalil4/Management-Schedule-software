using System.Linq;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class UCCalandermonth : UserControl
    {
        public UCCalandermonth(CalanderForm ucmonths)
        {
            InitializeComponent();
            foreach (LabelMonth m in tableLayoutPanel1.Controls.OfType<LabelMonth>())
            {
                m.ucmonths = ucmonths;
            }
        }

    }
}
