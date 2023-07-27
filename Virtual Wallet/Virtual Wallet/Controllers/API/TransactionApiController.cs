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
        private readonly IWalletService walletService;  
        public TransactionApiController(ITransactionService transactionService,
                                        IMapper mapper,
                                        AuthManager authManager,
                                        ICardService cardService,
                                        IWalletService walletService)
        {
            this.transactionService = transactionService;   
            this.mapper = mapper;
            this.authManager = authManager;
            this.cardService = cardService;
            this.walletService = walletService;
        }

        [HttpGet("")]
        public IActionResult GetAllTransactions()
        {
            var transactions = transactionService.GetAllTransactions();
            var transactionShow = mapper.Map<List<TransactionShowDto>>(transactions);

            if (transactions.Count != 0) 
            {
                return StatusCode(StatusCodes.Status200OK, transactionShow);
            }
            return StatusCode(StatusCodes.Status404NotFound, Alerts.NoItemToShow);
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
            //public Transaction AddMoneyCardToWallet(User user, Card card, Wallet wallet, decimal amount)
            try
            {
                User user = authManager.TryGetUser(credentials);
                Card card = cardService.GetById(transactionDto.CardId);
                Wallet wallet = walletService.GetWalletByUser(user.Username);
                Transaction makeTransaction = transactionService.AddMoneyCardToWallet(user, card, wallet, transactionDto.Amount);
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
        }
    }
}
