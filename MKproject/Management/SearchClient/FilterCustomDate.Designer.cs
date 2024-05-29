namespace MKproject.Management
{
    partial class FilterCustomDate
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
            dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            label10 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            buttonDone = new System.Windows.Forms.Button();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.29469F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.70531F));
            tableLayoutPanel1.Controls.Add(dateTimePickerEnd, 1, 1);
            tableLayoutPanel1.Controls.Add(dateTimePickerStart, 1, 0);
            tableLayoutPanel1.Controls.Add(label10, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(buttonDone, 1, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            tableLayoutPanel1.Size = new System.Drawing.Size(511, 241);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            dateTimePickerEnd.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dateTimePickerEnd.CalendarMonthBackground = System.Drawing.Color.Red;
            dateTimePickerEnd.CalendarTitleBackColor = System.Drawing.Color.Red;
            dateTimePickerEnd.CalendarTitleForeColor = System.Drawing.Color.Red;
            dateTimePickerEnd.CalendarTrailingForeColor = System.Drawing.Color.Red;
            dateTimePickerEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            dateTimePickerEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dateTimePickerEnd.Location = new System.Drawing.Point(139, 132);
            dateTimePickerEnd.Margin = new System.Windows.Forms.Padding(0, 3, 9, 3);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.ShowCheckBox = true;
            dateTimePickerEnd.Size = new System.Drawing.Size(362, 29);
            dateTimePickerEnd.TabIndex = 33;
            dateTimePickerEnd.ValueChanged += dateTimePickerEnd_ValueChanged;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            dateTimePickerStart.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dateTimePickerStart.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            dateTimePickerStart.CalendarTitleForeColor = System.Drawing.Color.Red;
            dateTimePickerStart.Cursor = System.Windows.Forms.Cursors.Hand;
            dateTimePickerStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dateTimePickerStart.Location = new System.Drawing.Point(139, 34);
            dateTimePickerStart.Margin = new System.Windows.Forms.Padding(0, 3, 9, 3);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.ShowCheckBox = true;
            dateTimePickerStart.Size = new System.Drawing.Size(362, 29);
            dateTimePickerStart.TabIndex = 32;
            dateTimePickerStart.Value = new System.DateTime(2023, 8, 24, 17, 10, 43, 0);
            dateTimePickerStart.ValueChanged += dateTimePickerStart_ValueChanged;
            // 
            // label10
            // 
            label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label10.Location = new System.Drawing.Point(0, 37);
            label10.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(135, 23);
            label10.TabIndex = 3;
            label10.Text = "Starting Date:";
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(0, 135);
            label1.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(134, 23);
            label1.TabIndex = 3;
            label1.Text = "Ending Date:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonDone
            // 
            buttonDone.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonDone.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonDone.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonDone.FlatAppearance.BorderSize = 0;
            buttonDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonDone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonDone.ForeColor = System.Drawing.Color.White;
            buttonDone.Location = new System.Drawing.Point(399, 202);
            buttonDone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new System.Drawing.Size(108, 33);
            buttonDone.TabIndex = 34;
            buttonDone.Text = "Done";
            buttonDone.UseVisualStyleBackColor = false;
            buttonDone.Click += buttonDone_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // FilterCustomDate
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(511, 241);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FilterCustomDate";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FilterCustomDate";
            Deactivate += FilterCustomDate_Deactivate;
            FormClosing += FilterCustomDate_FormClosing;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonDone;
    }
}