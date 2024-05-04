using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CustomizedTools;
using GlobalFunctions;



namespace MKproject.Management
{
    public partial class Statistics : Form
    {
#pragma warning disable CA1416 // Validate platform compatibility

        Label LabelNoDataYetIncome;
        Label LabelNoDataYetSessions;

        public UCComboFilterStat UCComboFilterDateSessions;
        UCLabelFilterStatistics UCCustomeDateSessions;

        public UCComboFilterStat UCComboFilterDateIncome;
        UCComboFilterStat UCComboFilterServiceIncome;


        UCLabelFilterStatistics UCCustomeDateIncome;


        DataTable OriginalIncomeDt;


        public DataTable OriginalAllServicesIncomeDt;
        public DataTable OriginalSessionsDt;

        public DateTime DateOfFilterIncome;
        public DateTime DateOfFilterSessions;

        public Statistics()
        {
            InitializeComponent();

            LoadForm();

        }



        void LoadForm()
        {

            CreatingTheNoDateLabel(ref LabelNoDataYetIncome);
            CreatingTheNoDateLabel(ref LabelNoDataYetSessions);

            SetupChartIncomePerService();
            SetupChartIncomePerTime();
            SetupChartSessions();

            Formatcharts();

            OriginalSessionsDt = SQLToProject.GetAttendanceDate();
            OriginalIncomeDt = SQLToProject.GetIncome();

            SplitServices(OriginalIncomeDt);

            CreateFilters();


            labelIncome.Font = new Font(labelIncome.Font.FontFamily, 12, FontStyle.Bold);
            labelSession.Font = new Font(labelSession.Font.FontFamily, 12, FontStyle.Bold);
            RandomFunctions.FixedFont(labelIncome, FontStyle.Bold);
            RandomFunctions.FixedFont(labelSession, FontStyle.Bold);

        }//try catch
        void CreatingTheNoDateLabel(ref Label DesireddLabel)//false yaane sessions
        {
            DesireddLabel = new Label();
            // Set the label properties


            DesireddLabel.Font = new System.Drawing.Font("Segoe UI", 35, FontStyle.Italic);
            DesireddLabel.BackColor = Color.FromArgb(238, 241, 254);
            DesireddLabel.ForeColor = Color.FromArgb(150, 150, 150);
            DesireddLabel.TextAlign = ContentAlignment.MiddleCenter;
            DesireddLabel.AutoSize = false;
            DesireddLabel.Dock = DockStyle.Fill;
            DesireddLabel.Padding = new Padding(0, 0, 0, 30);


        }


        void SetNoDateLabel(bool IsIncome, bool IsDataExist, List<Chart> Charts)//ma32oul ykun eena 2 charts or one chart
        {

            if (!IsDataExist)
            {
                for (int i = 0; i < Charts.Count; i++)
                {
                    Charts[i].Visible = false;
                }

                // Set the label properties
                if (IsIncome)
                {
                    LabelNoDataYetIncome.Text = "No income reported";
                    TLPGLobalIncom.Controls.Remove(LabelNoDataYetIncome);
                    LabelNoDataYetIncome.Show();
                    TLPGLobalIncom.Controls.Add(LabelNoDataYetIncome, 1, 0);
                    TLPGLobalIncom.SetRowSpan(LabelNoDataYetIncome, 2);

                }
                else
                {
                    LabelNoDataYetSessions.Text = "No Sessions Done ";
                    TLPGlobalSessions.Controls.Remove(LabelNoDataYetSessions);
                    LabelNoDataYetSessions.Show();
                    TLPGlobalSessions.Controls.Add(LabelNoDataYetSessions, 1, 0);

                }
            }
            else
            {
                for (int i = 0; i < Charts.Count; i++)
                {
                    Charts[i].Visible = true;
                }

                if (IsIncome)
                {
                    if (TLPGLobalIncom.Controls.Contains(LabelNoDataYetIncome))
                    {
                        LabelNoDataYetIncome.Hide();
                        TLPGLobalIncom.Controls.Remove(LabelNoDataYetIncome);
                    }

                }
                else
                {
                    if (TLPGlobalSessions.Controls.Contains(LabelNoDataYetSessions))
                    {
                        LabelNoDataYetSessions.Hide();
                        TLPGlobalSessions.Controls.Remove(LabelNoDataYetSessions);
                    }
                }
            }
        }
       
