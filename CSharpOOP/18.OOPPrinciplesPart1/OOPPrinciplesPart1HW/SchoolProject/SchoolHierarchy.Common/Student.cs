namespace SchoolHierarchy.Common
{
    using System;
    using System.Text;

    public class Student
        : Person, ICommentable
    {
        private byte? classNumber;
        private string comments = String.Empty;

        public string Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
        public byte? ClassNumber
        {
            get { return this.classNumber; }
            set
            {
                if (value < 1) throw new ArgumentOutOfRangeException("Class number can't be zero or negative!");
                this.classNumber = value;
            }
        }

        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }
        public Student(string firstName, string lastName, string comment)
            : this(firstName, lastName, null, comment)
        {
        }
        public Student(string firstName, string lastName, byte classNumber)
            : this(firstName, lastName, classNumber, String.Empty)
        {
        }
        public Student(string firstName, string lastName, byte? classNumber, string comment)
            : this(firstName, lastName)
        {
            this.ClassNumber = classNumber;
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
            var output = new StringBuilder(this.FirstName + " " + this.LastName);

            if (this.ClassNumber != null)
            {
                output.AppendFormat(" №{0}", this.ClassNumber);
            }

            if (!this.Comments.Equals(String.Empty))
            {
                output.AppendFormat(" ({0})", this.Comments);
            }

            return output.ToString();
        }
    }
}
