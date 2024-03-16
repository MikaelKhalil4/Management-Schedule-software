namespace MKproject.Schedule
{
    partial class UCDays
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
            labelDay = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // labelDay
            // 
            labelDay.BackColor = System.Drawing.Color.Transparent;
            labelDay.Dock = System.Windows.Forms.DockStyle.Fill;
            labelDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelDay.ForeColor = System.Drawing.Color.FromArgb(119, 132, 234);
            labelDay.Location = new System.Drawing.Point(0, 0);
            labelDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelDay.Name = "labelDay";
            labelDay.Size = new System.Drawing.Size(169, 114);
            labelDay.TabIndex = 3;
            labelDay.Text = "00";
            labelDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelDay.Click += UCDays_Click;
            labelDay.MouseEnter += labelDays_MouseEnter;
            labelDay.MouseLeave += labelDays_MouseLeave;
            // 
            // UCDays
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            Controls.Add(labelDay);
            DoubleBuffered = true;
            Margin = new System.Windows.Forms.Padding(0);
            Name = "UCDays";
            Size = new System.Drawing.Size(169, 114);
            Click += UCDays_Click;
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.Label labelDay;
    }
}
