using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Web_Api_Amazon.Models;
using Web_Api_Amazon.Entities;
using Amazon_clone.DataAccess.Data;
using DataAccess.Persistance;

namespace Web_Api_Amazon.Controllers
{
    public class HomeController : Controller
    {
        private const string HomepageProductsCacheKey = "home:products";
        private const string HomepageCategoriesCacheKey = "home:categories";

        private readonly ILogger<HomeController> _logger;
        private readonly ShopDbContext _context;
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, ShopDbContext context, IMemoryCache cache)
        {
            _logger = logger;
            _context = context;
            _cache = cache;
        }

        public async Task<IActionResult> Index(string searchString, int? categoryId)
        {
            var allProducts = await _cache.GetOrCreateAsync(HomepageProductsCacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
                return await _context.Products
                    .AsNoTracking()
                    .Include(p => p.Images)
                    .Include(p => p.Category)
                    .ToListAsync();
            }) ?? new List<Product>();

            var categories = await _cache.GetOrCreateAsync(HomepageCategoriesCacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                return await _context.Categories
                    .AsNoTracking()
                    .ToListAsync();
            }) ?? new List<Category>();

            IEnumerable<Product> filteredProducts = allProducts;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var searchLower = searchString.Trim().ToLowerInvariant();
                filteredProducts = filteredProducts.Where(p =>
                    (!string.IsNullOrEmpty(p.Name) && p.Name.ToLowerInvariant().Contains(searchLower)) ||
                    (!string.IsNullOrEmpty(p.Description) && p.Description.ToLowerInvariant().Contains(searchLower)));
            }

            if (categoryId.HasValue)
            {
                var childIds = categories
                    .Where(c => c.ParentCategoryId == categoryId.Value)
                    .Select(c => c.Id)
                    .ToList();

                filteredProducts = childIds.Any()
                    ? filteredProducts.Where(p => childIds.Contains(p.CategoryId))
                    : filteredProducts.Where(p => p.CategoryId == categoryId.Value);
            }

            ViewBag.FilteredProducts = filteredProducts.ToList();
            ViewBag.SelectedCategoryId = categoryId;
            ViewBag.AllProducts = allProducts;
            ViewBag.SearchString = searchString;
            ViewBag.Categories = categories;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}