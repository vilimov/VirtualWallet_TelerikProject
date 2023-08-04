using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.Models.ViewModels;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Repository;
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

        #region Register
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
        #endregion

        #region Login
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
				this.HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());
				//this.HttpContext.Session.SetString("UserImage", user.Photo);

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
        #endregion

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
        public IActionResult Profile()
        {
            string loggedInUserName = HttpContext.Session.GetString("LoggedUser");
            var user = userService.GetUserByUsername(loggedInUserName);

            var userProfileViewModel = new UserProfileViewModel
            {
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View(userProfileViewModel);
        }

        #region Update Profile
        [HttpGet]
        public IActionResult UpdateEmail()
        {
            string currentUserUsername = HttpContext.Session.GetString("LoggedUser");
            var user = userService.GetUserByUsername(currentUserUsername);
            var model = new UpdateEmailViewModel
            {
                CurrentEmail = user.Email
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateEmail(UpdateEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string currentUserUsername = HttpContext.Session.GetString("LoggedUser");
                    var user = userService.GetUserByUsername(currentUserUsername);
                    user.Email = model.NewEmail;
                    userService.UpdateUser(user);
                    return RedirectToAction("Profile");
                }
                catch (DuplicateEntityException ex)
                {
                    ModelState.AddModelError("Email", ex.Message);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdatePhone()
        {
			string currentUserUsername = HttpContext.Session.GetString("LoggedUser");
			var user = userService.GetUserByUsername(currentUserUsername);
			var model = new UpdatePhoneViewModel
			{
				CurrentPhoneNumber = user.PhoneNumber
			};
			return View(model);
		}
        [HttpPost]
        public IActionResult UpdatePhone(UpdatePhoneViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string currentUserUsername = HttpContext.Session.GetString("LoggedUser");
                    var user = userService.GetUserByUsername(currentUserUsername);
                    user.PhoneNumber = model.NewPhoneNumber;
                    userService.UpdateUser(user);
                    return RedirectToAction("Profile");
                }
                catch (DuplicateEntityException ex)
                {
                    ModelState.AddModelError("Phone", ex.Message);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateFirstName()
        {
			string currentUserUsername = HttpContext.Session.GetString("LoggedUser");
			var user = userService.GetUserByUsername(currentUserUsername);
			var model = new UpdateFirstNameViewModel
			{
				CurrentFirstName = user.FirstName
			};
			return View(model);
		}
        [HttpPost]
        public IActionResult UpdateFirstName(UpdateFirstNameViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string currentUserUsername = HttpContext.Session.GetString("LoggedUser");
                    var user = userService.GetUserByUsername(currentUserUsername);
                    user.FirstName = model.NewFirstName;
                    userService.UpdateUser(user);
                    return RedirectToAction("Profile");
                }
                catch (DuplicateEntityException ex)
                {
                    ModelState.AddModelError("FirstName", ex.Message);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateLastName()
        {
			string currentUserUsername = HttpContext.Session.GetString("LoggedUser");
			var user = userService.GetUserByUsername(currentUserUsername);
			var model = new UpdateLastNameViewModel
			{
				CurrentLastName = user.LastName
			};
			return View(model);
		}
        [HttpPost]
        public IActionResult UpdateLastName(UpdateLastNameViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string currentUserUsername = HttpContext.Session.GetString("LoggedUser");
                    var user = userService.GetUserByUsername(currentUserUsername);
                    user.LastName = model.NewLastName;
                    userService.UpdateUser(user);
                    return RedirectToAction("Profile");
                }
                catch (DuplicateEntityException ex)
                {
                    ModelState.AddModelError("FirstName", ex.Message);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdatePassword()
        {
			string currentUserUsername = HttpContext.Session.GetString("LoggedUser");
			var user = userService.GetUserByUsername(currentUserUsername);
			var model = new UpdatePasswordViewModel
			{
				CurrentPassword = user.Password
			};
			return View(model);
		}
        [HttpPost]
        public IActionResult UpdatePassword(UpdatePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string currentUserUsername = HttpContext.Session.GetString("LoggedUser");
                    var user = userService.GetUserByUsername(currentUserUsername);
                    user.Password = model.NewPassword;
                    userService.UpdateUser(user);
                    return RedirectToAction("Profile");
                }
                catch (DuplicateEntityException ex)
                {
                    ModelState.AddModelError("Password", ex.Message);
                }
            }
            return View(model);
        }
        #endregion
    }
}
