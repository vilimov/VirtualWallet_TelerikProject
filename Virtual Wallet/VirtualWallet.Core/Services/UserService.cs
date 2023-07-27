﻿using System.Security.Cryptography;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.AdditionalHelpers;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.AdditionalHelpers;

namespace Virtual_Wallet.VirtualWallet.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository userRepository;

		public UserService(IUserRepository userRepository) 
		{			
			this.userRepository = userRepository;
		}

		public IEnumerable<User> GetAllUsers()
		{
			return this.userRepository.GetAllUsers();
		}

		public User GetUserById(int id)
		{
			return this.userRepository.GetUserById(id);
		}

		public User GetUserByEmail(string email)
		{
			return userRepository.GetUserByEmail(email);
		}

		public User GetUserByUsername(string username)
		{
			return this.userRepository.GetUserByUsername(username);
		}

		public User Register(User user)
		{
			var existingUserUsername = this.userRepository.GetUserByUsername(user.Username);
			var existingUserEmail = this.userRepository.GetUserByEmail(user.Email);
			if (existingUserUsername != null)
			{
				throw new DuplicateEntityException(user.Username);
			}
			if (existingUserEmail != null)
			{
				throw new DuplicateEntityException(user.Email);
			}

            // Generate salt
            string salt = AuthManager.GenerateSalt();
            // Concatenate salt with password and generate hashed password
            string hashedPassword = AuthManager.HashPassword(user.Password, salt);
            // Assign salt and hashed password to user object
            user.Salt = salt;
            user.Password = hashedPassword;
			//Verification token used for mail
			user.VerificationToken = CreateRandomToken();

            return this.userRepository.AddUser(user);
		}

		public User UpdateUser(User user)
		{
			// Todo more business logic in future
			var existingUser = this.userRepository.GetUserById(user.Id);
			if (existingUser == null)
			{
                throw new UserNotFoundException(string.Format(Alerts.UserNotFound, "Id", $"{user.Id}"));
            }

			return this.userRepository.UpdateUser(user);
		}

		public void DeleteUser(int id)
		{
			this.userRepository.DeleteUser(id);
		}

        public User Login(string username, string password)
        {
            var user = userRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new EntityNotFoundException(Alerts.InvalidCredentials);
            }
			//HACK check for Verification
            if (user.VerifiedAt == null)
            {
                throw new EntityNotFoundException(Alerts.UserNotVerified);
            }
            string salt = user.Salt;
            string hashedPassword = AuthManager.HashPassword(password, salt);

            if (user.Password != hashedPassword)
            {
                throw new UnauthorizedAccessException(Alerts.InvalidCredentials);
            }

            return user;
        }

		public User Verify(string token)
		{
            var user = this.GetAllUsers().FirstOrDefault(u => u.VerificationToken == token);
			if(user == null)
			{
                throw new EntityNotFoundException(Alerts.UserNotVerified);
            }

            user.VerifiedAt = DateTime.Now;
            return this.userRepository.VerifyUser(user);
            
        }


        #region PrivateMethods
        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
        #endregion


    }
}