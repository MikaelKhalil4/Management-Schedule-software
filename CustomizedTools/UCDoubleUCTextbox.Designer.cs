

namespace CustomizedTools
{
    partial class UCDoubleUCTextbox
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
            this.TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.ucTextbox1 = new UCTextbox1();
            this.ucTextbox2 = new UCTextbox1();
            this.TLPGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPGlobal
            // 
            this.TLPGlobal.ColumnCount = 2;
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPGlobal.Controls.Add(this.ucTextbox1, 0, 0);
            this.TLPGlobal.Controls.Add(this.ucTextbox2, 1, 0);
            this.TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPGlobal.Location = new System.Drawing.Point(0, 0);
            this.TLPGlobal.Name = "TLPGlobal";
            this.TLPGlobal.RowCount = 1;
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.TLPGlobal.Size = new System.Drawing.Size(600, 68);
            this.TLPGlobal.TabIndex = 0;
            // 
            // ucTextbox1
            // 
            this.ucTextbox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTextbox1.HasRightEmailFormat = true;
            this.ucTextbox1.Index = 0;
            this.ucTextbox1.IsEmail = false;
            this.ucTextbox1.IsPhoneNumber = false;
            this.ucTextbox1.IsRequired = false;
            this.ucTextbox1.Location = new System.Drawing.Point(0, 0);
            this.ucTextbox1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ucTextbox1.Name = "ucTextbox1";
            this.ucTextbox1.NextControl = null;
            this.ucTextbox1.ParentOfNextControl = null;
            this.ucTextbox1.Size = new System.Drawing.Size(297, 68);
            this.ucTextbox1.StringType = null;
            this.ucTextbox1.TabIndex = 2;
            this.ucTextbox1.Value = null;
            // 
            // ucTextbox2
            // 
            this.ucTextbox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTextbox2.HasRightEmailFormat = true;
            this.ucTextbox2.Index = 0;
            this.ucTextbox2.IsEmail = false;
            this.ucTextbox2.IsPhoneNumber = false;
            this.ucTextbox2.IsRequired = false;
            this.ucTextbox2.Location = new System.Drawing.Point(303, 0);
            this.ucTextbox2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ucTextbox2.Name = "ucTextbox2";
            this.ucTextbox2.NextControl = null;
            this.ucTextbox2.ParentOfNextControl = null;
            this.ucTextbox2.Size = new System.Drawing.Size(297, 68);
            this.ucTextbox2.StringType = null;
            this.ucTextbox2.TabIndex = 1;
            this.ucTextbox2.Value = null;
            // 
            // UCDoubleUCTextbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TLPGlobal);
            this.Name = "UCDoubleUCTextbox";
            this.Size = new System.Drawing.Size(600, 68);
            this.TLPGlobal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        public UCTextbox1 ucTextbox1;
        public UCTextbox1 ucTextbox2;
    }
}
