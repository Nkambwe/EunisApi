using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eunis.Infrastructure.Data.Models.Configuration {
    public class CredentialsEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Credentials> entityBuilder) {
            entityBuilder.HasKey(c => c.Id);
            entityBuilder.Property(c => c.PostedOn).IsRequired();
            entityBuilder.Property(c => c.ClientId).HasMaxLength(int.MaxValue).IsRequired();
            entityBuilder.Property(c => c.Username).HasMaxLength(int.MaxValue).IsRequired();
            entityBuilder.Property(c => c.Password).HasMaxLength(int.MaxValue).IsRequired();
            entityBuilder.Property(c => c.SecretKey).HasMaxLength(int.MaxValue).IsRequired();
            entityBuilder.Property(c => c.Actions).HasMaxLength(int.MaxValue).IsRequired();
            entityBuilder.HasMany( c => c.Transactions).WithOne(e => e.Client).HasForeignKey(l => l.CredentialsId);
            
        }
    }
}
