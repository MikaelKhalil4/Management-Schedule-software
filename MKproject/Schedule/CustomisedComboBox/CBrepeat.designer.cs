namespace MKproject.Schedule
{
    partial class CBrepeat
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelWeek = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.labelNoRepeat = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelWeek);
            this.panel1.Controls.Add(this.labelDay);
            this.panel1.Controls.Add(this.labelNoRepeat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 85);
            this.panel1.TabIndex = 0;
            // 
            // labelWeek
            // 
            this.labelWeek.BackColor = System.Drawing.Color.White;
            this.labelWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelWeek.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelWeek.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWeek.Location = new System.Drawing.Point(0, 56);
            this.labelWeek.Margin = new System.Windows.Forms.Padding(0);
            this.labelWeek.Name = "labelWeek";
            this.labelWeek.Size = new System.Drawing.Size(142, 28);
            this.labelWeek.TabIndex = 2;
            this.labelWeek.Text = "Every week";
            this.labelWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWeek.Click += new System.EventHandler(this.labelWeek_Click);
            this.labelWeek.MouseLeave += new System.EventHandler(this.labelNoRepeat_MouseLeave);
            this.labelWeek.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelNoRepeat_MouseMove);
            // 
            // labelDay
            // 
            this.labelDay.BackColor = System.Drawing.Color.White;
            this.labelDay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelDay.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDay.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDay.Location = new System.Drawing.Point(0, 28);
            this.labelDay.Margin = new System.Windows.Forms.Padding(0);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(142, 28);
            this.labelDay.TabIndex = 1;
            this.labelDay.Text = "Every day";
            this.labelDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDay.Click += new System.EventHandler(this.labelDay_Click);
            this.labelDay.MouseLeave += new System.EventHandler(this.labelNoRepeat_MouseLeave);
            this.labelDay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelNoRepeat_MouseMove);
            // 
            // labelNoRepeat
            // 
            this.labelNoRepeat.BackColor = System.Drawing.Color.White;
            this.labelNoRepeat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelNoRepeat.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNoRepeat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoRepeat.Location = new System.Drawing.Point(0, 0);
            this.labelNoRepeat.Margin = new System.Windows.Forms.Padding(0);
            this.labelNoRepeat.Name = "labelNoRepeat";
            this.labelNoRepeat.Size = new System.Drawing.Size(142, 28);
            this.labelNoRepeat.TabIndex = 0;
            this.labelNoRepeat.Text = "Does not repeat";
            this.labelNoRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelNoRepeat.Click += new System.EventHandler(this.labelNoRepeat_Click);
            this.labelNoRepeat.MouseLeave += new System.EventHandler(this.labelNoRepeat_MouseLeave);
            this.labelNoRepeat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelNoRepeat_MouseMove);
            // 
            // CBrepeat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(142, 85);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(142, 85);
            this.Name = "CBrepeat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.Repeat_Deactivate);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelWeek;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label labelNoRepeat;
    }
}
