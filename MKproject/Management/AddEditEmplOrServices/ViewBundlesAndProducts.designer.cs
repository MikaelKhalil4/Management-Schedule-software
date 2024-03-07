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
            TLPMain = new System.Windows.Forms.TableLayoutPanel();
            buttonAdd = new System.Windows.Forms.Button();
            dataGridViewEdit = new CustomDataGridView();
            ucSlideButtonBundleProduct = new UCSlideButton();
            Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            TLPMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEdit).BeginInit();
            SuspendLayout();
            // 
            // TLPMain
            // 
            TLPMain.ColumnCount = 1;
            TLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPMain.Controls.Add(buttonAdd, 0, 1);
            TLPMain.Controls.Add(dataGridViewEdit, 0, 2);
            TLPMain.Controls.Add(ucSlideButtonBundleProduct, 0, 0);
            TLPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPMain.Location = new System.Drawing.Point(0, 0);
            TLPMain.Margin = new System.Windows.Forms.Padding(0);
            TLPMain.Name = "TLPMain";
            TLPMain.RowCount = 3;
            TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            TLPMain.Size = new System.Drawing.Size(955, 781);
            TLPMain.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonAdd.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonAdd.FlatAppearance.BorderSize = 0;
            buttonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(100, 112, 214);
            buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonAdd.ForeColor = System.Drawing.Color.White;
            buttonAdd.Location = new System.Drawing.Point(12, 117);
            buttonAdd.Margin = new System.Windows.Forms.Padding(12, 6, 18, 6);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new System.Drawing.Size(120, 33);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "Add Service";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // dataGridViewEdit
            // 
            dataGridViewEdit.AllowUserToAddRows = false;
            dataGridViewEdit.AllowUserToDeleteRows = false;
            dataGridViewEdit.AllowUserToResizeColumns = false;
            dataGridViewEdit.AllowUserToResizeRows = false;
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
            dataGridViewEdit.Size = new System.Drawing.Size(947, 619);
            dataGridViewEdit.TabIndex = 23;
            dataGridViewEdit.CellContentClick += dataGridViewEdit_CellContentClick;
            dataGridViewEdit.CellFormatting += dataGridViewEdit_CellFormatting;
            // 
            // ucSlideButtonBundleProduct
            // 
            ucSlideButtonBundleProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            ucSlideButtonBundleProduct.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            ucSlideButtonBundleProduct.Button1text = null;
            ucSlideButtonBundleProduct.Button2text = null;
            ucSlideButtonBundleProduct.ClickedButton = null;
            ucSlideButtonBundleProduct.Location = new System.Drawing.Point(343, 16);
            ucSlideButtonBundleProduct.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            ucSlideButtonBundleProduct.Name = "ucSlideButtonBundleProduct";
            ucSlideButtonBundleProduct.Size = new System.Drawing.Size(268, 46);
            ucSlideButtonBundleProduct.TabIndex = 0;
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
            // ViewBundlesAndProducts
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            ClientSize = new System.Drawing.Size(955, 781);
            Controls.Add(TLPMain);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "ViewBundlesAndProducts";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "EditPrices";
            Load += ViewBundlesAndProducts_Load;
            TLPMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewEdit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPMain;
        public CustomDataGridView dataGridViewEdit;
        private UCSlideButton ucSlideButtonBundleProduct;
        public System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}