namespace CustomizedTools
{
    partial class UCComboBoxFilterOriginal
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
            TLP = new System.Windows.Forms.TableLayoutPanel();
            comboBoxDetail = new System.Windows.Forms.ComboBox();
            labelTitle = new System.Windows.Forms.Label();
            TLP.SuspendLayout();
            SuspendLayout();
            // 
            // TLP
            // 
            TLP.ColumnCount = 1;
            TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLP.Controls.Add(comboBoxDetail, 0, 1);
            TLP.Controls.Add(labelTitle, 0, 0);
            TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            TLP.Location = new System.Drawing.Point(0, 0);
            TLP.Margin = new System.Windows.Forms.Padding(4, 12, 4, 3);
            TLP.Name = "TLP";
            TLP.RowCount = 2;
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            TLP.Size = new System.Drawing.Size(155, 66);
            TLP.TabIndex = 13;
            // 
            // comboBoxDetail
            // 
            comboBoxDetail.BackColor = System.Drawing.Color.White;
            comboBoxDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBoxDetail.Dock = System.Windows.Forms.DockStyle.Top;
            comboBoxDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            comboBoxDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBoxDetail.ForeColor = System.Drawing.Color.Black;
            comboBoxDetail.FormattingEnabled = true;
            comboBoxDetail.Location = new System.Drawing.Point(4, 29);
            comboBoxDetail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBoxDetail.Name = "comboBoxDetail";
            comboBoxDetail.Size = new System.Drawing.Size(147, 29);
            comboBoxDetail.TabIndex = 12;
            comboBoxDetail.SelectedIndexChanged += comboBoxDetail_SelectedIndexChanged;
            comboBoxDetail.DropDownClosed += comboBoxDetail_DropDownClosed;
            // 
            // labelTitle
            // 
            labelTitle.BackColor = System.Drawing.Color.Transparent;
            labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTitle.Location = new System.Drawing.Point(0, 0);
            labelTitle.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(151, 23);
            labelTitle.TabIndex = 2;
            labelTitle.Text = "Title";
            labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UCComboBoxFilterOriginal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(TLP);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UCComboBoxFilterOriginal";
            Size = new System.Drawing.Size(155, 66);
            TLP.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel TLP;
        public System.Windows.Forms.ComboBox comboBoxDetail;
        public System.Windows.Forms.Label labelTitle;
    }
}
