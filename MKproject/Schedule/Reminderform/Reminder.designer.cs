using CustomizedTools;

namespace MKproject.Schedule
{
    partial class Reminder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reminder));
            TLPReminder = new System.Windows.Forms.TableLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            flowLayoutPanelDoubleBufferedcs1 = new System.Windows.Forms.FlowLayoutPanel();
            labelDate = new System.Windows.Forms.Label();
            DownArrowDate = new System.Windows.Forms.PictureBox();
            label = new System.Windows.Forms.Label();
            panelDaysofTheWeek = new System.Windows.Forms.Panel();
            checkBoxMonday = new System.Windows.Forms.CheckBox();
            checkBoxSunday = new System.Windows.Forms.CheckBox();
            checkBoxTuesday = new System.Windows.Forms.CheckBox();
            checkBoxSaturday = new System.Windows.Forms.CheckBox();
            checkBoxWednesday = new System.Windows.Forms.CheckBox();
            checkBoxFriday = new System.Windows.Forms.CheckBox();
            checkBoxThursday = new System.Windows.Forms.CheckBox();
            panel6 = new System.Windows.Forms.Panel();
            TBLRepeat = new System.Windows.Forms.TableLayoutPanel();
            labelrepeat = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            labelStartTime = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            textBoxSearch = new TextBoxWithPlaceHolder();
            textBoxReminder = new TextBoxWithPlaceHolder();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            panel5 = new System.Windows.Forms.Panel();
            ButtonCancel = new CustomButton();
            ButtonDone = new CustomButton();
            labelQuote = new System.Windows.Forms.Label();
            TLPReminder.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanelDoubleBufferedcs1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrowDate).BeginInit();
            panelDaysofTheWeek.SuspendLayout();
            panel6.SuspendLayout();
            TBLRepeat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // TLPReminder
            // 
            TLPReminder.ColumnCount = 1;
            TLPReminder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPReminder.Controls.Add(panel1, 0, 3);
            TLPReminder.Controls.Add(panelDaysofTheWeek, 0, 2);
            TLPReminder.Controls.Add(panel6, 0, 1);
            TLPReminder.Controls.Add(panel2, 0, 0);
            TLPReminder.Controls.Add(panel5, 0, 5);
            TLPReminder.Controls.Add(labelQuote, 0, 4);
            TLPReminder.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPReminder.Location = new System.Drawing.Point(0, 0);
            TLPReminder.Margin = new System.Windows.Forms.Padding(0);
            TLPReminder.Name = "TLPReminder";
            TLPReminder.RowCount = 6;
            TLPReminder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            TLPReminder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            TLPReminder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            TLPReminder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            TLPReminder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            TLPReminder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            TLPReminder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            TLPReminder.Size = new System.Drawing.Size(418, 451);
            TLPReminder.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanelDoubleBufferedcs1);
            panel1.Controls.Add(label);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 265);
            panel1.Margin = new System.Windows.Forms.Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(418, 64);
            panel1.TabIndex = 75;
            // 
            // flowLayoutPanelDoubleBufferedcs1
            // 
            flowLayoutPanelDoubleBufferedcs1.Controls.Add(labelDate);
            flowLayoutPanelDoubleBufferedcs1.Controls.Add(DownArrowDate);
            flowLayoutPanelDoubleBufferedcs1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            flowLayoutPanelDoubleBufferedcs1.Location = new System.Drawing.Point(142, 18);
            flowLayoutPanelDoubleBufferedcs1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanelDoubleBufferedcs1.Name = "flowLayoutPanelDoubleBufferedcs1";
            flowLayoutPanelDoubleBufferedcs1.Size = new System.Drawing.Size(204, 22);
            flowLayoutPanelDoubleBufferedcs1.TabIndex = 73;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Cursor = System.Windows.Forms.Cursors.Hand;
            labelDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelDate.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelDate.Location = new System.Drawing.Point(4, 0);
            labelDate.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            labelDate.Name = "labelDate";
            labelDate.Size = new System.Drawing.Size(118, 17);
            labelDate.TabIndex = 60;
            labelDate.Text = "Day,00 Week,Year";
            labelDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            labelDate.Click += labelDate_Click;
            // 
            // DownArrowDate
            // 
            DownArrowDate.BackgroundImage = (System.Drawing.Image)resources.GetObject("DownArrowDate.BackgroundImage");
            DownArrowDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            DownArrowDate.Cursor = System.Windows.Forms.Cursors.Hand;
            DownArrowDate.Image = (System.Drawing.Image)resources.GetObject("DownArrowDate.Image");
            DownArrowDate.Location = new System.Drawing.Point(122, 0);
            DownArrowDate.Margin = new System.Windows.Forms.Padding(0);
            DownArrowDate.Name = "DownArrowDate";
            DownArrowDate.Size = new System.Drawing.Size(27, 22);
            DownArrowDate.TabIndex = 61;
            DownArrowDate.TabStop = false;
            DownArrowDate.Click += labelDate_Click;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label.Location = new System.Drawing.Point(15, 18);
            label.Margin = new System.Windows.Forms.Padding(6);
            label.Name = "label";
            label.Size = new System.Drawing.Size(39, 17);
            label.TabIndex = 72;
            label.Text = "Date:";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelDaysofTheWeek
            // 
            panelDaysofTheWeek.Controls.Add(checkBoxMonday);
            panelDaysofTheWeek.Controls.Add(checkBoxSunday);
            panelDaysofTheWeek.Controls.Add(checkBoxTuesday);
            panelDaysofTheWeek.Controls.Add(checkBoxSaturday);
            panelDaysofTheWeek.Controls.Add(checkBoxWednesday);
            panelDaysofTheWeek.Controls.Add(checkBoxFriday);
            panelDaysofTheWeek.Controls.Add(checkBoxThursday);
            panelDaysofTheWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            panelDaysofTheWeek.Location = new System.Drawing.Point(0, 199);
            panelDaysofTheWeek.Margin = new System.Windows.Forms.Padding(0);
            panelDaysofTheWeek.Name = "panelDaysofTheWeek";
            panelDaysofTheWeek.Size = new System.Drawing.Size(418, 66);
            panelDaysofTheWeek.TabIndex = 74;
            // 
            // checkBoxMonday
            // 
            checkBoxMonday.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            checkBoxMonday.AutoSize = true;
            checkBoxMonday.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxMonday.FlatAppearance.BorderColor = System.Drawing.Color.White;
            checkBoxMonday.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            checkBoxMonday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            checkBoxMonday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxMonday.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            checkBoxMonday.Location = new System.Drawing.Point(23, 13);
            checkBoxMonday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxMonday.Name = "checkBoxMonday";
            checkBoxMonday.Size = new System.Drawing.Size(67, 19);
            checkBoxMonday.TabIndex = 0;
            checkBoxMonday.Text = "Monday";
            checkBoxMonday.UseVisualStyleBackColor = true;
            checkBoxMonday.CheckedChanged += checkBoxMonday_CheckedChanged;
            // 
            // checkBoxSunday
            // 
            checkBoxSunday.AutoSize = true;
            checkBoxSunday.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxSunday.FlatAppearance.BorderColor = System.Drawing.Color.White;
            checkBoxSunday.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            checkBoxSunday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            checkBoxSunday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxSunday.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            checkBoxSunday.Location = new System.Drawing.Point(23, 38);
            checkBoxSunday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxSunday.Name = "checkBoxSunday";
            checkBoxSunday.Size = new System.Drawing.Size(63, 19);
            checkBoxSunday.TabIndex = 0;
            checkBoxSunday.Text = "Sunday";
            checkBoxSunday.UseVisualStyleBackColor = true;
            checkBoxSunday.CheckedChanged += checkBoxMonday_CheckedChanged;
            // 
            // checkBoxTuesday
            // 
            checkBoxTuesday.AutoSize = true;
            checkBoxTuesday.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxTuesday.FlatAppearance.BorderColor = System.Drawing.Color.White;
            checkBoxTuesday.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            checkBoxTuesday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            checkBoxTuesday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxTuesday.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            checkBoxTuesday.Location = new System.Drawing.Point(98, 13);
            checkBoxTuesday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxTuesday.Name = "checkBoxTuesday";
            checkBoxTuesday.Size = new System.Drawing.Size(67, 19);
            checkBoxTuesday.TabIndex = 0;
            checkBoxTuesday.Text = "Tuesday";
            checkBoxTuesday.UseVisualStyleBackColor = true;
            checkBoxTuesday.CheckedChanged += checkBoxMonday_CheckedChanged;
            // 
            // checkBoxSaturday
            // 
            checkBoxSaturday.AutoSize = true;
            checkBoxSaturday.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxSaturday.FlatAppearance.BorderColor = System.Drawing.Color.White;
            checkBoxSaturday.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            checkBoxSaturday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            checkBoxSaturday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxSaturday.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            checkBoxSaturday.Location = new System.Drawing.Point(98, 38);
            checkBoxSaturday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxSaturday.Name = "checkBoxSaturday";
            checkBoxSaturday.Size = new System.Drawing.Size(72, 19);
            checkBoxSaturday.TabIndex = 0;
            checkBoxSaturday.Text = "Saturday";
            checkBoxSaturday.UseVisualStyleBackColor = true;
            checkBoxSaturday.CheckedChanged += checkBoxMonday_CheckedChanged;
            // 
            // checkBoxWednesday
            // 
            checkBoxWednesday.Anchor = System.Windows.Forms.AnchorStyles.Top;
            checkBoxWednesday.AutoSize = true;
            checkBoxWednesday.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxWednesday.FlatAppearance.BorderColor = System.Drawing.Color.White;
            checkBoxWednesday.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            checkBoxWednesday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            checkBoxWednesday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxWednesday.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            checkBoxWednesday.Location = new System.Drawing.Point(173, 13);
            checkBoxWednesday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxWednesday.Name = "checkBoxWednesday";
            checkBoxWednesday.Size = new System.Drawing.Size(87, 19);
            checkBoxWednesday.TabIndex = 0;
            checkBoxWednesday.Text = "Wednesday";
            checkBoxWednesday.UseVisualStyleBackColor = true;
            checkBoxWednesday.CheckedChanged += checkBoxMonday_CheckedChanged;
            // 
            // checkBoxFriday
            // 
            checkBoxFriday.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            checkBoxFriday.AutoSize = true;
            checkBoxFriday.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxFriday.FlatAppearance.BorderColor = System.Drawing.Color.White;
            checkBoxFriday.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            checkBoxFriday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            checkBoxFriday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxFriday.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            checkBoxFriday.Location = new System.Drawing.Point(349, 13);
            checkBoxFriday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxFriday.Name = "checkBoxFriday";
            checkBoxFriday.Size = new System.Drawing.Size(56, 19);
            checkBoxFriday.TabIndex = 0;
            checkBoxFriday.Text = "Friday";
            checkBoxFriday.UseVisualStyleBackColor = true;
            checkBoxFriday.CheckedChanged += checkBoxMonday_CheckedChanged;
            // 
            // checkBoxThursday
            // 
            checkBoxThursday.AutoSize = true;
            checkBoxThursday.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxThursday.FlatAppearance.BorderColor = System.Drawing.Color.White;
            checkBoxThursday.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            checkBoxThursday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            checkBoxThursday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxThursday.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            checkBoxThursday.Location = new System.Drawing.Point(268, 13);
            checkBoxThursday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxThursday.Name = "checkBoxThursday";
            checkBoxThursday.Size = new System.Drawing.Size(73, 19);
            checkBoxThursday.TabIndex = 0;
            checkBoxThursday.Text = "Thursday";
            checkBoxThursday.UseVisualStyleBackColor = true;
            checkBoxThursday.CheckedChanged += checkBoxMonday_CheckedChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(TBLRepeat);
            panel6.Controls.Add(labelStartTime);
            panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Location = new System.Drawing.Point(0, 129);
            panel6.Margin = new System.Windows.Forms.Padding(0);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(418, 70);
            panel6.TabIndex = 12;
            // 
            // TBLRepeat
            // 
            TBLRepeat.BackColor = System.Drawing.Color.FromArgb(206, 220, 255);
            TBLRepeat.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            TBLRepeat.ColumnCount = 2;
            TBLRepeat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.51948F));
            TBLRepeat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.48052F));
            TBLRepeat.Controls.Add(labelrepeat, 0, 0);
            TBLRepeat.Controls.Add(pictureBox1, 1, 0);
            TBLRepeat.Cursor = System.Windows.Forms.Cursors.Hand;
            TBLRepeat.Location = new System.Drawing.Point(142, 15);
            TBLRepeat.Name = "TBLRepeat";
            TBLRepeat.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            TBLRepeat.RowCount = 1;
            TBLRepeat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TBLRepeat.Size = new System.Drawing.Size(140, 26);
            TBLRepeat.TabIndex = 73;
            // 
            // labelrepeat
            // 
            labelrepeat.AutoSize = true;
            labelrepeat.BackColor = System.Drawing.Color.FromArgb(206, 220, 255);
            labelrepeat.Cursor = System.Windows.Forms.Cursors.Hand;
            labelrepeat.Dock = System.Windows.Forms.DockStyle.Fill;
            labelrepeat.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelrepeat.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelrepeat.Location = new System.Drawing.Point(1, 1);
            labelrepeat.Margin = new System.Windows.Forms.Padding(0);
            labelrepeat.Name = "labelrepeat";
            labelrepeat.Size = new System.Drawing.Size(110, 22);
            labelrepeat.TabIndex = 65;
            labelrepeat.Text = "Does not repeat";
            labelrepeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelrepeat.Click += flowLayoutPanelRepeat_Click;
            labelrepeat.MouseLeave += flowLayoutPanelRepeat_MouseLeave;
            labelrepeat.MouseMove += flowLayoutPanelRepeat_MouseMove;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(206, 220, 255);
            pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox1.Location = new System.Drawing.Point(112, 1);
            pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(27, 22);
            pictureBox1.TabIndex = 64;
            pictureBox1.TabStop = false;
            pictureBox1.Click += flowLayoutPanelRepeat_Click;
            pictureBox1.MouseLeave += flowLayoutPanelRepeat_MouseLeave;
            pictureBox1.MouseMove += flowLayoutPanelRepeat_MouseMove;
            // 
            // labelStartTime
            // 
            labelStartTime.AutoSize = true;
            labelStartTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelStartTime.Location = new System.Drawing.Point(15, 18);
            labelStartTime.Margin = new System.Windows.Forms.Padding(6);
            labelStartTime.Name = "labelStartTime";
            labelStartTime.Size = new System.Drawing.Size(53, 17);
            labelStartTime.TabIndex = 72;
            labelStartTime.Text = "Repeat:";
            labelStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBoxSearch);
            panel2.Controls.Add(textBoxReminder);
            panel2.Controls.Add(pictureBox4);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(418, 129);
            panel2.TabIndex = 11;
            // 
            // textBoxSearch
            // 
            textBoxSearch.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            textBoxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            textBoxSearch.IsRequiredModeOn = false;
            textBoxSearch.Location = new System.Drawing.Point(71, 14);
            textBoxSearch.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "By name or phone (Optional)";
            textBoxSearch.Size = new System.Drawing.Size(304, 29);
            textBoxSearch.TabIndex = 32;
            textBoxSearch.Text = "By name or phone (Optional)";
            textBoxSearch.Click += textBoxSearch_Click;
            // 
            // textBoxReminder
            // 
            textBoxReminder.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            textBoxReminder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxReminder.ForeColor = System.Drawing.Color.Gray;
            textBoxReminder.IsRequiredModeOn = false;
            textBoxReminder.Location = new System.Drawing.Point(71, 58);
            textBoxReminder.Margin = new System.Windows.Forms.Padding(2);
            textBoxReminder.Multiline = true;
            textBoxReminder.Name = "textBoxReminder";
            textBoxReminder.PlaceholderText = "Add Reminder...";
            textBoxReminder.Size = new System.Drawing.Size(304, 57);
            textBoxReminder.TabIndex = 13;
            textBoxReminder.Text = "Add Reminder...";
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox4.ErrorImage = (System.Drawing.Image)resources.GetObject("pictureBox4.ErrorImage");
            pictureBox4.Location = new System.Drawing.Point(33, 14);
            pictureBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(18, 29);
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(ButtonCancel);
            panel5.Controls.Add(ButtonDone);
            panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            panel5.Location = new System.Drawing.Point(0, 406);
            panel5.Margin = new System.Windows.Forms.Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(418, 45);
            panel5.TabIndex = 72;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            ButtonCancel.BackAndMouseHoverColor = System.Drawing.Color.Empty;
            ButtonCancel.BackColor = System.Drawing.Color.FromArgb(95, 97, 99);
            ButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            ButtonCancel.FlatAppearance.BorderSize = 0;
            ButtonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 0, 0);
            ButtonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ButtonCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ButtonCancel.ForeColor = System.Drawing.Color.White;
            ButtonCancel.Location = new System.Drawing.Point(231, 6);
            ButtonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new System.Drawing.Size(83, 29);
            ButtonCancel.TabIndex = 2;
            ButtonCancel.Text = "Cancel";
            ButtonCancel.UseVisualStyleBackColor = false;
            ButtonCancel.Click += ButtonCancel_Click;
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
            ButtonDone.Location = new System.Drawing.Point(329, 6);
            ButtonDone.Margin = new System.Windows.Forms.Padding(4, 3, 6, 3);
            ButtonDone.Name = "ButtonDone";
            ButtonDone.Size = new System.Drawing.Size(83, 29);
            ButtonDone.TabIndex = 1;
            ButtonDone.Text = "Done";
            ButtonDone.UseVisualStyleBackColor = false;
            ButtonDone.Click += buttonD_Click;
            // 
            // labelQuote
            // 
            labelQuote.Anchor = System.Windows.Forms.AnchorStyles.None;
            labelQuote.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            labelQuote.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            labelQuote.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelQuote.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            labelQuote.Location = new System.Drawing.Point(51, 337);
            labelQuote.Margin = new System.Windows.Forms.Padding(0);
            labelQuote.Name = "labelQuote";
            labelQuote.Size = new System.Drawing.Size(316, 61);
            labelQuote.TabIndex = 71;
            labelQuote.Text = "Only for today";
            labelQuote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Reminder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            ClientSize = new System.Drawing.Size(418, 451);
            Controls.Add(TLPReminder);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Reminder";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reminder";
            TLPReminder.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanelDoubleBufferedcs1.ResumeLayout(false);
            flowLayoutPanelDoubleBufferedcs1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DownArrowDate).EndInit();
            panelDaysofTheWeek.ResumeLayout(false);
            panelDaysofTheWeek.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            TBLRepeat.ResumeLayout(false);
            TBLRepeat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label labelQuote;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.CheckBox checkBoxMonday;
        public System.Windows.Forms.CheckBox checkBoxTuesday;
        public System.Windows.Forms.CheckBox checkBoxWednesday;
        public System.Windows.Forms.CheckBox checkBoxThursday;
        public System.Windows.Forms.CheckBox checkBoxFriday;
        public System.Windows.Forms.Label labelrepeat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        public TextBoxWithPlaceHolder textBoxReminder;
        public TextBoxWithPlaceHolder textBoxSearch;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.FlowLayoutPanel FlowlayoutpanelDate;
        public System.Windows.Forms.CheckBox checkBoxSaturday;
        public System.Windows.Forms.CheckBox checkBoxSunday;
        public System.Windows.Forms.Panel panelDaysofTheWeek;
        public System.Windows.Forms.TableLayoutPanel TBLRepeat;
        public System.Windows.Forms.TableLayoutPanel TLPReminder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panel5;
        private CustomButton ButtonCancel;
        private CustomButton ButtonDone;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDoubleBufferedcs1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.PictureBox DownArrowDate;
    }
}