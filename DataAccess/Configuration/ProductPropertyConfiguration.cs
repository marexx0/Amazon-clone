using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class ProductPropertyConfiguration : IEntityTypeConfiguration<ProductProperty>
    {
        public void Configure(EntityTypeBuilder<ProductProperty> builder)
        {
            builder.HasKey(pp => pp.Id);

            builder.Property(pp => pp.Value)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.HasOne(pp => pp.Product)
                   .WithMany(p => p.Properties)
                   .HasForeignKey(pp => pp.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.PropertyDefinition)
                   .WithMany(pd => pd.ProductProperties)
                   .HasForeignKey(pp => pp.PropertyDefinitionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pp => pp.ProductId);
            builder.HasIndex(pp => pp.PropertyDefinitionId);
        }
    }
}
