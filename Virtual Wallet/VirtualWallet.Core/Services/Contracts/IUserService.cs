using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.AdditionalHelpers;

namespace VirtualWallet.Application.Services.Contracts
{
    public interface IUserService
    {
		IEnumerable<User> GetAllUsers();
		User GetUserById(int id);
		User GetUserByEmail(string email);
		User GetUserByUsername(string username);
		User GetUserByPhoneNumber(string phoneNumber);
		User Register(User user);
		User UpdateUser(User user);
		void DeleteUser(int id);
		User Login(string username, string password);
		public User Verify(string token);
		void BlockUser(int id);
		void UnblockUser(int id);
		IEnumerable<User> SearchByUsername(string username);
		IEnumerable<User> SearchByEmail(string email);
		IEnumerable<User> SearchByPhone(string phone);
	}
}
