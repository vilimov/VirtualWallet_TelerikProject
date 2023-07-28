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
			return context.Users.ToList();
		}

		public User GetUserById(int id)
		{
			var user = this.context.Users.FirstOrDefault(u => u.Id == id);

			return user;
		}
		public User GetUserByUsername(string username)
		{
			var user = this.context.Users.FirstOrDefault(u => u.Username == username);
			return user;
		}

		public User GetUserByEmail(string email)
		{
			var user = this.context.Users.FirstOrDefault(u => u.Email == email);
			return user;
		}
		public User GetUserByPhoneNumber(string phoneNumber)
		{
			var user = this.context.Users.FirstOrDefault(u =>u.PhoneNumber == phoneNumber);
			//if (user == null)
			//{
			//	throw new EntityNotFoundException(string.Format(Alerts.UserNotFound, "phone", $"{phoneNumber}"));
			//}
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
    }
}
