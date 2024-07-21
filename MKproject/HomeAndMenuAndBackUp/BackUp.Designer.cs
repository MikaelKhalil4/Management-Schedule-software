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
            ButtonOnlineBackUp = new CustomizedTools.CustomButton();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            checkBoxBackUp = new System.Windows.Forms.CheckBox();
            labelBackUpTime = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // ButtonOnlineBackUp
            // 
            ButtonOnlineBackUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            ButtonOnlineBackUp.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(128, 128, 255);
            ButtonOnlineBackUp.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            ButtonOnlineBackUp.FlatAppearance.BorderSize = 0;
            ButtonOnlineBackUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(88, 88, 215);
            ButtonOnlineBackUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(108, 108, 235);
            ButtonOnlineBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ButtonOnlineBackUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ButtonOnlineBackUp.ForeColor = System.Drawing.Color.White;
            ButtonOnlineBackUp.Location = new System.Drawing.Point(128, 117);
            ButtonOnlineBackUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ButtonOnlineBackUp.Name = "ButtonOnlineBackUp";
            ButtonOnlineBackUp.Size = new System.Drawing.Size(160, 127);
            ButtonOnlineBackUp.TabIndex = 0;
            ButtonOnlineBackUp.Text = "Online BackUp Manually";
            ButtonOnlineBackUp.UseVisualStyleBackColor = false;
            ButtonOnlineBackUp.Click += ButtonOnlineBackUp_Click;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 0);
            progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(463, 3);
            progressBar1.TabIndex = 1;
            // 
            // checkBoxBackUp
            // 
            checkBoxBackUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            checkBoxBackUp.AutoSize = true;
            checkBoxBackUp.Checked = true;
            checkBoxBackUp.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxBackUp.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxBackUp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxBackUp.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            checkBoxBackUp.Location = new System.Drawing.Point(122, 68);
            checkBoxBackUp.Margin = new System.Windows.Forms.Padding(11, 4, 3, 4);
            checkBoxBackUp.Name = "checkBoxBackUp";
            checkBoxBackUp.Size = new System.Drawing.Size(173, 27);
            checkBoxBackUp.TabIndex = 2;
            checkBoxBackUp.Text = "Auto Backup Daily";
            checkBoxBackUp.UseVisualStyleBackColor = false;
            checkBoxBackUp.CheckedChanged += checkBoxBackUp_CheckedChanged;
            // 
            // labelBackUpTime
            // 
            labelBackUpTime.AutoSize = true;
            labelBackUpTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelBackUpTime.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            labelBackUpTime.Location = new System.Drawing.Point(85, 7);
            labelBackUpTime.Name = "labelBackUpTime";
            labelBackUpTime.Size = new System.Drawing.Size(273, 23);
            labelBackUpTime.TabIndex = 3;
            labelBackUpTime.Text = "Last BackUp Time is Today at 6:04 ";
            // 
            // BackUp
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(463, 257);
            Controls.Add(labelBackUpTime);
            Controls.Add(checkBoxBackUp);
            Controls.Add(progressBar1);
            Controls.Add(ButtonOnlineBackUp);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BackUp";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "BackUp";
            Deactivate += BackUp_Deactivate;
            FormClosing += BackUp_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CustomizedTools.CustomButton ButtonOnlineBackUp;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.CheckBox checkBoxBackUp;
        private System.Windows.Forms.Label labelBackUpTime;
    }
}