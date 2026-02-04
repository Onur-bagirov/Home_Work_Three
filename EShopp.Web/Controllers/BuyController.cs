using Microsoft.AspNetCore.Mvc;
using EShopp.Aplication.Abstacts;
namespace EShopp.Web.Controllers
{
    public class BuyController : Controller
    {
        private readonly IBuyService _buyService;
        public BuyController(IBuyService buyService)
        {
            _buyService = buyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuyProduct(int productId, int quantity)
        {
            if (productId <= 0 || quantity <= 0)
            {
                return RedirectToAction("GetAllProducts", "Product");
            }

            await _buyService.BuyAsync(productId, quantity);
            return RedirectToAction("GetAllProducts", "Product");
        }
    }
}
