namespace VirtualWallet.Tests.Services.CardServices
{
    [TestClass]
    public class GetCardsShould
    {
        [TestMethod]
        public void ReturnAllCards_When_ParametersAreValid()
        {

            // Arrange
            List<Card> testCards = TestHelpers.CardHelper.GetTestCards();

            var repositoryMock = new Mock<ICardRepository>();

            repositoryMock.Setup(r => r.GetAll()).Returns(testCards.AsQueryable);

            var sut = new CardService(repositoryMock.Object);

            // Act
            List<Card> allCards = sut.GetAll().ToList();

            // Assert
            Assert.AreEqual(testCards.Count, allCards.Count);
            for (int i = 0; i < testCards.Count; i++)
            {
                Assert.AreEqual(testCards[i].Id, allCards[i].Id);
                Assert.AreEqual(testCards[i].Number, allCards[i].Number);
                Assert.AreEqual(testCards[i].CardHolder, allCards[i].CardHolder);
                Assert.AreEqual(testCards[i].User, allCards[i].User);
                Assert.AreEqual(testCards[i].ExpirationDate, allCards[i].ExpirationDate);
                Assert.AreEqual(testCards[i].IsCreditCard, allCards[i].IsCreditCard);
            }
        }

        [TestMethod]
        public void ThrowException_When_CardsNotFound()
        {
            // Arrange

            var repositoryMock = new Mock<ICardRepository>();

            repositoryMock.Setup(r => r.GetAll()).Throws(new EntityNotFoundException(""));

            var sut = new CardService(repositoryMock.Object);

            // Act & Assert

            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetAll());
        }
    }
}
