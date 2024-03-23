

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
            TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            ucTextbox1 = new UCTextbox1();
            ucTextbox2 = new UCTextbox1();
            TLPGlobal.SuspendLayout();
            SuspendLayout();
            // 
            // TLPGlobal
            // 
            TLPGlobal.ColumnCount = 2;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPGlobal.Controls.Add(ucTextbox1, 0, 0);
            TLPGlobal.Controls.Add(ucTextbox2, 1, 0);
            TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 0);
            TLPGlobal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 1;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            TLPGlobal.Size = new System.Drawing.Size(700, 69);
            TLPGlobal.TabIndex = 0;
            // 
            // ucTextbox1
            // 
            ucTextbox1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucTextbox1.HasRightEmailFormat = true;
            ucTextbox1.Index = 0;
            ucTextbox1.IsEmail = false;
            ucTextbox1.IsPhoneNumber = false;
            ucTextbox1.IsRequired = false;
            ucTextbox1.Location = new System.Drawing.Point(0, 0);
            ucTextbox1.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            ucTextbox1.Name = "ucTextbox1";
            ucTextbox1.NextControl = null;
            ucTextbox1.ParentOfNextControl = null;
            ucTextbox1.Size = new System.Drawing.Size(346, 69);
            ucTextbox1.StringType = null;
            ucTextbox1.TabIndex = 2;
            ucTextbox1.Value = null;
            // 
            // ucTextbox2
            // 
            ucTextbox2.Dock = System.Windows.Forms.DockStyle.Fill;
            ucTextbox2.HasRightEmailFormat = true;
            ucTextbox2.Index = 0;
            ucTextbox2.IsEmail = false;
            ucTextbox2.IsPhoneNumber = false;
            ucTextbox2.IsRequired = false;
            ucTextbox2.Location = new System.Drawing.Point(354, 0);
            ucTextbox2.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            ucTextbox2.Name = "ucTextbox2";
            ucTextbox2.NextControl = null;
            ucTextbox2.ParentOfNextControl = null;
            ucTextbox2.Size = new System.Drawing.Size(346, 69);
            ucTextbox2.StringType = null;
            ucTextbox2.TabIndex = 1;
            ucTextbox2.Value = null;
            // 
            // UCDoubleUCTextbox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(TLPGlobal);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UCDoubleUCTextbox";
            Size = new System.Drawing.Size(700, 69);
            TLPGlobal.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        public UCTextbox1 ucTextbox1;
        public UCTextbox1 ucTextbox2;
    }
}
