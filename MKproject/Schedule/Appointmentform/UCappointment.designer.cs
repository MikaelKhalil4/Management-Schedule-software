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
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            TLPGlobal.Controls.Add(labelTime, 1, 1);
            TLPGlobal.Controls.Add(labelFullName, 0, 1);
            TLPGlobal.Controls.Add(labelService, 0, 0);
            TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 4);
            TLPGlobal.Margin = new System.Windows.Forms.Padding(0);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 2;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            TLPGlobal.Size = new System.Drawing.Size(249, 78);
            TLPGlobal.TabIndex = 0;
            TLPGlobal.MouseLeave += UCappointments_MouseLeave;
            TLPGlobal.MouseMove += UCappointments_MouseMove;
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Dock = System.Windows.Forms.DockStyle.Fill;
            labelTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTime.ForeColor = System.Drawing.Color.DarkGray;
            labelTime.Location = new System.Drawing.Point(154, 36);
            labelTime.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            labelTime.Name = "labelTime";
            labelTime.Size = new System.Drawing.Size(95, 42);
            labelTime.TabIndex = 2;
            labelTime.Text = "10:00 - 11:00";
            labelTime.MouseLeave += UCappointments_MouseLeave;
            labelTime.MouseMove += UCappointments_MouseMove;
            // 
            // labelFullName
            // 
            labelFullName.BackColor = System.Drawing.Color.Transparent;
            labelFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            labelFullName.Font = new System.Drawing.Font("Segoe UI Semibold", 10.55F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelFullName.ForeColor = System.Drawing.Color.FromArgb(89, 102, 204);
            labelFullName.Location = new System.Drawing.Point(1, 36);
            labelFullName.Margin = new System.Windows.Forms.Padding(1, 5, 1, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new System.Drawing.Size(152, 42);
            labelFullName.TabIndex = 15;
            labelFullName.Text = "Full Name\r\nFull Name\r\n";
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
            labelService.Location = new System.Drawing.Point(1, 7);
            labelService.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
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
            Cursor = System.Windows.Forms.Cursors.Hand;
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Name = "UCappointment";
            Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            Size = new System.Drawing.Size(249, 82);
            GiveFeedback += UCappointment_GiveFeedback;
            QueryContinueDrag += UCappointment_QueryContinueDrag;
            MouseLeave += UCappointments_MouseLeave;
            MouseMove += UCappointments_MouseMove;
            Resize += UCappointment_Resize;
            TLPGlobal.ResumeLayout(false);
            TLPGlobal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.Label labelTime;
        public System.Windows.Forms.TableLayoutPanel TLPGlobal;
        private System.Windows.Forms.Label labelService;
        public System.Windows.Forms.Label labelFullName;
    }
}
