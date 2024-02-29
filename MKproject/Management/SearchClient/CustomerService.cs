using GlobalFunctions;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class CustomerService : Form
    {

        public SearchCurrentClient ParentFormSearch { get; set; }
        Label LabelNoDataRecordedBirthday;
        private DataTable Birthdt;



        public CustomerService()
        {
            InitializeComponent();

            LoadBirthdaysData();

            this.Opacity = 0;
            this.TopMost = true;
        }
        private void CustomerService_Load(object sender, EventArgs e)
        {
            FormatBirthDatagridViewDesign();
            dataGridViewBirthClients.ClearSelection();
        }




        //birthdays
        void CreatingTheNoDataLabelBirthday()
        {
            LabelNoDataRecordedBirthday = new Label();
            // Set the label properties
            LabelNoDataRecordedBirthday.Text = "No Client's Bithdays Soon";
            LabelNoDataRecordedBirthday.Font = new System.Drawing.Font("Segoe UI", 17, FontStyle.Italic);
            LabelNoDataRecordedBirthday.ForeColor = Color.LightGray;
            LabelNoDataRecordedBirthday.BackColor = Color.White;
            LabelNoDataRecordedBirthday.TextAlign = ContentAlignment.MiddleCenter;
            LabelNoDataRecordedBirthday.AutoSize = false;
            LabelNoDataRecordedBirthday.Dock = DockStyle.Fill;
            LabelNoDataRecordedBirthday.Padding = new Padding(0, 0, 0, 0);
        }
        void LoadBirthdaysData()
        {
            Birthdt = ClassClient.GetSoonBirthdaysSQL();
            SetDatagridMode();
        }
        void FormatBirthdt()
        {
            Birthdt.Columns.Add("DaysLeft", typeof(string));//used only fpr sorting
            Birthdt.Columns.Add("Days till Birthday", typeof(string));
            Birthdt.Columns.Add("Up coming Age", typeof(int));
            Birthdt.Columns.Add("FakeBirthday", typeof(string));




            DateTime birthDate;
            DateTime today = DateTime.Today;
            DateTime nextBirthday;

            foreach (DataRow row in Birthdt.Rows)
            {

                birthDate = (DateTime)row["Birthday"];
                nextBirthday = new DateTime(today.Year, birthDate.Month, birthDate.Day);

                if (nextBirthday < today)
                {
                    nextBirthday = new DateTime(today.Year + 1, birthDate.Month, birthDate.Day);
                }

                int daysTillBirthday = (nextBirthday - today).Days;

                row["DaysLeft"] = daysTillBirthday;
                if (daysTillBirthday > 1)
                {
                    row["Days till Birthday"] = daysTillBirthday + " days left";

                }
                else if (daysTillBirthday == 1)
                {
                    row["Days till Birthday"] = daysTillBirthday + " day left";
                }
                else
                {
                    row["Days till Birthday"] = "Today";
                }


                row["FakeBirthday"] = RandomFunctions.SetDateFormatWithDayWithoutHour(row["Birthday"].ToString());

                row["Up coming Age"] = RandomFunctions.AgeCalculator(Convert.ToDateTime(row["Birthday"])) + 1;
            }

            //DataView sortedView = Birthdt.DefaultView;
            //sortedView.Sort = "DaysLeft ASC";
            //Birthdt = sortedView.ToTable();


            int columnIndexToMove;
            int newIndex;

            columnIndexToMove = Birthdt.Columns.IndexOf("Name"); // Replace with the actual column name
            newIndex = 0; // The new desired index
            Birthdt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = Birthdt.Columns.IndexOf("Days till Birthday"); // Replace with the actual column name
            newIndex = 1; // The new desired index
            Birthdt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = Birthdt.Columns.IndexOf("Up coming Age"); // Replace with the actual column name
            newIndex = 2; // The new desired index
            Birthdt.Columns[columnIndexToMove].SetOrdinal(newIndex);


            columnIndexToMove = Birthdt.Columns.IndexOf("FakeBirthday"); // Replace with the actual column name
            newIndex = 3; // The new desired index
            Birthdt.Columns[columnIndexToMove].SetOrdinal(newIndex);


        }

        void FormatBirthDatagridView()
        {
            foreach (DataGridViewColumn col in dataGridViewBirthClients.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridViewBirthClients.ApplyStyle1();

            dataGridViewBirthClients.Columns["ID"].Visible = false;
            dataGridViewBirthClients.Columns["Birthday"].Visible = false;
            dataGridViewBirthClients.Columns["DaysLeft"].Visible = false;

            dataGridViewBirthClients.Columns["FakeBirthday"].HeaderCell.Value = "Birthdate";

            dataGridViewBirthClients.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewBirthClients.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewBirthClients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;//kermel taamil stretch aa kell surface  horizontally
            dataGridViewBirthClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//kermel taamil stretch aa kell surface  horizontally
            dataGridViewBirthClients.RowTemplate.MinimumHeight = 40; // Set minimum row height

            dataGridViewBirthClients.Columns["Name"].FillWeight = 30;
            dataGridViewBirthClients.Columns["Days till Birthday"].FillWeight = 20;
            dataGridViewBirthClients.Columns["Up coming Age"].FillWeight = 20;
            dataGridViewBirthClients.Columns["FakeBirthday"].FillWeight = 30;






        }
        void FormatBirthDatagridViewDesign()
        {
            foreach (DataGridViewRow row in dataGridViewBirthClients.Rows)
            {
                DataGridViewCell cellDaysLeft = (DataGridViewCell)row.Cells["DaysLeft"];
                DataGridViewCell cell = (DataGridViewCell)row.Cells["Days till Birthday"];
                if (Convert.ToInt16(cellDaysLeft.Value) == 0)
                {
                    cell.Style.ForeColor = Color.Red;
                    cell.Style.SelectionForeColor = Color.Red;
                }
                else if (Convert.ToInt16(cellDaysLeft.Value) == 1)
                {
                    cell.Style.ForeColor = Color.Orange;
                    cell.Style.SelectionForeColor = Color.Orange;

                }
                else
                {
                    cell.Style.ForeColor = Color.Green;
                    cell.Style.SelectionForeColor = Color.Green;

                }

            }
        }


        void SetDatagridMode()
        {
            if (Birthdt.Rows.Count > 0)
            {
                //kermel l LabelNoDataRecorded
                if (TLPBirthday.Controls.Contains(LabelNoDataRecordedBirthday))
                {
                    LabelNoDataRecordedBirthday.Hide();
                    TLPBirthday.Controls.Remove(LabelNoDataRecordedBirthday);
                }
                dataGridViewBirthClients.Visible = true;


                FormatBirthdt();
                dataGridViewBirthClients.DataSource = Birthdt;
                FormatBirthDatagridView();
            }
            else
            {

                CreatingTheNoDataLabelBirthday();
                dataGridViewBirthClients.Visible = false;
                TLPBirthday.Controls.Remove(LabelNoDataRecordedBirthday);
                LabelNoDataRecordedBirthday.Show();
                TLPBirthday.SetColumnSpan(LabelNoDataRecordedBirthday, 2);
                TLPBirthday.Controls.Add(LabelNoDataRecordedBirthday, 0, 1);

            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
                this.Select();
            }
            Opacity += .1;
        }

        private void dataGridViewBirthClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                object idValue = dataGridViewBirthClients.Rows[e.RowIndex].Cells["ID"].Value;

                if (idValue != DBNull.Value)
                {
                    int id = Convert.ToInt32(idValue);
                    ParentFormSearch.FocusOnADesiredRow(id);
                    this.Close();
                }
            }
        }


        private void CustomerService_Deactivate(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                this.Close();
            }
        }

        private void CustomerService_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }


    }
}
