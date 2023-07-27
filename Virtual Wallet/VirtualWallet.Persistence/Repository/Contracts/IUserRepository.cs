using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts
{
    public interface IUserRepository
    {
		IEnumerable<User> GetAllUsers();
		User GetUserById(int id);
		User GetUserByUsername(string username);
		User GetUserByEmail(string email);
		User GetUserByPhoneNumber(string phoneNumber);
		User AddUser(User user);
		User UpdateUser(User user);
		void DeleteUser(int id);
		public User VerifyUser(User user);

    }
}
