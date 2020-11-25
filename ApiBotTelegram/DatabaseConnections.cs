using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ApiBotTelegram
{
    public class DatabaseConnections
    {
        public readonly SqlConnection con;

        public DatabaseConnections()
        {
            var configuration = GetConfiguration();
            con = new SqlConnection(configuration.GetSection("Database").GetSection("SQLServerConnectionString").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            /*var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);*/
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
