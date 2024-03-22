using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomizedTools
{
    public class CustomButton : Button
    {
        private Color backAndMouseHoverColor;

        public Color BackAndMouseHoverColor
        {
            get { return backAndMouseHoverColor; }
            set
            {
                backAndMouseHoverColor = value;
                base.BackColor = value;
                FlatAppearance.MouseOverBackColor = Color.FromArgb( Math.Max(backAndMouseHoverColor.R - 20, 0),Math.Max(backAndMouseHoverColor.G - 20, 0), Math.Max(backAndMouseHoverColor.B - 20, 0));
                FlatAppearance.MouseDownBackColor= Color.FromArgb(Math.Max(backAndMouseHoverColor.R - 40, 0), Math.Max(backAndMouseHoverColor.G - 40, 0), Math.Max(backAndMouseHoverColor.B - 40, 0));
            }
        }
        public CustomButton()
        {
            SetStyle(null);
        }
        public CustomButton(Color backColor)
        {
            SetStyle(backColor);
        }
        void SetStyle(Color? backcolor)
        {
            if (backcolor != null)
            {
                BackAndMouseHoverColor = (Color)backcolor;
            }
            FlatAppearance.BorderSize = 0;
            Size = new Size(93, 29);
            Margin = new Padding(3);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 12, FontStyle.Bold);
            Anchor = AnchorStyles.None;
            FlatStyle = FlatStyle.Flat;
            Cursor = Cursors.Hand;
        }
    }
}
