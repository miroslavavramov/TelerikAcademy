namespace People.Common
{
    using System;

    public class Student
        : Human
    {
        private double? grade;

        public double? Grade
        {
            get { return this.grade; }
            set
            {
                if (value != null)
                {
                    if (!(value >= 2 && value <= 6))
                    {
                        throw new ArgumentOutOfRangeException("Grade can't be less than 2 or greater than 6!");
                    }
                }
                this.grade = value;
            }
        }

        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }
        public Student(string firstName, string lastName, double? grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} | Grade : {2:F2}", this.FirstName, this.LastName, this.Grade);
        }
    }

}