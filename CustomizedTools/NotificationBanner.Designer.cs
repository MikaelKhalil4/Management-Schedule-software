namespace CustomizedTools
{
    partial class NotificationBanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationBanner));
            TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            pictureBox = new System.Windows.Forms.PictureBox();
            labelText = new System.Windows.Forms.Label();
            timer2 = new System.Windows.Forms.Timer(components);
            timer1 = new System.Windows.Forms.Timer(components);
            TLPGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // TLPGlobal
            // 
            TLPGlobal.BackColor = System.Drawing.Color.FromArgb(2, 162, 111);
            TLPGlobal.ColumnCount = 2;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.Controls.Add(pictureBox, 0, 0);
            TLPGlobal.Controls.Add(labelText, 1, 0);
            TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 0);
            TLPGlobal.Margin = new System.Windows.Forms.Padding(0);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 1;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            TLPGlobal.Size = new System.Drawing.Size(271, 51);
            TLPGlobal.TabIndex = 31;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            pictureBox.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox.BackgroundImage");
            pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox.Location = new System.Drawing.Point(3, 11);
            pictureBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(39, 30);
            pictureBox.TabIndex = 31;
            pictureBox.TabStop = false;
            // 
            // labelText
            // 
            labelText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelText.AutoSize = true;
            labelText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelText.ForeColor = System.Drawing.Color.White;
            labelText.Location = new System.Drawing.Point(48, 15);
            labelText.Name = "labelText";
            labelText.Size = new System.Drawing.Size(150, 21);
            labelText.TabIndex = 32;
            labelText.Text = "Appointment Added";
            // 
            // timer2
            // 
            timer2.Interval = 1500;
            timer2.Tick += timer2_Tick;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick_1;
            // 
            // NotificationBanner
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(124, 218, 124);
            ClientSize = new System.Drawing.Size(271, 51);
            ControlBox = false;
            Controls.Add(TLPGlobal);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NotificationBanner";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            TLPGlobal.ResumeLayout(false);
            TLPGlobal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
    }
}