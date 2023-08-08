using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Application.Services;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Common.Exceptions;

namespace VirtualWallet.Tests.Services.TransactionServices
{
    [TestClass]
    public class CreateTransactionShould
    {
        [TestMethod]
        public void AddMoneyCardToWallet_WhenParametersAreValid()
        {
            //Arrange
            User user = TestHelpers.UsersHelper.GetTestUser();
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };
            Wallet wallet = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = user;
            testTransaction.Recipient = user;
            testTransaction.TransactionType = Domain.Enums.TransactionType.Deposit;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			walletServiceMock.Setup(walletService => walletService.GetWalletByUser(user.Username))
                         .Returns(wallet);

            repositoryMock.Setup(repo => repo.AddTransaction(It.IsAny<Transaction>()))
                      .Returns<Transaction>(transaction =>
                      {
                          transaction.Id = 1;
                          return transaction;
                      });

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            //Act
            Transaction actualTransaction = sut.AddMoneyCardToWallet(user, card, testTransaction.Amount, testTransaction.Description);

            //Assert
            Assert.AreEqual(testTransaction.Amount, actualTransaction.Amount);
            Assert.AreEqual(testTransaction.TransactionType, actualTransaction.TransactionType);
            Assert.AreEqual(testTransaction.Sender, actualTransaction.Sender);
            Assert.AreEqual(testTransaction.Recipient, actualTransaction.Recipient);
            Assert.AreEqual(testTransaction.CardNumber, actualTransaction.CardNumber);
            Assert.AreEqual(testTransaction.Description, actualTransaction.Description);

        }

        [TestMethod]
        public void Throw_When_UserIsBlocked_AddMoneyCardToWallet()
        {
            //Arrange
            User user = TestHelpers.UsersHelper.GetTestUser();
            user.IsBlocked = true;

            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };
            Wallet wallet = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = user;
            testTransaction.Recipient = user;
            testTransaction.TransactionType = Domain.Enums.TransactionType.Deposit;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			walletServiceMock.Setup(walletService => walletService.GetWalletByUser(user.Username))
                         .Returns(wallet);

