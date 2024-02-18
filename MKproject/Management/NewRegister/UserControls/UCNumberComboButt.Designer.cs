namespace MKproject.Management
{
    partial class UCNumberComboButt
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
            this.TLPTimeline = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxUnit = new System.Windows.Forms.ComboBox();
            this.ucPureNumber1 = new UCNumberButt();
            this.TLPTimeline.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPTimeline
            // 
            this.TLPTimeline.BackColor = System.Drawing.Color.Transparent;
            this.TLPTimeline.ColumnCount = 2;
            this.TLPTimeline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.09091F));
            this.TLPTimeline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.90909F));
            this.TLPTimeline.Controls.Add(this.ucPureNumber1, 0, 0);
            this.TLPTimeline.Controls.Add(this.comboBoxUnit, 1, 0);
            this.TLPTimeline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPTimeline.Location = new System.Drawing.Point(0, 0);
            this.TLPTimeline.Name = "TLPTimeline";
            this.TLPTimeline.RowCount = 1;
            this.TLPTimeline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPTimeline.Size = new System.Drawing.Size(220, 44);
            this.TLPTimeline.TabIndex = 19;
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.comboBoxUnit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxUnit.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.Location = new System.Drawing.Point(130, 5);
            this.comboBoxUnit.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(89, 33);
            this.comboBoxUnit.TabIndex = 13;
            // 
            // ucPureNumber1
            // 
            this.ucPureNumber1.BackColor = System.Drawing.Color.Transparent;
            this.ucPureNumber1.ButtonSizeMinus = new System.Drawing.Size(27, 30);
            this.ucPureNumber1.ButtonSizePlus = new System.Drawing.Size(27, 30);
            this.ucPureNumber1.IsNegative = false;
            this.ucPureNumber1.Location = new System.Drawing.Point(0, 0);
            this.ucPureNumber1.Margin = new System.Windows.Forms.Padding(0);
            this.ucPureNumber1.Maximum_number = 999;
            this.ucPureNumber1.Minimum_number = 0;
            this.ucPureNumber1.Name = "ucPureNumber1";
            this.ucPureNumber1.Number = 0;
            this.ucPureNumber1.Size = new System.Drawing.Size(130, 44);
            this.ucPureNumber1.TabIndex = 17;
            this.ucPureNumber1.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.ucPureNumber1.TextBoxFont = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold);
            // 
            // UCNumberComboButt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.TLPTimeline);
            this.Name = "UCNumberComboButt";
            this.Size = new System.Drawing.Size(220, 44);
            this.TLPTimeline.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ComboBox comboBoxUnit;
        public UCNumberButt ucPureNumber1;
        public System.Windows.Forms.TableLayoutPanel TLPTimeline;
    }
}
