using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCC._2014._05_1300875_LAC
{
    public interface IAmountConverter
    {
        string convertAmount(string amount);
        string convertDigit(char[] arr, int index);
        string convertTenDigit(char[] arr, int index);
        string convert10To19(char[] arr, int index);
    }
}
