using CustomizedTools;

namespace MKproject.Management
{
    partial class EditEmployee
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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            buttonCancel = new CustomButton();
            buttonDelete = new CustomButton();
            buttonSave = new CustomButton();
            FLPTop = new System.Windows.Forms.FlowLayoutPanel();
            ucTextboxFirstName = new UCTextbox1();
            ucTextboxLastName = new UCTextbox1();
            ucTextboxPhoneNumber = new UCTextbox1();
            ucTextboxPassword = new UCTextbox1();
            groupBoxFeatures = new CustomGroupBox();
            FLPFeatures = new System.Windows.Forms.FlowLayoutPanel();
            checkBoxStatus = new System.Windows.Forms.CheckBox();
            timer1 = new System.Windows.Forms.Timer(components);
            checkBoxScheduleMember = new System.Windows.Forms.CheckBox();
            TLPMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            FLPTop.SuspendLayout();
            groupBoxFeatures.SuspendLayout();
            SuspendLayout();
            // 
            // TLPMain
            // 
            TLPMain.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPMain.ColumnCount = 1;
            TLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPMain.Controls.Add(tableLayoutPanel1, 0, 1);
            TLPMain.Controls.Add(FLPTop, 0, 0);
            TLPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPMain.Location = new System.Drawing.Point(0, 0);
            TLPMain.Margin = new System.Windows.Forms.Padding(0);
            TLPMain.Name = "TLPMain";
            TLPMain.RowCount = 2;
            TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 99.99999F));
            TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            TLPMain.Size = new System.Drawing.Size(507, 616);
            TLPMain.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            tableLayoutPanel1.Controls.Add(buttonCancel, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonDelete, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonSave, 2, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 576);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(507, 40);
            tableLayoutPanel1.TabIndex = 7;
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
            buttonCancel.Location = new System.Drawing.Point(307, 5);
            buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(93, 29);
            buttonCancel.TabIndex = 737;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
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
            buttonDelete.Location = new System.Drawing.Point(4, 5);
            buttonDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new System.Drawing.Size(93, 29);
            buttonDelete.TabIndex = 739;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
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
            buttonSave.Location = new System.Drawing.Point(410, 5);
            buttonSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(93, 29);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // FLPTop
            // 
            FLPTop.Controls.Add(ucTextboxFirstName);
            FLPTop.Controls.Add(ucTextboxLastName);
            FLPTop.Controls.Add(ucTextboxPhoneNumber);
            FLPTop.Controls.Add(ucTextboxPassword);
            FLPTop.Controls.Add(groupBoxFeatures);
            FLPTop.Controls.Add(checkBoxScheduleMember);
            FLPTop.Controls.Add(checkBoxStatus);
            FLPTop.Dock = System.Windows.Forms.DockStyle.Fill;
            FLPTop.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            FLPTop.Location = new System.Drawing.Point(0, 0);
            FLPTop.Margin = new System.Windows.Forms.Padding(0);
            FLPTop.Name = "FLPTop";
            FLPTop.Size = new System.Drawing.Size(507, 576);
            FLPTop.TabIndex = 5;
            // 
            // ucTextboxFirstName
            // 
            ucTextboxFirstName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ucTextboxFirstName.HasRightEmailFormat = true;
            ucTextboxFirstName.Index = 0;
            ucTextboxFirstName.IsEmail = false;
            ucTextboxFirstName.IsPhoneNumber = false;
            ucTextboxFirstName.IsRequired = false;
            ucTextboxFirstName.Location = new System.Drawing.Point(4, 6);
            ucTextboxFirstName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 0);
            ucTextboxFirstName.Name = "ucTextboxFirstName";
            ucTextboxFirstName.NextControl = null;
            ucTextboxFirstName.ParentOfNextControl = null;
            ucTextboxFirstName.Size = new System.Drawing.Size(490, 69);
            ucTextboxFirstName.StringType = null;
            ucTextboxFirstName.TabIndex = 0;
            ucTextboxFirstName.Value = null;
            // 
            // ucTextboxLastName
            // 
            ucTextboxLastName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ucTextboxLastName.HasRightEmailFormat = true;
            ucTextboxLastName.Index = 0;
            ucTextboxLastName.IsEmail = false;
            ucTextboxLastName.IsPhoneNumber = false;
            ucTextboxLastName.IsRequired = false;
            ucTextboxLastName.Location = new System.Drawing.Point(4, 75);
            ucTextboxLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            ucTextboxLastName.Name = "ucTextboxLastName";
            ucTextboxLastName.NextControl = null;
            ucTextboxLastName.ParentOfNextControl = null;
            ucTextboxLastName.Size = new System.Drawing.Size(490, 69);
            ucTextboxLastName.StringType = null;
            ucTextboxLastName.TabIndex = 1;
            ucTextboxLastName.Value = null;
            // 
            // ucTextboxPhoneNumber
            // 
            ucTextboxPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ucTextboxPhoneNumber.HasRightEmailFormat = true;
            ucTextboxPhoneNumber.Index = 0;
            ucTextboxPhoneNumber.IsEmail = false;
            ucTextboxPhoneNumber.IsPhoneNumber = false;
            ucTextboxPhoneNumber.IsRequired = false;
            ucTextboxPhoneNumber.Location = new System.Drawing.Point(4, 144);
            ucTextboxPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            ucTextboxPhoneNumber.Name = "ucTextboxPhoneNumber";
            ucTextboxPhoneNumber.NextControl = null;
            ucTextboxPhoneNumber.ParentOfNextControl = null;
            ucTextboxPhoneNumber.Size = new System.Drawing.Size(490, 69);
            ucTextboxPhoneNumber.StringType = null;
            ucTextboxPhoneNumber.TabIndex = 2;
            ucTextboxPhoneNumber.Value = null;
            // 
            // ucTextboxPassword
            // 
            ucTextboxPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ucTextboxPassword.HasRightEmailFormat = true;
            ucTextboxPassword.Index = 0;
            ucTextboxPassword.IsEmail = false;
            ucTextboxPassword.IsPhoneNumber = false;
            ucTextboxPassword.IsRequired = false;
            ucTextboxPassword.Location = new System.Drawing.Point(4, 213);
            ucTextboxPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            ucTextboxPassword.Name = "ucTextboxPassword";
            ucTextboxPassword.NextControl = null;
            ucTextboxPassword.ParentOfNextControl = null;
            ucTextboxPassword.Size = new System.Drawing.Size(490, 69);
            ucTextboxPassword.StringType = null;
            ucTextboxPassword.TabIndex = 3;
            ucTextboxPassword.Value = null;
            // 
            // groupBoxFeatures
            // 
            groupBoxFeatures.BorderColor = System.Drawing.Color.Transparent;
            groupBoxFeatures.BorderSize = 1;
            groupBoxFeatures.Controls.Add(FLPFeatures);
            groupBoxFeatures.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBoxFeatures.Location = new System.Drawing.Point(4, 288);
            groupBoxFeatures.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBoxFeatures.Name = "groupBoxFeatures";
            groupBoxFeatures.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxFeatures.Size = new System.Drawing.Size(490, 194);
            groupBoxFeatures.TabIndex = 8;
            groupBoxFeatures.TabStop = false;
            groupBoxFeatures.Text = "Features";
            // 
            // FLPFeatures
            // 
            FLPFeatures.AutoScroll = true;
            FLPFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            FLPFeatures.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            FLPFeatures.Location = new System.Drawing.Point(4, 29);
            FLPFeatures.Margin = new System.Windows.Forms.Padding(0);
            FLPFeatures.Name = "FLPFeatures";
            FLPFeatures.Size = new System.Drawing.Size(482, 162);
            FLPFeatures.TabIndex = 0;
            FLPFeatures.WrapContents = false;
            // 
            // checkBoxStatus
            // 
            checkBoxStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            checkBoxStatus.AutoSize = true;
            checkBoxStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxStatus.Location = new System.Drawing.Point(212, 531);
            checkBoxStatus.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            checkBoxStatus.Name = "checkBoxStatus";
            checkBoxStatus.Size = new System.Drawing.Size(74, 25);
            checkBoxStatus.TabIndex = 1;
            checkBoxStatus.Text = "Status";
            checkBoxStatus.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // checkBoxScheduleMember
            // 
            checkBoxScheduleMember.Anchor = System.Windows.Forms.AnchorStyles.None;
            checkBoxScheduleMember.AutoSize = true;
            checkBoxScheduleMember.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxScheduleMember.Location = new System.Drawing.Point(167, 494);
            checkBoxScheduleMember.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            checkBoxScheduleMember.Name = "checkBoxScheduleMember";
            checkBoxScheduleMember.Size = new System.Drawing.Size(163, 25);
            checkBoxScheduleMember.TabIndex = 9;
            checkBoxScheduleMember.Text = "Schedule Member";
            checkBoxScheduleMember.UseVisualStyleBackColor = true;
            // 
            // EditEmployee
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(507, 616);
            Controls.Add(TLPMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditEmployee";
            Opacity = 0D;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "EditEmployee";
            FormClosing += EditEmployee_FormClosing;
            TLPMain.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            FLPTop.ResumeLayout(false);
            FLPTop.PerformLayout();
            groupBoxFeatures.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private UCTextbox1 ucTextboxFirstName;
        private UCTextbox1 ucTextboxLastName;
        private UCTextbox1 ucTextboxPhoneNumber;
        private UCTextbox1 ucTextboxPassword;
        public CustomGroupBox groupBoxFeatures;
        private System.Windows.Forms.FlowLayoutPanel FLPFeatures;
        private System.Windows.Forms.TableLayoutPanel TLPMain;
        private CustomButton buttonSave;
        private System.Windows.Forms.FlowLayoutPanel FLPTop;
        private System.Windows.Forms.CheckBox checkBoxStatus;
        private System.Windows.Forms.Timer timer1;
        private CustomButton buttonCancel;
        private CustomButton buttonDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxScheduleMember;
    }
}