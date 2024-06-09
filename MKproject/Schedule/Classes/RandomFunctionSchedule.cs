
using System.Drawing;
using System.Windows.Forms;


namespace MKproject.Schedule
{
    public class RandomFunctionSchedule
    {
        public static Label selectedlabeltime = null;

        //HIGHLIGHT:
        public static void HighlightUserControl(Label targetlabel)
        {         
            if (targetlabel != null)//hone baeed ma fetna aal flowlayout panel bas deghre eemelna highlight moujarad ma bayan lflow layout panel
            {
                targetlabel.BackColor = Color.FromArgb(229, 226, 244);
                selectedlabeltime = targetlabel;
            }
        }

    }
}
