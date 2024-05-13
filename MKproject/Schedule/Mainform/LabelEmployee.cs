using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKproject.Schedule
{

    internal class LabelEmployee : Label
    {
        public bool IsClicked { get; set; }
        public void SetDefaultModeDesign()
        {
            //BackColor = Program.BoldColor;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 12, FontStyle.Bold);
        }
        public void SetActiveModeDesign()
        {
            //BackColor = Color.FromArgb(2, 162, 111);
            ForeColor = Color.FromArgb(57, 240, 252);
            Font = new Font("Segoe UI", 13, FontStyle.Bold);
        }
    }
}
