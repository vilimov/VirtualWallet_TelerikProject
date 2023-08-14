using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.Models.ViewModels;
using Virtual_Wallet.Models.ViewModels.Admin;
using Virtual_Wallet.VirtualWallet.API.Models.ViewModels;
using Virtual_Wallet.VirtualWallet.Application.Services;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.Exceptions;

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
        public IActionResult Dashboard(int pageNumber = 1, int pageSize = 6, string search = null)
        {
            if (!IsUserLogged())
            {
                return RedirectToAction("Login", "Users");
            }
            string loggedInUserName = HttpContext.Session.GetString("LoggedUser");
            User currentUser = userService.GetUserByUsername(loggedInUserName);

            bool isAdmin = Boolean.Parse(HttpContext.Session.GetString("IsAdmin"));

            if (currentUser == null || !isAdmin)
            {
                Response.StatusCode = 403;
                this.ViewData["ErrorMessage"] = "You are not authorized for this action!";
                return View("Error");
            }

            try
            {
                var users = userService.GetAllUsers(pageNumber, pageSize, search);
                var totalUsers = userService.GetUserCount(search);
                var totalPages = Math.Ceiling((double)totalUsers / pageSize);

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

                var model = new DashboardViewModel
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = (int)totalPages,
                    Users = userViewModels.ToList(),
                    Search = search,
                };

                return View(model);
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = 404;
                this.ViewData["ErrorMessage"] = $"Not found: {ex.Message}";
                return View("Error");
            }
            catch (UnexpectedAppException)
            {
                Response.StatusCode = 500;
                this.ViewData["ErrorMessage"] = "An unexpected error has occurred.";
                return View("Error");
            }
        }
        #region Block and Unblock
        [HttpPost]
        public IActionResult BlockUser(int id)
        {
            if (!IsUserLogged())
            {
                return RedirectToAction("Login", "Users");
            }
            try
            {
                string loggedInUserName = HttpContext.Session.GetString("LoggedUser");
                User currentUser = userService.GetUserByUsername(loggedInUserName);
                bool isAdmin = Boolean.Parse(HttpContext.Session.GetString("IsAdmin"));

                if (currentUser == null || !isAdmin)
                {
                    Response.StatusCode = 403;
                    this.ViewData["ErrorMessage"] = "You are not authorized for this action!";
                    return View("Error");
                }

                adminService.BlockUser(id);
                return RedirectToAction("Dashboard");
            }
            catch(EntityNotFoundException ex)
            {
                Response.StatusCode = 404;
                this.ViewData["ErrorMessage"] = $"Not found: {ex.Message}";
                return View("Error");
            }
            catch (UnexpectedAppException)
            {
                Response.StatusCode = 500;
                this.ViewData["ErrorMessage"] = "An unexpected error has occurred.";
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult UnblockUser(int id)
        {
            if (!IsUserLogged())
            {
                return RedirectToAction("Login", "Users");
            }
            try
            {
                string loggedInUserName = HttpContext.Session.GetString("LoggedUser");
                User currentUser = userService.GetUserByUsername(loggedInUserName);
                bool isAdmin = Boolean.Parse(HttpContext.Session.GetString("IsAdmin"));

                if (currentUser == null || !isAdmin)
                {
                    Response.StatusCode = 403;
                    this.ViewData["ErrorMessage"] = "You are not authorized for this action!";
                    return View("Error");
                }

                adminService.UnblockUser(id);
                return RedirectToAction("Dashboard");
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = 404;
                this.ViewData["ErrorMessage"] = $"Not found: {ex.Message}";
                return View("Error");
            }
            catch (UnexpectedAppException)
            {
                Response.StatusCode = 500;
                this.ViewData["ErrorMessage"] = "An unexpected error has occurred.";
                return View("Error");
            }
        }
        #endregion
        #region Delete
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            if (!IsUserLogged())
            {
                return RedirectToAction("Login", "Users");
            }
            try
            {
                string loggedInUserName = HttpContext.Session.GetString("LoggedUser");
                User currentUser = userService.GetUserByUsername(loggedInUserName);
                bool isAdmin = Boolean.Parse(HttpContext.Session.GetString("IsAdmin"));

                if (currentUser == null || !isAdmin)
                {
                    Response.StatusCode = 403;
                    this.ViewData["ErrorMessage"] = "You are not authorized for this action!";
                    return View("Error");
                }

                userService.DeleteUser(id);
                return RedirectToAction("Dashboard");
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = 404;
                this.ViewData["ErrorMessage"] = $"Not found: {ex.Message}";
                return View("Error");
            }
            catch (UnexpectedAppException)
            {
                Response.StatusCode = 500;
                this.ViewData["ErrorMessage"] = "An unexpected error has occurred.";
                return View("Error");
            }
        }
        #endregion
        #region Promote and Demote
        [HttpPost]
        public IActionResult PromoteUser(int id)
        {
            if (!IsUserLogged())
            {
                return RedirectToAction("Login", "Users");
            }
            try
            {
                string loggedInUserName = HttpContext.Session.GetString("LoggedUser");
                User currentUser = userService.GetUserByUsername(loggedInUserName);
                bool isAdmin = Boolean.Parse(HttpContext.Session.GetString("IsAdmin"));

                if (currentUser == null || !isAdmin)
                {
                    Response.StatusCode = 403;
                    this.ViewData["ErrorMessage"] = "You are not authorized for this action!";
                    return View("Error");
                }
                adminService.PromoteToAdmin(id, currentUser);
                return RedirectToAction("Dashboard");
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = 404;
                this.ViewData["ErrorMessage"] = $"Not found: {ex.Message}";
                return View("Error");
            }
            catch (UnexpectedAppException)
            {
                Response.StatusCode = 500;
                this.ViewData["ErrorMessage"] = "An unexpected error has occurred.";
                return View("Error");
            }
        }
        [HttpPost]
        public IActionResult DemoteUser(int id)
        {
            if (!IsUserLogged())
            {
                return RedirectToAction("Login", "Users");
            }
            try
            {
                string loggedInUserName = HttpContext.Session.GetString("LoggedUser");
                User currentUser = userService.GetUserByUsername(loggedInUserName);
                bool isAdmin = Boolean.Parse(HttpContext.Session.GetString("IsAdmin"));

                if (currentUser == null || !isAdmin)
                {
                    Response.StatusCode = 403;
                    this.ViewData["ErrorMessage"] = "You are not authorized for this action!";
                    return View("Error");
                }

                adminService.DemoteFromAdmin(id, currentUser);
                return RedirectToAction("Dashboard");
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = 404;
                this.ViewData["ErrorMessage"] = $"Not found: {ex.Message}";
                return View("Error");
            }
            catch (UnexpectedAppException)
            {
                Response.StatusCode = 500;
                this.ViewData["ErrorMessage"] = "An unexpected error has occurred.";
                return View("Error");
            }
        }
        #endregion
        #region Private Methods
        private bool IsUserLogged()
        {
            if (this.HttpContext.Session.GetString("LoggedUser") == null)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
