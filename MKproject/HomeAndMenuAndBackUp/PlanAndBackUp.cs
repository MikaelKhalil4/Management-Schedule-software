using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using CustomizedTools;
using System.IO;
using GlobalFunctions;
using System.Net.Http;
using System.Reflection.Metadata;
using MKproject.Infrastucture;
using static MKproject.Infrastucture.SettingsSql;

namespace MKproject
{
    public partial class PlanAndBackUp : Form
    {
        bool IsFormShouldBeCloseOnDisactivation = true;
        bool isConstrutor;

        public PlanAndBackUp()
        {
            InitializeComponent();
            isConstrutor = true;


            DateTime DueDate =Convert.ToDateTime(ECService.GetDecryptedKeyValue(EnumSettingKey.DueDateMembership.ToString()));


            string DueDateString= RandomFunctions.SetDateFormatWithDayWithoutHour(DueDate.ToString());
            int DaysDifference = RandomFunctions.GetDaysDifference(DateTime.Now, DueDate);

            labelDueDatePlan.Text = $"{DueDateString}\n({DaysDifference} Days Left)";


            labelbackUpTime.Text = BackupHelper.GetLastbackUpTime();
            //AutoBackup
            checkBoxBackUp.Checked = BackupHelper.CheckIfAutomatedBackupIsActive();

            if (checkBoxBackUp.Checked)
                checkBoxBackUp.Text = "On";
            else 
                checkBoxBackUp.Text = "Off";

            isConstrutor = false;
        }



        private async void ButtonOnlineBackUp_Click(object sender, EventArgs e)
        {
            CloseNotfBanner();
            IsFormShouldBeCloseOnDisactivation = false;

            DialogResult dialogResult = CustomMessageBox.Show("This action will upload your database online.\nAre you sure you want to proceed?", CustomMessageBox.Type.YesNo);

            if (dialogResult == DialogResult.Yes)
            {


                if (RandomFunctions.IsInternetAvailable())
                {
                    NotificationBanner.Show("Uploading backup database online... Please Do not turn off your Wi-Fi or close the application.", NotificationBanner.EnumType.InformativeMode, false, Program.HomeForm, false, true);
                    this.Close();
                    if (await BackupHelper.Backup())
                    {
                        NotificationBanner.Show("Backup database uploaded successfully.", NotificationBanner.EnumType.ConfirmationMode, false, Program.HomeForm, false, false);

                    }
                    else
                    {
                        NotificationBanner.Show($"Backup failed to upload online, please try again.", NotificationBanner.EnumType.DeletedMode, false, Program.HomeForm, false, false);

                    }


                }
                else
                {
                    CustomMessageBox.Show("You don't have an Internet Connection, please connect to the internet", CustomMessageBox.Type.Error);
                    this.Select();

                }



                IsFormShouldBeCloseOnDisactivation = true;
            }
        }


        private void BackUp_Deactivate(object sender, EventArgs e)
        {
            if (IsFormShouldBeCloseOnDisactivation)
            {
                this.Close();

            }
        }


        private void BackUp_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }

        public void CloseNotfBanner()
        {
            if (CustomizedTools.NotificationBanner.CurrentNotfBanner != null)
            {
                CustomizedTools.NotificationBanner.CloseTheNotfBanner();
            }
        }


