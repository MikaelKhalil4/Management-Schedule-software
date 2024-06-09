using MKproject.Schedule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace MKproject.Management
{
    internal class ProjectToSQL
    {
        static SQLiteConnection con = new SQLiteConnection(Program.DataLocation);




        ///Finance


        public static void InsertToFinance(int ClientBalanceId, Double AmountPaid, DateTime Date, String AlbumType)
        {

            string QueryInsert = @"INSERT INTO finance (client_balance_id,AlbumType,amount_paid,payment_date) 
                        VALUES
                        (@client_balance_id,@AlbumType,@amount_paid,@payment_date) ";

            SQLiteCommand cmdInsert = new SQLiteCommand(QueryInsert, con); // Initialize the SQLiteCommand inside the loop

            cmdInsert.Parameters.AddWithValue("@client_balance_id", ClientBalanceId);

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
            con.Open();
            cmdInsert.ExecuteNonQuery();
            con.Close();
        }






        //client_struct table
        public static void InsertToClientAttendance(int ClientID, int clientBalanceId, int? AppointmentID,DateTime AttendanceDate)
        {

            string QueryInsert = "insert into client_services_attendance (client_id,client_balance_id,appointment_id,execute_date) values (@client_id,@client_balance_id,@appointment_id,@execute_date)";
            SQLiteCommand cmdInsert = new SQLiteCommand(QueryInsert, con);
            cmdInsert.Parameters.AddWithValue("@client_id", ClientID);
            cmdInsert.Parameters.AddWithValue("@client_balance_id", clientBalanceId);
            if (AppointmentID == null)
            {
                cmdInsert.Parameters.AddWithValue("@appointment_id", DBNull.Value);

            }
            else
            {
                cmdInsert.Parameters.AddWithValue("@appointment_id", AppointmentID);
            }
            cmdInsert.Parameters.AddWithValue("@execute_date", AttendanceDate);
            con.Open();
            cmdInsert.ExecuteNonQuery();
            con.Close();

        }


        //album
        public static void InsertNewAlbum(string albumName)
        {
            string query = "INSERT INTO Albums (AlbumType) VALUES (@AlbumName)";
            SQLiteCommand command = new SQLiteCommand(query, con);
            command.Parameters.AddWithValue("@AlbumName", albumName);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();

        }
        public static void UpdateAlbum(string NewAlbumName, string OldAlbumName)
        {
            string query = "UPDATE Albums SET AlbumType = @NewAlbumName WHERE AlbumType = @AlbumName";
            SQLiteCommand command = new SQLiteCommand(query, con);
            command.Parameters.AddWithValue("@AlbumName", OldAlbumName);
            command.Parameters.AddWithValue("@NewAlbumName", NewAlbumName);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void DeleteAlbum(string AlbumName)
        {
            string query = "Delete FROM  Albums  WHERE AlbumType = @AlbumName";
            SQLiteCommand command = new SQLiteCommand(query, con);
            command.Parameters.AddWithValue("@AlbumName", AlbumName);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }


        //registrationFidls
        public static void UpdateField(bool Isvisible, bool IsRequired, int id)
        {
            SQLiteCommand command = new SQLiteCommand("UPDATE required_visible_fields SET Visible = @Visible, Required = @Required WHERE fields_id = @fields_id", con);
            command.Parameters.AddWithValue("@Visible", Isvisible);
            command.Parameters.AddWithValue("@Required", IsRequired);
            command.Parameters.AddWithValue("@fields_id", id);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }


    }
}
