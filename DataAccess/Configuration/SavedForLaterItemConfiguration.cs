using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class SavedForLaterItemConfiguration : IEntityTypeConfiguration<SavedForLaterItem>
    {
        public void Configure(EntityTypeBuilder<SavedForLaterItem> builder)
        {
            builder.HasKey(sfl => sfl.Id);

            builder.Property(sfl => sfl.UserId)
                .IsRequired();

            builder.Property(sfl => sfl.Quantity)
                .IsRequired();

            builder.Property(sfl => sfl.VariantKey)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(sfl => sfl.SelectedOptionsJson)
                .IsRequired();

            builder.Property(sfl => sfl.CreatedAtUtc)
                .IsRequired();

            builder.HasOne(sfl => sfl.User)
                .WithMany(u => u.SavedForLaterItems)
                .HasForeignKey(sfl => sfl.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sfl => sfl.Product)
                .WithMany(p => p.SavedForLaterItems)
                .HasForeignKey(sfl => sfl.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(sfl => new { sfl.UserId, sfl.ProductId, sfl.VariantKey })
                .IsUnique();
        }
    }
}