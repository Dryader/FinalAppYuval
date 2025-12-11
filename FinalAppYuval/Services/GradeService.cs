using FinalAppYuval.Models;
using System.Net.Http.Json;

namespace FinalAppYuval.Services;

public class GradeService : IGradeService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<GradeService> _logger;
    private readonly IConfiguration _configuration;

    public GradeService(HttpClient httpClient, ILogger<GradeService> logger, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<List<StudentGrade>?> GetStudentsAndMarksAsync()
    {
        try
        {
            var apiUrl = _configuration["GradeApi:Url"];
            if (string.IsNullOrEmpty(apiUrl))
            {
                _logger.LogError("Grade API URL not configured");
                return null;
            }

            var response = await _httpClient.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"API returned {response.StatusCode}");
                return null;
            }

            return await response.Content.ReadAsAsync<List<StudentGrade>>();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error fetching students: {ex.Message}");
            return null;
        }
    }

    public async Task<StudentGrade?> GetStudentByIdAsync(int id)
    {
        try
        {
            var apiUrl = _configuration["GradeApi:Url"];
            if (string.IsNullOrEmpty(apiUrl))
            {
                _logger.LogError("Grade API URL not configured");
                return null;
            }

            var response = await _httpClient.GetAsync($"{apiUrl}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning($"Student {id} not found");
                return null;
            }

            return await response.Content.ReadAsAsync<StudentGrade>();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error fetching student: {ex.Message}");
            return null;
        }
    }
}

