namespace Students
{
    using System;
    using System.Collections.Generic;

    class Student
    {
        public string FirstName { get; private set; }                   
        public string LastName { get; private set; }
        public string FacultyNumber { get; private set; }
        public string PhoneNumber { get; set; }
        public string EMailAddress { get; set; }
        public Group Group { get; private set; }
        public List<int> Marks { get; private set; }

        public Student(string firstName, string lastName, string facultyNumber, 
            string phoneNumber, string eMailAddress, byte groupNumber, string departmentName, params int[] marks)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNumber;
            this.PhoneNumber = phoneNumber;
            this.EMailAddress = eMailAddress;
            this.Group = new Group(groupNumber, departmentName);

            this.Marks = new List<int>();
            this.AddMark(marks);
        }

        public void AddMark(params int[] marks)
        {
            foreach (var mark in marks)
            {
                this.Marks.Add(mark);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} FN: {2} \n #Tel: {3} Email: {4} \n#Department: {5} #Group: {6} Marks: {7}"
                , this.FirstName, this.LastName, this.FacultyNumber 
                , this.PhoneNumber, this.EMailAddress, this.Group.DepartmentName
                , this.Group.GroupNumber, string.Join(", ",this.Marks));
        }
    }
}
