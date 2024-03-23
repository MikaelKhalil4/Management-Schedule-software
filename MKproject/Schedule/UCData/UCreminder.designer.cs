namespace MKproject.Schedule
{
    partial class UCreminder
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCreminder));
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            buttonDelete = new System.Windows.Forms.Button();
            buttonUpdate = new System.Windows.Forms.Button();
            linkLabelName = new System.Windows.Forms.LinkLabel();
            panelColoredReminder = new System.Windows.Forms.Panel();
            checkBoxReminder = new System.Windows.Forms.CheckBox();
            TimerReminderDispose = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.51384735F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.99103F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.210762F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.4529152F));
            tableLayoutPanel1.Controls.Add(buttonDelete, 3, 0);
            tableLayoutPanel1.Controls.Add(buttonUpdate, 2, 0);
            tableLayoutPanel1.Controls.Add(linkLabelName, 1, 0);
            tableLayoutPanel1.Controls.Add(panelColoredReminder, 0, 0);
            tableLayoutPanel1.Controls.Add(checkBoxReminder, 1, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.70732F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.29268F));
            tableLayoutPanel1.Size = new System.Drawing.Size(223, 77);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = System.Drawing.Color.Transparent;
            buttonDelete.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonDelete.BackgroundImage");
            buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonDelete.Location = new System.Drawing.Point(195, 2);
            buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new System.Drawing.Size(25, 20);
            buttonDelete.TabIndex = 1;
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = System.Drawing.Color.Transparent;
            buttonUpdate.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonUpdate.BackgroundImage");
            buttonUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonUpdate.FlatAppearance.BorderSize = 0;
            buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonUpdate.Location = new System.Drawing.Point(171, 2);
            buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new System.Drawing.Size(18, 20);
            buttonUpdate.TabIndex = 1;
            buttonUpdate.UseVisualStyleBackColor = false;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // linkLabelName
            // 
            linkLabelName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            linkLabelName.AutoSize = true;
            linkLabelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            linkLabelName.LinkColor = System.Drawing.Color.FromArgb(109, 122, 224);
            linkLabelName.Location = new System.Drawing.Point(9, 4);
            linkLabelName.Margin = new System.Windows.Forms.Padding(4);
            linkLabelName.Name = "linkLabelName";
            linkLabelName.Size = new System.Drawing.Size(77, 15);
            linkLabelName.TabIndex = 4;
            linkLabelName.TabStop = true;
            linkLabelName.Text = "Mikael Khalil";
            linkLabelName.LinkClicked += linkLabelName_LinkClicked;
            // 
            // panelColoredReminder
            // 
            panelColoredReminder.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            panelColoredReminder.Dock = System.Windows.Forms.DockStyle.Fill;
            panelColoredReminder.Location = new System.Drawing.Point(0, 0);
            panelColoredReminder.Margin = new System.Windows.Forms.Padding(0);
            panelColoredReminder.Name = "panelColoredReminder";
            tableLayoutPanel1.SetRowSpan(panelColoredReminder, 2);
            panelColoredReminder.Size = new System.Drawing.Size(5, 77);
            panelColoredReminder.TabIndex = 5;
            // 
            // checkBoxReminder
            // 
            checkBoxReminder.AutoSize = true;
            checkBoxReminder.BackColor = System.Drawing.Color.Transparent;
            tableLayoutPanel1.SetColumnSpan(checkBoxReminder, 3);
            checkBoxReminder.FlatAppearance.BorderSize = 0;
            checkBoxReminder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            checkBoxReminder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBoxReminder.Location = new System.Drawing.Point(9, 28);
            checkBoxReminder.Margin = new System.Windows.Forms.Padding(4);
            checkBoxReminder.Name = "checkBoxReminder";
            checkBoxReminder.Size = new System.Drawing.Size(51, 21);
            checkBoxReminder.TabIndex = 3;
            checkBoxReminder.Text = "mika";
            checkBoxReminder.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            checkBoxReminder.UseVisualStyleBackColor = false;
            checkBoxReminder.Click += checkBoxReminder_Click;
            // 
            // TimerReminderDispose
            // 
            TimerReminderDispose.Interval = 1000;
            TimerReminderDispose.Tick += timer1_Tick;
            // 
            // UCreminder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(249, 246, 254);
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "UCreminder";
            Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            Size = new System.Drawing.Size(223, 84);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.LinkLabel linkLabelName;
        private System.Windows.Forms.Timer TimerReminderDispose;
        private System.Windows.Forms.CheckBox checkBoxReminder;
        private System.Windows.Forms.Panel panelColoredReminder;
    }
}
