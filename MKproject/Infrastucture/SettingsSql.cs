using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKproject.Infrastucture
{
    public class SettingsSql
    {
        public enum EnumSettingKey
        {
            TicketId,
            DueDateMembership,
            BackupInterval,
            LastBackupTime,
            IsMainDevice
        }
        
        //WHERE IT BEING CALLED
        public static void EnsureSettingsExist()
        {

            foreach (EnumSettingKey key in Enum.GetValues(typeof(EnumSettingKey)))
            {
                string keyName = key.ToString();
                string? keyValue = GetDefaultValueForKey(key);

                if (key == EnumSettingKey.TicketId || key == EnumSettingKey.DueDateMembership || key == EnumSettingKey.IsMainDevice)
                {
                    keyName = EncryptionService.EncryptString(keyName);
                    keyValue = keyValue != null ? EncryptionService.EncryptString(keyValue) : null;
                }


                //ejbare hone , after encyption
                if (!SettingsSql.IsKeyExists(keyName))
                {
                    SettingsSql.InsertKey(keyName, keyValue);
                }
            }
        } 
        private static string GetDefaultValueForKey(EnumSettingKey key)
        {
            switch (key)
            {
                case EnumSettingKey.TicketId:
                    return "1";
                case EnumSettingKey.DueDateMembership:
                    return null;
                case EnumSettingKey.BackupInterval:
                    return null;
                case EnumSettingKey.LastBackupTime:
                    return null;
                case EnumSettingKey.IsMainDevice:
                    return "false";
                default:
                    return "";
            }
        }
      
        
        
        //SqlRowQueries for SetingsTable
        public static string GetKeyValue(string key)
        {
            var cmd = Program.CreateCommand("select SettingValue from Settings Where SettingKey=@SettingKey");
            cmd.AddWithValue("@SettingKey", key);
            var sda = Program.CreateDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            string keyValue;
            if (dt.Rows[0][0] != DBNull.Value)
            {
                keyValue=dt.Rows[0][0].ToString();
            }
            else
            {
                keyValue = null;
            }
            return keyValue;

        }

    
        public static void InsertKey(string key, string KeyValue)
        {
            string query = "INSERT INTO Settings (SettingKey,SettingValue) VALUES (@SettingKey,@SettingValue)";
            var command = Program.CreateCommand(query);
            command.AddWithValue("@SettingKey", key);
            command.AddWithValue("@SettingValue", KeyValue);
            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();
        }
        public static void UpdateKeyValue(string key, string? keyValue)
        {
            string query = "UPDATE Settings SET SettingValue=@SettingValue Where SettingKey=@SettingKey";
            var command = Program.CreateCommand(query);
            command.AddWithValue("@SettingKey", key);
            if (keyValue == null)
            {
                command.AddWithValue("@SettingValue", DBNull.Value);
            }
            else
            {
                command.AddWithValue("@SettingValue", keyValue);
            }
            Program.conOpen();
            command.ExecuteNonQuery();
            Program.con.Close();
        }
        public static bool IsKeyExists(string key)
        {
            string query = "SELECT COUNT(1) FROM Settings WHERE SettingKey=@SettingKey";
            var command = Program.CreateCommand(query);
            command.AddWithValue("@SettingKey", key);
            Program.conOpen();
            int count = Convert.ToInt32(command.ExecuteScalar());
            Program.con.Close();

            return count > 0;
        }
    }
}
