namespace SchoolProject.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student 
        : Person, ICommentable
    {
        private byte? classNumber;
        
        public byte? ClassNumber
        {
            get { return this.classNumber; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Class number can't be zero or negative!");
                }
                this.classNumber = value;
            }
        }

        public List<string> Comments { get; set; }

        public Student(string firstName, string lastName, byte? classNumber)
            : this(firstName, lastName, classNumber, null)
        {
        }
        public Student(string firstName, string lastName, params string[] comments)
            : this(firstName, lastName, null, comments)
        {
        }
        public Student(string firstName, string lastName, byte? classNumber, params string[] comments)
            : base(firstName, lastName)
        {
            this.ClassNumber = classNumber;

            this.Comments = new List<string>();
            if (comments != null) AddComment(comments);
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

            if (this.ClassNumber != null)
            {
                output.Append(" № " + this.ClassNumber);
            }

            if (this.Comments.Count != 0)
            {
                output.AppendFormat("\n #Comments: {0}", string.Join(", ", this.Comments));
            }

            return output.ToString();
        }
    }
}
