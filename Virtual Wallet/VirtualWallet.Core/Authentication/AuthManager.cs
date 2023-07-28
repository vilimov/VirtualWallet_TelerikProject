using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Common.Exceptions;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace VirtualWallet.Application.AdditionalHelpers
{
    public class AuthManager
    {
        private readonly IUserService usersService;

        public AuthManager(IUserService usersService)
        {
            this.usersService = usersService;
        }

        public User TryGetUser(string credentials)
        {
            if (string.IsNullOrEmpty(credentials) || !credentials.Contains(':'))
            {
                throw new InvalidCredentialsException(Alerts.InvalidCredentials);
            }

            string[] credentialsArray = credentials.Split(':');
            string username = credentialsArray[0];
            string enteredPassword = credentialsArray[1];

            try
            {
                var user = this.usersService.GetUserByUsername(username);
                if (user == null)
                {
                    throw new EntityNotFoundException(Alerts.InvalidCredentials);
                }

                string hashedPassword = HashPassword(enteredPassword, user.Salt);

                if (user.Password == hashedPassword)
                {
                    return user;
                }
                throw new UnauthenticatedOperationException(Alerts.InvalidCredentials);
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException(Alerts.InvalidCredentials);
            }
            catch (UnauthenticatedOperationException)
            {
                throw new UnauthorizedOperationException(Alerts.InvalidCredentials);
            }
        }

        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16]; // 16 bytes = 128 bits
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000))
            {
                byte[] hashBytes = rfc2898DeriveBytes.GetBytes(32); // 32 bytes = 256 bits (recommended for bcrypt)
                return Convert.ToBase64String(hashBytes);
            }
        }
		// TEST
		public string GenerateJwtForUser(User user)
		{
			// Include Jwt package


			// Get the symmetric security key from your configuration (make sure to have it somewhere in your app settings)
			var key = Encoding.UTF8.GetBytes("Jwt:SecretKey");
			var symmetricSecurityKey = new SymmetricSecurityKey(key);
			var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

			// Prepare the claims for the token
			var claims = new[]
			{
		new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
		new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
		new Claim(ClaimTypes.Name, user.Username),
		new Claim(ClaimTypes.Role, user.Role) // include user's role in the token
    };

			// Create the token
			var token = new JwtSecurityToken(
				issuer: "Jwt:Issuer",
				audience: "Jwt:Audience",
				claims: claims,
				expires: DateTime.UtcNow.AddHours(1),
				signingCredentials: credentials);

			// Return the token
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
