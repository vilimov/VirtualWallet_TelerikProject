using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts
{
    public interface IUserRepository
    {
	    Task<User> GetUserById(int id);
		Task<IEnumerable<User>> GetAllUsers();
		Task<User> GetUserByUsername(string username);
		Task<User> GetUserByEmail(string email);
		Task<User> AddUser(User user);
		Task<User> UpdateUser(User user);
		Task DeleteUser(int id);
	}
}
