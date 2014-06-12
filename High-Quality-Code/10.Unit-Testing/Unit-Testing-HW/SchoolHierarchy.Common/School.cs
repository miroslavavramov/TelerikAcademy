namespace School.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class School
    {
        private string name;
        private IList<Course> courses;

        public School(string name)
            :this(name, new List<Course>())
        {
        }

        public School(string name, IList<Course> courses)
        {
            this.Name = name;
            this.Courses = courses;
        }

        public string Name 
        {
            get 
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("School's name can't be empty or white space.");
                }

                this.name = value;
            } 
        }

        public IList<Course> Courses 
        {
            get
            {
                return this.courses;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Course students can't be of null value");
                }

                this.courses = value;
            }
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Can't add course of null value.");
            }

            this.Courses.Add(course);
        }
    }
}
