using System;
using System.Drawing;
using System.Windows.Forms;


namespace CustomizedTools
{
    public partial class UCSlideButton : UserControl
    {
       public Color ColorUnclicked = Color.FromArgb(139, 152, 224);
       public Color ColorClicked= Color.FromArgb(109, 122, 224);

      




        public UCSlideButton()
        {
            InitializeComponent();
            this.BackColor = ColorUnclicked;
            TLPMain.BackColor = ColorUnclicked;
            button1.BackColor = ColorClicked;
            button2.BackColor = ColorUnclicked;

        }


       
        public event EventHandler Button1Clicked;
        public event EventHandler Button2Clicked;
      
        public void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = ColorClicked;
            button2.BackColor = ColorUnclicked;
            Button1Clicked?.Invoke(this, e);
          
        }

        public void button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = ColorUnclicked;
            button2.BackColor = ColorClicked;
            Button2Clicked?.Invoke(this, e);
           
        }           
    }
}
