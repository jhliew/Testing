using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCC._2014._05_1300875_LAC
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stopApplication = false;
            Console.WriteLine("Select Your Language Preference: (E-English/M-Bahasa Malaysia)");
            char languageSelection = Convert.ToChar(Console.ReadLine());
            languageSelection = Char.ToUpper(languageSelection);
            LegalAmountConverter legalAmountConverter = new LegalAmountConverter(languageSelection);

            Console.WriteLine("\n\nType 'Quit' to exit Application.\n");
            
            while (stopApplication != true)
            {
                Console.WriteLine("\n\nPlease Enter The Amount To Convert: ");
                string inputAmount = Console.ReadLine();
                if (inputAmount == "Quit")
                {
                    stopApplication = true;
                }

                else
                {
                    try
                    {
                        legalAmountConverter.setAmount(inputAmount);

                        string amountInWords = legalAmountConverter.convertAmount();

                        Console.WriteLine("{0}\n", amountInWords);
                    }

                    catch (NegativeAmountException)
                    {
                        Console.WriteLine("\n\nSystem does not accept negative value amount. \nPlease re-enter the correct value.");
                    }

                    catch (AmountExceedLimitException)
                    {
                        Console.WriteLine("\n\nSystem does not accept amount greater then 1,000,000. \nPlease re-enter the correct value.");
                    }


                }
            }
        }
    }
}
