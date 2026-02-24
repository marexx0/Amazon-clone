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

        public IActionResult Index(string searchString)
        {
            List<Product> products;

            if (_context.Products.Any())
            {
                var query = _context.Products
                    .Include(p => p.Images)
                    .Include(p => p.Category)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(searchString))
                    query = query.Where(p =>
                        p.Name.Contains(searchString) ||
                        p.Description.Contains(searchString));

                products = query.ToList();
            }
            else
            {
                products = ProductSeeder.GetProducts();

                if (!string.IsNullOrEmpty(searchString))
                    products = products
                        .Where(p =>
                            p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                            p.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                        .ToList();
            }

            return View(products);
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