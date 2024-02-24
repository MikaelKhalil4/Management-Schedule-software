using GlobalFunctions;
using MKproject.Schedule;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static MKproject.Management.ClassBundles;


namespace MKproject.Management
{
    public partial class UCBundlesOutput : UserControl
    {
        public BuyBundleOrProudct ParentFormBuy { get; set; }
        public ChooseService ParentFormChooseService { get; set; }

        public UCBundlesOutput()
        {
            InitializeComponent();

            dataGridViewBundles.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 226, 244);
            DataTable dtBundle = ClassBundles.RetrieveAllBundleStatusOn();
            FormatdtBundles(dtBundle);
            FormatDatagridViewBundles(dtBundle);
        }

        String StringMembership = "MemberShip", StringNotMembership = "Not MemberShip";

        public void FormatdtBundles(DataTable dt)
        {
            dt.Columns.Add("ColumnCheck", typeof(bool));
            dt.Columns.Add("Membership", typeof(string));
            dt.Columns.Add("FakePrice", typeof(string));
            dt.Columns.Add("BundleDetails", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                if (row["description"] == DBNull.Value)
                {
                    row["description"] = "N/A";
                }
                else
                {
                    row["description"] = row["description"].ToString();
                }

                if ((bool)row["is_member_ship"] == true)
                {
                    row["Membership"] = StringMembership;
                }
                else
                {
                    row["Membership"] = StringNotMembership;
                }

                row["ColumnCheck"] = false;
                row["FakePrice"] = Currency.Symbol + row["price"];
                row["BundleDetails"] = row["sessions_numb"] + " " + row["bundle_type"];
            }

            //ordering
            int columnIndexToMove;
            int newIndex;


            columnIndexToMove = dt.Columns.IndexOf("ColumnCheck"); // Replace with the actual column name
            newIndex = 0; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = dt.Columns.IndexOf("bundle_name"); // Replace with the actual column name
            newIndex = 1; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = dt.Columns.IndexOf("description"); // Replace with the actual column name
            newIndex = 2; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);


