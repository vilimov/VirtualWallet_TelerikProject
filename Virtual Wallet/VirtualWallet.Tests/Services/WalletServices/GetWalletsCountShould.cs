using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Persistence.Repository;

namespace VirtualWallet.Tests.Services.WalletServices
{
	[TestClass]
	public class GetWalletsCountShould
	{
		[TestMethod]
		public void GetWalletsCount_NoSearch_ReturnsCorrectCount()
		{
			// Arrange
			var mockRepository = new Mock<IWalletRepository>();
			mockRepository.Setup(repo => repo.GetAll()).Returns(new List<Wallet>
		{
			new Wallet { Id = 1, User = new User { Username = "user1" } },
			new Wallet { Id = 2, User = new User { Username = "user2" } },
			new Wallet { Id = 3, User = new User { Username = "user3" } }
		}.AsQueryable());

			var walletService = new WalletService(mockRepository.Object);

			// Act
			int count = walletService.GetWalletsCount();

			// Assert
			Assert.AreEqual(3, count);
		}

		[TestMethod]
		public void GetWalletsCount_WithSearch_ReturnsCorrectCount()
		{
			// Arrange
			var mockRepository = new Mock<IWalletRepository>();
			mockRepository.Setup(repo => repo.GetAll()).Returns(new List<Wallet>
		{
			new Wallet { Id = 1, User = new User { Username = "user1" } },
			new Wallet { Id = 2, User = new User { Username = "user2" } },
			new Wallet { Id = 3, User = new User { Username = "user3" } }
		}.AsQueryable());

			var walletService = new WalletService(mockRepository.Object);

			// Act
			int count = walletService.GetWalletsCount("user2");

			// Assert
			Assert.AreEqual(1, count);
		}
	}
}
