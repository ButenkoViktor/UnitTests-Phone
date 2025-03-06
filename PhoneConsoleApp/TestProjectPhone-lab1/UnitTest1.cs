using ClassLibrary;


namespace TestProjectPhone_lab1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Konstruktor_Dan_poprawne_Dia³amie_OK()
        {
            //AA

            //Arrange
            var wlasciciel = "Molenda";
            var numerTelefonu = "123456789";
            //Act
            var phone = new Phone(wlasciciel, numerTelefonu);
            //Assert
            Assert.AreEqual(wlasciciel, phone.Owner);
            Assert.AreEqual(numerTelefonu, phone.PhoneNumber);
        }
    }
}