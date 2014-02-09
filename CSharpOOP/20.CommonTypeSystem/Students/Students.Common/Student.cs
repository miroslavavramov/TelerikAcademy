namespace Students.Common
{
    using System;
    using System.Text;

    public class Student
        : Person, ICloneable, IComparable<Student>
    {
        public string SocialSecurityNumber { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string EMail { get; private set; }
        public byte Course { get; private set; }
        public Major Major { get; private set; }
        public Faculty Faculty { get; private set; }
        public University University { get; private set; }

        public Student(string firstName, string middleName, string lastName)
            : base(firstName, middleName, lastName, null)
        { 
        }

        public Student(
            string firstName, string middleName, string lastName, byte? age,
            string socialSecurityNumber, string address, string phoneNumber, string eMail, byte course,
            Major major, Faculty faculty, University university)
            : base(firstName, middleName, lastName, age)
        {
            this.SocialSecurityNumber = socialSecurityNumber;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.EMail = eMail;
            this.Course = course;
            this.Major = major;
            this.Faculty = faculty;
            this.University = university;
        }

        public override string ToString()
        {
            if (this.SocialSecurityNumber == null)
            {
                return base.ToString();
            }
            return new StringBuilder()
                .AppendLine(base.ToString())
                .AppendLine(string.Format("SSN: {0}", this.SocialSecurityNumber))
                .AppendLine(string.Format("Address: {0}", this.Address))
                .AppendLine(string.Format("Phone: {0}", this.PhoneNumber))
                .AppendLine(string.Format("Email: {0}", this.EMail))
                .AppendLine(string.Format("University: {0}", this.University))
                .AppendLine(string.Format("Faculty: {0}", this.Faculty))
                .AppendLine(string.Format("Major: {0}", this.Major))
                .AppendLine(string.Format("Course: {0}", this.Course))
                .ToString();

        }

        public override bool Equals(object obj)
        {
            return this.SocialSecurityNumber == (obj as Student).SocialSecurityNumber;
        }

        public override int GetHashCode()
        {
            return this.SocialSecurityNumber.GetHashCode();
        }

        public static bool operator == (Student s1, Student s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator != (Student s1, Student s2)
        {
            return !s1.Equals(s2);
        }

        public object Clone()
        {
            return new Student(
                this.FirstName, this.MiddleName, this.LastName, this.Age,
                this.SocialSecurityNumber, this.Address,
                this.PhoneNumber, this.EMail, this.Course,
                this.Major, this.Faculty, this.University 
            );
        }

        public int CompareTo(Student student)
        {
            if (this.FirstName.CompareTo(student.FirstName) != 0)
            {
                return this.FirstName.CompareTo(student.FirstName);
            }
            else if (this.MiddleName.CompareTo(student.MiddleName) != 0)
            {
                return this.MiddleName.CompareTo(student.MiddleName);
            }
            else if (this.LastName.CompareTo(student.LastName) != 0)
            {
                return this.LastName.CompareTo(student.LastName);
            }

            return this.SocialSecurityNumber.CompareTo(student.SocialSecurityNumber);
        }   
    }
}
