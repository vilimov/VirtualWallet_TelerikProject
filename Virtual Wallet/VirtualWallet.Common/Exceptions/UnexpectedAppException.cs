﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Common.Exceptions
{
    public class UnexpectedAppException : ApplicationException
    {
        public UnexpectedAppException(string message) : base(message) { }
    }
}
