using CustomizedTools;
using GlobalFunctions;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace MKproject.Management
{
    public partial class UCCamera : UserControl
    {
        Label labelOptional;
        Label labelTitle;
        Label labelRequired;

        Image DefaultImage;

        private Image valueImage;
        public Image ValueImage
        {
            get { return valueImage; }
            set
            {
                this.valueImage = value;
          

                if (ValueImage == null)
                {
                    iconButtonImage.BackgroundImage = DefaultImage;
                    buttonDelete.Visible = false;
                }
                else
                {
                    iconButtonImage.BackgroundImage = this.valueImage;
                    buttonDelete.Visible = true;
                }


            }
        }


        private int index;//to order by index in the FLPInfo in newregister
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public bool ISActiveRequiredModeOn { get; set; }
        private bool isrequired;
        public bool IsRequired//dynamic
        {
            get { return isrequired; }
            set
            {

                isrequired = value;

                if (!isrequired)//optional
                {

                    if (labelRequired != null)
                    {
                        labelRequired.Dispose();//in case ken mawjud
                        labelRequired = null;
                    }
                    if (labelOptional == null)
                    {

                        CreateLabelOptional();
                        TLPGlobal.Controls.Add(labelOptional, 1, 0);
                    }

                    ISActiveRequiredModeOn = false;

                }
                else//not optional, required
                {
                    if (labelOptional != null)
                    {
                        labelOptional.Dispose();//in case ken mawjud
                        labelOptional = null;
                    }
                    if (labelRequired == null)
                    {
                        CreateLabelRequired();
                        TLPGlobal.Controls.Add(labelRequired, 1, 0);
                    }

                }

            }
        }



        void CreateLabelOptional()
        {
            labelOptional = new Label();
            labelOptional.Anchor = AnchorStyles.Left;
            labelOptional.Text = "(Optional)";
            labelOptional.Font = new Font("Segoe UI", 12f);
            labelOptional.ForeColor = Color.Black;
        }
        void CreateLabelRequired()
        {
            labelRequired = new Label();
            labelRequired.Visible = false;//dynamic
            labelRequired.Anchor = AnchorStyles.Left;
            labelRequired.AutoSize = true;
            labelRequired.Text = "* field is required";
            labelRequired.Font = new Font("Segoe UI", 9.75f);
            labelRequired.ForeColor = Color.Red;
        }



        private string title;
        public string Title//static
        {
            get { return title; }
            set
            {
                title = value;
                CreateLabelTitle();
            }
        }
        void CreateLabelTitle()
        {
            labelTitle = new Label();
            labelTitle.Text = Title;
            labelTitle.Anchor = AnchorStyles.Left;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Semibold", 14.25f, FontStyle.Bold);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Margin = new Padding(0, 3, 0, 0);
        }

        
        public UCCamera()
        {
            InitializeComponent();
        }
        public UCCamera(string title, bool? isrequired)
        {
            InitializeComponent();
            DefaultImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "user1.png");
            SetDefaultImage();
          
            Title = title;
            IsRequired = (bool)isrequired;


            TLPGlobal.ColumnStyles[0] = new ColumnStyle(SizeType.AutoSize);
            TLPGlobal.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 100F);

            TLPGlobal.RowStyles[0] = new RowStyle(SizeType.Absolute, labelTitle.Height + labelTitle.Margin.Top + labelTitle.Margin.Bottom + 5);

            TLPGlobal.Controls.Add(labelTitle, 0, 0);

            this.Width = 600;
            this.Margin = new Padding(3, 5, 3, 5);
        }




        public bool ActiveRequiredMode()
        {

            ISActiveRequiredModeOn = false;//default value

            if (!IsRequired)
            {
                return false;
            }
            else
            {
                if (this.ValueImage == null)
                {
                    labelRequired.Visible = true;
                    ISActiveRequiredModeOn = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void FillDesignValues(Image data)
        {
            if (data != null)
            {
                ValueImage = data;
            }
            else
            {
                ValueImage = null;
            }

        }

        //battalit moustaamela bas treka in case
        public void Reset()
        {
            if (labelRequired != null && labelRequired.Visible==true)
            {
                labelRequired.Visible = false;
            }
            ISActiveRequiredModeOn = false;
            SetDefaultImage();
        }


        void SetDefaultImage()
        {
            ValueImage = null;      
        }


        private void buttonCapture_Click(object sender, EventArgs e)
        {        
            //Camera c = new Camera();
            //c.UCcamera = this;
            //c.ShowDialog();
            ////in here on button save juwwet hal form, baamil set lal pprop
        }
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
                openFileDialog.Title = "Select an Image File";


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    string imagePath = openFileDialog.FileName;
                    Image DesiredImage = Image.FromFile(imagePath);


                    MemoryStream ms1 = new MemoryStream();
                    DesiredImage.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg); // Save as JPEG, you can choose a different format if needed

                    if (ms1.Length > 2000000)//Max 1MB el pic,yaane mafrud add el 4k
                    {
                        CustomMessageBox.Show("please choose another picture with lower capacity(less than 2MB)", CustomMessageBox.Type.OkInfo);
                        ValueImage = null;
                    }
                    else
                    {
                        Cursor = Cursors.WaitCursor;
                        ValueImage = ImagesFunctions.CompressImage(DesiredImage);
                        Cursor = Cursors.Default;//lieanno eza ken large file byekhud waet
                    }
                }
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
           DialogResult dialogResult= CustomMessageBox.Show("Are you sure do you want to delete the picture?", CustomMessageBox.Type.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SetDefaultImage();

            }
            else if (dialogResult == DialogResult.No)
            {

            }


        }


        private void iconButtonImage_BackgroundImageChanged(object sender, EventArgs e)
        {
            if (ISActiveRequiredModeOn)
            {
                if (valueImage == null)
                {
                    labelRequired.Visible = true;
                }
                else
                {
                    labelRequired.Visible = false;
                }
            }
        }
    }
}
