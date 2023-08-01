using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.WalletServices
{
    [TestClass]
    public class DeleteShould
    {
        [TestMethod]
        public void DeleteWallet_When_ParametersAreValid()
        {
            // Arrange
            Wallet testWallet = TestHelpers.WalletHelper.GetTestWallet();

            var repositoryMock = new Mock<IWalletRepository>();

            var sut = new WalletService(repositoryMock.Object);

            // Act
            sut.Delete(testWallet.Id);

            // Assert
            repositoryMock.Verify(r => r.Delete(testWallet.Id), Times.Once);
        }
    }
}
