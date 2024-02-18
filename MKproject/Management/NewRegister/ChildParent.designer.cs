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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildParent));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FLPAddParent = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.TLPAddParent = new System.Windows.Forms.TableLayoutPanel();
            this.TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.ucSlideButton = new CustomizedTools.UCSlideButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.TLPSelectParent = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.dataGridViewSelectParent = new CustomizedTools.CustomDataGridView();
            this.textBoxSearch = new CustomizedTools.TextBoxWithPlaceHolder();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TLPAddParent.SuspendLayout();
            this.TLPGlobal.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.TLPSelectParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectParent)).BeginInit();
            this.SuspendLayout();
            // 
            // FLPAddParent
            // 
            this.FLPAddParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPAddParent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLPAddParent.Location = new System.Drawing.Point(3, 3);
            this.FLPAddParent.Name = "FLPAddParent";
            this.FLPAddParent.Size = new System.Drawing.Size(479, 279);
            this.FLPAddParent.TabIndex = 14;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(112)))), ((int)(((byte)(214)))));
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(250, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(93, 29);
            this.buttonAdd.TabIndex = 10;
            this.buttonAdd.Text = "Add Parent";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // TLPAddParent
            // 
            this.TLPAddParent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPAddParent.ColumnCount = 1;
            this.TLPAddParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPAddParent.Controls.Add(this.FLPAddParent, 0, 0);
            this.TLPAddParent.Location = new System.Drawing.Point(749, 120);
            this.TLPAddParent.Name = "TLPAddParent";
            this.TLPAddParent.RowCount = 1;
            this.TLPAddParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TLPAddParent.Size = new System.Drawing.Size(485, 285);
            this.TLPAddParent.TabIndex = 15;
            // 
            // TLPGlobal
            // 
            this.TLPGlobal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPGlobal.ColumnCount = 1;
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPGlobal.Controls.Add(this.ucSlideButton, 0, 0);
            this.TLPGlobal.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.TLPGlobal.Location = new System.Drawing.Point(12, 12);
            this.TLPGlobal.Name = "TLPGlobal";
            this.TLPGlobal.RowCount = 3;
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.72265F));
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.27735F));
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.TLPGlobal.Size = new System.Drawing.Size(352, 393);
            this.TLPGlobal.TabIndex = 16;
            // 
            // ucSlideButton
            // 
            this.ucSlideButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucSlideButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(224)))));
            this.ucSlideButton.Location = new System.Drawing.Point(20, 3);
            this.ucSlideButton.Name = "ucSlideButton";
            this.ucSlideButton.Size = new System.Drawing.Size(311, 39);
            this.ucSlideButton.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonAdd);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 356);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(346, 34);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(97)))), ((int)(((byte)(99)))));
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(151, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(93, 29);
            this.buttonCancel.TabIndex = 738;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // TLPSelectParent
            // 
            this.TLPSelectParent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPSelectParent.ColumnCount = 2;
            this.TLPSelectParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.TLPSelectParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPSelectParent.Controls.Add(this.pictureBoxSearch, 0, 0);
            this.TLPSelectParent.Controls.Add(this.dataGridViewSelectParent, 0, 1);
            this.TLPSelectParent.Controls.Add(this.textBoxSearch, 1, 0);
            this.TLPSelectParent.Location = new System.Drawing.Point(395, 12);
            this.TLPSelectParent.Name = "TLPSelectParent";
            this.TLPSelectParent.RowCount = 2;
            this.TLPSelectParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLPSelectParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.TLPSelectParent.Size = new System.Drawing.Size(334, 399);
            this.TLPSelectParent.TabIndex = 17;
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBoxSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxSearch.BackgroundImage")));
            this.pictureBoxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxSearch.Location = new System.Drawing.Point(9, 9);
            this.pictureBoxSearch.Margin = new System.Windows.Forms.Padding(7, 7, 0, 7);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(26, 20);
            this.pictureBoxSearch.TabIndex = 33;
            this.pictureBoxSearch.TabStop = false;
            // 
            // dataGridViewSelectParent
            // 
            this.dataGridViewSelectParent.AllowUserToAddRows = false;
            this.dataGridViewSelectParent.AllowUserToDeleteRows = false;
            this.dataGridViewSelectParent.AllowUserToResizeColumns = false;
            this.dataGridViewSelectParent.AllowUserToResizeRows = false;
            this.dataGridViewSelectParent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSelectParent.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSelectParent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSelectParent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewSelectParent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSelectParent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSelectParent.ColumnHeadersHeight = 50;
            this.dataGridViewSelectParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TLPSelectParent.SetColumnSpan(this.dataGridViewSelectParent, 2);
            this.dataGridViewSelectParent.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(226)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSelectParent.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSelectParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSelectParent.EnableHeadersVisualStyles = false;
            this.dataGridViewSelectParent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridViewSelectParent.GridColor = System.Drawing.Color.White;
            this.dataGridViewSelectParent.IsCustomScroll = true;
            this.dataGridViewSelectParent.IsRowColorChangeonMouseMove = true;
            this.dataGridViewSelectParent.IsSelectRow = true;
            this.dataGridViewSelectParent.Location = new System.Drawing.Point(3, 42);
            this.dataGridViewSelectParent.MultiSelect = false;
            this.dataGridViewSelectParent.Name = "dataGridViewSelectParent";
            this.dataGridViewSelectParent.ReadOnly = true;
            this.dataGridViewSelectParent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewSelectParent.RowHeadersVisible = false;
            this.dataGridViewSelectParent.RowHeadersWidth = 60;
            this.dataGridViewSelectParent.RowTemplate.DividerHeight = 1;
            this.dataGridViewSelectParent.RowTemplate.Height = 40;
            this.dataGridViewSelectParent.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSelectParent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSelectParent.Size = new System.Drawing.Size(328, 354);
            this.dataGridViewSelectParent.TabIndex = 31;
            this.dataGridViewSelectParent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectParent_CellDoubleClick);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSearch.Location = new System.Drawing.Point(38, 5);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Search by name or phone number...";
            this.textBoxSearch.Size = new System.Drawing.Size(277, 29);
            this.textBoxSearch.TabIndex = 32;
            this.textBoxSearch.Text = "Search by name or phone number...";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ChildParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 432);
            this.Controls.Add(this.TLPSelectParent);
            this.Controls.Add(this.TLPGlobal);
            this.Controls.Add(this.TLPAddParent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChildParent";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChildParent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChildParent_FormClosing);
            this.Load += new System.EventHandler(this.ChildParent_Load);
            this.TLPAddParent.ResumeLayout(false);
            this.TLPGlobal.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.TLPSelectParent.ResumeLayout(false);
            this.TLPSelectParent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectParent)).EndInit();
            this.ResumeLayout(false);

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