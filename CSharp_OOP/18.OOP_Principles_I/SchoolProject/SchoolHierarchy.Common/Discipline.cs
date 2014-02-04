namespace SchoolHierarchy.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Discipline 
        : ICommentable
    {
        private byte lectures;
        private byte exercises;

        public string Name { get; private set; }
        public string Comments { get; set; }
        public byte Lectures 
        {
            get { return this.lectures; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Lectures can't be a negative number!");
                this.lectures = value;
            }
        }
        public byte Exercises
        {
            get { return this.exercises; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Exercises can't be a negative number!");
                this.exercises = value;
            }
        }

        public Discipline(string name)
            : this(name, 2, 2, String.Empty)
        {
        }
        public Discipline(string name, string comment)
            : this(name, 2, 2, comment)
        {
        }
        public Discipline(string name, byte lectures, byte exercises)
            : this(name, lectures, exercises, String.Empty)
        {
        }
        public Discipline(string name, byte lectures, byte exercises, string comment)
        {
            this.Name = name;
            this.Lectures = lectures;
            this.Exercises = exercises;
            this.Comments = comment;
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
            var output = new StringBuilder(String.Format("{0}(L:{1} E:{2})", this.Name, this.Lectures, this.Exercises));

            if (this.Comments.Equals(String.Empty))
            {
                return output.ToString();
            }

            return output.AppendFormat(" ({0})", this.Comments).ToString();
        }
    }
}
