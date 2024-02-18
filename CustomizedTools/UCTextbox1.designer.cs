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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.myTextBox1 = new TextBoxWithPlaceHolder();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.groupBox1.Controls.Add(this.myTextBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // myTextBox1
            // 
            this.myTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.myTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.myTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTextBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.myTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.myTextBox1.Location = new System.Drawing.Point(3, 29);
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.PlaceholderText = null;
            this.myTextBox1.Size = new System.Drawing.Size(594, 22);
            this.myTextBox1.TabIndex = 0;
            this.myTextBox1.TextChanged += new System.EventHandler(this.myTextBox1_TextChanged);
            this.myTextBox1.Enter += new System.EventHandler(this.myTextBox1_Enter);
            this.myTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myTextBox1_KeyDown);
            this.myTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.myTextBox1_KeyPress);
            this.myTextBox1.Leave += new System.EventHandler(this.myTextBox1_Leave);
            // 
            // UCTextbox1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCTextbox1";
            this.Size = new System.Drawing.Size(600, 67);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.GroupBox groupBox1;
        public TextBoxWithPlaceHolder myTextBox1;
    }
}
