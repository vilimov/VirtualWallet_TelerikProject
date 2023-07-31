using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Application.Services;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.Services.Contracts;

namespace VirtualWallet.Tests.Services.UserServices
{
	[TestClass]
	public class DeleteUserShould
	{
		[TestMethod]
		public void DeleteUser_ValidId_CallsDeleteUserOnRepo()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
			var emailServiceMock = new Mock<IEmailService>();

			var sut = new UserService(userRepoMock.Object, emailServiceMock.Object);

			int testUserId = 1;

			// Act
			sut.DeleteUser(testUserId);

			// Assert
			userRepoMock.Verify(repo => repo.DeleteUser(testUserId), Times.Once);
		}
	}
}
