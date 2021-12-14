using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseWork_BLL_;

namespace Unemployed_TESTs
{
    [TestClass]
    public class Unemployed_Tests
    {
        [TestMethod]
        public void Test_Return_Firstname()
        {
            //Arrange
            string firstname = "Alex";
            string expected = "Alex";
            //Act
            Unemployed unemployed = new Unemployed(firstname, "TEST", "+TEST");
            //Assert
            string actual = unemployed.Firstname;
            Assert.AreEqual(expected, actual, "Firstname doesnt return right");
        }
        [TestMethod]
        public void Test_Return_Lastname()
        {
            //Arrange
            string lastname = "Orstor";
            string expected = "Orstor";
            //Act
            Unemployed unemployed = new Unemployed("TEST", lastname, "TEST");
            //Assert
            string actual = unemployed.Lastname;
            Assert.AreEqual(expected, actual, "Lastname doesnt return right");
        }
        [TestMethod]
        public void Test_Return_Phone()
        {
            //Arrange
            string phone = "+380931214765";
            string expected = "+380931214765";
            //Act
            Unemployed unemployed = new Unemployed("TEST", "TEST", phone);
            //Assert
            string actual = unemployed.Phone;
            Assert.AreEqual(expected, actual, "Phone doesnt return right");
        }
    }
}
