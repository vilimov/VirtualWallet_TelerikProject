using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWallet.Persistence.QueryParameters;

namespace VirtualWallet.Tests.Services.WalletServices
{
    [TestClass]
    public class GetFIlteredWalletsShould
    {
        [TestMethod]
        public void ReturnFilteredWallets_When_ParametersAreValid()
        {
            // Arrange
            List<Wallet> expectedWallets = TestHelpers.WalletHelper.GetTestWallets();
            var repositoryMock = new Mock<IWalletRepository>();
            WalletQueryParameters filter = new WalletQueryParameters() { BallanceMoreThan  = 0 };

            repositoryMock.Setup(r => r.GetFilteredWallets(filter))
                          .Returns(expectedWallets);

            var sut = new WalletService(repositoryMock.Object);

            // Act
            IEnumerable<Wallet> actualWallets = sut.GetFilteredWallets(filter);

            // Assert
            Assert.AreEqual(expectedWallets, actualWallets);
        }
    }
}
