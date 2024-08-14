using CustomizedTools;
using System.Windows.Forms;

namespace MKproject.Management
{
    partial class LOGIN
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOGIN));
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel5 = new Panel();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            panel3 = new Panel();
            buttonShow = new IconButton();
            textBoxPassword = new TextBox();
            buttonHide = new IconButton();
            buttonLogin = new Button();
            pictureBox1 = new PictureBox();
            labelVersion = new Label();
            timer1 = new Timer(components);
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Black;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(540, 644);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel5, 0, 1);
            tableLayoutPanel1.Controls.Add(buttonLogin, 0, 2);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(labelVersion, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 221F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.Size = new System.Drawing.Size(540, 644);
            tableLayoutPanel1.TabIndex = 12;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top;
            panel5.Controls.Add(pictureBox3);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(panel3);
            panel5.Controls.Add(buttonShow);
            panel5.Controls.Add(textBoxPassword);
            panel5.Controls.Add(buttonHide);
            panel5.Location = new System.Drawing.Point(116, 333);
            panel5.Margin = new Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(308, 78);
            panel5.TabIndex = 14;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = System.Drawing.Color.White;
            pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new System.Drawing.Point(16, 22);
            pictureBox3.Margin = new Padding(4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(31, 31);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.White;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.FromArgb(61, 121, 219);
            label2.Location = new System.Drawing.Point(46, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(83, 18);
            label2.TabIndex = 7;
            label2.Text = "Password :";
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.FromArgb(61, 121, 219);
            panel3.Location = new System.Drawing.Point(16, 58);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(285, 4);
            panel3.TabIndex = 8;
            // 
            // buttonShow
            // 
            buttonShow.BackColor = System.Drawing.Color.Transparent;
            buttonShow.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonShow.BackgroundImage");
            buttonShow.BackgroundImageLayout = ImageLayout.Stretch;
            buttonShow.FlatStyle = FlatStyle.Flat;
            buttonShow.Location = new System.Drawing.Point(271, 25);
            buttonShow.Margin = new Padding(4);
            buttonShow.MotionHeight = false;
            buttonShow.MotionWidth = false;
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new System.Drawing.Size(31, 31);
            buttonShow.TabIndex = 10;
            buttonShow.UseVisualStyleBackColor = false;
            buttonShow.Click += buttonShow_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BackColor = System.Drawing.Color.White;
            textBoxPassword.BorderStyle = BorderStyle.None;
            textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxPassword.ForeColor = System.Drawing.Color.FromArgb(20, 20, 20);
            textBoxPassword.Location = new System.Drawing.Point(52, 30);
            textBoxPassword.Margin = new Padding(4);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new System.Drawing.Size(250, 19);
            textBoxPassword.TabIndex = 5;
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPassword.KeyDown += textBoxPassword_KeyDown;
            // 
            // buttonHide
            // 
            buttonHide.BackColor = System.Drawing.Color.Transparent;
            buttonHide.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonHide.BackgroundImage");
            buttonHide.BackgroundImageLayout = ImageLayout.Stretch;
            buttonHide.FlatStyle = FlatStyle.Flat;
            buttonHide.Location = new System.Drawing.Point(272, 26);
            buttonHide.Margin = new Padding(4);
            buttonHide.MotionHeight = false;
            buttonHide.MotionWidth = false;
            buttonHide.Name = "buttonHide";
            buttonHide.Size = new System.Drawing.Size(29, 29);
            buttonHide.TabIndex = 9;
            buttonHide.UseVisualStyleBackColor = false;
            buttonHide.Click += buttonHide_Click;
            // 
            // buttonLogin
            // 
            buttonLogin.Anchor = AnchorStyles.Top;
            buttonLogin.AutoSize = true;
            buttonLogin.BackColor = System.Drawing.Color.White;
            buttonLogin.Cursor = Cursors.Hand;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonLogin.ForeColor = System.Drawing.Color.FromArgb(61, 121, 219);
            buttonLogin.Location = new System.Drawing.Point(182, 550);
            buttonLogin.Margin = new Padding(0);
            buttonLogin.MaximumSize = new System.Drawing.Size(175, 50);
            buttonLogin.MinimumSize = new System.Drawing.Size(175, 50);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new System.Drawing.Size(175, 50);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "LOGIN";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            buttonLogin.MouseLeave += buttonLogin_MouseLeave;
            buttonLogin.MouseHover += buttonLogin_MouseHover;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(76, 35);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(387, 258);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelVersion
            // 
            labelVersion.Anchor = AnchorStyles.Right;
            labelVersion.AutoSize = true;
            labelVersion.ForeColor = System.Drawing.Color.FromArgb(61, 121, 219);
            labelVersion.Location = new System.Drawing.Point(483, 616);
            labelVersion.Margin = new Padding(4, 0, 4, 0);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new System.Drawing.Size(53, 20);
            labelVersion.TabIndex = 15;
            labelVersion.Text = "v. 1.0.0";
            labelVersion.Visible = false;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;
            // 
            // LOGIN
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(540, 644);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(558, 813);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(558, 47);
            Name = "LOGIN";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGIN";
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Label label2;
        private TextBox textBoxPassword;
        private IconButton buttonHide;
        private IconButton buttonShow;
        private Button buttonLogin;
        private System.Windows.Forms.Timer timer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel5;
        public Label labelVersion;
    }
}