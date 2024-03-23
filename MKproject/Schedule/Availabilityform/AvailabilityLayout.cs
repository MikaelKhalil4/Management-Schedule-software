using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace MKproject.Schedule
{
    public partial class AvailabilityLayout : Form
    {
        //VARIABLES:
        int PreviousValue;
        int FutureValue;
        public Color ActiveColor = Color.FromArgb(196, 210, 245), DisactiveColor = Color.White;

        UCEmployee UCemployee;

        //INITIALISE:
        public AvailabilityLayout()
        {
            InitializeComponent();

            tableLayoutPanelAvailability.AutoScroll = true;
            tableLayoutPanelAvailability.VerticalScrollBarTable = VScrollBar1;

            //Fill uctime
            for (int i = 0; i < 24; i++)
            {
                UCTimeavailability uctime = new UCTimeavailability();
                uctime.Dock = DockStyle.Fill;
                uctime.Time = TimeSpan.FromHours(i);

                tableLayoutPanelAvailability.Controls.Add(uctime, 0, i);
            }


            //Fill panels
            for (int j = 1; j < 8; j++)//column
            {
                for (int i = 0; i < 24; i++)//row
                {
                    Panel panel = new Panel();
                    //Properties
                    panel.Dock = DockStyle.Fill;
                    panel.BackColor = Color.White;
                    panel.Cursor = Cursors.Hand;
                    panel.Margin = new Padding(2, 2, 2, 2);

                    //Events
                    panel.Click += panel1_Click;
                    panel.MouseMove += panel1_MouseMove;
                    panel.MouseLeave += panel1_MouseLeave;


                    tableLayoutPanelAvailability.Controls.Add(panel, j, i);
                }
            }
        }
        private void AvailabilityLayout_Load(object sender, EventArgs e)
        {
            //SCROLL:
            tableLayoutPanelAvailability.rowHeight = tableLayoutPanelAvailability.GetRowHeights()[0];
            tableLayoutPanelAvailability.AutoScrollPosition = new Point(0, (tableLayoutPanelAvailability.rowHeight * 6)-2);
            tableLayoutPanelAvailability.currentRow = 6;//for weel and touch scroll reason


            PreviousValue = (tableLayoutPanelAvailability.currentRow) * (tableLayoutPanelAvailability.rowHeight);
            FutureValue = (tableLayoutPanelAvailability.currentRow + 1) * (tableLayoutPanelAvailability.rowHeight);

            VScrollBar1.Minimum = tableLayoutPanelAvailability.VerticalScroll.Minimum;
            VScrollBar1.Maximum = tableLayoutPanelAvailability.VerticalScroll.Maximum;
            VScrollBar1.Value = tableLayoutPanelAvailability.VerticalScroll.Value;
            VScrollBar1.LargeChange = tableLayoutPanelAvailability.VerticalScroll.LargeChange;
            VScrollBar1.SmallChange = 165;

            tableLayoutPanelAvailability.VerticalScrollBarTable = VScrollBar1;

            //TestScroll:
            Console.WriteLine("Value: " + this.VerticalScroll.Value + "\nMax= " + this.VerticalScroll.Maximum + "\n");

            new TouchScroll(tableLayoutPanelAvailability, this, VScrollBar1);
        }



        //FUNCTION:
        public void AvailibilitySpecificEmployee(UCEmployee ucemployee)
        {
            UCemployee = ucemployee;

            //SCROLL:
            tableLayoutPanelAvailability.VerticalScroll.Value = tableLayoutPanelAvailability.rowHeight * 6;

            //Getting The name:
            labelfullname.Text = UCemployee.Fullname;


            string[] HoursOfTheday = UCemployee.Availability.Split('/');//each cell has the hours of the day for exemple day Monday cell[0] Sunday cell[6]...
            for (int i = 1; i < 8; i++)
            {
                string HoursOfThisday = HoursOfTheday[i - 1];//First Monday as 0
                if (HoursOfThisday == "")//mafi availibility aa hal nhar kell lpanels white
                {
                    for (int j = 0; j < 24; j++)
                    {
                        var control = tableLayoutPanelAvailability.GetControlFromPosition(i, j); // Replace YourUserControl with the actual UserControl type
                        control.BackColor = Color.White;
                    }
                }
                else
                {
                    int K = 0;
                    string[] EachHour = HoursOfThisday.Split('-');
                    for (int j = 0; j < 24; j++)
                    {
                        if (K != EachHour.Length)
                        {
                            if (EachHour[K] == j.ToString())//EZA ken zet number of hours ha cell ha tdawe
                            {
                                var control = tableLayoutPanelAvailability.GetControlFromPosition(i, j); // Replace YourUserControl with the actual UserControl type
                                control.BackColor = ActiveColor;
                                K++;//exemple each hour: 3-5-6
                            }
                            else
                            {
                                var control = tableLayoutPanelAvailability.GetControlFromPosition(i, j); // Replace YourUserControl with the actual UserControl type
                                control.BackColor = DisactiveColor;
                            }
                        }
                        else
                        {
                            var control = tableLayoutPanelAvailability.GetControlFromPosition(i, j); // Replace YourUserControl with the actual UserControl type
                            control.BackColor = DisactiveColor;
                        }

                    }
                }
            }
        }



        //EVENT:
        ///-CLICK
        public void panel1_Click(object sender, EventArgs e)
        {
            if (TouchScroll.MoveHoldClick == false)
            {
                Panel panel = sender as Panel;
                if (panel.BackColor == ActiveColor)
                {
                    panel.BackColor = DisactiveColor;
                }
                else
                {
                    panel.BackColor = ActiveColor;

                }
            }
            else
            {

            }

        }
        private void buttonD_Click(object sender, EventArgs e)
        {
            //getting the old availability
            string oldavailability = UCemployee.Availability;

            //it's a reset
            UCemployee.Availability = "";

            //i is a reference for the days: Monday...
            for (int i = 1; i < 8; i++)
            {
                //j is a reference for the hours of the day
                for (int j = 0; j < 24; j++)
                {
                    //Getting the active hours of the day
                    var control = tableLayoutPanelAvailability.GetControlFromPosition(i, j); // Replace YourUserControl with the actual UserControl type
                    if (control.BackColor == ActiveColor)
                    {
                        UCemployee.Availability += j.ToString() + "-";
                    }
                    else
                    {

                    }

                }
                if (UCemployee.Availability == "")//none hours
                {

                }
                else if (UCemployee.Availability[UCemployee.Availability.Length - 1] == '-')//Exemple: 1-2-4-6- so we will have to substract (-)
                {
                    UCemployee.Availability = UCemployee.Availability.Substring(0, UCemployee.Availability.Length - 1);
                }
                else//se3eta ma bi shil / fabyotla3 Monday//Thuesday
                {

                }
                UCemployee.Availability += "/";
            }

            //result:7-8/8//8-9/9-10/8-9-10-11/   (from 0 to 6 like from Monday to Sunday)
            UCemployee.Availability = UCemployee.Availability.Substring(0, UCemployee.Availability.Length - 1);

            //Checking if the availibibility has changed if yes then we have to update SQL and the 2 datatables: the originale and the copy
            if (oldavailability != UCemployee.Availability)
            {
                //SQL:
                ProjectToSql.UpdateEmployeeAvailabilitySQL(UCemployee.Availability_id, UCemployee.Availability);

                //UPDATE DataTableEmployeeavailability
                foreach (DataRow row in UCemployee.employees.schedule.ucday.DataTableEmployeeavailability.Rows)
                {
                    if ((int)row["availability_id"] == UCemployee.Availability_id)
                    {
                        row["availability"] = UCemployee.Availability;
                    }
                }

                //UPDATE DataTableEmployeeavailabilityCopy
                foreach (DataRow row in UCemployee.employees.DataTableEmployeeavailabilityCopy.Rows)
                {
                    if ((int)row["availability_id"] == UCemployee.Availability_id)
                    {
                        row["availability"] = UCemployee.Availability;
                    }
                }

                //Then We have to change the design of TLP because the employee is in the TLP
                if (UCemployee.IsChecked == true)
                {
                    //Design So we have to just cahnge the availibility of the column
                    int dayOfWeekInt = ((int)UCemployee.employees.schedule.ucday.DateUCDay.DayOfWeek + 6) % 7; //0 Monday to 6 Sunday
                    var query = from row in UCemployee.employees.schedule.ucday.DataTableEmployeeavailability.AsEnumerable()
                                where row.Field<int>("employee_id") == UCemployee.Employee_id
                                select row.Field<string>("availability");

                    string availibility = query.First();
                    string[] HoursOfThedays = availibility.Split('/');
                    string[] HoursOfTheday = HoursOfThedays[dayOfWeekInt].Split('-');
                    UCemployee.employees.schedule.ucday.AvailibilityColumnChanged(UCemployee.Rank, HoursOfTheday);//The Rank have the same number of with column the employee is in
                }
            }
            this.Close();
        }

        ///-SCROLL
        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (VScrollBar1.Value < PreviousValue || VScrollBar1.Value > FutureValue)
            {
                if (VScrollBar1.Value <= PreviousValue)
                {
                    tableLayoutPanelAvailability.currentRow = Math.Max(0, tableLayoutPanelAvailability.currentRow - 1);
                }
                else
                {
                    tableLayoutPanelAvailability.currentRow = Math.Min(tableLayoutPanelAvailability.RowCount - tableLayoutPanelAvailability.GetVisibleRowsCount(), tableLayoutPanelAvailability.currentRow + 1);
                }


                PreviousValue = (tableLayoutPanelAvailability.currentRow) * (tableLayoutPanelAvailability.rowHeight);
                int newValue = tableLayoutPanelAvailability.currentRow * tableLayoutPanelAvailability.rowHeight;
                FutureValue = (tableLayoutPanelAvailability.currentRow + 1) * (tableLayoutPanelAvailability.rowHeight);


                tableLayoutPanelAvailability.AutoScroll = false;
                tableLayoutPanelAvailability.VerticalScroll.Value = Math.Min(newValue, tableLayoutPanelAvailability.VerticalScroll.Maximum);//the maximum value is autotaken when autoscroll is on, if not we need to initialise it awwal shi, 
                tableLayoutPanelAvailability.AutoScroll = true;
                Console.WriteLine("Value: " + tableLayoutPanelAvailability.VerticalScroll.Value + "\nValueCust: " + VScrollBar1.Value + "\nMax= " + tableLayoutPanelAvailability.VerticalScroll.Maximum + "\nMaxCust " + VScrollBar1.Maximum + "\n");
            }
        }
        private void tableLayoutPanelAvailability_SizeChanged(object sender, EventArgs e)
        {
            VScrollBar1.LargeChange = tableLayoutPanelAvailability.VerticalScroll.LargeChange;
        }



        //DESIGN:
        public void panel1_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel.BackColor != ActiveColor)
            {
                panel.BackColor = DisactiveColor;
            }
        }
        public void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TouchScroll.MoveHoldClick == false)
            {
                Panel panel = sender as Panel;
                if (panel.BackColor != ActiveColor)
                {
                    panel.BackColor = Color.FromArgb(229, 226, 244);
                }
            }
            else
            {

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}

