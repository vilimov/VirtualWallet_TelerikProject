using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Common.QueryParameters;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.QueryParameters;

namespace VirtualWallet.Tests.Services.CardServices
{
    [TestClass]
    public class GetFilteredCardsShould
    {
        [TestMethod]
        public void ReturnFilteredCards_When_ParametersAreValid()
        {
            // Arrange
            List<Card> expectedCards = TestHelpers.CardHelper.GetTestCards();
            var repositoryMock = new Mock<ICardRepository>();
            CardQueryParameters filter = new CardQueryParameters() { ExpiresBefore = "true" };


            repositoryMock.Setup(r => r.GetFilteredCards(filter))
                          .Returns(expectedCards);

            var sut = new CardService(repositoryMock.Object);

            // Act
            IEnumerable<Card> actualCards = sut.GetFilteredCards(filter);

            // Assert
            Assert.AreEqual(expectedCards, actualCards);
        }
    }
}
