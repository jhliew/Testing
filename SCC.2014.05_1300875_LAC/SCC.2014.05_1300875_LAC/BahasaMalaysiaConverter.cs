using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCC._2014._05_1300875_LAC
{
    public class BahasaMalaysiaConverter: IAmountConverter
    {
        public string convertAmount(string amount)
        {
            char[] amountArrayInWord = amount.ToCharArray();
            int periodIndex = Array.IndexOf(amountArrayInWord, '.');
            int arrayLength = amountArrayInWord.Length;
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
                        resultString += "KOSONG ";
                    else
                    resultString += convertDigit(amountArrayInWord, i);
                }

                if (lengthBeforePeriod == 7)
                {
                    if (i == 0)
                        resultString += "SATU JUTA ";
                }

                if (lengthBeforePeriod == 6)
                {
                    if (i == 0)
                        resultString += "RATUS ";
                    else if (i == 2)
                        resultString += "RIBU ";
                    else if (i == 3)
                        resultString += "RATUS ";
                }

                else if (lengthBeforePeriod == 5)
                {
                    if (i == 1)
                        resultString += "RIBU ";
                    else if (i == 2)
                        resultString += "RATUS ";
                }

                else if (lengthBeforePeriod == 4)
                {
                    if (i == 0)
                        resultString += "RIBU ";
                    else if (i == 1)
                        resultString += "RATUS ";
                }

                else if (lengthBeforePeriod == 3)
                {
                    if (i == 0)
                        resultString += "RATUS ";
                }

            }

            if (frictionIndex != 0)
            {
                if (!(lengthBeforePeriod == 1 && amountArrayInWord[0] == '0'))
                    resultString += "DAN ";

                for (int i = frictionIndex; i < limit; i++)
                {
                    if (i == (frictionIndex))
                    {
                        resultString += "SEN ";
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

            resultString += "SAHAJA";

            return resultString;
        }

        public string convertDigit(char[] amountArray, int index)
        {
            char number = amountArray[index];

            switch (number)
            {
                case '1':
                    return "SATU ";
                case '2':
                    return "DUA ";
                case '3':
                    return "TIGA ";
                case '4':
                    return "EMPAT ";
                case '5':
                    return "LIMA ";
                case '6':
                    return "ENAM ";
                case '7':
                    return "TUJUH ";
                case '8':
                    return "LAPAN ";
                case '9':
                    return "SEMBILAN ";
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
                    return "DUA PULUH ";
                case '3':
                    return "TIGA PULUH ";
                case '4':
                    return "EMPAT PULUH ";
                case '5':
                    return "LIMA PULUH ";
                case '6':
                    return "ENAM PULUH ";
                case '7':
                    return "TUJUH PULUH ";
                case '8':
                    return "LAPAN PULUH ";
                case '9':
                    return "SEMBILAN PULUH ";
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
                    return "SEPULUH ";
                case '1':
                    return "SEBELAS ";
                case '2':
                    return "DUA BELAS ";
                case '3':
                    return "TIGA BELAS ";
                case '4':
                    return "EMPAT BELAS ";
                case '5':
                    return "LIMA BELAS ";
                case '6':
                    return "ENAM BELAS ";
                case '7':
                    return "TUJUH BELAS ";
                case '8':
                    return "LAPAN BELAS ";
                case '9':
                    return "SEMBILAN BELAS ";
                default:
                    return "";
            }
        }
    }
}
