using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CustomizedTools;


namespace MKproject.Management
{
    public partial class ViewBundlesAndProducts : Form
    {
        public int Bundle_ID;
        public int Product_ID;
        public bool ButtonBundleClicked;
        public DataTable dtBundles;
        public DataTable dtProducts;

        public ViewBundlesAndProducts()
        {
            InitializeComponent();

            SetUCSlidebutton();
            LoadInfo();
            ucSlideButtonBundleProduct.button1_Click(this, new EventArgs());
        }
        private void ViewBundlesAndProducts_Load(object sender, EventArgs e)
        {
            dataGridViewEdit.ClearSelection();
        }

        public void LoadInfo()
        {

            dtBundles = ClassBundles.RetrieveAllBundle();
            FormatdtBundles(dtBundles);

            dtProducts = ClassProduct.RetrieveAllProducts();
            FormatdtProducts(dtProducts);


            //since it for both cases w mesh kell marra band naamela set la hole kell ma nbaddil ben products w bundles
            dataGridViewEdit.RowTemplate.MinimumHeight = 40; // Set minimum row height
            dataGridViewEdit.DefaultCellStyle.WrapMode = DataGridViewTriState.True;


        }//try catch


        public void FormatdtBundles(DataTable dt)
        {
            dt.Columns.Add("Bundle", typeof(string));
            dt.Columns.Add("FakeMemberShip", typeof(string));
            dt.Columns.Add("FakeStatus", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                //
                string bundle = row["sessions_numb"].ToString() + " " + row["bundle_type"].ToString();
                row["Bundle"] = bundle;
                //
                if ((bool)row["is_member_ship"] == true)
                {
                    row["FakeMemberShip"] = "True";
                }
                else
                {
                    row["FakeMemberShip"] = "False";
                }

                if ((bool)row["status"] == true)
                {
                    row["FakeStatus"] = "True";
                }
                else
                {
                    row["FakeStatus"] = "False";
                }
            }

            //ordering
            int columnIndexToMove;
            int newIndex;

            columnIndexToMove = dt.Columns.IndexOf("bundle_name"); // Replace with the actual column name
            newIndex = 0; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);


            columnIndexToMove = dt.Columns.IndexOf("Bundle"); // Replace with the actual column name
            newIndex = 1; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);



