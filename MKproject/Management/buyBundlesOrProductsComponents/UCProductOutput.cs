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
            FillDataGrid();
        }
        public void FillDataGrid()
        {

            DataTable dt = ClassProduct.RetrieveAllProductsStatusOn();


            // Create UCPackage UserControls based on the data in the DataTable
            foreach (DataRow row in dt.Rows)
            {
                // Get the values from the DataTable row
                int id = Convert.ToInt16(row["product_id"]);
                string productsName = row["product_name"].ToString();
                string price = row["product_price"].ToString();
                dataGridViewProducts.Rows.Add(false, id, productsName, Currency.Symbol + price);
            }


        }//try catch

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ProductID = Convert.ToInt16(dataGridViewProducts.Rows[e.RowIndex].Cells["ProductId"].Value);
            string ProductName = dataGridViewProducts.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();         
            double price = Convert.ToDouble(RandomFunctions.ExtractDigits(Convert.ToString(dataGridViewProducts.Rows[e.RowIndex].Cells["price"].Value)));
          

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
                ParentFormBuy.RemoveButton(ProductID,price);

                //list
                ParentFormBuy.ProductList.RemoveAll(p => p.ID == ProductID);
            }
        }
    }
}
