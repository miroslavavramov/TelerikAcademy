namespace Methods
{
    using System;
    using System.Linq;
    using System.Text;

    public class Student
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 30;

        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private string hometown;
        private string additionalInfo;

        public Student(string firstName, string lastName, DateTime birthDate, string hometown, string info = null) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Hometown = hometown;
            this.AdditionalInfo = info;
        }

        public string FirstName 
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (!this.IsValidName(value))
                {
                    throw new ArgumentOutOfRangeException("Name either contains invalid characters or has invalid length.");
                }

                this.firstName = value;
            }
        }

        public string LastName 
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (!this.IsValidName(value))
                {
                    throw new ArgumentOutOfRangeException("Name either contains invalid characters or has invalid length.");
                }

                this.lastName = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }

            set 
            {
                this.birthDate = value;
            } 
        }

        public string Hometown
        {
            get
            {
                return this.hometown;
            }

            set
            {
                if (!this.IsValidName(value))
                {
                    throw new ArgumentOutOfRangeException("Name either contains invalid characters or has invalid length.");
                }

                this.hometown = value;
            }
        }

        public string AdditionalInfo
        {
            get
            {
                return this.additionalInfo;
            }

            set
            {
                this.additionalInfo = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            if (other.Equals(null))
            {
                throw new ArgumentNullException("Student can't consist of null value.");
            }

            return this.BirthDate < other.BirthDate;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("{0} {1} ", this.FirstName, this.LastName);
            output.AppendLine(this.BirthDate.ToShortDateString());
            output.AppendLine(this.Hometown);
            output.AppendLine(this.additionalInfo);

            return output.ToString();
        }

        private bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            if (name.Any(x => !char.IsLetter(x)))
            {
                return false;
            }

            if (name.Length < MinNameLength)
            {
                return false;
            }

            if (name.Length > MaxNameLength)
            {
                return false;
            }

            return true;
        }
    }
}