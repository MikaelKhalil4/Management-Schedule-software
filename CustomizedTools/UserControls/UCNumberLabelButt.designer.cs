



namespace CustomizedTools
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
            labelUnit = new System.Windows.Forms.Label();
            buttonValuePlus = new IconButton();
            textBoxValue = new System.Windows.Forms.TextBox();
            buttonValueMinus = new IconButton();
            TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            TLPGlobal.SuspendLayout();
            SuspendLayout();
            // 
            // labelUnit
            // 
            labelUnit.AutoSize = true;
            labelUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            labelUnit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUnit.Location = new System.Drawing.Point(99, 0);
            labelUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelUnit.Name = "labelUnit";
            labelUnit.Size = new System.Drawing.Size(34, 43);
            labelUnit.TabIndex = 14;
            labelUnit.Text = "hrs";
            labelUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonValuePlus
            // 
            buttonValuePlus.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonValuePlus.BackColor = System.Drawing.Color.Transparent;
            buttonValuePlus.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonValuePlus.BackgroundImage");
            buttonValuePlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonValuePlus.FlatAppearance.BorderSize = 0;
            buttonValuePlus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            buttonValuePlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonValuePlus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonValuePlus.ForeColor = System.Drawing.Color.White;
            buttonValuePlus.Location = new System.Drawing.Point(140, 4);
            buttonValuePlus.Margin = new System.Windows.Forms.Padding(0);
            buttonValuePlus.MotionHeight = true;
            buttonValuePlus.MotionWidth = true;
            buttonValuePlus.Name = "buttonValuePlus";
            buttonValuePlus.Size = new System.Drawing.Size(31, 35);
            buttonValuePlus.TabIndex = 15;
            buttonValuePlus.UseVisualStyleBackColor = false;
            buttonValuePlus.Click += buttonValuePlus_Click;
            // 
            // textBoxValue
            // 
            textBoxValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            textBoxValue.BackColor = System.Drawing.SystemColors.Window;
            textBoxValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBoxValue.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBoxValue.ForeColor = System.Drawing.Color.Black;
            textBoxValue.Location = new System.Drawing.Point(35, 3);
            textBoxValue.Margin = new System.Windows.Forms.Padding(0);
            textBoxValue.Name = "textBoxValue";
            textBoxValue.Size = new System.Drawing.Size(59, 36);
            textBoxValue.TabIndex = 13;
            textBoxValue.Text = "0";
            textBoxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBoxValue.TextChanged += textBoxValue_TextChanged;
            textBoxValue.Enter += textBoxValue_Enter;
            textBoxValue.KeyPress += textBoxValue_KeyPress;
            textBoxValue.Leave += textBoxValue_Leave;
            // 
            // buttonValueMinus
            // 
            buttonValueMinus.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonValueMinus.BackColor = System.Drawing.Color.Transparent;
            buttonValueMinus.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonValueMinus.BackgroundImage");
            buttonValueMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonValueMinus.FlatAppearance.BorderSize = 0;
            buttonValueMinus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            buttonValueMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonValueMinus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonValueMinus.ForeColor = System.Drawing.Color.White;
            buttonValueMinus.Location = new System.Drawing.Point(2, 4);
            buttonValueMinus.Margin = new System.Windows.Forms.Padding(0);
            buttonValueMinus.MotionHeight = true;
            buttonValueMinus.MotionWidth = true;
            buttonValueMinus.Name = "buttonValueMinus";
            buttonValueMinus.Size = new System.Drawing.Size(31, 35);
            buttonValueMinus.TabIndex = 16;
            buttonValueMinus.UseVisualStyleBackColor = false;
            buttonValueMinus.Click += buttonValueMinus_Click;
            // 
            // TLPGlobal
            // 
            TLPGlobal.BackColor = System.Drawing.Color.White;
            TLPGlobal.ColumnCount = 4;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.94394F));
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.112114F));
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.94394F));
            TLPGlobal.Controls.Add(labelUnit, 2, 0);
            TLPGlobal.Controls.Add(buttonValuePlus, 3, 0);
            TLPGlobal.Controls.Add(textBoxValue, 1, 0);
            TLPGlobal.Controls.Add(buttonValueMinus, 0, 0);
            TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 0);
            TLPGlobal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 1;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.Size = new System.Drawing.Size(174, 43);
            TLPGlobal.TabIndex = 1;
            // 
            // UCNumberLabelButt
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(TLPGlobal);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UCNumberLabelButt";
            Size = new System.Drawing.Size(174, 43);
            TLPGlobal.ResumeLayout(false);
            TLPGlobal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.TextBox textBoxValue;
        public System.Windows.Forms.Label labelUnit;
        public IconButton buttonValuePlus;
        public IconButton buttonValueMinus;
        public System.Windows.Forms.TableLayoutPanel TLPGlobal;
    }
}
