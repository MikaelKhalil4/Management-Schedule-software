using GlobalFunctions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomizedTools
{

    public partial class CustomMessageBox : Form
    {
        string text;
        Type type;
        public string ButtonClicked;
        public enum Type
        {
            OkCancel,
            YesNoWarning,
            YesNo,
            OkInfo,
            OkWarning,
            Error,

        }
        private CustomMessageBox(string Text, Type type)
        {
            InitializeComponent();
            this.Opacity = 0;
            this.TopMost = true;
            this.type = type;
            text = Text;
            LoadForm();
        }

        Button CreateButton(string text, DialogResult dialogResult)
        {
            Button button = new Button();
            button.Text = text;
            button.DialogResult = dialogResult;
            button.Size = new Size(93, 29);
            button.BackColor = Color.FromArgb(109, 122, 224);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Black;
            button.FlatAppearance.BorderSize = 1;
            button.Cursor = Cursors.Hand;
            FLPButtons.Controls.Add(button);
            return button;
        }

        void LoadForm()
        {
            Image DesiredIcon = null;

            labelText.Text = text;
            int LabelDesiredHeight = RandomFunctions.CalculateDesiredHeight(labelText, labelText.Width);
            int desiredHeight;
            if (pictureBox.Height > LabelDesiredHeight)
            {
                desiredHeight = pictureBox.Height;
            }
            else
            {
                desiredHeight = LabelDesiredHeight;
            }

            this.Height = FLPButtons.Height + desiredHeight + 70;

            Button Activebutton = null;
            if (type == Type.OkCancel)
            {
                Activebutton = CreateButton("Cancel", DialogResult.Cancel);
                CreateButton("OK", DialogResult.OK);


                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "Question.png");
            }
            else if (type == Type.YesNo)
            {
                CreateButton("No", DialogResult.No);
                Activebutton = CreateButton("Yes", DialogResult.Yes);


                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "YesOrNo.png");
            }

            else if (type == Type.OkInfo)
            {
                Activebutton = CreateButton("OK", DialogResult.OK);


                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "info.png");
            }
            else if (type == Type.YesNoWarning)
            {
                CreateButton("No", DialogResult.No);
                Activebutton = CreateButton("Yes", DialogResult.Yes);


                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "Warning.png");
            }
            else if (type == Type.OkWarning)
            {
                Activebutton = CreateButton("OK", DialogResult.OK);
                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "Warning.png");
            }
            else if (type == Type.Error)
            {
                Activebutton = CreateButton("OK", DialogResult.OK);


                DesiredIcon = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "Error.png");
            }





            pictureBox.BackgroundImage = DesiredIcon;
            Activebutton.Select();
            this.AcceptButton = Activebutton; // Allows the Enter key to click the OK button
        }

        public static DialogResult Show(string message, Type type)
        {
            using (CustomMessageBox cmb = new CustomMessageBox(message, type))
            {
                return cmb.ShowDialog();
            }
        }

        //How To Use it In ain forms
        //    DialogResult dialogResult = CustomMessageBox.Show("Your custom message here.");
        // Optional: Handle the DialogResult if needed
        //if (result == DialogResult.OK)
        //   {
        // Code to execute if OK is clicked
        // }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2;
        }
    }
}