            columnIndexToMove = dt.Columns.IndexOf("description"); // Replace with the actual column name
            newIndex = 2; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);


            columnIndexToMove = dt.Columns.IndexOf("price"); // Replace with the actual column name
            newIndex = 3; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = dt.Columns.IndexOf("FakeMemberShip"); // Replace with the actual column name
            newIndex = 4; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);


            columnIndexToMove = dt.Columns.IndexOf("FakeStatus"); // Replace with the actual column name
            newIndex = 5; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);



        }
        public void FormatDatagridViewBundles()
        {
            // Clear the existing columns added through DataSource (excluding "Edit" button column)
            for (int i = dataGridViewEdit.Columns.Count - 1; i >= 0; i--)
            {
                if (dataGridViewEdit.Columns[i].Name != "Edit")
                {
                    dataGridViewEdit.Columns.RemoveAt(i);
                }
            }

            dataGridViewEdit.DataSource = dtBundles;

            foreach (DataGridViewColumn col in dataGridViewEdit.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            // Hide the "PriceNoCurrency" column by referencing its name
            //
            dataGridViewEdit.Columns["bundle_type"].Visible = false;
            dataGridViewEdit.Columns["sessions_numb"].Visible = false;
            dataGridViewEdit.Columns["bundle_id"].Visible = false;
            dataGridViewEdit.Columns["Currency_Name"].Visible = false;
            dataGridViewEdit.Columns["is_member_ship"].Visible = false;
            dataGridViewEdit.Columns["status"].Visible = false;
            dataGridViewEdit.Columns["Edit"].DisplayIndex = dtBundles.Columns.Count;

            dataGridViewEdit.Columns["bundle_name"].HeaderCell.Value = "Service Name";
            dataGridViewEdit.Columns["Bundle"].HeaderCell.Value = "Service Type";
            dataGridViewEdit.Columns["description"].HeaderCell.Value = "Description";
            dataGridViewEdit.Columns["FakeMemberShip"].HeaderCell.Value = "MemberShip";
            dataGridViewEdit.Columns["FakeStatus"].HeaderCell.Value = "Status";
            dataGridViewEdit.Columns["price"].HeaderCell.Value = "Price";

            dataGridViewEdit.Columns["FakeMemberShip"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewEdit.Columns["FakeMemberShip"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewEdit.Columns["FakeStatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewEdit.Columns["FakeStatus"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewEdit.Columns["Edit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewEdit.ApplyStyle1();
            dataGridViewEdit.ClearSelection();
            FixDisplayingCells();
        }

        public void FormatdtProducts(DataTable dt)
        {
            dt.Columns.Add("FakeStatus", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                if ((bool)row["status"] == true)
                {
                    row["FakeStatus"] = "True";
                }
                else
                {
                    row["FakeStatus"] = "False";
                }
            }

            int columnIndexToMove;
            int newIndex;

            columnIndexToMove = dt.Columns.IndexOf("product_name"); // Replace with the actual column name
            newIndex = 0; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);


            columnIndexToMove = dt.Columns.IndexOf("product_price"); // Replace with the actual column name
            newIndex = 1; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);


            columnIndexToMove = dt.Columns.IndexOf("FakeStatus"); // Replace with the actual column name
            newIndex = 2; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);


        }
        public void FormatDatagridViewProducts()
        {
            for (int i = dataGridViewEdit.Columns.Count - 1; i >= 0; i--)
            {
                if (dataGridViewEdit.Columns[i].Name != "Edit")
                {
                    dataGridViewEdit.Columns.RemoveAt(i);
                }
            }

            dataGridViewEdit.DataSource = dtProducts;

            foreach (DataGridViewColumn col in dataGridViewEdit.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }



            dataGridViewEdit.Columns["product_id"].Visible = false;  
            dataGridViewEdit.Columns["Currency_Name"].Visible = false;
            dataGridViewEdit.Columns["status"].Visible = false;
            dataGridViewEdit.Columns["Edit"].DisplayIndex = dtProducts.Columns.Count;

            dataGridViewEdit.Columns["product_name"].HeaderCell.Value = "Product Name";
            dataGridViewEdit.Columns["FakeStatus"].HeaderCell.Value = "Status";
            dataGridViewEdit.Columns["product_price"].HeaderCell.Value = "Price";

            dataGridViewEdit.Columns["FakeStatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewEdit.Columns["Edit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewEdit.ApplyStyle1();
            dataGridViewEdit.ClearSelection();
            FixDisplayingCells();
        }



        private void dataGridViewEdit_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //for both table bundles and product , so make sure that the status same in db
            //Text Display
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.Value == DBNull.Value || string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.Value = "N/A";
                }
                else
                {
                    if (dataGridViewEdit.Columns[e.ColumnIndex].Name == "price")
                    {
                        e.Value =Program.SetCashFormat(e.Value.ToString());
                    }
                    if (dataGridViewEdit.Columns[e.ColumnIndex].Name == "product_price")
                    {
                        e.Value = Program.SetCashFormat(e.Value.ToString());
                    }
                }
                //Design Display
                if (dataGridViewEdit.Columns[e.ColumnIndex].Name == "FakeStatus")
                {

                    DataGridViewCell cell = dataGridViewEdit.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (Convert.ToString(cell.Value) == "False")
                    {
                        cell.Style.ForeColor = Color.Red;
                        cell.Style.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        cell.Style.ForeColor = Color.Green;
                        cell.Style.SelectionForeColor = Color.Green;
                    }
                }
            }
        }
        //performance wise, cz we know aal visible on w flase eza displaycell kenit byekhdo waet
        void FixDisplayingCells()
        {
            dataGridViewEdit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEdit.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

        }
        void RuinDisplayingCells()
        {
            dataGridViewEdit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewEdit.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }


        void SetUCSlidebutton()
        {


            ucSlideButtonBundleProduct.Button1Clicked += UcSlideButtonBundleProduct_Button1Clicked;
            ucSlideButtonBundleProduct.Button2Clicked += UcSlideButtonBundleProduct_Button2Clicked;

            ucSlideButtonBundleProduct.button1.Text = "Services";
            ucSlideButtonBundleProduct.button2.Text = "Products";
        }
        private void UcSlideButtonBundleProduct_Button2Clicked(object sender, EventArgs e)
        {
            if (ButtonBundleClicked)
            {
                RuinDisplayingCells();
                FormatDatagridViewProducts();
                buttonAdd.Text = "Add Product";
                ButtonBundleClicked = false;
            }

        }
        private void UcSlideButtonBundleProduct_Button1Clicked(object sender, EventArgs e)
        {
            if (!ButtonBundleClicked)
            {
                RuinDisplayingCells();
                FormatDatagridViewBundles();
                buttonAdd.Text = "Add services";
                ButtonBundleClicked = true;
            }
        }


        private void dataGridViewEdit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridViewEdit.Columns[e.ColumnIndex].Name == "Edit")//this condition aal name tabaa el column mesh el text
                {
                    DataGridViewRow selectedRow = dataGridViewEdit.Rows[e.RowIndex];
                    if (ButtonBundleClicked)
                    {
                        Bundle_ID = Convert.ToInt32(selectedRow.Cells["bundle_id"].Value);

                        DataRow[] rows = dtBundles.Select("bundle_id =" + Bundle_ID);
                        DataRow desiredRow = null;
                        if (rows.Length > 0)//wwe re we re going to have 1 row
                        {
                            desiredRow = rows[0];
                        }

                        Program.GreyForm = new GreyColor((Form)this.Tag, true, false);
                        Program.GreyForm.Show();
                        EditBundleProduct editform = new EditBundleProduct(true, true, desiredRow);
                        editform.ParentFormViewBundle = this;
                        editform.ShowDialog();
                    }
                    else
                    {
                        Product_ID = Convert.ToInt32(selectedRow.Cells["product_id"].Value);

                        DataRow[] rows = dtProducts.Select("product_id =" + Product_ID);
                        DataRow desiredRow = null;
                        if (rows.Length > 0)//wwe re we re going to have 1 row
                        {
                            desiredRow = rows[0];
                        }


                        Program.GreyForm = new GreyColor((Form)this.Tag, true, false);
                        Program.GreyForm.Show();
                        EditBundleProduct p = new EditBundleProduct(true, false, desiredRow);
                        p.ParentFormViewBundle = this;
                        p.ShowDialog();

                    }
                }
                dataGridViewEdit.ClearSelection();
            }
        }



        private void buttonAdd_Click(object sender, EventArgs e)
        {

            if (ButtonBundleClicked)
            {
                Program.GreyForm = new GreyColor((Form)this.Tag, true, false);
                Program.GreyForm.Show();
                EditBundleProduct p = new EditBundleProduct(false, true, null);
                p.ParentFormViewBundle = this;
                p.ShowDialog();
            }
            else
            {
                Program.GreyForm = new GreyColor((Form)this.Tag, true, false);
                Program.GreyForm.Show();
                EditBundleProduct p = new EditBundleProduct(false, false, null);
                p.ParentFormViewBundle = this;
                p.ShowDialog();
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


    }
}
