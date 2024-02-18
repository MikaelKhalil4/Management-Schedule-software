namespace MKproject.Schedule
{
    partial class Coach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Coach));
            this.panelContainsCoaches = new System.Windows.Forms.Panel();
            this.buttonD = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainsCoaches
            // 
            this.panelContainsCoaches.AutoScroll = true;
            this.panelContainsCoaches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainsCoaches.Location = new System.Drawing.Point(0, 0);
            this.panelContainsCoaches.Margin = new System.Windows.Forms.Padding(0);
            this.panelContainsCoaches.Name = "panelContainsCoaches";
            this.panelContainsCoaches.Size = new System.Drawing.Size(234, 255);
            this.panelContainsCoaches.TabIndex = 0;
            // 
            // buttonD
            // 
            this.buttonD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonD.BackColor = System.Drawing.Color.Transparent;
            this.buttonD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonD.BackgroundImage")));
            this.buttonD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonD.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.buttonD.FlatAppearance.BorderSize = 0;
            this.buttonD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.buttonD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonD.ForeColor = System.Drawing.Color.Transparent;
            this.buttonD.Location = new System.Drawing.Point(101, 263);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(32, 25);
            this.buttonD.TabIndex = 10;
            this.buttonD.UseVisualStyleBackColor = false;
            this.buttonD.Click += new System.EventHandler(this.buttonD_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonD, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelContainsCoaches, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.14865F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.85135F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(234, 296);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // Coach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(244, 303);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Coach";
            this.Padding = new System.Windows.Forms.Padding(5, 7, 5, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Coach";
            this.Deactivate += new System.EventHandler(this.Coach_Deactivate);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Panel panelContainsCoaches;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}