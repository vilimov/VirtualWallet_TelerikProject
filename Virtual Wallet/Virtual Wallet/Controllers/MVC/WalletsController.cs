using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.Models.ViewModels;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Application.Services;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.Controllers.MVC
{
	public class WalletsController : Controller
	{
		private readonly IWalletService walletService;
		private readonly IUserService userService;
		private readonly IMapper mapper;

		public WalletsController(IWalletService walletService, IUserService userService, IMapper mapper)
		{
			this.walletService = walletService;
			this.userService = userService;
			this.mapper = mapper;
		}
		public IActionResult Index()
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			try
			{
				var user = GetLoggedUser();
				Wallet wallet = this.walletService.GetWalletByUser(user.Username);
				WalletShowDto result = new WalletShowDto(wallet);
				return View(result);

			}
			catch (EntityNotFoundException e)
			{
				HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				ViewData["ErrorMessage"] = e.Message;
				//return View("Error");           // This will return the Error page
				return View();    // This will return the same view with validation errors
			}
			return View();
		}

		[HttpGet]
		public IActionResult ShowAllWallets()
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			var user = GetLoggedUser();
			if (!user.IsAdmin)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
				this.ViewData["ErrorMessage"] = "You are not authorized for this action!";
				//return View("Error");             this will return the Error page
				return View("Error");      // this will retur the same object and keep us on the same page
			}
			List<Wallet> wallets = this.walletService.GetAll().ToList();
			List<WalletShowDto> result = wallets.Select(c => new WalletShowDto(c)).ToList();
			return View(result);
		}

		[HttpGet]
		public IActionResult Details()
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			try
			{
				User user = GetLoggedUser();
				var wallet = walletService.GetWalletByUser(user.Username);
				WalletViewModel result = new WalletViewModel(wallet);
				return View(result);
			}
			catch (EntityNotFoundException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return View("Error");
			}
		}

		private bool IsUserLogged()
		{
			if (this.HttpContext.Session.GetString("LoggedUser") == null)
			{
				return false;
			}
			return true;
		}

		private User GetLoggedUser()
		{
			IsUserLogged();
			var getUserName = this.HttpContext.Session.GetString("LoggedUser");
			var loggedUser = userService.GetUserByUsername(getUserName);
			return loggedUser;
		}
	}
}
