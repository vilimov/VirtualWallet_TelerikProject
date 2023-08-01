using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace VirtualWallet.Tests.TestHelpers
{
    public class TransactionHelpers
    {
        public static Transaction GetTestTransaction()
        { 
            return new Transaction{ Id = 1, Date = DateTime.Now, Amount = 100, SenderId = 1, RecipientId = 1, Description = "Internal Test" };

        }

        public static List<Transaction> GetTestTransactions()
        {
            return new List<Transaction> { 
                new Transaction { Id = 1, Date = DateTime.Now.AddDays(-10), Amount = 111, SenderId = 1, RecipientId = 10, Description = "Transaction" },
                new Transaction { Id = 2, Date = DateTime.Now.AddDays(-9), Amount = 222, SenderId = 2, RecipientId = 9, Description = "Transfer to my friend Amancio " },
            };
        }
    }
}
