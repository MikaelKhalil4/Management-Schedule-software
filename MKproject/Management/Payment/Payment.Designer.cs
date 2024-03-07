using CustomizedTools;

namespace MKproject.Management
{
    partial class Payment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TLPForm = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewBalance = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonUpdateOrPay = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.TLPEditInfo = new System.Windows.Forms.TableLayoutPanel();
            this.labelPaymentSession = new System.Windows.Forms.Label();
            this.TLPBalance = new System.Windows.Forms.TableLayoutPanel();
            this.UCBalance = new MKproject.Management.UCPayments();
            this.labelBalance = new System.Windows.Forms.Label();
            this.ucSlideButtonPayOrEdit = new CustomizedTools.UCSlideButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TLPForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBalance)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.TLPEditInfo.SuspendLayout();
            this.TLPBalance.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPForm
            // 
            this.TLPForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.TLPForm.ColumnCount = 2;
            this.TLPForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPForm.Controls.Add(this.dataGridViewBalance, 0, 2);
            this.TLPForm.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.TLPForm.Controls.Add(this.TLPEditInfo, 1, 1);
            this.TLPForm.Controls.Add(this.TLPBalance, 0, 1);
            this.TLPForm.Controls.Add(this.ucSlideButtonPayOrEdit, 0, 0);
            this.TLPForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPForm.Location = new System.Drawing.Point(0, 0);
            this.TLPForm.Name = "TLPForm";
            this.TLPForm.RowCount = 4;
            this.TLPForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.TLPForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.77778F));
            this.TLPForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.95413F));
            this.TLPForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.TLPForm.Size = new System.Drawing.Size(860, 479);
            this.TLPForm.TabIndex = 5;
            // 
            // dataGridViewBalance
            // 
            this.dataGridViewBalance.AllowUserToAddRows = false;
            this.dataGridViewBalance.AllowUserToDeleteRows = false;
            this.dataGridViewBalance.AllowUserToResizeColumns = false;
            this.dataGridViewBalance.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewBalance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBalance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBalance.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewBalance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewBalance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBalance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBalance.ColumnHeadersHeight = 50;
            this.dataGridViewBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TLPForm.SetColumnSpan(this.dataGridViewBalance, 2);
            this.dataGridViewBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBalance.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBalance.EnableHeadersVisualStyles = false;
            this.dataGridViewBalance.Location = new System.Drawing.Point(10, 240);
            this.dataGridViewBalance.Margin = new System.Windows.Forms.Padding(10, 0, 10, 3);
            this.dataGridViewBalance.Name = "dataGridViewBalance";
            this.dataGridViewBalance.ReadOnly = true;
            this.dataGridViewBalance.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewBalance.RowHeadersVisible = false;
            this.dataGridViewBalance.RowHeadersWidth = 60;
            this.dataGridViewBalance.RowTemplate.DividerHeight = 1;
            this.dataGridViewBalance.RowTemplate.Height = 40;
            this.dataGridViewBalance.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBalance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewBalance.Size = new System.Drawing.Size(840, 194);
            this.dataGridViewBalance.TabIndex = 24;
            this.dataGridViewBalance.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewBalance_CellFormatting);
            // 
            // flowLayoutPanel1
            // 
            this.TLPForm.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.buttonUpdateOrPay);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 440);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(854, 36);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // buttonUpdateOrPay
            // 
            this.buttonUpdateOrPay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonUpdateOrPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.buttonUpdateOrPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdateOrPay.FlatAppearance.BorderSize = 0;
            this.buttonUpdateOrPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(142)))), ((int)(((byte)(244)))));
            this.buttonUpdateOrPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdateOrPay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonUpdateOrPay.ForeColor = System.Drawing.Color.White;
            this.buttonUpdateOrPay.Location = new System.Drawing.Point(761, 4);
            this.buttonUpdateOrPay.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.buttonUpdateOrPay.Name = "buttonUpdateOrPay";
            this.buttonUpdateOrPay.Size = new System.Drawing.Size(93, 29);
            this.buttonUpdateOrPay.TabIndex = 732;
            this.buttonUpdateOrPay.Text = "Pay";
            this.buttonUpdateOrPay.UseVisualStyleBackColor = false;
            this.buttonUpdateOrPay.Click += new System.EventHandler(this.buttonUpdateOrPay_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(97)))), ((int)(((byte)(99)))));
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(661, 3);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(93, 29);
            this.buttonCancel.TabIndex = 737;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // TLPEditInfo
            // 
            this.TLPEditInfo.BackColor = System.Drawing.Color.White;
            this.TLPEditInfo.ColumnCount = 1;
            this.TLPEditInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPEditInfo.Controls.Add(this.labelPaymentSession, 0, 0);
            this.TLPEditInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPEditInfo.Location = new System.Drawing.Point(480, 98);
            this.TLPEditInfo.Margin = new System.Windows.Forms.Padding(50, 50, 50, 20);
            this.TLPEditInfo.Name = "TLPEditInfo";
            this.TLPEditInfo.RowCount = 2;
            this.TLPEditInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.57895F));
            this.TLPEditInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.42105F));
            this.TLPEditInfo.Size = new System.Drawing.Size(330, 122);
            this.TLPEditInfo.TabIndex = 23;
            // 
            // labelPaymentSession
            // 
            this.labelPaymentSession.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPaymentSession.AutoSize = true;
            this.labelPaymentSession.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaymentSession.Location = new System.Drawing.Point(91, 6);
            this.labelPaymentSession.Name = "labelPaymentSession";
            this.labelPaymentSession.Size = new System.Drawing.Size(148, 25);
            this.labelPaymentSession.TabIndex = 9;
            this.labelPaymentSession.Text = "Down Payment";
            this.labelPaymentSession.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TLPBalance
            // 
            this.TLPBalance.BackColor = System.Drawing.Color.White;
            this.TLPBalance.ColumnCount = 1;
            this.TLPBalance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPBalance.Controls.Add(this.UCBalance, 0, 1);
            this.TLPBalance.Controls.Add(this.labelBalance, 0, 0);
            this.TLPBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPBalance.Location = new System.Drawing.Point(50, 98);
            this.TLPBalance.Margin = new System.Windows.Forms.Padding(50, 50, 50, 20);
            this.TLPBalance.Name = "TLPBalance";
            this.TLPBalance.RowCount = 2;
            this.TLPBalance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.52632F));
            this.TLPBalance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.47369F));
            this.TLPBalance.Size = new System.Drawing.Size(330, 122);
            this.TLPBalance.TabIndex = 22;
            // 
            // UCBalance
            // 
            this.UCBalance.Amount = 200D;
            this.UCBalance.BackColor = System.Drawing.Color.White;
            this.UCBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCBalance.EditModeOn = false;
            this.UCBalance.Location = new System.Drawing.Point(3, 40);
            this.UCBalance.Name = "UCBalance";
            this.UCBalance.Sign = "-";
            this.UCBalance.Size = new System.Drawing.Size(324, 79);
            this.UCBalance.TabIndex = 1;
            // 
            // labelBalance
            // 
            this.labelBalance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBalance.AutoSize = true;
            this.labelBalance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBalance.Location = new System.Drawing.Point(125, 6);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(80, 25);
            this.labelBalance.TabIndex = 5;
            this.labelBalance.Text = "Balance";
            this.labelBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucSlideButtonPayOrEdit
            // 
            this.ucSlideButtonPayOrEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucSlideButtonPayOrEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(224)))));
            this.ucSlideButtonPayOrEdit.Button1text = null;
            this.ucSlideButtonPayOrEdit.Button2text = null;
            this.ucSlideButtonPayOrEdit.ClickedButton = null;
            this.TLPForm.SetColumnSpan(this.ucSlideButtonPayOrEdit, 2);
            this.ucSlideButtonPayOrEdit.Location = new System.Drawing.Point(315, 4);
            this.ucSlideButtonPayOrEdit.Name = "ucSlideButtonPayOrEdit";
            this.ucSlideButtonPayOrEdit.Size = new System.Drawing.Size(230, 40);
            this.ucSlideButtonPayOrEdit.TabIndex = 25;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 479);
            this.Controls.Add(this.TLPForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Payment_FormClosing);
            this.TLPForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBalance)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.TLPEditInfo.ResumeLayout(false);
            this.TLPEditInfo.PerformLayout();
            this.TLPBalance.ResumeLayout(false);
            this.TLPBalance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPForm;
        private System.Windows.Forms.DataGridView dataGridViewBalance;
        private System.Windows.Forms.TableLayoutPanel TLPEditInfo;
        private System.Windows.Forms.Label labelPaymentSession;
        private System.Windows.Forms.TableLayoutPanel TLPBalance;
        private System.Windows.Forms.Label labelBalance;
        private UCPayments UCBalance;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonUpdateOrPay;
        private UCSlideButton ucSlideButtonPayOrEdit;
        private System.Windows.Forms.Button buttonCancel;
    }
}