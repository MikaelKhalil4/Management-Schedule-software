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
            labelIncome = new System.Windows.Forms.Label();
            labelTotalIncome = new System.Windows.Forms.Label();
            panelIncomeFilter = new System.Windows.Forms.Panel();
            labelSession = new System.Windows.Forms.Label();
            labelTotalNumberOfSessions = new System.Windows.Forms.Label();
            TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            TLPGLobalIncom.SuspendLayout();
            TLPIncome.SuspendLayout();
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
            TLPGLobalIncom.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGLobalIncom.Location = new System.Drawing.Point(0, 0);
            TLPGLobalIncom.Margin = new System.Windows.Forms.Padding(0);
            TLPGLobalIncom.Name = "TLPGLobalIncom";
            TLPGLobalIncom.RowCount = 2;
            TLPGLobalIncom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.5255661F));
            TLPGLobalIncom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.4744339F));
            TLPGLobalIncom.Size = new System.Drawing.Size(1410, 841);
            TLPGLobalIncom.TabIndex = 0;
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
            TLPGLobalIncom.SetRowSpan(TLPIncome, 2);
            TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPIncome.Size = new System.Drawing.Size(179, 841);
            TLPIncome.TabIndex = 41;
            // 
            // labelIncome
            // 
            labelIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            labelIncome.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelIncome.ForeColor = System.Drawing.Color.Black;
            labelIncome.Location = new System.Drawing.Point(0, 0);
            labelIncome.Margin = new System.Windows.Forms.Padding(0);
            labelIncome.Name = "labelIncome";
            labelIncome.Size = new System.Drawing.Size(179, 33);
            labelIncome.TabIndex = 0;
            labelIncome.Text = "Total Income";
            labelIncome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalIncome
            // 
            labelTotalIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            labelTotalIncome.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTotalIncome.ForeColor = System.Drawing.Color.Lime;
            labelTotalIncome.Location = new System.Drawing.Point(4, 33);
            labelTotalIncome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelTotalIncome.Name = "labelTotalIncome";
            labelTotalIncome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            labelTotalIncome.Size = new System.Drawing.Size(171, 48);
            labelTotalIncome.TabIndex = 1;
            labelTotalIncome.Text = "+$3000000";
            labelTotalIncome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelIncomeFilter
            // 
            panelIncomeFilter.AutoScroll = true;
            panelIncomeFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelIncomeFilter.Location = new System.Drawing.Point(0, 157);
            panelIncomeFilter.Margin = new System.Windows.Forms.Padding(0);
            panelIncomeFilter.Name = "panelIncomeFilter";
            panelIncomeFilter.Size = new System.Drawing.Size(179, 684);
            panelIncomeFilter.TabIndex = 33;
            // 
            // labelSession
            // 
            labelSession.Dock = System.Windows.Forms.DockStyle.Fill;
            labelSession.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelSession.ForeColor = System.Drawing.Color.Black;
            labelSession.Location = new System.Drawing.Point(0, 81);
            labelSession.Margin = new System.Windows.Forms.Padding(0);
            labelSession.Name = "labelSession";
            labelSession.Size = new System.Drawing.Size(179, 38);
            labelSession.TabIndex = 35;
            labelSession.Text = "Total Services";
            labelSession.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalNumberOfSessions
            // 
            labelTotalNumberOfSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            labelTotalNumberOfSessions.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTotalNumberOfSessions.ForeColor = System.Drawing.Color.Lime;
            labelTotalNumberOfSessions.Location = new System.Drawing.Point(4, 119);
            labelTotalNumberOfSessions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelTotalNumberOfSessions.Name = "labelTotalNumberOfSessions";
            labelTotalNumberOfSessions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            labelTotalNumberOfSessions.Size = new System.Drawing.Size(171, 38);
            labelTotalNumberOfSessions.TabIndex = 1;
            labelTotalNumberOfSessions.Text = "89";
            labelTotalNumberOfSessions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TLPGlobal
            // 
            TLPGlobal.BackColor = System.Drawing.Color.White;
            TLPGlobal.ColumnCount = 1;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.Controls.Add(TLPGLobalIncom, 0, 0);
            TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 0);
            TLPGlobal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 1;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            TLPGlobal.Size = new System.Drawing.Size(1410, 841);
            TLPGlobal.TabIndex = 2;
            // 
            // Statistics
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(1410, 841);
            Controls.Add(TLPGlobal);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Statistics";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Statistics";
            TLPGLobalIncom.ResumeLayout(false);
            TLPIncome.ResumeLayout(false);
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
    }
}