using System;

public class SimpleMathExam : Exam
{
    private const int MinPossibleProblemsSolved = 0;
    private const int MaxPossibleProblemsSolved = 2;

    private int problemsSolved;
    
    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved 
    {
        get 
        {
            return this.problemsSolved;
        }
        
        private set 
        {
            if (value < MinPossibleProblemsSolved)
            {
                throw new ArgumentOutOfRangeException("Number of problems can't be smaller than specified minimum.");
            }

            if (value > MaxPossibleProblemsSolved)
            {
                throw new ArgumentOutOfRangeException("Number of problems can't be bigger than specified maximum.");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        ExamResult result;

        if (this.ProblemsSolved == MinPossibleProblemsSolved)
        {
            result = new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == MaxPossibleProblemsSolved)
        {
            result = new ExamResult(6, 2, 6, "Excellent result: all tasks solved.");
        }
        else
        {
            result = new ExamResult(4, 2, 6, "Average result: half the tasks solved.");
        }

        return result;
    }
}
