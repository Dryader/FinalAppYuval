using FinalAppYuval.Models;
using FinalAppYuval.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalAppYuval.Controllers;

public class GradeController : Controller
{
    private readonly IGradeService _gradeService;

    public GradeController(IGradeService gradeService)
    {
        _gradeService = gradeService;
    }

    public async Task<IActionResult> Index()
    {
        var students = await _gradeService.GetStudentsAndMarksAsync();
        return View(students ?? new List<StudentGrade>());
    }


    public async Task<IActionResult> Summary()
    {
        var students = await _gradeService.GetStudentsAndMarksAsync();

        if (students == null || students.Count == 0)
            return View(new GradeSummary
            {
                TotalStudents = 0,
                PassedCount = 0,
                FailedCount = 0,
                AverageScore = 0
            });

        var summary = new GradeSummary
        {
            TotalStudents = students.Count,
            PassedCount = students.Count(s => s.Status == "Pass"),
            FailedCount = students.Count(s => s.Status == "Fail"),
            AverageScore = students.Average(s => s.CalculatedTotal)
        };

        return View(summary);
    }
}