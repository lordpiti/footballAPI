using Crosscutting.ViewModels;
using Football.DataAccessEFCore3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;

namespace Football.DataAccess
{
    // class created to support EF migrations on .net core 2 projects
    // https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation
    public class FootballContextFactory : IDesignTimeDbContextFactory<FootballContext>
    {
        private string _connectionString;

        public FootballContextFactory() { }

        public FootballContextFactory(IOptions<AppSettings> settings)
        {
            this._connectionString = settings.Value.ConnectionString;
        }

        public FootballContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuration.GetSection("AppSettings:ConnectionString").Value;

            var optionsBuilder = new DbContextOptionsBuilder<FootballContext>();
            var options = optionsBuilder.UseSqlServer(connectionString)
            .Options;

            return new FootballContext(options);
        }
    }
}
