using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Linq;
using System.Net;
using Virtual_Wallet.Models.Dtos;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
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
                    return StatusCode(StatusCodes.Status403Forbidden, "You are not autorised for this service!");
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
                Wallet wallet = this.walletService.GetWalletById(id);
                if (wallet == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"User {user.Username} does not have a wallet!");
                }
                else
                {
                    if (user.IsAdmin == true || user == wallet.User)
                    {
                        WalletShowDto result = new WalletShowDto(wallet);

                        return StatusCode(StatusCodes.Status200OK, result);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status403Forbidden, "You are not autorised for this service!");
                    }
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

        [HttpGet("user")]
        public IActionResult GetWalletByUsername([FromHeader] string credentials)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                Wallet wallet = walletService.GetWalletByUser(user.Username);
                if (wallet == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"User {user.Username} does not have a wallet!");
                }
                else
                {
                    WalletShowDto result = new WalletShowDto(wallet);

                    return StatusCode(StatusCodes.Status200OK, result);
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


        [HttpPost("")]
        public IActionResult CreateWallet([FromHeader] string credentials, [FromBody] WalletCreateUpdateDto newWallet)
        {
            // Create wallet should only be accessible through create user API
            User user = authManager.TryGetUser(credentials);
            try
            {
                Wallet existingWallet = walletService.GetWalletByUser(user.Username);
                return StatusCode(StatusCodes.Status409Conflict, $"User: {user.Username} already has a wallet!");
            }
            catch (EntityNotFoundException)
            {
                Wallet wallet = mapper.Map<Wallet>(newWallet);
                Wallet createdWallet = walletService.CreateWallet(wallet, user);
                WalletShowDto result = new WalletShowDto(createdWallet);
                return Ok(result);
            }
        }

        [HttpPut("")]
        public IActionResult UpdateWallet([FromHeader] string credentials, [FromBody] WalletCreateUpdateDto newWallet)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                Currency newCurrencyCode = newWallet.CurrencyCode;
                Wallet updatedWallet = this.walletService.Update(user, newCurrencyCode);
                WalletShowDto result = new WalletShowDto(updatedWallet);

                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWallet([FromHeader] string credentials, int id)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                Wallet wallet = walletService.GetWalletById(id);
                if (user.IsAdmin == true || user == wallet.User)
                {
                    Wallet deletedWallet = walletService.Delete(id);
                    WalletShowDto result = new WalletShowDto(deletedWallet);
                    return Ok(result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "You are not autorised for this service!");
                }
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
