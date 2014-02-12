namespace Students.Common
{
    using System;

    public class Person
    {
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public byte? Age { get; private set; }

        public Person(string firstName, string middleName, string lastName)
            : this(firstName, middleName, lastName, null)
        {
        }

        public Person(string firstName, string middleName, string lastName, byte? age)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Age = age;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1} {2}"
                , this.FirstName, this.MiddleName, this.LastName)
                + "\nAge: " + (this.Age == null ? "not specified" : this.Age.ToString());
        }
    }
}
