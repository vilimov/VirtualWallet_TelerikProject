using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.CardServices
{
    [TestClass]
    public class GetByUserShould
    {
        [TestMethod]
        public void GetCard_When_ParametersAreValid()
        {
            // Arrange
            User expectedUser = TestHelpers.UsersHelper.GetTestUser();
            List<Card> expectedCards = TestHelpers.CardHelper.GetTestCards().Where(c => c.UserId == expectedUser.Id).ToList();


            var repositoryMock = new Mock<ICardRepository>();

            repositoryMock.Setup(r => r.GetByUser(expectedUser)).Returns(expectedCards.AsQueryable);

            var sut = new CardService(repositoryMock.Object);

            // Act
            List<Card> allCards = sut.GetByUser(expectedUser).ToList();

            // Assert
            Assert.AreEqual(expectedCards.Count, allCards.Count);
            for (int i = 0; i < expectedCards.Count; i++)
            {
                Assert.AreEqual(expectedCards[i].Id, allCards[i].Id);
                Assert.AreEqual(expectedCards[i].Number, allCards[i].Number);
                Assert.AreEqual(expectedCards[i].CardHolder, allCards[i].CardHolder);
                Assert.AreEqual(expectedCards[i].User, allCards[i].User);
                Assert.AreEqual(expectedCards[i].ExpirationDate, allCards[i].ExpirationDate);
                Assert.AreEqual(expectedCards[i].IsCreditCard, allCards[i].IsCreditCard);
            }
        }

        [TestMethod]
        public void ThrowException_When_CardsNotFound()
        {
            // Arrange
            User expectedUser = TestHelpers.UsersHelper.GetTestUser();

            var repositoryMock = new Mock<ICardRepository>();

            repositoryMock.Setup(r => r.GetByUser(expectedUser)).Throws(new EntityNotFoundException(""));

            var sut = new CardService(repositoryMock.Object);

            // Act & Assert

            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetByUser(expectedUser));
        }
    }
}
