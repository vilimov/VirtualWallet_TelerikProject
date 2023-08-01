using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Domain.Enums;

namespace VirtualWallet.Tests.Services.WalletServices
{
    [TestClass]
    public class GetCurrencyByIdShould
    {
        [TestMethod]
        public void GetWalletCurrency_When_ParametersAreValid()
        {
            // Arrange
            Wallet testWallet = TestHelpers.WalletHelper.GetTestWallet();
            Currency expectedCurrency = testWallet.CurrencyCode;

            var repositoryMock = new Mock<IWalletRepository>();

            repositoryMock.Setup(r => r.GetCurrencyById(testWallet.Id)).Returns(testWallet.CurrencyCode);

            var sut = new WalletService(repositoryMock.Object);

            // Act

            Currency actualCurrency = sut.GetCurrencyById(testWallet.Id);

            // Assert

            Assert.AreEqual(expectedCurrency, actualCurrency);
        }

        [TestMethod]
        public void ThrowException_When_WalletNotFound()
        {
            // Arrange

            var repositoryMock = new Mock<IWalletRepository>();

            repositoryMock.Setup(r => r.GetCurrencyById(It.IsAny<int>())).Throws(new EntityNotFoundException(""));

            var sut = new WalletService(repositoryMock.Object);

            // Act & Assert

            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetCurrencyById(1));
        }
    }
}
