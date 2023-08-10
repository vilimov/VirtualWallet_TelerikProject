using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.CardServices
{
	[TestClass]
	public class GetCardsCountShould
	{
		[TestMethod]
		public void GetCardsCount_NoSearch_ReturnsCorrectCount()
		{
			// Arrange
			var mockRepository = new Mock<ICardRepository>();
			mockRepository.Setup(repo => repo.GetAll()).Returns(new List<Card>
		{
			new Card { Id = 1, User = new User { Username = "user1" } },
			new Card { Id = 2, User = new User { Username = "user2" } },
			new Card { Id = 3, User = new User { Username = "user3" } }
		}.AsQueryable());

			var cardService = new CardService(mockRepository.Object);

			// Act
			int count = cardService.GetCardsCount();

			// Assert
			Assert.AreEqual(3, count);
		}

		[TestMethod]
		public void GetCardsCount_WithSearch_ReturnsCorrectCount()
		{
			// Arrange
			var mockRepository = new Mock<ICardRepository>();
			mockRepository.Setup(repo => repo.GetAll()).Returns(new List<Card>
		{
			new Card { Id = 1, User = new User { Username = "user1" } },
			new Card { Id = 2, User = new User { Username = "user2" } },
			new Card { Id = 3, User = new User { Username = "user3" } }
		}.AsQueryable());

			var cardService = new CardService(mockRepository.Object);

			// Act
			int count = cardService.GetCardsCount("user2");

			// Assert
			Assert.AreEqual(1, count);
		}
	}
}
