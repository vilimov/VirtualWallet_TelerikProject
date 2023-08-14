using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using VirtualWallet.Application.ExchangeRateAPI;
using VirtualWallet.Common.Exceptions;

namespace VirtualWallet.Tests.Services.WalletServices
{
	[TestClass]
	public class UpdateWalletShould
	{
		[TestMethod]
		public void Update_ValidInput_ReturnsUpdatedWallet()
		{
			// Arrange
			var mockRepository = new Mock<IWalletRepository>();
			mockRepository.Setup(repo => repo.GetWalletByUser(It.IsAny<string>())).Returns(new Wallet
			{
				Id = 1,
				User = new User { Username = "user1" },
				CurrencyCode = Currency.USD
			});

			mockRepository.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<Currency>()))
						 .Returns((int id, double exchangeRate, Currency currency) =>
						 {
							 // Simulate wallet update logic
							 return new Wallet
							 {
								 Id = id,
								 User = new User { Username = "user1" },
								 CurrencyCode = currency
							 };
						 });

			var walletService = new WalletService(mockRepository.Object);

			var user = new User { Username = "user1" };
			var newWallet = new Wallet
			{
				CurrencyCode = Currency.EUR
			};

			// Act
			Wallet updatedWallet = walletService.Update(user, newWallet);

			// Assert
			Assert.IsNotNull(updatedWallet);
			Assert.AreEqual(Currency.EUR, updatedWallet.CurrencyCode);
		}
	}
}
