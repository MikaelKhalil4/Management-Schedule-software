using CustomizedTools;

namespace MKproject.Management
{
    partial class ViewBundlesAndProducts
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
            this.TLPMain = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridViewEdit = new CustomDataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ucSlideButtonBundleProduct = new UCSlideButton();
            this.TLPMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // TLPMain
            // 
            this.TLPMain.ColumnCount = 1;
            this.TLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPMain.Controls.Add(this.buttonAdd, 0, 1);
            this.TLPMain.Controls.Add(this.dataGridViewEdit, 0, 2);
            this.TLPMain.Controls.Add(this.ucSlideButtonBundleProduct, 0, 0);
            this.TLPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPMain.Location = new System.Drawing.Point(0, 0);
            this.TLPMain.Margin = new System.Windows.Forms.Padding(0);
            this.TLPMain.Name = "TLPMain";
            this.TLPMain.RowCount = 3;
            this.TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPMain.Size = new System.Drawing.Size(819, 677);
            this.TLPMain.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(112)))), ((int)(((byte)(214)))));
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(10, 100);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(10, 5, 15, 5);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(103, 29);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add Service";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dataGridViewEdit
            // 
            this.dataGridViewEdit.AllowUserToAddRows = false;
            this.dataGridViewEdit.AllowUserToDeleteRows = false;
            this.dataGridViewEdit.AllowUserToResizeColumns = false;
            this.dataGridViewEdit.AllowUserToResizeRows = false;
            this.dataGridViewEdit.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewEdit.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewEdit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEdit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEdit.ColumnHeadersHeight = 50;
            this.dataGridViewEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewEdit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit});
            this.dataGridViewEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEdit.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEdit.EnableHeadersVisualStyles = false;
            this.dataGridViewEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridViewEdit.GridColor = System.Drawing.Color.White;
            this.dataGridViewEdit.IsCustomScroll = true;
            this.dataGridViewEdit.IsRowColorChangeonMouseMove = true;
            this.dataGridViewEdit.IsSelectRow = false;
            this.dataGridViewEdit.Location = new System.Drawing.Point(3, 137);
            this.dataGridViewEdit.MultiSelect = false;
            this.dataGridViewEdit.Name = "dataGridViewEdit";
            this.dataGridViewEdit.ReadOnly = true;
            this.dataGridViewEdit.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewEdit.RowHeadersVisible = false;
            this.dataGridViewEdit.RowHeadersWidth = 60;
            this.dataGridViewEdit.RowTemplate.DividerHeight = 1;
            this.dataGridViewEdit.RowTemplate.Height = 40;
            this.dataGridViewEdit.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEdit.Size = new System.Drawing.Size(813, 537);
            this.dataGridViewEdit.TabIndex = 23;
            this.dataGridViewEdit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEdit_CellContentClick);
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.Edit.DefaultCellStyle = dataGridViewCellStyle2;
            this.Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Edit.HeaderText = "Edit";
            this.Edit.MinimumWidth = 20;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // ucSlideButtonBundleProduct
            // 
            this.ucSlideButtonBundleProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucSlideButtonBundleProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.ucSlideButtonBundleProduct.Location = new System.Drawing.Point(294, 13);
            this.ucSlideButtonBundleProduct.Name = "ucSlideButtonBundleProduct";
            this.ucSlideButtonBundleProduct.Size = new System.Drawing.Size(230, 40);
            this.ucSlideButtonBundleProduct.TabIndex = 0;
            // 
            // ViewBundlesAndProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(819, 677);
            this.Controls.Add(this.TLPMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewBundlesAndProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditPrices";
            this.Load += new System.EventHandler(this.ViewBundlesAndProducts_Load);
            this.TLPMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPMain;
        public CustomDataGridView dataGridViewEdit;
        private UCSlideButton ucSlideButtonBundleProduct;
        public System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}