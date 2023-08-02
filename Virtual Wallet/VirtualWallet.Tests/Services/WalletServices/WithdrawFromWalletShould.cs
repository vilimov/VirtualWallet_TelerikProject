using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.WalletServices
{
    [TestClass]
    public class WithdrawFromWalletShould
    {
        [TestMethod]
        public void ReduceBallance_When_ParametersAreValid()
        {
            // Arrange
            Wallet wallet = TestHelpers.WalletHelper.GetTestWallet();
            decimal ballance = wallet.Balance;
            decimal withdrawalAmount = 100.0m;
            decimal expectedResult = wallet.Balance - withdrawalAmount;

            var repositoryMock = new Mock<IWalletRepository>();
            repositoryMock.Setup(r => r.WithdrawFromWallet(wallet.Id, withdrawalAmount)).Returns(expectedResult);

            var sut = new WalletService(repositoryMock.Object);

            // Act
            decimal actualResult = sut.WithdrawFromWallet(wallet.Id, withdrawalAmount);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            repositoryMock.Verify(r => r.WithdrawFromWallet(wallet.Id, withdrawalAmount), Times.Once);
        }
    }
}
