using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eunis.Data.Models.Configuration {
    public class SettingsEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Settings> entityBuilder) {
            entityBuilder.ToTable("settings");
            entityBuilder.HasKey(s => s.Id).HasName("id");
            entityBuilder.Property(s => s.Id).HasColumnName("id");
            entityBuilder.Property(s => s.PostedOn).HasColumnName("postedon").IsRequired();
            entityBuilder.Property(s => s.ParamName).HasColumnName("paramname").HasMaxLength(225).IsRequired();
            entityBuilder.Property(s => s.ParamValue).HasColumnName("paramvalue").HasMaxLength(225).IsRequired();
        }
    }
}
