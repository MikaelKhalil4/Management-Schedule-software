using CustomizedTools;

namespace MKproject.Management
{
    partial class NewRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRegister));
            this.tableLayoutPanelForm = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.TLPEditClient = new System.Windows.Forms.TableLayoutPanel();
            this.iconButtonSettings = new IconButton();
            this.labelEditClient = new System.Windows.Forms.Label();
            this.radioButtonChild = new System.Windows.Forms.RadioButton();
            this.labelAdultOrChild = new System.Windows.Forms.Label();
            this.radioButtonAdult = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonAddToAlbumAndSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.FLPInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanelForm.SuspendLayout();
            this.TLPEditClient.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelForm
            // 
            this.tableLayoutPanelForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.tableLayoutPanelForm.ColumnCount = 2;
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 498F));
            this.tableLayoutPanelForm.Controls.Add(this.buttonDelete, 0, 2);
            this.tableLayoutPanelForm.Controls.Add(this.TLPEditClient, 0, 0);
            this.tableLayoutPanelForm.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanelForm.Controls.Add(this.FLPInfo, 0, 1);
            this.tableLayoutPanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelForm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelForm.Name = "tableLayoutPanelForm";
            this.tableLayoutPanelForm.RowCount = 3;
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.16028F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.839721F));
            this.tableLayoutPanelForm.Size = new System.Drawing.Size(634, 650);
            this.tableLayoutPanelForm.TabIndex = 1;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(10, 612);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(10, 5, 15, 5);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(103, 29);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete Client";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Visible = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // TLPEditClient
            // 
            this.TLPEditClient.ColumnCount = 4;
            this.tableLayoutPanelForm.SetColumnSpan(this.TLPEditClient, 2);
            this.TLPEditClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.TLPEditClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.TLPEditClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 381F));
            this.TLPEditClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.TLPEditClient.Controls.Add(this.iconButtonSettings, 3, 0);
            this.TLPEditClient.Controls.Add(this.labelEditClient, 0, 0);
            this.TLPEditClient.Controls.Add(this.radioButtonChild, 2, 1);
            this.TLPEditClient.Controls.Add(this.labelAdultOrChild, 0, 1);
            this.TLPEditClient.Controls.Add(this.radioButtonAdult, 1, 1);
            this.TLPEditClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPEditClient.Location = new System.Drawing.Point(3, 3);
            this.TLPEditClient.Name = "TLPEditClient";
            this.TLPEditClient.RowCount = 2;
            this.TLPEditClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.79012F));
            this.TLPEditClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.20988F));
            this.TLPEditClient.Size = new System.Drawing.Size(628, 58);
            this.TLPEditClient.TabIndex = 0;
            // 
            // iconButtonSettings
            // 
            this.iconButtonSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButtonSettings.BackColor = System.Drawing.Color.Transparent;
            this.iconButtonSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconButtonSettings.BackgroundImage")));
            this.iconButtonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconButtonSettings.FlatAppearance.BorderSize = 0;
            this.iconButtonSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButtonSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButtonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonSettings.Location = new System.Drawing.Point(591, 3);
            this.iconButtonSettings.MotionHeight = true;
            this.iconButtonSettings.MotionWidth = true;
            this.iconButtonSettings.Name = "iconButtonSettings";
            this.iconButtonSettings.Size = new System.Drawing.Size(32, 26);
            this.iconButtonSettings.TabIndex = 10;
            this.iconButtonSettings.UseVisualStyleBackColor = false;
            this.iconButtonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // labelEditClient
            // 
            this.labelEditClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEditClient.AutoSize = true;
            this.labelEditClient.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditClient.Location = new System.Drawing.Point(9, 1);
            this.labelEditClient.Name = "labelEditClient";
            this.labelEditClient.Size = new System.Drawing.Size(114, 30);
            this.labelEditClient.TabIndex = 6;
            this.labelEditClient.Text = "Edit Client";
            // 
            // radioButtonChild
            // 
            this.radioButtonChild.AutoSize = true;
            this.radioButtonChild.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonChild.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonChild.Location = new System.Drawing.Point(208, 35);
            this.radioButtonChild.Name = "radioButtonChild";
            this.radioButtonChild.Size = new System.Drawing.Size(56, 20);
            this.radioButtonChild.TabIndex = 8;
            this.radioButtonChild.TabStop = true;
            this.radioButtonChild.Text = "Child";
            this.radioButtonChild.UseVisualStyleBackColor = true;
            this.radioButtonChild.CheckedChanged += new System.EventHandler(this.radioButtonChild_CheckedChanged);
            // 
            // labelAdultOrChild
            // 
            this.labelAdultOrChild.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelAdultOrChild.AutoSize = true;
            this.labelAdultOrChild.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdultOrChild.Location = new System.Drawing.Point(4, 32);
            this.labelAdultOrChild.Name = "labelAdultOrChild";
            this.labelAdultOrChild.Size = new System.Drawing.Size(124, 21);
            this.labelAdultOrChild.TabIndex = 9;
            this.labelAdultOrChild.Text = "Adult Or Child ?";
            // 
            // radioButtonAdult
            // 
            this.radioButtonAdult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonAdult.AutoSize = true;
            this.radioButtonAdult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonAdult.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAdult.Location = new System.Drawing.Point(143, 35);
            this.radioButtonAdult.Name = "radioButtonAdult";
            this.radioButtonAdult.Size = new System.Drawing.Size(59, 20);
            this.radioButtonAdult.TabIndex = 7;
            this.radioButtonAdult.TabStop = true;
            this.radioButtonAdult.Text = "Adult";
            this.radioButtonAdult.UseVisualStyleBackColor = true;
            this.radioButtonAdult.CheckedChanged += new System.EventHandler(this.radioButtonAdult_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.Controls.Add(this.buttonSave);
            this.flowLayoutPanel1.Controls.Add(this.buttonAddToAlbumAndSave);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(139, 608);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(492, 38);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(112)))), ((int)(((byte)(214)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(396, 5);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(10, 5, 3, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(93, 29);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonAddToAlbumAndSave
            // 
            this.buttonAddToAlbumAndSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonAddToAlbumAndSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonAddToAlbumAndSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddToAlbumAndSave.FlatAppearance.BorderSize = 0;
            this.buttonAddToAlbumAndSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(112)))), ((int)(((byte)(214)))));
            this.buttonAddToAlbumAndSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddToAlbumAndSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddToAlbumAndSave.ForeColor = System.Drawing.Color.White;
            this.buttonAddToAlbumAndSave.Location = new System.Drawing.Point(198, 5);
            this.buttonAddToAlbumAndSave.Margin = new System.Windows.Forms.Padding(10, 5, 3, 5);
            this.buttonAddToAlbumAndSave.Name = "buttonAddToAlbumAndSave";
            this.buttonAddToAlbumAndSave.Size = new System.Drawing.Size(185, 29);
            this.buttonAddToAlbumAndSave.TabIndex = 2;
            this.buttonAddToAlbumAndSave.Text = "Add to album && Save";
            this.buttonAddToAlbumAndSave.UseVisualStyleBackColor = false;
            this.buttonAddToAlbumAndSave.Click += new System.EventHandler(this.buttonAddToAlbumAndSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(97)))), ((int)(((byte)(99)))));
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(92, 5);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(93, 29);
            this.buttonCancel.TabIndex = 736;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FLPInfo
            // 
            this.FLPInfo.AutoScroll = true;
            this.tableLayoutPanelForm.SetColumnSpan(this.FLPInfo, 2);
            this.FLPInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPInfo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLPInfo.Location = new System.Drawing.Point(5, 69);
            this.FLPInfo.Margin = new System.Windows.Forms.Padding(5);
            this.FLPInfo.Name = "FLPInfo";
            this.FLPInfo.Size = new System.Drawing.Size(624, 530);
            this.FLPInfo.TabIndex = 2;
            this.FLPInfo.WrapContents = false;
            this.FLPInfo.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flowLayoutPanelInfo_Scroll);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NewRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(634, 650);
            this.Controls.Add(this.tableLayoutPanelForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewRegister_FormClosing);
            this.tableLayoutPanelForm.ResumeLayout(false);
            this.TLPEditClient.ResumeLayout(false);
            this.TLPEditClient.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelForm;
        private System.Windows.Forms.Button buttonSave;
        public System.Windows.Forms.FlowLayoutPanel FLPInfo;
        private System.Windows.Forms.Label labelEditClient;
        private System.Windows.Forms.Label labelAdultOrChild;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonAddToAlbumAndSave;
        private System.Windows.Forms.Button buttonDelete;
        private IconButton iconButtonSettings;
        private System.Windows.Forms.TableLayoutPanel TLPEditClient;
        public System.Windows.Forms.RadioButton radioButtonAdult;
        public System.Windows.Forms.RadioButton radioButtonChild;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonCancel;
    }
}