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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchCurrentClient));
            TLPGlobalJunior = new TableLayoutPanel();
            panel1 = new Panel();
            dataGridViewClients = new CustomDataGridView();
            FLPFiltersSlideSDhow = new FlowLayoutPanel();
            TLPSearchAndFilter = new TableLayoutPanel();
            textBoxSearch = new TextBoxWithPlaceHolder();
            pictureBoxSearch = new PictureBox();
            FLPFilter = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            buttonResetOrder = new Button();
            iconButtonAddClient = new IconButton();
            iconButtonViewBirthdays = new IconButton();
            panelResults = new Panel();
            labelResults = new Label();
            label13 = new Label();
            timerFilterOn = new Timer(components);
            timerFilterOff = new Timer(components);
            TLPGlobal = new TableLayoutPanel();
            timerUnselectComboBox = new Timer(components);
            toolTip1 = new ToolTip(components);
            TLPGlobalJunior.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).BeginInit();
            TLPSearchAndFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearch).BeginInit();
            FLPFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelResults.SuspendLayout();
            TLPGlobal.SuspendLayout();
            SuspendLayout();
            // 
            // TLPGlobalJunior
            // 
            TLPGlobalJunior.ColumnCount = 1;
            TLPGlobalJunior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TLPGlobalJunior.Controls.Add(panel1, 0, 1);
            TLPGlobalJunior.Controls.Add(TLPSearchAndFilter, 0, 0);
            TLPGlobalJunior.Controls.Add(panelResults, 0, 2);
            TLPGlobalJunior.Dock = DockStyle.Fill;
            TLPGlobalJunior.Location = new System.Drawing.Point(9, 15);
            TLPGlobalJunior.Margin = new Padding(9, 15, 9, 0);
            TLPGlobalJunior.Name = "TLPGlobalJunior";
            TLPGlobalJunior.RowCount = 3;
            TLPGlobalJunior.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            TLPGlobalJunior.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLPGlobalJunior.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            TLPGlobalJunior.Size = new System.Drawing.Size(1293, 713);
            TLPGlobalJunior.TabIndex = 21;
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridViewClients);
            panel1.Controls.Add(FLPFiltersSlideSDhow);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 53);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1287, 615);
            panel1.TabIndex = 22;
            // 
            // dataGridViewClients
            // 
            dataGridViewClients.AllowUserToAddRows = false;
            dataGridViewClients.AllowUserToDeleteRows = false;
            dataGridViewClients.AllowUserToResizeColumns = false;
            dataGridViewClients.AllowUserToResizeRows = false;
            dataGridViewClients.BackgroundColor = System.Drawing.Color.White;
            dataGridViewClients.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewClients.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewClients.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewClients.ColumnHeadersHeight = 50;
            dataGridViewClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewClients.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(229, 226, 244);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewClients.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewClients.Dock = DockStyle.Fill;
            dataGridViewClients.EnableHeadersVisualStyles = false;
            dataGridViewClients.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewClients.GridColor = System.Drawing.Color.White;
            dataGridViewClients.IsCustomScroll = true;
            dataGridViewClients.IsRowColorChangeonMouseMove = true;
            dataGridViewClients.IsSelectRow = true;
            dataGridViewClients.Location = new System.Drawing.Point(0, 140);
            dataGridViewClients.MultiSelect = false;
            dataGridViewClients.Name = "dataGridViewClients";
            dataGridViewClients.ReadOnly = true;
            dataGridViewClients.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewClients.RowHeadersVisible = false;
            dataGridViewClients.RowHeadersWidth = 60;
            dataGridViewClients.RowTemplate.DividerHeight = 1;
            dataGridViewClients.RowTemplate.Height = 60;
            dataGridViewClients.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridViewClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClients.Size = new System.Drawing.Size(1287, 475);
            dataGridViewClients.TabIndex = 30;
            dataGridViewClients.CellFormatting += dataGridViewClients_CellFormatting;
            dataGridViewClients.CellMouseDoubleClick += dataGridViewClients_CellMouseDoubleClick;
            dataGridViewClients.CellMouseMove += dataGridViewClients_CellMouseMove;
            dataGridViewClients.CellPainting += dataGridViewClients_CellPainting;
            dataGridViewClients.ColumnHeaderMouseClick += dataGridViewClients_ColumnHeaderMouseClick;
            dataGridViewClients.RowsRemoved += dataGridViewClients_RowsRemoved;
            dataGridViewClients.Scroll += dataGridViewClients_Scroll;
            // 
            // FLPFiltersSlideSDhow
            // 
            FLPFiltersSlideSDhow.Dock = DockStyle.Top;
            FLPFiltersSlideSDhow.Location = new System.Drawing.Point(0, 0);
            FLPFiltersSlideSDhow.Name = "FLPFiltersSlideSDhow";
            FLPFiltersSlideSDhow.Size = new System.Drawing.Size(1287, 140);
            FLPFiltersSlideSDhow.TabIndex = 29;
            // 
            // TLPSearchAndFilter
            // 
            TLPSearchAndFilter.ColumnCount = 6;
            TLPSearchAndFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 33F));
            TLPSearchAndFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 286F));
            TLPSearchAndFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 98F));
            TLPSearchAndFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TLPSearchAndFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 43F));
            TLPSearchAndFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45F));
            TLPSearchAndFilter.Controls.Add(textBoxSearch, 1, 0);
            TLPSearchAndFilter.Controls.Add(pictureBoxSearch, 0, 0);
            TLPSearchAndFilter.Controls.Add(FLPFilter, 2, 0);
            TLPSearchAndFilter.Controls.Add(buttonResetOrder, 3, 0);
            TLPSearchAndFilter.Controls.Add(iconButtonAddClient, 5, 0);
            TLPSearchAndFilter.Controls.Add(iconButtonViewBirthdays, 4, 0);
            TLPSearchAndFilter.Dock = DockStyle.Fill;
            TLPSearchAndFilter.Location = new System.Drawing.Point(3, 3);
            TLPSearchAndFilter.Name = "TLPSearchAndFilter";
            TLPSearchAndFilter.RowCount = 1;
            TLPSearchAndFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLPSearchAndFilter.Size = new System.Drawing.Size(1287, 44);
            TLPSearchAndFilter.TabIndex = 29;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxSearch.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            textBoxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            textBoxSearch.IsRequiredModeOn = false;
            textBoxSearch.Location = new System.Drawing.Point(36, 9);
            textBoxSearch.Margin = new Padding(3, 3, 3, 6);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Search by name or phone number...";
            textBoxSearch.Size = new System.Drawing.Size(277, 29);
            textBoxSearch.TabIndex = 30;
            textBoxSearch.Text = "Search by name or phone number...";
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // pictureBoxSearch
            // 
            pictureBoxSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBoxSearch.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBoxSearch.BackgroundImage");
            pictureBoxSearch.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxSearch.Location = new System.Drawing.Point(7, 14);
            pictureBoxSearch.Margin = new Padding(7, 7, 0, 10);
            pictureBoxSearch.Name = "pictureBoxSearch";
            pictureBoxSearch.Size = new System.Drawing.Size(26, 20);
            pictureBoxSearch.TabIndex = 29;
            pictureBoxSearch.TabStop = false;
            // 
            // FLPFilter
            // 
            FLPFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            FLPFilter.BorderStyle = BorderStyle.FixedSingle;
            FLPFilter.Controls.Add(pictureBox1);
            FLPFilter.Controls.Add(label1);
            FLPFilter.Cursor = Cursors.Hand;
            FLPFilter.FlowDirection = FlowDirection.RightToLeft;
            FLPFilter.Location = new System.Drawing.Point(322, 10);
            FLPFilter.Margin = new Padding(3, 3, 3, 6);
            FLPFilter.Name = "FLPFilter";
            FLPFilter.Size = new System.Drawing.Size(88, 28);
            FLPFilter.TabIndex = 31;
            FLPFilter.Click += FLPFilter_Click;
            FLPFilter.MouseLeave += label1_MouseLeave;
            FLPFilter.MouseMove += FLPFilter_MouseMove;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new System.Drawing.Point(58, 1);
            pictureBox1.Margin = new Padding(0, 1, 0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(28, 24);
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            pictureBox1.Click += FLPFilter_Click;
            pictureBox1.MouseLeave += label1_MouseLeave;
            pictureBox1.MouseMove += FLPFilter_MouseMove;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(2, 2);
            label1.Margin = new Padding(0, 2, 0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 24);
            label1.TabIndex = 22;
            label1.Text = "Filters";
            label1.Click += FLPFilter_Click;
            label1.MouseLeave += label1_MouseLeave;
            label1.MouseMove += FLPFilter_MouseMove;
            // 
            // buttonResetOrder
            // 
            buttonResetOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonResetOrder.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonResetOrder.Cursor = Cursors.Hand;
            buttonResetOrder.FlatAppearance.BorderSize = 0;
            buttonResetOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 142, 244);
            buttonResetOrder.FlatStyle = FlatStyle.Flat;
            buttonResetOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonResetOrder.ForeColor = System.Drawing.Color.White;
            buttonResetOrder.Location = new System.Drawing.Point(421, 11);
            buttonResetOrder.Margin = new Padding(4, 4, 4, 7);
            buttonResetOrder.Name = "buttonResetOrder";
            buttonResetOrder.Size = new System.Drawing.Size(97, 26);
            buttonResetOrder.TabIndex = 4;
            buttonResetOrder.Text = "Reset Order";
            buttonResetOrder.UseVisualStyleBackColor = false;
            buttonResetOrder.Click += buttonResetOrder_Click;
            // 
            // iconButtonAddClient
            // 
            iconButtonAddClient.Anchor = AnchorStyles.None;
            iconButtonAddClient.BackColor = System.Drawing.Color.Transparent;
            iconButtonAddClient.BackgroundImage = (System.Drawing.Image)resources.GetObject("iconButtonAddClient.BackgroundImage");
            iconButtonAddClient.BackgroundImageLayout = ImageLayout.Zoom;
            iconButtonAddClient.FlatAppearance.BorderSize = 0;
            iconButtonAddClient.FlatStyle = FlatStyle.Flat;
            iconButtonAddClient.Location = new System.Drawing.Point(1247, 8);
            iconButtonAddClient.Margin = new Padding(3, 7, 3, 3);
            iconButtonAddClient.MotionHeight = true;
            iconButtonAddClient.MotionWidth = true;
            iconButtonAddClient.Name = "iconButtonAddClient";
            iconButtonAddClient.Size = new System.Drawing.Size(35, 32);
            iconButtonAddClient.TabIndex = 32;
            toolTip1.SetToolTip(iconButtonAddClient, "Add new client");
            iconButtonAddClient.UseVisualStyleBackColor = false;
            iconButtonAddClient.Click += iconButtonAddClient_Click;
            // 
            // iconButtonViewBirthdays
            // 
            iconButtonViewBirthdays.Anchor = AnchorStyles.None;
            iconButtonViewBirthdays.BackColor = System.Drawing.Color.Transparent;
            iconButtonViewBirthdays.BackgroundImage = (System.Drawing.Image)resources.GetObject("iconButtonViewBirthdays.BackgroundImage");
            iconButtonViewBirthdays.BackgroundImageLayout = ImageLayout.Zoom;
            iconButtonViewBirthdays.FlatAppearance.BorderSize = 0;
            iconButtonViewBirthdays.FlatStyle = FlatStyle.Flat;
            iconButtonViewBirthdays.Location = new System.Drawing.Point(1203, 6);
            iconButtonViewBirthdays.MotionHeight = true;
            iconButtonViewBirthdays.MotionWidth = true;
            iconButtonViewBirthdays.Name = "iconButtonViewBirthdays";
            iconButtonViewBirthdays.Size = new System.Drawing.Size(35, 32);
            iconButtonViewBirthdays.TabIndex = 32;
            toolTip1.SetToolTip(iconButtonViewBirthdays, "See coming birthdays");
            iconButtonViewBirthdays.UseVisualStyleBackColor = false;
            iconButtonViewBirthdays.Click += iconButtonViewBirthdays_Click;
            // 
            // panelResults
            // 
            panelResults.Controls.Add(labelResults);
            panelResults.Controls.Add(label13);
            panelResults.Dock = DockStyle.Fill;
            panelResults.Location = new System.Drawing.Point(3, 674);
            panelResults.Name = "panelResults";
            panelResults.Size = new System.Drawing.Size(1287, 36);
            panelResults.TabIndex = 30;
            // 
            // labelResults
            // 
            labelResults.AutoSize = true;
            labelResults.Dock = DockStyle.Left;
            labelResults.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelResults.Location = new System.Drawing.Point(179, 0);
            labelResults.Name = "labelResults";
            labelResults.Size = new System.Drawing.Size(31, 25);
            labelResults.TabIndex = 1;
            labelResults.Text = "10";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Dock = DockStyle.Left;
            label13.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label13.Location = new System.Drawing.Point(0, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(179, 25);
            label13.TabIndex = 0;
            label13.Text = "Number Of Results:";
            // 
            // timerFilterOn
            // 
            timerFilterOn.Interval = 1;
            timerFilterOn.Tick += timerFilterOn_Tick;
            // 
            // timerFilterOff
            // 
            timerFilterOff.Interval = 1;
            timerFilterOff.Tick += timerFilterOff_Tick;
            // 
            // TLPGlobal
            // 
            TLPGlobal.ColumnCount = 1;
            TLPGlobal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TLPGlobal.Controls.Add(TLPGlobalJunior, 0, 0);
            TLPGlobal.Dock = DockStyle.Fill;
            TLPGlobal.Location = new System.Drawing.Point(0, 0);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 1;
            TLPGlobal.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TLPGlobal.Size = new System.Drawing.Size(1311, 728);
            TLPGlobal.TabIndex = 22;
            // 
            // timerUnselectComboBox
            // 
            timerUnselectComboBox.Interval = 800;
            // 
            // SearchCurrentClient
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1311, 728);
            Controls.Add(TLPGlobal);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "SearchCurrentClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SearchCurrentClient";
            Deactivate += SearchCurrentClient_Deactivate;
            Load += SearchCurrentClient_Load;
            Resize += SearchCurrentClient_Resize;
            TLPGlobalJunior.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).EndInit();
            TLPSearchAndFilter.ResumeLayout(false);
            TLPSearchAndFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearch).EndInit();
            FLPFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelResults.ResumeLayout(false);
            panelResults.PerformLayout();
            TLPGlobal.ResumeLayout(false);
            ResumeLayout(false);
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