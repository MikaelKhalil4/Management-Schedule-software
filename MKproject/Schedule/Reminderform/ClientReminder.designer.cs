namespace MKproject.Schedule
{
    partial class ClientReminder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientReminder));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonAdd = new System.Windows.Forms.PictureBox();
            this.panelreminder = new System.Windows.Forms.Panel();
            this.labelFullName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.12027F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.87972F));
            this.tableLayoutPanel1.Controls.Add(this.ButtonAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelreminder, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelFullName, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.777778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.22222F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(388, 514);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonAdd.BackgroundImage")));
            this.ButtonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAdd.Location = new System.Drawing.Point(15, 11);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(27, 27);
            this.ButtonAdd.TabIndex = 3;
            this.ButtonAdd.TabStop = false;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // panelreminder
            // 
            this.panelreminder.AutoScroll = true;
            this.panelreminder.AutoSize = true;
            this.panelreminder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(254)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panelreminder, 23);
            this.panelreminder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelreminder.Location = new System.Drawing.Point(4, 54);
            this.panelreminder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelreminder.Name = "panelreminder";
            this.panelreminder.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panelreminder.Size = new System.Drawing.Size(380, 456);
            this.panelreminder.TabIndex = 1;
            // 
            // labelFullName
            // 
            this.labelFullName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFullName.AutoSize = true;
            this.labelFullName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullName.Location = new System.Drawing.Point(138, 12);
            this.labelFullName.Margin = new System.Windows.Forms.Padding(80, 0, 4, 0);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(120, 25);
            this.labelFullName.TabIndex = 2;
            this.labelFullName.Text = "Mikael Khalil";
            // 
            // ClientReminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 514);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ClientReminder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientRemindercs";
            this.Load += new System.EventHandler(this.ClientReminder_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Panel panelreminder;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.PictureBox ButtonAdd;
    }
}