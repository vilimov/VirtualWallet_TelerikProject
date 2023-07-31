using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Application.Services;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Tests.TestHelpers;

namespace VirtualWallet.Tests.Services.UserServices
{
	[TestClass]
	public class GetUserShould
	{
		[TestMethod]
		public void GetAllUsers_ReturnsAllUsers()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			List<User> testUsers = UsersHelper.GetTestUsersList();
			userRepoMock.Setup(repo => repo.GetAllUsers()).Returns(testUsers);
			var userService = new UserService(userRepoMock.Object);

			// Act
			var result = userService.GetAllUsers();

			// Assert
			CollectionAssert.AreEqual(testUsers, result.ToList());
		}
		[TestMethod]
		public void GetUserById_ReturnsCorrectUser()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			User testUser = UsersHelper.GetTestUser();
			userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns(testUser);
			var userService = new UserService(userRepoMock.Object);

			// Act
			var result = userService.GetUserById(testUser.Id);

			// Assert
			Assert.AreEqual(testUser, result);
		}
		[TestMethod]
		public void GetUserByUsername_ReturnsCorrectUser()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			User testUser = UsersHelper.GetTestUser();
			userRepoMock.Setup(repo => repo.GetUserByUsername(testUser.Username)).Returns(testUser);
			var userService = new UserService(userRepoMock.Object);

			// Act
			var result = userService.GetUserByUsername(testUser.Username);

			// Assert
			Assert.AreEqual(testUser, result);
		}

		[TestMethod]
		public void GetUserByEmail_ReturnsCorrectUser()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			User testUser = UsersHelper.GetTestUser();
			userRepoMock.Setup(repo => repo.GetUserByEmail(testUser.Email)).Returns(testUser);
			var userService = new UserService(userRepoMock.Object);

			// Act
			var result = userService.GetUserByEmail(testUser.Email);

			// Assert
			Assert.AreEqual(testUser, result);
		}

		[TestMethod]
		public void GetUserByPhoneNumber_ReturnsCorrectUser()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			User testUser = UsersHelper.GetTestUser();
			userRepoMock.Setup(repo => repo.GetUserByPhoneNumber(testUser.PhoneNumber)).Returns(testUser);
			var userService = new UserService(userRepoMock.Object);

			// Act
			var result = userService.GetUserByPhoneNumber(testUser.PhoneNumber);

			// Assert
			Assert.AreEqual(testUser, result);
		}
	}
}
