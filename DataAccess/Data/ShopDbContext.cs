using DataAccess.Persistance;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Amazon_clone.DataAccess.Data
{
    public class ShopDbContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);

            modelBuilder.Entity<Category>().HasData(CategorySeeder.GetCategories());
            modelBuilder.Entity<Product>().HasData(ProductSeeder.GetProducts());
            modelBuilder.Entity<ProductImage>().HasData(ProductImageSeeder.GetProductImages());
            modelBuilder.Entity<PropertyDefinition>().HasData(PropertySeeder.GetPropertyDefinitions());
            modelBuilder.Entity<CategoryProperty>().HasData(PropertySeeder.GetCategoryProperties());
            modelBuilder.Entity<ProductProperty>().HasData(PropertySeeder.GetProductProperties());
            modelBuilder.Entity<ProductVariant>().HasData(PropertySeeder.GetProductVariants());
            modelBuilder.Entity<ProductVariantValue>().HasData(PropertySeeder.GetProductVariantValues());
        }
    }
}
