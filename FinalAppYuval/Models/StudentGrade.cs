namespace FinalAppYuval.Models;

public class StudentGrade
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Assignment1 { get; set; }
    public int Assignment2 { get; set; }
    public int Midterm { get; set; }
    public int Final { get; set; }

    public int CalculatedTotal => Assignment1 + Assignment2 + Midterm + Final;
    public string Status => CalculatedTotal >= 50 ? "Pass" : "Fail";
}