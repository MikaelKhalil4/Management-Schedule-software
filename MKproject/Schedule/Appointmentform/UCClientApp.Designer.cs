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
            textBoxSearch = new CustomizedTools.TextBoxWithPlaceHolder();
            ButtonNewClient = new CustomizedTools.CustomButton();
            TLPglobal.SuspendLayout();
            SuspendLayout();
            // 
            // TLPglobal
            // 
            TLPglobal.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPglobal.ColumnCount = 4;
            TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            TLPglobal.Controls.Add(textBoxSearch, 1, 1);
            TLPglobal.Controls.Add(ButtonNewClient, 2, 1);
            TLPglobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPglobal.Location = new System.Drawing.Point(0, 0);
            TLPglobal.Margin = new System.Windows.Forms.Padding(0);
            TLPglobal.Name = "TLPglobal";
            TLPglobal.RowCount = 4;
            TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            TLPglobal.Size = new System.Drawing.Size(517, 304);
            TLPglobal.TabIndex = 0;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            textBoxSearch.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            textBoxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            textBoxSearch.IsRequiredModeOn = false;
            textBoxSearch.Location = new System.Drawing.Point(80, 113);
            textBoxSearch.Margin = new System.Windows.Forms.Padding(0);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "By name or phone ";
            textBoxSearch.Size = new System.Drawing.Size(306, 34);
            textBoxSearch.TabIndex = 31;
            textBoxSearch.Text = "By name or phone ";
            textBoxSearch.Click += textBoxSearch_Click;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // ButtonNewClient
            // 
            ButtonNewClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            ButtonNewClient.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(109, 122, 224);
            ButtonNewClient.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            TLPglobal.SetColumnSpan(ButtonNewClient, 2);
            ButtonNewClient.FlatAppearance.BorderSize = 0;
            ButtonNewClient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(69, 82, 184);
            ButtonNewClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(89, 102, 204);
            ButtonNewClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ButtonNewClient.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ButtonNewClient.ForeColor = System.Drawing.Color.White;
            ButtonNewClient.Image = (System.Drawing.Image)resources.GetObject("ButtonNewClient.Image");
            ButtonNewClient.Location = new System.Drawing.Point(399, 110);
            ButtonNewClient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ButtonNewClient.Name = "ButtonNewClient";
            ButtonNewClient.Size = new System.Drawing.Size(105, 39);
            ButtonNewClient.TabIndex = 70;
            ButtonNewClient.Text = "New Client";
            ButtonNewClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            ButtonNewClient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ButtonNewClient.UseVisualStyleBackColor = false;
            ButtonNewClient.Click += ButtonNewClient_Click;
            // 
            // UCClientApp
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            Controls.Add(TLPglobal);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "UCClientApp";
            Size = new System.Drawing.Size(517, 304);
            TLPglobal.ResumeLayout(false);
            TLPglobal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPglobal;
        public CustomizedTools.TextBoxWithPlaceHolder textBoxSearch;
        private CustomizedTools.CustomButton ButtonNewClient;
    }
}
