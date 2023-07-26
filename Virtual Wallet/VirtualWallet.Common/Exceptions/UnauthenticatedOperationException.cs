﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Common.Exceptions
{
    public class UnauthenticatedOperationException : ApplicationException
    {
        public UnauthenticatedOperationException(string message) :base(message)
        {
                
        }
    }
}
