using CustomizedTools;

namespace MKproject.Management
{
    partial class RelatedChildrens
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
            this.TLPMain = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewChildren = new CustomDataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TLPMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChildren)).BeginInit();
            this.SuspendLayout();
            // 
            // TLPMain
            // 
            this.TLPMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPMain.ColumnCount = 1;
            this.TLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPMain.Controls.Add(this.dataGridViewChildren, 0, 0);
            this.TLPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPMain.Location = new System.Drawing.Point(0, 0);
            this.TLPMain.Name = "TLPMain";
            this.TLPMain.RowCount = 1;
            this.TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.47369F));
            this.TLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPMain.Size = new System.Drawing.Size(384, 361);
            this.TLPMain.TabIndex = 27;
            // 
            // dataGridViewChildren
            // 
            this.dataGridViewChildren.AllowUserToAddRows = false;
            this.dataGridViewChildren.AllowUserToDeleteRows = false;
            this.dataGridViewChildren.AllowUserToResizeColumns = false;
            this.dataGridViewChildren.AllowUserToResizeRows = false;
            this.dataGridViewChildren.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewChildren.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewChildren.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewChildren.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewChildren.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewChildren.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewChildren.ColumnHeadersHeight = 50;
            this.dataGridViewChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewChildren.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewChildren.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewChildren.EnableHeadersVisualStyles = false;
            this.dataGridViewChildren.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridViewChildren.GridColor = System.Drawing.Color.White;
            this.dataGridViewChildren.IsCustomScroll = true;
            this.dataGridViewChildren.IsRowColorChangeonMouseMove = true;
            this.dataGridViewChildren.IsSelectRow = false;
            this.dataGridViewChildren.Location = new System.Drawing.Point(5, 5);
            this.dataGridViewChildren.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridViewChildren.MultiSelect = false;
            this.dataGridViewChildren.Name = "dataGridViewChildren";
            this.dataGridViewChildren.ReadOnly = true;
            this.dataGridViewChildren.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewChildren.RowHeadersVisible = false;
            this.dataGridViewChildren.RowHeadersWidth = 60;
            this.dataGridViewChildren.RowTemplate.DividerHeight = 1;
            this.dataGridViewChildren.RowTemplate.Height = 40;
            this.dataGridViewChildren.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewChildren.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewChildren.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewChildren.Size = new System.Drawing.Size(374, 351);
            this.dataGridViewChildren.TabIndex = 26;
            this.dataGridViewChildren.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewChildren_CellClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RelatedChildrens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.TLPMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelatedChildrens";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RelatedChildrens";
            this.Deactivate += new System.EventHandler(this.RelatedChildrens_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RelatedChildrens_FormClosing);
            this.Load += new System.EventHandler(this.RelatedChildrens_Load);
            this.TLPMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChildren)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLPMain;
        private System.Windows.Forms.Timer timer1;
        public CustomDataGridView dataGridViewChildren;
    }
}