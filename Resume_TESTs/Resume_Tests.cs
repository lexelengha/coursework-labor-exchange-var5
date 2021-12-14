using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseWork_BLL_;

namespace Resume_TESTs
{
    [TestClass]
    public class Resume_Tests
    {
        [TestMethod]
        public void Test_Return_CategoryOfWork()
        {
            //Arrange
            Unemployed unemployed = new Unemployed("Alex", "Orston", "+380931214765");
            string categoryOfWork = "IT";
            int experience = 1;
            int desirableSalary = 15000;
            string additionalInfo = "Nothing";

            string expected = "IT";
            //Act
            Resume resume = new Resume(unemployed, categoryOfWork, experience, desirableSalary, additionalInfo);
            //Assert
            string actual = resume.CategoryOfWork;

            Assert.AreEqual(expected, actual, "CategoryOfWork doesnt return right");
        }
        [TestMethod]
        public void Test_Return_Experience()
        {
            //Arrange
            Unemployed unemployed = new Unemployed("Alex", "Orston", "+380931214765");
            string categoryOfWork = "IT";
            int experience = 1;
            int desirableSalary = 15000;
            string additionalInfo = "Nothing";

            int expected = 1;
            //Act
            Resume resume = new Resume(unemployed, categoryOfWork, experience, desirableSalary, additionalInfo);
            //Assert
            int actual = resume.Experience;

            Assert.AreEqual(expected, actual, "Experience doesnt return right");
        }
        [TestMethod]
        public void Test_Return_DesirableSalary()
        {
            //Arrange
            Unemployed unemployed = new Unemployed("Alex", "Orston", "+380931214765");
            string categoryOfWork = "IT";
            int experience = 1;
            int desirableSalary = 15000;
            string additionalInfo = "Nothing";

            int expected = 15000;
            //Act
            Resume resume = new Resume(unemployed, categoryOfWork, experience, desirableSalary, additionalInfo);
            //Assert
            int actual = resume.DesirableSalary;

            Assert.AreEqual(expected, actual, "Desirable salary doesnt return right");
        }
        [TestMethod]
        public void Test_Return_AdditionalInfo()
        {
            //Arrange
            Unemployed unemployed = new Unemployed("Alex", "Orston", "+380931214765");
            string categoryOfWork = "IT";
            int experience = 1;
            int desirableSalary = 15000;
            string additionalInfo = "Nothing";

            string expected = "Nothing";
            //Act
            Resume resume = new Resume(unemployed, categoryOfWork, experience, desirableSalary, additionalInfo);
            //Assert
            string actual = resume.AdditionalInfo;

            Assert.AreEqual(expected, actual, "Additional info doesnt return right");
        }
        [TestMethod]
        public void Test_Return_Unemployed()
        {
            //Arrange
            Unemployed unemployed = new Unemployed("Alex", "Orston", "+380931214765");
            string categoryOfWork = "IT";
            int experience = 1;
            int desirableSalary = 15000;
            string additionalInfo = "Nothing";
            //Act
            Resume resume = new Resume(unemployed, categoryOfWork, experience, desirableSalary, additionalInfo);
            //Assert
            Assert.IsNotNull(resume.Unemployed, "Unemployed doesnt exist");
        }
    }
}
