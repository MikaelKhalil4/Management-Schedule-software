namespace MKproject.Schedule
{
    partial class CBdisplayTime
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelContainerTime = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxTime, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelContainerTime, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(111, 140);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTime.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBoxTime.Location = new System.Drawing.Point(0, 0);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(111, 25);
            this.textBoxTime.TabIndex = 10;
            // 
            // flowLayoutPanelContainerTime
            // 
            this.flowLayoutPanelContainerTime.AutoScroll = true;
            this.flowLayoutPanelContainerTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelContainerTime.Location = new System.Drawing.Point(0, 26);
            this.flowLayoutPanelContainerTime.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelContainerTime.Name = "flowLayoutPanelContainerTime";
            this.flowLayoutPanelContainerTime.Size = new System.Drawing.Size(111, 114);
            this.flowLayoutPanelContainerTime.TabIndex = 11;
            this.flowLayoutPanelContainerTime.MouseEnter += new System.EventHandler(this.flowLayoutPanelContainerTime_MouseEnter);
            // 
            // CBdisplayTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(111, 140);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(111, 140);
            this.MinimumSize = new System.Drawing.Size(40, 40);
            this.Name = "CBdisplayTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DispalyTime";
            this.Deactivate += new System.EventHandler(this.DisplayTime_Deactivate);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContainerTime;
        public System.Windows.Forms.TextBox textBoxTime;
    }
}