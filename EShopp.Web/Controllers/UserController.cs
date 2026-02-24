using EShopp.Domain.Entities;
using EShopp.Web.Models.ViewModel;
using EShopp.Web.Views.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace EShopp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
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

            var result = await _signInManager.PasswordSignInAsync(
                model.UserName,
                model.UserPassword,
                false,
                false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Username or password is incorrect");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Roles = _roleManager.Roles.Select(x => x.Name).ToList();

            return View(new ResgisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(ResgisterViewModel model, string selectedRole)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = _roleManager.Roles.Select(x => x.Name).ToList();
                return View(model);
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.UserEmail,
                Name = model.Name,
                Surname = model.Surname,
                UserPassword = model.UserPassword,
            };

            var result = await _userManager.CreateAsync(user, model.UserPassword);

            if (result.Succeeded)
            {
                string roleToAssign = string.IsNullOrEmpty(selectedRole) ? "Customer" : selectedRole;

                if (!await _roleManager.RoleExistsAsync(roleToAssign))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleToAssign));
                }

                await _userManager.AddToRoleAsync(user, roleToAssign);
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            ViewBag.Roles = _roleManager.Roles.Select(x => x.Name).ToList();
            return View(model);
        }

        [HttpGet] 
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}