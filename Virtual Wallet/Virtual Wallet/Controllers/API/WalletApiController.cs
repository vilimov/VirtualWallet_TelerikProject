using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Linq;
using System.Net;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.AdditionalHelpers;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Common.Exceptions;

namespace Virtual_Wallet.VirtualWallet.API.Controllers.API
{
    [ApiController]
    [Route("api/wallets")]
    public class WalletApiController : ControllerBase
    {
        private readonly IWalletService walletService;
        //private readonly IUserService userService;
        private readonly AuthManager authManager;
        private readonly IMapper mapper;

        public WalletApiController(IWalletService walletService/*, IUserService userService*/, AuthManager authManager, IMapper mapper)
        {
            this.walletService = walletService;
            //this.userService = userService;
            this.authManager = authManager;
            this.mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult GetWallets([FromHeader] string credentials)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                if (user.IsAdmin == true)
                {
                    List<Wallet> wallets = walletService.GetAll().ToList();
                    if (wallets.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, $"No wallets found!");
                    }
                    List<WalletShowDto> result = wallets.Select(wallets => new WalletShowDto(wallets)).ToList();
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "");
                }
            }
            catch (UnauthorizedOperationException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetWalletById([FromHeader] string credentials, int id)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                if (user.IsAdmin == true)
                {
                    Wallet wallet = walletService.GetWalletById(id);
                    WalletShowDto result = new WalletShowDto(wallet);

                    return StatusCode(StatusCodes.Status200OK, result);
                }
                else
                {
                    throw new UnauthenticatedOperationException(Alerts.InvalidCredentials);
                }                    
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }
        }
/*
        [HttpPost("")]
        public IActionResult CreateWallet(WalletCreateDto newWallet*//*, [FromHeader] string credentials*//*)
        {
            //ToDo
            //User user = AuthenticationManager.TryGetUser(credentials);
            User user = new User();
            Wallet wallet = mapper.Map<Wallet>(newWallet);
            Wallet createdWallet = walletService.CreateWallet(wallet, user);
            return createdWallet;
        }*/

        //ToDo
        [HttpDelete("{id}")]
        public IActionResult DeleteWallet([FromHeader] string credentials, int id)
        {
            try
            {                
                User user = authManager.TryGetUser(credentials);
                Wallet deletedWallet = walletService.Delete(id);
                WalletShowDto result = new WalletShowDto(deletedWallet);
                return Ok(result);
            }
            catch (WalletNotEmptyException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
