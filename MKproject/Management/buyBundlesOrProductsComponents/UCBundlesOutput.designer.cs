using CustomizedTools;

namespace MKproject.Management
{
    partial class UCBundlesOutput
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewBundles = new DoubleBufferAndCustomScrollDataGrid();
            this.ColumnCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BundleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BundleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SessionNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bundletype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberShip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBundles)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBundles
            // 
            this.dataGridViewBundles.AllowUserToAddRows = false;
            this.dataGridViewBundles.AllowUserToDeleteRows = false;
            this.dataGridViewBundles.AllowUserToResizeColumns = false;
            this.dataGridViewBundles.AllowUserToResizeRows = false;
            this.dataGridViewBundles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBundles.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBundles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewBundles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewBundles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewBundles.ColumnHeadersHeight = 50;
            this.dataGridViewBundles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewBundles.ColumnHeadersVisible = false;
            this.dataGridViewBundles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheck,
            this.BundleID,
            this.BundleName,
            this.Description,
            this.SessionNumber,
            this.bundletype,
            this.Price,
            this.MemberShip});
            this.dataGridViewBundles.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBundles.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBundles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBundles.EnableHeadersVisualStyles = false;
            this.dataGridViewBundles.GridColor = System.Drawing.Color.White;
            this.dataGridViewBundles.IsCustomScroll = true;
            this.dataGridViewBundles.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBundles.MultiSelect = false;
            this.dataGridViewBundles.Name = "dataGridViewBundles";
            this.dataGridViewBundles.ReadOnly = true;
            this.dataGridViewBundles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewBundles.RowHeadersVisible = false;
            this.dataGridViewBundles.RowHeadersWidth = 60;
            this.dataGridViewBundles.RowTemplate.DividerHeight = 1;
            this.dataGridViewBundles.RowTemplate.Height = 40;
            this.dataGridViewBundles.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBundles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewBundles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBundles.Size = new System.Drawing.Size(443, 320);
            this.dataGridViewBundles.TabIndex = 0;
            this.dataGridViewBundles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBundles_CellClick);
            // 
            // ColumnCheck
            // 
            this.ColumnCheck.FillWeight = 10F;
            this.ColumnCheck.HeaderText = "ColumnCheck";
            this.ColumnCheck.Name = "ColumnCheck";
            this.ColumnCheck.ReadOnly = true;
            this.ColumnCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BundleID
            // 
            this.BundleID.HeaderText = "BundleID";
            this.BundleID.Name = "BundleID";
            this.BundleID.ReadOnly = true;
            this.BundleID.Visible = false;
            // 
            // BundleName
            // 
            this.BundleName.FillWeight = 22.5F;
            this.BundleName.HeaderText = "BundleName";
            this.BundleName.Name = "BundleName";
            this.BundleName.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.FillWeight = 22.5F;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // SessionNumber
            // 
            this.SessionNumber.FillWeight = 22.5F;
            this.SessionNumber.HeaderText = "SessionNumber";
            this.SessionNumber.Name = "SessionNumber";
            this.SessionNumber.ReadOnly = true;
            // 
            // bundletype
            // 
            this.bundletype.HeaderText = "bundletype";
            this.bundletype.Name = "bundletype";
            this.bundletype.ReadOnly = true;
            this.bundletype.Visible = false;
            // 
            // Price
            // 
            this.Price.FillWeight = 22.5F;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // MemberShip
            // 
            this.MemberShip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MemberShip.HeaderText = "MemberShip";
            this.MemberShip.Name = "MemberShip";
            this.MemberShip.ReadOnly = true;
            this.MemberShip.Width = 5;
            // 
            // UCBundlesOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewBundles);
            this.Name = "UCBundlesOutput";
            this.Size = new System.Drawing.Size(443, 320);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBundles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferAndCustomScrollDataGrid dataGridViewBundles;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn BundleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BundleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn SessionNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn bundletype;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberShip;
    }
}
