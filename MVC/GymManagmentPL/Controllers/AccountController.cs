using GymManagmentBLL.Service.Interfaces;
using GymManagmentBLL.ViewModels.AccountViewModel;
using GymManagmentDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(IAccountService accountService, SignInManager<ApplicationUser> signInManager)
        {
            _accountService = accountService;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model) 
        {
            if (!ModelState.IsValid) 
                return View(model);

            var User = _accountService.ValidateUser(model);
            if (User is null)
            {
                ModelState.AddModelError("InvalidLogin", "Invalid username or password");
                return View(model);
            }
            var result = _signInManager.PasswordSignInAsync(User, model.Password, model.RememberMe, false).Result;
            if (result.IsNotAllowed)
                ModelState.AddModelError("InvalidLogin", "Your Email is not allowed");
            if (result.IsLockedOut)
                ModelState.AddModelError("InvalidLogin", "Your Email is lockedout");
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            return View(model);
        }

        public ActionResult Logout()
        {
            _signInManager.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction(nameof(Login));
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
