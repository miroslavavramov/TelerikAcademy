using System;

public class ExamResult
{
    private const int MinPossibleGrade = 0;

    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < MinPossibleGrade)
            {
                throw new ArgumentOutOfRangeException("Grade can't be less than the specified minimum.");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < MinPossibleGrade)
            {
                throw new ArgumentOutOfRangeException("Minimal grade can't be less than the specified minimum.");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value <= this.MinGrade)
            {
                throw new ArgumentOutOfRangeException("Maximal grade can't be less than or equal to the minimal.");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException("Comments can't be null or empty string.");
            }

            this.comments = value;
        }
    }
}
