using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Linq;
using System.Net;
using Virtual_Wallet.Models.Dtos;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Application.Services;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Common.QueryParameters;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using VirtualWallet.Application.AdditionalHelpers;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Common.Exceptions;
using VirtualWallet.Persistence.QueryParameters;

namespace Virtual_Wallet.VirtualWallet.API.Controllers.API
{
    [ApiController]
    [Route("api/wallets")]
    public class WalletApiController : ControllerBase
    {
        private readonly IWalletService walletService;
        private readonly AuthManager authManager;
        private readonly IMapper mapper;

        public WalletApiController(
            IWalletService walletService, 
            AuthManager authManager, 
            IMapper mapper)
        {
            this.walletService = walletService;
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
                        return StatusCode(StatusCodes.Status404NotFound, Alerts.NoItemToShow);
                    }

                    List<WalletShowDto> result = wallets.Select(wallets => new WalletShowDto(wallets)).ToList();

                    return StatusCode(StatusCodes.Status200OK, result);
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
        public IActionResult GetFilteredWallets([FromHeader] string credentials, [FromQuery] WalletQueryParameters filter)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);

                if (user.IsAdmin == true)
                {
                    var wallets = walletService.GetFilteredWallets(filter);
                    List<WalletShowDto> result = wallets.Select(c => new WalletShowDto(c)).ToList();

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

            catch (UnauthorizedOperationException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }

            catch (InvalidCredentialsException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
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
                    return StatusCode(StatusCodes.Status204NoContent, Alerts.NoItemToShow);
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
                        return StatusCode(StatusCodes.Status403Forbidden, Alerts.NotAutorised);
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

            catch (InvalidCredentialsException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
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
                    return StatusCode(StatusCodes.Status204NoContent, Alerts.NoItemToShow);
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

            catch (InvalidCredentialsException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }


        [HttpPost("")]
        public IActionResult CreateWallet([FromHeader] string credentials, [FromBody] WalletCreateUpdateDto wallet)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                Wallet newWallet = mapper.Map<Wallet>(wallet);
                Wallet createdWallet = walletService.CreateWallet(newWallet, user);
                WalletShowDto result = new WalletShowDto(createdWallet);

                return Ok(result);
            }

            catch (DuplicateEntityException)
            {
                return StatusCode(StatusCodes.Status409Conflict, Alerts.ExistingWallet);
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

        [HttpPut("")]
        public IActionResult UpdateWallet([FromHeader] string credentials, [FromBody] WalletCreateUpdateDto wallet)
        {
            try
            {
                User user = authManager.TryGetUser(credentials);
                Wallet newWallet = mapper.Map<Wallet>(wallet);
                Wallet updatedWallet = this.walletService.Update(user, newWallet);
                WalletShowDto result = new WalletShowDto(updatedWallet);

                return Ok(result);
            }

            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
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
                    return StatusCode(StatusCodes.Status403Forbidden, Alerts.NotAutorised);
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

            catch (UnauthorizedOperationException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }

            catch (InvalidCredentialsException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }
    }
}
