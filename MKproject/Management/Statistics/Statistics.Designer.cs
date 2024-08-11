namespace MKproject.Management
{
    partial class Statistics
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
            TLPGLobalIncom = new System.Windows.Forms.TableLayoutPanel();
            TLPIncome = new System.Windows.Forms.TableLayoutPanel();
            labelSession = new System.Windows.Forms.Label();
            labelTotalNumberOfSessions = new System.Windows.Forms.Label();
            labelIncome = new System.Windows.Forms.Label();
            labelTotalIncome = new System.Windows.Forms.Label();
            panelIncomeFilter = new System.Windows.Forms.Panel();
            TLPCheckBoxes = new System.Windows.Forms.TableLayoutPanel();
            checkBoxServices = new System.Windows.Forms.CheckBox();
            checkBoxIncome = new System.Windows.Forms.CheckBox();
            TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            TLPGLobalIncom.SuspendLayout();
            TLPIncome.SuspendLayout();
            TLPCheckBoxes.SuspendLayout();
            TLPGlobal.SuspendLayout();
            SuspendLayout();
            // 
            // TLPGLobalIncom
            // 
            TLPGLobalIncom.BackColor = System.Drawing.Color.Transparent;
            TLPGLobalIncom.ColumnCount = 2;
            TLPGLobalIncom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.7F));
            TLPGLobalIncom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.3F));
            TLPGLobalIncom.Controls.Add(TLPIncome, 0, 0);
            TLPGLobalIncom.Controls.Add(TLPCheckBoxes, 1, 1);
            TLPGLobalIncom.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGLobalIncom.Location = new System.Drawing.Point(0, 0);
            TLPGLobalIncom.Margin = new System.Windows.Forms.Padding(0);
            TLPGLobalIncom.Name = "TLPGLobalIncom";
            TLPGLobalIncom.RowCount = 3;
            TLPGLobalIncom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            TLPGLobalIncom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            TLPGLobalIncom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            TLPGLobalIncom.Size = new System.Drawing.Size(1611, 1121);
            TLPGLobalIncom.TabIndex = 0;
            TLPGLobalIncom.Resize += TLPGLobalIncom_Resize;
            // 
            // TLPIncome
            // 
            TLPIncome.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            TLPIncome.ColumnCount = 1;
            TLPIncome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPIncome.Controls.Add(labelSession, 0, 2);
            TLPIncome.Controls.Add(labelTotalNumberOfSessions, 0, 3);
            TLPIncome.Controls.Add(labelIncome, 0, 0);
            TLPIncome.Controls.Add(labelTotalIncome, 0, 1);
            TLPIncome.Controls.Add(panelIncomeFilter, 0, 4);
            TLPIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPIncome.Location = new System.Drawing.Point(0, 0);
            TLPIncome.Margin = new System.Windows.Forms.Padding(0);
            TLPIncome.Name = "TLPIncome";
            TLPIncome.RowCount = 5;
            TLPGLobalIncom.SetRowSpan(TLPIncome, 3);
            TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPIncome.Size = new System.Drawing.Size(204, 1121);
            TLPIncome.TabIndex = 41;
            // 
            // labelSession
            // 
            labelSession.Dock = System.Windows.Forms.DockStyle.Fill;
            labelSession.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelSession.ForeColor = System.Drawing.Color.Black;
            labelSession.Location = new System.Drawing.Point(0, 88);
            labelSession.Margin = new System.Windows.Forms.Padding(0);
            labelSession.Name = "labelSession";
            labelSession.Size = new System.Drawing.Size(204, 44);
            labelSession.TabIndex = 35;
            labelSession.Text = "Total Services";
            labelSession.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalNumberOfSessions
            // 
            labelTotalNumberOfSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            labelTotalNumberOfSessions.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTotalNumberOfSessions.ForeColor = System.Drawing.Color.Lime;
            labelTotalNumberOfSessions.Location = new System.Drawing.Point(5, 132);
            labelTotalNumberOfSessions.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            labelTotalNumberOfSessions.Name = "labelTotalNumberOfSessions";
            labelTotalNumberOfSessions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            labelTotalNumberOfSessions.Size = new System.Drawing.Size(194, 44);
            labelTotalNumberOfSessions.TabIndex = 1;
            labelTotalNumberOfSessions.Text = "89";
            labelTotalNumberOfSessions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelIncome
            // 
            labelIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            labelIncome.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelIncome.ForeColor = System.Drawing.Color.Black;
            labelIncome.Location = new System.Drawing.Point(0, 0);
            labelIncome.Margin = new System.Windows.Forms.Padding(0);
            labelIncome.Name = "labelIncome";
            labelIncome.Size = new System.Drawing.Size(204, 44);
            labelIncome.TabIndex = 0;
            labelIncome.Text = "Total Income";
            labelIncome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalIncome
            // 
            labelTotalIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            labelTotalIncome.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTotalIncome.ForeColor = System.Drawing.Color.Lime;
            labelTotalIncome.Location = new System.Drawing.Point(5, 44);
            labelTotalIncome.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            labelTotalIncome.Name = "labelTotalIncome";
            labelTotalIncome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            labelTotalIncome.Size = new System.Drawing.Size(194, 44);
            labelTotalIncome.TabIndex = 1;
            labelTotalIncome.Text = "+$3000000";
            labelTotalIncome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelIncomeFilter
            // 
            panelIncomeFilter.AutoScroll = true;
            panelIncomeFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelIncomeFilter.Location = new System.Drawing.Point(0, 176);
            panelIncomeFilter.Margin = new System.Windows.Forms.Padding(0);
            panelIncomeFilter.Name = "panelIncomeFilter";
            panelIncomeFilter.Size = new System.Drawing.Size(204, 945);
            panelIncomeFilter.TabIndex = 33;
            // 
            // TLPCheckBoxes
            // 
            TLPCheckBoxes.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            TLPCheckBoxes.ColumnCount = 1;
            TLPCheckBoxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPCheckBoxes.Controls.Add(checkBoxServices, 0, 1);
            TLPCheckBoxes.Controls.Add(checkBoxIncome, 0, 0);
            TLPCheckBoxes.Location = new System.Drawing.Point(1425, 490);
            TLPCheckBoxes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            TLPCheckBoxes.Name = "TLPCheckBoxes";
            TLPCheckBoxes.RowCount = 2;
            TLPCheckBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPCheckBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPCheckBoxes.Size = new System.Drawing.Size(183, 69);
            TLPCheckBoxes.TabIndex = 44;
            // 
            // checkBoxServices
            // 
            checkBoxServices.Anchor = System.Windows.Forms.AnchorStyles.Left;
            checkBoxServices.AutoSize = true;
            checkBoxServices.BackColor = System.Drawing.Color.White;
            checkBoxServices.Checked = true;
            checkBoxServices.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxServices.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxServices.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxServices.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            checkBoxServices.Location = new System.Drawing.Point(11, 38);
            checkBoxServices.Margin = new System.Windows.Forms.Padding(11, 4, 3, 4);
            checkBoxServices.Name = "checkBoxServices";
            checkBoxServices.Size = new System.Drawing.Size(169, 27);
            checkBoxServices.TabIndex = 43;
            checkBoxServices.Text = "Number of Services";
            checkBoxServices.UseVisualStyleBackColor = false;
            checkBoxServices.CheckedChanged += checkBoxServices_CheckedChanged;
            // 
            // checkBoxIncome
            // 
            checkBoxIncome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            checkBoxIncome.AutoSize = true;
            checkBoxIncome.BackColor = System.Drawing.Color.White;
            checkBoxIncome.Checked = true;
            checkBoxIncome.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxIncome.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxIncome.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBoxIncome.ForeColor = System.Drawing.Color.FromArgb(114, 189, 57);
            checkBoxIncome.Location = new System.Drawing.Point(11, 4);
            checkBoxIncome.Margin = new System.Windows.Forms.Padding(11, 4, 3, 4);
            checkBoxIncome.Name = "checkBoxIncome";
            checkBoxIncome.Size = new System.Drawing.Size(89, 26);
            checkBoxIncome.TabIndex = 42;
            checkBoxIncome.Text = "Income";
            checkBoxIncome.UseVisualStyleBackColor = false;
            checkBoxIncome.CheckedChanged += checkBoxIncome_CheckedChanged;
            // 
            // TLPGlobal
            // 
            TLPGlobal.BackColor = System.Drawing.Color.White;
            TLPGlobal.ColumnCount = 1;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.Controls.Add(TLPGLobalIncom, 0, 0);
            TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 0);
            TLPGlobal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 1;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            TLPGlobal.Size = new System.Drawing.Size(1611, 1121);
            TLPGlobal.TabIndex = 2;
            // 
            // Statistics
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(1611, 1121);
            Controls.Add(TLPGlobal);
            Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            Name = "Statistics";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Statistics";
            TLPGLobalIncom.ResumeLayout(false);
            TLPIncome.ResumeLayout(false);
            TLPCheckBoxes.ResumeLayout(false);
            TLPCheckBoxes.PerformLayout();
            TLPGlobal.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPGLobalIncom;
        private System.Windows.Forms.Label labelTotalNumberOfSessions;
        private System.Windows.Forms.TableLayoutPanel TLPIncome;
        private System.Windows.Forms.Label labelTotalIncome;
        public System.Windows.Forms.Panel panelIncomeFilter;
        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        public System.Windows.Forms.Label labelIncome;
        public System.Windows.Forms.Label labelSession;
        public System.Windows.Forms.CheckBox checkBoxIncome;
        public System.Windows.Forms.CheckBox checkBoxServices;
        private System.Windows.Forms.TableLayoutPanel TLPCheckBoxes;
    }
}