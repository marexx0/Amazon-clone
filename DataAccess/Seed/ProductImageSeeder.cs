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

                // Nike Dunk Low Retro - Cacao Wow (product 22)
                new ProductImage { Id = 22, ProductId = 22, FileName = "nike_dunk_cacao_pair.jpg", ContentType = "image/jpeg", ImageUrl = "/images/products/nike_dunk_cacao_pair.jpg", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 23, ProductId = 22, FileName = "nike_dunk_cacao_outsole.jpg", ContentType = "image/jpeg", ImageUrl = "/images/products/nike_dunk_cacao_outsole.jpg", ImageData = null, IsPrimary = false, SortOrder = 1 },
                new ProductImage { Id = 24, ProductId = 22, FileName = "nike_dunk_cacao_top.jpg", ContentType = "image/jpeg", ImageUrl = "/images/products/nike_dunk_cacao_top.jpg", ImageData = null, IsPrimary = false, SortOrder = 2 },
                new ProductImage { Id = 25, ProductId = 22, FileName = "nike_dunk_cacao_side.jpg", ContentType = "image/jpeg", ImageUrl = "/images/products/nike_dunk_cacao_side.jpg", ImageData = null, IsPrimary = false, SortOrder = 3 },
                new ProductImage { Id = 26, ProductId = 22, FileName = "nike_dunk_cacao_angle.jpg", ContentType = "image/jpeg", ImageUrl = "/images/products/nike_dunk_cacao_angle.jpg", ImageData = null, IsPrimary = false, SortOrder = 4 }
            
                
                

            };
        }
    }
}