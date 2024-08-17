using Eunis.Infrastructure.Data.Models;
using Eunis.Infrastructure.Data.Models.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Eunis.Infrastructure.Data {

    public class EunisDbContext : DbContext {

        public EunisDbContext(DbContextOptions<EunisDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            CredentialsEntityConfiguration.Configure(modelBuilder.Entity<Credentials>());
            SettingsEntityConfiguration.Configure(modelBuilder.Entity<Settings>());
            EunisTransactionEntityConfiguration.Configure(modelBuilder.Entity<EunisTransaction>());

            base.OnModelCreating(modelBuilder);
        }
    }

}
