using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace Commercium.Data.DbContexts
{
    public class CommerciumDbContextFactory : IDesignTimeDbContextFactory<CommerciumDbContext>
    {
        public CommerciumDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CommerciumDbContext>();

            // API projesinin kök dizinindeki appsettings.json'a erişiyoruz
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Commercium.API"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // ConnectionString'i alıyoruz
            var connectionString = configuration.GetConnectionString("SQLServer");

            // DbContextOptions ile bağlantı dizesini ayarlıyoruz
            optionsBuilder.UseSqlServer(connectionString);

            return new CommerciumDbContext(optionsBuilder.Options);
        }
    }
}
