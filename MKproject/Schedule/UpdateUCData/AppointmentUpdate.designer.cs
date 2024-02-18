using CustomizedTools;

namespace MKproject.Schedule
{
    partial class AppointmentUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentUpdate));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxEndTime = new System.Windows.Forms.TextBox();
            this.textBoxStartTime = new System.Windows.Forms.TextBox();
            this.labeldifferencetime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBoxOnPending = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonRemoveAppointment = new System.Windows.Forms.Button();
            this.buttonD = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBoxNotes = new TextBoxWithPlaceHolder();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonInvitation = new System.Windows.Forms.RadioButton();
            this.radioButtonTrial = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanelNew = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxFullName = new TextBoxWithPlaceHolder();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanelNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.51852F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.46296F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.73148F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.638889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.64815F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(515, 393);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxEndTime);
            this.panel1.Controls.Add(this.textBoxStartTime);
            this.panel1.Controls.Add(this.labeldifferencetime);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 100);
            this.panel1.TabIndex = 1;
            // 
            // textBoxEndTime
            // 
            this.textBoxEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEndTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEndTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEndTime.Location = new System.Drawing.Point(349, 36);
            this.textBoxEndTime.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxEndTime.Name = "textBoxEndTime";
            this.textBoxEndTime.Size = new System.Drawing.Size(111, 18);
            this.textBoxEndTime.TabIndex = 10;
            this.textBoxEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxEndTime.Click += new System.EventHandler(this.textBoxEndTime_Click);
            // 
            // textBoxStartTime
            // 
            this.textBoxStartTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStartTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStartTime.Location = new System.Drawing.Point(70, 36);
            this.textBoxStartTime.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxStartTime.Name = "textBoxStartTime";
            this.textBoxStartTime.Size = new System.Drawing.Size(111, 18);
            this.textBoxStartTime.TabIndex = 9;
            this.textBoxStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxStartTime.Click += new System.EventHandler(this.textBoxStartTime_Click);
            // 
            // labeldifferencetime
            // 
            this.labeldifferencetime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labeldifferencetime.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldifferencetime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.labeldifferencetime.Location = new System.Drawing.Point(233, 73);
            this.labeldifferencetime.Name = "labeldifferencetime";
            this.labeldifferencetime.Size = new System.Drawing.Size(57, 14);
            this.labeldifferencetime.TabIndex = 8;
            this.labeldifferencetime.Text = "00:00:00";
            this.labeldifferencetime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(233, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBoxOnPending);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 320);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(515, 30);
            this.panel3.TabIndex = 9;
            // 
            // checkBoxOnPending
            // 
            this.checkBoxOnPending.AutoSize = true;
            this.checkBoxOnPending.Location = new System.Drawing.Point(13, 10);
            this.checkBoxOnPending.Name = "checkBoxOnPending";
            this.checkBoxOnPending.Size = new System.Drawing.Size(72, 17);
            this.checkBoxOnPending.TabIndex = 0;
            this.checkBoxOnPending.Text = "Approved";
            this.checkBoxOnPending.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonRemoveAppointment);
            this.panel4.Controls.Add(this.buttonD);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 350);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(515, 43);
            this.panel4.TabIndex = 9;
            // 
            // buttonRemoveAppointment
            // 
            this.buttonRemoveAppointment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonRemoveAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonRemoveAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemoveAppointment.FlatAppearance.BorderSize = 0;
            this.buttonRemoveAppointment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonRemoveAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveAppointment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveAppointment.ForeColor = System.Drawing.Color.White;
            this.buttonRemoveAppointment.Location = new System.Drawing.Point(349, 6);
            this.buttonRemoveAppointment.Margin = new System.Windows.Forms.Padding(10, 5, 15, 5);
            this.buttonRemoveAppointment.Name = "buttonRemoveAppointment";
            this.buttonRemoveAppointment.Size = new System.Drawing.Size(161, 29);
            this.buttonRemoveAppointment.TabIndex = 10;
            this.buttonRemoveAppointment.Text = "Remove Appointment";
            this.buttonRemoveAppointment.UseVisualStyleBackColor = false;
            this.buttonRemoveAppointment.Click += new System.EventHandler(this.buttonRemoveAppointment_Click);
            // 
            // buttonD
            // 
            this.buttonD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonD.BackColor = System.Drawing.Color.Transparent;
            this.buttonD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonD.BackgroundImage")));
            this.buttonD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonD.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.buttonD.FlatAppearance.BorderSize = 0;
            this.buttonD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.buttonD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonD.ForeColor = System.Drawing.Color.Transparent;
            this.buttonD.Location = new System.Drawing.Point(244, 7);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(32, 28);
            this.buttonD.TabIndex = 8;
            this.buttonD.UseVisualStyleBackColor = false;
            this.buttonD.Click += new System.EventHandler(this.buttonD_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBoxNotes);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(6, 178);
            this.panel5.Margin = new System.Windows.Forms.Padding(6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(503, 136);
            this.panel5.TabIndex = 10;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNotes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.textBoxNotes.Location = new System.Drawing.Point(0, 0);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.PlaceholderText = "Notes";
            this.textBoxNotes.Size = new System.Drawing.Size(503, 136);
            this.textBoxNotes.TabIndex = 0;
            this.textBoxNotes.Text = "Notes";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonInvitation);
            this.panel2.Controls.Add(this.radioButtonTrial);
            this.panel2.Controls.Add(this.flowLayoutPanelNew);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.textBoxFullName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 72);
            this.panel2.TabIndex = 11;
            // 
            // radioButtonInvitation
            // 
            this.radioButtonInvitation.AutoSize = true;
            this.radioButtonInvitation.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonInvitation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonInvitation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonInvitation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(220)))), ((int)(((byte)(168)))));
            this.radioButtonInvitation.Location = new System.Drawing.Point(320, 48);
            this.radioButtonInvitation.Name = "radioButtonInvitation";
            this.radioButtonInvitation.Size = new System.Drawing.Size(73, 17);
            this.radioButtonInvitation.TabIndex = 67;
            this.radioButtonInvitation.TabStop = true;
            this.radioButtonInvitation.Text = "Invitation";
            this.radioButtonInvitation.UseVisualStyleBackColor = false;
            this.radioButtonInvitation.Visible = false;
            // 
            // radioButtonTrial
            // 
            this.radioButtonTrial.AutoSize = true;
            this.radioButtonTrial.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonTrial.Checked = true;
            this.radioButtonTrial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonTrial.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonTrial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(88)))), ((int)(((byte)(229)))));
            this.radioButtonTrial.Location = new System.Drawing.Point(269, 48);
            this.radioButtonTrial.Name = "radioButtonTrial";
            this.radioButtonTrial.Size = new System.Drawing.Size(45, 17);
            this.radioButtonTrial.TabIndex = 67;
            this.radioButtonTrial.TabStop = true;
            this.radioButtonTrial.Text = "Trial";
            this.radioButtonTrial.UseVisualStyleBackColor = false;
            this.radioButtonTrial.Visible = false;
            this.radioButtonTrial.CheckedChanged += new System.EventHandler(this.radioButtonTrial_CheckedChanged);
            // 
            // flowLayoutPanelNew
            // 
            this.flowLayoutPanelNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelNew.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelNew.Controls.Add(this.pictureBox3);
            this.flowLayoutPanelNew.Controls.Add(this.label1);
            this.flowLayoutPanelNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flowLayoutPanelNew.Location = new System.Drawing.Point(407, 20);
            this.flowLayoutPanelNew.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelNew.Name = "flowLayoutPanelNew";
            this.flowLayoutPanelNew.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.flowLayoutPanelNew.Size = new System.Drawing.Size(102, 22);
            this.flowLayoutPanelNew.TabIndex = 66;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(5, 2);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 20);
            this.pictureBox3.TabIndex = 64;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(23, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "New Client";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(5, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBoxFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFullName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.textBoxFullName.Location = new System.Drawing.Point(30, 20);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.PlaceholderText = "Search by name or phone number...";
            this.textBoxFullName.Size = new System.Drawing.Size(355, 22);
            this.textBoxFullName.TabIndex = 11;
            this.textBoxFullName.Text = "Search by name or phone number...";
            this.textBoxFullName.Click += new System.EventHandler(this.textBoxFullName_Click);
            // 
            // AppointmentUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(515, 393);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AppointmentUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AppointmentUpdate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AppointmentUpdate_FormClosed);
            this.Load += new System.EventHandler(this.AppointmentUpdate_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanelNew.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox textBoxEndTime;
        public System.Windows.Forms.TextBox textBoxStartTime;
        public System.Windows.Forms.Label labeldifferencetime;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.CheckBox checkBoxOnPending;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Panel panel5;
        public TextBoxWithPlaceHolder textBoxNotes;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.RadioButton radioButtonInvitation;
        public System.Windows.Forms.RadioButton radioButtonTrial;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNew;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        public TextBoxWithPlaceHolder textBoxFullName;
        private System.Windows.Forms.Button buttonRemoveAppointment;
    }
}