        Chart chartIncomePerService;
        private void SetupChartIncomePerService()
        {
            chartIncomePerService = new Chart();
            chartIncomePerService.BackColor = Color.Transparent;
            chartIncomePerService.BorderSkin.BackColor = Color.FromArgb(196, 210, 245);

            ChartArea chartArea7 = new ChartArea();
            chartArea7.AxisX.Enabled = AxisEnabled.True;
            chartArea7.AxisX.LabelStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            chartArea7.AxisX.MajorGrid.Enabled = false;
            chartArea7.AxisX.MajorTickMark.Enabled = false;
            chartArea7.AxisY.ArrowStyle = AxisArrowStyle.Lines;
            chartArea7.AxisY.Enabled = AxisEnabled.False;
            chartArea7.AxisY.IsLabelAutoFit = false;
            chartArea7.AxisY.LabelStyle.Font = new Font("Segoe UI", 9.75F);
            chartArea7.AxisY.MajorGrid.Enabled = false;
            chartArea7.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea7.AxisY.TitleFont = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            chartArea7.AxisY2.ArrowStyle = AxisArrowStyle.Lines;
            chartArea7.AxisY2.Enabled = AxisEnabled.False;
            chartArea7.AxisY2.IsLabelAutoFit = false;
            chartArea7.AxisY2.LabelStyle.Font = new Font("Segoe UI", 9.75F);
            chartArea7.AxisY2.MajorGrid.Enabled = false;
            chartArea7.BackColor = Color.Transparent;
            chartArea7.BackSecondaryColor = Color.Transparent;
            chartArea7.InnerPlotPosition.Auto = false;
            chartArea7.InnerPlotPosition.Height = 90F;
            chartArea7.InnerPlotPosition.Width = 90F;
            chartArea7.InnerPlotPosition.X = 5F;
            chartArea7.Name = "ChartArea1";
            chartArea7.Position.Auto = false;
            chartArea7.Position.Height = 75F;
            chartArea7.Position.Width = 100F;
            chartArea7.Position.Y = 20F;

            chartIncomePerService.ChartAreas.Add(chartArea7);
            chartIncomePerService.Dock = DockStyle.Fill;

            Legend legend3 = new Legend();
            legend3.Name = "Legend3";
            chartIncomePerService.Legends.Add(legend3);

            chartIncomePerService.Location = new Point(156, 3);
            chartIncomePerService.Name = "chartIncomePerService";

            Series series9 = new Series();
            series9.ChartArea = "ChartArea1";
            series9.Color = Color.FromArgb(109, 122, 224);
            series9.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            series9.IsValueShownAsLabel = true;
            series9.Label = "#VAL{C1}";
            series9.LabelBackColor = Color.WhiteSmoke;
            series9.LabelForeColor = Color.FromArgb(114, 189, 57);
            series9.Legend = "Legend3";
            series9.LegendText = "Income";
            series9.Name = "SeriesIncome";
            series9.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            series9.SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Top | LabelAlignmentStyles.TopRight | LabelAlignmentStyles.BottomLeft | LabelAlignmentStyles.BottomRight;

            Series series10 = new Series();
            series10.ChartArea = "ChartArea1";
            series10.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            series10.IsValueShownAsLabel = true;
            series10.LabelBackColor = Color.WhiteSmoke;
            series10.Legend = "Legend3";
            series10.LegendText = "Quantity";
            series10.Name = "SeriesQty";
            series10.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            series10.SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Top | LabelAlignmentStyles.TopLeft | LabelAlignmentStyles.TopRight | LabelAlignmentStyles.BottomLeft | LabelAlignmentStyles.BottomRight;
            series10.YAxisType = AxisType.Secondary;

            chartIncomePerService.Series.Add(series9);
            chartIncomePerService.Series.Add(series10);

            chartIncomePerService.Size = new Size(1050, 214);
            chartIncomePerService.TabIndex = 35;
            chartIncomePerService.Text = "chart1";
           
            TLPGLobalIncom.Controls.Add(chartIncomePerService, 1, 0);
        }   
        Chart chartIncomePerTime;
        private void SetupChartIncomePerTime()
        {
            chartIncomePerTime = new Chart();
            chartIncomePerTime.BackColor = Color.Transparent;

            ChartArea chartArea8 = new ChartArea();
            chartArea8.AxisX.ArrowStyle = AxisArrowStyle.Lines;
            chartArea8.AxisX.IsLabelAutoFit = false;
            chartArea8.AxisX.LabelStyle.Font = new Font("Segoe UI", 11.25F);
            chartArea8.AxisX.MajorGrid.Enabled = false;
            chartArea8.AxisX.MajorGrid.LineColor = Color.Empty;
            chartArea8.AxisX.MinorGrid.Enabled = false;
            chartArea8.AxisX.MinorGrid.LineColor = Color.WhiteSmoke;
            chartArea8.AxisX.TitleAlignment = StringAlignment.Far;
            chartArea8.AxisX.TitleFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            chartArea8.AxisY.ArrowStyle = AxisArrowStyle.Lines;
            chartArea8.AxisY.IsLabelAutoFit = false;
            chartArea8.AxisY.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            chartArea8.AxisY.MajorGrid.Enabled = false;
            chartArea8.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea8.AxisY.TitleFont = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            chartArea8.AxisY2.ArrowStyle = AxisArrowStyle.Lines;
            chartArea8.BackColor = Color.Transparent;
            chartArea8.InnerPlotPosition.Auto = false;
            chartArea8.InnerPlotPosition.Height = 85F;
            chartArea8.InnerPlotPosition.Width = 90F;
            chartArea8.InnerPlotPosition.X = 5F;
            chartArea8.Name = "ChartArea1";
            chartArea8.Position.Auto = false;
            chartArea8.Position.Height = 83F;
            chartArea8.Position.Width = 100F;
            chartArea8.Position.Y = 11F;

            chartIncomePerTime.ChartAreas.Add(chartArea8);
            chartIncomePerTime.Dock = DockStyle.Fill;
            chartIncomePerTime.Location = new Point(156, 223);
            chartIncomePerTime.Name = "chartIncomePerTime";

            Series series11 = new Series();
            series11.BorderColor = Color.White;
            series11.BorderWidth = 2;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = SeriesChartType.Line;
            series11.Color = Color.FromArgb(109, 122, 224);
            series11.CustomProperties = "LabelStyle=Top";
            series11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            series11.LabelBackColor = Color.WhiteSmoke;
            series11.LabelForeColor = Color.FromArgb(114, 189, 57);
            series11.MarkerColor = Color.FromArgb(109, 122, 224);
            series11.MarkerSize = 7;
            series11.MarkerStyle = MarkerStyle.Circle;
            series11.Name = "Series1";
            series11.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;
            series11.SmartLabelStyle.CalloutBackColor = Color.Empty;
            series11.SmartLabelStyle.CalloutLineColor = Color.FromArgb(109, 122, 224);
            series11.SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Top | LabelAlignmentStyles.TopRight | LabelAlignmentStyles.BottomLeft | LabelAlignmentStyles.BottomRight;

            chartIncomePerTime.Series.Add(series11);

            chartIncomePerTime.Size = new Size(1050, 237);
            chartIncomePerTime.TabIndex = 38;
            chartIncomePerTime.Text = "chart1";

            TLPGLobalIncom.Controls.Add(chartIncomePerTime, 1, 1);
        }
        Chart chartSessions;
        private void SetupChartSessions()
        {
            chartSessions = new Chart();
            // Initialize the chart
            chartSessions.BackColor = Color.Transparent;

            ChartArea chartArea9 = new ChartArea();
            chartArea9.AxisX.ArrowStyle = AxisArrowStyle.Lines;
            chartArea9.AxisX.LabelStyle.Font = new Font("Segoe UI", 11.25F);
            chartArea9.AxisX.MajorGrid.Enabled = false;
            chartArea9.AxisX.MajorGrid.LineColor = Color.WhiteSmoke;
            chartArea9.AxisX.MinorGrid.Enabled = false;
            chartArea9.AxisX.MinorGrid.LineColor = Color.WhiteSmoke;
            chartArea9.AxisX.TitleAlignment = StringAlignment.Far;
            chartArea9.AxisX.TitleFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            chartArea9.AxisY.ArrowStyle = AxisArrowStyle.Lines;
            chartArea9.AxisY.IsLabelAutoFit = false;
            chartArea9.AxisY.LabelStyle.Font = new Font("Segoe UI", 9.75F);
            chartArea9.AxisY.MajorGrid.Enabled = false;
            chartArea9.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea9.AxisY.TitleFont = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            chartArea9.BackColor = Color.Transparent;
            chartArea9.InnerPlotPosition.Auto = false;
            chartArea9.InnerPlotPosition.Height = 85F;
            chartArea9.InnerPlotPosition.Width = 90F;
            chartArea9.InnerPlotPosition.X = 5F;
            chartArea9.Name = "ChartArea1";
            chartArea9.Position.Auto = false;
            chartArea9.Position.Height = 83F;
            chartArea9.Position.Width = 100F;
            chartArea9.Position.Y = 11F;

            chartSessions.ChartAreas.Add(chartArea9);
            chartSessions.Dock = DockStyle.Fill;
            chartSessions.Location = new Point(156, 3);
            chartSessions.Name = "chartSessions";

            Series series12 = new Series();
            series12.BorderColor = Color.White;
            series12.BorderWidth = 2;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = SeriesChartType.Line;
            series12.Color = Color.FromArgb(109, 122, 224);
            series12.CustomProperties = "LabelStyle=Top";
            series12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            series12.LabelBackColor = Color.WhiteSmoke;
            series12.LabelForeColor = Color.FromArgb(114, 189, 57);
            series12.MarkerColor = Color.FromArgb(109, 122, 224);
            series12.MarkerSize = 7;
            series12.MarkerStyle = MarkerStyle.Circle;
            series12.Name = "Series1";
            series12.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;
            series12.SmartLabelStyle.CalloutBackColor = Color.Empty;
            series12.SmartLabelStyle.CalloutLineColor = Color.FromArgb(109, 122, 224);
            series12.SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Top | LabelAlignmentStyles.TopRight | LabelAlignmentStyles.BottomLeft | LabelAlignmentStyles.BottomRight;

            chartSessions.Series.Add(series12);

            chartSessions.Size = new Size(1050, 255);
            chartSessions.TabIndex = 39;
            chartSessions.Text = "chart1";

            TLPGlobalSessions.Controls.Add(chartSessions, 1, 0);
        }

