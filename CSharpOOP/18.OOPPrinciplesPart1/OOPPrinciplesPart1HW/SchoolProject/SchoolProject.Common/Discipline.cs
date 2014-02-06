namespace SchoolProject.Common
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
        public List<string> Comments { get; set; }

        public byte Lectures
        {
            get { return this.lectures; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Lectures can't be a negative number!");
                }
                this.lectures = value;
            }
        }

        public byte Exercises
        {
            get { return this.exercises; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Exercises can't be a negative number!");
                }
                this.exercises = value;
            }
        }

        public Discipline(string name)
            : this(name, 45, 30, null)
        {
        }
        public Discipline(string name, byte lectures, byte exercises, params string[] comments)
        {
            this.Name = name;
            this.Lectures = lectures;
            this.Exercises = exercises;

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
            var output = new StringBuilder
                (string.Format("{0} (L:{1} E:{2})", this.Name, this.Lectures, this.Exercises));

            if(this.Comments.Count != 0)
            {
                output.AppendFormat("\n #Comments: {0}", string.Join(", ", this.Comments));
            }

            return output.ToString();
        }
    }
}
