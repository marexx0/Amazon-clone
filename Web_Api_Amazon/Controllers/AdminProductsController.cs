using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Api_Amazon.Entities;
using Amazon_clone.DataAccess.Data;
using System.IO;

namespace Web_Api_Amazon.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProductsController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminProductsController(ShopDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // LIST ALL PRODUCTS
        public IActionResult Index()
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Properties)
                .Include(p => p.Variants)
                .ThenInclude(v => v.VariantValues)
                .ThenInclude(vv => vv.PropertyDefinition)
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
            RemoveNonFormModelStateEntries();

            if (model.CategoryId <= 0)
            {
                ModelState.AddModelError(nameof(Product.CategoryId), "Please select a category.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
                return View(model);
            }

            //  
            if (ImagesFiles != null && ImagesFiles.Count > 0)
            {
                model.Images = new List<ProductImage>();
                var imageFiles = ImagesFiles.Where(file => file.Length > 0).ToList();

                for (int i = 0; i < imageFiles.Count; i++)
                {
                    var file = imageFiles[i];
                    var imageUrl = await SaveProductImageAsync(file);

                    using var ms = new MemoryStream();
                    await file.CopyToAsync(ms);

                    model.Images.Add(new ProductImage
                    {
                        FileName = Path.GetFileName(imageUrl),
                        ContentType = file.ContentType,
                        ImageData = ms.ToArray(),
                        ImageUrl = imageUrl,
                        IsPrimary = i == 0,
                        SortOrder = i
                    });
                }

                model.ImageUrl = model.Images.FirstOrDefault(i => i.IsPrimary)?.ImageUrl ?? "/images/products/sneakers.png";
            }
            else
            {
                model.ImageUrl = "/images/products/sneakers.png";
            }

            model.Properties = (model.Properties ?? new List<ProductProperty>())
                .Where(p => !string.IsNullOrWhiteSpace(p.Name) && !string.IsNullOrWhiteSpace(p.Value))
                .ToList();


            model.Variants = await BuildVariantsAsync(model.Variants);

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

            RemoveNonFormModelStateEntries();

            if (model.CategoryId <= 0)
            {
                ModelState.AddModelError(nameof(Product.CategoryId), "Please select a category.");
            }

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
            var normalizedVariants = await BuildVariantsAsync(model.Variants);
            foreach (var variant in normalizedVariants)
            {
                product.Variants.Add(variant);
            }


            if (ImagesFiles != null && ImagesFiles.Count > 0)
            {
                product.Images.Clear();
                var imageFiles = ImagesFiles.Where(file => file.Length > 0).ToList();

                for (int i = 0; i < imageFiles.Count; i++)
                {
                    var file = imageFiles[i];
                    var imageUrl = await SaveProductImageAsync(file);

                    using var ms = new MemoryStream();
                    await file.CopyToAsync(ms);

                    product.Images.Add(new ProductImage
                    {
                        FileName = Path.GetFileName(imageUrl),
                        ContentType = file.ContentType,
                        ImageData = ms.ToArray(),
                        ImageUrl = imageUrl,
                        IsPrimary = i == 0,
                        SortOrder = i
                    });
                }

                product.ImageUrl = product.Images.FirstOrDefault(i => i.IsPrimary)?.ImageUrl ?? product.ImageUrl;
            }


            await _context.SaveChangesAsync();
            TempData["Success"] = "Product updated successfully.";
            return RedirectToAction("Index", "AdminProducts");
        }

        private async Task<List<ProductVariant>> BuildVariantsAsync(List<ProductVariant>? rawVariants)
        {
            var variants = (rawVariants ?? new List<ProductVariant>())
                .Where(v => !string.IsNullOrWhiteSpace(v.Name)
                            || !string.IsNullOrWhiteSpace(v.Value)
                            || v.Quantity > 0)
                .ToList();

            var definitions = await _context.Set<PropertyDefinition>().ToListAsync();
            var definitionMap = definitions
                .Where(d => !string.IsNullOrWhiteSpace(d.Name))
                .ToDictionary(d => d.Name.Trim(), d => d, StringComparer.OrdinalIgnoreCase);

            var normalizedVariants = new List<ProductVariant>();

            foreach (var variant in variants)
            {
                var variantName = variant.Name?.Trim() ?? string.Empty;
                var variantValue = variant.Value?.Trim() ?? string.Empty;

                var names = variantName
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .ToList();
                var values = variantValue
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .ToList();

                var pairCount = Math.Min(names.Count, values.Count);
                var variantValues = new List<ProductVariantValue>();

                for (int i = 0; i < pairCount; i++)
                {
                    var name = names[i];
                    var value = values[i];

                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(value))
                    {
                        continue;
                    }

                    if (!definitionMap.TryGetValue(name, out var definition))
                    {
                        definition = new PropertyDefinition
                        {
                            Name = name,
                            DataType = PropertyDataType.Text,
                            GroupName = "Variant",
                            CategoryProperties = new List<CategoryProperty>(),
                            ProductProperties = new List<ProductProperty>()
                        };
                        _context.Add(definition);
                        definitionMap[name] = definition;
                    }

                    variantValues.Add(new ProductVariantValue
                    {
                        PropertyDefinition = definition,
                        Value = value.Trim()
                    });
                }

                normalizedVariants.Add(new ProductVariant
                {
                    Name = pairCount > 0 ? names[0] : variantName,
                    Value = pairCount > 0 ? values[0] : variantValue,
                    Quantity = Math.Max(0, variant.Quantity),
                    VariantValues = variantValues
                });
            }

            var mergedByCombination = normalizedVariants
                .GroupBy(v => BuildVariantCombinationKey(v), StringComparer.OrdinalIgnoreCase)
                .Select(group =>
                {
                    var first = group.First();
                    var mergedVariantValues = group
                        .SelectMany(v => v.VariantValues ?? Enumerable.Empty<ProductVariantValue>())
                        .GroupBy(vv => $"{vv.PropertyDefinition?.Name?.Trim()?.ToLowerInvariant()}::{vv.Value?.Trim()?.ToLowerInvariant()}")
                        .Select(g => g.First())
                        .ToList();

                    return new ProductVariant
                    {
                        Name = first.Name,
                        Value = first.Value,
                        Quantity = group.Sum(v => Math.Max(0, v.Quantity)),
                        VariantValues = mergedVariantValues
                    };
                })
                .ToList();

            return mergedByCombination;
        }


        private static string BuildVariantCombinationKey(ProductVariant variant)
        {
            var values = (variant.VariantValues ?? new List<ProductVariantValue>())
                .Where(vv => !string.IsNullOrWhiteSpace(vv.PropertyDefinition?.Name) && !string.IsNullOrWhiteSpace(vv.Value))
                .Select(vv => $"{vv.PropertyDefinition!.Name.Trim().ToLowerInvariant()}={vv.Value!.Trim().ToLowerInvariant()}")
                .OrderBy(v => v)
                .ToList();

            if (values.Any())
            {
                return string.Join("|", values);
            }

            return $"name={variant.Name?.Trim().ToLowerInvariant()}|value={variant.Value?.Trim().ToLowerInvariant()}";
        }
        private void RemoveNonFormModelStateEntries()
        {
            ModelState.Remove(nameof(Product.ImageUrl));
            ModelState.Remove(nameof(Product.Category));
            ModelState.Remove(nameof(Product.CartItems));
            ModelState.Remove(nameof(Product.OrderItems));
            ModelState.Remove(nameof(Product.FavoriteItems));
            ModelState.Remove(nameof(Product.SavedForLaterItems));
            ModelState.Remove("Properties[].Product");
            ModelState.Remove("Variants[].Product");
            ModelState.Remove("Variants[].VariantValues");
        }

        private async Task<string> SaveProductImageAsync(IFormFile file)
        {
            var uploadsDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");
            Directory.CreateDirectory(uploadsDirectory);

            var extension = Path.GetExtension(file.FileName);
            var safeExtension = string.IsNullOrWhiteSpace(extension) ? ".jpg" : extension;
            var uniqueFileName = $"{Guid.NewGuid():N}{safeExtension}";
            var destinationPath = Path.Combine(uploadsDirectory, uniqueFileName);

            await using var stream = new FileStream(destinationPath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/images/products/{uniqueFileName}";
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