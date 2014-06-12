namespace Courses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string courseName;
        private string teacherName;
        private ICollection<string> students;

        protected Course(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        protected Course(string courseName, string teacherName, ICollection<string> students)
        {
            this.CourseName = courseName;
            this.TeacherName = teacherName;
            this.students = students;
        }
        
        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Provided course name can't be blank or whitespace.");
                }

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                this.teacherName = value;
            }
        }

        public ICollection<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append("LocalCourse { Name = ");
            output.Append(this.CourseName);

            if (!string.IsNullOrWhiteSpace(this.TeacherName))
            {
                output.Append("; Teacher = ");
                output.Append(this.TeacherName);
            }

            output.Append("; Students = ");
            output.Append(this.GetStudentsAsString());

            return output.ToString();
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }

            var output = new StringBuilder();

            output.Append("{");
            output.Append(string.Join(", ", this.Students));
            output.Append("}");

            return output.ToString();
        }
    }
}
