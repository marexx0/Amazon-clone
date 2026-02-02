using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistance
{
    public static class CategorySeeder
    {
        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                //Main categories
                new Category { Id = 1, Name = "Lifestyle", ParentCategoryId = null },
                new Category { Id = 2, Name = "Technology", ParentCategoryId = null },
                new Category { Id = 3, Name = "Home", ParentCategoryId = null },
                new Category { Id = 4, Name = "Auto", ParentCategoryId = null },
                new Category { Id = 5, Name = "Health", ParentCategoryId = null },

                //Lifestyle subcategories
                new Category { Id = 6, Name = "Clothing", ParentCategoryId = 1 },
                new Category { Id = 7, Name = "Shoes", ParentCategoryId = 1 },

                //Technology subcategories
                new Category { Id = 8, Name = "Computers / Laptops / Tablets", ParentCategoryId = 2 },
                new Category { Id = 9, Name = "Mobile Phones", ParentCategoryId = 2 },
                new Category { Id = 10, Name = "Audio and Wearables", ParentCategoryId = 2 },
                new Category { Id = 11, Name = "Cameras / Photo Equipment", ParentCategoryId = 2 },
                new Category { Id = 12, Name = "Gaming", ParentCategoryId = 2 },

                //Home subcategories
                new Category { Id = 13, Name = "Home Decor", ParentCategoryId = 3 },
                new Category { Id = 14, Name = "Furniture", ParentCategoryId = 3 },
                new Category { Id = 15, Name = "Lighting", ParentCategoryId = 3 },
                new Category { Id = 16, Name = "Yard and Garden", ParentCategoryId = 3 },
                new Category { Id = 17, Name = "Tools / Hardware / Plumbing", ParentCategoryId = 3 },
                new Category { Id = 18, Name = "Building Materials", ParentCategoryId = 3 },

                //Auto subcategories
                new Category { Id = 19, Name = "Sports / Outdoor / Fitness", ParentCategoryId = 4 },
                new Category { Id = 20, Name = "Auto Parts / Accessories", ParentCategoryId = 4 },

                //Health subcategories
                new Category { Id = 21, Name = "Toys Kids", ParentCategoryId = 5 },
                new Category { Id = 22, Name = "Books / Media", ParentCategoryId = 5 },
                new Category { Id = 23, Name = "Health", ParentCategoryId = 5 }
            };
        }
    }
}
