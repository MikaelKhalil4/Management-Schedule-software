using System.Windows.Forms;

namespace MKproject.Schedule
{
    partial class ScheduleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleForm));
            tableLayoutPanelForm = new TableLayoutPanel();
            TLPSide = new TableLayoutPanel();
            labelFilter = new Label();
            checkBoxCancel = new CheckBox();
            checkBoxComplete = new CheckBox();
            checkBoxOnPending = new CheckBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            buttonAllReminder = new Button();
            AddButton = new PictureBox();
            panelreminder = new Panel();
            tableLayoutPanelDoubleBufferedNoscroll1 = new TableLayoutPanel();
            buttonToday = new Button();
            flowLayoutPanelDoubleBufferedcs1 = new FlowLayoutPanel();
            labelDate = new Label();
            DownArrow = new PictureBox();
            tableLayoutPanelDoubleBufferedNoscroll2 = new TableLayoutPanel();
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            tableLayoutPanelForm.SuspendLayout();
            TLPSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AddButton).BeginInit();
            tableLayoutPanelDoubleBufferedNoscroll1.SuspendLayout();
            flowLayoutPanelDoubleBufferedcs1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrow).BeginInit();
            tableLayoutPanelDoubleBufferedNoscroll2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelForm
            // 
            tableLayoutPanelForm.BackColor = System.Drawing.Color.WhiteSmoke;
            tableLayoutPanelForm.BackgroundImageLayout = ImageLayout.Stretch;
            tableLayoutPanelForm.ColumnCount = 2;
            tableLayoutPanelForm.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 208F));
            tableLayoutPanelForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelForm.Controls.Add(TLPSide, 0, 0);
            tableLayoutPanelForm.Dock = DockStyle.Fill;
            tableLayoutPanelForm.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tableLayoutPanelForm.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelForm.Margin = new Padding(0);
            tableLayoutPanelForm.Name = "tableLayoutPanelForm";
            tableLayoutPanelForm.RowCount = 1;
            tableLayoutPanelForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 691F));
            tableLayoutPanelForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelForm.Size = new System.Drawing.Size(1148, 672);
            tableLayoutPanelForm.TabIndex = 0;
            // 
            // TLPSide
            // 
            TLPSide.BackColor = System.Drawing.Color.White;
            TLPSide.ColumnCount = 4;
            TLPSide.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.73375F));
            TLPSide.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5F));
            TLPSide.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.1730766F));
            TLPSide.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.1263943F));
            TLPSide.Controls.Add(labelFilter, 0, 0);
            TLPSide.Controls.Add(checkBoxCancel, 0, 3);
            TLPSide.Controls.Add(checkBoxComplete, 0, 2);
            TLPSide.Controls.Add(checkBoxOnPending, 0, 1);
            TLPSide.Controls.Add(pictureBox2, 0, 4);
            TLPSide.Controls.Add(label1, 1, 4);
            TLPSide.Controls.Add(buttonAllReminder, 2, 4);
            TLPSide.Controls.Add(AddButton, 3, 4);
            TLPSide.Controls.Add(panelreminder, 0, 5);
            TLPSide.Dock = DockStyle.Fill;
            TLPSide.Location = new System.Drawing.Point(0, 0);
            TLPSide.Margin = new Padding(0);
            TLPSide.Name = "TLPSide";
            TLPSide.RowCount = 6;
            TLPSide.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            TLPSide.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            TLPSide.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            TLPSide.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            TLPSide.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            TLPSide.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLPSide.Size = new System.Drawing.Size(208, 691);
            TLPSide.TabIndex = 1;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.BackColor = System.Drawing.Color.White;
            TLPSide.SetColumnSpan(labelFilter, 4);
            labelFilter.Dock = DockStyle.Fill;
            labelFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelFilter.ForeColor = System.Drawing.Color.Black;
            labelFilter.Location = new System.Drawing.Point(0, 0);
            labelFilter.Margin = new Padding(0);
            labelFilter.Name = "labelFilter";
            labelFilter.Padding = new Padding(6, 0, 0, 0);
            labelFilter.Size = new System.Drawing.Size(208, 30);
            labelFilter.TabIndex = 0;
            labelFilter.Text = "Filters:";
            labelFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxCancel
            // 
            checkBoxCancel.BackColor = System.Drawing.Color.White;
            checkBoxCancel.Checked = true;
            checkBoxCancel.CheckState = CheckState.Checked;
            TLPSide.SetColumnSpan(checkBoxCancel, 2);
            checkBoxCancel.Cursor = Cursors.Hand;
            checkBoxCancel.Dock = DockStyle.Fill;
            checkBoxCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxCancel.ForeColor = System.Drawing.Color.FromArgb(244, 86, 7);
            checkBoxCancel.Location = new System.Drawing.Point(10, 93);
            checkBoxCancel.Margin = new Padding(10, 3, 3, 3);
            checkBoxCancel.Name = "checkBoxCancel";
            checkBoxCancel.Size = new System.Drawing.Size(95, 24);
            checkBoxCancel.TabIndex = 0;
            checkBoxCancel.Text = "Canceled";
            checkBoxCancel.UseVisualStyleBackColor = false;
            checkBoxCancel.CheckedChanged += checkBoxCancel_CheckedChanged;
            // 
            // checkBoxComplete
            // 
            checkBoxComplete.AutoSize = true;
            checkBoxComplete.BackColor = System.Drawing.Color.White;
            checkBoxComplete.Checked = true;
            checkBoxComplete.CheckState = CheckState.Checked;
            TLPSide.SetColumnSpan(checkBoxComplete, 2);
            checkBoxComplete.Cursor = Cursors.Hand;
            checkBoxComplete.Dock = DockStyle.Fill;
            checkBoxComplete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(128, 255, 128);
            checkBoxComplete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxComplete.ForeColor = System.Drawing.Color.FromArgb(124, 218, 124);
            checkBoxComplete.Location = new System.Drawing.Point(10, 63);
            checkBoxComplete.Margin = new Padding(10, 3, 3, 3);
            checkBoxComplete.Name = "checkBoxComplete";
            checkBoxComplete.Size = new System.Drawing.Size(95, 24);
            checkBoxComplete.TabIndex = 0;
            checkBoxComplete.Text = "Completed";
            checkBoxComplete.UseVisualStyleBackColor = false;
            checkBoxComplete.CheckedChanged += checkBoxComplete_CheckedChanged;
            // 
            // checkBoxOnPending
            // 
            checkBoxOnPending.AutoSize = true;
            checkBoxOnPending.BackColor = System.Drawing.Color.White;
            checkBoxOnPending.Checked = true;
            checkBoxOnPending.CheckState = CheckState.Checked;
            TLPSide.SetColumnSpan(checkBoxOnPending, 2);
            checkBoxOnPending.Cursor = Cursors.Hand;
            checkBoxOnPending.Dock = DockStyle.Fill;
            checkBoxOnPending.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxOnPending.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            checkBoxOnPending.Location = new System.Drawing.Point(10, 33);
            checkBoxOnPending.Margin = new Padding(10, 3, 3, 3);
            checkBoxOnPending.Name = "checkBoxOnPending";
            checkBoxOnPending.Size = new System.Drawing.Size(95, 24);
            checkBoxOnPending.TabIndex = 0;
            checkBoxOnPending.Text = "Onpending";
            checkBoxOnPending.UseVisualStyleBackColor = false;
            checkBoxOnPending.CheckedChanged += checkBoxOnPending_CheckedChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new System.Drawing.Point(2, 125);
            pictureBox2.Margin = new Padding(0, 5, 0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(25, 34);
            pictureBox2.TabIndex = 64;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            label1.Location = new System.Drawing.Point(34, 131);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(70, 17);
            label1.TabIndex = 65;
            label1.Text = "Reminder:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAllReminder
            // 
            buttonAllReminder.Anchor = AnchorStyles.None;
            buttonAllReminder.BackColor = System.Drawing.Color.WhiteSmoke;
            buttonAllReminder.Cursor = Cursors.Hand;
            buttonAllReminder.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            buttonAllReminder.FlatAppearance.BorderSize = 0;
            buttonAllReminder.FlatStyle = FlatStyle.Flat;
            buttonAllReminder.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            buttonAllReminder.Location = new System.Drawing.Point(123, 127);
            buttonAllReminder.Margin = new Padding(4, 3, 4, 3);
            buttonAllReminder.Name = "buttonAllReminder";
            buttonAllReminder.Size = new System.Drawing.Size(38, 25);
            buttonAllReminder.TabIndex = 70;
            buttonAllReminder.Text = "All";
            buttonAllReminder.UseVisualStyleBackColor = false;
            buttonAllReminder.Click += buttonAllReminder_Click;
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.None;
            AddButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("AddButton.BackgroundImage");
            AddButton.BackgroundImageLayout = ImageLayout.Zoom;
            AddButton.Cursor = Cursors.Hand;
            AddButton.Location = new System.Drawing.Point(177, 127);
            AddButton.Margin = new Padding(0);
            AddButton.Name = "AddButton";
            AddButton.Size = new System.Drawing.Size(30, 25);
            AddButton.TabIndex = 66;
            AddButton.TabStop = false;
            AddButton.Click += AddButton_Click;
            // 
            // panelreminder
            // 
            panelreminder.AutoScroll = true;
            panelreminder.BackColor = System.Drawing.Color.FromArgb(249, 246, 254);
            TLPSide.SetColumnSpan(panelreminder, 4);
            panelreminder.Dock = DockStyle.Fill;
            panelreminder.Location = new System.Drawing.Point(0, 159);
            panelreminder.Margin = new Padding(0);
            panelreminder.Name = "panelreminder";
            panelreminder.Padding = new Padding(3, 5, 3, 0);
            panelreminder.Size = new System.Drawing.Size(208, 532);
            panelreminder.TabIndex = 0;
            // 
            // tableLayoutPanelDoubleBufferedNoscroll1
            // 
            tableLayoutPanelDoubleBufferedNoscroll1.ColumnCount = 5;
            tableLayoutPanelDoubleBufferedNoscroll1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
            tableLayoutPanelDoubleBufferedNoscroll1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tableLayoutPanelDoubleBufferedNoscroll1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tableLayoutPanelDoubleBufferedNoscroll1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 218F));
            tableLayoutPanelDoubleBufferedNoscroll1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelDoubleBufferedNoscroll1.Controls.Add(buttonToday, 0, 0);
            tableLayoutPanelDoubleBufferedNoscroll1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelDoubleBufferedNoscroll1.Name = "tableLayoutPanelDoubleBufferedNoscroll1";
            tableLayoutPanelDoubleBufferedNoscroll1.RowCount = 1;
            tableLayoutPanelDoubleBufferedNoscroll1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelDoubleBufferedNoscroll1.Size = new System.Drawing.Size(200, 100);
            tableLayoutPanelDoubleBufferedNoscroll1.TabIndex = 0;
            // 
            // buttonToday
            // 
            buttonToday.Anchor = AnchorStyles.None;
            buttonToday.BackColor = System.Drawing.Color.WhiteSmoke;
            buttonToday.Cursor = Cursors.Hand;
            buttonToday.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            buttonToday.FlatAppearance.BorderSize = 0;
            buttonToday.FlatStyle = FlatStyle.Flat;
            buttonToday.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            buttonToday.Location = new System.Drawing.Point(10, 37);
            buttonToday.Margin = new Padding(4, 3, 4, 3);
            buttonToday.Name = "buttonToday";
            buttonToday.Size = new System.Drawing.Size(97, 25);
            buttonToday.TabIndex = 69;
            buttonToday.Text = "Today";
            buttonToday.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanelDoubleBufferedcs1
            // 
            flowLayoutPanelDoubleBufferedcs1.Anchor = AnchorStyles.None;
            flowLayoutPanelDoubleBufferedcs1.Controls.Add(labelDate);
            flowLayoutPanelDoubleBufferedcs1.Controls.Add(DownArrow);
            flowLayoutPanelDoubleBufferedcs1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            flowLayoutPanelDoubleBufferedcs1.Location = new System.Drawing.Point(194, 37);
            flowLayoutPanelDoubleBufferedcs1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanelDoubleBufferedcs1.Name = "flowLayoutPanelDoubleBufferedcs1";
            flowLayoutPanelDoubleBufferedcs1.Size = new System.Drawing.Size(204, 25);
            flowLayoutPanelDoubleBufferedcs1.TabIndex = 0;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Cursor = Cursors.Hand;
            labelDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelDate.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelDate.Location = new System.Drawing.Point(4, 3);
            labelDate.Margin = new Padding(4, 3, 0, 0);
            labelDate.Name = "labelDate";
            labelDate.Size = new System.Drawing.Size(118, 17);
            labelDate.TabIndex = 60;
            labelDate.Text = "Day,00 Week,Year";
            labelDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DownArrow
            // 
            DownArrow.BackgroundImage = (System.Drawing.Image)resources.GetObject("DownArrow.BackgroundImage");
            DownArrow.BackgroundImageLayout = ImageLayout.Zoom;
            DownArrow.Cursor = Cursors.Hand;
            DownArrow.Image = (System.Drawing.Image)resources.GetObject("DownArrow.Image");
            DownArrow.Location = new System.Drawing.Point(122, 0);
            DownArrow.Margin = new Padding(0);
            DownArrow.Name = "DownArrow";
            DownArrow.Size = new System.Drawing.Size(27, 22);
            DownArrow.TabIndex = 61;
            DownArrow.TabStop = false;
            // 
            // tableLayoutPanelDoubleBufferedNoscroll2
            // 
            tableLayoutPanelDoubleBufferedNoscroll2.ColumnCount = 5;
            tableLayoutPanelDoubleBufferedNoscroll2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
            tableLayoutPanelDoubleBufferedNoscroll2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tableLayoutPanelDoubleBufferedNoscroll2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tableLayoutPanelDoubleBufferedNoscroll2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 218F));
            tableLayoutPanelDoubleBufferedNoscroll2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelDoubleBufferedNoscroll2.Controls.Add(button1, 0, 0);
            tableLayoutPanelDoubleBufferedNoscroll2.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelDoubleBufferedNoscroll2.Name = "tableLayoutPanelDoubleBufferedNoscroll2";
            tableLayoutPanelDoubleBufferedNoscroll2.RowCount = 1;
            tableLayoutPanelDoubleBufferedNoscroll2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelDoubleBufferedNoscroll2.Size = new System.Drawing.Size(200, 100);
            tableLayoutPanelDoubleBufferedNoscroll2.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = System.Drawing.Color.WhiteSmoke;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.ForeColor = System.Drawing.Color.Black;
            button1.Location = new System.Drawing.Point(15, 37);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(86, 26);
            button1.TabIndex = 69;
            button1.Text = "Today";
            button1.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.None;
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            flowLayoutPanel1.Location = new System.Drawing.Point(194, 39);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(204, 22);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Cursor = Cursors.Hand;
            label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            label2.Location = new System.Drawing.Point(4, 3);
            label2.Margin = new Padding(4, 3, 0, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(118, 17);
            label2.TabIndex = 60;
            label2.Text = "Day,00 Week,Year";
            label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(122, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(27, 20);
            pictureBox1.TabIndex = 61;
            pictureBox1.TabStop = false;
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1148, 672);
            Controls.Add(tableLayoutPanelForm);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ScheduleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += ScheduleForm_Load;
            Resize += ScheduleForm_Resize;
            tableLayoutPanelForm.ResumeLayout(false);
            TLPSide.ResumeLayout(false);
            TLPSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)AddButton).EndInit();
            tableLayoutPanelDoubleBufferedNoscroll1.ResumeLayout(false);
            flowLayoutPanelDoubleBufferedcs1.ResumeLayout(false);
            flowLayoutPanelDoubleBufferedcs1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrow).EndInit();
            tableLayoutPanelDoubleBufferedNoscroll2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanelForm;
        private System.Windows.Forms.TableLayoutPanel TLPSide;
        private System.Windows.Forms.Label labelFilter;
        public System.Windows.Forms.CheckBox checkBoxCancel;
        public System.Windows.Forms.CheckBox checkBoxComplete;
        public System.Windows.Forms.CheckBox checkBoxOnPending;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAllReminder;
        private System.Windows.Forms.PictureBox AddButton;
        public System.Windows.Forms.Panel panelreminder;
        private TableLayoutPanel tableLayoutPanelDoubleBufferedNoscroll1;
        private System.Windows.Forms.Button buttonToday;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDoubleBufferedcs1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.PictureBox DownArrow;
        private TableLayoutPanel tableLayoutPanelDoubleBufferedNoscroll2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

