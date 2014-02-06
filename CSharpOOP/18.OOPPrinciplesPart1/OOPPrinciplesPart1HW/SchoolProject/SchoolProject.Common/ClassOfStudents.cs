namespace SchoolProject.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ClassOfStudents
        : ICommentable
    {
        public string ClassID { get; private set; }
        public List<Teacher> Teachers { get; private set; }
        public List<Student> Students { get; private set; }
        public List<string> Comments { get; set; }

        public ClassOfStudents(string classId)
            : this(classId, new List<Teacher>(), new List<Student>(), null)
        {
        }
        public ClassOfStudents(string classId, params string[] comments) 
            : this(classId, new List<Teacher>(), new List<Student>(), comments)
        {
        }
        public ClassOfStudents(string classId, List<Teacher> teachers, List<Student> students, params string[] comments)
        {
            this.ClassID = classId;
            this.Teachers = teachers;
            this.Students = students;

            this.Comments = new List<string>();

            if (comments != null) AddComment(comments);
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

        public void AddStudent(params Student[] students)
        {
            foreach (var student in students)
                this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            this.Students.Remove(student);
        }

        public void AddComment(params string[] comments)
        {
            foreach (var comment in comments)
            {
                this.Comments.Add(comment);
            }
        }
		
        public override string ToString()
        {
            var output = new StringBuilder("Class : " + this.ClassID);

            if(this.Comments.Count != 0)
            {
                output.AppendFormat("\n #Comments: {0}", string.Join(", ", this.Comments));
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
                    output.AppendLine("-" + student.ToString());
            }

            return output.ToString();
        }
    }
}
