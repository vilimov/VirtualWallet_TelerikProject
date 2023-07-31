using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Application.Services;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.AdditionalHelpers;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Tests.TestHelpers;

namespace VirtualWallet.Tests.Services.UserServices
{
	[TestClass]
	public class LoginUserShould
	{
		[TestMethod]
		public void Login_UserDoesNotExist_ThrowsEntityNotFoundException()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();
			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			string testUsername = "NonExistentUser";
			string testPassword = "password123";

			// Act & Assert
			Assert.ThrowsException<EntityNotFoundException>(() => sut.Login(testUsername, testPassword));
		}
		[TestMethod]
		public void Login_UnverifiedUser_ThrowsEntityNotFoundException()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();
			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			var testUser = UsersHelper.GetTestUser();
			testUser.VerifiedAt = null;

			userRepoMock.Setup(repo => repo.GetUserByUsername(testUser.Username)).Returns(testUser);

			// Act & Assert
			Assert.ThrowsException<EntityNotFoundException>(() => sut.Login(testUser.Username, testUser.Password));
		}
		[TestMethod]
		public void Login_IncorrectPassword_ThrowsUnauthorizedAccessException()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();
			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			var testUser = UsersHelper.GetTestUser();

			userRepoMock.Setup(repo => repo.GetUserByUsername(testUser.Username)).Returns(testUser);

			string incorrectPassword = "IncorrectPassword";

			// Act & Assert
			Assert.ThrowsException<UnauthorizedAccessException>(() => sut.Login(testUser.Username, incorrectPassword));
		}
		[TestMethod]
		public void Login_InvalidPassword_ThrowsUnauthorizedAccessException()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();

			User testUser = UsersHelper.GetTestUser();
			testUser.VerifiedAt = DateTime.UtcNow;

			userRepoMock.Setup(repo => repo.GetUserByUsername(testUser.Username)).Returns(testUser);

			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			// Assert
			Assert.ThrowsException<UnauthorizedAccessException>(() => sut.Login(testUser.Username, "invalidPassword"));
		}
	}
}
