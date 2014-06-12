namespace School.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School.Common;
    
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolConstructorTest()
        {
            var name = "Polk High School";
            var courses = new List<Course>()
            {
                new Course("Mathematics")
            };

            var school = new School(name, courses);

            Assert.AreEqual(name, school.Name);
            Assert.AreEqual(courses, school.Courses);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolNameValidationIfIsNullTest()
        {
            var school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolNameValidationIfIsWhiteSpaceTest()
        {
            var school = new School("     ");
        }

        [TestMethod]
        public void AddCourseToSchoolTest()
        {
            var school = new School("Polk High");
            var expectedCoursesCount = school.Courses.Count + 1;
            school.AddCourse(new Course("English"));

            Assert.AreEqual(expectedCoursesCount, school.Courses.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetSchoolCoursesToNullTest()
        {
            var school = new School("Polk High", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullValueToAddCourseToSchoolMethod()
        {
            var school = new School("Polk High");
            school.AddCourse(null);
        }
    }
}
