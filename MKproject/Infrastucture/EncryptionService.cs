using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static MKproject.Infrastucture.BackupHelper;

namespace MKproject.Infrastucture
{
    public static class EncryptionService
    {
        private static readonly string keyString = "N5tE7kZCM3InhtZ4kI3adEzTMKAszYxi";
        private static readonly byte[] key = Encoding.UTF8.GetBytes(keyString);
        private static readonly byte[] iv = Encoding.UTF8.GetBytes("cksPq3C9AJOTReDI");

        public static string EncryptString(string plainText)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string DecryptString(string cipherText)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (var msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }


        public static string GetDecryptedKeyValue(string Key)
        {

            string Encryptedkey = EncryptionService.EncryptString(Key);
            string? EncryptedKeyValue = SettingsSql.GetKeyValue(Encryptedkey);


            if (EncryptedKeyValue == null)
                return null;
            else
                return EncryptionService.DecryptString(EncryptedKeyValue);
        }


    }
}
