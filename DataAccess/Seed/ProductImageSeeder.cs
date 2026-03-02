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
                new ProductImage { Id = 26, ProductId = 22, FileName = "nike_dunk_cacao_angle.jpg", ContentType = "image/jpeg", ImageUrl = "/images/products/nike_dunk_cacao_angle.jpg", ImageData = null, IsPrimary = false, SortOrder = 4 },


                new ProductImage { Id = 27, ProductId = 23, FileName = "levis_501.png", ContentType = "image/png", ImageUrl = "/images/products/levis_501.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 28, ProductId = 24, FileName = "asics_kayano_30.jpg", ContentType = "image/jpg", ImageUrl = "/images/products/asics_kayano_30.jpg", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 29, ProductId = 25, FileName = "dell_xps_13_plus.png", ContentType = "image/png", ImageUrl = "/images/products/dell_xps_13_plus.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 30, ProductId = 26, FileName = "pixel_8_pro.png", ContentType = "image/png", ImageUrl = "/images/products/pixel_8_pro.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 31, ProductId = 27, FileName = "apple_watch_series_9.jpg", ContentType = "image/jpeg", ImageUrl = "/images/products/apple_watch_series_9.jpg", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 32, ProductId = 28, FileName = "nikon_z6_ii.png", ContentType = "image/png", ImageUrl = "/images/products/nikon_z6_ii.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 33, ProductId = 29, FileName = "xbox_series_x.png", ContentType = "image/png", ImageUrl = "/images/products/xbox_series_x.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 34, ProductId = 30, FileName = "malm_dresser.png", ContentType = "image/png", ImageUrl = "/images/products/malm_dresser.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 35, ProductId = 31, FileName = "bosch_12v_drill.png", ContentType = "image/png", ImageUrl = "/images/products/bosch_12v_drill.png", ImageData = null, IsPrimary = true, SortOrder = 0 },
                new ProductImage { Id = 36, ProductId = 32, FileName = "lego_10696.png", ContentType = "image/png", ImageUrl = "/images/products/lego_10696.png", ImageData = null, IsPrimary = true, SortOrder = 0 }



            };
        }
    }
}