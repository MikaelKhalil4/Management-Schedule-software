
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Size = System.Drawing.Size;
using FontStyle = System.Drawing.FontStyle;
using GlobalFunctions;
using CustomizedTools;
//form made by nicolas
namespace MKproject.Management
{
    public partial class Album : Form
    {
        public ClientManagementProfile ClientManagementProfileForm;
        NewRegister RegisterForm;
        private string albumName;
        private UCTextbox1 UCAlbum;//the usercontrol that contains the textbox
        private bool IsEditClicked = false;
        Button ButtonEditClicked;//lamma nekbus a button badna naamelo edit, byetsayyav bi hayda el reference

        private Color ButtonColorEditing = Color.Green;
        private Color ButtonColorNotEditing = Color.FromArgb(109, 122, 224);

        public Album(NewRegister registerForm)
        {
            InitializeComponent();
            this.Opacity = 0;
            RegisterForm = registerForm;
            this.Size = new Size(600, 270);
            this.Opacity = 0;
            this.TopMost = true;

            IsEditClicked = false;
            DisplayHome();
            buttonEditAlbum.Select();
        }

        //ma tshila
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }






        void DisplayAddAlbum()
        {
            TLPHome.Visible = false;

            TLPAddAlbum.Visible = true;
            TLPAddAlbum.Dock = DockStyle.Fill;

            UCAlbum = new UCTextbox1("New Album", true);
            UCAlbum.BackColor = Color.FromArgb(196, 210, 245);
            UCAlbum.Dock = DockStyle.Top;
            UCAlbum.Margin = new Padding(3, 20, 3, 3);
            TLPAddAlbum.Controls.Add(UCAlbum, 0, 1);
            TLPAddAlbum.SetColumnSpan(UCAlbum, 3);

            if (IsEditClicked)
            {
                UCAlbum.myTextBox1.Text = albumName;
                UCAlbum.groupBox1.Text = UCAlbum.myTextBox1.PlaceholderText;
                buttonDeleteAlbum.Visible = true;

            }
            else
            {
                buttonDeleteAlbum.Visible = false;
            }

        }
        void DisplayHome()
        {
            if (RegisterForm != null)
            {
                buttonNoAlbum.Visible = false;
            }
            TLPHome.Visible = true;
            TLPAddAlbum.Visible = false;
            TLPHome.Dock = DockStyle.Fill;
            buttonEditAlbum.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "editgray.png");
            if (IsEditClicked)
            {
                IsEditClicked = false;
                ChangeButtonsColor(ButtonColorNotEditing);
            }


