using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseWork_BLL_;

namespace Vacancy_TESTs
{
    [TestClass]
    public class Vacancy_Tests
    {
        [TestMethod]
        public void Test_Return_CategoryOfWork()
        {
            //Arrange
            Customer customer = new Customer("Alex", "Orston", "+380931214765");
            string categoryOfWork = "IT";
            int experience = 1;
            int desirableSalary = 15000;
            bool isDistance = true;
            bool isCarrerGrowth = true;
            string additionalInfo = "Nothing";

            string expected = "IT";
            //Act
            Vacancy resume = new Vacancy(customer, categoryOfWork, experience, desirableSalary, isDistance, isCarrerGrowth, additionalInfo);
            //Assert
            string actual = resume.CategoryOfWork;
            Assert.AreEqual(expected, actual, "CategoryOfWork return doesnt right");
        }
        [TestMethod]
        public void Test_Return_Experience()
        {
            //Arrange
            Customer customer = new Customer("Alex", "Orston", "+380931214765");
            string categoryOfWork = "IT";
            int experience = 1;
            int desirableSalary = 15000;
            bool isDistance = true;
            bool isCarrerGrowth = true;
            string additionalInfo = "Nothing";

            int expected = 1;
            //Act
            Vacancy resume = new Vacancy(customer, categoryOfWork, experience, desirableSalary, isDistance, isCarrerGrowth, additionalInfo);
            //Assert
            int actual = resume.Experience;
            Assert.AreEqual(expected, actual, "Experience return doesnt right");
        }
        [TestMethod]
        public void Test_Return_DesirableSalary()
        {
            //Arrange
            Customer customer = new Customer("Alex", "Orston", "+380931214765");
            string categoryOfWork = "IT";
            int experience = 1;
            int desirableSalary = 15000;
            bool isDistance = true;
            bool isCarrerGrowth = true;
            string additionalInfo = "Nothing";

            int expected = 15000;
            //Act
            Vacancy resume = new Vacancy(customer, categoryOfWork, experience, desirableSalary, isDistance, isCarrerGrowth, additionalInfo);
            //Assert
            int actual = resume.DesirableSalary;
            Assert.AreEqual(expected, actual, "Desirable salary return doesnt right");
        }
        [TestMethod]
        public void Test_Return_IsDistance()
        {
            //Arrange
            Customer customer = new Customer("Alex", "Orston", "+380931214765");
            string categoryOfWork = "IT";
            int experience = 1;
            int desirableSalary = 15000;
            bool isDistance = true;
            bool isCarrerGrowth = true;
            string additionalInfo = "Nothing";

            bool expected = true;
            //Act
            Vacancy resume = new Vacancy(customer, categoryOfWork, experience, desirableSalary, isDistance, isCarrerGrowth, additionalInfo);
            //Assert
            bool actual = resume.IsDistance;
            Assert.AreEqual(expected, actual, "Distance return doesnt right");
        }
        [TestMethod]
        public void Test_Return_IsCarrerGrowth()
        {
            //Arrange
            Customer customer = new Customer("Alex", "Orston", "+380931214765");
            string categoryOfWork = "IT";
            int experience = 1;
            int desirableSalary = 15000;
            bool isDistance = true;
            bool isCarrerGrowth = true;
            string additionalInfo = "Nothing";

            bool expected = true;
            //Act
            Vacancy resume = new Vacancy(customer, categoryOfWork, experience, desirableSalary, isDistance, isCarrerGrowth, additionalInfo);
            //Assert
            bool actual = resume.IsCarrerGrowth;
            Assert.AreEqual(expected, actual, "Carrer growth return doesnt right");
        }
        [TestMethod]
        public void Test_Return_AdditionalInfo()
        {
            //Arrange
            Customer customer = new Customer("Alex", "Orston", "+380931214765");
            string categoryOfWork = "IT";
            int experience = 1;
            int desirableSalary = 15000;
            bool isDistance = true;
            bool isCarrerGrowth = true;
            string additionalInfo = "Nothing";

            string expected = "Nothing";
            //Act
            Vacancy resume = new Vacancy(customer, categoryOfWork, experience, desirableSalary, isDistance, isCarrerGrowth, additionalInfo);
            //Assert
            string actual = resume.AdditionalInfo;
            Assert.AreEqual(expected, actual, "Additional info return doesnt right");
        }
        [TestMethod]
        public void Test_Return_Customer()
        {
            //Arrange
            Customer customer = new Customer("Alex", "Orston", "+380931214765");
            string categoryOfWork = "IT";
            int experience = 1;
            int desirableSalary = 15000;
            bool isDistance = true;
            bool isCarrerGrowth = true;
            string additionalInfo = "Nothing";
            //Act
            Vacancy resume = new Vacancy(customer, categoryOfWork, experience, desirableSalary, isDistance, isCarrerGrowth, additionalInfo);
            //Assert
            Assert.IsNotNull(resume.Customer, "Customer doesnt return");
        }
    }
}
