namespace MKproject.Schedule
{
    partial class ScheduleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleForm));
            tableLayoutPanelForm = new System.Windows.Forms.TableLayoutPanel();
            TLPSide = new System.Windows.Forms.TableLayoutPanel();
            labelFilter = new System.Windows.Forms.Label();
            checkBoxCancel = new System.Windows.Forms.CheckBox();
            checkBoxComplete = new System.Windows.Forms.CheckBox();
            checkBoxOnPending = new System.Windows.Forms.CheckBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            buttonAllReminder = new System.Windows.Forms.Button();
            AddButton = new System.Windows.Forms.PictureBox();
            panelreminder = new System.Windows.Forms.Panel();
            tableLayoutPanelDoubleBufferedNoscroll1 = new TableLayoutPanelDoubleBufferedNoscroll();
            buttonToday = new System.Windows.Forms.Button();
            flowLayoutPanelDoubleBufferedcs1 = new System.Windows.Forms.FlowLayoutPanel();
            labelDate = new System.Windows.Forms.Label();
            DownArrow = new System.Windows.Forms.PictureBox();
            tableLayoutPanelForm.SuspendLayout();
            TLPSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AddButton).BeginInit();
            tableLayoutPanelDoubleBufferedNoscroll1.SuspendLayout();
            flowLayoutPanelDoubleBufferedcs1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrow).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelForm
            // 
            tableLayoutPanelForm.BackColor = System.Drawing.Color.WhiteSmoke;
            tableLayoutPanelForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            tableLayoutPanelForm.ColumnCount = 2;
            tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelForm.Controls.Add(TLPSide, 0, 0);
            tableLayoutPanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelForm.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tableLayoutPanelForm.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelForm.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelForm.Name = "tableLayoutPanelForm";
            tableLayoutPanelForm.RowCount = 1;
            tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 715F));
            tableLayoutPanelForm.Size = new System.Drawing.Size(1485, 791);
            tableLayoutPanelForm.TabIndex = 0;
            // 
            // TLPSide
            // 
            TLPSide.BackColor = System.Drawing.Color.White;
            TLPSide.ColumnCount = 4;
            TLPSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.73375F));
            TLPSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            TLPSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.1730766F));
            TLPSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.1263943F));
            TLPSide.Controls.Add(labelFilter, 0, 0);
            TLPSide.Controls.Add(checkBoxCancel, 0, 3);
            TLPSide.Controls.Add(checkBoxComplete, 0, 2);
            TLPSide.Controls.Add(checkBoxOnPending, 0, 1);
            TLPSide.Controls.Add(pictureBox2, 0, 4);
            TLPSide.Controls.Add(label1, 1, 4);
            TLPSide.Controls.Add(buttonAllReminder, 2, 4);
            TLPSide.Controls.Add(AddButton, 3, 4);
            TLPSide.Controls.Add(panelreminder, 0, 5);
            TLPSide.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPSide.Location = new System.Drawing.Point(0, 0);
            TLPSide.Margin = new System.Windows.Forms.Padding(0);
            TLPSide.Name = "TLPSide";
            TLPSide.RowCount = 6;
            TLPSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            TLPSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            TLPSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            TLPSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            TLPSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            TLPSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPSide.Size = new System.Drawing.Size(208, 791);
            TLPSide.TabIndex = 1;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.BackColor = System.Drawing.Color.White;
            TLPSide.SetColumnSpan(labelFilter, 4);
            labelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            labelFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelFilter.ForeColor = System.Drawing.Color.Black;
            labelFilter.Location = new System.Drawing.Point(0, 0);
            labelFilter.Margin = new System.Windows.Forms.Padding(0);
            labelFilter.Name = "labelFilter";
            labelFilter.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            labelFilter.Size = new System.Drawing.Size(208, 30);
            labelFilter.TabIndex = 0;
            labelFilter.Text = "Filters:";
            labelFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxCancel
            // 
            checkBoxCancel.BackColor = System.Drawing.Color.White;
            checkBoxCancel.Checked = true;
            checkBoxCancel.CheckState = System.Windows.Forms.CheckState.Checked;
            TLPSide.SetColumnSpan(checkBoxCancel, 2);
            checkBoxCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxCancel.ForeColor = System.Drawing.Color.FromArgb(244, 86, 7);
            checkBoxCancel.Location = new System.Drawing.Point(10, 93);
            checkBoxCancel.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            checkBoxCancel.Name = "checkBoxCancel";
            checkBoxCancel.Size = new System.Drawing.Size(95, 24);
            checkBoxCancel.TabIndex = 0;
            checkBoxCancel.Text = "Canceled";
            checkBoxCancel.UseVisualStyleBackColor = false;
            // 
            // checkBoxComplete
            // 
            checkBoxComplete.AutoSize = true;
            checkBoxComplete.BackColor = System.Drawing.Color.White;
            checkBoxComplete.Checked = true;
            checkBoxComplete.CheckState = System.Windows.Forms.CheckState.Checked;
            TLPSide.SetColumnSpan(checkBoxComplete, 2);
            checkBoxComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxComplete.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxComplete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(128, 255, 128);
            checkBoxComplete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxComplete.ForeColor = System.Drawing.Color.FromArgb(124, 218, 124);
            checkBoxComplete.Location = new System.Drawing.Point(10, 63);
            checkBoxComplete.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            checkBoxComplete.Name = "checkBoxComplete";
            checkBoxComplete.Size = new System.Drawing.Size(95, 24);
            checkBoxComplete.TabIndex = 0;
            checkBoxComplete.Text = "Completed";
            checkBoxComplete.UseVisualStyleBackColor = false;
            // 
            // checkBoxOnPending
            // 
            checkBoxOnPending.AutoSize = true;
            checkBoxOnPending.BackColor = System.Drawing.Color.White;
            checkBoxOnPending.Checked = true;
            checkBoxOnPending.CheckState = System.Windows.Forms.CheckState.Checked;
            TLPSide.SetColumnSpan(checkBoxOnPending, 2);
            checkBoxOnPending.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxOnPending.Dock = System.Windows.Forms.DockStyle.Fill;
            checkBoxOnPending.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxOnPending.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            checkBoxOnPending.Location = new System.Drawing.Point(10, 33);
            checkBoxOnPending.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            checkBoxOnPending.Name = "checkBoxOnPending";
            checkBoxOnPending.Size = new System.Drawing.Size(95, 24);
            checkBoxOnPending.TabIndex = 0;
            checkBoxOnPending.Text = "Onpending";
            checkBoxOnPending.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox2.Location = new System.Drawing.Point(2, 125);
            pictureBox2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(25, 34);
            pictureBox2.TabIndex = 64;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            label1.Location = new System.Drawing.Point(34, 131);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(70, 17);
            label1.TabIndex = 65;
            label1.Text = "Reminder:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAllReminder
            // 
            buttonAllReminder.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonAllReminder.BackColor = System.Drawing.Color.WhiteSmoke;
            buttonAllReminder.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonAllReminder.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            buttonAllReminder.FlatAppearance.BorderSize = 0;
            buttonAllReminder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAllReminder.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            buttonAllReminder.Location = new System.Drawing.Point(123, 127);
            buttonAllReminder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonAllReminder.Name = "buttonAllReminder";
            buttonAllReminder.Size = new System.Drawing.Size(38, 25);
            buttonAllReminder.TabIndex = 70;
            buttonAllReminder.Text = "All";
            buttonAllReminder.UseVisualStyleBackColor = false;
            buttonAllReminder.Click += buttonAllReminder_Click;
            // 
            // AddButton
            // 
            AddButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            AddButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("AddButton.BackgroundImage");
            AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            AddButton.Location = new System.Drawing.Point(177, 127);
            AddButton.Margin = new System.Windows.Forms.Padding(0);
            AddButton.Name = "AddButton";
            AddButton.Size = new System.Drawing.Size(30, 25);
            AddButton.TabIndex = 66;
            AddButton.TabStop = false;
            AddButton.Click += AddButton_Click;
            // 
            // panelreminder
            // 
            panelreminder.AutoScroll = true;
            panelreminder.BackColor = System.Drawing.Color.FromArgb(249, 246, 254);
            TLPSide.SetColumnSpan(panelreminder, 4);
            panelreminder.Dock = System.Windows.Forms.DockStyle.Fill;
            panelreminder.Location = new System.Drawing.Point(0, 159);
            panelreminder.Margin = new System.Windows.Forms.Padding(0);
            panelreminder.Name = "panelreminder";
            panelreminder.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            panelreminder.Size = new System.Drawing.Size(208, 632);
            panelreminder.TabIndex = 0;
            // 
            // tableLayoutPanelDoubleBufferedNoscroll1
            // 
            tableLayoutPanelDoubleBufferedNoscroll1.ColumnCount = 5;
            tableLayoutPanelDoubleBufferedNoscroll1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            tableLayoutPanelDoubleBufferedNoscroll1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanelDoubleBufferedNoscroll1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanelDoubleBufferedNoscroll1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218F));
            tableLayoutPanelDoubleBufferedNoscroll1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelDoubleBufferedNoscroll1.Controls.Add(buttonToday, 0, 0);
            tableLayoutPanelDoubleBufferedNoscroll1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelDoubleBufferedNoscroll1.Name = "tableLayoutPanelDoubleBufferedNoscroll1";
            tableLayoutPanelDoubleBufferedNoscroll1.RowCount = 1;
            tableLayoutPanelDoubleBufferedNoscroll1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanelDoubleBufferedNoscroll1.Size = new System.Drawing.Size(200, 100);
            tableLayoutPanelDoubleBufferedNoscroll1.TabIndex = 0;
            // 
            // buttonToday
            // 
            buttonToday.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonToday.BackColor = System.Drawing.Color.WhiteSmoke;
            buttonToday.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonToday.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            buttonToday.FlatAppearance.BorderSize = 0;
            buttonToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonToday.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            buttonToday.Location = new System.Drawing.Point(10, 37);
            buttonToday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonToday.Name = "buttonToday";
            buttonToday.Size = new System.Drawing.Size(97, 25);
            buttonToday.TabIndex = 69;
            buttonToday.Text = "Today";
            buttonToday.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanelDoubleBufferedcs1
            // 
            flowLayoutPanelDoubleBufferedcs1.Anchor = System.Windows.Forms.AnchorStyles.None;
            flowLayoutPanelDoubleBufferedcs1.Controls.Add(labelDate);
            flowLayoutPanelDoubleBufferedcs1.Controls.Add(DownArrow);
            flowLayoutPanelDoubleBufferedcs1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            flowLayoutPanelDoubleBufferedcs1.Location = new System.Drawing.Point(194, 37);
            flowLayoutPanelDoubleBufferedcs1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanelDoubleBufferedcs1.Name = "flowLayoutPanelDoubleBufferedcs1";
            flowLayoutPanelDoubleBufferedcs1.Size = new System.Drawing.Size(204, 25);
            flowLayoutPanelDoubleBufferedcs1.TabIndex = 0;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Cursor = System.Windows.Forms.Cursors.Hand;
            labelDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelDate.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelDate.Location = new System.Drawing.Point(4, 3);
            labelDate.Margin = new System.Windows.Forms.Padding(4, 3, 0, 0);
            labelDate.Name = "labelDate";
            labelDate.Size = new System.Drawing.Size(118, 17);
            labelDate.TabIndex = 60;
            labelDate.Text = "Day,00 Week,Year";
            labelDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DownArrow
            // 
            DownArrow.BackgroundImage = (System.Drawing.Image)resources.GetObject("DownArrow.BackgroundImage");
            DownArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            DownArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            DownArrow.Image = (System.Drawing.Image)resources.GetObject("DownArrow.Image");
            DownArrow.Location = new System.Drawing.Point(122, 0);
            DownArrow.Margin = new System.Windows.Forms.Padding(0);
            DownArrow.Name = "DownArrow";
            DownArrow.Size = new System.Drawing.Size(27, 22);
            DownArrow.TabIndex = 61;
            DownArrow.TabStop = false;
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1485, 791);
            Controls.Add(tableLayoutPanelForm);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ScheduleForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form1";
            tableLayoutPanelForm.ResumeLayout(false);
            TLPSide.ResumeLayout(false);
            TLPSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)AddButton).EndInit();
            tableLayoutPanelDoubleBufferedNoscroll1.ResumeLayout(false);
            flowLayoutPanelDoubleBufferedcs1.ResumeLayout(false);
            flowLayoutPanelDoubleBufferedcs1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrow).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanelForm;
        private System.Windows.Forms.TableLayoutPanel TLPSide;
        private System.Windows.Forms.Label labelFilter;
        public System.Windows.Forms.CheckBox checkBoxCancel;
        public System.Windows.Forms.CheckBox checkBoxComplete;
        public System.Windows.Forms.CheckBox checkBoxOnPending;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAllReminder;
        private System.Windows.Forms.PictureBox AddButton;
        public System.Windows.Forms.Panel panelreminder;
        private TableLayoutPanelDoubleBufferedNoscroll tableLayoutPanelDoubleBufferedNoscroll1;
        private System.Windows.Forms.Button buttonToday;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDoubleBufferedcs1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.PictureBox DownArrow;
    }
}

