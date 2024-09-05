using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eunis.Data.Models.Configuration {
    public class ClientEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Client> entityBuilder) {
            entityBuilder.ToTable("clients");
            entityBuilder.HasKey(c => c.Id).HasName("id");
            entityBuilder.Property(c => c.Id).HasColumnName("id");
            entityBuilder.Property(a => a.PostedOn).HasColumnName("postedon").HasColumnType("timestamp").IsRequired();
            entityBuilder.Property(c => c.FirstName).HasColumnName("firstname").HasMaxLength(80).IsRequired();
            entityBuilder.Property(c => c.MiddleName).HasColumnName("middlename").HasMaxLength(40);
            entityBuilder.Property(c => c.LastName).HasColumnName("lastname").HasMaxLength(80).IsRequired();
            entityBuilder.Property(c => c.DateOfBirth).HasColumnName("dateofbirth").HasColumnType("timestamp").IsRequired();
            entityBuilder.Property(c => c.EmailAddress).HasColumnName("email").HasMaxLength(225);
            entityBuilder.Property(c => c.PhysicalAddress).HasColumnName("physicaladdress").HasMaxLength(225);
            entityBuilder.Property(c => c.PostalAddress).HasColumnName("postaladdress").HasMaxLength(225);
            entityBuilder.Property(c => c.EmploymentType).HasColumnName("emptype").HasColumnType("integer").IsRequired();
            entityBuilder.HasMany(c => c.Accounts).WithOne(a => a.Client).HasForeignKey(c => c.ClientId);
        }

    }

}
