using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.WalletServices
{
    [TestClass]
    public class GetWalletsShould
    {
        [TestMethod]
        public void ReturnAllWallets_When_ParametersAreValid()
        {

            // Arrange
            List<Wallet> testWallet = TestHelpers.WalletHelper.GetTestWallets();

            var repositoryMock = new Mock<IWalletRepository>();

            repositoryMock.Setup(r => r.GetAll()).Returns(testWallet.AsQueryable);

            var sut = new WalletService(repositoryMock.Object);

            // Act
            List<Wallet> allWallets = sut.GetAll().ToList();

            // Assert
            Assert.AreEqual(testWallet.Count, allWallets.Count);
            for (int i = 0; i < testWallet.Count; i++)
            {
                Assert.AreEqual(testWallet[i].Id, allWallets[i].Id);
                Assert.AreEqual(testWallet[i].Balance, allWallets[i].Balance);
                Assert.AreEqual(testWallet[i].Blocked, allWallets[i].Blocked);
                Assert.AreEqual(testWallet[i].User, allWallets[i].User);
                Assert.AreEqual(testWallet[i].CurrencyCode, allWallets[i].CurrencyCode);
            }
        }

        [TestMethod]
        public void ThrowException_When_WalletsNotFound()
        {
            // Arrange

            var repositoryMock = new Mock<IWalletRepository>();

            repositoryMock.Setup(r => r.GetAll()).Throws(new EntityNotFoundException(""));

            var sut = new WalletService(repositoryMock.Object);

            // Act & Assert

            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetAll());
        }
    }
}
