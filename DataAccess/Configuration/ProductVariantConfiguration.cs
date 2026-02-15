using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasKey(pv => pv.Id);

            builder.Property(pv => pv.Quantity)
                   .IsRequired();

            builder.HasOne(pv => pv.Product)
                   .WithMany(p => p.Variants)
                   .HasForeignKey(pv => pv.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(pv => pv.ProductId);
        }
    }
}
