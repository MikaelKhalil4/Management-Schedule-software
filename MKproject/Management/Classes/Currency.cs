using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;


namespace MKproject.Management
{
    public class Currency
    {
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);
        public static string CurrencyName { get; set; }
        public static string Symbol { get; set; }

        public static void GetCurrency()
        {

            SQLiteCommand cmd = new SQLiteCommand("select * from Currencies where currency_id=1 ", con);//id=1 for default currency $
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            CurrencyName = dt.Rows[0]["Currency_Name"].ToString();
            Symbol = dt.Rows[0]["Symbol"].ToString();
        }
        //lezim nes7ab kell el currencies

    }
}
