namespace MKproject.Schedule
{
    partial class Appointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Appointment));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ucSlideButton1 = new CustomizedTools.UCSlideButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxStartTime = new System.Windows.Forms.TextBox();
            this.DownArrowStartTime = new System.Windows.Forms.PictureBox();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxEndTime = new System.Windows.Forms.TextBox();
            this.DownArrowEndTime = new System.Windows.Forms.PictureBox();
            this.labelEndTime = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBoxNotes = new CustomizedTools.TextBoxWithPlaceHolder();
            this.ucClientApp1 = new MKproject.Schedule.UCClientApp();
            this.customButton1 = new CustomizedTools.CustomButton();
            this.customButton2 = new CustomizedTools.CustomButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DownArrowStartTime)).BeginInit();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DownArrowEndTime)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.ucSlideButton1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ucClientApp1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.69652F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.4554F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.03286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0939F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.56338F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.29108F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(451, 473);
            this.tableLayoutPanel1.TabIndex = 70;
            // 
            // ucSlideButton1
            // 
            this.ucSlideButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ucSlideButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(224)))));
            this.ucSlideButton1.Location = new System.Drawing.Point(150, 4);
            this.ucSlideButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucSlideButton1.Name = "ucSlideButton1";
            this.ucSlideButton1.Size = new System.Drawing.Size(151, 31);
            this.ucSlideButton1.TabIndex = 75;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.labelStartTime);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 179);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 47);
            this.panel2.TabIndex = 71;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.textBoxStartTime);
            this.flowLayoutPanel1.Controls.Add(this.DownArrowStartTime);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(296, 9);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(142, 21);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // textBoxStartTime
            // 
            this.textBoxStartTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxStartTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStartTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStartTime.Location = new System.Drawing.Point(2, 2);
            this.textBoxStartTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxStartTime.Name = "textBoxStartTime";
            this.textBoxStartTime.Size = new System.Drawing.Size(111, 18);
            this.textBoxStartTime.TabIndex = 10;
            this.textBoxStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxStartTime.Click += new System.EventHandler(this.textBoxStartTime_Click);
            // 
            // DownArrowStartTime
            // 
            this.DownArrowStartTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DownArrowStartTime.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DownArrowStartTime.BackgroundImage")));
            this.DownArrowStartTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DownArrowStartTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DownArrowStartTime.Image = ((System.Drawing.Image)(resources.GetObject("DownArrowStartTime.Image")));
            this.DownArrowStartTime.Location = new System.Drawing.Point(115, 0);
            this.DownArrowStartTime.Margin = new System.Windows.Forms.Padding(0);
            this.DownArrowStartTime.Name = "DownArrowStartTime";
            this.DownArrowStartTime.Size = new System.Drawing.Size(23, 21);
            this.DownArrowStartTime.TabIndex = 62;
            this.DownArrowStartTime.TabStop = false;
            // 
            // labelStartTime
            // 
            this.labelStartTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelStartTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartTime.Location = new System.Drawing.Point(0, 0);
            this.labelStartTime.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.labelStartTime.Size = new System.Drawing.Size(145, 43);
            this.labelStartTime.TabIndex = 0;
            this.labelStartTime.Text = "Start Time:";
            this.labelStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.flowLayoutPanel2);
            this.panel3.Controls.Add(this.labelEndTime);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 226);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(451, 43);
            this.panel3.TabIndex = 72;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.textBoxEndTime);
            this.flowLayoutPanel2.Controls.Add(this.DownArrowEndTime);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(296, 12);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(142, 21);
            this.flowLayoutPanel2.TabIndex = 12;
            // 
            // textBoxEndTime
            // 
            this.textBoxEndTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxEndTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEndTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEndTime.Location = new System.Drawing.Point(2, 2);
            this.textBoxEndTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxEndTime.Name = "textBoxEndTime";
            this.textBoxEndTime.Size = new System.Drawing.Size(111, 18);
            this.textBoxEndTime.TabIndex = 10;
            this.textBoxEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxEndTime.Click += new System.EventHandler(this.textBoxEndTime_Click);
            // 
            // DownArrowEndTime
            // 
            this.DownArrowEndTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DownArrowEndTime.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DownArrowEndTime.BackgroundImage")));
            this.DownArrowEndTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DownArrowEndTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DownArrowEndTime.Image = ((System.Drawing.Image)(resources.GetObject("DownArrowEndTime.Image")));
            this.DownArrowEndTime.Location = new System.Drawing.Point(115, 0);
            this.DownArrowEndTime.Margin = new System.Windows.Forms.Padding(0);
            this.DownArrowEndTime.Name = "DownArrowEndTime";
            this.DownArrowEndTime.Size = new System.Drawing.Size(23, 20);
            this.DownArrowEndTime.TabIndex = 62;
            this.DownArrowEndTime.TabStop = false;
            // 
            // labelEndTime
            // 
            this.labelEndTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEndTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndTime.Location = new System.Drawing.Point(0, 0);
            this.labelEndTime.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelEndTime.Name = "labelEndTime";
            this.labelEndTime.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.labelEndTime.Size = new System.Drawing.Size(148, 39);
            this.labelEndTime.TabIndex = 0;
            this.labelEndTime.Text = "End Time:";
            this.labelEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 269);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(451, 45);
            this.panel4.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(296, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "1:00:00";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.label1.Size = new System.Drawing.Size(148, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Duration:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.customButton2);
            this.panel5.Controls.Add(this.customButton1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 429);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(445, 41);
            this.panel5.TabIndex = 73;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.textBoxNotes);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 314);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(451, 112);
            this.panel6.TabIndex = 74;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNotes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNotes.ForeColor = System.Drawing.Color.Gray;
            this.textBoxNotes.Location = new System.Drawing.Point(0, 0);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.PlaceholderText = "Notes";
            this.textBoxNotes.Size = new System.Drawing.Size(447, 108);
            this.textBoxNotes.TabIndex = 1;
            this.textBoxNotes.Text = "Notes";
            // 
            // ucClientApp1
            // 
            this.ucClientApp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucClientApp1.Location = new System.Drawing.Point(3, 48);
            this.ucClientApp1.Name = "ucClientApp1";
            this.ucClientApp1.Size = new System.Drawing.Size(445, 128);
            this.ucClientApp1.TabIndex = 75;
            // 
            // customButton1
            // 
            this.customButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customButton1.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.customButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.customButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customButton1.FlatAppearance.BorderSize = 0;
            this.customButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(142)))), ((int)(((byte)(244)))));
            this.customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.customButton1.ForeColor = System.Drawing.Color.White;
            this.customButton1.Location = new System.Drawing.Point(355, 7);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(87, 29);
            this.customButton1.TabIndex = 0;
            this.customButton1.Text = "Done";
            this.customButton1.UseVisualStyleBackColor = false;
            // 
            // customButton2
            // 
            this.customButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customButton2.BackAndMouseHoverColor = System.Drawing.Color.Empty;
            this.customButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(97)))), ((int)(((byte)(99)))));
            this.customButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customButton2.FlatAppearance.BorderSize = 0;
            this.customButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.customButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.customButton2.ForeColor = System.Drawing.Color.White;
            this.customButton2.Location = new System.Drawing.Point(262, 7);
            this.customButton2.Name = "customButton2";
            this.customButton2.Size = new System.Drawing.Size(87, 29);
            this.customButton2.TabIndex = 1;
            this.customButton2.Text = "Cancel";
            this.customButton2.UseVisualStyleBackColor = false;
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(451, 473);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Appointment";
            this.Text = "Appointment";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DownArrowStartTime)).EndInit();
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DownArrowEndTime)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelStartTime;
        public CustomizedTools.TextBoxWithPlaceHolder textBoxNotes;
        private System.Windows.Forms.Label labelEndTime;
        public System.Windows.Forms.TextBox textBoxStartTime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox DownArrowStartTime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public System.Windows.Forms.TextBox textBoxEndTime;
        private System.Windows.Forms.PictureBox DownArrowEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private CustomizedTools.UCSlideButton ucSlideButton1;
        private UCClientApp ucClientApp1;
        private CustomizedTools.CustomButton customButton2;
        private CustomizedTools.CustomButton customButton1;
    }
}