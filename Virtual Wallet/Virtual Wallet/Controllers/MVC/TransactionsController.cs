using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Virtual_Wallet.Models.ViewModels;
using Virtual_Wallet.Models.ViewModels.Admin;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.Exceptions;
using VirtualWallet.Common.QueryParameters;

namespace Virtual_Wallet.Controllers.MVC
{
	public class TransactionsController : Controller
	{
		private readonly ITransactionService transactionService;
		private readonly IMapper mapper;
		private readonly IUserService userService;
		private readonly ICardService cardService;
		public TransactionsController(
			ITransactionService transactionService,
			IMapper mapper,
			IUserService userService,
			ICardService cardService)
		{
			this.transactionService = transactionService;
			this.mapper = mapper;
			this.userService = userService;
			this.cardService = cardService;
		}

		[HttpGet]
		public IActionResult Index([FromQuery] TransactionsQueryParameters filterParams, string search = null, int page = 1, int pageSize = 5)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			var user = GetLoggedUser();
			var pageResults = 5f;
			TransactionsQueryParameters filter = new TransactionsQueryParameters() { AllMyTransactions = "true" };
			filter = CheckParameters(filter, filterParams, search);

			var transactions = this.transactionService.GetFilteredTransactions(filter, user);
			var transactionsVM = mapper.Map<List<TransactionViewModel>>(transactions);
			var totalTransactions = transactionsVM.Count();
			var pageCount = Math.Ceiling(totalTransactions / pageResults);

			var products = transactionsVM
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			var model = new PaginatedTransactionViewModel
			{
				TansactionsShow = products,
				CurrentPages = page,
				Pages = (int)pageCount,
				Search = search

			};

			return View(model);
		}

		[HttpGet]
		public IActionResult ShowAllTransactions([FromQuery] TransactionsQueryParameters filterParams, string search = null, int page = 1, int pageSize = 5)
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

			var pageResults = 5f;
			TransactionsQueryParameters filter = new TransactionsQueryParameters();
			filter = CheckParameters(filter, filterParams, search);

			var transactions = this.transactionService.GetFilteredTransactions(filter, user);
			var transactionsVM = mapper.Map<List<TransactionViewModel>>(transactions);
			var totalTransactions = transactionsVM.Count();
			var pageCount = Math.Ceiling(totalTransactions / pageResults);

