
using CustomizedTools;

namespace MKproject.Management
{
    partial class ClientManagementProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientManagementProfile));
            TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            TLPdatagrid = new System.Windows.Forms.TableLayoutPanel();
            TLPBalance = new System.Windows.Forms.TableLayoutPanel();
            buttonBackOffice = new System.Windows.Forms.Button();
            dataGridViewBalance = new CustomDataGridView();
            PayOrEdit = new System.Windows.Forms.DataGridViewImageColumn();
            Transactions = new System.Windows.Forms.DataGridViewImageColumn();
            buttonPayTotalBalance = new System.Windows.Forms.Button();
            panelServiceBalance = new System.Windows.Forms.Panel();
            labelServiceBalance = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            panelTotalBalance = new System.Windows.Forms.Panel();
            labelTotalBalance = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            panelProductBalance = new System.Windows.Forms.Panel();
            labelProductBalance = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            TLPAdd = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            buttonAddProduct = new System.Windows.Forms.Button();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            buttonAddPAckge = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            TLPInfo = new System.Windows.Forms.TableLayoutPanel();
            panelSecondaryInfo = new System.Windows.Forms.Panel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            buttonEditClientInfo = new IconButton();
            panelPrimaryInfo = new System.Windows.Forms.Panel();
            UCMemberSince = new UCLabelAndDetail();
            UCLastVisit = new UCLabelAndDetail();
            TLPAlbum = new System.Windows.Forms.TableLayoutPanel();
            buttonEditAlbum = new IconButton();
            UCAlbum = new UCLabelAndDetail();
            labelName = new System.Windows.Forms.Label();
            iconButtonImage = new IconButton();
            TLPHistory = new System.Windows.Forms.TableLayoutPanel();
            UCpaymentsTotal = new UCLabelAndDetail();
            UCpaymentsServices = new UCLabelAndDetail();
            UCTotalAttendance = new UCLabelAndDetail();
            UCTokenServices = new UCLabelAndDetail();
            UCpaymentsProducts = new UCLabelAndDetail();
            UCTokenProducts = new UCLabelAndDetail();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            timer1 = new System.Windows.Forms.Timer(components);
            TLPGlobal.SuspendLayout();
            TLPdatagrid.SuspendLayout();
            TLPBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBalance).BeginInit();
            panelServiceBalance.SuspendLayout();
            panelTotalBalance.SuspendLayout();
            panelProductBalance.SuspendLayout();
            TLPAdd.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            TLPInfo.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panelPrimaryInfo.SuspendLayout();
            TLPAlbum.SuspendLayout();
            TLPHistory.SuspendLayout();
            SuspendLayout();
            // 
            // TLPGlobal
            // 
            TLPGlobal.BackColor = System.Drawing.Color.White;
            TLPGlobal.ColumnCount = 2;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.09663F));
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.90337F));
            TLPGlobal.Controls.Add(TLPdatagrid, 1, 0);
            TLPGlobal.Controls.Add(tableLayoutPanel1, 0, 0);
            TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 0);
            TLPGlobal.Margin = new System.Windows.Forms.Padding(6);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 1;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 715F));
            TLPGlobal.Size = new System.Drawing.Size(1435, 846);
            TLPGlobal.TabIndex = 21;
            // 
            // TLPdatagrid
            // 
            TLPdatagrid.ColumnCount = 1;
            TLPdatagrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPdatagrid.Controls.Add(TLPBalance, 0, 2);
            TLPdatagrid.Controls.Add(TLPAdd, 0, 0);
            TLPdatagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPdatagrid.Location = new System.Drawing.Point(651, 0);
            TLPdatagrid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 7);
            TLPdatagrid.Name = "TLPdatagrid";
            TLPdatagrid.RowCount = 3;
            TLPdatagrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.23173F));
            TLPdatagrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.84339F));
            TLPdatagrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.92489F));
            TLPdatagrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            TLPdatagrid.Size = new System.Drawing.Size(780, 839);
            TLPdatagrid.TabIndex = 21;
            // 
            // TLPBalance
            // 
            TLPBalance.BackColor = System.Drawing.Color.FromArgb(238, 241, 254);
            TLPBalance.ColumnCount = 5;
            TLPBalance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            TLPBalance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            TLPBalance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            TLPBalance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            TLPBalance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            TLPBalance.Controls.Add(buttonBackOffice, 5, 0);
            TLPBalance.Controls.Add(dataGridViewBalance, 0, 1);
            TLPBalance.Controls.Add(buttonPayTotalBalance, 3, 0);
            TLPBalance.Controls.Add(panelServiceBalance, 0, 0);
            TLPBalance.Controls.Add(panelTotalBalance, 2, 0);
            TLPBalance.Controls.Add(panelProductBalance, 1, 0);
            TLPBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPBalance.Location = new System.Drawing.Point(4, 425);
            TLPBalance.Margin = new System.Windows.Forms.Padding(4, 6, 6, 0);
            TLPBalance.Name = "TLPBalance";
            TLPBalance.RowCount = 2;
            TLPBalance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLPBalance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            TLPBalance.Size = new System.Drawing.Size(770, 414);
            TLPBalance.TabIndex = 25;
            // 
            // buttonBackOffice
            // 
            buttonBackOffice.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonBackOffice.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonBackOffice.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonBackOffice.FlatAppearance.BorderSize = 0;
            buttonBackOffice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 142, 244);
            buttonBackOffice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonBackOffice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonBackOffice.ForeColor = System.Drawing.Color.White;
            buttonBackOffice.Location = new System.Drawing.Point(641, 12);
            buttonBackOffice.Margin = new System.Windows.Forms.Padding(12);
            buttonBackOffice.Name = "buttonBackOffice";
            buttonBackOffice.Size = new System.Drawing.Size(117, 58);
            buttonBackOffice.TabIndex = 23;
            buttonBackOffice.Text = "All Transactions";
            buttonBackOffice.UseVisualStyleBackColor = false;
            buttonBackOffice.Click += buttonBackOffice_Click;
            // 
            // dataGridViewBalance
            // 
            dataGridViewBalance.AllowUserToAddRows = false;
            dataGridViewBalance.AllowUserToDeleteRows = false;
            dataGridViewBalance.AllowUserToResizeColumns = false;
            dataGridViewBalance.AllowUserToResizeRows = false;
            dataGridViewBalance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBalance.BackgroundColor = System.Drawing.Color.White;
            dataGridViewBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewBalance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewBalance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewBalance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewBalance.ColumnHeadersHeight = 50;
            dataGridViewBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { PayOrEdit, Transactions });
            TLPBalance.SetColumnSpan(dataGridViewBalance, 5);
            dataGridViewBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewBalance.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewBalance.EnableHeadersVisualStyles = false;
            dataGridViewBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewBalance.GridColor = System.Drawing.Color.White;
            dataGridViewBalance.IsCustomScroll = true;
            dataGridViewBalance.IsRowColorChangeonMouseMove = true;
            dataGridViewBalance.IsSelectRow = false;
            dataGridViewBalance.Location = new System.Drawing.Point(8, 82);
            dataGridViewBalance.Margin = new System.Windows.Forms.Padding(8, 0, 8, 8);
            dataGridViewBalance.MultiSelect = false;
            dataGridViewBalance.Name = "dataGridViewBalance";
            dataGridViewBalance.ReadOnly = true;
            dataGridViewBalance.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewBalance.RowHeadersVisible = false;
            dataGridViewBalance.RowHeadersWidth = 60;
            dataGridViewBalance.RowTemplate.DividerHeight = 1;
            dataGridViewBalance.RowTemplate.Height = 43;
            dataGridViewBalance.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewBalance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dataGridViewBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBalance.Size = new System.Drawing.Size(754, 324);
            dataGridViewBalance.TabIndex = 22;
            dataGridViewBalance.CellClick += dataGridViewBalance_CellClick;
            dataGridViewBalance.CellFormatting += dataGridViewBalance_CellFormatting;
            dataGridViewBalance.CellMouseEnter += dataGridViewBalance_CellMouseEnter;
            dataGridViewBalance.CellMouseLeave += dataGridViewBalance_CellMouseLeave;
            // 
            // PayOrEdit
            // 
            PayOrEdit.FillWeight = 5F;
            PayOrEdit.HeaderText = "";
            PayOrEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            PayOrEdit.Name = "PayOrEdit";
            PayOrEdit.ReadOnly = true;
            PayOrEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            PayOrEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Transactions
            // 
            Transactions.FillWeight = 5F;
            Transactions.HeaderText = "";
            Transactions.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Transactions.Name = "Transactions";
            Transactions.ReadOnly = true;
            Transactions.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Transactions.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // buttonPayTotalBalance
            // 
            buttonPayTotalBalance.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonPayTotalBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonPayTotalBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonPayTotalBalance.FlatAppearance.BorderSize = 0;
            buttonPayTotalBalance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 142, 244);
            buttonPayTotalBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonPayTotalBalance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonPayTotalBalance.ForeColor = System.Drawing.Color.White;
            buttonPayTotalBalance.Location = new System.Drawing.Point(522, 12);
            buttonPayTotalBalance.Margin = new System.Windows.Forms.Padding(12);
            buttonPayTotalBalance.Name = "buttonPayTotalBalance";
            buttonPayTotalBalance.Size = new System.Drawing.Size(95, 58);
            buttonPayTotalBalance.TabIndex = 2;
            buttonPayTotalBalance.Text = "Pay All";
            buttonPayTotalBalance.UseVisualStyleBackColor = false;
            buttonPayTotalBalance.Click += buttonPayTotalBalance_Click;
            // 
            // panelServiceBalance
            // 
            panelServiceBalance.BackColor = System.Drawing.Color.White;
            panelServiceBalance.Controls.Add(labelServiceBalance);
            panelServiceBalance.Controls.Add(label2);
            panelServiceBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            panelServiceBalance.Location = new System.Drawing.Point(8, 8);
            panelServiceBalance.Margin = new System.Windows.Forms.Padding(8);
            panelServiceBalance.Name = "panelServiceBalance";
            panelServiceBalance.Size = new System.Drawing.Size(154, 66);
            panelServiceBalance.TabIndex = 0;
            // 
            // labelServiceBalance
            // 
            labelServiceBalance.Dock = System.Windows.Forms.DockStyle.Top;
            labelServiceBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelServiceBalance.ForeColor = System.Drawing.Color.Red;
            labelServiceBalance.Location = new System.Drawing.Point(0, 24);
            labelServiceBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelServiceBalance.Name = "labelServiceBalance";
            labelServiceBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            labelServiceBalance.Size = new System.Drawing.Size(154, 35);
            labelServiceBalance.TabIndex = 1;
            labelServiceBalance.Text = "-$150";
            labelServiceBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Dock = System.Windows.Forms.DockStyle.Top;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            label2.Location = new System.Drawing.Point(0, 0);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(154, 24);
            label2.TabIndex = 0;
            label2.Text = "Services Balance";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTotalBalance
            // 
            panelTotalBalance.BackColor = System.Drawing.Color.White;
            panelTotalBalance.Controls.Add(labelTotalBalance);
            panelTotalBalance.Controls.Add(label5);
            panelTotalBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTotalBalance.Location = new System.Drawing.Point(348, 8);
            panelTotalBalance.Margin = new System.Windows.Forms.Padding(8);
            panelTotalBalance.Name = "panelTotalBalance";
            panelTotalBalance.Size = new System.Drawing.Size(154, 66);
            panelTotalBalance.TabIndex = 1;
            // 
            // labelTotalBalance
            // 
            labelTotalBalance.Dock = System.Windows.Forms.DockStyle.Top;
            labelTotalBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTotalBalance.ForeColor = System.Drawing.Color.Red;
            labelTotalBalance.Location = new System.Drawing.Point(0, 24);
            labelTotalBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelTotalBalance.Name = "labelTotalBalance";
            labelTotalBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            labelTotalBalance.Size = new System.Drawing.Size(154, 35);
            labelTotalBalance.TabIndex = 1;
            labelTotalBalance.Text = "-$300";
            labelTotalBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Dock = System.Windows.Forms.DockStyle.Top;
            label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            label5.Location = new System.Drawing.Point(0, 0);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(154, 24);
            label5.TabIndex = 0;
            label5.Text = "Total Balance";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelProductBalance
            // 
            panelProductBalance.BackColor = System.Drawing.Color.White;
            panelProductBalance.Controls.Add(labelProductBalance);
            panelProductBalance.Controls.Add(label6);
            panelProductBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            panelProductBalance.Location = new System.Drawing.Point(178, 8);
            panelProductBalance.Margin = new System.Windows.Forms.Padding(8);
            panelProductBalance.Name = "panelProductBalance";
            panelProductBalance.Size = new System.Drawing.Size(154, 66);
            panelProductBalance.TabIndex = 2;
            // 
            // labelProductBalance
            // 
            labelProductBalance.Dock = System.Windows.Forms.DockStyle.Top;
            labelProductBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelProductBalance.ForeColor = System.Drawing.Color.Red;
            labelProductBalance.Location = new System.Drawing.Point(0, 24);
            labelProductBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelProductBalance.Name = "labelProductBalance";
            labelProductBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            labelProductBalance.Size = new System.Drawing.Size(154, 35);
            labelProductBalance.TabIndex = 1;
            labelProductBalance.Text = "-$150";
            labelProductBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Dock = System.Windows.Forms.DockStyle.Top;
            label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            label6.Location = new System.Drawing.Point(0, 0);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(154, 24);
            label6.TabIndex = 0;
            label6.Text = "Product Balance";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TLPAdd
            // 
            TLPAdd.BackColor = System.Drawing.Color.White;
            TLPAdd.ColumnCount = 2;
            TLPAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            TLPAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            TLPAdd.Controls.Add(tableLayoutPanel5, 1, 0);
            TLPAdd.Controls.Add(tableLayoutPanel4, 0, 0);
            TLPAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPAdd.Location = new System.Drawing.Point(4, 6);
            TLPAdd.Margin = new System.Windows.Forms.Padding(4, 6, 6, 6);
            TLPAdd.Name = "TLPAdd";
            TLPAdd.RowCount = 1;
            TLPAdd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPAdd.Size = new System.Drawing.Size(770, 132);
            TLPAdd.TabIndex = 27;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(238, 241, 254);
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(buttonAddProduct, 0, 0);
            tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel5.Location = new System.Drawing.Point(385, 6);
            tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0, 6, 6, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new System.Drawing.Size(379, 126);
            tableLayoutPanel5.TabIndex = 6;
            // 
            // buttonAddProduct
            // 
            buttonAddProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonAddProduct.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonAddProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonAddProduct.FlatAppearance.BorderSize = 0;
            buttonAddProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 142, 244);
            buttonAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAddProduct.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonAddProduct.ForeColor = System.Drawing.Color.White;
            buttonAddProduct.Location = new System.Drawing.Point(96, 25);
            buttonAddProduct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonAddProduct.Name = "buttonAddProduct";
            buttonAddProduct.Size = new System.Drawing.Size(186, 76);
            buttonAddProduct.TabIndex = 1;
            buttonAddProduct.Text = "Add\r\nProduct";
            buttonAddProduct.UseVisualStyleBackColor = false;
            buttonAddProduct.Click += buttonAddProduct_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(238, 241, 254);
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(buttonAddPAckge, 0, 0);
            tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel4.Location = new System.Drawing.Point(0, 6);
            tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0, 6, 6, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new System.Drawing.Size(379, 126);
            tableLayoutPanel4.TabIndex = 5;
            // 
            // buttonAddPAckge
            // 
            buttonAddPAckge.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonAddPAckge.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonAddPAckge.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonAddPAckge.FlatAppearance.BorderSize = 0;
            buttonAddPAckge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 142, 244);
            buttonAddPAckge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAddPAckge.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonAddPAckge.ForeColor = System.Drawing.Color.White;
            buttonAddPAckge.Location = new System.Drawing.Point(96, 26);
            buttonAddPAckge.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonAddPAckge.Name = "buttonAddPAckge";
            buttonAddPAckge.Size = new System.Drawing.Size(186, 73);
            buttonAddPAckge.TabIndex = 0;
            buttonAddPAckge.Text = "Add\r\n Service";
            buttonAddPAckge.UseVisualStyleBackColor = false;
            buttonAddPAckge.Click += buttonAddPAckge_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(TLPInfo, 0, 0);
            tableLayoutPanel1.Controls.Add(TLPHistory, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(4, 3);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.77548F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.22452F));
            tableLayoutPanel1.Size = new System.Drawing.Size(639, 840);
            tableLayoutPanel1.TabIndex = 22;
            // 
            // TLPInfo
            // 
            TLPInfo.ColumnCount = 2;
            TLPInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.68354F));
            TLPInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.31646F));
            TLPInfo.Controls.Add(panelSecondaryInfo, 1, 0);
            TLPInfo.Controls.Add(tableLayoutPanel2, 0, 0);
            TLPInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPInfo.Location = new System.Drawing.Point(4, 3);
            TLPInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPInfo.Name = "TLPInfo";
            TLPInfo.RowCount = 1;
            TLPInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 628F));
            TLPInfo.Size = new System.Drawing.Size(631, 630);
            TLPInfo.TabIndex = 0;
            // 
            // panelSecondaryInfo
            // 
            panelSecondaryInfo.AutoScroll = true;
            panelSecondaryInfo.BackColor = System.Drawing.Color.FromArgb(238, 241, 254);
            panelSecondaryInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSecondaryInfo.Location = new System.Drawing.Point(319, 6);
            panelSecondaryInfo.Margin = new System.Windows.Forms.Padding(6);
            panelSecondaryInfo.Name = "panelSecondaryInfo";
            panelSecondaryInfo.Size = new System.Drawing.Size(306, 618);
            panelSecondaryInfo.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(238, 241, 254);
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Controls.Add(panelPrimaryInfo, 0, 3);
            tableLayoutPanel2.Controls.Add(labelName, 0, 2);
            tableLayoutPanel2.Controls.Add(iconButtonImage, 0, 1);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(6);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.45674F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.04628F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.7773F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.47323F));
            tableLayoutPanel2.Size = new System.Drawing.Size(301, 618);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(buttonEditClientInfo, 0, 0);
            tableLayoutPanel3.Location = new System.Drawing.Point(245, 4);
            tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new System.Drawing.Size(52, 50);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // buttonEditClientInfo
            // 
            buttonEditClientInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonEditClientInfo.BackColor = System.Drawing.Color.Transparent;
            buttonEditClientInfo.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonEditClientInfo.BackgroundImage");
            buttonEditClientInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonEditClientInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonEditClientInfo.FlatAppearance.BorderSize = 0;
            buttonEditClientInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonEditClientInfo.Location = new System.Drawing.Point(6, 5);
            buttonEditClientInfo.Margin = new System.Windows.Forms.Padding(0);
            buttonEditClientInfo.MotionHeight = true;
            buttonEditClientInfo.MotionWidth = true;
            buttonEditClientInfo.Name = "buttonEditClientInfo";
            buttonEditClientInfo.Size = new System.Drawing.Size(40, 39);
            buttonEditClientInfo.TabIndex = 690;
            toolTip1.SetToolTip(buttonEditClientInfo, "Edit Client Info");
            buttonEditClientInfo.UseVisualStyleBackColor = false;
            buttonEditClientInfo.Click += buttonEditClientInfo_Click;
            // 
            // panelPrimaryInfo
            // 
            panelPrimaryInfo.AutoScroll = true;
            panelPrimaryInfo.BackColor = System.Drawing.Color.Transparent;
            panelPrimaryInfo.Controls.Add(UCMemberSince);
            panelPrimaryInfo.Controls.Add(UCLastVisit);
            panelPrimaryInfo.Controls.Add(TLPAlbum);
            panelPrimaryInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            panelPrimaryInfo.Location = new System.Drawing.Point(0, 387);
            panelPrimaryInfo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            panelPrimaryInfo.Name = "panelPrimaryInfo";
            panelPrimaryInfo.Size = new System.Drawing.Size(301, 231);
            panelPrimaryInfo.TabIndex = 0;
            // 
            // UCMemberSince
            // 
            UCMemberSince.Detail = null;
            UCMemberSince.Dock = System.Windows.Forms.DockStyle.Top;
            UCMemberSince.Index = 0;
            UCMemberSince.Location = new System.Drawing.Point(0, 89);
            UCMemberSince.Margin = new System.Windows.Forms.Padding(5);
            UCMemberSince.Name = "UCMemberSince";
            UCMemberSince.Size = new System.Drawing.Size(301, 42);
            UCMemberSince.TabIndex = 1;
            UCMemberSince.Type = "Member Since";
            // 
            // UCLastVisit
            // 
            UCLastVisit.Detail = null;
            UCLastVisit.Dock = System.Windows.Forms.DockStyle.Top;
            UCLastVisit.Index = 0;
            UCLastVisit.Location = new System.Drawing.Point(0, 47);
            UCLastVisit.Margin = new System.Windows.Forms.Padding(5);
            UCLastVisit.Name = "UCLastVisit";
            UCLastVisit.Size = new System.Drawing.Size(301, 42);
            UCLastVisit.TabIndex = 0;
            UCLastVisit.Type = "Last Visit";
            // 
            // TLPAlbum
            // 
            TLPAlbum.ColumnCount = 2;
            TLPAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            TLPAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            TLPAlbum.Controls.Add(buttonEditAlbum, 0, 0);
            TLPAlbum.Controls.Add(UCAlbum, 0, 0);
            TLPAlbum.Dock = System.Windows.Forms.DockStyle.Top;
            TLPAlbum.Location = new System.Drawing.Point(0, 0);
            TLPAlbum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPAlbum.Name = "TLPAlbum";
            TLPAlbum.RowCount = 1;
            TLPAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            TLPAlbum.Size = new System.Drawing.Size(301, 47);
            TLPAlbum.TabIndex = 0;
            // 
            // buttonEditAlbum
            // 
            buttonEditAlbum.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonEditAlbum.BackColor = System.Drawing.Color.Transparent;
            buttonEditAlbum.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonEditAlbum.BackgroundImage");
            buttonEditAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonEditAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonEditAlbum.FlatAppearance.BorderSize = 0;
            buttonEditAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonEditAlbum.Location = new System.Drawing.Point(250, 8);
            buttonEditAlbum.Margin = new System.Windows.Forms.Padding(0);
            buttonEditAlbum.MotionHeight = true;
            buttonEditAlbum.MotionWidth = true;
            buttonEditAlbum.Name = "buttonEditAlbum";
            buttonEditAlbum.Size = new System.Drawing.Size(40, 30);
            buttonEditAlbum.TabIndex = 691;
            toolTip1.SetToolTip(buttonEditAlbum, "Edit Album");
            buttonEditAlbum.UseVisualStyleBackColor = false;
            buttonEditAlbum.Click += buttonEditAlbum_Click;
            // 
            // UCAlbum
            // 
            UCAlbum.Detail = "";
            UCAlbum.Dock = System.Windows.Forms.DockStyle.Fill;
            UCAlbum.Index = 0;
            UCAlbum.Location = new System.Drawing.Point(0, 0);
            UCAlbum.Margin = new System.Windows.Forms.Padding(0);
            UCAlbum.Name = "UCAlbum";
            UCAlbum.Size = new System.Drawing.Size(240, 47);
            UCAlbum.TabIndex = 2;
            UCAlbum.Tag = "";
            UCAlbum.Type = "Album";
            // 
            // labelName
            // 
            labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            labelName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelName.Location = new System.Drawing.Point(4, 312);
            labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelName.Name = "labelName";
            labelName.Size = new System.Drawing.Size(293, 72);
            labelName.TabIndex = 1;
            labelName.Text = "Mikael khalil(Adult)";
            labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconButtonImage
            // 
            iconButtonImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            iconButtonImage.BackColor = System.Drawing.Color.Transparent;
            iconButtonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            iconButtonImage.FlatAppearance.BorderSize = 0;
            iconButtonImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            iconButtonImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            iconButtonImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            iconButtonImage.Location = new System.Drawing.Point(45, 98);
            iconButtonImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            iconButtonImage.MotionHeight = true;
            iconButtonImage.MotionWidth = true;
            iconButtonImage.Name = "iconButtonImage";
            iconButtonImage.Size = new System.Drawing.Size(211, 173);
            iconButtonImage.TabIndex = 691;
            iconButtonImage.UseVisualStyleBackColor = false;
            iconButtonImage.Click += iconButtonImage_Click;
            // 
            // TLPHistory
            // 
            TLPHistory.BackColor = System.Drawing.Color.FromArgb(238, 241, 254);
            TLPHistory.ColumnCount = 2;
            TLPHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.59481F));
            TLPHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.40519F));
            TLPHistory.Controls.Add(UCpaymentsTotal, 1, 2);
            TLPHistory.Controls.Add(UCpaymentsServices, 1, 0);
            TLPHistory.Controls.Add(UCTotalAttendance, 0, 2);
            TLPHistory.Controls.Add(UCTokenServices, 0, 0);
            TLPHistory.Controls.Add(UCpaymentsProducts, 1, 1);
            TLPHistory.Controls.Add(UCTokenProducts, 0, 1);
            TLPHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPHistory.Location = new System.Drawing.Point(4, 639);
            TLPHistory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPHistory.Name = "TLPHistory";
            TLPHistory.RowCount = 3;
            TLPHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            TLPHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            TLPHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            TLPHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            TLPHistory.Size = new System.Drawing.Size(631, 198);
            TLPHistory.TabIndex = 1;
            // 
            // UCpaymentsTotal
            // 
            UCpaymentsTotal.Detail = "$600";
            UCpaymentsTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            UCpaymentsTotal.Index = 0;
            UCpaymentsTotal.Location = new System.Drawing.Point(317, 137);
            UCpaymentsTotal.Margin = new System.Windows.Forms.Padding(5);
            UCpaymentsTotal.Name = "UCpaymentsTotal";
            UCpaymentsTotal.Size = new System.Drawing.Size(309, 56);
            UCpaymentsTotal.TabIndex = 0;
            UCpaymentsTotal.Type = "Total Payments";
            // 
            // UCpaymentsServices
            // 
            UCpaymentsServices.Detail = "$400";
            UCpaymentsServices.Dock = System.Windows.Forms.DockStyle.Fill;
            UCpaymentsServices.Index = 0;
            UCpaymentsServices.Location = new System.Drawing.Point(317, 5);
            UCpaymentsServices.Margin = new System.Windows.Forms.Padding(5);
            UCpaymentsServices.Name = "UCpaymentsServices";
            UCpaymentsServices.Size = new System.Drawing.Size(309, 56);
            UCpaymentsServices.TabIndex = 0;
            UCpaymentsServices.Type = "Total Services Payment";
            // 
            // UCTotalAttendance
            // 
            UCTotalAttendance.Detail = "14";
            UCTotalAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            UCTotalAttendance.Index = 0;
            UCTotalAttendance.Location = new System.Drawing.Point(5, 137);
            UCTotalAttendance.Margin = new System.Windows.Forms.Padding(5);
            UCTotalAttendance.Name = "UCTotalAttendance";
            UCTotalAttendance.Size = new System.Drawing.Size(302, 56);
            UCTotalAttendance.TabIndex = 0;
            UCTotalAttendance.Type = "Total Service Completions";
            // 
            // UCTokenServices
            // 
            UCTokenServices.Detail = "4";
            UCTokenServices.Dock = System.Windows.Forms.DockStyle.Fill;
            UCTokenServices.Index = 0;
            UCTokenServices.Location = new System.Drawing.Point(5, 5);
            UCTokenServices.Margin = new System.Windows.Forms.Padding(5);
            UCTokenServices.Name = "UCTokenServices";
            UCTokenServices.Size = new System.Drawing.Size(302, 56);
            UCTokenServices.TabIndex = 0;
            UCTokenServices.Type = "Token services";
            // 
            // UCpaymentsProducts
            // 
            UCpaymentsProducts.Detail = "$200";
            UCpaymentsProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            UCpaymentsProducts.Index = 0;
            UCpaymentsProducts.Location = new System.Drawing.Point(317, 71);
            UCpaymentsProducts.Margin = new System.Windows.Forms.Padding(5);
            UCpaymentsProducts.Name = "UCpaymentsProducts";
            UCpaymentsProducts.Size = new System.Drawing.Size(309, 56);
            UCpaymentsProducts.TabIndex = 0;
            UCpaymentsProducts.Type = "Total Products Payment";
            // 
            // UCTokenProducts
            // 
            UCTokenProducts.Detail = "1";
            UCTokenProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            UCTokenProducts.Index = 0;
            UCTokenProducts.Location = new System.Drawing.Point(5, 71);
            UCTokenProducts.Margin = new System.Windows.Forms.Padding(5);
            UCTokenProducts.Name = "UCTokenProducts";
            UCTokenProducts.Size = new System.Drawing.Size(302, 56);
            UCTokenProducts.TabIndex = 0;
            UCTokenProducts.Type = "Token Products";
            // 
            // timer1
            // 
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // ClientManagementProfile
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1435, 846);
            Controls.Add(TLPGlobal);
            DoubleBuffered = true;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ClientManagementProfile";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = " Client Profile";
            FormClosed += ClientManagementProfile_FormClosed;
            Load += ClientManagementProfile_Load;
            VisibleChanged += ClientManagementProfile_VisibleChanged;
            Resize += ClientManagementProfile_Resize;
            TLPGlobal.ResumeLayout(false);
            TLPdatagrid.ResumeLayout(false);
            TLPBalance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewBalance).EndInit();
            panelServiceBalance.ResumeLayout(false);
            panelTotalBalance.ResumeLayout(false);
            panelProductBalance.ResumeLayout(false);
            TLPAdd.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            TLPInfo.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panelPrimaryInfo.ResumeLayout(false);
            TLPAlbum.ResumeLayout(false);
            TLPHistory.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.DataGridViewButtonColumn Pay;
        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        private System.Windows.Forms.TableLayoutPanel TLPAdd;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.Button buttonAddPAckge;
        private System.Windows.Forms.Panel panelProductBalance;
        private System.Windows.Forms.Label labelProductBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelTotalBalance;
        private System.Windows.Forms.Button buttonPayTotalBalance;
        private System.Windows.Forms.Label labelTotalBalance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelServiceBalance;
        private System.Windows.Forms.Label labelServiceBalance;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TableLayoutPanel TLPdatagrid;
        public CustomDataGridView dataGridViewBalance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel TLPBalance;
        private System.Windows.Forms.TableLayoutPanel TLPInfo;
        private System.Windows.Forms.Panel panelSecondaryInfo;
        private System.Windows.Forms.Panel panelPrimaryInfo;
        private System.Windows.Forms.Label labelName;
        private IconButton buttonEditClientInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private UCLabelAndDetail UCAlbum;
        public UCLabelAndDetail UCLastVisit;
        private System.Windows.Forms.TableLayoutPanel TLPHistory;
        public UCLabelAndDetail UCpaymentsServices;
        public UCLabelAndDetail UCpaymentsTotal;
        public UCLabelAndDetail UCTotalAttendance;
        public UCLabelAndDetail UCpaymentsProducts;
        public UCLabelAndDetail UCTokenProducts;
        public UCLabelAndDetail UCTokenServices;
        public UCLabelAndDetail UCMemberSince;
        private System.Windows.Forms.TableLayoutPanel TLPAlbum;
        private IconButton iconButtonImage;
        private IconButton buttonEditAlbum;
        private System.Windows.Forms.Button buttonBackOffice;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DataGridViewImageColumn PayOrEdit;
        private System.Windows.Forms.DataGridViewImageColumn Transactions;
    }
}