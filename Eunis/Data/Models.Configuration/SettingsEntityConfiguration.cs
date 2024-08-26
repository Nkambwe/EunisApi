using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eunis.Data.Models.Configuration {
    public class SettingsEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Settings> entityBuilder) {
            entityBuilder.ToTable("settings");
            entityBuilder.HasKey(l => l.Id).HasName("id");
            entityBuilder.Property(l => l.PostedOn).IsRequired();
            entityBuilder.Property(l => l.ParamName).HasMaxLength(225).IsRequired();
            entityBuilder.Property(l => l.ParamName).HasMaxLength(225).IsRequired();
        }
    }
}
