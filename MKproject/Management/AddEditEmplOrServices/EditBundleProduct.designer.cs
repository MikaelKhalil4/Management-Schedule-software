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
            this.components = new System.ComponentModel.Container();
            this.TLPMain = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.FLPTop = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxPrice = new CustomizedTools.CustomGroupBox();
            this.ucPaymentsPrice = new MKproject.Management.UCPayments();
            this.groupBoxNumberOfSessions = new CustomizedTools.CustomGroupBox();
            this.TLPBundle = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxBundle = new System.Windows.Forms.ComboBox();
            this.UCNOSessionsOrDay = new MKproject.Management.UCNumberButt();
            this.checkBoxMemberShip = new System.Windows.Forms.CheckBox();
            this.checkBoxStatus = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TLPMain.SuspendLayout();
            this.FLPTop.SuspendLayout();
            this.groupBoxPrice.SuspendLayout();
            this.groupBoxNumberOfSessions.SuspendLayout();
            this.TLPBundle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPMain
            // 
            this.TLPMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPMain.ColumnCount = 1;
            this.TLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPMain.Controls.Add(this.FLPTop, 0, 0);
            this.TLPMain.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.TLPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPMain.Location = new System.Drawing.Point(0, 0);
            this.TLPMain.Margin = new System.Windows.Forms.Padding(0);
            this.TLPMain.Name = "TLPMain";
            this.TLPMain.RowCount = 2;
            this.TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.TLPMain.Size = new System.Drawing.Size(435, 574);
            this.TLPMain.TabIndex = 0;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(3, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(103, 29);
            this.buttonDelete.TabIndex = 738;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(97)))), ((int)(((byte)(99)))));
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(234, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(93, 29);
            this.buttonCancel.TabIndex = 737;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click_1);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(112)))), ((int)(((byte)(214)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(334, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(98, 29);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FLPTop
            // 
            this.FLPTop.AutoScroll = true;
            this.FLPTop.Controls.Add(this.groupBoxPrice);
            this.FLPTop.Controls.Add(this.groupBoxNumberOfSessions);
            this.FLPTop.Controls.Add(this.checkBoxMemberShip);
            this.FLPTop.Controls.Add(this.checkBoxStatus);
            this.FLPTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPTop.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLPTop.Location = new System.Drawing.Point(0, 0);
            this.FLPTop.Margin = new System.Windows.Forms.Padding(0);
            this.FLPTop.Name = "FLPTop";
            this.FLPTop.Size = new System.Drawing.Size(435, 536);
            this.FLPTop.TabIndex = 5;
            // 
            // groupBoxPrice
            // 
            this.groupBoxPrice.BorderColor = System.Drawing.Color.White;
            this.groupBoxPrice.BorderSize = 1;
            this.groupBoxPrice.Controls.Add(this.ucPaymentsPrice);
            this.groupBoxPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPrice.Location = new System.Drawing.Point(3, 10);
            this.groupBoxPrice.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.groupBoxPrice.Name = "groupBoxPrice";
            this.groupBoxPrice.Size = new System.Drawing.Size(420, 100);
            this.groupBoxPrice.TabIndex = 7;
            this.groupBoxPrice.TabStop = false;
            // 
            // ucPaymentsPrice
            // 
            this.ucPaymentsPrice.Amount = 0D;
            this.ucPaymentsPrice.BackColor = System.Drawing.Color.Transparent;
            this.ucPaymentsPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaymentsPrice.EditModeOn = true;
            this.ucPaymentsPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucPaymentsPrice.Location = new System.Drawing.Point(3, 29);
            this.ucPaymentsPrice.Margin = new System.Windows.Forms.Padding(6);
            this.ucPaymentsPrice.Name = "ucPaymentsPrice";
            this.ucPaymentsPrice.Sign = "+";
            this.ucPaymentsPrice.Size = new System.Drawing.Size(414, 68);
            this.ucPaymentsPrice.TabIndex = 4;
            // 
            // groupBoxNumberOfSessions
            // 
            this.groupBoxNumberOfSessions.BorderColor = System.Drawing.Color.White;
            this.groupBoxNumberOfSessions.BorderSize = 1;
            this.groupBoxNumberOfSessions.Controls.Add(this.TLPBundle);
            this.groupBoxNumberOfSessions.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNumberOfSessions.Location = new System.Drawing.Point(3, 130);
            this.groupBoxNumberOfSessions.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.groupBoxNumberOfSessions.Name = "groupBoxNumberOfSessions";
            this.groupBoxNumberOfSessions.Size = new System.Drawing.Size(420, 100);
            this.groupBoxNumberOfSessions.TabIndex = 8;
            this.groupBoxNumberOfSessions.TabStop = false;
            this.groupBoxNumberOfSessions.Text = "Bundle";
            // 
            // TLPBundle
            // 
            this.TLPBundle.ColumnCount = 2;
            this.TLPBundle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBundle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBundle.Controls.Add(this.comboBoxBundle, 0, 0);
            this.TLPBundle.Controls.Add(this.UCNOSessionsOrDay, 1, 0);
            this.TLPBundle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPBundle.Location = new System.Drawing.Point(3, 29);
            this.TLPBundle.Name = "TLPBundle";
            this.TLPBundle.RowCount = 1;
            this.TLPBundle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBundle.Size = new System.Drawing.Size(414, 68);
            this.TLPBundle.TabIndex = 0;
            // 
            // comboBoxBundle
            // 
            this.comboBoxBundle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxBundle.BackColor = System.Drawing.Color.White;
            this.comboBoxBundle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxBundle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBundle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxBundle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBundle.ForeColor = System.Drawing.Color.Black;
            this.comboBoxBundle.FormattingEnabled = true;
            this.comboBoxBundle.Location = new System.Drawing.Point(66, 15);
            this.comboBoxBundle.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.comboBoxBundle.Name = "comboBoxBundle";
            this.comboBoxBundle.Size = new System.Drawing.Size(126, 38);
            this.comboBoxBundle.TabIndex = 13;
            this.comboBoxBundle.DropDown += new System.EventHandler(this.comboBoxDetail_DropDown);
            this.comboBoxBundle.SelectedIndexChanged += new System.EventHandler(this.comboBoxDetail_SelectedIndexChanged);
            // 
            // UCNOSessionsOrDay
            // 
            this.UCNOSessionsOrDay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UCNOSessionsOrDay.BackColor = System.Drawing.Color.Transparent;
            this.UCNOSessionsOrDay.ButtonSizeMinus = new System.Drawing.Size(37, 46);
            this.UCNOSessionsOrDay.ButtonSizePlus = new System.Drawing.Size(38, 46);
            this.UCNOSessionsOrDay.IsNegative = false;
            this.UCNOSessionsOrDay.Location = new System.Drawing.Point(207, 11);
            this.UCNOSessionsOrDay.Margin = new System.Windows.Forms.Padding(0);
            this.UCNOSessionsOrDay.Maximum_number = 999;
            this.UCNOSessionsOrDay.Minimum_number = 0;
            this.UCNOSessionsOrDay.Name = "UCNOSessionsOrDay";
            this.UCNOSessionsOrDay.Number = 0;
            this.UCNOSessionsOrDay.Size = new System.Drawing.Size(162, 46);
            this.UCNOSessionsOrDay.TabIndex = 14;
            this.UCNOSessionsOrDay.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.UCNOSessionsOrDay.TextBoxFont = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // checkBoxMemberShip
            // 
            this.checkBoxMemberShip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxMemberShip.AutoSize = true;
            this.checkBoxMemberShip.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMemberShip.Location = new System.Drawing.Point(151, 250);
            this.checkBoxMemberShip.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.checkBoxMemberShip.Name = "checkBoxMemberShip";
            this.checkBoxMemberShip.Size = new System.Drawing.Size(124, 25);
            this.checkBoxMemberShip.TabIndex = 1;
            this.checkBoxMemberShip.Text = "MemberShip";
            this.checkBoxMemberShip.UseVisualStyleBackColor = true;
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxStatus.AutoSize = true;
            this.checkBoxStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStatus.Location = new System.Drawing.Point(176, 295);
            this.checkBoxStatus.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.checkBoxStatus.Name = "checkBoxStatus";
            this.checkBoxStatus.Size = new System.Drawing.Size(74, 25);
            this.checkBoxStatus.TabIndex = 1;
            this.checkBoxStatus.Text = "Status";
            this.checkBoxStatus.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelete, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 536);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(435, 38);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // EditBundleProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 574);
            this.Controls.Add(this.TLPMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditBundleProduct";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditBundle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditBundleProduct_FormClosing);
            this.TLPMain.ResumeLayout(false);
            this.FLPTop.ResumeLayout(false);
            this.FLPTop.PerformLayout();
            this.groupBoxPrice.ResumeLayout(false);
            this.groupBoxNumberOfSessions.ResumeLayout(false);
            this.TLPBundle.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPMain;
        private System.Windows.Forms.Button buttonSave;
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
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}