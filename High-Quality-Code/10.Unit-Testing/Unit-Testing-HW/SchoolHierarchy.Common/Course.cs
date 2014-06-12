namespace School.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Course
    {
        private const int MaxStudentsCount = 30;

        private string name;
        private IList<Student> students;

        public Course(string name)
            : this(name, new List<Student>())
        {
        }

        public Course(string name, IList<Student> students)
        {
            this.Name = name;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Course name can't be empty or white space.");
                }

                this.name = value;
            }
        }

        public IList<Student> Students
        {
            get
            {
                return this.students;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Course students can't be of null value");
                }

                if (value.Count > MaxStudentsCount)
                {
                    throw new ArgumentOutOfRangeException("Course can't have more than the allowed maximum number of students.");
                }

                this.students = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Can't enroll student with value of null.");
            }

            if (this.Students.Count == MaxStudentsCount)
            {
                throw new InvalidOperationException("The number of students can't exceed course's specified maximum.");
            }

            if(this.Students.Any(x => x.UniqueNumber == student.UniqueNumber))
            {
                throw new InvalidOperationException("No students with duplicate unique numbers allowed in single course.");
            }

            this.Students.Add(student);
        }

        public void RemoveStudentByUniqueNumber(int uniqueNumber)
        {
            //Will throw InvalidOperationException if student not found
            var studentToRemove = this.Students.First(x => x.UniqueNumber == uniqueNumber);

            this.Students.Remove(studentToRemove);
        }
    }
}
