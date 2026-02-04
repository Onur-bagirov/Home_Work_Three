using EShopp.Aplication.Abstracts;
using Microsoft.AspNetCore.Mvc;
namespace EShopp.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return View(orders);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var order = new Order
            {
                ProductId = productId,
                Quantity = quantity
            };

            await _orderService.AddOrderAsync(order);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await _orderService.RemoveOrderAsync(id);
            return RedirectToAction("Index");
        }
    }
}
