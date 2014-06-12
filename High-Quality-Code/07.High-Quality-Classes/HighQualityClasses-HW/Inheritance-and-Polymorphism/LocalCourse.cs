namespace Courses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name)
            : this(name, null)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                this.lab = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());

            if (!string.IsNullOrWhiteSpace(this.Lab))
            {
                output.Append("; Lab = ");
                output.Append(this.Lab);
            }

            output.Append(" }");

            return output.ToString();
        }
    }
}