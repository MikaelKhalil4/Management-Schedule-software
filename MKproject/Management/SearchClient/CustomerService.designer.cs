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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerService));
            TLPBirthday = new System.Windows.Forms.TableLayoutPanel();
            dataGridViewBirthClients = new CustomDataGridView();
            labelClientsBirthday = new System.Windows.Forms.Label();
            pictureBoxBirthdayCake = new System.Windows.Forms.PictureBox();
            TLPMain = new System.Windows.Forms.TableLayoutPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            TLPBirthday.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBirthClients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBirthdayCake).BeginInit();
            TLPMain.SuspendLayout();
            SuspendLayout();
            // 
            // TLPBirthday
            // 
            TLPBirthday.Anchor = System.Windows.Forms.AnchorStyles.None;
            TLPBirthday.BackColor = System.Drawing.Color.FromArgb(226, 240, 255);
            TLPBirthday.ColumnCount = 2;
            TLPBirthday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPBirthday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPBirthday.Controls.Add(dataGridViewBirthClients, 0, 1);
            TLPBirthday.Controls.Add(labelClientsBirthday, 0, 0);
            TLPBirthday.Controls.Add(pictureBoxBirthdayCake, 1, 0);
            TLPBirthday.Location = new System.Drawing.Point(21, 13);
            TLPBirthday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPBirthday.Name = "TLPBirthday";
            TLPBirthday.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            TLPBirthday.RowCount = 2;
            TLPBirthday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            TLPBirthday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            TLPBirthday.Size = new System.Drawing.Size(637, 483);
            TLPBirthday.TabIndex = 26;
            // 
            // dataGridViewBirthClients
            // 
            dataGridViewBirthClients.AllowUserToAddRows = false;
            dataGridViewBirthClients.AllowUserToDeleteRows = false;
            dataGridViewBirthClients.AllowUserToResizeColumns = false;
            dataGridViewBirthClients.AllowUserToResizeRows = false;
            dataGridViewBirthClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBirthClients.BackgroundColor = System.Drawing.Color.White;
            dataGridViewBirthClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewBirthClients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewBirthClients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewBirthClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewBirthClients.ColumnHeadersHeight = 50;
            dataGridViewBirthClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            TLPBirthday.SetColumnSpan(dataGridViewBirthClients, 2);
            dataGridViewBirthClients.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewBirthClients.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewBirthClients.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewBirthClients.EnableHeadersVisualStyles = false;
            dataGridViewBirthClients.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewBirthClients.GridColor = System.Drawing.Color.White;
            dataGridViewBirthClients.IsCustomScroll = true;
            dataGridViewBirthClients.IsRowColorChangeonMouseMove = true;
            dataGridViewBirthClients.IsSelectRow = false;
            dataGridViewBirthClients.Location = new System.Drawing.Point(10, 56);
            dataGridViewBirthClients.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dataGridViewBirthClients.MultiSelect = false;
            dataGridViewBirthClients.Name = "dataGridViewBirthClients";
            dataGridViewBirthClients.ReadOnly = true;
            dataGridViewBirthClients.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewBirthClients.RowHeadersVisible = false;
            dataGridViewBirthClients.RowHeadersWidth = 60;
            dataGridViewBirthClients.RowTemplate.DividerHeight = 1;
            dataGridViewBirthClients.RowTemplate.Height = 40;
            dataGridViewBirthClients.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewBirthClients.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dataGridViewBirthClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBirthClients.Size = new System.Drawing.Size(617, 418);
            dataGridViewBirthClients.TabIndex = 28;
            dataGridViewBirthClients.CellClick += dataGridViewBirthClients_CellClick;
            dataGridViewBirthClients.CellFormatting += dataGridViewBirthClients_CellFormatting;
            // 
            // labelClientsBirthday
            // 
            labelClientsBirthday.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            labelClientsBirthday.AutoSize = true;
            labelClientsBirthday.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelClientsBirthday.Location = new System.Drawing.Point(10, 9);
            labelClientsBirthday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            labelClientsBirthday.Name = "labelClientsBirthday";
            labelClientsBirthday.Size = new System.Drawing.Size(169, 41);
            labelClientsBirthday.TabIndex = 26;
            labelClientsBirthday.Text = "Clients Birthday";
            labelClientsBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxBirthdayCake
            // 
            pictureBoxBirthdayCake.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pictureBoxBirthdayCake.Image = (System.Drawing.Image)resources.GetObject("pictureBoxBirthdayCake.Image");
            pictureBoxBirthdayCake.Location = new System.Drawing.Point(564, 9);
            pictureBoxBirthdayCake.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBoxBirthdayCake.Name = "pictureBoxBirthdayCake";
            pictureBoxBirthdayCake.Size = new System.Drawing.Size(63, 39);
            pictureBoxBirthdayCake.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBoxBirthdayCake.TabIndex = 27;
            pictureBoxBirthdayCake.TabStop = false;
            // 
            // TLPMain
            // 
            TLPMain.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPMain.ColumnCount = 1;
            TLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPMain.Controls.Add(TLPBirthday, 0, 0);
            TLPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPMain.Location = new System.Drawing.Point(0, 0);
            TLPMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPMain.Name = "TLPMain";
            TLPMain.RowCount = 1;
            TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 517F));
            TLPMain.Size = new System.Drawing.Size(679, 509);
            TLPMain.TabIndex = 28;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // CustomerService
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(679, 509);
            Controls.Add(TLPMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomerService";
            Opacity = 0D;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Deactivate += CustomerService_Deactivate;
            FormClosing += CustomerService_FormClosing;
            Load += CustomerService_Load;
            TLPBirthday.ResumeLayout(false);
            TLPBirthday.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBirthClients).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBirthdayCake).EndInit();
            TLPMain.ResumeLayout(false);
            ResumeLayout(false);
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