namespace MKproject.Schedule
{
    partial class UCmeeting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCmeeting));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelEndTime = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.checkBoxMeeting = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.labelStartTime, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelEndTime, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonDelete, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxMeeting, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.21212F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.78788F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(295, 66);
            this.tableLayoutPanel2.TabIndex = 1;
            this.tableLayoutPanel2.Click += new System.EventHandler(this.UCmeeting_Click);
            this.tableLayoutPanel2.MouseLeave += new System.EventHandler(this.UCmeeting_MouseLeave);
            this.tableLayoutPanel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCmeeting_MouseMove);
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.BackColor = System.Drawing.Color.Transparent;
            this.labelStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStartTime.Font = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartTime.ForeColor = System.Drawing.Color.Silver;
            this.labelStartTime.Location = new System.Drawing.Point(175, 0);
            this.labelStartTime.Margin = new System.Windows.Forms.Padding(0);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(50, 13);
            this.labelStartTime.TabIndex = 2;
            this.labelStartTime.Text = "10:00";
            this.labelStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelStartTime.Click += new System.EventHandler(this.UCmeeting_Click);
            this.labelStartTime.MouseLeave += new System.EventHandler(this.UCmeeting_MouseLeave);
            this.labelStartTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCmeeting_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(228, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 7);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.UCmeeting_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.UCmeeting_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCmeeting_MouseMove);
            // 
            // labelEndTime
            // 
            this.labelEndTime.AutoSize = true;
            this.labelEndTime.BackColor = System.Drawing.Color.Transparent;
            this.labelEndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEndTime.Font = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndTime.ForeColor = System.Drawing.Color.Silver;
            this.labelEndTime.Location = new System.Drawing.Point(248, 0);
            this.labelEndTime.Margin = new System.Windows.Forms.Padding(0);
            this.labelEndTime.Name = "labelEndTime";
            this.labelEndTime.Size = new System.Drawing.Size(47, 13);
            this.labelEndTime.TabIndex = 6;
            this.labelEndTime.Text = "11:00";
            this.labelEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelEndTime.Click += new System.EventHandler(this.UCmeeting_Click);
            this.labelEndTime.MouseLeave += new System.EventHandler(this.UCmeeting_MouseLeave);
            this.labelEndTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCmeeting_MouseMove);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDelete.BackgroundImage")));
            this.buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Location = new System.Drawing.Point(0, 1);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(0, 1, 70, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(16, 12);
            this.buttonDelete.TabIndex = 19;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // checkBoxMeeting
            // 
            this.checkBoxMeeting.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxMeeting.AutoSize = true;
            this.checkBoxMeeting.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.SetColumnSpan(this.checkBoxMeeting, 4);
            this.checkBoxMeeting.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMeeting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.checkBoxMeeting.Location = new System.Drawing.Point(3, 29);
            this.checkBoxMeeting.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.checkBoxMeeting.Name = "checkBoxMeeting";
            this.checkBoxMeeting.Size = new System.Drawing.Size(88, 21);
            this.checkBoxMeeting.TabIndex = 14;
            this.checkBoxMeeting.Text = "Full Name";
            this.checkBoxMeeting.UseVisualStyleBackColor = false;
            this.checkBoxMeeting.Click += new System.EventHandler(this.checkBoxMeeting_Click);
            this.checkBoxMeeting.MouseLeave += new System.EventHandler(this.UCmeeting_MouseLeave);
            this.checkBoxMeeting.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCmeeting_MouseMove);
            // 
            // UCmeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(147)))));
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "UCmeeting";
            this.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.Size = new System.Drawing.Size(295, 70);
            this.Click += new System.EventHandler(this.UCmeeting_Click);
            this.MouseLeave += new System.EventHandler(this.UCmeeting_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCmeeting_MouseMove);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.CheckBox checkBoxMeeting;
        public System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label labelEndTime;
        private System.Windows.Forms.Button buttonDelete;
    }
}
