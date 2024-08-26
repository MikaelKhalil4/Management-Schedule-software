namespace MKproject
{
    partial class PlanAndBackUp
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
            progressBar1 = new System.Windows.Forms.ProgressBar();
            checkBoxBackUp = new System.Windows.Forms.CheckBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            customButtonBackUpOffiline = new CustomizedTools.CustomButton();
            label3 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            labelDueDatePlan = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            labelBackUpTimeReadOnly = new System.Windows.Forms.Label();
            ButtonOnlineBackUp = new CustomizedTools.CustomButton();
            labelbackUpTime = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 0);
            progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(525, 3);
            progressBar1.TabIndex = 1;
            // 
            // checkBoxBackUp
            // 
            checkBoxBackUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            checkBoxBackUp.AutoSize = true;
            checkBoxBackUp.Checked = true;
            checkBoxBackUp.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxBackUp.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxBackUp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxBackUp.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            checkBoxBackUp.Location = new System.Drawing.Point(450, 63);
            checkBoxBackUp.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            checkBoxBackUp.Name = "checkBoxBackUp";
            checkBoxBackUp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            checkBoxBackUp.Size = new System.Drawing.Size(55, 27);
            checkBoxBackUp.TabIndex = 2;
            checkBoxBackUp.Text = "On";
            checkBoxBackUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            checkBoxBackUp.UseVisualStyleBackColor = false;
            checkBoxBackUp.CheckedChanged += checkBoxBackUp_CheckedChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.6666679F));
            tableLayoutPanel1.Controls.Add(customButtonBackUpOffiline, 1, 7);
            tableLayoutPanel1.Controls.Add(label3, 0, 7);
            tableLayoutPanel1.Controls.Add(panel3, 0, 6);
            tableLayoutPanel1.Controls.Add(labelDueDatePlan, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(checkBoxBackUp, 1, 2);
            tableLayoutPanel1.Controls.Add(labelBackUpTimeReadOnly, 0, 4);
            tableLayoutPanel1.Controls.Add(ButtonOnlineBackUp, 1, 4);
            tableLayoutPanel1.Controls.Add(labelbackUpTime, 0, 5);
            tableLayoutPanel1.Controls.Add(panel1, 0, 3);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            tableLayoutPanel1.Size = new System.Drawing.Size(525, 258);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // customButtonBackUpOffiline
            // 
            customButtonBackUpOffiline.Anchor = System.Windows.Forms.AnchorStyles.Right;
            customButtonBackUpOffiline.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(128, 128, 255);
            customButtonBackUpOffiline.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            customButtonBackUpOffiline.FlatAppearance.BorderSize = 0;
            customButtonBackUpOffiline.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(88, 88, 215);
            customButtonBackUpOffiline.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(108, 108, 235);
            customButtonBackUpOffiline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            customButtonBackUpOffiline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            customButtonBackUpOffiline.ForeColor = System.Drawing.Color.White;
            customButtonBackUpOffiline.Location = new System.Drawing.Point(345, 203);
            customButtonBackUpOffiline.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            customButtonBackUpOffiline.Name = "customButtonBackUpOffiline";
            customButtonBackUpOffiline.Size = new System.Drawing.Size(160, 37);
            customButtonBackUpOffiline.TabIndex = 12;
            customButtonBackUpOffiline.Text = "BackUp Offline Now";
            customButtonBackUpOffiline.UseVisualStyleBackColor = false;
            customButtonBackUpOffiline.Click += customButtonBackUpOffiline_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.FromArgb(74, 74, 74);
            label3.Location = new System.Drawing.Point(3, 186);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(295, 72);
            label3.TabIndex = 11;
            label3.Text = "Backup Offline";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.Gainsboro;
            tableLayoutPanel1.SetColumnSpan(panel3, 2);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(3, 181);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(519, 2);
            panel3.TabIndex = 10;
            // 
            // labelDueDatePlan
            // 
            labelDueDatePlan.AutoSize = true;
            labelDueDatePlan.Dock = System.Windows.Forms.DockStyle.Fill;
            labelDueDatePlan.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelDueDatePlan.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
            labelDueDatePlan.Location = new System.Drawing.Point(304, 0);
            labelDueDatePlan.Name = "labelDueDatePlan";
            labelDueDatePlan.Size = new System.Drawing.Size(218, 46);
            labelDueDatePlan.TabIndex = 9;
            labelDueDatePlan.Text = "monday 7,17,2024\r\n(17 days left)";
            labelDueDatePlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.FromArgb(74, 74, 74);
            label2.Location = new System.Drawing.Point(3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(295, 46);
            label2.TabIndex = 8;
            label2.Text = "DueDate Plan";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.Gainsboro;
            tableLayoutPanel1.SetColumnSpan(panel2, 2);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(3, 49);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(519, 2);
            panel2.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.FromArgb(74, 74, 74);
            label1.Location = new System.Drawing.Point(3, 54);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(295, 46);
            label1.TabIndex = 5;
            label1.Text = "Automated Online BackUp Daily";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBackUpTimeReadOnly
            // 
            labelBackUpTimeReadOnly.AutoSize = true;
            labelBackUpTimeReadOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            labelBackUpTimeReadOnly.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelBackUpTimeReadOnly.ForeColor = System.Drawing.Color.FromArgb(74, 74, 74);
            labelBackUpTimeReadOnly.Location = new System.Drawing.Point(3, 108);
            labelBackUpTimeReadOnly.Name = "labelBackUpTimeReadOnly";
            labelBackUpTimeReadOnly.Size = new System.Drawing.Size(295, 35);
            labelBackUpTimeReadOnly.TabIndex = 3;
            labelBackUpTimeReadOnly.Text = "Last Successfull Online BackUp Time:";
            labelBackUpTimeReadOnly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonOnlineBackUp
            // 
            ButtonOnlineBackUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            ButtonOnlineBackUp.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(128, 128, 255);
            ButtonOnlineBackUp.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            ButtonOnlineBackUp.FlatAppearance.BorderSize = 0;
            ButtonOnlineBackUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(88, 88, 215);
            ButtonOnlineBackUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(108, 108, 235);
            ButtonOnlineBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ButtonOnlineBackUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ButtonOnlineBackUp.ForeColor = System.Drawing.Color.White;
            ButtonOnlineBackUp.Location = new System.Drawing.Point(345, 124);
            ButtonOnlineBackUp.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            ButtonOnlineBackUp.Name = "ButtonOnlineBackUp";
            tableLayoutPanel1.SetRowSpan(ButtonOnlineBackUp, 2);
            ButtonOnlineBackUp.Size = new System.Drawing.Size(160, 37);
            ButtonOnlineBackUp.TabIndex = 0;
            ButtonOnlineBackUp.Text = "BackUp Online Now";
            ButtonOnlineBackUp.UseVisualStyleBackColor = false;
            ButtonOnlineBackUp.Click += ButtonOnlineBackUp_Click;
            // 
            // labelbackUpTime
            // 
            labelbackUpTime.AutoSize = true;
            labelbackUpTime.Dock = System.Windows.Forms.DockStyle.Fill;
            labelbackUpTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelbackUpTime.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
            labelbackUpTime.Location = new System.Drawing.Point(3, 143);
            labelbackUpTime.Name = "labelbackUpTime";
            labelbackUpTime.Size = new System.Drawing.Size(295, 35);
            labelbackUpTime.TabIndex = 4;
            labelbackUpTime.Text = "monday 7,17,2024";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Gainsboro;
            tableLayoutPanel1.SetColumnSpan(panel1, 2);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 103);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(519, 2);
            panel1.TabIndex = 6;
            // 
            // PlanAndBackUp
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(525, 261);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(progressBar1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PlanAndBackUp";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Deactivate += BackUp_Deactivate;
            FormClosing += BackUp_FormClosing;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.CheckBox checkBoxBackUp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelBackUpTimeReadOnly;
        private CustomizedTools.CustomButton ButtonOnlineBackUp;
        private System.Windows.Forms.Label labelbackUpTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDueDatePlan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private CustomizedTools.CustomButton customButtonBackUpOffiline;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
    }
}