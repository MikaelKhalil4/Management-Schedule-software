using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace MKproject.Management
{
    internal class ProjectToSQL
    {
        static SqlConnection con = new SqlConnection(Program.DataLocation);
        static Currency currency = new Currency();



        ///Finance
        

        public static void InsertToFinance(int ClientBalanceId, Double AmountPaid, DateTime Date, String AlbumType)
        {

            string QueryInsert = @"INSERT INTO finance (id_client_balance,AlbumType,amount_paid,payment_date,Currency_Name) 
                        VALUES
                        (@id_client_balance,@AlbumType,@amount_paid,@payment_date,@Currency_Name) ";

            SqlCommand cmdInsert = new SqlCommand(QueryInsert, con); // Initialize the SqlCommand inside the loop

            cmdInsert.Parameters.AddWithValue("@id_client_balance", ClientBalanceId);

            if (AlbumType == null)
            {
                cmdInsert.Parameters.AddWithValue("@AlbumType", DBNull.Value);

            }
            else
            {
                cmdInsert.Parameters.AddWithValue("@AlbumType", AlbumType);
            }
            cmdInsert.Parameters.AddWithValue("@amount_paid", AmountPaid);
            cmdInsert.Parameters.AddWithValue("@payment_date", Date);
            cmdInsert.Parameters.AddWithValue("@Currency_Name", Currency.CurrencyName);
            con.Open();
            cmdInsert.ExecuteNonQuery();
            con.Close();
        }






        //client_struct table
        public static void InsertToClientAttendance(int ClientID)
        {

            string QueryInsert = "insert into client_attendance (client_id,execute_date) values (@client_id,@execute_date)";
            SqlCommand cmdInsert = new SqlCommand(QueryInsert, con);
            cmdInsert.Parameters.AddWithValue("@client_id", ClientID);
            cmdInsert.Parameters.AddWithValue("@execute_date", DateTime.Today);
            con.Open();
            cmdInsert.ExecuteNonQuery();
            con.Close();


        }


        //album
        public static void InsertNewAlbum(string albumName)
        {
            string query = "INSERT INTO Albums (AlbumType) VALUES (@AlbumName)";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@AlbumName", albumName);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();

        }
        public static void UpdateAlbum(string NewAlbumName, string OldAlbumName)
        {
            string query = "UPDATE Albums SET AlbumType = @NewAlbumName WHERE AlbumType = @AlbumName";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@AlbumName", OldAlbumName);
            command.Parameters.AddWithValue("@NewAlbumName", NewAlbumName);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void DeleteAlbum(string AlbumName)
        {
            string query = "Delete Albums  WHERE AlbumType = @AlbumName";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@AlbumName", AlbumName);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }


        //registrationFidls
        public static void UpdateField(bool Isvisible, bool IsRequired, int id)
        {
            SqlCommand command = new SqlCommand("UPDATE required_visible_fields SET Visible = @Visible, Required = @Required WHERE id = @ID", con);
            command.Parameters.AddWithValue("@Visible", Isvisible);
            command.Parameters.AddWithValue("@Required", IsRequired);
            command.Parameters.AddWithValue("@ID", id);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }


    }
}
