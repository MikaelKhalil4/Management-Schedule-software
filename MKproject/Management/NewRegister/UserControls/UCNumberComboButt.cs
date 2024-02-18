using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class UCNumberComboButt : UserControl
    {
        public Font ComBoBoxFont
        {
            get
            {
                return comboBoxUnit.Font;
            }
            set
            {
                comboBoxUnit.Font = value;
            }
        }
        public UCNumberComboButt()
        {
            InitializeComponent();
        }
    }
}
