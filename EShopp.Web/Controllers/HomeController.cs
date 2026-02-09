using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EShopp.Web.Models;
namespace EShopp.Web.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if (string.IsNullOrEmpty(UserController.LoggedInUser))
        {
            return RedirectToAction("Login", "User");
        }

        return View();
    }

    public IActionResult Privacy()
    {
        if (string.IsNullOrEmpty(UserController.LoggedInUser))
        {
            return RedirectToAction("Login", "User");
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
