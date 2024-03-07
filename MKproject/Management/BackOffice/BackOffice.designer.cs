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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FLPFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewBalance = new System.Windows.Forms.DataGridView();
            this.TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridViewBackOffice = new CustomizedTools.CustomDataGridView();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBalance)).BeginInit();
            this.TLPGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackOffice)).BeginInit();
            this.SuspendLayout();
            // 
            // FLPFilters
            // 
            this.FLPFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPFilters.Location = new System.Drawing.Point(3, 3);
            this.FLPFilters.Name = "FLPFilters";
            this.FLPFilters.Size = new System.Drawing.Size(1191, 60);
            this.FLPFilters.TabIndex = 30;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // dataGridViewBalance
            // 
            this.dataGridViewBalance.AllowUserToAddRows = false;
            this.dataGridViewBalance.AllowUserToDeleteRows = false;
            this.dataGridViewBalance.AllowUserToResizeColumns = false;
            this.dataGridViewBalance.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewBalance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBalance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBalance.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewBalance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewBalance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBalance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBalance.ColumnHeadersHeight = 50;
            this.dataGridViewBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBalance.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBalance.EnableHeadersVisualStyles = false;
            this.dataGridViewBalance.Location = new System.Drawing.Point(10, 523);
            this.dataGridViewBalance.Margin = new System.Windows.Forms.Padding(10, 0, 10, 3);
            this.dataGridViewBalance.Name = "dataGridViewBalance";
            this.dataGridViewBalance.ReadOnly = true;
            this.dataGridViewBalance.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewBalance.RowHeadersVisible = false;
            this.dataGridViewBalance.RowHeadersWidth = 60;
            this.dataGridViewBalance.RowTemplate.DividerHeight = 1;
            this.dataGridViewBalance.RowTemplate.Height = 40;
            this.dataGridViewBalance.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBalance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewBalance.Size = new System.Drawing.Size(1177, 99);
            this.dataGridViewBalance.TabIndex = 33;
            this.dataGridViewBalance.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewBalance_CellFormatting);
            // 
            // TLPGlobal
            // 
            this.TLPGlobal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPGlobal.ColumnCount = 1;
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPGlobal.Controls.Add(this.buttonCancel, 0, 3);
            this.TLPGlobal.Controls.Add(this.FLPFilters, 0, 0);
            this.TLPGlobal.Controls.Add(this.dataGridViewBackOffice, 0, 1);
            this.TLPGlobal.Controls.Add(this.dataGridViewBalance, 0, 2);
            this.TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPGlobal.Location = new System.Drawing.Point(0, 0);
            this.TLPGlobal.Name = "TLPGlobal";
            this.TLPGlobal.RowCount = 4;
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TLPGlobal.Size = new System.Drawing.Size(1197, 665);
            this.TLPGlobal.TabIndex = 34;
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
            this.buttonCancel.Location = new System.Drawing.Point(1101, 630);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(93, 29);
            this.buttonCancel.TabIndex = 737;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dataGridViewBackOffice
            // 
            this.dataGridViewBackOffice.AllowUserToAddRows = false;
            this.dataGridViewBackOffice.AllowUserToDeleteRows = false;
            this.dataGridViewBackOffice.AllowUserToResizeColumns = false;
            this.dataGridViewBackOffice.AllowUserToResizeRows = false;
            this.dataGridViewBackOffice.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBackOffice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewBackOffice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewBackOffice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBackOffice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewBackOffice.ColumnHeadersHeight = 50;
            this.dataGridViewBackOffice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewBackOffice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action});
            this.dataGridViewBackOffice.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBackOffice.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewBackOffice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBackOffice.EnableHeadersVisualStyles = false;
            this.dataGridViewBackOffice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridViewBackOffice.GridColor = System.Drawing.Color.White;
            this.dataGridViewBackOffice.IsCustomScroll = true;
            this.dataGridViewBackOffice.IsRowColorChangeonMouseMove = true;
            this.dataGridViewBackOffice.IsSelectRow = false;
            this.dataGridViewBackOffice.Location = new System.Drawing.Point(10, 76);
            this.dataGridViewBackOffice.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridViewBackOffice.MultiSelect = false;
            this.dataGridViewBackOffice.Name = "dataGridViewBackOffice";
            this.dataGridViewBackOffice.ReadOnly = true;
            this.dataGridViewBackOffice.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewBackOffice.RowHeadersVisible = false;
            this.dataGridViewBackOffice.RowHeadersWidth = 60;
            this.dataGridViewBackOffice.RowTemplate.DividerHeight = 1;
            this.dataGridViewBackOffice.RowTemplate.Height = 40;
            this.dataGridViewBackOffice.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBackOffice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBackOffice.Size = new System.Drawing.Size(1177, 437);
            this.dataGridViewBackOffice.TabIndex = 31;
            this.dataGridViewBackOffice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBackOffice_CellContentClick);
            this.dataGridViewBackOffice.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewBackOffice_CellFormatting);
            // 
            // Action
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.Action.DefaultCellStyle = dataGridViewCellStyle5;
            this.Action.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Action.Text = "Undo";
            this.Action.UseColumnTextForButtonValue = true;
            this.Action.Width = 587;
            // 
            // BackOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1197, 665);
            this.Controls.Add(this.TLPGlobal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackOffice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackOffice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackOffice_FormClosing);
            this.Load += new System.EventHandler(this.BackOffice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBalance)).EndInit();
            this.TLPGlobal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackOffice)).EndInit();
            this.ResumeLayout(false);

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