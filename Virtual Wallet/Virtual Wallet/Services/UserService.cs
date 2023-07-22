using Virtual_Wallet.Helpers.Exceptions;
using Virtual_Wallet.Models;
using Virtual_Wallet.Repository.Contracts;
using Virtual_Wallet.Services.Contracts;

namespace Virtual_Wallet.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository userRepository;

		public UserService(IUserRepository userRepository) 
		{			
			this.userRepository = userRepository;
		}

		public async Task<IEnumerable<User>> GetAllUsers()
		{
			return await this.userRepository.GetAllUsers();
		}
		public async Task<User> GetUserById(int id)
		{
			return await this.userRepository.GetUserById(id);
		}
		public async Task<User> GetUserByEmail(string email)
		{
			return await userRepository.GetUserByEmail(email);
		}

		public async Task<User> GetUserByUsername(string username)
		{
			return await this.userRepository.GetUserByUsername(username);
		}

		public async Task<User> Register(User user)
		{
			// Todo more business logic in future
			var existingUserUsername = await this.userRepository.GetUserByUsername(user.Username);
			var existingUserEmail = await this.userRepository.GetUserByEmail(user.Email);
			if (existingUserUsername != null)
			{
				throw new DuplicateEntityException(user.Username);
			}
			if (existingUserEmail != null)
			{
				throw new DuplicateEntityException(user.Email);
			}

			return await this.userRepository.AddUser(user);
		}

		public async Task<User> UpdateUser(User user)
		{
			// Todo more business logic in future
			var existingUser = await this.userRepository.GetUserById(user.Id);
			if (existingUser == null)
			{
				throw new UserNotFoundException(user.Id);
			}

			return await this.userRepository.UpdateUser(user);
		}

		public async Task DeleteUser(int id)
		{
			await this.userRepository.DeleteUser(id);
		}
	}
}
