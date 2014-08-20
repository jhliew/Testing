using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCC._2014._05_1300875_LAC
{
    public class AmountExceedLimitException : Exception
    {
        public AmountExceedLimitException()
        {
        }

        public AmountExceedLimitException(string message)
            : base(message)
        {
        }

        public AmountExceedLimitException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
