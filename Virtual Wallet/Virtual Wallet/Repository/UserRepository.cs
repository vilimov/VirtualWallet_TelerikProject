using Microsoft.EntityFrameworkCore;
using Virtual_Wallet.Data;
using Virtual_Wallet.Helpers.Exceptions;
using Virtual_Wallet.Models;
using Virtual_Wallet.Repository.Contracts;

namespace Virtual_Wallet.Repository
{
	public class UserRepository : IUserRepository

	{
		private readonly WalletContext context;

		public UserRepository(WalletContext context) 
		{
			this.context = context;
		}
		public async Task<IEnumerable<User>> GetAllUsers()
		{
			return await context.Users.ToListAsync();
		}

		public async Task<User> GetUserById(int id)
		{
			var user = await this.context.Users.FindAsync(id);
			if (user == null)
			{
				throw new UserNotFoundException(id);
			}
			return user;
		}
		public async Task<User> GetUserByUsername(string username)
		{
			var user = await this.context.Users.FirstOrDefaultAsync(u => u.Username == username);
			if (user == null)
			{
				throw new UsernameNotFoundException(username);
			}
			return user;
		}

		public async Task<User> AddUser(User user)
		{
			var result = await context.Users.AddAsync(user);
			await context.SaveChangesAsync();
			return result.Entity;
		}

		public async Task<User> UpdateUser(User user)
		{
			context.Entry(user).State = EntityState.Modified;
			await context.SaveChangesAsync();
			return user;
		}

		public async Task DeleteUser(int id)
		{
			var user = await context.Users.FindAsync(id);
			if (user != null)
			{
				context.Users.Remove(user);
				await context.SaveChangesAsync();
			}
		}
	}
}
