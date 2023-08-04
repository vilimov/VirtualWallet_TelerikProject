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
using VirtualWallet.Application.Services;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Tests.TestHelpers;

namespace VirtualWallet.Tests.Services.UserServices
{
	[TestClass]
	public class BlockUserShould
	{
		[TestMethod]
		public void BlockUser_ValidId_BlocksUser()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();

			User testUser = UsersHelper.GetTestUser();

			userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns(testUser);
			userRepoMock.Setup(repo => repo.UpdateUser(It.IsAny<User>()));

			var sut = new AdminService(userRepoMock.Object);

			// Act
			sut.BlockUser(testUser.Id);

			// Assert
			userRepoMock.Verify(repo => repo.UpdateUser(It.Is<User>(u => u.IsBlocked)));
		}
		[TestMethod]
		public void BlockUser_InvalidId_ThrowsEntityNotFoundException()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();

            userRepoMock.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns((User)null);

			var sut = new AdminService(userRepoMock.Object);

			// Assert
			Assert.ThrowsException<EntityNotFoundException>(() => sut.BlockUser(0));
		}
	}
}
