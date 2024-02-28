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
            this.TLPglobal = new System.Windows.Forms.TableLayoutPanel();
            this.TLPAddNewClient = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxSearch = new CustomizedTools.TextBoxWithPlaceHolder();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.TLPglobal.SuspendLayout();
            this.TLPAddNewClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // TLPglobal
            // 
            this.TLPglobal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPglobal.ColumnCount = 5;
            this.TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.TLPglobal.Controls.Add(this.TLPAddNewClient, 4, 0);
            this.TLPglobal.Controls.Add(this.textBoxSearch, 1, 0);
            this.TLPglobal.Controls.Add(this.pictureBoxSearch, 0, 0);
            this.TLPglobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPglobal.Location = new System.Drawing.Point(0, 0);
            this.TLPglobal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TLPglobal.Name = "TLPglobal";
            this.TLPglobal.RowCount = 3;
            this.TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.0729F));
            this.TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.96355F));
            this.TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.96355F));
            this.TLPglobal.Size = new System.Drawing.Size(560, 150);
            this.TLPglobal.TabIndex = 0;
            // 
            // TLPAddNewClient
            // 
            this.TLPAddNewClient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TLPAddNewClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.TLPAddNewClient.ColumnCount = 2;
            this.TLPAddNewClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPAddNewClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TLPAddNewClient.Controls.Add(this.label1, 1, 0);
            this.TLPAddNewClient.Controls.Add(this.pictureBox1, 0, 0);
            this.TLPAddNewClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TLPAddNewClient.Location = new System.Drawing.Point(429, 4);
            this.TLPAddNewClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TLPAddNewClient.Name = "TLPAddNewClient";
            this.TLPAddNewClient.RowCount = 1;
            this.TLPAddNewClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPAddNewClient.Size = new System.Drawing.Size(123, 37);
            this.TLPAddNewClient.TabIndex = 68;
            this.TLPAddNewClient.MouseLeave += new System.EventHandler(this.TLPAddNewClient_MouseLeave);
            this.TLPAddNewClient.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TLPAddNewClient_MouseMove);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(38, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 65;
            this.label1.Text = "New Client";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseLeave += new System.EventHandler(this.TLPAddNewClient_MouseLeave);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TLPAddNewClient_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(2, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 25);
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseLeave += new System.EventHandler(this.TLPAddNewClient_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TLPAddNewClient_MouseMove);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPglobal.SetColumnSpan(this.textBoxSearch, 3);
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSearch.Location = new System.Drawing.Point(44, 4);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Search by name or phone number...";
            this.textBoxSearch.Size = new System.Drawing.Size(341, 29);
            this.textBoxSearch.TabIndex = 31;
            this.textBoxSearch.Text = "Search by name or phone number...";
            this.textBoxSearch.Click += new System.EventHandler(this.textBoxSearch_Click);
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxSearch.BackgroundImage")));
            this.pictureBoxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxSearch.Location = new System.Drawing.Point(9, 7);
            this.pictureBoxSearch.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(35, 25);
            this.pictureBoxSearch.TabIndex = 32;
            this.pictureBoxSearch.TabStop = false;
            // 
            // UCClientApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TLPglobal);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UCClientApp";
            this.Size = new System.Drawing.Size(560, 150);
            this.TLPglobal.ResumeLayout(false);
            this.TLPglobal.PerformLayout();
            this.TLPAddNewClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPglobal;
        public CustomizedTools.TextBoxWithPlaceHolder textBoxSearch;
        public System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel TLPAddNewClient;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
