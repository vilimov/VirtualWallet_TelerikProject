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
	public class RegisterUserShould
	{
		[TestMethod]
		public void Register_UserWithExistingUsername_ThrowsDuplicateEntityException()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();
			User testUser = UsersHelper.GetTestUser();

			userRepoMock.Setup(repo => repo.GetUserByUsername(testUser.Username)).Returns(testUser);

			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			// Act & Assert
			Assert.ThrowsException<DuplicateEntityException>(() => sut.Register(testUser));
		}
		[TestMethod]
		public void Register_UserWithExistingEmail_ThrowsDuplicateEntityException()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();
			User testUser = UsersHelper.GetTestUser();

			userRepoMock.Setup(repo => repo.GetUserByEmail(testUser.Email)).Returns(testUser);

			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			// Act & Assert
			Assert.ThrowsException<DuplicateEntityException>(() => sut.Register(testUser));
		}

		[TestMethod]
		public void Register_ValidUser_CallsAddUser()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();
			User testUser = UsersHelper.GetTestUser();

			userRepoMock.Setup(repo => repo.GetUserByUsername(testUser.Username)).Returns((User)null);
			userRepoMock.Setup(repo => repo.GetUserByEmail(testUser.Email)).Returns((User)null);
			userRepoMock.Setup(repo => repo.AddUser(It.IsAny<User>())).Returns(testUser);

			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			// Act
			var result = sut.Register(testUser);

			// Assert
			userRepoMock.Verify(repo => repo.AddUser(It.Is<User>(u => u.Username == testUser.Username)), Times.Once);
		}
	}
}
