using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Data;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Common.AdditionalHelpers;

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
			return context.Users.Where(u => !u.IsDeleted).ToList();
		}

		public User GetUserById(int id)
		{
			return this.context.Users.FirstOrDefault(u => u.Id == id);
		}

		public User GetUserByUsername(string username)
		{
			return this.context.Users.FirstOrDefault(u => u.Username == username);
		}

		public User GetUserByEmail(string email)
		{
			return this.context.Users.FirstOrDefault(u => u.Email == email);
		}

		public User GetUserByPhoneNumber(string phoneNumber)
		{
			return this.context.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
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
				user.IsDeleted = true;
				context.SaveChanges();
			}
		}

		public User VerifyUser(User user)
        {
            if (user == null)
            {
                throw new EntityNotFoundException(Alerts.UserNotVerified);
            }
            context.Users.Update(user);
            context.SaveChanges();
            return user;
        }
		public IEnumerable<User> SearchByUsername(string username)
		{
			return context.Users
				.Where(u => u.Username.Contains(username))
				.ToList();
		}

		public IEnumerable<User> SearchByEmail(string email)
		{
			return context.Users
				.Where(u => u.Email.Contains(email))
				.ToList();
		}

		public IEnumerable<User> SearchByPhone(string phone)
		{
			return context.Users
				.Where(u => u.PhoneNumber.Contains(phone))
				.ToList();
		}
	}
}
