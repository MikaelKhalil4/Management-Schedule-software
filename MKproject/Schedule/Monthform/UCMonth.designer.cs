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
            tableLayoutPanelMonth = new System.Windows.Forms.TableLayoutPanel();
            panel2 = new System.Windows.Forms.Panel();
            buttonTypeDateChange = new System.Windows.Forms.Button();
            buttonPrevious = new System.Windows.Forms.Button();
            buttonNext = new System.Windows.Forms.Button();
            labelTitle = new System.Windows.Forms.Label();
            tableLayoutPanelMonth.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelMonth
            // 
            tableLayoutPanelMonth.BackColor = System.Drawing.Color.White;
            tableLayoutPanelMonth.ColumnCount = 1;
            tableLayoutPanelMonth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelMonth.Controls.Add(panel2, 0, 0);
            tableLayoutPanelMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelMonth.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelMonth.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelMonth.Name = "tableLayoutPanelMonth";
            tableLayoutPanelMonth.RowCount = 2;
            tableLayoutPanelMonth.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.6853151F));
            tableLayoutPanelMonth.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.31468F));
            tableLayoutPanelMonth.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanelMonth.Size = new System.Drawing.Size(311, 286);
            tableLayoutPanelMonth.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonTypeDateChange);
            panel2.Controls.Add(buttonPrevious);
            panel2.Controls.Add(buttonNext);
            panel2.Controls.Add(labelTitle);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(311, 42);
            panel2.TabIndex = 55;
            // 
            // buttonTypeDateChange
            // 
            buttonTypeDateChange.BackColor = System.Drawing.Color.WhiteSmoke;
            buttonTypeDateChange.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonTypeDateChange.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            buttonTypeDateChange.FlatAppearance.BorderSize = 0;
            buttonTypeDateChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonTypeDateChange.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonTypeDateChange.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonTypeDateChange.Location = new System.Drawing.Point(0, 13);
            buttonTypeDateChange.Margin = new System.Windows.Forms.Padding(4);
            buttonTypeDateChange.Name = "buttonTypeDateChange";
            buttonTypeDateChange.Size = new System.Drawing.Size(78, 22);
            buttonTypeDateChange.TabIndex = 69;
            buttonTypeDateChange.Text = "Month";
            buttonTypeDateChange.UseVisualStyleBackColor = false;
            buttonTypeDateChange.Click += buttonTypeDateChange_Click;
            // 
            // buttonPrevious
            // 
            buttonPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonPrevious.BackColor = System.Drawing.Color.Transparent;
            buttonPrevious.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonPrevious.BackgroundImage");
            buttonPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonPrevious.FlatAppearance.BorderColor = System.Drawing.Color.White;
            buttonPrevious.FlatAppearance.BorderSize = 0;
            buttonPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(229, 226, 244);
            buttonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonPrevious.ForeColor = System.Drawing.Color.Transparent;
            buttonPrevious.Location = new System.Drawing.Point(93, 16);
            buttonPrevious.Margin = new System.Windows.Forms.Padding(4);
            buttonPrevious.Name = "buttonPrevious";
            buttonPrevious.Size = new System.Drawing.Size(28, 17);
            buttonPrevious.TabIndex = 55;
            buttonPrevious.UseVisualStyleBackColor = false;
            buttonPrevious.Click += buttonPrevious_Click_1;
            // 
            // buttonNext
            // 
            buttonNext.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonNext.BackColor = System.Drawing.Color.Transparent;
            buttonNext.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonNext.BackgroundImage");
            buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(255, 255, 128);
            buttonNext.FlatAppearance.BorderSize = 0;
            buttonNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(229, 226, 244);
            buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonNext.ForeColor = System.Drawing.Color.Transparent;
            buttonNext.Location = new System.Drawing.Point(237, 16);
            buttonNext.Margin = new System.Windows.Forms.Padding(4);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new System.Drawing.Size(28, 17);
            buttonNext.TabIndex = 56;
            buttonNext.UseVisualStyleBackColor = false;
            buttonNext.Click += buttonNext_Click_1;
            // 
            // labelTitle
            // 
            labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            labelTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelTitle.Location = new System.Drawing.Point(129, 16);
            labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(100, 17);
            labelTitle.TabIndex = 53;
            labelTitle.Text = "MONTH YEAR";
            labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCMonth
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(311, 286);
            ControlBox = false;
            Controls.Add(tableLayoutPanelMonth);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(0);
            Name = "UCMonth";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Deactivate += UCMonth_Deactivate;
            tableLayoutPanelMonth.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanelMonth;
        public System.Windows.Forms.Label labelTitle;
        public System.Windows.Forms.Button buttonTypeDateChange;
    }
}
