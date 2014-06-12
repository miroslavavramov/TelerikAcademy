namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School.Common;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void StudentConstructorTest()
        {
            var name = "Tyler Durden";
            var uniqueNumber = 12345;

            var student = new Student(name, uniqueNumber);

            Assert.AreEqual(name, student.Name);
            Assert.AreEqual(uniqueNumber, student.UniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentNameValidationIfIsNullTest()
        {
            var student = new Student(null, 12345);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentNameValidationIfIsWhiteSpaceTest()
        {
            var student = new Student("          ", 12345);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentUniqueNumberValidationIfIsLargerThanMinValueTest()
        {
            var student = new Student("Nico Dietrich", 123456);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentUniqueNumberValidationIfIsLargerThanMaxValueTest()
        {
            var student = new Student("Nico Dietrich", 1234);
        }

        [TestMethod]
        public void StudentToStringTest()
        {
            var student = new Student("Martin Durkin" ,12345);
            var expectedResult = "12345 Martin Durkin";

            Assert.AreEqual(expectedResult, student.ToString());
        }
    }
}
