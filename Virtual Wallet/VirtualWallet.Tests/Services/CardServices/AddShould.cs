namespace VirtualWallet.Tests.Services.CardServices
{
    [TestClass]
    public class AddShould
    {
        [TestMethod]
        public void AddCard_When_ParametesAreValid()
        {
            // Arrange
            Card testCard = TestHelpers.CardHelper.GetTestCard();
            User testUser = TestHelpers.UsersHelper.GetTestUser();

            var repositoryMock = new Mock<ICardRepository>();

            repositoryMock.Setup(r => r.Add(testCard, testUser)).Returns(testCard);

            var sut = new CardService(repositoryMock.Object);

            // Act
            Card actualCard = sut.Add(testCard, testUser);

            // Assert
            Assert.AreEqual(testCard, actualCard);            
        }
    }
}
