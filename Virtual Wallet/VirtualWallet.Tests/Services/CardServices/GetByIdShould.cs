namespace VirtualWallet.Tests.Services.CardServices
{
    [TestClass]
    public class GetByIdShould
    {
        [TestMethod]
        public void GetCard_When_ParametersAreValid()
        {
            // Arrange

            Card expectedCard = TestHelpers.CardHelper.GetTestCard();

            var repositoryMock = new Mock<ICardRepository>();

            repositoryMock.Setup(r => r.GetById(1)).Returns(expectedCard);

            var sut = new CardService(repositoryMock.Object);

            // Act

            Card actualCard = sut.GetById(expectedCard.Id);

            // Assert

            Assert.AreEqual(expectedCard, actualCard);
        }

        [TestMethod]
        public void ThrowException_When_CardNotFound()
        {
            // Arrange

            var repositoryMock = new Mock<ICardRepository>();

            repositoryMock.Setup(r => r.GetById(It.IsAny<int>())).Throws(new EntityNotFoundException(""));

            var sut = new CardService(repositoryMock.Object);

            // Act & Assert

            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetById(1));
        }
    }
}
