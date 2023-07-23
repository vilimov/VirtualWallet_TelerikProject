﻿using Virtual_Wallet.Models;

namespace Virtual_Wallet.Repository.Contracts
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