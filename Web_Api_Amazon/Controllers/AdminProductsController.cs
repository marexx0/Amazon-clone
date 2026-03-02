using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Api_Amazon.Entities;
using Amazon_clone.DataAccess.Data;

namespace Web_Api_Amazon.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProductsController : Controller
    {
        private readonly ShopDbContext _context;

        public AdminProductsController(ShopDbContext context)
        {
            _context = context;
        }

        // LIST ALL PRODUCTS
        public IActionResult Index()
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Properties)
                .Include(p => p.Variants)
                .Include(p => p.Images)
                .ToList();
            return View(products);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View(new Product
            {
                Properties = new List<ProductProperty>(),
                Variants = new List<ProductVariant>(),
                Images = new List<ProductImage>()
            });
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model, List<IFormFile> ImagesFiles)
        {
            // Прибираємо ImageUrl з валідації — ми самі його встановимо
            ModelState.Remove("ImageUrl");
            // Прибираємо навігаційні властивості з валідації
            ModelState.Remove("Category");

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
                return View(model);
            }

            // Обробка фото
            if (ImagesFiles != null && ImagesFiles.Count > 0)
            {
                model.Images = new List<ProductImage>();
                foreach (var file in ImagesFiles)
                {
                    using var ms = new MemoryStream();
                    await file.CopyToAsync(ms);
                    model.Images.Add(new ProductImage
                    {
                        FileName = file.FileName,
                        ContentType = file.ContentType,
                        ImageData = ms.ToArray(),
                        ImageUrl = file.FileName,
                        IsPrimary = file == ImagesFiles[0],
                        SortOrder = ImagesFiles.IndexOf(file)
                    });
                }
                model.ImageUrl = ImagesFiles[0].FileName;
            }
            else
            {
                model.ImageUrl = "sneakers.png";
            }

            model.Properties = (model.Properties ?? new List<ProductProperty>())
                .Where(p => !string.IsNullOrWhiteSpace(p.Name) && !string.IsNullOrWhiteSpace(p.Value))
                .ToList();

           
            model.Variants = (model.Variants ?? new List<ProductVariant>())
                .Where(v => !string.IsNullOrWhiteSpace(v.Name) && !string.IsNullOrWhiteSpace(v.Value))
                .ToList();

            _context.Products.Add(model);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"Product '{model.Name}' created successfully.";
            return RedirectToAction(nameof(Index));
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var product = _context.Products
                .Include(p => p.Properties)
                .ThenInclude(pp => pp.PropertyDefinition)
                .Include(p => p.Variants)
                .ThenInclude(v => v.VariantValues)
                .ThenInclude(vv => vv.PropertyDefinition)
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product model, List<IFormFile> ImagesFiles)
        {
            
            ModelState.Remove("ImageUrl");
            ModelState.Remove("Category");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                TempData["Error"] = string.Join(", ", errors);
                ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
                return View(model);
            }

            var product = _context.Products
                .Include(p => p.Properties)
                .Include(p => p.Variants)
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == model.Id);

            if (product == null)
                return NotFound();

            
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;

           
            product.Properties.Clear();
            if (model.Properties != null)
            {
                foreach (var prop in model.Properties
                    .Where(p => !string.IsNullOrWhiteSpace(p.Name) &&
                                !string.IsNullOrWhiteSpace(p.Value)))
                {
                    product.Properties.Add(new ProductProperty
                    {
                        Name = prop.Name,
                        Value = prop.Value
                    });
                }
            }

            
            product.Variants.Clear();
            if (model.Variants != null)
            {
                foreach (var variant in model.Variants
                    .Where(v => !string.IsNullOrWhiteSpace(v.Name) &&
                                !string.IsNullOrWhiteSpace(v.Value)))
                {
                    product.Variants.Add(new ProductVariant
                    {
                        Name = variant.Name,
                        Value = variant.Value
                    });
                }
            }

            
            if (ImagesFiles != null && ImagesFiles.Count > 0)
            {
                product.Images.Clear();
                foreach (var file in ImagesFiles)
                {
                    using var ms = new MemoryStream();
                    await file.CopyToAsync(ms);
                    product.Images.Add(new ProductImage
                    {
                        FileName = file.FileName,
                        ContentType = file.ContentType,
                        ImageData = ms.ToArray(),
                        ImageUrl = file.FileName,
                        IsPrimary = file == ImagesFiles[0],
                        SortOrder = ImagesFiles.IndexOf(file)
                    });
                }
                product.ImageUrl = ImagesFiles[0].FileName;
            }
           

            await _context.SaveChangesAsync();
            TempData["Success"] = "Product updated successfully.";
            return RedirectToAction("Index", "AdminProducts");
        }

        // DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = _context.Products
                .Include(p => p.Properties)
                .Include(p => p.Variants)
                .Include(p => p.Images)
                .FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Product deleted successfully.";
            }

            return RedirectToAction("Index", "AdminProducts");
        }
    }
}