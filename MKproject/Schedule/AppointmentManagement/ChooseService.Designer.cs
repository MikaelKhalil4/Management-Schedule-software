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
            this.TLPglobal = new System.Windows.Forms.TableLayoutPanel();
            this.ucSlideButton = new CustomizedTools.UCSlideButton();
            this.TLPglobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPglobal
            // 
            this.TLPglobal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPglobal.ColumnCount = 1;
            this.TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 451F));
            this.TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPglobal.Controls.Add(this.ucSlideButton, 0, 0);
            this.TLPglobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPglobal.Location = new System.Drawing.Point(0, 0);
            this.TLPglobal.Name = "TLPglobal";
            this.TLPglobal.RowCount = 2;
            this.TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.TLPglobal.Size = new System.Drawing.Size(502, 379);
            this.TLPglobal.TabIndex = 1;
            // 
            // ucSlideButton
            // 
            this.ucSlideButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucSlideButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(224)))));
            this.ucSlideButton.Button1text = "Available Package";
            this.ucSlideButton.Button2text = "New Service";
            this.ucSlideButton.Location = new System.Drawing.Point(117, 3);
            this.ucSlideButton.Name = "ucSlideButton";
            this.ucSlideButton.Size = new System.Drawing.Size(268, 39);
            this.ucSlideButton.TabIndex = 0;
            // 
            // ChooseService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 379);
            this.Controls.Add(this.TLPglobal);
            this.Name = "ChooseService";
            this.Text = "ChooseService";
            this.TLPglobal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPglobal;
        private CustomizedTools.UCSlideButton ucSlideButton;
    }
}