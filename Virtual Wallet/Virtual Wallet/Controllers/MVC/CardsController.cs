using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.Controllers.MVC
{
	public class CardsController : Controller
	{
		private readonly ICardService cardService;
		private readonly IUserService userService;
		private readonly IMapper mapper;

		public CardsController(ICardService cardService, IUserService userService, IMapper mapper)
        {
            this.cardService = cardService;
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
				IList<Card> cards = this.cardService.GetByUser(user).ToList();
				List<CardShowDto> result = cards.Select(c => new CardShowDto(c)).ToList();
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
