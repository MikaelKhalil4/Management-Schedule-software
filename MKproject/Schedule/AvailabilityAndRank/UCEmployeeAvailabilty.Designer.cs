

namespace MKproject.Schedule

{
    partial class UCEmployeeAvailabilty
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
            TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            ButtonUpdate = new CustomizedTools.CustomButton();
            buttonCancel = new CustomizedTools.CustomButton();
            labelEmployeeName = new System.Windows.Forms.Label();
            TLPGlobal.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // TLPGlobal
            // 
            TLPGlobal.BackColor = System.Drawing.Color.White;
            TLPGlobal.ColumnCount = 1;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.Controls.Add(flowLayoutPanel3, 0, 3);
            TLPGlobal.Controls.Add(labelEmployeeName, 0, 0);
            TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 0);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 4;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            TLPGlobal.Size = new System.Drawing.Size(1123, 654);
            TLPGlobal.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(ButtonUpdate);
            flowLayoutPanel3.Controls.Add(buttonCancel);
            flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel3.Location = new System.Drawing.Point(3, 616);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new System.Drawing.Size(1117, 35);
            flowLayoutPanel3.TabIndex = 748;
            // 
            // ButtonUpdate
            // 
            ButtonUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            ButtonUpdate.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(109, 122, 224);
            ButtonUpdate.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            ButtonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            ButtonUpdate.FlatAppearance.BorderSize = 0;
            ButtonUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(69, 82, 184);
            ButtonUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 142, 244);
            ButtonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ButtonUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ButtonUpdate.ForeColor = System.Drawing.Color.White;
            ButtonUpdate.Location = new System.Drawing.Point(1019, 3);
            ButtonUpdate.Name = "ButtonUpdate";
            ButtonUpdate.Size = new System.Drawing.Size(95, 29);
            ButtonUpdate.TabIndex = 0;
            ButtonUpdate.Text = "Update";
            ButtonUpdate.UseVisualStyleBackColor = false;
            ButtonUpdate.Click += ButtonUpdate_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonCancel.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(95, 97, 99);
            buttonCancel.BackColor = System.Drawing.Color.FromArgb(95, 97, 99);
            buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(55, 57, 59);
            buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(75, 77, 79);
            buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCancel.ForeColor = System.Drawing.Color.White;
            buttonCancel.Location = new System.Drawing.Point(918, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(95, 29);
            buttonCancel.TabIndex = 742;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // labelEmployeeName
            // 
            labelEmployeeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            labelEmployeeName.AutoSize = true;
            labelEmployeeName.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelEmployeeName.Location = new System.Drawing.Point(500, 2);
            labelEmployeeName.Name = "labelEmployeeName";
            labelEmployeeName.Size = new System.Drawing.Size(123, 25);
            labelEmployeeName.TabIndex = 749;
            labelEmployeeName.Text = "Mikael Khalil";
            // 
            // UCEmployeeAvailabilty
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(TLPGlobal);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UCEmployeeAvailabilty";
            Size = new System.Drawing.Size(1123, 654);
            TLPGlobal.ResumeLayout(false);
            TLPGlobal.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        public CustomizedTools.CustomButton ButtonUpdate;
        public CustomizedTools.CustomButton buttonCancel;
        private System.Windows.Forms.Label labelEmployeeName;
    }
}