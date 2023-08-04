using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.Models.ViewModels;
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
            adminService.BlockUser(id);
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult UnblockUser(int id)
        {
            adminService.UnblockUser(id);
            return RedirectToAction("Dashboard");
        }
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            userService.DeleteUser(id);
            return RedirectToAction("Dashboard");
        }
    }
}
