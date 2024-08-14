using System.Windows.Forms;

namespace MKproject.Schedule
{
    partial class UCSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSchedule));
            TLPGlobal = new TableLayoutPanel();
            TLPUp = new TableLayoutPanel();
            FLPMembers = new FlowLayoutPanel();
            labelMember = new Label();
            pictureBoxMember = new PictureBox();
            comboBoxDaysOrWeek = new ComboBox();
            buttonToday = new Button();
            flowLayoutPanelDoubleBufferedcs1 = new FlowLayoutPanel();
            labelDate = new Label();
            DownArrow = new PictureBox();
            buttonPrevious = new Button();
            buttonNext = new Button();
            progressBar1 = new ProgressBar();
            TLPGlobal.SuspendLayout();
            TLPUp.SuspendLayout();
            FLPMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMember).BeginInit();
            flowLayoutPanelDoubleBufferedcs1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrow).BeginInit();
            SuspendLayout();
            // 
            // TLPGlobal
            // 
            TLPGlobal.BackColor = System.Drawing.Color.White;
            TLPGlobal.ColumnCount = 1;
            TLPGlobal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TLPGlobal.Controls.Add(TLPUp, 0, 0);
            TLPGlobal.Dock = DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 0);
            TLPGlobal.Margin = new Padding(0);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 3;
            TLPGlobal.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            TLPGlobal.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            TLPGlobal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLPGlobal.Size = new System.Drawing.Size(1317, 891);
            TLPGlobal.TabIndex = 1;
            // 
            // TLPUp
            // 
            TLPUp.BackColor = System.Drawing.Color.White;
            TLPUp.ColumnCount = 7;
            TLPUp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 134F));
            TLPUp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            TLPUp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            TLPUp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            TLPUp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TLPUp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 103F));
            TLPUp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114F));
            TLPUp.Controls.Add(FLPMembers, 6, 0);
            TLPUp.Controls.Add(comboBoxDaysOrWeek, 5, 0);
            TLPUp.Controls.Add(buttonToday, 0, 0);
            TLPUp.Controls.Add(flowLayoutPanelDoubleBufferedcs1, 3, 0);
            TLPUp.Controls.Add(buttonPrevious, 1, 0);
            TLPUp.Controls.Add(buttonNext, 2, 0);
            TLPUp.Controls.Add(progressBar1, 0, 1);
            TLPUp.Dock = DockStyle.Fill;
            TLPUp.Location = new System.Drawing.Point(0, 0);
            TLPUp.Margin = new Padding(0);
            TLPUp.Name = "TLPUp";
            TLPUp.RowCount = 2;
            TLPUp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLPUp.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
            TLPUp.Size = new System.Drawing.Size(1317, 56);
            TLPUp.TabIndex = 62;
            // 
            // FLPMembers
            // 
            FLPMembers.Anchor = AnchorStyles.None;
            FLPMembers.BackColor = System.Drawing.Color.White;
            FLPMembers.Controls.Add(labelMember);
            FLPMembers.Controls.Add(pictureBoxMember);
            FLPMembers.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            FLPMembers.Location = new System.Drawing.Point(1208, 12);
            FLPMembers.Margin = new Padding(5, 4, 5, 4);
            FLPMembers.Name = "FLPMembers";
            FLPMembers.Size = new System.Drawing.Size(104, 28);
            FLPMembers.TabIndex = 71;
            // 
            // labelMember
            // 
            labelMember.AutoSize = true;
            labelMember.Cursor = Cursors.Hand;
            labelMember.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelMember.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelMember.Location = new System.Drawing.Point(0, 3);
            labelMember.Margin = new Padding(0, 3, 0, 0);
            labelMember.Name = "labelMember";
            labelMember.Size = new System.Drawing.Size(78, 23);
            labelMember.TabIndex = 60;
            labelMember.Text = "Member";
            labelMember.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            labelMember.Click += labelMember_Click;
            labelMember.MouseLeave += labelMember_MouseLeave;
            labelMember.MouseMove += labelMember_MouseMove;
            // 
            // pictureBoxMember
            // 
            pictureBoxMember.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBoxMember.BackgroundImage");
            pictureBoxMember.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxMember.Cursor = Cursors.Hand;
            pictureBoxMember.Location = new System.Drawing.Point(0, 26);
            pictureBoxMember.Margin = new Padding(0);
            pictureBoxMember.Name = "pictureBoxMember";
            pictureBoxMember.Size = new System.Drawing.Size(31, 27);
            pictureBoxMember.TabIndex = 61;
            pictureBoxMember.TabStop = false;
            pictureBoxMember.Click += labelMember_Click;
            pictureBoxMember.MouseLeave += labelMember_MouseLeave;
            pictureBoxMember.MouseMove += labelMember_MouseMove;
            // 
            // comboBoxDaysOrWeek
            // 
            comboBoxDaysOrWeek.Anchor = AnchorStyles.Right;
            comboBoxDaysOrWeek.BackColor = System.Drawing.Color.WhiteSmoke;
            comboBoxDaysOrWeek.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDaysOrWeek.FlatStyle = FlatStyle.Flat;
            comboBoxDaysOrWeek.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            comboBoxDaysOrWeek.ForeColor = System.Drawing.Color.Black;
            comboBoxDaysOrWeek.FormattingEnabled = true;
            comboBoxDaysOrWeek.Location = new System.Drawing.Point(1107, 8);
            comboBoxDaysOrWeek.Margin = new Padding(7, 8, 7, 8);
            comboBoxDaysOrWeek.Name = "comboBoxDaysOrWeek";
            comboBoxDaysOrWeek.Size = new System.Drawing.Size(89, 36);
            comboBoxDaysOrWeek.TabIndex = 750;
            comboBoxDaysOrWeek.SelectedIndexChanged += comboBoxDaysOrWeek_SelectedIndexChanged;
            comboBoxDaysOrWeek.DropDownClosed += comboBoxDaysOrWeek_DropDownClosed;
            comboBoxDaysOrWeek.MouseLeave += comboBoxDaysOrWeek_MouseLeave;
            comboBoxDaysOrWeek.MouseMove += comboBoxDaysOrWeek_MouseMove;
            // 
            // buttonToday
            // 
            buttonToday.Anchor = AnchorStyles.None;
            buttonToday.BackColor = System.Drawing.Color.WhiteSmoke;
            buttonToday.Cursor = Cursors.Hand;
            buttonToday.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            buttonToday.FlatAppearance.BorderSize = 0;
            buttonToday.FlatStyle = FlatStyle.Flat;
            buttonToday.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonToday.ForeColor = System.Drawing.Color.Black;
            buttonToday.Location = new System.Drawing.Point(18, 10);
            buttonToday.Margin = new Padding(5, 4, 5, 4);
            buttonToday.Name = "buttonToday";
            buttonToday.Size = new System.Drawing.Size(98, 33);
            buttonToday.TabIndex = 69;
            buttonToday.Text = "Today";
            buttonToday.UseVisualStyleBackColor = false;
            buttonToday.Click += buttonToday_Click;
            // 
            // flowLayoutPanelDoubleBufferedcs1
            // 
            flowLayoutPanelDoubleBufferedcs1.Anchor = AnchorStyles.Left;
            flowLayoutPanelDoubleBufferedcs1.BackColor = System.Drawing.Color.White;
            flowLayoutPanelDoubleBufferedcs1.Controls.Add(labelDate);
            flowLayoutPanelDoubleBufferedcs1.Controls.Add(DownArrow);
            flowLayoutPanelDoubleBufferedcs1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            flowLayoutPanelDoubleBufferedcs1.Location = new System.Drawing.Point(219, 9);
            flowLayoutPanelDoubleBufferedcs1.Margin = new Padding(5, 4, 5, 4);
            flowLayoutPanelDoubleBufferedcs1.Name = "flowLayoutPanelDoubleBufferedcs1";
            flowLayoutPanelDoubleBufferedcs1.Size = new System.Drawing.Size(490, 35);
            flowLayoutPanelDoubleBufferedcs1.TabIndex = 0;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Cursor = Cursors.Hand;
            labelDate.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelDate.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelDate.Location = new System.Drawing.Point(0, 4);
            labelDate.Margin = new Padding(0, 4, 0, 0);
            labelDate.Name = "labelDate";
            labelDate.Size = new System.Drawing.Size(164, 25);
            labelDate.TabIndex = 60;
            labelDate.Text = "Day,00 Week,Year";
            labelDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            labelDate.Click += labelDate_Click;
            labelDate.MouseLeave += labelDate_MouseLeave;
            labelDate.MouseMove += labelDate_MouseMove;
            // 
            // DownArrow
            // 
            DownArrow.BackgroundImage = (System.Drawing.Image)resources.GetObject("DownArrow.BackgroundImage");
            DownArrow.BackgroundImageLayout = ImageLayout.Zoom;
            DownArrow.Cursor = Cursors.Hand;
            DownArrow.Location = new System.Drawing.Point(164, 3);
            DownArrow.Margin = new Padding(0, 3, 0, 0);
            DownArrow.Name = "DownArrow";
            DownArrow.Size = new System.Drawing.Size(31, 27);
            DownArrow.TabIndex = 61;
            DownArrow.TabStop = false;
            DownArrow.Click += labelDate_Click;
            DownArrow.MouseLeave += labelDate_MouseLeave;
            DownArrow.MouseMove += labelDate_MouseMove;
            // 
            // buttonPrevious
            // 
            buttonPrevious.Anchor = AnchorStyles.None;
            buttonPrevious.BackColor = System.Drawing.Color.Transparent;
            buttonPrevious.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonPrevious.BackgroundImage");
            buttonPrevious.BackgroundImageLayout = ImageLayout.Zoom;
            buttonPrevious.Cursor = Cursors.Hand;
            buttonPrevious.FlatAppearance.BorderColor = System.Drawing.Color.White;
            buttonPrevious.FlatAppearance.BorderSize = 0;
            buttonPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(229, 226, 244);
            buttonPrevious.FlatStyle = FlatStyle.Flat;
            buttonPrevious.ForeColor = System.Drawing.Color.Transparent;
            buttonPrevious.Location = new System.Drawing.Point(139, 6);
            buttonPrevious.Margin = new Padding(5, 4, 5, 4);
            buttonPrevious.Name = "buttonPrevious";
            buttonPrevious.Size = new System.Drawing.Size(30, 41);
            buttonPrevious.TabIndex = 57;
            buttonPrevious.UseVisualStyleBackColor = false;
            buttonPrevious.Click += buttonPrevious_Click;
            // 
            // buttonNext
            // 
            buttonNext.Anchor = AnchorStyles.None;
            buttonNext.BackColor = System.Drawing.Color.Transparent;
            buttonNext.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonNext.BackgroundImage");
            buttonNext.BackgroundImageLayout = ImageLayout.Zoom;
            buttonNext.Cursor = Cursors.Hand;
            buttonNext.FlatAppearance.BorderColor = System.Drawing.Color.White;
            buttonNext.FlatAppearance.BorderSize = 0;
            buttonNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(229, 226, 244);
            buttonNext.FlatStyle = FlatStyle.Flat;
            buttonNext.ForeColor = System.Drawing.Color.Transparent;
            buttonNext.Location = new System.Drawing.Point(179, 6);
            buttonNext.Margin = new Padding(5, 4, 5, 4);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new System.Drawing.Size(30, 41);
            buttonNext.TabIndex = 58;
            buttonNext.UseVisualStyleBackColor = false;
            buttonNext.Click += buttonNext_Click;
            // 
            // progressBar1
            // 
            TLPUp.SetColumnSpan(progressBar1, 7);
            progressBar1.Dock = DockStyle.Fill;
            progressBar1.Location = new System.Drawing.Point(0, 53);
            progressBar1.Margin = new Padding(0);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(1317, 3);
            progressBar1.TabIndex = 751;
            // 
            // UCSchedule
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TLPGlobal);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UCSchedule";
            Size = new System.Drawing.Size(1317, 891);
            TLPGlobal.ResumeLayout(false);
            TLPUp.ResumeLayout(false);
            FLPMembers.ResumeLayout(false);
            FLPMembers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMember).EndInit();
            flowLayoutPanelDoubleBufferedcs1.ResumeLayout(false);
            flowLayoutPanelDoubleBufferedcs1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrow).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        private System.Windows.Forms.Button buttonToday;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDoubleBufferedcs1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.PictureBox DownArrow;
        private System.Windows.Forms.Button buttonPrevious;
        private TableLayoutPanel TLPUp;
        private System.Windows.Forms.FlowLayoutPanel FLPMembers;
        private System.Windows.Forms.Label labelMember;
        private System.Windows.Forms.PictureBox pictureBoxMember;
        private System.Windows.Forms.ComboBox comboBoxDaysOrWeek;
        private ProgressBar progressBar1;
    }
}