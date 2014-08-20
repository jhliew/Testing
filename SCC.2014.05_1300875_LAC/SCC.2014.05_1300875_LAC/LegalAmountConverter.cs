using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCC._2014._05_1300875_LAC
{
    public class LegalAmountConverter
    {
        private string amount;
        private string language;
        private IAmountConverter iConverter;

        public LegalAmountConverter(char language)
        {
            if (language == 'E')
                iConverter = new EnglishConverter();
            else if (language == 'M')
                iConverter = new BahasaMalaysiaConverter();
        }

        public void setAmount(string amount)
        {
            double amountInNumber = Convert.ToDouble(amount);

            if (amountInNumber < 0)
            {
                throw new NegativeAmountException("Negative amount. Please enter a valid that is not a less than zero");
            }

            else if (amountInNumber > 1000000.00)
            {
                throw new AmountExceedLimitException("Amount exceeded limit of 1,000,000. Please enter a valid that is less than 1,000,000");
            }

            else
            {
                this.amount = amount;
            }
        }

        public void setLanguage(char language)
        {
            switch (language)
            {
                case 'E':
                    this.language = "English";
                    break;
                case 'M':
                    this.language = "Bahasa Malaysia";
                    break;

                default:
                    this.language = "Unselected";
                    break;
            }
        }

        public string convertAmount()
        {
            return iConverter.convertAmount(amount);
        }

        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        public IAmountConverter Converter
        {
            get { return iConverter; }
            set { iConverter = value; }
        }


    }
}
