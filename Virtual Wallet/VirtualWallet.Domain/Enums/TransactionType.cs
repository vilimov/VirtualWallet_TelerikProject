using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Domain.Enums
{
    public enum TransactionType
    {
        InternalIncome = 1,     //Wallet to Wallet, Receive money from user
        Transfer = 2,    //Wallet to Wallet, Send money to user
        Deposit = 3,       //Card to Wallet, send money from my card to my wallet
        Withdraw = 4          //Wallet to Card, send money from my wallet to my card
    }
}
