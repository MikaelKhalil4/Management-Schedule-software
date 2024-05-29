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
            TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            labelEmployeeOutput = new System.Windows.Forms.Label();
            labelStartTimeOutput = new System.Windows.Forms.Label();
            labelEndTimeOutput = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            ButtonAddOrUpdate = new CustomizedTools.CustomButton();
            buttonCompleted = new CustomizedTools.CustomButton();
            buttonCanceled = new CustomizedTools.CustomButton();
            LabelDuration = new System.Windows.Forms.Label();
            buttonDelete = new CustomizedTools.CustomButton();
            textBoxStartTime = new System.Windows.Forms.TextBox();
            textBoxEndTime = new System.Windows.Forms.TextBox();
            comboBoxEmployee = new System.Windows.Forms.ComboBox();
            timer1 = new System.Windows.Forms.Timer(components);
            TLPGlobal.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // TLPGlobal
            // 
            TLPGlobal.ColumnCount = 2;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.000008F));
            TLPGlobal.Controls.Add(labelEmployeeOutput, 0, 4);
            TLPGlobal.Controls.Add(labelStartTimeOutput, 0, 1);
            TLPGlobal.Controls.Add(labelEndTimeOutput, 0, 2);
            TLPGlobal.Controls.Add(label1, 0, 3);
            TLPGlobal.Controls.Add(flowLayoutPanel3, 1, 6);
            TLPGlobal.Controls.Add(LabelDuration, 1, 3);
            TLPGlobal.Controls.Add(buttonDelete, 0, 6);
            TLPGlobal.Controls.Add(textBoxStartTime, 1, 1);
            TLPGlobal.Controls.Add(textBoxEndTime, 1, 2);
            TLPGlobal.Controls.Add(comboBoxEmployee, 1, 4);
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
            TLPGlobal.Size = new System.Drawing.Size(415, 536);
            TLPGlobal.TabIndex = 70;
            // 
            // labelEmployeeOutput
            // 
            labelEmployeeOutput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelEmployeeOutput.AutoSize = true;
            labelEmployeeOutput.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            labelEmployeeOutput.Location = new System.Drawing.Point(6, 386);
            labelEmployeeOutput.Margin = new System.Windows.Forms.Padding(6);
            labelEmployeeOutput.Name = "labelEmployeeOutput";
            labelEmployeeOutput.Size = new System.Drawing.Size(59, 17);
            labelEmployeeOutput.TabIndex = 744;
            labelEmployeeOutput.Text = "Member:";
            labelEmployeeOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel3.Controls.Add(ButtonAddOrUpdate);
            flowLayoutPanel3.Controls.Add(buttonCompleted);
            flowLayoutPanel3.Controls.Add(buttonCanceled);
            flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel3.Location = new System.Drawing.Point(106, 495);
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
            buttonCompleted.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(89, 102, 204);
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
            buttonCanceled.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 0, 0);
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
            LabelDuration.Location = new System.Drawing.Point(354, 333);
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
            // textBoxStartTime
            // 
            textBoxStartTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            textBoxStartTime.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            textBoxStartTime.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxStartTime.Location = new System.Drawing.Point(291, 230);
            textBoxStartTime.Margin = new System.Windows.Forms.Padding(6);
            textBoxStartTime.Name = "textBoxStartTime";
            textBoxStartTime.Size = new System.Drawing.Size(118, 26);
            textBoxStartTime.TabIndex = 10;
            textBoxStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBoxStartTime.Click += textBoxStartTime_Click;
            textBoxStartTime.TextChanged += textBoxStartTime_TextChanged;
            // 
            // textBoxEndTime
            // 
            textBoxEndTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            textBoxEndTime.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            textBoxEndTime.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxEndTime.Location = new System.Drawing.Point(291, 280);
            textBoxEndTime.Margin = new System.Windows.Forms.Padding(6);
            textBoxEndTime.Name = "textBoxEndTime";
            textBoxEndTime.Size = new System.Drawing.Size(118, 26);
            textBoxEndTime.TabIndex = 10;
            textBoxEndTime.Text = "`";
            textBoxEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBoxEndTime.Click += textBoxEndTime_Click;
            textBoxEndTime.TextChanged += textBoxEndTime_TextChanged;
            // 
            // comboBoxEmployee
            // 
            comboBoxEmployee.Anchor = System.Windows.Forms.AnchorStyles.Right;
            comboBoxEmployee.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            comboBoxEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            comboBoxEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            comboBoxEmployee.FormattingEnabled = true;
            comboBoxEmployee.Location = new System.Drawing.Point(288, 381);
            comboBoxEmployee.Margin = new System.Windows.Forms.Padding(6);
            comboBoxEmployee.Name = "comboBoxEmployee";
            comboBoxEmployee.Size = new System.Drawing.Size(121, 28);
            comboBoxEmployee.TabIndex = 749;
            comboBoxEmployee.SelectedIndexChanged += comboBoxEmployee_SelectedIndexChanged;
            comboBoxEmployee.DropDownClosed += comboBoxEmployee_SelectedIndexChanged;
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
            ClientSize = new System.Drawing.Size(415, 536);
            Controls.Add(TLPGlobal);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Appointment";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Appointment";
            Deactivate += Appointment_Deactivate;
            FormClosing += Appointment_FormClosing;
            FormClosed += Appointment_FormClosed;
            VisibleChanged += Appointment_VisibleChanged;
            TLPGlobal.ResumeLayout(false);
            TLPGlobal.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        private System.Windows.Forms.Label labelEndTimeOutput;
        public System.Windows.Forms.TextBox textBoxStartTime;
        public System.Windows.Forms.TextBox textBoxEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStartTimeOutput;
        public CustomizedTools.CustomButton ButtonAddOrUpdate;
        public CustomizedTools.CustomButton buttonDelete;
        public CustomizedTools.CustomButton buttonCompleted;
        public CustomizedTools.CustomButton buttonCanceled;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelEmployeeOutput;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label LabelDuration;
        private System.Windows.Forms.ComboBox comboBoxEmployee;
    }
}