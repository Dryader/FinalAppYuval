using FinalAppYuval.Models;

namespace FinalAppYuval.Services;

public class GradeService : IGradeService
{
    private readonly string _apiUrl = "https://mohameom.dev.fast.sheridanc.on.ca/demo/grades.json";
    private readonly HttpClient _httpClient;

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
}