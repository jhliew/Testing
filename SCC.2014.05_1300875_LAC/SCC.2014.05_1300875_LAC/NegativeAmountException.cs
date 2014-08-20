using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCC._2014._05_1300875_LAC
{
    public class NegativeAmountException : Exception
    {
        public NegativeAmountException()
        {
        }

        public NegativeAmountException(string message)
            : base(message)
        {
        }

        public NegativeAmountException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
