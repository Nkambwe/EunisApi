using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eunis.Data.Models.Configuration {

    public class BankAccountEntityConfiguration {

        public static void Configure(EntityTypeBuilder<BankAccount> entityBuilder) {
            entityBuilder.ToTable("bankaccount");
            entityBuilder.HasKey(a => a.Id).HasName("id");
            entityBuilder.Property(a => a.Id).HasColumnName("id");
            entityBuilder.Property(a => a.PostedOn).HasColumnName("postedon").HasColumnType("timestamp").IsRequired();
            entityBuilder.Property(a => a.BankId).HasColumnName("bankid").HasColumnType("bigint").IsRequired();
            entityBuilder.Property(a => a.ClientId).HasColumnName("clientid").HasColumnType("bigint").IsRequired();
            entityBuilder.Property(a => a.AccountName).HasColumnName("accountname").HasMaxLength(225).IsRequired();
            entityBuilder.Property(a => a.AccountNumber).HasColumnName("accountnumber").HasMaxLength(40).IsRequired();
            entityBuilder.Property(a => a.IsDormant).HasColumnName("isdormant").HasColumnType("boolean").IsRequired();
            entityBuilder.Property(a => a.IsFrozen).HasColumnName("isfrozen").HasColumnType("boolean").IsRequired();
            entityBuilder.Property(a => a.FreezReason).HasColumnName("freezreason").HasMaxLength(225).IsRequired();
            entityBuilder.Property(a => a.Type).HasColumnName("type").HasColumnType("integer").IsRequired();
            entityBuilder.Property(a => a.CanWithdraw).HasColumnName("canwithdraw").HasColumnType("boolean").IsRequired();
            entityBuilder.Property(a => a.AllowOverdraft).HasColumnName("allowod").HasColumnType("boolean").IsRequired();
            entityBuilder.Property(a => a.CanDeposit).HasColumnName("candeposit").HasColumnType("boolean").IsRequired();
            entityBuilder.Property(a => a.CreatedOn).HasColumnName("createdon").HasColumnType("timestamp").IsRequired();
            entityBuilder.Property(a => a.CreatedBy).HasColumnName("createdby").HasMaxLength(10).IsRequired();
            entityBuilder.Property(a => a.ClosedOn).HasColumnName("closedon").HasColumnType("timestamp");
            entityBuilder.Property(a => a.LastTransactedOn).HasColumnName("lasttransactedon").HasColumnType("timestamp");
            entityBuilder.Property(a => a.Balance).HasColumnName("balance").HasPrecision(19,2).IsRequired();
            entityBuilder.HasOne(a => a.Bank).WithMany(b => b.BankAccounts).HasForeignKey(b => b.BankId);
            entityBuilder.HasOne(a => a.Client).WithMany(c => c.Accounts).HasForeignKey(c => c.ClientId);
        }

    }

}
