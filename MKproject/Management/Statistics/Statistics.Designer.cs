namespace MKproject.Management
{
    partial class Statistics
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TLPGLobalIncom = new System.Windows.Forms.TableLayoutPanel();
            this.TLPIncome = new System.Windows.Forms.TableLayoutPanel();
            this.labelIncome = new System.Windows.Forms.Label();
            this.labelTotalIncome = new System.Windows.Forms.Label();
            this.panelIncomeFilter = new System.Windows.Forms.Panel();
            this.chartIncomePerService = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartIncomePerTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TLPSessions = new System.Windows.Forms.TableLayoutPanel();
            this.labelSession = new System.Windows.Forms.Label();
            this.panelSessionsFilter = new System.Windows.Forms.Panel();
            this.labelTotalNumberOfSessions = new System.Windows.Forms.Label();
            this.chartSessions = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TLPGlobalSessions = new System.Windows.Forms.TableLayoutPanel();
            this.TLPGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.TLPGLobalIncom.SuspendLayout();
            this.TLPIncome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartIncomePerService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIncomePerTime)).BeginInit();
            this.TLPSessions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSessions)).BeginInit();
            this.TLPGlobalSessions.SuspendLayout();
            this.TLPGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPGLobalIncom
            // 
            this.TLPGLobalIncom.BackColor = System.Drawing.Color.Transparent;
            this.TLPGLobalIncom.ColumnCount = 2;
            this.TLPGLobalIncom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.7F));
            this.TLPGLobalIncom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.3F));
            this.TLPGLobalIncom.Controls.Add(this.TLPIncome, 0, 0);
            this.TLPGLobalIncom.Controls.Add(this.chartIncomePerService, 1, 0);
            this.TLPGLobalIncom.Controls.Add(this.chartIncomePerTime, 1, 1);
            this.TLPGLobalIncom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPGLobalIncom.Location = new System.Drawing.Point(0, 0);
            this.TLPGLobalIncom.Margin = new System.Windows.Forms.Padding(0);
            this.TLPGLobalIncom.Name = "TLPGLobalIncom";
            this.TLPGLobalIncom.RowCount = 2;
            this.TLPGLobalIncom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.52475F));
            this.TLPGLobalIncom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.47525F));
            this.TLPGLobalIncom.Size = new System.Drawing.Size(1209, 463);
            this.TLPGLobalIncom.TabIndex = 0;
            // 
            // TLPIncome
            // 
            this.TLPIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.TLPIncome.ColumnCount = 1;
            this.TLPIncome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPIncome.Controls.Add(this.labelIncome, 0, 0);
            this.TLPIncome.Controls.Add(this.labelTotalIncome, 0, 1);
            this.TLPIncome.Controls.Add(this.panelIncomeFilter, 0, 2);
            this.TLPIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPIncome.Location = new System.Drawing.Point(0, 0);
            this.TLPIncome.Margin = new System.Windows.Forms.Padding(0);
            this.TLPIncome.Name = "TLPIncome";
            this.TLPIncome.RowCount = 3;
            this.TLPGLobalIncom.SetRowSpan(this.TLPIncome, 2);
            this.TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.50324F));
            this.TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.09503F));
            this.TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.02594F));
            this.TLPIncome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPIncome.Size = new System.Drawing.Size(153, 463);
            this.TLPIncome.TabIndex = 41;
            // 
            // labelIncome
            // 
            this.labelIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelIncome.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIncome.ForeColor = System.Drawing.Color.Black;
            this.labelIncome.Location = new System.Drawing.Point(0, 0);
            this.labelIncome.Margin = new System.Windows.Forms.Padding(0);
            this.labelIncome.Name = "labelIncome";
            this.labelIncome.Size = new System.Drawing.Size(153, 44);
            this.labelIncome.TabIndex = 0;
            this.labelIncome.Text = "Total Income";
            this.labelIncome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalIncome
            // 
            this.labelTotalIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotalIncome.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalIncome.ForeColor = System.Drawing.Color.Lime;
            this.labelTotalIncome.Location = new System.Drawing.Point(3, 44);
            this.labelTotalIncome.Name = "labelTotalIncome";
            this.labelTotalIncome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTotalIncome.Size = new System.Drawing.Size(147, 56);
            this.labelTotalIncome.TabIndex = 1;
            this.labelTotalIncome.Text = "+$3000000";
            this.labelTotalIncome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelIncomeFilter
            // 
            this.panelIncomeFilter.AutoScroll = true;
            this.panelIncomeFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIncomeFilter.Location = new System.Drawing.Point(0, 100);
            this.panelIncomeFilter.Margin = new System.Windows.Forms.Padding(0);
            this.panelIncomeFilter.Name = "panelIncomeFilter";
            this.panelIncomeFilter.Size = new System.Drawing.Size(153, 363);
            this.panelIncomeFilter.TabIndex = 33;
            // 
            // chartIncomePerService
            // 
            this.chartIncomePerService.BackColor = System.Drawing.Color.Transparent;
            this.chartIncomePerService.BorderSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            chartArea7.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea7.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea7.AxisX.MajorGrid.Enabled = false;
            chartArea7.AxisX.MajorTickMark.Enabled = false;
            chartArea7.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea7.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea7.AxisY.IsLabelAutoFit = false;
            chartArea7.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea7.AxisY.MajorGrid.Enabled = false;
            chartArea7.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea7.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea7.AxisY2.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea7.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea7.AxisY2.IsLabelAutoFit = false;
            chartArea7.AxisY2.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            chartArea7.AxisY2.MajorGrid.Enabled = false;
            chartArea7.BackColor = System.Drawing.Color.Transparent;
            chartArea7.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea7.InnerPlotPosition.Auto = false;
            chartArea7.InnerPlotPosition.Height = 90F;
            chartArea7.InnerPlotPosition.Width = 90F;
            chartArea7.InnerPlotPosition.X = 5F;
            chartArea7.Name = "ChartArea1";
            chartArea7.Position.Auto = false;
            chartArea7.Position.Height = 75F;
            chartArea7.Position.Width = 100F;
            chartArea7.Position.Y = 20F;
            this.chartIncomePerService.ChartAreas.Add(chartArea7);
            this.chartIncomePerService.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend3";
            this.chartIncomePerService.Legends.Add(legend3);
            this.chartIncomePerService.Location = new System.Drawing.Point(156, 3);
            this.chartIncomePerService.Name = "chartIncomePerService";
            series9.ChartArea = "ChartArea1";
            series9.Color = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            series9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series9.IsValueShownAsLabel = true;
            series9.Label = "#VAL{C1}";
            series9.LabelBackColor = System.Drawing.Color.WhiteSmoke;
            series9.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(189)))), ((int)(((byte)(57)))));
            series9.Legend = "Legend3";
            series9.LegendText = "Income";
            series9.Name = "SeriesIncome";
            series9.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.Yes;
            series9.SmartLabelStyle.MovingDirection = ((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Top | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopRight) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomRight)));
            series10.ChartArea = "ChartArea1";
            series10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            series10.IsValueShownAsLabel = true;
            series10.LabelBackColor = System.Drawing.Color.WhiteSmoke;
            series10.Legend = "Legend3";
            series10.LegendText = "Quantity";
            series10.Name = "SeriesQty";
            series10.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.Yes;
            series10.SmartLabelStyle.MovingDirection = ((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles)(((((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Top | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopRight) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomRight)));
            series10.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chartIncomePerService.Series.Add(series9);
            this.chartIncomePerService.Series.Add(series10);
            this.chartIncomePerService.Size = new System.Drawing.Size(1050, 214);
            this.chartIncomePerService.TabIndex = 35;
            this.chartIncomePerService.Text = "chart1";
            // 
            // chartIncomePerTime
            // 
            this.chartIncomePerTime.BackColor = System.Drawing.Color.Transparent;
            chartArea8.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea8.AxisX.IsLabelAutoFit = false;
            chartArea8.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea8.AxisX.MajorGrid.Enabled = false;
            chartArea8.AxisX.MajorGrid.LineColor = System.Drawing.Color.Empty;
            chartArea8.AxisX.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea8.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea8.AxisX.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea8.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea8.AxisY.IsLabelAutoFit = false;
            chartArea8.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            chartArea8.AxisY.MajorGrid.Enabled = false;
            chartArea8.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea8.AxisY.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea8.AxisY2.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea8.BackColor = System.Drawing.Color.Transparent;
            chartArea8.InnerPlotPosition.Auto = false;
            chartArea8.InnerPlotPosition.Height = 85F;
            chartArea8.InnerPlotPosition.Width = 90F;
            chartArea8.InnerPlotPosition.X = 5F;
            chartArea8.Name = "ChartArea1";
            chartArea8.Position.Auto = false;
            chartArea8.Position.Height = 83F;
            chartArea8.Position.Width = 100F;
            chartArea8.Position.Y = 11F;
            this.chartIncomePerTime.ChartAreas.Add(chartArea8);
            this.chartIncomePerTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartIncomePerTime.Location = new System.Drawing.Point(156, 223);
            this.chartIncomePerTime.Name = "chartIncomePerTime";
            series11.BorderColor = System.Drawing.Color.White;
            series11.BorderWidth = 2;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Color = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            series11.CustomProperties = "LabelStyle=Top";
            series11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series11.LabelBackColor = System.Drawing.Color.WhiteSmoke;
            series11.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(189)))), ((int)(((byte)(57)))));
            series11.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            series11.MarkerSize = 7;
            series11.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series11.Name = "Series1";
            series11.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No;
            series11.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.Empty;
            series11.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            series11.SmartLabelStyle.MovingDirection = ((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Top | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopRight) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomRight)));
            this.chartIncomePerTime.Series.Add(series11);
            this.chartIncomePerTime.Size = new System.Drawing.Size(1050, 237);
            this.chartIncomePerTime.TabIndex = 38;
            this.chartIncomePerTime.Text = "chart1";
            // 
            // TLPSessions
            // 
            this.TLPSessions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.TLPSessions.ColumnCount = 1;
            this.TLPSessions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPSessions.Controls.Add(this.labelSession, 0, 0);
            this.TLPSessions.Controls.Add(this.panelSessionsFilter, 0, 2);
            this.TLPSessions.Controls.Add(this.labelTotalNumberOfSessions, 0, 1);
            this.TLPSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPSessions.Location = new System.Drawing.Point(0, 0);
            this.TLPSessions.Margin = new System.Windows.Forms.Padding(0);
            this.TLPSessions.Name = "TLPSessions";
            this.TLPSessions.RowCount = 3;
            this.TLPSessions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.19512F));
            this.TLPSessions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.41463F));
            this.TLPSessions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.39024F));
            this.TLPSessions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPSessions.Size = new System.Drawing.Size(153, 261);
            this.TLPSessions.TabIndex = 2;
            // 
            // labelSession
            // 
            this.labelSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSession.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSession.ForeColor = System.Drawing.Color.Black;
            this.labelSession.Location = new System.Drawing.Point(0, 0);
            this.labelSession.Margin = new System.Windows.Forms.Padding(0);
            this.labelSession.Name = "labelSession";
            this.labelSession.Size = new System.Drawing.Size(153, 31);
            this.labelSession.TabIndex = 35;
            this.labelSession.Text = "Client Attendance";
            this.labelSession.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSessionsFilter
            // 
            this.panelSessionsFilter.AutoScroll = true;
            this.panelSessionsFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSessionsFilter.Location = new System.Drawing.Point(0, 66);
            this.panelSessionsFilter.Margin = new System.Windows.Forms.Padding(0);
            this.panelSessionsFilter.Name = "panelSessionsFilter";
            this.panelSessionsFilter.Size = new System.Drawing.Size(153, 195);
            this.panelSessionsFilter.TabIndex = 34;
            // 
            // labelTotalNumberOfSessions
            // 
            this.labelTotalNumberOfSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotalNumberOfSessions.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelTotalNumberOfSessions.ForeColor = System.Drawing.Color.Lime;
            this.labelTotalNumberOfSessions.Location = new System.Drawing.Point(3, 31);
            this.labelTotalNumberOfSessions.Name = "labelTotalNumberOfSessions";
            this.labelTotalNumberOfSessions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTotalNumberOfSessions.Size = new System.Drawing.Size(147, 35);
            this.labelTotalNumberOfSessions.TabIndex = 1;
            this.labelTotalNumberOfSessions.Text = "89";
            this.labelTotalNumberOfSessions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartSessions
            // 
            this.chartSessions.BackColor = System.Drawing.Color.Transparent;
            chartArea9.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea9.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea9.AxisX.MajorGrid.Enabled = false;
            chartArea9.AxisX.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea9.AxisX.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea9.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea9.AxisX.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea9.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea9.AxisY.IsLabelAutoFit = false;
            chartArea9.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            chartArea9.AxisY.MajorGrid.Enabled = false;
            chartArea9.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea9.AxisY.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea9.BackColor = System.Drawing.Color.Transparent;
            chartArea9.InnerPlotPosition.Auto = false;
            chartArea9.InnerPlotPosition.Height = 85F;
            chartArea9.InnerPlotPosition.Width = 90F;
            chartArea9.InnerPlotPosition.X = 5F;
            chartArea9.Name = "ChartArea1";
            chartArea9.Position.Auto = false;
            chartArea9.Position.Height = 83F;
            chartArea9.Position.Width = 100F;
            chartArea9.Position.Y = 11F;
            this.chartSessions.ChartAreas.Add(chartArea9);
            this.chartSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartSessions.Location = new System.Drawing.Point(156, 3);
            this.chartSessions.Name = "chartSessions";
            series12.BorderColor = System.Drawing.Color.White;
            series12.BorderWidth = 2;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Color = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            series12.CustomProperties = "LabelStyle=Top";
            series12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series12.LabelBackColor = System.Drawing.Color.WhiteSmoke;
            series12.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(189)))), ((int)(((byte)(57)))));
            series12.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            series12.MarkerSize = 7;
            series12.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series12.Name = "Series1";
            series12.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No;
            series12.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.Empty;
            series12.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            series12.SmartLabelStyle.MovingDirection = ((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Top | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopRight) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomRight)));
            this.chartSessions.Series.Add(series12);
            this.chartSessions.Size = new System.Drawing.Size(1050, 255);
            this.chartSessions.TabIndex = 39;
            this.chartSessions.Text = "chart1";
            // 
            // TLPGlobalSessions
            // 
            this.TLPGlobalSessions.BackColor = System.Drawing.Color.Transparent;
            this.TLPGlobalSessions.ColumnCount = 2;
            this.TLPGlobalSessions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.7F));
            this.TLPGlobalSessions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.3F));
            this.TLPGlobalSessions.Controls.Add(this.TLPSessions, 0, 0);
            this.TLPGlobalSessions.Controls.Add(this.chartSessions, 1, 0);
            this.TLPGlobalSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPGlobalSessions.Location = new System.Drawing.Point(0, 468);
            this.TLPGlobalSessions.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.TLPGlobalSessions.Name = "TLPGlobalSessions";
            this.TLPGlobalSessions.RowCount = 1;
            this.TLPGlobalSessions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPGlobalSessions.Size = new System.Drawing.Size(1209, 261);
            this.TLPGlobalSessions.TabIndex = 1;
            // 
            // TLPGlobal
            // 
            this.TLPGlobal.BackColor = System.Drawing.Color.White;
            this.TLPGlobal.ColumnCount = 1;
            this.TLPGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPGlobal.Controls.Add(this.TLPGLobalIncom, 0, 0);
            this.TLPGlobal.Controls.Add(this.TLPGlobalSessions, 0, 1);
            this.TLPGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPGlobal.Location = new System.Drawing.Point(0, 0);
            this.TLPGlobal.Name = "TLPGlobal";
            this.TLPGlobal.RowCount = 2;
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.64883F));
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.35117F));
            this.TLPGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPGlobal.Size = new System.Drawing.Size(1209, 729);
            this.TLPGlobal.TabIndex = 2;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1209, 729);
            this.Controls.Add(this.TLPGlobal);
            this.Name = "Statistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.TLPGLobalIncom.ResumeLayout(false);
            this.TLPIncome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartIncomePerService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIncomePerTime)).EndInit();
            this.TLPSessions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSessions)).EndInit();
            this.TLPGlobalSessions.ResumeLayout(false);
            this.TLPGlobal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPGLobalIncom;
        private System.Windows.Forms.Label labelTotalNumberOfSessions;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSessions;
        private System.Windows.Forms.TableLayoutPanel TLPIncome;
        private System.Windows.Forms.Label labelTotalIncome;
        private System.Windows.Forms.TableLayoutPanel TLPSessions;
        public System.Windows.Forms.Panel panelSessionsFilter;
        public System.Windows.Forms.Panel panelIncomeFilter;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIncomePerService;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIncomePerTime;
        private System.Windows.Forms.TableLayoutPanel TLPGlobalSessions;
        private System.Windows.Forms.TableLayoutPanel TLPGlobal;
        public System.Windows.Forms.Label labelIncome;
        public System.Windows.Forms.Label labelSession;
    }
}