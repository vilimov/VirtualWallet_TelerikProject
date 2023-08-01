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
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Tests.TestHelpers;

namespace VirtualWallet.Tests.Services.UserServices
{
	[TestClass]
	public class UpdateUserShould
	{
		[TestMethod]
		public void UpdateUser_ValidUser_UpdatesEmailAndPassword()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();

			User testUser = UsersHelper.GetTestUser();
			User updateUser = new User
			{
				Id = testUser.Id,
				Email = "newemail@test.com",
				Password = "NewPassword123!"
			};

			userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns(testUser);
			userRepoMock.Setup(repo => repo.UpdateUser(It.IsAny<User>()));

			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			// Act
			sut.UpdateUser(updateUser);

			// Assert
			userRepoMock.Verify(repo => repo.UpdateUser(It.Is<User>(u =>
	                     u.Email == updateUser.Email && u.Password != It.IsAny<string>())));
		}

		[TestMethod]
		public void UpdateUser_InvalidUser_ThrowsEntityNotFoundException()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();

			User updateUser = new User
			{
				Id = 0,
				Email = "newemail@test.com",
				Password = "NewPassword123!"
			};

			userRepoMock.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns((User)null);

			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			// Assert
			Assert.ThrowsException<EntityNotFoundException>(() => sut.UpdateUser(updateUser));
		}

		[TestMethod]
		public void UpdateUser_InvalidPassword_DoesNotUpdatePassword()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();

			User testUser = UsersHelper.GetTestUser();
			User updateUser = new User
			{
				Id = testUser.Id,
				Email = "newemail@test.com",
				Password = "qwerty"
			};

			userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns(testUser);
			userRepoMock.Setup(repo => repo.UpdateUser(It.IsAny<User>()));

			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			// Act
			sut.UpdateUser(updateUser);

			// Assert
			userRepoMock.Verify(repo => repo.UpdateUser(It.Is<User>(u =>
		                 u.Email == updateUser.Email && u.Password == testUser.Password && u.Salt == testUser.Salt)));
		}
	}
}
