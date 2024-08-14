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
using System.IO.Packaging;

namespace MKproject.Infrastucture
{
    public class BackupHelper
    {
        public static string backUpConstantInterval = "06:00:00";
        static Timer backupTimer;



        public static async Task SetupBackupTimerndStartItIfNecessar()
        {
            backupTimer = new Timer();
            backupTimer.Interval = 60000 * 15; // 15 minutes == 900000 in ms
            backupTimer.Tick += async (sender, args) => await CheckAndAutomateBackUpIfNecessar();//setup the even tick and it s logic inside

            if (BackupHelper.CheckIfAutomatedBackupIsActive())
            {
                await CheckAndAutomateBackUpIfNecessar(); //starting the first iteration
                backupTimer.Start();
            }
        }
        public static bool CheckIfAutomatedBackupIsActive()
        {

            string backupIntervalKey = EnumSettingKey.BackupInterval.ToString();
            var BackupIntervalValue = SettingsSql.GetKeyValue(backupIntervalKey);

            if (string.IsNullOrEmpty(BackupIntervalValue))
            {
                return false;
            }
            else
            {
                SettingsSql.UpdateKeyValue(EnumSettingKey.BackupInterval.ToString(), BackupIntervalValue);//in order to keep the right time updated, in case ghayrto hard coded
                return true;
            }

        }
        public static async Task CheckAndAutomateBackUpIfNecessar()
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
                    await Backup();
                }
            }
        }
        public static async Task<bool> Backup()
        {
            String PreviousBackupDate= SettingsSql.GetKeyValue(EnumSettingKey.LastBackupTime.ToString());//kermel yenaamal upload aal server maa the last time naamal fiya backup
            string LastBackupTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
           

            if (await HttpRequestsClass.UploadBackupFileAsync())
            {
                SettingsSql.UpdateKeyValue(EnumSettingKey.LastBackupTime.ToString(), LastBackupTime);
                return true;
            }
            else
            {
                SettingsSql.UpdateKeyValue(EnumSettingKey.LastBackupTime.ToString(), PreviousBackupDate);
                return false;
            }
        }



        //used for frontend interaction
        public static void UpdateBackupIntervalAsync(bool isBackupAutoEnabled)
        {

            string BackupIntervalValue = null;
            if (isBackupAutoEnabled)
            {
                BackupIntervalValue = backUpConstantInterval;
            }

            SettingsSql.UpdateKeyValue(EnumSettingKey.BackupInterval.ToString(), BackupIntervalValue);


            if (isBackupAutoEnabled)
            {
                CheckAndAutomateBackUpIfNecessar();//first iteration
                backupTimer.Start();
            }
            else
            {
                backupTimer.Stop();
            }

        }
        public static string GetLastbackUpTime()
        {

            string BackUpTime = SettingsSql.GetKeyValue(EnumSettingKey.LastBackupTime.ToString());
            if (!string.IsNullOrEmpty(BackUpTime))
            {
                return RandomFunctions.SetDateFormatWithhours(BackUpTime);
            }
            else
            {
                return "N/A";
            }
        }

    }
}
