using GlobalFunctions;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MKproject.Management
{
    public partial class UCProductOutput : UserControl
    {

        public BuyBundleOrProudct ParentFormBuy { get; set; }
        public UCProductOutput()
        {
            InitializeComponent();
            DataTable dt = ClassProduct.RetrieveAllProductsStatusOn();
            FormatdtProducts(dt);
            FormatDatagridViewProducts(dt);
        }
      
        public void FormatdtProducts(DataTable dt)
        {
            dt.Columns.Add("ColumnCheck", typeof(bool));
            foreach (DataRow row in dt.Rows)
            {
                row["ColumnCheck"] = false;
            }
            //ordering
            int columnIndexToMove;
            int newIndex;


            columnIndexToMove = dt.Columns.IndexOf("ColumnCheck"); // Replace with the actual column name
            newIndex = 0; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = dt.Columns.IndexOf("product_name"); // Replace with the actual column name
            newIndex = 1; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);

            columnIndexToMove = dt.Columns.IndexOf("product_price"); // Replace with the actual column name
            newIndex = 2; // The new desired index
            dt.Columns[columnIndexToMove].SetOrdinal(newIndex);

        }
        public void FormatDatagridViewProducts(DataTable dt)
        {
            dataGridViewProducts.DataSource = dt;

            dataGridViewProducts.Columns["product_id"].Visible = false;
            dataGridViewProducts.Columns["Currency_Name"].Visible = false;
            dataGridViewProducts.Columns["status"].Visible = false;


            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProducts.RowTemplate.MinimumHeight = 40; // Set minimum row height

            dataGridViewProducts.Columns["product_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewProducts.Columns["product_price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewProducts.Columns["ColumnCheck"].FillWeight = 10;
        }
        private void dataGridViewProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dataGridViewProducts.Rows.Count && e.ColumnIndex < dataGridViewProducts.Columns.Count)
            {
                if (e.Value == DBNull.Value || string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.Value = "N/A";
                }
                else
                {
                    if (dataGridViewProducts.Columns[e.ColumnIndex].Name == "product_price")
                    {
                        e.Value =Program.SetCashFormat(e.Value.ToString());
                    }
                }
            }
        }



        private void dataGridViewProducts_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ProductID = Convert.ToInt32(dataGridViewProducts.Rows[e.RowIndex].Cells["product_id"].Value);
            string ProductName = dataGridViewProducts.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
            double price = Convert.ToDouble(RandomFunctions.ExtractDigits(Convert.ToString(dataGridViewProducts.Rows[e.RowIndex].Cells["product_price"].Value)));


            if (Convert.ToBoolean(dataGridViewProducts.Rows[e.RowIndex].Cells["ColumnCheck"].Value) == false)
            {
                dataGridViewProducts.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 226, 244);
                dataGridViewProducts.Rows[e.RowIndex].Cells["ColumnCheck"].Value = true;
                dataGridViewProducts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(229, 226, 244);


                //List
                ClassProduct product = new ClassProduct();
                product.ID = ProductID;
                product.Name = ProductName;
                product.Price = price;
                product.Qty = 1;
                //Design
                ParentFormBuy.AddItem(null, product);

            }
            else if (Convert.ToBoolean(dataGridViewProducts.Rows[e.RowIndex].Cells["ColumnCheck"].Value) == true)
            {
                dataGridViewProducts.RowsDefaultCellStyle.SelectionBackColor = Color.White;
                dataGridViewProducts.Rows[e.RowIndex].Cells["ColumnCheck"].Value = false;
                dataGridViewProducts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                //Design
                ParentFormBuy.RemoveButton(ProductID, price);

                //list
                ParentFormBuy.ProductList.RemoveAll(p => p.ID == ProductID);
            }

        }
    }
}