            repositoryMock.Setup(repo => repo.AddTransaction(It.IsAny<Transaction>()))
                      .Returns<Transaction>(transaction =>
                      {
                          transaction.Id = 1;
                          return transaction;
                      });

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            //Act and Assert
            Assert.ThrowsException<UnauthorizedOperationException>(() => sut.AddMoneyCardToWallet(user, card, testTransaction.Amount, testTransaction.Description));
        }


        [TestMethod]
        public void AddMoneyCardToWallet_UserIsNull_ShouldThrowEntityNotFoundException()
        {
            // Arrange
            User user = new User{ Username = "TestUser", IsBlocked = false };// user is null
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };

            decimal amount = 100M;
            string description = "Test transaction";

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);

            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                sut.AddMoneyCardToWallet(user, card, amount, description);
            });
        }

        [TestMethod]
        public void AddMoneyCardToWallet_CardIsNull_ShouldThrowEntityNotFoundException()
        {
            // Arrange
            User user = new User { Username = "TestUser", IsBlocked = false };
            Card card = null; // card is null
            decimal amount = 100M;
            string description = "Test transaction";

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);

            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                sut.AddMoneyCardToWallet(user, card, amount, description);
            });
        }

        [TestMethod]
        public void AddMoneyCardToWallet_CardNotOfThisUser_ShouldThrowEntityNotFoundException()
        {
            // Arrange
            User user = TestHelpers.UsersHelper.GetTestUser();
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 2
            };

            decimal amount = 100M;
            string description = "Test transaction";

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);

            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                sut.AddMoneyCardToWallet(user, card, amount, description);
            });
        }

        [TestMethod]
        public void AddMoneyCardToWallet_WalletNotOfThisUser_ShouldThrowUnauthorizedOperationException()
        {
            // Arrange
            User user = TestHelpers.UsersHelper.GetTestUser();
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };

            decimal amount = 100M;
            string description = "Test transaction";
            Wallet wallet = new Wallet { Id = 2, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 2 };

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			walletServiceMock.Setup(walletService => walletService.GetWalletByUser(user.Username))
             .Returns(wallet);
            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);

            // Act and Assert
            Assert.ThrowsException<UnauthorizedOperationException>(() =>
            {
                sut.AddMoneyCardToWallet(user, card, amount, description);
            });
        }

        [TestMethod]
        public void AddMoneyWalletToWallet_WhenParametersAreValid()
        {
            //Arrange
            List<User> users = TestHelpers.UsersHelper.GetTestUsersList();
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };
            Wallet walletU1 = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 };
            Wallet walletU2 = new Wallet { Id = 2, CurrencyCode = Currency.USD, Balance = 99999.99M, UserId = 2 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = users[0];
            testTransaction.Recipient = users[1];
            testTransaction.TransactionType = Domain.Enums.TransactionType.Transfer;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();

			walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[0].Username))
                         .Returns(walletU1); // Return wallet for users[0]
            walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[1].Username))
                         .Returns(walletU2); // Return wallet for users[1]
            walletServiceMock.SetupSequence(walletService => walletService.GetBalance(1))
                         .Returns(walletU1.Balance); // Return wallet for users[1]

            repositoryMock.Setup(repo => repo.AddTransaction(It.IsAny<Transaction>()))
                      .Returns<Transaction>(transaction =>
                      {
                          transaction.Id = 1;
                          return transaction;
                      });

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            //Act
            Transaction actualTransaction = sut.AddMoneyWalletToWallet(users[0], users[1], testTransaction.Amount, testTransaction.Description);

            //Assert
            Assert.AreEqual(testTransaction.Amount, actualTransaction.Amount);
            Assert.AreEqual(testTransaction.TransactionType, actualTransaction.TransactionType);
            Assert.AreEqual(testTransaction.Sender, actualTransaction.Sender);
            Assert.AreEqual(testTransaction.Recipient, actualTransaction.Recipient);
            Assert.AreEqual(testTransaction.Description, actualTransaction.Description);

        }

        [TestMethod]
        public void AddMoneyWalletToWallet_WhenSenderIsNull_ShouldThrowEntityNotFoundException()
        {
            //Arrange
            List<User> users = TestHelpers.UsersHelper.GetTestUsersList();
            User user = null;
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };
            Wallet walletU1 = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 };
            Wallet walletU2 = new Wallet { Id = 2, CurrencyCode = Currency.USD, Balance = 99999.99M, UserId = 2 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = user;
            testTransaction.Recipient = users[1];
            testTransaction.TransactionType = Domain.Enums.TransactionType.Transfer;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                sut.AddMoneyWalletToWallet(user, users[1], testTransaction.Amount, testTransaction.Description);
            });

        }

        [TestMethod]
        public void AddMoneyWalletToWallet_WhenRecipientIsNull_ShouldThrowEntityNotFoundException()
        {
            //Arrange
            List<User> users = TestHelpers.UsersHelper.GetTestUsersList();
            User user = null;
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };
            Wallet walletU1 = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 };
            Wallet walletU2 = new Wallet { Id = 2, CurrencyCode = Currency.USD, Balance = 99999.99M, UserId = 2 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = users[1];
            testTransaction.Recipient = user;
            testTransaction.TransactionType = Domain.Enums.TransactionType.Transfer;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                sut.AddMoneyWalletToWallet(users[1], user, testTransaction.Amount, testTransaction.Description);
            });

        }

        [TestMethod]
        public void AddMoneyWalletToWallet_WhenSenderIsBlocked_ShouldThrowUnauthorizedOperationException()
        {
            //Arrange
            List<User> users = TestHelpers.UsersHelper.GetTestUsersList();
            users[0].IsBlocked = true;
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };
            Wallet walletU1 = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 };
            Wallet walletU2 = new Wallet { Id = 2, CurrencyCode = Currency.USD, Balance = 99999.99M, UserId = 2 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = users[0];
            testTransaction.Recipient = users[1];
            testTransaction.TransactionType = Domain.Enums.TransactionType.Transfer;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            // Act and Assert
            Assert.ThrowsException<UnauthorizedOperationException>(() =>
            {
                sut.AddMoneyWalletToWallet(users[0], users[1], testTransaction.Amount, testTransaction.Description);
            });

        }

        [TestMethod]
        public void AddMoneyWalletToWallet_WhenInsuficientAmount_ShouldThrowInsuficientAmountException()
        {
            //Arrange
            List<User> users = TestHelpers.UsersHelper.GetTestUsersList();
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };
            Wallet walletU1 = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 1.11M, UserId = 1 };
            Wallet walletU2 = new Wallet { Id = 2, CurrencyCode = Currency.USD, Balance = 99999.99M, UserId = 2 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = users[0];
            testTransaction.Recipient = users[0];
            testTransaction.TransactionType = Domain.Enums.TransactionType.Withdraw;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[0].Username))
                         .Returns(walletU1); // Return wallet for users[0]
            walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[1].Username))
                         .Returns(walletU2); // Return wallet for users[1]
            walletServiceMock.SetupSequence(walletService => walletService.GetBalance(1))
                         .Returns(walletU1.Balance); // Return wallet for users[1]

            repositoryMock.Setup(repo => repo.AddTransaction(It.IsAny<Transaction>()))
                      .Returns<Transaction>(transaction =>
                      {
                          transaction.Id = 1;
                          return transaction;
                      });

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            // Act and Assert
            Assert.ThrowsException<InsuficientAmountException>(() =>
            {
                sut.AddMoneyWalletToWallet(users[0], users[1], testTransaction.Amount, testTransaction.Description);
            });

        }

        [TestMethod]
        public void ConvertMoney_WhendifferentCurrency_AddMoneyWalletToWalletBGN()
        {
            //Arrange
            List<User> users = TestHelpers.UsersHelper.GetTestUsersList();
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };
            Wallet walletU1 = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 };
            Wallet walletU2 = new Wallet { Id = 2, CurrencyCode = Currency.BGN, Balance = 99999.99M, UserId = 2 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = users[0];
            testTransaction.Recipient = users[0];
            testTransaction.TransactionType = Domain.Enums.TransactionType.Withdraw;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[0].Username))
                         .Returns(walletU1); // Return wallet for users[0]
            walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[1].Username))
                         .Returns(walletU2); // Return wallet for users[1]
            walletServiceMock.SetupSequence(walletService => walletService.GetBalance(1))
                         .Returns(walletU1.Balance); // Return wallet for users[1]

            repositoryMock.Setup(repo => repo.AddTransaction(It.IsAny<Transaction>()))
                      .Returns<Transaction>(transaction =>
                      {
                          transaction.Id = 1;
                          return transaction;
                      });

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            //Act
            Transaction actualTransaction = sut.AddMoneyWalletToWallet(users[0], users[1], testTransaction.Amount, testTransaction.Description);
            var testExchange = (double)actualTransaction.Amount * actualTransaction.CurrencyExchangeRate;
            //Assert
            Assert.AreEqual(testExchange, (double)actualTransaction.AmountReceived);

        }

        [TestMethod]
        public void ConvertMoney_WhendifferentCurrency_AddMoneyWalletToWalletEUR()
        {
            //Arrange
            List<User> users = TestHelpers.UsersHelper.GetTestUsersList();
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };
            Wallet walletU1 = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 };
            Wallet walletU2 = new Wallet { Id = 2, CurrencyCode = Currency.EUR, Balance = 99999.99M, UserId = 2 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = users[0];
            testTransaction.Recipient = users[0];
            testTransaction.TransactionType = Domain.Enums.TransactionType.Withdraw;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[0].Username))
                         .Returns(walletU1); // Return wallet for users[0]
            walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[1].Username))
                         .Returns(walletU2); // Return wallet for users[1]
            walletServiceMock.SetupSequence(walletService => walletService.GetBalance(1))
                         .Returns(walletU1.Balance); // Return wallet for users[1]

            repositoryMock.Setup(repo => repo.AddTransaction(It.IsAny<Transaction>()))
                      .Returns<Transaction>(transaction =>
                      {
                          transaction.Id = 1;
                          return transaction;
                      });

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            //Act
            Transaction actualTransaction = sut.AddMoneyWalletToWallet(users[0], users[1], testTransaction.Amount, testTransaction.Description);
            var testExchange = (double)actualTransaction.Amount * actualTransaction.CurrencyExchangeRate;
            //Assert
            Assert.AreEqual((decimal)testExchange, (decimal)actualTransaction.AmountReceived);

        }

        [TestMethod]
        public void ConvertMoney_WhendifferentCurrency_AddMoneyWalletToWalletUSD()
        {
            //Arrange
            List<User> users = TestHelpers.UsersHelper.GetTestUsersList();
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };
            Wallet walletU1 = new Wallet { Id = 1, CurrencyCode = Currency.EUR, Balance = 111111.11M, UserId = 1 };
            Wallet walletU2 = new Wallet { Id = 2, CurrencyCode = Currency.USD, Balance = 99999.99M, UserId = 2 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = users[0];
            testTransaction.Recipient = users[0];
            testTransaction.TransactionType = Domain.Enums.TransactionType.Withdraw;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[0].Username))
                         .Returns(walletU1); // Return wallet for users[0]
            walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[1].Username))
                         .Returns(walletU2); // Return wallet for users[1]
            walletServiceMock.SetupSequence(walletService => walletService.GetBalance(1))
                         .Returns(walletU1.Balance); // Return wallet for users[1]

            repositoryMock.Setup(repo => repo.AddTransaction(It.IsAny<Transaction>()))
                      .Returns<Transaction>(transaction =>
                      {
                          transaction.Id = 1;
                          return transaction;
                      });

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            //Act
            Transaction actualTransaction = sut.AddMoneyWalletToWallet(users[0], users[1], testTransaction.Amount, testTransaction.Description);
            var testExchange = (double)actualTransaction.Amount * actualTransaction.CurrencyExchangeRate;
            //Assert
            Assert.AreEqual((decimal)testExchange, (decimal)actualTransaction.AmountReceived);

        }

        [TestMethod]
        public void WithdrawalTransfer_WhenParametersAreValid()
        {
            //Arrange
            List<User> users = TestHelpers.UsersHelper.GetTestUsersList();
			var amount = 100.0m;
			var description = "Test withdrawal";
			Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1,
				CurrencyCode = Currency.USD
			};

            Wallet walletU1 = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 };
            Wallet walletU2 = new Wallet { Id = 2, CurrencyCode = Currency.USD, Balance = 99999.99M, UserId = 2 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = users[0];
            testTransaction.Recipient = users[0];
            testTransaction.TransactionType = Domain.Enums.TransactionType.Withdraw;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[0].Username))
                         .Returns(walletU1); // Return wallet for users[0]
            walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[1].Username))
                         .Returns(walletU2); // Return wallet for users[1]
            walletServiceMock.SetupSequence(walletService => walletService.GetBalance(1))
                         .Returns(walletU1.Balance); // Return wallet for users[1]

            repositoryMock.Setup(repo => repo.AddTransaction(It.IsAny<Transaction>()))
                      .Returns<Transaction>(transaction =>
                      {
                          transaction.Id = 1;
                          return transaction;
                      });

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            //Act
            Transaction actualTransaction = sut.WithdrawalTransfer(users[0], card, testTransaction.Amount, testTransaction.Description);

            //Assert
            Assert.AreEqual(testTransaction.Amount, actualTransaction.Amount);
            Assert.AreEqual(testTransaction.TransactionType, actualTransaction.TransactionType);
            Assert.AreEqual(testTransaction.Sender, actualTransaction.Sender);
            Assert.AreEqual(testTransaction.Recipient, actualTransaction.Recipient);
            Assert.AreEqual(testTransaction.Description, actualTransaction.Description);
            Assert.AreEqual(testTransaction.CardNumber, actualTransaction.CardNumber);

        }

        [TestMethod]
        public void WithdrawalTransfer_WhenSenderIsBlocked_ShouldThrowUnauthorizedOperationException()
        {
            //Arrange
            List<User> users = TestHelpers.UsersHelper.GetTestUsersList();
            users[0].IsBlocked = true;
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };
            Wallet walletU1 = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 };
            Wallet walletU2 = new Wallet { Id = 2, CurrencyCode = Currency.USD, Balance = 99999.99M, UserId = 2 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = users[0];
            testTransaction.Recipient = users[0];
            testTransaction.TransactionType = Domain.Enums.TransactionType.Withdraw;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[0].Username))
                         .Returns(walletU1); // Return wallet for users[0]
            walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(users[1].Username))
                         .Returns(walletU2); // Return wallet for users[1]
            walletServiceMock.SetupSequence(walletService => walletService.GetBalance(1))
                         .Returns(walletU1.Balance); // Return wallet for users[1]

            repositoryMock.Setup(repo => repo.AddTransaction(It.IsAny<Transaction>()))
                      .Returns<Transaction>(transaction =>
                      {
                          transaction.Id = 1;
                          return transaction;
                      });

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            // Act and Assert
            Assert.ThrowsException<UnauthorizedOperationException>(() =>
            {
                sut.WithdrawalTransfer(users[0], card, testTransaction.Amount, testTransaction.Description);
            });

        }

        [TestMethod]
        public void WithdrawalTransfer_WhenCardIsNull_ShouldThrowEntityNotFoundException()
        {
            //Arrange
            List<User> users = TestHelpers.UsersHelper.GetTestUsersList();
            User user = users[0];
            Card card = null;
            Wallet walletU1 = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 };
            Wallet walletU2 = new Wallet { Id = 2, CurrencyCode = Currency.USD, Balance = 99999.99M, UserId = 2 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = user;
            testTransaction.Recipient = user;
            testTransaction.TransactionType = Domain.Enums.TransactionType.Withdraw;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(user.Username))
                         .Returns(walletU1); // Return wallet for users[0]
            walletServiceMock.SetupSequence(walletService => walletService.GetBalance(1))
                         .Returns(walletU1.Balance); // Return wallet for users[1]

            repositoryMock.Setup(repo => repo.AddTransaction(It.IsAny<Transaction>()))
                      .Returns<Transaction>(transaction =>
                      {
                          transaction.Id = 1;
                          return transaction;
                      });

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                sut.WithdrawalTransfer(users[0], card, testTransaction.Amount, testTransaction.Description);
            });

        }
        [TestMethod]
        public void WithdrawalTransfer_WhenCardNotOfThisUser_ShouldThrowUnauthorizedOperationException()
        {
            //Arrange
            List<User> users = TestHelpers.UsersHelper.GetTestUsersList();
            User user = users[0];
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 2
            };
            Wallet walletU1 = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 };
            Wallet walletU2 = new Wallet { Id = 2, CurrencyCode = Currency.USD, Balance = 99999.99M, UserId = 2 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = user;
            testTransaction.Recipient = user;
            testTransaction.TransactionType = Domain.Enums.TransactionType.Withdraw;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(user.Username))
                         .Returns(walletU1); // Return wallet for users[0]
            walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(user.Username))
                         .Returns(walletU2); // Return wallet for users[1]
            walletServiceMock.SetupSequence(walletService => walletService.GetBalance(1))
                         .Returns(walletU1.Balance); // Return wallet for users[1]

            repositoryMock.Setup(repo => repo.AddTransaction(It.IsAny<Transaction>()))
                      .Returns<Transaction>(transaction =>
                      {
                          transaction.Id = 1;
                          return transaction;
                      });

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            // Act and Assert
            Assert.ThrowsException<UnauthorizedOperationException>(() =>
            {
                sut.WithdrawalTransfer(users[0], card, testTransaction.Amount, testTransaction.Description);
            });
        }

        [TestMethod]
        public void WithdrawalTransfer_WhenSenderIsNull_ShouldThrowEntityNotFoundException()
        {
            //Arrange
            List<User> users = TestHelpers.UsersHelper.GetTestUsersList();
            User user = new User { Username = "TestUser", IsBlocked = false };// user is null
            Card card = new Card
            {
                Id = 1,
                Number = "8676880603590752",
                ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3),
                CardHolder = "Elon Musk",
                CheckNumber = "649",
                IsCreditCard = true,
                UserId = 1
            };
            Wallet walletU1 = new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 };
            Wallet walletU2 = new Wallet { Id = 2, CurrencyCode = Currency.USD, Balance = 99999.99M, UserId = 2 };

            Transaction testTransaction = TestHelpers.TransactionHelpers.GetTestTransaction();
            testTransaction.CardNumber = "************0752";
            testTransaction.Sender = user;
            testTransaction.Recipient = user;
            testTransaction.TransactionType = Domain.Enums.TransactionType.Withdraw;

            var repositoryMock = new Mock<ITransactionRepository>();
            var walletServiceMock = new Mock<IWalletService>();
			var emailServiceMock = new Mock<IEmailService>();
			walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(user.Username))
                         .Returns(walletU1); // Return wallet for users[0]
            walletServiceMock.SetupSequence(walletService => walletService.GetWalletByUser(user.Username))
                         .Returns(walletU2); // Return wallet for users[1]
            walletServiceMock.SetupSequence(walletService => walletService.GetBalance(1))
                         .Returns(walletU1.Balance); // Return wallet for users[1]

            repositoryMock.Setup(repo => repo.AddTransaction(It.IsAny<Transaction>()))
                      .Returns<Transaction>(transaction =>
                      {
                          transaction.Id = 1;
                          return transaction;
                      });

            var sut = new TransactionService(repositoryMock.Object, walletServiceMock.Object, emailServiceMock.Object);
            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                sut.WithdrawalTransfer(users[0], card, testTransaction.Amount, testTransaction.Description);
            });

        }
    }
}