			var products = transactionsVM
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			var model = new PaginatedTransactionViewModel
			{
				TansactionsShow = products,
				CurrentPages = page,
				Pages = (int)pageCount,
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
				var transaction = transactionService.GetTransactionById(id);
				return View(transaction);
			}
			catch (EntityNotFoundException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return View("Error");
			}
		}

		[HttpGet]
		public IActionResult CreateDeposit()
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			var user = GetLoggedUser();
			var cardsList = user.Cards;
			var selectListItems = cardsList.Select(card => new SelectListItem
			{
				Value = card.Id.ToString(),
				Text = card.Name
			}).ToList();

			var makeTransaction = new MakeCardTransactionViewModel
			{
				Cards = new SelectList(selectListItems, "Value", "Text")
			};

			return View(makeTransaction);
		}

		[HttpPost]
		public IActionResult CreateDeposit(MakeCardTransactionViewModel makeTransaction)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			if (!ModelState.IsValid)
			{
				var user = GetLoggedUser();
				var cardsList = user.Cards;
				var selectListItems = cardsList.Select(card => new SelectListItem
				{
					Value = card.Id.ToString(),
					Text = card.Name
				}).ToList();
				makeTransaction.Cards = new SelectList(selectListItems, "Value", "Text");

				return View(makeTransaction);
			}

			try
			{
				var user = GetLoggedUser();
				var card = cardService.GetById(makeTransaction.CardId);
				var createdTransaction = transactionService.AddMoneyCardToWallet(user, card, makeTransaction.Amount, makeTransaction.Description);
				this.HttpContext.Session.SetString("WalletBalance", user.Wallet.Balance.ToString());
				this.HttpContext.Session.SetString("WalletCurrency", user.Wallet.CurrencyCode.ToString());

				return RedirectToAction("Details", "Transactions", new { id = createdTransaction.Id });
			}
			catch (EntityNotFoundException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return View("Error");
			}
			catch (UnauthorizedOperationException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return View("Error");
			}
			catch (InsuficientAmountException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return View("Error");
			}
		}

		[HttpGet]
		public IActionResult CreateWithdraw()
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			var user = GetLoggedUser();
			var cardsList = user.Cards;
			var selectListItems = cardsList.Select(card => new SelectListItem
			{
				Value = card.Id.ToString(),
				Text = card.Name
			}).ToList();

			var makeTransaction = new MakeCardTransactionViewModel
			{
				Cards = new SelectList(selectListItems, "Value", "Text")
			};

			return View(makeTransaction);
		}

		[HttpPost]
		public IActionResult CreateWithdraw(MakeCardTransactionViewModel makeTransaction)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			if (!ModelState.IsValid)
			{
				var user = GetLoggedUser();
				var cardsList = user.Cards;
				var selectListItems = cardsList.Select(card => new SelectListItem
				{
					Value = card.Id.ToString(),
					Text = card.Name
				}).ToList();

				makeTransaction.Cards = new SelectList(selectListItems, "Value", "Text");

				return View(makeTransaction);
			}

			try
			{
				var user = GetLoggedUser();
				var card = cardService.GetById(makeTransaction.CardId);
				var createdTransaction = transactionService.WithdrawalTransfer(user, card, makeTransaction.Amount, makeTransaction.Description);
				this.HttpContext.Session.SetString("WalletBalance", user.Wallet.Balance.ToString());
				this.HttpContext.Session.SetString("WalletCurrency", user.Wallet.CurrencyCode.ToString());

				return RedirectToAction("Details", "Transactions", new { id = createdTransaction.Id });
			}
			catch (EntityNotFoundException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return View("Error");
			}
			catch (UnauthorizedOperationException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return View("Error");
			}
			catch (InsuficientAmountException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return View("Error");
			}
		}

		[HttpGet]
		public IActionResult CreateTransfer(MakeWalletTransactionViewModel makeTransaction)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			var user = GetLoggedUser();

			return View(makeTransaction);
		}

		[HttpPost, ActionName("CreateTransfer")]
		public IActionResult CreateTransferPost(MakeWalletTransactionViewModel makeTransaction)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			if (!ModelState.IsValid)
			{
				return View(makeTransaction);
			}

			try
			{
				var user = GetLoggedUser();
				var recipient = userService.GetUserByUsername(makeTransaction.RecipientUsername);
				var createdTransaction = transactionService.AddMoneyWalletToWallet(user, recipient, makeTransaction.Amount, makeTransaction.Description);
				this.HttpContext.Session.SetString("WalletBalance", user.Wallet.Balance.ToString());
				this.HttpContext.Session.SetString("WalletCurrency", user.Wallet.CurrencyCode.ToString());

				return RedirectToAction("Details", "Transactions", new { id = createdTransaction.Id });
			}
			catch (EntityNotFoundException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = "Can't send money to this Recipient. Please contact Support team.";

				return View("Error");
			}
			catch (UnauthorizedOperationException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return View("Error");
			}
			catch (InsuficientAmountException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return View("Error");
			}
		}

		[HttpGet]
		public IActionResult SelectRecipient(int pageNumber = 1, int pageSize = 5, string search = null)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			try
			{
				var users = userService.GetAllUsers(pageNumber, pageSize, search);
				var sender = GetLoggedUser();
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
					Users = userViewModels.Where(u => u.Username != sender.Username).ToList(),
					Search = search
				};

				return View(model);
			}
			catch (EntityNotFoundException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return View("Error");
			}
			catch (UnauthorizedOperationException ex)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return View("Error");
			}
		}

		[HttpPost]
		public IActionResult SelectRecipient(string selectedUsername)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			var user = GetLoggedUser();
			var recipient = userService.GetUserByUsername(selectedUsername);
			var makeTransaction = new MakeWalletTransactionViewModel
			{
				RecipientUsername = recipient.Username,
				Amount = (decimal)0.01,
				Description = "Enter Description"
			};

			return RedirectToAction("CreateTransfer", makeTransaction);
		}

		#region PrivateMethods
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

		private TransactionsQueryParameters CheckParameters(TransactionsQueryParameters filter, TransactionsQueryParameters filterParams, string search)
		{
			if (filterParams.AllMyTransactions != null)
			{
				filter.AllMyTransactions = "true";
			}
			if (filterParams.Sender != null)
			{
				filter.Sender = search;
			}
			if (filterParams.Reciever != null)
			{
				filter.Reciever = search;
			}
			if (filterParams.Withdrawl != null)
			{
				filter.Withdrawl = "true";
			}
			if (filterParams.TransferToUser != null)
			{
				filter.TransferToUser = "true";
			}
			if (filterParams.DepositToWallet != null)
			{
				filter.DepositToWallet = "true";
			}
			if (filterParams.FilterByDate != null)
			{
				filter.FilterByDate = search;
			}

			return filter;
		}

		public string GetBackAction()
		{
			string referer = Request.Headers["Referer"].ToString();

			if (referer.Contains("ShowAllTransactions"))
			{
				return "ShowAllTransactions";
			}
			else
			{
				return "Index";
			}
		}
		#endregion

	}
}
