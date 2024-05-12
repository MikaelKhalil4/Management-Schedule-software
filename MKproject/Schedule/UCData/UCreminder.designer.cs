using CustomizedTools;

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
            buttonDelete = new IconButton();
            buttonUpdate = new IconButton();
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
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.46885848F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96.53114F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
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
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.7662354F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.2337646F));
            tableLayoutPanel1.Size = new System.Drawing.Size(223, 77);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonDelete.BackColor = System.Drawing.Color.Transparent;
            buttonDelete.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonDelete.BackgroundImage");
            buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonDelete.Location = new System.Drawing.Point(197, 4);
            buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            buttonDelete.MotionHeight = true;
            buttonDelete.MotionWidth = true;
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new System.Drawing.Size(18, 18);
            buttonDelete.TabIndex = 1;
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonUpdate.BackColor = System.Drawing.Color.Transparent;
            buttonUpdate.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonUpdate.BackgroundImage");
            buttonUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonUpdate.FlatAppearance.BorderSize = 0;
            buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonUpdate.Location = new System.Drawing.Point(165, 4);
            buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            buttonUpdate.MotionHeight = true;
            buttonUpdate.MotionWidth = true;
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new System.Drawing.Size(18, 18);
            buttonUpdate.TabIndex = 1;
            buttonUpdate.UseVisualStyleBackColor = false;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // linkLabelName
            // 
            linkLabelName.ActiveLinkColor = System.Drawing.Color.FromArgb(109, 122, 224);
            linkLabelName.AutoSize = true;
            linkLabelName.DisabledLinkColor = System.Drawing.Color.DodgerBlue;
            linkLabelName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            linkLabelName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            linkLabelName.LinkColor = System.Drawing.Color.FromArgb(109, 122, 224);
            linkLabelName.Location = new System.Drawing.Point(5, 4);
            linkLabelName.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            linkLabelName.Name = "linkLabelName";
            linkLabelName.Size = new System.Drawing.Size(74, 15);
            linkLabelName.TabIndex = 4;
            linkLabelName.TabStop = true;
            linkLabelName.Text = "Mikael Khalil";
            linkLabelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            linkLabelName.LinkClicked += linkLabelName_LinkClicked;
            // 
            // panelColoredReminder
            // 
            panelColoredReminder.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            panelColoredReminder.Dock = System.Windows.Forms.DockStyle.Left;
            panelColoredReminder.Location = new System.Drawing.Point(0, 0);
            panelColoredReminder.Margin = new System.Windows.Forms.Padding(0);
            panelColoredReminder.Name = "panelColoredReminder";
            tableLayoutPanel1.SetRowSpan(panelColoredReminder, 2);
            panelColoredReminder.Size = new System.Drawing.Size(4, 77);
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
            checkBoxReminder.Location = new System.Drawing.Point(9, 30);
            checkBoxReminder.Margin = new System.Windows.Forms.Padding(4);
            checkBoxReminder.Name = "checkBoxReminder";
            checkBoxReminder.Size = new System.Drawing.Size(51, 21);
            checkBoxReminder.TabIndex = 3;
            checkBoxReminder.Text = "mika";
            checkBoxReminder.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            checkBoxReminder.UseVisualStyleBackColor = false;
            checkBoxReminder.CheckedChanged += checkBoxReminder_CheckedChanged;
            checkBoxReminder.Click += checkBoxReminder_Click;
            // 
            // TimerReminderDispose
            // 
            TimerReminderDispose.Interval = 1000;
            TimerReminderDispose.Tick += TimerReminderDispose_Tick;
            // 
            // UCreminder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(238, 241, 254);
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

        private IconButton buttonDelete;
        private IconButton buttonUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.LinkLabel linkLabelName;
        private System.Windows.Forms.Timer TimerReminderDispose;
        private System.Windows.Forms.CheckBox checkBoxReminder;
        private System.Windows.Forms.Panel panelColoredReminder;
    }
}
