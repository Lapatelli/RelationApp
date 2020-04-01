using Microsoft.VisualStudio.TestTools.UnitTesting;
using RelationApp.BLL.Services;

namespace RelationApp.Tests
{
    [TestClass]
    public class RelationAddressServiceTest
    {
        private readonly RelationAddressService _relationServiceAddress;

        public RelationAddressServiceTest()
        {
            _relationServiceAddress = new RelationAddressService();
        }

        [TestMethod]
        [DataRow("123456")]
        [DataRow("ABCD1234567890123456890ABCDabcd")]
        [DataRow("789-AbC")]
        [DataRow("abc-PostalCode")]
        public void Test_PostalCodeToPostalCodeFormatWithOneSymbol(string postalCode)
        {
            var postalCodeFormat = ".";

            var actual = _relationServiceAddress.TransormPostalCode(postalCode, postalCodeFormat);

            Assert.AreEqual(postalCode, actual);
        }

        [TestMethod]
        [DataRow("123-ABC")]
        [DataRow("123ABC")]
        [DataRow("123abC")]
        [DataRow("123 AbC")]
        public void Test_PostalCodeToPostalCodeFormatWithDigitAndUpperLetters(string postalCode)
        {
            var postalCodeFormat = "NNN-LLL";

            var actual = _relationServiceAddress.TransormPostalCode(postalCode, postalCodeFormat);

            Assert.AreEqual("123-ABC", actual);
        }

        [TestMethod]
        [DataRow("Abc-D")]
        [DataRow("ABCD")]
        [DataRow("ABC-D")]
        [DataRow("aBC?D")]
        public void Test_PostalCodeToPostalCodeFormatWithLowerAndUpperLetters(string postalCode)
        {
            var postalCodeFormat = "Lll-L";

            var actual = _relationServiceAddress.TransormPostalCode(postalCode, postalCodeFormat);

            Assert.AreEqual("Abc-D", actual);
        }

        [TestMethod]
        [DataRow("12?aB")]
        public void Test_PostalCodeToIncorrectPostalCodeFormat(string postalCode)
        {
            var postalCodeFormat = "NN?LL-";

            var actual = _relationServiceAddress.TransormPostalCode(postalCode, postalCodeFormat);

            Assert.AreEqual("12?aB", actual);
        }
    }
}
