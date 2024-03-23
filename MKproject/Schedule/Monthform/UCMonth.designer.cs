namespace MKproject.Schedule
{
    partial class UCMonth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCMonth));
            buttonPrevious = new System.Windows.Forms.Button();
            labelTitleDay = new System.Windows.Forms.Label();
            buttonNext = new System.Windows.Forms.Button();
            tableLayoutPanelMonth = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelMonth.SuspendLayout();
            SuspendLayout();
            // 
            // buttonPrevious
            // 
            buttonPrevious.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonPrevious.BackColor = System.Drawing.Color.Transparent;
            buttonPrevious.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonPrevious.BackgroundImage");
            buttonPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonPrevious.FlatAppearance.BorderColor = System.Drawing.Color.White;
            buttonPrevious.FlatAppearance.BorderSize = 0;
            buttonPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(229, 226, 244);
            buttonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonPrevious.ForeColor = System.Drawing.Color.Transparent;
            buttonPrevious.Location = new System.Drawing.Point(79, 7);
            buttonPrevious.Margin = new System.Windows.Forms.Padding(4);
            buttonPrevious.Name = "buttonPrevious";
            buttonPrevious.Size = new System.Drawing.Size(22, 20);
            buttonPrevious.TabIndex = 55;
            buttonPrevious.UseVisualStyleBackColor = false;
            buttonPrevious.Click += buttonPrevious_Click_1;
            // 
            // labelTitleDay
            // 
            labelTitleDay.Anchor = System.Windows.Forms.AnchorStyles.None;
            labelTitleDay.AutoSize = true;
            labelTitleDay.Cursor = System.Windows.Forms.Cursors.Hand;
            labelTitleDay.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTitleDay.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelTitleDay.Location = new System.Drawing.Point(122, 7);
            labelTitleDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelTitleDay.Name = "labelTitleDay";
            labelTitleDay.Size = new System.Drawing.Size(108, 20);
            labelTitleDay.TabIndex = 53;
            labelTitleDay.Text = "MONTH YEAR";
            labelTitleDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelTitleDay.Click += labelTitleDay_Click;
            labelTitleDay.MouseEnter += labelTitleDay_MouseEnter;
            labelTitleDay.MouseLeave += labelTitleDay_MouseLeave;
            // 
            // buttonNext
            // 
            buttonNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            buttonNext.BackColor = System.Drawing.Color.Transparent;
            buttonNext.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonNext.BackgroundImage");
            buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(255, 255, 128);
            buttonNext.FlatAppearance.BorderSize = 0;
            buttonNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(229, 226, 244);
            buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonNext.Font = new System.Drawing.Font("Segoe UI", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonNext.ForeColor = System.Drawing.Color.Transparent;
            buttonNext.Location = new System.Drawing.Point(252, 7);
            buttonNext.Margin = new System.Windows.Forms.Padding(4);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new System.Drawing.Size(22, 20);
            buttonNext.TabIndex = 56;
            buttonNext.UseVisualStyleBackColor = false;
            buttonNext.Click += buttonNext_Click_1;
            // 
            // tableLayoutPanelMonth
            // 
            tableLayoutPanelMonth.BackColor = System.Drawing.Color.White;
            tableLayoutPanelMonth.ColumnCount = 3;
            tableLayoutPanelMonth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.1408443F));
            tableLayoutPanelMonth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.1267624F));
            tableLayoutPanelMonth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.7323952F));
            tableLayoutPanelMonth.Controls.Add(buttonNext, 2, 0);
            tableLayoutPanelMonth.Controls.Add(labelTitleDay, 1, 0);
            tableLayoutPanelMonth.Controls.Add(buttonPrevious, 0, 0);
            tableLayoutPanelMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelMonth.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelMonth.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelMonth.Name = "tableLayoutPanelMonth";
            tableLayoutPanelMonth.RowCount = 2;
            tableLayoutPanelMonth.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.9601326F));
            tableLayoutPanelMonth.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.03986F));
            tableLayoutPanelMonth.Size = new System.Drawing.Size(349, 291);
            tableLayoutPanelMonth.TabIndex = 0;
            // 
            // UCMonth
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(349, 291);
            ControlBox = false;
            Controls.Add(tableLayoutPanelMonth);
            Margin = new System.Windows.Forms.Padding(0);
            MaximumSize = new System.Drawing.Size(365, 307);
            MinimumSize = new System.Drawing.Size(365, 307);
            Name = "UCMonth";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Deactivate += UCMonth_Deactivate;
            tableLayoutPanelMonth.ResumeLayout(false);
            tableLayoutPanelMonth.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button buttonPrevious;
        public System.Windows.Forms.Label labelTitleDay;
        private System.Windows.Forms.Button buttonNext;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanelMonth;
    }
}