        public void Formatcharts()
        {

            chartIncomePerService.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Regular);
            chartIncomePerService.Series["SeriesIncome"].Label = Currency.Symbol + "#VAL{N1}";//rounding to one decimal
            chartIncomePerService.Series["SeriesQty"].Label = "#VAL{}";//rounding to one decimal
            chartIncomePerService.Series["SeriesIncome"]["PointWidth"] = "0.7";
            chartIncomePerService.Series["SeriesQty"]["PointWidth"] = "0.7";


            chartIncomePerTime.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
            chartIncomePerTime.ChartAreas[0].AxisX.Interval = 1;

            chartSessions.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
            chartSessions.ChartAreas[0].AxisX.Interval = 1;
        }
        public void CreateFilters()
        {
            ///
            UCComboFilterDateSessions = new UCComboFilterStat();
            UCComboFilterDateSessions.StatisticsForm = this;
            UCComboFilterDateSessions.FilterType = UCComboFilterStat.FiltersType.DateSessions;
            UCComboFilterDateSessions.Title = "Date";
            UCComboFilterDateSessions.Dock = DockStyle.Top;
            panelSessionsFilter.Controls.Add(UCComboFilterDateSessions);


            UCComboFilterServiceIncome = new UCComboFilterStat();
            UCComboFilterServiceIncome.StatisticsForm = this;

            UCComboFilterServiceIncome.FilterType = UCComboFilterStat.FiltersType.ServiceIncome;
            UCComboFilterServiceIncome.Title = "Category Type";
            UCComboFilterServiceIncome.Dock = DockStyle.Top;
            UCComboFilterServiceIncome.BringToFront();
            panelIncomeFilter.Controls.Add(UCComboFilterServiceIncome);
            UCComboFilterServiceIncome.BringToFront();



            //sessions
            UCComboFilterDateIncome = new UCComboFilterStat();
            UCComboFilterDateIncome.StatisticsForm = this;
            UCComboFilterDateIncome.FilterType = UCComboFilterStat.FiltersType.DateIncome;
            UCComboFilterDateIncome.Title = "Date";
            UCComboFilterDateIncome.Dock = DockStyle.Top;
            panelIncomeFilter.Controls.Add(UCComboFilterDateIncome);

        }
        public void CreateUCCustomeDateIncome()
        {
            String SelectedString = UCComboFilterDateIncome.comboBoxDetail.SelectedItem.ToString();
            if (SelectedString == UCComboFilterStat.ChooseMonth || SelectedString == UCComboFilterStat.ChooseYear)
            {
                if (UCCustomeDateIncome == null || UCCustomeDateIncome.IsDisposed)
                {
                    UCCustomeDateIncome = new UCLabelFilterStatistics(UCLabelFilterStatistics.FiltersCategories.Income);
                    UCCustomeDateIncome.StatisticsForm = this;
                    UCCustomeDateIncome.Visible = false;
                    UCCustomeDateIncome.Dock = DockStyle.Top;
                    panelIncomeFilter.Controls.Add(UCCustomeDateIncome);
                    int indexFather = panelIncomeFilter.Controls.GetChildIndex(UCComboFilterDateIncome);
                    panelIncomeFilter.Controls.SetChildIndex(UCCustomeDateIncome, indexFather);
                    UCCustomeDateIncome.Startdate = DateOfFilterIncome;

                }
                if (SelectedString == UCComboFilterStat.ChooseMonth)
                {
                    UCCustomeDateIncome.Title = "Month";

                    UCCustomeDateIncome.Show();
                    UCCustomeDateIncome.PerformLayout();//kermel tekhud el width tabaa el docktop
                    UCCustomeDateIncome.Detail = DateOfFilterIncome.ToString("MMMM") + " " + DateOfFilterIncome.ToString("yyyy");//default value


                    OpenDateMonthForm(UCCustomeDateIncome, DateOfFilterIncome);
                }
                else if (SelectedString == UCComboFilterStat.ChooseYear)
                {
                    UCCustomeDateIncome.Title = "Year";


                    UCCustomeDateIncome.Show();
                    UCCustomeDateIncome.PerformLayout();
                    UCCustomeDateIncome.Detail = DateOfFilterIncome.ToString("yyyy");


                    OpenDateYearForm(UCCustomeDateIncome, DateOfFilterIncome);
                }

            }

            else
            {
                if (UCCustomeDateIncome != null)
                {
                    UCCustomeDateIncome.Dispose();
                }
                FilterDatatbleIncome();//in case kenit gher custom date taamil filter
            }

        }
        public void CreateUCCustomeDateSessions()
        {
            String SelectedString = UCComboFilterDateSessions.comboBoxDetail.SelectedItem.ToString();
            if (SelectedString == UCComboFilterStat.ChooseMonth || SelectedString == UCComboFilterStat.ChooseYear)
            {
                if (UCCustomeDateSessions == null || UCCustomeDateSessions.IsDisposed)
                {
                    UCCustomeDateSessions = new UCLabelFilterStatistics(UCLabelFilterStatistics.FiltersCategories.Sessions);
                    UCCustomeDateSessions.StatisticsForm = this;
                    UCCustomeDateSessions.Visible = false;
                    UCCustomeDateSessions.Dock = DockStyle.Top;
                    panelSessionsFilter.Controls.Add(UCCustomeDateSessions);
                    int indexFather = panelSessionsFilter.Controls.GetChildIndex(UCComboFilterDateSessions);
                    panelSessionsFilter.Controls.SetChildIndex(UCCustomeDateSessions, indexFather);

                }

                if (SelectedString == UCComboFilterStat.ChooseMonth)
                {
                    UCCustomeDateSessions.Title = "Month";

                    UCCustomeDateSessions.Show();
                    UCCustomeDateSessions.PerformLayout();
                    UCCustomeDateSessions.Detail = DateOfFilterSessions.ToString("MMMM") + " " + DateOfFilterSessions.ToString("yyyy");//default value, on textchnage tabaa el label byaamil filter

                    OpenDateMonthForm(UCCustomeDateSessions, DateOfFilterSessions);
                }
                else if (SelectedString == UCComboFilterStat.ChooseYear)
                {
                    UCCustomeDateSessions.Title = "Year";
                    UCCustomeDateSessions.Show();
                    UCCustomeDateSessions.PerformLayout();
                    UCCustomeDateSessions.Detail = DateOfFilterSessions.ToString("yyyy");

                    OpenDateYearForm(UCCustomeDateSessions, DateOfFilterSessions);
                }

            }
            else
            {
                if (UCCustomeDateSessions != null)
                {
                    UCCustomeDateSessions.Dispose();
                }
                FilterDatatbleSessions();//in case kenit gher custom date taamil filter
            }
        }


