using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class ProductVariantValueConfiguration : IEntityTypeConfiguration<ProductVariantValue>
    {
        public void Configure(EntityTypeBuilder<ProductVariantValue> builder)
        {
            builder.HasKey(pvv => pvv.Id);

            builder.Property(pvv => pvv.Value)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasOne(pvv => pvv.ProductVariant)
                   .WithMany(pv => pv.VariantValues)
                   .HasForeignKey(pvv => pvv.ProductVariantId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pvv => pvv.PropertyDefinition)
                   .WithMany()
                   .HasForeignKey(pvv => pvv.PropertyDefinitionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pvv => pvv.ProductVariantId);
            builder.HasIndex(pvv => pvv.PropertyDefinitionId);
        }
    }
}
