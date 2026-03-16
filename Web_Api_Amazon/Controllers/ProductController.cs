using Amazon_clone.DataAccess.Data;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using Web_Api_Amazon.Models;
using Web_Api_Amazon.Entities;

namespace Web_Api_Amazon.Controllers
{
    public class ProductController : Controller
    {
        private const string LocalFavoritesSessionKey = "LocalFavorites";
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IFavoritesService _favoritesService;

        public ProductController(ShopDbContext context, IWebHostEnvironment environment, IFavoritesService favoritesService)
        {
            _context = context;
            _environment = environment;
            _favoritesService = favoritesService;
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .AsNoTracking()
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

            if (images.Count <= 1 && !string.IsNullOrWhiteSpace(product.ImageUrl))
            {
                images = EnrichImagesFromFiles(images, product.ImageUrl, product.Id);
            }

            var relatedProducts = await _context.Products
                .AsNoTracking()
                .Include(p => p.Images)
                .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id)
                .OrderBy(p => p.Name)
                .Take(4)
                .ToListAsync();

            var relatedIds = relatedProducts.Select(p => p.Id).ToHashSet();
            var monthSeed = DateTime.UtcNow.Year * 100 + DateTime.UtcNow.Month;

            var topPickCandidates = await _context.Products
                .AsNoTracking()
                .Include(p => p.Images)
                .Include(p => p.Variants)
                .Where(p => p.Id != product.Id && !relatedIds.Contains(p.Id))
                .ToListAsync();

            var topPicks = topPickCandidates
                .OrderByDescending(p => p.Variants.Sum(v => v.Quantity) > 0 || !p.Variants.Any())
                .ThenBy(p => Math.Abs(HashCode.Combine(p.Id, monthSeed)))
                .Take(8)
                .ToList();

            var variantSummaries = product.Variants?
                           .Where(v => !string.IsNullOrWhiteSpace(v.Name)
                                       || !string.IsNullOrWhiteSpace(v.Value)
                                       || v.Quantity > 0
                                       || (v.VariantValues?.Any() ?? false))
                           .Select(v =>
                           {
                               var optionMap = (v.VariantValues ?? new List<ProductVariantValue>())
                                   .Where(vv => !string.IsNullOrWhiteSpace(vv.PropertyDefinition?.Name) && !string.IsNullOrWhiteSpace(vv.Value))
                                   .GroupBy(vv => vv.PropertyDefinition!.Name.Trim(), StringComparer.OrdinalIgnoreCase)
                                   .ToDictionary(g => g.First().PropertyDefinition!.Name.Trim(), g => g.First().Value!.Trim(), StringComparer.OrdinalIgnoreCase);

                               if (optionMap.Count == 0)
                               {
                                   if (!string.IsNullOrWhiteSpace(v.Name) && !string.IsNullOrWhiteSpace(v.Value))
                                   {
                                       optionMap[v.Name.Trim()] = v.Value.Trim();
                                   }
                                   else if (!string.IsNullOrWhiteSpace(v.Name))
                                   {
                                       optionMap["Option"] = v.Name.Trim();
                                   }
                                   else if (!string.IsNullOrWhiteSpace(v.Value))
                                   {
                                       optionMap["Option"] = v.Value.Trim();
                                   }
                               }

                               return new ProductVariantSummaryViewModel
                               {
                                   Options = optionMap,
                                   Quantity = Math.Max(0, v.Quantity)
                               };
                           })
                           .ToList() ?? new List<ProductVariantSummaryViewModel>();

            var optionGroups = variantSummaries
                .SelectMany(v => v.Options)
                .GroupBy(kv => kv.Key, StringComparer.OrdinalIgnoreCase)
                .Select(group => new ProductVariantOptionGroupViewModel
                {
                    Name = group.First().Key,
                    Values = group.Select(kv => kv.Value?.Trim())
                        .Where(value => !string.IsNullOrWhiteSpace(value))
                        .Select(value => value!)
                        .Distinct(StringComparer.OrdinalIgnoreCase)
                        .ToList(),
                    IsColor = string.Equals(group.First().Key, "Color", StringComparison.OrdinalIgnoreCase)
                })
                .Where(group => group.Values.Any())
                .OrderBy(group => string.Equals(group.Name, "Color", StringComparison.OrdinalIgnoreCase) ? 0 :
                                  string.Equals(group.Name, "Size", StringComparison.OrdinalIgnoreCase) ? 1 : 2)
                .ThenBy(group => group.Name)
                .ToList();

