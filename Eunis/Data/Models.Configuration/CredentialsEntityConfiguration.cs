using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eunis.Data.Models.Configuration {
    public class CredentialsEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Credentials> entityBuilder) {
            entityBuilder.ToTable("credentials");
            entityBuilder.HasKey(c => c.Id);
            entityBuilder.Property(c => c.Id).HasColumnName("id");
            entityBuilder.Property(c => c.PostedOn).HasColumnName("postedon").IsRequired();
            entityBuilder.Property(c => c.ClientId).HasColumnName("clientid").HasMaxLength(int.MaxValue).IsRequired();
            entityBuilder.Property(c => c.ClientCode).HasColumnName("clientcode").HasMaxLength(int.MaxValue).IsRequired();
            entityBuilder.Property(c => c.Username).HasColumnName("username").HasMaxLength(int.MaxValue).IsRequired();
            entityBuilder.Property(c => c.Password).HasColumnName("password").HasMaxLength(int.MaxValue).IsRequired();
            entityBuilder.Property(c => c.SecretKey).HasColumnName("secretkey").HasMaxLength(int.MaxValue).IsRequired();
            entityBuilder.Property(c => c.Actions).HasColumnName("actions").HasMaxLength(int.MaxValue).IsRequired();
            entityBuilder.HasMany(c => c.Transactions).WithOne(e => e.Client).HasForeignKey(l => l.CredentialsId);

        }
    }
}
