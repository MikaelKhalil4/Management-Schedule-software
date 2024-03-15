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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxAppointment = new System.Windows.Forms.CheckBox();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.labelEndTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.60825F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.checkBoxAppointment, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelStartTime, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelEndTime, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.4375F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.56251F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(230, 66);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Click += new System.EventHandler(this.UCappointments_Click);
            this.tableLayoutPanel2.MouseLeave += new System.EventHandler(this.UCappointments_MouseLeave);
            this.tableLayoutPanel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCappointments_MouseMove);
            // 
            // checkBoxAppointment
            // 
            this.checkBoxAppointment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxAppointment.AutoSize = true;
            this.checkBoxAppointment.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxAppointment.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAppointment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.checkBoxAppointment.Location = new System.Drawing.Point(3, 30);
            this.checkBoxAppointment.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.checkBoxAppointment.Name = "checkBoxAppointment";
            this.checkBoxAppointment.Size = new System.Drawing.Size(88, 21);
            this.checkBoxAppointment.TabIndex = 14;
            this.checkBoxAppointment.Text = "Full Name";
            this.checkBoxAppointment.UseVisualStyleBackColor = false;
            this.checkBoxAppointment.Click += new System.EventHandler(this.checkBoxOnPending_Click);
            this.checkBoxAppointment.MouseLeave += new System.EventHandler(this.UCappointments_MouseLeave);
            this.checkBoxAppointment.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCappointments_MouseMove);
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.BackColor = System.Drawing.Color.Transparent;
            this.labelStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStartTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.labelStartTime.ForeColor = System.Drawing.Color.Silver;
            this.labelStartTime.Location = new System.Drawing.Point(127, 15);
            this.labelStartTime.Margin = new System.Windows.Forms.Padding(0);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(103, 51);
            this.labelStartTime.TabIndex = 2;
            this.labelStartTime.Text = "10:00";
            this.labelStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelStartTime.Click += new System.EventHandler(this.UCappointments_Click);
            this.labelStartTime.MouseLeave += new System.EventHandler(this.UCappointments_MouseLeave);
            this.labelStartTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCappointments_MouseMove);
            // 
            // labelEndTime
            // 
            this.labelEndTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEndTime.AutoSize = true;
            this.labelEndTime.BackColor = System.Drawing.Color.Transparent;
            this.labelEndTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.labelEndTime.ForeColor = System.Drawing.Color.Silver;
            this.labelEndTime.Location = new System.Drawing.Point(158, 0);
            this.labelEndTime.Margin = new System.Windows.Forms.Padding(0);
            this.labelEndTime.Name = "labelEndTime";
            this.labelEndTime.Size = new System.Drawing.Size(40, 15);
            this.labelEndTime.TabIndex = 6;
            this.labelEndTime.Text = "11:00";
            this.labelEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelEndTime.Click += new System.EventHandler(this.UCappointments_Click);
            this.labelEndTime.MouseLeave += new System.EventHandler(this.UCappointments_MouseLeave);
            this.labelEndTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCappointments_MouseMove);
            // 
            // UCappointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "UCappointments";
            this.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.Size = new System.Drawing.Size(230, 70);
            this.Click += new System.EventHandler(this.UCappointments_Click);
            this.MouseLeave += new System.EventHandler(this.UCappointments_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UCappointments_MouseMove);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label labelStartTime;
        public System.Windows.Forms.Label labelEndTime;
        public System.Windows.Forms.CheckBox checkBoxAppointment;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
