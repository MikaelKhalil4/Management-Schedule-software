using GlobalFunctions;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace MKproject.Management
{
    public partial class UCBundlesOutput : UserControl
    {
        public BuyBundleOrProudct ParentFormBuy { get; set; }


        public UCBundlesOutput()
        {
            InitializeComponent();
            FillDataGrid();
        }

        String StringMembership = "MemberShip", StringNotMembership = "Not MemberShip";

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

        private void dataGridViewBundles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int BundleId = Convert.ToInt16(dataGridViewBundles.Rows[e.RowIndex].Cells["BundleID"].Value);
            string BundleName = dataGridViewBundles.Rows[e.RowIndex].Cells["BundleName"].Value.ToString();
            string Description = dataGridViewBundles.Rows[e.RowIndex].Cells["Description"].Value.ToString();

            int? SessionNumber;

            if (dataGridViewBundles.Rows[e.RowIndex].Cells["bundletype"].Value.ToString() != ClassBundles.bundle.Solo.ToString())
            {
                SessionNumber = Convert.ToInt16(RandomFunctions.ExtractDigits(Convert.ToString(dataGridViewBundles.Rows[e.RowIndex].Cells["SessionNumber"].Value)));
            }
            else//eza kenit solo
            {
                SessionNumber = null;
            }

            string bundletype = dataGridViewBundles.Rows[e.RowIndex].Cells["bundletype"].Value.ToString();
            double price = Convert.ToDouble(RandomFunctions.ExtractDigits(Convert.ToString(dataGridViewBundles.Rows[e.RowIndex].Cells["price"].Value)));
            bool isMemerShip;
            if (dataGridViewBundles.Rows[e.RowIndex].Cells["Membership"].Value.ToString() == StringMembership)
            {
                isMemerShip = true;
            }
            else
            {
                isMemerShip = false;
            }


            if (Convert.ToBoolean(dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value) == false)
            {
                dataGridViewBundles.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 226, 244);
                dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value = true;
                dataGridViewBundles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(229, 226, 244);

                //List
                ClassBundles Bundle = new ClassBundles();
                Bundle.ID = BundleId;
                Bundle.Name = BundleName;
                Bundle.Description = Description;
                Bundle.Price = price;
                Bundle.SessionDaysNumber = SessionNumber;//could be null or a value
                Bundle.IsMemberShip = isMemerShip;
                Bundle.Qty = 1;
                //
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
                //Design
                ParentFormBuy.AddItem(Bundle, null);

            }
            else if (Convert.ToBoolean(dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value) == true)
            {
                dataGridViewBundles.RowsDefaultCellStyle.SelectionBackColor = Color.White;
                dataGridViewBundles.Rows[e.RowIndex].Cells["ColumnCheck"].Value = false;
                dataGridViewBundles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                //design
                ParentFormBuy.RemoveButton(BundleId, price);
                //list
                ParentFormBuy.BundleList.RemoveAll(p => p.ID == BundleId);
            }


        }

       


    }
}
