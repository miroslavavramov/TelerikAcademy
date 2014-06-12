namespace School.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School.Common;
    
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void CourseConstructorTest()
        {
            var courseName = "Biology";
            var students = new List<Student>();
            var biologyCourse = new Course(courseName, students);

            Assert.AreEqual(courseName, biologyCourse.Name);
            Assert.AreEqual(students, biologyCourse.Students);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseNameValidationIfIsNullTest()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseNameValidationIfIsWhiteSpaceTest()
        {
            var course = new Course("     ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseStudentsValidationIfNullTest()
        {
            var course = new Course("History", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CourseStudentsValidationIfCountIsLargenThanAllowedTest()
        {
            var students = new List<Student>();

            for (int i = 0; i < 31; i++)
            {
                students.Add(new Student("Unnamed", i + 10000));
            }

            var course = new Course("Literature", students);
        }

        [TestMethod]
        public void AddStudentToCourseMethodTest()
        {
            var students = new List<Student>() 
            { 
                new Student("Derek Banas", 12345)
            };

            var course = new Course("Literature", students);
            var expectedStudentsCount = course.Students.Count + 1;
            course.AddStudent(new Student("Barny Gumble", 20000));
            
            Assert.AreEqual(expectedStudentsCount, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStudentOfNullValueToCourseMethodTest()
        {
            var course = new Course("Math");
            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddStudentSoStudentCountExceedMaxAllowedToCourseMethodTest()
        {
            var students = new List<Student>();

            for (int i = 0; i < 30; i++)
            {
                students.Add(new Student("Unnamed", i + 10000));
            }

            var course = new Course("Music", students);

            course.AddStudent(new Student("Joe Satriani", 93332));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddStudentsWithDuplicateUniqueNumbersToCourseMethodTest()
        {
            var course = new Course("Sport");
            course.AddStudent(new Student("Alexis Machine", 12345));
            course.AddStudent(new Student("Michael Myers", 12345));
        }

        [TestMethod]
        public void RemoveStudentByUniqueNumberMethodTest()
        {
            var course = new Course("Advanced Potion Making");
            course.AddStudent(new Student("Stanley Kubrick", 12345));
            course.AddStudent(new Student("Maggie Simpson", 13345));

            var expectedStudentsCount = course.Students.Count - 1;
            course.RemoveStudentByUniqueNumber(12345);
            Assert.AreEqual(expectedStudentsCount, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetInvalidValueToRemoveStudentByUniqueNumberMethodTest()
        {
            var course = new Course("Geography");
            course.AddStudent(new Student("Cornelius Fudge", 12345));
            course.AddStudent(new Student("Bilbo Begins", 13345));
            course.RemoveStudentByUniqueNumber(999919);
        }
    }
}
