using ClassLibrary;
namespace UnitTestPhone
{
    [TestClass]
    public class TestPhone
    {
        /// Test 1 **Lab** 
        [TestMethod]
        public void Test_konstruktor_dane_poprawne_Działanie_ok()
        {
            ///AAA
            ///Arrange
            var wlasciciel = "Butenko";
            var numerTelefonu = "123456789";
            ///act
            var phone = new Phone(wlasciciel, numerTelefonu);

            ///assert
            Assert.AreEqual(wlasciciel, phone.Owner);
            Assert.AreEqual(numerTelefonu, phone.PhoneNumber);
        }

        /// Test 2 **Sprawdza, czy konstruktor rzuca wyjątek, gdy właściciel jest null.**"
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_konstruktor_wlasciciel_null()
        {
            ///AAA
            ///Arrange
            var numerTelefonu = "123456789";
            ///act
            var phone = new Phone(null, numerTelefonu);
        }

        /// Test 3 **Sprawdza, czy konstruktor rzuca wyjątek, gdy numer telefonu jest nieprawidłowy.**
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Konstruktor_NieprawidlowyNumerTelefonu()
        {
            ///AAA
            ///Arrange
            var wlasciciel = "Butenko";
            var numerTelefonu = "12345678";
            ///act
            var phone = new Phone(wlasciciel, numerTelefonu);
        }



    }
}

