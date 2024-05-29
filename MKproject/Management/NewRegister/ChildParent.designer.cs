using CustomizedTools;

namespace MKproject.Management
{
    partial class ChildParent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildParent));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            FLPAddParent = new System.Windows.Forms.FlowLayoutPanel();
            buttonAdd = new System.Windows.Forms.Button();
            TLPAddParent = new System.Windows.Forms.TableLayoutPanel();
            TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            ucSlideButton = new UCSlideButton();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            buttonCancel = new System.Windows.Forms.Button();
            TLPSelectParent = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxSearch = new System.Windows.Forms.PictureBox();
            dataGridViewSelectParent = new CustomDataGridView();
            textBoxSearch = new TextBoxWithPlaceHolder();
            timer1 = new System.Windows.Forms.Timer(components);
            TLPAddParent.SuspendLayout();
            TLPGlobal.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            TLPSelectParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSelectParent).BeginInit();
            SuspendLayout();
            // 
            // FLPAddParent
            // 
            FLPAddParent.Dock = System.Windows.Forms.DockStyle.Fill;
            FLPAddParent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            FLPAddParent.Location = new System.Drawing.Point(4, 3);
            FLPAddParent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            FLPAddParent.Name = "FLPAddParent";
            FLPAddParent.Size = new System.Drawing.Size(558, 323);
            FLPAddParent.TabIndex = 14;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonAdd.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonAdd.FlatAppearance.BorderSize = 0;
            buttonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(100, 112, 214);
            buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonAdd.ForeColor = System.Drawing.Color.White;
            buttonAdd.Location = new System.Drawing.Point(291, 3);
            buttonAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new System.Drawing.Size(108, 33);
            buttonAdd.TabIndex = 10;
            buttonAdd.Text = "Add Parent";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // TLPAddParent
            // 
            TLPAddParent.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPAddParent.ColumnCount = 1;
            TLPAddParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPAddParent.Controls.Add(FLPAddParent, 0, 0);
            TLPAddParent.Location = new System.Drawing.Point(874, 138);
            TLPAddParent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPAddParent.Name = "TLPAddParent";
            TLPAddParent.RowCount = 1;
            TLPAddParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            TLPAddParent.Size = new System.Drawing.Size(566, 329);
            TLPAddParent.TabIndex = 15;
            // 
            // TLPGlobal
            // 
            TLPGlobal.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPGlobal.ColumnCount = 1;
            TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPGlobal.Controls.Add(ucSlideButton, 0, 0);
            TLPGlobal.Controls.Add(flowLayoutPanel1, 0, 2);
            TLPGlobal.Location = new System.Drawing.Point(14, 14);
            TLPGlobal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPGlobal.Name = "TLPGlobal";
            TLPGlobal.RowCount = 3;
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.72265F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.27735F));
            TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            TLPGlobal.Size = new System.Drawing.Size(411, 453);
            TLPGlobal.TabIndex = 16;
            // 
            // ucSlideButton
            // 
            ucSlideButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            ucSlideButton.BackColor = System.Drawing.Color.FromArgb(139, 152, 224);
            ucSlideButton.Button1text = null;
            ucSlideButton.Button2text = null;
            ucSlideButton.ClickedButton = null;
            ucSlideButton.Location = new System.Drawing.Point(24, 3);
            ucSlideButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            ucSlideButton.Name = "ucSlideButton";
            ucSlideButton.Size = new System.Drawing.Size(363, 45);
            ucSlideButton.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonAdd);
            flowLayoutPanel1.Controls.Add(buttonCancel);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(4, 410);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(403, 40);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = System.Drawing.Color.FromArgb(95, 97, 99);
            buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(105, 107, 109);
            buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCancel.ForeColor = System.Drawing.Color.White;
            buttonCancel.Location = new System.Drawing.Point(175, 3);
            buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(108, 33);
            buttonCancel.TabIndex = 738;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // TLPSelectParent
            // 
            TLPSelectParent.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPSelectParent.ColumnCount = 2;
            TLPSelectParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            TLPSelectParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPSelectParent.Controls.Add(pictureBoxSearch, 0, 0);
            TLPSelectParent.Controls.Add(dataGridViewSelectParent, 0, 1);
            TLPSelectParent.Controls.Add(textBoxSearch, 1, 0);
            TLPSelectParent.Location = new System.Drawing.Point(461, 14);
            TLPSelectParent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPSelectParent.Name = "TLPSelectParent";
            TLPSelectParent.RowCount = 2;
            TLPSelectParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            TLPSelectParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            TLPSelectParent.Size = new System.Drawing.Size(390, 460);
            TLPSelectParent.TabIndex = 17;
            // 
            // pictureBoxSearch
            // 
            pictureBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            pictureBoxSearch.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBoxSearch.BackgroundImage");
            pictureBoxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBoxSearch.Location = new System.Drawing.Point(11, 11);
            pictureBoxSearch.Margin = new System.Windows.Forms.Padding(8, 8, 0, 8);
            pictureBoxSearch.Name = "pictureBoxSearch";
            pictureBoxSearch.Size = new System.Drawing.Size(30, 23);
            pictureBoxSearch.TabIndex = 33;
            pictureBoxSearch.TabStop = false;
            // 
            // dataGridViewSelectParent
            // 
            dataGridViewSelectParent.AllowUserToAddRows = false;
            dataGridViewSelectParent.AllowUserToDeleteRows = false;
            dataGridViewSelectParent.AllowUserToResizeColumns = false;
            dataGridViewSelectParent.AllowUserToResizeRows = false;
            dataGridViewSelectParent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSelectParent.BackgroundColor = System.Drawing.Color.White;
            dataGridViewSelectParent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewSelectParent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewSelectParent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewSelectParent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewSelectParent.ColumnHeadersHeight = 50;
            dataGridViewSelectParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            TLPSelectParent.SetColumnSpan(dataGridViewSelectParent, 2);
            dataGridViewSelectParent.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(229, 226, 244);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewSelectParent.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewSelectParent.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewSelectParent.EnableHeadersVisualStyles = false;
            dataGridViewSelectParent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewSelectParent.GridColor = System.Drawing.Color.White;
            dataGridViewSelectParent.IsCustomScroll = true;
            dataGridViewSelectParent.IsRowColorChangeonMouseMove = true;
            dataGridViewSelectParent.IsSelectRow = true;
            dataGridViewSelectParent.Location = new System.Drawing.Point(4, 49);
            dataGridViewSelectParent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dataGridViewSelectParent.MultiSelect = false;
            dataGridViewSelectParent.Name = "dataGridViewSelectParent";
            dataGridViewSelectParent.ReadOnly = true;
            dataGridViewSelectParent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewSelectParent.RowHeadersVisible = false;
            dataGridViewSelectParent.RowHeadersWidth = 60;
            dataGridViewSelectParent.RowTemplate.DividerHeight = 1;
            dataGridViewSelectParent.RowTemplate.Height = 40;
            dataGridViewSelectParent.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewSelectParent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSelectParent.Size = new System.Drawing.Size(382, 408);
            dataGridViewSelectParent.TabIndex = 31;
            dataGridViewSelectParent.CellDoubleClick += dataGridViewSelectParent_CellDoubleClick;
            dataGridViewSelectParent.CellFormatting += dataGridViewSelectParent_CellFormatting;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            textBoxSearch.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            textBoxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            textBoxSearch.IsRequiredModeOn = false;
            textBoxSearch.Location = new System.Drawing.Point(45, 8);
            textBoxSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Search by name or phone number...";
            textBoxSearch.Size = new System.Drawing.Size(322, 29);
            textBoxSearch.TabIndex = 32;
            textBoxSearch.Text = "Search by name or phone number...";
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // ChildParent
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1498, 498);
            Controls.Add(TLPSelectParent);
            Controls.Add(TLPGlobal);
            Controls.Add(TLPAddParent);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChildParent";
            Opacity = 0D;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ChildParent";
            FormClosing += ChildParent_FormClosing;
            Load += ChildParent_Load;
            TLPAddParent.ResumeLayout(false);
            TLPGlobal.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            TLPSelectParent.ResumeLayout(false);
            TLPSelectParent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSelectParent).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel FLPAddParent;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TableLayoutPanel TLPAddParent;
        public CustomDataGridView dataGridViewSelectParent;
        private UCSlideButton ucSlideButton;
        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        private System.Windows.Forms.TableLayoutPanel TLPSelectParent;
        public TextBoxWithPlaceHolder textBoxSearch;
        public System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonCancel;
    }
}