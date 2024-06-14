using MKproject.Schedule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
        public static void InsertToClientAttendance(int ClientID, int clientBalanceId, int? AppointmentID, DateTime AttendanceDate)
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

        //client-fields
        public static void InsertClientField(int clientId, int fieldId, string content)
        {
            string insertQuery = "INSERT INTO client_fields (client_id, fields_id, content) VALUES (@clientId, @fieldId, @content)";
            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, con);
            insertCommand.Parameters.AddWithValue("@clientId", clientId);
            insertCommand.Parameters.AddWithValue("@fieldId", fieldId);
            insertCommand.Parameters.AddWithValue("@content", content);
            con.Open();
            insertCommand.ExecuteNonQuery();
            con.Close();
        }

        public static void UpdateClientField(int clientId, int fieldId, string content)
        {
            string updateQuery = "UPDATE client_fields SET content = @content WHERE client_id = @clientId AND fields_id = @fieldId";
            SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, con);
            updateCommand.Parameters.AddWithValue("@content", content);
            updateCommand.Parameters.AddWithValue("@clientId", clientId);
            updateCommand.Parameters.AddWithValue("@fieldId", fieldId);
            con.Open();
            updateCommand.ExecuteNonQuery();
            con.Close();

        }
        public static void DeleteClientField(int clientId, int? fieldId)
        {
            string DeleteQuery = "Delete from client_fields WHERE client_id = @clientId ";
            if (fieldId != null)
            {
                DeleteQuery += " AND fields_id = @fieldId";
            }

            SQLiteCommand DeleteCommand = new SQLiteCommand(DeleteQuery, con);
            DeleteCommand.Parameters.AddWithValue("@clientId", clientId);

            if (fieldId != null)
            {
                DeleteCommand.Parameters.AddWithValue("@fieldId", fieldId);
            }

            con.Open();
            DeleteCommand.ExecuteNonQuery();
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
        public static void InsertField(string fieldName, bool visible, bool required, bool isOriginal)
        {
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO required_visible_fields (Fields, Visible, Required, IsOriginal) VALUES (@Fields, @Visible, @Required, @IsOriginal)", con);
            cmd.Parameters.AddWithValue("@Fields", fieldName);
            cmd.Parameters.AddWithValue("@Visible", visible);
            cmd.Parameters.AddWithValue("@Required", required);
            cmd.Parameters.AddWithValue("@IsOriginal", isOriginal);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }



    }
}
