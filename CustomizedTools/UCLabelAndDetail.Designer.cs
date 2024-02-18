namespace CustomizedTools
{
    partial class UCLabelAndDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelDetail = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.12987F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.87013F));
            this.tableLayoutPanel1.Controls.Add(this.labelDetail, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelType, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 42);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelDetail
            // 
            this.labelDetail.BackColor = System.Drawing.Color.Transparent;
            this.labelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetail.ForeColor = System.Drawing.Color.Black;
            this.labelDetail.Location = new System.Drawing.Point(282, 0);
            this.labelDetail.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.labelDetail.Name = "labelDetail";
            this.labelDetail.Size = new System.Drawing.Size(340, 42);
            this.labelDetail.TabIndex = 1;
            this.labelDetail.Text = "Details";
            this.labelDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelType
            // 
            this.labelType.BackColor = System.Drawing.Color.Transparent;
            this.labelType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.labelType.Location = new System.Drawing.Point(0, 0);
            this.labelType.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(279, 42);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "Type";
            this.labelType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UCLabelAndDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCLabelAndDetail";
            this.Size = new System.Drawing.Size(622, 42);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label labelDetail;
        public System.Windows.Forms.Label labelType;
    }
}
