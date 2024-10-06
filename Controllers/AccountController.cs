using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoBacharelatoFilas.Models;
using ProjetoBacharelatoFilas.Repositories;
using ProjetoBacharelatoFilas.ViewModels;

namespace ProjetoBacharelatoFilas.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAuthenticate _authenticate;

        public AccountController(ILogger<AccountController> logger, IAuthenticate authenticate)
        {
            _logger = logger;
            _authenticate = authenticate;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(nameof(Login), loginViewModel);

            var result = await _authenticate.AuthenticateAsync(loginViewModel.Email, loginViewModel.Password);

            if (result)
            {
                if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(loginViewModel.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.(password must be strong).");
                return View(loginViewModel);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _authenticate.Logout();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
