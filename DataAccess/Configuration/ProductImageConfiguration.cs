using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.FileName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(pi => pi.ContentType)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(pi => pi.ImageData)
                .IsRequired(false);

            builder.Property(pi => pi.ImageUrl)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(pi => pi.IsPrimary)
                .HasDefaultValue(false);

            builder.Property(pi => pi.SortOrder)
                .HasDefaultValue(0);

            builder.HasOne(pi => pi.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(pi => new { pi.ProductId, pi.IsPrimary });
        }
    }
}