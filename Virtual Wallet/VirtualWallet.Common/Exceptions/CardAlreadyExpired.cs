using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Common.Exceptions
{
    public class CardAlreadyExpired : ApplicationException
    {
        public CardAlreadyExpired(string message) : base(message) 
        {
        }
    }
}
