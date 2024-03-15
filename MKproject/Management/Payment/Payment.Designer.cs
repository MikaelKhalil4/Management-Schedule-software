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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            TLPForm = new System.Windows.Forms.TableLayoutPanel();
            dataGridViewBalance = new System.Windows.Forms.DataGridView();
            TLPEditInfo = new System.Windows.Forms.TableLayoutPanel();
            labelPaymentSession = new System.Windows.Forms.Label();
            TLPBalance = new System.Windows.Forms.TableLayoutPanel();
            UCBalance = new UCPayments();
            labelBalance = new System.Windows.Forms.Label();
            ucSlideButtonPayOrEdit = new UCSlideButton();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            buttonUpdateOrPay = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            timer1 = new System.Windows.Forms.Timer(components);
            TLPForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBalance).BeginInit();
            TLPEditInfo.SuspendLayout();
            TLPBalance.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TLPForm
            // 
            TLPForm.BackColor = System.Drawing.Color.FromArgb(196, 210, 245);
            TLPForm.ColumnCount = 2;
            TLPForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TLPForm.Controls.Add(dataGridViewBalance, 0, 2);
            TLPForm.Controls.Add(TLPEditInfo, 1, 1);
            TLPForm.Controls.Add(TLPBalance, 0, 1);
            TLPForm.Controls.Add(ucSlideButtonPayOrEdit, 0, 0);
            TLPForm.Controls.Add(flowLayoutPanel1, 0, 3);
            TLPForm.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPForm.Location = new System.Drawing.Point(0, 0);
            TLPForm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 4;
            TLPForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            TLPForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.77778F));
            TLPForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.95413F));
            TLPForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            TLPForm.Size = new System.Drawing.Size(1003, 553);
            TLPForm.TabIndex = 5;
            // 
            // dataGridViewBalance
            // 
            dataGridViewBalance.AllowUserToAddRows = false;
            dataGridViewBalance.AllowUserToDeleteRows = false;
            dataGridViewBalance.AllowUserToResizeColumns = false;
            dataGridViewBalance.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewBalance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewBalance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBalance.BackgroundColor = System.Drawing.Color.White;
            dataGridViewBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewBalance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewBalance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewBalance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewBalance.ColumnHeadersHeight = 50;
            dataGridViewBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            TLPForm.SetColumnSpan(dataGridViewBalance, 2);
            dataGridViewBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewBalance.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewBalance.EnableHeadersVisualStyles = false;
            dataGridViewBalance.Location = new System.Drawing.Point(12, 277);
            dataGridViewBalance.Margin = new System.Windows.Forms.Padding(12, 0, 12, 3);
            dataGridViewBalance.Name = "dataGridViewBalance";
            dataGridViewBalance.ReadOnly = true;
            dataGridViewBalance.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewBalance.RowHeadersVisible = false;
            dataGridViewBalance.RowHeadersWidth = 60;
            dataGridViewBalance.RowTemplate.DividerHeight = 1;
            dataGridViewBalance.RowTemplate.Height = 40;
            dataGridViewBalance.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewBalance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dataGridViewBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            dataGridViewBalance.Size = new System.Drawing.Size(979, 224);
            dataGridViewBalance.TabIndex = 24;
            dataGridViewBalance.CellFormatting += dataGridViewBalance_CellFormatting;
            // 
            // TLPEditInfo
            // 
            TLPEditInfo.BackColor = System.Drawing.Color.White;
            TLPEditInfo.ColumnCount = 1;
            TLPEditInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPEditInfo.Controls.Add(labelPaymentSession, 0, 0);
            TLPEditInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPEditInfo.Location = new System.Drawing.Point(559, 114);
            TLPEditInfo.Margin = new System.Windows.Forms.Padding(58, 58, 58, 23);
            TLPEditInfo.Name = "TLPEditInfo";
            TLPEditInfo.RowCount = 2;
            TLPEditInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.57895F));
            TLPEditInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.42105F));
            TLPEditInfo.Size = new System.Drawing.Size(386, 140);
            TLPEditInfo.TabIndex = 23;
            // 
            // labelPaymentSession
            // 
            labelPaymentSession.Anchor = System.Windows.Forms.AnchorStyles.None;
            labelPaymentSession.AutoSize = true;
            labelPaymentSession.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelPaymentSession.Location = new System.Drawing.Point(119, 9);
            labelPaymentSession.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelPaymentSession.Name = "labelPaymentSession";
            labelPaymentSession.Size = new System.Drawing.Size(148, 25);
            labelPaymentSession.TabIndex = 9;
            labelPaymentSession.Text = "Down Payment";
            labelPaymentSession.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TLPBalance
            // 
            TLPBalance.BackColor = System.Drawing.Color.White;
            TLPBalance.ColumnCount = 1;
            TLPBalance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            TLPBalance.Controls.Add(UCBalance, 0, 1);
            TLPBalance.Controls.Add(labelBalance, 0, 0);
            TLPBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            TLPBalance.Location = new System.Drawing.Point(58, 114);
            TLPBalance.Margin = new System.Windows.Forms.Padding(58, 58, 58, 23);
            TLPBalance.Name = "TLPBalance";
            TLPBalance.RowCount = 2;
            TLPBalance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.52632F));
            TLPBalance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.47369F));
            TLPBalance.Size = new System.Drawing.Size(385, 140);
            TLPBalance.TabIndex = 22;
            // 
            // UCBalance
            // 
            UCBalance.Amount = 200D;
            UCBalance.BackColor = System.Drawing.Color.White;
            UCBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            UCBalance.EditModeOn = false;
            UCBalance.Location = new System.Drawing.Point(5, 45);
            UCBalance.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            UCBalance.Name = "UCBalance";
            UCBalance.Sign = "-";
            UCBalance.Size = new System.Drawing.Size(375, 92);
            UCBalance.TabIndex = 1;
            // 
            // labelBalance
            // 
            labelBalance.Anchor = System.Windows.Forms.AnchorStyles.None;
            labelBalance.AutoSize = true;
            labelBalance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelBalance.Location = new System.Drawing.Point(152, 8);
            labelBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new System.Drawing.Size(80, 25);
            labelBalance.TabIndex = 5;
            labelBalance.Text = "Balance";
            labelBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucSlideButtonPayOrEdit
            // 
            ucSlideButtonPayOrEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            ucSlideButtonPayOrEdit.BackColor = System.Drawing.Color.FromArgb(139, 152, 224);
            ucSlideButtonPayOrEdit.Button1text = null;
            ucSlideButtonPayOrEdit.Button2text = null;
            ucSlideButtonPayOrEdit.ClickedButton = null;
            TLPForm.SetColumnSpan(ucSlideButtonPayOrEdit, 2);
            ucSlideButtonPayOrEdit.Location = new System.Drawing.Point(367, 5);
            ucSlideButtonPayOrEdit.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            ucSlideButtonPayOrEdit.Name = "ucSlideButtonPayOrEdit";
            ucSlideButtonPayOrEdit.Size = new System.Drawing.Size(268, 46);
            ucSlideButtonPayOrEdit.TabIndex = 25;
            // 
            // flowLayoutPanel1
            // 
            TLPForm.SetColumnSpan(flowLayoutPanel1, 2);
            flowLayoutPanel1.Controls.Add(buttonUpdateOrPay);
            flowLayoutPanel1.Controls.Add(buttonCancel);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(4, 507);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(995, 43);
            flowLayoutPanel1.TabIndex = 26;
            // 
            // buttonUpdateOrPay
            // 
            buttonUpdateOrPay.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonUpdateOrPay.BackColor = System.Drawing.Color.FromArgb(109, 122, 224);
            buttonUpdateOrPay.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonUpdateOrPay.FlatAppearance.BorderSize = 0;
            buttonUpdateOrPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 142, 244);
            buttonUpdateOrPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonUpdateOrPay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonUpdateOrPay.ForeColor = System.Drawing.Color.White;
            buttonUpdateOrPay.Location = new System.Drawing.Point(887, 4);
            buttonUpdateOrPay.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            buttonUpdateOrPay.Name = "buttonUpdateOrPay";
            buttonUpdateOrPay.Size = new System.Drawing.Size(108, 33);
            buttonUpdateOrPay.TabIndex = 732;
            buttonUpdateOrPay.Text = "Pay";
            buttonUpdateOrPay.UseVisualStyleBackColor = false;
            buttonUpdateOrPay.Click += buttonUpdateOrPay_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonCancel.BackColor = System.Drawing.Color.FromArgb(95, 97, 99);
            buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(105, 107, 109);
            buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCancel.ForeColor = System.Drawing.Color.White;
            buttonCancel.Location = new System.Drawing.Point(771, 3);
            buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 8, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(108, 33);
            buttonCancel.TabIndex = 737;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // Payment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1003, 553);
            Controls.Add(TLPForm);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Payment";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Payment";
            FormClosing += Payment_FormClosing;
            TLPForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewBalance).EndInit();
            TLPEditInfo.ResumeLayout(false);
            TLPEditInfo.PerformLayout();
            TLPBalance.ResumeLayout(false);
            TLPBalance.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
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
        private UCSlideButton ucSlideButtonPayOrEdit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonUpdateOrPay;
        private System.Windows.Forms.Button buttonCancel;
    }
}