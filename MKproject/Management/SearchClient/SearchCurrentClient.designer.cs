using CustomizedTools;
using System.Windows.Forms;

namespace MKproject.Management
{
    partial class SearchCurrentClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchCurrentClient));
            this.TLPGlobalJunior = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewClients = new CustomizedTools.CustomDataGridView();
            this.FLPFiltersSlideSDhow = new System.Windows.Forms.FlowLayoutPanel();
            this.TLPSearchAndFilter = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxSearch = new CustomizedTools.TextBoxWithPlaceHolder();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.FLPFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonResetOrder = new System.Windows.Forms.Button();
            this.iconButtonAddClient = new CustomizedTools.IconButton();
            this.iconButtonViewBirthdays = new CustomizedTools.IconButton();
            this.panelResults = new System.Windows.Forms.Panel();
            this.labelResults = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.timerFilterOn = new System.Windows.Forms.Timer(this.components);
            this.timerFilterOff = new System.Windows.Forms.Timer(this.components);
            this.TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.timerUnselectComboBox = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TLPGlobalJunior.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.TLPSearchAndFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            this.FLPFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelResults.SuspendLayout();
            this.TLPGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPGlobalJunior
            // 
            this.TLPGlobalJunior.ColumnCount = 1;
            this.TLPGlobalJunior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPGlobalJunior.Controls.Add(this.panel1, 0, 1);
            this.TLPGlobalJunior.Controls.Add(this.TLPSearchAndFilter, 0, 0);
            this.TLPGlobalJunior.Controls.Add(this.panelResults, 0, 2);
            this.TLPGlobalJunior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPGlobalJunior.Location = new System.Drawing.Point(9, 15);
            this.TLPGlobalJunior.Margin = new System.Windows.Forms.Padding(9, 15, 9, 0);
            this.TLPGlobalJunior.Name = "TLPGlobalJunior";
            this.TLPGlobalJunior.RowCount = 3;
            this.TLPGlobalJunior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TLPGlobalJunior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPGlobalJunior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.TLPGlobalJunior.Size = new System.Drawing.Size(1293, 713);
            this.TLPGlobalJunior.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewClients);
            this.panel1.Controls.Add(this.FLPFiltersSlideSDhow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1287, 615);
            this.panel1.TabIndex = 22;
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.AllowUserToAddRows = false;
            this.dataGridViewClients.AllowUserToDeleteRows = false;
            this.dataGridViewClients.AllowUserToResizeColumns = false;
            this.dataGridViewClients.AllowUserToResizeRows = false;
            this.dataGridViewClients.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewClients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewClients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewClients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewClients.ColumnHeadersHeight = 50;
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewClients.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(226)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewClients.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewClients.EnableHeadersVisualStyles = false;
            this.dataGridViewClients.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridViewClients.GridColor = System.Drawing.Color.White;
            this.dataGridViewClients.IsCustomScroll = true;
            this.dataGridViewClients.IsRowColorChangeonMouseMove = true;
            this.dataGridViewClients.IsSelectRow = true;
            this.dataGridViewClients.Location = new System.Drawing.Point(0, 140);
            this.dataGridViewClients.MultiSelect = false;
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.ReadOnly = true;
            this.dataGridViewClients.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewClients.RowHeadersVisible = false;
            this.dataGridViewClients.RowHeadersWidth = 60;
            this.dataGridViewClients.RowTemplate.DividerHeight = 1;
            this.dataGridViewClients.RowTemplate.Height = 60;
            this.dataGridViewClients.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewClients.Size = new System.Drawing.Size(1287, 475);
            this.dataGridViewClients.TabIndex = 30;
            this.dataGridViewClients.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewClients_CellFormatting);
            this.dataGridViewClients.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewClients_CellMouseDoubleClick);
            this.dataGridViewClients.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewClients_CellMouseMove);
            this.dataGridViewClients.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewClients_CellPainting);
            this.dataGridViewClients.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewClients_ColumnHeaderMouseClick);
            this.dataGridViewClients.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewClients_RowsRemoved);
            this.dataGridViewClients.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridViewClients_Scroll);
            // 
            // FLPFiltersSlideSDhow
            // 
            this.FLPFiltersSlideSDhow.Dock = System.Windows.Forms.DockStyle.Top;
            this.FLPFiltersSlideSDhow.Location = new System.Drawing.Point(0, 0);
            this.FLPFiltersSlideSDhow.Name = "FLPFiltersSlideSDhow";
            this.FLPFiltersSlideSDhow.Size = new System.Drawing.Size(1287, 140);
            this.FLPFiltersSlideSDhow.TabIndex = 29;
            // 
            // TLPSearchAndFilter
            // 
            this.TLPSearchAndFilter.ColumnCount = 6;
            this.TLPSearchAndFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.TLPSearchAndFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 286F));
            this.TLPSearchAndFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.TLPSearchAndFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPSearchAndFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.TLPSearchAndFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TLPSearchAndFilter.Controls.Add(this.textBoxSearch, 1, 0);
            this.TLPSearchAndFilter.Controls.Add(this.pictureBoxSearch, 0, 0);
            this.TLPSearchAndFilter.Controls.Add(this.FLPFilter, 2, 0);
            this.TLPSearchAndFilter.Controls.Add(this.buttonResetOrder, 3, 0);
            this.TLPSearchAndFilter.Controls.Add(this.iconButtonAddClient, 5, 0);
            this.TLPSearchAndFilter.Controls.Add(this.iconButtonViewBirthdays, 4, 0);
            this.TLPSearchAndFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPSearchAndFilter.Location = new System.Drawing.Point(3, 3);
            this.TLPSearchAndFilter.Name = "TLPSearchAndFilter";
            this.TLPSearchAndFilter.RowCount = 1;
            this.TLPSearchAndFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPSearchAndFilter.Size = new System.Drawing.Size(1287, 44);
            this.TLPSearchAndFilter.TabIndex = 29;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSearch.Location = new System.Drawing.Point(36, 9);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Search by name or phone number...";
            this.textBoxSearch.Size = new System.Drawing.Size(277, 29);
            this.textBoxSearch.TabIndex = 30;
            this.textBoxSearch.Text = "Search by name or phone number...";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxSearch.BackgroundImage")));
            this.pictureBoxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxSearch.Location = new System.Drawing.Point(7, 14);
            this.pictureBoxSearch.Margin = new System.Windows.Forms.Padding(7, 7, 0, 10);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(26, 20);
            this.pictureBoxSearch.TabIndex = 29;
            this.pictureBoxSearch.TabStop = false;
            // 
            // FLPFilter
            // 
            this.FLPFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FLPFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FLPFilter.Controls.Add(this.pictureBox1);
            this.FLPFilter.Controls.Add(this.label1);
            this.FLPFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FLPFilter.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FLPFilter.Location = new System.Drawing.Point(322, 10);
            this.FLPFilter.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.FLPFilter.Name = "FLPFilter";
            this.FLPFilter.Size = new System.Drawing.Size(88, 28);
            this.FLPFilter.TabIndex = 31;
            this.FLPFilter.Click += new System.EventHandler(this.FLPFilter_Click);
            this.FLPFilter.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.FLPFilter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FLPFilter_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(58, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 24);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.FLPFilter_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FLPFilter_MouseMove);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "Filters";
            this.label1.Click += new System.EventHandler(this.FLPFilter_Click);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FLPFilter_MouseMove);
            // 
            // buttonResetOrder
            // 
            this.buttonResetOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonResetOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonResetOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonResetOrder.FlatAppearance.BorderSize = 0;
            this.buttonResetOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(142)))), ((int)(((byte)(244)))));
            this.buttonResetOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetOrder.ForeColor = System.Drawing.Color.White;
            this.buttonResetOrder.Location = new System.Drawing.Point(421, 11);
            this.buttonResetOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 7);
            this.buttonResetOrder.Name = "buttonResetOrder";
            this.buttonResetOrder.Size = new System.Drawing.Size(97, 26);
            this.buttonResetOrder.TabIndex = 4;
            this.buttonResetOrder.Text = "Reset Order";
            this.buttonResetOrder.UseVisualStyleBackColor = false;
            this.buttonResetOrder.Click += new System.EventHandler(this.buttonResetOrder_Click);
            // 
            // iconButtonAddClient
            // 
            this.iconButtonAddClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButtonAddClient.BackColor = System.Drawing.Color.Transparent;
            this.iconButtonAddClient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconButtonAddClient.BackgroundImage")));
            this.iconButtonAddClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconButtonAddClient.FlatAppearance.BorderSize = 0;
            this.iconButtonAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonAddClient.Location = new System.Drawing.Point(1247, 8);
            this.iconButtonAddClient.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.iconButtonAddClient.MotionHeight = true;
            this.iconButtonAddClient.MotionWidth = true;
            this.iconButtonAddClient.Name = "iconButtonAddClient";
            this.iconButtonAddClient.Size = new System.Drawing.Size(35, 32);
            this.iconButtonAddClient.TabIndex = 32;
            this.toolTip1.SetToolTip(this.iconButtonAddClient, "Add new client");
            this.iconButtonAddClient.UseVisualStyleBackColor = false;
            this.iconButtonAddClient.Click += new System.EventHandler(this.iconButtonAddClient_Click);
            // 
            // iconButtonViewBirthdays
            // 
            this.iconButtonViewBirthdays.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButtonViewBirthdays.BackColor = System.Drawing.Color.Transparent;
            this.iconButtonViewBirthdays.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconButtonViewBirthdays.BackgroundImage")));
            this.iconButtonViewBirthdays.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconButtonViewBirthdays.FlatAppearance.BorderSize = 0;
            this.iconButtonViewBirthdays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonViewBirthdays.Location = new System.Drawing.Point(1203, 6);
            this.iconButtonViewBirthdays.MotionHeight = true;
            this.iconButtonViewBirthdays.MotionWidth = true;
            this.iconButtonViewBirthdays.Name = "iconButtonViewBirthdays";
            this.iconButtonViewBirthdays.Size = new System.Drawing.Size(35, 32);
            this.iconButtonViewBirthdays.TabIndex = 32;
            this.toolTip1.SetToolTip(this.iconButtonViewBirthdays, "See coming birthdays");
            this.iconButtonViewBirthdays.UseVisualStyleBackColor = false;
            this.iconButtonViewBirthdays.Click += new System.EventHandler(this.iconButtonViewBirthdays_Click);
            // 
            // panelResults
            // 
            this.panelResults.Controls.Add(this.labelResults);
            this.panelResults.Controls.Add(this.label13);
            this.panelResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResults.Location = new System.Drawing.Point(3, 674);
            this.panelResults.Name = "panelResults";
            this.panelResults.Size = new System.Drawing.Size(1287, 36);
            this.panelResults.TabIndex = 30;
            // 
            // labelResults
            // 
            this.labelResults.AutoSize = true;
            this.labelResults.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelResults.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResults.Location = new System.Drawing.Point(179, 0);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(31, 25);
            this.labelResults.TabIndex = 1;
            this.labelResults.Text = "10";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(179, 25);
            this.label13.TabIndex = 0;
            this.label13.Text = "Number Of Results:";
            // 
            // timerFilterOn
            // 
            this.timerFilterOn.Interval = 1;
            this.timerFilterOn.Tick += new System.EventHandler(this.timerFilterOn_Tick);
            // 
            // timerFilterOff
            // 
            this.timerFilterOff.Interval = 1;
            this.timerFilterOff.Tick += new System.EventHandler(this.timerFilterOff_Tick);
            // 
            // TLPGlobal
            // 
            this.TLPGlobal.ColumnCount = 1;
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPGlobal.Controls.Add(this.TLPGlobalJunior, 0, 0);
            this.TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPGlobal.Location = new System.Drawing.Point(0, 0);
            this.TLPGlobal.Name = "TLPGlobal";
            this.TLPGlobal.RowCount = 1;
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPGlobal.Size = new System.Drawing.Size(1311, 728);
            this.TLPGlobal.TabIndex = 22;
            // 
            // timerUnselectComboBox
            // 
            this.timerUnselectComboBox.Interval = 800;
            // 
            // SearchCurrentClient
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1311, 728);
            this.Controls.Add(this.TLPGlobal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchCurrentClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchCurrentClient";
            this.Deactivate += new System.EventHandler(this.SearchCurrentClient_Deactivate);
            this.Load += new System.EventHandler(this.SearchCurrentClient_Load);
            this.Resize += new System.EventHandler(this.SearchCurrentClient_Resize);
            this.TLPGlobalJunior.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.TLPSearchAndFilter.ResumeLayout(false);
            this.TLPSearchAndFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            this.FLPFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelResults.ResumeLayout(false);
            this.panelResults.PerformLayout();
            this.TLPGlobal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel TLPGlobalJunior;
        private TableLayoutPanel TLPSearchAndFilter;
        private FlowLayoutPanel FLPFilter;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel1;
        public FlowLayoutPanel FLPFiltersSlideSDhow;
        private TableLayoutPanel TLPGlobal;
        public CustomDataGridView dataGridViewClients;
        private Panel panelResults;
        private Label label13;
        private Timer timerUnselectComboBox;
        public PictureBox pictureBoxSearch;
        public TextBoxWithPlaceHolder textBoxSearch;
        public Label labelResults;
        public Button buttonResetOrder;
        public Timer timerFilterOn;
        public Timer timerFilterOff;
        private IconButton iconButtonAddClient;
        private IconButton iconButtonViewBirthdays;
        private ToolTip toolTip1;
    }
}