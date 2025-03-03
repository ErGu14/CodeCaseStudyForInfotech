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

          
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Commercium.API"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

           
            var connectionString = configuration.GetConnectionString("SQLServer");

           
            optionsBuilder.UseSqlServer(connectionString);

            return new CommerciumDbContext(optionsBuilder.Options);
        }
    }
}
