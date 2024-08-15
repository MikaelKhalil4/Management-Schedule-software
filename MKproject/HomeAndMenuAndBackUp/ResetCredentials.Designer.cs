namespace MKproject.HomeAndMenuAndBackUp
{
    partial class ResetCredentials
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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            UCTextboxTicketID = new CustomizedTools.UCTextbox1();
            buttonReset = new CustomizedTools.CustomButton();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(UCTextboxTicketID, 0, 1);
            tableLayoutPanel1.Controls.Add(buttonReset, 0, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.7065849F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.94012F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.1155777F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new System.Drawing.Size(531, 334);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Location = new System.Drawing.Point(3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(525, 156);
            label2.TabIndex = 9;
            label2.Text = "Oops! Something went wrong with your credentials during authentication.\r\nPlease contact the support team to send you the new ticket \r\nid to reset your credentials.";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCTextboxTicketID
            // 
            UCTextboxTicketID.BackColor = System.Drawing.Color.Transparent;
            UCTextboxTicketID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            UCTextboxTicketID.HasRightEmailFormat = true;
            UCTextboxTicketID.Index = 0;
            UCTextboxTicketID.IsEmail = false;
            UCTextboxTicketID.IsPhoneNumber = false;
            UCTextboxTicketID.IsRequired = true;
            UCTextboxTicketID.Location = new System.Drawing.Point(5, 164);
            UCTextboxTicketID.Margin = new System.Windows.Forms.Padding(5, 8, 5, 0);
            UCTextboxTicketID.Name = "UCTextboxTicketID";
            UCTextboxTicketID.NextControl = null;
            UCTextboxTicketID.ParentOfNextControl = null;
            UCTextboxTicketID.Size = new System.Drawing.Size(521, 92);
            UCTextboxTicketID.StringType = "TicketId";
            UCTextboxTicketID.TabIndex = 10;
            UCTextboxTicketID.Value = null;
            // 
            // buttonReset
            // 
            buttonReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonReset.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(128, 128, 255);
            buttonReset.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            buttonReset.FlatAppearance.BorderSize = 0;
            buttonReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(88, 88, 215);
            buttonReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(108, 108, 235);
            buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonReset.ForeColor = System.Drawing.Color.White;
            buttonReset.Location = new System.Drawing.Point(200, 276);
            buttonReset.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new System.Drawing.Size(111, 37);
            buttonReset.TabIndex = 11;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = false;
            buttonReset.Click += buttonReset_ClickAsync;
            // 
            // ResetCredentials
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            ClientSize = new System.Drawing.Size(531, 334);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ResetCredentials";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ResetCredentials";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private CustomizedTools.UCTextbox1 UCTextboxTicketID;
        private CustomizedTools.CustomButton buttonReset;
    }
}