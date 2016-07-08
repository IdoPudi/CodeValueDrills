using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() 
            : base() { }

        public InsufficientFundsException(string message)
            : base(message) { }
    }
}
