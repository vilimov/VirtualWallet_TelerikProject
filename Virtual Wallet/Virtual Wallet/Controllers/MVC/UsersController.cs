using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.Models.ViewModels;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.AdditionalHelpers;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.Controllers.MVC
{
	public class UsersController : Controller
    {
        private readonly IUserService userService;
		private readonly AuthManager authManager;
		public UsersController(IUserService userService, AuthManager authManager) 
        {
			this.userService = userService;
			this.authManager = authManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var user = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password
                };

                userService.Register(user);

                return RedirectToAction("RegistrationConfirmation");
            }
            catch (DuplicateEntityException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult RegistrationConfirmation()
        {
            return View();
        }

        [HttpGet]
		public IActionResult Login()
		{
			return View(new LoginViewModel());
		}
		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				var user = userService.Login(model.Username, model.Password);
				this.HttpContext.Session.SetString("LoggedUser", user.Username);

				return RedirectToAction("Index", "Home");
			}
			catch (EntityNotFoundException ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(model);
			}
			catch (UnauthorizedAccessException ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(model);
			}
		}
		public IActionResult Logout()
		{
			this.HttpContext.Session.Clear();
			return RedirectToAction("Login", "Users");
		}
        [HttpGet("Users/VerifyEmail")]
        public IActionResult VerifyEmail(string token)
        {
            try
            {
                userService.Verify(token);
                ViewBag.Message = "Email successfully verified!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "An error occurred while verifying your email. Please try again later.";
            }

            return View();
        }
    }
}
