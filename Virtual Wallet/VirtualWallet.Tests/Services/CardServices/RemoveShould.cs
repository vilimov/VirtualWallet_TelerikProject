using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.CardServices
{
    [TestClass]
    public class RemoveShould
    {
        [TestMethod]
        public void RemoveCard_When_ParametersAreValid()
        {
            // Arrange
            Card testCard = TestHelpers.CardHelper.GetTestCard();

            var repositoryMock = new Mock<ICardRepository>();

            var sut = new CardService(repositoryMock.Object);

            // Act
            sut.Remove(testCard.Id);

            // Assert
            repositoryMock.Verify(r => r.Remove(testCard.Id), Times.Once);
        }
    }
}
