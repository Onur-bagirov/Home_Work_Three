using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EShopp.Aplication.Abstacts;
using EShopp.Aplication.Abstracts;
namespace EShopp.Web.Controllers
{
    public class BuyController : Controller
    {
        private readonly IBuyService _buyService;
        private readonly IProductService _productService;
        public BuyController(IBuyService buyService, IProductService productService)
        {
            _buyService = buyService;
            _productService = productService;
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> BuyProduct(int productId, int quantity)
        {
            if (productId <= 0 || quantity <= 0)
            {
                return RedirectToAction("Index");
            }

            await _buyService.BuyAsync(productId, quantity);
            TempData["Message"] = "Purchase completed successfully";
            return RedirectToAction("Index");
        }
    }
}