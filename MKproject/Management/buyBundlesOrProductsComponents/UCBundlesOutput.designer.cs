using CustomizedTools;

namespace MKproject.Management
{
    partial class UCBundlesOutput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewBundles = new CustomizedTools.DoubleBufferAndCustomScrollDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBundles)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBundles
            // 
            this.dataGridViewBundles.AllowUserToAddRows = false;
            this.dataGridViewBundles.AllowUserToDeleteRows = false;
            this.dataGridViewBundles.AllowUserToResizeColumns = false;
            this.dataGridViewBundles.AllowUserToResizeRows = false;
            this.dataGridViewBundles.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBundles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewBundles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewBundles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewBundles.ColumnHeadersHeight = 50;
            this.dataGridViewBundles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewBundles.ColumnHeadersVisible = false;
            this.dataGridViewBundles.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBundles.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBundles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBundles.EnableHeadersVisualStyles = false;
            this.dataGridViewBundles.GridColor = System.Drawing.Color.White;
            this.dataGridViewBundles.IsCustomScroll = true;
            this.dataGridViewBundles.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBundles.MultiSelect = false;
            this.dataGridViewBundles.Name = "dataGridViewBundles";
            this.dataGridViewBundles.ReadOnly = true;
            this.dataGridViewBundles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewBundles.RowHeadersVisible = false;
            this.dataGridViewBundles.RowHeadersWidth = 60;
            this.dataGridViewBundles.RowTemplate.DividerHeight = 1;
            this.dataGridViewBundles.RowTemplate.Height = 40;
            this.dataGridViewBundles.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBundles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewBundles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBundles.Size = new System.Drawing.Size(443, 320);
            this.dataGridViewBundles.TabIndex = 0;
            this.dataGridViewBundles.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewBundles_CellFormatting);
            this.dataGridViewBundles.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewBundles_CellMouseDown);
            // 
            // UCBundlesOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewBundles);
            this.Name = "UCBundlesOutput";
            this.Size = new System.Drawing.Size(443, 320);
            this.Load += new System.EventHandler(this.UCBundlesOutput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBundles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferAndCustomScrollDataGrid dataGridViewBundles;
    }
}
