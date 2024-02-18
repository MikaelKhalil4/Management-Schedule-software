using CustomizedTools;

namespace MKproject.Management
{
    partial class CustomerService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerService));
            this.TLPBirthday = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewBirthClients = new CustomDataGridView();
            this.labelClientsBirthday = new System.Windows.Forms.Label();
            this.pictureBoxBirthdayCake = new System.Windows.Forms.PictureBox();
            this.TLPMain = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TLPBirthday.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBirthClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBirthdayCake)).BeginInit();
            this.TLPMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPBirthday
            // 
            this.TLPBirthday.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TLPBirthday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.TLPBirthday.ColumnCount = 2;
            this.TLPBirthday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBirthday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBirthday.Controls.Add(this.dataGridViewBirthClients, 0, 1);
            this.TLPBirthday.Controls.Add(this.labelClientsBirthday, 0, 0);
            this.TLPBirthday.Controls.Add(this.pictureBoxBirthdayCake, 1, 0);
            this.TLPBirthday.Location = new System.Drawing.Point(18, 11);
            this.TLPBirthday.Name = "TLPBirthday";
            this.TLPBirthday.Padding = new System.Windows.Forms.Padding(5);
            this.TLPBirthday.RowCount = 2;
            this.TLPBirthday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLPBirthday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.TLPBirthday.Size = new System.Drawing.Size(546, 419);
            this.TLPBirthday.TabIndex = 26;
            // 
            // dataGridViewBirthClients
            // 
            this.dataGridViewBirthClients.AllowUserToAddRows = false;
            this.dataGridViewBirthClients.AllowUserToDeleteRows = false;
            this.dataGridViewBirthClients.AllowUserToResizeColumns = false;
            this.dataGridViewBirthClients.AllowUserToResizeRows = false;
            this.dataGridViewBirthClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBirthClients.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBirthClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewBirthClients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewBirthClients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBirthClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBirthClients.ColumnHeadersHeight = 50;
            this.dataGridViewBirthClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TLPBirthday.SetColumnSpan(this.dataGridViewBirthClients, 2);
            this.dataGridViewBirthClients.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBirthClients.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBirthClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBirthClients.EnableHeadersVisualStyles = false;
            this.dataGridViewBirthClients.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridViewBirthClients.GridColor = System.Drawing.Color.White;
            this.dataGridViewBirthClients.IsCustomScroll = true;
            this.dataGridViewBirthClients.IsRowColorChangeonMouseMove = true;
            this.dataGridViewBirthClients.IsSelectRow = false;
            this.dataGridViewBirthClients.Location = new System.Drawing.Point(8, 48);
            this.dataGridViewBirthClients.MultiSelect = false;
            this.dataGridViewBirthClients.Name = "dataGridViewBirthClients";
            this.dataGridViewBirthClients.ReadOnly = true;
            this.dataGridViewBirthClients.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewBirthClients.RowHeadersVisible = false;
            this.dataGridViewBirthClients.RowHeadersWidth = 60;
            this.dataGridViewBirthClients.RowTemplate.DividerHeight = 1;
            this.dataGridViewBirthClients.RowTemplate.Height = 40;
            this.dataGridViewBirthClients.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBirthClients.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewBirthClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBirthClients.Size = new System.Drawing.Size(530, 363);
            this.dataGridViewBirthClients.TabIndex = 28;
            this.dataGridViewBirthClients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBirthClients_CellClick);
            // 
            // labelClientsBirthday
            // 
            this.labelClientsBirthday.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClientsBirthday.AutoSize = true;
            this.labelClientsBirthday.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientsBirthday.Location = new System.Drawing.Point(8, 8);
            this.labelClientsBirthday.Margin = new System.Windows.Forms.Padding(3);
            this.labelClientsBirthday.Name = "labelClientsBirthday";
            this.labelClientsBirthday.Size = new System.Drawing.Size(169, 34);
            this.labelClientsBirthday.TabIndex = 26;
            this.labelClientsBirthday.Text = "Clients Birthday";
            this.labelClientsBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxBirthdayCake
            // 
            this.pictureBoxBirthdayCake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxBirthdayCake.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBirthdayCake.Image")));
            this.pictureBoxBirthdayCake.Location = new System.Drawing.Point(484, 8);
            this.pictureBoxBirthdayCake.Name = "pictureBoxBirthdayCake";
            this.pictureBoxBirthdayCake.Size = new System.Drawing.Size(54, 34);
            this.pictureBoxBirthdayCake.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBirthdayCake.TabIndex = 27;
            this.pictureBoxBirthdayCake.TabStop = false;
            // 
            // TLPMain
            // 
            this.TLPMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPMain.ColumnCount = 1;
            this.TLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPMain.Controls.Add(this.TLPBirthday, 0, 0);
            this.TLPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPMain.Location = new System.Drawing.Point(0, 0);
            this.TLPMain.Name = "TLPMain";
            this.TLPMain.RowCount = 1;
            this.TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 448F));
            this.TLPMain.Size = new System.Drawing.Size(582, 441);
            this.TLPMain.TabIndex = 28;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CustomerService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(582, 441);
            this.Controls.Add(this.TLPMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerService";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Deactivate += new System.EventHandler(this.CustomerService_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomerService_FormClosing);
            this.Load += new System.EventHandler(this.CustomerService_Load);
            this.TLPBirthday.ResumeLayout(false);
            this.TLPBirthday.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBirthClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBirthdayCake)).EndInit();
            this.TLPMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLPBirthday;
        private System.Windows.Forms.Label labelClientsBirthday;
        private System.Windows.Forms.PictureBox pictureBoxBirthdayCake;
        private System.Windows.Forms.TableLayoutPanel TLPMain;
        private System.Windows.Forms.Timer timer1;
        public CustomDataGridView dataGridViewBirthClients;
    }
}