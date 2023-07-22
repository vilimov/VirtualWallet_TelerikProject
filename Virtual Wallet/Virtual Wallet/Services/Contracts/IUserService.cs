using Virtual_Wallet.Models;

namespace Virtual_Wallet.Services.Contracts
{
    public interface IUserService
    {
		Task<IEnumerable<User>> GetAllUsers();
		Task<User> GetUserById(int id);
		Task<User> GetUserByEmail(string email);
		Task<User> GetUserByUsername(string username);
		Task<User> Register(User user);
		Task<User> UpdateUser(User user);
		Task DeleteUser(int id);
	}
}
