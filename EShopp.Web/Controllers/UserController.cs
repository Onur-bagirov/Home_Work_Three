using EShopp.DAL.Context;
using EShopp.Domain.Entities;
using EShopp.Web.Models.ViewModel;
using EShopp.Web.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EShopp.Web.Controllers
{
    public class UserController : Controller
    {
        public static string LoggedInUser { get; set; } = string.Empty;
        private readonly EShoppDbContext _context;
        public UserController(EShoppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(LoggedInUser))
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName && u.UserPassword == model.UserPassword);

            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is incorrect");
                return View(model);
            }

            LoggedInUser = user.UserName;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (!string.IsNullOrEmpty(LoggedInUser))
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new ResgisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(ResgisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var exists = await _context.Users.AnyAsync(u => u.UserName == model.UserName);

            if (exists)
            {
                ModelState.AddModelError("", "This username is already taken.");
                return View(model);
            }

            var user = new User
            {
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.UserName,
                UserPassword = model.UserPassword,
                Email = model.UserEmail
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login", "User");
        }
        public IActionResult Logout()
        {
            LoggedInUser = string.Empty;
            return RedirectToAction("Index", "Home");
        }
    }
}