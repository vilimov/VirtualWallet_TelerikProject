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
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Common.Exceptions;

namespace Virtual_Wallet.Controllers.API
{
	[ApiController]
	[Route("api/users")]
	public class UsersApiController : ControllerBase
	{
		private readonly IUserService userService;
		private readonly IMapper mapper;
		private readonly AuthManager authManager;

		public UsersApiController(IUserService userService, IMapper mapper, AuthManager authManager)
		{
			this.userService = userService;
			this.mapper = mapper;
			this.authManager = authManager;
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
		#region Update Profile
		[HttpPut("{id}")]
		public IActionResult UpdateProfile([FromHeader] string credentials, int id, [FromBody] UserUpdateDto userUpdateDto)
		{
			try
			{
				User authenticatedUser = authManager.TryGetUser(credentials);
				if (authenticatedUser == null)
				{
					return Unauthorized("Invalid credentials");
				}
				if (authenticatedUser.Id != id)
				{
					return Unauthorized("You are not authorized to perform this operation");
				}
				User userToUpdate = new User
				{
					Id = id,
					Email = userUpdateDto.Email,
					Password = userUpdateDto.Password
				};
				var updatedUser = userService.UpdateUser(userToUpdate);
				return Ok(updatedUser);
			}
			catch (EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		#endregion
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

        [HttpPost("verification/{token}")]
        public IActionResult Verify(string token)
        {
            try
            {
                var user = userService.Verify(token);
                return StatusCode(StatusCodes.Status200OK, user);
            }
            catch (EntityNotFoundException)
            {
                return NotFound("User not found or not verified.");
            }
            catch (DuplicateEntityException e)
            {
                return Unauthorized(e.Message);
            }
            catch (UnauthorizedOperationException)
            {
                return Unauthorized("Invalid credentials.");
            }
        }

        [HttpDelete("{id}")]
		public IActionResult DeleteUser([FromHeader] string credentials, int id)
		{
			try
			{
				User authenticatedUser = authManager.TryGetUser(credentials);
				if (authenticatedUser == null)
				{
					return Unauthorized("Invalid credentials");
				}
				var userToDelete = userService.GetUserById(id);
				if (userToDelete == null)
				{
					return NotFound("User not found");
				}
				// Check if the authenticated user is an admin or the owner of the account
				if (authenticatedUser.IsAdmin || authenticatedUser.Id == id)
				{
					userService.DeleteUser(id);
					return Ok(new { message = "User is deleted successfully." });
				}
				else
				{
					return Unauthorized("You are not authorized to perform this operation");
				}
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again.");
			}
		}
		#region Block and Unblock Users
		[HttpPut("block/{id}")]
		public IActionResult BlockUser([FromHeader] string credentials, int id)
		{
			try
			{
				User authenticatedUser = authManager.TryGetUser(credentials);
				if (authenticatedUser == null || !authenticatedUser.IsAdmin)
				{
					return Unauthorized("You are not authorized to perform this operation");
				}

				userService.BlockUser(id);
				return Ok("User is blocked");
			}
			catch (EntityNotFoundException)
			{
				return NotFound("User not found");
			}
			catch (Exception)
			{
				return BadRequest("An error occurred while trying to block the user");
			}
		}

		[HttpPut("unblock/{id}")]
		public IActionResult UnblockUser([FromHeader] string credentials, int id)
		{
			try
			{
				User authenticatedUser = authManager.TryGetUser(credentials);
				if (authenticatedUser == null || !authenticatedUser.IsAdmin)
				{
					return Unauthorized("You are not authorized to perform this operation");
				}

				userService.UnblockUser(id);
				return Ok("User is unblocked");
			}
			catch (EntityNotFoundException)
			{
				return NotFound("User not found");
			}
			catch (Exception)
			{
				return BadRequest("An error occurred while trying to unblock the user");
			}
		}
		#endregion
		#region Search Users
		[HttpGet("search/username")]
		public IActionResult SearchByUsername(string username)
		{
			try
			{
				var users = userService.SearchByUsername(username);
				var userDto = mapper.Map<List<UserShowDto>>(users);
				return Ok(userDto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("search/email")]
		public IActionResult SearchByEmail(string email)
		{
			try
			{
				var users = userService.SearchByEmail(email);
				var userDto = mapper.Map<List<UserShowDto>>(users);
				return Ok(userDto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("search/phone")]
		public IActionResult SearchByPhone(string phone)
		{
			try
			{
				var users = userService.SearchByPhone(phone);
				var userDto = mapper.Map<List<UserShowDto>>(users);
				return Ok(userDto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		#endregion
		#region PrivateMethods

		#endregion
	}
}
