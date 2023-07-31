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
using VirtualWallet.Tests.TestHelpers;

namespace VirtualWallet.Tests.Services.UserServices
{
	[TestClass]
	public class RegisterUserShould
	{
		[TestMethod]
		public void Register_UserWithExistingUsername_ThrowsException()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			User testUser = UsersHelper.GetTestUser();

			userRepoMock.Setup(repo => repo.GetUserByUsername(testUser.Username)).Returns(testUser);
			var userService = new UserService(userRepoMock.Object);

			// Act & Assert
			Assert.ThrowsException<DuplicateEntityException>(() => userService.Register(testUser));
		}
		[TestMethod]
		public void Register_UserWithExistingEmail_ThrowsException()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			User testUser = UsersHelper.GetTestUser();

			userRepoMock.Setup(repo => repo.GetUserByEmail(testUser.Email)).Returns(testUser);
			var userService = new UserService(userRepoMock.Object);

			// Act & Assert
			Assert.ThrowsException<DuplicateEntityException>(() => userService.Register(testUser));
		}

		[TestMethod]
		public void Register_ValidUser_ReturnsRegisteredUser()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			User testUser = UsersHelper.GetTestUser();

			userRepoMock.Setup(repo => repo.GetUserByUsername(testUser.Username)).Returns((User)null);
			userRepoMock.Setup(repo => repo.GetUserByEmail(testUser.Email)).Returns((User)null);
			userRepoMock.Setup(repo => repo.AddUser(It.IsAny<User>())).Returns(testUser);

			var userService = new UserService(userRepoMock.Object);

			// Act
			var registeredUser = userService.Register(testUser);

			// Assert
			Assert.IsNotNull(registeredUser);
			Assert.AreEqual(testUser.Username, registeredUser.Username);
			Assert.AreEqual(testUser.Email, registeredUser.Email);
		}
	}
}
