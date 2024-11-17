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




        ///Finance


        public static void InsertToFinance(int ClientBalanceId, Double AmountPaid, DateTime Date, String AlbumType,long? archiveId)
        {

            string QueryInsert = @"INSERT INTO finance (client_balance_id,AlbumType,amount_paid,payment_date,archive_id) 
                        VALUES
                        (@client_balance_id,@AlbumType,@amount_paid,@payment_date,@archive_id) ";

            var cmdInsert = Program.CreateCommand(QueryInsert); // Initialize the SQLiteCommand inside the loop

            cmdInsert.AddWithValue("@client_balance_id", ClientBalanceId);

            if (AlbumType == null)
            {
                cmdInsert.AddWithValue("@AlbumType", DBNull.Value);

            }
            else
            {
                cmdInsert.AddWithValue("@AlbumType", AlbumType);
            }
            cmdInsert.AddWithValue("@amount_paid", AmountPaid);
            cmdInsert.AddWithValue("@payment_date", Date);


            if (archiveId == null)//lamma ykun money 0, and we're adding it bas kermel el qtt
            {
                cmdInsert.AddWithValue("@archive_id", DBNull.Value);

            }
            else
            {
                cmdInsert.AddWithValue("@archive_id", archiveId);
            }

            Program.conOpen();
            cmdInsert.ExecuteNonQuery();
            Program.con.Close();
        }






        //client_struct table
        public static void InsertToClientAttendance(int ClientID, int clientBalanceId, int? AppointmentID, DateTime AttendanceDate)
        {

            string QueryInsert = "insert into client_services_attendance (client_id,client_balance_id,appointment_id,execute_date) values (@client_id,@client_balance_id,@appointment_id,@execute_date)";
            var cmdInsert = Program.CreateCommand(QueryInsert);
            cmdInsert.AddWithValue("@client_id", ClientID);
            cmdInsert.AddWithValue("@client_balance_id", clientBalanceId);
            if (AppointmentID == null)
            {
                cmdInsert.AddWithValue("@appointment_id", DBNull.Value);

            }
            else
            {
                cmdInsert.AddWithValue("@appointment_id", AppointmentID);
            }
            cmdInsert.AddWithValue("@execute_date", AttendanceDate);
            Program.conOpen();
            cmdInsert.ExecuteNonQuery();
            Program.con.Close();

        }

        //client-fields
        public static void InsertClientField(int clientId, int fieldId, string content)
        {
            string insertQuery = "INSERT INTO client_fields (client_id, fields_id, content) VALUES (@clientId, @fieldId, @content)";
            var insertCommand = Program.CreateCommand(insertQuery);
            insertCommand.AddWithValue("@clientId", clientId);
            insertCommand.AddWithValue("@fieldId", fieldId);
            insertCommand.AddWithValue("@content", content);
            Program.conOpen();
            insertCommand.ExecuteNonQuery();
            Program.con.Close();
        }

        public static void UpdateClientField(int clientId, int fieldId, string content)
        {
            string updateQuery = "UPDATE client_fields SET content = @content WHERE client_id = @clientId AND fields_id = @fieldId";
            var updateCommand = Program.CreateCommand(updateQuery);
            updateCommand.AddWithValue("@content", content);
            updateCommand.AddWithValue("@clientId", clientId);
            updateCommand.AddWithValue("@fieldId", fieldId);
            Program.conOpen();
            updateCommand.ExecuteNonQuery();
            Program.con.Close();

        }
        public static void DeleteClientField(int clientId, int? fieldId)
        {
            string DeleteQuery = "Delete from client_fields WHERE client_id = @clientId ";
            if (fieldId != null)
            {
                DeleteQuery += " AND fields_id = @fieldId";
            }

            var DeleteCommand = Program.CreateCommand(DeleteQuery);
            DeleteCommand.AddWithValue("@clientId", clientId);

            if (fieldId != null)
            {
                DeleteCommand.AddWithValue("@fieldId", fieldId);
            }

            Program.conOpen();
            DeleteCommand.ExecuteNonQuery();
            Program.con.Close();
        }


        //album
        public static void InsertNewAlbum(string albumName)
        {
            string query = "INSERT INTO Albums (AlbumType) VALUES (@AlbumName)";
            var command = Program.CreateCommand(query);
            command.AddWithValue("@AlbumName", albumName);
            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();

        }
        public static void UpdateAlbum(string NewAlbumName, string OldAlbumName)
        {
            string query = "UPDATE Albums SET AlbumType = @NewAlbumName WHERE AlbumType = @AlbumName";
            var command = Program.CreateCommand(query);
            command.AddWithValue("@AlbumName", OldAlbumName);
            command.AddWithValue("@NewAlbumName", NewAlbumName);
            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();
        }
        public static void DeleteAlbum(string AlbumName)
        {
            string query = "Delete FROM  Albums  WHERE AlbumType = @AlbumName";
            var command = Program.CreateCommand(query);
            command.AddWithValue("@AlbumName", AlbumName);
            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();
        }


        //registrationFidls
        public static void UpdateField(bool Isvisible, bool IsRequired, int id)
        {
            var command = Program.CreateCommand("UPDATE required_visible_fields SET Visible = @Visible, Required = @Required WHERE fields_id = @fields_id");
            command.AddWithValue("@Visible", Isvisible);
            command.AddWithValue("@Required", IsRequired);
            command.AddWithValue("@fields_id", id);
            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();
        }
        public static void InsertField(string fieldName, bool visible, bool required, bool isOriginal)
        {
            var cmd = Program.CreateCommand("INSERT INTO required_visible_fields (Fields, Visible, Required, IsOriginal) VALUES (@Fields, @Visible, @Required, @IsOriginal)");
            cmd.AddWithValue("@Fields", fieldName);
            cmd.AddWithValue("@Visible", visible);
            cmd.AddWithValue("@Required", required);
            cmd.AddWithValue("@IsOriginal", isOriginal);
            Program.conOpen();
            cmd.ExecuteNonQuery();
            Program.con.Close();

        }



    }
}
