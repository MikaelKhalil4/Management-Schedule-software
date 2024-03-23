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
            components = new System.ComponentModel.Container();
            TLPExercises = new System.Windows.Forms.TableLayoutPanel();
            FLPSelectedItems = new System.Windows.Forms.FlowLayoutPanel();
            UCItemCost = new UCPayments();
            buttonBuy = new System.Windows.Forms.Button();
            timer1 = new System.Windows.Forms.Timer(components);
            TLPExercises.SuspendLayout();
            SuspendLayout();
            // 
            // TLPExercises
            // 
            TLPExercises.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPExercises.ColumnCount = 1;
            TLPExercises.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPExercises.Controls.Add(FLPSelectedItems, 0, 1);
            TLPExercises.Controls.Add(UCItemCost, 0, 0);
            TLPExercises.Controls.Add(buttonBuy, 0, 3);
            TLPExercises.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPExercises.Location = new System.Drawing.Point(0, 0);
            TLPExercises.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPExercises.Name = "TLPExercises";
            TLPExercises.RowCount = 4;
            TLPExercises.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            TLPExercises.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.80702F));
            TLPExercises.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.70176F));
            TLPExercises.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.74561F));
            TLPExercises.Size = new System.Drawing.Size(544, 508);
            TLPExercises.TabIndex = 739;
            // 
            // FLPSelectedItems
            // 
            FLPSelectedItems.AutoScroll = true;
            FLPSelectedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            FLPSelectedItems.Location = new System.Drawing.Point(4, 56);
            FLPSelectedItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            FLPSelectedItems.Name = "FLPSelectedItems";
            FLPSelectedItems.Size = new System.Drawing.Size(536, 110);
            FLPSelectedItems.TabIndex = 737;
            FLPSelectedItems.WrapContents = false;
            // 
            // UCItemCost
            // 
            UCItemCost.Amount = 0D;
            UCItemCost.Anchor = System.Windows.Forms.AnchorStyles.None;
            UCItemCost.BackColor = System.Drawing.Color.Transparent;
            UCItemCost.EditModeOn = false;
            UCItemCost.Location = new System.Drawing.Point(90, 3);
            UCItemCost.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            UCItemCost.Name = "UCItemCost";
            UCItemCost.Sign = "+";
            UCItemCost.Size = new System.Drawing.Size(363, 47);
            UCItemCost.TabIndex = 739;
            // 
            // buttonBuy
            // 
            buttonBuy.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonBuy.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonBuy.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonBuy.FlatAppearance.BorderSize = 0;
            buttonBuy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(100, 112, 214);
            buttonBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonBuy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonBuy.ForeColor = System.Drawing.Color.White;
            buttonBuy.Location = new System.Drawing.Point(432, 466);
            buttonBuy.Margin = new System.Windows.Forms.Padding(4, 9, 4, 9);
            buttonBuy.Name = "buttonBuy";
            buttonBuy.Size = new System.Drawing.Size(108, 33);
            buttonBuy.TabIndex = 732;
            buttonBuy.Text = "Purchase";
            buttonBuy.UseVisualStyleBackColor = false;
            buttonBuy.Click += buttonBuy_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // BuyBundleOrProudct
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(544, 508);
            Controls.Add(TLPExercises);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BuyBundleOrProudct";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "BuyServiceOrProudct";
            Deactivate += BuyBundleOrProudct_Deactivate;
            FormClosing += BuyBundleOrProudct_FormClosing;
            TLPExercises.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPExercises;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.FlowLayoutPanel FLPSelectedItems;
        private System.Windows.Forms.Timer timer1;
        public UCPayments UCItemCost;
    }
}