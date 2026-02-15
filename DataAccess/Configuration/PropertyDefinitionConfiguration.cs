using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class PropertyDefinitionConfiguration : IEntityTypeConfiguration<PropertyDefinition>
    {
        public void Configure(EntityTypeBuilder<PropertyDefinition> builder)
        {
            builder.HasKey(pd => pd.Id);

            builder.Property(pd => pd.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(pd => pd.DataType)
                   .IsRequired()
                   .HasConversion<string>();

            builder.Property(pd => pd.GroupName)
                   .HasMaxLength(50);

            builder.HasIndex(pd => pd.Name);
        }
    }
}
