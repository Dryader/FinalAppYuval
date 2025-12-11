using FinalAppYuval.Models;
using System.Net.Http.Json;

namespace FinalAppYuval.Services;

public class GradeService : IGradeService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl = "https://mohameom.dev.fast.sheridanc.on.ca/demo/grades.json";

    public GradeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<StudentGrade>?> GetStudentsAndMarksAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<List<StudentGrade>>();
        }
        catch
        {
            return null;
        }
    }

    public async Task<StudentGrade?> GetStudentByIdAsync(int id)
    {
        var students = await GetStudentsAndMarksAsync();
        return students?.FirstOrDefault(s => s.Id == id);
    }
}

