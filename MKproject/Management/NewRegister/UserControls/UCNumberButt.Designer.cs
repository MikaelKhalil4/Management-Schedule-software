

using CustomizedTools;

namespace MKproject.Management
{
    partial class UCNumberButt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCNumberButt));
            this.TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.buttonValueMinus = new IconButton();
            this.buttonValuePlus = new IconButton();
            this.TLPGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPGlobal
            // 
            this.TLPGlobal.BackColor = System.Drawing.Color.Transparent;
            this.TLPGlobal.ColumnCount = 3;
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54F));
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.TLPGlobal.Controls.Add(this.textBoxValue, 0, 0);
            this.TLPGlobal.Controls.Add(this.buttonValueMinus, 0, 0);
            this.TLPGlobal.Controls.Add(this.buttonValuePlus, 2, 0);
            this.TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPGlobal.Location = new System.Drawing.Point(0, 0);
            this.TLPGlobal.Name = "TLPGlobal";
            this.TLPGlobal.RowCount = 1;
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPGlobal.Size = new System.Drawing.Size(184, 46);
            this.TLPGlobal.TabIndex = 0;
            // 
            // textBoxValue
            // 
            this.textBoxValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxValue.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxValue.Font = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValue.ForeColor = System.Drawing.Color.Black;
            this.textBoxValue.Location = new System.Drawing.Point(42, 0);
            this.textBoxValue.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(99, 47);
            this.textBoxValue.TabIndex = 13;
            this.textBoxValue.Text = "0";
            this.textBoxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxValue.TextChanged += new System.EventHandler(this.textBoxValue_TextChanged);
            this.textBoxValue.Enter += new System.EventHandler(this.textBoxValue_Enter);
            this.textBoxValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValue_KeyPress);
            this.textBoxValue.Leave += new System.EventHandler(this.textBoxValue_Leave);
            // 
            // buttonValueMinus
            // 
            this.buttonValueMinus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonValueMinus.BackColor = System.Drawing.Color.Transparent;
            this.buttonValueMinus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonValueMinus.BackgroundImage")));
            this.buttonValueMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonValueMinus.FlatAppearance.BorderSize = 0;
            this.buttonValueMinus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonValueMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonValueMinus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonValueMinus.ForeColor = System.Drawing.Color.White;
            this.buttonValueMinus.Location = new System.Drawing.Point(6, 8);
            this.buttonValueMinus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonValueMinus.MotionHeight = true;
            this.buttonValueMinus.MotionWidth = true;
            this.buttonValueMinus.Name = "buttonValueMinus";
            this.buttonValueMinus.Size = new System.Drawing.Size(30, 30);
            this.buttonValueMinus.TabIndex = 3;
            this.buttonValueMinus.UseVisualStyleBackColor = false;
            this.buttonValueMinus.Click += new System.EventHandler(this.buttonValueMinus_Click);
            // 
            // buttonValuePlus
            // 
            this.buttonValuePlus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonValuePlus.BackColor = System.Drawing.Color.Transparent;
            this.buttonValuePlus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonValuePlus.BackgroundImage")));
            this.buttonValuePlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonValuePlus.FlatAppearance.BorderSize = 0;
            this.buttonValuePlus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonValuePlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonValuePlus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonValuePlus.ForeColor = System.Drawing.Color.White;
            this.buttonValuePlus.Location = new System.Drawing.Point(147, 8);
            this.buttonValuePlus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonValuePlus.MotionHeight = true;
            this.buttonValuePlus.MotionWidth = true;
            this.buttonValuePlus.Name = "buttonValuePlus";
            this.buttonValuePlus.Size = new System.Drawing.Size(30, 30);
            this.buttonValuePlus.TabIndex = 2;
            this.buttonValuePlus.UseVisualStyleBackColor = false;
            this.buttonValuePlus.Click += new System.EventHandler(this.buttonValuePlus_Click);
            // 
            // UCNumberButt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.TLPGlobal);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCNumberButt";
            this.Size = new System.Drawing.Size(184, 46);
            this.TLPGlobal.ResumeLayout(false);
            this.TLPGlobal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox textBoxValue;
        public IconButton buttonValuePlus;
        public IconButton buttonValueMinus;
        public System.Windows.Forms.TableLayoutPanel TLPGlobal;
    }
}
