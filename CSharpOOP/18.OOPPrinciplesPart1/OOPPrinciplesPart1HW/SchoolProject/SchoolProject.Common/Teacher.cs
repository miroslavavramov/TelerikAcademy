namespace SchoolProject.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Teacher
        : Person, ICommentable
    {
        public List<Discipline> Disciplines { get; private set; }
        public List<string> Comments { get; set; }

        public Teacher(string firstName, string lastName)
            : this(firstName, lastName, new List<Discipline>(), null)
        {
        }
        public Teacher(string firstName, string lastName, params string[] comments)
            : this(firstName, lastName, new List<Discipline>(), comments)
        {
        }
        public Teacher(string firstName, string lastName, List<Discipline> disciplines, params string[] comments)
            : base(firstName, lastName)
        {
            this.Disciplines = disciplines;

            this.Comments = new List<string>();
            if (comments != null) AddComment(comments);
        }

        public void AddDiscipline(params Discipline[] disciplines)
        {
            foreach (var discipline in disciplines)
                this.Disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.Disciplines.Remove(discipline);
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
            var output = new StringBuilder(this.FirstName + " " + this.LastName);

            if (this.Disciplines.Count != 0)
            {
                output.AppendFormat("\n #Disciplines: {0}", string.Join(", ", this.Disciplines));
            }
            
            if (this.Comments.Count != 0)
            {
                output.AppendFormat("\n #Comments: {0}", string.Join(", ", this.Comments));
            }

            return output.ToString();
        }
    }
}
