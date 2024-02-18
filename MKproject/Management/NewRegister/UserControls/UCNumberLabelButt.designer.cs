

using CustomizedTools;

namespace MKproject.Management
{
    partial class UCNumberLabelButt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCNumberLabelButt));
            this.labelUnit = new System.Windows.Forms.Label();
            this.buttonValuePlus = new IconButton();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.buttonValueMinus = new IconButton();
            this.TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.TLPGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUnit
            // 
            this.labelUnit.AutoSize = true;
            this.labelUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUnit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnit.Location = new System.Drawing.Point(83, 0);
            this.labelUnit.Name = "labelUnit";
            this.labelUnit.Size = new System.Drawing.Size(32, 37);
            this.labelUnit.TabIndex = 14;
            this.labelUnit.Text = "hrs";
            this.labelUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.buttonValuePlus.Location = new System.Drawing.Point(120, 3);
            this.buttonValuePlus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonValuePlus.MotionHeight = true;
            this.buttonValuePlus.MotionWidth = true;
            this.buttonValuePlus.Name = "buttonValuePlus";
            this.buttonValuePlus.Size = new System.Drawing.Size(27, 30);
            this.buttonValuePlus.TabIndex = 15;
            this.buttonValuePlus.UseVisualStyleBackColor = false;
            this.buttonValuePlus.Click += new System.EventHandler(this.buttonValuePlus_Click);
            // 
            // textBoxValue
            // 
            this.textBoxValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxValue.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxValue.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValue.ForeColor = System.Drawing.Color.Black;
            this.textBoxValue.Location = new System.Drawing.Point(29, 0);
            this.textBoxValue.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(51, 36);
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
            this.buttonValueMinus.Location = new System.Drawing.Point(1, 3);
            this.buttonValueMinus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonValueMinus.MotionHeight = true;
            this.buttonValueMinus.MotionWidth = true;
            this.buttonValueMinus.Name = "buttonValueMinus";
            this.buttonValueMinus.Size = new System.Drawing.Size(27, 30);
            this.buttonValueMinus.TabIndex = 16;
            this.buttonValueMinus.UseVisualStyleBackColor = false;
            this.buttonValueMinus.Click += new System.EventHandler(this.buttonValueMinus_Click);
            // 
            // TLPGlobal
            // 
            this.TLPGlobal.BackColor = System.Drawing.Color.White;
            this.TLPGlobal.ColumnCount = 4;
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.22819F));
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.50336F));
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPGlobal.Controls.Add(this.labelUnit, 2, 0);
            this.TLPGlobal.Controls.Add(this.buttonValuePlus, 3, 0);
            this.TLPGlobal.Controls.Add(this.textBoxValue, 1, 0);
            this.TLPGlobal.Controls.Add(this.buttonValueMinus, 0, 0);
            this.TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPGlobal.Location = new System.Drawing.Point(0, 0);
            this.TLPGlobal.Name = "TLPGlobal";
            this.TLPGlobal.RowCount = 1;
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPGlobal.Size = new System.Drawing.Size(149, 37);
            this.TLPGlobal.TabIndex = 1;
            // 
            // UCNumberLabelButt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TLPGlobal);
            this.Name = "UCNumberLabelButt";
            this.Size = new System.Drawing.Size(149, 37);
            this.TLPGlobal.ResumeLayout(false);
            this.TLPGlobal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox textBoxValue;
        public System.Windows.Forms.Label labelUnit;
        public IconButton buttonValuePlus;
        public IconButton buttonValueMinus;
        public System.Windows.Forms.TableLayoutPanel TLPGlobal;
    }
}
