using Microsoft.EntityFrameworkCore;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Data;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository
{
	public class UserRepository : IUserRepository

	{
		private readonly WalletContext context;

		public UserRepository(WalletContext context) 
		{
			this.context = context;
		}
		public IEnumerable<User> GetAllUsers()
		{
			return context.Users.ToList();
		}

		public User GetUserById(int id)
		{
			var user = this.context.Users.Find(id);
			if (user == null)
			{
				throw new UserNotFoundException(id);
			}
			return user;
		}
		public User GetUserByUsername(string username)
		{
			var user = this.context.Users.FirstOrDefault(u => u.Username == username);
			if (user == null)
			{
				throw new EntityNotFoundException(username);
			}
			return user;
		}
		public User GetUserByEmail(string email)
		{
			var user = this.context.Users.FirstOrDefault(u => u.Email == email);
			if (user == null)
			{
				throw new EntityNotFoundException(email);
			}
			return user;
		}

		public User AddUser(User user)
		{
			var result = context.Users.Add(user);
			context.SaveChanges();
			return result.Entity;
		}

		public User UpdateUser(User user)
		{
			context.Entry(user).State = EntityState.Modified;
			context.SaveChanges();
			return user;
		}

		public void DeleteUser(int id)
		{
			var user = context.Users.Find(id);
			if (user != null)
			{
				context.Users.Remove(user);
				context.SaveChanges();
			}
		}
	}
}
