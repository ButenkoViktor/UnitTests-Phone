using ClassLibrary;
namespace UnitTestPhone
{
    [TestClass]
    public sealed class Test1
    {
        /// Test 1 **Lab** 
        [TestClass]
        public class TestPhone
        {
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
        }
    }
}

