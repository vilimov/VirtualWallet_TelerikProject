using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.WalletServices
{
    [TestClass]
    public class GetByIdShould
    {
        [TestMethod]
        public void GetWallet_When_ParametersAreValid()
        {
            // Arrange

            Wallet expectedWallet = TestHelpers.WalletHelper.GetTestWallet();

            var repositoryMock = new Mock<IWalletRepository>();

            repositoryMock.Setup(r => r.GetWalletById(1)).Returns(expectedWallet);

            var sut = new WalletService(repositoryMock.Object);

            // Act

            Wallet actualWallet = sut.GetWalletById(expectedWallet.Id);

            // Assert

            Assert.AreEqual(expectedWallet, actualWallet);
        }

        [TestMethod]
        public void ThrowException_When_WalletNotFound()
        {
            // Arrange

            var repositoryMock = new Mock<IWalletRepository>();

            repositoryMock.Setup(r => r.GetWalletById(It.IsAny<int>())).Throws(new EntityNotFoundException(""));

            var sut = new WalletService(repositoryMock.Object);

            // Act & Assert

            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetWalletById(1));
        }
    }
}
