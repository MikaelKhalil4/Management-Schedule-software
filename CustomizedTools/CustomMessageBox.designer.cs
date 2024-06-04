namespace CustomizedTools
{
    partial class CustomMessageBox
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMessageBox));
            labelText = new System.Windows.Forms.Label();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            pictureBox = new System.Windows.Forms.PictureBox();
            FLPButtons = new System.Windows.Forms.FlowLayoutPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // labelText
            // 
            labelText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelText.AutoSize = true;
            labelText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelText.Location = new System.Drawing.Point(83, 33);
            labelText.Margin = new System.Windows.Forms.Padding(4, 17, 4, 17);
            labelText.Name = "labelText";
            labelText.Size = new System.Drawing.Size(179, 84);
            labelText.TabIndex = 29;
            labelText.Text = "label1v hello ow are you\r\nlabel1v hello ow are you\r\nlabel1v hello ow are you\r\nlabel1v hello ow are you\r\n";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel1.Controls.Add(labelText, 1, 0);
            tableLayoutPanel1.Controls.Add(FLPButtons, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            tableLayoutPanel1.Size = new System.Drawing.Size(418, 211);
            tableLayoutPanel1.TabIndex = 30;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            pictureBox.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox.BackgroundImage");
            pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox.Location = new System.Drawing.Point(10, 46);
            pictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(59, 57);
            pictureBox.TabIndex = 31;
            pictureBox.TabStop = false;
            // 
            // FLPButtons
            // 
            FLPButtons.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            tableLayoutPanel1.SetColumnSpan(FLPButtons, 2);
            FLPButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            FLPButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            FLPButtons.Location = new System.Drawing.Point(0, 150);
            FLPButtons.Margin = new System.Windows.Forms.Padding(0);
            FLPButtons.Name = "FLPButtons";
            FLPButtons.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            FLPButtons.Size = new System.Drawing.Size(418, 61);
            FLPButtons.TabIndex = 30;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // CustomMessageBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(418, 211);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomMessageBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel FLPButtons;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Timer timer1;
    }
}