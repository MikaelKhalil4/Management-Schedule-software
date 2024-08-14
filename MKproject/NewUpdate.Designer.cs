namespace MKproject
{
    partial class NewUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewUpdate));
            TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            labelDetails = new System.Windows.Forms.Label();
            pictureBoxLoading = new System.Windows.Forms.PictureBox();
            TLPGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoading).BeginInit();
            SuspendLayout();
            // 
            // TLPGlobal
            // 
            TLPGlobal.BackColor = System.Drawing.Color.White;
            TLPGlobal.ColumnCount = 1;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 513F));
            TLPGlobal.Controls.Add(labelDetails, 0, 0);
            TLPGlobal.Controls.Add(pictureBoxLoading, 0, 1);
            TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGlobal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TLPGlobal.Location = new System.Drawing.Point(0, 0);
            TLPGlobal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 2;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            TLPGlobal.Size = new System.Drawing.Size(513, 191);
            TLPGlobal.TabIndex = 31;
            // 
            // labelDetails
            // 
            labelDetails.AutoSize = true;
            labelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            labelDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelDetails.Location = new System.Drawing.Point(3, 0);
            labelDetails.Name = "labelDetails";
            labelDetails.Size = new System.Drawing.Size(507, 82);
            labelDetails.TabIndex = 1;
            labelDetails.Text = "Updating, please wait... This should take around one minute.\r\nAfter the update, the application will restart automatically.\r\nPlease do not turn off your Wi-Fi or close the application..";
            labelDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLoading
            // 
            pictureBoxLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            pictureBoxLoading.Image = (System.Drawing.Image)resources.GetObject("pictureBoxLoading.Image");
            pictureBoxLoading.Location = new System.Drawing.Point(204, 94);
            pictureBoxLoading.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBoxLoading.Name = "pictureBoxLoading";
            pictureBoxLoading.Size = new System.Drawing.Size(104, 85);
            pictureBoxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBoxLoading.TabIndex = 2;
            pictureBoxLoading.TabStop = false;
            // 
            // NewUpdate
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(513, 191);
            Controls.Add(TLPGlobal);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewUpdate";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "New Update...";
            TLPGlobal.ResumeLayout(false);
            TLPGlobal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoading).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        private System.Windows.Forms.Label labelDetails;
        private System.Windows.Forms.PictureBox pictureBoxLoading;
    }
}