            if (FLPHome.Controls.Count == 0)//only awwal ma neftah el form men aabiya
            {
                DataTable dt = SQLToProject.GetAlbums();
                foreach (DataRow row in dt.Rows)
                {
                    CreateAlbumButton(row["AlbumType"].ToString(), false);

                }

            }

        }
        void CreateAlbumButton(string albumName, bool SetIndex0)
        {
            Button button = new Button();
            button.Text = albumName;
            button.Size = new Size(125, 125);
            button.Margin = new Padding(15);
            button.ForeColor = Color.White;
            button.BackColor = ButtonColorNotEditing;
            button.Font = new Font("Segoe UI", 12);
            button.Font = new Font(button.Font, FontStyle.Bold);
            button.FlatStyle = FlatStyle.Flat;
            button.Click += AlbumButton_Click;
            button.Cursor = Cursors.Hand;
            FLPHome.Controls.Add(button);
            if (SetIndex0)
            {
                FLPHome.Controls.SetChildIndex(button, 0);
            }
        }


        private void AlbumButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            albumName = clickedButton.Text;
            if (!IsEditClicked)
            {
                if (ClientManagementProfileForm == null)//jeyin men new register
                {
                    RegisterForm.SaveOrUpdate(albumName,false);
                }
                else//jeyin men clientProfile
                {
                    //sql
                    ClassClientCustom.UpdateClientAlbumSQL(ClientManagementProfileForm.Client.ClientId, albumName);
                    //design
                    ClientManagementProfileForm.Client.AlbumType = albumName;
                    ClientManagementProfileForm.UpdateAlbum();
                }
                this.Close();
            }
            else
            {
                ButtonEditClicked = clickedButton;
                DisplayAddAlbum();
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!UCAlbum.ActiveRequiredMode())
            {
                if (!IsEditClicked)
                {
                    if (!SQLToProject.IsAlbumAlreadyExists(UCAlbum.myTextBox1.Text, null))
                    {


                        ProjectToSQL.InsertNewAlbum(UCAlbum.myTextBox1.Text);
                        //design
                        CreateAlbumButton(UCAlbum.myTextBox1.Text, true);
                        DisplayHome();
                        UCAlbum.Dispose();

                    }
                    else
                    {
                        CustomMessageBox.Show("Album name already exist", CustomMessageBox.Type.Error);
                    }
                }
                else
                {
                    if (!SQLToProject.IsAlbumAlreadyExists(UCAlbum.myTextBox1.Text, albumName))
                    {

                        ProjectToSQL.UpdateAlbum(UCAlbum.myTextBox1.Text, albumName);
                        //design
                        if (ClientManagementProfileForm != null)
                        {
                            if (ClientManagementProfileForm.Client.AlbumType == albumName)
                            {
                                ClientManagementProfileForm.Client.AlbumType = UCAlbum.myTextBox1.Text;
                                ClientManagementProfileForm.UpdateAlbum();
                            }
                        }
                        ButtonEditClicked.Text = UCAlbum.myTextBox1.Text;
                        DisplayHome();
                        UCAlbum.Dispose();
                    }
                    else
                    {
                        CustomMessageBox.Show("Album name already exist", CustomMessageBox.Type.Error);
                    }
                }
            }
        }


        private void buttonAddNewAlbum_Click(object sender, EventArgs e)
        {
            DisplayAddAlbum();
        }
        private void buttonEditAlbum_Click(object sender, EventArgs e)
        {
            IsEditClicked = !IsEditClicked;
            if (IsEditClicked)
            {
                buttonEditAlbum.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "editgreen.png");
                ChangeButtonsColor(ButtonColorEditing);
            }
            else
            {
                buttonEditAlbum.BackgroundImage = ImagesFunctions.loadImageFromProject(AppDomain.CurrentDomain.BaseDirectory, "images", "editgray.png");
                ChangeButtonsColor(ButtonColorNotEditing);
            }

        }
        private void buttonDeleteAlbum_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = CustomMessageBox.Show("Deleting this album may result in clients, who are included in this album, becoming without an album.", CustomMessageBox.Type.YesNoWarning);
            if (dialogResult == DialogResult.Yes)
            {
                ProjectToSQL.DeleteAlbum(albumName);

                //design
                if (ClientManagementProfileForm != null)
                {
                    if (ClientManagementProfileForm.Client.AlbumType == albumName)
                    {
                        ClientManagementProfileForm.Client.AlbumType = null;
                        ClientManagementProfileForm.UpdateAlbum();
                    }
                }
                DisplayHome();
                ButtonEditClicked.Dispose();
                UCAlbum.Dispose();
            }
        }
        private void buttonNoAlbum_Click(object sender, EventArgs e)
        {
            if (ClientManagementProfileForm == null)
            {
                RegisterForm.SaveOrUpdate(null,false);
            }
            else
            {
                //sql
                ClassClientCustom.UpdateClientAlbumSQL(ClientManagementProfileForm.Client.ClientId, null);
                //design
                ClientManagementProfileForm.Client.AlbumType = null;
                ClientManagementProfileForm.UpdateAlbum();
            }
            this.Close();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {

            DisplayHome();
            UCAlbum.Dispose();//kermel eza rje3na fetna 3laya nerja3 ne5la2o
        }





        private void ChangeButtonsColor(Color newColor)
        {
            foreach (Control control in FLPHome.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = newColor;
                }
            }
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .1;
        }

        private void Album_Deactivate(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void Album_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ejbare hek
            if (Program.GreyFormJuniorJunior != null)
            {
                Program.GreyFormJuniorJunior.Close();
                Program.GreyFormJuniorJunior = null;
            }
            else if (Program.GreyFormJunior != null)
            {
                Program.GreyFormJunior.Close();
                Program.GreyFormJunior = null;
            }
            else if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
