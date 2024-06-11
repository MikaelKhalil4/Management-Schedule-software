using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows;


namespace MKproject.Management
{
    public class Currency
    {
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);
        public static string CurrencyName { get; set; }
        public static string Symbol { get; set; }

    }
}
