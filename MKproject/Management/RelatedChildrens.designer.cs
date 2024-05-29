using CustomizedTools;

namespace MKproject.Management
{
    partial class RelatedChildrens
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
            TLPMain = new System.Windows.Forms.TableLayoutPanel();
            dataGridViewChildren = new CustomDataGridView();
            timer1 = new System.Windows.Forms.Timer(components);
            TLPMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChildren).BeginInit();
            SuspendLayout();
            // 
            // TLPMain
            // 
            TLPMain.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPMain.ColumnCount = 1;
            TLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            TLPMain.Controls.Add(dataGridViewChildren, 0, 0);
            TLPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPMain.Location = new System.Drawing.Point(0, 0);
            TLPMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPMain.Name = "TLPMain";
            TLPMain.RowCount = 1;
            TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.47369F));
            TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            TLPMain.Size = new System.Drawing.Size(448, 417);
            TLPMain.TabIndex = 27;
            // 
            // dataGridViewChildren
            // 
            dataGridViewChildren.AllowUserToAddRows = false;
            dataGridViewChildren.AllowUserToDeleteRows = false;
            dataGridViewChildren.AllowUserToResizeColumns = false;
            dataGridViewChildren.AllowUserToResizeRows = false;
            dataGridViewChildren.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewChildren.BackgroundColor = System.Drawing.Color.White;
            dataGridViewChildren.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewChildren.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewChildren.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewChildren.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewChildren.ColumnHeadersHeight = 50;
            dataGridViewChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewChildren.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewChildren.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewChildren.EnableHeadersVisualStyles = false;
            dataGridViewChildren.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewChildren.GridColor = System.Drawing.Color.White;
            dataGridViewChildren.IsCustomScroll = true;
            dataGridViewChildren.IsRowColorChangeonMouseMove = true;
            dataGridViewChildren.IsSelectRow = false;
            dataGridViewChildren.Location = new System.Drawing.Point(6, 6);
            dataGridViewChildren.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            dataGridViewChildren.MultiSelect = false;
            dataGridViewChildren.Name = "dataGridViewChildren";
            dataGridViewChildren.ReadOnly = true;
            dataGridViewChildren.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewChildren.RowHeadersVisible = false;
            dataGridViewChildren.RowHeadersWidth = 60;
            dataGridViewChildren.RowTemplate.DividerHeight = 1;
            dataGridViewChildren.RowTemplate.Height = 40;
            dataGridViewChildren.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewChildren.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dataGridViewChildren.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewChildren.Size = new System.Drawing.Size(436, 405);
            dataGridViewChildren.TabIndex = 26;
            dataGridViewChildren.CellClick += dataGridViewChildren_CellClick;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // RelatedChildrens
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(448, 417);
            Controls.Add(TLPMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RelatedChildrens";
            Opacity = 0D;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "RelatedChildrens";
            Deactivate += RelatedChildrens_Deactivate;
            FormClosing += RelatedChildrens_FormClosing;
            Load += RelatedChildrens_Load;
            TLPMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewChildren).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLPMain;
        private System.Windows.Forms.Timer timer1;
        public CustomDataGridView dataGridViewChildren;
    }
}