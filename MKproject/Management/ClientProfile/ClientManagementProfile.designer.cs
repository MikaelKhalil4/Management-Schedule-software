
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientManagementProfile));
            this.TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.TLPdatagrid = new System.Windows.Forms.TableLayoutPanel();
            this.TLPBalance = new System.Windows.Forms.TableLayoutPanel();
            this.buttonBackOffice = new System.Windows.Forms.Button();
            this.dataGridViewBalance = new CustomizedTools.CustomDataGridView();
            this.PayOrEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.BackOffice = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttonPayTotalBalance = new System.Windows.Forms.Button();
            this.panelServiceBalance = new System.Windows.Forms.Panel();
            this.labelServiceBalance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTotalBalance = new System.Windows.Forms.Panel();
            this.labelTotalBalance = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelProductBalance = new System.Windows.Forms.Panel();
            this.labelProductBalance = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TLPAdd = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAddPAckge = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TLPInfo = new System.Windows.Forms.TableLayoutPanel();
            this.panelSecondaryInfo = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonEditClientInfo = new CustomizedTools.IconButton();
            this.panelPrimaryInfo = new System.Windows.Forms.Panel();
            this.UCMemberSince = new CustomizedTools.UCLabelAndDetail();
            this.UCLastVisit = new CustomizedTools.UCLabelAndDetail();
            this.TLPAlbum = new System.Windows.Forms.TableLayoutPanel();
            this.buttonEditAlbum = new CustomizedTools.IconButton();
            this.UCAlbum = new CustomizedTools.UCLabelAndDetail();
            this.labelName = new System.Windows.Forms.Label();
            this.iconButtonImage = new CustomizedTools.IconButton();
            this.TLPHistory = new System.Windows.Forms.TableLayoutPanel();
            this.UCpaymentsTotal = new CustomizedTools.UCLabelAndDetail();
            this.UCpaymentsServices = new CustomizedTools.UCLabelAndDetail();
            this.UCTotalAttendance = new CustomizedTools.UCLabelAndDetail();
            this.UCTokenServices = new CustomizedTools.UCLabelAndDetail();
            this.UCpaymentsProducts = new CustomizedTools.UCLabelAndDetail();
            this.UCTokenProducts = new CustomizedTools.UCLabelAndDetail();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TLPGlobal.SuspendLayout();
            this.TLPdatagrid.SuspendLayout();
            this.TLPBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBalance)).BeginInit();
            this.panelServiceBalance.SuspendLayout();
            this.panelTotalBalance.SuspendLayout();
            this.panelProductBalance.SuspendLayout();
            this.TLPAdd.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.TLPInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelPrimaryInfo.SuspendLayout();
            this.TLPAlbum.SuspendLayout();
            this.TLPHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPGlobal
            // 
            this.TLPGlobal.BackColor = System.Drawing.Color.White;
            this.TLPGlobal.ColumnCount = 2;
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.09663F));
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.90337F));
            this.TLPGlobal.Controls.Add(this.TLPdatagrid, 1, 0);
            this.TLPGlobal.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPGlobal.Location = new System.Drawing.Point(0, 0);
            this.TLPGlobal.Margin = new System.Windows.Forms.Padding(5);
            this.TLPGlobal.Name = "TLPGlobal";
            this.TLPGlobal.RowCount = 1;
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 733F));
            this.TLPGlobal.Size = new System.Drawing.Size(1230, 733);
            this.TLPGlobal.TabIndex = 21;
            // 
            // TLPdatagrid
            // 
            this.TLPdatagrid.ColumnCount = 1;
            this.TLPdatagrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPdatagrid.Controls.Add(this.TLPBalance, 0, 2);
            this.TLPdatagrid.Controls.Add(this.TLPAdd, 0, 0);
            this.TLPdatagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPdatagrid.Location = new System.Drawing.Point(557, 0);
            this.TLPdatagrid.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.TLPdatagrid.Name = "TLPdatagrid";
            this.TLPdatagrid.RowCount = 3;
            this.TLPdatagrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.23173F));
            this.TLPdatagrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.84339F));
            this.TLPdatagrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.92489F));
            this.TLPdatagrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPdatagrid.Size = new System.Drawing.Size(670, 727);
            this.TLPdatagrid.TabIndex = 21;
            // 
            // TLPBalance
            // 
            this.TLPBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.TLPBalance.ColumnCount = 5;
            this.TLPBalance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.TLPBalance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.TLPBalance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.TLPBalance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.TLPBalance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.TLPBalance.Controls.Add(this.buttonBackOffice, 5, 0);
            this.TLPBalance.Controls.Add(this.dataGridViewBalance, 0, 1);
            this.TLPBalance.Controls.Add(this.buttonPayTotalBalance, 3, 0);
            this.TLPBalance.Controls.Add(this.panelServiceBalance, 0, 0);
            this.TLPBalance.Controls.Add(this.panelTotalBalance, 2, 0);
            this.TLPBalance.Controls.Add(this.panelProductBalance, 1, 0);
            this.TLPBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPBalance.Location = new System.Drawing.Point(3, 368);
            this.TLPBalance.Margin = new System.Windows.Forms.Padding(3, 5, 5, 0);
            this.TLPBalance.Name = "TLPBalance";
            this.TLPBalance.RowCount = 2;
            this.TLPBalance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPBalance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TLPBalance.Size = new System.Drawing.Size(662, 359);
            this.TLPBalance.TabIndex = 25;
            // 
            // buttonBackOffice
            // 
            this.buttonBackOffice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonBackOffice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBackOffice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBackOffice.FlatAppearance.BorderSize = 0;
            this.buttonBackOffice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(142)))), ((int)(((byte)(244)))));
            this.buttonBackOffice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackOffice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackOffice.ForeColor = System.Drawing.Color.White;
            this.buttonBackOffice.Location = new System.Drawing.Point(565, 10);
            this.buttonBackOffice.Margin = new System.Windows.Forms.Padding(10);
            this.buttonBackOffice.Name = "buttonBackOffice";
            this.buttonBackOffice.Size = new System.Drawing.Size(87, 51);
            this.buttonBackOffice.TabIndex = 23;
            this.buttonBackOffice.Text = "All Transactions";
            this.buttonBackOffice.UseVisualStyleBackColor = false;
            this.buttonBackOffice.Click += new System.EventHandler(this.buttonBackOffice_Click);
            // 
            // dataGridViewBalance
            // 
            this.dataGridViewBalance.AllowUserToAddRows = false;
            this.dataGridViewBalance.AllowUserToDeleteRows = false;
            this.dataGridViewBalance.AllowUserToResizeColumns = false;
            this.dataGridViewBalance.AllowUserToResizeRows = false;
            this.dataGridViewBalance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBalance.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewBalance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewBalance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBalance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBalance.ColumnHeadersHeight = 50;
            this.dataGridViewBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PayOrEdit,
            this.BackOffice});
            this.TLPBalance.SetColumnSpan(this.dataGridViewBalance, 5);
            this.dataGridViewBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBalance.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBalance.EnableHeadersVisualStyles = false;
            this.dataGridViewBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridViewBalance.GridColor = System.Drawing.Color.White;
            this.dataGridViewBalance.IsCustomScroll = true;
            this.dataGridViewBalance.IsRowColorChangeonMouseMove = true;
            this.dataGridViewBalance.IsSelectRow = false;
            this.dataGridViewBalance.Location = new System.Drawing.Point(7, 71);
            this.dataGridViewBalance.Margin = new System.Windows.Forms.Padding(7, 0, 7, 7);
            this.dataGridViewBalance.MultiSelect = false;
            this.dataGridViewBalance.Name = "dataGridViewBalance";
            this.dataGridViewBalance.ReadOnly = true;
            this.dataGridViewBalance.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewBalance.RowHeadersVisible = false;
            this.dataGridViewBalance.RowHeadersWidth = 60;
            this.dataGridViewBalance.RowTemplate.DividerHeight = 1;
            this.dataGridViewBalance.RowTemplate.Height = 43;
            this.dataGridViewBalance.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBalance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBalance.Size = new System.Drawing.Size(648, 281);
            this.dataGridViewBalance.TabIndex = 22;
            this.dataGridViewBalance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBalance_CellContentClick);
            this.dataGridViewBalance.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBalance_CellMouseEnter);
            this.dataGridViewBalance.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBalance_CellMouseLeave);
            this.dataGridViewBalance.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewBalance_ColumnHeaderMouseClick);
            // 
            // PayOrEdit
            // 
            this.PayOrEdit.FillWeight = 5F;
            this.PayOrEdit.HeaderText = "";
            this.PayOrEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.PayOrEdit.Name = "PayOrEdit";
            this.PayOrEdit.ReadOnly = true;
            this.PayOrEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PayOrEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BackOffice
            // 
            this.BackOffice.FillWeight = 5F;
            this.BackOffice.HeaderText = "";
            this.BackOffice.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.BackOffice.Name = "BackOffice";
            this.BackOffice.ReadOnly = true;
            this.BackOffice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BackOffice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // buttonPayTotalBalance
            // 
            this.buttonPayTotalBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonPayTotalBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPayTotalBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPayTotalBalance.FlatAppearance.BorderSize = 0;
            this.buttonPayTotalBalance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(142)))), ((int)(((byte)(244)))));
            this.buttonPayTotalBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPayTotalBalance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPayTotalBalance.ForeColor = System.Drawing.Color.White;
            this.buttonPayTotalBalance.Location = new System.Drawing.Point(463, 10);
            this.buttonPayTotalBalance.Margin = new System.Windows.Forms.Padding(10);
            this.buttonPayTotalBalance.Name = "buttonPayTotalBalance";
            this.buttonPayTotalBalance.Size = new System.Drawing.Size(82, 51);
            this.buttonPayTotalBalance.TabIndex = 2;
            this.buttonPayTotalBalance.Text = "Pay All";
            this.buttonPayTotalBalance.UseVisualStyleBackColor = false;
            this.buttonPayTotalBalance.Click += new System.EventHandler(this.buttonPayTotalBalance_Click);
            // 
            // panelServiceBalance
            // 
            this.panelServiceBalance.BackColor = System.Drawing.Color.White;
            this.panelServiceBalance.Controls.Add(this.labelServiceBalance);
            this.panelServiceBalance.Controls.Add(this.label2);
            this.panelServiceBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelServiceBalance.Location = new System.Drawing.Point(7, 7);
            this.panelServiceBalance.Margin = new System.Windows.Forms.Padding(7);
            this.panelServiceBalance.Name = "panelServiceBalance";
            this.panelServiceBalance.Size = new System.Drawing.Size(137, 57);
            this.panelServiceBalance.TabIndex = 0;
            // 
            // labelServiceBalance
            // 
            this.labelServiceBalance.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelServiceBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServiceBalance.ForeColor = System.Drawing.Color.Red;
            this.labelServiceBalance.Location = new System.Drawing.Point(0, 21);
            this.labelServiceBalance.Name = "labelServiceBalance";
            this.labelServiceBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelServiceBalance.Size = new System.Drawing.Size(137, 30);
            this.labelServiceBalance.TabIndex = 1;
            this.labelServiceBalance.Text = "-$150";
            this.labelServiceBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Services Balance";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTotalBalance
            // 
            this.panelTotalBalance.BackColor = System.Drawing.Color.White;
            this.panelTotalBalance.Controls.Add(this.labelTotalBalance);
            this.panelTotalBalance.Controls.Add(this.label5);
            this.panelTotalBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotalBalance.Location = new System.Drawing.Point(309, 7);
            this.panelTotalBalance.Margin = new System.Windows.Forms.Padding(7);
            this.panelTotalBalance.Name = "panelTotalBalance";
            this.panelTotalBalance.Size = new System.Drawing.Size(137, 57);
            this.panelTotalBalance.TabIndex = 1;
            // 
            // labelTotalBalance
            // 
            this.labelTotalBalance.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTotalBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalBalance.ForeColor = System.Drawing.Color.Red;
            this.labelTotalBalance.Location = new System.Drawing.Point(0, 21);
            this.labelTotalBalance.Name = "labelTotalBalance";
            this.labelTotalBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTotalBalance.Size = new System.Drawing.Size(137, 30);
            this.labelTotalBalance.TabIndex = 1;
            this.labelTotalBalance.Text = "-$300";
            this.labelTotalBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total Balance";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelProductBalance
            // 
            this.panelProductBalance.BackColor = System.Drawing.Color.White;
            this.panelProductBalance.Controls.Add(this.labelProductBalance);
            this.panelProductBalance.Controls.Add(this.label6);
            this.panelProductBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductBalance.Location = new System.Drawing.Point(158, 7);
            this.panelProductBalance.Margin = new System.Windows.Forms.Padding(7);
            this.panelProductBalance.Name = "panelProductBalance";
            this.panelProductBalance.Size = new System.Drawing.Size(137, 57);
            this.panelProductBalance.TabIndex = 2;
            // 
            // labelProductBalance
            // 
            this.labelProductBalance.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelProductBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductBalance.ForeColor = System.Drawing.Color.Red;
            this.labelProductBalance.Location = new System.Drawing.Point(0, 21);
            this.labelProductBalance.Name = "labelProductBalance";
            this.labelProductBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelProductBalance.Size = new System.Drawing.Size(137, 30);
            this.labelProductBalance.TabIndex = 1;
            this.labelProductBalance.Text = "-$150";
            this.labelProductBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Product Balance";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TLPAdd
            // 
            this.TLPAdd.BackColor = System.Drawing.Color.White;
            this.TLPAdd.ColumnCount = 2;
            this.TLPAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPAdd.Controls.Add(this.panel4, 0, 0);
            this.TLPAdd.Controls.Add(this.panel2, 0, 0);
            this.TLPAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPAdd.Location = new System.Drawing.Point(3, 5);
            this.TLPAdd.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.TLPAdd.Name = "TLPAdd";
            this.TLPAdd.RowCount = 1;
            this.TLPAdd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPAdd.Size = new System.Drawing.Size(662, 115);
            this.TLPAdd.TabIndex = 27;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panel4.Controls.Add(this.buttonAddProduct);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(331, 5);
            this.panel4.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(326, 110);
            this.panel4.TabIndex = 4;
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonAddProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddProduct.FlatAppearance.BorderSize = 0;
            this.buttonAddProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(142)))), ((int)(((byte)(244)))));
            this.buttonAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddProduct.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddProduct.ForeColor = System.Drawing.Color.White;
            this.buttonAddProduct.Location = new System.Drawing.Point(85, 15);
            this.buttonAddProduct.Margin = new System.Windows.Forms.Padding(28);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(174, 70);
            this.buttonAddProduct.TabIndex = 1;
            this.buttonAddProduct.Text = "Add\r\nProduct";
            this.buttonAddProduct.UseVisualStyleBackColor = false;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panel2.Controls.Add(this.buttonAddPAckge);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 110);
            this.panel2.TabIndex = 2;
            // 
            // buttonAddPAckge
            // 
            this.buttonAddPAckge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddPAckge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonAddPAckge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddPAckge.FlatAppearance.BorderSize = 0;
            this.buttonAddPAckge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(142)))), ((int)(((byte)(244)))));
            this.buttonAddPAckge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddPAckge.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPAckge.ForeColor = System.Drawing.Color.White;
            this.buttonAddPAckge.Location = new System.Drawing.Point(76, 15);
            this.buttonAddPAckge.Margin = new System.Windows.Forms.Padding(28);
            this.buttonAddPAckge.Name = "buttonAddPAckge";
            this.buttonAddPAckge.Size = new System.Drawing.Size(174, 70);
            this.buttonAddPAckge.TabIndex = 0;
            this.buttonAddPAckge.Text = "Add\r\n Service";
            this.buttonAddPAckge.UseVisualStyleBackColor = false;
            this.buttonAddPAckge.Click += new System.EventHandler(this.buttonAddPAckge_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.TLPInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TLPHistory, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.77548F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.22452F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(548, 727);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // TLPInfo
            // 
            this.TLPInfo.ColumnCount = 2;
            this.TLPInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.68354F));
            this.TLPInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.31646F));
            this.TLPInfo.Controls.Add(this.panelSecondaryInfo, 1, 0);
            this.TLPInfo.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.TLPInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPInfo.Location = new System.Drawing.Point(3, 3);
            this.TLPInfo.Name = "TLPInfo";
            this.TLPInfo.RowCount = 1;
            this.TLPInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 544F));
            this.TLPInfo.Size = new System.Drawing.Size(542, 544);
            this.TLPInfo.TabIndex = 0;
            // 
            // panelSecondaryInfo
            // 
            this.panelSecondaryInfo.AutoScroll = true;
            this.panelSecondaryInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panelSecondaryInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSecondaryInfo.Location = new System.Drawing.Point(274, 5);
            this.panelSecondaryInfo.Margin = new System.Windows.Forms.Padding(5);
            this.panelSecondaryInfo.Name = "panelSecondaryInfo";
            this.panelSecondaryInfo.Size = new System.Drawing.Size(263, 534);
            this.panelSecondaryInfo.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelPrimaryInfo, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelName, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.iconButtonImage, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.45674F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.04628F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.7773F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.47323F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(259, 534);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.buttonEditClientInfo, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(211, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(45, 43);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // buttonEditClientInfo
            // 
            this.buttonEditClientInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonEditClientInfo.BackColor = System.Drawing.Color.Transparent;
            this.buttonEditClientInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEditClientInfo.BackgroundImage")));
            this.buttonEditClientInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEditClientInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditClientInfo.FlatAppearance.BorderSize = 0;
            this.buttonEditClientInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditClientInfo.Location = new System.Drawing.Point(5, 4);
            this.buttonEditClientInfo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEditClientInfo.MotionHeight = true;
            this.buttonEditClientInfo.MotionWidth = true;
            this.buttonEditClientInfo.Name = "buttonEditClientInfo";
            this.buttonEditClientInfo.Size = new System.Drawing.Size(34, 34);
            this.buttonEditClientInfo.TabIndex = 690;
            this.toolTip1.SetToolTip(this.buttonEditClientInfo, "Edit Client Info");
            this.buttonEditClientInfo.UseVisualStyleBackColor = false;
            this.buttonEditClientInfo.Click += new System.EventHandler(this.buttonEditClientInfo_Click);
            // 
            // panelPrimaryInfo
            // 
            this.panelPrimaryInfo.AutoScroll = true;
            this.panelPrimaryInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelPrimaryInfo.Controls.Add(this.UCMemberSince);
            this.panelPrimaryInfo.Controls.Add(this.UCLastVisit);
            this.panelPrimaryInfo.Controls.Add(this.TLPAlbum);
            this.panelPrimaryInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrimaryInfo.Location = new System.Drawing.Point(0, 335);
            this.panelPrimaryInfo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panelPrimaryInfo.Name = "panelPrimaryInfo";
            this.panelPrimaryInfo.Size = new System.Drawing.Size(259, 199);
            this.panelPrimaryInfo.TabIndex = 0;
            // 
            // UCMemberSince
            // 
            this.UCMemberSince.Detail = null;
            this.UCMemberSince.Dock = System.Windows.Forms.DockStyle.Top;
            this.UCMemberSince.Index = 0;
            this.UCMemberSince.Location = new System.Drawing.Point(0, 83);
            this.UCMemberSince.Margin = new System.Windows.Forms.Padding(4);
            this.UCMemberSince.Name = "UCMemberSince";
            this.UCMemberSince.Size = new System.Drawing.Size(259, 45);
            this.UCMemberSince.TabIndex = 1;
            this.UCMemberSince.Type = "Member Since";
            // 
            // UCLastVisit
            // 
            this.UCLastVisit.Detail = null;
            this.UCLastVisit.Dock = System.Windows.Forms.DockStyle.Top;
            this.UCLastVisit.Index = 0;
            this.UCLastVisit.Location = new System.Drawing.Point(0, 41);
            this.UCLastVisit.Margin = new System.Windows.Forms.Padding(4);
            this.UCLastVisit.Name = "UCLastVisit";
            this.UCLastVisit.Size = new System.Drawing.Size(259, 42);
            this.UCLastVisit.TabIndex = 0;
            this.UCLastVisit.Type = "Last Visit";
            // 
            // TLPAlbum
            // 
            this.TLPAlbum.ColumnCount = 2;
            this.TLPAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TLPAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPAlbum.Controls.Add(this.buttonEditAlbum, 0, 0);
            this.TLPAlbum.Controls.Add(this.UCAlbum, 0, 0);
            this.TLPAlbum.Dock = System.Windows.Forms.DockStyle.Top;
            this.TLPAlbum.Location = new System.Drawing.Point(0, 0);
            this.TLPAlbum.Name = "TLPAlbum";
            this.TLPAlbum.RowCount = 1;
            this.TLPAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.TLPAlbum.Size = new System.Drawing.Size(259, 41);
            this.TLPAlbum.TabIndex = 0;
            // 
            // buttonEditAlbum
            // 
            this.buttonEditAlbum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonEditAlbum.BackColor = System.Drawing.Color.Transparent;
            this.buttonEditAlbum.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEditAlbum.BackgroundImage")));
            this.buttonEditAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEditAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditAlbum.FlatAppearance.BorderSize = 0;
            this.buttonEditAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditAlbum.Location = new System.Drawing.Point(216, 7);
            this.buttonEditAlbum.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEditAlbum.MotionHeight = true;
            this.buttonEditAlbum.MotionWidth = true;
            this.buttonEditAlbum.Name = "buttonEditAlbum";
            this.buttonEditAlbum.Size = new System.Drawing.Size(34, 26);
            this.buttonEditAlbum.TabIndex = 691;
            this.toolTip1.SetToolTip(this.buttonEditAlbum, "Edit Album");
            this.buttonEditAlbum.UseVisualStyleBackColor = false;
            this.buttonEditAlbum.Click += new System.EventHandler(this.buttonEditAlbum_Click);
            // 
            // UCAlbum
            // 
            this.UCAlbum.Detail = "";
            this.UCAlbum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCAlbum.Index = 0;
            this.UCAlbum.Location = new System.Drawing.Point(4, 4);
            this.UCAlbum.Margin = new System.Windows.Forms.Padding(4);
            this.UCAlbum.Name = "UCAlbum";
            this.UCAlbum.Size = new System.Drawing.Size(199, 33);
            this.UCAlbum.TabIndex = 2;
            this.UCAlbum.Tag = "";
            this.UCAlbum.Type = "Album";
            // 
            // labelName
            // 
            this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(3, 269);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(253, 63);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Mikael khalil(Adult)";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconButtonImage
            // 
            this.iconButtonImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButtonImage.BackColor = System.Drawing.Color.Transparent;
            this.iconButtonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconButtonImage.FlatAppearance.BorderSize = 0;
            this.iconButtonImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButtonImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButtonImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonImage.Location = new System.Drawing.Point(29, 84);
            this.iconButtonImage.MotionHeight = true;
            this.iconButtonImage.MotionWidth = true;
            this.iconButtonImage.Name = "iconButtonImage";
            this.iconButtonImage.Size = new System.Drawing.Size(200, 150);
            this.iconButtonImage.TabIndex = 691;
            this.iconButtonImage.UseVisualStyleBackColor = false;
            this.iconButtonImage.Click += new System.EventHandler(this.iconButtonImage_Click);
            // 
            // TLPHistory
            // 
            this.TLPHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.TLPHistory.ColumnCount = 2;
            this.TLPHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.59481F));
            this.TLPHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.40519F));
            this.TLPHistory.Controls.Add(this.UCpaymentsTotal, 1, 2);
            this.TLPHistory.Controls.Add(this.UCpaymentsServices, 1, 0);
            this.TLPHistory.Controls.Add(this.UCTotalAttendance, 0, 2);
            this.TLPHistory.Controls.Add(this.UCTokenServices, 0, 0);
            this.TLPHistory.Controls.Add(this.UCpaymentsProducts, 1, 1);
            this.TLPHistory.Controls.Add(this.UCTokenProducts, 0, 1);
            this.TLPHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPHistory.Location = new System.Drawing.Point(3, 553);
            this.TLPHistory.Name = "TLPHistory";
            this.TLPHistory.RowCount = 3;
            this.TLPHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPHistory.Size = new System.Drawing.Size(542, 171);
            this.TLPHistory.TabIndex = 1;
            // 
            // UCpaymentsTotal
            // 
            this.UCpaymentsTotal.Detail = "$600";
            this.UCpaymentsTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCpaymentsTotal.Index = 0;
            this.UCpaymentsTotal.Location = new System.Drawing.Point(272, 118);
            this.UCpaymentsTotal.Margin = new System.Windows.Forms.Padding(4);
            this.UCpaymentsTotal.Name = "UCpaymentsTotal";
            this.UCpaymentsTotal.Size = new System.Drawing.Size(266, 49);
            this.UCpaymentsTotal.TabIndex = 0;
            this.UCpaymentsTotal.Type = "Total Payments";
            // 
            // UCpaymentsServices
            // 
            this.UCpaymentsServices.Detail = "$400";
            this.UCpaymentsServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCpaymentsServices.Index = 0;
            this.UCpaymentsServices.Location = new System.Drawing.Point(272, 4);
            this.UCpaymentsServices.Margin = new System.Windows.Forms.Padding(4);
            this.UCpaymentsServices.Name = "UCpaymentsServices";
            this.UCpaymentsServices.Size = new System.Drawing.Size(266, 49);
            this.UCpaymentsServices.TabIndex = 0;
            this.UCpaymentsServices.Type = "Total Services Payment";
            // 
            // UCTotalAttendance
            // 
            this.UCTotalAttendance.Detail = "14";
            this.UCTotalAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCTotalAttendance.Index = 0;
            this.UCTotalAttendance.Location = new System.Drawing.Point(4, 118);
            this.UCTotalAttendance.Margin = new System.Windows.Forms.Padding(4);
            this.UCTotalAttendance.Name = "UCTotalAttendance";
            this.UCTotalAttendance.Size = new System.Drawing.Size(260, 49);
            this.UCTotalAttendance.TabIndex = 0;
            this.UCTotalAttendance.Type = "Total Attendance";
            // 
            // UCTokenServices
            // 
            this.UCTokenServices.Detail = "4";
            this.UCTokenServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCTokenServices.Index = 0;
            this.UCTokenServices.Location = new System.Drawing.Point(4, 4);
            this.UCTokenServices.Margin = new System.Windows.Forms.Padding(4);
            this.UCTokenServices.Name = "UCTokenServices";
            this.UCTokenServices.Size = new System.Drawing.Size(260, 49);
            this.UCTokenServices.TabIndex = 0;
            this.UCTokenServices.Type = "Token services";
            // 
            // UCpaymentsProducts
            // 
            this.UCpaymentsProducts.Detail = "$200";
            this.UCpaymentsProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCpaymentsProducts.Index = 0;
            this.UCpaymentsProducts.Location = new System.Drawing.Point(272, 61);
            this.UCpaymentsProducts.Margin = new System.Windows.Forms.Padding(4);
            this.UCpaymentsProducts.Name = "UCpaymentsProducts";
            this.UCpaymentsProducts.Size = new System.Drawing.Size(266, 49);
            this.UCpaymentsProducts.TabIndex = 0;
            this.UCpaymentsProducts.Type = "Total Products Payment";
            // 
            // UCTokenProducts
            // 
            this.UCTokenProducts.Detail = "1";
            this.UCTokenProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCTokenProducts.Index = 0;
            this.UCTokenProducts.Location = new System.Drawing.Point(4, 61);
            this.UCTokenProducts.Margin = new System.Windows.Forms.Padding(4);
            this.UCTokenProducts.Name = "UCTokenProducts";
            this.UCTokenProducts.Size = new System.Drawing.Size(260, 49);
            this.UCTokenProducts.TabIndex = 0;
            this.UCTokenProducts.Type = "Token Products";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ClientManagementProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 733);
            this.Controls.Add(this.TLPGlobal);
            this.DoubleBuffered = true;
            this.Name = "ClientManagementProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientManagementProfile_FormClosed);
            this.Load += new System.EventHandler(this.ClientManagementProfile_Load);
            this.VisibleChanged += new System.EventHandler(this.ClientManagementProfile_VisibleChanged);
            this.Resize += new System.EventHandler(this.ClientManagementProfile_Resize);
            this.TLPGlobal.ResumeLayout(false);
            this.TLPdatagrid.ResumeLayout(false);
            this.TLPBalance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBalance)).EndInit();
            this.panelServiceBalance.ResumeLayout(false);
            this.panelTotalBalance.ResumeLayout(false);
            this.panelProductBalance.ResumeLayout(false);
            this.TLPAdd.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.TLPInfo.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panelPrimaryInfo.ResumeLayout(false);
            this.TLPAlbum.ResumeLayout(false);
            this.TLPHistory.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
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
        private System.Windows.Forms.DataGridViewImageColumn PayOrEdit;
        private System.Windows.Forms.DataGridViewImageColumn BackOffice;
        private IconButton buttonEditAlbum;
        private System.Windows.Forms.Button buttonBackOffice;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Timer timer1;
    }
}