using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.AdditionalHelpers;

namespace Virtual_Wallet.Controllers.API
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionApiController : ControllerBase
    {
        private readonly ITransactionService transactionService;
        private readonly IMapper mapper;
        public TransactionApiController(ITransactionService transactionService,
                                        IMapper mapper)
        {
            this.transactionService = transactionService;   
            this.mapper = mapper;
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
    }
}
