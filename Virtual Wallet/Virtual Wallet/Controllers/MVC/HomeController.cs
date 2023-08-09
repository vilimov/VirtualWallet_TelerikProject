using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Virtual_Wallet.VirtualWallet.API.Models.ViewModels;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.Controllers.MVC
{
    public class HomeController : Controller
    {
        private readonly ITransactionService transactionService;
        private readonly IUserService userService;
        public HomeController(ILogger<HomeController> logger, ITransactionService transactionService, IUserService userService)
        {
            this.transactionService = transactionService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
			if (this.HttpContext.Session.GetString("LoggedUser") == null)
			{
				return RedirectToAction("Welcomepage", "Home");
			}
            var user = userService.GetUserByUsername(this.HttpContext.Session.GetString("LoggedUser"));
            var allTransactions = transactionService.GetAllTransactions().Where(t=>t.SenderId == user.Id || t.RecipientId == user.Id).ToList();

            return View(allTransactions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


		public IActionResult Welcomepage()
		{
			return View();
		}
	}
}