using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.VirtualWallet.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository userRepository;

		public UserService(IUserRepository userRepository) 
		{			
			this.userRepository = userRepository;
		}

		public IEnumerable<User> GetAllUsers()
		{
			return this.userRepository.GetAllUsers();
		}

		public User GetUserById(int id)
		{
			return this.userRepository.GetUserById(id);
		}

		public User GetUserByEmail(string email)
		{
			return userRepository.GetUserByEmail(email);
		}

		public User GetUserByUsername(string username)
		{
			return this.userRepository.GetUserByUsername(username);
		}

		public User Register(User user)
		{
			// Todo more business logic in future
			var existingUserUsername = this.userRepository.GetUserByUsername(user.Username);
			var existingUserEmail = this.userRepository.GetUserByEmail(user.Email);
			if (existingUserUsername != null)
			{
				throw new DuplicateEntityException(user.Username);
			}
			if (existingUserEmail != null)
			{
				throw new DuplicateEntityException(user.Email);
			}

			return this.userRepository.AddUser(user);
		}

		public User UpdateUser(User user)
		{
			// Todo more business logic in future
			var existingUser = this.userRepository.GetUserById(user.Id);
			if (existingUser == null)
			{
				throw new UserNotFoundException(user.Id);
			}

			return this.userRepository.UpdateUser(user);
		}

		public void DeleteUser(int id)
		{
			this.userRepository.DeleteUser(id);
		}
	}
}
