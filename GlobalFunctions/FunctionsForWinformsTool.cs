using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalFunctions
{
    public class FunctionsForWinformsTool
    {
        public static void AdjustTableLayoutPanelHeight(TableLayoutPanel tlp)//all should be absolute and make sure it isnt dockfill
        {

            tlp.Dock = DockStyle.None;
            float totalHeight = 0;

            foreach (RowStyle style in tlp.RowStyles)
            {
                if (style.SizeType == SizeType.Absolute)
                {
                    totalHeight += style.Height;
                }
            }
            // Add padding or margin if necessary
            // totalHeight += tlp.Padding.Top + tlp.Padding.Bottom;


            tlp.Height = (int)Math.Ceiling(totalHeight);
        }
        public static int ReturnComboBoxWidth( ComboBox comboBoxDetail)
        {
            int maxWidth = 0;

            // Iterate through items to find the maximum item width
            foreach (var item in comboBoxDetail.Items)
            {
                string displayedText = comboBoxDetail.GetItemText(item);
                int itemWidth = TextRenderer.MeasureText(displayedText, comboBoxDetail.Font).Width;
                maxWidth = Math.Max(maxWidth, itemWidth);
            }

            return maxWidth;


        }
    }
}
