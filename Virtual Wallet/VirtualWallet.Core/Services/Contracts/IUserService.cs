using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace VirtualWallet.Application.Services.Contracts
{
    public interface IUserService
    {
		IEnumerable<User> GetAllUsers();
		User GetUserById(int id);
		User GetUserByEmail(string email);
		User GetUserByUsername(string username);
		User Register(User user);
		User UpdateUser(User user);
		void DeleteUser(int id);
	}
}
