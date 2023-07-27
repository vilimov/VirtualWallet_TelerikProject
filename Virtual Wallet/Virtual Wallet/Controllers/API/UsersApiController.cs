using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.VirtualWallet.API.Helpers.Mappers;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.AdditionalHelpers;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.Controllers.API
{
	[ApiController]
	[Route("api/users")]
	public class UsersApiController : ControllerBase
	{
		private readonly IUserService userService;
		private readonly IMapper mapper;

		public UsersApiController(IUserService userService, IMapper mapper)
		{
			this.userService = userService;
			this.mapper = mapper;
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
					return BadRequest("User registration details are null.");
				}

				var newUser = mapper.Map<User>(userRegisterDto);

				var registeredUser = userService.Register(newUser);

				return Ok(registeredUser);
			}
			catch (DuplicateEntityException)
			{
				return BadRequest("Username or Email is already in use.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPost("login")]
		public IActionResult Login(UserLoginDto userLoginDto)
		{
			try
			{
				var userEntity = mapper.Map<User>(userLoginDto);

				var user = userService.Login(userLoginDto.Username, userLoginDto.Password);
				return Ok();
			}
			catch(EntityNotFoundException)
			{
				return NotFound("User not found or not verified.");
			}
			catch(UnauthorizedAccessException)
			{
				return Unauthorized("Invalid credentials.");
			}
			catch(Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again.");
			}
		}
		#region PrivateMethods

		#endregion
	}
}
