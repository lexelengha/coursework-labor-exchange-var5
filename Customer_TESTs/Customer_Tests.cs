using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseWork_BLL_;

namespace Customer_TESTs
{
    [TestClass]
    public class Customer_Tests
    {
        [TestMethod]
        public void Test_Return_Firstname()
        {
            //Arrange
            string firstname = "Alex";
            string expected = "Alex";
            //Act
            Customer customer = new Customer(firstname, "TEST", "+TEST");
            //Assert
            string actual = customer.Firstname;
            Assert.AreEqual(expected, actual, "Firstname doesnt return right");
        }
        [TestMethod]
        public void Test_Return_Lastname()
        {
            //Arrange
            string lastname = "Orstor";
            string expected = "Orstor";
            //Act
            Customer customer = new Customer("TEST", lastname, "TEST");
            //Assert
            string actual = customer.Lastname;
            Assert.AreEqual(expected, actual, "Lastname doesnt return right");
        }
        [TestMethod]
        public void Test_Return_Phone()
        {
            //Arrange
            string phone = "+380931214765";
            string expected = "+380931214765";
            //Act
            Customer customer = new Customer("TEST", "TEST", phone);
            //Assert
            string actual = customer.Phone;
            Assert.AreEqual(expected, actual, "Phone doesnt return right");
        }
    }
}

