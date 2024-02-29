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
            this.components = new System.ComponentModel.Container();
            this.TLPMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.FLPTop = new System.Windows.Forms.FlowLayoutPanel();
            this.ucTextboxFirstName = new CustomizedTools.UCTextbox1();
            this.ucTextboxLastName = new CustomizedTools.UCTextbox1();
            this.ucTextboxPhoneNumber = new CustomizedTools.UCTextbox1();
            this.ucTextboxPassword = new CustomizedTools.UCTextbox1();
            this.groupBoxFeatures = new CustomizedTools.CustomGroupBox();
            this.FLPFeatures = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxStatus = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TLPMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.FLPTop.SuspendLayout();
            this.groupBoxFeatures.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPMain
            // 
            this.TLPMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPMain.ColumnCount = 1;
            this.TLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPMain.Controls.Add(this.panelButtons, 0, 1);
            this.TLPMain.Controls.Add(this.FLPTop, 0, 0);
            this.TLPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPMain.Location = new System.Drawing.Point(0, 0);
            this.TLPMain.Margin = new System.Windows.Forms.Padding(0);
            this.TLPMain.Name = "TLPMain";
            this.TLPMain.RowCount = 2;
            this.TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 99.99999F));
            this.TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.TLPMain.Size = new System.Drawing.Size(435, 596);
            this.TLPMain.TabIndex = 9;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonDelete);
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Controls.Add(this.buttonSave);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 561);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(435, 35);
            this.panelButtons.TabIndex = 3;
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
            this.buttonDelete.Location = new System.Drawing.Point(6, 3);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(10, 5, 15, 5);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(103, 29);
            this.buttonDelete.TabIndex = 739;
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
            this.buttonCancel.Location = new System.Drawing.Point(235, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(93, 29);
            this.buttonCancel.TabIndex = 737;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
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
            this.buttonSave.Location = new System.Drawing.Point(334, 2);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(15, 5, 45, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(93, 29);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FLPTop
            // 
            this.FLPTop.Controls.Add(this.ucTextboxFirstName);
            this.FLPTop.Controls.Add(this.ucTextboxLastName);
            this.FLPTop.Controls.Add(this.ucTextboxPhoneNumber);
            this.FLPTop.Controls.Add(this.ucTextboxPassword);
            this.FLPTop.Controls.Add(this.groupBoxFeatures);
            this.FLPTop.Controls.Add(this.checkBoxStatus);
            this.FLPTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPTop.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLPTop.Location = new System.Drawing.Point(0, 0);
            this.FLPTop.Margin = new System.Windows.Forms.Padding(0);
            this.FLPTop.Name = "FLPTop";
            this.FLPTop.Size = new System.Drawing.Size(435, 561);
            this.FLPTop.TabIndex = 5;
            // 
            // ucTextboxFirstName
            // 
            this.ucTextboxFirstName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTextboxFirstName.HasRightEmailFormat = true;
            this.ucTextboxFirstName.Index = 0;
            this.ucTextboxFirstName.IsEmail = false;
            this.ucTextboxFirstName.IsPhoneNumber = false;
            this.ucTextboxFirstName.IsRequired = false;
            this.ucTextboxFirstName.Location = new System.Drawing.Point(3, 5);
            this.ucTextboxFirstName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.ucTextboxFirstName.Name = "ucTextboxFirstName";
            this.ucTextboxFirstName.NextControl = null;
            this.ucTextboxFirstName.ParentOfNextControl = null;
            this.ucTextboxFirstName.Size = new System.Drawing.Size(420, 75);
            this.ucTextboxFirstName.StringType = null;
            this.ucTextboxFirstName.TabIndex = 0;
            this.ucTextboxFirstName.Value = null;
            // 
            // ucTextboxLastName
            // 
            this.ucTextboxLastName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTextboxLastName.HasRightEmailFormat = true;
            this.ucTextboxLastName.Index = 0;
            this.ucTextboxLastName.IsEmail = false;
            this.ucTextboxLastName.IsPhoneNumber = false;
            this.ucTextboxLastName.IsRequired = false;
            this.ucTextboxLastName.Location = new System.Drawing.Point(3, 80);
            this.ucTextboxLastName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ucTextboxLastName.Name = "ucTextboxLastName";
            this.ucTextboxLastName.NextControl = null;
            this.ucTextboxLastName.ParentOfNextControl = null;
            this.ucTextboxLastName.Size = new System.Drawing.Size(420, 75);
            this.ucTextboxLastName.StringType = null;
            this.ucTextboxLastName.TabIndex = 1;
            this.ucTextboxLastName.Value = null;
            // 
            // ucTextboxPhoneNumber
            // 
            this.ucTextboxPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTextboxPhoneNumber.HasRightEmailFormat = true;
            this.ucTextboxPhoneNumber.Index = 0;
            this.ucTextboxPhoneNumber.IsEmail = false;
            this.ucTextboxPhoneNumber.IsPhoneNumber = false;
            this.ucTextboxPhoneNumber.IsRequired = false;
            this.ucTextboxPhoneNumber.Location = new System.Drawing.Point(3, 155);
            this.ucTextboxPhoneNumber.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ucTextboxPhoneNumber.Name = "ucTextboxPhoneNumber";
            this.ucTextboxPhoneNumber.NextControl = null;
            this.ucTextboxPhoneNumber.ParentOfNextControl = null;
            this.ucTextboxPhoneNumber.Size = new System.Drawing.Size(420, 75);
            this.ucTextboxPhoneNumber.StringType = null;
            this.ucTextboxPhoneNumber.TabIndex = 2;
            this.ucTextboxPhoneNumber.Value = null;
            // 
            // ucTextboxPassword
            // 
            this.ucTextboxPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTextboxPassword.HasRightEmailFormat = true;
            this.ucTextboxPassword.Index = 0;
            this.ucTextboxPassword.IsEmail = false;
            this.ucTextboxPassword.IsPhoneNumber = false;
            this.ucTextboxPassword.IsRequired = false;
            this.ucTextboxPassword.Location = new System.Drawing.Point(3, 230);
            this.ucTextboxPassword.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ucTextboxPassword.Name = "ucTextboxPassword";
            this.ucTextboxPassword.NextControl = null;
            this.ucTextboxPassword.ParentOfNextControl = null;
            this.ucTextboxPassword.Size = new System.Drawing.Size(420, 75);
            this.ucTextboxPassword.StringType = null;
            this.ucTextboxPassword.TabIndex = 3;
            this.ucTextboxPassword.Value = null;
            // 
            // groupBoxFeatures
            // 
            this.groupBoxFeatures.BorderColor = System.Drawing.Color.Transparent;
            this.groupBoxFeatures.BorderSize = 1;
            this.groupBoxFeatures.Controls.Add(this.FLPFeatures);
            this.groupBoxFeatures.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFeatures.Location = new System.Drawing.Point(3, 310);
            this.groupBoxFeatures.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBoxFeatures.Name = "groupBoxFeatures";
            this.groupBoxFeatures.Size = new System.Drawing.Size(420, 168);
            this.groupBoxFeatures.TabIndex = 8;
            this.groupBoxFeatures.TabStop = false;
            this.groupBoxFeatures.Text = "Features";
            // 
            // FLPFeatures
            // 
            this.FLPFeatures.AutoScroll = true;
            this.FLPFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPFeatures.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLPFeatures.Location = new System.Drawing.Point(3, 29);
            this.FLPFeatures.Margin = new System.Windows.Forms.Padding(0);
            this.FLPFeatures.Name = "FLPFeatures";
            this.FLPFeatures.Size = new System.Drawing.Size(414, 136);
            this.FLPFeatures.TabIndex = 0;
            this.FLPFeatures.WrapContents = false;
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxStatus.AutoSize = true;
            this.checkBoxStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStatus.Location = new System.Drawing.Point(176, 488);
            this.checkBoxStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
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
            // EditEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 596);
            this.Controls.Add(this.TLPMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditEmployee";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditEmployee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditEmployee_FormClosing);
            this.TLPMain.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.FLPTop.ResumeLayout(false);
            this.FLPTop.PerformLayout();
            this.groupBoxFeatures.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCTextbox1 ucTextboxFirstName;
        private UCTextbox1 ucTextboxLastName;
        private UCTextbox1 ucTextboxPhoneNumber;
        private UCTextbox1 ucTextboxPassword;
        public CustomGroupBox groupBoxFeatures;
        private System.Windows.Forms.FlowLayoutPanel FLPFeatures;
        private System.Windows.Forms.TableLayoutPanel TLPMain;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.FlowLayoutPanel FLPTop;
        private System.Windows.Forms.CheckBox checkBoxStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDelete;
    }
}