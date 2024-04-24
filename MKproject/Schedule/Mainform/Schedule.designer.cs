namespace MKproject.Schedule
{
    partial class Schedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schedule));
            tableLayoutPanelForm = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelSide = new System.Windows.Forms.TableLayoutPanel();
            checkBoxCancel = new System.Windows.Forms.CheckBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            checkBoxComplete = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            panelreminder = new System.Windows.Forms.Panel();
            AddButton = new System.Windows.Forms.PictureBox();
            buttonAllReminder = new System.Windows.Forms.Button();
            checkBoxOnPending = new System.Windows.Forms.CheckBox();
            tableLayoutPanelForm.SuspendLayout();
            tableLayoutPanelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AddButton).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelForm
            // 
            tableLayoutPanelForm.BackColor = System.Drawing.Color.FromArgb(236, 238, 244);
            tableLayoutPanelForm.ColumnCount = 2;
            tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.07407F));
            tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.92593F));
            tableLayoutPanelForm.Controls.Add(tableLayoutPanelSide, 0, 0);
            tableLayoutPanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelForm.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelForm.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelForm.Name = "tableLayoutPanelForm";
            tableLayoutPanelForm.RowCount = 1;
            tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelForm.Size = new System.Drawing.Size(1485, 841);
            tableLayoutPanelForm.TabIndex = 0;
            // 
            // tableLayoutPanelSide
            // 
            tableLayoutPanelSide.Anchor = System.Windows.Forms.AnchorStyles.Top;
            tableLayoutPanelSide.BackColor = System.Drawing.Color.White;
            tableLayoutPanelSide.ColumnCount = 4;
            tableLayoutPanelSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.7887306F));
            tableLayoutPanelSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.2112732F));
            tableLayoutPanelSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.4507027F));
            tableLayoutPanelSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.5492954F));
            tableLayoutPanelSide.Controls.Add(checkBoxCancel, 0, 1);
            tableLayoutPanelSide.Controls.Add(pictureBox2, 0, 2);
            tableLayoutPanelSide.Controls.Add(checkBoxComplete, 2, 0);
            tableLayoutPanelSide.Controls.Add(label1, 1, 2);
            tableLayoutPanelSide.Controls.Add(panelreminder, 0, 3);
            tableLayoutPanelSide.Controls.Add(AddButton, 3, 2);
            tableLayoutPanelSide.Controls.Add(buttonAllReminder, 2, 2);
            tableLayoutPanelSide.Controls.Add(checkBoxOnPending, 0, 0);
            tableLayoutPanelSide.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelSide.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelSide.Name = "tableLayoutPanelSide";
            tableLayoutPanelSide.RowCount = 4;
            tableLayoutPanelSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanelSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            tableLayoutPanelSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.972375F));
            tableLayoutPanelSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.027626F));
            tableLayoutPanelSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanelSide.Size = new System.Drawing.Size(268, 841);
            tableLayoutPanelSide.TabIndex = 0;
            // 
            // checkBoxCancel
            // 
            checkBoxCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            checkBoxCancel.AutoSize = true;
            checkBoxCancel.BackColor = System.Drawing.Color.White;
            checkBoxCancel.Checked = true;
            checkBoxCancel.CheckState = System.Windows.Forms.CheckState.Checked;
            tableLayoutPanelSide.SetColumnSpan(checkBoxCancel, 4);
            checkBoxCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxCancel.ForeColor = System.Drawing.Color.FromArgb(244, 86, 7);
            checkBoxCancel.Location = new System.Drawing.Point(97, 47);
            checkBoxCancel.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            checkBoxCancel.Name = "checkBoxCancel";
            checkBoxCancel.Size = new System.Drawing.Size(81, 21);
            checkBoxCancel.TabIndex = 0;
            checkBoxCancel.Text = "Canceled";
            checkBoxCancel.UseVisualStyleBackColor = false;
            checkBoxCancel.CheckedChanged += checkBoxCancel_CheckedChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox2.Location = new System.Drawing.Point(8, 85);
            pictureBox2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(22, 25);
            pictureBox2.TabIndex = 64;
            pictureBox2.TabStop = false;
            // 
            // checkBoxComplete
            // 
            checkBoxComplete.Anchor = System.Windows.Forms.AnchorStyles.None;
            checkBoxComplete.AutoSize = true;
            checkBoxComplete.BackColor = System.Drawing.Color.White;
            checkBoxComplete.Checked = true;
            checkBoxComplete.CheckState = System.Windows.Forms.CheckState.Checked;
            tableLayoutPanelSide.SetColumnSpan(checkBoxComplete, 2);
            checkBoxComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxComplete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(128, 255, 128);
            checkBoxComplete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxComplete.ForeColor = System.Drawing.Color.FromArgb(124, 218, 124);
            checkBoxComplete.Location = new System.Drawing.Point(157, 9);
            checkBoxComplete.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            checkBoxComplete.Name = "checkBoxComplete";
            checkBoxComplete.Size = new System.Drawing.Size(93, 21);
            checkBoxComplete.TabIndex = 0;
            checkBoxComplete.Text = "Completed";
            checkBoxComplete.UseVisualStyleBackColor = false;
            checkBoxComplete.CheckedChanged += checkBoxComplete_CheckedChanged;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            label1.Location = new System.Drawing.Point(51, 86);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(70, 17);
            label1.TabIndex = 65;
            label1.Text = "Reminder:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelreminder
            // 
            panelreminder.AutoScroll = true;
            panelreminder.BackColor = System.Drawing.Color.FromArgb(249, 246, 254);
            tableLayoutPanelSide.SetColumnSpan(panelreminder, 4);
            panelreminder.Dock = System.Windows.Forms.DockStyle.Fill;
            panelreminder.Location = new System.Drawing.Point(4, 117);
            panelreminder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelreminder.Name = "panelreminder";
            panelreminder.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            panelreminder.Size = new System.Drawing.Size(260, 721);
            panelreminder.TabIndex = 0;
            // 
            // AddButton
            // 
            AddButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            AddButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("AddButton.BackgroundImage");
            AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            AddButton.Location = new System.Drawing.Point(230, 82);
            AddButton.Margin = new System.Windows.Forms.Padding(0);
            AddButton.Name = "AddButton";
            AddButton.Size = new System.Drawing.Size(29, 25);
            AddButton.TabIndex = 66;
            AddButton.TabStop = false;
            AddButton.Click += AddButton_Click;
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
            buttonAllReminder.Location = new System.Drawing.Point(154, 82);
            buttonAllReminder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonAllReminder.Name = "buttonAllReminder";
            buttonAllReminder.Size = new System.Drawing.Size(46, 25);
            buttonAllReminder.TabIndex = 70;
            buttonAllReminder.Text = "All";
            buttonAllReminder.UseVisualStyleBackColor = false;
            buttonAllReminder.Click += buttonAllReminder_Click;
            // 
            // checkBoxOnPending
            // 
            checkBoxOnPending.Anchor = System.Windows.Forms.AnchorStyles.None;
            checkBoxOnPending.AutoSize = true;
            checkBoxOnPending.BackColor = System.Drawing.Color.White;
            checkBoxOnPending.Checked = true;
            checkBoxOnPending.CheckState = System.Windows.Forms.CheckState.Checked;
            tableLayoutPanelSide.SetColumnSpan(checkBoxOnPending, 2);
            checkBoxOnPending.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxOnPending.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxOnPending.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            checkBoxOnPending.Location = new System.Drawing.Point(20, 9);
            checkBoxOnPending.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            checkBoxOnPending.Name = "checkBoxOnPending";
            checkBoxOnPending.Size = new System.Drawing.Size(99, 21);
            checkBoxOnPending.TabIndex = 0;
            checkBoxOnPending.Text = "On Pending";
            checkBoxOnPending.UseVisualStyleBackColor = false;
            checkBoxOnPending.CheckedChanged += checkBoxOnPending_CheckedChanged;
            // 
            // Schedule
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1485, 841);
            Controls.Add(tableLayoutPanelForm);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Schedule";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form1";
            tableLayoutPanelForm.ResumeLayout(false);
            tableLayoutPanelSide.ResumeLayout(false);
            tableLayoutPanelSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)AddButton).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSide;
        private System.Windows.Forms.CheckBox checkBoxOnPending;
        private System.Windows.Forms.CheckBox checkBoxComplete;
        private System.Windows.Forms.CheckBox checkBoxCancel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanelForm;
        private System.Windows.Forms.PictureBox AddButton;
        private System.Windows.Forms.Button buttonAllReminder;
        public System.Windows.Forms.Panel panelreminder;
    }
}

