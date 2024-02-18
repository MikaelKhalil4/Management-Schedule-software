namespace MKproject.Management
{
    partial class BuyBundleOrProudct
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
            this.TLPExercises = new System.Windows.Forms.TableLayoutPanel();
            this.FLPSelectedItems = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonBuy = new System.Windows.Forms.Button();
            this.UCItemCost = new UCPayments();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TLPExercises.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPExercises
            // 
            this.TLPExercises.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPExercises.ColumnCount = 1;
            this.TLPExercises.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPExercises.Controls.Add(this.FLPSelectedItems, 0, 1);
            this.TLPExercises.Controls.Add(this.panel1, 0, 3);
            this.TLPExercises.Controls.Add(this.UCItemCost, 0, 0);
            this.TLPExercises.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPExercises.Location = new System.Drawing.Point(0, 0);
            this.TLPExercises.Name = "TLPExercises";
            this.TLPExercises.RowCount = 4;
            this.TLPExercises.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.TLPExercises.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.80702F));
            this.TLPExercises.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.70176F));
            this.TLPExercises.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.74561F));
            this.TLPExercises.Size = new System.Drawing.Size(584, 456);
            this.TLPExercises.TabIndex = 739;
            // 
            // FLPSelectedItems
            // 
            this.FLPSelectedItems.AutoScroll = true;
            this.FLPSelectedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPSelectedItems.Location = new System.Drawing.Point(3, 51);
            this.FLPSelectedItems.Name = "FLPSelectedItems";
            this.FLPSelectedItems.Size = new System.Drawing.Size(578, 98);
            this.FLPSelectedItems.TabIndex = 737;
            this.FLPSelectedItems.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonBuy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 409);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 44);
            this.panel1.TabIndex = 738;
            // 
            // buttonBuy
            // 
            this.buttonBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonBuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBuy.FlatAppearance.BorderSize = 0;
            this.buttonBuy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(112)))), ((int)(((byte)(214)))));
            this.buttonBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonBuy.ForeColor = System.Drawing.Color.White;
            this.buttonBuy.Location = new System.Drawing.Point(482, 8);
            this.buttonBuy.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(93, 29);
            this.buttonBuy.TabIndex = 732;
            this.buttonBuy.Text = "Buy";
            this.buttonBuy.UseVisualStyleBackColor = false;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // UCItemCost
            // 
            this.UCItemCost.Amount = 0D;
            this.UCItemCost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UCItemCost.BackColor = System.Drawing.Color.Transparent;
            this.UCItemCost.EditModeOn = false;
            this.UCItemCost.Location = new System.Drawing.Point(136, 3);
            this.UCItemCost.Name = "UCItemCost";
            this.UCItemCost.Sign = "+";
            this.UCItemCost.Size = new System.Drawing.Size(311, 41);
            this.UCItemCost.TabIndex = 739;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BuyBundleOrProudct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 456);
            this.Controls.Add(this.TLPExercises);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuyBundleOrProudct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuyServiceOrProudct";
            this.Deactivate += new System.EventHandler(this.BuyBundleOrProudct_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BuyBundleOrProudct_FormClosing);
            this.TLPExercises.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPExercises;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.FlowLayoutPanel FLPSelectedItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        public UCPayments UCItemCost;
    }
}