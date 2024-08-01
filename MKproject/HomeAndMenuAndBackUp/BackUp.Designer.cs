namespace MKproject
{
    partial class BackUp
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
            progressBar1.Size = new System.Drawing.Size(464, 3);
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
            checkBoxBackUp.Location = new System.Drawing.Point(389, 13);
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
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.36207F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.63793F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(checkBoxBackUp, 1, 0);
            tableLayoutPanel1.Controls.Add(labelBackUpTimeReadOnly, 0, 2);
            tableLayoutPanel1.Controls.Add(ButtonOnlineBackUp, 1, 2);
            tableLayoutPanel1.Controls.Add(labelbackUpTime, 0, 3);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            tableLayoutPanel1.Size = new System.Drawing.Size(464, 143);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.FromArgb(74, 74, 74);
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(288, 54);
            label1.TabIndex = 5;
            label1.Text = "Automated BackUp Daily";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBackUpTimeReadOnly
            // 
            labelBackUpTimeReadOnly.AutoSize = true;
            labelBackUpTimeReadOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            labelBackUpTimeReadOnly.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelBackUpTimeReadOnly.ForeColor = System.Drawing.Color.FromArgb(74, 74, 74);
            labelBackUpTimeReadOnly.Location = new System.Drawing.Point(3, 62);
            labelBackUpTimeReadOnly.Name = "labelBackUpTimeReadOnly";
            labelBackUpTimeReadOnly.Size = new System.Drawing.Size(288, 40);
            labelBackUpTimeReadOnly.TabIndex = 3;
            labelBackUpTimeReadOnly.Text = "Last Successfull BackUp Time:";
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
            ButtonOnlineBackUp.Location = new System.Drawing.Point(333, 84);
            ButtonOnlineBackUp.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            ButtonOnlineBackUp.Name = "ButtonOnlineBackUp";
            tableLayoutPanel1.SetRowSpan(ButtonOnlineBackUp, 2);
            ButtonOnlineBackUp.Size = new System.Drawing.Size(111, 37);
            ButtonOnlineBackUp.TabIndex = 0;
            ButtonOnlineBackUp.Text = "BackUp Now";
            ButtonOnlineBackUp.UseVisualStyleBackColor = false;
            ButtonOnlineBackUp.Click += ButtonOnlineBackUp_Click;
            // 
            // labelbackUpTime
            // 
            labelbackUpTime.AutoSize = true;
            labelbackUpTime.Dock = System.Windows.Forms.DockStyle.Fill;
            labelbackUpTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelbackUpTime.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
            labelbackUpTime.Location = new System.Drawing.Point(3, 102);
            labelbackUpTime.Name = "labelbackUpTime";
            labelbackUpTime.Size = new System.Drawing.Size(288, 41);
            labelbackUpTime.TabIndex = 4;
            labelbackUpTime.Text = "monday 7,17,2024";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Gainsboro;
            tableLayoutPanel1.SetColumnSpan(panel1, 2);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 57);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(458, 2);
            panel1.TabIndex = 6;
            // 
            // BackUp
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(464, 146);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(progressBar1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BackUp";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "BackUp";
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
    }
}