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
            ButtonOfflineBackUp = new CustomizedTools.CustomButton();
            ButtonOnlineBackUp = new CustomizedTools.CustomButton();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            SuspendLayout();
            // 
            // ButtonOfflineBackUp
            // 
            ButtonOfflineBackUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            ButtonOfflineBackUp.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(128, 128, 255);
            ButtonOfflineBackUp.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            ButtonOfflineBackUp.FlatAppearance.BorderSize = 0;
            ButtonOfflineBackUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(88, 88, 215);
            ButtonOfflineBackUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(108, 108, 235);
            ButtonOfflineBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ButtonOfflineBackUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ButtonOfflineBackUp.ForeColor = System.Drawing.Color.White;
            ButtonOfflineBackUp.Location = new System.Drawing.Point(241, 49);
            ButtonOfflineBackUp.Name = "ButtonOfflineBackUp";
            ButtonOfflineBackUp.Size = new System.Drawing.Size(140, 95);
            ButtonOfflineBackUp.TabIndex = 0;
            ButtonOfflineBackUp.Text = "Offline BackUp";
            ButtonOfflineBackUp.UseVisualStyleBackColor = false;
            ButtonOfflineBackUp.Click += ButtonOfflineBackUp_Click;
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
            ButtonOnlineBackUp.Location = new System.Drawing.Point(42, 49);
            ButtonOnlineBackUp.Name = "ButtonOnlineBackUp";
            ButtonOnlineBackUp.Size = new System.Drawing.Size(140, 95);
            ButtonOnlineBackUp.TabIndex = 0;
            ButtonOnlineBackUp.Text = "Online BackUp";
            ButtonOnlineBackUp.UseVisualStyleBackColor = false;
            ButtonOnlineBackUp.Click += ButtonOnlineBackUp_Click;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 0);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(426, 2);
            progressBar1.TabIndex = 1;
            // 
            // BackUp
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(426, 213);
            Controls.Add(progressBar1);
            Controls.Add(ButtonOnlineBackUp);
            Controls.Add(ButtonOfflineBackUp);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BackUp";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "BackUp";
            Deactivate += BackUp_Deactivate;
            FormClosing += BackUp_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private CustomizedTools.CustomButton ButtonOfflineBackUp;
        private CustomizedTools.CustomButton ButtonOnlineBackUp;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}