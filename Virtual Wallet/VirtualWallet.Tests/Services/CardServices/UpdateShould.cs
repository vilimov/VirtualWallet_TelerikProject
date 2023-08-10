using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.CardServices
{
	[TestClass]
	public class UpdateShould
	{
		[TestMethod]
		public void UpdateCard_When_ParametesAreValid()
		{
			// Arrange
			Card testCard = TestHelpers.CardHelper.GetTestCard();
			User testUser = TestHelpers.UsersHelper.GetTestUser();
			int id = testCard.Id;

			var repositoryMock = new Mock<ICardRepository>();

			repositoryMock.Setup(r => r.Update(testCard, testUser, id)).Returns(testCard);

			var sut = new CardService(repositoryMock.Object);

			// Act
			Card actualCard = sut.Update(testCard, testUser, id);

			// Assert
			Assert.AreEqual(testCard, actualCard);
		}
	}
}
