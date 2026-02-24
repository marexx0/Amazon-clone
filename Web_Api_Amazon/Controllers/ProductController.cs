using System.Collections.Generic;
using System.Linq;
using Amazon_clone.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_Amazon.Models;
using Web_Api_Amazon.Entities;

namespace Web_Api_Amazon.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopDbContext _context;

        public ProductController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .ThenInclude(c => c.ParentCategory)
                .Include(p => p.Images)
                .Include(p => p.Properties)
                .ThenInclude(pp => pp.PropertyDefinition)
                .Include(p => p.Variants)
                .ThenInclude(v => v.VariantValues)
                .ThenInclude(vv => vv.PropertyDefinition)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            var images = product.Images?
                .OrderBy(i => i.SortOrder)
                .ToList() ?? new List<ProductImage>();

            if (!images.Any() && !string.IsNullOrWhiteSpace(product.ImageUrl))
            {
                images.Add(new ProductImage
                {
                    ImageUrl = product.ImageUrl,
                    IsPrimary = true,
                    SortOrder = 0
                });
            }

            var relatedProducts = await _context.Products
                .Include(p => p.Images)
                .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id)
                .OrderBy(p => p.Name)
                .Take(4)
                .ToListAsync();

            var relatedIds = relatedProducts.Select(p => p.Id).ToHashSet();
            var topPicks = await _context.Products
                .Include(p => p.Images)
                .Where(p => p.Id != product.Id && !relatedIds.Contains(p.Id))
                .OrderByDescending(p => p.Id)
                .Take(4)
                .ToListAsync();

            var availableColors = product.Variants?
                .SelectMany(v => v.VariantValues)
                .Where(vv => vv.PropertyDefinition?.Name == "Color")
                .Select(vv => vv.Value)
                .Distinct()
                .ToList() ?? new List<string>();

            var availableSizes = product.Variants?
                .SelectMany(v => v.VariantValues)
                .Where(vv => vv.PropertyDefinition?.Name == "Size")
                .Select(vv => vv.Value)
                .Distinct()
                .ToList() ?? new List<string>();

            var brand = product.Properties?
                .FirstOrDefault(pp => pp.PropertyDefinition?.Name == "Brand")
                ?.Value;

            var viewModel = new ProductDetailsViewModel
            {
                Product = product,
                Images = images,
                RelatedProducts = relatedProducts,
                TopPicks = topPicks,
                AvailableColors = availableColors,
                AvailableSizes = availableSizes,
                Brand = brand
            };

            return View(viewModel);
        }
    }
}
