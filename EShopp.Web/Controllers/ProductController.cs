using EShopp.Aplication.Abstracts;
using EShopp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace EShopp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        public ProductController(
            IProductService productService,
            ICategoryService categoryService,
            IOrderService orderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.Categories = new SelectList(
                await _categoryService.GetAllCategoriesAsync(),
                "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(
                    await _categoryService.GetAllCategoriesAsync(),
                    "Id", "Name");
                return View(product);
            }
            await _productService.AddProductAsync(product);
            return RedirectToAction("GetAllProducts");
        }
        public async Task<IActionResult> GetAllProducts()
            => View(await _productService.GetAllProductsAsync());

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.RemoveProductAsync(id);
            return RedirectToAction("GetAllProducts");
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, int quantity = 1)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            var order = new Order
            {
                ProductId = product.Id,
                Quantity = quantity
            };
            await _orderService.AddOrderAsync(order);
            return RedirectToAction("Index", "Order");
        }
    }
}
