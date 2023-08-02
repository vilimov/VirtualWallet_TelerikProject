using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.Controllers.MVC
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionService transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;       
        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<Transaction> transactions = this.transactionService.GetAllTransactions();
            return View(transactions);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
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
    }
}
