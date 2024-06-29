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

namespace MKproject
{
    public partial class BackUp : Form
    {
        bool IsFormShouldBeCloseOnDisactivation = true;


        public BackUp()
        {
            InitializeComponent();
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
        private void ButtonOfflineBackUp_Click(object sender, EventArgs e)
        {
            CloseNotfBanner();
            IsFormShouldBeCloseOnDisactivation = false;
          
            
            string dbPath = AppPaths.DatabasePath;
          
            if (!string.IsNullOrEmpty(dbPath) && System.IO.File.Exists(dbPath))
            {
                string BackUpDBPath = AppPaths.DirectoryPath + "\\FoxBackUp.db";
                File.Copy(dbPath, BackUpDBPath, true);

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Database files (*.db)|*.db|All files (*.*)|*.*";
                    saveFileDialog.Title = "Save Backup Database";
                    saveFileDialog.FileName = "FoxBackUp.db";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(BackUpDBPath, saveFileDialog.FileName, true);

                        // Assuming the attachment and the MailMessage are no longer using the file
                        File.Delete(BackUpDBPath);
                        NotificationBanner.Show("Backup saved successfully!", NotificationBanner.EnumType.ConfirmationMode, false, Program.HomeForm, false,false);
                        this.Close();
                    }
                }
            }
            IsFormShouldBeCloseOnDisactivation = true;
        }

        private async void ButtonOnlineBackUp_Click(object sender, EventArgs e)
        {
            CloseNotfBanner();
            IsFormShouldBeCloseOnDisactivation = false;

            DialogResult dialogResult = CustomMessageBox.Show("This action will send the database via Gmail.\nAre you sure you want to proceed?", CustomMessageBox.Type.YesNo);

            if (RandomFunctions.IsInternetConnected())
            {
                NotificationBanner.Show("Sending email with backup database... Please Do not turn off your Wi-Fi or close the application.", NotificationBanner.EnumType.InformativeMode, false, Program.HomeForm, false,true);
                this.Close();
                await SendEmail("mikaelkhalil7.mk@gmail.com", "Backup", "");
            }
            else
            {
                CustomMessageBox.Show("You don't have an Internet Connection, please connect to the internet", CustomMessageBox.Type.Error);
                this.Select();

            }



            IsFormShouldBeCloseOnDisactivation = true;


        }
        public async Task SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                var fromEmail = "mikaelkhalil7.mk@gmail.com";
                var password = "pxvm nxuv ahth mkgn";
                // Use App Passwords if you have 2FA enabled on your Google account.



                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromEmail, password),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(toEmail);


                string dbPath = AppPaths.DatabasePath;
                string BackUpDBPath = AppPaths.DirectoryPath + "\\FoxBackUp.db";

                if (!string.IsNullOrEmpty(dbPath) && System.IO.File.Exists(dbPath))
                {
                    File.Copy(dbPath, BackUpDBPath, true);

                    using (var attachment = new Attachment(BackUpDBPath))
                    {
                        mailMessage.Attachments.Add(attachment);
                       await smtpClient.SendMailAsync(mailMessage);
                    }
                }

                // Assuming the attachment and the MailMessage are no longer using the file
                File.Delete(BackUpDBPath);

                NotificationBanner.Show("Email with backup database sent successfully.", NotificationBanner.EnumType.ConfirmationMode, false, Program.HomeForm, false, false );
            }
            catch (Exception ex)
            {
                NotificationBanner.Show($"Email with backup failed to send, please try again.", NotificationBanner.EnumType.DeletedMode, false, Program.HomeForm, false, false);
            }
        }



        public static bool IsInternetAvailable()
        {
            try
            {
                InternetTest();
                return true;//cz if  it's offline or online w ma sar fi exceptoion so it s true             
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static void InternetTest()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var result = ping.Send("www.google.com", 5000);
                    if (result.Status != IPStatus.Success)
                    {
                        throw new Exception("No internet connection. Please check your network.");//in case la2oit el pc internet bas mesh meshye
                    }
                }
            }
            catch
            {

                throw new Exception("No internet connection. Please check your network.");//in case sar fi crach bel ping, w ma nbaat el mssg, yane eza maken el device connected men el asel
            }
        }


        public void CloseNotfBanner()
        {
            if (CustomizedTools.NotificationBanner.CurrentNotfBanner != null)
            {
                CustomizedTools.NotificationBanner.CloseTheNotfBanner();
            }
        }
    }
}
