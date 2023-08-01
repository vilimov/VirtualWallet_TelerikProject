using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.WalletServices
{
    [TestClass]
    public class GetBallanceShould
    {
        [TestMethod]
        public void GetWalletBallance_When_ParametersAreValid()
        {
            // Arrange
            Wallet testWallet = TestHelpers.WalletHelper.GetTestWallet();
            decimal expectedBallance = testWallet.Balance;

            var repositoryMock = new Mock<IWalletRepository>();

            repositoryMock.Setup(r => r.GetBalance(testWallet.Id)).Returns(testWallet.Balance);

            var sut = new WalletService(repositoryMock.Object);

            // Act

            decimal actualBallance = sut.GetBalance(testWallet.Id);

            // Assert

            Assert.AreEqual(expectedBallance, actualBallance);
        }

        [TestMethod]
        public void ThrowException_When_WalletNotFound()
        {
            // Arrange

            var repositoryMock = new Mock<IWalletRepository>();

            repositoryMock.Setup(r => r.GetBalance(It.IsAny<int>())).Throws(new EntityNotFoundException(""));

            var sut = new WalletService(repositoryMock.Object);

            // Act & Assert

            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetBalance(1));
        }
    }
}
