using CustomizedTools;

namespace MKproject.Management
{
    partial class BackOffice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            FLPFilters = new System.Windows.Forms.FlowLayoutPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            dataGridViewBalance = new System.Windows.Forms.DataGridView();
            TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            buttonCancel = new System.Windows.Forms.Button();
            dataGridViewBackOffice = new CustomDataGridView();
            Action = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBalance).BeginInit();
            TLPGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBackOffice).BeginInit();
            SuspendLayout();
            // 
            // FLPFilters
            // 
            FLPFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            FLPFilters.Location = new System.Drawing.Point(4, 3);
            FLPFilters.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            FLPFilters.Name = "FLPFilters";
            FLPFilters.Size = new System.Drawing.Size(1388, 70);
            FLPFilters.TabIndex = 30;
            // 
            // timer1
            // 
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // timer2
            // 
            timer2.Interval = 1;
            timer2.Tick += timer2_Tick;
            // 
            // dataGridViewBalance
            // 
            dataGridViewBalance.AllowUserToAddRows = false;
            dataGridViewBalance.AllowUserToDeleteRows = false;
            dataGridViewBalance.AllowUserToResizeColumns = false;
            dataGridViewBalance.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewBalance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewBalance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBalance.BackgroundColor = System.Drawing.Color.White;
            dataGridViewBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewBalance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewBalance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewBalance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewBalance.ColumnHeadersHeight = 50;
            dataGridViewBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewBalance.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewBalance.EnableHeadersVisualStyles = false;
            dataGridViewBalance.Location = new System.Drawing.Point(12, 603);
            dataGridViewBalance.Margin = new System.Windows.Forms.Padding(12, 0, 12, 3);
            dataGridViewBalance.Name = "dataGridViewBalance";
            dataGridViewBalance.ReadOnly = true;
            dataGridViewBalance.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewBalance.RowHeadersVisible = false;
            dataGridViewBalance.RowHeadersWidth = 60;
            dataGridViewBalance.RowTemplate.DividerHeight = 1;
            dataGridViewBalance.RowTemplate.Height = 40;
            dataGridViewBalance.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewBalance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dataGridViewBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            dataGridViewBalance.Size = new System.Drawing.Size(1372, 115);
            dataGridViewBalance.TabIndex = 33;
            dataGridViewBalance.CellFormatting += dataGridViewBalance_CellFormatting;
            // 
            // TLPGlobal
            // 
            TLPGlobal.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPGlobal.ColumnCount = 1;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.Controls.Add(buttonCancel, 0, 3);
            TLPGlobal.Controls.Add(FLPFilters, 0, 0);
            TLPGlobal.Controls.Add(dataGridViewBackOffice, 0, 1);
            TLPGlobal.Controls.Add(dataGridViewBalance, 0, 2);
            TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 0);
            TLPGlobal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 4;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            TLPGlobal.Size = new System.Drawing.Size(1396, 767);
            TLPGlobal.TabIndex = 34;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonCancel.BackColor = System.Drawing.Color.FromArgb(95, 97, 99);
            buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(105, 107, 109);
            buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCancel.ForeColor = System.Drawing.Color.White;
            buttonCancel.Location = new System.Drawing.Point(1284, 727);
            buttonCancel.Margin = new System.Windows.Forms.Padding(12, 6, 4, 6);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(108, 33);
            buttonCancel.TabIndex = 737;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // dataGridViewBackOffice
            // 
            dataGridViewBackOffice.AllowUserToAddRows = false;
            dataGridViewBackOffice.AllowUserToDeleteRows = false;
            dataGridViewBackOffice.AllowUserToResizeColumns = false;
            dataGridViewBackOffice.AllowUserToResizeRows = false;
            dataGridViewBackOffice.BackgroundColor = System.Drawing.Color.White;
            dataGridViewBackOffice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewBackOffice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewBackOffice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewBackOffice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewBackOffice.ColumnHeadersHeight = 50;
            dataGridViewBackOffice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewBackOffice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Action });
            dataGridViewBackOffice.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewBackOffice.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewBackOffice.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewBackOffice.EnableHeadersVisualStyles = false;
            dataGridViewBackOffice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewBackOffice.GridColor = System.Drawing.Color.White;
            dataGridViewBackOffice.IsCustomScroll = true;
            dataGridViewBackOffice.IsRowColorChangeonMouseMove = true;
            dataGridViewBackOffice.IsSelectRow = false;
            dataGridViewBackOffice.Location = new System.Drawing.Point(12, 88);
            dataGridViewBackOffice.Margin = new System.Windows.Forms.Padding(12);
            dataGridViewBackOffice.MultiSelect = false;
            dataGridViewBackOffice.Name = "dataGridViewBackOffice";
            dataGridViewBackOffice.ReadOnly = true;
            dataGridViewBackOffice.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewBackOffice.RowHeadersVisible = false;
            dataGridViewBackOffice.RowHeadersWidth = 60;
            dataGridViewBackOffice.RowTemplate.DividerHeight = 1;
            dataGridViewBackOffice.RowTemplate.Height = 40;
            dataGridViewBackOffice.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewBackOffice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBackOffice.Size = new System.Drawing.Size(1372, 503);
            dataGridViewBackOffice.TabIndex = 31;
            dataGridViewBackOffice.CellContentClick += dataGridViewBackOffice_CellContentClick;
            dataGridViewBackOffice.CellFormatting += dataGridViewBackOffice_CellFormatting;
            // 
            // Action
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            Action.DefaultCellStyle = dataGridViewCellStyle5;
            Action.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            Action.HeaderText = "Action";
            Action.Name = "Action";
            Action.ReadOnly = true;
            Action.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            Action.Text = "Undo";
            Action.UseColumnTextForButtonValue = true;
            Action.Width = 587;
            // 
            // BackOffice
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1396, 767);
            Controls.Add(TLPGlobal);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BackOffice";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "BackOffice";
            FormClosing += BackOffice_FormClosing;
            Load += BackOffice_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBalance).EndInit();
            TLPGlobal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewBackOffice).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.FlowLayoutPanel FLPFilters;
        public CustomDataGridView dataGridViewBackOffice;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.DataGridView dataGridViewBalance;
        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
    }
}