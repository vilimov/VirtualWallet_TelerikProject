using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.WalletServices
{
    [TestClass]
    public class CreateWalletShould
    {
        [TestMethod]
        public void CreateWallet_When_ParametesAreValid()
        {
            // Arrange
            Wallet testWallet = TestHelpers.WalletHelper.GetTestWallet();
            User testUser = TestHelpers.UsersHelper.GetTestUser();

            var repositoryMock = new Mock<IWalletRepository>();

            repositoryMock.Setup(r => r.CreateWallet(testWallet)).Returns(testWallet);

            var sut = new WalletService(repositoryMock.Object);

            // Act
            Wallet actualWallet = sut.CreateWallet(testWallet, testUser);

            // Assert
            Assert.AreEqual(testWallet, actualWallet);
        }
    }
}
