namespace MKproject.Schedule
{
    partial class ChooseService
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
            TLPglobal = new System.Windows.Forms.TableLayoutPanel();
            labelFullName = new System.Windows.Forms.Label();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            buttonChoose = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            ucSlideButton = new CustomizedTools.UCSlideButton();
            TLPglobal.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TLPglobal
            // 
            TLPglobal.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPglobal.ColumnCount = 1;
            TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPglobal.Controls.Add(labelFullName, 0, 0);
            TLPglobal.Controls.Add(flowLayoutPanel1, 0, 3);
            TLPglobal.Controls.Add(ucSlideButton, 0, 1);
            TLPglobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPglobal.Location = new System.Drawing.Point(0, 0);
            TLPglobal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPglobal.Name = "TLPglobal";
            TLPglobal.RowCount = 4;
            TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            TLPglobal.Size = new System.Drawing.Size(447, 437);
            TLPglobal.TabIndex = 1;
            // 
            // labelFullName
            // 
            labelFullName.Anchor = System.Windows.Forms.AnchorStyles.None;
            labelFullName.AutoSize = true;
            labelFullName.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelFullName.Location = new System.Drawing.Point(175, 9);
            labelFullName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new System.Drawing.Size(96, 20);
            labelFullName.TabIndex = 11;
            labelFullName.Text = "Mikael khalil";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonChoose);
            flowLayoutPanel1.Controls.Add(buttonCancel);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(4, 392);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(439, 42);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // buttonChoose
            // 
            buttonChoose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonChoose.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonChoose.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonChoose.FlatAppearance.BorderSize = 0;
            buttonChoose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 142, 244);
            buttonChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonChoose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonChoose.ForeColor = System.Drawing.Color.White;
            buttonChoose.Location = new System.Drawing.Point(331, 4);
            buttonChoose.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            buttonChoose.Name = "buttonChoose";
            buttonChoose.Size = new System.Drawing.Size(108, 33);
            buttonChoose.TabIndex = 732;
            buttonChoose.Text = "Choose";
            buttonChoose.UseVisualStyleBackColor = false;
            buttonChoose.Click += buttonChoose_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonCancel.BackColor = System.Drawing.Color.FromArgb(95, 97, 99);
            buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(105, 107, 109);
            buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCancel.ForeColor = System.Drawing.Color.White;
            buttonCancel.Location = new System.Drawing.Point(215, 3);
            buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 8, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(108, 33);
            buttonCancel.TabIndex = 737;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ucSlideButton
            // 
            ucSlideButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            ucSlideButton.BackColor = System.Drawing.Color.FromArgb(139, 152, 224);
            ucSlideButton.Button1text = "Available Package";
            ucSlideButton.Button2text = "Services";
            ucSlideButton.ClickedButton = null;
            ucSlideButton.Location = new System.Drawing.Point(67, 45);
            ucSlideButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            ucSlideButton.Name = "ucSlideButton";
            ucSlideButton.Size = new System.Drawing.Size(313, 45);
            ucSlideButton.TabIndex = 0;
            // 
            // ChooseService
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(447, 437);
            Controls.Add(TLPglobal);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChooseService";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ChooseService";
            FormClosing += ChooseService_FormClosing;
            TLPglobal.ResumeLayout(false);
            TLPglobal.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPglobal;
        private CustomizedTools.UCSlideButton ucSlideButton;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonChoose;
        private System.Windows.Forms.Button buttonCancel;
    }
}