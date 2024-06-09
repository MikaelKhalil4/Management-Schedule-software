namespace MKproject.Schedule
{
    partial class ClientReminder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientReminder));
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panelreminder = new System.Windows.Forms.Panel();
            textBoxSearch = new CustomizedTools.TextBoxWithPlaceHolder();
            ButtonAdd = new System.Windows.Forms.PictureBox();
            pictureBoxSearch = new System.Windows.Forms.PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ButtonAdd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearch).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 263F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            tableLayoutPanel1.Controls.Add(panelreminder, 0, 1);
            tableLayoutPanel1.Controls.Add(textBoxSearch, 1, 0);
            tableLayoutPanel1.Controls.Add(ButtonAdd, 2, 0);
            tableLayoutPanel1.Controls.Add(pictureBoxSearch, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.46106F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.53894F));
            tableLayoutPanel1.Size = new System.Drawing.Size(347, 482);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelreminder
            // 
            panelreminder.AutoScroll = true;
            panelreminder.AutoSize = true;
            panelreminder.BackColor = System.Drawing.Color.FromArgb(238, 241, 254);
            tableLayoutPanel1.SetColumnSpan(panelreminder, 23);
            panelreminder.Dock = System.Windows.Forms.DockStyle.Fill;
            panelreminder.Location = new System.Drawing.Point(4, 64);
            panelreminder.Margin = new System.Windows.Forms.Padding(4);
            panelreminder.Name = "panelreminder";
            panelreminder.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            panelreminder.Size = new System.Drawing.Size(339, 414);
            panelreminder.TabIndex = 1;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            textBoxSearch.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            textBoxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            textBoxSearch.IsRequiredModeOn = false;
            textBoxSearch.Location = new System.Drawing.Point(45, 14);
            textBoxSearch.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "By name or number";
            textBoxSearch.Size = new System.Drawing.Size(252, 29);
            textBoxSearch.TabIndex = 32;
            textBoxSearch.Text = "By name or number";
            textBoxSearch.Click += textBoxSearch_Click;
            // 
            // ButtonAdd
            // 
            ButtonAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            ButtonAdd.BackgroundImage = (System.Drawing.Image)resources.GetObject("ButtonAdd.BackgroundImage");
            ButtonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            ButtonAdd.Location = new System.Drawing.Point(314, 20);
            ButtonAdd.Margin = new System.Windows.Forms.Padding(4);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new System.Drawing.Size(24, 20);
            ButtonAdd.TabIndex = 3;
            ButtonAdd.TabStop = false;
            ButtonAdd.Click += ButtonAdd_Click;
            // 
            // pictureBoxSearch
            // 
            pictureBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            pictureBoxSearch.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBoxSearch.BackgroundImage");
            pictureBoxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBoxSearch.Location = new System.Drawing.Point(15, 17);
            pictureBoxSearch.Margin = new System.Windows.Forms.Padding(7, 7, 0, 10);
            pictureBoxSearch.Name = "pictureBoxSearch";
            pictureBoxSearch.Size = new System.Drawing.Size(18, 22);
            pictureBoxSearch.TabIndex = 31;
            pictureBoxSearch.TabStop = false;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // ClientReminder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(347, 482);
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "ClientReminder";
            Opacity = 0D;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ClientRemindercs";
            Deactivate += ClientReminder_Deactivate;
            FormClosed += ClientReminder_FormClosed;
            Load += ClientReminder_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ButtonAdd).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearch).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Panel panelreminder;
        private System.Windows.Forms.PictureBox ButtonAdd;
        public CustomizedTools.TextBoxWithPlaceHolder textBoxSearch;
        public System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.Timer timer1;
    }
}