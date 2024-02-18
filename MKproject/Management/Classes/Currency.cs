using System.Data;
using System.Data.SqlClient;


namespace MKproject.Management
{
    public class Currency
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);
        public static string CurrencyName { get; set; }
        public static string Symbol { get; set; }

        public static void GetCurrency()
        {

            SqlCommand cmd = new SqlCommand("select * from Currencies where id=1 ", con);//id=1 for default currency $
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            CurrencyName = dt.Rows[0]["Currency_Name"].ToString();
            Symbol = dt.Rows[0]["Symbol"].ToString();
        }
        //lezim nes7ab kell el currencies


        // Constructor with currencyName argument
        //public Currency(string currencyName)
        //{
        //    CurrencyName = currencyName;
        //    // You can set the Symbol based on the currencyName or provide default values here
        //    Symbol = GetSymbolForCurrency(currencyName);
        //}
        //private string GetSymbolForCurrency(string currencyName)
        //{
        //    //sql job
        //}
    }
}
