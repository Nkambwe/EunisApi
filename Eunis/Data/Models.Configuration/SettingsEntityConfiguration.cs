using Eunis.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eunis.Data.Models.Configuration
{
    public class SettingsEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<Settings> entityBuilder)
        {
            entityBuilder.HasKey(l => l.Id);
            entityBuilder.Property(l => l.PostedOn).IsRequired();
            entityBuilder.Property(l => l.ParamName).HasMaxLength(225).IsRequired();
            entityBuilder.Property(l => l.ParamName).HasMaxLength(225).IsRequired();
        }
    }
}
