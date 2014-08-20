using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCC._2014._05_1300875_LAC;

namespace UnitTest_LegalAmountConverter
{
    [TestClass]
    public class TestLegalAmountConverter
    {
        public LegalAmountConverter lac;

        [TestInitialize]
        public void initialize()
        {
            char defaultLanguage = 'E';
            lac = new LegalAmountConverter(defaultLanguage);
        }

        [TestMethod]
        public void setAmount_setValidAmount_AmountAccepted()
        {
            string amount = "0.01";
            string expected = "0.01";

            
            lac.setAmount(amount);
            Assert.AreEqual(expected, lac.Amount);
        }

        [TestMethod]
        public void constructor_createEnglishConverter_passTest()
        {
            char language = 'E';
            bool detector = false;

            LegalAmountConverter legalAmountConverter = new LegalAmountConverter(language);

            if (legalAmountConverter.Converter.GetType() == typeof(EnglishConverter))
                detector = true;

            Assert.AreEqual(true, detector);
        }

        [TestMethod]
        public void setLanguage_selectEnglish_EnglishSelected()
        {
            char language = 'E';
            string expected = "English";

            lac.setLanguage(language);

            Assert.AreEqual(expected, lac.Language);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeAmountException))]
        public void setAmount_NegativeValue_ThrowException()
        {
            string amount = "-0.99";

            lac.setAmount(amount);
        }

        [TestMethod]
        [ExpectedException(typeof(AmountExceedLimitException))]
        public void setAmount_greaterThanMillion_ThrowException()
        {
            string amount = "1000000.01";

            lac.setAmount(amount);
        }

        [TestMethod]
        public void englishConvertAmount_validAmount_passTest()
        {
            string amount = "100.01";
            char language = 'E';
            string expected = "ONE HUNDRED AND CENT ONE ONLY";
            lac = new LegalAmountConverter(language);
            lac.setAmount(amount);
            lac.setLanguage(language);

            string result = lac.convertAmount();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void englishConvertAmount_oneMillion_passTest()
        {
            string amount = "1000000";
            char language = 'E';
            string expected = "ONE MILLION ONLY";
            lac = new LegalAmountConverter(language);
            lac.setAmount(amount);
            lac.setLanguage(language);

            string result = lac.convertAmount();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void englishConvertAmount_zero_passTest()
        {
            string amount = "0";
            char language = 'E';
            string expected = "ZERO ONLY";
            lac = new LegalAmountConverter(language);
            lac.setAmount(amount);
            lac.setLanguage(language);

            string result = lac.convertAmount();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void englishConvertDigit_validAmount_passTest()
        {
            string amount = "123456.78";
            char language = 'E';
            int index = 2;
            string expected = "THREE ";
            lac = new LegalAmountConverter(language);
            lac.setAmount(amount);
            lac.setLanguage(language);
            char [] array = lac.Amount.ToCharArray();

            string result = lac.Converter.convertDigit(array, index);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void englishConvertTenDigit_validAmount_passTest()
        {
            string amount = "123456.78";
            char language = 'E';
            int index = 1;
            string expected = "TWENTY ";
            lac = new LegalAmountConverter(language);
            lac.setAmount(amount);
            lac.setLanguage(language);
            char[] array = lac.Amount.ToCharArray();

            string result = lac.Converter.convertTenDigit(array, index);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void englishConvert10To19_validAmount_passTest()
        {
            string amount = "213456.78";
            char language = 'E';
            int index = 1;
            string expected = "THIRTEEN ";
            lac = new LegalAmountConverter(language);
            lac.setAmount(amount);
            lac.setLanguage(language);
            char[] array = lac.Amount.ToCharArray();

            string result = lac.Converter.convert10To19(array, index);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void bahasaMalaysiaConvertAmount_validAmount_passTest()
        {
            string amount = "100.01";
            char language = 'M';
            string expected = "SATU RATUS DAN SEN SATU SAHAJA";
            lac = new LegalAmountConverter(language);
            lac.setAmount(amount);
            lac.setLanguage(language);

            string result = lac.convertAmount();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void bahasaMalaysiaConvertAmount_oneMillion_passTest()
        {
            string amount = "1000000";
            char language = 'M';
            string expected = "SATU JUTA SAHAJA";
            lac = new LegalAmountConverter(language);
            lac.setAmount(amount);
            lac.setLanguage(language);

            string result = lac.convertAmount();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void bahasaMalaysiaConvertAmount_zero_passTest()
        {
            string amount = "0";
            char language = 'M';
            string expected = "KOSONG SAHAJA";
            lac = new LegalAmountConverter(language);
            lac.setAmount(amount);
            lac.setLanguage(language);

            string result = lac.convertAmount();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void bahasaMalaysiaConvertDigit_validAmount_passTest()
        {
            string amount = "123456.78";
            char language = 'M';
            int index = 2;
            string expected = "TIGA ";
            lac = new LegalAmountConverter(language);
            lac.setAmount(amount);
            lac.setLanguage(language);
            char[] array = lac.Amount.ToCharArray();

            string result = lac.Converter.convertDigit(array, index);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void bahasaMalaysiaConvertTenDigit_validAmount_passTest()
        {
            string amount = "123456.78";
            char language = 'M';
            int index = 1;
            string expected = "DUA PULUH ";
            lac = new LegalAmountConverter(language);
            lac.setAmount(amount);
            lac.setLanguage(language);
            char[] array = lac.Amount.ToCharArray();

            string result = lac.Converter.convertTenDigit(array, index);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void bahasaMalaysiaConvert10To19_validAmount_passTest()
        {
            string amount = "213456.78";
            char language = 'M';
            int index = 1;
            string expected = "TIGA BELAS ";
            lac = new LegalAmountConverter(language);
            lac.setAmount(amount);
            lac.setLanguage(language);
            char[] array = lac.Amount.ToCharArray();

            string result = lac.Converter.convert10To19(array, index);

            Assert.AreEqual(expected, result);
        }
    }
}