        public void FilterDatatbleIncome()
        {
            DataTable FilteredDt = OriginalAllServicesIncomeDt.Copy();
            if (UCComboFilterServiceIncome != null && UCComboFilterDateIncome != null)
            {
                string selectedString1 = UCComboFilterServiceIncome.comboBoxDetail.SelectedItem.ToString();
                if (selectedString1 != UCComboFilterStat.All)
                {
                    FilteredDt = FiltersDataTable.FilterDatatableIFStringEquality("Category Type", selectedString1, FilteredDt);
                }



                DateTime currentDate = DateTime.Now;
                string selectedString3 = UCComboFilterDateIncome.comboBoxDetail.SelectedItem.ToString();

                if (selectedString3 == UCComboFilterStat.ThisMonth)
                {
                    OutputChartIncomePerDay(FilteredDt, DateTime.Now);
                    // This month
                    DateTime thisMonthStartDate = new DateTime(currentDate.Year, currentDate.Month, 1);
                    DateTime thisMonthEndDate = thisMonthStartDate.AddMonths(1).AddSeconds(-1);
                    OutputChartIncomePerService(FiltersDataTable.FilterDatatableDateCustomDate("Payment Date", FilteredDt, thisMonthStartDate, thisMonthEndDate));
                }
                else if (selectedString3 == UCComboFilterStat.LastMonth)
                {
                    // Last month
                    DateTime thisMonthStartDate = new DateTime(currentDate.Year, currentDate.Month, 1);
                    DateTime lastMonthStartDate = thisMonthStartDate.AddMonths(-1);
                    DateTime lastMonthEndDate = thisMonthStartDate.AddSeconds(-1);

                    OutputChartIncomePerDay(FilteredDt, lastMonthEndDate);
                    OutputChartIncomePerService(FiltersDataTable.FilterDatatableDateCustomDate("Payment Date", FilteredDt, lastMonthStartDate, lastMonthEndDate));
                }
                else if (selectedString3 == UCComboFilterStat.ThisYear)
                {
                    OutputChartIncomePerMonth(FilteredDt, DateTime.Now);

                    DateTime thisYearStartDate = new DateTime(currentDate.Year, 1, 1);
                    DateTime thisYearEndDate = new DateTime(currentDate.Year + 1, 1, 1).AddSeconds(-1);
                    OutputChartIncomePerService(FiltersDataTable.FilterDatatableDateCustomDate("Payment Date", FilteredDt, thisYearStartDate, thisYearEndDate));
                }
                else if (selectedString3 == UCComboFilterStat.LastYear)
                {
                    // Last year
                    DateTime lastYearStartDate = new DateTime(currentDate.Year - 1, 1, 1);
                    DateTime lastYearEndDate = new DateTime(currentDate.Year, 1, 1).AddSeconds(-1);
                    OutputChartIncomePerMonth(FilteredDt, lastYearEndDate);
                    OutputChartIncomePerService(FiltersDataTable.FilterDatatableDateCustomDate("Payment Date", FilteredDt, lastYearStartDate, lastYearEndDate));
                }

                else if (selectedString3 == UCComboFilterStat.AllYears)
                {

                    OutputChartIncomePerYear(FilteredDt);
                    OutputChartIncomePerService(FilteredDt);
                }
                else if (selectedString3 == UCComboFilterStat.ChooseMonth)
                {
                    if (UCCustomeDateIncome.Startdate != null && UCCustomeDateIncome.Enddate != null)
                    {

                        OutputChartIncomePerDay(FilteredDt, (DateTime)UCCustomeDateIncome.Startdate);
                        OutputChartIncomePerService(FiltersDataTable.FilterDatatableDateCustomDate("Payment Date", FilteredDt, (DateTime)UCCustomeDateIncome.Startdate, (DateTime)UCCustomeDateIncome.Enddate));

                    }
                }
                else if (selectedString3 == UCComboFilterStat.ChooseYear)
                {
                    if (UCCustomeDateIncome.Startdate != null && UCCustomeDateIncome.Enddate != null)
                    {
                        OutputChartIncomePerMonth(FilteredDt, (DateTime)UCCustomeDateIncome.Startdate);
                        OutputChartIncomePerService(FiltersDataTable.FilterDatatableDateCustomDate("Payment Date", FilteredDt, (DateTime)UCCustomeDateIncome.Startdate, (DateTime)UCCustomeDateIncome.Enddate));
                    }
                }
            }
        }
        public void FilterDatatbleSessions()
        {

            if (UCComboFilterDateSessions != null)
            {
                DateTime currentDate = DateTime.Now;
                string selectedString = UCComboFilterDateSessions.comboBoxDetail.SelectedItem.ToString();
                if (selectedString == UCComboFilterStat.ThisMonth)
                {
                    OutputSessionPerDay(OriginalSessionsDt, DateTime.Now);
                }
                else if (selectedString == UCComboFilterStat.LastMonth)
                {
                    // Last month
                    DateTime thisMonthStartDate = new DateTime(currentDate.Year, currentDate.Month, 1);
                    DateTime lastMonthStartDate = thisMonthStartDate.AddMonths(-1);
                    DateTime lastMonthEndDate = thisMonthStartDate.AddSeconds(-1);
                    OutputSessionPerDay(OriginalSessionsDt, lastMonthEndDate);

                }

                else if (selectedString == UCComboFilterStat.ThisYear)
                {
                    OutputSessionPerMonth(OriginalSessionsDt, DateTime.Now);
                }
                else if (selectedString == UCComboFilterStat.LastYear)
                {
                    // Last year
                    DateTime lastYearStartDate = new DateTime(currentDate.Year - 1, 1, 1);
                    DateTime lastYearEndDate = new DateTime(currentDate.Year, 1, 1).AddSeconds(-1);
                    OutputSessionPerMonth(OriginalSessionsDt, lastYearEndDate);

                }

                else if (selectedString == UCComboFilterStat.AllYears)
                {

                    OutputSessionPerYear(OriginalSessionsDt);
                }
                else if (selectedString == UCComboFilterStat.ChooseMonth)
                {
                    if (UCCustomeDateSessions.Startdate != null && UCCustomeDateSessions.Enddate != null)
                    {
                        OutputSessionPerDay(OriginalSessionsDt, (DateTime)UCCustomeDateSessions.Startdate);
                    }
                }
                else if (selectedString == UCComboFilterStat.ChooseYear)
                {
                    if (UCCustomeDateSessions.Startdate != null && UCCustomeDateSessions.Enddate != null)
                    {
                        OutputSessionPerMonth(OriginalSessionsDt, (DateTime)UCCustomeDateSessions.Startdate);

                    }
                }
            }
        }
        public void SplitServices(DataTable OriginalIncomDt)
        {
            // Create a new DataTable to hold all the data

            OriginalAllServicesIncomeDt = new DataTable();
            // Define columns for the AllServicesDt
            OriginalAllServicesIncomeDt.Columns.Add("Category Type", typeof(String));
            OriginalAllServicesIncomeDt.Columns.Add("Category Id", typeof(int));
            OriginalAllServicesIncomeDt.Columns.Add("ClientBalance Id", typeof(int));
            OriginalAllServicesIncomeDt.Columns.Add("Amount Paid", typeof(double));
            OriginalAllServicesIncomeDt.Columns.Add("Payment Date", typeof(DateTime));


            // Retrieve and merge the desired columns from FilteredbundleDt
            foreach (DataRow row in OriginalIncomDt.Rows)
            {


                double AmountPaid = (double)row["amount_paid"];
                DateTime Date = (DateTime)row["payment_date"]; // Replace with the actual column name

                int CategoryId;
                string Item;
                if (row["bundle_id"] != DBNull.Value)
                {
                    CategoryId = (int)row["bundle_id"];
                    Item = UCComboFilterStat.Services;
                }
                else
                {
                    CategoryId = (int)row["product_id"];
                    Item = UCComboFilterStat.Products;
                }




                int ClientBalanceId = (int)row["client_balance_id"];
                OriginalAllServicesIncomeDt.Rows.Add(Item, CategoryId, ClientBalanceId, AmountPaid, Date);



            }






        }



