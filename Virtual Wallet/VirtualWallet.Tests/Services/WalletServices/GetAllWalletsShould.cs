using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.WalletServices
{
	[TestClass]
	public class GetAllWalletsShould
	{
		[TestMethod]
		public void GetAll_NoSearch_ReturnsCorrectPage()
		{
			// Arrange
			var mockRepository = new Mock<IWalletRepository>();
			mockRepository.Setup(repo => repo.GetAll()).Returns(new List<Wallet>
		{
			new Wallet { Id = 1, User = new User { Username = "user1" } },
			new Wallet { Id = 2, User = new User { Username = "user2" } },
			new Wallet { Id = 3, User = new User { Username = "user3" } },
			new Wallet { Id = 4, User = new User { Username = "user4" } },
			new Wallet { Id = 5, User = new User { Username = "user5" } }
		}.AsQueryable());

			var walletService = new WalletService(mockRepository.Object);

			int pageNumber = 2;
			int pageSize = 2;

			// Act
			IEnumerable<Wallet> result = walletService.GetAll(pageNumber, pageSize);

			// Assert
			Assert.AreEqual(2, result.Count());
			CollectionAssert.AreEqual(new[] { 3, 4 }, result.Select(w => w.Id).ToList());
		}

		[TestMethod]
		public void GetAll_WithSearch_ReturnsCorrectPage()
		{
			// Arrange
			var mockRepository = new Mock<IWalletRepository>();
			mockRepository.Setup(repo => repo.GetAll()).Returns(new List<Wallet>
		{
			new Wallet { Id = 1, User = new User { Username = "user1" } },
			new Wallet { Id = 2, User = new User { Username = "user2" } },
			new Wallet { Id = 3, User = new User { Username = "user3" } },
			new Wallet { Id = 4, User = new User { Username = "user4" } },
			new Wallet { Id = 5, User = new User { Username = "user5" } }
		}.AsQueryable());

			var walletService = new WalletService(mockRepository.Object);

			int pageNumber = 1;
			int pageSize = 3;

			// Act
			IEnumerable<Wallet> result = walletService.GetAll(pageNumber, pageSize, "user3");

			// Assert
			Assert.AreEqual(1, result.Count());
			CollectionAssert.AreEqual(new[] { 3 }, result.Select(w => w.Id).ToList());
		}
	}
}
