using Eunis.Data.Models;
using Eunis.Data.Models.Configuration;
using Eunis.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Eunis.Data {

    public class EunisDbContext : DbContext {

        public EunisDbContext(DbContextOptions<EunisDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CredentialsEntityConfiguration.Configure(modelBuilder.Entity<Credentials>());
            SettingsEntityConfiguration.Configure(modelBuilder.Entity<Settings>());
            EunisTransactionEntityConfiguration.Configure(modelBuilder.Entity<EunisTransaction>());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class EunisDbContextFactory : IDesignTimeDbContextFactory<EunisDbContext> {
        public EunisDbContext CreateDbContext(string[] args) {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EunisDbContext>();
            var encryptedConnectionString = configuration.GetConnectionString("dbConectionString");
            var connectionString = Secure.DecryptString(encryptedConnectionString, Utils.PassKey);

            optionsBuilder.UseNpgsql(connectionString);
            return new EunisDbContext(optionsBuilder.Options);
        }
    }

}
