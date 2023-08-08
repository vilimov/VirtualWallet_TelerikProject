using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Common.Exceptions
{
    public class EmailVerificationException : Exception
    {
        public EmailVerificationException(string message)
            : base(message) { }
    }
}
