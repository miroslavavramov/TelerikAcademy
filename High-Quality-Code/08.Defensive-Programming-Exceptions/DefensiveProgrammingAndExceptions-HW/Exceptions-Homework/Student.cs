using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private const int MinNameLength = 2;
    private const int MaxNameLength = 30;

    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public Student(string firstName, string lastName)
        : this(firstName, lastName, null)
    {
    }

    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName 
    {
        get 
        {
            return this.firstName;
        }

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Student's first name can't be null or whitespace");
            }

            if (value.Length < MinNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    "Student's first name can't be less than the specified minimum number of characters long.");
            }

            if (value.Length > MaxNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    "Student's first name can't be contain more than the specified maximum number of characters.");
            }

            if (value.Any(x => !char.IsLetter(x)))
            {
                throw new ArgumentOutOfRangeException("Student's first name must contain only letters!");
            }

            this.firstName = value;
        } 
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Student's last name can't be null or whitespace");
            }

            if (value.Length < MinNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    "Student's last name can't be less than the specified minimum number of characters long.");
            }

            if (value.Length > MaxNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    "Student's first name can't be contain more than the specified maximum number of characters.");
            }

            if (value.Any(x => !char.IsLetter(x)))
            {
                throw new ArgumentOutOfRangeException("Student's last name must contain only letters!");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams 
    {
        get 
        {
            return this.exams;
        }

        set
        {
            this.exams = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException("Exams can't be null.");
        }

        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Exams can't be an empty list.");
        }

        var results = new List<ExamResult>();

        results.AddRange(this.Exams.Select(x => x.Check()));

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException("Exams can't be null.");
        }

        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Exams can't be an empty list.");
        }

        double[] examScore = new double[this.Exams.Count];

        IList<ExamResult> examResults = this.CheckExams();

        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
