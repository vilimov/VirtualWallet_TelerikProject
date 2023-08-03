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
			var cardsList = user.Cards;
			var selectListItems = cardsList.Select(card => new SelectListItem
			{
				Value = card.Id.ToString(), // Set the value to the card's ID
				Text = card.Name // Set the text to the card's number (or any other relevant property)
			}).ToList();

			var makeTransaction = new MakeCardTransactionViewModel()
			{
				Cards = selectListItems // Assign the list of cards to the Cards property
			};
			return View(makeTransaction);
		}

        [HttpPost]
        public IActionResult CreateDeposit(MakeCardTransactionViewModel makeTransactio)
        {
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			if (!this.ModelState.IsValid)
			{
				return View(makeTransactio);
			}
			try
			{
				var user = GetLoggedUser();
				var card = cardService.GetById(makeTransactio.CardId);
				var createdTransaction = transactionService.AddMoneyCardToWallet(user, card, makeTransactio.Amount, makeTransactio.Description);
				return View(createdTransaction);
			}
            catch (Exception e)
            {
				var user = GetLoggedUser();
				var cardsList = user.Cards;
				var selectListItems = cardsList.Select(card => new SelectListItem
				{
					Value = card.Id.ToString(), // Set the value to the card's ID
					Text = card.Name // Set the text to the card's number (or any other relevant property)
				}).ToList();

				var makeTransaction = new MakeCardTransactionViewModel()
				{
					Cards = selectListItems // Assign the list of cards to the Cards property
				};
				this.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				this.ViewData["ErrorMessage"] = e.Message;
				//return View("Error");             this will return the Error page
				return View(makeTransactio);      // this will retur the same object and keep us on the same page
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
		#endregion




	}
}
