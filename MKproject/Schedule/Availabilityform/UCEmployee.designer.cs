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
            labelRank = new System.Windows.Forms.Label();
            buttonAvailability = new CustomizedTools.IconButton();
            CheckBoxAppearance = new System.Windows.Forms.CheckBox();
            iconButtonUp = new CustomizedTools.IconButton();
            iconButtonDown = new CustomizedTools.IconButton();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.Controls.Add(labelRank, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonAvailability, 2, 0);
            tableLayoutPanel1.Controls.Add(CheckBoxAppearance, 1, 0);
            tableLayoutPanel1.Controls.Add(iconButtonUp, 3, 0);
            tableLayoutPanel1.Controls.Add(iconButtonDown, 4, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(269, 40);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.MouseLeave += UCEmployee_MouseLeave;
            tableLayoutPanel1.MouseMove += UCEmployee_MouseMove;
            // 
            // labelRank
            // 
            labelRank.AutoSize = true;
            labelRank.Dock = System.Windows.Forms.DockStyle.Fill;
            labelRank.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelRank.Location = new System.Drawing.Point(4, 0);
            labelRank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelRank.Name = "labelRank";
            labelRank.Size = new System.Drawing.Size(12, 40);
            labelRank.TabIndex = 7;
            labelRank.Text = "1";
            labelRank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelRank.MouseLeave += UCEmployee_MouseLeave;
            labelRank.MouseMove += UCEmployee_MouseMove;
            // 
            // buttonAvailability
            // 
            buttonAvailability.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonAvailability.BackColor = System.Drawing.Color.Transparent;
            buttonAvailability.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonAvailability.BackgroundImage");
            buttonAvailability.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonAvailability.FlatAppearance.BorderSize = 0;
            buttonAvailability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAvailability.Location = new System.Drawing.Point(170, 9);
            buttonAvailability.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonAvailability.MotionHeight = true;
            buttonAvailability.MotionWidth = true;
            buttonAvailability.Name = "buttonAvailability";
            buttonAvailability.Size = new System.Drawing.Size(22, 22);
            buttonAvailability.TabIndex = 6;
            buttonAvailability.UseVisualStyleBackColor = true;
            buttonAvailability.Click += buttonAvailability_Click;
            buttonAvailability.MouseLeave += UCEmployee_MouseLeave;
            buttonAvailability.MouseMove += UCEmployee_MouseMove;
            // 
            // CheckBoxAppearance
            // 
            CheckBoxAppearance.Checked = true;
            CheckBoxAppearance.CheckState = System.Windows.Forms.CheckState.Checked;
            CheckBoxAppearance.Dock = System.Windows.Forms.DockStyle.Fill;
            CheckBoxAppearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CheckBoxAppearance.Location = new System.Drawing.Point(23, 3);
            CheckBoxAppearance.Name = "CheckBoxAppearance";
            CheckBoxAppearance.Size = new System.Drawing.Size(138, 34);
            CheckBoxAppearance.TabIndex = 8;
            CheckBoxAppearance.Text = "Elie Khalil";
            CheckBoxAppearance.UseVisualStyleBackColor = true;
            CheckBoxAppearance.CheckStateChanged += CheckBoxAppearance_CheckStateChanged;
            CheckBoxAppearance.MouseLeave += UCEmployee_MouseLeave;
            CheckBoxAppearance.MouseMove += UCEmployee_MouseMove;
            // 
            // iconButtonUp
            // 
            iconButtonUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            iconButtonUp.BackColor = System.Drawing.Color.Transparent;
            iconButtonUp.BackgroundImage = (System.Drawing.Image)resources.GetObject("iconButtonUp.BackgroundImage");
            iconButtonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            iconButtonUp.FlatAppearance.BorderSize = 0;
            iconButtonUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            iconButtonUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            iconButtonUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            iconButtonUp.Location = new System.Drawing.Point(205, 9);
            iconButtonUp.MotionHeight = true;
            iconButtonUp.MotionWidth = true;
            iconButtonUp.Name = "iconButtonUp";
            iconButtonUp.Size = new System.Drawing.Size(22, 22);
            iconButtonUp.TabIndex = 9;
            iconButtonUp.UseVisualStyleBackColor = false;
            iconButtonUp.Click += iconButtonUp_Click;
            iconButtonUp.MouseLeave += UCEmployee_MouseLeave;
            iconButtonUp.MouseMove += UCEmployee_MouseMove;
            // 
            // iconButtonDown
            // 
            iconButtonDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            iconButtonDown.BackColor = System.Drawing.Color.Transparent;
            iconButtonDown.BackgroundImage = (System.Drawing.Image)resources.GetObject("iconButtonDown.BackgroundImage");
            iconButtonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            iconButtonDown.FlatAppearance.BorderSize = 0;
            iconButtonDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            iconButtonDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            iconButtonDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            iconButtonDown.Location = new System.Drawing.Point(240, 9);
            iconButtonDown.MotionHeight = true;
            iconButtonDown.MotionWidth = true;
            iconButtonDown.Name = "iconButtonDown";
            iconButtonDown.Size = new System.Drawing.Size(22, 22);
            iconButtonDown.TabIndex = 9;
            iconButtonDown.UseVisualStyleBackColor = false;
            iconButtonDown.Click += iconButtonDown_Click;
            iconButtonDown.MouseLeave += UCEmployee_MouseLeave;
            iconButtonDown.MouseMove += UCEmployee_MouseMove;
            // 
            // UCEmployee
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(tableLayoutPanel1);
            Name = "UCEmployee";
            Size = new System.Drawing.Size(269, 40);
            MouseLeave += UCEmployee_MouseLeave;
            MouseMove += UCEmployee_MouseMove;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelRank;
        public System.Windows.Forms.CheckBox CheckBoxAppearance;
        private CustomizedTools.IconButton buttonAvailability;
        private CustomizedTools.IconButton iconButtonUp;
        private CustomizedTools.IconButton iconButtonDown;
    }
}
