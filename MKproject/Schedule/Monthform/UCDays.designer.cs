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
            this.labelDay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDay
            // 
            this.labelDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(132)))), ((int)(((byte)(234)))));
            this.labelDay.Location = new System.Drawing.Point(0, 0);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(145, 99);
            this.labelDay.TabIndex = 3;
            this.labelDay.Text = "00";
            this.labelDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDay.Click += new System.EventHandler(this.UCDays_Click);
            this.labelDay.MouseEnter += new System.EventHandler(this.labelDays_MouseEnter);
            this.labelDay.MouseLeave += new System.EventHandler(this.labelDays_MouseLeave);
            // 
            // UCDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDay);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCDays";
            this.Size = new System.Drawing.Size(145, 99);
            this.Click += new System.EventHandler(this.UCDays_Click);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label labelDay;
    }
}
