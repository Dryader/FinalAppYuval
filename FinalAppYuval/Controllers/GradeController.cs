using FinalAppYuval.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalAppYuval.Controllers;

public class GradeController : Controller
{
    private readonly IGradeService _gradeService;
    private readonly ILogger<GradeController> _logger;

    public GradeController(IGradeService gradeService, ILogger<GradeController> logger)
    {
        _gradeService = gradeService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var students = await _gradeService.GetStudentsAndMarksAsync();
        
        if (students == null)
        {
            TempData["Error"] = "Failed to load student grades. Please try again later.";
            return View(new List<StudentGrade>());
        }

        return View(students);
    }

    public async Task<IActionResult> Details(int id)
    {
        var student = await _gradeService.GetStudentByIdAsync(id);
        
        if (student == null)
        {
            TempData["Error"] = $"Student with ID {id} not found.";
            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }
}