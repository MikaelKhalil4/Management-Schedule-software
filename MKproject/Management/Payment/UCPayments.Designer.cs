namespace MKproject.Management
{
    partial class UCPayments
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
            this.textBoxPayment = new System.Windows.Forms.TextBox();
            this.labelPayment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPayment
            // 
            this.textBoxPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.textBoxPayment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold);
            this.textBoxPayment.ForeColor = System.Drawing.Color.Black;
            this.textBoxPayment.Location = new System.Drawing.Point(0, 0);
            this.textBoxPayment.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPayment.Name = "textBoxPayment";
            this.textBoxPayment.Size = new System.Drawing.Size(378, 47);
            this.textBoxPayment.TabIndex = 12;
            this.textBoxPayment.Text = "+$500";
            this.textBoxPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPayment.Click += new System.EventHandler(this.textBoxPayment_Click_1);
            this.textBoxPayment.DoubleClick += new System.EventHandler(this.textBoxPayment_DoubleClick_1);
            this.textBoxPayment.Enter += new System.EventHandler(this.textBoxPayment_Enter_1);
            this.textBoxPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPayment_KeyDown_1);
            this.textBoxPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPayment_KeyPress_1);
            this.textBoxPayment.Leave += new System.EventHandler(this.textBoxPayment_Leave);
            // 
            // labelPayment
            // 
            this.labelPayment.BackColor = System.Drawing.Color.Transparent;
            this.labelPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold);
            this.labelPayment.Location = new System.Drawing.Point(0, 47);
            this.labelPayment.Margin = new System.Windows.Forms.Padding(0);
            this.labelPayment.Name = "labelPayment";
            this.labelPayment.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelPayment.Size = new System.Drawing.Size(378, 47);
            this.labelPayment.TabIndex = 13;
            this.labelPayment.Text = "+$500Label";
            this.labelPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelPayment);
            this.Controls.Add(this.textBoxPayment);
            this.Name = "UCPayments";
            this.Size = new System.Drawing.Size(378, 139);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxPayment;
        private System.Windows.Forms.Label labelPayment;
    }
}
