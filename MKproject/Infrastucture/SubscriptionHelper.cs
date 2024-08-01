using CustomizedTools;
using GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKproject.Infrastucture
{
    public class SubscriptionHelper
    {

        //Subscription Wise
        public static async Task SetupTimerAndStartSubuscriptionTimer()
        {
            //first iteration
            await CheckSubscription();


            System.Windows.Forms.Timer TimerSubsucription = new System.Windows.Forms.Timer();
            TimerSubsucription.Interval = 60000 * 360;//each 6hrs
            TimerSubsucription.Tick += async (sender, args) => await CheckSubscription();

            TimerSubsucription.Start();
        }
      
        public static async Task CheckSubscription()
        {

            if (RandomFunctions.IsInternetAvailable())
            {
                await HttpRequestsClass.CheckIfClientHasSubscriptionAndReturnDueDate();//it will upadte the offline db
            }

            //check offline his due date,and start drop warnings
            string DueDateValue = EncryptionService.GetDecryptedKeyValue(SettingsSql.EnumSettingKey.DueDateMembership.ToString());

            DateTime? dueDate = null;
            int Minute = 60000;


            if (!string.IsNullOrEmpty(DueDateValue))
            {
                dueDate = DateTime.Parse(DueDateValue);
                if (dueDate.Value < DateTime.Now.Date)//kholis eshitrako
                {
                    CloseAppIfSubsciptionFinished();
                }
                else if (dueDate.Value == DateTime.Now.Date)//eza liom byokhlas eshtirako
                {
                    LaunchWarningTimer(0, Minute * 15, false);//each 15min
                }
                else if (dueDate.Value == DateTime.Now.Date.AddDays(1))
                {
                    LaunchWarningTimer(1, Minute * 60, false);//each one hour
                }
                else if (dueDate.Value == DateTime.Now.Date.AddDays(2))
                {
                    LaunchWarningTimer(2, Minute * 180, true);//each 3 hrs
                }
                else if (dueDate.Value == DateTime.Now.Date.AddDays(3))
                {
                    LaunchWarningTimer(3, Minute * 360, true);//each 6 hrs
                }
                else if (dueDate.Value == DateTime.Now.Date.AddDays(4))
                {
                    LaunchWarningTimer(4, Minute * 360, true);//each 6 hrs
                }
                else if (dueDate.Value == DateTime.Now.Date.AddDays(5))
                {
                    LaunchWarningTimer(5, Minute * 360, true);//each 6 hrs
                }
            }
            else//kholis eshitrako
            {
                CloseAppIfSubsciptionFinished();
            }
        }
        public static void LaunchWarningTimer(int NbrOfDaysLeft, int Duration, bool IsWarningOrUrgent)
        {
            string message = $"{NbrOfDaysLeft} Days Left Before Your Bundle Finishes,Please Refuel your Days";
            if (IsWarningOrUrgent)
            {
                if (Program.HomeForm != null)
                {
                    NotificationBanner.Show(message, NotificationBanner.EnumType.InformativeMode, false, Program.HomeForm, false, false);
                }
            }
            else
            {
                CustomMessageBox.Show(message, CustomMessageBox.Type.OkWarning);
            }
        }
        public static void CloseAppIfSubsciptionFinished()
        {
            CustomMessageBox.Show("Bundle Finished,Please Recharge your Plan in order to keep using your software", CustomMessageBox.Type.Error);
            Application.Exit();
        }
    }
}
