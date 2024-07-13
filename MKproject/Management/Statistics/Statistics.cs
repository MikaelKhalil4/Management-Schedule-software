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

        //public UCComboFilterStat UCComboFilterDateIncome;
        //UCLabelFilterStatistics UCCustomeDateIncome;



        public UCComboFilterStat UCComboFilterDateIncome;
        UCLabelFilterStatistics UCCustomeDateIncome;


        UCComboFilterStat UCComboFilterServiceIncome;





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
            SetupCombinedChart();



            Formatcharts();

            OriginalSessionsDt = SQLToProject.GetAttendanceDate();
            OriginalIncomeDt = SQLToProject.GetIncome();

            SplitServices(OriginalIncomeDt);

            CreateFilters();




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
                    LabelNoDataYetSessions.Show();
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
                    if (TLPGLobalIncom.Controls.Contains(LabelNoDataYetSessions))
                    {
                        LabelNoDataYetSessions.Hide();
                        TLPGLobalIncom.Controls.Remove(LabelNoDataYetSessions);
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
            legend3.Font = new Font("Segoe UI Semibold", 9.00f, FontStyle.Bold);
            legend3.BackColor = Color.Transparent;
            chartIncomePerService.Legends.Add(legend3);

            chartIncomePerService.Location = new Point(156, 3);
            chartIncomePerService.Name = "chartIncomePerService";

            Series Income = new Series();
            Income.ChartArea = "ChartArea1";
            Income.Color = Color.FromArgb(109, 122, 224);
            Income.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Income.IsValueShownAsLabel = true;
            Income.Label = "#VAL{C1}";
            Income.LabelBackColor = Color.WhiteSmoke;
            Income.LabelForeColor = Color.FromArgb(114, 189, 57);
            Income.Legend = "Legend3";
            Income.LegendText = "Income";
            Income.Name = "SeriesIncome";
            Income.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            Income.SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Top | LabelAlignmentStyles.TopRight | LabelAlignmentStyles.BottomLeft | LabelAlignmentStyles.BottomRight;

            Series Quantity = new Series();
            Quantity.ChartArea = "ChartArea1";
            Quantity.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Quantity.IsValueShownAsLabel = true;
            Quantity.LabelBackColor = Color.WhiteSmoke;
            Quantity.Legend = "Legend3";
            Quantity.LegendText = "Quantity";
            Quantity.Name = "SeriesQty";
            Quantity.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            Quantity.SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Top | LabelAlignmentStyles.TopLeft | LabelAlignmentStyles.TopRight | LabelAlignmentStyles.BottomLeft | LabelAlignmentStyles.BottomRight;
            Quantity.YAxisType = AxisType.Secondary;

            chartIncomePerService.Series.Add(Income);
            chartIncomePerService.Series.Add(Quantity);

            chartIncomePerService.Size = new Size(1050, 214);
            chartIncomePerService.TabIndex = 35;
            chartIncomePerService.Text = "chart1";

            TLPGLobalIncom.Controls.Add(chartIncomePerService, 1, 0);
        }

        Chart combinedChart;
        private void SetupCombinedChart()
        {
            // Initialize the chart
            combinedChart = new Chart();
            combinedChart.BackColor = Color.Transparent;
            combinedChart.Dock = DockStyle.Fill;
            combinedChart.Location = new Point(156, 3);
            combinedChart.Name = "combinedChart";
            combinedChart.Size = new Size(1050, 255);
            combinedChart.TabIndex = 39;
            combinedChart.Text = "Combined Chart";

            // Create and configure the Chart Area
            ChartArea chartArea = new ChartArea();
            chartArea.BackColor = Color.Transparent;
            chartArea.Name = "ChartArea1";
            chartArea.AxisX.ArrowStyle = AxisArrowStyle.Lines;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 11.25F);
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisX.MinorGrid.Enabled = false;
            chartArea.AxisX.TitleFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            chartArea.AxisX.TitleAlignment = StringAlignment.Far;

            chartArea.AxisY.Enabled = AxisEnabled.False;
            chartArea.AxisY2.Enabled = AxisEnabled.False;
            //// Configure the primary Y-Axis (for Income)
            //chartArea.AxisY.ArrowStyle = AxisArrowStyle.Lines;
            //chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            //chartArea.AxisY.MajorGrid.Enabled = false;
            //chartArea.AxisY.TitleFont = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);

            //// Configure the secondary Y-Axis (for Sessions)
            //chartArea.AxisY2.Enabled = AxisEnabled.True;
            //chartArea.AxisY2.ArrowStyle = AxisArrowStyle.Lines;
            //chartArea.AxisY2.LabelStyle.Font = new Font("Segoe UI", 9.75F);
            //chartArea.AxisY2.MajorGrid.Enabled = false;
            //chartArea.AxisY2.TitleFont = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);

            combinedChart.ChartAreas.Add(chartArea);

            // Series for Income and Sessions
            Series seriesIncome = new Series();
            Color IncomeColor = Color.FromArgb(114, 189, 57);
            seriesIncome.BorderColor = Color.White;
            seriesIncome.BorderWidth = 2;
            seriesIncome.ChartArea = "ChartArea1";
            seriesIncome.ChartType = SeriesChartType.Line;
            seriesIncome.Color = IncomeColor;
            seriesIncome.CustomProperties = "LabelStyle=Top";
            seriesIncome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            seriesIncome.LabelBackColor = Color.WhiteSmoke;
            seriesIncome.LabelForeColor = IncomeColor;
            seriesIncome.MarkerColor = IncomeColor;
            seriesIncome.MarkerSize = 7;
            seriesIncome.MarkerStyle = MarkerStyle.Circle;
            seriesIncome.Name = "Income";
            seriesIncome.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;
            seriesIncome.SmartLabelStyle.CalloutBackColor = Color.Empty;
            seriesIncome.SmartLabelStyle.CalloutLineColor = IncomeColor;
            seriesIncome.SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Top | LabelAlignmentStyles.TopRight | LabelAlignmentStyles.BottomLeft | LabelAlignmentStyles.BottomRight;


            // Series for Sessions
            Series seriesSessions = new Series();
            Color sessionColor = Color.FromArgb(109, 122, 224);
            seriesSessions.BorderColor = Color.White;
            seriesSessions.BorderWidth = 2;
            seriesSessions.ChartArea = "ChartArea1";
            seriesSessions.ChartType = SeriesChartType.Line;
            seriesSessions.Color = sessionColor;
            seriesSessions.CustomProperties = "LabelStyle=Top";
            seriesSessions.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            seriesSessions.LabelBackColor = Color.WhiteSmoke;
            seriesSessions.LabelForeColor = sessionColor;
            seriesSessions.MarkerColor = sessionColor;
            seriesSessions.MarkerSize = 7;
            seriesSessions.MarkerStyle = MarkerStyle.Circle;
            seriesSessions.Name = "Sessions";
            seriesSessions.YAxisType = AxisType.Secondary;
            seriesSessions.SmartLabelStyle.Enabled = true;
            seriesSessions.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;
            seriesSessions.SmartLabelStyle.CalloutBackColor = Color.Empty;
            seriesSessions.SmartLabelStyle.CalloutLineColor = sessionColor;
            seriesSessions.SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Top | LabelAlignmentStyles.TopRight | LabelAlignmentStyles.BottomLeft | LabelAlignmentStyles.BottomRight;

            combinedChart.Series.Add(seriesIncome);
            combinedChart.Series.Add(seriesSessions);



            // Add the chart to a panel or a form
            TLPGLobalIncom.Controls.Add(combinedChart, 1, 2);// Assuming this code is in a Form
        }



        public void Formatcharts()
        {

            chartIncomePerService.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Regular);
            chartIncomePerService.Series["SeriesIncome"].Label = Currency.Symbol + "#VAL{N1}";//rounding to one decimal
            chartIncomePerService.Series["SeriesQty"].Label = "#VAL{}";//rounding to one decimal
            chartIncomePerService.Series["SeriesIncome"]["PointWidth"] = "0.7";
            chartIncomePerService.Series["SeriesQty"]["PointWidth"] = "0.7";


            combinedChart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
            combinedChart.ChartAreas[0].AxisX.Interval = 1;

            //combinedChart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
            //combinedChart.ChartAreas[0].AxisX.Interval = 1;
        }
        public void CreateFilters()
        {

            UCComboFilterServiceIncome = new UCComboFilterStat();
            UCComboFilterServiceIncome.StatisticsForm = this;
            UCComboFilterServiceIncome.FilterType = UCComboFilterStat.FiltersType.CategoryType;
            UCComboFilterServiceIncome.Title = "Category Type";
            UCComboFilterServiceIncome.Dock = DockStyle.Top;
            UCComboFilterServiceIncome.BringToFront();
            panelIncomeFilter.Controls.Add(UCComboFilterServiceIncome);
            UCComboFilterServiceIncome.BringToFront();



            //income,session /time
            UCComboFilterDateIncome = new UCComboFilterStat();
            UCComboFilterDateIncome.StatisticsForm = this;
            UCComboFilterDateIncome.FilterType = UCComboFilterStat.FiltersType.DateIncomeSessions;
            UCComboFilterDateIncome.Title = "Date";
            UCComboFilterDateIncome.Dock = DockStyle.Top;
            panelIncomeFilter.Controls.Add(UCComboFilterDateIncome);

        }
        public void CreateUCCustomeDate()
        {
            String SelectedString = UCComboFilterDateIncome.comboBoxDetail.SelectedItem.ToString();
            if (SelectedString == UCComboFilterStat.ChooseMonth || SelectedString == UCComboFilterStat.ChooseYear)
            {
                if (UCCustomeDateIncome == null || UCCustomeDateIncome.IsDisposed)
                {
                    UCCustomeDateIncome = new UCLabelFilterStatistics(UCLabelFilterStatistics.FiltersCategories.IncomeSessions);
                    UCCustomeDateIncome.StatisticsForm = this;
                    UCCustomeDateIncome.Visible = false;
                    UCCustomeDateIncome.Dock = DockStyle.Top;
                    panelIncomeFilter.Controls.Add(UCCustomeDateIncome);
                    int indexFather = panelIncomeFilter.Controls.GetChildIndex(UCComboFilterDateIncome);
                    panelIncomeFilter.Controls.SetChildIndex(UCCustomeDateIncome, indexFather);

                    if (SelectedString == UCComboFilterStat.ChooseMonth) // Month
                    {
                        UCCustomeDateIncome.Startdate = new DateTime(DateOfFilterIncome.Year, DateOfFilterIncome.Month, 1);
                        UCCustomeDateIncome.Enddate = ((DateTime)UCCustomeDateIncome.Startdate).AddMonths(1).AddDays(-1);
                    }
                    else // Year
                    {
                        UCCustomeDateIncome.Startdate = new DateTime(DateOfFilterIncome.Year, 1, 1);
                        UCCustomeDateIncome.Enddate = new DateTime(DateOfFilterIncome.Year, 12, 31);
                    }

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
            }
        }


        //public void CreateUCCustomeDateSessions()
        //{
        //    String SelectedString = UCComboFilterDateIncome.comboBoxDetail.SelectedItem.ToString();
        //    if (SelectedString == UCComboFilterStat.ChooseMonth || SelectedString == UCComboFilterStat.ChooseYear)
        //    {
        //        if (UCCustomeDateIncome == null || UCCustomeDateIncome.IsDisposed)
        //        {
        //            UCCustomeDateIncome = new UCLabelFilterStatistics(UCLabelFilterStatistics.FiltersCategories.Sessions);
        //            UCCustomeDateIncome.StatisticsForm = this;
        //            UCCustomeDateIncome.Visible = false;
        //            UCCustomeDateIncome.Dock = DockStyle.Top;
        //            panelSessionsFilter.Controls.Add(UCCustomeDateIncome);
        //            int indexFather = panelSessionsFilter.Controls.GetChildIndex(UCComboFilterDateIncome);
        //            panelSessionsFilter.Controls.SetChildIndex(UCCustomeDateIncome, indexFather);

        //        }

        //        if (SelectedString == UCComboFilterStat.ChooseMonth)
        //        {
        //            UCCustomeDateIncome.Title = "Month";

        //            UCCustomeDateIncome.Show();
        //            UCCustomeDateIncome.PerformLayout();
        //            UCCustomeDateIncome.Detail = DateOfFilterSessions.ToString("MMMM") + " " + DateOfFilterSessions.ToString("yyyy");//default value, on textchnage tabaa el label byaamil filter

        //            OpenDateMonthForm(UCCustomeDateIncome, DateOfFilterSessions);
        //        }
        //        else if (SelectedString == UCComboFilterStat.ChooseYear)
        //        {
        //            UCCustomeDateIncome.Title = "Year";
        //            UCCustomeDateIncome.Show();
        //            UCCustomeDateIncome.PerformLayout();
        //            UCCustomeDateIncome.Detail = DateOfFilterSessions.ToString("yyyy");

        //            OpenDateYearForm(UCCustomeDateIncome, DateOfFilterSessions);
        //        }

        //    }
        //    else
        //    {
        //        if (UCCustomeDateIncome != null)
        //        {
        //            UCCustomeDateIncome.Dispose();
        //        }

        //    }
        //}

        bool IsServices;
        public void FilterDatatbleIncomeSessions()
        {
            DataTable FilteredIncomeDt = OriginalAllServicesIncomeDt.Copy();

            if (UCComboFilterServiceIncome != null && UCComboFilterDateIncome != null)
            {


                combinedChart.Series["Income"].Points.Clear();
                combinedChart.Series["Sessions"].Points.Clear();

                combinedChart.ChartAreas[0].AxisX.CustomLabels.Clear();
                combinedChart.ChartAreas[0].AxisX.StripLines.Clear();





                string selectedString1 = UCComboFilterServiceIncome.comboBoxDetail.SelectedItem.ToString();
                if (selectedString1 != UCComboFilterStat.All)
                {
                    FilteredIncomeDt = FiltersDataTable.FilterDatatableIFStringEquality("Category Type", selectedString1, FilteredIncomeDt);
                }


                int RowHeight = 33;
                TLPGLobalIncom.RowStyles[1].Height = 55;

                if (selectedString1 == UCComboFilterStat.Services)
                {
                    IsServices = true;
                    TLPIncome.RowStyles[0].Height = RowHeight;
                    TLPIncome.RowStyles[1].Height = RowHeight;
                    TLPIncome.RowStyles[2].Height = RowHeight;
                    TLPIncome.RowStyles[3].Height = RowHeight;


                    combinedChart.Series["Income"].Enabled = true;
                    combinedChart.Series["Sessions"].Enabled = true;

                    checkBoxServices.Enabled = true;
                    checkBoxServices.Checked = true;

                    checkBoxIncome.Enabled = true;
                    checkBoxIncome.Checked = true;
                }
                else
                {
                    IsServices = false;
                    TLPIncome.RowStyles[0].Height = RowHeight;
                    TLPIncome.RowStyles[1].Height = RowHeight;
                    TLPIncome.RowStyles[2].Height = 0;
                    TLPIncome.RowStyles[3].Height = 0;

                    combinedChart.Series["Income"].Enabled = true;
                    combinedChart.Series["Sessions"].Enabled = false;

                    checkBoxServices.Enabled = false;
                    checkBoxServices.Checked = false;

                    checkBoxIncome.Enabled = true;
                    checkBoxIncome.Checked = true;
                }
                FixFonts();

                DateTime currentDate = DateTime.Now;
                string selectedString3 = UCComboFilterDateIncome.comboBoxDetail.SelectedItem.ToString();

                if (selectedString3 == UCComboFilterStat.ThisMonth)
                {
                    OutputChartIncomePerDay(FilteredIncomeDt, DateTime.Now);
                    // This month
                    //income
                    DateTime thisMonthStartDate = new DateTime(currentDate.Year, currentDate.Month, 1);
                    DateTime thisMonthEndDate = thisMonthStartDate.AddMonths(1).AddSeconds(-1);
                    OutputChartIncomePerService(FiltersDataTable.FilterDatatableDateCustomDate("Payment Date", FilteredIncomeDt, thisMonthStartDate, thisMonthEndDate));

                    //session
                    if (IsServices)
                    {
                        OutputSessionPerDay(OriginalSessionsDt, DateTime.Now);
                    }


                }
                else if (selectedString3 == UCComboFilterStat.LastMonth)
                {
                    // Last month
                    DateTime thisMonthStartDate = new DateTime(currentDate.Year, currentDate.Month, 1);
                    DateTime lastMonthStartDate = thisMonthStartDate.AddMonths(-1);
                    DateTime lastMonthEndDate = thisMonthStartDate.AddSeconds(-1);

                    //income
                    OutputChartIncomePerDay(FilteredIncomeDt, lastMonthEndDate);
                    OutputChartIncomePerService(FiltersDataTable.FilterDatatableDateCustomDate("Payment Date", FilteredIncomeDt, lastMonthStartDate, lastMonthEndDate));

                    //sessions
                    if (IsServices)
                    {
                        OutputSessionPerDay(OriginalSessionsDt, lastMonthEndDate);
                    }
                }
                else if (selectedString3 == UCComboFilterStat.ThisYear)
                {

                    DateTime thisYearStartDate = new DateTime(currentDate.Year, 1, 1);
                    DateTime thisYearEndDate = new DateTime(currentDate.Year + 1, 1, 1).AddSeconds(-1);

                    //income
                    OutputChartIncomePerMonth(FilteredIncomeDt, DateTime.Now);
                    OutputChartIncomePerService(FiltersDataTable.FilterDatatableDateCustomDate("Payment Date", FilteredIncomeDt, thisYearStartDate, thisYearEndDate));

                    //sessions
                    if (IsServices)
                    {
                        OutputSessionPerMonth(OriginalSessionsDt, DateTime.Now);
                    }

                }
                else if (selectedString3 == UCComboFilterStat.LastYear)
                {
                    // Last year
                    DateTime lastYearStartDate = new DateTime(currentDate.Year - 1, 1, 1);
                    DateTime lastYearEndDate = new DateTime(currentDate.Year, 1, 1).AddSeconds(-1);

                    //income
                    OutputChartIncomePerMonth(FilteredIncomeDt, lastYearEndDate);
                    OutputChartIncomePerService(FiltersDataTable.FilterDatatableDateCustomDate("Payment Date", FilteredIncomeDt, lastYearStartDate, lastYearEndDate));

                    //session
                    if (IsServices)
                    {
                        OutputSessionPerMonth(OriginalSessionsDt, lastYearEndDate);
                    }

                }

                else if (selectedString3 == UCComboFilterStat.AllYears)
                {
                    //income
                    OutputChartIncomePerYear(FilteredIncomeDt);
                    OutputChartIncomePerService(FilteredIncomeDt);

                    //sessions
                    if (IsServices)
                    {
                        OutputSessionPerYear(OriginalSessionsDt);
                    }

                }
                else if (selectedString3 == UCComboFilterStat.ChooseMonth)
                {
                    if (UCCustomeDateIncome.Startdate != null && UCCustomeDateIncome.Enddate != null)
                    {
                        //income
                        OutputChartIncomePerDay(FilteredIncomeDt, (DateTime)UCCustomeDateIncome.Startdate);
                        OutputChartIncomePerService(FiltersDataTable.FilterDatatableDateCustomDate("Payment Date", FilteredIncomeDt, (DateTime)UCCustomeDateIncome.Startdate, (DateTime)UCCustomeDateIncome.Enddate));


                        //sessions
                        if (IsServices)
                        {
                            OutputSessionPerDay(OriginalSessionsDt, (DateTime)UCCustomeDateIncome.Startdate);
                        }

                    }
                }
                else if (selectedString3 == UCComboFilterStat.ChooseYear)
                {
                    if (UCCustomeDateIncome.Startdate != null && UCCustomeDateIncome.Enddate != null)
                    {


                        //income
                        OutputChartIncomePerMonth(FilteredIncomeDt, (DateTime)UCCustomeDateIncome.Startdate);
                        OutputChartIncomePerService(FiltersDataTable.FilterDatatableDateCustomDate("Payment Date", FilteredIncomeDt, (DateTime)UCCustomeDateIncome.Startdate, (DateTime)UCCustomeDateIncome.Enddate));


                        //sessions
                        if (IsServices)
                        {
                            OutputSessionPerMonth(OriginalSessionsDt, (DateTime)UCCustomeDateIncome.Startdate);
                        }

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
            OriginalAllServicesIncomeDt.Columns.Add("Payment Date", typeof(String));


            // Retrieve and merge the desired columns from FilteredbundleDt
            foreach (DataRow row in OriginalIncomDt.Rows)
            {


                double AmountPaid = (double)row["amount_paid"];
                DateTime Date = Convert.ToDateTime(row["payment_date"]); // Replace with the actual column name

                int CategoryId;
                string Item;
                if (row["bundle_id"] != DBNull.Value)
                {
                    CategoryId = Convert.ToInt32(row["bundle_id"]);
                    Item = UCComboFilterStat.Services;
                }
                else
                {
                    CategoryId = Convert.ToInt32(row["product_id"]);
                    Item = UCComboFilterStat.Products;
                }




                int ClientBalanceId = Convert.ToInt32(row["client_balance_id"]);
                OriginalAllServicesIncomeDt.Rows.Add(Item, CategoryId, ClientBalanceId, AmountPaid, Date);



            }






        }



        public void OutputChartIncomePerService(DataTable FilteredAllServicesIncomeDt)
        {

            List<Chart> charts = new List<Chart> { chartIncomePerService, combinedChart };//kermel el el mode

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
                        int CategoryQty = Convert.ToInt32(group.ClientBalanceIdReps);


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
                        int serviceId = Convert.ToInt32(group.CategoryId);
                        double totalAmountPaid = group.TotalAmountPaid;
                        int CategoryQty = Convert.ToInt32(group.ClientBalanceIdReps);
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
                        int serviceId = Convert.ToInt32(group.CategoryId);
                        double totalAmountPaid = group.TotalAmountPaid;
                        string ProductName = ClassProduct.FindProductName(serviceId);
                        int CategoryQty = Convert.ToInt32(group.ClientBalanceIdReps);

                        chartIncomePerService.Series["SeriesIncome"].Points.AddXY(i, totalAmountPaid);
                        chartIncomePerService.Series["SeriesQty"].Points.AddXY(i, CategoryQty);
                        chartIncomePerService.ChartAreas[0].AxisX.CustomLabels.Add(i - 1, i + 1, ProductName);

                        i += 2;

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
            combinedChart.Series["Income"].Label = "";//reset
            combinedChart.Series["Sessions"].Label = "";

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
                              where Convert.ToDateTime(row.Field<string>("Payment Date")).Year == DesiredDate.Year &&
                                    Convert.ToDateTime(row.Field<string>("Payment Date")).Month == DesiredDate.Month
                              group row by Convert.ToDateTime(row.Field<string>("Payment Date")).Day into g
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



            double TotalIncome = 0;
            string[] dayAbbreviations = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };


            // Populate the joinedDataTable with the grouped data
            int index = 0;
            foreach (var group in joinedData)
            {
                TotalIncome += group.TotalAmountPaid;



                combinedChart.Series["Income"].Points.AddXY(group.Day, group.TotalAmountPaid);




                var dayOfWeek = new DateTime(DesiredDate.Year, DesiredDate.Month, group.Day).DayOfWeek;
                var dayNameAbbreviation = dayAbbreviations[(int)dayOfWeek]; // Get day abbreviation
                combinedChart.ChartAreas[0].AxisX.CustomLabels.Add(group.Day - 0.5, group.Day + 0.5, dayNameAbbreviation + "\n" + group.Day.ToString());


                //kermel el x axis labels
                if (group.TotalAmountPaid > 0)
                {
                    combinedChart.Series["Income"].Points[index].Label = Currency.Symbol + "#VAL{N1}";
                    combinedChart.Series["Income"].Points[index].IsValueShownAsLabel = true;


                    // Create a StripLine for the specific gridline
                    CreateStripLine(index + 1, combinedChart);



                }
                else
                {
                    combinedChart.Series["Income"].Points[index].IsValueShownAsLabel = false;
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
                              where Convert.ToDateTime(row.Field<string>("Payment Date")).Year == DesiredDate.Year
                              group row by Convert.ToDateTime(row.Field<string>("Payment Date")).Month into g
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






            double TotalIncome = 0;
            int index = 1;
            foreach (var data in joinedData)
            {



                combinedChart.Series["Income"].Points.AddXY(data.Month, data.TotalAmountPaid);
                TotalIncome += data.TotalAmountPaid;

                var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(data.Month);
                combinedChart.ChartAreas[0].AxisX.CustomLabels.Add(data.Month - 0.5, data.Month + 0.5, monthName);

                if (data.TotalAmountPaid > 0)
                {
                    CreateStripLine(index, combinedChart);

                }
                index++;
            }

            combinedChart.Series["Income"].Label = Currency.Symbol + "#VAL{N1}";
            labelTotalIncome.Text = Currency.Symbol + TotalIncome.ToString("N1");
        }
        public void OutputChartIncomePerYear(DataTable FilteredAllServicesIncomeDt)
        {


            //
            DateOfFilterIncome = DateTime.Now;
            // Get distinct years from your DataTable
            var distinctYears = FilteredAllServicesIncomeDt.AsEnumerable()
                                 .Select(row => Convert.ToDateTime(row.Field<string>("Payment Date")).Year)
                                 .Distinct();

            // Group and aggregate the data from FilteredAllServicesIncomeDt by year
            var groupedData = from row in FilteredAllServicesIncomeDt.AsEnumerable()
                              group row by Convert.ToDateTime(row.Field<string>("Payment Date")).Year into g
                              orderby g.Key
                              select new
                              {
                                  Year = g.Key,
                                  TotalAmountPaid = g.Sum(r => r.Field<double>("Amount Paid"))
                              };






            double TotalIncome = 0;
            int index = 1;
            foreach (var group in groupedData)
            {

                combinedChart.Series["Income"].Points.AddXY(group.Year, group.TotalAmountPaid);
                TotalIncome += group.TotalAmountPaid;

                combinedChart.ChartAreas[0].AxisX.CustomLabels.Add(group.Year - 0.5, group.Year + 0.5, group.Year.ToString());
                if (group.TotalAmountPaid > 0)
                {
                    CreateStripLine(index, combinedChart);

                }
                index++;
            }
            //chartIncomePerTime.ChartAreas[0].AxisX.Title = "Years";

            combinedChart.Series["Income"].Label = Currency.Symbol + "#VAL{N1}";
            labelTotalIncome.Text = Currency.Symbol + TotalIncome.ToString("N1");
        }


        public void OutputSessionPerDay(DataTable FilteredSessionsDt, DateTime DesiredDate)
        {

            //

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
                              where Convert.ToDateTime(row.Field<string>("execute_date")).Year == DesiredDate.Year &&
                                   Convert.ToDateTime(row.Field<string>("execute_date")).Month == DesiredDate.Month
                              group row by Convert.ToDateTime(row.Field<string>("execute_date")).Day into g
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





            string[] dayAbbreviations = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            int TotalNumberOfSessions = 0;
            int index = 0;
            foreach (var data in mergedData)
            {
                combinedChart.Series["Sessions"].Points.AddXY(data.Day, data.TotalSessionsPerDay);
                TotalNumberOfSessions += data.TotalSessionsPerDay;
                var dayOfWeek = new DateTime(DesiredDate.Year, DesiredDate.Month, data.Day).DayOfWeek;
                var dayNameAbbreviation = dayAbbreviations[(int)dayOfWeek]; // Get day abbreviation
                combinedChart.ChartAreas[0].AxisX.CustomLabels.Add(data.Day - 0.5, data.Day + 0.5, $"{dayNameAbbreviation}\n{data.Day}");


                if (data.TotalSessionsPerDay > 0)
                {
                    combinedChart.Series["Sessions"].Points[index].IsValueShownAsLabel = true;
                    // Create a StripLine for the specific gridline
                    CreateStripLine(index + 1, combinedChart);
                }
                else
                {
                    combinedChart.Series["Sessions"].Points[index].IsValueShownAsLabel = false;
                }
                index++;

            }

            labelTotalNumberOfSessions.Text = TotalNumberOfSessions.ToString();


            ////
            //List<Chart> charts = new List<Chart> { combinedChart };//kermel el el mode
            //if (groupedData.ToList().Count > 0)
            //{
            //    SetNoDateLabel(false, true, charts);
            //}
            //else
            //{
            //    SetNoDateLabel(false, false, charts);
            //}
            ////
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
                              where Convert.ToDateTime(row.Field<string>("execute_date")).Year == DesiredDate.Year
                              group row by Convert.ToDateTime(row.Field<string>("execute_date")).Month into g
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


            int TotalNumberOfSessions = 0;
            int index = 1;
            foreach (var data in mergedData)
            {
                // Adding points to the chart series
                combinedChart.Series["Sessions"].Points.AddXY(data.Month, data.TotalSessionsPerMonth);
                TotalNumberOfSessions += data.TotalSessionsPerMonth;
                // Add a custom label for the current data point
                var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(data.Month);
                combinedChart.ChartAreas[0].AxisX.CustomLabels.Add(data.Month - 0.5, data.Month + 0.5, monthName);

                if (data.TotalSessionsPerMonth > 0)
                {
                    CreateStripLine(index, combinedChart);
                }
                index++;
            }
            combinedChart.Series["Sessions"].Label = "#VAL{}";
            labelTotalNumberOfSessions.Text = TotalNumberOfSessions.ToString();

            ////
            //List<Chart> charts = new List<Chart> { combinedChart };//kermel el el mode
            //if (groupedData.ToList().Count > 0)
            //{
            //    SetNoDateLabel(false, true, charts);
            //}
            //else
            //{
            //    SetNoDateLabel(false, false, charts);
            //}
            //
        }
        public void OutputSessionPerYear(DataTable FilteredSessionsDt)
        {
            DateOfFilterSessions = DateTime.Now;
            //
            var groupedData = from row in FilteredSessionsDt.AsEnumerable()
                              group row by Convert.ToDateTime(row.Field<string>("execute_date")).Year into g
                              orderby g.Key
                              select new
                              {
                                  Year = g.Key,
                                  TotalSessionsPerYear = g.Count()
                              };




            int TotalNumberOfSessions = 0;
            int index = 1;
            foreach (var data in groupedData)
            {
                // Adding points to the chart series
                combinedChart.Series["Sessions"].Points.AddXY(data.Year, data.TotalSessionsPerYear);
                TotalNumberOfSessions += data.TotalSessionsPerYear;
                // Add a custom label for the current data point
                combinedChart.ChartAreas[0].AxisX.CustomLabels.Add(data.Year - 0.5, data.Year + 0.5, data.Year.ToString());

                if (data.TotalSessionsPerYear > 0)
                {
                    CreateStripLine(index, combinedChart);

                }
                index++;
            }
            combinedChart.Series["Sessions"].Label = "#VAL{}";
            labelTotalNumberOfSessions.Text = TotalNumberOfSessions.ToString();


            ////
            //List<Chart> charts = new List<Chart> { combinedChart };//kermel el el mode
            //if (groupedData.ToList().Count > 0)
            //{
            //    SetNoDateLabel(false, true, charts);
            //}
            //else
            //{
            //    SetNoDateLabel(false, false, charts);
            //}
            ////
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

        private void TLPGLobalIncom_Resize(object sender, EventArgs e)
        {
            FixFonts();


        }
        void FixFonts()
        {
            labelIncome.Font = new Font(labelIncome.Font.FontFamily, 12, FontStyle.Bold);
            RandomFunctions.FixedFont(labelIncome, FontStyle.Bold);

            if (IsServices)
            {
                labelSession.Font = new Font(labelSession.Font.FontFamily, 12, FontStyle.Bold);
                RandomFunctions.FixedFont(labelSession, FontStyle.Bold);
            }
        }

     
        private void checkBoxIncome_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIncome.Checked)
            {
                combinedChart.Series["Income"].Enabled = true;
            }
            else
            {
                combinedChart.Series["Income"].Enabled = false;
            }
        }

        private void checkBoxServices_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxServices.Checked)
            {
                combinedChart.Series["Sessions"].Enabled = true;
            }
            else
            {
                combinedChart.Series["Sessions"].Enabled = false;
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
