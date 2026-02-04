using EShopp.Aplication.Abstacts;
using EShopp.Aplication.Abstracts;
using Microsoft.AspNetCore.Mvc;
namespace EShopp.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IBuyService _buyService;
        public OrderController(IOrderService orderService, IProductService productService, IBuyService buyService)
        {
            _orderService = orderService;
            _productService = productService;
            _buyService = buyService;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> IncreaseQuantity(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductByIdAsync(order.ProductId);

            if (product == null)
            {
                return NotFound();
            }

            if (product.StockQuantity <= 0)
            {
                TempData["Message"] = "Not enough stock";
                return RedirectToAction("Index");
            }

            order.Quantity++;
            await _orderService.UpdateOrderAsync(order);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DecreaseQuantity(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            order.Quantity--;

            if (order.Quantity <= 0)
            {
                await _orderService.RemoveOrderAsync(id);
            }
            else
            {
                await _orderService.UpdateOrderAsync(order);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await _orderService.RemoveOrderAsync(id);
            TempData["Message"] = "Removed from cart";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductByIdAsync(order.ProductId);

            if (product == null)
            {
                return NotFound();
            }

            if (product.StockQuantity < order.Quantity)
            {
                TempData["Message"] = $"Not enough stock Available : {product.StockQuantity}";
                return RedirectToAction("Index");
            }

            await _buyService.BuyAsync(order.ProductId, order.Quantity);
            await _orderService.RemoveOrderAsync(order.Id);

            TempData["Message"] = "Purchase completed successfully";
            return RedirectToAction("Index");
        }
    }
}