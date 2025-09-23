using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Core.Configuration
{
    public static class DbConfiguration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../../../WebAPI"));
                configurationManager.AddJsonFile("appsettings.json");

                string connectionString = configurationManager.GetConnectionString("MySQLConnectionString");
                return connectionString == null ? throw new Exception("Not Found") : connectionString;
            }
        }
    }
}
