using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Virtual_Wallet.Models.ViewModels;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Application.Services;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.AdditionalHelpers;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.Controllers.MVC
{
	public class CardsController : Controller
	{
		private readonly ICardService cardService;
		private readonly IUserService userService;
		private readonly IMapper mapper;
		private readonly AuthManager authManager;

		public CardsController(ICardService cardService, IUserService userService, IMapper mapper, AuthManager authManager)
		{
			this.cardService = cardService;
			this.userService = userService;
			this.mapper = mapper;
			this.authManager = authManager;
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

		[HttpGet]
		public IActionResult ShowAllCards()
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
			List<Card> cards = this.cardService.GetAll().ToList();
			List<CardShowDto> result = cards.Select(c => new CardShowDto(c)).ToList();
			return View(result);
		}

		[HttpGet]
		public IActionResult Details(string number)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			try
			{
				var card = cardService.GetByNumber(number);
				CardViewModel result = new CardViewModel(card);
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
		public IActionResult AddCard(CardAddDto newCard)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}
			var user = GetLoggedUser();

			return View(newCard);
		}

		[HttpPost, ActionName("AddCard")]
		public IActionResult AddCardPost(CardAddDto newCard)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			if (!ModelState.IsValid)
			{
				return View(newCard);
			}

			try
			{
				var user = GetLoggedUser();
				Card card = mapper.Map<Card>(newCard);
				card = cardService.Add(card, user);
				return RedirectToAction("Details", "Cards", new { id = card.Number});
			}
			catch (Exception e)
			{
				HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				ViewData["ErrorMessage"] = e.Message;
				return View(newCard);
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
