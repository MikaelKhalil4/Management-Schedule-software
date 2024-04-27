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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            textBoxTime = new System.Windows.Forms.TextBox();
            flowLayoutPanelContainerTime = new System.Windows.Forms.FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(textBoxTime, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanelContainerTime, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            tableLayoutPanel1.Size = new System.Drawing.Size(118, 162);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxTime
            // 
            textBoxTime.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            textBoxTime.Dock = System.Windows.Forms.DockStyle.Fill;
            textBoxTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxTime.Location = new System.Drawing.Point(0, 0);
            textBoxTime.Margin = new System.Windows.Forms.Padding(0);
            textBoxTime.Name = "textBoxTime";
            textBoxTime.Size = new System.Drawing.Size(118, 25);
            textBoxTime.TabIndex = 10;
            textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // flowLayoutPanelContainerTime
            // 
            flowLayoutPanelContainerTime.AutoScroll = true;
            flowLayoutPanelContainerTime.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanelContainerTime.Location = new System.Drawing.Point(0, 28);
            flowLayoutPanelContainerTime.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanelContainerTime.Name = "flowLayoutPanelContainerTime";
            flowLayoutPanelContainerTime.Size = new System.Drawing.Size(118, 134);
            flowLayoutPanelContainerTime.TabIndex = 11;
            flowLayoutPanelContainerTime.MouseEnter += flowLayoutPanelContainerTime_MouseEnter;
            // 
            // CBdisplayTime
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(118, 162);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "CBdisplayTime";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Deactivate += DisplayTime_Deactivate;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContainerTime;
        public System.Windows.Forms.TextBox textBoxTime;
    }
}