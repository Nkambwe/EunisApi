using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eunis.Data.Models.Configuration {
    public class BankEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Bank> entityBuilder) {
            entityBuilder.ToTable("bank");
            entityBuilder.HasKey(b => b.Id).HasName("id");
            entityBuilder.Property(b => b.Id).HasColumnName("id");
            entityBuilder.Property(a => a.PostedOn).HasColumnName("postedon").HasColumnType("timestamp").IsRequired();
            entityBuilder.Property(b => b.BankName).HasColumnName("bankname").HasMaxLength(225).IsRequired();
            entityBuilder.Property(b => b.SortCode).HasColumnName("sortcode").HasMaxLength(225).IsRequired();
            entityBuilder.HasMany(b => b.BankAccounts).WithOne(a => a.Bank).HasForeignKey(b=> b.BankId);
        }
    }
}
