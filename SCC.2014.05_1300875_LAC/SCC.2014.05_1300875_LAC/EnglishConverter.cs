using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCC._2014._05_1300875_LAC
{
    public class EnglishConverter: IAmountConverter
    {
        public string convertAmount(string amount)
        {
            char[] amountArrayInWord = amount.ToCharArray();
            int arrayLength = amountArrayInWord.Length;
            int periodIndex = Array.IndexOf(amountArrayInWord, '.');
            int lengthBeforePeriod = periodIndex;
            int frictionIndex = periodIndex + 1;
            int limit = periodIndex + 3;

            if (periodIndex == -1)
            {
                lengthBeforePeriod = arrayLength;
                frictionIndex = 0;
                limit = arrayLength;
            }

            string resultString = "";

            for (int i = 0; i < lengthBeforePeriod; i++)
            {

                if (lengthBeforePeriod == 5 || lengthBeforePeriod == 2)
                {
                    if (i == 0 || i == 3)
                    {
                        resultString += convertTenDigit(amountArrayInWord, i);

                        if (amountArrayInWord[i] == '1')
                        {
                            i++;
                        }
                    }

                    else
                        resultString += convertDigit(amountArrayInWord, i);
                }

                if (lengthBeforePeriod == 6 || lengthBeforePeriod == 3)
                {
                    if (i == 1 || i == 4)
                    {
                        resultString += convertTenDigit(amountArrayInWord, i);

                        if (amountArrayInWord[i] == '1')
                        {
                            i++;
                        }
                    }

                    else
                        resultString += convertDigit(amountArrayInWord, i);
                }

                if (lengthBeforePeriod == 4)
                {
                    if (i == 2)
                    {
                        resultString += convertTenDigit(amountArrayInWord, i);

                        if (amountArrayInWord[i] == '1')
                        {
                            i++;
                        }
                    }

                    else
                        resultString += convertDigit(amountArrayInWord, i);
                }

                if (lengthBeforePeriod == 1)
                {
                    if (amountArrayInWord[i] == '0')
                        resultString += "ZERO ";
                    else
                    resultString += convertDigit(amountArrayInWord, i);
                }

                if (lengthBeforePeriod == 7)
                {
                    if (i == 0)
                        resultString += "ONE MILLION ";
                }

                if (lengthBeforePeriod == 6)
                {
                    if (i == 0)
                        resultString += "HUNDRED ";
                    else if (i == 2)
                        resultString += "THOUSAND ";
                    else if (i == 3)
                        resultString += "HUNDRED ";
                }

                else if (lengthBeforePeriod == 5)
                {
                    if (i == 1)
                        resultString += "THOUSAND ";
                    else if (i == 2)
                        resultString += "HUNDRED ";
                }

                else if (lengthBeforePeriod == 4)
                {
                    if (i == 0)
                        resultString += "THOUSAND ";
                    else if (i == 1)
                        resultString += "HUNDRED ";
                }

                else if (lengthBeforePeriod == 3)
                {
                    if (i == 0)
                        resultString += "HUNDRED ";
                }

            }

            if (frictionIndex != 0)
            {
                if(!(lengthBeforePeriod == 1 && amountArrayInWord[0] == '0'))
                    resultString += "AND ";

                for (int i = frictionIndex; i < limit; i++)
                {
                    if (i == (frictionIndex))
                    {
                        if (amountArrayInWord[i] == '0' && amountArrayInWord[i + 1] == '1')
                            resultString += "CENT ";
                        else
                            resultString += "CENTS ";
                    }

                    if (i == frictionIndex)
                    {
                        resultString += convertTenDigit(amountArrayInWord, i);

                        if (amountArrayInWord[i] == '1')
                        {
                            i++;
                        }
                    }

                    else
                        resultString += convertDigit(amountArrayInWord, i);
                }
            }

            resultString += "ONLY";

            return resultString;
        }

        public string convertDigit(char[] amountArray, int index)
        {
            char number = amountArray[index];

            switch (number)
            {
                case '1':
                    return "ONE ";
                case '2':
                    return "TWO ";
                case '3':
                    return "THREE ";
                case '4':
                    return "FOUR ";
                case '5':
                    return "FIVE ";
                case '6':
                    return "SIX ";
                case '7':
                    return "SEVEN ";
                case '8':
                    return "EIGHT ";
                case '9':
                    return "NINE ";
                default:
                    return "";
            }
        }

        public string convertTenDigit(char[] amountArray, int index)
        {
            char number = amountArray[index];

            switch (number)
            {
                case '1':
                    return convert10To19(amountArray, index);
                case '2':
                    return "TWENTY ";
                case '3':
                    return "THIRTY ";
                case '4':
                    return "FOURTY ";
                case '5':
                    return "FIFTY ";
                case '6':
                    return "SIXTY ";
                case '7':
                    return "SEVENTY ";
                case '8':
                    return "EIGHTY ";
                case '9':
                    return "NINETY ";
                default:
                    return "";
            }
        }

        public string convert10To19(char[] amountArray, int index)
        {
            char nextNumber = amountArray[index + 1];

            switch (nextNumber)
            {
                case '0':
                    return "TEN ";
                case '1':
                    return "ELEVEN ";
                case '2':
                    return "TWELVE ";
                case '3':
                    return "THIRTEEN ";
                case '4':
                    return "FOURTEEN ";
                case '5':
                    return "FIFTEEN ";
                case '6':
                    return "SIXTEEN ";
                case '7':
                    return "SEVENTEEN ";
                case '8':
                    return "EIGHTEEN ";
                case '9':
                    return "NINETEEN ";
                default:
                    return "";
            }
        }
    }
}
