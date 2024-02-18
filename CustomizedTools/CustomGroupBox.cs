using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomizedTools
{
    public class CustomGroupBox : GroupBox
    {
        private int bordersize = 1;

        public int BorderSize
        {
            get { return bordersize; }
            set
            {
                bordersize = value;
                // Call Invalidate to trigger the Paint event
                Invalidate();
            }
        }

        private Color bordercolor = Color.White;
        public Color BorderColor
        {
            get { return bordercolor; }
            set
            {
                bordercolor = value;
                // Call Invalidate to trigger the Paint event
                Invalidate();
            }
        }

        public CustomGroupBox()
        {
            // Set the control style to support double buffering for smooth drawing
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Change the color of the custom border
            Color borderColor = BorderColor; // Change this to your desired color
            int borderThickness = BorderSize; // Change this to your desired thickness
            int y = Font.Height / 2 + Padding.Top - 3;

            // Calculate the coordinates for the four corners of the rectangle
            int left = 0;
            int top = y;
            int right = Width - 1;
            int bottom = Height - 1;
            // Calculate the text width
            int textWidth = TextRenderer.MeasureText(Text, Font).Width;
            int textRight = left + textWidth;
            // Draw the line after the text
            using (Pen borderPen = new Pen(borderColor, borderThickness))
            {
                e.Graphics.DrawLine(borderPen, textRight + 1, y, Width, y);
            }

            // Draw the line before the text
            using (Pen borderPen = new Pen(borderColor, borderThickness))
            {
                int textLeft = left + borderThickness; // Adjust this value as needed
                e.Graphics.DrawLine(borderPen, left, y, 5, y);
            }

            // Draw the three sides of the rectangle (left, right, and bottom) individually
            // Left side
            using (Pen borderPen = new Pen(borderColor, borderThickness))
            {
                e.Graphics.DrawLine(borderPen, left, top, left, bottom - 1);
            }

            // Right side
            using (Pen borderPen = new Pen(borderColor, borderThickness))
            {
                e.Graphics.DrawLine(borderPen, right, top, right, bottom - 1);
            }

            // Bottom side
            using (Pen borderPen = new Pen(borderColor, borderThickness))
            {
                e.Graphics.DrawLine(borderPen, left, bottom - 1, right, bottom - 1);
            }
        }

     
    }
}
