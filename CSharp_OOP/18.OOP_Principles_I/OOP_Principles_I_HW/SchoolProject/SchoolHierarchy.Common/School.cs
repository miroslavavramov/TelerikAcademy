namespace SchoolHierarchy.Common
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        public string SchoolName { get; private set; }
        public List<ClassOfStudents> Classes { get; private set; }

        public School(string schoolName)
        {
            this.SchoolName = schoolName;
            this.Classes = new List<ClassOfStudents>();
        }

        public void AddClass(params ClassOfStudents[] classesOfStudents)
        {
            foreach (var classOfStudents in classesOfStudents)
                this.Classes.Add(classOfStudents);   
        }

        public void RemoveClass(ClassOfStudents classOfStudents)
        {
            this.Classes.Remove(classOfStudents);
        }

        public void ClearClasses()
        {
            this.Classes.Clear();
        }
    }
}
