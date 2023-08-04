using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography;
using Virtual_Wallet.Models.ViewModels;
using Virtual_Wallet.VirtualWallet.Application.Services;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.Controllers.MVC
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionService transactionService;
		private readonly IMapper mapper;
		private readonly IUserService userService;
		private readonly ICardService cardService;
		public TransactionsController(ITransactionService transactionService, IMapper mapper, IUserService userService, ICardService cardService)
        {
            this.transactionService = transactionService;   
            this.mapper = mapper;
			this.userService = userService;
			this.cardService = cardService;	
        }

        [HttpGet]
        public IActionResult Index()
        {
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			var user = GetLoggedUser();
			//IList<Transaction> transactions = this.transactionService.GetAllTransactions();
			IList<Transaction> transactions = this.transactionService.GetTransactionsByUserId(user.Id);
			return View(transactions);
        }

		[HttpGet]
		public IActionResult ShowAllTransactions()
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
			IList<Transaction> transactions = this.transactionService.GetAllTransactions();
			return View(transactions);
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
			var cardsList = user.Cards; // Assuming cardsList is a List<Card>
			var selectListItems = cardsList.Select(card => new SelectListItem
			{
				Value = card.Id.ToString(),   // Replace with actual property that holds card ID
				Text = card.Name              // Replace with actual property that holds card Name
			}).ToList();

			var makeTransaction = new MakeCardTransactionViewModel
			{
				Cards = new SelectList(selectListItems, "Value", "Text") // Bind the list of selectListItems to the Cards property
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
				// Here, you need to populate the Cards SelectList again for displaying in case of validation errors.
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
				return RedirectToAction("Details", "Transactions", new { id = createdTransaction.Id });
			}
			catch (Exception e)
			{
				HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				ViewData["ErrorMessage"] = e.Message;
				//return View("Error");           // This will return the Error page
				return View(makeTransaction);    // This will return the same view with validation errors
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
			var cardsList = user.Cards; // Assuming cardsList is a List<Card>
			var selectListItems = cardsList.Select(card => new SelectListItem
			{
				Value = card.Id.ToString(),   // Replace with actual property that holds card ID
				Text = card.Name              // Replace with actual property that holds card Name
			}).ToList();

			var makeTransaction = new MakeCardTransactionViewModel
			{
				Cards = new SelectList(selectListItems, "Value", "Text") // Bind the list of selectListItems to the Cards property
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
				// Here, you need to populate the Cards SelectList again for displaying in case of validation errors.
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
				return RedirectToAction("Details", "Transactions", new { id = createdTransaction.Id });
			}
			catch (Exception e)
			{
				HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				ViewData["ErrorMessage"] = e.Message;
				//return View("Error");           // This will return the Error page
				return View(makeTransaction);    // This will return the same view with validation errors
			}
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


		public string GetBackAction()
		{
			string referer = Request.Headers["Referer"].ToString();

			// Check if referer contains specific keywords from the previous pages
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
