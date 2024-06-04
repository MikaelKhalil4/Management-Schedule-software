
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using System.Windows.Xps.Serialization;
using GlobalFunctions;
using MKproject.Management;
using MKproject.Schedule;


namespace MKproject.Schedule
{

    public partial class UCEmployeeAvailabilty : UserControl
    {

        public TableLayoutPanel TLPScheduleAv;
        public TableLayoutPanel TLPDays;


        List<string> ListdaysOfWeek = new List<string>()
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };


        public UCEmployeeAvailabilty()
        {
            InitializeComponent();

      
            CreateTLP();
            SetTLPColumns();
      
        }
        void SetTLPColumns()
        {
            float PercentageOfEachGroup = 100 / ListdaysOfWeek.Count;
            for (int i = 0; i < ListdaysOfWeek.Count; i++)
            {
                //Days
                TLPDays.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, PercentageOfEachGroup));
                TLPDays.ColumnCount++;
                ButtonEmployeeOrDay buttonEmployeeOrDay = new ButtonEmployeeOrDay();
                buttonEmployeeOrDay.Dock = DockStyle.Fill;
                buttonEmployeeOrDay.Text = ListdaysOfWeek[i];
                buttonEmployeeOrDay.DesiredDate = DateTime.Now.AddDays(1);//hayyalla shi bas kermel tkun diffenet null, w tekhud el future design
                buttonEmployeeOrDay.SetButtonDesignBehavor(false, true);//ejbare tahet el Set fow
                TLPDays.Controls.Add(buttonEmployeeOrDay, i + 1, 0);//i+1, lieanno first column kermel el time

                TLPScheduleAv.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, PercentageOfEachGroup));
                TLPScheduleAv.ColumnCount++;
            }
        }

        void CreateTLP()
        {
            //uc1.UCAppIsDroped += Uc1_UCAppIsDroped;


            //
            if (TLPScheduleAv == null && TLPDays == null)
            {
                //TLPSchedule
                TLPScheduleAv = new TableLayoutPanel();
                TLPScheduleAv.AllowDrop = true;
                TLPScheduleAv.Dock = DockStyle.Fill;
                TLPScheduleAv.AutoScroll = true;
                TLPScheduleAv.BackColor = Color.FromArgb(249, 246, 254);
                TLPScheduleAv.Margin = new Padding(0, 0, 0, 0);
                TLPScheduleAv.AutoSize = false;
                //Hours
                TLPScheduleAv.RowCount = 96;
                for (int i = 0; i < TLPScheduleAv.RowCount; i++)
                {
                    TLPScheduleAv.RowStyles.Add(new RowStyle(SizeType.Absolute, 9));
                }


                //TLPEmployee
                TLPDays = new TableLayoutPanel();
                TLPDays.Dock = DockStyle.Fill;
                TLPDays.RowCount = 1;
                TLPDays.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
                TLPDays.Margin = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                TLPDays.BackColor = TLPScheduleAv.BackColor;

                //Time

                //Time in Tlp employee
                TLPDays.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
                TLPDays.ColumnCount++;

                //Time in TLP Schedule, ejbare absoloute
                TLPScheduleAv.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
                TLPScheduleAv.ColumnCount++;



                //
                for (int i = 0; i < TLPScheduleAv.RowCount; i += 4)
                {
                    Label LabelTime = new Label();
                    LabelTime.Dock = DockStyle.Fill;
                    LabelTime.BackColor = TLPScheduleAv.BackColor;
                    LabelTime.ForeColor = Color.FromArgb(64, 64, 64);
                    LabelTime.Dock = DockStyle.Fill;
                    LabelTime.TextAlign = ContentAlignment.TopRight;
                    LabelTime.Font = new Font("Segoe UI", 10, FontStyle.Regular);

                    TimeSpan Time = TimeSpan.FromHours(i / 4);

                    DateTime dateTime = DateTime.Today.Add(Time);//datetime it's a reference
                    string timestring = dateTime.ToString("h tt");
                    string[] partstime = timestring.Split(' ');
                    LabelTime.Text = partstime[0] + " " + partstime[1];


                    TLPScheduleAv.Controls.Add(LabelTime, 0, i);
                    TLPScheduleAv.SetRowSpan(LabelTime, 4);
                }


                //Events

                //TLPScheduleAv.MouseWheel += TLPScheduleAv_MouseMove;
                //TLPScheduleAv.MouseMove += TLPScheduleAv_MouseMove;

                //TLPScheduleAv.MouseLeave += TLPScheduleAv_MouseLeave;

                TLPScheduleAv.CellPaint += TLPScheduleAv_CellPaint; ;
                //TLPScheduleAv.DragDrop += TLPScheduleAv_DragDrop; ;
                //TLPScheduleAv.DragEnter += TLPScheduleAv_DragEnter; ;
                //TLPScheduleAv.DragOver += TLPScheduleAv_DragOver; ;

                //TLPScheduleAv.MouseClick += TLPScheduleAv_MouseClick; ;
                //
                this.TLPGlobal.Controls.Add(TLPDays, 0, 1);
                this.TLPGlobal.Controls.Add(TLPScheduleAv, 0, 2);

            }

        }



        private void TLPScheduleAv_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void TLPScheduleAv_DragOver(object sender, DragEventArgs e)
        {
        }

        private void TLPScheduleAv_DragEnter(object sender, DragEventArgs e)
        {
        }

        private void TLPScheduleAv_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void TLPScheduleAv_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;

            ////Check if we're in the last column; if not, don't draw vertical lines
            if (e.Column < TLPScheduleAv.ColumnCount)
            {
                for (int i = 0; i < ListdaysOfWeek.Count; i++) //+1 lieanno awwal wahde el time
                {

                    if (e.Column == i + 1 && e.Column != 0)
                    {
                        g.DrawLine(Pens.LightGray, r.Left, r.Top, r.Left, r.Bottom);
                    }

                }

            }

            // Always draw horizontal lines below the cell if not the last row
            if (e.Row < TLPScheduleAv.RowCount)
            {
                if (e.Row % 4 == 0)
                {
                    if (e.Row != 0)
                    {
                        g.DrawLine(Pens.LightGray, r.Left, r.Top, r.Right, r.Top);

                    }
                }
                else//hone el hidden rows
                {
                    //g.DrawLine(Pens.WhiteSmoke, r.Left, r.Top, r.Right, r.Top);
                }
            }

        }

        private void TLPScheduleAv_MouseLeave(object sender, EventArgs e)
        {
            //ResetSelection();
        }

        private void TLPScheduleAv_MouseMove(object sender, MouseEventArgs e)
        {
            //NbreofRowsHighlighted = 1;
            //SetValuesthatWillAffectselection(e.Location);
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
    }


}
