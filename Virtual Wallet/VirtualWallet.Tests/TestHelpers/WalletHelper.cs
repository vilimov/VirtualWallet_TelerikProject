using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Domain.Enums;

namespace VirtualWallet.Tests.TestHelpers
{
    public class WalletHelper
    {
        public static Wallet GetTestWallet()
        {
            return new Wallet()
            {
                Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1
            };
        }

        public static List<Wallet> GetTestWallets()
        {
            return new List<Wallet>()
            {
                new Wallet { Id = 1, CurrencyCode = Currency.USD, Balance = 111111.11M, UserId = 1 },
                new Wallet { Id = 2, CurrencyCode = Currency.USD, Balance = 99999.99M, UserId = 2 },
                new Wallet { Id = 3, CurrencyCode = Currency.USD, Balance = 88888.88M, UserId = 3 }
            };
        }
    }
}
