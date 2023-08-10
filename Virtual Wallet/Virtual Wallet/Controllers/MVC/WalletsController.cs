using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.Models.ViewModels;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.Exceptions;

namespace Virtual_Wallet.Controllers.MVC
{
	public class WalletsController : Controller
	{
		private readonly IWalletService walletService;
		private readonly IUserService userService;
		private readonly IMapper mapper;

		public WalletsController(
			IWalletService walletService,
			IUserService userService,
			IMapper mapper)
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
				WalletViewModel result = new WalletViewModel(wallet);

				return View(result);
			}
			catch (EntityNotFoundException e)
			{
				HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				ViewData["ErrorMessage"] = e.Message;
			}

			return View();
		}

		[HttpGet]
		public IActionResult ShowAllWallets(int pageNumber = 1, int pageSize = 5, string search = null)
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

				return View("Error");
			}

			var wallets = this.walletService.GetAll(pageNumber, pageSize, search);
			List<WalletViewModel> walletsVM = wallets.Select(w => new WalletViewModel(w)).ToList();
			var totalWallets = walletService.GetWalletsCount(search);
			var totalPages = Math.Ceiling((double)totalWallets / pageSize);

			var model = new PaginatedWalletsViewModel
			{
				PageNumber = pageNumber,
				PageSize = pageSize,
				TotalPages = (int)totalPages,
				WalletsShow = walletsVM,
				Search = search
			};

			return View(model);
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			try
			{
				var wallet = walletService.GetWalletById(id);
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

		[HttpGet]
		public IActionResult CreateWallet()
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			var newWallet = new WalletCreateUpdateDto();

			return View(newWallet);
		}

		[HttpPost]
		public IActionResult CreateWallet(WalletCreateUpdateDto newWallet)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			if (!ModelState.IsValid)
			{
				return View(newWallet);
			}

			try
			{
				var user = GetLoggedUser();
				Wallet wallet = mapper.Map<Wallet>(newWallet);
				wallet = walletService.CreateWallet(wallet, user);
				this.HttpContext.Session.SetString("WalletBalance", wallet.Balance.ToString());
				this.HttpContext.Session.SetString("WalletCurrency", wallet.CurrencyCode.ToString());

				return RedirectToAction("Index", "Wallets");
			}
			catch (Exception e)
			{
				HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				ViewData["ErrorMessage"] = e.Message;

				return View(newWallet);
			}
		}

		[HttpGet]
		public IActionResult UpdateWallet([FromRoute] int id)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			var user = GetLoggedUser();

			return View();
		}

		[HttpPost]
		public IActionResult UpdateWallet([FromRoute] int id, WalletCreateUpdateDto newWallet)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			if (!ModelState.IsValid)
			{
				return View(newWallet);
			}

			try
			{
				var user = GetLoggedUser();
				Wallet wallet = mapper.Map<Wallet>(newWallet);
				Wallet updatedWallet = walletService.Update(user, wallet);
				this.HttpContext.Session.SetString("WalletBalance", updatedWallet.Balance.ToString());
				this.HttpContext.Session.SetString("WalletCurrency", updatedWallet.CurrencyCode.ToString());
				return RedirectToAction("Details", "Wallets", new { id = updatedWallet.Id });
			}
			catch (Exception e)
			{
				HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				ViewData["ErrorMessage"] = e.Message;

				return View(newWallet);
			}
		}

		[HttpGet]
		public IActionResult RemoveWallet([FromRoute] int id)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			try
			{
				var wallet = walletService.Delete(id);
				this.HttpContext.Session.SetString("WalletBalance", "No wallet");
				this.HttpContext.Session.SetString("WalletCurrency", "No wallet");

				return RedirectToAction("Index", "Wallets");
			}
			catch (EntityNotFoundException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = e.Message;

				return View("Error");
			}
			catch (WalletNotEmptyException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
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
