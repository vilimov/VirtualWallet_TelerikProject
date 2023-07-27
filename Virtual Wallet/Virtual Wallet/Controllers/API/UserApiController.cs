using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.AdditionalHelpers;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.Controllers.API
{
	[ApiController]
	[Route("api/users")]
	public class UserApiController : ControllerBase
	{
		private readonly IUserService userService;
		private readonly AuthManager authManager;

		public UserApiController(IUserService userService, AuthManager authManager)
		{
			this.userService = userService;
			this.authManager = authManager;
		}
		[HttpGet]
		public IActionResult GetUsers()
		{
			try
			{
				var users = userService.GetAllUsers();
				return Ok(users);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpGet("{id}")]
		public IActionResult GetUser(int id)
		{
			try
			{
				var user = userService.GetUserById(id);
				if (user == null)
				{
					return NotFound();
				}

				return Ok(user);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPost("register")]
		public IActionResult Register(UserRegisterDto userRegisterDto)
		{
			try
			{
				if (userRegisterDto == null)
				{
					return BadRequest("User registration details are null");
				}

				var newUser = ToEntity(userRegisterDto);

				var registeredUser = userService.Register(newUser);

				return Ok(registeredUser);
			}
			catch (DuplicateEntityException)
			{
				return BadRequest("Username or Email is already in use");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		#region PrivateMethods
		private User ToEntity(UserRegisterDto userRegisterDto)
		{
			return new User
			{
				Username = userRegisterDto.Username,
				Email = userRegisterDto.Email,
				Password = userRegisterDto.Password
			};
		}
		#endregion
	}
}
