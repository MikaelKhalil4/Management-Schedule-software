using CustomizedTools;


namespace CustomizedTools
{
    partial class UCTextbox1
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            myTextBox1 = new TextBoxWithPlaceHolder();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            groupBox1.Controls.Add(myTextBox1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBox1.ForeColor = System.Drawing.Color.Black;
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(383, 69);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // myTextBox1
            // 
            myTextBox1.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            myTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            myTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            myTextBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            myTextBox1.ForeColor = System.Drawing.Color.Gray;
            myTextBox1.IsRequiredModeOn = false;
            myTextBox1.Location = new System.Drawing.Point(4, 29);
            myTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            myTextBox1.Name = "myTextBox1";
            myTextBox1.PlaceholderText = null;
            myTextBox1.Size = new System.Drawing.Size(375, 22);
            myTextBox1.TabIndex = 0;
            myTextBox1.TextChanged += myTextBox1_TextChanged;
            myTextBox1.Enter += myTextBox1_Enter;
            myTextBox1.KeyDown += myTextBox1_KeyDown;
            myTextBox1.KeyPress += myTextBox1_KeyPress;
            myTextBox1.Leave += myTextBox1_Leave;
            // 
            // UCTextbox1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UCTextbox1";
            Size = new System.Drawing.Size(383, 69);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.GroupBox groupBox1;
        public TextBoxWithPlaceHolder myTextBox1;
    }
}
