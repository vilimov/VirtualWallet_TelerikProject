using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Application.Services;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.QueryParameters;

namespace VirtualWallet.Tests.Services.TransactionServices
{
    [TestClass]
    public class GetTransactionShould
    {
        [TestMethod]
        public void ReturnCorrectTransaction_For_GetTransactionById()
        {
            // Arrange
            int transactionId = 1;
            Transaction expectedTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            expectedTransaction.Id = transactionId;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			repositoryMock.Setup(repo => repo.GetTransactionById(transactionId))
                          .Returns(expectedTransaction);

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);

            // Act
            Transaction actualTransaction = sut.GetTransactionById(transactionId);

            // Assert
            Assert.AreEqual(expectedTransaction, actualTransaction);

            // Verify that GetTransactionById was called once with the expected transactionId
            repositoryMock.Verify(repo => repo.GetTransactionById(transactionId), Times.Once);
        }

        [TestMethod]
        public void ReturnCorrectTransactions_For_GetAllTransactions()
        {
            // Arrange
            List<Transaction> expectedTransactions = TestHelpers.TransactionHelpers.GetTestTransactions();
            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			walletServiceMock.Setup(walletService => walletService.GetWalletByUser(It.IsAny<string>()))
                             .Returns(new Wallet());

            repositoryMock.Setup(repo => repo.GetAllTransactions())
                          .Returns(expectedTransactions);

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);

            // Act
            IList<Transaction> actualTransactions = sut.GetAllTransactions();

            // Assert
            Assert.AreEqual(expectedTransactions, actualTransactions);
        }

        [TestMethod]
        public void ReturnCorrectTransactions_For_GetFilteredTransactions()
        {
            // Arrange
            User user = TestHelpers.UsersHelper.GetTestUser();
            List<Transaction> expectedTransactions = TestHelpers.TransactionHelpers.GetTestTransactions();
            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			TransactionsQueryParameters filter = new TransactionsQueryParameters() { AllMyTransactions = "true"};


            repositoryMock.Setup(repo => repo.GetFilteredTransactions(filter, user))
                          .Returns(expectedTransactions);

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);

            // Act
            IList<Transaction> actualTransactions = sut.GetFilteredTransactions(filter, user);

            // Assert
            Assert.AreEqual(expectedTransactions, actualTransactions);
        }
        //GetTransactionsByUserId
        [TestMethod]
        public void ReturnCorrectTransactions_For_GetTransactionsByUserId()
        {
            // Arrange
            User user = TestHelpers.UsersHelper.GetTestUser();
            List<Transaction> expectedTransactions = TestHelpers.TransactionHelpers.GetTestTransactions();
            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			repositoryMock.Setup(repo => repo.GetTransactionsByUserId(user.Id))
                          .Returns(expectedTransactions);

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);

            // Act
            IList<Transaction> actualTransactions = sut.GetTransactionsByUserId(user.Id);

            // Assert
            Assert.AreEqual(expectedTransactions, actualTransactions);
        }
    }
}
