using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.WalletServices
{
    [TestClass]
    public class AddToWalletShould
    {
        [TestMethod]
        public void IncreaseBallance_When_ParametersAreValid()
        {
            // Arrange
            Wallet wallet = TestHelpers.WalletHelper.GetTestWallet();
            decimal ballance = wallet.Balance;
            decimal addedAmount = 100.0m;
            decimal expectedResult = wallet.Balance + addedAmount;

            var repositoryMock = new Mock<IWalletRepository>();
            repositoryMock.Setup(r => r.AddToWallet(wallet.Id, addedAmount)).Returns(expectedResult);

            var sut = new WalletService(repositoryMock.Object);

            // Act
            decimal actualResult = sut.AddToWallet(wallet.Id, addedAmount);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            repositoryMock.Verify(r => r.AddToWallet(wallet.Id, addedAmount), Times.Once);
        }
    }
}
