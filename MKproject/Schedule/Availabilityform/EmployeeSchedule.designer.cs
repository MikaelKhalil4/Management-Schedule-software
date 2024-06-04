namespace MKproject.Schedule
{
    partial class EmployeeSchedule
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ButtonDone = new CustomizedTools.CustomButton();
            panelGlobal = new System.Windows.Forms.Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(ButtonDone, 0, 1);
            tableLayoutPanel1.Controls.Add(panelGlobal, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(6, 8);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.3333359F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Size = new System.Drawing.Size(323, 342);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // ButtonDone
            // 
            ButtonDone.Anchor = System.Windows.Forms.AnchorStyles.None;
            ButtonDone.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(109, 122, 224);
            ButtonDone.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            ButtonDone.Cursor = System.Windows.Forms.Cursors.Hand;
            ButtonDone.FlatAppearance.BorderSize = 0;
            ButtonDone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(69, 82, 184);
            ButtonDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 142, 244);
            ButtonDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ButtonDone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ButtonDone.ForeColor = System.Drawing.Color.White;
            ButtonDone.Location = new System.Drawing.Point(117, 299);
            ButtonDone.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            ButtonDone.Name = "ButtonDone";
            ButtonDone.Size = new System.Drawing.Size(87, 29);
            ButtonDone.TabIndex = 1;
            ButtonDone.Text = "Done";
            ButtonDone.UseVisualStyleBackColor = false;
            ButtonDone.Click += ButtonDone_Click;
            // 
            // panelGlobal
            // 
            panelGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            panelGlobal.Location = new System.Drawing.Point(3, 3);
            panelGlobal.Name = "panelGlobal";
            panelGlobal.Size = new System.Drawing.Size(317, 279);
            panelGlobal.TabIndex = 2;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // EmployeeSchedule
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(249, 246, 254);
            ClientSize = new System.Drawing.Size(335, 350);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "EmployeeSchedule";
            Padding = new System.Windows.Forms.Padding(6, 8, 6, 0);
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Deactivate += Employee_Deactivate;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public CustomizedTools.CustomButton ButtonDone;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Panel panelGlobal;
    }
}