            columnIndexToMove = dt.Columns.IndexOf("BundleDetails"); // Replace with the actual column name
            newIndex = 3; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);

          
            columnIndexToMove = dt.Columns.IndexOf("FakePrice"); // Replace with the actual column name
            newIndex = 4; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);


            columnIndexToMove = dt.Columns.IndexOf("Membership"); // Replace with the actual column name
            newIndex = 5; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);
        }
        public void FormatDatagridViewBundles(DataTable dtBundles)
        {
            dataGridViewBundles.DataSource = dtBundles;

            dataGridViewBundles.Columns["price"].Visible = false;
            dataGridViewBundles.Columns["is_member_ship"].Visible = false;
            dataGridViewBundles.Columns["Currency_Name"].Visible = false;
            dataGridViewBundles.Columns["bundle_id"].Visible = false;
            dataGridViewBundles.Columns["sessions_numb"].Visible = false;
            dataGridViewBundles.Columns["status"].Visible = false;
            dataGridViewBundles.Columns["bundle_type"].Visible = false;

            dataGridViewBundles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBundles.RowTemplate.MinimumHeight = 40; // Set minimum row height

            dataGridViewBundles.Columns["Membership"].FillWeight = 20;
            dataGridViewBundles.Columns["ColumnCheck"].FillWeight = 8;
            dataGridViewBundles.Columns["bundle_name"].FillWeight = 22;
            dataGridViewBundles.Columns["BundleDetails"].FillWeight = 22;
            dataGridViewBundles.Columns["FakePrice"].FillWeight = 11;
            dataGridViewBundles.Columns["description"].FillWeight = 15;


        }
        public void FillDataGrid()
        {

            DataTable dt = ClassBundles.RetrieveAllBundleStatusOn();


            // Create UCPackage UserControls based on the data in the DataTable
            foreach (DataRow row in dt.Rows)
            {
                // Get the values from the DataTable row
                int id = Convert.ToInt16(row["bundle_id"]);
                string bundleName = row["bundle_name"].ToString();

                string description;
                if (row["description"] == DBNull.Value)
                {
                    description = "N/A";
                }
                else
                {
                    description = row["description"].ToString();
                }

                string Membership;
                if ((bool)row["is_member_ship"] == true)
                {
                    Membership = StringMembership;
                }
                else
                {
                    Membership = StringNotMembership;
                }
                string sessionsNumber;
                if (row["sessions_numb"] != DBNull.Value)
                {
                    sessionsNumber = row["sessions_numb"].ToString();

                }
                else
                {
                    sessionsNumber = null;
                }

                string bundletype = row["bundle_type"].ToString();
                string price = row["price"].ToString();

                dataGridViewBundles.Rows.Add(false, id, bundleName, description, sessionsNumber + " " + bundletype, bundletype, Currency.Symbol + price, Membership);
            }


        }//try catch

      

        void FillingBundleDetails(DataGridViewRow DesiredRow, ClassBundles Bundle)
        {
            Bundle.ID = Convert.ToInt16(DesiredRow.Cells["bundle_id"].Value);
            Bundle.Name = DesiredRow.Cells["bundle_name"].Value.ToString();
            Bundle.Description = DesiredRow.Cells["description"].Value.ToString();

            if (DesiredRow.Cells["bundle_type"].Value.ToString() != ClassBundles.bundle.Solo.ToString())
            {
                Bundle.SessionDaysNumber = Convert.ToInt16(RandomFunctions.ExtractDigits(Convert.ToString(DesiredRow.Cells["sessions_numb"].Value)));
            }
            else//eza kenit solo
            {
                Bundle.SessionDaysNumber = null;
            }


            Bundle.Price = Convert.ToDouble(RandomFunctions.ExtractDigits(Convert.ToString(DesiredRow.Cells["price"].Value)));

            if (DesiredRow.Cells["Membership"].Value.ToString() == StringMembership)
            {
                Bundle.IsMemberShip = true;
            }
            else
            {
                Bundle.IsMemberShip = false;
            }

            string bundletype = DesiredRow.Cells["bundle_type"].Value.ToString();

            if (bundletype == ClassBundles.bundle.Sessions.ToString())
            {
                Bundle.EnumBundletype = ClassBundles.bundle.Sessions;
            }
            else if (bundletype == ClassBundles.bundle.Days.ToString())
            {
                Bundle.EnumBundletype = ClassBundles.bundle.Days;
            }
            else if (bundletype == ClassBundles.bundle.Solo.ToString())
            {
                Bundle.EnumBundletype = ClassBundles.bundle.Solo;
            }

            Bundle.Qty = 1;
        }
        private void dataGridViewBundles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        DataGridViewRow LastRowSelected;

        private void UCBundlesOutput_Load(object sender, EventArgs e)
        {
            dataGridViewBundles.ClearSelection();
        }

        private void dataGridViewBundles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ParentFormBuy!=null)
            {
               ClassBundles Bundle = new ClassBundles();
                FillingBundleDetails(dataGridViewBundles.Rows[e.RowIndex], Bundle);

                if (Convert.ToBoolean(dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value) == false)
                {
                    dataGridViewBundles.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 226, 244);
                    dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value = true;
                    dataGridViewBundles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(229, 226, 244);
                    //Design
                    ParentFormBuy.AddItem(Bundle, null);

                }
                else if (Convert.ToBoolean(dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value) == true)
                {
                    dataGridViewBundles.RowsDefaultCellStyle.SelectionBackColor = Color.White;
                    dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value = false;
                    dataGridViewBundles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    //design
                    ParentFormBuy.RemoveButton(Bundle.ID, Bundle.Price);
                    //list
                    ParentFormBuy.BundleList.RemoveAll(p => p.ID == Bundle.ID);
                }
            }
            else if(ParentFormChooseService!=null)
            {
                if (Convert.ToBoolean(dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value) == false)
                {
                    dataGridViewBundles.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 226, 244);
                    dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value = true;
                    dataGridViewBundles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(229, 226, 244);
                    if (LastRowSelected != null)
                    {
                        LastRowSelected.DefaultCellStyle.BackColor = Color.White;
                        LastRowSelected.Cells["ColumnCheck"].Value = false;
                    }
                    LastRowSelected = dataGridViewBundles.Rows[e.RowIndex];

                }
                else if (Convert.ToBoolean(dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value) == true)
                {
                    dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value = false;
                    dataGridViewBundles.RowsDefaultCellStyle.SelectionBackColor = Color.White;
                    dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value = false;
                    dataGridViewBundles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }




    }
}
