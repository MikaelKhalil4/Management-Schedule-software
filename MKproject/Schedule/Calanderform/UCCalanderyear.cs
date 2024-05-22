using System.Windows.Forms;

namespace MKproject.Schedule
{
    public partial class UCCalanderyear : UserControl
    {
        public UCCalanderyear(CalanderForm ucmonths)
        {
            InitializeComponent();
            int year = ucmonths.DateCalander.Year;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Control control = tableLayoutPanel1.GetControlFromPosition(j, i);//to get the labels by order
                    if (control is LabelYear y)
                    {
                        y.ucmonths = ucmonths;
                        y.Year = year;
                        year++;
                    }
                }

            }
        }
    }
}
