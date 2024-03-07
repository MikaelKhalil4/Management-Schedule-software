using CustomizedTools;

namespace MKproject.Management
{
    partial class ViewEmployee
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewEdit = new CustomDataGridView();
            buttonAdd = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEdit).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewEdit
            // 
            dataGridViewEdit.AllowUserToAddRows = false;
            dataGridViewEdit.AllowUserToDeleteRows = false;
            dataGridViewEdit.AllowUserToResizeColumns = false;
            dataGridViewEdit.AllowUserToResizeRows = false;
            dataGridViewEdit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEdit.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewEdit.BackgroundColor = System.Drawing.Color.White;
            dataGridViewEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewEdit.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewEdit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewEdit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewEdit.ColumnHeadersHeight = 50;
            dataGridViewEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewEdit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Edit });
            dataGridViewEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewEdit.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewEdit.EnableHeadersVisualStyles = false;
            dataGridViewEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewEdit.GridColor = System.Drawing.Color.White;
            dataGridViewEdit.IsCustomScroll = true;
            dataGridViewEdit.IsRowColorChangeonMouseMove = true;
            dataGridViewEdit.IsSelectRow = false;
            dataGridViewEdit.Location = new System.Drawing.Point(4, 159);
            dataGridViewEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dataGridViewEdit.MultiSelect = false;
            dataGridViewEdit.Name = "dataGridViewEdit";
            dataGridViewEdit.ReadOnly = true;
            dataGridViewEdit.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewEdit.RowHeadersVisible = false;
            dataGridViewEdit.RowHeadersWidth = 60;
            dataGridViewEdit.RowTemplate.DividerHeight = 1;
            dataGridViewEdit.RowTemplate.Height = 40;
            dataGridViewEdit.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dataGridViewEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEdit.Size = new System.Drawing.Size(1206, 619);
            dataGridViewEdit.TabIndex = 24;
            dataGridViewEdit.CellContentClick += dataGridViewEdit_CellContentClick;
            dataGridViewEdit.CellFormatting += dataGridViewEdit_CellFormatting;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonAdd.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonAdd.FlatAppearance.BorderSize = 0;
            buttonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(100, 112, 214);
            buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonAdd.ForeColor = System.Drawing.Color.White;
            buttonAdd.Location = new System.Drawing.Point(12, 117);
            buttonAdd.Margin = new System.Windows.Forms.Padding(12, 6, 18, 6);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new System.Drawing.Size(139, 33);
            buttonAdd.TabIndex = 25;
            buttonAdd.Text = "Add Employee";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(buttonAdd, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridViewEdit, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1214, 781);
            tableLayoutPanel1.TabIndex = 26;
            // 
            // Edit
            // 
            Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(109, 122, 224);
            Edit.DefaultCellStyle = dataGridViewCellStyle2;
            Edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            Edit.HeaderText = "Edit";
            Edit.MinimumWidth = 20;
            Edit.Name = "Edit";
            Edit.ReadOnly = true;
            Edit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            Edit.Text = "Edit";
            Edit.UseColumnTextForButtonValue = true;
            // 
            // ViewEmployee
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            ClientSize = new System.Drawing.Size(1214, 781);
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ViewEmployee";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "EditEmployee";
            Load += ViewEmployee_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEdit).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public CustomDataGridView dataGridViewEdit;
        public System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}