        bool isFromEventCheckItself;
        private void checkBoxBackUp_CheckedChanged(object sender, EventArgs e)
        {
            if (!isConstrutor && !isFromEventCheckItself)
            {
                IsFormShouldBeCloseOnDisactivation = false;
                if (checkBoxBackUp.Checked)
                {
                    DialogResult dialog = CustomMessageBox.Show("Are you do you want to active the auto backup daily", CustomMessageBox.Type.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        BackupHelper.UpdateBackupIntervalAsync(true);
                        checkBoxBackUp.Text = "On";

                    }
                    else
                    {
                        isFromEventCheckItself = true;
                        checkBoxBackUp.Checked = false;
                        checkBoxBackUp.Text = "Off";
                        isFromEventCheckItself = false;
                    }
                }
                else
                {
                    DialogResult dialog = CustomMessageBox.Show("Are you do you want to desactive the auto backup daily", CustomMessageBox.Type.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        BackupHelper.UpdateBackupIntervalAsync(false);
                        checkBoxBackUp.Text = "Off";
                    }
                    else
                    {
                        isFromEventCheckItself = true;
                        checkBoxBackUp.Checked = true;
                        checkBoxBackUp.Text = "On";
                        isFromEventCheckItself = false;
                    }
                }
                IsFormShouldBeCloseOnDisactivation = true;
            }

        }



        //Email and offline backup
        //private void ButtonOfflineBackUp_Click(object sender, EventArgs e)
        //{
        //    CloseNotfBanner();
        //    IsFormShouldBeCloseOnDisactivation = false;


        //    string dbPath = AppPaths.DatabasePath;

        //    if (!string.IsNullOrEmpty(dbPath) && System.IO.File.Exists(dbPath))
        //    {
        //        string BackUpDBPath = AppPaths.DirectoryPath + "\\FoxBackUp.db";
        //        File.Copy(dbPath, BackUpDBPath, true);

        //        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        //        {
        //            saveFileDialog.Filter = "Database files (*.db)|*.db|All files (*.*)|*.*";
        //            saveFileDialog.Title = "Save Backup Database";
        //            saveFileDialog.FileName = "FoxBackUp.db";

        //            if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                File.Copy(BackUpDBPath, saveFileDialog.FileName, true);

        //                // Assuming the attachment and the MailMessage are no longer using the file
        //                File.Delete(BackUpDBPath);
        //                NotificationBanner.Show("Backup saved successfully!", NotificationBanner.EnumType.ConfirmationMode, false, Program.HomeForm, false, false);
        //                this.Close();
        //            }
        //        }
        //    }
        //    IsFormShouldBeCloseOnDisactivation = true;
        //}






        //public async Task SendEmail(string toEmail, string subject, string body)
        //{
        //    try
        //    {
        //        var fromEmail = "mikaelkhalil7.mk@gmail.com";
        //        var password = "    ";
        //        // Use App Passwords if you have 2FA enabled on your Google account.



        //        var smtpClient = new SmtpClient("smtp.gmail.com")
        //        {
        //            Port = 587,
        //            Credentials = new NetworkCredential(fromEmail, password),
        //            EnableSsl = true,
        //        };

        //        var mailMessage = new MailMessage
        //        {
        //            From = new MailAddress(fromEmail),
        //            Subject = subject,
        //            Body = body,
        //            IsBodyHtml = true,
        //        };

        //        mailMessage.To.Add(toEmail);


        //        string dbPath = AppPaths.DatabasePath;
        //        string BackUpDBPath = AppPaths.DirectoryPath + "\\FoxBackUp.db";

        //        if (!string.IsNullOrEmpty(dbPath) && System.IO.File.Exists(dbPath))
        //        {
        //            File.Copy(dbPath, BackUpDBPath, true);

        //            using (var attachment = new Attachment(BackUpDBPath))
        //            {
        //                mailMessage.Attachments.Add(attachment);
        //                await smtpClient.SendMailAsync(mailMessage);
        //            }
        //        }

        //        // Assuming the attachment and the MailMessage are no longer using the file
        //        File.Delete(BackUpDBPath);

        //        NotificationBanner.Show("Email with backup database sent successfully.", NotificationBanner.EnumType.ConfirmationMode, false, Program.HomeForm, false, false);
        //    }
        //    catch (Exception ex)
        //    {
        //        NotificationBanner.Show($"Email with backup failed to send, please try again.", NotificationBanner.EnumType.DeletedMode, false, Program.HomeForm, false, false);
        //    }
        //}



    }
}
