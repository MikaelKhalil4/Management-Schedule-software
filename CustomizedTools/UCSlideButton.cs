using System;
using System.Drawing;
using System.Windows.Forms;


namespace CustomizedTools
{
    public partial class UCSlideButton : UserControl
    {
       public Color ColorUnclicked = Color.FromArgb(139, 152, 224);
       public Color ColorClicked= Color.FromArgb(109, 122, 224);


        private string button1text;
        public string Button1text
        {
            get { return button1text; }
            set {
                button1text = value;
                button1.Text = value;
            }
        }
        private string button2text;
        public string Button2text
        {
            get { return button2text; }
            set {               
                button2text = value;
                button2.Text = value;
            }
        }



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
