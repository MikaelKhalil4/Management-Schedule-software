using GlobalFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CustomizedTools;
using Newtonsoft.Json;
using System.Data.SQLite;
using System.Drawing;
using Amazon.S3.Model.Internal.MarshallTransformations;
using static MKproject.Infrastucture.SettingsSql;
using MKproject.Management;
using System.Management;
using MKproject.ViewModels;

namespace MKproject.Infrastucture
{
    public class HttpRequestsClass
    {
        static string BaseAddress = "http://localhost:5117";


        //BackUP
        public static async Task<bool> UploadBackupFileAsync()
        {
            try
            {
                bool result;

                string ticketID = EncryptionService.GetDecryptedKeyValue(SettingsSql.EnumSettingKey.TicketId.ToString());

                if (ticketID == null)
                    return false;

                string dbPath = AppPaths.DatabasePath;
                string NewBackFile = "FoxBackUp.db";
                string BackUpDBPath = $"{AppPaths.DirectoryPath}\\{NewBackFile}";

                if (!string.IsNullOrEmpty(dbPath) && File.Exists(dbPath))
                {
                    File.Copy(dbPath, BackUpDBPath, true);
                }

                using (var client = new HttpClient())
                {
                    // Create Multipart Content
                    using (var content = new MultipartFormDataContent())
                    {
                        //string requestUri = $"{AppConfig.Configuration["api-url"]}?TicketId=123&branchName={AppConfig.GetBucketName()}";
                        string requestUri = $"{BaseAddress}/Backup/Backup()?TicketId={ticketID}&branchName={AppConfig.GetBucketName()}";


                        var fileContent = new StreamContent(File.OpenRead(BackUpDBPath));
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        content.Add(fileContent, "backupFile", NewBackFile);

                        // Send POST request6
                        var response = await client.PostAsync(requestUri, content);

                        // Check if the response is successful
                        if (response.IsSuccessStatusCode)
                        {
                            // Optionally read the response
                            await response.Content.ReadAsStringAsync();
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
                File.Delete(BackUpDBPath);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        //logs
        public static async Task CheckAndProcessLogs()
        {
            string logDirectoryPath = AppPaths.DirectoryPath;

            // Ensure the directory exists to avoid runtime exceptions
            if (Directory.Exists(logDirectoryPath))
            {
                // Get all .json files in the directory
                string[] logFiles = Directory.GetFiles(logDirectoryPath, "*.json");
                if (logFiles.Count() > 0)
                {

                    if (RandomFunctions.IsInternetAvailable())
                    {
                        string ticketID = EncryptionService.GetDecryptedKeyValue(SettingsSql.EnumSettingKey.TicketId.ToString());

                        if (ticketID == null)
                            return;

                        // Process each file
                        foreach (string filePath in logFiles)
                        {
                            HttpResponseMessage response = null;
                            using (var client = new HttpClient())
                            {
                                // Create Multipart Content
                                using (var content = new MultipartFormDataContent())
                                {
                                    //string requestUri = $"{AppConfig.Configuration["api-url"]}?TicketId=123&branchName={AppConfig.GetBucketName()}";
                                    string requestUri = $"{BaseAddress}/Backup/Log()?TicketId={ticketID}&branchName={AppConfig.GetBucketName()}";


                                    // Load the file data
                                    var fileContent = new StreamContent(File.OpenRead(filePath));
                                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                                    // 'logFile' is the parameter name that the server expects
                                    content.Add(fileContent, "logFile", Path.GetFileName(filePath));

                                    response = await client.PostAsync(requestUri, content);

                                }
                            }

                            // Check if the response is successful then delete the log file
                            if (response != null && response.IsSuccessStatusCode)
                            {
                                File.Delete(filePath);
                            }
                        }
                    }
                }
            }
        }




        //client registration
        public static async Task<bool> RegisterClient(string TicketIdValue, string phoneNumber)
        {
            try
            {


                if (string.IsNullOrEmpty(TicketIdValue))
                    return false;


                string MacAdress = GetMotherboardSerialNumber();

                using (HttpClient client = new HttpClient())
                {
                    var requestUri = $"{BaseAddress}/Subscription/RegisterClient()?TicketId={TicketIdValue}&phoneNumber={phoneNumber}&MACAdressOfDesiredDevice={MacAdress}";
                    HttpResponseMessage response = await client.PostAsync(requestUri, null);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        ClientTicket clientTicket = JsonConvert.DeserializeObject<ClientTicket>(jsonResponse);


                        //Updating the TicketId
                        string TicketIdKeyEnc = EncryptionService.EncryptString(SettingsSql.EnumSettingKey.TicketId.ToString());
                        string TicketIDvalueEncryp = EncryptionService.EncryptString(clientTicket.TicketId);
                        SettingsSql.UpdateKeyValue(TicketIdKeyEnc, TicketIDvalueEncryp);

                        //Updating the TicketId The Main Device
                        string IsMaindDeviceKeyEnc = EncryptionService.EncryptString(SettingsSql.EnumSettingKey.IsMainDevice.ToString());
                        string IsMaindDeviceKeyValueEnc = EncryptionService.EncryptString(clientTicket.IsMainDevice.ToString());
                        SettingsSql.UpdateKeyValue(IsMaindDeviceKeyEnc, IsMaindDeviceKeyValueEnc);


                        //Update the Duedate
                        await UpdateDueDateSubscription();
                    }

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Something went wrong from our side,Please let us know and then try again\nDetails:{ex}", CustomMessageBox.Type.Error);
                return false;
            }
        }
        public static string GetMotherboardSerialNumber()
        {
            try
            {
                string serialNumber = string.Empty;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    serialNumber = queryObj["SerialNumber"].ToString();
                    break; // Assuming only one motherboard
                }
                return serialNumber;
            }
            catch
            {
                return "MACNOTFOUND";
            }
        }





        //subscription
        public static async Task UpdateDueDateSubscription()
        {

            string DueDateKeyEncryp = EncryptionService.EncryptString(EnumSettingKey.DueDateMembership.ToString());
            string DueDateValueEncryp = null;

            try
            {

                string ticketId = EncryptionService.GetDecryptedKeyValue(SettingsSql.EnumSettingKey.TicketId.ToString());
                string DeviceIp = GetMotherboardSerialNumber();
                using (HttpClient client = new HttpClient())
                {
                    var requestUri = $"{BaseAddress}/Subscription/CheckIfClientHasSubscriptionAndReturnDueDate/{ticketId}/{DeviceIp}";
                    HttpResponseMessage response = await client.GetAsync(requestUri);

                    DateTime? Date = null;


                    if (response.IsSuccessStatusCode)//eza ma eendo package available ha tred NotFound
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Date = DateTime.Parse(JsonConvert.DeserializeObject<string>(jsonResponse));
                    }
                    else
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        throw new Exception(responseContent);
                    }

                    //Update DB, take into consideration if null or no


                    if (Date != null)
                    {
                        DueDateValueEncryp = EncryptionService.EncryptString(((DateTime)Date).ToString("yyyy-MM-dd"));
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                SettingsSql.UpdateKeyValue(DueDateKeyEncryp, DueDateValueEncryp);
            }
        }




    }
}
