namespace MKproject.Schedule
{
    partial class Employee
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
            panelContainsEmployees = new System.Windows.Forms.Panel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ButtonDone = new CustomizedTools.CustomButton();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelContainsEmployees
            // 
            panelContainsEmployees.AutoScroll = true;
            panelContainsEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            panelContainsEmployees.Location = new System.Drawing.Point(0, 0);
            panelContainsEmployees.Margin = new System.Windows.Forms.Padding(0);
            panelContainsEmployees.Name = "panelContainsEmployees";
            panelContainsEmployees.Size = new System.Drawing.Size(312, 380);
            panelContainsEmployees.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(ButtonDone, 0, 1);
            tableLayoutPanel1.Controls.Add(panelContainsEmployees, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(7, 11);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.3333359F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Size = new System.Drawing.Size(312, 456);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // ButtonDone
            // 
            ButtonDone.Anchor = System.Windows.Forms.AnchorStyles.None;
            ButtonDone.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(109, 122, 224);
            ButtonDone.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            ButtonDone.Cursor = System.Windows.Forms.Cursors.Hand;
            ButtonDone.FlatAppearance.BorderSize = 0;
            ButtonDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 142, 244);
            ButtonDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ButtonDone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ButtonDone.ForeColor = System.Drawing.Color.White;
            ButtonDone.Location = new System.Drawing.Point(105, 398);
            ButtonDone.Margin = new System.Windows.Forms.Padding(3, 4, 6, 4);
            ButtonDone.Name = "ButtonDone";
            ButtonDone.Size = new System.Drawing.Size(99, 39);
            ButtonDone.TabIndex = 1;
            ButtonDone.Text = "Done";
            ButtonDone.UseVisualStyleBackColor = false;
            ButtonDone.Click += buttonD_Click;
            // 
            // Employee
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(249, 246, 254);
            ClientSize = new System.Drawing.Size(326, 467);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            Name = "Employee";
            Padding = new System.Windows.Forms.Padding(7, 11, 7, 0);
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Deactivate += Employee_Deactivate;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelContainsEmployees;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public CustomizedTools.CustomButton ButtonDone;
    }
}