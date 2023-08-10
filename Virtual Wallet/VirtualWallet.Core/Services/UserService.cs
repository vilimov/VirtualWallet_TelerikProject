using System.Security.Cryptography;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.AdditionalHelpers;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Common.Exceptions;
using VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository userRepository;
        private readonly IEmailService emailService;
        public UserService(IUserRepository userRepository, IEmailService emailService) 
		{			
			this.userRepository = userRepository;
			this.emailService = emailService;
		}

		public IEnumerable<User> GetAllUsers()
		{
			return this.userRepository.GetAllUsers();
		}
        #region GetBy
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
		public User GetUserByPhoneNumber(string phoneNumber)
		{
			return userRepository.GetUserByPhoneNumber(phoneNumber);
		}
        #endregion
        #region Register
        public User Register(User user)
		{
			var existingUserUsername = this.userRepository.GetUserByUsername(user.Username);
			var existingUserEmail = this.userRepository.GetUserByEmail(user.Email);
            if (existingUserUsername != null)
            {
                throw new DuplicateEntityException($"Username '{user.Username}' already exists.");
            }
            if (existingUserEmail != null)
            {
                throw new DuplicateEntityException($"Email '{user.Email}' already exists.");
            }

            string salt = AuthManager.GenerateSalt();
            string hashedPassword = AuthManager.HashPassword(user.Password, salt);

            user.Salt = salt;
            user.Password = hashedPassword;
			user.VerificationToken = CreateRandomToken();
			string verificationLink = emailService.GenerateVerificationLink(user.VerificationToken);

            var mailRequest = new Mail
			{
				Body = $"Hello {user.Username}! Please verify your registration by clicking the link: {verificationLink}",
				To = user.Email,
				Subject = "MaxKashMate verification mail"
            };

            emailService.SendEmail(mailRequest);
			
			return this.userRepository.AddUser(user);
		}
        #endregion
        #region UpdateUser
        public User UpdateUser(User userUpdate)
        {
            var existingUser = userRepository.GetUserById(userUpdate.Id);

            if (existingUser == null)
            {
                throw new EntityNotFoundException($"User with id {userUpdate.Id} does not exist.");
            }

            if (!string.IsNullOrEmpty(userUpdate.Email) && userUpdate.Email != existingUser.Email)
            {
                var existingUserWithEmail = userRepository.GetUserByEmail(userUpdate.Email);

                if (existingUserWithEmail != null)
                {
                    throw new DuplicateEntityException($"Email {userUpdate.Email} already in use.");
                }
                else
                {
                    existingUser.Email = userUpdate.Email;
                }
            }

            if (!string.IsNullOrEmpty(userUpdate.Password) && userUpdate.Password.Length >= 8 && userUpdate.Password.Length <= 20)
            {
                string newSalt = AuthManager.GenerateSalt();
                string newHashedPassword = AuthManager.HashPassword(userUpdate.Password, newSalt);
                existingUser.Salt = newSalt;
                existingUser.Password = newHashedPassword;
            }

            if (!string.IsNullOrEmpty(userUpdate.FirstName))
            {
                existingUser.FirstName = userUpdate.FirstName;
            }

            if (!string.IsNullOrEmpty(userUpdate.LastName))
            {
                existingUser.LastName = userUpdate.LastName;
            }

            if (!string.IsNullOrEmpty(userUpdate.PhoneNumber))
            {
                existingUser.PhoneNumber = userUpdate.PhoneNumber;
            }

            return userRepository.UpdateUser(existingUser);
        }
        #endregion
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
            if (user == null || user.IsDeleted)
            {
                throw new EntityNotFoundException(Alerts.InvalidCredentials);
            }
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

            if (user.VerifiedAt != null)
            {
                throw new DuplicateEntityException(Alerts.UserAlreadyVerified);
            }
            user.VerifiedAt = DateTime.Now;

            return this.userRepository.VerifyUser(user);
            
        }
        public IEnumerable<User> GetAllUsers(int pageNumber, int pageSize, string search = null)
        {
            var users = userRepository.GetAllUsers().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                users = users.Where(u => u.Username.Contains(search)
                                      || u.Email.Contains(search)
                                      || u.PhoneNumber.Contains(search));
            }

            return users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public int GetUserCount(string search = null)
        {
            var users = userRepository.GetAllUsers().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                users = users.Where(u => u.Username.Contains(search)
                                      || u.Email.Contains(search)
                                      || u.PhoneNumber.Contains(search));
            }

            return users.Count();
        }
        #region Search
        public IEnumerable<User> SearchByUsername(string username)
		{
			return userRepository.SearchByUsername(username);
		}

		public IEnumerable<User> SearchByEmail(string email)
		{
			return userRepository.SearchByEmail(email);
		}

		public IEnumerable<User> SearchByPhone(string phone)
		{
			return userRepository.SearchByPhone(phone);
		}
        #endregion
        #region PrivateMethods
        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        #endregion


    }
}
