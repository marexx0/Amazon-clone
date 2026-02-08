using System.Collections.Generic;

namespace DataAccess.Persistance
{
    public static class ProductImageSeeder
    {
        public static List<ProductImage> GetProductImages()
        {
            return new List<ProductImage>
            {
                new ProductImage { Id = 1, ProductId = 1, FileName = "tshirt.png", ContentType = "image/png", ImageUrl = "/images/products/tshirt.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 2, ProductId = 2, FileName = "sneakers.png", ContentType = "image/png", ImageUrl = "/images/products/sneakers.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 3, ProductId = 3, FileName = "macbook_air_m2.png", ContentType = "image/png", ImageUrl = "/images/products/macbook_air_m2.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 4, ProductId = 4, FileName = "galaxy_s24.png", ContentType = "image/png", ImageUrl = "/images/products/galaxy_s24.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 5, ProductId = 5, FileName = "sony_xm5.png", ContentType = "image/png", ImageUrl = "/images/products/sony_xm5.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 6, ProductId = 6, FileName = "canon_r10.png", ContentType = "image/png", ImageUrl = "/images/products/canon_r10.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 7, ProductId = 7, FileName = "ps5.png", ContentType = "image/png", ImageUrl = "/images/products/ps5.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 8, ProductId = 8, FileName = "wall_clock.png", ContentType = "image/png", ImageUrl = "/images/products/wall_clock.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 9, ProductId = 9, FileName = "dining_table.png", ContentType = "image/png", ImageUrl = "/images/products/dining_table.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 10, ProductId = 10, FileName = "desk_lamp.png", ContentType = "image/png", ImageUrl = "/images/products/desk_lamp.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 11, ProductId = 11, FileName = "garden_tools.png", ContentType = "image/png", ImageUrl = "/images/products/garden_tools.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 12, ProductId = 12, FileName = "drill.png", ContentType = "image/png", ImageUrl = "/images/products/drill.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 13, ProductId = 13, FileName = "concrete.png", ContentType = "image/png", ImageUrl = "/images/products/concrete.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 14, ProductId = 14, FileName = "dumbbells.png", ContentType = "image/png", ImageUrl = "/images/products/dumbbells.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 15, ProductId = 15, FileName = "car_holder.png", ContentType = "image/png", ImageUrl = "/images/products/car_holder.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 16, ProductId = 16, FileName = "blocks.png", ContentType = "image/png", ImageUrl = "/images/products/blocks.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 17, ProductId = 17, FileName = "csharp_book.png", ContentType = "image/png", ImageUrl = "/images/products/csharp_book.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 18, ProductId = 18, FileName = "vitamin_c.png", ContentType = "image/png", ImageUrl = "/images/products/vitamin_c.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 19, ProductId = 19, FileName = "wireless_mouse.png", ContentType = "image/png", ImageUrl = "/images/products/wireless_mouse.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 20, ProductId = 20, FileName = "smart_watch.png", ContentType = "image/png", ImageUrl = "/images/products/smart_watch.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 21, ProductId = 21, FileName = "yoga_mat.png", ContentType = "image/png", ImageUrl = "/images/products/yoga_mat.png", ImageData = null, IsPrimary = true, SortOrder = 0 }
            };
        }
    }
}