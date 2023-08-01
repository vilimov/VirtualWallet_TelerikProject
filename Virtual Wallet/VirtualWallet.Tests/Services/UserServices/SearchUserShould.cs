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
	public class SearchUserShould
	{
		[TestMethod]
		public void SearchByUsername_UsernameExists_ReturnsUsers()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();
			List<User> testUsers = UsersHelper.GetTestUsersList();

			userRepoMock.Setup(repo => repo.SearchByUsername("ElonMusk")).Returns(testUsers.Where(u => u.Username == "ElonMusk"));

			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			// Act
			var result = sut.SearchByUsername("ElonMusk");

			// Assert
			Assert.IsTrue(result.Any());
			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("ElonMusk", result.First().Username);
		}

		[TestMethod]
		public void SearchByEmail_EmailExists_ReturnsUsers()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();
			List<User> testUsers = UsersHelper.GetTestUsersList();

			userRepoMock.Setup(repo => repo.SearchByEmail("elon@musk.com")).Returns(testUsers.Where(u => u.Email == "elon@musk.com"));

			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			// Act
			var result = sut.SearchByEmail("elon@musk.com");

			// Assert
			Assert.IsTrue(result.Any());
			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("elon@musk.com", result.First().Email);
		}

		[TestMethod]
		public void SearchByPhone_PhoneExists_ReturnsUsers()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();
			List<User> testUsers = UsersHelper.GetTestUsersList();

			userRepoMock.Setup(repo => repo.SearchByPhone("1234567890")).Returns(testUsers.Where(u => u.PhoneNumber == "1234567890"));

			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			// Act
			var result = sut.SearchByPhone("1234567890");

			// Assert
			Assert.IsTrue(result.Any());
			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("1234567890", result.First().PhoneNumber);
		}
	}
}
