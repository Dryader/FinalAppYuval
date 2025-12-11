namespace FinalAppYuval.Models;

public class GradeSummary
{
    public int TotalStudents { get; set; }
    public int PassedCount { get; set; }
    public int FailedCount { get; set; }
    public double AverageScore { get; set; }

    public double PassPercentage => TotalStudents > 0 ? PassedCount / (double)TotalStudents * 100 : 0;
    public double FailPercentage => TotalStudents > 0 ? FailedCount / (double)TotalStudents * 100 : 0;
}