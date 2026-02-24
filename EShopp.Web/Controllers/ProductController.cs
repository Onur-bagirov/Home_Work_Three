using EShopp.Aplication.Abstracts;
using EShopp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace EShopp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        public ProductController(IProductService productService, ICategoryService categoryService, IOrderService orderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
        }

        [Authorize(Roles = "Admin,Cashier")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "Name");
            return View();
        }

        [Authorize(Roles = "Admin,Cashier")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "Name");
                return View(product);
            }

            await _productService.AddProductAsync(product);
            return RedirectToAction("GetAllProducts");
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        [Authorize(Roles = "Admin,Cashier")]
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.RemoveProductAsync(id);
            return RedirectToAction("GetAllProducts");
        }

        [Authorize(Roles ="Customer")]
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, int quantity = 1)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            if (product.StockQuantity < quantity)
            {
                TempData["Message"] = "Not enough stock";
                return RedirectToAction("GetAllProducts");
            }

            await _productService.UpdateProductAsync(product);

            var orders = await _orderService.GetAllOrdersAsync();
            var existingOrder = orders.FirstOrDefault(o => o.ProductId == id);

            if (existingOrder != null)
            {
                existingOrder.Quantity += quantity;
                await _orderService.UpdateOrderAsync(existingOrder);
            }
            else
            {
                var order = new Order
                {
                    ProductId = product.Id,
                    Quantity = quantity
                };

                await _orderService.AddOrderAsync(order);
            }

            return RedirectToAction("GetAllProducts");
        }

        [Authorize(Roles = "Admin,Cashier")]
        [HttpPost]
        public async Task<IActionResult> IncreaseQuantity(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.StockQuantity++;

            await _productService.UpdateProductAsync(product);
            return RedirectToAction("GetAllProducts");
        }

        [Authorize(Roles = "Admin,Cashier")]
        [HttpPost]
        public async Task<IActionResult> DecreaseQuantity(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            if (product.StockQuantity <= 0)
            {
                return RedirectToAction("GetAllProducts");
            }

            product.StockQuantity--;

            await _productService.UpdateProductAsync(product);
            return RedirectToAction("GetAllProducts");
        }
    }
}