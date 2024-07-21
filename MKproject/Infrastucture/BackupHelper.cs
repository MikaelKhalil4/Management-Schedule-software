using CustomizedTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MKproject.Properties;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Entity;
using static MKproject.Infrastucture.SettingsSql;
using GlobalFunctions;

namespace MKproject.Infrastucture
{
    public class BackupHelper
    {
        public static string backUpConstantInterval = "24:00:00";
        static Timer backupTimer;



        //leh el waet hl2d asir?
        public static async Task SetupBackupTimerndStartItIfNecessar()
        {
            backupTimer = new Timer();
            backupTimer.Interval = 10000; // 15 minutes == 900000 in ms


            backupTimer.Tick += async (sender, args) => await CheckAndMaybeBackupAsync();//setup the even tick and it s logic inside


            if (BackupHelper.CheckBackupIntervalIfExists())
            {
              backupTimer.Start();
            }
        }
        public static  bool CheckBackupIntervalIfExists()
        {

            string backupIntervalKey = EnumSettingKey.BackupInterval.ToString();


            var KeyValue = SettingsSql.GetKeyValue(backupIntervalKey);

            if (string.IsNullOrEmpty(KeyValue))
            {
                return false;
            }
            else
            {
                UpdateBackupIntervalAsync(true);
                return true;
            }
           
        }
        //hayde el function kermel el automated backup
        public static async Task CheckAndMaybeBackupAsync()
        {
            if (RandomFunctions.IsInternetAvailable())
            {
                var backupIntervalSettingValue = SettingsSql.GetKeyValue(EnumSettingKey.BackupInterval.ToString());
                var lastBackupTimeSetting = SettingsSql.GetKeyValue(EnumSettingKey.LastBackupTime.ToString());

                TimeSpan? backupIntervalValue = null;
                DateTime? lastBackupTimeValue = null;



                if (backupIntervalSettingValue != null)
                    backupIntervalValue = TimeSpan.Parse(backupIntervalSettingValue);

                if (lastBackupTimeSetting != null)
                    lastBackupTimeValue = DateTime.Parse(lastBackupTimeSetting);


                if (backupIntervalValue != null && (lastBackupTimeValue == null || DateTime.Now >= lastBackupTimeValue + backupIntervalValue))
                {

                    await HttpRequestsClass.UploadBackupFileAsync();

                    string LastBackupTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    SettingsSql.UpdateKeyValue(EnumSettingKey.LastBackupTime.ToString(), LastBackupTime);
                }
            }
        }
   
        public static void UpdateBackupIntervalAsync(bool isBackupAutoEnabled)//it will change lamma ghayyir bel setting =s el checkbox
        {
           
            if (isBackupAutoEnabled)
                backupTimer.Start();
            else
                backupTimer.Stop();


            string BackupIntervalValue = null;
            if (isBackupAutoEnabled)
            {
                BackupIntervalValue = backUpConstantInterval;
            }

            SettingsSql.UpdateKeyValue(EnumSettingKey.BackupInterval.ToString(), BackupIntervalValue);
        }


      




    }
}
