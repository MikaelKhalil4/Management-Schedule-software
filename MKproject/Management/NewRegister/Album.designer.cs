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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Album));
            this.TLPHome = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddNewAlbum = new IconButton();
            this.buttonEditAlbum = new IconButton();
            this.FLPHome = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonNoAlbum = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TLPAddAlbum = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDeleteAlbum = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCancel2 = new System.Windows.Forms.Button();
            this.TLPHome.SuspendLayout();
            this.TLPAddAlbum.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPHome
            // 
            this.TLPHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPHome.ColumnCount = 3;
            this.TLPHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.26966F));
            this.TLPHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.677902F));
            this.TLPHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.052434F));
            this.TLPHome.Controls.Add(this.buttonCancel, 0, 2);
            this.TLPHome.Controls.Add(this.buttonAddNewAlbum, 2, 0);
            this.TLPHome.Controls.Add(this.buttonEditAlbum, 1, 0);
            this.TLPHome.Controls.Add(this.FLPHome, 0, 1);
            this.TLPHome.Controls.Add(this.buttonNoAlbum, 0, 0);
            this.TLPHome.Location = new System.Drawing.Point(22, 23);
            this.TLPHome.Margin = new System.Windows.Forms.Padding(0);
            this.TLPHome.Name = "TLPHome";
            this.TLPHome.RowCount = 3;
            this.TLPHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.30502F));
            this.TLPHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.69498F));
            this.TLPHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TLPHome.Size = new System.Drawing.Size(645, 259);
            this.TLPHome.TabIndex = 0;
            this.TLPHome.Visible = false;
            // 
            // buttonAddNewAlbum
            // 
            this.buttonAddNewAlbum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddNewAlbum.BackColor = System.Drawing.Color.Transparent;
            this.buttonAddNewAlbum.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAddNewAlbum.BackgroundImage")));
            this.buttonAddNewAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAddNewAlbum.FlatAppearance.BorderSize = 0;
            this.buttonAddNewAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddNewAlbum.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddNewAlbum.ForeColor = System.Drawing.Color.White;
            this.buttonAddNewAlbum.Location = new System.Drawing.Point(605, 6);
            this.buttonAddNewAlbum.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddNewAlbum.MotionHeight = true;
            this.buttonAddNewAlbum.MotionWidth = true;
            this.buttonAddNewAlbum.Name = "buttonAddNewAlbum";
            this.buttonAddNewAlbum.Size = new System.Drawing.Size(27, 30);
            this.buttonAddNewAlbum.TabIndex = 4;
            this.toolTip1.SetToolTip(this.buttonAddNewAlbum, "Add New Album");
            this.buttonAddNewAlbum.UseVisualStyleBackColor = false;
            this.buttonAddNewAlbum.Click += new System.EventHandler(this.buttonAddNewAlbum_Click);
            // 
            // buttonEditAlbum
            // 
            this.buttonEditAlbum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonEditAlbum.BackColor = System.Drawing.Color.Transparent;
            this.buttonEditAlbum.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEditAlbum.BackgroundImage")));
            this.buttonEditAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEditAlbum.FlatAppearance.BorderSize = 0;
            this.buttonEditAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditAlbum.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditAlbum.ForeColor = System.Drawing.Color.White;
            this.buttonEditAlbum.Location = new System.Drawing.Point(554, 6);
            this.buttonEditAlbum.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEditAlbum.MotionHeight = true;
            this.buttonEditAlbum.MotionWidth = true;
            this.buttonEditAlbum.Name = "buttonEditAlbum";
            this.buttonEditAlbum.Size = new System.Drawing.Size(27, 30);
            this.buttonEditAlbum.TabIndex = 7;
            this.toolTip1.SetToolTip(this.buttonEditAlbum, "Edit Mode");
            this.buttonEditAlbum.UseVisualStyleBackColor = false;
            this.buttonEditAlbum.Click += new System.EventHandler(this.buttonEditAlbum_Click);
            // 
            // FLPHome
            // 
            this.FLPHome.BackColor = System.Drawing.Color.Transparent;
            this.TLPHome.SetColumnSpan(this.FLPHome, 3);
            this.FLPHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPHome.Location = new System.Drawing.Point(3, 45);
            this.FLPHome.Name = "FLPHome";
            this.FLPHome.Size = new System.Drawing.Size(639, 170);
            this.FLPHome.TabIndex = 3;
            this.FLPHome.WrapContents = false;
            // 
            // buttonNoAlbum
            // 
            this.buttonNoAlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonNoAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNoAlbum.FlatAppearance.BorderSize = 0;
            this.buttonNoAlbum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(112)))), ((int)(((byte)(214)))));
            this.buttonNoAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNoAlbum.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold);
            this.buttonNoAlbum.ForeColor = System.Drawing.Color.White;
            this.buttonNoAlbum.Location = new System.Drawing.Point(10, 10);
            this.buttonNoAlbum.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.buttonNoAlbum.Name = "buttonNoAlbum";
            this.buttonNoAlbum.Size = new System.Drawing.Size(172, 29);
            this.buttonNoAlbum.TabIndex = 8;
            this.buttonNoAlbum.Text = "Remove Client From Album";
            this.buttonNoAlbum.UseVisualStyleBackColor = false;
            this.buttonNoAlbum.Click += new System.EventHandler(this.buttonNoAlbum_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(112)))), ((int)(((byte)(214)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(10, 10);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(10);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(93, 29);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(112)))), ((int)(((byte)(214)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(539, 10);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(10);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(93, 29);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TLPAddAlbum
            // 
            this.TLPAddAlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPAddAlbum.ColumnCount = 3;
            this.TLPAddAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPAddAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPAddAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.TLPAddAlbum.Controls.Add(this.buttonCancel2, 0, 2);
            this.TLPAddAlbum.Controls.Add(this.buttonBack, 0, 0);
            this.TLPAddAlbum.Controls.Add(this.buttonSave, 2, 0);
            this.TLPAddAlbum.Controls.Add(this.buttonDeleteAlbum, 1, 0);
            this.TLPAddAlbum.Location = new System.Drawing.Point(25, 309);
            this.TLPAddAlbum.Margin = new System.Windows.Forms.Padding(0);
            this.TLPAddAlbum.Name = "TLPAddAlbum";
            this.TLPAddAlbum.RowCount = 3;
            this.TLPAddAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.31034F));
            this.TLPAddAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.68966F));
            this.TLPAddAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TLPAddAlbum.Size = new System.Drawing.Size(642, 225);
            this.TLPAddAlbum.TabIndex = 2;
            // 
            // buttonDeleteAlbum
            // 
            this.buttonDeleteAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteAlbum.BackColor = System.Drawing.Color.Red;
            this.buttonDeleteAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteAlbum.FlatAppearance.BorderSize = 0;
            this.buttonDeleteAlbum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonDeleteAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteAlbum.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteAlbum.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteAlbum.Location = new System.Drawing.Point(427, 10);
            this.buttonDeleteAlbum.Margin = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.buttonDeleteAlbum.Name = "buttonDeleteAlbum";
            this.buttonDeleteAlbum.Size = new System.Drawing.Size(101, 29);
            this.buttonDeleteAlbum.TabIndex = 4;
            this.buttonDeleteAlbum.Text = "Delete Album";
            this.buttonDeleteAlbum.UseVisualStyleBackColor = false;
            this.buttonDeleteAlbum.Click += new System.EventHandler(this.buttonDeleteAlbum_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(97)))), ((int)(((byte)(99)))));
            this.TLPHome.SetColumnSpan(this.buttonCancel, 3);
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(545, 224);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(93, 29);
            this.buttonCancel.TabIndex = 738;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonCancel2
            // 
            this.buttonCancel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonCancel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(97)))), ((int)(((byte)(99)))));
            this.TLPAddAlbum.SetColumnSpan(this.buttonCancel2, 3);
            this.buttonCancel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel2.FlatAppearance.BorderSize = 0;
            this.buttonCancel2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.buttonCancel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonCancel2.ForeColor = System.Drawing.Color.White;
            this.buttonCancel2.Location = new System.Drawing.Point(542, 190);
            this.buttonCancel2.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.buttonCancel2.Name = "buttonCancel2";
            this.buttonCancel2.Size = new System.Drawing.Size(93, 29);
            this.buttonCancel2.TabIndex = 739;
            this.buttonCancel2.Text = "Cancel";
            this.buttonCancel2.UseVisualStyleBackColor = false;
            this.buttonCancel2.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // Album
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1014, 627);
            this.Controls.Add(this.TLPAddAlbum);
            this.Controls.Add(this.TLPHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Album";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save";
            this.Deactivate += new System.EventHandler(this.Album_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Album_FormClosing);
            this.TLPHome.ResumeLayout(false);
            this.TLPAddAlbum.ResumeLayout(false);
            this.ResumeLayout(false);

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