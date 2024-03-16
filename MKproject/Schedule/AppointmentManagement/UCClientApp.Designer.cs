namespace MKproject.Schedule
{
    partial class UCClientApp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCClientApp));
            TLPglobal = new System.Windows.Forms.TableLayoutPanel();
            TLPAddNewClient = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            textBoxSearch = new CustomizedTools.TextBoxWithPlaceHolder();
            ucSlideButtonServicerOthers = new CustomizedTools.UCSlideButton();
            TLPglobal.SuspendLayout();
            TLPAddNewClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TLPglobal
            // 
            TLPglobal.BackColor = System.Drawing.Color.Transparent;
            TLPglobal.ColumnCount = 3;
            TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            TLPglobal.Controls.Add(TLPAddNewClient, 2, 1);
            TLPglobal.Controls.Add(textBoxSearch, 1, 1);
            TLPglobal.Controls.Add(ucSlideButtonServicerOthers, 0, 0);
            TLPglobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPglobal.Location = new System.Drawing.Point(0, 0);
            TLPglobal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPglobal.Name = "TLPglobal";
            TLPglobal.RowCount = 3;
            TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            TLPglobal.Size = new System.Drawing.Size(452, 166);
            TLPglobal.TabIndex = 0;
            // 
            // TLPAddNewClient
            // 
            TLPAddNewClient.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            TLPAddNewClient.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            TLPAddNewClient.ColumnCount = 2;
            TLPAddNewClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPAddNewClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            TLPAddNewClient.Controls.Add(label1, 1, 0);
            TLPAddNewClient.Controls.Add(pictureBox1, 0, 0);
            TLPAddNewClient.Cursor = System.Windows.Forms.Cursors.Hand;
            TLPAddNewClient.Location = new System.Drawing.Point(355, 72);
            TLPAddNewClient.Margin = new System.Windows.Forms.Padding(0, 10, 6, 4);
            TLPAddNewClient.Name = "TLPAddNewClient";
            TLPAddNewClient.RowCount = 1;
            TLPAddNewClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPAddNewClient.Size = new System.Drawing.Size(91, 29);
            TLPAddNewClient.TabIndex = 68;
            TLPAddNewClient.Click += TLPAddNewClient_Click;
            TLPAddNewClient.MouseLeave += TLPAddNewClient_MouseLeave;
            TLPAddNewClient.MouseMove += TLPAddNewClient_MouseMove;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Cursor = System.Windows.Forms.Cursors.Hand;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(27, 3);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 23);
            label1.TabIndex = 65;
            label1.Text = "New Client";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label1.Click += TLPAddNewClient_Click;
            label1.MouseLeave += TLPAddNewClient_MouseLeave;
            label1.MouseMove += TLPAddNewClient_MouseMove;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox1.Location = new System.Drawing.Point(0, 3);
            pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(27, 23);
            pictureBox1.TabIndex = 66;
            pictureBox1.TabStop = false;
            pictureBox1.Click += TLPAddNewClient_Click;
            pictureBox1.MouseLeave += TLPAddNewClient_MouseLeave;
            pictureBox1.MouseMove += TLPAddNewClient_MouseMove;
            // 
            // textBoxSearch
            // 
            textBoxSearch.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            textBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            textBoxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            textBoxSearch.IsRequiredModeOn = false;
            textBoxSearch.Location = new System.Drawing.Point(70, 72);
            textBoxSearch.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "By name or phone ";
            textBoxSearch.Size = new System.Drawing.Size(276, 29);
            textBoxSearch.TabIndex = 31;
            textBoxSearch.Text = "By name or phone ";
            textBoxSearch.Click += textBoxSearch_Click;
            // 
            // ucSlideButtonServicerOthers
            // 
            ucSlideButtonServicerOthers.Anchor = System.Windows.Forms.AnchorStyles.None;
            ucSlideButtonServicerOthers.BackColor = System.Drawing.Color.FromArgb(139, 152, 224);
            ucSlideButtonServicerOthers.Button1text = "Service";
            ucSlideButtonServicerOthers.Button2text = "Others";
            ucSlideButtonServicerOthers.ClickedButton = null;
            TLPglobal.SetColumnSpan(ucSlideButtonServicerOthers, 3);
            ucSlideButtonServicerOthers.Location = new System.Drawing.Point(108, 13);
            ucSlideButtonServicerOthers.Margin = new System.Windows.Forms.Padding(5);
            ucSlideButtonServicerOthers.Name = "ucSlideButtonServicerOthers";
            ucSlideButtonServicerOthers.Size = new System.Drawing.Size(236, 36);
            ucSlideButtonServicerOthers.TabIndex = 76;
            // 
            // UCClientApp
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            Controls.Add(TLPglobal);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "UCClientApp";
            Size = new System.Drawing.Size(452, 166);
            TLPglobal.ResumeLayout(false);
            TLPglobal.PerformLayout();
            TLPAddNewClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPglobal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel TLPAddNewClient;
        private System.Windows.Forms.PictureBox pictureBox1;
        public CustomizedTools.TextBoxWithPlaceHolder textBoxSearch;
        private CustomizedTools.UCSlideButton ucSlideButtonServicerOthers;
    }
}