        public void OutputChartIncomePerService(DataTable FilteredAllServicesIncomeDt)
        {

            List<Chart> charts = new List<Chart> { chartIncomePerService, chartIncomePerTime };//kermel el el mode

            //
            chartIncomePerService.Series["SeriesIncome"].Points.Clear();
            chartIncomePerService.Series["SeriesQty"].Points.Clear();
            chartIncomePerService.ChartAreas[0].AxisX.CustomLabels.Clear();
            if (FilteredAllServicesIncomeDt.Rows.Count > 0)
            {
                SetNoDateLabel(true, true, charts);

                if (UCComboFilterServiceIncome == null || UCComboFilterServiceIncome.comboBoxDetail.SelectedItem.ToString() == UCComboFilterStat.All)
                {

                    var groupedByClientBalanceId = FilteredAllServicesIncomeDt.AsEnumerable()
                     .GroupBy(row => row.Field<int>("ClientBalance Id"))
                     .Select(group => new
                     {
                         ClientBalanceId = group.Key,
                         TotalAmountPaid = group.Sum(row => row.Field<double>("Amount Paid")),
                         CategoryType = group.First().Field<string>("Category Type"), // Get the first value of "NO reps"
                         ClientBalanceIdReps = 1
                     });


                    DataTable resultTable = new DataTable();

                    resultTable.Columns.Add("Category Type", typeof(string));
                    resultTable.Columns.Add("ClientBalance Id", typeof(int));
                    resultTable.Columns.Add("Amount Paid", typeof(double));
                    resultTable.Columns.Add("ClientBalanceIdReps", typeof(int));

                    foreach (var group in groupedByClientBalanceId)
                    {
                        DataRow newRow = resultTable.NewRow();
                        newRow["Category Type"] = group.CategoryType;
                        newRow["ClientBalance Id"] = group.ClientBalanceId;
                        newRow["Amount Paid"] = group.TotalAmountPaid;
                        newRow["ClientBalanceIdReps"] = group.ClientBalanceIdReps;

                        //newRow["Amount Paid"] = group.NoOfSectionRepition;
                        resultTable.Rows.Add(newRow);
                    }

                    var groupedByCategoryId = resultTable.AsEnumerable()
                     .GroupBy(row => row.Field<string>("Category Type"))
                     .Select(group => new
                     {
                         CategoryType = group.Key,
                         TotalAmountPaid = group.Sum(row => row.Field<double>("Amount Paid")),
                         ClientBalanceIdReps = group.Sum(row => row.Field<int>("ClientBalanceIdReps"))
                     });



                    int i = 1;
                    foreach (var group in groupedByCategoryId)
                    {
                        string CategoryType = group.CategoryType;
                        double totalAmountPaid = group.TotalAmountPaid;
                        int CategoryQty = group.ClientBalanceIdReps;


                        chartIncomePerService.Series["SeriesIncome"].Points.AddXY(i, totalAmountPaid);
                        chartIncomePerService.Series["SeriesQty"].Points.AddXY(i, CategoryQty);
                        chartIncomePerService.ChartAreas[0].AxisX.CustomLabels.Add(i - 1, i + 1, CategoryType);

                        i += 2;
                    }



                }
                else if (UCComboFilterServiceIncome.comboBoxDetail.SelectedItem.ToString() == UCComboFilterStat.Services)
                {
                    var groupedByClientBalanceId = FilteredAllServicesIncomeDt.AsEnumerable()
                      .Where(row => row.Field<string>("Category Type") == UCComboFilterStat.Services)
                     .GroupBy(row => row.Field<int>("ClientBalance Id"))
                     .Select(group => new
                     {
                         ClientBalanceId = group.Key,
                         TotalAmountPaid = group.Sum(row => row.Field<double>("Amount Paid")),
                         CategoryId = group.First().Field<int>("Category Id"), // Get the first value of "NO reps"
                         ClientBalanceIdReps = 1
                     });


                    DataTable resultTable = new DataTable();

                    resultTable.Columns.Add("Category Id", typeof(int));
                    resultTable.Columns.Add("ClientBalance Id", typeof(int));
                    resultTable.Columns.Add("Amount Paid", typeof(double));
                    resultTable.Columns.Add("ClientBalanceIdReps", typeof(int));

                    foreach (var group in groupedByClientBalanceId)
                    {
                        DataRow newRow = resultTable.NewRow();
                        newRow["Category Id"] = group.CategoryId;
                        newRow["ClientBalance Id"] = group.ClientBalanceId;
                        newRow["Amount Paid"] = group.TotalAmountPaid;
                        newRow["ClientBalanceIdReps"] = group.ClientBalanceIdReps;

                        //newRow["Amount Paid"] = group.NoOfSectionRepition;
                        resultTable.Rows.Add(newRow);
                    }

                    var groupedByCategoryId = resultTable.AsEnumerable()
                     .GroupBy(row => row.Field<int>("Category Id"))
                     .Select(group => new
                     {
                         CategoryId = group.Key,
                         TotalAmountPaid = group.Sum(row => row.Field<double>("Amount Paid")),
                         ClientBalanceIdReps = group.Sum(row => row.Field<int>("ClientBalanceIdReps"))
                     });


                    int i = 1;
                    foreach (var group in groupedByCategoryId)
                    {
                        int serviceId = group.CategoryId;
                        double totalAmountPaid = group.TotalAmountPaid;
                        int CategoryQty = group.ClientBalanceIdReps;
                        string BundleName = ClassBundles.FindBundleName(serviceId);

                        chartIncomePerService.Series["SeriesIncome"].Points.AddXY(i, totalAmountPaid);
                        chartIncomePerService.Series["SeriesQty"].Points.AddXY(i, CategoryQty);
                        chartIncomePerService.ChartAreas[0].AxisX.CustomLabels.Add(i - 1, i + 1, BundleName);

                        i += 2;
                    }
                }
                else if (UCComboFilterServiceIncome.comboBoxDetail.SelectedItem.ToString() == UCComboFilterStat.Products)
                {

                    var groupedByClientBalanceId = FilteredAllServicesIncomeDt.AsEnumerable()
                      .Where(row => row.Field<string>("Category Type") == UCComboFilterStat.Products)
                     .GroupBy(row => row.Field<int>("ClientBalance Id"))
                     .Select(group => new
                     {
                         ClientBalanceId = group.Key,
                         TotalAmountPaid = group.Sum(row => row.Field<double>("Amount Paid")),
                         CategoryId = group.First().Field<int>("Category Id"), // Get the first value of "NO reps"
                         ClientBalanceIdReps = 1
                     });


                    DataTable resultTable = new DataTable();

                    resultTable.Columns.Add("Category Id", typeof(int));
                    resultTable.Columns.Add("ClientBalance Id", typeof(int));
                    resultTable.Columns.Add("Amount Paid", typeof(double));
                    resultTable.Columns.Add("ClientBalanceIdReps", typeof(int));

                    foreach (var group in groupedByClientBalanceId)
                    {
                        DataRow newRow = resultTable.NewRow();
                        newRow["Category Id"] = group.CategoryId;
                        newRow["ClientBalance Id"] = group.ClientBalanceId;
                        newRow["Amount Paid"] = group.TotalAmountPaid;
                        newRow["ClientBalanceIdReps"] = group.ClientBalanceIdReps;

                        //newRow["Amount Paid"] = group.NoOfSectionRepition;
                        resultTable.Rows.Add(newRow);
                    }

                    var groupedByCategoryId = resultTable.AsEnumerable()
                     .GroupBy(row => row.Field<int>("Category Id"))
                     .Select(group => new
                     {
                         CategoryId = group.Key,
                         TotalAmountPaid = group.Sum(row => row.Field<double>("Amount Paid")),
                         ClientBalanceIdReps = group.Sum(row => row.Field<int>("ClientBalanceIdReps"))
                     });


                    int i = 1;
                    foreach (var group in groupedByCategoryId)
                    {
                        int serviceId = group.CategoryId;
                        double totalAmountPaid = group.TotalAmountPaid;
                        string ProductName = ClassProduct.FindProductName(serviceId);
                        int CategoryQty = group.ClientBalanceIdReps;

                        chartIncomePerService.Series["SeriesIncome"].Points.AddXY(i, totalAmountPaid);
                        chartIncomePerService.Series["SeriesQty"].Points.AddXY(i, CategoryQty);
                        chartIncomePerService.ChartAreas[0].AxisX.CustomLabels.Add(i - 1, i + 1, ProductName);

                        i++;

                    }
                }

            }
            else
            {
                SetNoDateLabel(true, false, charts);
            }



        }



