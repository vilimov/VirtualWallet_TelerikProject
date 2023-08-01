using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Domain.Enums;

namespace VirtualWallet.Tests.Services.WalletServices
{
    [TestClass]
    public class UpdateWalletShould
    {
        [TestMethod]
        public void ChangeWalletCurrency_When_ParametersAreValid()
        {
            /*// Arrange
            Wallet currentWallet = TestHelpers.WalletHelper.GetTestWallet();
            User testUser = TestHelpers.UsersHelper.GetTestUser();
            double exchangeRate = 1.00;
            Currency newCurrencyCode = Currency.BGN;

            var repositoryMock = new Mock<IWalletRepository>();

            repositoryMock.Setup(r => r.Update(currentWallet.Id, exchangeRate, newCurrencyCode)).Returns();

            var sut = new WalletService(repositoryMock.Object);

            // Act
            Wallet updatedWallet = sut.Update(testUser, newCurrencyCode);

            // Assert
            Assert.AreEqual(currentWallet, updatedWallet);*/
        }
    }
}
