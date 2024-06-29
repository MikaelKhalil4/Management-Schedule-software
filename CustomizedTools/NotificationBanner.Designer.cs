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
            TLPglobal = new System.Windows.Forms.TableLayoutPanel();
            pictureBox = new System.Windows.Forms.PictureBox();
            labelText = new System.Windows.Forms.Label();
            ButtonUndo = new CustomButton();
            timerAppearanceDuation = new System.Windows.Forms.Timer(components);
            timerLocation = new System.Windows.Forms.Timer(components);
            TLPglobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // TLPglobal
            // 
            TLPglobal.BackColor = System.Drawing.Color.FromArgb(2, 162, 111);
            TLPglobal.ColumnCount = 3;
            TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            TLPglobal.Controls.Add(pictureBox, 0, 0);
            TLPglobal.Controls.Add(labelText, 1, 0);
            TLPglobal.Controls.Add(ButtonUndo, 2, 0);
            TLPglobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPglobal.Location = new System.Drawing.Point(0, 0);
            TLPglobal.Margin = new System.Windows.Forms.Padding(0);
            TLPglobal.Name = "TLPglobal";
            TLPglobal.RowCount = 1;
            TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPglobal.Size = new System.Drawing.Size(304, 51);
            TLPglobal.TabIndex = 31;
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
            // ButtonUndo
            // 
            ButtonUndo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            ButtonUndo.BackAndMouseHoverColor = System.Drawing.Color.Transparent;
            ButtonUndo.BackColor = System.Drawing.Color.Transparent;
            ButtonUndo.Cursor = System.Windows.Forms.Cursors.Hand;
            ButtonUndo.FlatAppearance.BorderSize = 0;
            ButtonUndo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(215, 215, 215);
            ButtonUndo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            ButtonUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ButtonUndo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ButtonUndo.ForeColor = System.Drawing.Color.White;
            ButtonUndo.Location = new System.Drawing.Point(233, 11);
            ButtonUndo.Margin = new System.Windows.Forms.Padding(0);
            ButtonUndo.Name = "ButtonUndo";
            ButtonUndo.Size = new System.Drawing.Size(61, 29);
            ButtonUndo.TabIndex = 33;
            ButtonUndo.Text = "Undo";
            ButtonUndo.UseVisualStyleBackColor = false;
            ButtonUndo.Click += ButtonUndo_Click;
            // 
            // timerAppearanceDuation
            // 
            timerAppearanceDuation.Tick += timer2_Tick;
            // 
            // timerLocation
            // 
            timerLocation.Interval = 10;
            timerLocation.Tick += timer1_Tick_1;
            // 
            // NotificationBanner
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(124, 218, 124);
            ClientSize = new System.Drawing.Size(304, 51);
            ControlBox = false;
            Controls.Add(TLPglobal);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NotificationBanner";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Deactivate += NotificationBanner_Deactivate;
            TLPglobal.ResumeLayout(false);
            TLPglobal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPglobal;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Timer timerAppearanceDuation;
        private System.Windows.Forms.Timer timerLocation;
        public CustomButton ButtonUndo;
    }
}