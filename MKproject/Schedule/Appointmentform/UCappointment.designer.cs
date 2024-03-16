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
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            labelTime = new System.Windows.Forms.Label();
            labelFullName = new System.Windows.Forms.Label();
            labelService = new System.Windows.Forms.Label();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            tableLayoutPanel2.Controls.Add(labelTime, 1, 1);
            tableLayoutPanel2.Controls.Add(labelFullName, 0, 1);
            tableLayoutPanel2.Controls.Add(labelService, 0, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 5);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.1578941F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.8421059F));
            tableLayoutPanel2.Size = new System.Drawing.Size(268, 76);
            tableLayoutPanel2.TabIndex = 0;
            tableLayoutPanel2.Click += UCappointments_Click;
            tableLayoutPanel2.MouseLeave += UCappointments_MouseLeave;
            tableLayoutPanel2.MouseMove += UCappointments_MouseMove;
            // 
            // labelTime
            // 
            labelTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            labelTime.AutoSize = true;
            labelTime.BackColor = System.Drawing.Color.Transparent;
            labelTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTime.ForeColor = System.Drawing.Color.DarkGray;
            labelTime.Location = new System.Drawing.Point(181, 34);
            labelTime.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            labelTime.Name = "labelTime";
            labelTime.Size = new System.Drawing.Size(87, 19);
            labelTime.TabIndex = 2;
            labelTime.Text = "10:00 - 11:00";
            labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelTime.Click += UCappointments_Click;
            labelTime.MouseLeave += UCappointments_MouseLeave;
            labelTime.MouseMove += UCappointments_MouseMove;
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelFullName.ForeColor = System.Drawing.Color.FromArgb(89, 102, 204);
            labelFullName.Location = new System.Drawing.Point(3, 34);
            labelFullName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new System.Drawing.Size(73, 19);
            labelFullName.TabIndex = 15;
            labelFullName.Text = "Full Name";
            // 
            // labelService
            // 
            labelService.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelService.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(labelService, 2);
            labelService.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelService.ForeColor = System.Drawing.Color.FromArgb(74, 74, 74);
            labelService.Location = new System.Drawing.Point(3, 6);
            labelService.Name = "labelService";
            labelService.Size = new System.Drawing.Size(51, 17);
            labelService.TabIndex = 16;
            labelService.Text = "Service";
            // 
            // UCappointment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            Controls.Add(tableLayoutPanel2);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UCappointment";
            Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            Size = new System.Drawing.Size(268, 81);
            Click += UCappointments_Click;
            MouseLeave += UCappointments_MouseLeave;
            MouseMove += UCappointments_MouseMove;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.Label labelTime;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelService;
    }
}
