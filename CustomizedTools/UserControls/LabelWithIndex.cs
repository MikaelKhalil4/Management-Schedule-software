using System.Windows.Forms;

namespace CustomizedTools
{
     public class LabelWithIndex : Label
    {

        private int index;//to order by index in the FLPInfo in newregister

        public int Index
        {
            get { return index; }
            set { index = value; }
        }
    }
}
