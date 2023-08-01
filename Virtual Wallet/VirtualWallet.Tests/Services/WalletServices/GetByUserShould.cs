using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Tests.Services.WalletServices
{
    [TestClass]
    public class GetByUserShould
    {
        [TestMethod]
        public void GetWallet_When_ParametersAreValid()
        {
            // Arrange
            User expectedUser = TestHelpers.UsersHelper.GetTestUser();
            Wallet expectedWallet = TestHelpers.WalletHelper.GetTestWallets().FirstOrDefault(c => c.UserId == expectedUser.Id);


            var repositoryMock = new Mock<IWalletRepository>();

            repositoryMock.Setup(r => r.GetWalletByUser(expectedUser.Username)).Returns(expectedWallet);

            var sut = new WalletService(repositoryMock.Object);

            // Act
            Wallet actualWallet = sut.GetWalletByUser(expectedUser.Username);

            // Assert
            Assert.AreEqual(expectedWallet, actualWallet);
        }

        [TestMethod]
        public void ThrowException_When_WalletNotFound()
        {
            // Arrange
            User expectedUser = TestHelpers.UsersHelper.GetTestUser();

            var repositoryMock = new Mock<IWalletRepository>();

            repositoryMock.Setup(r => r.GetWalletByUser(expectedUser.Username)).Throws(new EntityNotFoundException(""));

            var sut = new WalletService(repositoryMock.Object);

            // Act & Assert

            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetWalletByUser(expectedUser.Username));
        }
    }
}
