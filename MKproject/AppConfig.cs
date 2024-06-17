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
        public IConfiguration Configuration { get; set; }

        public AppConfig()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public string GetConnectionString()
        {
            return Configuration["Database:ConnectionString"];
        }

        public string GetImagesDirectory()
        {
            return Configuration["Paths:ImagesDirectory"];
        }
    }
}
