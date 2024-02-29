namespace MKproject
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.TLPHome = new System.Windows.Forms.TableLayoutPanel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.buttonMaximize = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.buttonBackHome = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.TLPHome.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPHome
            // 
            this.TLPHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPHome.ColumnCount = 1;
            this.TLPHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPHome.Controls.Add(this.panelTitleBar, 0, 0);
            this.TLPHome.Controls.Add(this.panelContainer, 0, 1);
            this.TLPHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPHome.Location = new System.Drawing.Point(0, 0);
            this.TLPHome.Margin = new System.Windows.Forms.Padding(0);
            this.TLPHome.Name = "TLPHome";
            this.TLPHome.RowCount = 2;
            this.TLPHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.TLPHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPHome.Size = new System.Drawing.Size(1271, 748);
            this.TLPHome.TabIndex = 1;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.White;
            this.panelTitleBar.Controls.Add(this.buttonMaximize);
            this.panelTitleBar.Controls.Add(this.buttonMinimize);
            this.panelTitleBar.Controls.Add(this.buttonClose);
            this.panelTitleBar.Controls.Add(this.flowLayoutPanel1);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1271, 31);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // buttonMaximize
            // 
            this.buttonMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMaximize.BackColor = System.Drawing.Color.Transparent;
            this.buttonMaximize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMaximize.BackgroundImage")));
            this.buttonMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMaximize.FlatAppearance.BorderSize = 0;
            this.buttonMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.buttonMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaximize.Location = new System.Drawing.Point(1221, 3);
            this.buttonMaximize.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.buttonMaximize.Name = "buttonMaximize";
            this.buttonMaximize.Size = new System.Drawing.Size(18, 18);
            this.buttonMaximize.TabIndex = 6;
            this.buttonMaximize.UseVisualStyleBackColor = false;
            this.buttonMaximize.Click += new System.EventHandler(this.buttonMaximize_Click);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMinimize.BackgroundImage")));
            this.buttonMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.buttonMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Location = new System.Drawing.Point(1194, 3);
            this.buttonMinimize.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(18, 18);
            this.buttonMinimize.TabIndex = 5;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClose.BackgroundImage")));
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(1248, 3);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(18, 18);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonMenu);
            this.flowLayoutPanel1.Controls.Add(this.buttonBackHome);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 31);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMenu.BackgroundImage")));
            this.buttonMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMenu.FlatAppearance.BorderSize = 0;
            this.buttonMenu.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.buttonMenu.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Location = new System.Drawing.Point(0, 3);
            this.buttonMenu.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(32, 25);
            this.buttonMenu.TabIndex = 0;
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // buttonBackHome
            // 
            this.buttonBackHome.BackColor = System.Drawing.Color.Transparent;
            this.buttonBackHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBackHome.FlatAppearance.BorderSize = 0;
            this.buttonBackHome.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.buttonBackHome.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonBackHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonBackHome.ForeColor = System.Drawing.Color.Black;
            this.buttonBackHome.Image = ((System.Drawing.Image)(resources.GetObject("buttonBackHome.Image")));
            this.buttonBackHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBackHome.Location = new System.Drawing.Point(32, 3);
            this.buttonBackHome.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.buttonBackHome.Name = "buttonBackHome";
            this.buttonBackHome.Size = new System.Drawing.Size(83, 25);
            this.buttonBackHome.TabIndex = 3;
            this.buttonBackHome.Text = "Home";
            this.buttonBackHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonBackHome.UseVisualStyleBackColor = false;
            this.buttonBackHome.Visible = false;
            this.buttonBackHome.Click += new System.EventHandler(this.buttonBackHome_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 31);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1271, 717);
            this.panelContainer.TabIndex = 2;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1271, 748);
            this.ControlBox = false;
            this.Controls.Add(this.TLPHome);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TLPHome.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.TableLayoutPanel TLPHome;
        public System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMaximize;
        private System.Windows.Forms.Button buttonMinimize;
        public System.Windows.Forms.Button buttonBackHome;
    }
}