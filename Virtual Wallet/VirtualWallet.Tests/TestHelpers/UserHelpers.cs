using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.AdditionalHelpers;

namespace VirtualWallet.Tests.TestHelpers
{
	internal class UsersHelper
	{
		public static User GetTestUser()
		{
			return new User
			{
				Id = 1,
				Username = "ElonMusk",
				Salt = "aYkdwwd7tFrZOsBA2Za0qQ==",
				VerifiedAt = DateTime.Now.AddDays(-6),
				Password = AuthManager.HashPassword("password123", "aYkdwwd7tFrZOsBA2Za0qQ=="),
				Email = "elon@musk.com",
				PhoneNumber = "1234567890",
				Photo = "elon_musk.jpg",
				IsAdmin = true,
				IsBlocked = false,
				IsDeleted = false,
			};
		}

		public static List<User> GetTestUsersList()
		{
			var salt = "aYkdwwd7tFrZOsBA2Za0qQ==";
			
			return new List<User>
		    {
			
				new User 
			    { 
				    Id = 1, 
				    Username = "ElonMusk", 
				    Salt = salt, VerifiedAt = DateTime.Now.AddDays(-6), 
				    Password = AuthManager.HashPassword("password123", salt), 
				    Email = "elon@musk.com", PhoneNumber = "1234567890", 
				    Photo = "elon_musk.jpg", 
				    IsAdmin = true, 
				    IsBlocked = false, 
				    IsDeleted = false
			    },
			
				new User 
			    { 
				    Id = 2,
				    Username = "JeffBezos", 
				    Salt = salt, VerifiedAt = DateTime.Now.AddDays(-6), 
				    Password = AuthManager.HashPassword("password456", salt), 
				    Email = "jeff@amazon.com", PhoneNumber = "9876543210", 
				    Photo = "jeff_bezos.jpg", 
				    IsAdmin = false, 
				    IsBlocked = false, 
				    IsDeleted = false
			    },
            };
		}
	}
}
