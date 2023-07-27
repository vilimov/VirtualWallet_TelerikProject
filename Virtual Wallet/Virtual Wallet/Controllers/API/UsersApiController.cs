using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Virtual_Wallet.Models.Dtos;
using Virtual_Wallet.VirtualWallet.API.Helpers.Mappers;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.AdditionalHelpers;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.Exceptions;

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

				if(users == null || !users.Any())
				{
					return NotFound("No users found");
				}

				var userDtos = mapper.Map<IEnumerable<UserShowDto>>(users);
				
				return Ok(userDtos);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again.");
			}
		}
		[HttpGet("{id}")]
		public IActionResult GetUserWithId(int id)
		{
			try
			{
				var user = userService.GetUserById(id);
				if (user == null)
				{
					return NotFound();
				}

				var userDto = mapper.Map<UserShowDto>(user);

				return Ok(userDto);
			}
			catch (EntityNotFoundException)
			{
				return NotFound("User not found.");
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again.");
			}
		}
		[HttpGet("email/{email}")]
		public IActionResult GetUserWithEmail(string email)
		{
			try
			{
				var user = userService.GetUserByEmail(email);

				if (user == null)
				{
					return NotFound("User not found.");
				}

				var userDto = mapper.Map<UserShowDto>(user);

				return Ok(userDto);
			}
			catch (EntityNotFoundException)
			{
				return NotFound("User not found.");
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again.");
			}
		}
		[HttpGet("phone/{phoneNumber}")]
		public IActionResult GetUserWithPhoneNumber(string phoneNumber)
		{
			try
			{
				var user = userService.GetUserByPhoneNumber(phoneNumber);

				if (user == null)
				{
					return NotFound("User not found.");
				}

				var userDto = mapper.Map<UserShowDto>(user);

				return Ok(userDto);
			}
			catch (EntityNotFoundException)
			{
				return NotFound("User not found.");
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again.");
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

				return Ok(newUser);
			}
			catch (DuplicateEntityException)
			{
				return BadRequest(new { message = "User already exists" });
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
			catch(UnauthorizedOperationException)
			{
				return Unauthorized("Invalid credentials.");
			}
			catch(Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again.");
			}
		}
		[HttpDelete("id")]
		public IActionResult DeleteUser(int id)
		{
			try
			{
				var userToDelete = userService.GetUserById(id);

				if(userToDelete == null)
				{
					return NotFound("User not found.");
				}

				userService.DeleteUser(id);
				return Ok(new { message = "User is deleted successfully."});
			}
			catch(EntityNotFoundException)
			{
				return NotFound("User not found");
			}
			catch (UnauthorizedOperationException)
			{
				return Unauthorized("Invalid cretentials.");
			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again.");
			}
		}
		#region PrivateMethods

		#endregion
	}
}
