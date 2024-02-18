using CustomizedTools;

namespace CustomizedTools
{
    partial class UCTextBoxFilterOriginal
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
            this.TLPJob = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBox = new TextBoxWithPlaceHolder();
            this.TLPJob.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPJob
            // 
            this.TLPJob.ColumnCount = 1;
            this.TLPJob.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPJob.Controls.Add(this.textBox, 0, 1);
            this.TLPJob.Controls.Add(this.labelTitle, 0, 0);
            this.TLPJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPJob.Location = new System.Drawing.Point(0, 0);
            this.TLPJob.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.TLPJob.Name = "TLPJob";
            this.TLPJob.RowCount = 2;
            this.TLPJob.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TLPJob.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TLPJob.Size = new System.Drawing.Size(173, 57);
            this.TLPJob.TabIndex = 14;
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(170, 20);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.White;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.textBox.Location = new System.Drawing.Point(3, 25);
            this.textBox.Name = "textBox";
            this.textBox.PlaceholderText = "";
            this.textBox.Size = new System.Drawing.Size(167, 29);
            this.textBox.TabIndex = 32;
            this.textBox.Click += new System.EventHandler(this.textBox_Click);
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // UCTextBoxFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TLPJob);
            this.Name = "UCTextBoxFilter";
            this.Size = new System.Drawing.Size(173, 57);
            this.TLPJob.ResumeLayout(false);
            this.TLPJob.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel TLPJob;
        public TextBoxWithPlaceHolder textBox;
        public System.Windows.Forms.Label labelTitle;
    }
}
