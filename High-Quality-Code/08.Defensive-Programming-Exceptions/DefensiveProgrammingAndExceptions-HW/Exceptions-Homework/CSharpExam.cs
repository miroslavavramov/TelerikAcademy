using System;

public class CSharpExam : Exam
{
    private const int MinPossibleScore = 0;
    private const int MaxPossibleScore = 100;

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < MinPossibleScore)
            {
                throw new ArgumentOutOfRangeException("Exam score can't be smaller than the specified minimal score.");
            }

            if (value > MaxPossibleScore)
            {
                throw new ArgumentOutOfRangeException("Exam score can't be bigger than the specified maximal score.");
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        var result = new ExamResult(this.Score, MinPossibleScore, MaxPossibleScore, "Exam results calculated by score.");

        return result;
    }
}