        public void OutputChartIncomePerDay(DataTable FilteredAllServicesIncomeDt, DateTime DesiredDate)
        {
            //hone ma eemlna format la kell el labels metel tahet, or eemelneha , label by label that are different then 0
            chartIncomePerTime.Series["Series1"].Label = "";//reset
            //
            DateOfFilterIncome = DesiredDate;
            //
            IEnumerable<int> allDays;
            if (DesiredDate.Month == DateTime.Now.Month)
            {
                allDays = Enumerable.Range(1, DateTime.Now.Day);
            }
            else
            {
                allDays = Enumerable.Range(1, DateTime.DaysInMonth(DesiredDate.Year, DesiredDate.Month));//eza ken gher tabaa hayda el month since hayda el month bas bi hemna nfarje till this day adde sorna mtaliin
            }



            // Group and aggregate the data from AllServicesDt by day of the last month
            var groupedData = from row in FilteredAllServicesIncomeDt.AsEnumerable()
                              where row.Field<DateTime>("Payment Date").Year == DesiredDate.Year &&
                                    row.Field<DateTime>("Payment Date").Month == DesiredDate.Month
                              group row by row.Field<DateTime>("Payment Date").Day into g
                              orderby g.Key
                              select new
                              {
                                  Day = g.Key,
                                  TotalAmountPaid = g.Sum(r => r.Field<double>("Amount Paid"))
                              };


            var joinedData = from day in allDays
                             join groupData in groupedData on day equals groupData.Day into dayGroup
                             from groupData in dayGroup.DefaultIfEmpty()
                             select new
                             {
                                 Day = day,
                                 TotalAmountPaid = groupData?.TotalAmountPaid ?? 0
                             };

            chartIncomePerTime.Series["Series1"].Points.Clear();
            chartIncomePerTime.ChartAreas[0].AxisX.CustomLabels.Clear();
            chartIncomePerTime.ChartAreas[0].AxisX.StripLines.Clear();

            double TotalIncome = 0;
            string[] dayAbbreviations = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };


