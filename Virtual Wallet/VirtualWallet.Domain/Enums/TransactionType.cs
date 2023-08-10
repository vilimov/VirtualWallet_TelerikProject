using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Domain.Enums
{
    public enum TransactionType
    {
        InternalIncome = 1,   
        Transfer = 2,    
        Deposit = 3,      
        Withdraw = 4         
    }
}
