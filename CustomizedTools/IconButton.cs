using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomizedTools
{// na2e el display tabaa el icon 85 bel flaticons, w teakkad eno el icon eena mahal taamle expand
    public class IconButton :  Button
    {
        int InitialWidth;
        int InitialHeight;
        bool IsEdited=false;

        private bool motionWidth =true;
        public bool MotionWidth
        {
            get { return motionWidth ; }
            set { motionWidth  = value; }
        }

        private bool motionHeight =true;
        public bool MotionHeight
        {
            get { return motionHeight ; }
            set { motionHeight  = value; }
        }


        public new Size Size
        {
            get
            {
                
                return base.Size;
            }
            set
            {
               
                    base.Size = value;
               
                    //if (!IsEdited)
                    //{
                        IsEdited = true;
                        InitialWidth = value.Width;
                        InitialHeight = value.Height;
                    //}
                
            }
        }
        public IconButton()
        {
           
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
         
            this.BackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackgroundImageLayout = ImageLayout.Zoom;

        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (motionWidth )
            {
                this.Width = InitialWidth + 2;
            }
             if (motionHeight )
            {
                this.Height = InitialHeight + 2;
            }
          this.Cursor = Cursors.Hand;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (motionWidth || motionHeight)
            {
                this.Size = new Size(InitialWidth, InitialHeight);
            }
            this.Cursor= Cursors.Default;
        }
      

    }
}
