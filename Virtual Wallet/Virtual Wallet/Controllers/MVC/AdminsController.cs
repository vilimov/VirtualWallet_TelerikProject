using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.Models.ViewModels;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.Controllers.MVC
{
    public class AdminsController : Controller
    {
        private readonly IUserService userService;
        public AdminsController(IUserService userService) 
        {
            this.userService = userService;
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
            userService.BlockUser(id);
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult UnblockUser(int id)
        {
            userService.UnblockUser(id);
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
