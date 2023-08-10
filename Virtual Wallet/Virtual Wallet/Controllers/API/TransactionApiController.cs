using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.Models.Dtos;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.AdditionalHelpers;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Common.Exceptions;
using VirtualWallet.Common.QueryParameters;

namespace Virtual_Wallet.Controllers.API
{
	[ApiController]
	[Route("api/transaction")]
	public class TransactionApiController : ControllerBase
	{
		private readonly ITransactionService transactionService;
		private readonly IMapper mapper;
		private readonly AuthManager authManager;
		private readonly ICardService cardService;
		private readonly IUserService userService;
		public TransactionApiController(
			ITransactionService transactionService,
			IMapper mapper,
			AuthManager authManager,
			ICardService cardService,
			IUserService userService)
		{
			this.transactionService = transactionService;
			this.mapper = mapper;
			this.authManager = authManager;
			this.cardService = cardService;
			this.userService = userService;
		}

		[HttpGet("")]
		public IActionResult GetAllTransactions([FromHeader] string credentials, [FromQuery] TransactionsQueryParameters filter)
		{
			User user = authManager.TryGetUser(credentials);
			var transactions = transactionService.GetAllTransactions();
			var transactionShow = mapper.Map<List<TransactionShowDto>>(transactions);

			if (transactions.Count != 0)
			{
				return StatusCode(StatusCodes.Status200OK, transactionShow);
			}

			return StatusCode(StatusCodes.Status404NotFound, Alerts.NoItemToShow);
		}

		[HttpGet("filters")]
		public IActionResult GetFilteredTransactions(
			[FromHeader] string credentials,
			[FromQuery] TransactionsQueryParameters filter,
			int pageNumber = 1,
			int pageSize = 5)
		{
			try
			{
				User user = authManager.TryGetUser(credentials);
				var transactions = transactionService.GetFilteredTransactions(pageNumber, pageSize, filter, user);
				var transactionShow = mapper.Map<List<TransactionShowDto>>(transactions);
				return transactions.Count > 0
					? StatusCode(StatusCodes.Status200OK, transactionShow)
					: (IActionResult)StatusCode(StatusCodes.Status404NotFound, Alerts.NoItemToShow);
			}
			catch (EntityNotFoundException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
			catch (InvalidCredentialsException e)
			{
				return StatusCode(StatusCodes.Status400BadRequest, e.Message);
			}
			catch (UnauthorizedOperationException e)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}

		}

		[HttpGet("{id}")]
		public IActionResult GetTransactionById(int id)
		{
			try
			{
				var transaction = transactionService.GetTransactionById(id);
				var transactionShow = mapper.Map<TransactionShowDto>(transaction);
				return StatusCode(StatusCodes.Status200OK, transactionShow);
			}
			catch (EntityNotFoundException)
			{
				return StatusCode(StatusCodes.Status404NotFound, string.Format(Alerts.NotFound, "Transaction", "ID", $"{id}"));
			}
		}

		[HttpGet("mytransactions/{userId}")]
		public IActionResult GetTransactionsByUserID(int userId)
		{
			try
			{
				var transactiona = transactionService.GetTransactionsByUserId(userId);
				var transactionShow = mapper.Map<List<TransactionShowDto>>(transactiona);
				return StatusCode(StatusCodes.Status200OK, transactionShow);
			}
			catch (EntityNotFoundException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpPost("BankTransfer")]
		public IActionResult MakeBankTransfer([FromHeader] string credentials, [FromBody] CreateBankTransactionDto transactionDto)
		{
			try
			{
				User user = authManager.TryGetUser(credentials);
				Card card = cardService.GetById(transactionDto.CardId);
				Transaction makeTransaction = transactionService.AddMoneyCardToWallet(user, card, transactionDto.Amount, transactionDto.Description);
				return StatusCode(StatusCodes.Status200OK, makeTransaction);
			}
			catch (EntityNotFoundException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
			catch (UnauthorizedOperationException e)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
			catch (InvalidCredentialsException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpPost("internalTransfer")]
		public IActionResult MakeInternalTransfer([FromHeader] string credentials, [FromBody] CreateTransactionRequestDto transactionDto)
		{
			try
			{
				User sender = authManager.TryGetUser(credentials);
				User recipient = userService.GetUserById(transactionDto.RecipientId);
				if (recipient == sender)
				{
					return StatusCode(StatusCodes.Status406NotAcceptable, Alerts.MoneyToYourself);
				}
				Transaction makeTransaction = transactionService.AddMoneyWalletToWallet(sender, recipient, transactionDto.Amount, transactionDto.Description);
				return StatusCode(StatusCodes.Status200OK, makeTransaction);
			}
			catch (EntityNotFoundException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
			catch (UnauthorizedOperationException e)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
			catch (InvalidCredentialsException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}

		[HttpPost("WithdrawalTransfer")]
		public IActionResult MakeWithdrawalTransfer([FromHeader] string credentials, [FromBody] CreateBankTransactionDto transactionDto)
		{
			try
			{
				User user = authManager.TryGetUser(credentials);
				Card card = cardService.GetById(transactionDto.CardId);
				Transaction makeTransaction = transactionService.WithdrawalTransfer(user, card, transactionDto.Amount, transactionDto.Description);
				return StatusCode(StatusCodes.Status200OK, makeTransaction);
			}
			catch (EntityNotFoundException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
			catch (UnauthorizedOperationException e)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
			catch (InvalidCredentialsException e)
			{
				return StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
		}
	}
}
