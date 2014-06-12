namespace Courses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name)
            : this(name, null)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set 
            {
                this.town = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());

            if (!string.IsNullOrEmpty(this.Town))
            {
                output.Append("; Town = ");
                output.Append(this.Town);
            }

            return output.ToString();
        }
    }
}
