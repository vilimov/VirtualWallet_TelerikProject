using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.CardServices
{
    [TestClass]
    public class GetByNumberShould
    {
        [TestMethod]
        public void GetCard_When_ParametersAreValid()
        {
            // Arrange

            Card expectedCard = TestHelpers.CardHelper.GetTestCard();

            var repositoryMock = new Mock<ICardRepository>();

            repositoryMock.Setup(r => r.GetByNumber("9876543210123456")).Returns(expectedCard);

            var sut = new CardService(repositoryMock.Object);

            // Act

            Card actualCard = sut.GetByNumber(expectedCard.Number);

            // Assert

            Assert.AreEqual(expectedCard, actualCard);
        }

        [TestMethod]
        public void ThrowException_When_CardNotFound()
        {
            // Arrange

            var repositoryMock = new Mock<ICardRepository>();

            repositoryMock.Setup(r => r.GetByNumber(It.IsAny<string>())).Throws(new EntityNotFoundException(""));

            var sut = new CardService(repositoryMock.Object);

            // Act & Assert

            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetByNumber("1234567890123456"));
        }
    }
}