            var brand = product.Properties?
                .FirstOrDefault(pp => pp.PropertyDefinition?.Name == "Brand")
                ?.Value;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isFavorite = string.IsNullOrWhiteSpace(userId)
                ? GetFavoriteProductIds().Contains(product.Id)
                : await _favoritesService.IsFavoriteAsync(userId, product.Id);

            var viewModel = new ProductDetailsViewModel
            {
                Product = product,
                Images = images,
                RelatedProducts = relatedProducts,
                TopPicks = topPicks,
                VariantOptionGroups = optionGroups,
                VariantSummaries = variantSummaries,
                IsFavorite = isFavorite
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleFavorite(int productId)
        {
            var productExists = _context.Products.Any(p => p.Id == productId);
            if (!productExists)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isFavorite;

            if (string.IsNullOrWhiteSpace(userId))
            {
                var favoriteIds = GetFavoriteProductIds();
                isFavorite = favoriteIds.Contains(productId);

                if (isFavorite)
                {
                    favoriteIds.Remove(productId);
                }
                else
                {
                    favoriteIds.Add(productId);
                }

                SaveFavoriteProductIds(favoriteIds);
            }
            else
            {
                isFavorite = await _favoritesService.IsFavoriteAsync(userId, productId);

                if (isFavorite)
                {
                    await _favoritesService.RemoveAsync(userId, productId);
                }
                else
                {
                    await _favoritesService.AddAsync(userId, productId);
                }
            }

            return Json(new
            {
                isFavorite = !isFavorite,
                message = isFavorite ? "Removed from favorites." : "Added to favorites."
            });
        }
        private List<int> GetFavoriteProductIds()
        {
            var rawValue = HttpContext.Session.GetString(LocalFavoritesSessionKey);
            if (string.IsNullOrWhiteSpace(rawValue))
            {
                // Backward compatibility with previous session key
                rawValue = HttpContext.Session.GetString("FavoriteProductIds");
            }
            if (string.IsNullOrWhiteSpace(rawValue))
            {
                return new List<int>();
            }

            try
            {
                var productIds = JsonSerializer.Deserialize<List<int>>(rawValue) ?? new List<int>();
                return productIds.Distinct().ToList();
            }
            catch
            {
                return new List<int>();
            }
        }

        private void SaveFavoriteProductIds(List<int> productIds)
        {
            if (!productIds.Any())
            {
                HttpContext.Session.Remove(LocalFavoritesSessionKey);
                HttpContext.Session.Remove("FavoriteProductIds");
                return;
            }

            HttpContext.Session.SetString(LocalFavoritesSessionKey, JsonSerializer.Serialize(productIds.Distinct().ToList()));
            HttpContext.Session.Remove("FavoriteProductIds");
        }

        private List<ProductImage> EnrichImagesFromFiles(List<ProductImage> images, string primaryImageUrl, int productId)
        {
            var safePath = primaryImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
            var primaryAbsolutePath = Path.Combine(_environment.WebRootPath, safePath);
            var primaryDirectory = Path.GetDirectoryName(primaryAbsolutePath);
            var primaryFileName = Path.GetFileNameWithoutExtension(primaryAbsolutePath);
            var extension = Path.GetExtension(primaryAbsolutePath);

            if (string.IsNullOrWhiteSpace(primaryDirectory) || string.IsNullOrWhiteSpace(primaryFileName) || !Directory.Exists(primaryDirectory))
            {
                return images;
            }

            var separatorIndex = primaryFileName.LastIndexOf('_');
            if (separatorIndex <= 0)
            {
                return images;
            }

            var filePrefix = primaryFileName[..(separatorIndex + 1)];
            var matchedFiles = Directory
                .GetFiles(primaryDirectory, $"{filePrefix}*{extension}")
                .OrderBy(path => path)
                .ToList();

            if (matchedFiles.Count <= 1)
            {
                return images;
            }

            var knownUrls = images
                .Select(i => i.ImageUrl)
                .Where(url => !string.IsNullOrWhiteSpace(url))
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var sortOrder = images.Count;
            foreach (var filePath in matchedFiles)
            {
                var relativePath = filePath
                    .Replace(_environment.WebRootPath, string.Empty)
                    .Replace(Path.DirectorySeparatorChar, '/');

                if (!relativePath.StartsWith('/'))
                {
                    relativePath = $"/{relativePath}";
                }

                if (knownUrls.Contains(relativePath))
                {
                    continue;
                }

                images.Add(new ProductImage
                {
                    ProductId = productId,
                    ImageUrl = relativePath,
                    FileName = Path.GetFileName(filePath),
                    ContentType = "image/jpeg",
                    IsPrimary = false,
                    SortOrder = sortOrder++
                });
            }

            return images.OrderBy(i => i.SortOrder).ToList();
        }
    }
}