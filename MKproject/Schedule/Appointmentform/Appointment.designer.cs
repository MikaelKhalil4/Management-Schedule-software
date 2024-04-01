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
            FLPEndTime = new System.Windows.Forms.FlowLayoutPanel();
            textBoxEndTime = new System.Windows.Forms.TextBox();
            DownArrowEndTime = new System.Windows.Forms.PictureBox();
            FLPStartTime = new System.Windows.Forms.FlowLayoutPanel();
            textBoxStartTime = new System.Windows.Forms.TextBox();
            DownArrowStartTime = new System.Windows.Forms.PictureBox();
            labelStartTimeOutput = new System.Windows.Forms.Label();
            labelEndTimeOutput = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            ButtonAddOrUpdate = new CustomizedTools.CustomButton();
            buttonCompleted = new CustomizedTools.CustomButton();
            buttonCanceled = new CustomizedTools.CustomButton();
            LabelDuration = new System.Windows.Forms.Label();
            buttonDelete = new CustomizedTools.CustomButton();
            timer1 = new System.Windows.Forms.Timer(components);
            TLPGlobal.SuspendLayout();
            FLPEndTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrowEndTime).BeginInit();
            FLPStartTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrowStartTime).BeginInit();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // TLPGlobal
            // 
            TLPGlobal.ColumnCount = 2;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.000008F));
            TLPGlobal.Controls.Add(labelEmployee, 1, 4);
            TLPGlobal.Controls.Add(label2, 0, 4);
            TLPGlobal.Controls.Add(FLPEndTime, 1, 2);
            TLPGlobal.Controls.Add(FLPStartTime, 1, 1);
            TLPGlobal.Controls.Add(labelStartTimeOutput, 0, 1);
            TLPGlobal.Controls.Add(labelEndTimeOutput, 0, 2);
            TLPGlobal.Controls.Add(label1, 0, 3);
            TLPGlobal.Controls.Add(flowLayoutPanel3, 1, 6);
            TLPGlobal.Controls.Add(LabelDuration, 1, 3);
            TLPGlobal.Controls.Add(buttonDelete, 0, 6);
            TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 0);
            TLPGlobal.Margin = new System.Windows.Forms.Padding(0);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 7;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 218F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            TLPGlobal.Size = new System.Drawing.Size(447, 536);
            TLPGlobal.TabIndex = 70;
            // 
            // labelEmployee
            // 
            labelEmployee.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelEmployee.AutoSize = true;
            labelEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelEmployee.Location = new System.Drawing.Point(323, 385);
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
            label2.Location = new System.Drawing.Point(6, 386);
            label2.Margin = new System.Windows.Forms.Padding(6);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(59, 17);
            label2.TabIndex = 744;
            label2.Text = "Member:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FLPEndTime
            // 
            FLPEndTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            FLPEndTime.BackColor = System.Drawing.Color.White;
            FLPEndTime.Controls.Add(textBoxEndTime);
            FLPEndTime.Controls.Add(DownArrowEndTime);
            FLPEndTime.Location = new System.Drawing.Point(279, 282);
            FLPEndTime.Margin = new System.Windows.Forms.Padding(6);
            FLPEndTime.Name = "FLPEndTime";
            FLPEndTime.Size = new System.Drawing.Size(162, 21);
            FLPEndTime.TabIndex = 12;
            FLPEndTime.Click += textBoxEndTime_Click;
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
            textBoxEndTime.Text = "`";
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
            // FLPStartTime
            // 
            FLPStartTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            FLPStartTime.BackColor = System.Drawing.Color.White;
            FLPStartTime.Controls.Add(textBoxStartTime);
            FLPStartTime.Controls.Add(DownArrowStartTime);
            FLPStartTime.Location = new System.Drawing.Point(279, 232);
            FLPStartTime.Margin = new System.Windows.Forms.Padding(6);
            FLPStartTime.Name = "FLPStartTime";
            FLPStartTime.Size = new System.Drawing.Size(162, 21);
            FLPStartTime.TabIndex = 11;
            FLPStartTime.Click += textBoxStartTime_Click;
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
            // labelStartTimeOutput
            // 
            labelStartTimeOutput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelStartTimeOutput.AutoSize = true;
            labelStartTimeOutput.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            labelStartTimeOutput.Location = new System.Drawing.Point(6, 234);
            labelStartTimeOutput.Margin = new System.Windows.Forms.Padding(6);
            labelStartTimeOutput.Name = "labelStartTimeOutput";
            labelStartTimeOutput.Size = new System.Drawing.Size(73, 17);
            labelStartTimeOutput.TabIndex = 0;
            labelStartTimeOutput.Text = "Start Time:";
            labelStartTimeOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEndTimeOutput
            // 
            labelEndTimeOutput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelEndTimeOutput.AutoSize = true;
            labelEndTimeOutput.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            labelEndTimeOutput.Location = new System.Drawing.Point(6, 284);
            labelEndTimeOutput.Margin = new System.Windows.Forms.Padding(6);
            labelEndTimeOutput.Name = "labelEndTimeOutput";
            labelEndTimeOutput.Size = new System.Drawing.Size(66, 17);
            labelEndTimeOutput.TabIndex = 0;
            labelEndTimeOutput.Text = "End Time:";
            labelEndTimeOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            flowLayoutPanel3.Controls.Add(ButtonAddOrUpdate);
            flowLayoutPanel3.Controls.Add(buttonCompleted);
            flowLayoutPanel3.Controls.Add(buttonCanceled);
            flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel3.Location = new System.Drawing.Point(136, 495);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new System.Drawing.Size(306, 34);
            flowLayoutPanel3.TabIndex = 747;
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
            ButtonAddOrUpdate.Location = new System.Drawing.Point(208, 3);
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
            buttonCompleted.Location = new System.Drawing.Point(107, 3);
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
            buttonCanceled.Location = new System.Drawing.Point(6, 3);
            buttonCanceled.Name = "buttonCanceled";
            buttonCanceled.Size = new System.Drawing.Size(95, 29);
            buttonCanceled.TabIndex = 742;
            buttonCanceled.Text = "Canceled";
            buttonCanceled.UseVisualStyleBackColor = false;
            buttonCanceled.Click += buttonCanceled_Click;
            // 
            // LabelDuration
            // 
            LabelDuration.Anchor = System.Windows.Forms.AnchorStyles.Right;
            LabelDuration.AutoSize = true;
            LabelDuration.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LabelDuration.Location = new System.Drawing.Point(386, 333);
            LabelDuration.Margin = new System.Windows.Forms.Padding(6);
            LabelDuration.Name = "LabelDuration";
            LabelDuration.Size = new System.Drawing.Size(55, 20);
            LabelDuration.TabIndex = 748;
            LabelDuration.Text = "1:00:00";
            LabelDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            buttonDelete.BackAndMouseHoverColor = System.Drawing.Color.Red;
            buttonDelete.BackColor = System.Drawing.Color.Red;
            buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(215, 0, 0);
            buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 20, 20);
            buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonDelete.ForeColor = System.Drawing.Color.White;
            buttonDelete.Location = new System.Drawing.Point(3, 498);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new System.Drawing.Size(95, 28);
            buttonDelete.TabIndex = 743;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
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
            ClientSize = new System.Drawing.Size(447, 536);
            Controls.Add(TLPGlobal);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Appointment";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Appointment";
            Deactivate += Appointment_Deactivate;
            FormClosing += Appointment_FormClosing;
            FormClosed += Appointment_FormClosed;
            VisibleChanged += Appointment_VisibleChanged;
            TLPGlobal.ResumeLayout(false);
            TLPGlobal.PerformLayout();
            FLPEndTime.ResumeLayout(false);
            FLPEndTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrowEndTime).EndInit();
            FLPStartTime.ResumeLayout(false);
            FLPStartTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrowStartTime).EndInit();
            flowLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        private System.Windows.Forms.Label labelEndTimeOutput;
        public System.Windows.Forms.TextBox textBoxStartTime;
        private System.Windows.Forms.FlowLayoutPanel FLPStartTime;
        private System.Windows.Forms.PictureBox DownArrowStartTime;
        private System.Windows.Forms.FlowLayoutPanel FLPEndTime;
        public System.Windows.Forms.TextBox textBoxEndTime;
        private System.Windows.Forms.PictureBox DownArrowEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStartTimeOutput;
        public CustomizedTools.CustomButton ButtonAddOrUpdate;
        public CustomizedTools.CustomButton buttonDelete;
        public CustomizedTools.CustomButton buttonCompleted;
        public CustomizedTools.CustomButton buttonCanceled;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label LabelDuration;
    }
}