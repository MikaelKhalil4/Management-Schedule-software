using System;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Data.SQLite;

namespace MKproject.Management
{
    public class ClassProduct
    {
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);
        public int ID { get; set; }
        private string name;

        public string Name
        {
            get { return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower()); }
            set { name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()); }
        }

  
        public Double Price { get; set; }
        public bool Status { get; set; }
        public int Qty { get; set; }//only used lamma badde eshtere item 

      
        //product
        public static double FindProductDetails(int categoryId)
        {

            string query = "Select product_price From products WHERE  product_id='" + categoryId + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);


            // Return the results as a tuple
            return (Convert.ToDouble(dt.Rows[0]["product_price"]));
        }
        public static string FindProductName(int categoryId)
        {
            string ProuctName = "Not Accessible";

            string query = "Select product_name From products WHERE  product_id='" + categoryId + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);


            // Return the results as a tuple
            return (dt.Rows[0]["product_name"].ToString());
        }
        public static DataTable GetLastInsertProduct()
        {
            string Query = "Select * from products where  product_id=(Select MAX(product_id) from products)";
            SQLiteCommand cmd = new SQLiteCommand(Query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable RetrieveAllProductsStatusOn()
        {
            string query = "Select * From products where status=1 ORDER by product_id Desc";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable RetrieveAllProducts()
        {
            string query = "Select * From products ORDER by status Desc, product_id Desc";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }



        public void InsertProduct()
        {
            string query = "INSERT INTO products (product_name,product_price,status) " +
                           "VALUES (@ProductName, @Price,@Status)";

            SQLiteCommand command = new SQLiteCommand(query, con);
            command.Parameters.AddWithValue("@ProductName", Name);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Status", Status);
            con.Open();

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Product added successfully.");
            }

            con.Close();
        }
        public void UpdateProduct()
        {
            string query = "UPDATE products " +
               "SET product_name = @ProductName, " +
               "product_price = @Price, " +
               "status = @Status " +
               "WHERE product_id = @ProductID";

            // Create a SQL command with parameters
            SQLiteCommand command = new SQLiteCommand(query, con);
            command.Parameters.AddWithValue("@ProductName", Name);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@ProductID", ID);

            // Open the connection
            con.Open();

            // Execute the SQL query to update the bundle
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Product updated successfully.");
            }

            // Close the connection
            con.Close();
        }
        public void DeleteProducts()
        {

            SQLiteCommand cmd = new SQLiteCommand("Delete FROM  products where product_id='" + ID + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }
        public bool CheckIProductHasReferences()
        {
            string query = @"Select Count(*) from products as p
                         where product_id='"+ID+"' And  Exists ( Select * from client_balance as c where c.product_id=p.product_id)";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
