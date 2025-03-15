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

        /// Test 6 **Sprawdza, czy metoda AddContact dodaje kontakt, gdy książka telefoniczna nie jest pełna.**
        [TestMethod]
        public void Test_AddContact_dodaje_kontakt()
        {
            ///AAA
            ///Arrange
            var phone = new Phone("Butenko", "123456789");
            var wlasciciel = "Jan";
            var numerTelefonu = "987654321";
            ///act
            var result = phone.AddContact(wlasciciel, numerTelefonu);
            ///assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, phone.Count);
        }

        /// Test 7 **Sprawdza, czy metoda Call rzuca wyjątek, gdy kontakt nie istnieje.**
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_Call_kontakt_nie_istnieje()
        {
            ///AAA
            ///Arrange
            var phone = new Phone("Butenko", "123456789");
            ///act
            phone.Call("Nieistniejący Kontakt");
        }

        /// Test 8 **Sprawdza, czy metoda AddContact nie dodaje duplikatu kontaktu.**
        [TestMethod]
        public void Test_AddContact_nie_dodaje_duplikatu()
        {
            ///AAA
            ///Arrange
            var phone = new Phone("Butenko", "123456789");
            var wlasciciel = "Jan";
            var numerTelefonu = "987654321";
            phone.AddContact(wlasciciel, numerTelefonu);
            ///act
            var result = phone.AddContact(wlasciciel, numerTelefonu);
            ///assert
            Assert.IsFalse(result);
            Assert.AreEqual(1, phone.Count);
        }

        /// Test 9 **Sprawdza, czy metoda Call zwraca poprawny komunikat dla różnych kontaktów.**
        [TestMethod]
        public void Test_Call_roznorodne_kontakty()
        {
            ///AAA
            ///Arrange
            var phone = new Phone("Butenko", "123456789");
            var wlasciciel01 = "Jan";
            var numerTelefonu01 = "987654321";
            var wlasciciel02 = "Anna";
            var numerTelefonu02 = "123456789";
            phone.AddContact(wlasciciel01, numerTelefonu01);
            phone.AddContact(wlasciciel02, numerTelefonu02);
            ///act
            var result1 = phone.Call(wlasciciel01);
            var result2 = phone.Call(wlasciciel02);
            ///assert
            Assert.AreEqual($"Calling {numerTelefonu01} ({wlasciciel01}) ...", result1);
            Assert.AreEqual($"Calling {numerTelefonu02} ({wlasciciel02}) ...", result2);
        }

        /// Test 10 **Sprawdza, czy metoda AddContact dodaje kontakt z maksymalną długością nazwy.**
        [TestMethod]
        public void Test_AddContact_maksymalna_dl_nazwy()
        {
            ///AAA
            ///Arrange
            var phone = new Phone("Molenda", "123456789");
            var wlasciciel = new string('A', 100);
            var numerTelefonu = "987654321";
            ///act
            var result = phone.AddContact(wlasciciel, numerTelefonu);
            ///assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, phone.Count);
        }
    }
}

