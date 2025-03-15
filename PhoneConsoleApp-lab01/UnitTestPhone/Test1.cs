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

        // Test 4: Sprawdza, czy metoda AddContact dodaje kontakt poprawnie
        [TestMethod]
        public void Test_AddContact_PoprawneDodanie()
        {
            ///AAA
            ///Arrange
            var phone = new Phone("Butenko", "123456789");

            ///Act
            var result = phone.AddContact("Jan", "987654321");

            ///Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, phone.Count);
        }

        /// Test 5 **Sprawdza, czy metoda AddContact rzuca wyjątek, gdy książka telefoniczna jest pełna.**
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_AddContact_ksiazka_pelna()
        {
            ///AAA
            ///Arrange
            var phone = new Phone("Butenko", "123456789");
            for (int i = 0; i < phone.PhoneBookCapacity; i++)
            {
                phone.AddContact($"Kontakt{i}", $"12345678{i % 10}");
            }
            ///act
            phone.AddContact("Nowy Kontakt", "987654321");
        }

    }
}

