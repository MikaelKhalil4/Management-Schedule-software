using CustomizedTools;

namespace MKproject
{
    partial class Search
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            textBoxSearch = new System.Windows.Forms.TextBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            dataGridViewMembers = new CustomDataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMembers).BeginInit();
            SuspendLayout();
            // 
            // textBoxSearch
            // 
            textBoxSearch.BackColor = System.Drawing.Color.White;
            textBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxSearch.Location = new System.Drawing.Point(0, 0);
            textBoxSearch.Margin = new System.Windows.Forms.Padding(0);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new System.Drawing.Size(414, 29);
            textBoxSearch.TabIndex = 20;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(textBoxSearch, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridViewMembers, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            tableLayoutPanel1.Size = new System.Drawing.Size(414, 211);
            tableLayoutPanel1.TabIndex = 21;
            // 
            // dataGridViewMembers
            // 
            dataGridViewMembers.AllowUserToAddRows = false;
            dataGridViewMembers.AllowUserToDeleteRows = false;
            dataGridViewMembers.AllowUserToResizeColumns = false;
            dataGridViewMembers.AllowUserToResizeRows = false;
            dataGridViewMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMembers.BackgroundColor = System.Drawing.Color.White;
            dataGridViewMembers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewMembers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewMembers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewMembers.ColumnHeadersHeight = 50;
            dataGridViewMembers.ColumnHeadersVisible = false;
            dataGridViewMembers.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewMembers.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewMembers.EnableHeadersVisualStyles = false;
            dataGridViewMembers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewMembers.IsCustomScroll = true;
            dataGridViewMembers.IsRowColorChangeonMouseMove = false;
            dataGridViewMembers.IsSelectRow = false;
            dataGridViewMembers.Location = new System.Drawing.Point(2, 35);
            dataGridViewMembers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            dataGridViewMembers.Name = "dataGridViewMembers";
            dataGridViewMembers.ReadOnly = true;
            dataGridViewMembers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewMembers.RowHeadersVisible = false;
            dataGridViewMembers.RowHeadersWidth = 60;
            dataGridViewMembers.RowTemplate.DividerHeight = 1;
            dataGridViewMembers.RowTemplate.Height = 40;
            dataGridViewMembers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewMembers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dataGridViewMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMembers.Size = new System.Drawing.Size(410, 176);
            dataGridViewMembers.TabIndex = 19;
            dataGridViewMembers.CellFormatting += dataGridViewMembers_CellFormatting;
            dataGridViewMembers.CellMouseClick += dataGridViewMembers_CellMouseClick;
            dataGridViewMembers.CellMouseLeave += dataGridViewMembers_CellMouseLeave;
            dataGridViewMembers.CellMouseMove += dataGridViewMembers_CellMouseMove;
            // 
            // Search
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ActiveCaption;
            ClientSize = new System.Drawing.Size(414, 213);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Search";
            Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "SearchName";
            Deactivate += Search_Deactivate;
            Load += Search_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMembers).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private CustomDataGridView dataGridViewMembers;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}