            // Populate the joinedDataTable with the grouped data
            int index = 0;
            foreach (var group in joinedData)
            {
                TotalIncome += group.TotalAmountPaid;



                chartIncomePerTime.Series["Series1"].Points.AddXY(group.Day, group.TotalAmountPaid);




                var dayOfWeek = new DateTime(DesiredDate.Year, DesiredDate.Month, group.Day).DayOfWeek;
                var dayNameAbbreviation = dayAbbreviations[(int)dayOfWeek]; // Get day abbreviation
                chartIncomePerTime.ChartAreas[0].AxisX.CustomLabels.Add(group.Day - 0.5, group.Day + 0.5, dayNameAbbreviation + "\n" + group.Day.ToString());


                //kermel el x axis labels
                if (group.TotalAmountPaid > 0)
                {
                    chartIncomePerTime.Series["Series1"].Points[index].Label = Currency.Symbol + "#VAL{N1}";
                    chartIncomePerTime.Series["Series1"].Points[index].IsValueShownAsLabel = true;


                    // Create a StripLine for the specific gridline
                    CreateStripLine(index + 1, chartIncomePerTime);



                }
                else
                {
                    chartIncomePerTime.Series["Series1"].Points[index].IsValueShownAsLabel = false;
                }
                index++;
            }
            labelTotalIncome.Text = Currency.Symbol + TotalIncome.ToString("N1");
        }
        public void OutputChartIncomePerMonth(DataTable FilteredAllServicesIncomeDt, DateTime DesiredDate)
        {

            //
            DateOfFilterIncome = DesiredDate;
            //
            IEnumerable<int> allMonths;
            if (DesiredDate.Year == DateTime.Now.Year)
            {
                allMonths = Enumerable.Range(1, DateTime.Now.Month);
            }
            else
            {
                allMonths = Enumerable.Range(1, 12);
            }

            // Group and aggregate the data from FilteredAllServicesIncomeDt by month of the current year
            var groupedData = from row in FilteredAllServicesIncomeDt.AsEnumerable()
                              where row.Field<DateTime>("Payment Date").Year == DesiredDate.Year
                              group row by row.Field<DateTime>("Payment Date").Month into g
                              orderby g.Key
                              select new
                              {
                                  Month = g.Key,
                                  TotalAmountPaid = g.Sum(r => r.Field<double>("Amount Paid"))
                              };


            // Join the grouped data with all months to fill in missing months
            var joinedData = from month in allMonths
                             join groupData in groupedData on month equals groupData.Month into monthGroup
                             from groupData in monthGroup.DefaultIfEmpty()
                             select new
                             {
                                 Month = month,
                                 TotalAmountPaid = groupData?.TotalAmountPaid ?? 0
                             };




            chartIncomePerTime.Series["Series1"].Points.Clear();
            chartIncomePerTime.ChartAreas[0].AxisX.CustomLabels.Clear();
            chartIncomePerTime.ChartAreas[0].AxisX.StripLines.Clear();

            double TotalIncome = 0;
            int index = 1;
            foreach (var data in joinedData)
            {



                chartIncomePerTime.Series["Series1"].Points.AddXY(data.Month, data.TotalAmountPaid);
                TotalIncome += data.TotalAmountPaid;

                var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(data.Month);
                chartIncomePerTime.ChartAreas[0].AxisX.CustomLabels.Add(data.Month - 0.5, data.Month + 0.5, monthName);

                if (data.TotalAmountPaid > 0)
                {
                    CreateStripLine(index, chartIncomePerTime);

                }
                index++;
            }

            chartIncomePerTime.Series["Series1"].Label = Currency.Symbol + "#VAL{N1}";
            labelTotalIncome.Text = Currency.Symbol + TotalIncome.ToString("N1");
        }
        public void OutputChartIncomePerYear(DataTable FilteredAllServicesIncomeDt)
        {
            //
            DateOfFilterIncome = DateTime.Now;
            // Get distinct years from your DataTable
            var distinctYears = FilteredAllServicesIncomeDt.AsEnumerable()
                                 .Select(row => row.Field<DateTime>("Payment Date").Year)
                                 .Distinct();

            // Group and aggregate the data from FilteredAllServicesIncomeDt by year
            var groupedData = from row in FilteredAllServicesIncomeDt.AsEnumerable()
                              group row by row.Field<DateTime>("Payment Date").Year into g
                              orderby g.Key
                              select new
                              {
                                  Year = g.Key,
                                  TotalAmountPaid = g.Sum(r => r.Field<double>("Amount Paid"))
                              };




            chartIncomePerTime.Series["Series1"].Points.Clear();
            chartIncomePerTime.ChartAreas[0].AxisX.CustomLabels.Clear();
            chartIncomePerTime.ChartAreas[0].AxisX.StripLines.Clear();

            double TotalIncome = 0;
            int index = 1;
            foreach (var group in groupedData)
            {

                chartIncomePerTime.Series["Series1"].Points.AddXY(group.Year, group.TotalAmountPaid);
                TotalIncome += group.TotalAmountPaid;

                chartIncomePerTime.ChartAreas[0].AxisX.CustomLabels.Add(group.Year - 0.5, group.Year + 0.5, group.Year.ToString());
                if (group.TotalAmountPaid > 0)
                {
                    CreateStripLine(index, chartIncomePerTime);

                }
                index++;
            }
            //chartIncomePerTime.ChartAreas[0].AxisX.Title = "Years";

            chartIncomePerTime.Series["Series1"].Label = Currency.Symbol + "#VAL{N1}";
            labelTotalIncome.Text = Currency.Symbol + TotalIncome.ToString("N1");
        }


        public void OutputSessionPerDay(DataTable FilteredSessionsDt, DateTime DesiredDate)
        {

            //
            chartSessions.Series["Series1"].Label = "";
            //
            DateOfFilterSessions = DesiredDate;
            //


            IEnumerable<int> allDays;
            if (DesiredDate.Month == DateTime.Now.Month)
            {
                allDays = Enumerable.Range(1, DateTime.Now.Day);
            }
            else
            {
                allDays = Enumerable.Range(1, DateTime.DaysInMonth(DesiredDate.Year, DesiredDate.Month));
            }


            var groupedData = from row in FilteredSessionsDt.AsEnumerable()
                              where row.Field<DateTime>("execute_date").Year == DesiredDate.Year &&
                                    row.Field<DateTime>("execute_date").Month == DesiredDate.Month
                              group row by row.Field<DateTime>("execute_date").Day into g
                              orderby g.Key
                              select new
                              {
                                  Day = g.Key,
                                  TotalSessionsPerDay = g.Count() // Count the sessions for the day
                              };

            var mergedData = from day in allDays
                             join groupEntry in groupedData on day equals groupEntry.Day into dayGroup
                             from dayData in dayGroup.DefaultIfEmpty()  // Left join
                             select new
                             {
                                 Day = day,
                                 TotalSessionsPerDay = dayData != null ? dayData.TotalSessionsPerDay : 0
                             };




            chartSessions.Series["Series1"].Points.Clear();
            chartSessions.ChartAreas[0].AxisX.CustomLabels.Clear();
            chartSessions.ChartAreas[0].AxisX.StripLines.Clear();

            string[] dayAbbreviations = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            int TotalNumberOfSessions = 0;
            int index = 0;
            foreach (var data in mergedData)
            {
                chartSessions.Series["Series1"].Points.AddXY(data.Day, data.TotalSessionsPerDay);
                TotalNumberOfSessions += data.TotalSessionsPerDay;
                var dayOfWeek = new DateTime(DesiredDate.Year, DesiredDate.Month, data.Day).DayOfWeek;
                var dayNameAbbreviation = dayAbbreviations[(int)dayOfWeek]; // Get day abbreviation
                chartSessions.ChartAreas[0].AxisX.CustomLabels.Add(data.Day - 0.5, data.Day + 0.5, $"{dayNameAbbreviation}\n{data.Day}");


                if (data.TotalSessionsPerDay > 0)
                {
                    chartSessions.Series["Series1"].Points[index].IsValueShownAsLabel = true;
                    // Create a StripLine for the specific gridline
                    CreateStripLine(index + 1, chartSessions);
                }
                else
                {
                    chartSessions.Series["Series1"].Points[index].IsValueShownAsLabel = false;
                }
                index++;

            }

            labelTotalNumberOfSessions.Text = TotalNumberOfSessions.ToString();


            //
            List<Chart> charts = new List<Chart> { chartSessions };//kermel el el mode
            if (groupedData.ToList().Count > 0)
            {
                SetNoDateLabel(false, true, charts);
            }
            else
            {
                SetNoDateLabel(false, false, charts);
            }
            //
        }
        public void OutputSessionPerMonth(DataTable FilteredSessionsDt, DateTime DesiredDate)
        {

            DateOfFilterSessions = DesiredDate;
            //

            IEnumerable<int> allMonths;
            if (DesiredDate.Year == DateTime.Now.Year)
            {
                allMonths = Enumerable.Range(1, DateTime.Now.Month);
            }
            else
            {
                allMonths = Enumerable.Range(1, 12);
            }

            var groupedData = from row in FilteredSessionsDt.AsEnumerable()
                              where row.Field<DateTime>("execute_date").Year == DesiredDate.Year
                              group row by row.Field<DateTime>("execute_date").Month into g
                              orderby g.Key
                              select new
                              {
                                  Month = g.Key,
                                  TotalSessionsPerMonth = g.Count()
                              };

            var mergedData = from month in allMonths
                             join groupEntry in groupedData on month equals groupEntry.Month into monthGroup
                             from monthData in monthGroup.DefaultIfEmpty()  // Left join
                             select new
                             {
                                 Month = month,
                                 TotalSessionsPerMonth = monthData != null ? monthData.TotalSessionsPerMonth : 0
                             };

            chartSessions.Series["Series1"].Points.Clear();
            chartSessions.ChartAreas[0].AxisX.CustomLabels.Clear();
            chartSessions.ChartAreas[0].AxisX.StripLines.Clear();

            int TotalNumberOfSessions = 0;
            int index = 1;
            foreach (var data in mergedData)
            {
                // Adding points to the chart series
                chartSessions.Series["Series1"].Points.AddXY(data.Month, data.TotalSessionsPerMonth);
                TotalNumberOfSessions += data.TotalSessionsPerMonth;
                // Add a custom label for the current data point
                var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(data.Month);
                chartSessions.ChartAreas[0].AxisX.CustomLabels.Add(data.Month - 0.5, data.Month + 0.5, monthName);

                if (data.TotalSessionsPerMonth > 0)
                {
                    CreateStripLine(index, chartSessions);
                }
                index++;
            }
            chartSessions.Series["Series1"].Label = "#VAL{}";
            labelTotalNumberOfSessions.Text = TotalNumberOfSessions.ToString();

            //
            List<Chart> charts = new List<Chart> { chartSessions };//kermel el el mode
            if (groupedData.ToList().Count > 0)
            {
                SetNoDateLabel(false, true, charts);
            }
            else
            {
                SetNoDateLabel(false, false, charts);
            }
            //
        }
        public void OutputSessionPerYear(DataTable FilteredSessionsDt)
        {
            DateOfFilterSessions = DateTime.Now;
            //
            var groupedData = from row in FilteredSessionsDt.AsEnumerable()
                              group row by row.Field<DateTime>("execute_date").Year into g
                              orderby g.Key
                              select new
                              {
                                  Year = g.Key,
                                  TotalSessionsPerYear = g.Count()
                              };

            chartSessions.Series["Series1"].Points.Clear();
            chartSessions.ChartAreas[0].AxisX.CustomLabels.Clear();
            chartSessions.ChartAreas[0].AxisX.StripLines.Clear();



            int TotalNumberOfSessions = 0;
            int index = 1;
            foreach (var data in groupedData)
            {
                // Adding points to the chart series
                chartSessions.Series["Series1"].Points.AddXY(data.Year, data.TotalSessionsPerYear);
                TotalNumberOfSessions += data.TotalSessionsPerYear;
                // Add a custom label for the current data point
                chartSessions.ChartAreas[0].AxisX.CustomLabels.Add(data.Year - 0.5, data.Year + 0.5, data.Year.ToString());

                if (data.TotalSessionsPerYear > 0)
                {
                    CreateStripLine(index, chartSessions);

                }
                index++;
            }
            chartSessions.Series["Series1"].Label = "#VAL{}";
            labelTotalNumberOfSessions.Text = TotalNumberOfSessions.ToString();
            //
            List<Chart> charts = new List<Chart> { chartSessions };//kermel el el mode
            if (groupedData.ToList().Count > 0)
            {
                SetNoDateLabel(false, true, charts);
            }
            else
            {
                SetNoDateLabel(false, false, charts);
            }
            //
        }


        void CreateStripLine(int index, Chart DesiredChart)//we re expecting eza ken eena one point ma tozbat,w fi ela algorithm bas sa2il , metel el workout huwwe zeto, cz already helela
        {
            StripLine stripLine = new StripLine();
            stripLine.IntervalOffset = index; // position of the strip line
            stripLine.StripWidth = 0.0001; // thin line width
            stripLine.BackColor = Color.LightGray; // color of the gridline
            stripLine.BorderWidth = 0; // adjust thickness if required
            DesiredChart.ChartAreas[0].AxisX.StripLines.Add(stripLine);
        }


        public void OpenDateMonthForm(UCLabelFilterOriginal UCCustomDate, DateTime DateType)
        {
            if (Program.GreyForm == null)
            {
                Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
                Program.GreyForm.Show();

                Calander calander = new Calander(UCCustomDate, DateType);
                calander.StatisticsForm = this;
                calander.Show();
            }
        }
        public void OpenDateYearForm(UCLabelFilterOriginal UCCustomDate, DateTime DateType)
        {
            if (Program.GreyForm == null)
            {
                Program.GreyForm = new GreyColor(Program.HomeForm, true, false, null);
                Program.GreyForm.Show();

                Calanderyear calander = new Calanderyear(UCCustomDate, DateType);
                calander.StatisticsForm = this;
                calander.Show();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

#pragma warning restore CA1416 // Validate platform compatibility


    }
}
