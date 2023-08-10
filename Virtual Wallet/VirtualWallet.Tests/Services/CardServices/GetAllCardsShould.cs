using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.CardServices
{
	[TestClass]
	public class GetAllCardsShould
	{
		[TestMethod]
		public void GetAll_NoSearch_ReturnsCorrectPage()
		{
			// Arrange
			var mockRepository = new Mock<ICardRepository>();
			mockRepository.Setup(repo => repo.GetAll()).Returns(new List<Card>
		{
			new Card { Id = 1, User = new User { Username = "user1" } },
			new Card { Id = 2, User = new User { Username = "user2" } },
			new Card { Id = 3, User = new User { Username = "user3" } },
			new Card { Id = 4, User = new User { Username = "user4" } },
			new Card { Id = 5, User = new User { Username = "user5" } }
		}.AsQueryable());

			var cardService = new CardService(mockRepository.Object);

			int pageNumber = 2;
			int pageSize = 2;

			// Act
			IEnumerable<Card> result = cardService.GetAll(pageNumber, pageSize);

			// Assert
			Assert.AreEqual(2, result.Count());
			CollectionAssert.AreEqual(new[] { 3, 4 }, result.Select(c => c.Id).ToList());
		}

		[TestMethod]
		public void GetAll_WithSearch_ReturnsCorrectPage()
		{
			// Arrange
			var mockRepository = new Mock<ICardRepository>();
			mockRepository.Setup(repo => repo.GetAll()).Returns(new List<Card>
		{
			new Card { Id = 1, User = new User { Username = "user1" } },
			new Card { Id = 2, User = new User { Username = "user2" } },
			new Card { Id = 3, User = new User { Username = "user3" } },
			new Card { Id = 4, User = new User { Username = "user4" } },
			new Card { Id = 5, User = new User { Username = "user5" } }
		}.AsQueryable());

			var cardService = new CardService(mockRepository.Object);

			int pageNumber = 1;
			int pageSize = 3;

			// Act
			IEnumerable<Card> result = cardService.GetAll(pageNumber, pageSize, "user3");

			// Assert
			Assert.AreEqual(1, result.Count());
			CollectionAssert.AreEqual(new[] { 3 }, result.Select(c => c.Id).ToList());
		}
	}
}
