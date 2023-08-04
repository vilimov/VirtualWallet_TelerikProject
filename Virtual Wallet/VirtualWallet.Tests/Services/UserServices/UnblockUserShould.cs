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
	public class UnblockUserShould
	{
		[TestMethod]
		public void UnblockUser_ValidId_UnblocksUser()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
            var adminServiceMock = new Mock<IAdminService>();

            User testUser = UsersHelper.GetTestUser();

			userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns(testUser);
			userRepoMock.Setup(repo => repo.UpdateUser(It.IsAny<User>()));

			var sut = new AdminService(userRepoMock.Object, adminServiceMock.Object);

			// Act
			sut.UnblockUser(testUser.Id);

			// Assert
			userRepoMock.Verify(repo => repo.UpdateUser(It.Is<User>(u => !u.IsBlocked)));
		}

		[TestMethod]
		public void UnblockUser_InvalidId_ThrowsEntityNotFoundException()
		{
			// Arrange
			var userRepoMock = new Mock<IUserRepository>();
            var adminServiceMock = new Mock<IAdminService>();

            userRepoMock.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns((User)null);

			var sut = new AdminService(userRepoMock.Object, adminServiceMock.Object);

			// Assert
			Assert.ThrowsException<EntityNotFoundException>(() => sut.UnblockUser(0));
		}
	}
}
