using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CreateTransferTransaction()
        {
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			var makeTransaction = new MakeCardTransactionViewModel();
			return View(makeTransaction);
		}

        [HttpPost]
        public IActionResult CreateDepositTransaction(MakeCardTransactionViewModel makeTransactio)
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
            catch (Exception)
            {

                throw;
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
