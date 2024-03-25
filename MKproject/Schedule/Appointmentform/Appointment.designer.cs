namespace MKproject.Schedule
{
    partial class Appointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Appointment));
            TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            labelEmployee = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            textBoxNotes = new CustomizedTools.TextBoxWithPlaceHolder();
            buttonDelete = new CustomizedTools.CustomButton();
            labelDifferenceTime = new System.Windows.Forms.Label();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            textBoxEndTime = new System.Windows.Forms.TextBox();
            DownArrowEndTime = new System.Windows.Forms.PictureBox();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            textBoxStartTime = new System.Windows.Forms.TextBox();
            DownArrowStartTime = new System.Windows.Forms.PictureBox();
            labelStartTime = new System.Windows.Forms.Label();
            labelEndTime = new System.Windows.Forms.Label();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            ButtonAddOrUpdate = new CustomizedTools.CustomButton();
            buttonCompleted = new CustomizedTools.CustomButton();
            buttonCanceled = new CustomizedTools.CustomButton();
            label1 = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(components);
            TLPGlobal.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrowEndTime).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrowStartTime).BeginInit();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // TLPGlobal
            // 
            TLPGlobal.ColumnCount = 2;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 314F));
            TLPGlobal.Controls.Add(labelEmployee, 1, 4);
            TLPGlobal.Controls.Add(label2, 0, 4);
            TLPGlobal.Controls.Add(textBoxNotes, 0, 5);
            TLPGlobal.Controls.Add(buttonDelete, 0, 6);
            TLPGlobal.Controls.Add(labelDifferenceTime, 1, 3);
            TLPGlobal.Controls.Add(flowLayoutPanel2, 1, 2);
            TLPGlobal.Controls.Add(flowLayoutPanel1, 1, 1);
            TLPGlobal.Controls.Add(labelStartTime, 0, 1);
            TLPGlobal.Controls.Add(labelEndTime, 0, 2);
            TLPGlobal.Controls.Add(flowLayoutPanel3, 1, 6);
            TLPGlobal.Controls.Add(label1, 0, 3);
            TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 0);
            TLPGlobal.Margin = new System.Windows.Forms.Padding(0);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 7;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 218F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            TLPGlobal.Size = new System.Drawing.Size(447, 537);
            TLPGlobal.TabIndex = 70;
            // 
            // labelEmployee
            // 
            labelEmployee.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelEmployee.AutoSize = true;
            labelEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelEmployee.Location = new System.Drawing.Point(323, 383);
            labelEmployee.Margin = new System.Windows.Forms.Padding(6);
            labelEmployee.Name = "labelEmployee";
            labelEmployee.Size = new System.Drawing.Size(118, 20);
            labelEmployee.TabIndex = 745;
            labelEmployee.Text = "Andrea Mayada";
            labelEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(6, 384);
            label2.Margin = new System.Windows.Forms.Padding(6);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(59, 17);
            label2.TabIndex = 744;
            label2.Text = "Member:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxNotes
            // 
            textBoxNotes.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPGlobal.SetColumnSpan(textBoxNotes, 2);
            textBoxNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            textBoxNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxNotes.ForeColor = System.Drawing.Color.Gray;
            textBoxNotes.IsRequiredModeOn = false;
            textBoxNotes.Location = new System.Drawing.Point(7, 421);
            textBoxNotes.Margin = new System.Windows.Forms.Padding(7, 3, 6, 3);
            textBoxNotes.Multiline = true;
            textBoxNotes.Name = "textBoxNotes";
            textBoxNotes.PlaceholderText = "Note";
            textBoxNotes.Size = new System.Drawing.Size(434, 58);
            textBoxNotes.TabIndex = 77;
            textBoxNotes.Text = "Note";
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonDelete.BackAndMouseHoverColor = System.Drawing.Color.Red;
            buttonDelete.BackColor = System.Drawing.Color.Red;
            buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(215, 0, 0);
            buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 20, 20);
            buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonDelete.ForeColor = System.Drawing.Color.White;
            buttonDelete.Location = new System.Drawing.Point(3, 499);
            buttonDelete.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new System.Drawing.Size(95, 29);
            buttonDelete.TabIndex = 743;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // labelDifferenceTime
            // 
            labelDifferenceTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelDifferenceTime.BackColor = System.Drawing.Color.White;
            labelDifferenceTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelDifferenceTime.Location = new System.Drawing.Point(280, 332);
            labelDifferenceTime.Margin = new System.Windows.Forms.Padding(6);
            labelDifferenceTime.Name = "labelDifferenceTime";
            labelDifferenceTime.Size = new System.Drawing.Size(161, 21);
            labelDifferenceTime.TabIndex = 2;
            labelDifferenceTime.Text = "1:00:00";
            labelDifferenceTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            flowLayoutPanel2.Controls.Add(textBoxEndTime);
            flowLayoutPanel2.Controls.Add(DownArrowEndTime);
            flowLayoutPanel2.Location = new System.Drawing.Point(279, 282);
            flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(6);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(162, 21);
            flowLayoutPanel2.TabIndex = 12;
            flowLayoutPanel2.Click += textBoxEndTime_Click;
            // 
            // textBoxEndTime
            // 
            textBoxEndTime.BackColor = System.Drawing.Color.White;
            textBoxEndTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBoxEndTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxEndTime.Location = new System.Drawing.Point(2, 2);
            textBoxEndTime.Margin = new System.Windows.Forms.Padding(2);
            textBoxEndTime.Name = "textBoxEndTime";
            textBoxEndTime.Size = new System.Drawing.Size(130, 18);
            textBoxEndTime.TabIndex = 10;
            textBoxEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBoxEndTime.Click += textBoxEndTime_Click;
            textBoxEndTime.TextChanged += textBoxEndTime_TextChanged;
            // 
            // DownArrowEndTime
            // 
            DownArrowEndTime.BackColor = System.Drawing.Color.White;
            DownArrowEndTime.BackgroundImage = (System.Drawing.Image)resources.GetObject("DownArrowEndTime.BackgroundImage");
            DownArrowEndTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            DownArrowEndTime.Cursor = System.Windows.Forms.Cursors.Hand;
            DownArrowEndTime.Image = (System.Drawing.Image)resources.GetObject("DownArrowEndTime.Image");
            DownArrowEndTime.Location = new System.Drawing.Point(134, 0);
            DownArrowEndTime.Margin = new System.Windows.Forms.Padding(0);
            DownArrowEndTime.Name = "DownArrowEndTime";
            DownArrowEndTime.Size = new System.Drawing.Size(27, 23);
            DownArrowEndTime.TabIndex = 62;
            DownArrowEndTime.TabStop = false;
            DownArrowEndTime.Click += textBoxEndTime_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            flowLayoutPanel1.Controls.Add(textBoxStartTime);
            flowLayoutPanel1.Controls.Add(DownArrowStartTime);
            flowLayoutPanel1.Location = new System.Drawing.Point(279, 232);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(162, 21);
            flowLayoutPanel1.TabIndex = 11;
            flowLayoutPanel1.Click += textBoxStartTime_Click;
            // 
            // textBoxStartTime
            // 
            textBoxStartTime.BackColor = System.Drawing.Color.White;
            textBoxStartTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBoxStartTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxStartTime.Location = new System.Drawing.Point(2, 2);
            textBoxStartTime.Margin = new System.Windows.Forms.Padding(2);
            textBoxStartTime.Name = "textBoxStartTime";
            textBoxStartTime.Size = new System.Drawing.Size(130, 18);
            textBoxStartTime.TabIndex = 10;
            textBoxStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBoxStartTime.Click += textBoxStartTime_Click;
            textBoxStartTime.TextChanged += textBoxStartTime_TextChanged;
            // 
            // DownArrowStartTime
            // 
            DownArrowStartTime.BackColor = System.Drawing.Color.White;
            DownArrowStartTime.BackgroundImage = (System.Drawing.Image)resources.GetObject("DownArrowStartTime.BackgroundImage");
            DownArrowStartTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            DownArrowStartTime.Cursor = System.Windows.Forms.Cursors.Hand;
            DownArrowStartTime.Image = (System.Drawing.Image)resources.GetObject("DownArrowStartTime.Image");
            DownArrowStartTime.Location = new System.Drawing.Point(134, 0);
            DownArrowStartTime.Margin = new System.Windows.Forms.Padding(0);
            DownArrowStartTime.Name = "DownArrowStartTime";
            DownArrowStartTime.Size = new System.Drawing.Size(27, 24);
            DownArrowStartTime.TabIndex = 62;
            DownArrowStartTime.TabStop = false;
            DownArrowStartTime.Click += textBoxStartTime_Click;
            // 
            // labelStartTime
            // 
            labelStartTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelStartTime.AutoSize = true;
            labelStartTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            labelStartTime.Location = new System.Drawing.Point(6, 234);
            labelStartTime.Margin = new System.Windows.Forms.Padding(6);
            labelStartTime.Name = "labelStartTime";
            labelStartTime.Size = new System.Drawing.Size(73, 17);
            labelStartTime.TabIndex = 0;
            labelStartTime.Text = "Start Time:";
            labelStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEndTime
            // 
            labelEndTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelEndTime.AutoSize = true;
            labelEndTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            labelEndTime.Location = new System.Drawing.Point(6, 284);
            labelEndTime.Margin = new System.Windows.Forms.Padding(6);
            labelEndTime.Name = "labelEndTime";
            labelEndTime.Size = new System.Drawing.Size(66, 17);
            labelEndTime.TabIndex = 0;
            labelEndTime.Text = "End Time:";
            labelEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel3.Controls.Add(ButtonAddOrUpdate);
            flowLayoutPanel3.Controls.Add(buttonCompleted);
            flowLayoutPanel3.Controls.Add(buttonCanceled);
            flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel3.Location = new System.Drawing.Point(139, 497);
            flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new System.Drawing.Size(308, 36);
            flowLayoutPanel3.TabIndex = 76;
            // 
            // ButtonAddOrUpdate
            // 
            ButtonAddOrUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            ButtonAddOrUpdate.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(109, 122, 224);
            ButtonAddOrUpdate.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            ButtonAddOrUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            ButtonAddOrUpdate.FlatAppearance.BorderSize = 0;
            ButtonAddOrUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(69, 82, 184);
            ButtonAddOrUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 142, 244);
            ButtonAddOrUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ButtonAddOrUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ButtonAddOrUpdate.ForeColor = System.Drawing.Color.White;
            ButtonAddOrUpdate.Location = new System.Drawing.Point(210, 3);
            ButtonAddOrUpdate.Name = "ButtonAddOrUpdate";
            ButtonAddOrUpdate.Size = new System.Drawing.Size(95, 29);
            ButtonAddOrUpdate.TabIndex = 0;
            ButtonAddOrUpdate.Text = "Update";
            ButtonAddOrUpdate.UseVisualStyleBackColor = false;
            ButtonAddOrUpdate.Click += ButtonAddOrUpdate_Click;
            // 
            // buttonCompleted
            // 
            buttonCompleted.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonCompleted.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonCompleted.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonCompleted.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonCompleted.FlatAppearance.BorderSize = 0;
            buttonCompleted.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(69, 82, 184);
            buttonCompleted.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 142, 244);
            buttonCompleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCompleted.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCompleted.ForeColor = System.Drawing.Color.White;
            buttonCompleted.Location = new System.Drawing.Point(109, 3);
            buttonCompleted.Name = "buttonCompleted";
            buttonCompleted.Size = new System.Drawing.Size(95, 29);
            buttonCompleted.TabIndex = 741;
            buttonCompleted.Text = "Completed";
            buttonCompleted.UseVisualStyleBackColor = false;
            buttonCompleted.Click += buttonCompleted_Click;
            // 
            // buttonCanceled
            // 
            buttonCanceled.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonCanceled.BackAndMouseHoverColor = System.Drawing.Color.Red;
            buttonCanceled.BackColor = System.Drawing.Color.Red;
            buttonCanceled.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonCanceled.FlatAppearance.BorderSize = 0;
            buttonCanceled.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(215, 0, 0);
            buttonCanceled.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 20, 20);
            buttonCanceled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCanceled.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCanceled.ForeColor = System.Drawing.Color.White;
            buttonCanceled.Location = new System.Drawing.Point(8, 3);
            buttonCanceled.Name = "buttonCanceled";
            buttonCanceled.Size = new System.Drawing.Size(95, 29);
            buttonCanceled.TabIndex = 742;
            buttonCanceled.Text = "Canceled";
            buttonCanceled.UseVisualStyleBackColor = false;
            buttonCanceled.Click += buttonCanceled_Click;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(6, 334);
            label1.Margin = new System.Windows.Forms.Padding(6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 17);
            label1.TabIndex = 1;
            label1.Text = "Duration:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // Appointment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            ClientSize = new System.Drawing.Size(447, 537);
            Controls.Add(TLPGlobal);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Appointment";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Appointment";
            FormClosed += Appointment_FormClosed;
            TLPGlobal.ResumeLayout(false);
            TLPGlobal.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrowEndTime).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrowStartTime).EndInit();
            flowLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        private System.Windows.Forms.Label labelEndTime;
        public System.Windows.Forms.TextBox textBoxStartTime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox DownArrowStartTime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public System.Windows.Forms.TextBox textBoxEndTime;
        private System.Windows.Forms.PictureBox DownArrowEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDifferenceTime;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        public CustomizedTools.TextBoxWithPlaceHolder textBoxNotes;
        public CustomizedTools.CustomButton ButtonAddOrUpdate;
        public CustomizedTools.CustomButton buttonDelete;
        public CustomizedTools.CustomButton buttonCompleted;
        public CustomizedTools.CustomButton buttonCanceled;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelEmployee;
    }
}