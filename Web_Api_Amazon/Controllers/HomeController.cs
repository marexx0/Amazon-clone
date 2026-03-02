using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_Amazon.Models;
using Web_Api_Amazon.Entities;
using Amazon_clone.DataAccess.Data;
using DataAccess.Persistance;
namespace Web_Api_Amazon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopDbContext _context;
        public HomeController(ILogger<HomeController> logger, ShopDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index(string searchString, int? categoryId)
        {
            // ?? Всі товари
            var allProducts = _context.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .ToList();

            // ?? Початково всі
            var filteredProducts = _context.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .AsQueryable();

            // ?? Пошук
            if (!string.IsNullOrEmpty(searchString))
            {
                var searchLower = searchString.ToLower();
                filteredProducts = filteredProducts.Where(p =>
                    (p.Name != null && p.Name.ToLower().Contains(searchLower)) ||
                    (p.Description != null && p.Description.ToLower().Contains(searchLower)));
            }

            // ?? Фільтр категорії (залишаємо як є)
            if (categoryId.HasValue)
            {
                var childIds = _context.Categories
                    .Where(c => c.ParentCategoryId == categoryId.Value)
                    .Select(c => c.Id)
                    .ToList();

                if (childIds.Any())
                    filteredProducts = filteredProducts.Where(p => childIds.Contains(p.CategoryId));
                else
                    filteredProducts = filteredProducts.Where(p => p.CategoryId == categoryId.Value);
            }

            // ?? Відправляємо у View
            ViewBag.FilteredProducts = filteredProducts.ToList();
            ViewBag.SelectedCategoryId = categoryId;
            ViewBag.AllProducts = allProducts;
            ViewBag.SearchString = searchString;
            ViewBag.AllProducts = allProducts;
            ViewBag.Categories = _context.Categories.ToList();

            // ?? Додаємо категорії (з бази або сідера)
            var categories = _context.Categories.ToList(); // або CategorySeeder.GetCategories()
            ViewBag.Categories = categories;

            return View();
        }
        public IActionResult Profile()
        {
            return View("~/Views/Profile/Index.cshtml");
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