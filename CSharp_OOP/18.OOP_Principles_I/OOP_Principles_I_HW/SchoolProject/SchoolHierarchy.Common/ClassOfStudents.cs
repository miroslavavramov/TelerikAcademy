namespace SchoolHierarchy.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class ClassOfStudents 
        : ICommentable
    {
        private string comments = String.Empty;

        public List<Teacher> Teachers { get; private set; }
        public List<Student> Students { get; private set; }
        public string ClassID { get; private set; }
        public string Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public ClassOfStudents(string classId)
            : this(classId, new List<Teacher>(), new List<Student>(), String.Empty)
        {
        }
        public ClassOfStudents(string classId, string comment)
            : this(classId, new List<Teacher>(), new List<Student>(), comment)
        {
        }
        public ClassOfStudents(string classId, List<Teacher> teachers, List<Student> students, string comment)
        {
            this.ClassID = classId;
            this.Teachers = teachers;
            this.Students = students;
            this.Comments = comment;
        }

        public void AddTeacher(params Teacher[] teachers)
        {
            foreach (var teacher in teachers)
                this.Teachers.Add(teacher);    
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.Teachers.Remove(teacher);
        }

        public void ClearTeachers()
        {
            this.Teachers.Clear();
        }

        public void AddStudent(params Student[] students)
        {
            foreach (var student in students)
                this.Students.Add(student);   
        }

        public void RemoveStudent(Student student)
        {
            this.Students.Remove(student);
        }

        public void ClearStudents()
        {
            this.Students.Clear();
        }

        public void AddComment(string comment)
        {
            this.Comments = new StringBuilder(this.Comments)
                .Append("; " + comment).ToString();
        }

        public void ClearComments()
        {
            this.Comments = String.Empty;
        }

        public override string ToString()
        {
            var output = new StringBuilder("Class : " + this.ClassID);

            if (!this.Comments.Equals(String.Empty))
            {
                output.AppendFormat(" ({0})", this.Comments);
            }

            output.AppendLine("\n\nTeachers : ");
            if (this.Teachers.Count == 0)
            {
                output.AppendLine("No teachers to show.");
            }
            else
            {
                foreach (var teacher in this.Teachers)
                    output.AppendLine("-" + teacher.ToString());
            }
            

            output.AppendLine("\nStudents : ");
            if (this.Students.Count == 0)
            {
                output.AppendLine("No students to show.");
            }
            else
            {
                foreach (var student in this.Students)
                    output.AppendLine("-"+student.ToString());
            }
            
            return output.ToString();
        }
    }
}
