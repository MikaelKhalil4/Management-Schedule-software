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
            dataGridViewBundles = new CustomDataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBundles).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewBundles
            // 
            dataGridViewBundles.AllowUserToAddRows = false;
            dataGridViewBundles.AllowUserToDeleteRows = false;
            dataGridViewBundles.AllowUserToResizeColumns = false;
            dataGridViewBundles.AllowUserToResizeRows = false;
            dataGridViewBundles.BackgroundColor = System.Drawing.Color.White;
            dataGridViewBundles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewBundles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewBundles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewBundles.ColumnHeadersHeight = 50;
            dataGridViewBundles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewBundles.ColumnHeadersVisible = false;
            dataGridViewBundles.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewBundles.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewBundles.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewBundles.EnableHeadersVisualStyles = false;
            dataGridViewBundles.GridColor = System.Drawing.Color.White;
            dataGridViewBundles.IsCustomScroll = true;
            dataGridViewBundles.IsRowColorChangeonMouseMove = false;
            dataGridViewBundles.IsSelectRow = false;
            dataGridViewBundles.Location = new System.Drawing.Point(0, 0);
            dataGridViewBundles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dataGridViewBundles.Name = "dataGridViewBundles";
            dataGridViewBundles.ReadOnly = true;
            dataGridViewBundles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewBundles.RowHeadersVisible = false;
            dataGridViewBundles.RowHeadersWidth = 60;
            dataGridViewBundles.RowTemplate.DividerHeight = 1;
            dataGridViewBundles.RowTemplate.Height = 40;
            dataGridViewBundles.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewBundles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dataGridViewBundles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBundles.Size = new System.Drawing.Size(517, 369);
            dataGridViewBundles.TabIndex = 0;
            dataGridViewBundles.CellFormatting += dataGridViewBundles_CellFormatting;
            dataGridViewBundles.CellMouseDown += dataGridViewBundles_CellMouseDown;
            // 
            // UCBundlesOutput
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(dataGridViewBundles);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UCBundlesOutput";
            Size = new System.Drawing.Size(517, 369);
            Load += UCBundlesOutput_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBundles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CustomDataGridView dataGridViewBundles;
    }
}
