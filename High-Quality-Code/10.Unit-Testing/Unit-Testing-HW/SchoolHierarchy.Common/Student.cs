namespace School.Common
{
    using System;
    
    public class Student
    {
        private string name;
        private int uniqueNumber;

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
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
                    throw new ArgumentException("Student's name can't be empty or white space.");
                }

                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }

            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("Student unique number must be between 10000 and 99999");
                }

                this.uniqueNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.UniqueNumber, this.Name);
        }
    }
}
