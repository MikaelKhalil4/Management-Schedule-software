using CustomizedTools;

namespace MKproject.Management
{
    partial class Album
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Album));
            TLPHome = new System.Windows.Forms.TableLayoutPanel();
            buttonCancel = new System.Windows.Forms.Button();
            buttonAddNewAlbum = new IconButton();
            buttonEditAlbum = new IconButton();
            FLPHome = new System.Windows.Forms.FlowLayoutPanel();
            buttonNoAlbum = new System.Windows.Forms.Button();
            buttonBack = new System.Windows.Forms.Button();
            buttonSave = new System.Windows.Forms.Button();
            timer1 = new System.Windows.Forms.Timer(components);
            TLPAddAlbum = new System.Windows.Forms.TableLayoutPanel();
            buttonCancel2 = new System.Windows.Forms.Button();
            buttonDeleteAlbum = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            TLPHome.SuspendLayout();
            TLPAddAlbum.SuspendLayout();
            SuspendLayout();
            // 
            // TLPHome
            // 
            TLPHome.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPHome.ColumnCount = 3;
            TLPHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.26966F));
            TLPHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.677902F));
            TLPHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.052434F));
            TLPHome.Controls.Add(buttonCancel, 0, 2);
            TLPHome.Controls.Add(buttonAddNewAlbum, 2, 0);
            TLPHome.Controls.Add(buttonEditAlbum, 1, 0);
            TLPHome.Controls.Add(FLPHome, 0, 1);
            TLPHome.Controls.Add(buttonNoAlbum, 0, 0);
            TLPHome.Location = new System.Drawing.Point(26, 27);
            TLPHome.Margin = new System.Windows.Forms.Padding(0);
            TLPHome.Name = "TLPHome";
            TLPHome.RowCount = 3;
            TLPHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.30502F));
            TLPHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.69498F));
            TLPHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            TLPHome.Size = new System.Drawing.Size(752, 299);
            TLPHome.TabIndex = 0;
            TLPHome.Visible = false;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonCancel.BackColor = System.Drawing.Color.FromArgb(95, 97, 99);
            TLPHome.SetColumnSpan(buttonCancel, 3);
            buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(105, 107, 109);
            buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCancel.ForeColor = System.Drawing.Color.White;
            buttonCancel.Location = new System.Drawing.Point(636, 259);
            buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 8, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(108, 33);
            buttonCancel.TabIndex = 738;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonAddNewAlbum
            // 
            buttonAddNewAlbum.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonAddNewAlbum.BackColor = System.Drawing.Color.Transparent;
            buttonAddNewAlbum.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonAddNewAlbum.BackgroundImage");
            buttonAddNewAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonAddNewAlbum.FlatAppearance.BorderSize = 0;
            buttonAddNewAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAddNewAlbum.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonAddNewAlbum.ForeColor = System.Drawing.Color.White;
            buttonAddNewAlbum.Location = new System.Drawing.Point(705, 6);
            buttonAddNewAlbum.Margin = new System.Windows.Forms.Padding(0);
            buttonAddNewAlbum.MotionHeight = true;
            buttonAddNewAlbum.MotionWidth = true;
            buttonAddNewAlbum.Name = "buttonAddNewAlbum";
            buttonAddNewAlbum.Size = new System.Drawing.Size(31, 35);
            buttonAddNewAlbum.TabIndex = 4;
            toolTip1.SetToolTip(buttonAddNewAlbum, "Add New Album");
            buttonAddNewAlbum.UseVisualStyleBackColor = false;
            buttonAddNewAlbum.Click += buttonAddNewAlbum_Click;
            // 
            // buttonEditAlbum
            // 
            buttonEditAlbum.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonEditAlbum.BackColor = System.Drawing.Color.Transparent;
            buttonEditAlbum.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonEditAlbum.BackgroundImage");
            buttonEditAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonEditAlbum.FlatAppearance.BorderSize = 0;
            buttonEditAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonEditAlbum.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonEditAlbum.ForeColor = System.Drawing.Color.White;
            buttonEditAlbum.Location = new System.Drawing.Point(646, 6);
            buttonEditAlbum.Margin = new System.Windows.Forms.Padding(0);
            buttonEditAlbum.MotionHeight = true;
            buttonEditAlbum.MotionWidth = true;
            buttonEditAlbum.Name = "buttonEditAlbum";
            buttonEditAlbum.Size = new System.Drawing.Size(31, 35);
            buttonEditAlbum.TabIndex = 7;
            toolTip1.SetToolTip(buttonEditAlbum, "Edit Mode");
            buttonEditAlbum.UseVisualStyleBackColor = false;
            buttonEditAlbum.Click += buttonEditAlbum_Click;
            // 
            // FLPHome
            // 
            FLPHome.BackColor = System.Drawing.Color.Transparent;
            TLPHome.SetColumnSpan(FLPHome, 3);
            FLPHome.Dock = System.Windows.Forms.DockStyle.Fill;
            FLPHome.Location = new System.Drawing.Point(4, 51);
            FLPHome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            FLPHome.Name = "FLPHome";
            FLPHome.Size = new System.Drawing.Size(744, 198);
            FLPHome.TabIndex = 3;
            FLPHome.WrapContents = false;
            // 
            // buttonNoAlbum
            // 
            buttonNoAlbum.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonNoAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonNoAlbum.FlatAppearance.BorderSize = 0;
            buttonNoAlbum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(100, 112, 214);
            buttonNoAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonNoAlbum.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonNoAlbum.ForeColor = System.Drawing.Color.White;
            buttonNoAlbum.Location = new System.Drawing.Point(12, 12);
            buttonNoAlbum.Margin = new System.Windows.Forms.Padding(12, 12, 4, 0);
            buttonNoAlbum.Name = "buttonNoAlbum";
            buttonNoAlbum.Size = new System.Drawing.Size(201, 33);
            buttonNoAlbum.TabIndex = 8;
            buttonNoAlbum.Text = "Remove Client From Album";
            buttonNoAlbum.UseVisualStyleBackColor = false;
            buttonNoAlbum.Click += buttonNoAlbum_Click;
            // 
            // buttonBack
            // 
            buttonBack.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonBack.FlatAppearance.BorderSize = 0;
            buttonBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(100, 112, 214);
            buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonBack.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonBack.ForeColor = System.Drawing.Color.White;
            buttonBack.Location = new System.Drawing.Point(12, 12);
            buttonBack.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new System.Drawing.Size(108, 33);
            buttonBack.TabIndex = 3;
            buttonBack.Text = "Back";
            buttonBack.UseVisualStyleBackColor = false;
            buttonBack.Click += buttonBack_Click;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonSave.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(100, 112, 214);
            buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSave.ForeColor = System.Drawing.Color.White;
            buttonSave.Location = new System.Drawing.Point(629, 12);
            buttonSave.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(108, 33);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // TLPAddAlbum
            // 
            TLPAddAlbum.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPAddAlbum.ColumnCount = 3;
            TLPAddAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPAddAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPAddAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            TLPAddAlbum.Controls.Add(buttonCancel2, 0, 2);
            TLPAddAlbum.Controls.Add(buttonBack, 0, 0);
            TLPAddAlbum.Controls.Add(buttonSave, 2, 0);
            TLPAddAlbum.Controls.Add(buttonDeleteAlbum, 1, 0);
            TLPAddAlbum.Location = new System.Drawing.Point(29, 357);
            TLPAddAlbum.Margin = new System.Windows.Forms.Padding(0);
            TLPAddAlbum.Name = "TLPAddAlbum";
            TLPAddAlbum.RowCount = 3;
            TLPAddAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.31034F));
            TLPAddAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.68966F));
            TLPAddAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            TLPAddAlbum.Size = new System.Drawing.Size(749, 260);
            TLPAddAlbum.TabIndex = 2;
            // 
            // buttonCancel2
            // 
            buttonCancel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonCancel2.BackColor = System.Drawing.Color.FromArgb(95, 97, 99);
            TLPAddAlbum.SetColumnSpan(buttonCancel2, 3);
            buttonCancel2.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonCancel2.FlatAppearance.BorderSize = 0;
            buttonCancel2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(105, 107, 109);
            buttonCancel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCancel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCancel2.ForeColor = System.Drawing.Color.White;
            buttonCancel2.Location = new System.Drawing.Point(633, 220);
            buttonCancel2.Margin = new System.Windows.Forms.Padding(4, 3, 8, 3);
            buttonCancel2.Name = "buttonCancel2";
            buttonCancel2.Size = new System.Drawing.Size(108, 33);
            buttonCancel2.TabIndex = 739;
            buttonCancel2.Text = "Cancel";
            buttonCancel2.UseVisualStyleBackColor = false;
            buttonCancel2.Click += buttonCancel_Click;
            // 
            // buttonDeleteAlbum
            // 
            buttonDeleteAlbum.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonDeleteAlbum.BackColor = System.Drawing.Color.Red;
            buttonDeleteAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonDeleteAlbum.FlatAppearance.BorderSize = 0;
            buttonDeleteAlbum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            buttonDeleteAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonDeleteAlbum.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonDeleteAlbum.ForeColor = System.Drawing.Color.White;
            buttonDeleteAlbum.Location = new System.Drawing.Point(498, 12);
            buttonDeleteAlbum.Margin = new System.Windows.Forms.Padding(12, 12, 0, 12);
            buttonDeleteAlbum.Name = "buttonDeleteAlbum";
            buttonDeleteAlbum.Size = new System.Drawing.Size(118, 33);
            buttonDeleteAlbum.TabIndex = 4;
            buttonDeleteAlbum.Text = "Delete Album";
            buttonDeleteAlbum.UseVisualStyleBackColor = false;
            buttonDeleteAlbum.Click += buttonDeleteAlbum_Click;
            // 
            // Album
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1183, 723);
            Controls.Add(TLPAddAlbum);
            Controls.Add(TLPHome);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Album";
            Opacity = 0D;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Save";
            Deactivate += Album_Deactivate;
            FormClosing += Album_FormClosing;
            TLPHome.ResumeLayout(false);
            TLPAddAlbum.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPHome;
        private System.Windows.Forms.FlowLayoutPanel FLPHome;
        private IconButton buttonAddNewAlbum;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Timer timer1;
        private IconButton buttonEditAlbum;
        private System.Windows.Forms.TableLayoutPanel TLPAddAlbum;
        private System.Windows.Forms.Button buttonDeleteAlbum;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonNoAlbum;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonCancel2;
    }
}