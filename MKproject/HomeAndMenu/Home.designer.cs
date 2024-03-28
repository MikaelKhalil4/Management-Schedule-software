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
            TLPHome = new System.Windows.Forms.TableLayoutPanel();
            panelTitleBar = new System.Windows.Forms.Panel();
            buttonMaximize = new System.Windows.Forms.Button();
            buttonMinimize = new System.Windows.Forms.Button();
            buttonClose = new System.Windows.Forms.Button();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            buttonMenu = new System.Windows.Forms.Button();
            buttonBackHome = new System.Windows.Forms.Button();
            panelContainer = new System.Windows.Forms.Panel();
            TLPHome.SuspendLayout();
            panelTitleBar.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TLPHome
            // 
            TLPHome.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPHome.ColumnCount = 1;
            TLPHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPHome.Controls.Add(panelTitleBar, 0, 0);
            TLPHome.Controls.Add(panelContainer, 0, 1);
            TLPHome.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPHome.Location = new System.Drawing.Point(0, 0);
            TLPHome.Margin = new System.Windows.Forms.Padding(0);
            TLPHome.Name = "TLPHome";
            TLPHome.RowCount = 2;
            TLPHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            TLPHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPHome.Size = new System.Drawing.Size(1271, 748);
            TLPHome.TabIndex = 1;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = System.Drawing.Color.White;
            panelTitleBar.Controls.Add(buttonMaximize);
            panelTitleBar.Controls.Add(buttonMinimize);
            panelTitleBar.Controls.Add(buttonClose);
            panelTitleBar.Controls.Add(flowLayoutPanel1);
            panelTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTitleBar.Location = new System.Drawing.Point(0, 0);
            panelTitleBar.Margin = new System.Windows.Forms.Padding(0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new System.Drawing.Size(1271, 31);
            panelTitleBar.TabIndex = 1;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            // 
            // buttonMaximize
            // 
            buttonMaximize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonMaximize.BackColor = System.Drawing.Color.Transparent;
            buttonMaximize.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonMaximize.BackgroundImage");
            buttonMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonMaximize.FlatAppearance.BorderSize = 0;
            buttonMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            buttonMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            buttonMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonMaximize.Location = new System.Drawing.Point(1221, 3);
            buttonMaximize.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            buttonMaximize.Name = "buttonMaximize";
            buttonMaximize.Size = new System.Drawing.Size(18, 18);
            buttonMaximize.TabIndex = 6;
            buttonMaximize.UseVisualStyleBackColor = false;
            buttonMaximize.Click += buttonMaximize_Click;
            // 
            // buttonMinimize
            // 
            buttonMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonMinimize.BackColor = System.Drawing.Color.Transparent;
            buttonMinimize.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonMinimize.BackgroundImage");
            buttonMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonMinimize.FlatAppearance.BorderSize = 0;
            buttonMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            buttonMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonMinimize.Location = new System.Drawing.Point(1194, 3);
            buttonMinimize.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            buttonMinimize.Name = "buttonMinimize";
            buttonMinimize.Size = new System.Drawing.Size(18, 18);
            buttonMinimize.TabIndex = 5;
            buttonMinimize.UseVisualStyleBackColor = false;
            buttonMinimize.Click += buttonMinimize_Click;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonClose.BackColor = System.Drawing.Color.Transparent;
            buttonClose.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonClose.BackgroundImage");
            buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonClose.Location = new System.Drawing.Point(1248, 3);
            buttonClose.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new System.Drawing.Size(18, 18);
            buttonClose.TabIndex = 0;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonMenu);
            flowLayoutPanel1.Controls.Add(buttonBackHome);
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(200, 31);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // buttonMenu
            // 
            buttonMenu.BackColor = System.Drawing.Color.Transparent;
            buttonMenu.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonMenu.BackgroundImage");
            buttonMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonMenu.FlatAppearance.BorderSize = 0;
            buttonMenu.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            buttonMenu.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonMenu.Location = new System.Drawing.Point(0, 3);
            buttonMenu.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            buttonMenu.Name = "buttonMenu";
            buttonMenu.Size = new System.Drawing.Size(32, 25);
            buttonMenu.TabIndex = 0;
            buttonMenu.UseVisualStyleBackColor = false;
            buttonMenu.Click += buttonMenu_Click;
            // 
            // buttonBackHome
            // 
            buttonBackHome.BackColor = System.Drawing.Color.Transparent;
            buttonBackHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonBackHome.FlatAppearance.BorderSize = 0;
            buttonBackHome.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            buttonBackHome.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            buttonBackHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonBackHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonBackHome.ForeColor = System.Drawing.Color.Black;
            buttonBackHome.Image = (System.Drawing.Image)resources.GetObject("buttonBackHome.Image");
            buttonBackHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonBackHome.Location = new System.Drawing.Point(32, 3);
            buttonBackHome.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            buttonBackHome.Name = "buttonBackHome";
            buttonBackHome.Size = new System.Drawing.Size(98, 25);
            buttonBackHome.TabIndex = 3;
            buttonBackHome.Text = "Schedule";
            buttonBackHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            buttonBackHome.UseVisualStyleBackColor = false;
            buttonBackHome.Visible = false;
            buttonBackHome.Click += buttonBackHome_Click;
            // 
            // panelContainer
            // 
            panelContainer.BackColor = System.Drawing.Color.White;
            panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelContainer.Location = new System.Drawing.Point(0, 31);
            panelContainer.Margin = new System.Windows.Forms.Padding(0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new System.Drawing.Size(1271, 717);
            panelContainer.TabIndex = 2;
            // 
            // Home
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1271, 748);
            ControlBox = false;
            Controls.Add(TLPHome);
            Name = "Home";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            TLPHome.ResumeLayout(false);
            panelTitleBar.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
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