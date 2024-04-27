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
            panel1 = new System.Windows.Forms.Panel();
            labelWeek = new System.Windows.Forms.Label();
            labelDay = new System.Windows.Forms.Label();
            labelNoRepeat = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(labelWeek);
            panel1.Controls.Add(labelDay);
            panel1.Controls.Add(labelNoRepeat);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(150, 104);
            panel1.TabIndex = 0;
            // 
            // labelWeek
            // 
            labelWeek.BackColor = System.Drawing.Color.White;
            labelWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            labelWeek.Dock = System.Windows.Forms.DockStyle.Top;
            labelWeek.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelWeek.Location = new System.Drawing.Point(0, 64);
            labelWeek.Margin = new System.Windows.Forms.Padding(0);
            labelWeek.Name = "labelWeek";
            labelWeek.Size = new System.Drawing.Size(150, 32);
            labelWeek.TabIndex = 2;
            labelWeek.Text = "Every week";
            labelWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelWeek.Click += labelWeek_Click;
            labelWeek.MouseLeave += labelNoRepeat_MouseLeave;
            labelWeek.MouseMove += labelNoRepeat_MouseMove;
            // 
            // labelDay
            // 
            labelDay.BackColor = System.Drawing.Color.White;
            labelDay.Cursor = System.Windows.Forms.Cursors.Hand;
            labelDay.Dock = System.Windows.Forms.DockStyle.Top;
            labelDay.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelDay.Location = new System.Drawing.Point(0, 32);
            labelDay.Margin = new System.Windows.Forms.Padding(0);
            labelDay.Name = "labelDay";
            labelDay.Size = new System.Drawing.Size(150, 32);
            labelDay.TabIndex = 1;
            labelDay.Text = "Every day";
            labelDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelDay.Click += labelDay_Click;
            labelDay.MouseLeave += labelNoRepeat_MouseLeave;
            labelDay.MouseMove += labelNoRepeat_MouseMove;
            // 
            // labelNoRepeat
            // 
            labelNoRepeat.BackColor = System.Drawing.Color.White;
            labelNoRepeat.Cursor = System.Windows.Forms.Cursors.Hand;
            labelNoRepeat.Dock = System.Windows.Forms.DockStyle.Top;
            labelNoRepeat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelNoRepeat.Location = new System.Drawing.Point(0, 0);
            labelNoRepeat.Margin = new System.Windows.Forms.Padding(0);
            labelNoRepeat.Name = "labelNoRepeat";
            labelNoRepeat.Size = new System.Drawing.Size(150, 32);
            labelNoRepeat.TabIndex = 0;
            labelNoRepeat.Text = "Does not repeat";
            labelNoRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelNoRepeat.Click += labelNoRepeat_Click;
            labelNoRepeat.MouseLeave += labelNoRepeat_MouseLeave;
            labelNoRepeat.MouseMove += labelNoRepeat_MouseMove;
            // 
            // CBrepeat
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(140, 94);
            ControlBox = false;
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximumSize = new System.Drawing.Size(156, 110);
            MinimumSize = new System.Drawing.Size(156, 110);
            Name = "CBrepeat";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Deactivate += Repeat_Deactivate;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelWeek;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label labelNoRepeat;
    }
}
