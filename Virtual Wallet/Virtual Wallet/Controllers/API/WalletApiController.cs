using AutoMapper;

namespace Virtual_Wallet.Controllers.API
{
    [ApiController]
    [Route("api/wallets")]
    public class WalletApiController : ControllerBase
    {
        private readonly IWalletService walletService;
        //private readonly AuthManager authManager;
        //private readonly IMapper mapper;

        public WalletApiController(IWalletService walletService)
        {
            this.walletService = walletService;
        }

        [HttpGet("")]
        public IActionResult GetWallets()
        {
            List<Wallet> result = walletService.GetAll().ToList();
            if (result.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"No wallets found!");
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
