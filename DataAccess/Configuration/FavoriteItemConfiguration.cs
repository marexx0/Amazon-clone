
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class FavoriteItemConfiguration : IEntityTypeConfiguration<FavoriteItem>
    {
        public void Configure(EntityTypeBuilder<FavoriteItem> builder)
        {
            builder.HasKey(fi => fi.Id);

            builder.Property(fi => fi.UserId)
                .IsRequired();

            builder.Property(fi => fi.CreatedAtUtc)
                .IsRequired();

            builder.HasOne(fi => fi.User)
                .WithMany(u => u.FavoriteItems)
                .HasForeignKey(fi => fi.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fi => fi.Product)
                .WithMany(p => p.FavoriteItems)
                .HasForeignKey(fi => fi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(fi => new { fi.UserId, fi.ProductId })
                .IsUnique();
        }
    }
}