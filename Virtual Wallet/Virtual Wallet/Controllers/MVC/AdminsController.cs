using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.Models.ViewModels;
using Virtual_Wallet.VirtualWallet.Application.Services;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.Controllers.MVC
{
    public class AdminsController : Controller
    {
        private readonly IUserService userService;
        private readonly IAdminService adminService;
        public AdminsController(IUserService userService, IAdminService adminService) 
        {
            this.userService = userService;
            this.adminService = adminService;
        }
        public IActionResult Dashboard(string search = null)
        {
            var users = userService.GetAllUsers(search);
            var userViewModels = users.Select(u => new UserAdminViewModel
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                IsAdmin = u.IsAdmin,
                IsBlocked = u.IsBlocked,
                IsDeleted = u.IsDeleted
            });

            return View(userViewModels);
        }
        [HttpPost]
        public IActionResult BlockUser(int id)
        {
            try
            {
                adminService.BlockUser(id);
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult UnblockUser(int id)
        {
            try
            {
                adminService.UnblockUser(id);
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                userService.DeleteUser(id);
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        [HttpPost]
        public IActionResult Promote(int id)
        {
            try
            {
                string loggedInUserName = HttpContext.Session.GetString("LoggedUser");
                User currentUser = userService.GetUserByUsername(loggedInUserName);

                bool isAdmin = Boolean.Parse(HttpContext.Session.GetString("IsAdmin"));
                if (currentUser == null || !isAdmin)
                {
                    return Unauthorized();
                }
                adminService.PromoteToAdmin(id, currentUser);
                return RedirectToAction("AllUsers");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        [HttpPost]
        public IActionResult DemoteUser(int id)
        {
            try
            {
                string loggedInUserName = HttpContext.Session.GetString("LoggedUser");
                User currentUser = userService.GetUserByUsername(loggedInUserName);

                bool isAdmin = Boolean.Parse(HttpContext.Session.GetString("IsAdmin"));
                if (currentUser == null || !isAdmin)
                {
                    return Unauthorized();
                }

                adminService.DemoteFromAdmin(id, currentUser);
                return RedirectToAction("AllUsers");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}
