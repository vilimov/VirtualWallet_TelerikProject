using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            IList<Transaction> transactions = this.transactionService.GetAllTransactions();
            return View(transactions);
        }
    }
}
