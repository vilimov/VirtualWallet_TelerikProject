using AutoMapper;
using System.Net;

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
            List<Wallet> wallets = walletService.GetAll().ToList();
            if (wallets.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"No wallets found!");
            }
            List<WalletShowDto> result = wallets.Select(wallets => new WalletShowDto(wallets)).ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetWalletById(int id)
        {
            try
            {
                Wallet wallet = walletService.GetWalletById(id);
                WalletShowDto result = new WalletShowDto(wallet);

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (EntityNotFoundException ex)
            {
                string message = ex.Message.ToString();
                return StatusCode(StatusCodes.Status404NotFound, message);
            }
        }

        /*[HttpPost("")]
        public IActionResult CreateWallet()
        { 
        }*/

        [HttpDelete("{id}")]
        public IActionResult DeleteWallet(int id)//[FromHeader] string credentials
        {
            try
            {
                //User user = AuthenticationManager.TryGetUser(credentials);
                Wallet deletedWallet = walletService.Delete(id);
                return Ok(deletedWallet);
            }
            catch (WalletNotEmptyException ex)
            {
                string message = ex.Message.ToString();
                return StatusCode(StatusCodes.Status403Forbidden, message);
            }
            catch (EntityNotFoundException ex)
            {
                string message = ex.Message.ToString();
                return StatusCode(StatusCodes.Status404NotFound, message);
            }
        }
    }
}
