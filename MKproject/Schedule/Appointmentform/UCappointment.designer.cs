namespace MKproject.Schedule
{
    partial class UCappointment
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
            TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            labelTime = new System.Windows.Forms.Label();
            labelFullName = new System.Windows.Forms.Label();
            labelService = new System.Windows.Forms.Label();
            TLPGlobal.SuspendLayout();
            SuspendLayout();
            // 
            // TLPGlobal
            // 
            TLPGlobal.BackColor = System.Drawing.Color.White;
            TLPGlobal.ColumnCount = 2;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            TLPGlobal.Controls.Add(labelTime, 1, 1);
            TLPGlobal.Controls.Add(labelFullName, 0, 1);
            TLPGlobal.Controls.Add(labelService, 0, 0);
            TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 5);
            TLPGlobal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 2;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            TLPGlobal.Size = new System.Drawing.Size(268, 76);
            TLPGlobal.TabIndex = 0;
            TLPGlobal.MouseLeave += UCappointments_MouseLeave;
            TLPGlobal.MouseMove += UCappointments_MouseMove;
            // 
            // labelTime
            // 
            labelTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            labelTime.AutoSize = true;
            labelTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTime.ForeColor = System.Drawing.Color.DarkGray;
            labelTime.Location = new System.Drawing.Point(181, 35);
            labelTime.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            labelTime.Name = "labelTime";
            labelTime.Size = new System.Drawing.Size(87, 19);
            labelTime.TabIndex = 2;
            labelTime.Text = "10:00 - 11:00";
            labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelTime.MouseLeave += UCappointments_MouseLeave;
            labelTime.MouseMove += UCappointments_MouseMove;
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Font = new System.Drawing.Font("Segoe UI Semibold", 10.55F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelFullName.ForeColor = System.Drawing.Color.FromArgb(89, 102, 204);
            labelFullName.Location = new System.Drawing.Point(3, 35);
            labelFullName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new System.Drawing.Size(79, 20);
            labelFullName.TabIndex = 15;
            labelFullName.Text = "Full Name";
            labelFullName.MouseLeave += UCappointments_MouseLeave;
            labelFullName.MouseMove += UCappointments_MouseMove;
            // 
            // labelService
            // 
            labelService.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelService.AutoSize = true;
            TLPGlobal.SetColumnSpan(labelService, 2);
            labelService.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelService.ForeColor = System.Drawing.Color.FromArgb(94, 94, 94);
            labelService.Location = new System.Drawing.Point(3, 6);
            labelService.Name = "labelService";
            labelService.Size = new System.Drawing.Size(51, 17);
            labelService.TabIndex = 16;
            labelService.Text = "Service";
            labelService.MouseLeave += UCappointments_MouseLeave;
            labelService.MouseMove += UCappointments_MouseMove;
            // 
            // UCappointment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            Controls.Add(TLPGlobal);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UCappointment";
            Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            Size = new System.Drawing.Size(268, 81);
            MouseLeave += UCappointments_MouseLeave;
            MouseMove += UCappointments_MouseMove;
            TLPGlobal.ResumeLayout(false);
            TLPGlobal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.Label labelTime;
        public System.Windows.Forms.TableLayoutPanel TLPGlobal;
        private System.Windows.Forms.Label labelService;
        private System.Windows.Forms.Label labelFullName;
    }
}
