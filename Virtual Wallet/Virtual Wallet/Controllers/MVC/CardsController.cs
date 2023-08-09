using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.Models.ViewModels;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
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

		public CardsController(ICardService cardService, IUserService userService, IMapper mapper, AuthManager authManager)
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
				List<CardViewModel> result = cards.Select(c => new CardViewModel(c)).ToList();
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
		public IActionResult ShowAllCards(int pageNumber = 1, int pageSize = 5, string search = null)
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

			var cards = this.cardService.GetAll(pageNumber, pageSize, search);
			List<CardViewModel> cardVM = cards.Select(c => new CardViewModel(c)).ToList();
			var totalCards = cardService.GetCardsCount(search);
			var totalPages = Math.Ceiling((double)totalCards / pageSize);

			var model = new PaginatedCardsViewModel
			{
				PageNumber = pageNumber,
				PageSize = pageSize,
				TotalPages = (int)totalPages,
				CardsShow = cardVM,
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
				var card = cardService.GetById(id);
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
		public IActionResult AddCard()
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			var newCard = new CardAddDto();

			return View(newCard);
		}

		[HttpPost]
		public IActionResult AddCard(CardAddDto newCard)
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
				return RedirectToAction("Index", "Cards");
			}

			catch (Exception e)
			{
				HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				ViewData["ErrorMessage"] = e.Message;
				return View(newCard);
			}
		}

		[HttpGet]
		public IActionResult UpdateCard([FromRoute] int id)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			var user = GetLoggedUser();

			return View();
		}

		[HttpPost]
		public IActionResult UpdateCard([FromRoute] int id, CardUpdateViewModel newCard)
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
				Card cardToUpdate = cardService.GetById(id);
				var user = GetLoggedUser();
				Card card = mapper.Map<Card>(newCard);
				Card updatedCard = cardService.Update(card, user, cardToUpdate.Id);
				return RedirectToAction("Details", "Cards", new { id = updatedCard.Id });
			}

			catch (Exception e)
			{
				HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
				ViewData["ErrorMessage"] = e.Message;
				return View(newCard);
			}
		}

		[HttpGet]
		public IActionResult RemoveCard([FromRoute] int id)
		{
			if (!IsUserLogged())
			{
				return RedirectToAction("Login", "Users");
			}

			try
			{
				var card = cardService.Remove(id);
				return RedirectToAction("Index", "Cards");
			}

			catch (EntityNotFoundException e)
			{
				this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = e.Message;
				return View("Erorr");
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
