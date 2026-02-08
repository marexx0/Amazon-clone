using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class CategoryPropertyConfiguration : IEntityTypeConfiguration<CategoryProperty>
    {
        public void Configure(EntityTypeBuilder<CategoryProperty> builder)
        {
            builder.HasKey(cp => new { cp.CategoryId, cp.PropertyDefinitionId });

            builder.HasOne(cp => cp.Category)
                   .WithMany(c => c.CategoryProperties)
                   .HasForeignKey(cp => cp.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cp => cp.PropertyDefinition)
                   .WithMany(pd => pd.CategoryProperties)
                   .HasForeignKey(cp => cp.PropertyDefinitionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(cp => cp.IsRequired)
                   .IsRequired();

            builder.Property(cp => cp.IsVariantOption)
                   .IsRequired();
        }
    }
}
