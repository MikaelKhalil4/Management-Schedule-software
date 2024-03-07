namespace MKproject.Schedule
{
    partial class ChooseService
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
            this.TLPglobal = new System.Windows.Forms.TableLayoutPanel();
            this.ucSlideButton = new CustomizedTools.UCSlideButton();
            this.labelFullName = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonChoose = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.TLPglobal.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPglobal
            // 
            this.TLPglobal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPglobal.ColumnCount = 1;
            this.TLPglobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 502F));
            this.TLPglobal.Controls.Add(this.ucSlideButton, 0, 1);
            this.TLPglobal.Controls.Add(this.labelFullName, 0, 0);
            this.TLPglobal.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.TLPglobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPglobal.Location = new System.Drawing.Point(0, 0);
            this.TLPglobal.Name = "TLPglobal";
            this.TLPglobal.RowCount = 4;
            this.TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPglobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.TLPglobal.Size = new System.Drawing.Size(502, 379);
            this.TLPglobal.TabIndex = 1;
            // 
            // ucSlideButton
            // 
            this.ucSlideButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucSlideButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(224)))));
            this.ucSlideButton.Button1text = "Available Package";
            this.ucSlideButton.Button2text = "Services";
            this.ucSlideButton.ClickedButton = null;
            this.ucSlideButton.Location = new System.Drawing.Point(117, 39);
            this.ucSlideButton.Name = "ucSlideButton";
            this.ucSlideButton.Size = new System.Drawing.Size(268, 39);
            this.ucSlideButton.TabIndex = 0;
            // 
            // labelFullName
            // 
            this.labelFullName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFullName.AutoSize = true;
            this.labelFullName.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullName.Location = new System.Drawing.Point(203, 6);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(96, 20);
            this.labelFullName.TabIndex = 11;
            this.labelFullName.Text = "Mikael khalil";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonChoose);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 340);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(496, 36);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // buttonChoose
            // 
            this.buttonChoose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonChoose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonChoose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChoose.FlatAppearance.BorderSize = 0;
            this.buttonChoose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(142)))), ((int)(((byte)(244)))));
            this.buttonChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChoose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonChoose.ForeColor = System.Drawing.Color.White;
            this.buttonChoose.Location = new System.Drawing.Point(403, 4);
            this.buttonChoose.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.buttonChoose.Name = "buttonChoose";
            this.buttonChoose.Size = new System.Drawing.Size(93, 29);
            this.buttonChoose.TabIndex = 732;
            this.buttonChoose.Text = "Choose";
            this.buttonChoose.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(97)))), ((int)(((byte)(99)))));
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(303, 3);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(93, 29);
            this.buttonCancel.TabIndex = 737;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // ChooseService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 379);
            this.Controls.Add(this.TLPglobal);
            this.Name = "ChooseService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChooseService";
            this.TLPglobal.ResumeLayout(false);
            this.TLPglobal.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPglobal;
        private CustomizedTools.UCSlideButton ucSlideButton;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonChoose;
        private System.Windows.Forms.Button buttonCancel;
    }
}