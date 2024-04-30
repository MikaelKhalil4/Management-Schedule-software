namespace MKproject.Schedule
{
    partial class UCEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCEmployee));
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            labelRank = new System.Windows.Forms.Label();
            CheckBoxAppearance = new System.Windows.Forms.CheckBox();
            buttonUp = new System.Windows.Forms.Button();
            buttonDown = new System.Windows.Forms.Button();
            buttonAvailability = new System.Windows.Forms.Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.4320412F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.11492F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.78129F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.3358755F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.3358755F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(labelRank, 0, 0);
            tableLayoutPanel1.Controls.Add(CheckBoxAppearance, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonUp, 4, 0);
            tableLayoutPanel1.Controls.Add(buttonDown, 3, 0);
            tableLayoutPanel1.Controls.Add(buttonAvailability, 2, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.12346F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.876543F));
            tableLayoutPanel1.Size = new System.Drawing.Size(288, 57);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Click += buttonAvailability_Click;
            tableLayoutPanel1.MouseLeave += UCEmployee_MouseLeave;
            tableLayoutPanel1.MouseMove += UCEmployee_MouseMove;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(249, 246, 254);
            tableLayoutPanel1.SetColumnSpan(panel1, 5);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 51);
            panel1.Margin = new System.Windows.Forms.Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(288, 6);
            panel1.TabIndex = 4;
            // 
            // labelRank
            // 
            labelRank.AutoSize = true;
            labelRank.Dock = System.Windows.Forms.DockStyle.Fill;
            labelRank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelRank.Location = new System.Drawing.Point(4, 0);
            labelRank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelRank.Name = "labelRank";
            labelRank.Size = new System.Drawing.Size(36, 51);
            labelRank.TabIndex = 7;
            labelRank.Text = "1";
            labelRank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelRank.MouseLeave += UCEmployee_MouseLeave;
            labelRank.MouseMove += UCEmployee_MouseMove;
            // 
            // CheckBoxAppearance
            // 
            CheckBoxAppearance.AutoSize = true;
            CheckBoxAppearance.Checked = true;
            CheckBoxAppearance.CheckState = System.Windows.Forms.CheckState.Checked;
            CheckBoxAppearance.Dock = System.Windows.Forms.DockStyle.Fill;
            CheckBoxAppearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CheckBoxAppearance.Location = new System.Drawing.Point(48, 3);
            CheckBoxAppearance.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CheckBoxAppearance.Name = "CheckBoxAppearance";
            CheckBoxAppearance.Size = new System.Drawing.Size(144, 45);
            CheckBoxAppearance.TabIndex = 8;
            CheckBoxAppearance.Text = "Elie Khalil";
            CheckBoxAppearance.UseVisualStyleBackColor = true;
            CheckBoxAppearance.CheckStateChanged += CheckBoxAppearance_CheckStateChanged;
            CheckBoxAppearance.MouseLeave += UCEmployee_MouseLeave;
            CheckBoxAppearance.MouseMove += UCEmployee_MouseMove;
            // 
            // buttonUp
            // 
            buttonUp.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonUp.BackgroundImage");
            buttonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonUp.FlatAppearance.BorderSize = 0;
            buttonUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonUp.Location = new System.Drawing.Point(260, 3);
            buttonUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonUp.Name = "buttonUp";
            buttonUp.Size = new System.Drawing.Size(24, 44);
            buttonUp.TabIndex = 9;
            buttonUp.UseVisualStyleBackColor = true;
            buttonUp.Click += buttonUp_Click;
            buttonUp.MouseLeave += UCEmployee_MouseLeave;
            buttonUp.MouseMove += UCEmployee_MouseMove;
            // 
            // buttonDown
            // 
            buttonDown.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonDown.BackgroundImage");
            buttonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonDown.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonDown.FlatAppearance.BorderSize = 0;
            buttonDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonDown.Location = new System.Drawing.Point(231, 3);
            buttonDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonDown.Name = "buttonDown";
            buttonDown.Size = new System.Drawing.Size(21, 45);
            buttonDown.TabIndex = 6;
            buttonDown.UseVisualStyleBackColor = true;
            buttonDown.Click += buttonDown_Click;
            buttonDown.MouseLeave += UCEmployee_MouseLeave;
            buttonDown.MouseMove += UCEmployee_MouseMove;
            // 
            // buttonAvailability
            // 
            buttonAvailability.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonAvailability.BackgroundImage");
            buttonAvailability.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonAvailability.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonAvailability.FlatAppearance.BorderSize = 0;
            buttonAvailability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAvailability.Location = new System.Drawing.Point(200, 3);
            buttonAvailability.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonAvailability.Name = "buttonAvailability";
            buttonAvailability.Size = new System.Drawing.Size(23, 45);
            buttonAvailability.TabIndex = 6;
            buttonAvailability.UseVisualStyleBackColor = true;
            buttonAvailability.Click += buttonAvailability_Click;
            buttonAvailability.MouseLeave += UCEmployee_MouseLeave;
            buttonAvailability.MouseMove += UCEmployee_MouseMove;
            // 
            // UCEmployee
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UCEmployee";
            Size = new System.Drawing.Size(288, 57);
            Click += buttonAvailability_Click;
            MouseLeave += UCEmployee_MouseLeave;
            MouseMove += UCEmployee_MouseMove;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Label labelRank;
        private System.Windows.Forms.Button buttonUp;
        public System.Windows.Forms.CheckBox CheckBoxAppearance;
        private System.Windows.Forms.Button buttonAvailability;
    }
}
