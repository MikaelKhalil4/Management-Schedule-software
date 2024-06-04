using System.Windows.Forms;

namespace MKproject.Schedule
{
    public class TableLayoutPanelDoubleBufferedNoscroll : TableLayoutPanel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
     
    }
}
