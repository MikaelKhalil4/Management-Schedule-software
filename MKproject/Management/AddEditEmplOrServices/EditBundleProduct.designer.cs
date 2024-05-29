using CustomizedTools;

namespace MKproject.Management
{
    partial class EditBundleProduct
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
            TLPMain = new System.Windows.Forms.TableLayoutPanel();
            FLPTop = new System.Windows.Forms.FlowLayoutPanel();
            groupBoxPrice = new CustomGroupBox();
            ucPaymentsPrice = new UCPayments();
            groupBoxNumberOfSessions = new CustomGroupBox();
            TLPBundle = new System.Windows.Forms.TableLayoutPanel();
            comboBoxBundle = new System.Windows.Forms.ComboBox();
            UCNOSessionsOrDay = new UCNumberButt();
            checkBoxMemberShip = new System.Windows.Forms.CheckBox();
            checkBoxStatus = new System.Windows.Forms.CheckBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            buttonSave = new CustomButton();
            buttonCancel = new CustomButton();
            buttonDelete = new CustomButton();
            timer1 = new System.Windows.Forms.Timer(components);
            TLPMain.SuspendLayout();
            FLPTop.SuspendLayout();
            groupBoxPrice.SuspendLayout();
            groupBoxNumberOfSessions.SuspendLayout();
            TLPBundle.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TLPMain
            // 
            TLPMain.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPMain.ColumnCount = 1;
            TLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPMain.Controls.Add(FLPTop, 0, 0);
            TLPMain.Controls.Add(tableLayoutPanel1, 0, 1);
            TLPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPMain.Location = new System.Drawing.Point(0, 0);
            TLPMain.Margin = new System.Windows.Forms.Padding(0);
            TLPMain.Name = "TLPMain";
            TLPMain.RowCount = 2;
            TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            TLPMain.Size = new System.Drawing.Size(507, 592);
            TLPMain.TabIndex = 0;
            // 
            // FLPTop
            // 
            FLPTop.AutoScroll = true;
            FLPTop.Controls.Add(groupBoxPrice);
            FLPTop.Controls.Add(groupBoxNumberOfSessions);
            FLPTop.Controls.Add(checkBoxMemberShip);
            FLPTop.Controls.Add(checkBoxStatus);
            FLPTop.Dock = System.Windows.Forms.DockStyle.Fill;
            FLPTop.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            FLPTop.Location = new System.Drawing.Point(0, 0);
            FLPTop.Margin = new System.Windows.Forms.Padding(0);
            FLPTop.Name = "FLPTop";
            FLPTop.Size = new System.Drawing.Size(507, 554);
            FLPTop.TabIndex = 5;
            // 
            // groupBoxPrice
            // 
            groupBoxPrice.BorderColor = System.Drawing.Color.White;
            groupBoxPrice.BorderSize = 1;
            groupBoxPrice.Controls.Add(ucPaymentsPrice);
            groupBoxPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBoxPrice.Location = new System.Drawing.Point(4, 12);
            groupBoxPrice.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            groupBoxPrice.Name = "groupBoxPrice";
            groupBoxPrice.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxPrice.Size = new System.Drawing.Size(490, 90);
            groupBoxPrice.TabIndex = 7;
            groupBoxPrice.TabStop = false;
            // 
            // ucPaymentsPrice
            // 
            ucPaymentsPrice.Amount = 0D;
            ucPaymentsPrice.BackColor = System.Drawing.Color.Transparent;
            ucPaymentsPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPaymentsPrice.EditModeOn = true;
            ucPaymentsPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ucPaymentsPrice.Location = new System.Drawing.Point(4, 29);
            ucPaymentsPrice.Margin = new System.Windows.Forms.Padding(7);
            ucPaymentsPrice.Name = "ucPaymentsPrice";
            ucPaymentsPrice.Sign = "+";
            ucPaymentsPrice.Size = new System.Drawing.Size(482, 58);
            ucPaymentsPrice.TabIndex = 4;
            // 
            // groupBoxNumberOfSessions
            // 
            groupBoxNumberOfSessions.BorderColor = System.Drawing.Color.White;
            groupBoxNumberOfSessions.BorderSize = 1;
            groupBoxNumberOfSessions.Controls.Add(TLPBundle);
            groupBoxNumberOfSessions.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBoxNumberOfSessions.Location = new System.Drawing.Point(4, 126);
            groupBoxNumberOfSessions.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            groupBoxNumberOfSessions.Name = "groupBoxNumberOfSessions";
            groupBoxNumberOfSessions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxNumberOfSessions.Size = new System.Drawing.Size(490, 115);
            groupBoxNumberOfSessions.TabIndex = 8;
            groupBoxNumberOfSessions.TabStop = false;
            groupBoxNumberOfSessions.Text = "Bundle";
            // 
            // TLPBundle
            // 
            TLPBundle.ColumnCount = 2;
            TLPBundle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPBundle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPBundle.Controls.Add(comboBoxBundle, 0, 0);
            TLPBundle.Controls.Add(UCNOSessionsOrDay, 1, 0);
            TLPBundle.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPBundle.Location = new System.Drawing.Point(4, 29);
            TLPBundle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPBundle.Name = "TLPBundle";
            TLPBundle.RowCount = 1;
            TLPBundle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPBundle.Size = new System.Drawing.Size(482, 83);
            TLPBundle.TabIndex = 0;
            // 
            // comboBoxBundle
            // 
            comboBoxBundle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            comboBoxBundle.BackColor = System.Drawing.Color.White;
            comboBoxBundle.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBoxBundle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxBundle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            comboBoxBundle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            comboBoxBundle.ForeColor = System.Drawing.Color.Black;
            comboBoxBundle.FormattingEnabled = true;
            comboBoxBundle.Location = new System.Drawing.Point(77, 22);
            comboBoxBundle.Margin = new System.Windows.Forms.Padding(0, 0, 18, 0);
            comboBoxBundle.Name = "comboBoxBundle";
            comboBoxBundle.Size = new System.Drawing.Size(146, 38);
            comboBoxBundle.TabIndex = 13;
            comboBoxBundle.DropDown += comboBoxDetail_DropDown;
            comboBoxBundle.SelectedIndexChanged += comboBoxDetail_SelectedIndexChanged;
            // 
            // UCNOSessionsOrDay
            // 
            UCNOSessionsOrDay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            UCNOSessionsOrDay.BackColor = System.Drawing.Color.Transparent;
            UCNOSessionsOrDay.ButtonSizeMinus = new System.Drawing.Size(43, 48);
            UCNOSessionsOrDay.ButtonSizePlus = new System.Drawing.Size(44, 48);
            UCNOSessionsOrDay.IsNegative = false;
            UCNOSessionsOrDay.Location = new System.Drawing.Point(241, 17);
            UCNOSessionsOrDay.Margin = new System.Windows.Forms.Padding(0);
            UCNOSessionsOrDay.Maximum_number = 999;
            UCNOSessionsOrDay.Minimum_number = 0;
            UCNOSessionsOrDay.Name = "UCNOSessionsOrDay";
            UCNOSessionsOrDay.Number = 0;
            UCNOSessionsOrDay.Size = new System.Drawing.Size(189, 48);
            UCNOSessionsOrDay.TabIndex = 14;
            UCNOSessionsOrDay.TextBoxBackColor = System.Drawing.SystemColors.Window;
            UCNOSessionsOrDay.TextBoxFont = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            // 
            // checkBoxMemberShip
            // 
            checkBoxMemberShip.Anchor = System.Windows.Forms.AnchorStyles.None;
            checkBoxMemberShip.AutoSize = true;
            checkBoxMemberShip.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxMemberShip.Location = new System.Drawing.Point(187, 265);
            checkBoxMemberShip.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            checkBoxMemberShip.Name = "checkBoxMemberShip";
            checkBoxMemberShip.Size = new System.Drawing.Size(124, 25);
            checkBoxMemberShip.TabIndex = 1;
            checkBoxMemberShip.Text = "MemberShip";
            checkBoxMemberShip.UseVisualStyleBackColor = true;
            // 
            // checkBoxStatus
            // 
            checkBoxStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            checkBoxStatus.AutoSize = true;
            checkBoxStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxStatus.Location = new System.Drawing.Point(212, 314);
            checkBoxStatus.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            checkBoxStatus.Name = "checkBoxStatus";
            checkBoxStatus.Size = new System.Drawing.Size(74, 25);
            checkBoxStatus.TabIndex = 1;
            checkBoxStatus.Text = "Status";
            checkBoxStatus.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel1.Controls.Add(buttonSave, 2, 0);
            tableLayoutPanel1.Controls.Add(buttonCancel, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonDelete, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 554);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(507, 38);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonSave.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonSave.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(69, 82, 184);
            buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(89, 102, 204);
            buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSave.ForeColor = System.Drawing.Color.White;
            buttonSave.Location = new System.Drawing.Point(410, 4);
            buttonSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(93, 29);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonCancel.BackAndMouseHoverColor = System.Drawing.Color.DarkGray;
            buttonCancel.BackColor = System.Drawing.Color.DarkGray;
            buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(129, 129, 129);
            buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(149, 149, 149);
            buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCancel.ForeColor = System.Drawing.Color.White;
            buttonCancel.Location = new System.Drawing.Point(309, 4);
            buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(93, 29);
            buttonCancel.TabIndex = 737;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click_1;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            buttonDelete.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(255, 50, 50);
            buttonDelete.BackColor = System.Drawing.Color.FromArgb(255, 50, 50);
            buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(215, 10, 10);
            buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 30, 30);
            buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonDelete.ForeColor = System.Drawing.Color.White;
            buttonDelete.Location = new System.Drawing.Point(4, 4);
            buttonDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new System.Drawing.Size(93, 29);
            buttonDelete.TabIndex = 738;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // EditBundleProduct
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(507, 592);
            Controls.Add(TLPMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditBundleProduct";
            Opacity = 0D;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "EditBundle";
            FormClosing += EditBundleProduct_FormClosing;
            TLPMain.ResumeLayout(false);
            FLPTop.ResumeLayout(false);
            FLPTop.PerformLayout();
            groupBoxPrice.ResumeLayout(false);
            groupBoxNumberOfSessions.ResumeLayout(false);
            TLPBundle.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPMain;
        private CustomButton buttonSave;
        private System.Windows.Forms.FlowLayoutPanel FLPTop;
        private System.Windows.Forms.CheckBox checkBoxStatus;
        private CustomGroupBox groupBoxNumberOfSessions;
        public CustomGroupBox groupBoxPrice;
        public UCPayments ucPaymentsPrice;
        public System.Windows.Forms.ComboBox comboBoxBundle;
        private System.Windows.Forms.TableLayoutPanel TLPBundle;
        private UCNumberButt UCNOSessionsOrDay;
        private System.Windows.Forms.CheckBox checkBoxMemberShip;
        private System.Windows.Forms.Timer timer1;
        private CustomButton buttonCancel;
        private CustomButton buttonDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}