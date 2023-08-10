using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Common.QueryParameters;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.AdditionalHelpers;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Common.Exceptions;

namespace Virtual_Wallet.VirtualWallet.API.Controllers.API
{
	[ApiController]
	[Route("api/cards")]
	public class CardsApiController : ControllerBase
	{
		private readonly ICardService cardService;
		private readonly IMapper mapper;
		private readonly IUserService userService;
		private readonly AuthManager authManager;

		public CardsApiController(
			ICardService cardService,
			IMapper mapper,
			IUserService userService,
			AuthManager authManager)
		{
			this.cardService = cardService;
			this.mapper = mapper;
			this.userService = userService;
			this.authManager = authManager;
		}

		[HttpGet("")]
		public IActionResult GetCards([FromHeader] string credentials)
		{
			try
			{
				User user = authManager.TryGetUser(credentials);

				if (user.IsAdmin == true)
				{
					List<Card> cards = cardService.GetAll().ToList();

					if (cards.Count == 0)
					{
						return StatusCode(StatusCodes.Status204NoContent, Alerts.NoItemToShow);
					}

					List<CardShowDto> result = cards.Select(c => new CardShowDto(c)).ToList();

					return Ok(result);
				}
				else
				{
					return StatusCode(StatusCodes.Status403Forbidden, Alerts.NotAutorised);
				}
			}
			catch (UnauthorizedOperationException ex)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
			}
			catch (InvalidCredentialsException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpGet("filters")]
		public IActionResult GetFilteredCards([FromHeader] string credentials, [FromQuery] CardQueryParameters filter)
		{
			try
			{
				User user = authManager.TryGetUser(credentials);

				if (user.IsAdmin == true)
				{
					var cards = cardService.GetFilteredCards(filter);
					List<CardShowDto> result = cards.Select(c => new CardShowDto(c)).ToList();

					return result.Count > 0
						? StatusCode(StatusCodes.Status200OK, result)
						: (IActionResult)StatusCode(StatusCodes.Status404NotFound, Alerts.NoItemToShow);
				}
				else
				{
					return StatusCode(StatusCodes.Status401Unauthorized, Alerts.NotAutorised);
				}
			}
			catch (EntityNotFoundException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}

			catch (InvalidCredentialsException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpGet("id")]
		public IActionResult GetById([FromHeader] string credentials, int id)
		{
			try
			{
				User user = authManager.TryGetUser(credentials);
				Card card = cardService.GetById(id);

				if (user.IsAdmin == true || user == card.User)
				{
					try
					{
						CardShowDto result = new CardShowDto(card);

						return Ok(result);
					}
					catch (EntityNotFoundException ex)
					{
						return StatusCode(StatusCodes.Status404NotFound, ex.Message);
					}
				}
				else
				{
					return StatusCode(StatusCodes.Status403Forbidden, Alerts.NotAutorised);
				}
			}
			catch (UnauthorizedOperationException ex)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
			}
			catch (EntityNotFoundException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (InvalidCredentialsException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpGet("number")]
		public IActionResult GetByNumber([FromHeader] string credentials, string number)
		{
			try
			{
				User user = authManager.TryGetUser(credentials);
				Card card = cardService.GetByNumber(number);

				if (user.IsAdmin == true || user == card.User)
				{
					try
					{
						CardShowDto result = new CardShowDto(card);

						return Ok(result);
					}
					catch (EntityNotFoundException ex)
					{
						return StatusCode(StatusCodes.Status404NotFound, ex.Message);
					}
				}
				else
				{
					return StatusCode(StatusCodes.Status403Forbidden, Alerts.NotAutorised);
				}
			}
			catch (UnauthorizedOperationException ex)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
			}

			catch (EntityNotFoundException ex)
			{
				return BadRequest(ex.Message);
			}

			catch (InvalidCredentialsException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpGet("user")]
		public IActionResult GetByUser([FromHeader] string credentials)
		{
			try
			{
				User user = authManager.TryGetUser(credentials);
				List<Card> cards = cardService.GetByUser(user).ToList();

				if (cards.Count == 0)
				{
					return StatusCode(StatusCodes.Status404NotFound, Alerts.NoItemToShow);
				}

				List<CardShowDto> result = cards.Select(c => new CardShowDto(c)).ToList();

				return Ok(result);
			}
			catch (UnauthorizedOperationException ex)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
			}
			catch (InvalidCredentialsException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpPost("")]
		public IActionResult Post([FromHeader] string credentials, [FromBody] CardAddDto cardDto)
		{
			try
			{
				User user = authManager.TryGetUser(credentials);
				Card card = mapper.Map<Card>(cardDto);
				Card cardToAdd = cardService.Add(card, user);
				CardShowDto result = new CardShowDto(cardToAdd);

				return Ok(result);
			}
			catch (EntityNotFoundException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (UnauthorizedOperationException ex)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
			}
			catch (DuplicateEntityException ex)
			{
				return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
			}
			catch (CardAlreadyExpired ex)
			{
				return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
			}
			catch (InvalidCredentialsException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCard([FromHeader] string credentials, [FromBody] CardAddDto cardDto, int id)
		{
			try
			{
				User user = authManager.TryGetUser(credentials);
				Card currentCard = cardService.GetById(id);

				if (currentCard.User != user)
				{
					return StatusCode(StatusCodes.Status401Unauthorized, Alerts.NotAutorised);
				}

				Card updatedCard = mapper.Map<Card>(cardDto);
				Card result = cardService.Update(currentCard, user, id);

				return Ok(result);
			}
			catch (EntityNotFoundException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (UnauthorizedOperationException ex)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
			}
			catch (DuplicateEntityException ex)
			{
				return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
			}
			catch (CardAlreadyExpired ex)
			{
				return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
			}
			catch (InvalidCredentialsException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpDelete("id")]
		public IActionResult RemoveCard([FromHeader] string credentials, int id)
		{
			try
			{
				User user = authManager.TryGetUser(credentials);
				Card card = cardService.GetById(id);

				if (card.User == user || user.IsAdmin == true)
				{
					cardService.Remove(card.Id);
					CardShowDto result = new CardShowDto(card);

					return Ok(result);
				}
				else
				{
					return StatusCode(StatusCodes.Status403Forbidden, Alerts.NotAutorised);
				}
			}
			catch (EntityNotFoundException ex)
			{
				return StatusCode(StatusCodes.Status404NotFound, ex.Message);
			}
			catch (InvalidCredentialsException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}
	}
}
