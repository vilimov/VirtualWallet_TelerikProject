using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Common.Exceptions
{
    public class EmailVerificationException : ApplicationException
    {
        public EmailVerificationException(string message)
            : base(message) { }
    }
}
