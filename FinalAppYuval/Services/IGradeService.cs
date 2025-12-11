using FinalAppYuval.Models;

namespace FinalAppYuval.Services;

public interface IGradeService
{
    Task<List<StudentGrade>?> GetStudentsAndMarksAsync();
}