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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRegister));
            tableLayoutPanelForm = new System.Windows.Forms.TableLayoutPanel();
            buttonDelete = new System.Windows.Forms.Button();
            TLPEditClient = new System.Windows.Forms.TableLayoutPanel();
            iconButtonSettings = new IconButton();
            labelEditClient = new System.Windows.Forms.Label();
            radioButtonChild = new System.Windows.Forms.RadioButton();
            labelAdultOrChild = new System.Windows.Forms.Label();
            radioButtonAdult = new System.Windows.Forms.RadioButton();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            buttonSave = new System.Windows.Forms.Button();
            buttonAddToAlbumAndSave = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            FLPInfo = new System.Windows.Forms.FlowLayoutPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanelForm.SuspendLayout();
            TLPEditClient.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelForm
            // 
            tableLayoutPanelForm.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            tableLayoutPanelForm.ColumnCount = 2;
            tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 489F));
            tableLayoutPanelForm.Controls.Add(buttonDelete, 0, 2);
            tableLayoutPanelForm.Controls.Add(TLPEditClient, 0, 0);
            tableLayoutPanelForm.Controls.Add(flowLayoutPanel1, 1, 2);
            tableLayoutPanelForm.Controls.Add(FLPInfo, 0, 1);
            tableLayoutPanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelForm.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelForm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanelForm.Name = "tableLayoutPanelForm";
            tableLayoutPanelForm.RowCount = 3;
            tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.16028F));
            tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.839721F));
            tableLayoutPanelForm.Size = new System.Drawing.Size(732, 633);
            tableLayoutPanelForm.TabIndex = 1;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            buttonDelete.BackColor = System.Drawing.Color.FromArgb(255, 50, 50);
            buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonDelete.ForeColor = System.Drawing.Color.White;
            buttonDelete.Location = new System.Drawing.Point(3, 594);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new System.Drawing.Size(120, 33);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Delete Client";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Visible = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // TLPEditClient
            // 
            TLPEditClient.ColumnCount = 4;
            tableLayoutPanelForm.SetColumnSpan(TLPEditClient, 2);
            TLPEditClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            TLPEditClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            TLPEditClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPEditClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            TLPEditClient.Controls.Add(iconButtonSettings, 3, 0);
            TLPEditClient.Controls.Add(labelEditClient, 0, 0);
            TLPEditClient.Controls.Add(radioButtonChild, 2, 1);
            TLPEditClient.Controls.Add(labelAdultOrChild, 0, 1);
            TLPEditClient.Controls.Add(radioButtonAdult, 1, 1);
            TLPEditClient.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPEditClient.Location = new System.Drawing.Point(4, 3);
            TLPEditClient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPEditClient.Name = "TLPEditClient";
            TLPEditClient.RowCount = 2;
            TLPEditClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.79012F));
            TLPEditClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.20988F));
            TLPEditClient.Size = new System.Drawing.Size(724, 68);
            TLPEditClient.TabIndex = 0;
            // 
            // iconButtonSettings
            // 
            iconButtonSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            iconButtonSettings.BackColor = System.Drawing.Color.Transparent;
            iconButtonSettings.BackgroundImage = (System.Drawing.Image)resources.GetObject("iconButtonSettings.BackgroundImage");
            iconButtonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            iconButtonSettings.FlatAppearance.BorderSize = 0;
            iconButtonSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            iconButtonSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            iconButtonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            iconButtonSettings.Location = new System.Drawing.Point(684, 4);
            iconButtonSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            iconButtonSettings.MotionHeight = true;
            iconButtonSettings.MotionWidth = true;
            iconButtonSettings.Name = "iconButtonSettings";
            iconButtonSettings.Size = new System.Drawing.Size(36, 30);
            iconButtonSettings.TabIndex = 10;
            iconButtonSettings.UseVisualStyleBackColor = false;
            iconButtonSettings.Click += buttonSettings_Click;
            // 
            // labelEditClient
            // 
            labelEditClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            labelEditClient.AutoSize = true;
            labelEditClient.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelEditClient.Location = new System.Drawing.Point(20, 4);
            labelEditClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelEditClient.Name = "labelEditClient";
            labelEditClient.Size = new System.Drawing.Size(114, 30);
            labelEditClient.TabIndex = 6;
            labelEditClient.Text = "Edit Client";
            // 
            // radioButtonChild
            // 
            radioButtonChild.AutoSize = true;
            radioButtonChild.Cursor = System.Windows.Forms.Cursors.Hand;
            radioButtonChild.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            radioButtonChild.Location = new System.Drawing.Point(243, 41);
            radioButtonChild.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButtonChild.Name = "radioButtonChild";
            radioButtonChild.Size = new System.Drawing.Size(56, 21);
            radioButtonChild.TabIndex = 8;
            radioButtonChild.TabStop = true;
            radioButtonChild.Text = "Child";
            radioButtonChild.UseVisualStyleBackColor = true;
            radioButtonChild.CheckedChanged += radioButtonChild_CheckedChanged;
            // 
            // labelAdultOrChild
            // 
            labelAdultOrChild.Anchor = System.Windows.Forms.AnchorStyles.Top;
            labelAdultOrChild.AutoSize = true;
            labelAdultOrChild.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelAdultOrChild.Location = new System.Drawing.Point(15, 38);
            labelAdultOrChild.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelAdultOrChild.Name = "labelAdultOrChild";
            labelAdultOrChild.Size = new System.Drawing.Size(124, 21);
            labelAdultOrChild.TabIndex = 9;
            labelAdultOrChild.Text = "Adult Or Child ?";
            // 
            // radioButtonAdult
            // 
            radioButtonAdult.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            radioButtonAdult.AutoSize = true;
            radioButtonAdult.Cursor = System.Windows.Forms.Cursors.Hand;
            radioButtonAdult.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            radioButtonAdult.Location = new System.Drawing.Point(176, 41);
            radioButtonAdult.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButtonAdult.Name = "radioButtonAdult";
            radioButtonAdult.Size = new System.Drawing.Size(59, 21);
            radioButtonAdult.TabIndex = 7;
            radioButtonAdult.TabStop = true;
            radioButtonAdult.Text = "Adult";
            radioButtonAdult.UseVisualStyleBackColor = true;
            radioButtonAdult.CheckedChanged += radioButtonAdult_CheckedChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            flowLayoutPanel1.Controls.Add(buttonSave);
            flowLayoutPanel1.Controls.Add(buttonAddToAlbumAndSave);
            flowLayoutPanel1.Controls.Add(buttonCancel);
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(247, 592);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(481, 38);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonSave.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(100, 112, 214);
            buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSave.ForeColor = System.Drawing.Color.White;
            buttonSave.Location = new System.Drawing.Point(370, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(108, 33);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonAddToAlbumAndSave
            // 
            buttonAddToAlbumAndSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonAddToAlbumAndSave.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonAddToAlbumAndSave.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonAddToAlbumAndSave.FlatAppearance.BorderSize = 0;
            buttonAddToAlbumAndSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(100, 112, 214);
            buttonAddToAlbumAndSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAddToAlbumAndSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonAddToAlbumAndSave.ForeColor = System.Drawing.Color.White;
            buttonAddToAlbumAndSave.Location = new System.Drawing.Point(148, 3);
            buttonAddToAlbumAndSave.Name = "buttonAddToAlbumAndSave";
            buttonAddToAlbumAndSave.Size = new System.Drawing.Size(216, 33);
            buttonAddToAlbumAndSave.TabIndex = 2;
            buttonAddToAlbumAndSave.Text = "Add to album && Save";
            buttonAddToAlbumAndSave.UseVisualStyleBackColor = false;
            buttonAddToAlbumAndSave.Click += buttonAddToAlbumAndSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = System.Drawing.Color.FromArgb(95, 97, 99);
            buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(105, 107, 109);
            buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCancel.ForeColor = System.Drawing.Color.White;
            buttonCancel.Location = new System.Drawing.Point(34, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(108, 33);
            buttonCancel.TabIndex = 736;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FLPInfo
            // 
            FLPInfo.AutoScroll = true;
            tableLayoutPanelForm.SetColumnSpan(FLPInfo, 2);
            FLPInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            FLPInfo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            FLPInfo.Location = new System.Drawing.Point(6, 80);
            FLPInfo.Margin = new System.Windows.Forms.Padding(6);
            FLPInfo.Name = "FLPInfo";
            FLPInfo.Size = new System.Drawing.Size(720, 503);
            FLPInfo.TabIndex = 2;
            FLPInfo.WrapContents = false;
            FLPInfo.Scroll += flowLayoutPanelInfo_Scroll;
            // 
            // timer1
            // 
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // NewRegister
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(732, 633);
            Controls.Add(tableLayoutPanelForm);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewRegister";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            FormClosing += NewRegister_FormClosing;
            tableLayoutPanelForm.ResumeLayout(false);
            TLPEditClient.ResumeLayout(false);
            TLPEditClient.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
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