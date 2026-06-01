using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ISApteka.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PharmacyContext>
    {
        public PharmacyContext CreateDbContext(string[] args)
        {
            // Находим appsettings.json
            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            // Если в текущей папке нет, ищем в родительской
            if (!File.Exists(configPath))
            {
                configPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName ?? "", "appsettings.json");
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(configPath) ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PharmacyContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("PharmacyDB"));

            return new PharmacyContext(optionsBuilder.Options);
        }
    }
}