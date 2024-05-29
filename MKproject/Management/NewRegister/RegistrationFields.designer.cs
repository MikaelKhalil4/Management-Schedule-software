using CustomizedTools;

namespace MKproject.Management
{
    partial class RegistrationFields
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            dataGridViewFieldsNew = new DoubleBufferAndCustomScrollDataGrid();
            label1 = new System.Windows.Forms.Label();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            buttonSave = new CustomButton();
            buttonCancel = new CustomButton();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFieldsNew).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanel1.Controls.Add(dataGridViewFieldsNew, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.970149F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.31219F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.844741F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanel1.Size = new System.Drawing.Size(604, 564);
            tableLayoutPanel1.TabIndex = 20;
            // 
            // dataGridViewFieldsNew
            // 
            dataGridViewFieldsNew.AllowUserToAddRows = false;
            dataGridViewFieldsNew.AllowUserToDeleteRows = false;
            dataGridViewFieldsNew.AllowUserToResizeColumns = false;
            dataGridViewFieldsNew.AllowUserToResizeRows = false;
            dataGridViewFieldsNew.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewFieldsNew.BackgroundColor = System.Drawing.Color.White;
            dataGridViewFieldsNew.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewFieldsNew.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewFieldsNew.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewFieldsNew.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewFieldsNew.ColumnHeadersHeight = 50;
            dataGridViewFieldsNew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewFieldsNew.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewFieldsNew.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewFieldsNew.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewFieldsNew.EnableHeadersVisualStyles = false;
            dataGridViewFieldsNew.GridColor = System.Drawing.Color.White;
            dataGridViewFieldsNew.IsCustomScroll = true;
            dataGridViewFieldsNew.Location = new System.Drawing.Point(12, 36);
            dataGridViewFieldsNew.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            dataGridViewFieldsNew.MultiSelect = false;
            dataGridViewFieldsNew.Name = "dataGridViewFieldsNew";
            dataGridViewFieldsNew.ReadOnly = true;
            dataGridViewFieldsNew.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewFieldsNew.RowHeadersVisible = false;
            dataGridViewFieldsNew.RowHeadersWidth = 60;
            dataGridViewFieldsNew.RowTemplate.DividerHeight = 1;
            dataGridViewFieldsNew.RowTemplate.Height = 40;
            dataGridViewFieldsNew.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewFieldsNew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dataGridViewFieldsNew.Size = new System.Drawing.Size(580, 485);
            dataGridViewFieldsNew.TabIndex = 23;
            dataGridViewFieldsNew.CellClick += dataGridViewFieldsNew_CellClick;
            dataGridViewFieldsNew.CellFormatting += dataGridViewFieldsNew_CellFormatting;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(158, 1);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(287, 30);
            label1.TabIndex = 21;
            label1.Text = "Client Required Informations";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonSave);
            flowLayoutPanel1.Controls.Add(buttonCancel);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(4, 527);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(596, 34);
            flowLayoutPanel1.TabIndex = 24;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonSave.BackAndMouseHoverColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonSave.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(69, 82, 184);
            buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 142, 244);
            buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSave.ForeColor = System.Drawing.Color.White;
            buttonSave.Location = new System.Drawing.Point(499, 3);
            buttonSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(93, 29);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonCancel.BackAndMouseHoverColor = System.Drawing.Color.DarkGray;
            buttonCancel.BackColor = System.Drawing.Color.DarkGray;
            buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(129, 129, 129);
            buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(189, 189, 189);
            buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCancel.ForeColor = System.Drawing.Color.White;
            buttonCancel.Location = new System.Drawing.Point(398, 3);
            buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(93, 29);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // RegistrationFields
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(604, 564);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegistrationFields";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            FormClosing += RegistrationFields_FormClosing;
            Load += RegistrationFields_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFieldsNew).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        public DoubleBufferAndCustomScrollDataGrid dataGridViewFieldsNew;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private CustomButton buttonCancel;
        private CustomButton buttonSave;
    }
}