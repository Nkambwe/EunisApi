using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eunis.Data.Models.Configuration {
    public class EunisTransactionEntityConfiguration {
        public static void Configure(EntityTypeBuilder<EuniceTransaction> entityBuilder) {
            entityBuilder.ToTable("transactions");
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.HasOne(t => t.Client).WithMany(e => e.Transactions).HasForeignKey(l => l.CredentialsId);
            entityBuilder.Property(t => t.CredentialsId).IsRequired();
            entityBuilder.Property(t => t.ClientId).IsRequired();
            entityBuilder.Property(t => t.PostedOn).IsRequired();
            entityBuilder.Property(t => t.RequestId).IsRequired();
            entityBuilder.Property(t => t.BeneficiaryName).HasMaxLength(120).IsRequired();
            entityBuilder.Property(t => t.BeneficiaryAccount).HasMaxLength(50).IsRequired();
            entityBuilder.Property(t => t.MobileNumber).HasMaxLength(25).IsRequired();
            entityBuilder.Property(t => t.Particulars).HasMaxLength(225).IsRequired();
            entityBuilder.Property(t => t.Amount).HasPrecision(9, 2).IsRequired();
            entityBuilder.Property(t => t.Destination).HasMaxLength(40).IsRequired();
            entityBuilder.Property(t => t.Network).HasMaxLength(40).IsRequired();
            entityBuilder.Property(t => t.StatusCode).HasMaxLength(10).IsRequired();
            entityBuilder.Property(t => t.VendorReference).HasMaxLength(20).IsRequired();
            entityBuilder.Property(t => t.VendorMessage).HasMaxLength(225).IsRequired();

        }
    }
}
