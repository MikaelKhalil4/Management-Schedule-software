using GlobalFunctions;
using System;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class UCItem : UserControl
    {
      

        public int Id { get; set; }
      
        private int noItem;
        public int NOItem
        {
            get { return noItem; }
            set { noItem = value;

                ucNOItem.Number = noItem;

            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value;
            labelTitle.Text = title;
            RandomFunctions.FixedFont(labelTitle,null);
            }
        }

        public UCItem()
        {
            InitializeComponent();
            ucNOItem.TextBoxValueTextBoxValueTextChange += UcNOItem_TextBoxValueTextBoxValueTextChange;
         

        }


        public event EventHandler TextBoxValueTextChange;
        private void UcNOItem_TextBoxValueTextBoxValueTextChange(object sender, EventArgs e)
        {
            TextBoxValueTextChange?.Invoke(this, e);

          
        }

      
    }
}
