using System.Globalization;
using DeskMarket.Data;
using DeskMarket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DeskMarket.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.Serialization;

namespace DeskMarket.Controllers
{
    using static Constants.EntityMessages.Product;
    using static Constants.EntityConstants.Product;

    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var userId = User.Identity?.IsAuthenticated == true ? GetUserId() : null;

            var products = await context.Products
                .Where(p => p.IsDeleted == false)
                .Select(p => new ProductIndexViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    IsSeller = p.SellerId == userId,
                    HasBought = p.ProductsClients.Any(pc => pc.ClientId == userId)
                })
                .ToListAsync();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var viewModel = new ProductAddViewModel
            {
                Categories = await GetCategories()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!DateTime.TryParseExact(model.AddedOn, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime addedOnDate))
                {
                    ModelState.AddModelError(nameof(model.AddedOn), InvalidDateFormat);

                    model.Categories = await GetCategories();
                    return View(model);
                }

                var product = new Product()
                {
                    ProductName = model.ProductName,
                    Price = model.Price,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    AddedOn = addedOnDate,
                    CategoryId = model.CategoryId,
                    SellerId = GetUserId()!,
                    IsDeleted = false
                };

                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            model.Categories = await GetCategories();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null || product.SellerId != GetUserId())
            {
                return NotFound(NotFoundProduct);
            }

            var viewModel = new ProductEditViewModel()
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                AddedOn = product.AddedOn.ToString(DateTimeFormat),
                CategoryId = product.CategoryId,
                Categories = await GetCategories(),
                SellerId = GetUserId()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!DateTime.TryParseExact(model.AddedOn, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime addedOnDate))
                {
                    ModelState.AddModelError(nameof(model.AddedOn), InvalidDateFormat);

                    model.Categories = await GetCategories();
                    return View(model);
                }

                var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);

                if (product == null)
                {
                    return NotFound(NotFoundProduct);
                }

                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.Description = model.Description;
                product.ImageUrl = model.ImageUrl;
                product.CategoryId = model.CategoryId;
                product.AddedOn = addedOnDate;

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = product.Id });
            }

            model.Categories = await GetCategories();
            return View(model);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = GetUserId();
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);

            if (product == null)
            {
                return NotFound(NotFoundProduct);
            }

            if (product.SellerId == userId)
            {
                return BadRequest(CannotAddOwnProductToCart);
            }

            bool hasBought = await context.ProductsClients.AnyAsync(pc => pc.ClientId == userId && pc.ProductId == id);
            if (hasBought)
            {
                return BadRequest(AlreadyPurchasedProduct);
            }

            bool productExistsInCart = await context.ProductsClients.AnyAsync(pc => pc.ClientId == userId && pc.ProductId == id);
            if (!productExistsInCart)
            {
                var cartItem = new ProductClient() { ClientId = userId, ProductId = id };
                context.ProductsClients.Add(cartItem);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Cart");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = GetUserId();
            var cartItem = await context.ProductsClients.FirstOrDefaultAsync(pc => pc.ProductId == id && pc.ClientId == userId);

            if (cartItem != null)
            {
                context.ProductsClients.Remove(cartItem);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Cart));
        }

        public async Task<IActionResult> Cart()
        {
            var userId = GetUserId();
            var cartItems = await context.ProductsClients.Where(pc => pc.ClientId == userId)
                .Select(pc => new ProductCartViewModel()
                {
                    Id = pc.ProductId,
                    ImageUrl = pc.Product.ImageUrl,
                    Price = pc.Product.Price,
                    ProductName = pc.Product.ProductName
                }).ToListAsync();

            return View(cartItems);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var product = await context.Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);

            if (product == null)
            {
                return NotFound(NotFoundProduct);
            }

            var userId = GetUserId();
            var viewModel = new ProductDetailsViewModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                AddedOn = product.AddedOn.ToString(DateTimeFormat),
                CategoryName = product.Category.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Seller = product.Seller.UserName,
                HasBought = await context.ProductsClients.AnyAsync(pc => pc.ClientId == userId && pc.ProductId == id)
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await context.Products.Include(p => p.Seller).FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);

            if (product == null)
            {
                return NotFound(NotFoundProduct);
            }

            var viewModel = new ProductDeleteViewModel() { Id = product.Id, ProductName = product.ProductName, SellerId = product.SellerId, Seller = product.Seller.UserName };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteViewModel model)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == model.Id);
            if (product.SellerId != GetUserId())
            {
                return Forbid();
            }

            product.IsDeleted = true;
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private string? GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        private async Task<List<CategoryViewModel>> GetCategories() => await context.Categories
            .Select(c => new CategoryViewModel() { Id = c.Id, Name = c.Name }).ToListAsync();
    }
}
