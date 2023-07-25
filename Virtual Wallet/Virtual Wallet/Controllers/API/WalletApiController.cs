using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.VirtualWallet.API.Controllers.API
{
    [ApiController]
    [Route("api/wallets")]
    public class WalletApiController : ControllerBase
    {
        private readonly IWalletService walletService;
        private readonly IUserService userService;
        //private readonly AuthManager authManager;
        private readonly IMapper mapper;

        public WalletApiController(IWalletService walletService, IUserService userService, IMapper mapper)
        {
            this.walletService = walletService;
            this.userService = userService;
            this.mapper = mapper;
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
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
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
        public IActionResult DeleteWallet(int id/*, [FromHeader] string credentials*/)
        {
            try
            {
                //ToDo
                //User user = AuthenticationManager.TryGetUser(credentials);
                Wallet deletedWallet = walletService.Delete(id);
                return Ok(deletedWallet);
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
