using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKproject
{
    public class AppConfig
    {
        private static IConfiguration _configuration;
        public static IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    InitializeConfiguration();
                }
                return _configuration;
            }
        }

        private static void InitializeConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string GetBucketName()
        {
            return Configuration[""]; // Consider what to return if "bucketname" is not found.
        }
        public static string GetURL()
        {
            return Configuration["url"]; // Consider what to return if "bucketname" is not found.
        }
    }
}
