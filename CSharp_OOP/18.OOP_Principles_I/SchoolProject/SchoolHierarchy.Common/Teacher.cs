namespace SchoolHierarchy.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Teacher
        : Person, ICommentable
    {
        private List<Discipline> disciplines = new List<Discipline>();
        private string comment = String.Empty;
        public List<Discipline> Disciplines 
        {
            get { return this.disciplines; }
            set { this.disciplines = value; }
        }
        public string Comments 
        {
            get { return this.comment; }
            set { this.comment = value; } 
        }
 
        public Teacher(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }
        public Teacher(string firstName, string lastName, string comment)
            : this(firstName, lastName, new List<Discipline>(), comment)
        {
        }
        public Teacher(string firstName, string lastName, List<Discipline> disciplines, string comment)
            : this(firstName, lastName)
        {
            this.Disciplines = disciplines;
            this.Comments = comment;
        }

        public void AddDiscipline(params Discipline[] disciplines)
        {
            foreach (var discipline in disciplines)
            {
                this.Disciplines.Add(discipline);
            }
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.Disciplines.Remove(discipline);
        }

        public void ClearDisciplines()
        {
            this.Disciplines.Clear();
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
            var output = new StringBuilder(this.FirstName + " " + this.LastName);

            if (!this.Comments.Equals(String.Empty))
            {
                output.AppendFormat(" ({0})", this.Comments);
            }
            if (this.Disciplines.Count != 0)
            {
                output.Append("\n #Disciplines : "  + String.Join(", ", this.Disciplines));
            }

            return output.ToString();
        }
    }
}