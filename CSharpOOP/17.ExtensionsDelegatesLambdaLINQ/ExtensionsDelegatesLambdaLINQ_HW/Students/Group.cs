namespace Students
{
    using System;

    class Group //Task 16
    {
        public byte GroupNumber { get; private set; }

        public string DepartmentName { get; private set; }
        
        public Group(byte groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }
    }
}
